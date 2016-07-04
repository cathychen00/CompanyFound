<%@ Control Language="C#" AutoEventWireup="true" CodeFile="login.ascx.cs" Inherits="login" %>
<div style="z-index: 102; left: 0px; background-image: url(image/loggin.gif); width: 205px; position: absolute; top: 0px; height: 100px">
    <div style="z-index: 101; left: 47px; width: 111px; position: absolute; top: 67px; height: 4px">
        <asp:TextBox ID="password" runat="server" BorderWidth="1px" TextMode="Password" Width="95px" Height="22px"></asp:TextBox>
    </div>
    &nbsp;
    <div style="z-index: 102; left: 152px; width: 38px; position: absolute; top: 39px; height: 16px">
        <asp:ImageButton ID="ImageButton2" runat="server" BorderWidth="1px" ImageUrl="~/image/logginBtn.gif"
            OnClick="ImageButton2_Click" />
    </div>
    <div style="z-index: 103; left: 47px; width: 100px; position: absolute; top: 38px; height: 12px">
        <asp:TextBox ID="username" runat="server" BorderWidth="1px" Width="95px" Height="22px"></asp:TextBox>
    </div>
</div>
