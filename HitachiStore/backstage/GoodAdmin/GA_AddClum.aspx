<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_AddClum.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_AddClum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
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
            <div style="height: 28px;">
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
                            商品管理员类目管理
                        </td>
                    </tr>
                </table>
            </div>
            <%--类目管理--%>
            <div style=" background-color: #add2da; 
                width: 80%; margin-left: 10%; height: 320px; margin-top: 10px">
                 <div style=" height:25px; margin-top:20px; margin-bottom:20px;">
                <center>
                   <asp:Label ID="lblCheck" runat="server" Font-Size="Large" ForeColor="#ff0066" Font-Bold="true"></asp:Label>
                </center>
                </div>
                <center>
                    <%--一级类目管理--%>
                   <div style="float: left; width:16% ;text-align:left">
                        一级类目管理：</div>
                    <asp:DropDownList ID="dlistFirstClumName" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="dlistFirstClumName_SelectedIndexChanged" Width="100px" style=" border-style:solid; border-color:Black; border-width:1px;">
                    </asp:DropDownList>
                    <asp:Button ID="Delete1" runat="server" Text="删除" Width="56px" 
                        onclick="Delete1_Click" BorderColor="Black" BorderStyle="Solid" />
                    <asp:TextBox ID="TextBox1" runat="server" BorderColor="Black" 
                        BorderStyle="Solid" style="width: 148px"></asp:TextBox>
                    <asp:Button ID="Update1" runat="server" Text="修改" Width="55px" 
                        BorderColor="Black" BorderStyle="Solid" onclick="Update1_Click" />
                    <asp:Button ID="Add1" runat="server" Text="添加" Width="57px" 
                        onclick="Add1_Click" BorderColor="Black" BorderStyle="Solid" /><br />
                    <asp:ListBox ID="ListBox1" runat="server" Height="74px" Style="margin-left: 0px"
                        Width="466px"></asp:ListBox>
                    <br />
                    <%--二级类目管理--%>
                    <div style="float: left; width:16% ;text-align:left">
                        二级类目管理：</div>
                    <asp:DropDownList ID="dlistSecondClumName" runat="server" AutoPostBack="True" onselectedindexchanged="dlistSecondClumName_SelectedIndexChanged" 
                      Width="100px" style=" border-style:solid; border-color:Black; border-width:1px;" >
                    </asp:DropDownList>
                    <asp:Button ID="Delete2" runat="server" Text="删除" Width="56px" 
                        onclick="Delete2_Click" BorderColor="Black" BorderStyle="Solid" />
                    <asp:TextBox ID="TextBox2" runat="server" BorderColor="Black" 
                        BorderStyle="Solid"></asp:TextBox>
                    <asp:Button ID="Update2" runat="server" Text="修改" Width="55px" 
                        BorderColor="Black" BorderStyle="Solid" onclick="Update2_Click" 
                        Height="20px" />
                    <asp:Button ID="Add2" runat="server" Text="添加" Width="57px" 
                        onclick="Add2_Click" BorderColor="Black" BorderStyle="Solid" /><br />
                    <asp:ListBox ID="ListBox2" runat="server" Height="76px" Style="margin-left: 0px"
                        Width="466px"></asp:ListBox>
                    <br />
                    <%--三级类目管理--%>
                   <div style="float: left; width:16% ;text-align:left">
                        三级类目管理：</div>
                    <asp:DropDownList ID="dlistThirdClumName" runat="server" 
                         Width="100px" style=" border-style:solid; border-color:Black; border-width:1px;">
                    </asp:DropDownList>
                    <asp:Button ID="Delete3" runat="server" Text="删除" Width="56px" 
                        onclick="Delete3_Click" BorderColor="Black" BorderStyle="Solid" />
                    <asp:TextBox ID="TextBox3" runat="server" BorderColor="Black" 
                        BorderStyle="Solid"></asp:TextBox>
                    <asp:Button ID="Update3" runat="server" Text="修改" Width="55px" 
                        BorderColor="Black" BorderStyle="Solid" onclick="Update3_Click" />
                    <asp:Button ID="Add3" runat="server" Text="添加" Width="57px" 
                        onclick="Add3_Click" BorderColor="Black" BorderStyle="Solid" /><br />
                </center>
            </div>
        </div>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
