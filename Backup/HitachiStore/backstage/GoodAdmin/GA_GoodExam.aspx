<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_GoodExam.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_GoodExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--总框架高度--%>
        <div id="whole" style="height: 800px">
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
                            商品详细信息
                        </td>
                    </tr>
                </table>
            </div>
            <%--中间空白--%>
            <div>
                <table style="width: 75%; background-color: #add2da; border-style: solid; border-color: Black"
                    align="center">
                    <%--上部空白--%>
                    <%--类目选择--%>
                    <tr style="text-align: left; height: 35px">
                        <%--左边空白--%>
                        <td style="width: 75px">
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList  BorderColor="Black" BorderStyle="Solid" ID="ddlFirstClum" runat="server" Width="115px" Style="border-style: solid;
                                border-color: Black; border-width: 1px;" OnSelectedIndexChanged="ddlFirstClum_SelectedIndexChanged"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="lbFirstClum" runat="server" Text="一级类目"></asp:Label>
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList BorderColor="Black" BorderStyle="Solid" ID="ddlSecondClum" runat="server" Width="115px" Style="border-style: solid;
                                border-color: Black; border-width: 1px;" AutoPostBack="True" OnSelectedIndexChanged="ddlSecondClum_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="lbSecondClum" runat="server" Text="二级类目"></asp:Label>
                        </td>
                        <td style="width: 150px">
                            <asp:DropDownList BorderColor="Black" BorderStyle="Solid" ID="ddlThirdClum" runat="server" Width="115px" Style="border-style: solid;
                                border-color: Black; border-width: 1px;" AutoPostBack="True" OnSelectedIndexChanged="ddlThirdClum_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 150px">
                            <asp:Label ID="lbThirdClum" runat="server" Text="三级类目"></asp:Label>
                        </td>
                    </tr>
                </table>
                <div id="datalist">
                    <asp:DataList DataKeyField="GoodID" runat="server" ID="dlistGoodShow" Style="width: 100%; margin-top:30px"
                        OnEditCommand="dlistGoodShow_EditCommand">
                        <HeaderTemplate>
                            <table style="width: 90%; background-color: #add2da; border-style: solid; border-color: Black"
                                align="center">
                                <tr>
                                    <td style="width:10%">
                                        商品编号：
                                    </td>
                                    <td style="width:20%">
                                        商品名称：
                                    </td>
                                    <td style="width:15%">
                                        商品价格：
                                    </td>
                                    <td style="width:15%">
                                        商品库存：
                                    </td>
                                    <td style="width:15%">
                                        商品销量:
                                    </td>
                                    <td style="width:15%">
                                        操作：
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width: 90%; background-color: #add2da; border-style: solid; border-color: Black"
                                align="center">
                                <tr>
                                    <td style="width:10%">
                                        <%#Eval("GoodID") %>
                                    </td>
                                    <td style="width:20%">
                                        <%#Eval("GoodName") %>
                                    </td>
                                    <td style="width:15%">
                                        <%#Eval("GoodPrice") %>
                                    </td>
                                    <td style="width:15%">
                                        <%#Eval("GoodIncentory") %>
                                    </td>
                                    <td style="width:15%">
                                        <%#Eval("SalesVolume") %>
                                    </td>
                                    <td style="width:15%">
                                        <asp:Button ID="btnGoodExam" BorderColor="Black" BorderStyle="Solid" Text="查看" runat="server" CommandName="Edit" />
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <div align="center">
                        <table>
                            <tr>
                                <td>
                                    <asp:Button BorderColor="Black" BorderStyle="Solid" runat="server" ID="btnUppage" Text="上一页" OnClick="btnUppage_Click" />
                                </td>
                                <td>
                                    <asp:Label ID="ShwoPages" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button BorderColor="Black" BorderStyle="Solid" runat="server" ID="btnNextpage" Text="下一页" Style="margin-left: 20px;
                                        height: 21px;" OnClick="btnNextpage_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
