<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styles/mystyle.css">
    <link rel="stylesheet" href="styles/mycss.css">

    <!--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    -->

    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <script src="jquery/jquery-1.9.1.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>

    <title>Standard Union Securities Limited</title>

    <style>
        a:hover {
            color: orange;
        }
    </style>
</head>
<body style="padding:0px; margin:0px; font-family:Arial, Verdana;background-color:#fff;">
<form id ="form1" runat ="server" >




    <!-- Logo wing-->
    <!--
    <div class ="logowing" >
    <div class="container">
      <div class="rows">
      <div class ="col-md-12" >

      </div>
      </div>
      </div>
    </div>
    -->

    <div style=" height:5px;"></div>
    <!--Nav bar -->
    <nav class="navbar navbar-inverse head">
        <div class="container">
            <div class="rows">
                <!--Logo Starts here-->
                <!--<div class="col-md-3 logo">
                </div> -->
                <!--End of logo-->

                <div class="col-md-3">
                    <a href="Default.aspx"><img src="images\used\logo.jpg" style=" padding:0; margin:0;" class="img-responsive" /></a>
                </div>
                <div class="col-md-9">
                    <!--Menu only-->
                    <div class="navbar-header">
                        <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar" style="background-color:#e9781A; color:#e9781A;">
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                            <span class="icon-bar"></span>
                        </button>
                        <!--<a id ="mTitle" class="navbar-brand" href="Default.aspx"><strong>Smart Jobs</strong></a>-->
                    </div>
                    <div class="collapse navbar-collapse" id="myNavbar">
                        <ul class="nav navbar-nav navbar-right">

                            <li class="active"><a href="../Default.aspx">HOME</a></li>
                            <li><a href="aboutus.html">ABOUT US</a></li>
                            <li><a href="signup.aspx">ACCOUNT OPENING</a></li>
                            <li><a href="products.html" >PRODUCTS</a></li>
                            <li><a href="downloads.html" >DOWNLOADS</a></li>
                            <li><a href="policies.html">POLICY</a></li>
                <li><a href="https://standardunion.xcloudintegra.com/login.aspx?ReturnUrl=%2fdefault.aspx" target="_blank" ID="butLogin">OMS Login</a></li>
                            
                            
                        </ul>
                        <!--
                        <ul class="nav navbar-nav navbar-right">


                          <!--<li><a href="contactus.aspx"><span class="glyphicon glyphicon-request"></span> Request a pickup</a></li>
                          <li><a href="#"><span class="glyphicon glyphicon-log-in"></span> Login</a></li><li><asp:LinkButton ID="butMyAC" runat="server">My/Acct</asp:LinkButton></li>
                        </ul>-->
                    </div>
                </div>
            </div> <!-- close of rows-->
        </div>
    </nav>
    <div style ="background-color :orange; color:#fff; font-size :large;">
    <marquee>Welcome to Standard union Securities Limited, your home of investment with excellent service delivery. We are duly licensed by the Nigerian Stock Exchange as a Dealing Member and registered as Broker/Dealer, Portfolio Manager and Investors Adviser by the Securities & Exchange Commission ("SEC"). Our Registered Office/Corporate Headquarters is on the 1st floor, Shippers' Plaza 31, Ndola Cresent, Off Michael Okpara Street Wuse Zone 5, Abuja. Our area office is at African Alliance Building, F1, Sani Abacha Way, Kano. Welcome to wealth  </marquee>
        </div>
    <!-- End of nav bar -->

    <!--<div style=" height:3px; background-color:#000;"></div> BLue line-->

    <!-- it works the same with all jquery version from 1.x to 2.x -->
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <!-- use jssor.slider.mini.js (40KB) instead for release -->
    <!-- jssor.slider.mini.js = (jssor.js + jssor.slider.js) -->
    <script type="text/javascript" src="js/jssor.js"></script>
    <script type="text/javascript" src="js/jssor.slider.js"></script>
    <script>
        jQuery(document).ready(function ($) {


            var _CaptionTransitions = [];
            /* _CaptionTransitions["L"] = { $Duration: 900, x: 0.6, $Easing: { $Left: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["R"] = { $Duration: 900, x: -0.6, $Easing: { $Left: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["T"] = { $Duration: 900, y: 0.6, $Easing: { $Top: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["B"] = { $Duration: 900, y: -0.6, $Easing: { $Top: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["ZMF|10"] = { $Duration: 900, $Zoom: 11, $Easing: { $Zoom: $JssorEasing$.$EaseOutQuad, $Opacity: $JssorEasing$.$EaseLinear }, $Opacity: 2 };
            _CaptionTransitions["RTT|10"] = { $Duration: 900, $Zoom: 11, $Rotate: 1, $Easing: { $Zoom: $JssorEasing$.$EaseOutQuad, $Opacity: $JssorEasing$.$EaseLinear, $Rotate: $JssorEasing$.$EaseInExpo }, $Opacity: 2, $Round: { $Rotate: 0.8} };
            _CaptionTransitions["RTT|2"] = { $Duration: 900, $Zoom: 3, $Rotate: 1, $Easing: { $Zoom: $JssorEasing$.$EaseInQuad, $Opacity: $JssorEasing$.$EaseLinear, $Rotate: $JssorEasing$.$EaseInQuad }, $Opacity: 2, $Round: { $Rotate: 0.5} };
            _CaptionTransitions["RTTL|BR"] = { $Duration: 900, x: -0.6, y: -0.6, $Zoom: 11, $Rotate: 1, $Easing: { $Left: $JssorEasing$.$EaseInCubic, $Top: $JssorEasing$.$EaseInCubic, $Zoom: $JssorEasing$.$EaseInCubic, $Opacity: $JssorEasing$.$EaseLinear, $Rotate: $JssorEasing$.$EaseInCubic }, $Opacity: 2, $Round: { $Rotate: 0.8} };
            _CaptionTransitions["CLIP|LR"] = { $Duration: 900, $Clip: 15, $Easing: { $Clip: $JssorEasing$.$EaseInOutCubic }, $Opacity: 2 };
            _CaptionTransitions["MCLIP|L"] = { $Duration: 900, $Clip: 1, $Move: true, $Easing: { $Clip: $JssorEasing$.$EaseInOutCubic} };
            _CaptionTransitions["MCLIP|R"] = { $Duration: 900, $Clip: 2, $Move: true, $Easing: { $Clip: $JssorEasing$.$EaseInOutCubic} };
            */
            _CaptionTransitions["AN"] = { $Duration: 900, x: -0.6, y: -0.6, $Easing: { $Left: $JssorEasing$.$EaseInOutSine, $Top: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["L"] = { $Duration: 900, x: 0.6, $Easing: { $Left: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["R"] = { $Duration: 900, x: -0.6, $Easing: { $Left: $JssorEasing$.$EaseInOutSine }, $Opacity: 2 };
            _CaptionTransitions["T"] = { $Duration: 2000, y: -0.6, $Easing: { $Top: $JssorEasing$.$EaseInOutSine }, $Opacity: 2, $During: { $Opacity: [0, 2]} };




            var options = {
                $FillMode: 2,                                       //[Optional] The way to fill image in slide, 0 stretch, 1 contain (keep aspect ratio and put all inside slide), 2 cover (keep aspect ratio and cover whole slide), 4 actual size, 5 contain for large image, actual size for small image, default value is 0
                $AutoPlay: true,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
                $AutoPlayInterval: 4000,                            //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                $PauseOnHover: 1,                                   //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
                $SlideEasing: $JssorEasing$.$EaseOutQuint,          //[Optional] Specifies easing for right to left animation, default value is $JssorEasing$.$EaseOutQuad
                $SlideDuration: 800,                               //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                $MinDragOffsetToSlide: 20,                          //[Optional] Minimum drag offset to trigger slide , default value is 20
                //$SlideWidth: 600,                                 //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                //$SlideHeight: 300,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                $SlideSpacing: 0, 					                //[Optional] Space between each slide in pixels, default value is 0
                $DisplayPieces: 1,                                  //[Optional] Number of pieces to display (the slideshow would be disabled if the value is set to greater than 1), the default value is 1
                $ParkingPosition: 0,                                //[Optional] The offset position to park slide (this options applys only when slideshow disabled), default value is 0.
                $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                $DragOrientation: 1,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $DisplayPieces is greater than 1, or parking position is not 0)


                $CaptionSliderOptions: {                            //[Optional] Options which specifies how to animate caption
                    $Class: $JssorCaptionSlider$,                   //[Required] Class to create instance to animate caption
                    $CaptionTransitions: _CaptionTransitions,       //[Required] An array of caption transitions to play caption, see caption transition section at jssor slideshow transition builder
                    $PlayInMode: 1,                                 //[Optional] 0 None (no play), 1 Chain (goes after main slide), 3 Chain Flatten (goes after main slide and flatten all caption animations), default value is 1
                    $PlayOutMode: 3                                 //[Optional] 0 None (no play), 1 Chain (goes before main slide), 3 Chain Flatten (goes before main slide and flatten all caption animations), default value is 1
                },

                $BulletNavigatorOptions: {                          //[Optional] Options to specify and enable navigator or not
                    $Class: $JssorBulletNavigator$,                 //[Required] Class to create navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 1,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                    $Lanes: 1,                                      //[Optional] Specify lanes to arrange items, default value is 1
                    $SpacingX: 8,                                   //[Optional] Horizontal space between each item in pixel, default value is 0
                    $SpacingY: 8,                                   //[Optional] Vertical space between each item in pixel, default value is 0
                    $Orientation: 1                                 //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                },

                $ArrowNavigatorOptions: {                           //[Optional] Options to specify and enable arrow navigator or not
                    $Class: $JssorArrowNavigator$,                  //[Requried] Class to create arrow navigator instance
                    $ChanceToShow: 1,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 2,                                 //[Optional] Auto center arrows in parent container, 0 No, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1                                       //[Optional] Steps to go for each navigation request, default value is 1
                }
            };

            var jssor_slider1 = new $JssorSlider$("slider1_container", options);

            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizes
            function ScaleSlider() {
                var bodyWidth = document.body.clientWidth;
                if (bodyWidth)
                    jssor_slider1.$ScaleWidth(Math.min(bodyWidth, 1920));
                else
                    window.setTimeout(ScaleSlider, 30);
            }
            ScaleSlider();

            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            //responsive code end
        });
    </script>
    <!-- Jssor Slider Begin -->
    <!-- To move inline styles to css file/block, please specify a class name for each element. -->
    <div id="slider1_container" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 1300px; height: 400px; overflow: hidden;">

        <!-- Slides Container -->
        <div u="slides" style="cursor:auto; position: absolute; left: 0px; top: 0px; width: 1300px;
            height: 400px; overflow: hidden;">

            <!--<div>
                <!--Temporary Slide 
                <a href="sec_info.html"><img u="image" src="images\display\sec_bann.jpg" /></a>
               
                
                

            </div>--> <!--End of Temp Slide-->
            


            <div>
                <!--Slide 1-->
                <img u="image" src="images\display\1.jpg" />
            
                <div u="caption" t="R" style="background-color:#e9781A; position: absolute; width: 450px; height: 50px; top: 65px; left: 690px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    Personal Portfolio Management
                </div>

                <div u="caption" t="R" style="opacity:0.7; background-color:#28156E; position: absolute; width: 450px; height: 50px; top: 130px; left: 690px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    Quick Mandate Authorization
                </div>

                <div u="caption" t="R" style="opacity:0.7; background-color:#3d8d77; position: absolute; width: 450px; height: 50px; top: 195px; left: 690px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    Secured Personal Trading
                </div>

                <a href="signup.aspx"><img u="caption" t="AN" src="images/used/signup2.png" style=" position: absolute; width: 220px; height: 60px; top: 305px; left: 600px;" /></a>

            </div> <!--End of Slide 1-->

            <div>
                <!--Slide 2-->
                <img u="image" src="images\display\01_1.jpg" />

                <a href="contactus.aspx"><div u="caption" t="R" style=" border-radius:4px; background-color:#e9781A; position: absolute; width: 450px; height: 40px; top: 285px; left: 50px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    Contact our Investment Advisors
                </div></a>
                
            </div> <!--End of Slide 2-->
            
            <div>
                <!--Slide 3-->
                <img u="image" src="images\display\3.jpg" />

                <div u="caption" t="L" style=" border-radius:4px; background-color:#e9781A; position: absolute; width: 490px; height: 40px; top: 200px; left: 75px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    Best hands handle your resources,
                </div>

                <div u="caption" t="L" style=" border-radius:4px; background-color:#e9781A; position: absolute; width: 400px; height: 40px; top: 260px; left: 75px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    savegard your investment,
                </div>

                <div u="caption" t="L" style=" border-radius:4px; background-color:#e9781A; position: absolute; width: 400px; height: 40px; top: 320px; left: 75px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                    ..to guarantee your success.
                </div>
                <!--<img u="caption" t="AN" src="img/1920/logo2.png" style="position: absolute; width: 120px; height: 140px; top: 10px; left: 0px;" />-->
                <!--
                <div style="position: absolute; width:380px; height: 90px; top: 60px; left: 150px; padding: 5px;
                    text-align: left; line-height: 36px; font-size: 30px;
                        color: #FFF; background-color:#DA251C;">
                        For home/office cleaning, we offer the best services.
                </div>

                <div u="caption" t="R" style="background-color:#00923F; position: absolute; width: 380px; height: 50px; top: 170px; left: 150px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                        We get you satisfied
                </div>

                <div u="caption" t="R" style=" opacity:10; background-color:#00923F; position: absolute; width: 380px; height: 50px; top: 245px; left: 150px; padding: 5px; text-align: left; line-height: 36px; font-size: 30px; color: #FFFFFF;">
                        We make you come back
                </div>

                <img u="caption" t="R" src="img/1920/house_clean_t.png" style="position: absolute; width: 344px; height: 262px; top: 200px; left: 900px;" />

                <!--<div style="position: absolute; width: 600px; height: 40px; top: -5px; left: 800px; padding: 5px;
                    text-align: left; line-height: 36px; font-size: 30px;
                        color: #fff;">
                        For pick up request pls click <a href="#">here</a> or Call : <span style =" background-color :#C7A55E;">0703-597-2203</span>.
                </div>-->

            </div>  <!--End Slide 3-->


            
        </div>


        <!--#region Bullet Navigator Skin Begin -->
        <!-- Help: http://www.jssor.com/development/slider-with-bullet-navigator-jquery.html -->
        <style>
            /* jssor slider bullet navigator skin 21 css */
            /*
            .jssorb21 div           (normal)
            .jssorb21 div:hover     (normal mouseover)
            .jssorb21 .av           (active)
            .jssorb21 .av:hover     (active mouseover)
            .jssorb21 .dn           (mousedown)
            */
            .jssorb21 {
                position: absolute;
            }

                .jssorb21 div, .jssorb21 div:hover, .jssorb21 .av {
                    position: absolute;
                    /* size of bullet elment */
                    width: 19px;
                    height: 19px;
                    text-align: center;
                    line-height: 19px;
                    color: white;
                    font-size: 12px;
                    background: url(img/b21.png) no-repeat;
                    overflow: hidden;
                    cursor: pointer;
                }

                .jssorb21 div {
                    background-position: -5px -5px;
                }

                    .jssorb21 div:hover, .jssorb21 .av:hover {
                        background-position: -35px -5px;
                    }

                .jssorb21 .av {
                    background-position: -65px -5px;
                }

                .jssorb21 .dn, .jssorb21 .dn:hover {
                    background-position: -95px -5px;
                }
        </style>
        <!-- bullet navigator container -->
        <div u="navigator" class="jssorb21" style="bottom: 26px; right: 6px;">
            <!-- bullet navigator item prototype -->
            <div u="prototype"></div>
        </div>
        <!--#endregion Bullet Navigator Skin End -->
        <!--#region Arrow Navigator Skin Begin -->
        <!-- Help: http://www.jssor.com/development/slider-with-arrow-navigator-jquery.html -->
        <style>
            /* jssor slider arrow navigator skin 21 css */
            /*
            .jssora21l                  (normal)
            .jssora21r                  (normal)
            .jssora21l:hover            (normal mouseover)
            .jssora21r:hover            (normal mouseover)
            .jssora21l.jssora21ldn      (mousedown)
            .jssora21r.jssora21rdn      (mousedown)
            */
            .jssora21l, .jssora21r {
                display: block;
                position: absolute;
                /* size of arrow element */
                width: 55px;
                height: 55px;
                cursor: pointer;
                background: url(img/a21.png) center center no-repeat;
                overflow: hidden;
            }

            .jssora21l {
                background-position: -3px -33px;
            }

            .jssora21r {
                background-position: -63px -33px;
            }

            .jssora21l:hover {
                background-position: -123px -33px;
            }

            .jssora21r:hover {
                background-position: -183px -33px;
            }

            .jssora21l.jssora21ldn {
                background-position: -243px -33px;
            }

            .jssora21r.jssora21rdn {
                background-position: -303px -33px;
            }
        </style>
        <!-- Arrow Left -->
        <span u="arrowleft" class="jssora21l" style="top: 123px; left: 8px;">
        </span>
        <!-- Arrow Right -->
        <span u="arrowright" class="jssora21r" style="top: 123px; right: 8px;">
        </span>
        <!--#endregion Arrow Navigator Skin End -->
        <a style="display: none" href="http://www.jssor.com">Bootstrap Slider</a>
    </div>
    <!-- Jssor Slider End -->

    <div style="height:20px;"></div> <!--Space-->

    <div class="container">
        <!--begining of the body content-->
        <div class="rows">
            <div class="col-md-3">
                <h3>Securities Trading</h3>
                <p>Trading and making markets in quoted securities.In this respect....read more.</p>
                <br /><br />
                </div> 

            <div class="col-md-3">
                <h3>Investment Management</h3>
                <p>We provide specialised investment advisory services to individual.read more..</p>
                
                </div> 

            <div class="col-md-3" >
                <h3>Regularizing Shares</h3>
                <p>This is a product designed to assist banks and all other money lenders...read more</p><br />
                </div> 

            <div class="col-md-3" >
                <h3>Portfolio/Asset Management</h3>
                <p>Our staff members are specially trained to monitor events in the market place.. read more</p>
                </div> 

            <div class="md-col-12" style ="height :40px;"></div> <!--Space of 20px-->
            <div class ="col-md-3" style =" background-color :#f1f1f1; border-radius:5px; padding :10px;"><img src="images\invest_small.jpg" class="img-responsive" style ="border-radius:5px;" /></div>
            <div class="col-md-9" style =" background-color :#f1f1f1; border-radius:5px; padding :10px;">
                
                
                <p class="padP" >
                    Standard Union Securities Limited (“STUS”) was incorporated as a Private Limited Liability Company on 7th July 1997 The Company is duly licensed by the Nigerian Stock Exchange as a Dealing Member and registered as Broker/Dealer, Portfolio Manager and Investors Adviser by the Securities & Exchange Commission (“SEC”), Its Registered Office/Corporate Headquarters is on the 1st floor, Shippers' Plaza 31, Ndola Cresent, Off Michael Okpara Street Wuse Zone 5, Abuja.
Our area office is at African Alliance Building, F1, Sani Abacha Way, Kano. Standard Union Securities Limited is a financial supermarket in terms of capital market activities. We know the importance of wealth hence we assist our numerous clients in wealth creation. <a href="aboutus.html" class="btn btn-success">Read more..</a>
                </p>
            </div>

             <!-- Policy display -->
             <div class="rows" style="font-size: medium;">
                <div class="col-md-12 " style =" text-align:center; margin: 1.6rem; color: orange" >
                    <h3>Our Policies</h3>
                    
                </div>
                <div class="col-md-3" style="font-size: medium; border-radius:5px; padding: 0px;">
                    <h3 class="color1">BUSINESS CONTINUITY PLAN</h3>
                    <a href="a12bc3d45ef67g8910hijk11121314mlo1234dcba/policies/Business_Continuity_Plan.pdf" alt="Business Continuity Plan"><h4 class="color1">Download</h4></a>
                    <p class="padP">
                      
    
                      
                    </p>
                </div>
    
                <div class="col-md-3" style="border-radius:5px; padding: 0px;">
                    <h3 class="color1">COMPLAINT MANAGEMENT POLICY</h3>
                    <a href="a12bc3d45ef67g8910hijk11121314mlo1234dcba/policies/Complaint_management.pdf" alt="Compaint Management Policy"><h4 class="color1">Download</h4></a>
                    <p class="padP">
                      
    
                      
                    </p>
                </div>
    

                <!-- Policy display -->
            <div class="rows">
                <div class="col-md-3" style="border-radius:5px; padding: 0px;">
                    <h3 class="color1">DATA PROTECTION AND PRIVACY</h3>
                    <a href="a12bc3d45ef67g8910hijk11121314mlo1234dcba/policies/Data_Protection_and_management.pdf" alt="Data Protection and Managemeny Policy"><h4 class="color1">Download</h4></a>
                    <p class="padP">
                      
    
                      
                    </p>
                </div>
    
                <div class="col-md-3" style=" background-color #f1f1f1; border-radius:5px; padding: 0px;">
                    <h3 class="color1">BEST EXECUTION POLICY</h3>
                    <a href="a12bc3d45ef67g8910hijk11121314mlo1234dcba/policies/Best_Execution_Policy.pdf" alt="Best Execution Policy""><h4 class="color1">Download</h4></a>
                    <p class="padP">
                      
    
                      
                    </p>
                </div>
    
            </div>
            </div>
            
        </div> <!-- End of the content-->
    </div>
    <div style="height:20px;"></div> <!--Space-->

    <div class="footer big">
        <!-- Footer begins here-->
        <div class="container">

            <div class="col-md-6">
                <h2 style="color:#E1E1E1;">More about our services</h2>
                <p class="footerlinks padP">
                    Our staff members are specially trained to monitor events in the market place in order to make accurate investments decisions that are highly profitable to our numerous clients. We assist our clients to monitor their investments especially the high net-worth individuals and those Nigerians in Diaspora who are time constrained. This is done by creating a NOMINEE ACCOUNTS for them.


                    <br /><br />In Standard Union Securities Limited, clients are given arrays of investment options from which to choose. Our investment principle allows the clients to have either the discretionary or non-discretionary power to decide what stocks to buy or sell on his/her behalf. Some of the options include but not limited to : Fixed Term Investments, Capital Market Investments, Government Debt Instruments, Real Estate Investments.
                </p>

            </div>

            <div class="col-md-3" >
                
                <h2 style="color:#E1E1E1;">NGX Investors Protection Fund</h2>
                <a href ="https://ngxgroup.com" target="_blank" >
                <p class="footerlinks padP">
                    
                    <img src="images/used/ngx.png" alt="facebook" style=" padding: 0px; width: 98%"></img>

                    
                </p>
            </a>
            </div>

            <div class="col-md-3">

                <!--<h2 style="color:#E1E1E1;">Business Links</h2>
                <div style="height:7px;"></div>
                <a href="http://vikotravel.com.ng" target="_parent" class="footerlinks">www.vikotravel.com.ng</a>
                <a href="http://consolidatedalliance.ng" target="_parent" class="footerlinks">www.consolidatedalliance.ng</a>

                <a href="http://wwww.bustime.com.ng" target="_parent" class="footerlinks">www.bustime.com.ng</a>

                <a href="http://www.flightstime.com.ng" target="_parent" class="footerlinks">www.flightstime.com.ng</a>
                <a href="http://vikonigeria.com" target="_parent" class="footerlinks">www.vikonigeria.com</a>
                -->

                <h2 style="color:#E1E1E1;">Contact</h2>
                <br />
                <p style=" font-weight:bold;" class="footerlinks">Telephone : +234 818 128 3000</p>
                <p style="font-weight:bold;" class="footerlinks">Email: office@standardun.com</p>
                <p style="color:#DA251C; font-weight:bold;">Social media</p>
                <a href="http://www.facebook.com/viko-sme-1660949797494538" target="_blank">
                    <img src="img/1920/facebook.png" alt="facebook" style="padding-left:0px;"></img><a>
                        <a href="http://www.twitter.com/vikosme" target="_blank">
                            <img src="img/1920/twitter.png" alt="Twitter" style="padding-left:0px;"></img><a>
                                <!--          <a href="http://www.instagram.com/vikosme" target ="_blank" >
                                              <img src="img/1920/instagram.png" alt="Instagram" style="padding-left:0px;"></img><a>
                                                  <a href="https://www.youtube.com/results?search_query=viko+sme" target ="_blank" ><img src="img/1920/youtube.jpg" alt="YouTube" style="padding-left:0px;"></img><a>
                                                      -->
                                <hr />
                                <a href="aboutus.html" class="footerlinks">aboutus</a> <span class="footerlinks">| </span><a href="signup.aspx" class="footerlinks">signup</a> <span class="footerlinks">| </span> <a href="testing.aspx" class="footerlinks">Learn</a> <span class="footerlinks">| </span> <a href="http://mail.standardun.com" target="_blank" class="footerlinks">Webmail</a>

            </div>




            <div class="col-md-12" style=" color White; text-align center; font-size small ;"><span style=" color #fff;">By using this website, you have agreed to our</span> <a href="terms.html" target="_blank">Terms</a><span style=" color #fff;"> of service</span></div>
        </div>
        <div class="container">
            <div style=" height:30px; background-color:#5f5f5f; border-radius:3px;">
                <div class="col-md-2"></div>
                <div class="col-md-4"><div style="text-align:center; color:#fff; padding-top:10px;">Copyright © 2021 Standard Union Securities Limited. </div></div>
                <div class="col-md-4"><div style="text-align:center; color:#fff; padding-top:10px;" class="footerlinks">Built by <a class="footerlinks" href="http://www.photizotechnologies.com"> Photizotechnologies.com</a></div></div>
                <div class="col-md-2"></div>

            </div>
        </div>
    </div>
    </form>
</body>
</html>