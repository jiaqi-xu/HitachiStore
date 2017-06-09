<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UA_UserInfo.aspx.cs" Inherits="HitachiStore.backstage.UserAdmin.UA_UserInfo" %>

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
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div align="center">
        <asp:Panel ID="Panel1" runat="server">
            <%--总框架高度--%>
            <div style="height: 1000px">
                <%--动态管理员信息提示栏--%>
                <div style="height: 28px; ">
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
                <div style="background-color: #353c44; height: 28px; border-style: solid; border-color: White;
                    border-width: 3px">
                    <table style="width: 100%; height: 28px">
                        <tr>
                            <td style="width: 3%">
                            </td>
                            <td style="width: 97%; text-align: left; color: White; font-size: smaller">
                                用户个人信息
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="allView" style="width: 78%; margin-top: 100px; height:320px;
                    background-color: #add2da"align="center">
                 <div style=" width:200px; height:25px; margin-top:20px">
                <center>
                   <asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="#ff0066" Font-Bold="true"></asp:Label>
                </center>
                </div>
                       <table cellspacing="5px" style=" margin-left :50px; margin-top: 20px; float: left ; width :80%">
                            <tr>
                                <td style="text-align: left">
                                    用户名
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxUserName" runat="server" Enabled="false"></asp:TextBox>
                                </td>
                                                                <td style="text-align: left">
                                    UserID
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxUserID" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    是否为会员
                                </td>
                                <td>
                                    <asp:RadioButton ID="Yes" runat="server" Text="是" ValidationGroup="Yes" 
                                        GroupName="a" AutoPostBack="True" oncheckedchanged="Yes_CheckedChanged" />
                                </td>
                                <td>
                                    <asp:RadioButton ID="No" runat="server" Text="否"  GroupName="a" 
                                        AutoPostBack="True" oncheckedchanged="Yes_CheckedChanged"/>
                                </td>
                                <td style="text-align: left">
                                    姓名
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxTrueName" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    身份证号
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxCreditCard" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    年龄
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxAge" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    性别
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxSex" runat="server"  Enabled="false"></asp:TextBox>
                                </td>

                                <td style="text-align: left">
                                    联系电话
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxPhone" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    注册时间
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxRegisterTime" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    QQ
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxQQ" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    累计消费
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="tbxTotalConsum" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                          
                        </table>
                        
                         <div style ="margin-top :30px ; width :200px">
                            <table cellspacing ="5px" style ="width :30%" align="center">
                            <tr><td><asp:Button ID="Alter" runat ="server" Text="修改" Width ="80px" 
                                    Height ="30px" onclick="Alter_Click"/></td>
                            
                            </tr>
                            </table>
                            </div>
                </div>
            </div>
        </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
