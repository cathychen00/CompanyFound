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

public partial class ADDyun : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {


            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {

                SqlData da = new SqlData();
                this.user.Text = Session["username"].ToString();
                string id = Request.QueryString["id"];
                if (id != null && id.ToString() != string.Empty)
                {
                    Button2.Visible = false;
                    string sqlstr = "select * from gy_yun where gy_yunID=" + id + " ";

                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.begintime.Text = read["gy_y_bgtime"].ToString();
                        this.endtime.Text = read["gy_y_endtime"].ToString();
                        this.client.SelectedValue = read["gy_clientID"].ToString();
                        this.carno.Text = read["gy_y_carno"].ToString();
                        this.totalcar.Text = read["gy_y_totalcar"].ToString();
                        this.totalamount.Text = read["gy_y_totalamount"].ToString();
                        this.price.Text = read["gy_y_price"].ToString();
                        this.mileage.Text = read["gy_y_mileage"].ToString();
                        this.total.Text = read["gy_y_total"].ToString();
                        this.begin.Text = read["gy_y_bgarea"].ToString();
                        this.end.Text = read["gy_y_endarea"].ToString();
                        this.remark.Text = read["gy_y_remark"].ToString();



                        read.Close();
                    }
                   
                }
                else
                {
                    this.Button3.Visible = false;

                }
            }


                else
                {
                    ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='default.aspx'", true);
                    return;
                }
            }
        }
    
        
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
       
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select sum(gy_x_amount) AS totalamount,count(gy_x_amount) as totalcar from gy_xiao where gy_x_time between '" + this.begintime.Text + "' and  '" + this.endtime.Text + "' and gy_clientID='" + this.client.Text + "' and gy_x_carno='" + this.carno.Text + "'");
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
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
     
        decimal x = Convert.ToDecimal(this.totalamount.Text) * Convert.ToDecimal(this.price.Text) * Convert.ToDecimal(this.mileage.Text);
        this.total.Text = x.ToString();    
        }  
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
         
        string userinfoID = Session["userinfoID"].ToString();
        SqlData da = new SqlData();
        string addxiao = "insert into  gy_yun(gy_y_bgtime,gy_y_endtime,gy_clientID,gy_y_carno,gy_y_totalcar,gy_y_totalamount,gy_y_price,gy_y_mileage,gy_y_total,gy_y_bgarea,gy_y_endarea,gy_y_remark,userinfoID)values('" + this.begintime.Text + "','" + this.endtime.Text + "','" + this.client.SelectedValue + "','" + this.carno.Text + "','" + this.totalcar.Text + "','" + this.totalamount.Text + "','" + Convert.ToString(this.price.Text) + "','" + Convert.ToString(this.mileage.Text) + "','" + Convert.ToString(this.total.Text) + "','" + this.begin.Text + "','" + this.end.Text + "','" + this.remark.Text + "','"+userinfoID+"')";
        bool add = da.ExceSQL(addxiao);
        if (add == true)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录成功！');location='addyun.aspx'", true);
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录失败！')", true);
        }  
        }   
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string userinfoID = Session["userinfoID"].ToString();
        string id = Request.QueryString["id"];
        SqlData da = new SqlData();
        string update = "update gy_yun set gy_y_bgtime='" + this.begintime.Text + "',gy_y_endtime='" + this.endtime.Text + "',gy_clientID='" + this.client.SelectedValue + "',gy_y_carno='" + this.carno.Text + "',gy_y_totalcar='" + this.totalcar.Text + "',gy_y_totalamount='" + this.totalamount.Text + "',gy_y_price='" + Convert.ToString(this.price.Text) + "',gy_y_mileage='" + Convert.ToString(this.mileage.Text) + "',gy_y_total='" + Convert.ToString(this.total.Text) + "',gy_y_bgarea='" + this.begin.Text + "',gy_y_endarea='" + this.end.Text + "',gy_y_remark='" + this.remark.Text + "',userinfoID='" + userinfoID + "' where gy_yunID='"+id+"' ";
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
