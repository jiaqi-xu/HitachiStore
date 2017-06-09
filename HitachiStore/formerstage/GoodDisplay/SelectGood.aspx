<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectGood.aspx.cs" Inherits="HitachiStore.formerstage.GoodDisplay.SelectGood"
    MasterPageFile="~/formerstage/stage_Master/ShowProduct.Master" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1">
    <style>
        .button
        {
            background-image: url(../../image/标题头微条.jpg);
            height: 25px;
            width: 70px;
            border: 1px solid #ffcc00;
            forecolor: white;
            color: White;
        }
    </style>
    <div style="width: 20%; float: left; height: 1000px; background-image: url(../../image/左侧树背景2.png);">
        <asp:DataList ID="DataList1" runat="server" Width="100%" RepeatColumns="2" DataKeyField="FirstClassDmName"
            OnDeleteCommand="DataList1_DeleteCommand">
            <HeaderTemplate>
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="如下是否是您想要搜索的商品"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px;">
                        </td>
                    </tr>
                </table>
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                    <asp:LinkButton ID="lbtn_SecondClass" runat="server" CommandName="Delete"><%#Eval("FirstClassDmName")%></asp:LinkButton>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
    <div style="width: 80%; float: left;">
        <asp:DataList ID="datalist_good" runat="server" Width="100%" RepeatColumns="4" RepeatDirection="Horizontal">
            <ItemTemplate>
                <div style="width: 100%; height: 30px; background-image: url('../../image/微条.jpg');">
                </div>
                <div style="width: 100%; height: 280px; border: 1px solid #ed1100">
                    <a href="../SaleOrders/SingleGood.aspx?ImageAddress=<%#Eval("ImgAddress") %>">
                        <img runat="server" id="imgShow" width="240" height="270" style="border: none" src='<%#Eval("ImgAddress") %>' />
                    </a>
                </div>
                <div style="height: 70px; width: 100%; border: 1px solid red">
                    <div style="height: 40px">
                        <asp:Label runat="server" Text='<%#Eval("ImgTitle") %>'></asp:Label>
                    </div>
                    <div style="float: left; width: 49%; height: 30px; border-right: 1px solid red; border-top: 1px solid red">
                        价格:<%#Eval("Property") %></div>
                    <div style="float: right; width: 50%; height: 30px; border-top: 1px solid red">
                        <div style="margin-top:5px">
                            <a class="button" href="../SaleOrders/SingleGood.aspx?ImageAddress=<%#Eval("ImgAddress") %>">
                                立即购买</a>
                        </div>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
