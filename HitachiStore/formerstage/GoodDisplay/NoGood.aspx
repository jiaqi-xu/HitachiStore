<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoGood.aspx.cs" Inherits="HitachiStore.formerstage.GoodDisplay.NoGood"
    MasterPageFile="~/formerstage/stage_Master/ShowProduct.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width: 100%; height: 500px; border: 1px solid #ed1100; text-align: center;">
        <div style="width: 100%; height: 30px; background-image: url('../../image/微条.jpg');">
        </div>
        <div style="width: 40%; height: 200px; margin-top: 100px; margin-left:400px;">
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td colspan="2" style="color: Red; font-size: 18pt;">
                        亲~木有您搜索的商品！
                    </td>
                </tr>
                <tr>
                    <td style=" text-align:left;">
                        请您重新搜索
                    </td>
                    <td>
                        返回<a id="a_ShowGood" href="ProductShow.aspx">首页</a>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
