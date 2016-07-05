using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

public partial class chaxun : System.Web.UI.Page
{
    SqlConnection sqlcon;
    SqlCommand sqlcom;
    string strCon = ConfigurationManager.AppSettings["conStr"];
    public string table_ID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["username"] != null && Session["username"].ToString() != string.Empty)
            {
                BindData();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(UpdatePanel1, this.GetType(), "click", "alert('您还未登录系统，不能访问此页！请先登录系统。');location='Default.aspx'", true);
                return;
            }
        }
    }
    #region 绑定列表
    private void BindData()
    {
        string lb = Request.QueryString["查询类别"];
        string tj = Request.QueryString["查询条件"];
        string lr = Request.QueryString["查询内容"];
        string lr1 = Request.QueryString["查询内容1"];
        string lr2 = Request.QueryString["查询内容2"];

        string sqlstr = null;
        if (lb == null)
        {
            this.Label1.Text = "请选择条件查询记录！！";
        }
        else
        {
            string table = null;
            string B_ID = null;
            switch (lb)
            {
                case ("购进信息"):
                    Label1.Text = "购进信息";
                    table = "gy_gou";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "SELECT gy_Gou.gou_ID ID  , gy_Gou.gou_time 时间, gy_KName.k_name  矿名, gy_Gou.gou_amount 数量, gy_Gou.gou_price 单价, gy_Gou.gou_total 总额, gy_js.jsname 结算 , gy_Gou.gou_billno 票据号, gy_Gou.gou_pqyment 已付款, gy_Gou.gou_remark 备注,username  操作员  FROM " + table + " ,userinfo,gy_KName ,gy_js WHERE " + table + " .k_ID=gy_KName.k_ID   and  " + table + " .jsID=gy_js.jsID and (" + table + ".userinfoID=userinfo.userinfoID) ORDER BY gou_ID DESC";
                            break;
                        case ("按产地查询"):
                            sqlstr = "SELECT gy_Gou.gou_ID ID, gy_Gou.gou_time 时间, gy_KName.k_name  矿名, gy_Gou.gou_amount 数量, gy_Gou.gou_price 单价, gy_Gou.gou_total 总额, gy_js.jsname 结算 , gy_Gou.gou_billno 票据号, gy_Gou.gou_pqyment 已付款, gy_Gou.gou_remark 备注, username  操作员  FROM " + table + ",userinfo ,gy_KName ,gy_js WHERE " + table + " .k_ID=gy_KName.k_ID  and (gy_KName.k_name = '" + lr + "')  and  " + table + " .jsID=gy_js.jsID and (" + table + ".userinfoID=userinfo.userinfoID) ORDER BY gou_ID DESC";
                            break;
                        case ("按时间查询"):
                            sqlstr = "SELECT gy_Gou.gou_ID ID, gy_Gou.gou_time 时间, gy_KName.k_name  矿名, gy_Gou.gou_amount 数量, gy_Gou.gou_price 单价, gy_Gou.gou_total 总额, gy_js.jsname 结算 , gy_Gou.gou_billno 票据号, gy_Gou.gou_pqyment 已付款, gy_Gou.gou_remark 备注, username  操作员  FROM " + table + ",userinfo ,gy_KName,gy_js  WHERE   " + table + " .k_ID=gy_KName.k_ID and (gy_gou.gou_time = '" + lr + "')   and  " + table + " .jsID=gy_js.jsID and (" + table + ".userinfoID=userinfo.userinfoID) ORDER BY gou_ID DESC";
                            break;
                        case ("按时间段查询"):
                            sqlstr = "SELECT gy_Gou.gou_ID ID, gy_Gou.gou_time 时间, gy_KName.k_name  矿名, gy_Gou.gou_amount 数量, gy_Gou.gou_price 单价, gy_Gou.gou_total 总额, gy_js.jsname 结算 , gy_Gou.gou_billno 票据号, gy_Gou.gou_pqyment 已付款, gy_Gou.gou_remark 备注, username  操作员  FROM " + table + " ,userinfo,gy_KName,gy_js  WHERE   " + table + " .k_ID=gy_KName.k_ID and (gy_gou.gou_time  between  '" + lr + "' and '" + lr1 + "')  and  " + table + " .jsID=gy_js.jsID and (" + table + ".userinfoID=userinfo.userinfoID) ORDER BY gou_ID DESC";
                            break;
                        case ("按产地，时间段查询"):
                            sqlstr = "SELECT gy_Gou.gou_ID ID, gy_Gou.gou_time 时间, gy_KName.k_name  矿名, gy_Gou.gou_amount 数量, gy_Gou.gou_price 单价, gy_Gou.gou_total 总额,gy_js.jsname 结算 , gy_Gou.gou_billno 票据号, gy_Gou.gou_pqyment 已付款, gy_Gou.gou_remark 备注, username  操作员  FROM " + table + ",userinfo ,gy_KName,gy_js  WHERE   " + table + " .k_ID=gy_KName.k_ID and (gy_KName.k_name = '" + lr + "') and ( gy_gou.gou_time  between  '" + lr1 + "' and '" + lr2 + "')  and  " + table + " .jsID=gy_js.jsID and (" + table + ".userinfoID=userinfo.userinfoID) ORDER BY gou_ID DESC";
                            break;
                        case ("操作员"):
                            sqlstr = "SELECT gy_Gou.gou_ID ID, gy_Gou.gou_time 时间, gy_KName.k_name  矿名, gy_Gou.gou_amount 数量, gy_Gou.gou_price 单价, gy_Gou.gou_total 总额, gy_js.jsname 结算 , gy_Gou.gou_billno 票据号 , gy_Gou.gou_pqyment 已付款, gy_Gou.gou_remark 备注 ,userinfo.username 操作员 FROM " + table + " ,gy_KName,userinfo,gy_js  WHERE   " + table + " .k_ID=gy_KName.k_ID  and  (" + table + ".userinfoID=UserInfo.userinfoID) and (userinfo.username = '" + lr + "')   and  " + table + " .jsID=gy_js.jsID ORDER BY gou_ID DESC";
                            break;

                    }


                    break;
                case ("销售信息"):
                    this.Label1.Text = "销售信息";
                    table = "gy_xiao";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time  时间,gy_x_carNO  车号,gy_x_voucher  凭证号,gy_c_name  销售单位,gy_x_amount  数量,gy_x_price  单价,gy_x_total  总额,gy_js.jsname  结算,gy_x_remark  备注,username  操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID)  and (" + table + " .jsID=gy_js.jsID ) ORDER BY gy_xiaoID DESC";
                            break;
                        case ("按销售单位查询"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time 时间,gy_x_carNO 车号,gy_x_voucher 凭证号,gy_c_name 销售单位,gy_x_amount 数量,gy_x_price 单价,gy_x_total 总额,gy_js.jsname 结算,gy_x_remark 备注,username 操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_c_name='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY gy_xiaoID DESC";
                            break;
                        case ("按时间查询"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time 时间,gy_x_carNO 车号,gy_x_voucher 凭证号,gy_c_name 销售单位,gy_x_amount 数量,gy_x_price 单价,gy_x_total 总额,gy_js.jsname 结算,gy_x_remark 备注,username 操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_x_time='" + lr + "') (" + table + " .jsID=gy_js.jsID ) ";
                            break;
                        case ("按时间段查询"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time 时间,gy_x_carNO 车号,gy_x_voucher 凭证号,gy_c_name 销售单位,gy_x_amount 数量,gy_x_price 单价,gy_x_total 总额,gy_js.jsname 结算,gy_x_remark 备注,username 操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_x_time between  '" + lr + "' and '" + lr1 + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY gy_xiaoID DESC ";
                            break;
                        case ("按销售单位，时间段查询"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time 时间,gy_x_carNO 车号,gy_x_voucher 凭证号,gy_c_name 销售单位,gy_x_amount 数量,gy_x_price 单价,gy_x_total 总额,gy_js.jsname 结算,gy_x_remark 备注,username 操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_x_time between  '" + lr1 + "' and '" + lr2 + "') and (gy_c_name='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY gy_xiaoID DESC ";
                            break;
                        case ("按凭证号查询"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time 时间,gy_x_carNO 车号,gy_x_voucher 凭证号,gy_c_name 销售单位,gy_x_amount 数量,gy_x_price 单价,gy_x_total 总额,gy_js.jsname 结算,gy_x_remark 备注,username 操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_x_voucher='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY gy_xiaoID DESC ";
                            break;
                        case ("操作员"):
                            sqlstr = "select gy_xiaoID ID,gy_x_time 时间,gy_x_carNO 车号,gy_x_voucher 凭证号,gy_c_name 销售单位,gy_x_amount 数量,gy_x_price 单价,gy_x_total 总额,gy_js.jsname 结算,gy_x_remark 备注,username 操作员 from " + table + " ,gy_client ,userinfo,gy_js where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (username='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY gy_xiaoID DESC ";
                            break;
                    }
                    GridView1.DataKeyNames = new string[] { "gy_xiaoID" };
                    break;
                case ("销售票据"):
                    this.Label1.Text = "销售票据";
                    table = "gy_xiao_billno";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "select gy_xiao_billnoID ID,gy_c_name  销售单位,gy_x_b_bgtime 起始时间,gy_x_b_endtime 结束时间,gy_x_b_totalcar 总车次,gy_x_b_totalamount 总吨位,gy_x_b_billNO 发票号,gy_x_b_totalmoney 金额,gy_x_b_gathering 已收款,gy_x_b_remark 备注,username 操作员 from " + table + " ,userinfo,gy_client where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + ".gy_clientID=gy_client.gy_clientID) ORDER BY ID DESC";
                            break;
                        case ("按销售单位查询"):
                            sqlstr = "select gy_xiao_billnoID ID,gy_c_name  销售单位,gy_x_b_bgtime 起始时间,gy_x_b_endtime 结束时间,gy_x_b_totalcar 总车次,gy_x_b_totalamount 总吨位,gy_x_b_billNO 发票号,gy_x_b_totalmoney 金额,gy_x_b_gathering 已收款,gy_x_b_remark 备注,username 操作员 from " + table + " ,userinfo,gy_client where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + ".gy_clientID=gy_client.gy_clientID) and (gy_c_name='" + lr + "') ORDER BY ID DESC";
                            break;
                        case ("按时间查询"):
                            sqlstr = "select gy_xiao_billnoID ID,gy_c_name  销售单位,gy_x_b_bgtime 起始时间,gy_x_b_endtime 结束时间,gy_x_b_totalcar 总车次,gy_x_b_totalamount 总吨位,gy_x_b_billNO 发票号,gy_x_b_totalmoney 金额,gy_x_b_gathering 已收款,gy_x_b_remark 备注,username 操作员 from " + table + " ,userinfo,gy_client where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + ".gy_clientID=gy_client.gy_clientID) and (gy_x_b_bgtime='" + lr + "') ORDER BY ID DESC";
                            break;
                        case ("按时间段查询"):
                            sqlstr = "select gy_xiao_billnoID ID,gy_c_name  销售单位,gy_x_b_bgtime 起始时间,gy_x_b_endtime 结束时间,gy_x_b_totalcar 总车次,gy_x_b_totalamount 总吨位,gy_x_b_billNO 发票号,gy_x_b_totalmoney 金额,gy_x_b_gathering 已收款,gy_x_b_remark 备注,username 操作员 from " + table + " ,userinfo,gy_client where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + ".gy_clientID=gy_client.gy_clientID) and (gy_x_b_bgtime between  '" + lr + "' and '" + lr1 + "') ORDER BY ID DESC";
                            break;
                        case ("按销售单位，时间段查询"):
                            sqlstr = "select gy_xiao_billnoID ID,gy_c_name  销售单位,gy_x_b_bgtime 起始时间,gy_x_b_endtime 结束时间,gy_x_b_totalcar 总车次,gy_x_b_totalamount 总吨位,gy_x_b_billNO 发票号,gy_x_b_totalmoney 金额,gy_x_b_gathering 已收款,gy_x_b_remark 备注,username 操作员 from " + table + " ,userinfo,gy_client where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + ".gy_clientID=gy_client.gy_clientID) and (gy_c_name='" + lr + "') and (gy_x_b_bgtime between  '" + lr1 + "' and '" + lr2 + "')  ORDER BY ID DESC";
                            break;
                        case ("操作员"):
                            sqlstr = "select gy_xiao_billnoID ID,gy_c_name  销售单位,gy_x_b_bgtime 起始时间,gy_x_b_endtime 结束时间,gy_x_b_totalcar 总车次,gy_x_b_totalamount 总吨位,gy_x_b_billNO 发票号,gy_x_b_totalmoney 金额,gy_x_b_gathering 已收款,gy_x_b_remark 备注,username 操作员 from " + table + " ,userinfo,gy_client where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + ".gy_clientID=gy_client.gy_clientID) and (username='" + lr + "') ORDER BY ID DESC";
                            break;
                    }
                    break;
                case ("运输汇总"):
                    this.Label1.Text = "运输汇总";
                    table = "gy_yun";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID)  ORDER BY ID DESC";
                            break;
                        case ("按销售单位查询"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID)  and (gy_c_name='" + lr + "') ORDER BY ID DESC";
                            break;
                        case ("按时间查询"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID)  and (gy_y_bgtime='" + lr + "') ORDER BY ID DESC";
                            break;
                        case ("按车号查询"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_y_carno='" + lr + "') ORDER BY ID DESC";
                            break;
                        case ("按车号，时间段查询"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_y_carno='" + lr + "') and (gy_y_bgtime between  '" + lr1 + "' and '" + lr2 + "') ORDER BY ID DESC";
                            break;
                        case ("操作员"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (username='" + lr + "') ORDER BY ID DESC";
                            break;
                        case ("按时间段查询"):
                            sqlstr = "select gy_yunID ID,gy_y_bgtime 起始时间,gy_y_endtime 结束时间,gy_c_name 销售单位,gy_y_carno 车号,gy_y_totalcar 总车次,gy_y_totalamount 总吨位,gy_y_price 单价,gy_y_mileage 里程,gy_y_total 总额,gy_y_bgarea 起点,gy_y_endarea 终点,gy_y_remark 备注,username 操作员 from " + table + ",userinfo,gy_client where " + table + ".gy_clientID=gy_client.gy_clientID and (" + table + ".userinfoID=userinfo.userinfoID) and (gy_y_bgtime between  '" + lr + "' and '" + lr1 + "') ORDER BY ID DESC";
                            break;
                    }
                    break;
                case ("火车皮纪录"):
                    this.Label1.Text = "火车皮纪录";
                    table = "gy_train";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf  多经费,gy_t_yff  已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (" + table + " .jsID=gy_js.jsID )  ORDER BY ID DESC";
                            break;

                        case ("按车号查询"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf 多经费,gy_t_yff 已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (gy_t_carNO='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY ID DESC";
                            break;

                        case ("按托运人查询"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf 多经费,gy_t_yff 已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (gy_t_shipper='" + lr + "') and (" + table + " .jsID=gy_js.jsID )  ORDER BY ID DESC";
                            break;
                        case ("按车号，时间段查询"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf 多经费,gy_t_yff 已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (gy_t_carNO='" + lr + "')  and (gy_t_time between  '" + lr1 + "' and '" + lr2 + "')  and (" + table + " .jsID=gy_js.jsID ) ORDER BY ID DESC";
                            break;
                        case ("按时间段查询"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf 多经费,gy_t_yff 已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (gy_t_time between  '" + lr + "' and '" + lr1 + "')  and (" + table + " .jsID=gy_js.jsID ) ORDER BY ID DESC";
                            break;
                        case ("操作员"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf 多经费,gy_t_yff 已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (username='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY ID DESC";
                            break;
                        case ("按时间查询"):
                            sqlstr = "select gy_trainID ID, gy_t_time 时间,gy_t_carNO 车号,gy_t_shipper 托运人,gy_t_bgarea 发站,gy_t_consignee 收货人,gy_t_totalamount 吨位,gy_t_realamount 实际吨位,gy_t_carriage 运费,gy_t_djf 多经费,gy_t_yff 已付款,gy_js.jsname 结算,gy_t_remark 备注,username 操作员 from " + table + ", userinfo,gy_js where (" + table + ".userinfoID=userinfo.userinfoID) and (gy_t_time='" + lr + "') and (" + table + " .jsID=gy_js.jsID ) ORDER BY ID DESC";
                            break;
                    }
                    break;
                case ("顾客信息"):
                    this.Label1.Text = "顾客信息";
                    table = "gy_client";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "select gy_clientID ID,gy_c_name 顾客单位名称,gy_c_phone 电话,gy_c_address 地址,gy_c_Email 电子邮件,gy_c_remark 备注 from " + table + "  ORDER BY ID DESC";
                            break;
                        case ("按顾客单位名称查询"):
                            sqlstr = "select gy_clientID ID,gy_c_name 顾客单位名称,gy_c_phone 电话,gy_c_address 地址,gy_c_Email 电子邮件,gy_c_remark 备注 from " + table + " where (gy_c_name='" + lr + "')  ORDER BY ID DESC";
                            break;

                    }
                    break;

                case ("产地信息"):
                    this.Label1.Text = "产地信息";
                    table = "gy_kname";
                    B_ID = "ID";
                    switch (tj)
                    {
                        case ("查询全部信息"):
                            sqlstr = "select K_ID ID,k_name 产地单位名称,k_phone 电话,k_remark 备注 from " + table + "  ORDER BY ID DESC  ";
                            break;
                        case ("按产地单位名称查询"):
                            sqlstr = "select K_ID ID,k_name 产地单位名称,k_phone 电话,k_remark 备注 from " + table + "  where (K_name='" + lr + "') ORDER BY ID DESC  ";
                            break;
                    }
                    break;
                case ("用户信息"):
                    this.Label1.Text = "用户信息";
                    table = "UserInfo";
                    B_ID = "ID";
                    string userinfoID = Session["userinfoID"].ToString();
                    string userlevel = Session["userlevel"].ToString();
                    switch (tj)
                    {
                        case ("查询,修改用户信息"):
                            if (userlevel == "普通用户")
                            {
                                sqlstr = "select userinfoID ID ,userName 用户名,userPwd 密码,gy_sex.usersexname 性别,gy_userlevel.userlevelname 等级 from userinfo,gy_userlevel,gy_sex where userinfoID='" + userinfoID + "'and userinfo.usersexID=gy_sex.usersexID and userinfo.userlevelID=gy_userlevel.userlevelID ORDER BY userinfoID DESC";
                            }
                            else if (userlevel == "管理员")
                            {
                                sqlstr = "select userinfoID ID ,userName 用户名,userPwd 密码,gy_sex.usersexname 性别,gy_userlevel.userlevelname 等级 from userinfo,gy_userlevel,gy_sex where userinfo.usersexID=gy_sex.usersexID and userinfo.userlevelID=gy_userlevel.userlevelID ORDER BY userinfoID DESC";
                            }
                            break;
                    }
                    break;
            }

            sqlcon = new SqlConnection(strCon);
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlcon);
            DataSet myds = new DataSet();
            sqlcon.Open();
            myda.Fill(myds, table);
            GridView1.DataSource = myds;
            GridView1.DataKeyNames = new string[] { B_ID };//主键
            GridView1.DataBind();
            sqlcon.Close();
        }
    }
    #endregion

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // Confirms that an HtmlForm control is rendered for 

    }

    #region 导出Excel
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExportDataGrid("online/ms-excel", "111.xls");
    }
    private void ExportDataGrid(string FileType, string FileName)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "utf-8";
        Response.AppendHeader("Content-Disposition", "attachment;filename=FileFlow.xls");
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.ContentType = "application/ms-excel";
        this.EnableViewState = false;
        System.IO.StringWriter oStringWriter = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter oHtmlTextWriter = new System.Web.UI.HtmlTextWriter(oStringWriter);
        this.GridView1.RenderControl(oHtmlTextWriter);
        Response.Write(oStringWriter.ToString());
        Response.End();
    }
    #endregion

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    }

    #region 删除
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string lb = Request.QueryString["查询类别"];

        string sqlstr = null;
        SqlData sd = new SqlData();
        string state = lb;
        table_ID = GridView1.DataKeys[e.RowIndex].Value.ToString();
        int id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        switch (lb)
        {

            case ("购进信息"):

                sqlstr = "delete from gy_Gou where gou_ID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                sqlcon = new SqlConnection(strCon);
                sqlcom = new SqlCommand(sqlstr, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();

                break;
            case ("销售信息"):

                sqlstr = "delete from gy_xiao where gy_xiaoID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                sqlcon = new SqlConnection(strCon);
                sqlcom = new SqlCommand(sqlstr, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                break;
            case ("销售票据"):

                sqlstr = "delete from gy_xiao_billno where gy_xiao_billnoID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                sqlcon = new SqlConnection(strCon);
                sqlcom = new SqlCommand(sqlstr, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                break;
            case ("运输汇总"):

                sqlstr = "delete from gy_yun where gy_yunID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                sqlcon = new SqlConnection(strCon);
                sqlcom = new SqlCommand(sqlstr, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                break;
            case ("火车皮纪录"):
                sqlstr = "delete from gy_train where gy_trainID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                sqlcon = new SqlConnection(strCon);
                sqlcom = new SqlCommand(sqlstr, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                break;
            case ("顾客信息"):
                sqlstr = "delete from gy_client where gy_clientID='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
                sqlcon = new SqlConnection(strCon);
                sqlcom = new SqlCommand(sqlstr, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                break;

            case ("产地信息"):
                ProductAreaDal.Delete(id);
                break;
            case ("用户信息"):
                UserInfoDal.Delete(id);
                break;
        }
        
        BindData();
    }
    #endregion

    #region 修改
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.ToString() == "xg")
        {

            string lb = Request.QueryString["查询类别"];
            string tj = Request.QueryString["查询条件"];
            string lr = Request.QueryString["查询内容"];
            string lr1 = Request.QueryString["查询内容1"];
            string lr2 = Request.QueryString["查询内容2"];
            string web = null;
            switch (lb)
            {

                case ("购进信息"):
                    web = "AddGou.aspx";
                    break;
                case ("销售信息"):
                    web = "ADDxiao.aspx";
                    break;
                case ("销售票据"):
                    web = "ADDxiaopiao.aspx";
                    break;
                case ("运输汇总"):
                    web = "ADDyun.aspx";
                    break;
                case ("火车皮纪录"):
                    web = "ADDtrain.aspx";
                    break;
                case ("顾客信息"):
                    web = "addclient.aspx";
                    break;

                case ("产地信息"):
                    web = "ADDproducingarea.aspx";
                    break;
                case ("用户信息"):
                    web = "adduser.aspx";
                    break;
            }

            string url;
            url = "" + web + "?id=" + e.CommandArgument + "&查询类别=" + lb
         + "&查询条件=" + tj + "&查询内容=" + lr + "&查询内容1=" + lr1 + "&查询内容2=" + lr2; ;
            Response.Redirect(url);
        }
    }
    #endregion
}







