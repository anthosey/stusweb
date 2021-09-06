<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pers_stage_2_1.aspx.vb" Inherits="pers_stage_2_1" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styles/mystyle.css">
    <link rel="stylesheet" href="styles/mycss.css">
    <link rel="stylesheet" type="text/css" href="css/sweetalert.css">

    <!--<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>

    -->

    <link rel="stylesheet" href="bootstrap/css/bootstrap.min.css">
    <script src="jquery/jquery-1.9.1.min.js"></script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    <script src="js/sweetalert.min.js"></script>
    <title>Standard Union Securities Limited</title>

    <style>
        a:hover {
            color: orange;
        }

        .height{
            height :60px;
            vertical-align :middle  ;
        }

        
    </style>

    <script type ="text/javascript" >
        function feedback(mtitle, msg, types) {
            //alert("User already exists with either email or mobile number");
            swal(mtitle, msg, types);
        }
    </script>
</head>
<body style="padding:0px; margin:0px; font-family:Arial, Verdana;background-color:#fff;">
<form id ="form1" runat ="server" >

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
                            <li><a href="contactus.aspx">CONTACT</a></li>
                            <li><a href="https://standardunion.xcloudintegra.com/login.aspx?ReturnUrl=%2fdefault.aspx" target="_blank" ID="butLogin">OMS Login</a></li>
                            <li><asp:Linkbutton runat ="server" ID="butLogout">SIGN OUT</asp:Linkbutton></li>
                            
                           
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

    <!-- End of nav bar -->

