$(document).ready(function() {

    //photo slider inside gallery details
    $('#GalleryCarousel').carousel({
        interval: 5000
    });

    //Handles the carousel thumbnails
    $('[id^=carousel-selector-]').click(function () {
        var id = this.id.substr(this.id.lastIndexOf("-") + 1);
        var id = parseInt(id);
        $('#GalleryCarousel').carousel(id);
    });

   
    $('#accordion').on('hidden.bs.collapse', toggleChevron);
    $('#accordion').on('shown.bs.collapse', toggleChevron);


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

//change open and close accordion panel styles
function toggleChevron(e) {

    $(e.target)
        .prev('.panel-heading')
        .find("i.indicator")
        .toggleClass('glyphicon-chevron-up glyphicon-chevron-down');

    if ($(e.target).is(":visible"))
        $(e.target).parent().removeClass("panel-default").addClass("panel-danger");
    else
        $(e.target).parent().removeClass("panel-danger").addClass("panel-default");
}
