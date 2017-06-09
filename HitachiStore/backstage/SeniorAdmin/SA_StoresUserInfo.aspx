<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_StoresUserInfo.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.SA_StoresUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div align="center">
        <asp:Panel ID="Panel1" runat="server">
            <%--总框架高度--%>
            <div style="height: 1000px">
                <%--动态管理员信息提示栏--%>
                <div style="height: 28px; background-color: #add2da">
                    <table style="width: 100%; height: 28px">
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
                    border-width: 1px">
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
                <div style="width: 70%; margin-top: 100px; height: 300px; background-color: #add2da">
                    <div align="center"  style ="height :300px">
                       <table cellspacing="5px"  style="margin-left: 10px; margin-top: 20px; width :500px">
                            <tr>
                                <td style="text-align: left">
                                    用户名
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxUserName" runat="server" Enabled="false" Height="22px" 
                                       ></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    UserID
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxUserID" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    是否为会员
                                </td>
                                <td style ="width :151px">
                                    <asp:Label ID="lbStoreType" runat="server"></asp:Label>
                                </td>
                                 <td style="text-align: left">
                                    姓名
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxTrueName" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    身份证号
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxCreditCard" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                                <td style="text-align: left">
                                    年龄
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxAge" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                           
                            <tr>
                                <td style="text-align: left">
                                    性别
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxSex" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                                 <td style="text-align: left">
                                    E-mail
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxEmail" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: left">
                                    联系电话
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxPhone" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                                  <td style="text-align: left">
                                    注册时间
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxRegisterTime" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                          
                            <tr>
                                <td style="text-align: left">
                                    QQ
                                </td>
                                <td >
                                    <asp:TextBox ID="tbxQQ" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                                 <td style="text-align: left">
                                    累计消费
                                </td>
                                <td>
                                    <asp:TextBox ID="tbxTotalConsum" runat="server"  Enabled="false"></asp:TextBox>
                                </td>
                            </tr>
                         
                        </table>
                        
                         <div style =" margin-top :15px; width :100px">
                           <asp:Button ID ="BtnBack" runat ="server" Width ="80px"  Text ="返回" 
                                 onclick="BtnBack_Click1" />
                         </div>
                            
                       
                    </div> 
                   
                </div>
            </div>
        </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
