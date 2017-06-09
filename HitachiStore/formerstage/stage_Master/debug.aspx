<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductShow.aspx.cs" Inherits="HitachiStore.formerstage.GoodDisplay.ProductShow"
    MasterPageFile="~/formerstage/stage_Master/FirstMa.Master" %>

<asp:Content ID="content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <%--实现函数--%>
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
                    },
    j || {}); var c = $(b.imgContainer,
    this),
    $list = $(b.listContainer, this),
    currId = 0,
    currPage = 0,
    size = $list.children().length - 1,
    pageSize = Math.floor(size / b.step); var f = b.direction == 'v'; var g = f ? 'top' : 'left';
                    var h = (size >= b.step) ? $('li', $list).eq(b.step).offset()[g] - $('li', $list).eq(0).offset()[g] : 0;
                    var i = function () {
                        var a = $(this); if (a.is('.current')) { return false } $('img', c).fadeOut(800, function ()
                        { $(this).remove() }); $('<img>').hide().attr('src', $('a', a).attr('href')).appendTo(c).fadeIn(800); a.addClass('current').siblings().removeClass('current');
                        return false
                    };
                    $.proxy(i, $('li', $list).eq(0))();
                    $list.delegate('li', b.event, $.proxy(i)).bind('moveforward movebackward', function (e) {
                        var a = e.type == 'moveforward'; if (a) {
                            currId += b.step; if (currId > size) { currId = size }
                            if (++currPage > pageSize)
                            { currPage = pageSize; return false }
                        }
                        else {
                            currId -= b.step;
                            if (currId < 0) { currId = 0 }
                            if (--currPage < 0) { currPage = 0; return false }
                        };
                        var d = (a ? '-=' : '+=') + h;
                        $(this).stop(true, true).animate(f ? { top: d} : { left: d }, 500, function ()
                        { $.proxy(i, $('li', $list).eq(currId))() })
                    }); $('div.button', this).click(function ()
                    { $list.trigger($(this).is('.moveforward') ? 'moveforward' : 'movebackward') })
                })
            }
        })(jQuery);
    </script>
    <%--样式设计--%>
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
            width: 570px;
            background: RGB(255,150,150);
            margin: 10px auto;
            padding: 10px;
            font-size: 10px;
            position:relative;
            float:left;
        }
        .albumSlider-h .fullview
        {
            position: relative;
        }
        .albumSlider-h .fullview, .albumSlider-h .fullview img
        {
            width: 570px;
            height: 300px;
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
            width: auto;
            height: 76px;
            margin-top: 1em;
            background: #fff;
            padding-left: 3px;
        }
        .albumSlider-h .imglistwrap
        {
            height: 69px;
            width: 510px;
            overflow: hidden;
            position: relative;
        }
        .albumSlider-h .imglist
        {
            position: relative;
            width: 999em;
        }
        .albumSlider-h li
        {
            float: left;
            margin: 0 3px;
        }
        .albumSlider-h li img
        {
            width: 90px;
            height: 56px;
            margin: 9px 0 0 2px;
            border: 1px solid RGB(255,150,150);
        }
        .albumSlider-h a
        {
            width: 96px;
            height: 69px;
            display: block;
            outline: none;
        }
        .albumSlider-h li a:hover, .albumSlider-h li.current a
        {
            background: url(../../image/album-slider-arrow-h.png) no-repeat 0 0;
        }
        .albumSlider-h .button
        {
            height: 76px;
            width: 16px;
            margin: 0 5px;
            background: url(../../image/album-slider-button-h.png) no-repeat 100% 50%;
            cursor: pointer;
        }
        .albumSlider-h .movebackward
        {
            background-position: 0 50%;
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
    <div style="width: 100%; height: 400px; padding-left:10px;">
        <div class="albumSlider">
            <div class="clearfix albumSlider-h">
                <%--商品图片--%>
                <div class="fullview" style="background-image:url(../../image/b001.jpg)">
                    <%--<img src="../../image/b001.jpg" alt="" />--%>
                    <%--图片页码--%>
                </div>
                <div class="slider">
                    <div class="button movebackward" title="向左滚动">
                    </div>
                    <div class="imglistwrap">
                        <ul class="imglist">
                            <li><a href="../../image/b001.jpg">
                                <img src="../../image/001.jpg" alt="" /></a></li>
                            <li><a href="../../image/b002.jpg">
                                <img src="../../image/002.jpg" alt="" /></a></li>
                            <li><a href="../../image/b003.jpg">
                                <img src="../../image/003.jpg" alt="" /></a></li>
                            <li><a href="../../image/b004.jpg">
                                <img src="../../image/004.jpg" alt="" /></a></li>
                            <li><a href="../../image/b001.jpg">
                                <img src="../../image/001.jpg" alt="" /></a></li>
                            <li><a href="../../image/b002.jpg">
                                <img src="../../image/002.jpg" alt="" /></a></li>
                            <li><a href="../../image/b003.jpg">
                                <img src="../../image/003.jpg" alt="" /></a></li>
                            <li><a href="../../image/b004.jpg">
                                <img src="../../image/004.jpg" alt="" /></a></li>
                            <li><a href="../../image/b001.jpg">
                                <img src="../../image/001.jpg" alt="" /></a></li>
                            <li><a href="../../image/b002.jpg">
                                <img src="../../image/002.jpg" alt="" /></a></li>
                            <li><a href="../../image/b003.jpg">
                                <img src="../../image/003.jpg" alt="" /></a></li>
                        </ul>
                    </div>
                    <div class="button moveforward" title="向右滚动">
                    </div>
                </div>
            </div>
        </div>
        
    </div>
</asp:Content>
<asp:Content ID="content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="background-image: url(../../image/左侧树背景2.png); height: 600px;">
        <div id="div_head" style="width: 100%; height: 25px; background-image: url('../../image/标题头微条.jpg');
            font-size: 90%; padding-top: 5px;">
            各种品牌
        </div>
    </div>

</asp:Content>
