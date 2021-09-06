<%@ Page Language="VB" AutoEventWireup="false" CodeFile="pers_stage1.aspx.vb" Inherits="pers_stage1" %>

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

        function pickDate() {
            $("#txtDOB").datepicker({ dateFormat: 'yy/mm/dd' });
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
                 <h1>Step 2 of 5 (Personal Information)</h1>
             </div>
            </div> 
            <div class="col-md-12" style ="height :40px;"></div> <!--Space of 20px-->
        <div class="row" style ="padding:10px; min-height :580px;">
		 <div class="col-md-4">
			<div class="form-group">TITLE : (Mr./Mrs./Ms./Dr./Others.)
               <input class="form-control" type="text" id ="txtTitle" runat="server">
            </div>
  
                           <div class="form-group">SURNAME:
                                <input class="form-control" type="text" id="txtSurname" runat="server">
                           </div>
						   
                          <div class="form-group">FIRST NAME:
                               <input class="form-control" id="txtfName" runat="server">
                          </div>
						  
                           <div class="form-group">MIDDLE NAME:
                                 <input class="form-control" type="text" id="txtmName" runat="server" >
                           </div>
						   
                           <div class="form-group">DATE OF BIRTH (DD/MM/YY):
                            <asp:TextBox ID="txtDOB" placeholder="Your date of birth" CssClass="form-control validate[required] validate[custom[date]]" runat="server"></asp:TextBox>
                           </div>					
             <div class="form-group">GENDER:
                    <asp:DropDownList ID="drpGender" runat ="server" CssClass ="form-control">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:DropDownList>

                     </div>              
                                  
                    <div class="form-group">MARITAL STATUS:
                       
                        <asp:DropDownList ID="drpMarriageStatus" runat ="server" CssClass ="form-control">
                            <asp:ListItem>Single</asp:ListItem>
                            <asp:ListItem>Married</asp:ListItem>
                            <asp:ListItem>Divorced</asp:ListItem>
                        </asp:DropDownList>

                    </div>
                    	

				</div>
				
				<div class="col-md-4">
                    <div class="form-group">MORTHER's MAIDEN NAME:
                        <input class="form-control" type="text" id="txtmother" runat ="server" >
                     </div>              
				
                    <div class="form-group">MOBILE TELEPHONE NUMBER:
                                <input class="form-control" type="text" id="txtmobile" runat ="server" >
                           </div>	   
                    <div class="form-group">ALTERNATIVE TELEPHONE NUMBER:
	                     <input class="form-control" type="text" id="txtMobile2" runat ="server" >
	                </div>
                    <div class="form-group">EMAIL ADDRESS:
                       <input class="form-control" type="text" runat="server" id="txtEmail">
	                </div>
                          
					
                    <div class="form-group">COUNTRY:
                        <asp:TextBox runat="server" ID="drpCountry" Enabled ="false" CssClass ="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">STATE OF ORIGIN
                         <asp:TextBox runat="server" ID="drpState" Enabled ="false" CssClass ="form-control"></asp:TextBox>
                    </div>
					
                    <div class="form-group">LOCAL GOVERMENT AREA:<a href="Country_select.aspx">Change State/Country</a>
                         <asp:DropDownList ID="drpLga" runat ="server" CssClass ="form-control">
                                <asp:ListItem>Select Lg:</asp:ListItem>
                            </asp:DropDownList>
                        
                    </div>
				  </div>
                    
                                      
                 				
				<div class="col-md-4">
                    <div class="form-group"> NIGERIAN RESIDENT:
                                 <asp:DropDownList ID="drpResident" runat ="server" CssClass ="form-control">
                                <asp:ListItem >Yes</asp:ListItem>
                                <asp:ListItem >No</asp:ListItem>
                            </asp:DropDownList>
                              </div>
                           <div class="form-group">CITIZENSHIP:
                                <asp:TextBox class="form-control" type="text" id="txtciti" runat ="server"></asp:TextBox>
                           </div>
                    
                    <div class="form-group">
                  <label id="error1" class="error" runat ="server" ></label>
                  </div>

                  <!--<a href="" class="btn btn-success width">Login</a> -->
                    <asp:LinkButton ID="butSave" runat="server" CssClass="btn btn-warning btn-lg">Save & Continue</asp:LinkButton>
                    <br /><a href="pers_stage_2.aspx" id  ="butSkip">Skip to the next page</a>
				  <div style=" height:15px;"></div>
                    
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