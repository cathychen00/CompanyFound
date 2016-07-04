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
public partial class Adduser : System.Web.UI.UserControl
{
   
         protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userlevel"] == null)
        {
            Response.Write("<script lanuage=javascript>alert('您的权限不够，不能访问此页！');location='javascript:history.go(-1)'</script>");
            return;
        }
          

        
    }
   
    protected void okbtn_Click(object sender, EventArgs e)
    {

        if (this.userpwd.Text != this.userpwd1.Text)
        {
            Response.Write("<script lanuage=javascript>alert('您输入的密码不一致！');location='javascript:history.go(-1)'</script>");
        }
        SqlData da = new SqlData();
        string useradd = "insert into userinfo(username,userpwd,userlevelID,usersexID)values('" + this.username.Text + "','" +da.Encrypt(this.userpwd.Text) + "','" + this.userlevel.SelectedValue + "','" + this.usersex.SelectedValue + "')";
        bool add = da.ExceSQL(useradd);
        if (add == true)
        {
            Response.Write("<script lanuage=javascript>alert('注册成功！');</script>");
        }
        else
        {
            Response.Write("<script lanuage=javascript>alert('注册失败！');location='javascript:history.go(-1)'</script>");
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
                Response.Write("<script lanuage=javascript>alert('对不起，该用户名已经注册！');location='adduser.aspx'</script>");
            }
        }
        else
        {
            Response.Write("<script lanuage=javascript>alert('此用户名可以注册！');</script>");
        }
        read.Close();

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminindex.aspx");
    }
    
}
