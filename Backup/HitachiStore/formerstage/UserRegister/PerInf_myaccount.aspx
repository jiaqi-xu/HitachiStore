<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PerInf_myaccount.aspx.cs"
    Inherits="HitachiStore.formerstage.UserRegister.PerInf_myaccount" MasterPageFile="~/formerstage/stage_Master/PersonIfor.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" ID="Content1" runat="server">
    <div id="div_Whole" align="center" style="height: 400px; border: 1px solid red;">
        <div id="div_Content" style="width: 100%; margin-top: 0px; height: 400px;">
            <div id="div_topItem" style="height: 30px; text-align: left; background-image: url(../../image/微条.jpg);
                background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                color: White;">
                <strong>个人中心-账号信息</strong>
            </div>
            <div id="div-Table" style="margin-top: 1px">
                <table id="table_Content" cellspacing="20px" style="margin-top: 50px; border: 1px solid #ed1100">
                    <tr>
                        <td style="text-align: right; font-size: 18pt">
                            用户名:
                        </td>
                        <td>
                            <asp:TextBox ID="tbxUserName" runat="server" ReadOnly="true" Width="202px" Height="24px"
                                BorderColor="Red" BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 18pt">
                            会员类型:
                        </td>
                        <td>
                            <asp:TextBox ID="tbxUserType" runat="server" ReadOnly="true" Width="202px" Height="24px"
                                BorderColor="Red" BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 18pt">
                            累计消费金额:
                        </td>
                        <td>
                            <asp:TextBox ID="tbxTotalConsum" runat="server" ReadOnly="true" Width="202px" Height="24px"
                                BorderColor="Red" BorderWidth="1px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: right;">
                            <div  align="center" >
                                <asp:Button ID="AlterPwd" runat="server" Text="修改密码" OnClick="AlterPwd_Click" Width="97px"
                                    Height="30px" Style="background-image: url('../../image/微条.jpg');" BorderColor="Yellow"
                                    BorderStyle="Solid" BorderWidth="1px" ForeColor="White" Font-Size="Large" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
    </div>
</asp:Content>
