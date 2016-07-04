<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="ADDxiaopiao.aspx.cs" Inherits="ADDxiaopiao" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div style="z-index: 101; left: 44px; width: 100px; position: absolute; top: 0px;
        height: 100px">
        <div style="z-index: 102; left: 448px; width: 76px; position: absolute; top: 131px;
            height: 100px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="1" Width="139px" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="2" Width="138px" />
        </div>
        <div style="z-index: 103; left: 459px; width: 100px; position: absolute; top: 254px;
            height: 100px">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\SqlExpress;Initial Catalog=DbName;User ID=sa;pwd=sa;"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [gy_clientID], [gy_c_name] FROM [gy_client]">
            </asp:SqlDataSource>
        </div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
  
<TABLE style="WIDTH: 409px; HEIGHT: 326px" id="TABLE1" border=0><TBODY><TR><TD style="COLOR: black; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 19px; BACKGROUND-COLOR: #7ec3bf; TEXT-ALIGN: center; BORDER-BOTTOM-STYLE: none" colSpan=2>销售票据信息</TD></TR><TR><TD style="WIDTH: 80px">销售单位：</TD><TD style="WIDTH: 67px"><asp:DropDownList id="client" runat="server" DataValueField="gy_clientID" DataTextField="gy_c_name" DataSourceID="SqlDataSource1">
                    </asp:DropDownList> </TD></TR><TR><TD style="HEIGHT: 16px" colSpan=2>日期：<asp:TextBox id="begintime" runat="server" Width="70px"></asp:TextBox> <DIV style="Z-INDEX: 101; LEFT: 256px; WIDTH: 352px; POSITION: absolute; TOP: 90px; HEIGHT: 4px"><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" Width="148px" ValidationGroup="1" Height="13px" ErrorMessage="计算数量汇总时，开始时间不能为空！" ControlToValidate="begintime">开始时间不能为空！</asp:RequiredFieldValidator> <asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" ValidationGroup="1" ErrorMessage="计算数量汇总时，结束时间不能为空！" ControlToValidate="endtime" Width="139px">结束时间不能为空！</asp:RequiredFieldValidator></DIV>&nbsp; 到 &nbsp; <asp:TextBox id="endtime" runat="server" Width="70px"></asp:TextBox>&nbsp;&nbsp;&nbsp; <DIV style="Z-INDEX: 104; LEFT: 258px; WIDTH: 349px; POSITION: absolute; TOP: 75px; HEIGHT: 17px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ValidationGroup="2" ErrorMessage="添加数据时，开始时间不能为空！" ControlToValidate="begintime" Width="147px">开始时间不能为空！</asp:RequiredFieldValidator> <asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" Width="131px" ValidationGroup="2" Height="1px" ErrorMessage="添加数据时，结束时间不能为空！" ControlToValidate="endtime">结束时间不能为空！</asp:RequiredFieldValidator></DIV></TD></TR><TR><TD style="HEIGHT: 13px" colSpan=2><asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="112px" ValidationGroup="1" Text="数量汇总"></asp:Button> </TD></TR><TR><TD style="WIDTH: 80px; HEIGHT: 11px">车次汇总：</TD><TD style="WIDTH: 67px; HEIGHT: 11px"><SPAN style="FONT-SIZE: 9pt; COLOR: #ff0033"><asp:TextBox id="totalcar" runat="server" Width="55px" ForeColor="Red"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" Width="211px" ValidationGroup="2" Height="15px" ErrorMessage="添加数据时，车次汇总不能为空！" ControlToValidate="totalcar">车次汇总不能为空！</asp:RequiredFieldValidator> </SPAN></TD></TR><TR><TD style="WIDTH: 80px; HEIGHT: 6px">数量汇总：</TD><TD style="WIDTH: 67px; HEIGHT: 6px"><SPAN style="FONT-SIZE: 9pt; COLOR: #ff0033"><asp:TextBox id="totalamount" runat="server" Width="77px" ForeColor="Red"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Width="177px" ValidationGroup="2" Height="14px" ErrorMessage="添加数据时，数量汇总不能为空！" ControlToValidate="totalamount">数量汇总不能为空！</asp:RequiredFieldValidator> </SPAN></TD></TR><TR><TD style="WIDTH: 80px; HEIGHT: 28px">票据：</TD><TD style="WIDTH: 67px; HEIGHT: 28px"><asp:TextBox id="bill" runat="server"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px">金额：</TD><TD style="WIDTH: 67px"><asp:TextBox id="totalmoney" runat="server">0</asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px">已收款：</TD><TD style="WIDTH: 67px"><asp:TextBox id="gathering" runat="server">0</asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px">备注：</TD><TD style="WIDTH: 67px"><asp:TextBox id="remark" runat="server" Height="72px" TextMode="MultiLine" Width="207px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 80px; HEIGHT: 35px">操作员：</TD><TD style="WIDTH: 67px; HEIGHT: 35px"><asp:Label id="user" runat="server" Text="Label" ForeColor="Red"></asp:Label>&nbsp; </TD></TR><TR><TD style="HEIGHT: 24px" align=center colSpan=2><asp:Button id="Button2" onclick="Button2_Click" runat="server" Width="55px" ValidationGroup="2" Text="添加"></asp:Button><asp:Button id="updata" onclick="total_Click" runat="server" Width="55px" Text="更新" CausesValidation="False"></asp:Button></TD></TR></TBODY></TABLE></contenttemplate>
        </asp:UpdatePanel>

    </div>
 
</asp:Content>

