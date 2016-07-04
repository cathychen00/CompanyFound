<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="ADDproducingarea.aspx.cs" Inherits="ADDproducingarea" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="z-index: 101; left: 84px; width: 100px; position: absolute; top: 0px; height: 100px">
        <div style="z-index: 101; left: 156px; width: 100px; position: absolute; top: 83px; height: 7px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name"
                ErrorMessage="名称不能为空！" Font-Size="Small" Width="134px">名称不能为空！</asp:RequiredFieldValidator>
        </div>
        <div style="z-index: 102; left: 328px; width: 128px; position: absolute; top: 283px; height: 35px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
        </div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table style="width: 307px; height: 333px" id="TABLE1" onclick="return TABLE1_onclick()" border="0">
                    <tbody>
                        <tr>
                            <td style="font-size: 14px; color: black; border-top-style: none; border-right-style: none; border-left-style: none; height: 19px; background-color: #7ec3bf; text-align: center; border-bottom-style: none" align="center" colspan="2"><span>产地信息添加</span></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">名称：</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="name" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnCheck" OnClick="btnCheck_Click" runat="server" Width="108px" Text="检测名称！" CausesValidation="False"></asp:Button></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">电话：</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="phone" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="width: 100px">备注：</td>
                            <td style="width: 100px">
                                <asp:TextBox ID="remark" runat="server" Width="175px" Rows="3" Height="121px"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Width="54px" Text="添加"></asp:Button>
                                <asp:Button ID="btnUpdate" OnClick="btnUpdate_Click" runat="server" Width="60px" Text="更新" CausesValidation="False"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

