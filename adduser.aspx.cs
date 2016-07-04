using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
public partial class adduser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            SqlData da = new SqlData();




            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {
                string id = Request.QueryString["id"];

                if (id != null && id.ToString() != string.Empty)
                {

                    this.okbtn.Visible = false;
                    string sqlstr = "select * from userinfo where userinfoID=" + id + " ";
                    this.rpwd.Visible = false;
                    this.tr_jcname.Visible = false;
                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.username.Text = read["username"].ToString();

                        this.usersex.SelectedValue = read["usersexID"].ToString();
                        this.userlevel.SelectedValue = read["userlevelID"].ToString();
                    }

                    read.Close();



                    if (Session["userlevel"].ToString() == "普通用户")
                    {
                        this.rpwd.Visible = false;

                        this.tr_jcname.Visible = false;
                        this.tr_userlevel.Visible = false;

                    }


                    else if (Session["userlevel"].ToString() == "管理员")
                    {
                        this.rpwd.Visible = false;
                        this.okbtn.Visible = false;
                    }
                }
                else
                {
                    this.Button1.Visible = false;
                }

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='Default.aspx'", true);

                return;
            }
      
        }
    }
    
    protected void okbtn_Click(object sender, EventArgs e)
    {
    

            if (this.userpwd.Text != this.userpwd1.Text)
            {
               
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您输入的密码不一致！')", true);
            }
            SqlData da = new SqlData();
            SqlDataReader read = da.ExceRead("select * from userinfo where username='" + this.username.Text + "'");
            read.Read();
            if (read.HasRows)
            {
                if (this.username.Text == read["username"].ToString())
                {

                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('对不起，该用户名已经注册！请更换用户名再进行注册！！');location='adduser.aspx'", true);
                }
            }
            read.Close();
            
            string useradd = "insert into userinfo(UserName,UserPwd,userlevelID,usersexID)values('" + this.username.Text + "','"+Md5.Encrypt(this.userpwd.Text)+"','" + this.userlevel.SelectedValue + "','" + this.usersex.SelectedValue + "')";
            bool add = da.ExceSQL(useradd);
            if (add == true)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('数据添加成功');location='adduser.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('数据添加失败');location='javascript:history.go(-1)'", true);
            }       
         
        
    }
    protected void jcname_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select * from userinfo where username='" + this.username.Text + "'");
        read.Read();
        if (read.HasRows)
        {
            if (this.username.Text == read["username"].ToString())
            {
            
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('对不起，该用户名已经注册！');location='adduser.aspx'", true);
            }
        }
        else
        {
         
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('此用户名可以注册！')", true);
      
        }
        read.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string id = Request.QueryString["id"];
        SqlData da = new SqlData();
        string update = "update userinfo set username='" + this.username.Text + "',userpwd='" +Md5.Encrypt( this.userpwd.Text )+ "',usersexID='" + this.usersex.SelectedValue + "',userlevelID='"+this.userlevel.SelectedValue+"' where userinfoID='"+id+"'"; 
        bool up = da.ExceSQL(update);
        if (up == true)
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
}
