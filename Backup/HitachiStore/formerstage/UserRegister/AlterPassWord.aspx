<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AlterPassWord.aspx.cs"
    Inherits="HitachiStore.formerstage.UserRegister.AlterPassWord" MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function PassWordExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "AlterPassWord.aspx/PassWordExam",
                data: "{PassWord:'" + $("#tbxNewPassword").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#labPassWord").html(result.d);
                    //                    document.getElementById("ContentPlaceHolder1_lblTest").outerText = result.d;
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }


        function CPassWordExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "AlterPassWord.aspx/ConfirmPassWordExam",
                data: "{PassWord:'" + $("#tbxNewPassword").val() + "',cPassWord:'" + $("#tbxAgainPassWord").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#labAginPassWord").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
    </script>
    <center style="margin-top: 50px">
        <%--全局--%>
        <div id="div_Whole" style="height: 450px; border: 1px solid #ed1100;">
            <%--样式--%>
            <div id="div_topItem" style="height: 30px; text-align: left; background-image: url('../../image/微条.jpg');
                background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                color: White;">
                <strong>修改密码</strong></div>
            <div id="div_topBlank" style="height: 80px">
            </div>
            <%--控件--%>
            <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                <%--view1--%>
                <asp:View ID="View1" runat="server">
                    <div id="div_Content1">
                        <table cellpadding="10px" cellspacing="10px" id="table_Content1">
                            <tr>
                                <td style="font-size: 18pt; height: 60px;">
                                    已验证的身份证:
                                </td>
                                <td style="text-align: left; height: 60px;">
                                    <div>
                                        <asp:TextBox runat="server" ID="tbxFormerIdCard" Height="24px" Width="202px" BorderColor="Red"
                                            BorderWidth="1px" CausesValidation="True" Enabled="False" MaxLength="18"></asp:TextBox></div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 18pt; height: 60px;">
                                    请输入身份证号:
                                </td>
                                <td style="text-align: left; height: 60px;">
                                    <asp:TextBox runat="server" ID="tbxInputIdcard" Height="24px" Width="202px" BorderColor="Red"
                                        BorderWidth="1px" CausesValidation="True" MaxLength="18"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 60px;" align="center">
                                    
                                        <asp:Button runat="server" ID="btnView1Next" Text="下一步" Height="30px" Width="96px"
                                            Style="background-image: url('../../image/微条.jpg'); font-size: 12pt; margin-left: 308px; margin-left :50px"
                                            BorderStyle="Solid" BorderColor="Yellow" BorderWidth="1px" ForeColor ="White"  OnClick="btnView1Next_Click" />
                                    
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
                <%--view2--%>
                <asp:View ID="View2" runat="server">
                    <div id="div_Content2" style="width: 900px">
                        <table cellpadding="10px" cellspacing="10px" id="table_Content2" style="width: 100%;">
                            <tr>
                                <td style="font-size: 18pt; text-align: right; height: 60px;">
                                    请输入原来密码:
                                </td>
                                <td style="text-align: left; height: 60px;">
                                    <div style="float: left;">
                                        <asp:TextBox runat="server" ID="tbxPassWord" TextMode="Password" Height="24px" Width="202px"
                                            BorderColor="Red" BorderWidth="1px" CausesValidation="True" MaxLength="18"></asp:TextBox>
                                    </div>
                                    <div style="float: left;">
                                        &nbsp
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 18pt; text-align: right; height: 60px;">
                                    请输入新密码:
                                </td>
                                <td style="text-align: left; height: 60px;">
                                    <asp:TextBox runat="server" ID="tbxNewPassword" TextMode="Password" Height="24px"
                                        Width="202px" BorderColor="Red" BorderWidth="1px" CausesValidation="True" MaxLength="18"
                                        onblur="PassWordExam()" ClientIDMode="Static"></asp:TextBox>
                                    <asp:Label ID="labPassWord" runat="server" ClientIDMode="Static"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 18pt; text-align: right; height: 60px;">
                                    请再次输入密码:
                                </td>
                                <td style="text-align: left; height: 60px;">
                                    <asp:TextBox runat="server" ID="tbxAgainPassWord" TextMode="Password" Height="24px"
                                        Width="202px" BorderColor="Red" BorderWidth="1px" CausesValidation="True" MaxLength="18"
                                        ClientIDMode="Static" onblur="CPassWordExam()"></asp:TextBox>
                                    <asp:Label ID="labAginPassWord" runat="server" ClientIDMode="Static"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="height: 60px;">
                                    <asp:Button runat="server" ID="btnView2Next" Text="下一步" Height="30px" Width="96px"
                                        Style="background-image: url('../../image/微条.jpg'); font-size: 12pt; margin-left: 300px; margin-left :0px"
                                        BorderStyle="Solid" BorderColor="Yellow" BorderWidth="1px" ForeColor ="White" OnClick="btnView2Next_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
                <%--view3--%>
                <asp:View runat="server" ID="View3">
                    <div id="div_Content">
                        <table cellpadding="10px" cellspacing="10px" id="table_Content">
                            <tr>
                                <td style="font-size: 18pt; text-align: left; height: 60px;">
                                    恭喜你，密码修改成功!
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 60px;">
                                    <asp:Button runat="server" ID="btnSubmit" Text="确定" Height="30px" Width="96px" Style="background-image: url('../../image/微条.jpg');
                                        font-size: 12pt; margin-left: 0px;" BorderStyle="Solid" BorderColor="Yellow"
                                        BorderWidth="1px" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </asp:View>
            </asp:MultiView>
        </div>
    </center>
</asp:Content>
