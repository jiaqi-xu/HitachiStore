<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="HitachiStore.backstage.Admin.AdminLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
<script type="text/javascript">
    function show() {
        var a = document.getElementById("imageValidate");
        a.src = a.src + "?";
    }
    </script>       
<script type="text/javascript">
//    var lSubmitOk = [true, true];
//    //对真实姓名格式的限制
//    //$(document).ready(function () {
//        $('#tbxTrueName').blur(function () {
//            var gStr = $(this).val();
//            var gPattern = /^[\u4e00-\u9fa5]{1,5}$/;
//            if (!gStr.match(gPattern) && gStr != "" && gStr != null) {
//                $('#lblName').html('请输入正确格式的姓名！');
//                lSubmitOk[0] = false;
//            }
//            else {
//                $('#lblName').html('');
//                lSubmitOk[0] = true;
//            }
//        });
//    //});
// //对身份证号格式的限制
//       // $(document).ready(function () {
//            $('#tbxIDCardNum').blur(function () {
//                var gStr = $(this).val();
//                var gPattern = /^\d{17}[\d|X]|\d{15}$/;
//                if (gStr == "" || gStr == null) {
//                    lSubmitOk[1] = false;
//                    $('#lblIDcardNO').html('请输入身份证号！');
//                }
//                else if (!gPattern.exec(gStr)) {
//                    lSubmitOk[1] = false;
//                    $('#lblIDcardNO').html('请输入正确的身份证号！');
//                }
//                else {
//                    lSubmitOk[1] = true;
//                    $('#lblIDcardNO').html('');
//                }
//            });
//      //  });

//        //验证与数据绑定
//        function mAlter() {
//            if (lSubmitOk[0]==true&&lSubmitOk[1]==true) {
//                return true;
//            }
//            else {
//                //$('#lblCheck').html('请正确填写信息！');
//                return false;
//            }
//        }
    </script>
