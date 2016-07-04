<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation = "false" CodeFile="chaxun.aspx.cs" Inherits="chaxun" %>

<%@ Register Src="moudle/ascx/heardmenu.ascx" TagName="heardmenu" TagPrefix="uc4" %>

<%@ Register Src="moudle/ascx/heardmenu.ascx" TagName="menu" TagPrefix="uc3" %>

<%@ Register Src="moudle/ascx/Chaxunye.ascx" TagName="Chaxunye" TagPrefix="uc2" %>

<%@ Register Src="moudle/ascx/Cha.ascx" TagName="Cha" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="moudle/css/maincha.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="z-index: 101; left: 102px; width: 100px; position: absolute; top: 76px;
            height: 100px">
            &nbsp;<uc2:Chaxunye ID="Chaxunye1" runat="server" />
        </div>
        <div style="z-index: 102; left: 1px; ; width: 998px; position: absolute; top: 100px;
            height: 100px">
            <br />
            <div style="z-index: 101; left: 454px; top: 4px; text-align: center">
                <asp:Label ID="Label1" runat="server" Style="font-size: 18pt; text-align: center;"
                    Text="信息表" ForeColor="Maroon"></asp:Label></div>
            <br />
        <div id="center"  runat="server" style="z-index: 101; left: 0px; width: 996px; top: 181px;
            height: 1px; text-align: center;">
            &nbsp;&nbsp;
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <asp:GridView ID="GridView1"  OnRowDeleting="GridView1_RowDeleting"  OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing"
 runat="server"  >
                <Columns>
                    <asp:TemplateField HeaderText="删除" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                Text="删除"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False" HeaderText="修改">
                        <ItemTemplate>
                            <asp:linkButton ID="ImageButton1"  runat="server"     CausesValidation="false" 
  CommandArgument='<%# Eval("ID") %>'   CommandName="xg"
                                  Text="修改" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
            &nbsp;
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Excel" BackColor="Green" ForeColor="White" />
           
            
            </div>
            <br />
            &nbsp;<br />
        </div>
        <div style="z-index: 103; left: 340px; width: 12px; position: absolute; top: 30px;
            height: 32px">
            <uc4:heardmenu ID="Heardmenu1" runat="server" />
          
        </div>
    
    </div>
</form>
</body>
</html>
