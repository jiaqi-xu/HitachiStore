﻿<%--
 * 1 功能描述：
 *   商品注册界面；
 * 2 作者：
 *   郭正肖；
   3 创建时间：
 *   2012-08-08-09-25；
 * 4 完成时间：
 * 
 * 5 修改记录：
 *   暂无（修改时间、内容、人）；
 */
--%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="HitachiStore.formerstage.UserRegister.Register"
    MasterPageFile="~/formerstage/stage_Master/Secondary.Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%--验证码样式--%>
    <script src="../../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function UserNameExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/UserNameExam",
                data: "{UserName:'" + $("#tbxUserName").val() + "'}",
                datatype: "json",
                success: function (result) {
                    if (result.d == "√") {
                        $("#tiplbUserName").html(result.d);
                    } else {
                        $("#tiplbUserName").html(result.d);
                    }
                    //                    document.getElementById("ContentPlaceHolder1_lblTest").outerText = result.d;
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
    </script>
    <script type="text/javascript">
//    密码验证
        function PassWordExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/PassWordExam",
                data: "{PassWord:'" + $("#tbxPassWord").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#ContentPlaceHolder1_labPassWord").html(result.d);
                    //                    document.getElementById("ContentPlaceHolder1_lblTest").outerText = result.d;
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
    </script>
    <script type="text/javascript">
    //密码确认验证
        function CPassWordExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/ConfirmPassWordExam",
                data: "{PassWord:'" + $("#tbxPassWord").val() + "',cPassWord:'" + $("#tbxConfirmPassWord").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#ContentPlaceHolder1_labConfirmPassWord").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
        //身份证验证
        function IdCardExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/IdcardExam",
                data: "{Idcard:'" + $("#tbxIdcard").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#ContentPlaceHolder1_labIDCard").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
        //真实姓名验证
        function TrueNameExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/TrueNameExam",
                data: "{Truename:'" + $("#tbxTruename").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#ContentPlaceHolder1_labTrueName").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
        //邮箱验证
        function EmailExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/EmailExam",
                data: "{Email:'" + $("#tbxEmail").val() + "'}",
                datatype: "json",
                success: function (result) {
                    $("#ContentPlaceHolder1_labEmail").html(result.d);
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
        //提交按钮验证
        function ButtonExam() {
            $.ajax({
                type: "POST",
                contentType: "application/json",
                url: "Register.aspx/ButtonExam",
                data: "{UserName:'" + $("#ContentPlaceHolder1_labUserName").html() + "',PassWord:'" + $("#ContentPlaceHolder1_labPassWord").html() + "',cPassWord:'" + $("#ContentPlaceHolder1_labConfirmPassWord").html() + "',Idcard:'" + $("#ContentPlaceHolder1_labIDCard").html() + "',Email:'" + $("#ContentPlaceHolder1_labEmail").html() + "',Truename:'" + $("#ContentPlaceHolder1_labTrueName").html() + "'}",
                datatype: "json",
                success: function (result) {
                    if (result.d == "1") {
                        document.getElementById("btnSubmit").removeAttribute("disabled");
                    }
                    else {
                        document.getElementById("btnSubmit").setAttribute("disabled", true);
                    }
                },
                error: function (aaa) {
                    alert(aaa + "cuole");
                }
            });
        }
    </script>
    <script type="text/javascript">
    //验证码图片
        function show() {
            var a = document.getElementById("image");
            a.src = a.src + "?";
        }
        //提交按钮验证
        function aaa() {
            ButtonExam();
        }      
    </script>
    <style type="text/css">
   
        .modalBackground
        {
            background-color: Grey;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
    </style>
    <center style="margin-top: 50px">
        <%--全局--%>
        <div id="div_Whole" style="text-align: center; height: 550px; border: 1px solid #ed1100;">
            <%--样式 --%>
            <div id="div_topItem" style="height: 30px; background-image: url('../../image/微条.jpg');
                background-repeat: repeat-x; font-size: larger; padding-top: 5px; padding-left: 9px;
                color: White; text-align: left;">
                <strong>注册新用户</strong>
            </div>
            <div id="div_topBlank">
            </div>
            <div id="div_Content" style="margin-top: 30px">
                <%--控件--%>
                <table id="table_Content" cellspacing="10px" style="width: 100%;">
                    <tr>
                        <td align="right" style="width: 40%; padding-right: 30px; font-size: 18pt;">
                            请输入用户名:
                        </td>
                        <td align="left">
                            <div style="float: left">
                                <asp:TextBox runat="server" ID="tbxUserName" Height="24px" Width="202px" BorderColor="Red"
                                    BorderWidth="1px" CausesValidation="True" MaxLength="18" onblur="UserNameExam();"
                                    ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div style="float: left">
                                <asp:Label ID="tiplbUserName" runat="server" ClientIDMode="Static"></asp:Label>
                                <asp:Button ID="btnExamUserName" runat="server" Text="验证用户名" Height="25px" Width="96px"
                                    Style="background-image: url('../../image/微条.jpg'); font-size: 12pt; margin-left: 30px;"
                                    BorderStyle="Solid" BorderColor="Yellow" BorderWidth="1px" OnClick="btnExamUserName_Click" />
                            </div>
                            <div style="float: left">
                                <asp:UpdatePanel runat="server" ID="UpdatePanel" ChildrenAsTriggers="true" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <div style="float: left; padding-left: 5px; padding-top: 5px;">
                                            <asp:Label ID="labUserName" runat="server" Text=""></asp:Label>
                                        </div>
                                        <ajaxtoolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="asd"
                                            PopupControlID="PNL" OkControlID="asd" BackgroundCssClass="modalBackground" CancelControlID ="asd"
                                            X="400" Y="300" DropShadow="true" />
                                        <asp:Panel ID="PNL" runat="server" Style="display: none; width: 400px; height: 70px;
                                            background-color: #feb1b1; border-width: 2px; border-color: Red; border-style: solid;
                                            padding: 20px;">
                                            <asp:Label ID="labReturnInfo" runat="server" Text="123123" Style="font-size: 16pt;" />
                                            <br />
                                            <br />
                                            <div style="text-align: right;">
                                                <asp:Button ID="ButtonOk" runat="server" OnClick="ButtonOk_Click" 
                                                    style=" background-image: url('../../image/标题头微条.jpg')"  Text="确定" 
                                                    BorderColor="Red" BorderStyle="None" BorderWidth="1px" Height="25px" 
                                                    Width="60px" />
                                                <asp:Label ID ="asd" runat ="server" style=" display:none"></asp:Label>
                                            </div>
                                        </asp:Panel>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnExamUserName" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 30px; font-size: 18pt;" class="style3">
                            请输入密码:
                        </td>
                        <td align="left" class="style3">
                            <asp:TextBox runat="server" ID="tbxPassWord" TextMode="Password" Height="24px" Width="202px"
                                BorderColor="Red" BorderWidth="1px" CausesValidation="True" MaxLength="18" onblur="PassWordExam()"
                                ClientIDMode="Static" ></asp:TextBox>
                            <asp:Label ID="labPassWord" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="padding-right: 30px; font-size: 18pt;" class="style4">
                            请再次输入密码:
                        </td>
                        <td align="left" class="style4">
                            <asp:TextBox runat="server" ID="tbxConfirmPassWord" TextMode="Password" Height="24px"
                                Width="202px" BorderColor="Red" BorderWidth="1px" CausesValidation="True" MaxLength="18"
                                ClientIDMode="Static" onblur="CPassWordExam()"  ></asp:TextBox>
                            <asp:Label ID="labConfirmPassWord" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%; padding-right: 30px; font-size: 18pt;">
                            请输入身份证号:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxIdcard" Height="24px" Width="202px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18" onblur="IdCardExam()"
                                ClientIDMode="Static" ></asp:TextBox>
                            <asp:Label ID="labIDCard" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%; padding-right: 30px; font-size: 18pt;">
                            请输入真实姓名:
                        </td>
                        <td align="left" class="style2">
                            <asp:TextBox runat="server" ID="tbxTruename" Height="24px" Width="202px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18" ClientIDMode="Static"
                                onblur="TrueNameExam()" ></asp:TextBox>
                            <asp:Label ID="labTrueName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 40%; padding-right: 30px; font-size: 18pt;">
                            请输入邮箱:
                        </td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="tbxEmail" Height="24px" Width="202px" BorderColor="Red"
                                BorderWidth="1px" CausesValidation="True" MaxLength="18" ClientIDMode="Static"
                                onblur="EmailExam() " ></asp:TextBox>
                            <asp:Label ID="labEmail" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <%--验证码--%>
                    <tr>
                        <td align="right" style="width: 40%; padding-right: 30px; font-size: 18pt;">
                            请输入验证码:
                        </td>
                        <td align="left">
                            <div style="float: left;">
                                <asp:TextBox runat="server" ID="tbxSecutity" Width="50px" Height="24px" BorderColor="Red"
                                    BorderWidth="1px" CausesValidation="True" MaxLength="18" ClientIDMode="Static"
                                    ></asp:TextBox></div>
                            <div style="float: left; padding-left: 5px;">
                                <image id="image" alt="载入中..." width="75px" height="29px" src="../../verification%20code/verification%20code.aspx" />
                            </div>
                            &nbsp;
                            <div style="font-size: 12pt; float: left; padding-top: 6px; padding-left: 4px;">
                                看不清？<a href="javascript:show();" style="font-size: larger;">换一张</a></div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div id="position" style="margin-left: 10%; margin-top: 20px;">
                                <div style="width: 100%; text-align: left; padding-left: 415px;">
                                    <asp:Button runat="server" ID="btnSubmit" Text="同意以下协议，提交" OnClick="btnSubmit_Click"
                                        Height="30px" Width="180px" Style="background-image: url('../../image/微条.jpg');
                                        font-size: 12pt; margin-left: 0px;" BorderStyle="Solid" BorderColor="Yellow"
                                        BorderWidth="1px" ClientIDMode="Static" /></div>
                            </div>
                        </td>
                    </tr>
                </table>
                <br />
                <%--协议--%>
                <div id="div_text" style="width: 400px; height: 71px; overflow: auto; border: 1px solid #ed1100;
                    text-align: center; margin-left: 420px">
                    天外天商城网站用户注册协议
                    <br />
                    第1条 本站服务条款的确认和接纳 1.1本站的各项电子服务的所有权和运作权归天外天商城所有。用户同意所有注册协议条款并完成注册程序，才能成为本站的正式用户。用户确认：本协议条款是处理双方权利义务的契约，始终有效，法律另有强制性规定或双方另有特别约定的，依其规定。
                    1.2用户点击同意本协议的，即视为用户确认自己具有享受本站服务、下单购物等相应的权利能力和行为能力，能够独立承担法律责任。 1.3如果您在18周岁以下，您只能在父母或监护人的监护参与下才能使用本站。
                    1.4天外天商城保留在中华人民共和国大陆地区法施行之法律允许的范围内独自决定拒绝服务、关闭用户账户、清除或编辑内容或取消订单的权利。 第2条 本站服务 2.1天外天商城通过互联网依法为用户提供互联网信息等服务，用户在完全同意本协议及本站规定的情况下，方有权使用本站的相关服务。
                    2.2用户必须自行准备如下设备和承担如下开支：（1）上网设备，包括并不限于电脑或者其他上网终端、调制解调器及其他必备的上网装置；（2）上网开支，包括并不限于网络接入费、上网设备租用费、手机流量费等。
                    第3条 用户信息 3.1用户应自行诚信向本站提供注册资料，用户同意其提供的注册资料真实、准确、完整、合法有效，用户注册资料如有变动的，应及时更新其注册资料。如果用户提供的注册资料不合法、不真实、不准确、不详尽的，用户需承担因此引起的相应责任及后果，并且天外天商城保留终止用户使用天外天商城各项服务的权利。
                    3.2用户在本站进行浏览、下单购物等活动时，涉及用户真实姓名/名称、通信地址、联系电话、电子邮箱等隐私信息的，本站将予以严格保密，除非得到用户的授权或法律另有规定，本站不会向外界披露用户隐私信息。
                    3.3用户注册成功后，将产生用户名和密码等账户信息，您可以根据本站规定改变您的密码。用户应谨慎合理的保存、使用其用户名和密码。用户若发现任何非法使用用户账号或存在安全漏洞的情况，请立即通知本站并向公安机关报案。
                    3.4用户同意，天外天商城拥有通过邮件形式，向在本站注册、购物用户、收货人发送订单信息、促销活动等告知信息的权利。 3.5用户不得将在本站注册获得的账户借给他人使用，否则用户应承担由此产生的全部责任，并与实际使用人承担连带责任。
                    3.6用户同意，天外天商城有权使用用户的注册信息、用户名、密码等信息，登陆进入用户的注册账户，进行证据保全，包括但不限于公证、见证等。 第4条 用户依法言行义务
                    本协议依据国家相关法律法规规章制定，用户同意严格遵守以下义务： （1）不得传输或发表：煽动抗拒、破坏宪法和法律、行政法规实施的言论，煽动颠覆国家政权，推翻社会主义制度的言论，煽动分裂国家、破坏国家统一的的言论，煽动民族仇恨、民族歧视、破坏民族团结的言论；
                    （2）从中国大陆向境外传输资料信息时必须符合中国有关法规； （3）不得利用本站从事洗钱、窃取商业秘密、窃取个人信息等违法犯罪活动； （4）不得干扰本站的正常运转，不得侵入本站及国家计算机信息系统；
                    （5）不得传输或发表任何违法犯罪的、骚扰性的、中伤他人的、辱骂性的、恐吓性的、伤害性的、庸俗的，淫秽的、不文明的等信息资料； （6）不得传输或发表损害国家社会公共利益和涉及国家安全的信息资料或言论；
                    （7）不得教唆他人从事本条所禁止的行为； （8）不得利用在本站注册的账户进行牟利性经营活动； （9）不得发布任何侵犯他人著作权、商标权等知识产权或合法权利的内容；
                    用户应不时关注并遵守本站不时公布或修改的各类合法规则规定。 本站保有删除站内各类不符合法律政策或不真实的信息内容而无须通知用户的权利。 若用户未遵守以上规定的，本站有权作出独立判断并采取暂停或关闭用户帐号等措施。用户须对自己在网上的言论和行为承担法律责任。
                    第5条 商品信息 本站上的商品价格、数量、是否有货等商品信息随时都有可能发生变动，本站不作特别通知。由于网站上商品信息的数量极其庞大，虽然本站会尽最大努力保证您所浏览商品信息的准确性，但由于众所周知的互联网技术因素等客观原因存在，本站网页显示的信息可能会有一定的滞后性或差错，对此情形您知悉并理解；天外天商城欢迎纠错，并会视情况给予纠错者一定的奖励。
                    为表述便利，商品和服务简称为“商品”或“货物”。 第6条 订单 6.1在您下订单时，请您仔细确认所购商品的名称、价格、数量、型号、规格、尺寸、联系地址、电话、收货人等信息。收货人与用户本人不一致的，收货人的行为和意思表示视为用户的行为和意思表示，用户应对收货人的行为及意思表示的法律后果承担连带责任。
                    6.2除法律另有强制性规定外，双方约定如下：本站上销售方展示的商品和价格等信息仅仅是要约邀请，您下单时须填写您希望购买的商品数量、价款及支付方式、收货人、联系方式、收货地址（合同履行地点）、合同履行方式等内容；系统生成的订单信息是计算机信息系统根据您填写的内容自动生成的数据，仅是您向销售方发出的合同要约；销售方收到您的订单信息后，只有在销售方将您在订单中订购的商品从仓库实际直接向您发出时（
                    以商品出库为标志），方视为您与销售方之间就实际直接向您发出的商品建立了合同关系；如果您在一份订单里订购了多种商品并且销售方只给您发出了部分商品时，您与销售方之间仅就实际直接向您发出的商品建立了合同关系；只有在销售方实际直接向您发出了订单中订购的其他商品时，您和销售方之间就订单中该其他已实际直接向您发出的商品才成立合同关系。您可以随时登陆您在本站注册的账户，查询您的订单状态。
                    6.3由于市场变化及各种以合理商业努力难以控制的因素的影响，本站无法保证您提交的订单信息中希望购买的商品都会有货；如您拟购买的商品，发生缺货，您有权取消订单。
                    第7条 配送 7.1销售方将会把商品（货物）送到您所指定的收货地址，所有在本站上列出的送货时间为参考时间，参考时间的计算是根据库存状况、正常的处理过程和送货时间、送货地点的基础上估计得出的。
                    7.2因如下情况造成订单延迟或无法配送等，销售方不承担延迟配送的责任： （1）用户提供的信息错误、地址不详细等原因导致的； （2）货物送达后无人签收，导致无法配送或延迟配送的；
                    （3）情势变更因素导致的； （4）不可抗力因素导致的，例如：自然灾害、交通戒严、突发战争等。 第8条 所有权及知识产权条款 8.1用户一旦接受本协议，即表明该用户主动将其在任何时间段在本站发表的任何形式的信息内容（包括但不限于客户评价、客户咨询、各类话题文章等信息内容）的财产性权利等任何可转让的权利，如著作权财产权（包括并不限于：复制权、发行权、出租权、展览权、表演权、放映权、广播权、信息网络传播权、摄制权、改编权、翻译权、汇编权以及应当由著作权人享有的其他可转让权利），全部独家且不可撤销地转让给天外天商城所有，用户同意天外天商城有权就任何主体侵权而单独提起诉讼。
                    8.2本协议已经构成《中华人民共和国著作权法》第二十五条（条文序号依照2011年版著作权法确定）及相关法律规定的著作财产权等权利转让书面协议，其效力及于用户在天外天商城网站上发布的任何受著作权法保护的作品内容，无论该等内容形成于本协议订立前还是本协议订立后。
                    8.3用户同意并已充分了解本协议的条款，承诺不将已发表于本站的信息，以任何形式发布或授权其它主体以任何方式使用（包括但限于在各类网站、媒体上使用）。 8.4天外天商城是本站的制作者,拥有此网站内容及资源的著作权等合法权利,受国家法律保护,有权不时地对本协议及本站的内容进行修改，并在本站张贴，无须另行通知用户。在法律允许的最大限度范围内，天外天商城对本协议及本站内容拥有解释权。
                    8.5除法律另有强制性规定外，未经天外天商城明确的特别书面许可,任何单位或个人不得以任何方式非法地全部或部分复制、转载、引用、链接、抓取或以其他方式使用本站的信息内容，否则，天外天商城有权追究其法律责任。
                    8.6本站所刊登的资料信息（诸如文字、图表、标识、按钮图标、图像、声音文件片段、数字下载、数据编辑和软件），均是天外天商城或其内容提供者的财产，受中国和国际版权法的保护。本站上所有内容的汇编是天外天商城的排他财产，受中国和国际版权法的保护。本站上所有软件都是天外天商城或其关联公司或其软件供应商的财产，受中国和国际版权法的保护。
                    第9条 责任限制及不承诺担保 除非另有明确的书面说明,本站及其所包含的或以其它方式通过本站提供给您的全部信息、内容、材料、产品（包括软件）和服务，均是在“按现状”和“按现有”的基础上提供的。
                    除非另有明确的书面说明,天外天商城不对本站的运营及其包含在本网站上的信息、内容、材料、产品（包括软件）或服务作任何形式的、明示或默示的声明或担保（根据中华人民共和国法律另有规定的以外）。
                    天外天商城不担保本站所包含的或以其它方式通过本站提供给您的全部信息、内容、材料、产品（包括软件）和服务、其服务器或从本站发出的电子信件、信息没有病毒或其他有害成分。
                    如因不可抗力或其它本站无法控制的原因使本站销售系统崩溃或无法正常使用导致网上交易无法完成或丢失有关的信息、记录等，天外天商城会合理地尽力协助处理善后事宜。 第10条
                    协议更新及用户关注义务 根据国家法律法规变化及网站运营需要，天外天商城有权对本协议条款不时地进行修改，修改后的协议一旦被张贴在本站上即生效，并代替原来的协议。用户可随时登陆查阅最新协议；用户有义务不时关注并阅读最新版的协议及网站公告。如用户不同意更新后的协议，可以且应立即停止接受天外天商城网站依据本协议提供的服务；如用户继续使用本网站提供的服务的，即视为同意更新后的协议。天外天商城建议您在使用本站之前阅读本协议及本站的公告。
                    如果本协议中任何一条被视为废止、无效或因任何理由不可执行，该条应视为可分的且并不影响任何其余条款的有效性和可执行性。 第11条 法律管辖和适用 本协议的订立、执行和解释及争议的解决均应适用在中华人民共和国大陆地区适用之有效法律（但不包括其冲突法规则）。
                    如发生本协议与适用之法律相抵触时，则这些条款将完全按法律规定重新解释，而其它有效条款继续有效。 如缔约方就本协议内容或其执行发生任何争议，双方应尽力友好协商解决；协商不成时，任何一方均可向有管辖权的中华人民共和国大陆地区法院提起诉讼。
                </div>
            </div>
            <div id="div_bottomBlank">
            </div>
        </div>
    </center>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
</asp:Content>
