<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Chaxunye.ascx.cs" Inherits="moudle_ascx_Cha" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:ScriptManager ID="ScriptManager3" runat="server" EnablePartialRendering="True">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div style="z-index: 101; left: 0px; width: 713px; position: absolute; top: 0px; height: 12px; vertical-align: super;">
            <asp:DropDownList ID="ddl1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl1_SelectedIndexChanged">
                <asp:ListItem Selected="True">请选择查询</asp:ListItem>
                <asp:ListItem>销售信息</asp:ListItem>
                <asp:ListItem>销售票据</asp:ListItem>
                <asp:ListItem>购进信息</asp:ListItem>
                <asp:ListItem>运输汇总</asp:ListItem>
                <asp:ListItem>火车皮纪录</asp:ListItem>
                <asp:ListItem>顾客信息</asp:ListItem>
                <asp:ListItem>产地信息</asp:ListItem>
                <asp:ListItem>用户信息</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:DropDownList ID="ddl2" runat="server" OnSelectedIndexChanged="ddl2_SelectedIndexChanged1" AutoPostBack="True">
            </asp:DropDownList>
            <asp:Label ID="Label3" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>
            <asp:DropDownList ID="ddl3" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="90px"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Label" ForeColor="Maroon"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="66px"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server" Width="66px"></asp:TextBox>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
            <asp:ImageButton ID="btnSearch" runat="server" ImageUrl="~/image/chaxun.GIF" OnClick="btnSearch_Click" />
            &nbsp; &nbsp;
        </div>
        &nbsp;&nbsp;
    </ContentTemplate>
</asp:UpdatePanel>
&nbsp;&nbsp;&nbsp;&nbsp;
