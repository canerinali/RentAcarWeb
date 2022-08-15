(function($) {
    "use strict";



    /* =================================
    	ONE PAGE MENU ADD CURRENT CLASS
    =================================== */
    $('#menu').singlePageNav({
        filter: ':not(.extra)' // make posible open menu link in new windows
    });


    /* =================================
	TOGGLE FOOTER DIV
=================================== */

    $('.toggle-next-div').click(function() {
        $(this).toggleClass('active').next().slideToggle(300);
    }); // .click


     /* =================================
    	Toggle
    =================================== */
  

  $(".contentHideText").hide();
    $(".toggle").on("click", function(e) {

        var $this = $(this).prev('.contentHideText');
        var $text = $(this);
        $this.slideToggle('fast', function() {
            if ($(this).is(':visible')) {
                $text.text('Hide');
            } else {
                $text.text('Read more');
            }
        });
});
   


    /* =================================
    	NAVBAR COLLAPSE ON SCROLL
    =================================== */
    $(window).on('scroll', function() {
        var b = $(window).scrollTop();
        if (b > 60) {
            $(".scroll_header").addClass("scrollMenu");
        } else {
            $(".scroll_header").removeClass("scrollMenu");
        }
    });




   




    /* =================================
    	Preloader
    =================================== */
   $(window).load(function(){
    $('#loading').addClass('hide');
    $('#loading').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend',
      function(e) {
        $('#loading').addClass('none');
    });
  });;



    /* =================================
    	BACK TOP
    =================================== */
    $("#back-top").hide();

    $(window).scroll(function() {
        if ($(this).scrollTop() > 100) {
            $('#back-top').fadeIn();
        } else {
            $('#back-top').fadeOut();
        }
    });
    $(' a #back-top').click(function() {
        $('body,html').animate({
            scrollTop: 0
        }, 800);
        return false;
    });
 





    /* =================================
    	Accordion shortcodes
    =================================== */
    $('.accordion_title').click(function() {
        $(this).toggleClass('active').next().slideToggle(300);
    }); // .click




    /* ==========================================================================
      Product statistics counter
      ========================================================================== */
    $('.count').counterUp({
        delay: 10, // the delay time in ms
        time: 2000 // the speed time in ms
    });

    /* ==========================================================================
     Tabs
     ========================================================================== */

    // tabbed content
    // http://www.entheosweb.com/tutorials/css/tabs.asp
    $(".tab_content").hide();
    $(".tab_content:first").show();

    /* if in tab mode */
    $("ul.tabs li").click(function() {

        $(".tab_content").hide();
        var activeTab = $(this).attr("rel");
        $("#" + activeTab).fadeIn();

        $("ul.tabs li").removeClass("active");
        $(this).addClass("active");

        $(".tab_drawer_heading").removeClass("d_active");
        $(".tab_drawer_heading[rel^='" + activeTab + "']").addClass("d_active");

    });
    /* if in drawer mode */
    $(".tab_drawer_heading").click(function() {

        $(".tab_content").hide();
        var d_activeTab = $(this).attr("rel");
        $("#" + d_activeTab).fadeIn();

        $(".tab_drawer_heading").removeClass("d_active");
        $(this).addClass("d_active");

        $("ul.tabs li").removeClass("active");
        $("ul.tabs li[rel^='" + d_activeTab + "']").addClass("active");
    });




    /* Extra class "tab_last" 
    	   to add border to right side
    	   of last tab */
    $('ul.tabs li').last().addClass("tab_last");




    /* ==========================================================================
     Pop up and Lighbox 
     ========================================================================== */
    //$('.gallery').magnificPopup({
    //    delegate: 'a',
    //    type: 'image',
    //    tLoading: 'Loading image #%curr%...',
    //    mainClass: 'mfp-img-mobile',
    //    callbacks: {
    //        change: function() {
    //            if (this.isOpen) {
    //                this.wrap.addClass('mfp-open');
    //            }
    //        },
    //        beforeOpen: function() {
    //            // just a hack that adds mfp-anim class to markup 
    //            this.st.image.markup = this.st.image.markup.replace('mfp-figure', 'mfp-figure mfp-with-anim');
    //            this.st.mainClass = this.st.el.attr('data-effect');
    //        }
    //    },
    //    gallery: {
    //        enabled: true,
    //        navigateByImgClick: true,
    //        preload: [0, 1] // Will preload 0 - before current, and 1 after the current image
    //    },
    //    image: {
    //        tError: '<a href="%url%">The image #%curr%</a> could not be loaded.'
    //    }
    //});



    $('.popup-modal').magnificPopup({
        type: 'inline',
        preloader: false,
        focus: '#username'
    });
    $(document).on('click', '.popup-modal-dismiss', function(e) {
        e.preventDefault();
        $.magnificPopup.close();
    });


    $('.popup-youtube, .popup-vimeo, .popup-gmaps').magnificPopup({
        disableOn: 700,
        type: 'iframe',
        mainClass: 'mfp-fade',
        removalDelay: 160,
        preloader: false,

        fixedContentPos: false
    });

    $('.simple-ajax-popup').magnificPopup({
        type: 'ajax'
    });




    $('.image-popup-no-margins').magnificPopup({
        type: 'image',
        closeOnContentClick: true,
        closeBtnInside: false,
        fixedContentPos: true,
        mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
        image: {
            verticalFit: true
        },
        zoom: {
            enabled: true,
            duration: 300 // don't foget to change the duration also in CSS
        }
    });




    /* =================================
    	Timer 
    =================================== */

    timer();



    function timer() {
        var now = new Date();
        var newDate = new Date("November,14,2018 23:59:59");
        var totalRemains = (newDate.getTime() - now.getTime());
        if (totalRemains > 1) {
            var Days = (parseInt(parseInt(totalRemains / 1000) / (24 * 3600)));
            var Hours = (parseInt((parseInt(totalRemains / 1000) - Days * 24 * 3600) / 3600));
            var Min = (parseInt(parseInt((parseInt(totalRemains / 1000) - Days * 24 * 3600) - Hours * 3600) / 60));
            var Sec = parseInt((parseInt(totalRemains / 1000) - Days * 24 * 3600) - Hours * 3600) - Min * 60;
            if (Days < 10) {
                Days = "0" + Days
            }
            if (Hours < 10) {
                Hours = "0" + Hours
            }
            if (Min < 10) {
                Min = "0" + Min
            }
            if (Sec < 10) {
                Sec = "0" + Sec
            }
            $(".day").each(function() {
                $(this).text(Days);
            });
            $(".hour").each(function() {
                $(this).text(Hours);
            });
            $(".min").each(function() {
                $(this).text(Min);
            });
            $(".sec").each(function() {
                $(this).text(Sec);
            });
            setTimeout(timer, 1000);
        }
    }


    /* ==========================================================================
     Datapick
     ========================================================================== */


    flatpickr(".flatpickr", {
        enableTime: true,
        disableMobile: true,
        altFormat: "F j, Y h:i K"
    });



})(jQuery);

 /* ==========================================================================
   Contact form 1
   ========================================================================== */

  
