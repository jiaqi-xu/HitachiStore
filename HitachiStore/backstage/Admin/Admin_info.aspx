<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_info.aspx.cs" Inherits="HitachiStore.backstage.Admin.Admin_info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <%--总框架高度--%>
      <div style="height: 488px">
            <%--动态管理员信息提示栏--%>
            <div style="height: 28px">
                <table style="width: 100%; height: 28px; background-color: #add2da; border-width:2px">
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
                            管理员个人信息界面
                        </td>
                    </tr>
                </table>
            </div> 
           <%--中间空白--%>
           <div style="width:100%; height:15px"></div>
           <%-- 主界面 --%>
            <div>
              <table style="width:40%; background-color:#add2da; border-style:solid; border-color:Black"align="center" >
                <tr style="height:30px"></tr>
               <%--StauffID--%>
                <tr align="left">  
                  <td width="75px"></td>              
                  <td height="30px">
                      <asp:Label ID="lbStauffID" runat="server" Text="StauffID:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtStauffID" runat="server" Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--用户名--%>
                <tr align="left">  
                  <td width="75px"></td>              
                  <td height="30px">
                      <asp:Label ID="lbStauffName" runat="server" Text="用户名:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtStauffName" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%-- 管理员类别--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td height="30px">
                      <asp:Label ID="lbAdministratorClass" runat="server" Text="管理员类别:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtAdministratorClass" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%-- 姓名--%>
                <tr align="left">   
                  <td width="75px"></td>             
                  <td height="30px">
                      <asp:Label ID="lbName" runat="server" Text="姓名:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtName" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--身份证号--%>
                <tr align="left">
                  <td width="75px"></td>                
                  <td height="30px">
                      <asp:Label ID="lbIDcardNO" runat="server" Text="身份证号:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtIDcardNO" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%-- 年龄--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td height="30px">
                      <asp:Label ID="lbAge" runat="server" Text="年龄:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtAge" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--Email--%>
                <tr align="left">
                  <td width="75px"></td>                
                  <td height="30px">
                      <asp:Label ID="lbEmail" runat="server" Text="E-mail:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtEmail" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--联系电话--%>
                <tr align="left">   
                  <td width="75px"></td>             
                  <td height="30px">
                      <asp:Label ID="lbPhone" runat="server" Text="联系电话:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtPhone" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--家庭住址--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td height="30px">
                      <asp:Label ID="lbAddress" runat="server" Text="家庭住址:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtAddress" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--qq--%>
                <tr align="left">
                  <td width="75px"></td>                
                  <td height="30px">
                      <asp:Label ID="lbQQ" runat="server" Text="qq:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtQQ" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <%--注册时间--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td height="30px">
                      <asp:Label ID="lbRegister" runat="server" Text="注册时间:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtRegister" runat="server"  Width="155px"></asp:TextBox>
                  </td>
                </tr>
                <tr  >
                   <td width="75px"></td>
                   <td colspan="2" align="center">                 
                    <asp:Button ID="btnAlter" runat="server" Text="修改" Height="37px" Width="75px" /> 
                  </td>                  
                </tr>
              </table>
            </div>
      </div>         
    </form>
</body>
</html>
