<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_DailyRecord.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.SA_DailyRecord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://localhost:3193/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#tbxHandleTime').focus(function () {
                $('#lblTip').html('输入格式:22/08/2012');
            });
        });
        //        function Check() {
        //            if ($('#ContentPlaceHolder2_lblTip').html == '' || $('#ContentPlaceHolder2_lblTip').html == null) {
        //                return true;
        //            }
        //        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server">
        <%--总框架高度--%>
        <div style="height: 488px">
            <%--动态管理员信息提示栏--%>
            <div style="height: 28px; background-color: #add2da">
                <table style="width: 100%; height: 28px">
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
                            日志信息查询界面
                        </td>
                    </tr>
                </table>
            </div>
            <%--高级管理员查询普通管理员界面 --%>
            <div  background-color: #add2da;
                width: 80%; margin-left: 10%; height: 415px; margin-top: 5px">
                <%-- 搜索框--%>
                <div style="height: 8">
                    <center>
                        操作日期：
                        <asp:TextBox ID="tbxHandleTime" runat="server" Style="margin-bottom: 0px"></asp:TextBox>
                        <asp:Button ID="btnCheck" runat="server" Text="查询" OnClick="btnCheck_Click" />
                        <br />
                        <asp:Label ID="lblTip" runat="server" Font-Size="Small" ForeColor="Yellow"></asp:Label>
                    </center>
                </div>
                <%--高级管理员查询日志界面 --%>
                <div style="background-color: #add2da; width: 80%; margin-left: 10%; height: 330px;
                    margin-top: 10px;">
                    <center>
                        <%--日志信息列表--%>
                        <div id="Div1" runat="server" height="349px" width="100%" style="margin-top: 0px">
                            <asp:DataList ID="DayBookList" runat="server" Height="349px" Width="100%" DataKeyField="handleTime"
                                Style="margin-bottom: 0px" OnEditCommand="DayBookList_EditCommand">
                                <HeaderTemplate>
                                    <center>
                                        <table style="width: 100%">
                                            <tr style="width: 100%">
                                                <td style="border-color: Black; width: 16%">
                                                    操作管理员用户名
                                                </td>
                                                <td style="border-color: Black; width: 16%">
                                                    操作时间
                                                </td>
                                                <td style="border-color: Black; width: 16%">
                                                    操作对象
                                                </td>
                                                <td style="border-color: Black; width: 16%">
                                                    操作类型
                                                </td>
                                                <td style="border-color: Black; width: 16%">
                                                    操作
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <center>
                                        <table style="width: 100%">
                                            <tr style="width: 100%">
                                                <td style="width: 16%">
                                                    <asp:Label runat="server" ID="lblUserName" Text='<%#Eval("UserName")%>'></asp:Label>
                                                </td>
                                                <td style="width: 16%">
                                                    <asp:Label runat="server" ID="lblHandleTime" Text='<%#Eval("HandleTime")%>'></asp:Label>
                                                </td>
                                                <td style="width: 16%">
                                                    <asp:Label runat="server" ID="lblHandleObjects" Text='<%#Eval("HandleObjects")%>'></asp:Label>
                                                </td>
                                                <td style="width: 16%">
                                                    <asp:Label runat="server" ID="lblDayBookVerSion" Text='<%#Eval("DayBookVersion")%>'></asp:Label>
                                                </td>
                                                <td style="width: 20%">
                                                    <asp:Button ID="update" Text="查看" CommandName="Edit" runat="server" />
                                                </td>
                                            </tr>
                                        </table>
                                    </center>
                                </ItemTemplate>
                            </asp:DataList>
                        </div>
                    </center>
                    <center style="margin-top: 0px">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button ID="last" runat="server" Text="上一页" OnClick="last_Click" Height="21px" />
                                </td>
                                 <td>
                                 <asp:Label ID="ShowPages" runat ="server" ></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="next" runat="server" Text="下一页" OnClick="next_Click" />
                                </td>
                               
                            </tr>
                        </table>
                    </center>
                </div>
            </div>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