$("#submit_btn").click(function() { 

        var proceed = true;
        //simple validation at client's end
        //loop through each field and we simply change border color to red for invalid fields       
      $("#contact_form [required]").each(function(){
      
            $(this).css('border-color',''); 
            if(!$.trim($(this).val())){ //if this field is empty 
            
            $(this).css('border-color','red'); //change border color to red   
            $(this).parent().addClass('form-error-message');
            proceed = false; //set do not proceed flag
             
             
            }
            //check invalid email
            var email_reg = /^([\w-\.]+@([\w-]+\.)+[\w-]{2,4})?$/; 
            if($(this).attr("type")=="email" && !email_reg.test($.trim($(this).val()))){
                $(this).css('border-color','red'); //change border color to red   
                proceed = false; //set do not proceed flag              
            }   
        });
       
        if(proceed) //everything looks good! proceed...
        {
            //get input field values data to be sent to server
            post_data = {
                'user_name'     : $("#contact_form input[name=name]").val(), 
                'user_email'    : $("#contact_form input[name=email]").val(), 
                'phone_number'  : $("#contact_form  input[name=phone]").val(), 
                'msg'           : $("#contact_form  textarea[name=message]").val()
            };
            
            //Ajax post data to server 
            $.post('./php/contact.php', post_data, function(response){  
                if(response.type == 'error'){ //load json data from server and output message     
                    output = '<div class="error">'+response.text+'</div>';
                }else{
                    output = '<div class="success">'+response.text+'</div>';
                    //reset values in all input fields
                    $("#contact_form [required]").val(''); 
                    $("#contact_form #contact_body").slideUp(); //hide form after success
                }
                $("#contact_form #contact_results").hide().html(output).slideDown();
            }, 'json');
        }
    });
    
    //reset previously set border colors and hide all message on .keyup()
    $("#contact_form [required]").focus(function() { 
        $(this).css('border-color',''); 
        $(this).parent().removeClass('form-error-message');
        $("#contact_results").slideUp();
    });
    
    
    
    
    


