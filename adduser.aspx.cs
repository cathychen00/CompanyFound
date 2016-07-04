using System;
using System.Web.UI;

/// <summary>
/// 添加修改用户页面
/// </summary>
public partial class adduser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {
                string id = Request.QueryString["id"];
                //修改
                if (!string.IsNullOrEmpty(id))
                {
                    this.btnAdd.Visible = false;
                    this.rpwd.Visible = false;
                    this.tr_checkName.Visible = false;
                    InitUserInfo(id);
                }
                //新增
                else
                {
                    this.btnUpdate.Visible = false;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='Default.aspx'", true);
                return;
            }
        }
    }

    #region 添加用户
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (userpwd.Text != userpwd1.Text)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您输入的密码不一致！')", true);
            return;
        }

        bool exist = UserInfoDal.Exist(this.username.Text);
        if (exist)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('对不起，该用户名已经注册！请更换用户名再进行注册！！');location='adduser.aspx'", true);
        }

        bool result = UserInfoDal.Add(username.Text, Md5.Encrypt(userpwd.Text), int.Parse(userlevel.SelectedValue), int.Parse(usersex.SelectedValue));
        if (result)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('数据添加成功');location='adduser.aspx'", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('数据添加失败');location='javascript:history.go(-1)'", true);
        }
    }

    /// <summary>
    /// 校验用户名是否已经存在
    /// </summary>
    protected void btnCheckName_Click(object sender, EventArgs e)
    {
        bool exist = UserInfoDal.Exist(username.Text);
        if (exist)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('对不起，该用户名已经注册！');location='adduser.aspx'", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('此用户名可以注册！')", true);
        }
    }

    #endregion

    #region 修改用户
    /// <summary>
    /// 初始化用户信息
    /// </summary>
    /// <param name="id"></param>
    private void InitUserInfo(string id)
    {
        UserInfo userInfo = UserInfoDal.Get(Convert.ToInt32(id));
        if (userInfo.userinfoID == 0)
        {
            return;
        }

        this.username.Text = userInfo.UserName;
        this.usersex.SelectedValue = userInfo.usersexID.ToString();
        this.userlevel.SelectedValue = userInfo.userlevelID.ToString();

        if (Session["userlevel"].ToString() == "普通用户")
        {
            this.rpwd.Visible = false;

            this.tr_checkName.Visible = false;
            this.tr_userlevel.Visible = false;
        }
        else if (Session["userlevel"].ToString() == "管理员")
        {
            this.rpwd.Visible = false;
            this.btnAdd.Visible = false;
        }
    }

    /// <summary>
    /// 修改用户信息
    /// </summary>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string id = Request.QueryString["id"];

        UserInfo userInfo = new UserInfo();
        userInfo.UserName = username.Text;
        userInfo.UserPwd = Md5.Encrypt(userpwd.Text);
        userInfo.usersexID = Convert.ToInt16(usersex.SelectedValue);
        userInfo.userlevelID = Convert.ToInt16(userlevel.SelectedValue);
        userInfo.userinfoID = Convert.ToInt32(id);

        bool result = UserInfoDal.Update(userInfo);
        if (result)
        {
            string url;
            url = "chaxun.aspx?查询类别=" + lb
             + "&查询条件=" + tj + "&查询内容=" + lr + "&查询内容1=" + lr1 + "&查询内容2=" + lr2;
            Response.Redirect(url);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('更新记录失败！！');location='javascript:history.go(-1)'", true);
        }
    }
    #endregion
}
