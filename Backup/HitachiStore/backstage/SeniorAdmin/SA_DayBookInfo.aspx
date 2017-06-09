<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_DayBookInfo.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.SA_DayBookInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--总框架高度--%>
    <div style="height: 600px">
        <%--动态管理员信息提示栏--%>
        <div style="height: 28px">
            <table style="width: 100%; height: 28px; background-color: #add2da; border-width: 2px">
                <tr>
                    <td style="width: 3%">
                    </td>
                    <td style="width: 12%; font-size: smaller; text-align: left">
                        当前登录用户:<br />
                    </td>
                    <td style="width: 6%; text-align: left">
                        <asp:Label ID="label1" runat="server"></asp:Label>
                    </td>
                    <td style="width: 10%; font-size: smaller; text-align: left">
                        用户角色:<br />
                    </td>
                    <td style="width: 6%; text-align: left">
                        <asp:Label ID="label2" runat="server"></asp:Label>
                    </td>
                    <td style="width: 63%">
                    </td>
                </tr>
            </table>
        </div>
        <%--内容页功能说明--%>
        <div style="background-color: #353c44; height: 28px; border-style: solid; border-color: White;
            border-width: 3px">
            <table style="width: 100%; height: 28px">
                <tr>
                    <td style="width: 3%">
                    </td>
                    <td style="width: 97%; text-align: left; color: White; font-size: smaller">
                        日志详细信息
                    </td>
                </tr>
            </table>
        </div>
        <%--中间空白--%>
        <%-- 主界面 --%>
        <div>
        <center>
            <div style=" margin-top :50px;width: 40%; background-color: #add2da; height :420px; ">
                <table style ="width :80%; margin-top :10px; height :300px" align="center">
                    
                    <%--上部空白--%>
                    <%--EvaluateID--%>
                    <tr align="left">
                        <%--左边空白--%>
                        <%--StaffID--%>
                        <td style="height: 39px">
                            <asp:Label ID="lbStaffID" runat="server" Text="StaffID:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtStaffID" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--StaffName--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbUserNameName" runat="server" Text="管理员用户名:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtUserName" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--HandleTime--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbHandleTime" runat="server" Text="操作时间:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <%--多行的评价--%>
                            <asp:TextBox ID="txtHandleTime" runat="server" Width="155px" ReadOnly="true" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--HandleObjects--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbHandleObjects" runat="server" Text=" 操作对象:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtHandleObjects" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--DayBookType--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbDayBookType" runat="server" Text="操作类型:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtDayBookType" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--HandleContent--%>
                    <tr align="left">
                        <td style="height: 60px">
                            <asp:Label ID="lbHandleContent" runat="server" Text="详细内容:"></asp:Label>
                        </td>
                        <td style="height: 60px">
                            <asp:TextBox ID="txtHandleContent" runat="server" Enabled="False" TextMode="MultiLine" Width="155px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                       <td></td>
                       <td style="height: 60px" align="left">
                          <asp:Button ID="btnBack" runat="server" Text="返回到所有日志查看" OnClick="btnBack_Click" Height="37px" Width="155px" />
                       </td>
                    </tr>
                    <tr>
                       <td></td>
                       <td style="height: 60px" align="left">
                           <asp:Button ID="btnBackDay" runat="server" Text="返回到当日日志查看"  Height="37px" onclick="btnBackDay_Click"  Width="155px"/>
                       </td>
                    </tr>
                </table>
                <%--<div style ="margin-top :20px; width :100px" align="center">--%>
                <center>
                    
                   <br/><br/>
                   
                </center>
               <%-- </div>--%>
            </div>
            </center>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
