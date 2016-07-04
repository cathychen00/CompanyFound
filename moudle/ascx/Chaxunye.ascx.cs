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
using System.Text;
using System.Data.SqlClient;


public partial class moudle_ascx_Cha : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {


        this.DropDownList3.Visible = false;
        this.TextBox1.Visible = false;
        this.TextBox2.Visible = false;
        this.TextBox3.Visible = false;
        this.Label1.Visible = false;
        this.Label2.Visible = false;
        this.Label3.Visible = false;

    }

    protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
    {
        this.Label1.Text = "";
        this.Label2.Text = "";
        this.Label3.Text = "";
        SqlData sd = new SqlData();


        if (DropDownList2.SelectedValue.ToString() == "all")
        {
            this.Label3.Visible = false;
            this.DropDownList3.Visible = false;
            this.TextBox1.Visible = false;
            this.TextBox2.Visible = false;
            this.TextBox3.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;


        }
        else if (DropDownList2.SelectedValue.ToString() == "xl" || DropDownList2.SelectedValue.ToString() == "xl1")
        {
            if (DropDownList2.SelectedItem.ToString() == "按产地查询")
            {
                this.Label3.Text = "产地";

                SqlDataReader sdr = sd.ExceRead("select k_name from gy_KName");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "k_name";
                this.DropDownList3.DataValueField = "k_name";
                this.DropDownList3.DataBind();
            }
            else if (DropDownList2.SelectedItem.ToString() == "操作员")
            {
                this.Label3.Text = "操作员";
                SqlDataReader sdr = sd.ExceRead("select username from userinfo");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "username";
                this.DropDownList3.DataValueField = "username";
                this.DropDownList3.DataBind();
            }
            else if (DropDownList2.SelectedItem.ToString() == "按销售单位查询")
            {
                this.Label3.Text = "销售单位";
                SqlDataReader sdr = sd.ExceRead("select gy_c_name from gy_client");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "gy_c_name";
                this.DropDownList3.DataValueField = "gy_c_name";
                this.DropDownList3.DataBind();
            }
            else if (DropDownList2.SelectedItem.ToString() == "按顾客单位名称查询")
            {
                this.Label3.Text = "单位名称";
                SqlDataReader sdr = sd.ExceRead("select gy_c_name from gy_client");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "gy_c_name";
                this.DropDownList3.DataValueField = "gy_c_name";
                this.DropDownList3.DataBind();
            }

            else if (DropDownList2.SelectedItem.ToString() == "按产地单位名称查询")
            {
                this.Label3.Text = "单位名称";
                SqlDataReader sdr = sd.ExceRead("select k_name from gy_KName");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "K_name";
                this.DropDownList3.DataValueField = "K_name";
                this.DropDownList3.DataBind();
            }
            this.Label3.Visible = true;
            this.DropDownList3.Visible = true;
            this.TextBox1.Visible = false;
            this.TextBox2.Visible = false;
            this.TextBox3.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;

        }
        else if (DropDownList2.SelectedValue.ToString() == "1TextBox" || DropDownList2.SelectedValue.ToString() == "1TextBox1" || DropDownList2.SelectedValue.ToString() == "1TextBox2")
        {
            if (DropDownList2.SelectedItem.ToString() == "按时间查询")
            {
                this.Label1.Text = "时间";
            }
            else if (DropDownList2.SelectedItem.ToString() == "按凭证号查询")
            {
                this.Label1.Text = "凭证号";
            }

            else if (DropDownList2.SelectedItem.ToString() == "按车号查询")
            {
                this.Label1.Text = "车号";
            }
            else if (DropDownList2.SelectedItem.ToString() == "按托运人查询")
            {
                this.Label1.Text = "托运人";
            }

            this.Label1.Visible = true;
            this.TextBox1.Visible = true;
            this.Label3.Visible = false;
            this.DropDownList3.Visible = false;

            this.TextBox2.Visible = false;
            this.TextBox3.Visible = false;

            this.Label2.Visible = false;
            this.Label3.Visible = false;
        }
        else if (DropDownList2.SelectedValue.ToString() == "2TextBox")
        {
            if (DropDownList2.SelectedItem.ToString() == "按时间段查询")
            {
                this.Label2.Text = "时间段";
            }

            this.Label2.Visible = true;
            this.TextBox2.Visible = true;
            this.TextBox3.Visible = true;
            this.Label3.Visible = false;
            this.DropDownList3.Visible = false;
            this.TextBox1.Visible = false;

            this.Label1.Visible = false;

            this.Label3.Visible = false;

        }
        else if (DropDownList2.SelectedValue.ToString() == "3TextBox")
        {
            if (DropDownList2.SelectedItem.ToString() == "按车号，时间段查询")
            {
                this.Label1.Text = "车号";
                this.Label2.Text = "时间段";

            }

            this.Label1.Visible = true;
            this.TextBox1.Visible = true;
            this.Label2.Visible = true;
            this.TextBox2.Visible = true;
            this.TextBox3.Visible = true;
            this.Label3.Visible = false;
            this.DropDownList3.Visible = false;



        }
        else if (DropDownList2.SelectedValue.ToString() == "xl2TextBox")
        {

            if (DropDownList2.SelectedItem.ToString() == "按产地，时间段查询")
            {
                this.Label2.Text = "时间段";
                this.Label3.Text = "产地";
                SqlDataReader sdr = sd.ExceRead("select k_name from gy_KName");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "k_name";
                this.DropDownList3.DataValueField = "k_name";
                this.DropDownList3.DataBind();

            }
            else if (DropDownList2.SelectedItem.ToString() == "按销售单位，时间段查询")
            {
                this.Label2.Text = "时间段";
                this.Label3.Text = "销售单位";
                SqlDataReader sdr = sd.ExceRead("select gy_c_name from gy_client");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "gy_c_name";
                this.DropDownList3.DataValueField = "gy_c_name";
                this.DropDownList3.DataBind();
            }
            else if (DropDownList2.SelectedItem.ToString() == "按销售单位，起始时间段查询")
            {
                this.Label2.Text = "起始时间段";
                this.Label3.Text = "销售单位";
                SqlDataReader sdr = sd.ExceRead("select gy_c_name from gy_client");

                this.DropDownList3.DataSource = sdr;
                this.DropDownList3.DataTextField = "gy_c_name";
                this.DropDownList3.DataValueField = "gy_c_name";
                this.DropDownList3.DataBind();
            }

            this.DropDownList3.Visible = true;
            this.Label3.Visible = true;
            this.Label2.Visible = true;
            this.TextBox2.Visible = true;
            this.TextBox3.Visible = true;
            this.TextBox1.Visible = false;
            this.Label1.Visible = false;


        }
        else if (DropDownList2.SelectedValue.ToString() == "all")
        {
            this.Label3.Visible = false;
            this.DropDownList3.Visible = false;
            this.TextBox1.Visible = false;
            this.TextBox2.Visible = false;
            this.TextBox3.Visible = false;
            this.Label1.Visible = false;
            this.Label2.Visible = false;
            this.Label3.Visible = false;


        }




    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.Label1.Text = null;
        this.Label2.Text = null;
        this.Label3.Text = null;
        string State = DropDownList1.SelectedValue.ToString();
        switch (State)
        {
            case "购进信息":

                this.DropDownList2.Items.Clear();

                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按产地查询", this.DropDownList2.DataValueField = "xl")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间查询", this.DropDownList2.DataValueField = "1TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间段查询", this.DropDownList2.DataValueField = "2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按产地，时间段查询", this.DropDownList2.DataValueField = "xl2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "操作员", this.DropDownList2.DataValueField = "xl1")); ;
                break;
            case "销售信息":


                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按销售单位查询", this.DropDownList2.DataValueField = "xl")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间查询", this.DropDownList2.DataValueField = "1TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间段查询", this.DropDownList2.DataValueField = "2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按凭证号查询", this.DropDownList2.DataValueField = "1TextBox1")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按销售单位，时间段查询", this.DropDownList2.DataValueField = "xl2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "操作员", this.DropDownList2.DataValueField = "xl1")); ;

                break;
            case "销售票据":


                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按销售单位查询", this.DropDownList2.DataValueField = "xl")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间查询", this.DropDownList2.DataValueField = "1TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间段查询", this.DropDownList2.DataValueField = "2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按销售单位，时间段查询", this.DropDownList2.DataValueField = "xl2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "操作员", this.DropDownList2.DataValueField = "xl1")); ;

                break;
            case "运输汇总":


                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按销售单位查询", this.DropDownList2.DataValueField = "xl")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按车号查询", this.DropDownList2.DataValueField = "1TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按销售单位，时间段查询", this.DropDownList2.DataValueField = "xl2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按车号，时间段查询", this.DropDownList2.DataValueField = "3TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间查询", this.DropDownList2.DataValueField = "1TextBox1")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间段查询", this.DropDownList2.DataValueField = "2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "操作员", this.DropDownList2.DataValueField = "xl1")); ;

                break;
            case "火车皮纪录":


                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按车号查询", this.DropDownList2.DataValueField = "1TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按托运人查询", this.DropDownList2.DataValueField = "1TextBox1")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按车号，时间段查询", this.DropDownList2.DataValueField = "3TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间查询", this.DropDownList2.DataValueField = "1TextBox2")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按时间段查询", this.DropDownList2.DataValueField = "2TextBox")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "操作员", this.DropDownList2.DataValueField = "xl")); ;

                break;


            case "产地信息":


                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按产地单位名称查询", this.DropDownList2.DataValueField = "xl")); ;
                break;
            case "顾客信息":


                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询全部信息", this.DropDownList2.DataValueField = "all")); ;
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "按顾客单位名称查询", this.DropDownList2.DataValueField = "xl")); ;

                break;
            case "用户信息":
                this.DropDownList2.Items.Clear();
                this.DropDownList2.Items.Add(new ListItem(this.DropDownList2.DataTextField = "查询,修改用户信息", this.DropDownList2.DataValueField = "all")); ;
                break;


        }


    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string lb = null;
        string tj = null;
        lb = DropDownList1.SelectedItem.ToString();
        tj = DropDownList2.SelectedItem.ToString();
        string lr = null;
        string lr1 = null;
        string lr2 = null;
        string state = DropDownList2.SelectedItem.ToString();
        switch (state)
        {
            case "查询,修改用户信息":
                lr = "all";

                break;
            case "查询全部信息":
                lr = "all";
                break;
            case "按产地查询":
                lr = DropDownList3.SelectedItem.ToString();
                break;
            case "按时间查询":
                lr = TextBox1.Text.ToString();
                break;
            case "按时间段查询":
                lr = TextBox2.Text.ToString();
                lr1 = TextBox3.Text.ToString();
                break;
            case "按产地，时间段查询":
                lr = DropDownList3.SelectedItem.ToString();
                lr1 = TextBox2.Text.ToString();
                lr2 = TextBox3.Text.ToString();
                break;
            case "操作员":
                lr = DropDownList3.SelectedItem.ToString();
                break;
            case "按销售单位查询":
                lr = DropDownList3.SelectedItem.ToString();
                break;
            case "按凭证号查询":
                lr = TextBox1.Text.ToString();
                break;
            case "按销售单位，时间段查询":
                lr = DropDownList3.SelectedItem.ToString();
                lr1 = TextBox2.Text.ToString();
                lr2 = TextBox3.Text.ToString();
                break;
            case "按车号查询":
                lr = TextBox1.Text.ToString();
                break;
            case "按车号，时间段查询":
                lr = TextBox1.Text.ToString();
                lr1 = TextBox2.Text.ToString();
                lr2 = TextBox3.Text.ToString();
                break;
            case "按托运人查询":
                lr = TextBox1.Text.ToString();
                break;
            case "按顾客单位名称查询":
                lr = DropDownList3.SelectedItem.ToString();
                break;
            case "按产地单位名称查询":
                lr = DropDownList3.SelectedItem.ToString();
                break;
        }


        string url;
        url = "chaxun.aspx?查询类别=" + lb
         + "&查询条件=" + tj + "&查询内容=" + lr + "&查询内容1=" + lr1 + "&查询内容2=" + lr2;
        Response.Redirect(url);
    }
}