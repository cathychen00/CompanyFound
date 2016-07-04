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

public partial class addclient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            
            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {
                SqlData da = new SqlData();
                
                string id = Request.QueryString["id"];
                if (id != null && id.ToString() != string.Empty)
                {
                    Button1.Visible = false;
                    string sqlstr = "select * from gy_client where gy_clientID=" + id + " ";

                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.username.Text = read["gy_c_name"].ToString();
                        this.phone.Text = read["gy_c_phone"].ToString();
                        this.addres.Text = read["gy_c_address"].ToString();
                        this.E_mail.Text = read["gy_c_Email"].ToString();
                        this.remark.Text = read["gy_c_remark"].ToString();

                        read.Close();
                       



                    }
                }
                else
                {
                    this.Button2.Visible = false;
                }

            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='default.aspx'", true);
                return;
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select * from gy_client where gy_c_name='" + this.username.Text + "'");
        read.Read();
        if (read.HasRows)
        {
            if (this.username.Text == read["username"].ToString())
            {
                
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('对不起，该用户名已经注册！')", true);
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
        if (Page.IsValid)
        {
        
        SqlData da = new SqlData();
        string useradd = "insert into gy_client (gy_c_name,gy_c_phone,gy_c_address,gy_c_Email,gy_c_remark)values('" + this.username.Text + "','" + this.phone.Text + "','" + this.addres.Text + "','" + this.E_mail.Text + "','" + this.remark.Text + "')";
        bool add = da.ExceSQL(useradd);
        if (add == true)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('数据添加成功');location='addclient.aspx'", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('注册失败！')", true);
           
        }
       
    }   
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string id = Request.QueryString["id"];
        SqlData da = new SqlData();
        string update = "update gy_client set gy_c_name='" + this.username.Text + "',gy_c_phone='" + this.phone.Text + "',gy_c_address='" + this.addres.Text + "',gy_c_Email='" + this.E_mail.Text + "',gy_c_remark='" + this.remark.Text + "' where gy_clientID='"+id+"'";
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

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('更新记录失败！')", true);
           
        }
        
    }
    

}
