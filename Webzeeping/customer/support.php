<!DOCTYPE html>

<head>
	<meta charset="UTF-8">
	<title>Zeeping - Form</title>
	<link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
    <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
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
	<body style=" background-color:#EEEEEE;" > 

		<div class="page-content" style=" background-color:#EEEEEE; margin: 3% 0 0 0;" >
			<div class="row" >
				<div class="col-sm-8 col-sm-offset-2" style="background-color:white">
					<br>
					<br>
					<div class="widget-header widget-header-large">
						<h3 class="widget-title grey lighter">
							<font color="green" align="center" size="6px"><strong> Submit Ticket </strong></font>
						</h3>
						<div class="widget-toolbar no-border invoice-info">
							<img src="http://zeeping.com/image/common/logo.png" style="height:49.2px;width:90.5px">
						</div>					
					</div>
					<br>
					<br>				

					<div class="widget-box transparent">
						<form class="form-horizontal" role="form" form id="frmSupport" action="./action/getSupport.php" method="post" onsubmit="return validateForm()">
						
							<div class="form-group">
								<label class="col-sm-3 control-label no-padding-right" for="form-field-1"> <strong>Your Name </strong></label>
								<div class="col-sm-9">
									<input type="text" placeholder="Username" name="name" id="yourname" >
								</div>
							</div>
							
							<div class="form-group">
								<label class="col-sm-3 control-label no-padding-right" for="form-field-1"><strong> Your Email </strong></label>
								<div class="col-sm-9">
									<input type="text" name="mail" id="email" placeholder="Zeeping@gmail.com" class="col-xs-10 col-sm-5">
								</div>
							</div>
							
							<div class="form-group">
								<label class="col-sm-3 control-label no-padding-right" for="form-field-1"><strong> Number Phone </strong></label>
								<div class="col-sm-9">
									<input type="text" name="phonenumber" id="phonenumber" placeholder="712-899-3993" class="col-xs-10 col-sm-5">
								</div>
							</div>
							<br>
							
							<div class="form-group">
								<label class="col-sm-3 control-label no-padding-right" for="form-field-1" ><strong> Your Message </strong></label>
								<div class="col-sm-9">
									<textarea class="input-xxlarge" id="message" name="message" placeholder="Your Message..." rows="6" ></textarea>
								</div>
							<div class="col-sm-3"></div>
							<div class="col-sm-9">
								<form >
									<div class="g-recaptcha" id="capcharid" data-sitekey="6Lei7CQUAAAAAL0-FWw-jcfV7V9wTRbZ7uw9QGOX" data-callback="verifyCallback"></div>
								</form>
							
							</div>
							 <input type="hidden" name="isaction" value="1" ></input>
							<div class="col-md-offset-3 col-md-9">
							<br>
							<button class="btn btn-info" type="submit" name="action" >
								<i class="ace-icon fa fa-check bigger-110"></i>
								Submit
							</button>
							<br>
							<br>
							<br>
							</div>
						</form>	
					</div>
				</div>
			</div>
		</div>

    </div>
</body>
