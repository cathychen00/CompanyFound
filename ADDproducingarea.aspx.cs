using System;
using System.Web.UI;

/// <summary>
/// 新增修改产地信息
/// </summary>
public partial class ADDproducingarea : System.Web.UI.Page
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
                    btnAdd.Visible = false;
                    ProductArea area = ProductAreaDal.Get(Convert.ToInt32(id));
                    if (area.Id>0)
                    {
                        this.name.Text = area.Name;
                        this.phone.Text = area.Phone;
                        this.remark.Text = area.Remark;
                        this.btnAdd.Visible = false;
                    }
                }
                //添加
                else
                {
                    this.btnUpdate.Visible = false;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='default.aspx'", true);
                return;
            }
        }
    }


    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            ProductArea area = new ProductArea();
            area.Name = name.Text;
            area.Phone = phone.Text;
            area.Remark = remark.Text;

            bool result = ProductAreaDal.Add(area);
            if (result)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('注册成功！');location='addproducingarea.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('注册失败！')", true);
            }
        }
    }

    protected void btnCheck_Click(object sender, EventArgs e)
    {
        bool exist = ProductAreaDal.Exist(name.Text);
        if (exist)
        {

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('对不起，该用户名已经注册！');location='addproducingarea.aspx'", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('此用户名可以注册！')", true);
        }
    }


    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string id = Request.QueryString["id"];

        ProductArea area = new ProductArea
        {
            Id = Convert.ToInt32(id),
            Name = name.Text,
            Phone = phone.Text,
            Remark = remark.Text
        };

        bool result = ProductAreaDal.Update(area);

        if (result)
        {
            string url;
            url = "chaxun.aspx?查询类别=" + lb
             + "&查询条件=" + tj + "&查询内容=" + lr + "&查询内容1=" + lr1 + "&查询内容2=" + lr2;
            Response.Redirect(url);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('更新记录失败！')", true);
        }
    }
}
