<html lang="en"><head>
	<meta charset="UTF-8">
	<title>Zeeping - Form</title>
	<link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">

	<script src='https://www.google.com/recaptcha/api.js'></script>
	<script>
		var hoang = false;
		function validateForm() {
		    if (hoang == false) alert("Are you bot ?");
			return hoang;
		}
		function verifyCallback( response ) {
			hoang = true;
		};

	</script>
	<meta name="robots" content="noindex,follow" />


		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Form Elements - Ace Admin</title>

		<meta name="description" content="Common form elements and layouts" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.2.0/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->
		<link rel="stylesheet" href="assets/css/jquery-ui.custom.min.css" />
		<link rel="stylesheet" href="assets/css/chosen.min.css" />
		<link rel="stylesheet" href="assets/css/datepicker.min.css" />
		<link rel="stylesheet" href="assets/css/bootstrap-timepicker.min.css" />
		<link rel="stylesheet" href="assets/css/daterangepicker.min.css" />
		<link rel="stylesheet" href="assets/css/bootstrap-datetimepicker.min.css" />
		<link rel="stylesheet" href="assets/css/colorpicker.min.css" />
		
		
		<script src='https://www.google.com/recaptcha/api.js'></script>

		<!-- text fonts -->
		<link rel="stylesheet" href="assets/fonts/fonts.googleapis.com.css" />

		<!-- ace styles -->
		<link rel="stylesheet" href="assets/css/ace.min.css" class="ace-main-stylesheet" id="main-ace-style" />

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" class="ace-main-stylesheet" />
		<![endif]-->

		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->
		<script src="assets/js/ace-extra.min.js"></script>

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
	</head>

<body >
	<div class="page-content">
        <div class="row">				
    		<div class="col-sm-10 col-sm-offset-1">
    									   
    			<div class="widget-box transparent">
    											
    				<div class="widget-body">
    												
    					<div class="row">
    							<div class="col-xs-12 col-sm-12 pricing-box">
                                    <div class="widget-box widget-color-dark">
                                        <div class="widget-header">
                                            
                                        	<div class="widget-header widget-header-large">
                                        	    <div class="widget-toolbar no-border invoice-info">
                        							<img src="http://zeeping.com/image/common/logo.png" style="width:110px;height:70px">
                        						</div>
                        						<h3 class="widget-title grey lighter">
                        							<font color="green" align="center" size="6px"><strong> Submit Ticket </strong></font>
                        						</h3>
                        					</div>
                                        </div>
                                        <div class="widget-body">
                            			    <div class="col-sm-6">
                    							<ul class="list-unstyled spaced">
                    								<li>
                    								    <p><font size="4px"><strong>Your Name </strong></font></p>
                    								    <input type="text" name="mail" id="email" placeholder="Your Name" class="input-xxlarge">
                    								</li>
                               								
                    								<li>
                    								    <p><font size="4px"><strong>Your Email </strong></font></p>
                    								    <input type="text" name="mail" id="email" placeholder="Zeeping@gmail.com" class="input-xxlarge">
                    								</li>
                    								
                    								<li>
                     								    <p><font size="4px"><strong>Phone Number </strong></font></p>
    													<div class="input-group">
        													<span class="input-group-addon">
    														<p style="font-size:10px">&#9742;</p>
    														</span>
    														<input type="tel" id="phone" name="phone" placeholder="Number Phone" class="col-xs-8">
    													</div>
    		          								</li>
                            								
                                                </ul>
                     					    </div><!-- /.col -->
                                    					
                           				    <div class="col-sm-6">   
                            				    <ul class="list-unstyled spaced">
                                					<li>
                                                        <p><font size="4px"><strong>Your Name </strong></font></p> 
                                 						<textarea class="input-xlarge" name="comment" id="comment" placeholder="Your Message..." style="margin: 0px; width: 600px; height: 195px;"></textarea>
                            						</li>
                                                </ul>
                            	            </div>
                                        </div>

                							<div class="col-sm-9">
                								<form >
                									<div class="g-recaptcha" id="capcharid" data-sitekey="6Lei7CQUAAAAAL0-FWw-jcfV7V9wTRbZ7uw9QGOX" data-callback="verifyCallback"></div>
                								</form>
                                        	</div> 									
        									<div>
        									    <form name="frmBuyDirect" action="./action/confirminfoaction.php" method="post" >
        										    <button class="btn btn-block btn-primary" type="submit" name="submit" value="Next Step">
                                          		    <input type="hidden" id="style_id" name="style_id" value=""></input>
                                                    <input type="hidden" id="color_id" name="color_id" value=""></input>
                                                    <?php echo'<input type="hidden" name="url" value="'.$_POST["product_link"].'"></input>'; ?>
        											<i class="ace-icon fa fa-shopping-cart bigger-110" ></i>
        											<span >Submit</span>
        										</form>

                							
                							</div>                                            
    								    </div>
    							    </div>
    					        </div>
    														
                		</div><!-- /.row -->
    				</div>
    			</div>
    		</div>
    	</div>
    </div>
	
	

</body>
</html>