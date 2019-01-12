/* 
*作者：一些事情
*时间：2012-6-28
*需要结合jquery一起使用
----------------------------------------------------------*/
var timer = null;
var offset = 5000;
var currIndex = 0;
var liStep = 74; //LI宽度
var liSpacing = 10; //LI间隔
var moveTime = 300; //移动速度,毫秒
var imgCount = 0; //图片数量
var imgWidth = 0; //图片总长度
var scrollWidth = 0; //滚动区域宽量

//大图交替轮换
function slideImage(i){
	$("#pic_show img").hide();
	$('#pic_box').height($("#pic_show img").eq(i-1).height());
	$("#pic_show img").eq(i-1).animate({opacity: 'show'}, 800);
}
//bind thumb a
function hookThumb(){    
    $('#pic_scroll ul li a').bind('click', function(){
		if (timer) {
			clearTimeout(timer);
		}                
		currIndex = $('#pic_scroll ul li').index($(this).parent()) + 1;
		rechange(currIndex);
		slideImage(currIndex); 
		timer = window.setTimeout(slidePlay, offset);  
		this.blur();            
		return false;
	});
}
//缩略图左右按钮绑定事件
function smallBtnSlide(){
	$('.scroll_box .small_prev').bind('click', function(){
		if (timer){
			clearTimeout(timer);
		}
		currIndex--;
		if (currIndex < 1) currIndex = imgCount;
		rechange(currIndex);
		slideImage(currIndex);
		moveScroll(currIndex);
		timer = window.setTimeout(slidePlay, offset);
	});
	$('.scroll_box .small_next').bind('click', function(){
		if (timer){
			clearTimeout(timer);
		}
		currIndex++;
		if (currIndex > imgCount) currIndex = 1;
		rechange(currIndex);
		slideImage(currIndex);
		moveScroll(currIndex);
		timer = window.setTimeout(slidePlay, offset);
	});
}
//按钮绑定事件
function btnSlide(){
	$('.slide_box .big_prev,.scroll_box .small_prev').bind('click', function(){
		if (timer){
			clearTimeout(timer);
		}
		currIndex--;
		if (currIndex < 1) currIndex = imgCount;
		rechange(currIndex);
		slideImage(currIndex);
		moveScroll(currIndex);
		timer = window.setTimeout(slidePlay, offset);
	});
	$('.slide_box .big_next,.scroll_box .small_next').bind('click', function(){
		if (timer){
			clearTimeout(timer);
		}
		currIndex++;
		if (currIndex > imgCount) currIndex = 1;
		rechange(currIndex);
		slideImage(currIndex);
		moveScroll(currIndex);
		timer = window.setTimeout(slidePlay, offset);
	});
}
//移动缩络图
function moveScroll(i){
	var currWidth = i * liStep - liSpacing;
	var moveWidth = 0;
	//如果当前长度大于scrollWidth则移动
	if(currWidth > scrollWidth){
		moveWidth = scrollWidth - currWidth;
	}
	$('#pic_scroll ul').animate({left: moveWidth + 'px'}, moveTime);
}
//缩略图选中
function rechange(i){
    $('#pic_scroll ul li a.current').removeClass('current');
    $('#pic_scroll ul li a').eq(i-1).addClass('current');
}
function slidePlay(){
    currIndex++;
	if(currIndex > imgCount){
		currIndex = 1;
	}else if(currIndex < 1){
		currIndex = imgCount;
	}
	moveScroll(currIndex);
    rechange(currIndex);
    slideImage(currIndex);
    timer = window.setTimeout(slidePlay, offset);
}
//创建大图
function createImage(){
	$("#pic_scroll ul li img").each(function(i){
		var imgsrc = $(this).attr("bimg");
		$("#pic_show").append('<img src="' + imgsrc + '" />');
	});
	imgCount = $('#pic_show img').length;
	imgWidth = (imgCount) * liStep - liSpacing;
	scrollWidth = $("#pic_scroll").width();
	//加载完成时获得宽度
	$("#pic_show img").eq(0).load(function(){
		$('#pic_box').height($(this).height());
	});
	slidePlay();
}
$(function(){
	createImage();
    hookThumb();
	btnSlide();
    
});