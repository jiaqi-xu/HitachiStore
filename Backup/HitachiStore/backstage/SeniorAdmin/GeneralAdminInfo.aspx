<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeneralAdminInfo.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.GeneralAdminInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--对输入格式的判断--%>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        // 全局变量与修改按钮绑定
        var lSubmitOK = [true, true];
        //密码格式匹配
        $(document).ready(function () {
            $('#txtPassword').blur(function () {
                var gStr = $(this).val();
                var gPattern = /^[0-9A-Za-z]{1,16}$/
                if ((gStr == "" || gStr == null)) {
                    $('#lblPassword').html('请输入密码！');
                    lSubmitOK[0] = false;
                }
                else if (!gPattern.exec(gStr)) {
                    $('#lblPassword').html('请输入有效密码！');
                    lSubmitOK[0] = false;
                }
                else {
                    lSubmitOK[0] = true;
                    $('#lblPassword').html('√');
                }
            });
            //提示密码格式的输入
            $(document).ready(function () {
                $('#txtPassword').focus(function () {
                    $('#lblPassword').html('1-16位，由数字及英文字母组成');
                });
            });
        });

        //管理员类别输入的判断
        $(document).ready(function () {
            $('#txtAdministratorClass').blur(function () {
                var gStr1 = "商品管理员", gStr2 = "订单管理员", gStr3 = "评价管理员", gStr4 = "用户管理员";
                var gStr = $(this).val();
                if (gStr == "" || gStr == null) {
                    lSubmitOK[1] = false;
                    $('#lblAdministratorClass').html('请输入管理员类别！');

                }
                else if (gStr == gStr1 || gStr == gStr2 || gStr == gStr3 || gStr == gStr4) {
                    lSubmitOK[1] = true;
                }
                else {
                    $('#lblAdministratorClass').html('请输入正确格式的管理员类别！');
                    lSubmitOK[1] = false;
                }
            });
        });

        // 验证与提交的绑定
        function AlterGeneralAdmin() {
            if (lSubmitOK[0] == true && lSubmitOK[1] == true) {
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
         //                 $('#lblCheck').text('');
         //             });
         //         });
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--总框架高度--%>
    <div style="height: 600px">
        <%--动态管理员信息提示栏--%>
        <div style="height: 28px">
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
                        管理员信息管理界面
                    </td>
                </tr>
            </table>
        </div>
        <%-- 主界面 --%>
        <div style =" margin-top :50px" align="center">
            <div style="width: 60%; background-color: #add2da; height: 400px; margin-top:60px"align="center">
                <%--修改结果的提示--%>
                <div style=" width:200px; height:25px; margin-top:20px">
                <center>
                   <asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="#ff0066" Font-Bold="true"></asp:Label>
                </center>
                </div>
                <table style =" margin-top :20px">
                    <%--StaffID--%>
                    <tr align="left">
                       
                        <td style="height: 32px; width: 75px; line-height: 24px">
                            <asp:Label ID="lbStaffID" runat="server" Text="StaffID:"></asp:Label>
                        </td>
                        <td style="height: 32px">
                            <asp:TextBox ID="txtStaffID" runat="server" Width="155px" Enabled="False" ReadOnly="True"></asp:TextBox>
                        </td>
                       
                    </tr>
                    <%--用户名--%>
                    <tr align="left">
                       
                        <td style="height: 32px">
                            <asp:Label ID="lbStaffName" runat="server" Text="用户名:"></asp:Label>
                        </td>
                        <td style="height: 32px">
                            <asp:TextBox ID="txtStaffName" runat="server" Width="155px" Enabled="False" MaxLength="40"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <%--密码--%>
                    <tr align="left">
                       
                        <td height="32px">
                            <asp:Label ID="lbPassword" runat="server" Text="密码:"></asp:Label>
                        </td>
                        <td height="32px" width="250px">
                            <asp:TextBox ID="txtPassword" runat="server" Width="155px" MaxLength="100"></asp:TextBox>
                            <br/>
                            <asp:Label ID="lblPassword" runat="server" Font-Size="Small" ForeColor="Yellow"></asp:Label>
                        </td>
                    </tr>
                    <%-- 管理员类别--%>
                    <tr align="left">
                       
                        <td style="height: 32px">
                            <asp:Label ID="lbAdministratorClass" runat="server" Text="管理员类别:"></asp:Label>
                        </td>
                        <td style="height: 32px">
                            <asp:TextBox ID="txtAdministratorClass" runat="server" Width="155px"></asp:TextBox>
                            <br/>
                            <asp:Label ID="lblAdministratorClass" runat="server" Font-Size="Small" ForeColor="Yellow"></asp:Label>
                        </td>
                       
                    </tr>
                    <%-- 姓名--%>
                    <tr align="left">
                        
                        <td style="height: 32px">
                            <asp:Label ID="lbName" runat="server" Text="姓名:"></asp:Label>
                        </td>
                        <td style="height: 32px">
                            <asp:TextBox ID="txtName" runat="server" Width="155px" MaxLength="40" Enabled="False"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <%--身份证号--%>
                    <tr align="left">
                       
                        <td style="height: 32px">
                            <asp:Label ID="lbIDcardNO" runat="server" Text="身份证号:"></asp:Label>
                        </td>
                        <td style="height: 32px">
                            <asp:TextBox ID="txtIDcardNO" runat="server" Width="155px" MaxLength="20" Enabled="False"
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <%--注册时间--%>
                    <tr align="left">
                       
                        <td style="height: 32px">
                            <asp:Label ID="lbRegister" runat="server" Text="注册时间:"></asp:Label>
                        </td>
                        <td style="height: 32px">
                            <asp:TextBox ID="txtRegister" runat="server" Width="155px" Enabled="False" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <%--对个人信息的修改--%>
                </table>
                <div style="margin-left: 55px; margin-left:20px; width :200px; margin-top :20px" >
                   
                                <asp:Button ID="btnAlter" runat="server" Text="修改" Height="37px" Width="76px" OnClick="btnAlter_Click"
                                    OnClientClick=" return AlterGeneralAdmin()" /> &nbsp
                           
                                <asp:Button ID="btnBack" runat="server" Text="返回" Height="37px" Width="76px" OnClick="btnBack_Click" />
                          &nbsp&nbsp&nbsp&nbsp
                </div>
          </div>
    </div>
    </div>
    </form>
</body>
</html>
