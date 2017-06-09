<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OA_AdminInfo.aspx.cs" Inherits="HitachiStore.backstage.OrderAdmin.OA_AdminInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://localhost:3193/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
     <script type="text/javascript">
         //全局变量与修改按钮绑定
         var lSubmitOk = [true, true, true];
         //密码格式匹配
         $(document).ready(function () {
             $('#txtPassword').blur(function () {
                 var gStr = $(this).val();
                 var gPattern = /^[0-9A-Za-z]{1,16}$/
                 if ((gStr == "" || gStr == null)) {
                     $('#lblPassword').html('请输入密码！');
                     lSubmitOk[0] = false;
                 }
                 else if (!gPattern.exec(gStr)) {
                     $('#lblPassword').html('请输入有效密码！');
                     lSubmitOk[0] = false;
                 }
                 else {
                     $('#lblPassword').html('√');
                     lSubmitOk[0] = true;
                 }
             });
             //提示密码格式的输入
             $(document).ready(function () {
                 $('#txtPassword').focus(function () {
                     $('#lblPassword').html('1-16位，由数字及英文字母组成');
                 });
             });
         });

         //对真实姓名格式的限制
         $(document).ready(function () {
             $('#tbxTrueName').blur(function () {
                 var gStr = $(this).val();
                 var gPattern = /^[\u4e00-\u9fa5]{1,5}$/;
                 if (!gStr.match(gPattern) && gStr != "" && gStr != null) {
                     $('#lblName').html('请输入正确格式的姓名！');
                     lSubmitOk[1] = false;
                 }
                 else {
                     $('#lblName').html('');
                     lSubmitOk[0] = true;
                 }
             });
         });

         //对身份证号格式的限制
         $(document).ready(function () {
             $('#tbxIDcardNum').blur(function () {
                 var gStr = $(this).val();
                 var gPattern = /^\d{17}[\d|X]|\d{15}$/;
                 if (gStr == "" && gStr == null) {
                     lSubmitOk[2] = false;
                     $('#lblIDcardNO').html('请输入身份证号！');
                 }
                 else if (!gPattern.exec(gStr)) {
                     lSubmitOk[2] = false;
                     $('#lblIDcardNO').html('请输入正确格式的身份证号！');

                 }
                 else {
                     lSubmitOk[2] = true;
                     $('#lblIDcardNO').html('');
                 }
             });
         });

         //验证与数据绑定
         function mAlter() {
             if (lSubmitOk[0] == true && lSubmitOk[1] == true && lSubmitOk[2] == true) {
                 return true;
             }
             else {
                 $('#lblCheck').html('请正确填写信息！');
                 return false;
             }
         }
    </script>
     <script type="text/javascript">
         //         $(document).ready(function () {
         //             $('*').click(function () {
         //                 $('#ContentPlaceHolder2_lblCheck').text('');
         //             });
         //         });
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="height: 600px">
        <%--身份证号--%>
        <div style="height: 28px;">
            <table style="width: 100%; height: 28px; background-color: #add2da; border-width: 1px">
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
        <%-- 年龄--%>
        <div style="background-color: #353c44; height: 28px; border-style: solid; border-color: White;
            border-width: 1px">
            <table style="width: 100%; height: 28px">
                <tr>
                    <td style="width: 3%">
                    </td>
                    <td style="width: 97%; text-align: left; color: White; font-size: smaller">
                        管理员个人信息界面
                    </td>
                </tr>
            </table>
        </div>
        <div style="width: 100%; height: 15px" align="center">
        </div>
        <%-- 主界面 --%>
        <center>
            <div align="center">
                <div align="center" style="background-color: #add2da; width: 60%; height: 380px;
                    margin-top: 60px; ">
                    <div style="width: 200px; height: 25px; margin-top: 5px" align="center">
                        <center>
                            提示：<asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="#ff0066" Font-Bold="true"></asp:Label>
                        </center>
                    </div>
                    <table style="width: 60%; margin-top: 20px;" align="center">
                        <tr align="left">
                            <td style="height: 32px">
                                <asp:Label ID="lbStaffID" runat="server" Text="StaffID:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txtStaffID" runat="server" Width="155px" ReadOnly="True" OnTextChanged="btnAlter_Click"
                                    Enabled="False" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr align="left">
                            <td style="height: 32px">
                                <asp:Label ID="lbStaffName" runat="server" Text="用户名:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="tbxUserName" runat="server" Width="155px" ReadOnly="True" Enabled="False"
                                    BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"></asp:TextBox>
                            </td>
                        </tr>
                        <%--注册时间--%>
                        <tr align="left">
                            <td height="30px">
                                <asp:Label ID="lbPassword" runat="server" Text="密码:"></asp:Label>
                            </td>
                            <td height="30px" class="style2">
                                <asp:TextBox ID="txtPassword" runat="server" Width="155px" Style="float: left"></asp:TextBox>
                                <asp:Label ID="lblPassword" runat="server" Font-Size="Small" ForeColor="Yellow" Style="float: left"></asp:Label>
                            </td>
                        </tr>
                        <%--对个人信息的修改--%>
                        <tr align="left">
                            <td style="height: 32px">
                                <asp:Label ID="lbAdministratorClass" runat="server" Text="管理员类别:" Width="90px"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txtAdministratorClass" runat="server" Width="155px" ReadOnly="True"
                                    Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <%--姓名--%>
                        <tr align="left">
                            <td style="height: 32px">
                                <asp:Label ID="lbName" runat="server" Text="姓名:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="tbxTrueName" runat="server" Width="155px"></asp:TextBox><br />
                                <asp:Label ID="lblName" runat="server" Font-Size="Small" ForeColor="Yellow"></asp:Label>
                            </td>
                        </tr>
                        <%--身份证号--%>
                        <tr align="left">
                            <td style="height: 32px">
                                <asp:Label ID="lbIDcardNO" runat="server" Text="身份证号:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="tbxIDcardNum" runat="server" Width="155px"></asp:TextBox>
                                <asp:Label ID="lblIDcardNO" runat="server" Font-Size="Small" ForeColor="Yellow"></asp:Label>
                            </td>
                        </tr>
                        <%--注册时间--%>
                        <tr align="left">
                            <td style="height: 32px">
                                <asp:Label ID="lbRegister" runat="server" Text="注册时间:"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="tbxAddTime" runat="server" Width="155px" ReadOnly="True" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <%--对个人信息的修改--%>
                    <div align="center" style="margin-top: 10px">
                        <asp:Button ID="btnAlter" runat="server" Text="修改" Height="37px" Width="76px" OnClick="btnAlter_Click" />
                    </div>
                </div>
        </center>
    </div>
    </div>
    </form>
</body>
</html>
