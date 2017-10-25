<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Checkout - Zeeping</title>

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
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
		<!-- ace settings handler -->
		<script src="assets/js/ace-extra.min.js"></script>

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
		<?php include('../config/config.php'); ?>
		<script src="https://www.paypalobjects.com/api/checkout.js"></script>
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

														<li data-step="4">
															<span class="step">4</span>
															<span class="title">Finish</span>
														</li>
													</ul>
												</div>
							<div class="col-xs-12">
								<!-- PAGE CONTENT BEGINS -->
								<div class="space-6"></div>

								<div class="row">
									<div class="col-sm-10 col-sm-offset-1">
									    <div class="widget-header widget-header-large">
												<h3 class="widget-title grey lighter">
													<img src="/image/common/logo.png" style="height:49.2px;width:90.5px;margin-right:35%"></img>
													<b style="font-size:1.325em">Checkout </b>
												</h3>

												<div class="widget-toolbar no-border invoice-info">
													<span class="invoice-info-label">Invoice:</span>
													<span class="red"><?php echo "ZO" . sprintf("%'.07d\n", $OrderInfo["order_id"]); ?></span>

													<br>
													<span class="invoice-info-label">Date:</span>
													<span class="blue"><?php echo date("d/m/Y", strtotime($OrderInfo["createDate"])); ?></span>
												</div>

												
											</div>
										<div class="widget-box transparent">
											

											<div class="widget-body">
												<div class="widget-main padding-24">
													<div class="row">
														<div class="col-sm-6">
															<div class="row" >
																<div class="col-xs-11 label label-lg label-info arrowed-in arrowed-right">
																	<b>Review Product</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled spaced">
																	<li> 
																		<div name="img-blackground" id="img-background" style="width:280px;height:353px">
                                                                            <div name="img-style" id="img-style" style="width:280px;height:353px;background-size:cover">
                                                                                <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                                                                                
                                                                            </div>
                                                                    
                                                                        </div>
                                                                       
																	</li>
																	
																	<li style="width:280px"> 
																		 <div style="font-size:20px;margin-left:5%;text-align:center">
																		     <b><?php echo $product["product_title"]; ?></b>
																		 </div>
																		  
																	</li>
																	
																	
																	<li style="width:280px">
																		 <div style="font-size:15px;margin-left:5%;;text-align:center">
																		    <div style="color:#b8bdc5"> <?php echo $size[0]["size_name"] . ' - ' . $color["color_name"]; ?> </div>
																		 </div>
																		  
																	</li>
																	
																</ul>
															</div>
														</div><!-- /.col -->

														<div class="col-sm-6">
															<div class="row">
																<div class="col-xs-11 label label-lg label-success arrowed-in arrowed-right">
																	<b>Checkout Info</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled  spaced">
																	<li>
																		<div style="margin-top:8%">
																		  <span style="font-size:20px;padding-right:15px">Basic Price :</span>
																		
																		 
																		 <b><span class="black" style="float:right;padding-right:2%;padding-top:1%;"><span style="color:#b8bdc5;padding-right:10px"><?php echo $OrderInfo["quantity"]."x"; ?></span> 
																		 
																		     <?php echo " $" . (getCostafterPromosion($style["style_cost"]) + $size[0]["size_additional_cost"]); ?> 
																		     </span></b>
																		 <div class="hr hr8 hr-double hr-dotted"></div>
																		 </div>
																	</li>

																	

																	<li>
																		<div style="margin-top:8%">
																		<span style="font-size:20px;padding-right:15px;color:#ed3e80">Discount:</span>
																		
																		
																		<b><span class="black" style="float:right;padding-right:2%;padding-top:1%;color:#ed3e80"><?php echo (100-getCostafterPromosion(100,$promosion))."%"." ($".((100-getCostafterPromosion(100,$promosion))*(getCostafterPromosion((($style["style_cost"] + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"])))/100).")" ;?></span></b>
						
																		
																		</div> 
																		<div class="hr hr8 hr-double hr-dotted"></div>
																		
																	</li>
																	
																	<li>
																		<div style="margin-top:8%">
																		<span style="font-size:20px;padding-right:15px">Shipping:</span>
																	
																		<b><span class="black" style="float:right;padding-right:2%;padding-top:1%"> <?php echo '$'. getCostShipCountry($country,$OrderInfo["quantity"]); ?> </span></b>
																		
																		</div>
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
																
																<b><span class="red"> <?php echo '$' . ((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"])); ?> </div> </b>
															</h4>
														</div>
														<div class="hr hr8 hr-double hr-dotted"></div>	
													</div>
													
												

												
													<div class="wizard-actions">
                                                      		<form class="form-horizontal" id="frmcheckoutPre" method="post" novalidate="novalidate" action="./confirm.php">
                                                                <input type="hidden" name="g" value="<?php echo $OrderInfo["guid"]; ?>"></input>
                                                                <input type="hidden" name="isaction" value="1"></input>
                                                            </form>
															<button class="btn btn-prev"  style="width:65px;height:36px;margin-right:2%;padding:0px" form="frmcheckoutPre">
    															<i class="ace-icon fa fa-arrow-left" ></i>
    															Prev
															</button>
															
															<div  id="paypal-button-container" style="width:200px;float:right"></div>
															<div id="hidden_form_container" style="display:none;"></div>
															

															
											            </div>

													<div class="space-6"></div>
													<div class="col-sm-7 pull-left"> Extra Information </div>
													<div class="well">
														Thank you for choosing Zeeping Shirt products.
				We believe you will be satisfied by our product.
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
        paypal.Button.render({

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
        
        
        function Init()
        {
            <?php
                echo $product["style_design"] . ';';
                echo 'var product_design = "' . $product["product_image_design"] . '";';
		echo 'var isFront = '. $product["isFrontVision"] . ';';
            ?>
			
			if(isFront)
			{			
				if(product_design.split(",")[0] != "None")
				{
					document.getElementById("img-design").src  = "/image/Design/" + product_design.split(",")[0];
					document.getElementById("img-design").style.visibility = "visible";
                
					document.getElementById("img-design").style.marginLeft = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[0].split('!',2)[0] * 0.56) + "px";
					document.getElementById("img-design").style.marginTop = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[0].split('!',2)[1] * 0.56) + "px";
					document.getElementById("img-design").style.width = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[1].split('!',2)[0] * 0.56) + "px";
					document.getElementById("img-design").style.height = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[1].split('!',2)[1] * 0.56) + "px";
				}
				else
				{
					document.getElementById("img-design").src  = "";
					document.getElementById("img-design").style.visibility = "hidden";
				}
            
				document.getElementById("img-background").style.backgroundColor = "<?php echo $color["color_value"]; ?>";
				document.getElementById("img-style").style.backgroundImage = "url(\'/image/StyleImage/s<?php echo $OrderInfo["style_id"]; ?>.png\')";
			}
			else
			{
				if(product_design.split(",")[1] != "None")
				{
					document.getElementById("img-design").src  = "/image/Design/" + product_design.split(",")[1];
					document.getElementById("img-design").style.visibility = "visible";
                
					document.getElementById("img-design").style.marginLeft = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["s"].split('@',2)[0].split('!',2)[0] * 0.56) + "px";
					document.getElementById("img-design").style.marginTop = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["s"].split('@',2)[0].split('!',2)[1] * 0.56) + "px";
					document.getElementById("img-design").style.width = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["s"].split('@',2)[1].split('!',2)[0] * 0.56) + "px";
					document.getElementById("img-design").style.height = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["s"].split('@',2)[1].split('!',2)[1] * 0.56) + "px";
				}
				else
				{
					document.getElementById("img-design").src  = "";
					document.getElementById("img-design").style.visibility = "hidden";
				}
            
				document.getElementById("img-background").style.backgroundColor = "<?php echo $color["color_value"]; ?>";
				document.getElementById("img-style").style.backgroundImage = "url(\'/image/StyleImage/sh<?php echo $OrderInfo["style_id"]; ?>.png\')";
			}
        }
        Init();
  </script>

</body>
</html>