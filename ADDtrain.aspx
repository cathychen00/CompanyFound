<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="ADDtrain.aspx.cs" Inherits="ADDtrain" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="z-index: 101; left: 73px; width: 100px; position: absolute; top: 0px;
        height: 100px">
        <div style="z-index: 101; left: 341px; width: 13px; position: absolute; top: 45px;
            height: 8px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="datetime"
                ErrorMessage="添加数据必须填入日期！！" Height="13px" Width="148px">添加数据必须填入日期!</asp:RequiredFieldValidator></div>
        <div style="z-index: 102; left: 342px; width: 37px; position: absolute; top: 87px;
            height: 1px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="carNO"
                ErrorMessage="车皮号不能为空！" Width="126px">车皮号不能为空！</asp:RequiredFieldValidator></div>
        <div style="z-index: 103; left: 379px; width: 127px; position: absolute; top: 256px;
            height: 32px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
        </div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
        <table border="0" style="width: 382px; height: 340px">
            <tr>
                <td colspan="2" style="color: black; border-top-style: none; border-right-style: none;
                    border-left-style: none; height: 19px; background-color: #7ec3bf; text-align: center;
                    border-bottom-style: none">
                    火车皮纪录</td>
            </tr>
            <tr>
                <td style="width: 73px">
                    日期：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="datetime" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 13px;">
                    车皮号：</td>
                <td style="width: 100px; height: 13px;">
                    <asp:TextBox ID="carNO" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 11px;">
                    托运人：</td>
                <td style="width: 100px; height: 11px;">
                    <asp:TextBox ID="shipper" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 14px;">
                    发站：</td>
                <td style="width: 100px; height: 14px;">
                    <asp:TextBox ID="beginarea" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 10px">
                    收货人：</td>
                <td style="width: 100px; height: 10px">
                    <asp:TextBox ID="consignee" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 2px">
                    核吨：</td>
                <td style="width: 100px; height: 2px">
                    <asp:TextBox ID="totalamount" runat="server">0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px">
                    实际数量：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="factamount" runat="server">0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px">
                    运费：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="carriage" runat="server">0</asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 10px">
                    多经费：</td>
                <td style="width: 100px; height: 10px">
                    <asp:TextBox ID="djf" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px">
                    已付款：</td>
                <td style="width: 100px">
                    <asp:TextBox ID="yfk" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 4px;">
                    备注：</td>
                <td style="width: 100px; height: 4px;">
                    <asp:TextBox ID="remark" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 5px;">
                    操作员：</td>
                <td style="width: 100px; height: 5px;">
                    <asp:Label ID="user" runat="server" ForeColor="Red" Text="Label"></asp:Label>&nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="2">已结算</asp:ListItem>
                            <asp:ListItem Selected="True" Value="1">未结算</asp:ListItem>
                        </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2" style="height: 1px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" Width="56px" /><asp:Button ID="Button2" runat="server" CausesValidation="False" OnClick="Button2_Click"
                        Text="更新" Width="56px" /></td>
            </tr>
        </table></contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

