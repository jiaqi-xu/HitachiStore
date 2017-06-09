<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="HitachiStore.formerstage.Evaluation.Evaluation"
    MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
     .button
        {
            background-image: url(../../image/标题头微条.jpg);
            height: 25px;
            width: 70px;
            border: 1px solid #ffcc00;
            forecolor: white;
        }
</style>
    <center style="margin-top: 50px">
        <%--全局--%>
        <div id="div_Whole" style="height: 500px; border-bottom-style: solid; border-color: red;">
            <%--样式--%>
            <div id="div_topItem" style="height: 30px; background-image: url(../../image/微条.jpg);
                background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                color: White; text-align: left;">
                评价商品</div>
            <div id="div_topBlank" style="height: 120px">
            </div>
            <%--控件--%>
            <div id="div_Content">
                <table cellpadding="10px" cellspacing="10px" width="50%" id="table_Content" style =" height :300px; border :1px solid black">
                    <tr>
                        <td align="right" style="width: 45%">
                             <strong>订单号:</strong>
                        </td>
                        <td align="left">
                            <asp:TextBox ReadOnly="true" ID="txbOrderID" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButton runat="server" Text="好" ID="rbtnEvaluateGood" GroupName="Evaluate" />
                            <asp:RadioButton runat="server" Text="中" ID="rbtnEvaluateMiddle" GroupName="Evaluate" />
                            <asp:RadioButton runat="server" Text="差" ID="rbtnEvaluateBad" GroupName="Evaluate" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <div style="vertical-align: top; height :100%">
                                <div style =" margin-top :0px; float:left "><strong >详细意见：</strong></div>
                                <textarea id="txaEvaluateContent" runat="server" rows ="5" cols="5" style =" width :350px"></textarea></div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Button CssClass="button" runat="server" ID="btnSubmit" Text="提交" OnClick="btnSubmit_Click" Style="height: 35px" />
                        </td>
                    </tr>
                </table>
            </div>
            <%--footer--%>
            <div id="footer">
            </div>
        </div>
        <animations>
        <asp:Panel runat="server" ID="palShow" style="height:100px; width:200px; background-image:url(../../image/左侧树背景2.png)">
            <center>
            <div style="text-align:left; background-image:url(../../image/微条.jpg);height:25px">
                评价订单
            </div>
            <div style="margin-top:15px">
                <asp:Label runat="server" ID="lbShowMessage"></asp:Label>
            </div>
            <div style="margin-top:20px">
                <asp:Button ID="Ok" Text="确定" runat="server" style="background-image: url(../../image/标题头微条.jpg)"
                                    Width="70px" Height="25px" BorderStyle="None" 
                    ForeColor="White" onclick="Ok_Click" />
                <asp:Button ID="Cancel" Text="取消" runat="server" style="background-image: url(../../image/标题头微条.jpg);
                                    margin-left: 20px" Width="70px" Height="25px" BorderStyle="None" ForeColor="White"  />
            </div>
            </center>
        </asp:Panel>
        </animations>
        <AjaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="Cancel"
            DropShadow="true" OkControlID="Ok" PopupControlID="palShow" TargetControlID="Ok">
        </AjaxToolkit:ModalPopupExtender>
    </center>
</asp:Content>