<div style="height:20px;"></div> <!--Space-->

    <div class="container" style ="background-color :#f1f1f1; border-radius :20px;">
        <marquee style="background-color :red;font-size :16px; color :#fff; padding :5px; font-weight :bold;">Please make sure you always provide us with accurate information in order to fast-track your account openning process. Thank you for choosing Standard Union Securities Limited as your portfolio manager.</marquee>
        <!--begining of the body content-->
        

            <div class="col-md-12" style ="height :40px;"></div> <!--Space of 20px-->
            
            <div class="col-md-12" style =" background-color :#E5E5E5; text-align :center; border-radius:5px;">
             <div style ="background-color :#E5E5E5; color:orangered;">
                 <h1>Step 4 of 5 (KYC 2 : File Uploads)</h1>
             </div>
            </div> 
            <div class="col-md-12" style ="height :40px;"></div> <!--Space of 20px-->
        <div class="row" style ="padding:10px; min-height :580px;">
		 <div class="col-md-4">
		                               <div class="form-group">UPLOAD YOUR PASSPORT PHOTOGRAPH:
                                            <asp:Image ID="impPrev" runat="server" Height="120px" Width="140px"  CssClass="img-responsive" />
                                            <asp:FileUpload ID="FileUpload1" runat="server" onchange="ShowPreview(this)" />
                                            <asp:LinkButton ID="butPassport" runat="server" CssClass="btn btn-default">Upload Now</asp:LinkButton>
                                         </div> 
										 
                                         <div class="form-group"><span id="lblIdentity">UPLOAD YOUR SIGNATURE</span>
                                             <asp:Image ID="imgSign" runat="server" Height="120px" Width="140px"  CssClass="img-responsive" />
                                              <asp:FileUpload ID="FileUpload2" runat="server" onchange="ShowPreview(this)" />
                                             <asp:LinkButton ID="btnId" runat="server" CssClass="btn btn-default">Upload Now</asp:LinkButton>
                                         </div>
										 
                                         
	                
         	
	                            </div>
				
		 <div class="col-md-4">
                            				
             <div class="form-group">ADDRESS CONFIRMATION: <br />
                 <span id="spnConfirm" runat ="server"></span>
                                            <asp:Image ID="imgAddy" runat="server" Height="120px" Width="140px"  CssClass="img-responsive" />
                                            <asp:FileUpload ID="FileUpload3" runat="server" onchange="ShowPreview(this)" />
                                            <asp:LinkButton ID="butAddyConfirm" runat="server" CssClass="btn btn-default">Upload Now</asp:LinkButton>
                                         </div> 
             <div class="form-group">MEANS OF IDENTIFICATION:<br />
                 <span id="spnID" runat ="server"></span>
                                            <asp:Image ID="imgId" runat="server" Height="120px" Width="140px"  CssClass="img-responsive" />
                                            <asp:FileUpload ID="FileUpload4" runat="server" onchange="ShowPreview(this)" />
                                            <asp:LinkButton ID="butID" runat="server" CssClass="btn btn-default">Upload Now</asp:LinkButton>
                                         </div> 
             
				  <div style=" height:15px;"></div>
         </div> 
            
            <div class ="col-md-4">
       <div class="form-group">BIRTH CERTIFICATE / SWORN:
                                            <asp:Image ID="imgBirth" runat="server" Height="120px" Width="140px"  CssClass="img-responsive" />
                                            <asp:FileUpload ID="FileUpload5" runat="server" onchange="ShowPreview(this)" />
                                            <asp:LinkButton ID="butBirth" runat="server" CssClass="btn btn-default">Upload Now</asp:LinkButton>
                                         </div>   
                  <!--<a href="" class="btn btn-success width">Login</a> -->
                    <asp:LinkButton ID="butBack" runat="server" CssClass="btn btn-default btn-lg">Go back</asp:LinkButton>&nbsp;<asp:LinkButton ID="butCreate" runat="server" CssClass="btn btn-warning btn-lg">Save & Continue</asp:LinkButton>
                <br /><a href="pers_stage_3.aspx" id  ="butSkip">Skip to the next page</a>
            </div>
               </div>
            </div>

            
         <!-- End of the content-->
   
    <div style="height:20px;"></div> <!--Space-->

    <div class="footer big">
        <!-- Footer begins here-->
        <div class="container">

            <div class="col-md-9">
                <h2 style="color:#E1E1E1;">More about our services</h2>
                <p class="footerlinks padP">
                    Our staff members are specially trained to monitor events in the market place in order to make accurate investments decisions that are highly profitable to our numerous clients. We assist our clients to monitor their investments especially the high net-worth individuals and those Nigerians in Diaspora who are time constrained. This is done by creating a NOMINEE ACCOUNTS for them.


                    <br /><br />In Standard Union Securities Limited, clients are given arrays of investment options from which to choose. Our investment principle allows the clients to have either the discretionary or non-discretionary power to decide what stocks to buy or sell on his/her behalf. Some of the options include but not limited to : Fixed Term Investments, Capital Market Investments, Government Debt Instruments, Real Estate Investments.
                </p>

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
                <a href="http://www.facebook.com/viko-sme-1660949797494538" target ="_blank" >
                    <img src="img/1920/facebook.png" alt="facebook" style="padding-left:0px;"></img><a>
                        <a href="http://www.twitter.com/vikosme" target ="_blank" >
                            <img src="img/1920/twitter.png" alt="Twitter" style="padding-left:0px;"></img><a>
                      <!--          <a href="http://www.instagram.com/vikosme" target ="_blank" >
                                    <img src="img/1920/instagram.png" alt="Instagram" style="padding-left:0px;"></img><a>
                                        <a href="https://www.youtube.com/results?search_query=viko+sme" target ="_blank" ><img src="img/1920/youtube.jpg" alt="YouTube" style="padding-left:0px;"></img><a>
                                            -->
                <hr />
                <a href="aboutus.html" class="footerlinks">aboutus</a> <span class="footerlinks">| </span><a href="signup.aspx" class="footerlinks">signup</a> <span class="footerlinks">| </span> <a href="testing.aspx" class="footerlinks">Learn</a> <span class="footerlinks">| </span> <a href="http://mail.standardun.com" target ="_blank"  class="footerlinks">Webmail</a>

            </div>

            


            <div class="col-md-12" style=" color :White; text-align :center; font-size :small ;"><span style=" color :#fff;">By using this website, you have agreed to our</span> <a href="terms.html" target ="_blank" >Terms</a><span style=" color :#fff;"> of service</span></div>
        </div>
        <div class="container">
            <div style=" height:30px; background-color:#5f5f5f; border-radius:3px;">
                <div class="col-md-2"></div>
                <div class="col-md-4"><div style="text-align:center; color:#fff; padding-top:10px;">Copyright © 2018 Standard Union Securities Limited. </div></div>
                <div class="col-md-4"><div style="text-align:center; color:#fff; padding-top:10px;" class="footerlinks">Built by <a class="footerlinks" href="http://www.photizotechnologies.com"> Photizotechnologies.com</a></div></div>
                <div class="col-md-2"></div>

            </div>
        </div>
    </div>
    </form>
</body>
</html>