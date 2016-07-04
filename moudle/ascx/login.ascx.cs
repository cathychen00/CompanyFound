using System;
using System.Web.UI;
using System.Data.SqlClient;

/// <summary>
/// 登录控件
/// </summary>
public partial class login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //登录事件
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string userName = username.Text.Trim();
        string passWord = password.Text.Trim();
        if (string.IsNullOrEmpty(userName))
        {
            Response.Write("<script lanuage=javascript>alert('请输入用户名！');location='javascript:history.go(-1)'</script>");
            return;
        }
        if (string.IsNullOrEmpty(passWord))
        {
            Response.Write("<script lanuage=javascript>alert('请输入密码！');location='javascript:history.go(-1)'</script>");
            return;
        }

        string sql = string.Format("SELECT *,userlevelname FROM [userinfo]A,[gy_Userlevel]B where A.userlevelID=B.userlevelID AND username='{0}' and userpwd='{1}'", userName, Md5.Encrypt(passWord));
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead(sql);
        read.Read();
        if (read.HasRows)
        {
            string userlevelname = Convert.ToString(read["userlevelname"]);
            Session["username"] = this.username.Text;
            Session["password"] = this.password.Text;
            Session["userlevel"] = userlevelname;
            Session["userinfoID"] = read["userinfoID"];

            Page.Response.Redirect("chaxun.aspx");
        }
        else
        {
            Response.Write("<script lanuage=javascript>alert('用户名或密码有误！');location='javascript:history.go(-1)'</script>");
            return;
        }
    }
}
