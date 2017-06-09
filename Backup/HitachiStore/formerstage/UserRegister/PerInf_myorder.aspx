<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerInf_myorder.aspx.cs"
    Inherits="HitachiStore.formerstage.UserRegister.PerInf_myorder" MasterPageFile="~/formerstage/stage_Master/PersonIfor.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center style="margin-top: 0px; height: 1000px">
        <%--全局--%>
        <div id="div_Whole" style="height: 1000px; margin-bottom: 40px; border: 1px solid #ed1100">
            <%--样式 --%>
            <div id="div_topItem" style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
                font-size: larger; padding-top: 5px; padding-left: 9px; color: White; background-repeat: repeat-x">
                个人中心——订单查看
            </div>
            <div id="div_topBlank" style="height: 80px">
            </div>
            <%--控件--%>
            <div id="div_Title" style="width: 80%; text-align: left">
                <a style="background-image: url(../../image/微条.jpg); background-repeat: repeat; font-size: 21px">
                    我的订单</a></div>
            <div style="width: 80%; height: 800px; border: 1px solid #ed1100">
                <asp:DataList ID="dlstOrder" runat="server" Width="100%">
                    <ItemTemplate>
                        <div>
                            <table style="width: 100%">
                                <tr style="background-image: url(../../image/标题头微条.jpg)">
                                    <td style="font-size: 18pt; width: 108">
                                        商品
                                    </td>
                                    <td style="font-size: 18pt; width: 108">
                                        订单号
                                    </td>
                                    <td style="font-size: 18pt; width: 108">
                                        订单商品
                                    </td>
                                    <td style="font-size: 18pt; width: 108">
                                        订单金额
                                    </td>
                                    <td style="font-size: 18pt; width: 108">
                                        下单时间
                                    </td>
                                    <td style="font-size: 18pt; width: 108">
                                        订单状态
                                    </td>
                                    <td style="font-size: 18pt">
                                        操作
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 114px; height: 108; font-size: 18pt; border-right: 1px solid Black;
                                        border-left: 1px solid Black; border-bottom: 1px solid Black">
                                       <img runat="server"  src='<%#Eval("ImgAddress") %>' style="height:108px;width:108px" />
                                    </td>
                                     <td style="height: 100px; border-right: 1px solid Black; border-bottom: 1px solid Black">
                                        <%#Eval("SaveOrderID")%>
                                    </td>
                                    <td style="height: 100px; border-right: 1px solid Black; border-bottom: 1px solid Black">
                                        <%#Eval("GoodName")%>
                                    </td>
                                    <td style="height: 100px; border-right: 1px solid Black; border-bottom: 1px solid Black">
                                        <%#Eval("TotalPrices")%>
                                    </td>
                                    <td style="height: 100px; border-right: 1px solid Black; border-bottom: 1px solid Black">
                                        <%#Eval("SubmitTime")%>
                                    </td>
                                    <td style="height: 100px; border-right: 1px solid Black; border-bottom: 1px solid Black">
                                        <%#this.Set( Eval("TradeStatus"))%>
                                    </td>
                                    <td style="height: 100px; border-right: 1px solid Black; border-bottom: 1px solid Black">
                                        <a href="../OrderExam/OrdersExam.aspx?SaveOrderID=<%#Eval("SaveOrderID") %>">查看订单</a><br />
                                        <a href="../OrderExam/CancelOrders.aspx?SaveOrderID=<%#Eval("SaveOrderID") %>">
                                            <asp:Label runat="server" Visible='<%#bool.Parse(isVisible.ToString()) %>' Text="取消订单"></asp:Label></a><br />
                                        <a href="../Evaluation/Evaluation.aspx?SaveOrderID=<%#Eval("SaveOrderID") %>">
                                            <%#this.Set(Eval("IsEvaluate"),Eval("TradeStatus"))%></a>
                                    </td>
                                </tr>
                            </table>
                            <div style="height: 10px">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:Panel runat="server">
                    <div>
                        <asp:Button ID="btnUpPage" runat="server" Text="上一页" OnClick="btnUpPage_Click" Style="height: 21px;
                            background-image: url('../../image/微条.jpg');" BorderStyle="None" />
                        <asp:Label ID="lbPage" runat="server"></asp:Label>
                        <asp:Button ID="btnDwonPage" runat="server" Text="下一页" OnClick="btnDwonPage_Click"
                            Style="height: 21px; background-image: url('../../image/微条.jpg');" BorderStyle="None" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </center>
</asp:Content>
