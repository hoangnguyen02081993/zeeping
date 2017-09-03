<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Dashboard - Zeeping User</title>

		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

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
		<?php include('../config/config.php'); ?>
	</head>
	
<body>
    <?php
        if(!isset($_POST["g"]))
        {
            echo '404 ERROR';
            return;
        }
        else if(!isGuid($_POST["g"]))
        {
            echo '404 ERROR';
            return;
        }
        else if(!IsHaveOrder($_POST["g"]))
        {
            echo '404 ERROR';
            return;
        }
        $OrderInfo = getOrder($_POST["g"]);
        $style = getStylebyId($OrderInfo["style_id"]);
        $size = getSizes('where `size_id` = \'' . $OrderInfo["size_id"] . '\'');
        $country = getCountrybyId($OrderInfo["country_id"]);
        $product = getProductbyId($OrderInfo["product_id"]);
        $color = getColorbyId($OrderInfo["color_id"]);
        $promosion = getPromosionbyUser($OrderInfo["username"]);
        $testpaypal = getIsTestPayPal();
    ?>
<div class="page-content">
						<div class="ace-settings-container" id="ace-settings-container">
							<div class="btn btn-app btn-xs btn-warning ace-settings-btn" id="ace-settings-btn">
								<i class="ace-icon fa fa-cog bigger-130"></i>
							</div>

							<div class="ace-settings-box clearfix" id="ace-settings-box">
								<div class="pull-left width-50">
									<div class="ace-settings-item">
										<div class="pull-left">
											<select id="skin-colorpicker" class="hide">
												<option data-skin="no-skin" value="#438EB9">#438EB9</option>
												<option data-skin="skin-1" value="#222A2D">#222A2D</option>
												<option data-skin="skin-2" value="#C6487E">#C6487E</option>
												<option data-skin="skin-3" value="#D0D0D0">#D0D0D0</option>
											</select><div class="dropdown dropdown-colorpicker">		<a data-toggle="dropdown" class="dropdown-toggle" href="#"><span class="btn-colorpicker" style="background-color:#438EB9"></span></a><ul class="dropdown-menu dropdown-caret"><li><a class="colorpick-btn selected" href="#" style="background-color:#438EB9;" data-color="#438EB9"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#222A2D;" data-color="#222A2D"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#C6487E;" data-color="#C6487E"></a></li><li><a class="colorpick-btn" href="#" style="background-color:#D0D0D0;" data-color="#D0D0D0"></a></li></ul></div>
										</div>
										<span>&nbsp; Choose Skin</span>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-navbar">
										<label class="lbl" for="ace-settings-navbar"> Fixed Navbar</label>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-sidebar">
										<label class="lbl" for="ace-settings-sidebar"> Fixed Sidebar</label>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-breadcrumbs">
										<label class="lbl" for="ace-settings-breadcrumbs"> Fixed Breadcrumbs</label>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-rtl">
										<label class="lbl" for="ace-settings-rtl"> Right To Left (rtl)</label>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-add-container">
										<label class="lbl" for="ace-settings-add-container">
											Inside
											<b>.container</b>
										</label>
									</div>
								</div><!-- /.pull-left -->

								<div class="pull-left width-50">
									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-hover">
										<label class="lbl" for="ace-settings-hover"> Submenu on Hover</label>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-compact">
										<label class="lbl" for="ace-settings-compact"> Compact Sidebar</label>
									</div>

									<div class="ace-settings-item">
										<input type="checkbox" class="ace ace-checkbox-2" id="ace-settings-highlight">
										<label class="lbl" for="ace-settings-highlight"> Alt. Active Item</label>
									</div>
								</div><!-- /.pull-left -->
							</div><!-- /.ace-settings-box -->
						</div><!-- /.ace-settings-container -->

						<div class="row">
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->
								<div class="space-6"></div>

								<div class="row">
									<div class="col-sm-10 col-sm-offset-1">
										<div class="widget-box transparent">
											<div class="widget-header widget-header-large">
												<h3 class="widget-title grey lighter">
													<i class="ace-icon fa fa-leaf green"></i>
													Customer Invoice
												</h3>

												<div class="widget-toolbar no-border invoice-info">
													<span class="invoice-info-label">Invoice:</span>
													<span class="red">#121212</span>

													<br>
													<span class="invoice-info-label">Date:</span>
													<span class="blue">04/04/2014</span>
												</div>

												<div class="widget-toolbar hidden-480">
													<a href="#">
														<i class="ace-icon fa fa-print"></i>
													</a>
												</div>
											</div>

											<div class="widget-body">
												<div class="widget-main padding-24">
													<div class="row">
														<div class="col-sm-6">
															<div class="row">
																<div class="col-xs-11 label label-lg label-info arrowed-in arrowed-right">
																	<b>Company Info</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled spaced">
																	<li> 
																		<div name="img-blackground" id="img-background" style="width:170px;height:200px">
                                                                        <div name="img-style" id="img-style" style="width:170px;height:200px;background-size:cover">
                                                                            <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                                                                        </div> 
                                                                    </div>
																	</li>
																	<li> 
																		 <div style="font-size:20px">
																		    <div class="order-summary-infor-name"> <?php echo $product["product_title"]; ?> </div>
																		 </div>
																		  
																	</li>
																	<li> 
																		 <div style="font-size:20px">
																		    <div style="color:#b8bdc5"> <?php echo $size[0]["size_name"] . ' - ' . $color["color_name"]; ?> </div>
																		 </div>
																		  
																	</li>

																	<li> 
																		 <div style="font-size:20px">
																		  Shipping
																		  </div>
																		  
																	</li>

																	<li>
																		<div style="font-size:20px">
																		Sub-total
																		</div>
																	</li>
																	
																</ul>
															</div>
														</div><!-- /.col -->

														<div class="col-sm-6">
															<div class="row">
																<div class="col-xs-11 label label-lg label-success arrowed-in arrowed-right">
																	<b>Customer Info</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled  spaced">
																	<li>
																		<i class="ace-icon fa fa-caret-right green"></i>Street, City
																	</li>

																	<li>
																		<i class="ace-icon fa fa-caret-right green"></i>Zip Code
																	</li>

																	<li>
																		<i class="ace-icon fa fa-caret-right green"></i>State, Country
																	</li>

																	<li class="divider"></li>

																	<li>
																		<i class="ace-icon fa fa-caret-right green"></i>
																		Contact Info
																	</li>
																</ul>
															</div>
														</div><!-- /.col -->
													</div><!-- /.row -->

													<div class="space"></div>

													

													<div class="hr hr8 hr-double hr-dotted"></div>

													<div class="row">
														<div class="col-sm-5 pull-right">
															<h4 class="pull-right">
																Total amount :
																<span class="red">$395</span>
															</h4>
														</div>
														<div class="col-sm-7 pull-left"> Extra Information </div>
													</div>

													<div class="space-6"></div>
													<div class="well">
														Thank you for choosing Ace Company products.
				We believe you will be satisfied by our services.
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>

								<!-- PAGE CONTENT ENDS -->
							</div><!-- /.col -->
						</div><!-- /.row -->
					</div>
 
