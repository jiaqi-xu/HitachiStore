<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPassWord.aspx.cs" Inherits="HitachiStore.formerstage.UserRegister.FindPassWord"
    MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function show() {
            var a = document.getElementById("image");
            a.src = a.src + "?";
        }
    </script>
    <center style="margin-top: 50px">
        <%--全局--%>
        <div id="div_Whole" style="text-align: center; height: 500px; border: 1px solid #ed1100;">
            <%--样式--%>
            <div id="div_topItem" style="height: 30px; background-image: url('../../image/微条.jpg');
                background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                color: White; text-align:left;">
                <strong>找回密码</strong>  </div>
            <div id="div_topBlank" style="height: 50px">
            </div>
            <%--控件--%>
            <div id="div_Content">
                <table cellpadding="10px" width="100%" cellspacing="10px" id="table_Content">
                    <tr>
                        <td align="right" style="width: 40%;font-size: 18pt;" >
                            用户名:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxUserName" Height="24px" Width="202px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt;">
                            身份证号:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxIdCard" Height="24px" Width="202px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt;">
                            邮箱:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxgEmail" Height="24px" Width="202px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="font-size: 18pt;">
                            验证码:
                        </td>
                        <td align="left">
                        <div style="float:left; font-size:larger;">
                            <asp:TextBox runat="server" ID="tbxSecurity" Width="50px" Height="24px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18"></asp:TextBox></div>
                            <div style="float:left; padding-left:5px;"><image id="image" alt="载入中..." width="75px" height="29px" src="../../verification%20code/verification%20code.aspx" /></div>
                            &nbsp;
                            <div style="font-size: 12pt; float:left; padding-top:6px; padding-left:4px;">看不清？<a href="javascript:show();" style="font-size:larger;">换一张</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button runat="server" ID="btnSubmit" Text="提交" 
                                        Height="30px" Width="96px" Style="background-image: url('../../image/微条.jpg');
                                        font-size: 12pt; margin-left: 80px;" BorderStyle="Solid" BorderColor="Yellow"
                                        BorderWidth="1px"  ForeColor ="White"  onclick="btnSubmit_Click1" />
                        </td>
                    </tr>
                </table>
            </div>
            <%--footer--%>
            <div id="div_bottomBlank">
            </div>
        </div>
    </center>
</asp:Content>
