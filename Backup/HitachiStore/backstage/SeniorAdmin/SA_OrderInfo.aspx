<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_OrderInfo.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.SA_OrderInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--总框架高度--%>
      <div style="height: 660px">
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
                            个体订单信息
                        </td>
                    </tr>
                </table>
            </div> 
            <%--中间空白--%>
           <div style="width:100%; height:15px"></div>
           <%-- 主界面 --%>
            <div align="center" >
              <div style="background-color: #add2da ;
                width: 70%; margin-top: 70px; height :350px; " align="center">
                <table  style="width: 80%; margin-top :50px">
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td class="style1">
                            <asp:Label ID="lbOrderFormID" runat="server" Text="订单ID:"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="tbxOrderID" runat="server" Width="155px" ReadOnly="True" Enabled ="false" ></asp:TextBox>
                        </td>
                        <td style="height: 33px">
                            <asp:Label ID="lbUserID" runat="server" Text="用户名:"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxUserID" runat="server" Width="155px" ReadOnly="True" Enabled ="false" ></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                      
                         <td style="height: 33px">
                            <asp:Label ID="lbFinishStuffID" runat="server" Text="管理员姓名:"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxStaffID" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                        <td style="height: 33px">
                            <asp:Label ID="lbNumber" runat="server" Text="数量:"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxNumber" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td style="height: 33px">
                            <asp:Label ID="lbAllPrice" runat="server" Text="总价:"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="tbxToTalPrice" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                        <td style="height: 33px">
                            <asp:Label ID="lbShipAddress" runat="server" Text="发货地址:"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxAddress" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%><%--处理该订单员工ID--%>
                    <tr align="left">
                        <td style="height: 33px">
                            <asp:Label ID="lbTradeState" runat="server" Text="交易状态:"></asp:Label>
                        </td>
                        <td class="style2">
                            
                            <asp:Label ID="lblTradeStatus" runat="server"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:Label ID="lbCancelreason" runat="server" Text="取消理由:"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxCalloffReason" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td class="style1">
                            <asp:Label ID="lbPresentTime" runat="server" Text="提交时间:"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="tbxSubmitTime" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                        <td class="style1">
                            <asp:Label ID="lbShipTime" runat="server" Text="发货时间:"></asp:Label>
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="tbxSendTime" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td style="height: 33px">
                            <asp:Label ID="lbFinishTradeTime" runat="server" Text="交易完成时间:"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="tbxEndTime" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                       
                    </tr>
                </table>
                <div style ="width :100px; margin-top :10px">
                    <asp:Button ID="btnBack" runat="server" Text="返回" OnClick="btnBack_Click" Width="80px" Height="35px"/>
                </div>
            </div>
            </div>
      </div>         
    </div>
    </form>
</body>
</html>
