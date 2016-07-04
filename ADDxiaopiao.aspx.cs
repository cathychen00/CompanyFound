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

public partial class ADDxiaopiao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {


            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {
                this.user.Text = Session["username"].ToString();
                SqlData da = new SqlData();
                string id = Request.QueryString["id"];

                if (id != null && id.ToString() != string.Empty)
                {
                    this.Button2.Visible = false;
                   
                    string sqlstr = "select * from gy_xiao_billno where gy_xiao_billnoID=" + id + " ";

                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.client.SelectedValue = read["gy_clientID"].ToString();
                        this.begintime.Text = read["gy_x_b_bgtime"].ToString();
                        this.endtime.Text = read["gy_x_b_endtime"].ToString();
                        this.totalcar.Text = read["gy_x_b_totalcar"].ToString();
                        this.totalamount.Text = read["gy_x_b_totalamount"].ToString();
                        this.bill.Text = read["gy_x_b_billno"].ToString();
                        this.gathering.Text = read["gy_x_b_gathering"].ToString();
                        this.remark.Text = read["gy_x_b_remark"].ToString();
                        read.Close();

                    }


                }
                else
                {
                    this.updata.Visible = false;
                }

            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='default.aspx'", true);
                return;
            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
       
        string userinfoID = Session["userinfoID"].ToString();
        SqlData da = new SqlData();
        string addxiaopiao = "insert into gy_xiao_billno(gy_clientID,gy_x_b_bgtime,gy_x_b_endtime,gy_x_b_totalcar,gy_x_b_totalamount,gy_x_b_billno,gy_x_b_totalmoney,gy_x_b_gathering,gy_x_b_remark,userinfoID)values('" + this.client.SelectedValue + "','" + this.begintime.Text + "','" + this.endtime.Text + "','" + this.totalcar.Text + "','" + this.totalamount.Text + "','" + this.bill.Text + "','" + this.totalmoney.Text + "','" + this.gathering.Text + "','" + this.remark.Text + "','"+userinfoID+"')";
        bool add = da.ExceSQL(addxiaopiao);
        if (add == true)
        {

            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录成功！');location='addxiaopiao.aspx'", true);
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
         
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select sum(gy_x_amount) AS totalamount,count(gy_x_amount) as totalcar from gy_xiao where gy_x_time between '" + this.begintime.Text + "' and  '" + this.endtime.Text + "' and gy_clientID='" + this.client.Text + "'");
        read.Read();
        if (read.HasRows)
        {
            this.totalcar.Text = Convert.ToString(read["totalcar"]);
            this.totalamount.Text = Convert.ToString(read["totalamount"]);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('未能查到相关记录！请确认输入是否有误！')", true);
            return;
        }   
        }  
    }
    protected void total_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string userinfoID = Session["userinfoID"].ToString();
        string id = Request.QueryString["id"];
        SqlData da = new SqlData();
        string update = "update gy_xiao_billno set gy_clientID='" + this.client.SelectedValue + "',gy_x_b_bgtime='" + this.begintime.Text + "',gy_x_b_endtime='" + this.endtime.Text + "',gy_x_b_totalcar='" + this.totalcar.Text + "',gy_x_b_totalamount='" + this.totalamount.Text + "',gy_x_b_billno='" + this.bill.Text + "',gy_x_b_totalmoney='" + this.totalmoney.Text + "',gy_x_b_gathering='" + this.gathering.Text + "',gy_x_b_remark='" + this.remark.Text + "',userinfoID='" + userinfoID + "'where gy_xiao_billnoID='"+id+"' ";
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
