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

public partial class ADDGOU1 : System.Web.UI.Page
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
                SqlDataReader km = da.ExceRead("select * from gy_KName");
                this.K_name.DataSource = km;
                this.K_name.DataTextField = "k_name";
                this.K_name.DataValueField = "k_ID";
                this.K_name.DataBind();
                km.Close();
                /*
                 SqlDataReader updata_js = da.ExceRead("select * from gy_js");

                 this.K_name.DataSource = updata_js;
                 this.K_name.DataTextField = "jsname";
                 this.K_name.DataValueField = "jsID";
                
                 this.K_name.DataBind();
                 updata_js.Close();
                */

                if (id != null && id.ToString() != string.Empty)
                {
                    Button1.Visible = false;
                    string sqlstr = "select * from gy_gou where gou_id=" + id + " ";

                    SqlDataReader read = da.ExceRead(sqlstr);
                    read.Read();
                    if (read.HasRows)
                    {
                        this.time.Text = read["gou_time"].ToString();
                        this.amount.Text = read["gou_amount"].ToString();
                        this.price.Text = read["gou_price"].ToString();
                        this.total.Text = read["gou_total"].ToString();
                        this.remark.Text = read["gou_remark"].ToString();
                        this.billno.Text = read["gou_billno"].ToString();
                        this.yfk.Text = read["gou_pqyment"].ToString();
                        string jsID = read["jsID"].ToString();
                        string kmID = read["k_ID"].ToString();

                        read.Close();
                        SqlDataReader sdr = da.ExceRead("select * from gy_KName");

                        this.K_name.DataSource = sdr;
                        this.K_name.DataTextField = "k_name";
                        this.K_name.DataValueField = "k_ID";

                        this.K_name.SelectedValue = kmID;
                        this.K_name.DataBind();
                        sdr.Close();
                        SqlDataReader xg_js = da.ExceRead("select * from gy_js ");

                        this.djs.DataSource = xg_js;
                        this.djs.DataTextField = "jsname";
                        this.djs.DataValueField = "jsID";
                        this.djs.SelectedValue = jsID;
                        this.djs.DataBind();
                        xg_js.Close();




                    }


                }
                else
                {
                    this.Button4.Visible = false;
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

            string userinfoID = Session["userinfoID"].ToString();
            SqlData da = new SqlData();
            string useradd = "insert into gy_gou(gou_time,k_ID,gou_amount,gou_price,gou_total,jsID,gou_billno,gou_pqyment,gou_remark,userinfoID)values('" + this.time.Text + "','" + this.K_name.SelectedValue + "','" + this.amount.Text + "','" + this.price.Text + "','" + this.total.Text + "','" + this.djs.SelectedValue + "','" + this.billno.Text + "','" + this.yfk.Text + "','" + this.remark.Text + "','" + userinfoID + "')";
            bool add = da.ExceSQL(useradd);
            if (add == true)
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('数据添加成功');location='addgou.aspx'", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('添加记录失败');location='addgou.aspx'", true);
            }

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {

            Double c = Convert.ToDouble(this.amount.Text) * Convert.ToDouble(this.price.Text);
            total.Text = c.ToString();

        }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];
        string userinfoID = Session["userinfoID"].ToString();
        string id = Request.QueryString["id"];
        SqlData da = new SqlData();
        string update = "update gy_Gou set gou_time='" + this.time.Text + "',k_ID='" + this.K_name.SelectedValue + "',gou_amount='" + this.amount.Text + "',gou_price='" + this.price.Text + "',gou_total='" + this.total.Text + "',jsID='" + this.djs.SelectedValue + "',gou_billno='" + this.billno.Text + "',gou_pqyment='" + this.yfk.Text + "',gou_remark='" + this.remark.Text + "',userinfoID='" + userinfoID + "' where gou_ID='" + id + "'";
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
            Response.Write("<script lanuage=javascript>alert('更新记录失败！');location='javascript:history.go(-1)'</script>");
        }

    }
}
