(function (window) {

    'use strict';

    // class helper
    function classReg(className) {
        return new RegExp("(^|\\s+)" + className + "(\\s+|$)");
    }

    // classList support for class management
    var hasClass, addClass, removeClass;

    if ('classList' in document.documentElement) {
        hasClass = function (elem, c) {
            return elem.classList.contains(c);
        };
        addClass = function (elem, c) {
            elem.classList.add(c);
        };
        removeClass = function (elem, c) {
            elem.classList.remove(c);
        };
    }
    else {
        hasClass = function (elem, c) {
            return classReg(c).test(elem.className);
        };
        addClass = function (elem, c) {
            if (!hasClass(elem, c)) {
                elem.className = elem.className + ' ' + c;
            }
        };
        removeClass = function (elem, c) {
            elem.className = elem.className.replace(classReg(c), ' ');
        };
    }

    function toggleClass(elem, c) {
        var fn = hasClass(elem, c) ? removeClass : addClass;
        fn(elem, c);
    }

    var classie = {
        hasClass: hasClass,
        addClass: addClass,
        removeClass: removeClass,
        toggleClass: toggleClass,
        has: hasClass,
        add: addClass,
        remove: removeClass,
        toggle: toggleClass
    };

    // transport
    if (typeof define === 'function' && define.amd) {
        // AMD
        define(classie);
    } else {
        // browser global
        window.classie = classie;
    }

})(window);


// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function () {
    $('a.page-scroll').bind('click', function (event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function () {
    $('.navbar-toggle:visible').click();
});


var cbpAnimatedHeader = (function () {
    var docElem = document.documentElement,
        header = document.querySelector('.navbar-default'),
        didScroll = false,
        changeHeaderOn = 50;

    function init() {
        window.addEventListener('scroll', function (event) {
            if (!didScroll) {
                didScroll = true;
                setTimeout(scrollPage, 250);
            }
        }, false);
    }

    function scrollPage() {
        var sy = scrollY();
        if (sy >= changeHeaderOn) {
            classie.add(header, 'navbar-shrink');
        }
        else {
            classie.remove(header, 'navbar-shrink');
        }
        didScroll = false;
    }

    function scrollY() {
        return window.pageYOffset || docElem.scrollTop;
    }

    init();

})();


var topNavbar = (function () {
    header = document.querySelector('.navbar-default');
    watchPageChanges();

    function watchPageChanges() {
        var url = getRelativeUrl();
        updateNavbar(url);
    }

    function updateNavbar(url) {
        if (url === "/") {
            classie.remove(header, 'navbar-black');
        } else {
            classie.add(header, 'navbar-black');
        }
    }
})();

function getRelativeUrl() {
    return location.pathname + location.search + location.hash;
}
