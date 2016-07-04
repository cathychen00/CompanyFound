<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Src="moudle/ascx/login.ascx" TagName="login" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>51aspx.com</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <div style="z-index: 101; left: 0px; background-image: url(image/index背景.gif); width: 1000px; position: absolute; top: 0px; height: 727px">
            <div style="z-index: 101; left: 435px; width: 205px; position: absolute; top: 418px; height: 100px">
                <uc1:login ID="Login1" runat="server" />
            </div>
        </div>
    </form>
</body>
</html>
