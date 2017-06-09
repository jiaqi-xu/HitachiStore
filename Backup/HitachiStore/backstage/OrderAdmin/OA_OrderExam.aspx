<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OA_OrderExam.aspx.cs" Inherits="HitachiStore.backstage.OrderAdmin.OA_OrderExam" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
            <div style="height: 28px;">
                <table style="width: 100%; height: 28px; background-color: #add2da">
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
                            消费订单查询
                        </td>
                    </tr>
                </table>
            </div>
            <%--根据订单ID对订单搜索的搜索框--%>
            <div align="center">
                <div style=" background-color: #add2da; 
                    width: 80%; height: 410px; margin-top: 10px">
                    <div style="margin-top: 0px; width: 100%; height: 30px;">
                        <div style="height: 30px;">
                            <iframe src="TotalDeal.aspx" id="NotDeal" style="height: 30px; float: left"></iframe>
                            <div>
                                OrderID：
                                <asp:TextBox ID="tbxOrderID" runat="server" MaxLength="18"></asp:TextBox>
                                <asp:Button ID="Enter" runat="server" Text="查询" Height="21px" Style="margin-left: 0px"
                                    Width="58px" OnClick="Enter_Click" />
                            </div>
                        </div>
                        <asp:DataList ID="OrderList" runat="server" Height="330px" Width="90%">
                            <HeaderTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="border-color: Black; width: 14%">
                                            订单号
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            订单状态
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            用户名
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            商品名称
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            总价
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            操作
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="border-color: Black; width: 14%">
                                            <asp:Label ID="OrderID" runat="server" Text='<%#Eval("OrderID") %>'></asp:Label>
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            <asp:Label ID="IsDeal" runat="server" Text='<%#Eval("IsDeal") %>'></asp:Label>
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            <asp:Label ID="UserID" runat="server" Text='<%#Eval("ReceiveStr") %>'>
                                            </asp:Label>
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            <asp:Label runat="server" ID="SingleGoodID" Text='<%#Eval("Getstr") %>'></asp:Label>
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            <asp:Label ID="TotalPrices" runat="server" Text='<%#Eval("TotalPrices") %>'></asp:Label>
                                        </td>
                                        <td style="border-color: Black; width: 14%">
                                            <a href="OA_OrderInfoma.aspx?OrderID=<%#Eval("OrderID") %>">进入查看</a>
                                            <%-- <asp:Button ID="EnterOrder" Text ="进入查看"  runat ="server"  CommandName="EnterOrder" />--%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <ajaxToolkit:ToolkitScriptManager ID="Ajax" runat="server">
                        </ajaxToolkit:ToolkitScriptManager>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FOrderID" TargetControlID="tbxOrderID" runat="server"
                            FilterType="Numbers">
                        </ajaxToolkit:FilteredTextBoxExtender>
                        <table cellspacing="10px" style="height: 20px">
                            <tr>
                                <td style="height: 10px">
                                    <asp:Button ID="Last" runat="server" Text="上一页" OnClick="Last_Click" />
                                </td>
                                <td style="height: 10px">
                                    <asp:Label ID="ShowPages" runat="server"></asp:Label>
                                </td>
                                <td style="height: 10px">
                                    <asp:Button ID="next" runat="server" Text="下一页" OnClick="next_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
