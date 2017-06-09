<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrdersExam.aspx.cs" Inherits="HitachiStore.formerstage.OrderExam.OrdersExam"
    MasterPageFile="~/formerstage/stage_Master/PersonIfor.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <style>
        .button
        {
            background-image: url(../../image/标题头微条.jpg);
            height: 25px;
            width: 70px;
            border: 1px solid #ffcc00;
            forecolor: white;
        }
    </style>
    <div id="div_Whole" align="center" style="margin-bottom: 40px; width: 100%">
        <div id="div_Content" style="width: 100%; margin-bottom: 30px; border-style: solid;
            border-color: red; border-width: 1px; height: 800px;">
            <table id="table_topBlank" style="width: 100%; height: 34px; border: 2px; border-color: red;
                border-style: solid">
                <tr style="border: 0px; border-style: solid">
                    <td style="text-align: left">
                        <div id="div_topItem" style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
                            background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                            color: White">
                            <strong>订单查看 </strong>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="width: 70%; height: 400px; margin-top: 30px; border-style: solid; border-width: 1px;
                border-color: red;">
                <table id="table_Tatle" style="width: 100%; height: 34px;">
                    <tr style="border: 0px; border-style: solid">
                        <td style="text-align: left">
                            <div id="div1" style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
                                background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                                color: White">
                                <strong>收货人地址</strong>
                            </div>
                        </td>
                    </tr>
                </table>
                <table id="table_Content1" cellspacing="20px" style="margin-top: 20px; width :80%; height :70%">
                    <tr>
                        <td>
                            收货人姓名:
                        </td>
                        <td>
                            <asp:TextBox ID="tbxUserName" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            收货地址：
                        </td>
                        <td>
                            <asp:TextBox ID="tbxReveiveAddress" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            手机号码：
                        </td>
                        <td>
                            <asp:TextBox ID="tbxPhoneNumber" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电子邮件：
                        </td>
                        <td>
                            <asp:TextBox ID="tbxEmail" runat="server" Enabled="False"></asp:TextBox>
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
            <asp:ListView ID="OrderLisstview" runat="server">
                <ItemTemplate>
                    <table id="table_Content2" width="620px" cellspacing="20px" style="margin-top: 5px; border:1px solid red">
                        <tr>
                            <td rowspan="2"  style="border:1px solid red">
                                商品清单：
                            </td>
                            <td style="width: 100px;border:1px solid red">
                                商品编号
                            </td>
                            <td style="width: 100px;border:1px solid red">
                                商品名称
                            </td>
                            <td style="width: 100px;border:1px solid red">
                                商品数量
                            </td>
                            <td style="width: 100px;border:1px solid red">
                                商品价格
                            </td>
                        </tr>
                        <tr>
                            <td style="border:1px solid red">
                                <%#Eval("GoodID")%>
                            </td>
                            <td style="border:1px solid red">
                                <%#Eval("GoodName")%>
                            </td>
                            <td style="border:1px solid red">
                                <%#Eval("Number")%>
                            </td>
                            <td style="border:1px solid red">
                                <%#this.Set(Eval("GoodPrice"),Eval("Number"))%>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:ListView>
            <div style="text-align: left; margin-top: 15px; height: 150px">
                <div style="text-align: left; margin-left: 10px;">
                    结算信息：</div>
                <br />
                <div style="margin-left: 80px; text-align: center; font-size: 15px">
                    应付总和：
                    <asp:Label ID="TotalPrice" runat="server" Text="1000"></asp:Label>
                    <table cellspacing="20px">
                        <tr>
                            <td>
                                <asp:Button CssClass="button" ID="ConfirmBtn" runat="server" Text="返回" 
                                    onclick="ConfirmBtn_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
