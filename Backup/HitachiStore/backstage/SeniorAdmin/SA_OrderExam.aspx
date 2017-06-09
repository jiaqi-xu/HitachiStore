<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_OrderExam.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.SA_OrderExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                            订单信息查询界面
                        </td>
                    </tr>
                </table>
            </div>
            <%--高级管理员查询普通管理员界面 --%>
            <div style=" background-color: #add2da;
                width: 80%; margin-left: 10%; height: 410px; margin-top: 5px">
                <center>
                    <%-- 搜索框--%>
                    <div style="height: 8">
                        <center>
                              订单ID:
                            <asp:TextBox ID="OrderID" runat="server" style="width: 148px"></asp:TextBox>
                            <asp:Button ID="Enter" runat="server" Text="查询"  OnClick="Enter_Click" />
                        </center>
                    </div>
                    </center>
            <%--订单信息列表--%>
            <div id="Div1" runat="server" height="350px" width="100%"  style="margin-top: 0px" >
                <asp:DataList ID="OrderList" runat="server" Height="350px" Width="100%"  
                    DataKeyField="OrderID" Style="margin-bottom: 0px" 
                    oneditcommand="OrderList_EditCommand" >
                    <HeaderTemplate>
                        <center>
                            <table style="width: 100%">
                                <tr style="width: 100%">
                                    <td style="border-color: Black; width: 16%">
                                       订单ID
                                    </td>
                                    <td style="border-color: Black; width: 16%">
                                        用户ID
                                    </td>
                                    <td style="border-color: Black; width: 16%">
                                       总价
                                    </td>
                                    <td style="border-color: Black; width: 16%">
                                       提交时间
                                    </td>
                                    <td style="border-color: Black; width: 16%">
                                       交易状态
                                    </td>
                                    <td style="border-color: Black; width: 20%">
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
                                        <asp:Label runat="server" ID="testLabel" Text='<%#Eval("OrderID")%>'></asp:Label>
                                    </td>
                                    <td style="width: 16%">
                                        <asp:Label runat="server" ID="Label3" Text='<%#Eval("UserID")%>'></asp:Label>
                                    </td>
                                    <td style="width: 16%">
                                        <asp:Label runat="server" ID="Label4" Text='<%#Eval("TotalPrices")%>'></asp:Label>
                                    </td>
                                    <td style="width: 16%">
                                        <asp:Label runat="server" ID="Label5" Text='<%#Eval("SubmitTime")%>'></asp:Label>
                                    </td>
                                    <td style="width: 16%">
                                        <asp:Label runat="server" ID="Label6" Text='<%#Eval("aTradeStatus")%>'></asp:Label>
                                    </td>
                                    <td style="width: 20%">
                                        <asp:Button ID="btnCheck" Text="查看" runat="server"  CommandName="Edit" />
                                    </td>
                                </tr>
                            </table>
                        </center>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <center>
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="last" runat="server" Text="上一页" OnClick="last_Click" />
                        </td>
                        <asp:Label ID="ShowPages" runat ="server" ></asp:Label>
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
