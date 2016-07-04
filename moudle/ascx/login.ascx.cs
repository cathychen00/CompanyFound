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


public partial class login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
    }

  
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
     
       
            
            SqlData da = new SqlData();
            SqlDataReader read = da.ExceRead("SELECT *,userlevelname FROM [userinfo]A,[gy_Userlevel]B where A.userlevelID=B.userlevelID AND username='" + this.username.Text + "' and userpwd='" + da.Encrypt(this.password.Text) + "'");
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
