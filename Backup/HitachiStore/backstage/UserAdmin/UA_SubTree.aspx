<%@ Page Title="" Language="C#" MasterPageFile="~/backstage/Back_Master/FirstLogin.Master" AutoEventWireup="true" CodeBehind="UA_SubTree.aspx.cs" Inherits="HitachiStore.backstage.UserAdmin.UA_SubTree" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
  
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
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
         input
        {
            border-color:black;
            border-bottom-style:solid;
            border-width:0.5px 0.5px 1px 1px;
        }
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
    </style>

  
    <div style="height: 488px; width:147px">
        <div style="width: 100% ;height:28px; background-color:#add2da">
           
                    <img src="../../image/main_29.gif" alt="faklj" />
        </div>
        <div style="height:420px">
        <ul id="navigation">
            <li><a class="head">用户管理员个人信息</a>
                <ul>
                   
        <li><a href="UA_AdminInfo.aspx" target="UAifrSubTree">用户管理员个人信息</a></li>                  
                </ul>
            </li>
           
            <li><a class="head">用户信息的查看</a>
            
                      <ul>
                   
        <li><a href="UA_UserExam.aspx" target="UAifrSubTree">用户信息的查看</a></li>
        
                    
                </ul>
             </li>
        </ul>
        </div> 
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <%--总框架高度--%>
    <div style="height: 600px">
       <iframe id="iframe2" name="UAifrSubTree" src="UA_AdminInfo.aspx" frameborder="0" scrolling="no" style="background-color:#add2da; width:100%; height:100%;"></iframe>
    </div>
</asp:Content>
