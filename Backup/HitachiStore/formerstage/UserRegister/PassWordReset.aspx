<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PassWordReset.aspx.cs" Inherits="HitachiStore.formerstage.UserRegister.PassWordReset"  MasterPageFile="~/formerstage/stage_Master/Secondary.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <center style="margin-top:20px">
    <title>天外天商城—重置密码</title>
    <%--Ajax对密码的输入限制--%>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        //第一次输入密码
        function PassWordExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "PassWordReset.aspx/PassWordExam",
                data: "{PassWord:'" + $("#tbxResetPassword").val() + "'}",   //传入输入的密码
                datatype: "json",
                success: function (result) {                                   //根据结果返回相应的提示
                    $("#ContentPlaceHolder1_lblResetPassword").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
        //确认密码
        function CPassWordExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "PassWordReset.aspx/ConfirmPassWordExam",
                data: "{PassWord:'" + $("#tbxResetPassword").val() + "',cPassWord:'" + $("#tbxResetagain").val() + "'}",    //传入在此输入的密码
                datatype: "json",
                success: function (result) {                                                                     //根据结果返回相应的提示
                    $("#ContentPlaceHolder1_lblResetagain").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
    </script>
   <%--全局--%>
   <div style="margin-top: 80px; margin-bottom:80px; margin-left: 0px; width: 75%; height: 350px; border: 1px;
                border-color: #ed1100; border-style: solid" id="div_Whole">
         <%--头部提示--%>
                <div style="width:100%;" id="divTop">                  
                    <div style=" border:none;  height:30px;text-align:left;background-image: url('../../image/微条.jpg'); background-repeat:repeat-x; font-size:11pt;padding-left:10px; color:white; line-height:30px; " ><strong>重置密码</strong></div>                             
                </div>
            <div id="wholeDiv" style="height:35px;"></div>
            <table id="table_Content" width="100%" cellspacing="30px" >
                <%--用户提示--%>
                <tr>
                   <td align="center" style=" font-family:@华文楷体;font-size:12pt; color:Gray; width:100%;" colspan ="3">请设置新的登录密码，这次一定要记牢哦！</td>
                </tr>
                <%--设置新密码--%>
                <tr>
                    <td align="right" style="font-size:18pt">设置新密码：</td>
                    <td align="left" style="width:202px"><div><asp:TextBox runat="server" ID="tbxResetPassword" TextMode="Password" Height="24px" Width="202px" BorderColor="Red"
                                        BorderWidth="1px" MaxLength="18" CausesValidation="true" onblur="PassWordExam()" ClientIDMode="Static"></asp:TextBox></div></td>
                    <td  align="left" style="width:220px"><asp:Label ID="lblResetPassword" runat="server"></asp:Label></td>
                </tr>
                <%--请再次输入密码--%>
                <tr>
                     <td align="right" style="font-size:18pt">请再次输入密码：</td>
                     <td align="left"><div><asp:TextBox runat="server" ID="tbxResetagain" TextMode="Password" Height="24px" Width="202px" BorderColor="Red"
                                        BorderWidth="1px" MaxLength="18" CausesValidation="true" onblur="CPassWordExam()" ClientIDMode="Static" ></asp:TextBox></div>
                     </td>
                     <td align="left"><asp:Label ID="lblResetagain" runat="server"></asp:Label></td>
                </tr>
                <%--完成并提交--%>
                <tr>
                    <td align="center" colspan="3">
                        <asp:Button runat="server" ID="btnSubmit" Text="完成" Width="80px" 
                            Height="30px" ForeColor="White" 
                            style="background-image:url('../../image/微条.jpg'); background-repeat:repeat-x;" 
                            BorderStyle="None" Font-Bold="true" onclick="btnSubmit_Click"/></td>
                </tr>
            </table>
        </div>
</center>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
</asp:Content>
