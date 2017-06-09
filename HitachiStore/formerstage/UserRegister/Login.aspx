<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HitachiStore.formerstage.UserRegister.Login"
    MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="content1" runat="server">
<title>登录天外天商城</title>
    <script type="text/javascript">
        function show() {
            var a = document.getElementById("image");
            a.src = a.src + "?";
        }
    </script>
    <div style="margin-top: 80px; margin-bottom: 80px; margin-left: 0px; width: 85%;
        height: 350px; border: 1px; border-color: #ed1100; border-style: solid" id="div_Whole">
        <%--头部提示--%>
        <div style="width: 100%;" id="divTop">
            <div style="border: none; height: 30px; text-align: left; background-image: url('../../image/微条.jpg');
                background-repeat: repeat-x; font-size: 9pt; padding-top: 5px; padding-left: 9px;
                color: white; line-height: 23px; font-size: larger;">
                <strong>用户登录</strong></div>
        </div>
        <%--内容部分 --%>
        <div style="margin-left: 0px; margin-top: 0px; width: 100%; height: 370px" id="div_Content">
            <%--左部登录内容 --%>
            <div style="margin-top: 40px; height: 100%; font-size: 18pt; float: left; width: 65%;
                height: 350px" align="center">
                <table cellpadding="20px">
                    <%--用户名--%>
                    <tr>
                        <td align="right" style="height:40px;">
                            用户名:
                        </td>
                        <td align="left" style="height:40px;">
                            <asp:TextBox ID="txbUserName" Height="24px" Width="202px" BorderColor="Red" BorderWidth="1px"
                                CausesValidation="True" MaxLength="18" runat="server"></asp:TextBox>
                             <asp:Label ID="lblUserName" runat="server" ClientIDMode="Static" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <%--密码--%>
                    <tr>
                        <td align="right" style="height:40px;">
                            密码:
                        </td>
                        <td align="left" style="height:40px;">
                            <asp:TextBox ID="txbPassWord" runat="server" Height="24px" Width="202px" BorderColor="Red" TextMode="Password" 
                                BorderWidth="1px"></asp:TextBox><a href="FindPassWord.aspx"><strong style="font-size: smaller">
                                    忘记密码？</strong></a>
                        </td>
                    </tr>
                    <%--输入验证码--%>
                    <tr>
                        <td align="right" style="height:40px;">
                            <div>
                                请输入验证码:</div>
                        </td>
                        <td align="left" style="font-size: 13pt;height:40px;">
                            <div>
                                <div style="float: left">
                                    <asp:TextBox runat="server" ID="tbxSecurity" Width="50px" Height="24px" BorderColor="Red"
                                        BorderWidth="1px"></asp:TextBox>
                                </div>
                                <%--验证码--%>
                                <div style="float: left; padding-top: 1px; margin-left: 4px;">
                                    <image id="image" src="../../verification%20code/verification%20code.aspx" width="71px"
                                        height="27px"> </image>
                                </div>
                                <div style="float: left; padding-top: 8px; margin-left: 4px;">
                                    看不清? <a href="javascript:show()">换一张</a></div>
                            </div>
                        </td>
                    </tr>
                    <%--登录--%>
                    <tr>
                        <td align="center" colspan="2" style="height:50px;">
                            <asp:Button ID="LoginBtn" runat="server" Width="80px" Height="30px" Text="登录" Font-Bold="true"
                                OnClick="LoginBtn_Click" ForeColor="White" Style="background-image: url('../../image/微条.jpg');
                                background-repeat: repeat-x;" BorderStyle="None" />
                        </td>
                    </tr>
                </table>
            </div>
            <%--左右分隔条--%>
            <div style="float: left; width: 0.5px; height: 290px; margin-top: 16px; margin-right: 5px;
                background-color: #ed1100">
            </div>
            <%--右边内容--%>
            <div style="float: left; width: 34%; height: 300px; margin-top: 30px; font-size: 11pt">
                <p style="margin-top: 5px; font-size: 18pt; text-align: center;" align="left">
                    <strong>&nbsp 还不是天外天商城用户？</strong></p>
                <br />
                <p align="left" style="font-size: 13pt;">
                    &nbsp 现在免费注册成为天外天商城用户,<br/>&nbsp 便能立刻享受便宜又放心的购物乐趣。</p>
                <%-- 链接到注册界面--%>
                <div style="margin-top: 40px; height: 100px" align="center">
                    <div style="margin-top: 30px; width: 100px">
                        <asp:Button ID="registerBtn" runat="server" Text="注册新用户" Width="100px" OnClick="registerBtn_Click"
                            Style="background-image: url('../../image/微条.jpg'); background-repeat: repeat-x;"
                            BorderStyle="None" ForeColor="Black" Height="30px" Font-Bold="true" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
