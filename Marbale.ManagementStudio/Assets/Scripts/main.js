function IsmenuCollapsedSet() {
	//open ==collapsed
	if ($('body').hasClass("open")) {
		sessionStorage.MenuCollapsed = "true";
	}
	else {
		sessionStorage.MenuCollapsed = "false";
	}
}
 
function ExpandMenus() {
	 
	//console.log("Action name" + $("#acname").val());
	//console.log("Controller name" + $("#cntname").val());
	var contName = $("#cntname").val();
	var acName = $("#acname").val();

	$("#main-menu").find("li.dropdown").each(function (i, ele) {
		//console.log("loop   dropdown " + i);
		 
			 
		$(this).find(".dropdown-menu").find("li").each(function (i, ele) {
			 //console.log("loop   li  " + i);

			if ($(this).find("a").attr("href").indexOf(acName) >= 0
				&& $(this).find("a").attr("href").indexOf(contName) >= 0)
			{
				//	console.log("Found  Action");
					$(this).addClass("active");
					$(this).closest(".dropdown").find("a:first-child").trigger("click")
				}
			});

			 
		 
	});


	//$("#main-menu").find("li.dropdown").each(function (i, ele) {
	//	console.log("loop   dropdown " +i);
	//	if ($(this).find("a:first-child").text().trim().indexOf(contName) >= 0) {
	//		console.log("Found  Controller");
	//		$(this).find("a:first-child").trigger("click");
	//		$(this).find(".dropdown-menu").find("li").each(function (i, ele) {
	//			if ($(this).find("a").attr("href").indexOf(acName) > 0 && $(this).find("a").attr("href").indexOf(contName) > 0) {
	//				console.log("Found  Action");
	//				$(this).addClass("active");
	//			}
	//		});

	//		return false; // breaks
 //       }
	//});
}

$(document).ready(function () {
	IsmenuCollapsedSet();
	ExpandMenus();
	// Menu Trigger
	$('#menuToggle').on('click', function (event) {
		console.log("menutoggle")
		var windowWidth = $(window).width();
		if (windowWidth < 1010) {
			$('body').removeClass('open');
			if (windowWidth < 760) {
				$('#left-panel').slideToggle();
			} else {
				$('#left-panel').toggleClass('open-menu');
			}
		} else {
			$('body').toggleClass('open');
			$('#left-panel').removeClass('open-menu');
		}
		IsmenuCollapsedSet();
		
	});

	


	$(".nav .menu-item-has-children.dropdown").each(function () {
		$(this).on('click', function () {
			var $temp_text = $(this).children('.dropdown-toggle').html();
			$(this).find('.sub-menu').find(".subtitle").empty();

			$(this).children('.sub-menu').prepend('<li class="subtitle">' + $temp_text + '</li>');
		});
	});
	$('#sidebarCollapse').on('click', function () {

		$('#sidebar').addClass('active');
		$('.overlay').addClass('active');
		$('.collapse.in').toggleClass('in');
		$('a[aria-expanded=true]').attr('aria-expanded', 'false');
		SetSideMenu(true);
	});
	
	$('.header-menu .dropdown-toggle').on('click', function () {


		if ($(this).closest(".dropdown").find(".dropdown-menu").hasClass("show")) {
			$(".header-menu").find(".dropdown-menu").removeClass("show");
		}
		else {
			$(".header-menu").find(".dropdown-menu").removeClass("show");
			$(this).closest(".dropdown").find(".dropdown-menu").addClass("show");
		}


	});
	// Load Resize 
	$(window).on("load resize", function (event) {
		var windowWidth = $(window).width();
		if (windowWidth < 1010) {
			$('body').addClass('small-device');
		} else {
			$('body').removeClass('small-device');
		}

	});
	$(document).ajaxStart(function () {
		$("#cover-spin").css("display", "block");
	});

	$(document).ajaxComplete(function () {
		$("#cover-spin").css("display", "none");
	});
});


//$(document).ready(function () {

//	"use strict";

//	[].slice.call(document.querySelectorAll('select.cs-select')).forEach(function (el) {
//		new SelectFx(el);
//	});

//	jQuery('.selectpicker').selectpicker;




//	$('.search-trigger').on('click', function (event) {
//		event.preventDefault();
//		event.stopPropagation();
//		$('.search-trigger').parent('.header-left').addClass('open');
//	});

//	$('.search-close').on('click', function (event) {
//		event.preventDefault();
//		event.stopPropagation();
//		$('.search-trigger').parent('.header-left').removeClass('open');
//	});

//	$('.equal-height').matchHeight({
//		property: 'max-height'
//	});

//	// var chartsheight = $('.flotRealtime2').height();
//	// $('.traffic-chart').css('height', chartsheight-122);


//	// Counter Number
//	$('.count').each(function () {
//		$(this).prop('Counter', 0).animate({
//			Counter: $(this).text()
//		}, {
//			duration: 3000,
//			easing: 'swing',
//			step: function (now) {
//				$(this).text(Math.ceil(now));
//			}
//		});
//	});




//});
