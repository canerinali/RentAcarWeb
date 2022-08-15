/*! modernizr 3.3.1 (Custom Build) | MIT *
 * https://modernizr.com/download/?-mq-setclasses !*/
!function(e,n,t){function o(e,n){return typeof e===n}function a(){var e,n,t,a,s,i,r;for(var l in d)if(d.hasOwnProperty(l)){if(e=[],n=d[l],n.name&&(e.push(n.name.toLowerCase()),n.options&&n.options.aliases&&n.options.aliases.length))for(t=0;t<n.options.aliases.length;t++)e.push(n.options.aliases[t].toLowerCase());for(a=o(n.fn,"function")?n.fn():n.fn,s=0;s<e.length;s++)i=e[s],r=i.split("."),1===r.length?Modernizr[r[0]]=a:(!Modernizr[r[0]]||Modernizr[r[0]]instanceof Boolean||(Modernizr[r[0]]=new Boolean(Modernizr[r[0]])),Modernizr[r[0]][r[1]]=a),f.push((a?"":"no-")+r.join("-"))}}function s(e){var n=u.className,t=Modernizr._config.classPrefix||"";if(p&&(n=n.baseVal),Modernizr._config.enableJSClass){var o=new RegExp("(^|\\s)"+t+"no-js(\\s|$)");n=n.replace(o,"$1"+t+"js$2")}Modernizr._config.enableClasses&&(n+=" "+t+e.join(" "+t),p?u.className.baseVal=n:u.className=n)}function i(){return"function"!=typeof n.createElement?n.createElement(arguments[0]):p?n.createElementNS.call(n,"http://www.w3.org/2000/svg",arguments[0]):n.createElement.apply(n,arguments)}function r(){var e=n.body;return e||(e=i(p?"svg":"body"),e.fake=!0),e}function l(e,t,o,a){var s,l,f,d,c="modernizr",p=i("div"),m=r();if(parseInt(o,10))for(;o--;)f=i("div"),f.id=a?a[o]:c+(o+1),p.appendChild(f);return s=i("style"),s.type="text/css",s.id="s"+c,(m.fake?m:p).appendChild(s),m.appendChild(p),s.styleSheet?s.styleSheet.cssText=e:s.appendChild(n.createTextNode(e)),p.id=c,m.fake&&(m.style.background="",m.style.overflow="hidden",d=u.style.overflow,u.style.overflow="hidden",u.appendChild(m)),l=t(p,e),m.fake?(m.parentNode.removeChild(m),u.style.overflow=d,u.offsetHeight):p.parentNode.removeChild(p),!!l}var f=[],d=[],c={_version:"3.3.1",_config:{classPrefix:"",enableClasses:!0,enableJSClass:!0,usePrefixes:!0},_q:[],on:function(e,n){var t=this;setTimeout(function(){n(t[e])},0)},addTest:function(e,n,t){d.push({name:e,fn:n,options:t})},addAsyncTest:function(e){d.push({name:null,fn:e})}},Modernizr=function(){};Modernizr.prototype=c,Modernizr=new Modernizr;var u=n.documentElement,p="svg"===u.nodeName.toLowerCase(),m=function(){var n=e.matchMedia||e.msMatchMedia;return n?function(e){var t=n(e);return t&&t.matches||!1}:function(n){var t=!1;return l("@media "+n+" { #modernizr { position: absolute; } }",function(n){t="absolute"==(e.getComputedStyle?e.getComputedStyle(n,null):n.currentStyle).position}),t}}();c.mq=m,a(),s(f),delete c.addTest,delete c.addAsyncTest;for(var h=0;h<Modernizr._q.length;h++)Modernizr._q[h]();e.Modernizr=Modernizr}(window,document);

