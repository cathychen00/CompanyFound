<%@ Page Language="C#" MasterPageFile="~/moudle/MasterPage.master" AutoEventWireup="true" CodeFile="ADDyun.aspx.cs" Inherits="ADDyun" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <div style="z-index: 101; left: 0px; width: 32px; position: absolute; top: 0px; height: 100px">
        <div style="z-index: 109; left: 516px; width: 116px; position: absolute; top: 112px;
            height: 90px">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" Height="30px" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="1" Width="156px" />
            <asp:ValidationSummary ID="ValidationSummary2" runat="server" Height="39px" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="2" Width="157px" DisplayMode="SingleParagraph" />
            <asp:ValidationSummary ID="ValidationSummary3" runat="server" ShowMessageBox="True"
                ShowSummary="False" ValidationGroup="3" Width="161px" />
        </div>
        <div style="z-index: 110; left: 522px; width: 100px; position: absolute; top: 280px;
            height: 100px">
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=.\SqlExpress;Initial Catalog=DbName;User ID=sa;pwd=sa;"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [gy_clientID], [gy_c_name] FROM [gy_client]">
            </asp:SqlDataSource>
        </div>
        <asp:UpdatePanel id="UpdatePanel1" runat="server">
            <contenttemplate>
    
        <table border="0" style="width: 504px; height: 308px">
            <tr>
                <td align="center" colspan="4" style="color: black; border-top-style: none; border-right-style: none; border-left-style: none; height: 18px; background-color: #7ec3bf; text-align: center; border-bottom-style: none">
                    运输汇总
                    <div style="z-index: 111; left: 359px; width: 91px; color: black; position: absolute;
                        top: 9px; height: 1px">
                        &nbsp;表示不能为空</div>
                    <div style="z-index: 112; left: 348px; width: 15px; color: #ff0000; position: absolute;
                        top: 9px; height: 12px">
                        *</div>
                </td>
            </tr>
            <tr>
                <td style="width: 73px; height: 6px;">
                    起始时间：</td>
                <td style="width: 8px; height: 6px">
                    <asp:TextBox ID="begintime" runat="server" Width="92px"></asp:TextBox>
                    <div style="z-index: 101; left: 199px; width: 34px; position: absolute; top: 47px;
                        height: 8px">
                        <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator10" runat="server" ControlToValidate="begintime" ErrorMessage="起始时间不能为空！"
                                ValidationGroup="3" Height="16px" Width="1px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="begintime"
                            ErrorMessage="查询汇总时，起始时间不能为空！" ValidationGroup="1" Height="12px" Width="8px">*</asp:RequiredFieldValidator></div>
                </td>
                <td style="width: 53px; height: 6px">
                    结束时间：</td>
                <td style="width: 26px; height: 6px">
                    <asp:TextBox ID="endtime" runat="server" Width="92px"></asp:TextBox>
                    <div style="z-index: 103; left: 452px; width: 37px; position: absolute; top: 45px;
                        height: 1px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="endtime"
                            ErrorMessage="结束时间不能为空！" ValidationGroup="3" Height="6px" Width="7px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="endtime" ErrorMessage="查询汇总时，结束时间不能为空！"
                                ValidationGroup="1" Height="9px" Width="1px">*</asp:RequiredFieldValidator></div>
                </td>
            </tr>
            <tr>
                <td style="width: 73px; height: 2px">
                    销售单位：</td>
                <td style="width: 8px; height: 2px">
                    <asp:DropDownList ID="client" runat="server" DataSourceID="SqlDataSource1" DataTextField="gy_c_name"
                        DataValueField="gy_clientID">
                    </asp:DropDownList><SPAN style="FONT-SIZE: 10pt; COLOR: #ff3333"> &nbsp; </SPAN>
                    <div style="z-index: 102; left: 186px; width: 33px; position: absolute; top: 89px;
                        height: 1px; font-size: 10pt; color: #ff3333;">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="client"
                            ErrorMessage="查询汇总时，销售单位不能为空！" ValidationGroup="1" Height="16px" Width="1px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator12" runat="server" ControlToValidate="client" ErrorMessage="销售单位不能为空！"
                                ValidationGroup="3" Height="3px" Width="5px">*</asp:RequiredFieldValidator></div>
                </td>
                <td style="width: 53px; height: 2px">
                    <span style="font-size: 8pt; color: #4f6b72">
                            车号：</span></td>
                <td style="font-size: 8pt; width: 26px; color: #4f6b72; height: 2px">
                    <asp:TextBox ID="carno" runat="server" Width="92px"></asp:TextBox>
                    <div style="z-index: 104; left: 454px; width: 37px; position: absolute; top: 88px;
                        height: 9px">
                        <asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="carno" ErrorMessage="查询汇总时，车号不能为空！"
                                ValidationGroup="1" Height="12px" Width="7px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="carno"
                            ErrorMessage="车号不能为空！" ValidationGroup="3" Height="15px" Width="8px">*</asp:RequiredFieldValidator></div>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 14px">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="查询汇总" ValidationGroup="1"
                        Width="132px" /></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 5px">
                    总车数：</td>
                <td style="width: 8px; height: 5px">
                    <asp:TextBox ID="totalcar" runat="server" ForeColor="#C00000" Width="65px"></asp:TextBox><span
                        style="font-size: 10pt; color: #ff3333"><SPAN style="FONT-SIZE: 8pt; COLOR: #4f6b72">&nbsp; </SPAN>
                        <div style="z-index: 105; left: 175px; width: 59px; position: absolute; top: 170px;
                            height: 14px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="totalcar"
                                ErrorMessage="总车数不能为空！" ValidationGroup="3" Height="1px" Width="4px">*</asp:RequiredFieldValidator></div>
                    </span></td>
                <td style="width: 53px; height: 5px">
                    总吨位：</td>
                <td style="width: 26px; height: 5px">
                    <asp:TextBox ID="totalamount" runat="server" ForeColor="#C00000" Width="65px"></asp:TextBox><span
                        style="font-size: 10pt; color: #ff3333">
                        <div style="z-index: 106; left: 427px; width: 41px; position: absolute; top: 168px;
                            height: 21px">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="totalamount"
                                ErrorMessage="计算总额时，总吨位不能为空！" ValidationGroup="2" Height="2px" Width="1px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator15" runat="server" ControlToValidate="totalamount"
                                    ErrorMessage="总吨位不能为空！" ValidationGroup="3" Height="1px" Width="8px">*</asp:RequiredFieldValidator></div>
                    </span></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 37px;">
                    运价：</td>
                <td style="width: 8px; height: 37px;">
                    <asp:TextBox ID="price" runat="server" Width="65px"></asp:TextBox>
                    <div style="z-index: 107; left: 169px; width: 34px; position: absolute; top: 214px;
                        height: 1px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="price"
                            ErrorMessage="运价不能为空！" ValidationGroup="3" Height="5px" Width="1px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator7" runat="server" ControlToValidate="price" ErrorMessage="计算总额时，运价不能为空！"
                                ValidationGroup="2" Height="1px" Width="3px">*</asp:RequiredFieldValidator></div>
                </td>
                <td style="width: 53px; height: 37px;">
                    里程：</td>
                <td style="width: 26px; height: 37px;">
                    <asp:TextBox ID="mileage" runat="server" Width="65px"></asp:TextBox>
                    <div style="z-index: 108; left: 423px; width: 42px; position: absolute; top: 215px;
                        height: 7px">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="mileage"
                            ErrorMessage="计算总额时，里程不能为空！" ValidationGroup="2" Height="7px" Width="4px">*</asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator17" runat="server" ControlToValidate="mileage" ErrorMessage="里程不能为空！"
                                ValidationGroup="3" Height="1px" Width="6px">*</asp:RequiredFieldValidator></div>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 34px">
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="计算总额" ValidationGroup="2"
                        Width="132px" /></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 18px">
                    总额：</td>
                <td colspan="3" style="height: 18px">
                    <asp:TextBox ID="total" runat="server" ForeColor="Red" Width="90px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator9" runat="server" ControlToValidate="total" ErrorMessage="总额不能为空！"
                        ValidationGroup="3">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 13px">
                    起点：</td>
                <td style="width: 8px; height: 13px">
                    <asp:TextBox ID="begin" runat="server" Width="90px"></asp:TextBox></td>
                <td style="width: 53px; height: 13px">
                    终点：</td>
                <td style="width: 26px; height: 13px">
                    <asp:TextBox ID="end" runat="server" Width="90px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px; height: 23px">
                    备注：</td>
                <td colspan="3" style="height: 23px">
                    <asp:TextBox ID="remark" runat="server" Height="78px" TextMode="MultiLine" Width="395px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 73px">
                    操作员：</td>
                <td colspan="3">
                    <asp:Label ID="user" runat="server" ForeColor="#C00000" Text="Label" Width="63px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="4" style="height: 32px">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="添加" ValidationGroup="3" Width="69px" /><asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="更新" Width="69px" /></td>
            </tr>
        </table></contenttemplate>
        </asp:UpdatePanel>
        </div>
     
   
</asp:Content>

