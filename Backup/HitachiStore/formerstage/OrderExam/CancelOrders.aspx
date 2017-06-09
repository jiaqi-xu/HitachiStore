<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelOrders.aspx.cs" Inherits="HitachiStore.formerstage.OrderExam.CancelOrders"
    MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>

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
    <div align="center" style="border-bottom-style: solid; border-color: #1d96ba;" id="div_Whole">
        <div style="width: 100%; margin-top: 50px; border-color: #ed1100; border: 1px solid #ed1100;
            height: 400px;" id="div_Content">
            <table style="text-align: left; width: 100%; height: 30px" id="table_topBlank">
                <tr>
                    <td>
                        <div id="div_topItem" style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
                            background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                            color: White">
                            <strong>取消订单</strong>
                        </div>
                    </td>
                </tr>
            </table>
            <div style="margin-top: 60px; width: 80%; height: 300px; text-align: left">
                <div style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
                    background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                    color: White">
                    <strong>取消订单理由：</strong>
                </div>
                <div align="center" style="margin-top: 40px; width: 100%; height: 150px" id="div_Position">
                    <div style="width: 400px" id="div_Textarea">
                        <textarea id="txareCancleReson" runat="server" rows="5" cols="40" style =" width :400px"></textarea></div>
                    <div style="width: 100px; margin-top: 30px">
                        <table cellspacing="10px" cellpadding="20px" id="table_Button">
                            <tr>
                                <td>
                                    <asp:Button CssClass="button" ID="Button1" runat="server" Text="提交" OnClick="Button1_Click" />
                                </td>
                                <td>
                                    <asp:Button CssClass="button" ID="CancleBtn" runat="server" Text="取消" 
                                        onclick="CancleBtn_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
