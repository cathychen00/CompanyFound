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

public partial class menu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {

            StringBuilder strMenu = new StringBuilder();
            if (Session["userlevel"] != null && Session["userlevel"].ToString() != string.Empty)
            {
                string State = Session["userlevel"].ToString();
                switch (State)
                {
                    case "普通用户":
                        strMenu.Append(Session["UserName"]);
                        strMenu.Append(":  ");
                        strMenu.Append("<span class='bold'><a href='loginout.aspx");
                        strMenu.Append("'> 退出</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addgou.aspx'>购进信息</a>");
                        strMenu.Append("|");
                        strMenu.Append("<a href='addxiao.aspx'>销售信息</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addxiaopiao.aspx'>销售（发票）</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addyun.aspx'>运输汇总</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addtrain.aspx'>火车皮纪录</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addclient.aspx'>顾客信息</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addproducingarea.aspx'>产地信息</a></span>");
                        break;
                    case "管理员":
                        strMenu.Append(Session["UserName"]);
                        strMenu.Append(":  ");
                        strMenu.Append("<span class='bold'><a href='loginout.aspx");
                        strMenu.Append("'>退出</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='adduser.aspx'>注册新用户</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addgou.aspx'>购进信息</a>");
                        strMenu.Append("|");
                        strMenu.Append("<a href='addxiao.aspx'>销售信息</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addxiaopiao.aspx'>销售（发票）</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addyun.aspx'>运输汇总</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addtrain.aspx'>火车皮纪录</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addclient.aspx'>顾客信息</a></span>");
                        strMenu.Append("|");
                        strMenu.Append("<span class='bold'><a href='addproducingarea.aspx'>产地信息</a></span>");
                        break;
                   
                }
            }
            else
            {
                strMenu.Append("游客：");
                
                strMenu.Append("|<span class='bold'><a href='default.aspx'>登陆</a></span>");
            }
            this.LabMenu.Text = strMenu.ToString();
        }
    }
}

