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

public partial class ADDxiao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
           
            SqlData da = new SqlData();
            string id = Request.QueryString["id"];
            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {
                this.user.Text = Session["username"].ToString();
                if (id != null && id.ToString() != string.Empty)
                {
                    this.botton2.Visible = false;
                    this.user.Text = Session["username"].ToString();
                    string sqlstr = "select * from gy_xiao where gy_xiaoID=" + id + " ";

                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.time.Text = read["gy_x_time"].ToString();
                        this.carno.Text = read["gy_x_carno"].ToString();
                        this.voucher.Text = read["gy_x_voucher"].ToString();
                        this.client.SelectedValue = read["gy_clientID"].ToString();
                        this.amount.Text = read["gy_x_amount"].ToString();
                        this.price.Text = read["gy_x_price"].ToString();
                        this.total.Text = read["gy_x_total"].ToString();
                        this.DropDownList1.SelectedValue = read["jsID"].ToString();
                        this.remark.Text = read["gy_x_remark"].ToString();


                        read.Close();
                    }
                }
                else
                {
                    this.botton3.Visible = false;
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='default.aspx'", true);
                return;
            }
        }
    }
    protected void botton2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
        
        string userinfoID = Session["userinfoID"].ToString();
        SqlData da = new SqlData();
        string addxiao = "insert into gy_xiao(gy_x_time,gy_x_carno,gy_x_voucher,gy_clientID,gy_x_amount,gy_x_price,gy_x_total,jsID,gy_x_remark,userinfoID)values('" + this.time.Text + "','" + this.carno.Text + "','" + this.voucher.Text + "','" + this.client.SelectedValue + "','" + this.amount.Text + "','" + Convert.ToString(this.price.Text) + "','" + Convert.ToString(this.total.Text) + "','" + this.DropDownList1.SelectedValue + "','" + this.remark.Text + "','"+userinfoID+"')";
        bool add = da.ExceSQL(addxiao);
        if (add == true)
        {

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录成功！');location='addxiao.aspx'", true);
        }
        else
        {

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录失败！')", true);
        }   
        } 
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
        
        decimal x = Convert.ToDecimal(this.amount.Text) * Convert.ToDecimal(this.price.Text);
        this.total.Text = x.ToString();    
        } 
    }
    protected void botton3_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string userinfoID = Session["userinfoID"].ToString();
        string id = Request.QueryString["id"];
        SqlData da = new SqlData();
        string update = "update gy_xiao set gy_x_time='" + this.time.Text + "',gy_x_carno='" + this.carno.Text + "',gy_x_voucher='" + this.voucher.Text + "',gy_clientID='" + this.client.SelectedValue + "',gy_x_amount='" + this.amount.Text + "',gy_x_price='" + Convert.ToString(this.price.Text) + "',gy_x_total='" + Convert.ToString(this.total.Text) + "',jsID='" + this.DropDownList1.SelectedValue + "',gy_x_remark='" + this.remark.Text + "',userinfoID='" + userinfoID + "' where gy_xiaoID='"+id+"'";
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