<script>
        /*--paypal.Button.render({

            env: 'production', // sandbox | production

            style: {
            label: 'pay', // checkout | credit | pay
            size:  'responsive',    // small | medium | responsive
            shape: 'rect',     // pill | rect
            color: 'blue'      // gold | blue | silver
            },

            // PayPal Client IDs - replace with your own
            // Create a PayPal app: https://developer.paypal.com/developer/applications/create
            client: {
                sandbox:    '',
                production: 'Af7fdfBnWNndQRMPo7leIWO5iOYElaxjWJxj3pkTcjqPB6TpteMUGuweZtH8P4j4ahHhF-70-V_N3CcZ'
            },

            // Show the buyer a 'Pay Now' button in the checkout flow
            commit: true,

            // payment() is called when the button is clicked
            payment: function(data, actions) {

                // Make a call to the REST api to create the payment
                return actions.payment.create({
                    transactions: [
                        {
                            amount: { total: '<?php if($testpaypal == "0") {echo round(((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"])),2,PHP_ROUND_HALF_UP);} else { echo '1.00'; } ?>', currency: 'USD' }
                        }
                    ]
                });
            }, 

            // onAuthorize() is called when the buyer approves the payment
            onAuthorize: function(data, actions) {

                // Make a call to the REST api to execute the payment
                return actions.payment.execute().then(function() {
                    function postRefreshPage () {
                      var theForm, inputg;
                      theForm = document.createElement("form");
                      theForm.action = "./action/checkoutaction.php";
                      theForm.method = "post";
                      inputg = document.createElement("input");
                      inputg.type = "hidden";
                      inputg.name = "g";
                      inputg.value = "<?php echo $_POST["g"];?>";
                      inputc = document.createElement("input");
                      inputc.type = "hidden";
                      inputc.name = "c";
                      inputc.value = "<?php echo ((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"]));?>";
                      inputdata = document.createElement("input");
                      inputdata.type = "hidden";
                      inputdata.name = "data";
                      inputdata.value = data;
                      theForm.appendChild(inputdata);
                      theForm.appendChild(inputg);
                      theForm.appendChild(inputc);
                      document.getElementById("hidden_form_container").appendChild(theForm);
                      theForm.submit();
                    }
                    postRefreshPage();
                });
            }
        }, '#paypal-button-container');
        
        --*/
        function Init()
        {
            <?php
                echo $product["style_design"] . ';';
                echo 'var product_design = "' . $product["product_image_design"] . '";';
            ?>
            if(product_design.split(",")[0] != "None")
            {
                document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + product_design.split(",")[0];
                document.getElementById("img-design").style.visibility = "visible";
                
                document.getElementById("img-design").style.marginLeft = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[0].split('!',2)[0] * 0.32) + "px";
                document.getElementById("img-design").style.marginTop = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[0].split('!',2)[1] * 0.32) + "px";
                document.getElementById("img-design").style.width = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[1].split('!',2)[0] * 0.32) + "px";
                document.getElementById("img-design").style.height = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[1].split('!',2)[1] * 0.32) + "px";
            }
            else
            {
                document.getElementById("img-design").src  = "";
                document.getElementById("img-design").style.visibility = "hidden";
            }
            
            document.getElementById("img-background").style.backgroundColor = "<?php echo $color["color_value"]; ?>";
            document.getElementById("img-style").style.backgroundImage = "url(\'http://zeeping.com/image/StyleImage/s<?php echo $OrderInfo["style_id"]; ?>.png\')";
        }
        Init();
        function postRefreshPage () {
          var theForm, inputg;
          theForm = document.createElement("form");
          theForm.action = "./action/checkoutaction.php";
          theForm.method = "post";
          inputg = document.createElement("input");
          inputg.type = "hidden";
          inputg.name = "g";
          inputg.value = "<?php echo $_POST["g"];?>";
          inputc = document.createElement("input");
          inputc.type = "hidden";
          inputc.name = "c";
          inputc.value = "<?php echo ((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"]));?>";
          theForm.appendChild(inputg);
          theForm.appendChild(inputc);
          document.getElementById("hidden_form_container").appendChild(theForm);
          theForm.submit();
        }
  </script>

</body>
</html>