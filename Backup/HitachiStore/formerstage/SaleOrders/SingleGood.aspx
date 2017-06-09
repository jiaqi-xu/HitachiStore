<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleGood.aspx.cs" Inherits="HitachiStore.formerstage.SaleOrders.SingleGood"
    MasterPageFile="~/formerstage/stage_Master/ShowProduct.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxToolkit" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function add() {
            var a = document.getElementById("<%=tbxGoodCount.ClientID %>").value;
            $.ajax({
                type: "Post",
                contenttype: "application/josn",
                url: "SingleGood.aspx/Add",
                data: "{'Count','" + a + "'}",
                datatype: "josn",
                success: function (result) {
                    $("#tbxGoodCount").html(result.d);
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
        function reduce() {
            var a = document.getElementById("<%=tbxGoodCount.ClientID %>").value;
            $.ajax({
                type: "Post",
                contenttype: "application/josn",
                url: "SingleGood.aspx/Reduce",
                data: "{,'" + a + "'}",
                datatype: "josn",
                success: function (result) {
                    $('#tbxGoodCount').html(result.d);
                },
                error: function (result) {
                    alert(result);
                }
            });
        }
        function bbb() {
            $.ajax({
                type: "Post",
                contentType: "application/json",
                url: "SingleGood.aspx/b",
                data: "{}",
                datatype: "json",
                success: function (result) {
                    var content = result.d;
                    if (content != null || content != "") {

                        window.location.href = "../UserRegister/Login.aspx";
                    }
                },
                error: function (err) {
                    alert(err);
                }
            });
        }
    </script>
    <style type="text/css">
        a :hover
        {
            border-color: #ffcc00;
        }
        .b
        {
            z-index: 100;
            top: 0px;
            left: 0px;
            background-color: #000;
            filter: alpha(opacity=60);
            -moz-opacity: 0.6;
            opacity: 0.6;
        }
    </style>
    <center>
        <%--全局--%>
        <div id="div_Whole" style="text-align: center; height: 100%; width: 99%; margin-top: 10px">
            <%--头部样式 --%>
            <div id="div_topItem" style="height: 30px; background-repeat: repeat-x; font-size: larger;
                padding-top: 5px; padding-left: 9px; color: Black; text-align: left; font-size: 16pt;">
                <strong>个体商品</strong>
            </div>
            <%--内容--%>
            <div style="height: 20px; text-align: left;">
                <asp:LinkButton ID="linkbtn_FirstName" runat="server">一级类目名称></asp:LinkButton>
                >
                <asp:LinkButton ID="linkbtn_SecondName" runat="server">二级类目名称></asp:LinkButton>
                >
                <asp:LinkButton ID="linkbtn_ThirdName" runat="server">三级类目名称</asp:LinkButton>
            </div>
            <div style="width: 100%; height: 2px; background-color: Red;">
            </div>
            <div style="height: 20px; margin-top: 5px;">
                <asp:Label runat="server" ID="lbFirstName"></asp:Label>
                <asp:Label runat="server" ID="lbSecondName"></asp:Label>
            </div>
            <div style="height: 300px; text-align: center">
                <div style="float: left; width: 60%; height: 300px">
                    <div style="float: left; width: 250px; height: 298px;">
                        <asp:Image ID="Image1" runat="server" Width="250px" ImageUrl="~/image/质保.jpg" Height="298px" />
                    </div>
                    <div style="float: right; width: 250px; height: 298px; margin-right: 50px">
                        <img runat="server" id="imgGoodShow" width="250" height="298" />
                    </div>
                </div>
                <div style="float: right; width: 40%; height: 300px">
                    <table style="width: 90%; height: 130px; font-size: 14pt; text-align: left;">
                        <tr>
                            <td style="width: 100px">
                                商品编号：
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lbGoodID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                价格:
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lbGoodPrice"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 100px">
                                评价：
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <div style="height: 50px; width: 100%; border: 2px solid red; border-bottom-style: dotted;
                        background-image: url(../../image/左侧树背景2.png)">
                        <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional"
                            Style="font-size: 18pt;">
                            <ContentTemplate>
                                <div style="height: 50px; width: 100%; text-align: center; margin-top: 15px">
                                    <a>我要买：
                                        <asp:Button runat="server" ID="btnAdd" Text="+" Style="background-image: url(../../image/标题头微条.jpg);
                                            width: 30px" OnClick="btnAdd_Click" />
                                        <asp:TextBox runat="server" ID="tbxGoodCount" Style="width: 40px; border: 1px solid red;
                                            margin-left: 10px" Text="1"></asp:TextBox>
                                        <asp:Button runat="server" ID="btnReduce" Text="-" Style="background-image: url(../../image/标题头微条.jpg);
                                            margin-left: 10px; width: 30px" OnClick="btnReduce_Click" />
                                </div>
                                </a>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="btnReduce" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div style="border: 2px solid red; width: 100%; border-top-style: none; height: 50px;
                        background-image: url(../../image/左侧树背景2.png)">
                        <asp:Button ID="btnSubmit" runat="server" Text="确认付款" OnClick="btnSubmit_Click1"
                            Style="background-image: url(../../image/标题头微条.jpg); height: 25px; margin-top: 15px;
                            border: 1px solid  #ffcc00" Width="70px" ForeColor="White" />
                    </div>
                </div>
            </div>
        </div>
        <div style="height: 25px; background-image: url(../../image/标题头微条.jpg); margin-top: 10px;
            color: White; font-size: large; padding-top: 5px; text-align: left; padding-left: 5px;">
            <strong>商品介绍</strong>
        </div>
        <div style="height: 500px; margin-top: 0px;">
            <asp:DataList ID="DataList1" runat="server" Width="100%">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 100%; margin-top: 0px;">
                        <tr style="width: 100%; height: 200px;">
                            <td>
                                <asp:Image ID="Image2" runat="server" ImageUrl='<%#Eval("EditImg")%>' />
                            </td>
                        </tr>
                        <tr style="width: 100%; height: 50px;">
                            <td style="width: 80%;">
                                <div style="width: 800px; margin-left: 20%;">
                                    <%#Eval("EditText")%>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <asp:Panel runat="server" ID="palConfirmInfo" Style="background-image: url(../../image/左侧树背景.png);
            height: 470px; width: 480px" OnLoad="palConfirmInfo_Load">
            <center>
                <div style="height: 25px; background-image: url(../../image/微条.jpg)">
                </div>
               <%-- <div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:Label runat="server" Font-Size="18pt" ID="lbShow"></asp:Label>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnSubmitOrder" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>--%>
                <table cellpadding="10px" cellspacing="10px" style="font-size: 18pt; margin-top: 30px">
                    <tr>
                        <td style="width: 200px">
                            姓名：
                        </td>
                        <td style="width: 280px">
                            <asp:Label runat="server" ID="lbUserName"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            电话：
                        </td>
                        <td>
                            <AjaxToolkit:FilteredTextBoxExtender runat="server" TargetControlID="tbxUserPhone"
                                FilterType="Numbers">
                            </AjaxToolkit:FilteredTextBoxExtender>
                            <asp:TextBox runat="server" ID="tbxUserPhone" Width="202px" Height="24px" BorderColor="Red"
                                BorderWidth="1px" MaxLength="11"></asp:TextBox>
                            <%--<asp:Label ID="lbPhone" runat="server" Font-Size="10pt" ClientIDMode="Static"></asp:Label>--%>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="font-size: 18pt;">
                            收货地址：
                        </td>
                        <td>
                            <div>
                                <asp:RadioButton runat="server" Text="是否为送货地址" ID="rbtnAddress1" GroupName="Address" />
                                <asp:TextBox runat="server" ID="tbxAddress1" Width="202px" Height="24px" BorderColor="Red"
                                    BorderWidth="1px">
                                </asp:TextBox>
                                <br />
                                <br />
                                <asp:RadioButton runat="server" Text="是否为送货地址" ID="rbtnAddress2" GroupName="Address" />
                                <asp:TextBox runat="server" ID="tbxAddress2" Width="202px" Height="24px" BorderColor="Red"
                                    BorderWidth="1px">
                                </asp:TextBox>
                                <br />
                                <br />
                                <asp:RadioButton runat="server" Text="是否为送货地址" ID="rbtnAddress3" GroupName="Address" />
                                <asp:TextBox runat="server" ID="tbxAddress3" Width="202px" Height="24px" BorderColor="Red"
                                    BorderWidth="1px">
                                </asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            总价格：
                        </td>
                        <td>
                            <asp:UpdatePanel runat="server" ID="updatePalMoney">
                                <ContentTemplate>
                                    <asp:Label runat="server" ID="lbMoney"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAdd" EventName="Click" />
                                    <asp:AsyncPostBackTrigger ControlID="btnReduce" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSubmitOrder" Text="提交订单" runat="server" Height="25px" Style="background-image: url(../../image/标题头微条.jpg);
                                margin-left: 20px" Width="70px" BorderStyle="None" ForeColor="White" OnClick="btnSubmitOrder_Click" />
                            <asp:Button ID="btnCancelOrder" Text="取消" runat="server" Height="25px" Style="background-image: url(../../image/标题头微条.jpg);
                                margin-left: 20px" Width="70px" BorderStyle="None" ForeColor="White" OnClick="btnCancelOrder_Click" />
                        </td>
                    </tr>
                </table>
            </center>
        </asp:Panel>
        <AjaxToolkit:ModalPopupExtender BackgroundCssClass="b" ID="ModalPopupExtender1" runat="server"
            PopupControlID="palConfirmInfo" TargetControlID="lbUserName" DropShadow="true">
        </AjaxToolkit:ModalPopupExtender>
        </div>
    </center>
</asp:Content>
