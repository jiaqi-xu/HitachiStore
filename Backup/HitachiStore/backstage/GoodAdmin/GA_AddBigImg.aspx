<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GA_AddBigImg.aspx.cs" Inherits="HitachiStore.backstage.GoodAdmin.GA_AddBigImg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加商城大图片</title>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        //增加上传量
        function addForm() {
            var strForm = "<br/><input type='file' size='50' name='File'>";
            document.getElementById('MyFile').insertAdjacentHTML("beforeEnd", strForm)
        }
    </script>
</head>
<body>
    
    <div>
        <%--总框架高度--%>
        <div style="height: 600px;background-color: #add2da; ">
            <%--动态管理员信息提示栏--%>
            <div style="height: 28px;">
                <table style="width: 100%; height: 28px; background-color: #add2da; border-width: 1px">
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
                            添加商城大图片
                        </td>
                    </tr>
                </table>
            </div>
            <%--中间空白--%>
            <div style="width: 100%; height: 3px">
            </div>
            <%-- 主界面 --%>
            <div style="text-align: center;">
                <form id="form1" runat="server" enctype="multipart/form-data">
                <%--为首页上传图片--%>
                <h4>为首页添加图片</h4>
                <p id="MyFile">
                    <input type="file" size="50" name="File" />
                </p>
                <p>
                    <input type="button" value="增加一个" onclick="addForm()" />
                    <asp:Button runat="Server" Text="开始上传" ID="UploadButton" OnClick="UploadButton_Click" />
                    <input type="button" value="重置" onclick="this.form.reset()" /><br />
                    <asp:Label ID="Label3" runat="server" />
                </p>
                <%-- 为服装城添加大图片--%>
                <h4>为服装城上传图片：</h4>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btn1" runat="server" Text="上传" OnClick="submit1" /><br />
                <asp:Label ID="Label4" runat="server" /><br />
                <asp:Image ID="Image1" runat="Server" Height="50px" />
                <%--为电器城添加大图片--%>
                <h4>为电器城上传图片：</h4>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:Button ID="Button1" runat="server" Text="上传" OnClick="submit2" /><br />
                <asp:Label ID="Label5" runat="server" /><br />
                <asp:Image ID="Image2" runat="Server" Width="50px" Height="50px" />
                <%--为家具城添加大图片--%>
                <h4>为家具城上传图片：</h4>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:Button ID="Button2" runat="server" Text="上传" OnClick="submit3" /><br />
                <asp:Label ID="Label6" runat="server" /><br />
                <asp:Image ID="Image3" runat="Server" Width="50px" Height="50px" />
                </form>
            </div>
        </div>
    </div>
   
</body>
</html>
