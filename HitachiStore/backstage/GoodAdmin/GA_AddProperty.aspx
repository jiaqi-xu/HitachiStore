<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_AddProperty.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_AddProperty" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="http://localhost:3193/Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('*').click(function () {
                $('#lblCheck').text('');
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Panel ID="Panel1" runat="server">
        <%--总框架高度--%>
        <div style="height: 488px">
            <%--动态管理员信息提示栏--%>
            <div style="height: 28px; background-color: #add2da">
                <table style="width: 100%; height: 28px; background-color: #add2da">
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
                            商品管理员商品属性管理
                        </td>
                    </tr>
                </table>
            </div>
            <%--商品属性管理--%>
            <div align="center">
                <div style="background-color: #add2da; width: 80%; height: 345px; margin-top: 40px">
                    <div style="width: 100px; height: 25px; margin-top: 15px; margin-bottom: 15px" align="center">
                        <asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="#ff0066" Font-Bold="true"></asp:Label>
                    </div>
                    <table style="width: 75%; margin-left: 0px; border: 1px black solid" align="center">
                        <tr>
                            <td class="style25" style ="border: 1px black solid">
                                <strong>一级类目</strong>
                            </td>
                            <td class="style26" style ="border: 1px black solid">
                                <asp:DropDownList runat="server" Width="100px" ID="drpFirstclass" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpFirstclass_SelectedIndexChanged" Style="border-style: solid;
                                    border-color: Black; border-width: 1px;">
                                </asp:DropDownList>
                            </td>
                            <td rowspan="3" style ="border: 1px black solid">
                                <asp:ListBox ID="ListBox1" runat="server" Height="76px" Width="200px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="style25" style ="border: 1px black solid">
                                <strong>二级类目</strong>
                            </td>
                            <td class="style26" style ="border: 1px black solid">
                                <asp:DropDownList runat="server" Width="100px" ID="drpSecondclass" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpSecondclass_SelectedIndexChanged" Style="border-style: solid;
                                    border-color: Black; border-width: 1px;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style11" style ="border: 1px black solid">
                                <strong>三级类目</strong>
                            </td>
                            <td class="style12" style ="border: 1px black solid">
                                <asp:DropDownList runat="server" Width="100px" ID="drpThirdclass" AutoPostBack="True"
                                    OnSelectedIndexChanged="drpThirdclass_SelectedIndexChanged" Style="border-style: solid;
                                    border-color: Black; border-width: 1px;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div align="center">
                        <table style="margin-top: 8px; width: 75%; border :1px black solid">
                            <tr>
                                <td class="style4" style ="border: 1px black solid">
                                    新增属性名:
                                </td>
                                <td class="style9" style ="border: 1px black solid">
                                    <asp:TextBox ID="tbxAddproname" runat="server" BorderColor="Black" BorderStyle="Solid"
                                        Style="width: 80px;"></asp:TextBox>
                                </td>
                                <td class="style5" style ="border: 1px black solid">
                                    <asp:Button ID="btnAdd" Text="增加" runat="server" OnClick="btnAdd_Click" BorderColor="Black"
                                        BorderStyle="Solid" Style="height: 21px" />
                                </td>
                                <td rowspan="2" class="style21" style ="border: 1px black solid">
                                    <asp:ListBox ID="ListBox2" runat="server" Height="76px" Width="189px"></asp:ListBox>
                                </td>
                            </tr>
                            <tr >
                                <td class="style3" style ="border: 1px black solid">
                                    <asp:DropDownList runat="server" Width="100px" ID="drpNewProname" AutoPostBack="True"
                                        OnSelectedIndexChanged="drpNewProname_SelectedIndexChanged" Style="border-style: solid;
                                        border-color: Black; border-width: 1px;">
                                    </asp:DropDownList>
                                </td>
                                <td class="style9" style ="border: 1px black solid">
                                    <asp:TextBox ID="tbxDelupdate" runat="server" BorderColor="Black" BorderStyle="Solid"
                                        Style=" width: 80px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Button runat="server" ID="btnDelete" Text="删除" Height="23px" OnClick="btnDelete_Click"
                                        BorderColor="Black" BorderStyle="Solid" />
                                    <asp:Button runat="server" ID="btnUpdate" Text="修改" Height="23px" OnClick="btnUpdate_Click"
                                        BorderColor="Black" BorderStyle="Solid" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <table style="margin-top: 20px; width: 75%; border: 1px black solid">
                        <tr style ="border: 1px black solid">
                            <td class="style20" style ="border: 1px black solid">
                                新增属性内容：
                            </td>
                            <td class="style15" style ="border: 1px black solid">
                                <asp:TextBox ID="tbxNewcon" runat="server" BorderColor="Black" BorderStyle="Solid"
                                    Style="width: 80px"></asp:TextBox>
                            </td>
                            <td class="style5" style ="border: 1px black solid">
                                <asp:Button ID="btnAdd1" runat="server" BorderColor="Black" BorderStyle="Solid" OnClick="btnAdd1_Click"
                                    Text="增加" />
                            </td>
                            <td class="style18" style ="border: 1px black solid">
                                <asp:DropDownList ID="drpNewProcon" runat="server" Style="border-style: solid; border-color: Black;
                                    border-width: 1px;" Width="100px">
                                </asp:DropDownList>
                            </td>
                            <td class="style19"style ="border: 1px black solid" >
                                修改为：
                            </td>
                            <td class="style16" style ="border: 1px black solid">
                                <asp:TextBox ID="tbxCondelup" runat="server" BorderColor="Black" BorderStyle="Solid"
                                    Style="width: 80px"></asp:TextBox>
                            </td>
                            <td style ="border: 1px black solid">
                                <asp:Button ID="btnDel1" runat="server" BorderColor="Black" BorderStyle="Solid" Height="23px"
                                    OnClick="btnDel1_Click" Text="删除" />
                                <asp:Button ID="btnUpdate1" runat="server" BorderColor="Black" BorderStyle="Solid"
                                    Height="23px" OnClick="btnUpdate1_Click" Text="修改" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
