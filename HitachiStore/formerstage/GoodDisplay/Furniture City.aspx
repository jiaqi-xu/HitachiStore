<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Furniture City.aspx.cs"
    MasterPageFile="~/formerstage/stage_Master/ShowProduct.Master" Inherits="HitachiStore.formerstage.GoodDisplay.Furniture_City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .font
        {
            text-align: center;
            font-size: large;
            font-weight: bold;
        }
        #imgProductShow
        {
            height: 456px;
            width: 962px;
        }
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
    <div id="div_Whole">
        <div id="div_left" style="float: left; width: 20%; height: 800px; background-image: url(../../image/左侧树背景2.png)">
            <div id="div_datalist1" style="margin-top: 30px">
                <asp:DataList runat="server" ID="dlistClassDm" Width="80%" CssClass="font">
                    <ItemTemplate>
                        <div style="text-align: left; font-size: large; text-align: center">
                            <a href="SecondClass.aspx?SecondName=<%#Eval("SecondClassDmName") %>">
                                <%#Eval("SecondClassDmName") %></a>
                        </div>
                        <div style="height: 20px">
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
        <div id="div_right" style="float: right; width: 80%;">
            <div>
                <%--<img id="imgProductShow" runat="server" src="~/GoodImg/家具城.jpg" style="margin-top: 20px;
                    margin-right: 80px" />--%>
                    <asp:Image ID="BigImg" runat="Server" height="450px" width="983px" style="margin-top:5px;"/>
                <div style="margin-top: 30px;">
                    <asp:DataList runat="server" ID="dlistProductShow" Width="100%" RepeatColumns="4"
                        RepeatDirection="Horizontal">
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
                                    <asp:Label ID="Label1" runat="server" Text='<%#Eval("ImgTitle") %>'></asp:Label>
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
            </div>
        </div>
    </div>
</asp:Content>
