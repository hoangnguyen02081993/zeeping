<?php
    if(!isset($_POST["g"]))
    {
        return;
    }
?>
<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Finish - Zeeping</title>

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
		<?php 
		    include('../config/config.php');
		    $Order = getOrder($_POST["g"]);
		    $Countrys = getCountry();
		?>
	</head>
	
<body class="body-finish">

   
<div class="page-content">
						
    <div class="row">
												<div>
													<ul class="steps">
														<li data-step="1" class="active">
															<span class="step">1</span>
															<span class="title">Delivery</span>
														</li>

														<li data-step="2" class="active">
															<span class="step">2</span>
															<span class="title">Confirmation</span>
														</li>

														<li data-step="3" class="active">
															<span class="step">3</span>
															<span class="title">Checkout</span>
														</li>

														<li data-step="4" class="active">
															<span class="step">4</span>
															<span class="title">Finish</span>
														</li>
													</ul>
												</div>
									<div class="col-sm-10 col-sm-offset-1">
									    <div class="widget-header widget-header-large">
												<h3 class="widget-title grey lighter">
													<img src="http://zeeping.com/image/common/logo.png" style="height:49.2px;width:90.5px;margin-right:35%"></img>
													<b style="font-size:1.325em">Finish </b>
												</h3>
												

												<div class="widget-toolbar no-border invoice-info">
													<span class="invoice-info-label">Invoice:</span>
													<span class="red"><?php echo "ZO" . sprintf("%'.07d\n", $Order["order_id"]); ?></span>

													<br>
													<span class="invoice-info-label">Date:</span>
													<span class="blue"><?php echo date("d/m/Y", strtotime($Order["createDate"])); ?></span>
												</div>

												<div class="widget-toolbar hidden-480">
													<a href="#">
														<i class="ace-icon fa fa-print"></i>
													</a>
												</div>
											</div>
											
										<div class="widget-box transparent">
											

											<div class="widget-body">
												<div class="widget-main ">
													<div class="row">
														<h2 class="col-sm-offset-3" style="margin-top:-0.2%">Thank you, your order has been place.</h2>
														
														<span class="col-sm-offset-3">We've sent you an e-mail confirmation</span>
														<br>
														<br>
														<div class="row rcorners2 col-sm-5 col-sm-offset-3" style="padding-left:-2%">
														<span >1 item will be delivered to <?php echo $Order["firstname"] . " " . $Order["lastname"]; ?> at <?php echo $Order["street_address"]. ", " . $Order["city"] . ", " . getObjbyCondition($Countrys, "country_id", $Order["country_id"])["country_name"]; ?>
                                                            <img src="http://zeeping.com/image/common/logo.png" style="height:30px;width:55.2px"></img> </span>
                                                            <br>
                                                            <br>
                                                        <span >Estimated delivery:</span> <b><span style="color:#00FF33"><?php echo date("d M y", strtotime("+7 days",strtotime($Order["createDate"]))) . " - " . date("d M y", strtotime("+12 days",strtotime($Order["createDate"]))); ?></span></b>
														</div>

														
													</div><!-- /.row -->

													<div class="space"></div>

													<div class="hr hr8 hr-double hr-dotted"></div>

													<div class="row">
														<div class="wizard-actions">
    														
															<button class="btn btn-success btn-next" data-last="Finish" >
															<a class="zeeping-home" href="http://zeeping.com">Continue Shopping</a>
															<i class="ace-icon fa fa-arrow-right icon-on-right"></i>
															</button>
											            </div>
														<div class="col-sm-7 pull-left"> Extra Information </div>
													</div>

													<div class="space-6"></div>
													<div class="well">
														Thank you for choosing Zeeping Shirt products.
				We believe you will be satisfied by our product.
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
								</div>

 <style>
    .rcorners2 {
    border-radius: 25px;
    border: 2px solid #73AD21;
    padding: 20px; 
    
}
    a.zeeping-home{
        color:#fff;
        text-decoration: none;
    }
    .body-finish {
    background-color: #fff;
    padding-bottom: 0;
    font-family: 'Open Sans';
    font-size: 13px;
    color: #393939;
    line-height: 1.5;
}
 </style>


</body>
</html>