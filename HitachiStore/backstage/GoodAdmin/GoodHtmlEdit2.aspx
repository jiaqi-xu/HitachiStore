<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodHtmlEdit2.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GoodHtmlEdit2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 100%; height: 500px;">
        <div style="width: 30%; height: 144px; float: left;">
            <div>
                商品详细描述：
            </div>
        </div>
        <div style="width: 69%; height: 144px; float: left;">
            <textarea id="EditText" BorderColor="Black" BorderStyle="Solid" runat="server" 
                style="border: thin solid #000000; width: 560px; height: 136px">
        </textarea>
        </div>
        <div style="width: 30%; height: 25px; float: left; margin-top: 5px; padding-top: 1px;">
            图片路径：
        </div>
        <div style="width: 69%; height: 25px; float: left; margin-top: 5px; padding-top: 1px;">
            <div style="width: 50%; height: 100%; float: left;">
                <asp:FileUpload ID="FileUpload1" runat="server" BorderColor="Black" BorderStyle="Solid" />
            </div>
            <div style="width: 40%; height: 100%; float: left; text-align: center;">
                <asp:Button ID="btn_update" runat="server" BorderColor="Black" BorderStyle="Solid" OnClick="btn_update_Click" Text="保存" />
            </div>
        </div>
        <div style="height: 25px;">
            <div style="float: left; height: 25px; width: 200px;">
                <asp:Label ID="tip" runat="server" Font-Size="Large" ForeColor="#FF66FF"></asp:Label></div>
        </div>
        <div style="width: 100%; height: 242px;">
            <asp:DataList ID="datalist_exam" runat="server" Width="100%" Height="100%"  
                ondeletecommand="datalist_exam_DeleteCommand" 
                oneditcommand="datalist_exam_EditCommand">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <table style="width: 100%">
                        <tr style="width: 100%;">
                            <td style="width: 40%;">
                                <asp:TextBox ID="TextBox1" BorderColor="Black" BorderStyle="Solid" runat="server" Text='<%#Eval("EditText")%>'></asp:TextBox>
                            </td>
                            <td style="width: 40%;">
                            <asp:TextBox ID="TextBox2" BorderColor="Black" BorderStyle="Solid" runat="server" Text='<%#Eval("EditImg")%>'></asp:TextBox>
                                
                            </td>
                            <td style="width: 20%;">
                                <asp:Button ID="btn_delete" runat="server" Text="删除" BorderColor="Black" BorderStyle="Solid" CommandName="Delete" />
                           
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
    </div>
    </form>
</body>
</html>
