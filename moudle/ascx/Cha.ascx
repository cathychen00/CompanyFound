<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Cha.ascx.cs" Inherits="moudle_ascx_Cha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="z-index: 102; left: 0px; width: 165px; position: absolute; top: 0px;
            height: 20px">
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
        <asp:ListItem>销售信息</asp:ListItem>
        <asp:ListItem>销售票据</asp:ListItem>
        <asp:ListItem>购进信息</asp:ListItem>
        <asp:ListItem>运输汇总</asp:ListItem>
        <asp:ListItem>火车皮纪录</asp:ListItem>
        <asp:ListItem>顾客信息</asp:ListItem>
        <asp:ListItem>产地信息</asp:ListItem>
        <asp:ListItem>用户信息</asp:ListItem>
        <asp:ListItem Selected="True">请选择查询</asp:ListItem>
    </asp:DropDownList>&nbsp;
            <br />
    <asp:DropDownList ID="DropDownList2" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged1" AutoPostBack="True"  >
    </asp:DropDownList><br />
    <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList3" runat="server">
    </asp:DropDownList><br />
    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Width="90px"></asp:TextBox><br />
    <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" Width="66px"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Width="66px"></asp:TextBox><br />
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/chaxun.GIF" OnClick="ImageButton1_Click" CausesValidation="False" /></div>
        &nbsp;&nbsp;
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;&nbsp;
