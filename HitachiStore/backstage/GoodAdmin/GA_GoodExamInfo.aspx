<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_GoodExamInfo.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_GoodExamInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="whole" style="height: 800px">
        <%--动态管理员信息提示栏--%>
        <div style="height: 28px;">
            <table style="width: 100%; height: 28px; background-color: #add2da; border-width: 2px">
                <tr>
                    <td style="width: 3%">
                    </td>
                    <td style="width: 12%; font-size: smaller; text-align: left">
                        当前登录用户:<br />
                    </td>
                    <td style="width: 6%; text-align: left">
                        <asp:Label ID="label1" runat="server"></asp:Label>
                    </td>
                    <td style="width: 10%; font-size: smaller; text-align: left">
                        用户角色:<br />
                    </td>
                    <td style="width: 6%; text-align: left">
                        <asp:Label ID="label2" runat="server"></asp:Label>
                    </td>
                    <td style="width: 63%">
                    </td>
                </tr>
            </table>
        </div>
        <%--内容页功能说明--%>
        <div style="background-color: #353c44; height: 28px; border-style: solid; border-color: White;
            border-width: 3px">
            <table style="width: 100%; height: 28px">
                <tr>
                    <td style="width: 3%">
                    </td>
                    <td style="width: 97%; text-align: left; color: White; font-size: smaller">
                        商品详细信息
                    </td>
                </tr>
            </table>
        </div>
        <%--商品详细信息--%>
        <div>
            <table cellpadding="10px" cellspacing="10px" style="width: 100%;font-size:18pt">
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbShow" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品名称：

                    </td>
                    <td>
                        <asp:TextBox BorderColor="Black" BorderStyle="Solid" runat="server" ID="tbxGoodName"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品价格：

                    </td>
                    <td>
                        <asp:TextBox BorderColor="Black" BorderStyle="Solid" runat="server" ID="tbxGoodPrice"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品库存：

                    </td>
                    <td>
                        <asp:TextBox BorderColor="Black" BorderStyle="Solid" runat="server" ID="tbxGoodIncontory"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        商品销量:
                    </td>
                    <td>
                        <asp:TextBox BorderColor="Black" BorderStyle="Solid" runat="server" ID="tbxGoodSales"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        图片名称：

                    </td>
                    <td>
                        <asp:TextBox BorderColor="Black" BorderStyle="Solid" runat="server" ID="tbxGoodImgTitle"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        图片路径:
                    </td>
                    <td>
                        <asp:TextBox BorderColor="Black" BorderStyle="Solid" runat="server" ID="tbxGoodImgUrl"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button BorderColor="Black" BorderStyle="Solid" runat="server" ID="btnUpdate" Text="修改信息" 
                            onclick="btnUpdate_Click" />
                        
                       </td>
                       <td>
                       <asp:Button BorderColor="Black" BorderStyle="Solid" ID="btnEdit" runat="server" Text="编辑" onclick="btnEdit_Click" 
                               Width="68px" />
                       </td>
                </tr>
            </table>
        </div>
    </div> 
    </div>
    </form>
</body>
</html>
