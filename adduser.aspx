<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="adduser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="z-index: 102; left: 71px; width: 76px; position: absolute; top: 0px; height: 1px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 282px" border="0">
                    <tbody>
                        <tr>
                            <td style="font-size: 12px; color: black; border-top-style: none; border-right-style: none; border-left-style: none; height: 19px; background-color: #7ec3bf; text-align: center; border-bottom-style: none" colspan="2">添加用户信息</td>
                        </tr>
                        <tr>
                            <td style="width: 72px; height: 17px">姓名：</td>
                            <td style="width: 100px; height: 17px">
                                <asp:TextBox ID="username" runat="server" Width="100px"></asp:TextBox>
                                <div style="z-index: 101; left: 272px; width: 92px; position: absolute; top: 46px; height: 16px">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="94px" Font-Size="Small" ErrorMessage="用户名不能为空" ControlToValidate="username">用户名不能为空</asp:RequiredFieldValidator></div>
                            </td>
                        </tr>
                        <tr id="tr_checkName" runat="server">
                            <td colspan="2">
                                <asp:Button ID="btnCheckName" OnClick="btnCheckName_Click" runat="server" Width="118px" Text="检测用户名" CausesValidation="False"></asp:Button></td>
                        </tr>
                        <tr>
                            <td style="width: 72px">密码：</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="userpwd" runat="server" Width="100px" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr id="rpwd" runat="server">
                            <td style="width: 72px">确认密码：</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="userpwd1" runat="server" Width="100px" TextMode="Password"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 72px">性别：</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="usersex" runat="server">
                                    <asp:ListItem Value="1">男</asp:ListItem>
                                    <asp:ListItem Value="2">女</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr id="tr_userlevel" runat="server">
                            <td style="width: 72px">权限：</td>
                            <td style="width: 100px">
                                <asp:DropDownList ID="userlevel" runat="server">
                                    <asp:ListItem Value="1">用户</asp:ListItem>
                                    <asp:ListItem Value="2">管理员</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td style="height: 19px; text-align: center" colspan="2">
                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Width="48px" Text="添加"></asp:Button>
                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Width="51px" Text="更新"></asp:Button></td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    &nbsp;&nbsp;
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="17px" ShowMessageBox="True"
        ShowSummary="False" Width="138px" />
</asp:Content>

