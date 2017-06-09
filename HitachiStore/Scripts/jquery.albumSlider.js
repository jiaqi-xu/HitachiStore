/*
* date 2010-3-31
* by ambar
*/
(function($){
	$.fn.albumSlider = function(opt){
		return this.each(function(){
			var cfg = $.extend({
							   //一次移动几张图片距离
							   step: 2,
							   //大图容器
							   imgContainer: 'div.fullview',
							   //缩略图列表容器
							   listContainer: 'ul.imglist',
							   //触发事件,'click mouseenter'
							   event: 'mouseover',
							   //横向为‘h’，纵向为‘v’
							   direction: 'v'
							   },opt || {} );
			
			var $fv = $(cfg.imgContainer, this),
				$list = $(cfg.listContainer, this),
				//当前显示序号
				currId = 0,
				//当前分页号，本地分页
				currPage = 0,	
				//列表总数，以0为索引
				size = $list.children().length - 1,	
				//页面大小，本地分页，以移动间隔距离为每页大小
				pageSize = Math.floor( size / cfg.step );
			var isVertical = cfg.direction == 'v';
			//用偏移获取每次移动的距离
			var offsetType = isVertical ? 'top' : 'left';
			var stepDistance = ( size >= cfg.step ) 
				? $('li',$list).eq(cfg.step).offset()[offsetType] - $('li',$list).eq(0).offset()[offsetType]
				: 0;
				
			//proxy,显示上下文对象
			var display = function(){
				var $li = $(this);
				if( $li.is('.current') ){
					return false;
				}
				$('img',$fv).fadeOut(800,function(){$(this).remove();});
				$('<img>').hide()
					.attr('src',$('a',$li).attr('href'))
					.appendTo($fv)
					.fadeIn(800);
				$li.addClass('current').siblings().removeClass('current');
				return false;
			};
			
			//初始化后激活第一个
			$.proxy(display,$('li', $list).eq(0))();
			
			$list
				.delegate('li',cfg.event,$.proxy(display))
				.bind('moveforward movebackward',function(e){
					var isForward = e.type == 'moveforward';
					
					if( isForward ){
						currId += cfg.step;
						if( currId > size ){
							currId = size;
						}						
						//if(size - currPage * cfg.step < cfg.step )  return false;
						if( ++currPage > pageSize ){
							currPage = pageSize;
							return false;
						}
					}
					else{//movebackward
						currId -= cfg.step;
						if( currId < 0 ) {
							currId = 0;
						}
						if( --currPage < 0 ){
							currPage = 0;
							return false;
						}				
					};
					
					var d  = (isForward ?'-=':'+=' ) + stepDistance;
					
					$(this).stop(true,true).animate(
								isVertical ? { top : d } : { left : d }
								,500
								,function(){
									   $.proxy(display,$('li', $list).eq(currId))();
								   });
				});
			
			$('div.button',this).click(function(){
										   $list.trigger($(this).is('.moveforward') ? 'moveforward' : 'movebackward');
										   });
		});
	};
})(jQuery);