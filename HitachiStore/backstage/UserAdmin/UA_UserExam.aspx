<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UA_UserExam.aspx.cs" Inherits="HitachiStore.backstage.UserAdmin.UA_UserExam" %>
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
                <table style="width: 100%; height: 28px;  background-color: #add2da">
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
            <div style="background-color: #353c44; height: 28px; border-style: solid; border-width:1px; border-color: White;
                border-width: 3px">
                <table style="width: 100%; height: 28px">
                    <tr>
                        <td style="width: 3%">
                        </td>
                        <td style="width: 97%; text-align: left; color: White; font-size: smaller">
                            用户查询
                        </td>
                    </tr>
                </table>
            </div>
            <%--根据用户ID对用户进行搜索的搜索框--%>
            <div style=" background-color: #add2da; width: 80%; margin-left: 10%; height: 410px; margin-top: 5px">
                <%-- 搜索框--%>
                <div style="height: 8">
                    <center>
                            用户名：
                            <asp:TextBox ID="tbxUserName" runat="server"></asp:TextBox>
               
                            <asp:Button ID="Enter" runat="server" Text="查询" 
                                style="margin-left: 0px"  onclick="Enter_Click" />
                    </center>
                </div>
                <%--用户信息列表--%>
                <div id="Div1" runat="server" height="350px" width="100%" style="margin-top: 0px">
                    <asp:DataList ID="UserList" runat="server" Height="350px" Width="100%" 
                        Style="margin-bottom: 0px" oneditcommand="UserList_EditCommand"  
                        DataKeyField="UserName" ondeletecommand="UserList_DeleteCommand"
                        >
                        <HeaderTemplate>
                            <center>
                                <table style="width: 100%">
                                    <tr style="width: 100%">
                                        <td style="border-color: Black; width: 16%">
                                            用户ID
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            用户名
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            用户类型
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
                                            <asp:Label runat="server" ID="testLabel" Text='<%#Eval("UserID")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="Label3" Text='<%#Eval("UserName")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="Label4" Text='<%#Eval("aUsertype")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="Label5" Text='<%#Eval("UserTrueName")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label runat="server" ID="Label6" Text='<%#Eval("RegistTime")%>'></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Button ID="update" Text="修改" runat="server" CommandName="Edit"  /><asp:Button runat="server" ID="delete"
                                                Text="删除"  CommandName ="Delete"/>
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
                                <asp:Button ID="last" runat="server" Text="上一页" onclick="last_Click" />
                            </td>
                            <td><asp:Label ID="ShowPages" runat ="server" ></asp:Label></td>
                            <td>
                                <asp:Button ID="next" runat="server" Text="下一页" onclick="next_Click" />
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
