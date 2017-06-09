<%@ Page Title="" Language="C#" MasterPageFile="~/backstage/Back_Master/FirstLogin.Master" AutoEventWireup="true" CodeBehind="GA_SubTree.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_SubTree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" src="../../Scripts/jquery.js"></script>
    <script type="text/javascript" src="../../Scripts/chili-1.7.pack.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.easing.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.dimensions.js"></script>
    <script type="text/javascript" src="../../Scripts/jquery.accordion.js"></script>
    <script type="text/javascript" language="javascript">
        jQuery().ready(function () {
            jQuery('#navigation').accordion({
                header: '.head',
                navigation1: true,
                event: 'click',
                fillSpace: true,
                animated: 'bounceslide'
            });
        });
    </script>
    <style type="text/css">
        body
        {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
        }
        #navigation
        {
            margin: 0px;
            padding: 0px;
            width: 147px;
        }
        #navigation a.head
        {
            cursor: pointer;
            background: url("../../image/main_34.gif" ) no-repeat scroll;
            display: block;
            font-weight: bold;
            margin: 0px;
            padding: 5px 0 5px;
            text-align: center;
            font-size: 12px;
            text-decoration: none;
        }
        #navigation ul
        {
            border-width: 0px;
            margin: 0px;
            padding: 0px;
            text-indent: 0px;
        }
        #navigation li
        {
            list-style: none;
            display: inline;
        }
        #navigation li li a
        {
            display: block;
            font-size: 12px;
            text-decoration: none;
            text-align: center;
            padding: 3px;
        }
        #navigation li li a:hover
        {
            background: url("../../image/tab_bg.gif") repeat-x;
            border: solid 1px #adb9c2;
        }
         input
        {
            border-color:black;
            border-bottom-style:solid;
            border-width:0.5px 0.5px 1px 1px;
        }
    </style>

    <div style="height: 488px; width:147px">
        <div style="width: 100% ;height:28px; background-color:#add2da">
           
                    <img src="../../image/main_29.gif" alt="faklj" />
        </div>
        <div style="height:420px">
        <ul id="navigation" >
            
            <li><a class="head">商品管理员个人信息</a>
                <ul>
                 <li><a href="GA_AdminInfo.aspx" target="ifrSubTree">商品管理员个人信息</a></li>
                </ul>
            </li>
            <li><a class="head">商品类目管理</a>
                <ul>
                 <li><a href="GA_AddClum.aspx" target="ifrSubTree">商品类目管理</a></li>
                </ul>
            </li>
             <li><a class="head">商品属性管理</a>
                <ul>
                 <li><a href="GA_AddProperty.aspx" target="ifrSubTree">商品属性管理</a></li>
                </ul>
            </li>
            <li><a class="head">商品的查看</a>
                <ul>
                 <li><a href="GA_GoodExam.aspx" target="ifrSubTree">商品的查看</a></li>
                </ul>
            </li>
            <li><a class="head">商品的添加</a>
            <ul>
             <li><a href="GA_AddGood.aspx" target="ifrSubTree">商品的添加</a></li>
             </ul>
             </li>
             <li><a class="head">添加大图片</a>
            <ul>
             <li><a href="GA_AddBigImg.aspx" target="ifrSubTree">添加大图片</a></li>
             </ul>
             </li>
             <li><a class="head">更改首页商品</a>
            <ul>
             <li><a href="GA_UpdateHomepage.aspx" target="ifrSubTree">更改首页商品</a></li>
             </ul>
             </li>
             <li><a class="head">更改服装城商品</a>
            <ul>
             <li><a href="GA_UpdateClothesCity.aspx" target="ifrSubTree">更改服装城商品</a></li>
             </ul>
             </li>
             <li><a class="head">更改电器城商品</a>
            <ul>
             <li><a href="GA_UpdateCircuitCity.aspx" target="ifrSubTree">更改电器城商品</a></li>
             </ul>
             </li>
             <li><a class="head">更改家具城商品</a>
            <ul>
             <li><a href="GA_UpdateFurnitureCity.aspx" target="ifrSubTree">更改家具城商品</a></li>
             </ul>
             </li>
        </ul>
        </div> 
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
   <%--总框架高度--%>
    <div style="height: 600px;background-color:#add2da;">
       <iframe id="iframe1" name="ifrSubTree" src="GA_AdminInfo.aspx" frameborder="0" 
            scrolling="no" style="width:100%; height:100%;"></iframe>
    </div>
</asp:Content>
