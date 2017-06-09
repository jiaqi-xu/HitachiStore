<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Activation.aspx.cs" Inherits="HitachiStore.formerstage.UserRegister.Activation"
    MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<meta http-equiv="Refresh" content="10;url=Login.aspx"/>
    <center style="margin-top: 50px">
        <%--全局--%>
        <div style="margin-top: 80px; margin-bottom: 80px; margin-left: 0px; width: 70%;
            height: 350px; border: 1px; border-color: #ed1100; border-style: solid" id="div_Whole">
            <%--头部提示--%>
            <div style="width: 100%;" id="divTop">
                <div style="border: none; height: 30px; text-align: left; background-image: url('../../image/微条.jpg');
                    background-repeat: repeat-x; font-size: 11pt; padding-left: 10px; color: white;
                    line-height: 30px;">
                    <strong>注册新用户</strong></div>
            </div>
            <div id="div_topBlank" style="height: 50px">
            </div>
            <%--提示邮箱链接--%>
            <div id="div_Content">
                <table id="table_Content" width="100%">
                    <tr>
                        <td style="font-size: 18pt; text-align:center;">
                            <asp:Label ID="labActivation" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    </table>
            </div>
        </div>
    </center>
</asp:Content>
