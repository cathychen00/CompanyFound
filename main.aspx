<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="z-index: 101; left: 0px; width: 950px; position: absolute; top: 0px; height: 700px">
                &nbsp;&nbsp;&nbsp;&nbsp;
            <div style="z-index: 102; left: 0px; background-image: url(image/main1.gif); width: 1000px; position: absolute; top: 0px; height: 728px">
                <div style="z-index: 101; left: 114px; position: absolute; top: 264px; width: 487px; height: 158px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackImageUrl="~/image/mainbg.gif"
                        DataSourceID="SqlDataSource1" AllowPaging="True" BorderWidth="0px">
                        <Columns>
                            <asp:BoundField DataField="用户姓名" HeaderText="用户姓名" SortExpression="用户姓名">
                                <ItemStyle Height="28px" />
                                <HeaderStyle Height="31px" BackColor="#7EC3BF" />
                            </asp:BoundField>
                            <asp:BoundField DataField="用户密码" HeaderText="用户密码" SortExpression="用户密码">
                                <HeaderStyle BackColor="#7EC3BF" />
                            </asp:BoundField>
                            <asp:BoundField DataField="用户性别" HeaderText="用户性别" SortExpression="用户性别">
                                <HeaderStyle BackColor="#7EC3BF" />
                            </asp:BoundField>
                            <asp:BoundField DataField="用户等级名称" HeaderText="用户等级名称" SortExpression="用户等级名称">
                                <HeaderStyle BackColor="#7EC3BF" />
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div style="z-index: 102; left: 688px; width: 100px; position: absolute; top: 485px; height: 100px">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\SqlExpress;Initial Catalog=DbName;User ID=sa;pwd=sa;"
                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [用户姓名], [用户密码], [用户性别], [用户等级名称] FROM [View2]"></asp:SqlDataSource>
                </div>
            </div>
            </div>

        </div>
    </form>
</body>
</html>
