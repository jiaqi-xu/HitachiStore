<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_UpdateClothesCity.aspx.cs"
    Inherits="HitachiStore.backstage.GoodAdmin.GA_UpdateClothesCity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="div_whole">
        <asp:UpdatePanel runat="server" ID="updatepal" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="div_top" style="height: 20px; text-align: center">
                    <asp:Label ID="lbPrompt" runat="server"></asp:Label>
                </div>
                <div style="text-align: left; width: 391px; float: left">
                    <div style="height: 430px; width: 400; border: 1px solid red; background-color: Gray;
                        border-right-style: none">
                        <asp:CheckBoxList runat="server" CellPadding="10" ID="cblistUpdate">
                        </asp:CheckBoxList>
                        <br />
                        <br />
                    </div>
                </div>
                <div style="float: right; width: 433px; height: 430px; background-color: Gray; margin-right: 10px;
                    border: 1px solid red; border-left-style: none">
                    <asp:DataList runat="server" ID="dlistPictureShow" RepeatColumns="2" RepeatDirection="Horizontal"
                        DataKeyField="ImgAddress" OnEditCommand="dlistPictureShow_EditCommand">
                        <ItemTemplate>
                            <div style="width: 220; height: 64px">
                                <%--<img id="Img1" src='<%#Eval("ImgAddress") %>' runat="server" style="width: 210px;
                                    height: 64px; margin-left: 5px" />--%>
                                <asp:ImageButton runat="server" ID="imgbtn" CommandName="Edit" ImageUrl='<%#Eval("ImgAddress") %>'
                                    Style="width: 210px; height: 64px; margin-left: 5px" />
                            </div>
                            <div style="height: 15px; width: 210px">
                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("ImgTitle") %>'></asp:Label>
                            </div>
                            <%--   <img src=<%#Eval("ImgAddress") %> style="width:190px;height:64px" />--%>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div>
                    <asp:Button runat="server" ID="btnUpPage" Text="上一页" OnClick="btnUpPage_Click" />
                    <asp:Label runat="server" ID="lbPage"></asp:Label>
                    <asp:Button runat="server" ID="btnDownPage" Text="下一页" OnClick="btnDownPage_Click"
                        Style="height: 21px" />
                    <asp:Button runat="server" ID="btnSubmit" Text="提交" Style="margin-left: 300px" OnClick="btnSubmit_Click" />
                </div>
                <div>
                    <asp:DropDownList runat="server" ID="drpdownlist">
                    </asp:DropDownList>
                    <asp:TextBox runat="server" ID="tbxUpdate"></asp:TextBox>
                    <asp:Button ID="btnUpdate" runat="server" Text="修改" OnClick="btnUpdate_Click" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnUpPage" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnDownPage" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnUpdate" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
