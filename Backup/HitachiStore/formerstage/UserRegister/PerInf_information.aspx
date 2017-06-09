<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerInf_information.aspx.cs"
    Inherits="HitachiStore.formerstage.UserRegister.PerInf_information" MasterPageFile="~/formerstage/stage_Master/PersonIfor.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .a
        {
            z-index: 100;
            top: 0px;
            left: 0px;
            background-color: #000;
            filter: alpha(opacity=60);
            -moz-opacity: 0.6;
            opacity: 0.6;
        }
    </style>
    <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">
        function aaa() {
            var a = document.getElementById("<%=tbxAge.ClientID %>").value;
            $.ajax({
                type: "Post",
                contentType: "application/json",
                url: "PerInf_information.aspx/a",
                data: "{content:'" + a + "'}",
                datatype: "json",
                success: function (result) {
                    $("#lbShow").html(result.d);
                    document.getElementById("btnSubmit").removeAttribute("disabled");
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
        function bbb() {
            var a = document.getElementById("<%=tbxPhone.ClientID%>").value;
            $.ajax({
                type: "Post",
                contentType: "application/json",
                url: "PerInf_information.aspx/b",
                data: "{content:'" + a + "'}",
                datatype: "json",
                success: function (result) {
                    $("#lbPhone").html(result.d);
                    document.getElementById("btnSubmit").removeAttribute("disabled");
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
        function ccc() {
            var a = document.getElementById("<%=tbxQQ.ClientID%>").value;
            $.ajax({
                type: "Post",
                contentType: "application/json",
                url: "PerInf_information.aspx/c",
                data: "{content:'" + a + "'}",
                datatype: "json",
                success: function (result) {
                    $("#lbQQ").html(result.d);
                    document.getElementById("btnSubmit").removeAttribute("disabled");
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    </script>
    <script type="text/javascript">
        function ablur() {
            document.getElementById("btnSubmit").removeAttribute("disabled");
        }
    </script>
    <%--全局--%>
    <div id="div_Whole" style="height: 600px; border: 1px solid #ed1100;" align="center">
        <%--样式 --%>
        <div id="div_topItem" style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
            background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
            color: White">
            <strong>个人中心-个人信息</strong>
        </div>
        <%--控件--%>
        <div id="div_Content" style="margin-top: 20px">
            <div style="width: 80%; height: 23px; text-align: left; margin-top: 15px">
                <a style="background-image: url(../../image/微条.jpg); background-repeat: repeat; font-size: 21px">
                    个人信息</a></div>
            <center>
                <table id="table_Content" cellpadding="5px" width="80%" style="border-color: #ed1100;
                    border-style: solid; border-width: 1px">
                    <tr>
                        <td align="right" style="width: 40%; font-size: 18pt; height: 40px;">
                            昵称:
                        </td>
                        <td align="left" style="font-size: 18pt; height: 40px;">
                            <asp:TextBox runat="server" ID="tbxNickName" Width="202px" Height="24px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" ClientIDMode="Static" MaxLength="20"
                                onblur="ablur()"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt; height: 40px;">
                            真实姓名:
                        </td>
                        <td align="left" style="font-size: 18pt; height: 40px;">
                            <asp:TextBox runat="server" ID="tbxTrueName" Width="202px" Height="24px" BorderColor="Red"
                                BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt; height: 40px;">
                            年龄:
                        </td>
                        <td align="left" style="font-size: 18pt; height: 40px;">
                            <asp:TextBox runat="server" ID="tbxAge" MaxLength="2" Width="202px" Height="24px"
                                BorderColor="Red" BorderWidth="1px" onblur="aaa()"></asp:TextBox>
                            <asp:Label runat="server" ID="lbShow" Font-Size="10pt" ClientIDMode="Static"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 40px; font-size: 18pt">
                            性别:
                        </td>
                        <td align="left" style="height: 40px;">
                            <asp:RadioButton runat="server" Text="男" ID="rbtnMen" GroupName="Sex" />
                            <asp:RadioButton runat="server" Text="女" ID="rbtnWoman" GroupName="Sex" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt; height: 40px;">
                            手机号:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxPhone" MaxLength="11" Width="202px" Height="24px"
                                BorderColor="Red" BorderWidth="1px" onblur="bbb()"></asp:TextBox>
                            <asp:Label ID="lbPhone" runat="server" Font-Size="10pt" ClientIDMode="Static"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt; height: 40px;">
                            QQ:
                        </td>
                        <td align="left" style="font-size: 18pt; height: 40px;">
                            <asp:TextBox runat="server" ID="tbxQQ" MaxLength="20" Width="202px" Height="24px"
                                BorderColor="Red" BorderWidth="1px" onblur="ccc()"></asp:TextBox>
                            <asp:Label runat="server" ID="lbQQ" Font-Size="10pt" ClientIDMode="Static"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt;">
                            收货地址:
                        </td>
                        <td align="left">
                            <div>
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:RadioButton runat="server" Text="是否为默认" ID="rbtnAddress1" GroupName="Address" />
                                    <asp:TextBox runat="server" ID="tbxAddress1" Width="202px" Height="24px" BorderColor="Red"
                                        BorderWidth="1px" onblur="ablur()"></asp:TextBox><br />
                                    <br />
                                    <asp:RadioButton runat="server" Text="是否为默认" ID="rbtnAddress2" GroupName="Address" />
                                    <asp:TextBox runat="server" ID="tbxAddress2" Width="202px" Height="24px" BorderColor="Red"
                                        BorderWidth="1px" onblur="ablur()"></asp:TextBox><br />
                                    <br />
                                    <asp:RadioButton runat="server" Text="是否为默认" ID="rbtnAddress3" GroupName="Address" />
                                    <asp:TextBox runat="server" ID="tbxAddress3" Width="202px" Height="24px" BorderColor="Red"
                                        BorderWidth="1px" onblur="ablur()"></asp:TextBox></asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="font-size: 18pt; height: 60px;">
                            <asp:Button Text="提交" ID="btnSubmit" Width="150px" runat="server" OnClick="btnSubmit_Click"
                                Height="30px" Style="background-color: #ed1100; background-image: url(../../image/微条.jpg)"
                                BorderStyle="Solid" BorderWidth="1px" ClientIDMode="Static" ForeColor ="White"  />
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <%--弹出层--%>
        <asp:Panel runat="server" ID="panelShow" Width="250px" Height="100px" BorderColor="Red"
            BackColor="#FFCCCC" BorderStyle="Solid" BorderWidth="2px">
            <div style="background-image: url(../../image/微条.jpg); text-align: left; height: 25px">
                个人中心-个人信息
            </div>
            <div style="margin-top: 20px">
                <asp:Label ID="lbtext" runat="server" Text="您确认要提交？" Style="margin-top: 20px;"></asp:Label>
            </div>
            <div style="margin-top: 15px">
                <asp:Button ID="OkButton" Height="25px" runat="server" Text="确定" OnClick="OkButton_Click"
                    Style="background-image: url(../../image/标题头微条.jpg)" Width="70px" BorderStyle="None"
                    ForeColor="White" />
                <asp:Button ID="CancelButton" Height="25" runat="server" Text="取消" Width="70px" Style="background-image: url(../../image/标题头微条.jpg)"
                    BorderStyle="None" ForeColor="White" />
            </div>
        </asp:Panel>
        <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" BackgroundCssClass="a" runat="server"
            TargetControlID="tbxTrueName" DropShadow="true" PopupControlID="panelShow" X="550"
            Y="300">
        </AjaxToolkit:ModalPopupExtender>
        <%--footer--%>
        <div id="div_bottomBlank">
        </div>
    </div>
</asp:Content>
