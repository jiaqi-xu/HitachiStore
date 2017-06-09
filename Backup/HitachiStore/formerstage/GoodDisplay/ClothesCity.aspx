<%@ Page Title="" Language="C#" MasterPageFile="~/formerstage/stage_Master/ShowProduct.Master"
    AutoEventWireup="true" CodeBehind="ClothesCity.aspx.cs" Inherits="HitachiStore.formerstage.GoodDisplay.ClothesCity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .kind
        {
            width: 20%;
            float: left;
            margin: 0 10px 0 0;
            text-align: center;
            font-size: large;
            font-weight: bold;
            height: 800px;
            padding-top: 20px;
            background-image: url(../../image/左侧树背景2.png);
        }
        .BigImg
        {
            width: 951px;
            height: 450px;
            float: left;
            margin: 5px 0 5px 0px;
            position: relative;
        }
        img
        {
            width: 985px;
            height: 450px;
            margin: 15px 0px 10px 10px;
            position: relative;
            top: 0px;
            left: -9px;
        }
        .discription
        {
            font-size: 9pt;
        }
        .otherImage
        {
            width: 77%;
            height: 300px;
            float: right;
            margin: 10px 30px 10px 10px;
        }
        .secondcolum
        {
            padding: 8px;
            border: 0px;
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--服装分类--%>
    <div class="kind">
        <center>
            <asp:DataList ID="dlClothes" runat="server">
                <ItemTemplate>
                    <center>
                        <div style="font-size: large; text-align: center; margin-top: 5px;">
                            <a href="SecondClass.aspx?SecondName=<%#Eval("SecondClassDmName") %>">
                                <asp:Label ID="lblWomanCloth" runat="server" Text='<%# Eval("SecondClassDmName") %>'></asp:Label></a><br />
                        </div>
                    </center>
                </ItemTemplate>
            </asp:DataList>
        </center>
    </div>
    <%--畅销图片--%>
    <div class="bigimgs" style="margin:5px,8px,5px,8px;">
        <%--在此做一个动态相框并加上链接--%>
        <%--<img alt="图像加载失败！"  src="../../GoodImg/服装城1.png" />--%>
        <asp:Image ID="BigImg" runat="Server" Height="450px"/>
        <%--<asp:DataList ID="dlBigImg" runat="server">
        <ItemTemplate>
           <a href="../SaleOrders/SingleGood.aspx?ImageAddress=<%# Eval("ImgAddress") %>">
              <img alt="图像加载失败！" src='<%# Eval("ImgAddress") %>'/>
           </a>
        </ItemTemplate>
     </asp:DataList>--%>
    </div>
    <%--下侧商品展示--%>
    <div style="width: 77%; margin-top: 30px; float: right">
        <asp:DataList runat="server" ID="dlistProductShow" Width="100%" RepeatColumns="4"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <div style="width: 100%; height: 30px; background-image: url('../../image/微条.jpg');">
                </div>
                <div style="width: 100%; height: 280px; border: 1px solid #ed1100">
                    <a href="../SaleOrders/SingleGood.aspx?ImageAddress=<%#Eval("ImgAddress") %>">
                        <img runat="server" id="imgShow" style="border: none; width: 240px; height: 250px;"
                            src='<%#Eval("ImgAddress") %>' />
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
</asp:Content>
