<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SA_GoodExam.aspx.cs" Inherits="HitachiStore.backstage.SeniorAdmin.SA_GoodExam" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--总框架高度--%>
      <div id="whole" style="height: 800px">
            <%--动态管理员信息提示栏--%>
            <div style="height: 28px">
                <table style="width: 100%; height: 28px; background-color: #add2da; border-width:2px">
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
            <%--中间空白--%>
           <div style="width:100%; height:50px"></div>        
            <div>
             <table style="width:75%; background-color:#add2da; "align="center">
               <%--上部空白--%>
                <%--类目选择--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px">
                     <asp:DropDownList ID="ddlFirstClum" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="lbFirstClum" runat="server" Text="一级类目"></asp:Label>
                 </td>
                 <td style="width:150px">
                     <asp:DropDownList ID="ddlSecondClum" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="lbSecondClum" runat="server" Text="二级类目"></asp:Label>
                 </td>
                 <td style="width:150px">
                     <asp:DropDownList ID="ddlThirdClum" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="lbThirdClum" runat="server" Text="三级类目"></asp:Label>
                 </td>
               </tr>
                <%--3个属性名及属性内容--%>
                <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px">
                     <asp:DropDownList ID="ddlPropertyName" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="lbPropertyName" runat="server" Text="属性名"></asp:Label>
                 </td>
                 <td style="width:150px">
                     <asp:DropDownList ID="ddlPropertyContent" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="lbddlPropertyContent" runat="server" Text="属性内容"></asp:Label>
                 </td>
                 <td style="width:150px" colspan="3"></td>
                 <td style="width:150px" colspan="3"></td>
               </tr>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px">
                     <asp:DropDownList ID="DropDownList1" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="Label3" runat="server" Text="属性名"></asp:Label>
                 </td>
                 <td style="width:150px">
                     <asp:DropDownList ID="DropDownList2" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="Label4" runat="server" Text="属性内容"></asp:Label>
                 </td>
                 <td style="width:150px" colspan="3"></td>
                 <td style="width:150px" colspan="3"></td>
               </tr>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px">
                     <asp:DropDownList ID="DropDownList3" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="Label5" runat="server" Text="属性名"></asp:Label>
                 </td>
                 <td style="width:150px">
                     <asp:DropDownList ID="DropDownList4" runat="server" Width="115px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="Label6" runat="server" Text="属性内容"></asp:Label>
                 </td>
                 <td style="width:150px" colspan="2" rowspan="3"></td>
                 <td style="width:150px" colspan="2" rowspan="3"></td>
               </tr>
               <%--商品选择--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td colspan="2">
                   <asp:DropDownList ID="DropDownList5" runat="server" Width="200px"></asp:DropDownList>
                 </td>
                 <td style="width:150px">
                     <asp:Label ID="lbChoseGood" runat="server" Text="商品选择"></asp:Label>
                 </td>
                 <td colspan="3"></td>
               </tr>
               <%--商品详细信息--%>
               <%--GoodID--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbGoodID" runat="server" Text="GoodID:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtGoodID" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--商品名--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbGoodName" runat="server" Text="商品名:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtGoodName" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--价格区间--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbPrice" runat="server" Text="价格:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtlbPriceRange" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--销售量--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbSellVolume" runat="server" Text="销售量:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtSellVolume" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--库存--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbGoodReserve" runat="server" Text="库存:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtlbGoodReserve" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--图片路径--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbPhotoUrl" runat="server" Text="图片路径:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtPhotoUrl" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--广告路径--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     <asp:Label ID="lbAdUrl" runat="server" Text="商品信息图片路径:"></asp:Label>
                 </td>
                 <td style="width:150px;" colspan="2">
                     <asp:TextBox ID="txtAdUrl" runat="server" Width="155px"></asp:TextBox>
                 </td>
               </tr>
               <%--进价--%>
               <tr style="text-align:left; height:35px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td style="width:150px">
                     &nbsp;</td>
                 <td style="width:150px;" colspan="2">
                     &nbsp;</td>
               </tr>
               <%--删除、查看、添加--%>
               <tr style="text-align:right; height:75px">
                 <%--左边空白--%> 
                 <td style="width:75px"></td>
                 <td style="width:150px"></td>
                 <td colspan="3">
                     <asp:Button ID="btnDelete" runat="server" Text="删除" Height="37px" Width="75px" />
                     <asp:Button ID="btnCheck" runat="server" Text="查看" Height="37px" Width="75px" />
                     <asp:Button ID="btnAdd" runat="server" Text="添加" Height="37px" Width="75px" />
                 </td>
                 <td colspan="2"></td>
               </tr>
             </table>
           </div>   
       </div> 
    </div>
    </form>
</body>
</html>
