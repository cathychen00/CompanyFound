<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Adduser.ascx.cs" Inherits="Adduser" %>
<div style="z-index: 103; left: 0px; width: 375px; position: absolute; top: 0px;
    height: 491px">
    <table id="TABLE1" border="0" onclick="return TABLE1_onclick()" style="width: 323px;
        height: 404px">
        <tr>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 103px; border-bottom: #cccc66 thin solid; height: 45px">
                姓名：</td>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 100px; border-bottom: #cccc66 thin solid; height: 45px">
                <asp:TextBox ID="username" runat="server" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                    ErrorMessage="用户名不能为空" Font-Size="Small" Width="135px">用户名不能为空</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td colspan="2" style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid;
                border-left: #cccc66 thin solid; border-bottom: #cccc66 thin solid; height: 45px">
                &nbsp;
                <div style="z-index: 102; left: 98px; width: 165px; position: absolute; top: 87px;
                    height: 34px">
                    <asp:Button ID="jcname" runat="server" CausesValidation="False" OnClick="jcname_Click"
                        Text="检测用户名" Width="125px" /></div>
            </td>
        </tr>
        <tr>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 103px; border-bottom: #cccc66 thin solid; height: 35px">
                密码：</td>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 100px; border-bottom: #cccc66 thin solid; height: 35px">
                &nbsp;<asp:TextBox ID="userpwd" runat="server" Width="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 103px; border-bottom: #cccc66 thin solid; height: 35px">
                确认密码：</td>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 100px; border-bottom: #cccc66 thin solid; height: 35px">
                <asp:TextBox ID="userpwd1" runat="server" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 103px; border-bottom: #cccc66 thin solid; height: 35px">
                性别：</td>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 100px; border-bottom: #cccc66 thin solid; height: 35px">
                <asp:DropDownList ID="usersex" runat="server">
                    <asp:ListItem Value="1">男</asp:ListItem>
                    <asp:ListItem Value="2">女</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 103px; border-bottom: #cccc66 thin solid; height: 35px">
                权限：</td>
            <td style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid; border-left: #cccc66 thin solid;
                width: 100px; border-bottom: #cccc66 thin solid; height: 35px">
                <asp:DropDownList ID="userlevel" runat="server">
                    <asp:ListItem Value="1">普通用户</asp:ListItem>
                    <asp:ListItem Value="2">管理员</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="2" style="border-right: #cccc66 thin solid; border-top: #cccc66 thin solid;
                border-left: #cccc66 thin solid; border-bottom: #cccc66 thin solid; height: 35px">
                &nbsp;
                <div style="z-index: 101; left: 120px; width: 130px; position: absolute; top: 363px;
                    height: 35px">
                    <asp:Button ID="okbtn" runat="server" OnClick="okbtn_Click" Text="提交 " /></div>
                &nbsp;
                <div style="z-index: 103; left: 213px; width: 172px; position: absolute; top: 363px;
                    height: 25px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="取消" />
                </div>
                <div style="z-index: 104; left: -10px; width: 243px; position: absolute; top: 358px;
                    height: 30px">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="17px" ShowMessageBox="True"
                        ShowSummary="False" Width="138px" />
                </div>
            </td>
        </tr>
    </table>
</div>
