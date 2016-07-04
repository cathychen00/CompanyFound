
  
<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="adduser.aspx.cs" Inherits="adduser" Title="Untitled Page" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="z-index: 102; left: 71px; width: 76px; position: absolute; top: 0px;
        height: 1px">
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
<TABLE style="WIDTH: 282px" border=0><TBODY><TR><TD style="FONT-SIZE: 12px; COLOR: black; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 19px; BACKGROUND-COLOR: #7ec3bf; TEXT-ALIGN: center; BORDER-BOTTOM-STYLE: none" colSpan=2>添加用户信息</TD></TR><TR><TD style="WIDTH: 72px; HEIGHT: 17px">姓名：</TD><TD style="WIDTH: 100px; HEIGHT: 17px"><asp:TextBox id="username" runat="server" Width="100px"></asp:TextBox> <DIV style="Z-INDEX: 101; LEFT: 272px; WIDTH: 92px; POSITION: absolute; TOP: 46px; HEIGHT: 16px"><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" Width="94px" Font-Size="Small" ErrorMessage="用户名不能为空" ControlToValidate="username">用户名不能为空</asp:RequiredFieldValidator></DIV></TD></TR><TR id="tr_jcname" runat="server"><TD colSpan=2><asp:Button id="jcname" onclick="jcname_Click" runat="server" Width="118px" Text="检测用户名" CausesValidation="False"></asp:Button></TD></TR><TR><TD style="WIDTH: 72px">密码：</TD><TD style="WIDTH: 100px"><asp:TextBox id="userpwd" runat="server" Width="100px" TextMode="Password"></asp:TextBox></TD></TR><TR id="rpwd" runat="server"><TD style="WIDTH: 72px">确认密码：</TD><TD style="WIDTH: 100px"><asp:TextBox id="userpwd1" runat="server" Width="100px" TextMode="Password"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 72px">性别：</TD><TD style="WIDTH: 100px"><asp:DropDownList id="usersex" runat="server">
                        <asp:ListItem Value="1">男</asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                    </asp:DropDownList></TD></TR><TR id="tr_userlevel" runat="server"><TD style="WIDTH: 72px">权限：</TD><TD style="WIDTH: 100px"><asp:DropDownList id="userlevel" runat="server">
                        <asp:ListItem Value="1">用户</asp:ListItem>
                        <asp:ListItem Value="2">管理员</asp:ListItem>
                    </asp:DropDownList></TD></TR><TR><TD style="HEIGHT: 19px; TEXT-ALIGN: center" colSpan=2><asp:Button id="okbtn" onclick="okbtn_Click" runat="server" Width="48px" Text="添加"></asp:Button><asp:Button id="Button1" onclick="Button1_Click" runat="server" Width="51px" Text="更新"></asp:Button></TD></TR></TBODY></TABLE>
</contenttemplate>
        </asp:UpdatePanel>
    </div>
    &nbsp;&nbsp;
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="17px" ShowMessageBox="True"
        ShowSummary="False" Width="138px" />
</asp:Content>

