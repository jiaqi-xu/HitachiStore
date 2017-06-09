<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OA_OrderInfoma.aspx.cs" Inherits="HitachiStore.backstage.OrderAdmin.OA_OrderInfoma" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://localhost:3193/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
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
        <%--交易完成时间--%>
    <div style="height: 660px">
        <%--处理该订单员工ID--%>
        <div style="height: 28px;">
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
        <%--处理该订单员工ID--%>
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
        <%--处理该订单员工ID--%>
        <div style="width: 100%; height: 15px">
        </div>
        <%--处理该订单员工ID--%>
        <div align="center" >
            
            <div style="background-color: #add2da ; border-width:1px;
                width: 70%; margin-top: 70px; height :350px; " align="center">
                <div style =" margin-top :15px">提示：<asp:Label ID="Tip" runat ="server" Text ="" ForeColor ="Red" Font-Size ="Large" ></asp:Label></div>
                <table  style="width: 80%; height :200px ; margin-top :60px">
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td style ="height:25px">
                            <asp:Label ID="lbOrderFormID" runat="server" Text="订单ID:"></asp:Label>
                        </td>
                        <td  class ="style1">
                            <asp:TextBox ID="tbxOrderID" runat="server" Width="155px" ReadOnly="True" Enabled ="false" ></asp:TextBox>
                        </td>
                        <td style="height: 33px" class="style1">
                            <asp:Label ID="lbUserID" runat="server" Text="用户名:"></asp:Label>
                        </td>
                        <td  style="height: 33px">
                            <asp:TextBox ID="tbxUserID" runat="server" Width="155px" ReadOnly="True" Enabled ="false" ></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td style="height: 33px" class="style1">
                            <asp:Label ID="lbFinishStuffID" runat="server" Text="管理员姓名"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxStaffID" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                        <td style="height: 33px" class="style1">
                            <asp:Label ID="lbNumber" runat="server" Text="数量:"></asp:Label>
                        </td>
                        <td style="height: 33px">
                            <asp:TextBox ID="tbxNumber" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <%--处理该订单员工ID--%>
                    <tr align="left">
                        <td style="height: 33px" class="style1">
                            <asp:Label ID="lbAllPrice" runat="server" Text="总价:"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="tbxToTalPrice" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                        <td style="height: 33px" class="style1">
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
                            <asp:DropDownList ID="TradeStatus" runat="server" Width="150px" OnSelectedIndexChanged="TradeStatus_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="0">买家未付款</asp:ListItem>
                                <asp:ListItem Value="1">表示买家付款</asp:ListItem>
                                <asp:ListItem Value="2">表示商城发货</asp:ListItem>
                                <asp:ListItem Value="3">表示交易完成</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="height: 33px" class="style1">
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
                        <td style="height: 33px" class="style1">
                            <asp:Label ID="lbFinishTradeTime" runat="server" Text="交易完成时间:"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="tbxEndTime" runat="server" Width="155px" ReadOnly="True" 
                                Enabled="False"></asp:TextBox>
                        </td>
                        
                    </tr>
                </table>
                <div style ="width :100px">
                <table >
                <tr><td><asp:Button ID="Alter" runat="server" Text="修改" Width="80px" OnClick="Alter_Click" /></td>
                <td><asp:Button ID="Delete" runat="server" Text="删除" Width="80px" 
                        OnClick="Delete_Click" /></td>
                </tr>
                </table>
                    
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
