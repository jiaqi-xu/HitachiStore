<%@ Page Title="" Language="C#" MasterPageFile="~/backstage/Back_Master/FirstLogin.Master" AutoEventWireup="true" CodeBehind="EA_SubTree.aspx.cs" Inherits="HitachiStore.backstage.EvaluationAdmin.Left_SubTree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <style type="text/css">
    .btn
    {
     border-right: #7b9ebd 1px solid; 
     padding-right: 2px; 
     border-top: #7b9ebd 1px solid; 
     padding-left  : 2px; 
     font-size : 12px; 
     FILTER: progid:DXImageTransform.Microsoft.Gradient(GradientType=0,StartColorStr=#ffffff, EndColorStr=#cecfde); 
     border-left: #7b9ebd 1px solid; 
     cursor  : hand; 
     color : black; 
     padding-top: 2px; 
     BORDER-BOTTOM: #7b9ebd 1px solid
}

</style>
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
            list-style-type: none;
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
            list-style-type: none;
        }
        #navigationa li
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
            list-style-type: none;
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
   
    <div style="height: 488px; width: 147px">
        <div style="width: 100%; height: 28px; background-color: #add2da">
            <img src="../../image/main_29.gif" alt="faklj" />
        </div>
        <div style="height: 420px">
            <ul id="navigation">
                <li><a class="head">评价管理员个人信息</a>
                    <ul>
                        <li><a href="EA_AdminInfo.aspx" target="ifrSubTree">评价管理员个人信息</a></li>
                    </ul>
                </li>
                <li><a class="head">用户评价管理</a>
                    <ul>
                        <li><a href="EA_EvaluationExam.aspx" target="ifrSubTree">用户评价管理</a></li>
                    </ul>
                </li>
            </ul>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--总框架高度--%>
    <div style="height: 600px">
       <iframe id="iframe1" name="ifrSubTree" src="EA_AdminInfo.aspx" frameborder="0" scrolling="no" style="background-color:#add2da; width:100%; height:100%;"></iframe>
    </div>
</asp:Content>
