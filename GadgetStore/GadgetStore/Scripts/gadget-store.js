// jQuery to collapse the navbar on scroll
$(window).scroll(function() {
    if ($(".navbar").offset().top > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
});

// jQuery for page scrolling feature
$(function() {
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

var topNavbar = (function () {
    watchPageChanges();

    function watchPageChanges() {
        var url = getRelativeUrl();
        updateNavbar(url);
    }

    function updateNavbar(url) {
        if (url === "/") {
            $(".navbar-default").removeClass("navbar-black");
        } else {
            $(".navbar-default").addClass("navbar-black");
        }
    }
})();

function getRelativeUrl() {
    return location.pathname + location.search + location.hash;
}
