<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductShow.aspx.cs" Inherits="HitachiStore.formerstage.GoodDisplay.ProductShow"
    MasterPageFile="~/formerstage/stage_Master/FirstMa.Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>天外天商城首页</title>
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <%--图片自动更换--%>
    <script type="text/javascript">
        var imgIndex = 0;
        var timeInterval = 1000;   //单位毫秒
        var arrImg = new Array();
        arrImg[0] = "../../image/aaa1.jpg";
        arrImg[1] = "../../image/b002.jpg";
        arrImg[2] = "../../image/b003.jpg";
        arrImg[3] = "../../image/b004.jpg";
        arrImg[4] = "../../image/b001.jpg";
        //setInterval(changing1, timeInterval);
        function changing() {
            var mId = document.getElementById("itemPhoto");
            if (imgIndex == arrImg.length - 1) {
                imgIndex = 0;
            }
            else {
                imgIndex += 1;
            }
            //纵向，默认，移动间隔2
            //$('div.albumSlider').albumSlider();
            //横向设置
            //$('div.albumSlider-h').albumSlider({ direction: 'h', step: 3 });
            //$('#itemPhoto').css({backgroundImage:"url:("+ arrImg[imgIndex]}+")");
            //mId.style.backgroundImage.hasOwnProperty = arrImg[imgIndex];
        }
    </script>
    <%--图片展示实现函数--%>
    <script type="text/javascript">
        (function ($) {
            $.fn.albumSlider = function (j) {
                return this.each(function () {
                    var b = $.extend({
                        step: 2,
                        imgContainer: 'div.fullview',
                        listContainer: 'ul.imglist',
                        event: 'mouseover',
                        direction: 'v'
                    }, j || {});
                    var c = $(b.imgContainer, this),
                        $list = $(b.listContainer, this),
                        currId = 0,
                        currPage = 0,
                        size = $list.children().length - 1,
                        pageSize = Math.floor(size / b.step);
                    var f = b.direction == 'v';
                    var g = f ? 'top' : 'left';
                    var h = (size >= b.step) ? $('li', $list).eq(b.step).offset()[g] - $('li', $list).eq(0).offset()[g] : 0;
                    var i = function () {
                        var a = $(this);
                        if (a.is('.current')) { return false } $('img', c).fadeOut(800, function () { $(this).remove() });
                        $('<img>').hide().attr('src', $('a', a).attr('href')).appendTo(c).fadeIn(800);
                        a.addClass('current').siblings().removeClass('current');
                        return false
                    };
                    $.proxy(i, $('li', $list).eq(0))();
                    $list.delegate('li', b.event, $.proxy(i)).bind('moveforward movebackward', function (e) {
                        var a = e.type == 'moveforward';
                        if (a) {
                            currId += b.step;
                            if (currId > size) { currId = size }
                            if (++currPage > pageSize) {
                                currPage = pageSize;
                                return false
                            }
                        }
                        else {
                            currId -= b.step;
                            if (currId < 0) { currId = 0 }
                            if (--currPage < 0) {
                                currPage = 0;
                                return false
                            }
                        };
                        var d = (a ? '-=' : '+=') + h;
                        $(this).stop(true, true).animate(f ? { top: d} : { left: d }, 500, function () {
                            $.proxy(i, $('li', $list).eq(currId))()
                        })
                    });
                    $('div.button', this).click(function () { $list.trigger($(this).is('.moveforward') ? 'moveforward' : 'movebackward') })
                })
            }
        })(jQuery);
    </script>
    <%--右侧样式设计--%>
    <style type="text/css">
        .div
        {
            background: #fff;
            font-family: "Lucida Grande" , Helvetica, Arial, sans-serif;
            font-size: 12px;
        }
        
        #info
        {
            font-family: font-family: "trebuchet ms" , trebuchet, arial, sans-serif;
            font-size: 1em;
        }
        #menu
        {
            margin: 0;
            padding: 0;
            height: 32.5em;
            overflow: hidden;
            background: RGB(255,150,150);
        }
        #menu li
        {
            list-style-type: none;
            float: left;
            display: block;
            width: 100%;
        }
        #menu li a
        {
            display: block;
            text-decoration: none;
            color: RGB(255,150,150);
            margin: 0;
            width: 100%;
        }
        #menu li a span
        {
            display: none;
            color: #000;
        }
        #menu li a.one span
        {
            display: block;
            height: 15em;
            margin: 0 10px;
        }
        #menu li a:hover
        {
            background: RGB(255,155,155);
        }
        #menu li a:hover span
        {
            display: block;
            height: 15em;
            margin: 0 10px;
            cursor: pointer;
        }
        #menu .h2
        {
            margin: 0 5px;
            padding: 0;
            color: RGB(255,255,255);
            font-variant: small-caps;
            font-size: 1.5em;
            border: 0;
        }
        #menu .h3
        {
            margin: 0 5px;
            padding: 0;
            font-size: 1.1em;
            color: RGB(0,0,0);
        }
        #menu img
        {
            margin: 5px 5px 5px 0;
            border: 1px solid #ed1100;
            float: left;
            width: 110px;
            height: 110px;
        }
        .curved
        {
            width: 21em;
            margin: 0 auto;
        }
        .curved .b1, .curved .b2, .curved .b3, .curved .b4
        {
            font-size: 1px;
            display: block;
            background: #ed1100;
            overflow: hidden;
        }
        .curved .b1, .curved .b2, .curved .b3
        {
            height: 1px;
        }
        .curved .b2, .curved .b3, .curved .b4
        {
            background: RGB(255,155,155);
            border-left: 1px solid #ed1100;
            border-right: 1px solid #ed1100;
        }
        .curved .b1
        {
            margin: 0 4px;
            background: #ed1100;
        }
        .curved .b2
        {
            margin: 0 2px;
            border-width: 0 2px;
        }
        .curved .b3
        {
            margin: 0 1px;
        }
        .curved .b4
        {
            height: 2px;
            margin: 0;
        }
        .curved .c1
        {
            margin: 0 5px;
            background: #ed1100;
        }
        .curved .c2
        {
            margin: 0 3px;
            border-width: 0 2px;
        }
        .curved .c3
        {
            margin: 0 2px;
        }
        .curved .c4
        {
            height: 2px;
            margin: 0 1px;
        }
        .curved .boxcontent
        {
            display: block;
            background: transparent;
            border-left: 1px solid #ed1100;
            border-right: 1px solid #ed1100;
            font-size: 0.9em;
            text-align: justify;
        }
    </style>
    <%--左侧样式设计--%>
    <style type="text/css">
        h1, p
        {
            text-align: center;
        }
        *
        {
            margin: 0;
            padding: 0;
        }
        li
        {
            list-style: none;
        }
        img
        {
            border: none;
        }
        /*横向布局*/
        .albumSlider-h
        {
            background: RGB(255,150,150);
            margin: 10px auto;
            padding: 0px;
            font-size: 10px;
            position: relative;
            float: left;
            top: 0px;
            left: 0px;
        }
        .albumSlider-h .fullview
        {
            height: 365px;
            position: relative;
        }
        .albumSlider-h .fullview, .albumSlider-h .fullview img
        {
            width: 750px;
            height: 365px;
        }
        .albumSlider-h .fullview img
        {
            position: absolute;
            top: 0;
            left: 0;
        }
        .albumSlider-h .button, .albumSlider-h .imglistwrap
        {
            float: left;
            display: inline;
        }
        .albumSlider-h .slider
        {
            width: 747px;
            height: 20px;
            margin-top: 3px;
            background: RGB(255,150,150);
            padding-left: 3px;
        }
        .albumSlider-h .imglistwrap
        {
            height: 20px;
            width: 105px;
            overflow: hidden;
            position: relative;
            margin-right: 5px;
            margin-bottom: 1px;
            margin-top: 1px;
            float: right;
        }
        .albumSlider-h .imglist
        {
            position: relative;
            width: 999em;
            top: 0px;
            left: 0px;
        }
        .albumSlider-h li
        {
            float: left;
            margin: 0 3px;
        }
        .albumSlider-h li img
        {
            width: 15px;
            height: 18px;
            margin: 0px 0 0 0px;
            border: 1px solid RGB(255,150,150);
        }
        .albumSlider-h a
        {
            width: 15px;
            height: 18px;
            display: block;
            outline: none;
        }
        .albumSlider-h li a:hover, .albumSlider-h li.current a
        {
        }
        .albumSlider-h .button
        {
            height: 76px;
            width: 16px;
            margin: 0 5px;
            cursor: pointer;
        }
        .albumSlider-h .movebackward
        {
            background-position: 0 50%;
        }
        .button
        {
            background-image: url(../../image/标题头微条.jpg);
            height: 25px;
            width: 70px;
            border: 1px solid #ffcc00;
            forecolor: white;
            color: White;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            //纵向，默认，移动间隔2
            $('div.albumSlider').albumSlider();
            //横向设置
            $('div.albumSlider-h').albumSlider({ direction: 'h', step: 3 });
        });
    </script>
    <%--总体布局--%>
    <div style="width: 100%; height: 400px; padding-left: 10px;">
        <%--左侧商品--%>
        <table>
            <tr>
                <td>
                    <div class="albumSlider" style="float: left; margin-left: 5px;">
                        <div class="clearfix albumSlider-h" style="float: left;">
                            <%--商品图片--%>
                            <a  id="a6" style="width: 750px; height: 300px">
                                <div class="fullview" id="itemPhoto" style="top: 0px; left: 0px;">
                                    <%--<img id="img6" src="#" alt="" width="750" height="300" runat="server" />--%>
                                </div>
                            </a>
                            <%--图片页码--%>
                            <div class="slider" style="margin-top: 38px">
                                <div class="imglistwrap">
                                    <ul class="imglist">
                                        <li><a id="a1"  runat="server">
                                            <img id="img1" src="../../image/1.png" alt="" width="18px" /></a></li>
                                        <li><a id="a2"  runat="server">
                                            <img id="img2" src="../../image/2.png" alt="" width="18px" /></a></li>
                                        <li><a id="a3"  runat="server">
                                            <img id="img3" src="../../image/3.png" alt="" width="18px" /></a></li>
                                        <li><a id="a4" runat="server">
                                            <img id="img4" src="../../image/4.png" alt="" width="18px" /></a></li>
                                        <li><a id="a5" runat="server">
                                            <img id="img5" src="../../image/5.png" alt="" width="18px" /></a></li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </td>
                <td>
                    <%--右侧商品--%>
                    <div class="div" style="float: left; margin-top: 10px; margin-left: 20px;">
                        <div class="curved" style="float: left">
                            <b class="b1 c1"></b><b class="b2 c2"></b><b class="b3 c3"></b><b class="b4 c4">
                            </b>
                            <div class="boxcontent">
                                <ul id="menu">
                                    <li><a class="m5 five" href="#nogo"><b class="h2">手机</b><br />
                                        <b class="h3">iPhone</b> <span>
                                            <img src="../../GoodImg/Iphone4S1.jpg" alt="painting" title="painting" />
                                            iPhone 4S是苹果公司推出的一款触摸屏智能手机，取代iPhone 4成为iPhone的第五代产品，2011年4月，在美国加利福尼亚州举行的Let's talk
                                            iPhone的新品发布会上，苹果发布了这款运行iOS 5系统的新一代iPhone手机。 </span></a></li>
                                    <li><a href="#nogo"><b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4">
                                    </b><b class="h2">手机</b><br />
                                        <b class="h3">摩托罗拉</b> <span>
                                            <img src="../../GoodImg/摩托罗拉XT390.jpg" alt="painting" title="painting" />
                                        </span></a></li>
                                    <li><a href="#nogo"><b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4">
                                    </b><b class="h2">手机</b><br />
                                        <b class="h3">三星</b> <span>
                                            <img src="../../GoodImg/三星I9103.jpg" alt="painting" title="painting" />
                                        </span></a></li>
                                    <li><a href="#nogo"><b class="b1"></b><b class="b2"></b><b class="b3"></b><b class="b4">
                                    </b><b class="h2">手机</b><br />
                                        <b class="h3">三星</b> <span>
                                            <img src="../../GoodImg/三星I9300.jpg" alt="painting" title="painting" />
                                        </span></a></li>
                                    <li><a class="one" href="#nogo"><b class="b1"></b><b class="b2"></b><b class="b3"></b>
                                        <b class="b4"></b><b class="h2">手机</b><br />
                                        <b class="h3">(1840-1926)</b> <span>
                                            <img src="../../GoodImg/摩托罗拉XT390.jpg" alt="painting" title="painting" />
                                        </span></a></li>
                                </ul>
                            </div>
                            <b class="b4 c4"></b><b class="b3 c3"></b><b class="b2 c2"></b><b class="b1 c1">
                            </b>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    <%--下侧商品展示--%>
    <div style="width: 100%; height: 380px;">
        <asp:DataList runat="server" ID="dlistProductShow" Width="100%" RepeatColumns="4"
            RepeatDirection="Horizontal">
            <ItemTemplate>
                <div style="width: 100%; height: 30px; background-image: url('../../image/微条.jpg');">
                </div>
                <div style="width: 100%; height: 280px; border: 1px solid #ed1100">
                    <a href="../SaleOrders/SingleGood.aspx?ImageAddress=<%#Eval("ImgAddress") %>">
                        <img runat="server" id="imgShow" width="240" height="270" style="border: none" src='<%#Eval("ImgAddress") %>' />
                    </a>
                </div>
                <div style="height: 70px; width: 100%; border: 1px solid red">
                    <div style="height: 40px">
                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("ImgTitle") %>'></asp:Label>
                    </div>
                    <div style="float: left; width: 49%; height: 30px; border-right: 1px solid red; border-top: 1px solid red">
                        价格:<%#Eval("Property") %></div>
                    <div style="float: right; width: 50%; height: 30px; border-top: 1px solid red">
                        <div style="margin-top: 5px">
                            <a class="button" href="../SaleOrders/SingleGood.aspx?ImageAddress=<%#Eval("ImgAddress") %>">
                                立即购买</a>
                        </div>
                    </div>
                </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style=" height:100%">
        
    </div>
</asp:Content>
