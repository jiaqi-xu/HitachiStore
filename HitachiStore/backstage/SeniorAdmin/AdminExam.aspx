<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminExam.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.AdminExam" %>

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
                            管理员信息查询界面
                        </td>
                    </tr>
                </table>
            </div>
            <%--高级管理员查询普通管理员界面 --%>
            <div style=" background-color: #add2da; 
                width: 80%; margin-left: 10%; height: 410px; margin-top: 5px">
                <%-- 搜索框--%>
                <div style="height: 30px">
                    <div style="float: left">
                        用户名:
                        <asp:TextBox ID="tbxUserName" runat="server" MaxLength="40"></asp:TextBox>
                        <asp:DropDownList ID="dplStaffType" runat="server">
                            <asp:ListItem Value="5"> 商品管理员</asp:ListItem>
                            <asp:ListItem Value="2">订单管理员</asp:ListItem>
                            <asp:ListItem Value="4">用户管理员</asp:ListItem>
                            <asp:ListItem Value="3">评价管理员</asp:ListItem>
                            <asp:ListItem Value="1">高级管理员</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button ID="btnActive" runat="server" Text="激活" BorderColor="Black" BorderStyle="Solid" OnClick="btnActive_Click" />
                        <asp:Button ID="btnEnter" runat="server" Text="查询" BorderColor="Black" BorderStyle="Solid" OnClick="btnEnter_Click" />
                    </div>
                    <div style="float: right; height: 30px">
                        <iframe id="NotActivate" runat="server" src="NotActivate.aspx" height="30px" style="float: right;
                            width: 200px"></iframe>
                    </div>
                </div>
                <%--普通管理员信息列表--%>
                <div id="Div1" runat="server" height="350px" width="100%" style="margin-top: 0px">
                    <asp:DataList ID="AdminList" runat="server" Height="350px" Width="100%" Style="margin-bottom: 0px"
                        OnDeleteCommand="AdminList_DeleteCommand" OnEditCommand="AdminList_EditCommand">
                        <HeaderTemplate>
                            <center>
                                <table style="width: 100%">
                                    <tr style="width: 100%">
                                        <td style="border-color: Black; width: 16%">
                                            管理员ID
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            用户名
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            管理员类型
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            真实姓名
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            注册时间
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
                                            <asp:Label runat="server" ID="lblStaffID" Text='<%#Eval("StaffID")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="lblUserName" Text='<%#Eval("UserName")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="lblStaffType" Text='<%#Eval("aStaffType")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="Label5" Text='<%#Eval("TrueName")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="Label6" Text='<%#Eval("AddTime")%>'></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Button ID="update" Text="修改" CommandName="Edit" runat="server" BorderColor="Black" BorderStyle="Solid" />
                                            <asp:Button runat="server" ID="delete" CommandName="Delete" Text="删除" BorderColor="Black" BorderStyle="Solid" OnClientClick="return confirm('确定要删除吗?')" />
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
                                <asp:Button ID="last" runat="server" Text="上一页" BorderColor="Black" BorderStyle="Solid" OnClick="last_Click" />
                            </td>
                            <td>
                                <asp:Label ID="ShowPages" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="next" runat="server" Text="下一页" BorderColor="Black" BorderStyle="Solid" OnClick="next_Click" />
                            </td>
                        </tr>
                    </table>
                </center>
                <br />
            </div>
        </div>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
