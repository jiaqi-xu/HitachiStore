<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminRegsiter.aspx.cs" Inherits="HitachiStore.backstage.Admin.AdminRegsiter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <%--验证码样式--%>
    <script type="text/javascript">
        function show() {
            var a = document.getElementById("imgValidate");
            a.src = a.src + "?";
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
      <%--总框架高度--%>
      <div style="height: 488px; margin-bottom: 0px;">
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
                            管理员注册界面
                        </td>
                    </tr>
                </table>
            </div> 
           <%--中间空白--%>
           <div style="width:100%; height:15px"></div>
           <%-- 主界面 --%>
            <div>
              <table style="width:50%; background-color:#add2da; border-style:solid; border-color:Black"align="center" >                
                <%--用户名--%>
                <tr align="left">  
                  <td width="75px"></td>              
                  <td style="height:32px">
                      <asp:Label ID="lbStaffName" runat="server" Text="用户名:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtStaffName" runat="server"  Width="155px" MaxLength="40"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStaffName" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                      <asp:Button ID="btnStaffName" runat="server"  Width="155px" Text="验证用户名" 
                          Height="30px" onclick="btnStaffName_Click"></asp:Button>
                  </td>
                </tr>
                <%--密码--%>
                <tr align="left">  
                  <td width="75px"></td>              
                  <td height="30px">
                      <asp:Label ID="lbPassword" runat="server" Text="密码:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtPassword" runat="server" Width="155px" TextMode="Password" 
                          MaxLength="100"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%--再次输入密码--%>
                <tr align="left">  
                  <td width="75px"></td>            
                  <td height="30px">
                      <asp:Label ID="lbSecPassword" runat="server" Text="请再次输入密码:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:TextBox ID="txtSecPassword" runat="server" Width="155px" TextMode="Password" 
                          MaxLength="100"></asp:TextBox>
                      <asp:CompareValidator ID="cvSecPassword" runat="server" 
                          ErrorMessage="CompareValidator" ControlToCompare="txtPassword" 
                          ControlToValidate="txtSecPassword" ForeColor="Red" Font-Size="Small">两次密码输入不一致</asp:CompareValidator>
                      <asp:RequiredFieldValidator ID="revSecPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                   <%--性别--%>
                <tr align="left">  
                  <td width="75px"></td>              
                  <td height="30px">
                      <asp:Label ID="lbSex" runat="server" Text="性别:"></asp:Label>
                  </td>
                  <td height="30px">
                      <asp:RadioButton ID="rbnMan" runat="server" Text="男" GroupName="rbnSex" Checked="true" />
                      <asp:RadioButton ID="rbnWoman" runat="server" Text="女" GroupName="rbnSex"/>
                  </td>
                </tr>
                <%-- 管理员类别--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td style="height:32px">
                      <asp:Label ID="lbAdministratorClass" runat="server" Text="管理员类别:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtAdministratorClass" Text="未激活" runat="server"  Width="155px" Enabled="false"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdministratorClass" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%-- 姓名--%>
                <tr align="left">   
                  <td width="75px"></td>             
                  <td style="height:32px">
                      <asp:Label ID="lbName" runat="server" Text="姓名:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtName" runat="server"  Width="155px" MaxLength="40"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtName" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%--身份证号--%>
                <tr align="left">
                  <td width="75px"></td>                
                  <td style="height:32px">
                      <asp:Label ID="lbIDcardNO" runat="server" Text="身份证号:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtIDcardNO" runat="server"  Width="155px" MaxLength="20"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="revIDcardNO" runat="server" 
                          ErrorMessage="RegularExpressionValidator" ControlToValidate="txtIDcardNO" 
                          ForeColor="Red" Font-Size="Small" ValidationExpression="\d{17}[\d|X]|\d{15}">请输入有效身份证号</asp:RegularExpressionValidator>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtIDcardNO" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%-- 年龄--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td style="height:32px">
                      <asp:Label ID="lbAge" runat="server" Text="年龄:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtAge" runat="server"  Width="155px" MaxLength="3"></asp:TextBox> 
                      <asp:RangeValidator ID="rvAge" runat="server" ErrorMessage="RangeValidator" 
                          ControlToValidate="txtAge" ForeColor="Red" MaximumValue="150" MinimumValue="1" 
                          Type="Integer" Font-Size="Small">请输入正确格式的年龄</asp:RangeValidator>                     
                  </td>
                </tr>
                <%--Email--%>
                <tr align="left">
                  <td width="75px"></td>                
                  <td style="height:32px">
                      <asp:Label ID="lbEmail" runat="server" Text="E-mail:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtEmail" runat="server"  Width="155px" MaxLength="50"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="revEmail" runat="server" 
                          ErrorMessage="RegularExpressionValidator" ControlToValidate="txtEmail" 
                          ForeColor="Red"  Font-Size="Small"
                          ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">请输入有效邮箱</asp:RegularExpressionValidator>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtEmail" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%--联系电话--%>
                <tr align="left">   
                  <td width="75px"></td>             
                  <td style="height:32px">
                      <asp:Label ID="lbPhone" runat="server" Text="联系电话:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtPhone" runat="server"  Width="155px" MaxLength="11"></asp:TextBox>
                      <asp:RegularExpressionValidator ID="revPhone" runat="server" 
                          ErrorMessage="RegularExpressionValidator" ControlToValidate="txtPhone" 
                          ForeColor="Red" Font-Size="Small" ValidationExpression="[0-9]{11}">请输入正确格式的手机号码</asp:RegularExpressionValidator>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPhone" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%--家庭住址--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td style="height:32px">
                      <asp:Label ID="lbAddress" runat="server" Text="家庭住址:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtAddress" runat="server"  Width="155px" MaxLength="200"></asp:TextBox>
                  </td>
                </tr>
                <%--qq--%>
                <tr align="left">
                  <td style="height:32px"></td>                
                  <td style="height:32px">
                      <asp:Label ID="lbQQ" runat="server" Text="qq:"></asp:Label>
                  </td>
                  <td style="height:32px"">
                      <asp:TextBox ID="txtQQ" runat="server"  Width="155px" MaxLength="12"></asp:TextBox> 
                      <asp:RegularExpressionValidator ID="revQQ" runat="server" 
                          ErrorMessage="RegularExpressionValidator" ControlToValidate="txtQQ" 
                          ForeColor="Red" Font-Size="Small" ValidationExpression="^\d{5,12}$">请输入正确格式的QQ号码</asp:RegularExpressionValidator>                     
                  </td>
                </tr>
                <%--注册时间--%>
                <tr align="left"> 
                  <td width="75px"></td>               
                  <td style="height:32px">
                      <asp:Label ID="lbRegister" runat="server" Text="注册时间:"></asp:Label>
                  </td>
                  <td style="height:32px">
                      <asp:TextBox ID="txtRegister" runat="server"  Width="155px" Enabled="false"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtRegister" ErrorMessage="不能为空" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                  </td>
                </tr>
                <%--验证码--%>
                <tr align="left">
                   <td width="75px"></td>
                    <td style="height:38px">
                      <asp:Label ID="lbValidate" runat="server" Text="请输入验证码:"></asp:Label>
                  </td>
                   <td  style="height:38px"> 
                   <asp:TextBox ID="txtValidate" runat="server"  Width="80px" Height="38px"></asp:TextBox> &nbsp               
                       <image alt="载入中..." id="imgValidate" width="75px" height="38px" src="../../verification%20code/verification%20code.aspx"/> &nbsp 区分大小写 &nbsp 看不清？<a href="javascript:show();">换一张</a>&nbsp
                            <asp:RequiredFieldValidator ID="revValidate" Font-Size="Small" runat="server" ForeColor="Red" ControlToValidate="txtValidate" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                  </td>                  
                </tr>
                <%--提交注册并返回登录--%>
                <tr>
                   <td width="75px"></td>
                   <td colspan="2" align="center" style="height:53px">                 
                    <asp:Button ID="btnAlter" runat="server" Text="提交" Height="37px" Width="76px" 
                           onclick="btnAlter_Click" Enabled="False" />                     
                  </td>                  
                </tr>               
              </table>
            </div>
            <div>
            </div>
      </div>         
    </form>
</body>
</html>
