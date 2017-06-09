<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddOrderInfo.aspx.cs" Inherits="HitachiStore.formerstage.SaleOrders.AddOrderInfo" MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>


 <asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div align="center" style=" margin:40px;">
        <div style="width: 60%; margin-top: 30px; height: 800px; border: 2px; border-color: Gray;
            border-style: solid">
            <table style="width: 100%; height: 40px; border: 2px; border-color: #1d96ba; border-style: solid;
                background-color: #1d96ba">
                <tr style="border: 0px; border-color：#1d96ba; border-style: solid">
                    <td style="text-align: left">
                        <strong>订单填写</strong>
                    </td>
                </tr>
            </table>
            <div style="width: 70%; height: 400px; margin-top: 30px">
                <table style="width: 100%; height: 40px; border: 2px; border-color:#1d96ba; border-style: solid;
                    background-color:#1d96ba">
                    <tr style="border: 0px; border-color: #1d96ba; border-style: solid">
                        <td style="text-align: left">
                            收货人信息
                        </td>
                    </tr>
                </table>
                <table cellspacing="20px" style="margin-top: 20px">
                    <tr>
                        <td style="text-align: left">
                            收货人姓名:
                        </td>
                        <td>
                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="3" style="text-align: left">
                            收货地址：
                        </td>
                        <td style="text-align: left">
                            <asp:RadioButton ID="Address1" runat="server" GroupName="a" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:RadioButton ID="Address2" runat="server" GroupName="a" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            <asp:RadioButton ID="Address3" runat="server" GroupName="a" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            手机号码：
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="PhoneNumber" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">
                            电子邮件：
                        </td>
                        <td style="text-align: left">
                            <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                   
                    <tr>
                        <td>
                            支付及配送方式：
                        </td>
                        <td>
                            <strong>货到付款</strong>
                        </td>
                    </tr>
                </table>
            </div>
            <table cellspacing="20px" style="margin-top: 5px">
                <tr>
                    <td rowspan="2">
                        商品清单：
                    </td>
                    <td>
                        商品编号
                    </td>
                    <td>
                        商品名称
                    </td>
                    <td>
                        商品数量
                    </td>
                    <td>
                        商品价格
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ListView ID="OrderLisstview" runat="server">
                        </asp:ListView>
                    </td>
                </tr>
            </table>
            <div style="height: 1px; background-color: #1d96ba; width: 60%">
            </div>
            <div style="text-align: left; margin-top: 15px; height: 150px">
                结算信息：
                <br />
                <div style="margin-left: 80px; text-align: center; font-size: 15px">
                    应付总和：
                    <asp:Label ID="TotalPrice" runat="server" Text="1000"></asp:Label>
                    <br />
                    <br />
                    <strong>请核实订单信息确认无误之后提交订单</strong>
                    <table cellspacing="20px">
                        <tr>
                            <td>
                                <asp:Button ID="CancleBtn" runat="server" Text="提交订单" />
                            </td>
                            <td>
                                <asp:Button ID="ConfirmBtn" runat="server" Text="取消提交" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
    </asp:Content>