(function($){

$.fn.prettyMenu = function(options) {
        options = $.extend({
           colorScheme: 'dark',
           fixed: false,
           submenuAnimation: 'bounceInDown',
           hoverAnimation: 'hvr-shutter-out-horizontal',
           hoverColor: false,
           shadow: true,
           hideOnScroll: false,
           mobile: 1000,
           direction: 'left', 
           mobileBackground: true,
           mobileDirection: 'left',
           onTop: false,
           pushContent: false,
           iconMenu: false,
           iconStyle: "slider",
           showDividers: true,
           closeOnClick: false
        }, options);

return this.each(function() {
   var $t = $(this);
   $t.addClass("prettyMenu");
   $t.find("> ul").addClass("main").wrap('<div class="pm_menu_container"></div>');
   var mobile;
   var heightMenu = $t.find("ul.main").height();
   if (options.colorScheme) $t.addClass(options.colorScheme);
   $("#pm_right").appendTo(".pm_menu_container");
   var mobileMenu = $t.find('.pm_menu_container');
   var windowHeight;
   var fixedMargin;  

   if (mobileMenu.hasClass('pm_on_top')) {
    fixedMargin = 0;
   } else {
    fixedMargin = 57; 
   } 

   $(window).resize(function () {
       if (Modernizr.mq('(max-width: '+options.mobile+'px)')) {
           $t.addClass("pm_mobile");
           $('body').addClass('pm_mobile'); 
       } else {
           $t.removeClass("pm_mobile");
           $('body').removeClass('pm_mobile');  
       }
       heightMenu = $t.find("ul.main").height();
       windowHeight = $(window).height();
       if (options.fixed) { 
       		$t.addClass('pm_fixed'); $('body').addClass('pm_fixed');
       } 
   }).resize();
    
   $t.find("ul.main > li").has("> ul").find("> a").append('<i class="fa fa-angle-down arrow"></i>');
   $t.find("ul:not(.main) > li").has("ul").find("> a").append('<i class="fa fa-angle-right arrow"></i>');
   $t.find("ul > li").has("> ul").addClass('toggle up');
   $t.find("ul.main > li").each(function() {
       $(this).find("li.toggle > ul").each(function(i) {
           var padding=20+i*5+'%';
           $(this).find("> li > a").css({paddingLeft:padding});
       }); 
   });

   $t.prepend('<div class="pm_main_mobile"><a class="pm_toggle"><span class="hamburger hamburger--'+ options.iconStyle +'"><div class="hamburger-box"><div class="hamburger-inner"></div></span></div></a></div>');
   $t.find('li.toggle > a').append('<span class="arrow_click"></span>');
   $t.find('li.toggle > a .arrow_click').click(function(e) {
       e.preventDefault();
       if ($t.hasClass('pm_mobile')) {
           $(this).closest('li.toggle').toggleClass('up').find('> ul').slideToggle();        
       }
   });

   if (options.onTop && $t.hasClass('pm_mobile')) {
       if (options.mobileDirection=='left') {
           mobileMenu.addClass("pm_on_top");
           $(window).resize(function () {
               var documentHeight = $(document).height();
               if (!options.fixed) {
                   mobileMenu.css({'minHeight':documentHeight});
               }
           }).resize();
       }
   }    
   if (options.hoverAnimation) $t.find("ul > li > a").addClass(options.hoverAnimation);
   if (options.shadow) $t.addClass('shadow');
   if (options.direction!='left') $t.addClass(options.direction);
   $t.find("ul > li").hover(
       function() {
           $( this ).prev().addClass('prev').find('> a');
       }, function() {
           $( this ).prev().removeClass('prev').find('> a');
       }
   );
   if (options.submenuAnimation) {
       $t.addClass("animation");
       $t.find("ul > li a").hover(
           function() {
               $( this ).parent().find('> ul').removeClass().addClass(options.submenuAnimation + ' animated').one('webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend', function(){
                   $(this).removeClass();
               });
           }, function() {
               $( this ).parent().find('> ul').removeClass();
           }
       );  
   }
   if (options.hoverColor) $('head').append("<style>a[class^=\"hvr-\"]:before{background-color: "+options.hoverColor+" !important;}</style>");
   if (options.hideOnScroll) {
       var previousScroll = 0;
       $(window).scroll(function(){
           var scroll = $("body").scrollTop();
           if (scroll > previousScroll) {
               if (options.hideOnScroll) $t.css({top:-heightMenu-10});
           } else {
               if (options.hideOnScroll) $t.css({top:0});
           }
           previousScroll = scroll;
       });
   }

    if (options.mobileBackground) $('body').append('<div class="pm_background"></div>');
    $('.prettyMenu .pm_main_mobile .pm_toggle').click(function(event) {
       event.preventDefault();
       if (options.mobileDirection=='top') {
           $t.toggleClass('toggle').find('.pm_menu_container').slideToggle(function() {
                if ($(this).is(':visible'))
                    $(this).css('display','inline-block');
            });
       } else {
           mobileMenu.toggleClass('on');
       }
       $(this).find(".hamburger").toggleClass('is-active');
       $('body, .pm_drag').toggleClass('on');
        $('.pm_background').toggleClass('show');
   });

   $(".pm_background").click(function() {
       closeMenu();
   });
       
   function openMenu() {
       $('.pm_background').addClass('show');
       $t.find('.pm_toggle').addClass('on');
       $t.find('.pm_toggle .hamburger').addClass('is-active');
       $('body, .pm_drag').addClass('on');
       if (options.mobileDirection=='top') {
           mobileMenu.slideDown(function() {
               $(this).css('display','inline-block');
           });
       } else {
           mobileMenu.addClass('on');
       }
   }
       
   function closeMenu() {
       $('.pm_background').removeClass('show');
       $t.find('.pm_toggle').removeClass('on');
       $t.find('.pm_toggle .hamburger').removeClass('is-active');
       $('body, .pm_drag').removeClass('on');
       if (options.mobileDirection=='top') {
           mobileMenu.slideUp();
       } else {
           mobileMenu.removeClass('on');           
       }
   }
       
   $(".prettyMenu #pm_right #search .pm_search").click(function(e) {
       e.preventDefault();
       $(this).closest("#pm_right").toggleClass("on");
   });

   if (options.mobileDirection=='left') {
       $('.pm_menu_container').addClass("pm_left");
   }       

   if (options.iconMenu) {
       $t.addClass("pm_icon_menu");
   }   

   if (!options.showDividers) {
       $t.addClass("pm_no_dividers");
   }

   if (options.pushContent && options.mobileDirection=='left' && $t.hasClass('pm_mobile')) {
       $('.pm_menu_container').addClass("pm_on_top");
       $(window).resize(function () {
           var windowWidth = $(window).width();
           $('body').addClass("pm_push_content").css({'width':windowWidth});
           if (!options.fixed) {
               var documentHeight = $(document).height();
               mobileMenu.css({'minHeight':documentHeight});
           }
       }).resize();
   }
   if (options.pushContent && options.mobileDirection=='top' && $t.hasClass('pm_mobile')) {
       $('body').addClass("pm_push_content_top");  
   }           

   if(jQuery().flick) {
       if (options.mobileDirection=='left') {
           $("body").append('<div class="pm_drag"></div>');
           $('.pm_drag').on('flick', function(e) {
               if ('horizontal' == e.orientation) {
                   if (1 == e.direction) {
                       openMenu();
                   }
                   else {
                       closeMenu();
                   }
               }           
           });
       } else {
           $('.prettyMenu.pm_mobile').on('flick', function(e) {
               if ('vertical' == e.orientation) {
                  if (1 == e.direction) {
                       openMenu();
                   }
               }       
           });
       }
   }

   if (options.closeOnClick && $t.hasClass('pm_mobile')) {
      $t.find("ul li a").click(function(e) {
         e.preventDefault();
         if (e.target !== this) return;
         closeMenu();
      });
   }
   
});
}
})(jQuery);