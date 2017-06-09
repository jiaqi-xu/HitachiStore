<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_AddGood.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_AddGood" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
    <style type="text/css">
        .modalBackground
        {
            background-color: Grey;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptMaster1" runat="server">
        </asp:ScriptManager>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopup2" runat="server" TargetControlID="btnCancel"
            CancelControlID="btnCancel" PopupControlID="ModalPanel" BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="ModalPanel" runat="server" Width="668px" Height="505px" BackColor="#b6dffa">
            <div style="text-align: left; width: 100%; padding-left: 5px; padding-top: 5px">
                <asp:DataList ID="DataList1" runat="server" Width="100%">
                    <HeaderTemplate>
                        <asp:Label ID="lbl_Property" runat="server" Text="属性如下"></asp:Label>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table style="width: 100%; text-align: left">
                            <tr>
                                <td style="width: 50%;">
                                    <asp:Label ID="lbl_PropertyContent" runat="server" Text='<%#Eval("PropertyName") %>'></asp:Label>
                                </td>
                                <td style="width: 50%;">
                                    <asp:DropDownList ID="dpl_PropertyContent" runat="server" DataSource=' <%#DropDownSource%> '
                                        Width="150px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:DataList>
            </div>
            <div style="height: 20px">
                请填写商品信息
            </div>
            <div style="width: 100%;">
                <table style="width: 100%; text-align: left">
                    <tr>
                        <td style="width: 50%">
                            名称:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%">
                            添加数量:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxCount"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%">
                            价格:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxPrice"></asp:TextBox>
                        </td>
             
                    <tr>
                        <td style="width: 50%">
                            图片说明:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxPicexplain"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 50%">
                            图片路径:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbxPriurl"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="width: 100%; height: 149px">
                <div style="float: left; padding-left: 20px; margin-top: 80px; height: 25px;">
                    <asp:Label ID="lbl_tip" runat="server" Text="tip" Font-Size="Large"></asp:Label>
                </div>
                <div style="width: 112px; height: 26px; margin-left: 500px; margin-top: 80px; float: left;
                    text-align: center;">
                    <asp:Button ID="btnOK" Text="添加" runat="server" OnClick="btnOK_Click" />
                    <asp:Button ID="btnCancel" Text="取消" runat="server" />
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
            <%--总框架高度--%>
            <div style="height: 510px">
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
                                商品管理员商品添加管理
                            </td>
                        </tr>
                    </table>
                </div>
                <%--商品添加管理--%>
                <div style="background-color: #add2da; width: 80%; margin-left: 10%; height: 360px;
                    margin-top: 40px">
                    <center>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="dplFirstClum" runat="server" Height="23px" Width="100px" AutoPostBack="True"
                                        OnSelectedIndexChanged="dplFirstClum_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    一级类目
                                </td>
                                <td>
                                    <asp:DropDownList ID="dplSecondClum" runat="server" Height="23px" Width="100px" AutoPostBack="True"
                                        OnSelectedIndexChanged="dplSecondClum_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    二级类目
                                </td>
                                <td>
                                    <asp:DropDownList ID="dplThirdClum" runat="server" Height="23px" Width="100px" AutoPostBack="True"
                                        OnSelectedIndexChanged="dplThirdClum_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    三级类目
                                </td>
                            </tr>
                        </table>
                        <table style="width: 100%">
                            <tr>
                                <td style="vertical-align: top; width: 50%;">
                                    属性列表：<asp:Button ID="Button1" runat="server" Text="商品添加" OnClick="Button1_Click"
                                        BackColor="White" BorderColor="Black" BorderStyle="Solid" />
                                </td>
                                <td style="vertical-align: top; width: 50%;">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
                <div style="height: 25px; margin-top: 20px">
                    <center>
                        <asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="Blue" Font-Bold="true"></asp:Label>
                    </center>
                </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>
