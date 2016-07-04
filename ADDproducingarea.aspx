<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="ADDproducingarea.aspx.cs" Inherits="ADDproducingarea" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="z-index: 101; left: 84px; width: 100px; position: absolute; top: 0px;
        height: 100px">
        <div style="z-index: 101; left: 156px; width: 100px; position: absolute; top: 83px;
            height: 7px">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="name"
                ErrorMessage="名称不能为空！" Font-Size="Small" Width="134px">名称不能为空！</asp:RequiredFieldValidator></div>
        <div style="z-index: 102; left: 328px; width: 128px; position: absolute; top: 283px;
            height: 35px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False" />
        </div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 307px; HEIGHT: 333px" id="TABLE1" onclick="return TABLE1_onclick()" border=0><TBODY><TR><TD style="FONT-SIZE: 14px; COLOR: black; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 19px; BACKGROUND-COLOR: #7ec3bf; TEXT-ALIGN: center; BORDER-BOTTOM-STYLE: none" align=center colSpan=2><SPAN>产地信息添加</SPAN></TD></TR><TR><TD style="WIDTH: 100px">名称：</TD><TD style="WIDTH: 100px"><asp:TextBox id="name" runat="server"></asp:TextBox> </TD></TR><TR><TD colSpan=2><asp:Button id="Button3" onclick="Button3_Click" runat="server" Width="108px" Text="检测名称！" CausesValidation="False"></asp:Button></TD></TR><TR><TD style="WIDTH: 100px">电话：</TD><TD style="WIDTH: 100px"><asp:TextBox id="phone" runat="server"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 100px">备注：</TD><TD style="WIDTH: 100px"><asp:TextBox id="remark" runat="server" Width="175px" Rows="3" Height="121px"></asp:TextBox></TD></TR><TR><TD align=center colSpan=2><asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="54px" Text="添加"></asp:Button><asp:Button id="Button2" onclick="Button2_Click" runat="server" Width="60px" Text="更新" CausesValidation="False"></asp:Button> </TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

