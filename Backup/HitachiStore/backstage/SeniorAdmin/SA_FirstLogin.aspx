﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_FirstLogin.aspx.cs"
    Inherits="HitachiStore.backstage.SeniorAdmin.SA_FirstLogin"  MasterPageFile="~/backstage/Back_Master/FirstLogin.Master" %>

    <asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
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
    </style>

   
    <div style="height: 488px; width:147px">
        <div style="width: 100% ;height:28px; background-color:#add2da">
           
                    <img src="../../image/main_29.gif" alt="faklj" />
        </div>
        <div style="height:420px">
        <ul id="navigation">
            <li>
            <a class="head">高级管理员个人信息</a>
                <ul>
                    
        <li><a href="SA_AdminInfo.aspx">高级管理员个人信息</a></li>
      
                    
                </ul>
            </li>
            <li>
            <a class="head">普通管理员信息管理</a>
                <ul>
                   
        
        <li><a href="AdminExam.aspx" >普通管理员信息管理</a></li>
                   
                </ul>
            </li>
            <li><a class="head">用户信息查看</a>
                <ul>
     
        <li><a href="SA_UserExam.aspx">用户信息查看</a></li>
                    
                </ul>
            </li>
            <li><a class="head">商品信息查看</a>
                <ul>
                         <li><a href="SA_GoodExam.aspx">商品信息查看</a></li>
       
                </ul>
            </li>
            <li><a class="head">订单信息查看</a>
                <ul>
                 <li><a href="SA_OrderExam.aspx" >订单信息查看</a></li>
                </ul>
            </li>
            <li><a class="head">评价信息查看</a> 
             <ul>
                 <li><a href="SA_EvaluationExam.aspx">评价信息查看</a></li>
                </ul>
            </li>
               <li><a class="head">日志管理</a> 
             <ul>
                 <li><a href="SA_DailyRecord.aspx">日志管理</a></li>
                </ul>
            </li>
        </ul>
        </div> 
    </div>
</asp:Content>
