<?php 
    if(!isset($_POST["user"]))
    {
        header('HTTP/1.0 404 Not Found');
        return;
    }
    include('../config/config.php'); 
?>
<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>ConfirmPass - Zeeping</title>
        
		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->

		<!-- text fonts -->
		<link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

		<!-- ace styles -->
		<link rel="stylesheet" href="assets/css/ace.min.css" class="ace-main-stylesheet" id="main-ace-style" />

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" class="ace-main-stylesheet" />
		<![endif]-->
		<link rel="stylesheet" href="assets/css/ace-skins.min.css" />
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

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
	
<body class="body-confirmpass">

   
<div class="page-content">
						
    <div class="row">
												
									<div class="col-sm-7 col-sm-offset-2" style="padding-top:1%" style="background-color:#fff">
									     <img  class="col-sm-offset-5" src="http://zeeping.com/image/common/logo.png" style="height:60px;width:110.37px"></img>
									    
									    <div class="alert alert-success" style="margin-top:2%">
																

																<strong >
																	<i class="ace-icon fa fa-check"></i>
																	<span style="font-size:1.312em;margin:auto" >Successfully.</span>
																	
																</strong>
                                                                
																
																<br>
															</div>
											
										<div class="widget-box ">
											

											<div class="widget-body" >
												<div class="widget-main " >
													<div class="row" style="padding:0% 2% 2% 2%">
														<h3  >Please check your email inbox.</h3>
														
														<span>An email has been sent to your email address. It can take a few minutes before you have it in your inbox. </span>
														
														<h3>Didn't get the email?</h3>
														<ul  style="list-style-type: none">
														    <li>
														        1. Wait a few minutes.
														    </li>
														    <li>
														        2. Check your junk mail or spam mail folder.
														    </li>
														    <li>
														        3. Still didn't get the email? <button onclick="onForgotClick()"style="background-color:Transparent;background-repeat:no-repeat;border: none;cursor:pointer;overflow:hidden;outline:none"> <span style="color:blue;border-bottom: 2px groove blue;">Resend the activation link</span></button>
														    </li>
														    <li>
														        4. Still having no luck with the email? Send an email to zeepingshop@gmail.com with your username and "reset zeeping account" in the subject field.

														    </li>
														    
														</ul>
														<h3>Having problems or questions?</h3>
														<span>If you don’t know how to proceed please don’t hesitate to contact our support team via <a href="/customer/support.php">HERE!!!</a></span>
														
														

														
													</div><!-- /.row -->

													

												


													
												</div>
											</div>
										</div>
									</div>
								</div>
								</div>

 <style>
   .img-thumbnail, body {
        background-color:#f2f2f2;
}
.page-content {
    background-color: #f2f2f2;
    position: relative;
    margin: 0;
    padding: 8px 20px 24px;
}
 </style>
<script src="assets/js/jquery-3.2.1.min.js"></script>
<script>
    function onForgotClick()
	{
	    $.post("http://zeeping.com/customer/action/forgotaction.php",
        {
            email: "<?php echo $_POST["user"]; ?>",
            submit: "1"
        },
        function(data, status){
            alert("Success");
        });
        return false;
	}
</script>

</body>
</html>