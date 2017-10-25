<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Confirm - Zeeping</title>

		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
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
		<?php include('../config/config.php'); ?>
	</head>


<body>
  <?php
    if(!isset($_POST["g"]))
    {
        echo '404 ERROR';
        return;
    }
    if(isset($_POST["g"]))
    {
        if(!isGuid($_POST["g"]))
        {
            echo '404 ERROR';
            return;
        }
    }
    
    $Order = getOrder($_POST["g"]);
?>
    
        <div class="page-content">
			<div class="row">			
											<div id="fuelux-wizard-container">
												<div>
													<ul class="steps">
														<li data-step="1" class="active">
															<span class="step">1</span>
															<span class="title">Delivery</span>
														</li>

														<li data-step="2"  class="active">
															<span class="step">2</span>
															<span class="title">Confirmation</span>
														</li>

														<li data-step="3">
															<span class="step">3</span>
															<span class="title">Checkout</span>
														</li>

														<li data-step="4">
															<span class="step">4</span>
															<span class="title">Finish</span>
														</li>
													</ul>
													
												</div>

												
                                                <div class="col-sm-10 col-sm-offset-1" style="float:None">
                                                    
                                                    <div class="widget-header widget-header-large">
												        <h3 class="widget-title grey lighter">
													<img src="http://zeeping.com/image/common/logo.png" style="height:49.2px;width:90.5px;margin-right:35%"></img>
													<b style="font-size:1.325em">Confirmation </b>
												        </h3>

												    <div class="widget-toolbar no-border invoice-info">
													<span class="invoice-info-label">Invoice:</span>
													<span class="red"><?php echo "ZO" . sprintf("%'.07d\n", $Order["order_id"]); ?></span>

													<br>
													<span class="invoice-info-label">Date:</span>
													<span class="blue"><?php echo date("d/m/Y", strtotime($Order["createDate"])); ?></span>
												    </div>

												    
												
											</div>
												<div class="step-content pos-rel">
													<div class="step-pane active" data-step="2">
														<h3 class="lighter block green">Enter the following information</h3>

														

														<form class="form-horizontal col-sm-offset-2"  id="frmConfirmationNext" method="post" novalidate="novalidate" action="./action/confirmaction.php">
															<div class="form-group ">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="email">Email Address:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="email" name="email" id="email" class="col-xs-12 col-sm-6" placeholder="E-Mail" value="<?php echo $Order["email"]; ?>" required />
																	</div>
																</div>
															</div>

															<div class="space-2"></div>

															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="firstname" >First Name:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="firstname" id="firstname" class="col-xs-12 col-sm-6" placeholder="First Name" value="<?php echo $Order["firstname"]; ?>" required/>
																	</div>
																</div>
															</div>

															<div class="space-2"></div>

															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="lastname">Last Name:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="lastname" id="lastname" class="col-xs-12 col-sm-6" placeholder="Last Name" value="<?php echo $Order["lastname"]; ?>" required />
																	</div>
																</div>
															</div>

                                                            <div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="address">Street Address:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="street_address" id="street_address" class="col-xs-12 col-sm-6" placeholder="Street Address" value="<?php echo $Order["street_address"]; ?>" required />
																	</div>
																</div>
															</div>
															
															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="apt">Apt/Suite/Other:</label> 

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="apt_suite_other" id="apt_suite_other" class="col-xs-12 col-sm-6" placeholder="Apt/Suite/Other" value="<?php echo $Order["apt_suite_other"]; ?>">
																	</div>
																</div>
															</div>
															
															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="city">City:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="city" id="city" class="col-xs-12 col-sm-6" placeholder="City" value="<?php echo $Order["city"]; ?>" required />
																	</div>
																</div>
															</div>
															
															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="province">Province/State:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="province" id="province" class="col-xs-12 col-sm-6" placeholder="Province/State" value="<?php echo $Order["province"]; ?>" required />
																	</div>
																</div>
															</div>
															
															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="postalcode">Postal Code:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="clearfix">
																		<input type="text" name="postal_code" id="postal_code" class="col-xs-12 col-sm-6" placeholder="Postal Code" value="<?php echo $Order["postal_code"]; ?>" required />
																	</div>
																</div>
															</div>
															
															<div class="hr hr-dotted"></div>

															
															<div class="space-2"></div>

															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="phone">Phone Number:</label>

																<div class="col-xs-12 col-sm-9">
																	<div class="input-group">
																		<span class="input-group-addon">
																			<i class="ace-icon fa fa-phone"></i>
																		</span>

																		<input type="tel" id="phone_number" name="phone_number" value="<?php echo $Order["phone_number"]; ?>" required />
																	</div>
																</div>
															</div>

															<div class="space-2"></div>

															
															<div class="hr hr-dotted"></div>

															<div class="form-group">
																<label class="control-label col-xs-12 col-sm-3 no-padding-right" for="state">State</label>
																
                                                            <div class="col-xs-12 col-sm-9">
																<select class="country-select" name="country_id" id="country_id" required />
                                            					    <?php
                                            					        $CountryList = getCountry();
                                            					        foreach ($CountryList as $country)
                                            					        {
                                            					            if($Order["country_id"] == $country["country_id"])
                                            					            {
                                            					               echo '<option class="country" value="'. $country["country_id"] .'" selected>'. $country["country_name"] .'</option>
                                            					                '; 
                                            					            }
                                            					            else
                                            					            {
                                            					                echo '<option class="country" value="'. $country["country_id"] .'">'. $country["country_name"] .'</option>
                                            					                ';
                                            					            }
                                            					        }
                                            					    ?>
                                                                </select> 
															</div>
														</div>
														<input type="hidden" name="g" value="<?php echo $Order["guid"]; ?>"></input>
														<input type="hidden" name="isaction" value="1"></input>
														</form>
													</div>
												</div>
												<hr>
											</div>

										
											</div>
											<div class="col-sm-10 col-sm-offset-1" style="float:None">
                                            <div class="wizard-actions">
                                                
                                                <form class="form-horizontal" id="frmConfirmationPre" method="post" novalidate="novalidate" action="./delivery.php">
                                                    <input type="hidden" name="g" value="<?php echo $Order["guid"]; ?>"></input>
                                                    <input type="hidden" name="isaction" value="1"></input>
                                                </form>
												<button class="btn btn-prev" tyle="submit" form="frmConfirmationPre" >
													<i class="ace-icon fa fa-arrow-left"></i>
													Prev
												</button>
												

												<button class="btn btn-success btn-next" data-last="Finish" tyle="submit" form="frmConfirmationNext">
													Next
													
												<i class="ace-icon fa fa-arrow-right icon-on-right"></i></button>
											</div>
											<div class="space-6"></div>
													<div class="well">
														Thank you for choosing Zeeping Shirt products.
				We believe you will be satisfied by our product.
													</div>
											</div>
											
											</div>
											
										
										<!-- basic scripts -->
    </div>
		<!--[if !IE]> -->
		<script src="assets/js/jquery-2.1.4.min.js"></script>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets/js/jquery.1.11.1.min.js"></script>
