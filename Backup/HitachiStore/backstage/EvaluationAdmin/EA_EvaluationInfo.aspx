<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EA_EvaluationInfo.aspx.cs" Inherits="HitachiStore.backstage.EvaluationAdmin.EA_EvaluationInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('*').click(function () {
                $('#lblCheck').text('');
            });
        });
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <%--总框架高度--%>
    <div style="height: 600px">
        <%--动态管理员信息提示栏--%>
        <div style="height: 28px;">
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
                        单个商品评价
                    </td>
                </tr>
            </table>
        </div>
        <%-- 主界面 --%>
        <div>
        <center>
            <div style="width: 60%; background-color: #add2da;  height: 350px;
                margin-top: 100px" align="center">
                <div style="height: 25px; margin-top: 20px">
                    <center>
                        <asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="#ff0066" Font-Bold="true"></asp:Label>
                    </center>
                </div>
                <table style="width: 70%;" align="center">
                    <%--EvaluateID--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbEvaluateID" runat="server" Text="评价ID:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtEvaluateID" runat="server" Width="155px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--GoodID--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbGoodID" runat="server" Text="商品ID:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtGoodID" runat="server" Width="155px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <%--EvaluateContent--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbEvaluateContent" runat="server" Text="评价内容:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <%--多行的评价--%>
                            <asp:TextBox ID="txtEvaluateContent" runat="server" Width="155px" ReadOnly="true"
                                TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <%--EvaluateTime--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbEvaluateTime" runat="server" Text="评价时间:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtEvaluateTime" runat="server" Width="155px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <%--UserID--%>
                    <tr align="left">
                        <td style="height: 39px">
                            <asp:Label ID="lbUserID" runat="server" Text="用户ID:"></asp:Label>
                        </td>
                        <td style="height: 39px">
                            <asp:TextBox ID="txtUserID" runat="server" Width="155px" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <%--EvaluateGrade--%>
                    <tr>
                        <td style="text-align: left">
                            <asp:Label ID="lbEvaluateGrade" runat="server" Text="评价等级:"></asp:Label>
                        </td>
                        <td style="text-align: left">
                            <%--三种评价--%>
                            <asp:Label ID="lbGoodEvaluateGrade" runat="server" Enabled="false"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div style ="margin-top :10px;" align="center">
                    <asp:Button ID="btnAlter" runat="server" Text="删除" Height="37px" Width="75px" type="submit"
                        OnClick="btnAlter_Click" /> &nbsp <asp:Button ID="btnBack" runat="server" 
                        Text="返回" Width="75px" Height="37px" onclick="btnBack_Click" /></div>
            </div>
            </center>
        </div>
    </div>
    </div>
    </form>
</body>
</html>
