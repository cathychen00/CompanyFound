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

public partial class ADDtrain : System.Web.UI.Page
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
                    Button1.Visible = false;
                    string sqlstr = "select * from gy_train where gy_trainID=" + id + " ";

                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.datetime.Text = read["gy_t_time"].ToString();
                        this.carNO.Text = read["gy_t_carno"].ToString();
                        this.shipper.Text = read["gy_t_shipper"].ToString();
                        this.beginarea.Text = read["gy_t_bgarea"].ToString();
                        this.consignee.Text = read["gy_t_consignee"].ToString();
                        this.totalamount.Text = read["gy_t_totalamount"].ToString();
                        this.factamount.Text = read["gy_t_realamount"].ToString();
                        this.carriage.Text = read["gy_t_carriage"].ToString();
                        this.djf.Text = read["gy_t_djf"].ToString();
                        this.yfk.Text = read["gy_t_yff"].ToString();
                        this.remark.Text = read["gy_t_remark"].ToString();
                        this.DropDownList1.SelectedValue = read["jsID"].ToString();


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
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            //执行需要的代码   
        

        string userinfoID = Session["userinfoID"].ToString();
        SqlData da = new SqlData();
        string useradd = "insert into gy_train(gy_t_time,gy_t_carno,gy_t_shipper,gy_t_bgarea,gy_t_consignee,gy_t_totalamount,gy_t_realamount,gy_t_carriage,jsID,gy_t_djf,gy_t_yff,gy_t_remark,userinfoID)values('" + this.datetime.Text + "','" + this.carNO.Text + "','" + this.shipper.Text + "','" + this.beginarea.Text + "','" + this.consignee.Text + "','" + this.totalamount.Text + "','" + this.factamount.Text + "','" + this.carriage.Text + "','" + this.DropDownList1.SelectedValue + "','"+this.djf.Text+"','"+this.yfk.Text+"','" + this.remark.Text + "','"+userinfoID+"')";
        bool add = da.ExceSQL(useradd);
        if (add == true)
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录成功！');location='addtrain.aspx'", true);

          
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录失败！')", true);

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
        string userinfoID = Session["userinfoID"].ToString();
        SqlData da = new SqlData();
        string update = "update gy_train set gy_t_time='" + this.datetime.Text + "',gy_t_carno='" + this.carNO.Text + "',gy_t_shipper='" + this.shipper.Text + "',gy_t_bgarea='" + this.beginarea.Text + "',gy_t_consignee='" + this.consignee.Text + "',gy_t_totalamount='" + this.totalamount.Text + "',gy_t_realamount='" + this.factamount.Text + "',gy_t_carriage='" + this.carriage.Text + "',gy_t_djf='"+this.djf.Text+"',gy_t_yff='"+this.yfk.Text+"',jsID='" + this.DropDownList1.SelectedValue + "',gy_t_remark='" + this.remark.Text + "',userinfoID='" + userinfoID + "' where gy_trainID='"+id+"'";
        
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
