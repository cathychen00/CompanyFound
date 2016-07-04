<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="addclient.aspx.cs" Inherits="addclient" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp;
    <div style="z-index: 101; left: 69px; width: 383px; position: absolute; top: 5px;
        height: 197px">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
        <table border="0" style="width: 374px">
            <tr>
                <td colspan="2" style="font-size: 12px; color: black; border-top-style: none; border-right-style: none;
                    border-left-style: none; background-color: #7ec3bf; text-align: center; border-bottom-style: none">
                    <span>添加顾客信息</span></td>
            </tr>
            <tr>
                <td style="width: 117px; height: 15px">
                    顾客姓名：</td>
                <td style="width: 122px; height: 15px">
                    <asp:TextBox ID="username" runat="server" Width="98px"></asp:TextBox>&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="username"
                        ErrorMessage="顾客姓名不能为空！！" Width="153px">顾客姓名不能为空！！</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 36px">
                    <asp:Button ID="Button3" runat="server" CausesValidation="False" OnClick="Button3_Click"
                        Text="检测用户名" Width="83px" /></td>
            </tr>
            <tr>
                <td style="width: 117px">
                    电话：</td>
                <td style="width: 122px">
                    <asp:TextBox ID="phone" runat="server" Width="153px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 117px">
                    地址：</td>
                <td style="width: 122px">
                    <asp:TextBox ID="addres" runat="server" Width="198px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 117px">
                    电子邮件：</td>
                <td style="width: 122px">
                    <asp:TextBox ID="E_mail" runat="server" Width="198px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 117px">
                    备注：</td>
                <td style="width: 122px">
                    <asp:TextBox ID="remark" runat="server" Height="83px" Rows="5" Width="204px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 38px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" Width="60px" /><asp:Button
                        ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click"
                        Text="更新" Width="60px" /></td>
            </tr>
        </table></contenttemplate>
        </asp:UpdatePanel>
    </div>
    <div style="z-index: 102; left: 499px; width: 100px; position: absolute; top: 246px;
        height: 24px">
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="34px" ShowMessageBox="True"
            ShowSummary="False" Width="171px" />
    </div>
</asp:Content>