<head id="Head1" runat="server">
    <meta http-equiv="Page-Exit" content="revealTrans(duration=5.0, transition=23)" />
    <meta http-equiv="Page-Enter" content="revealTrans(duration=5.0,transition=23)" />
    <title></title>
    <style type="text/css">
        .bg
        {
            position: absolute;
            z-index: 100;
            top: 0px;
            left: 0px;
            background-color: #000;
            filter: alpha(opacity=60);
            -moz-opacity: 0.6;
            opacity: 0.6;
        }
        .style1
        {
            height: 26px;
        }
        .style2
        {
            width: 151px;
            height: 18px;
            border-width: 1px;
            border-color: #10b5e2;
            border-style: solid;
        }
    </style>
    <link href="../../Styles/StyleSheet2.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server" defaultbutton="LoginImBtn">
    <div class="warp">
        <div class="top">
            <img src="../../image/topbg.gif" alt="topbg" /></div>
        <div class="left">
            <img src="../../image/left.gif" alt="left" /></div>
        <div class="center">
            <div class="center1">
                <img src="../../image/centertop.gif" alt="centertop" />
            </div>
            <div class="center2">
                <div class="text1">
                    用户名：</div>
                <div class="text2">
                    <asp:TextBox ID="TbxUserName" runat="server" CssClass="asp1" AutoComplete="off"></asp:TextBox>
                    提示：<asp:Label  ID ="LoginTip" runat ="server" Text ="" ForeColor ="Red" ></asp:Label>
                </div>
                <div class="text1">
                    密&nbsp码：
                </div>
                <div class="text2">
                    <asp:TextBox ID="TbxPassWord" runat="server" CssClass="asp1" TextMode="Password"></asp:TextBox>&nbsp;
                    &nbsp;
                    <asp:Button ID="Register1" runat="server" Text="注册" />
                </div>
            </div>
            <div class="center3">
                <table style="width: 266px; height: 70px">
                    <tr>
                        <td width="21px" id="Rbn">
                            <asp:RadioButton ID="rbnSA" runat="server" GroupName="1" Text="1" />
                        </td>
                        <td width="112px">
                            高级管理员
                        </td>
                        <td width="21px" id="RbnUA">
                            <asp:RadioButton ID="rbnUA" runat="server" GroupName="1" Text="4" />
                        </td>
                        <td width="112px">
                            用户管理员
                        </td>
                    </tr>
                    <tr>
                        <td width="21px" id="RbnOA">
                            <asp:RadioButton ID="rbnOA" runat="server" GroupName="1" Text="2" />
                        </td>
                        <td width="112px">
                            订单管理员
                        </td>
                        <td width="21px">
                            <asp:RadioButton ID="rbnGA" runat="server" GroupName="1" Text="5" />
                        </td>
                        <td width="112px">
                            商品管理员
                        </td>
                    </tr>
                </table>
                <table style="width: 266px; height: 35px;">
                    <tr>
                        <td width="21px">
                            <asp:RadioButton ID="rbnEA" runat="server" GroupName="1" Text="3" />
                        </td>
                        <td width="112px">
                            评价管理员
                        </td>
                        <td width="133px">
                            <asp:ImageButton ID="LoginImBtn" runat="server" ImageUrl="../../image/denglu.gif"
                                OnClick="LoginImBtn_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="right">
            <img src="../../image/rightbg.gif" alt="rightbg" /></div>
        <div class="bottom">
            <img src="../../image/bottombg.gif" alt="bottom" /></div>
    </div>
    <ajaxToolkit:ToolkitScriptManager ID="sasa" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="tbxUserName"
                                FilterType="LowercaseLetters,Numbers ,UppercaseLetters">
                            </ajaxToolkit:FilteredTextBoxExtender>
    <ajaxToolkit:ModalPopupExtender ID="da" PopupControlID="Client" TargetControlID="Register1"
        BackgroundCssClass="bg" runat="server" >
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Client" runat="server" Style="width: 500px">
        <asp:UpdatePanel ID="Uqdate" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                <div>
                    <div style="border: 3px; width: 500px; height: 400px; background-color: Aqua">
                        <div id="plant" runat="server" align="center" style="height: 400px; width: 480px">
                            <div style="width: 130px; height: 130px; float: left">
                                <img src="../../image/png-0010.png" />
                            </div>
                            <div style="height: 130px; line-height: 100px; font-size: 20px; float: right; width: 350px;
                                text-align: left">
                                <div style="margin-top: 20px; height: 30px; text-align: left">
                                    用户注册</div>
                                提示：<asp:Label ID="Tip" runat="server" ForeColor ="Red"  Text="请先验证用户名"></asp:Label>
                            </div>
                            <table style="text-align: left; width: 90%; height: 50%; top: 50%; left: 50%">
                                <tr>
                                    <td style="width: 50px; height: 30px">
                                        用户名
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxRUserName" runat="server" CssClass="style2" MaxLength="20" AutoComplete="off"></asp:TextBox>
                                    </td>
                                    <td style="width: 74px">
                                        密码
                                    </td>
                                    <td class="style1">
                                        <asp:TextBox ID="tbxRPassWord" runat="server" TextMode="Password" CssClass="style2"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                        性别
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="male" runat="server" GroupName="Sex" Text="男" Checked="True" />
                                        <asp:RadioButton ID="female" Text="女" runat="server" GroupName="Sex" />
                                    </td>
                                    <td>
                                        确认密码
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxRPassWord2" runat="server" TextMode="Password" CssClass="style2"
                                            MaxLength="16"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                        姓名
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxTrueName" runat="server" CssClass="style2"></asp:TextBox>
                                        <br/>
                                        <asp:Label ID="lblName" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                    <td>
                                        身份证号
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxIDCardNum" runat="server" CssClass="style2" MaxLength="18"></asp:TextBox>
                                        <br/>
                                        <asp:Label ID="lblIDcardNO" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 30px">
                                        验证码
                                    </td>
                                    <td>
                                        <asp:TextBox ID="tbxValidate" runat="server" CssClass="style2"> </asp:TextBox>
                                    </td>
                                    <td>
                                        <image id="imageValidate" src="../../verification%20code/verification%20code.aspx"
                                            width="71px" height="24px"></image>
                                    </td>
                                    <td>
                                        看不清？ <a href="javascript:show()"><font color="blue">换一张</font></a>
                                    </td>
                                </tr>
                            </table>
                            <%--Ajax控件--%>
                            <ajaxToolkit:FilteredTextBoxExtender ID="UserName" runat="server" TargetControlID="tbxRUserName"
                                FilterType="LowercaseLetters,Numbers ,UppercaseLetters">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <ajaxToolkit:FilteredTextBoxExtender ID="IDCardNum" TargetControlID="tbxIDCardNum"
                                runat="server" FilterType="Custom" ValidChars="0123456789x">
                            </ajaxToolkit:FilteredTextBoxExtender>
                            <%--<asp:Panel ID="Panel1" runat="server">
                                请输入由字母和数字组成的用户名
                            </asp:Panel>
                            <ajaxToolkit:BalloonPopupExtender ID="BalloonPopupExtender" runat="server" TargetControlID="tbxRUserName"
                                BalloonPopupControlID="Panel1" BalloonStyle="Cloud" Position="BottomRight" BalloonSize="Small"
                                DisplayOnClick="true" DisplayOnFocus="true" UseShadow="false">
                            </ajaxToolkit:BalloonPopupExtender>--%>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="BtnCheckUName" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID ="BtnRegister"  EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <div align="center" >
        <table cellspacing="10px" style="margin-top: 10px; width: 100px">
            <tr>
                <td style="height: 15px">
                    <asp:ImageButton ID="BtnRegister" runat="server" OnClick="BtnRegister_Click" ImageUrl="~/image/zhuce.png" />
                </td>
                <td>
                    <asp:ImageButton ID="BtnCancle" runat="server" Text="取消" ImageUrl="~/image/cancle.png" />
                </td>
                <td>
                    <asp:ImageButton ID="BtnCheckUName" runat="server" Text="验证用户名" OnClick="BtnCheckUName_Click "
                        ImageUrl="~/image/yanzheng.png" />
                </td>
            </tr>
        </table>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
