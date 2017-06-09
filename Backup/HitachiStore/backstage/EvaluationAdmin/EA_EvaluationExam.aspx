<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EA_EvaluationExam.aspx.cs" Inherits="HitachiStore.backstage.EvaluationAdmin.EA_EvaluationExam" %>
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
                            用户评价查询
                        </td>
                    </tr>
                </table>
            </div>
            <%--根据单个商品对评价搜索的搜索框--%>
            <div style=" background-color: #add2da; width: 80%; margin-left: 10%; height: 410px; margin-top: 5px">
                <div style="height: 8">
                    <center>
                        评价ID:
                        <asp:TextBox ID="txtEvaluateID" runat="server" AutoPostBack="True" 
                            Height="19px" style="margin-bottom: 0px"></asp:TextBox>
                        <asp:Button ID="Enter" runat="server" Height="20px" OnClick="Enter_Click" 
                            Style="margin-left: 0px" Text="查询" Width="58px" />
                    </center>
                </div>
                <%--订单信息列表--%>
                <div ID="Div1" runat="server" height="350px" style="margin-top: 0px" 
                    width="100%">
                    <asp:DataList ID="EvaluateList" runat="server" DataKeyField="EvaluateID" 
                        Height="350px" ondeletecommand="EvaluateList_DeleteCommand" 
                        oneditcommand="EvaluateList_EditCommand" Style="margin-bottom: 0px" 
                        Width="100%">
                        <HeaderTemplate>
                            <center>
                                <table style="width: 100%">
                                    <tr style="width: 100%">
                                        <td style="border-color: Black; width: 16%">
                                            评价ID
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            用户名 
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            订单ID
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            评价等级 
                                        </td>
                                        <td style="border-color: Black; width: 16%">
                                            评价时间 
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
                                            <asp:Label ID="testLabel" runat="server" Text='<%#Eval("EvaluateID")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("EvaluateContent")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label ID="Label4" runat="server" Text='<%#Eval("OrderID")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("aEvaluateGrade")%>'></asp:Label>
                                        </td>
                                        <td style="width: 16%">
                                            <asp:Label ID="Label6" runat="server" Text='<%#Eval("EvaluateTime")%>'></asp:Label>
                                        </td>
                                        <td style="width: 20%">
                                            <asp:Button ID="update" runat="server" CommandName="Edit" Text="修改" />
                                            <asp:Button ID="delete" runat="server" CommandName="Delete" Text="删除" />
                                        </td>
                                    </tr>
                                </table>
                            </center>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <%--  AjAx控件--%>
                <ajaxToolkit:ToolkitScriptManager ID="qwe" runat="server">
                </ajaxToolkit:ToolkitScriptManager>
                <ajaxToolkit:FilteredTextBoxExtender ID="Validate" runat="server" 
                    FilterType="Numbers" TargetControlID="txtEvaluateID">
                </ajaxToolkit:FilteredTextBoxExtender>
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="last" runat="server" onclick="last_Click" Text="上一页" />
                            </td>
                            <td>
                                <asp:Label ID="ShowPages" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="next" runat="server" onclick="next_Click" Text="下一页" />
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
