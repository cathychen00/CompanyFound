using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/// <summary>
/// 查询条件联动控件
/// </summary>
public partial class moudle_ascx_Cha : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ddl3.Visible = false;
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        TextBox3.Visible = false;
        Label1.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
    }

    #region 查询条件联动
    /// <summary>
    /// 选择一级查询条件
    /// </summary>
    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label1.Text = null;
        Label2.Text = null;
        Label3.Text = null;

        ddl2.Items.Clear();
        string state = ddl1.SelectedValue;
        switch (state)
        {
            case "购进信息":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按产地查询", "xl"));
                ddl2.Items.Add(new ListItem("按时间查询", "1TextBox"));
                ddl2.Items.Add(new ListItem("按时间段查询", "2TextBox"));
                ddl2.Items.Add(new ListItem("按产地，时间段查询", "xl2TextBox"));
                ddl2.Items.Add(new ListItem("操作员", "xl1"));
                break;

            case "销售信息":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按销售单位查询", "xl"));
                ddl2.Items.Add(new ListItem("按时间查询", "1TextBox"));
                ddl2.Items.Add(new ListItem("按时间段查询", "2TextBox"));
                ddl2.Items.Add(new ListItem("按凭证号查询", "1TextBox1"));
                ddl2.Items.Add(new ListItem("按销售单位，时间段查询", "xl2TextBox"));
                ddl2.Items.Add(new ListItem("操作员", "xl1"));

                break;

            case "销售票据":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按销售单位查询", "xl"));
                ddl2.Items.Add(new ListItem("按时间查询", "1TextBox"));
                ddl2.Items.Add(new ListItem("按时间段查询", "2TextBox"));
                ddl2.Items.Add(new ListItem("按销售单位，时间段查询", "xl2TextBox"));
                ddl2.Items.Add(new ListItem("操作员", "xl1"));

                break;

            case "运输汇总":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按销售单位查询", "xl"));
                ddl2.Items.Add(new ListItem("按车号查询", "1TextBox"));
                ddl2.Items.Add(new ListItem("按销售单位，时间段查询", "xl2TextBox"));
                ddl2.Items.Add(new ListItem("按车号，时间段查询", "3TextBox"));
                ddl2.Items.Add(new ListItem("按时间查询", "1TextBox1"));
                ddl2.Items.Add(new ListItem("按时间段查询", "2TextBox"));
                ddl2.Items.Add(new ListItem("操作员", "xl1"));

                break;

            case "火车皮纪录":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按车号查询", "1TextBox"));
                ddl2.Items.Add(new ListItem("按托运人查询", "1TextBox1"));
                ddl2.Items.Add(new ListItem("按车号，时间段查询", "3TextBox"));
                ddl2.Items.Add(new ListItem("按时间查询", "1TextBox2"));
                ddl2.Items.Add(new ListItem("按时间段查询", "2TextBox"));
                ddl2.Items.Add(new ListItem("操作员", "xl"));

                break;

            case "产地信息":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按产地单位名称查询", "xl"));
                break;

            case "顾客信息":
                ddl2.Items.Add(new ListItem("查询全部信息", "all"));
                ddl2.Items.Add(new ListItem("按顾客单位名称查询", "xl"));

                break;

            case "用户信息":
                ddl2.Items.Add(new ListItem("查询,修改用户信息", "all"));
                break;
        }
    }

    /// <summary>
    /// 选择二级查询条件
    /// </summary>
    protected void ddl2_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Label1.Text = "";
        Label2.Text = "";
        Label3.Text = "";
        Label1.Visible = false;
        Label2.Visible = false;
        Label3.Visible = false;
        TextBox1.Visible = false;
        TextBox2.Visible = false;
        TextBox3.Visible = false;
        ddl3.Visible = false;

        string ddlValue2 = ddl2.SelectedValue;
        string ddlText2 = ddl2.SelectedItem.ToString();

        SqlData sd = new SqlData();
        SqlDataReader dr= sd.ExceRead("select k_name from gy_KName");
        switch (ddlValue2)
        {
            case "all":
                break;

            case "xl":
            case "xl1":
                switch (ddlText2)
                {
                    case "按产地查询":
                        {
                            Label3.Text = "产地";
                            ddl3BindChandi();
                        }
                        break;

                    case "操作员":
                        {
                            Label3.Text = "操作员";
                            ddl3BindOperator();
                        }
                        break;

                    case "按销售单位查询":
                    case "按顾客单位名称查询":
                        {
                            Label3.Text = "单位名称";
                            ddl3BindClient();
                        }
                        break;

                    case "按产地单位名称查询":
                        {
                            Label3.Text = "单位名称";
                            ddl3BindChandi();
                        }
                        break;
                }

                Label3.Visible = true;
                ddl3.Visible = true;
                break;

            case "1TextBox":
            case "1TextBox1":
            case "1TextBox2":
                switch (ddlText2)
                {
                    case "按时间查询":
                        Label1.Text = "时间";
                        break;
                    case "按凭证号查询":
                        Label1.Text = "凭证号";
                        break;
                    case "按车号查询":
                        Label1.Text = "车号";
                        break;
                    case "按托运人查询":
                        Label1.Text = "托运人";
                        break;
                }

                Label1.Visible = true;
                TextBox1.Visible = true;
                break;

            case "2TextBox":
                if (ddlText2 == "按时间段查询")
                {
                    Label2.Text = "时间段";
                }

                Label2.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                
                break;

            case "3TextBox":
                if (ddlText2 == "按车号，时间段查询")
                {
                    Label1.Text = "车号";
                    Label2.Text = "时间段";

                }

                Label1.Visible = true;
                TextBox1.Visible = true;
                Label2.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                break;

            case "xl2TextBox":
                switch (ddlText2)
                {
                    case "按产地，时间段查询":
                        Label2.Text = "时间段";
                        Label3.Text = "产地";
                        ddl3BindChandi();
                        break;

                    case "按销售单位，时间段查询":
                        Label2.Text = "时间段";
                        Label3.Text = "销售单位";
                        ddl3BindClient();
                        break;

                    case "按销售单位，起始时间段查询":
                        Label2.Text = "起始时间段";
                        Label3.Text = "销售单位";
                        ddl3BindClient();

                        break;
                }

                ddl3.Visible = true;
                Label3.Visible = true;
                Label2.Visible = true;
                TextBox2.Visible = true;
                TextBox3.Visible = true;
                break;
        }
    }

    /// <summary>
    /// 绑定产地信息
    /// </summary>
    private void ddl3BindChandi()
    {
        SqlData sd = new SqlData();
        SqlDataReader dr = sd.ExceRead("select k_name from gy_KName");
        ddl3.DataSource = dr;
        ddl3.DataTextField = "k_name";
        ddl3.DataValueField = "k_name";
        ddl3.DataBind();
    }

    /// <summary>
    /// 绑定操作员信息
    /// </summary>
    private void ddl3BindOperator()
    {
        SqlData sd = new SqlData();
        SqlDataReader dr = sd.ExceRead("select username from userinfo");
        ddl3.DataSource = dr;
        ddl3.DataTextField = "username";
        ddl3.DataValueField = "username";
        ddl3.DataBind();
    }

    /// <summary>
    /// 绑定单位信息
    /// </summary>
    private void ddl3BindClient()
    {
        SqlData sd = new SqlData();
        SqlDataReader dr = sd.ExceRead("select gy_c_name from gy_client");
        ddl3.DataSource = dr;
        ddl3.DataTextField = "gy_c_name";
        ddl3.DataValueField = "gy_c_name";
        ddl3.DataBind();
    }
    #endregion

    #region 查询
    protected void btnSearch_Click(object sender, ImageClickEventArgs e)
    {
        string lb = ddl1.SelectedItem.ToString();
        string tj = ddl2.SelectedItem.ToString();
        string lr = null;
        string lr1 = null;
        string lr2 = null;
        string state = ddl2.SelectedItem.ToString();
        switch (state)
        {
            case "查询,修改用户信息":
                lr = "all";

                break;
            case "查询全部信息":
                lr = "all";
                break;
            case "按产地查询":
                lr = ddl3.SelectedItem.ToString();
                break;
            case "按时间查询":
                lr = TextBox1.Text;
                break;
            case "按时间段查询":
                lr = TextBox2.Text;
                lr1 = TextBox3.Text;
                break;
            case "按产地，时间段查询":
                lr = ddl3.SelectedItem.ToString();
                lr1 = TextBox2.Text;
                lr2 = TextBox3.Text;
                break;
            case "操作员":
                lr = ddl3.SelectedItem.ToString();
                break;
            case "按销售单位查询":
                lr = ddl3.SelectedItem.ToString();
                break;
            case "按凭证号查询":
                lr = TextBox1.Text;
                break;
            case "按销售单位，时间段查询":
                lr = ddl3.SelectedItem.ToString();
                lr1 = TextBox2.Text;
                lr2 = TextBox3.Text;
                break;
            case "按车号查询":
                lr = TextBox1.Text;
                break;
            case "按车号，时间段查询":
                lr = TextBox1.Text;
                lr1 = TextBox2.Text;
                lr2 = TextBox3.Text;
                break;
            case "按托运人查询":
                lr = TextBox1.Text;
                break;
            case "按顾客单位名称查询":
                lr = ddl3.SelectedItem.ToString();
                break;
            case "按产地单位名称查询":
                lr = ddl3.SelectedItem.ToString();
                break;
        }


        string url = string.Format("chaxun.aspx?查询类别={0}&查询条件={1}&查询内容={2}&查询内容1={3}&查询内容2={4}", lb, tj, lr, lr1, lr2);
        Response.Redirect(url);
    }
    #endregion
}