<![endif]-->

		<!--[if !IE]> -->
		<script type="text/javascript">
			window.jQuery || document.write("<script src='assets/js/jquery.min.js'>"+"<"+"/script>");
		</script>

		<!-- <![endif]-->

		<!--[if IE]>
<script type="text/javascript">
 window.jQuery || document.write("<script src='assets/js/jquery1x.min.js'>"+"<"+"/script>");
</script>
<![endif]-->
		<script type="text/javascript">
			if('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>"+"<"+"/script>");
		</script>
		<script src="assets/js/bootstrap.min.js"></script>

		<!-- page specific plugin scripts -->
		<script src="assets/js/wizard.min.js"></script>
		<script src="assets/js/jquery.validate.min.js"></script>
		<script src="assets/js/jquery-additional-methods.min.js"></script>
		<script src="assets/js/bootbox.js"></script>
		<script src="assets/js/jquery.maskedinput.min.js"></script>
		<script src="assets/js/select2.min.js"></script>

		<!-- ace scripts -->
		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>
		<script type="text/javascript">
			jQuery(function($) {
			
				$('[data-rel=tooltip]').tooltip();
			
				$(".select2").css('width','200px').select2({allowClear:true})
				.on('change', function(){
					$(this).closest('form').validate().element($(this));
				}); 
			
			
				$('#frmConfirmationNext').validate({
					errorElement: 'div',
					errorClass: 'help-block',
					focusInvalid: false,
					ignore: "",
					rules: {
						email: {
							required: true,
							email:true
						},
						firstname: {
							required: true
						},
						lastname: {
							required: true
						},
						street_address: {
							required: true
						},
						
						city: {
							required: true
						},
						province: {
							required: true
						},
						postal_code: {
							required: true,
						},
						country_id: {
							required: true,
						},
						phone_number: {
							required: true,
						}
					},
			
					messages: {
						email: {
							required: "Please provide a valid email.",
							email: "Please provide a valid email."
						},
						state: "Please choose state",
					},
			
			
					highlight: function (e) {
						$(e).closest('.form-group').removeClass('has-info').addClass('has-error');
					},
			
					success: function (e) {
						$(e).closest('.form-group').removeClass('has-error');//.addClass('has-info');
						$(e).remove();
					},
			
					errorPlacement: function (error, element) {
						if(element.is('input[type=checkbox]') || element.is('input[type=radio]')) {
							var controls = element.closest('div[class*="col-"]');
							if(controls.find(':checkbox,:radio').length > 1) controls.append(error);
							else error.insertAfter(element.nextAll('.lbl:eq(0)').eq(0));
						}
						else if(element.is('.select2')) {
							error.insertAfter(element.siblings('[class*="select2-container"]:eq(0)'));
						}
						else if(element.is('.chosen-select')) {
							error.insertAfter(element.siblings('[class*="chosen-container"]:eq(0)'));
						}
						else error.insertAfter(element.parent());
					},
			
					submitHandler: function (form) {
					    return true;
					},
					invalidHandler: function (form) {
					}
				});


				
			})
		</script>

</body>
</html>