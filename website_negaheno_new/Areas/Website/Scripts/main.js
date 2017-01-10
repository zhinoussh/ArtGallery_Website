$(document).ready(function() {


    var current_page_URL = location.href;
    $( "a" ).each(function() {
        if ($(this).attr("href") !== "#") {
            var target_URL = $(this).prop("href");
            if (target_URL == current_page_URL) {
                $('nav a').parents('li, ul').removeClass('active');
                $(this).parent('li').addClass('active');
                return false;
            }
        }
    });

	//#main-slider
	$(function(){
		$('#main-slider.carousel').carousel({
			interval: 5000
		});
	});


	//Initiat WOW JS
	new WOW().init();


	//Pretty Photo
	$("a[rel^='prettyPhoto']").prettyPhoto({
		social_tools: false
	});	
});