(function ($) {
  "use strict";

  $('.tab-link').click( function() {
	
    var tabID = $(this).attr('data-tab');
    
    $(this).addClass('active').siblings().removeClass('active');
    
    $('#tab-'+tabID).addClass('active').siblings().removeClass('active');
  });

  /* ========================== 
  Select2 Init 
  ==========================*/
  $(document).ready(function () {
    $('.destination-select').select2();
  });

   /***********
   Preloder js
   ************/
  jQuery(window).on('load', function () {
    $(".preloader").delay(1600).fadeOut("slow");
  });

  /* ========================== 
   Daterange Init
   ==========================*/
  $('input[name="daterange"]').daterangepicker({
    opens: 'left'
  }, function (start, end, label) {
    console.log("A new date selection was made: " + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD'));
  });

  $('input[name="booking"]').daterangepicker({
    singleDatePicker: true,
    // showDropdowns: true,
    // minYear: 2000,
    // maxYear: parseInt(moment().format('YYYY'),10)
  });

/* ========================== 
   Accordion Js
   ==========================*/
  $('.toggle').click(function(e) {
  	e.preventDefault();
  
    let $this = $(this);
  
    if ($this.next().hasClass('show')) {
        $this.next().removeClass('show');
        $this.next().slideUp(350);
    } else {
        $this.parent().parent().find('.single__accordion .inner').removeClass('show');
        $this.parent().parent().find('.single__accordion .inner').slideUp(350);
        $this.next().toggleClass('show');
        $this.next().slideToggle(350);
    }
});


/* ========================== 
    Sticky Header
   ==========================*/
   $(window).scroll(function () {
    var scroll = $(window).scrollTop();
    if (scroll >= 20) {
      $(".header-style").addClass("sticky");
    } else {
      $(".header-style").removeClass("sticky");
    }
  });

/* ========================== 
   Jarallax Js
   ==========================*/
jarallax(document.querySelectorAll(".jarallax"));


/* ========================== 
   WOW JS
   ==========================*/
function wowAnimation(){
  new WOW({
    offset:100,
    animateClass:"animated",
    mobile:true,
  }).init();
}

jQuery(window).on( 'load', function(){
  wowAnimation();
});



/* ========================== 
   Navbar JS
   ==========================*/
  const menuLinks = document.querySelectorAll('.nav-link.nav-link-sm.has-dropdown');
  const dropdownMenus = document.querySelectorAll('.nav-dropdown-sm');
  const hamburgerBtn = document.getElementById('hamburger')
  const mobileMenu = document.getElementById('mobile-menu')

  hamburgerBtn && hamburgerBtn.addEventListener('click', () => {
    if (!(hamburgerBtn.classList.contains('hum-active'))) {
      hamburgerBtn.classList.add('hum-active')
      mobileMenu.classList.add('mm-active')
    } else {
      hamburgerBtn.classList.remove('hum-active')
      mobileMenu.classList.remove('mm-active')
    }
  })

  menuLinks && menuLinks.forEach((menuLink) => {
    menuLink.addEventListener('click', () => {
      dropdownMenus.forEach((dropdownMenu) => {
        if (dropdownMenu.classList.contains('nav-show') && dropdownMenu !== menuLink.nextElementSibling) {
          dropdownMenu.classList.remove('nav-show');
        }
      });
      const dropdownMenu = menuLink.nextElementSibling;
      dropdownMenu.classList.toggle('nav-show');
    });
  });

  /* ========================== 
   Swiper Slider JS
   ==========================*/

  var heroTwoSlider = new Swiper('.hero-slider-two', {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    speed: 1000,
    effect: 'fade',
    autoplay: {
      delay: 6000,
    },
    fadeEffect: {
      crossFade: true
    },
    navigation: {
      nextEl: '.hero-next',
      prevEl: '.hero-prev'
    }
  });

  var testimonialTwo = new Swiper('.testimonial-slider-two', {
    slidesPerView: 1,
    spaceBetween: 30,
    loop: true,
    speed: 500,
    pagination: {
      el: '.testi-two-pagi',
    },
    breakpoints: {
      320: {
        slidesPerView: 1
      },
      992: {
        slidesPerView: 2
      },
      1200: {
        slidesPerView: 3
      }
    }
  });

  var productDetailsSlider = new Swiper('.product_details__slider', {
    slidesPerView: 2,
    spaceBetween: 10,
    loop: true,
    speed: 500,
    navigation: {
      nextEl: '.pd-next',
      prevEl: '.pd-prev'
    },
    breakpoints: {
      320: {
        slidesPerView: 2
      },
      992: {
        slidesPerView: 3
      },
      1200: {
        slidesPerView: 4
      }
    }
  });

  var packageTwoSlider = new Swiper('.package-two-slider', {
    slidesPerView: 1.2,
    spaceBetween: 30,
    loop: true,
    speed: 500,
    pagination: {
      el: '.pack-two-pagi',
    },
    breakpoints: {
      320: {
        slidesPerView: 1.2
      },
      567: {
        slidesPerView: 2
      },
      992: {
        slidesPerView: 3
      },
      1200: {
        slidesPerView: 4
      }
    }
  });

  var packageTwoSlider = new Swiper('.package-three-slider', {
    slidesPerView: 1.2,
    spaceBetween: 30,
    loop: false,
    navigation: {
      nextEl: '.pack-next',
      prevEl: '.pack-prev'
    },
    breakpoints: {
      320: {
        slidesPerView: 1.2
      },
      567: {
        slidesPerView: 2
      },
      992: {
        slidesPerView: 3
      },
    }
  });

  var brandSlider = new Swiper('.partner-swiper', {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    slidesPerView: 'auto',
    speed: 7000,
    grabCursor: true,
    mousewheelControl: true,
    keyboardControl: true,
    autoplay: {
      delay: 1,
      disableOnInteraction: false
    },
    breakpoints: {
      320: {
        slidesPerView: 2
      },
      480: {
        slidesPerView: 3
      },
      768: {
        slidesPerView: 4
      },
      1200: {
        slidesPerView: 6
      },
      2000: {
        slidesPerView: 8
      }
    }
  });

  var instaFeed = new Swiper('.insta-feed-slider', {
    slidesPerView: 2,
    spaceBetween: 30,
    loop: false,
    breakpoints: {
      320: {
        slidesPerView: 2
      },
      480: {
        slidesPerView: 3
      },
      768: {
        slidesPerView: 4
      },
      1200: {
        slidesPerView: 5
      }
    }
  });

  var destinationSliderOne = new Swiper('.destination-slider-one', {
    slidesPerView: 1.3,
    spaceBetween: 30,
    loop: false,
    breakpoints: {
      320: {
        slidesPerView: 1.3
      },
      480: {
        slidesPerView: 1.8
      },
      768: {
        slidesPerView: 2.2
      },
    }
  });

  var testimonialOne = new Swiper('.testimonial-slider-one', {
    slidesPerView: 1,
    spaceBetween: 30,
    loop: true,
    effect: 'fade',
    fadeEffect: {
      crossFade: true
    },
    navigation: {
      nextEl: '.testi-next',
      prevEl: '.testi-prev'
    }
  });

  var testimonialOne = new Swiper('.testimonial-slider-three', {
    slidesPerView: 1,
    spaceBetween: 30,
    loop: true,
    navigation: {
      nextEl: '.testi-next',
      prevEl: '.testi-prev'
    }
  });

  var blogListSlider = new Swiper('.blog_list__slider', {
    slidesPerView: 1,
    spaceBetween: 0,
    loop: true,
    navigation: {
      nextEl: '.blog-next',
      prevEl: '.blog-prev'
    }
  });


/* ========================== 
   Scroll On Top JS
   ==========================*/
  document.getElementById('scrollTop')?.addEventListener('click', () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  })

  /* ========================== 
   Leaflet Map JS
   ==========================*/

   const mapElement = document.getElementById('map');

   if (mapElement) {
    var map = L.map(mapElement).setView([51.505, -0.09], 15);

    // L.tileLayer('https://tiles.stadiamaps.com/tiles/alidade_smooth_dark/{z}/{x}/{y}{r}.{ext}', {
    //     attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    // }).addTo(map);

      var Stadia_AlidadeSmoothDark = L.tileLayer('https://tiles.stadiamaps.com/tiles/alidade_smooth_dark/{z}/{x}/{y}{r}.{ext}', {
        minZoom: 0,
        maxZoom: 20,
        attribution: '&copy; <a href="https://www.stadiamaps.com/" target="_blank">Stadia Maps</a> &copy; <a href="https://openmaptiles.org/" target="_blank">OpenMapTiles</a> &copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors',
        ext: 'png'
      }).addTo(map);

    L.marker([51.5, -0.09]).addTo(map)
        .bindPopup('A pretty CSS3 popup.<br> Easily customizable.')
        .openPopup();
  }



  

}(jQuery));