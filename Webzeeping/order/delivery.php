<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Delivery - Zeeping</title>

		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
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
    if(!isset($_POST["isaction"]))
    {
        echo '404 ERROR';
        return;
    }
    if(!isset($_POST["proInfo"]) && !isset($_POST["g"]))
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
?>
    <script>
        <?php
            $style_id = '';
            $product_link = '';
            $title = '';
            $order = '';
            $product = '';
            $cl = '';
            $d = '';
            $style_design = '';
            $product_id = '';
            $size_id = '';
            $quantity = '1';
			$isFront = '';
            if(isset($_POST["proInfo"]))
            {
                $product_link = $_POST["product_link"];
                $product_id = $_POST["product_id"];
                $title = $_POST["title"];
                $style_id = substr($_POST["proInfo"],strpos($_POST["proInfo"], 'st: "') + 5,strpos($_POST["proInfo"], '!') - strpos($_POST["proInfo"], 'st: "') - 5);
				$isFront = $_POST["vision"] == "0" ? "btn_sau" : "btn_truoc";
            }
            else
            {
                $order = getOrderbyGuid($_POST["g"]);
                $product_id = $order["product_id"];
                $style_id = $order["style_id"];
                $size_id = $order["size_id"];
                $quantity = $order["quantity"];
                $product = getProductbyId($product_id);
                $product_link = $product["product_link"];
                $title = $product["product_title"];
                $d = $product["product_image_design"];
                $style_design = $product["style_design"];
                $cl = $order["color_id"] . '!' . getColorbyId($order["color_id"])["color_value"];
		$isFront = $product["isFrontVision"] == 1 ? "btn_truoc" : "btn_sau";
                
            }
            $SizeList = getSizes('where `size_id` in (' . getStylebyId($style_id)["style_listsize"] . ')');
            echo 'size_costs = {';
            foreach ($SizeList as $Size)
            {
                echo 'sc' . $Size["size_id"] . ':"' .  $Size["size_additional_cost"] . '",';
            }
            echo '};';
        ?>
    </script>
<div class="page-content">
						
    <div class="row">
												<div>
													<ul class="steps">
														<li data-step="1" class="active">
															<span class="step">1</span>
															<span class="title">Delivery</span>
														</li>

														<li data-step="2">
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
									<div class="col-sm-10 col-sm-offset-1">
									    <div class="widget-header widget-header-large">
												<h3 class="widget-title grey lighter">
													<img src="/image/common/logo.png" style="height:49.2px;width:90.5px;margin-right:35%"></img>
													<b style="font-size:1.325em">Delivery </b>
												</h3>
												

												<div class="widget-toolbar no-border invoice-info">
													<span class="invoice-info-label">Invoice:</span>
													<span class="red"><?php echo "ZO" . ((isset($_POST["proInfo"]))? "???????": sprintf("%'.07d\n", $order["order_id"])); ?></span>

													<br>
													<span class="invoice-info-label">Date:</span>
													<span class="blue"><?php echo ((isset($_POST["proInfo"])) ? "??/??/?????" : date("d/m/Y", strtotime($order["createDate"]))); ?></span>
												</div>

												
											</div>
											
										<div class="widget-box transparent">
											

											<div class="widget-body">
												<div class="widget-main padding-24">
													<div class="row">
														<div class="col-sm-6">
															<div class="row">
																<div class="col-xs-11 label label-lg label-info arrowed-in arrowed-right">
																	<b>Review Product</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled spaced" >
																    <li style="height:400px">
																	<div name="img-blackground" id="img-background" style="width:280px;height:353px">
                                                                        <div name="img-style" id="img-style" style="width:280px;height:353px;background-size:cover">
                                                                            <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                                                                        </div> 
                                                                    </div>
                                                                    </li>
                                                                    
                                                                        
                                                                    
																</ul>
															</div>
														</div><!-- /.col -->

														<div class="col-sm-6">
															<div class="row">
																<div class="col-xs-11 label label-lg label-success arrowed-in arrowed-right">
																	<b>Order Information</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled  spaced">
																	<li>
																	    <div >
																		 <!--.<b><a   style="font-size:25px" href="<?php echo $product_link; ?>" target="_blank" title="<?php echo $title; ?>"><?php echo $title; ?></a></b>--> 
																		 <b   style="font-size:25px"   title="<?php echo $title; ?>"><?php echo $title; ?></b>
																	    </div>
																	</li>

																	<li>
																	    <div  style="margin-top:2%">
																		 <div  id="style-of-shirt" style="font-size:22px">S • Basic Tees</div>
																		</div>
																	</li>

																	<li>
																		
																		<div  style="font-size:20px;margin-top:5%">Size:
																		  
                                                                            <select  id="size-select" onchange="sizechange(this.value,this.text)" style="font-size:15px;width:64px;height:34px;margin-left:10px">
                                                                         <?php
                                                                        foreach ($SizeList as $Size)
                                                                        {
                                                                            if($size_id != $Size["size_id"])
                                                                            {
                                                                                echo '<option class="size-select" value="'. $Size["size_id"] .'">'. $Size["size_name"] .'</option>';
                                                                            }
                                                                            else
                                                                            {
                                                                                echo '<option class="size-select" value="'. $Size["size_id"] .'" selected>'. $Size["size_name"] .'</option>';
                                                                            }
                                                                        }
                                                                         ?>                              
                                                                        </select>  
	        		                                                </div>
	        		                                                </li>
	        		                                                <li>
																		<div style="font-size:20px;margin-top:5%">Qty:
																		
																		<input style="font-size:15px;width:64px;height:34px;margin-left:13px" id="quantity" type="number" min="0" max="999" pos="0" value="<?php echo $quantity; ?>" onchange="quantityChange(this.value)" >
																		
																		</div>
																		
																	</li>
																	<li>
																	    <div class="hr hr8 hr-double hr-dotted"></div>
																		<div style="font-size:20px;margin-top:5%" id="quantity-price"></div>
																	</li>
																</ul>
															</div>
														</div><!-- /.col -->
													</div><!-- /.row -->

													<div class="space"></div>

													

													<div class="hr hr8 hr-double hr-dotted"></div>

													<div class="row">
														<div class="wizard-actions">
    														<form name="frmDeliveryNext" id="frmDeliveryNext" action="./action/deliveryaction.php" method="post">
                                                      		    <input type="hidden" name="style_id" value="<?php echo $style_id; ?>"></input>
                                                      		    <input type="hidden" id="color_id_post" name="color_id" value="<?php echo split ("!", $cl)[0]; ?>"></input>
                                                      		    <input type="hidden" id="size_id_post" name="size_id" value=""></input>
                                                      		    <input type="hidden" id="quantity_post" name="quantity" value=""></input>
                                                      		    <input type="hidden" id="product_id_post" name="product_id" value="<?php echo $product_id; ?>"></input>
                                                      		    <input type="hidden" name="username" value="<?php if(isset($_POST["username"])) { echo $_POST["username"];  } ?>"></input>
                                                      		    <input type="hidden" name="g" value="<?php if(isset($_POST["g"])) { echo $_POST["g"];  } ?>"></input>
                                                      		</form>
															<button class="btn btn-prev" disabled="disabled">
															<i class="ace-icon fa fa-arrow-left"></i>
															Prev
															</button>

															<button class="btn btn-success btn-next" data-last="Finish" tyle="submit" form="frmDeliveryNext">
															Next
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
<script>
        <?php 
            if(isset($_POST["proInfo"]))
            {
                echo $_POST["proInfo"] . ';' ;
            }
            else
            {
                $pro_pro = 'var pro_pro = {';
                $pro_pro.= 'st: "' . $style_id . '!",';
                $pro_pro.= 'cl: "' . $cl . '",'; 
                $pro_pro.= 't: "",';
                $pro_pro.= 's: "",';
                $pro_pro.= 'd: "' . $d . '"}';
                echo $pro_pro . ';';
                echo $style_design . ';';
                echo 'pro_pro["t"] = product_pro["s'. $style_id . '"]["t"];';
                echo 'pro_pro["s"] = product_pro["s'. $style_id . '"]["s"];';
                echo 'delete product_pro;';
            }
             
            
        ?>
        var style_id = "";
        var style_cost = "";
        function Init()
	    {
	        
	        document.getElementById("img-background").style.backgroundColor = pro_pro["cl"].split('!',2)[1];
            document.getElementById("img-style").style.backgroundImage  = "url('/image/StyleImage/s" + pro_pro["st"].split('!',2)[0] + ".png')";
            if(pro_pro["d"].split(",")[1] != "None")
            {
                document.getElementById("img-design").src  = "/image/Design/" + pro_pro["d"].split(",")[1];
                document.getElementById("img-design").style.visibility = "visible";
            }
            else
            {
                document.getElementById("img-design").src  = "";
                document.getElementById("img-design").style.visibility = "hidden";
            }
            
            document.getElementById("img-design").style.marginLeft = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[0])*0.56 + "px";
            document.getElementById("img-design").style.marginTop = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[1])*0.56 + "px";
            document.getElementById("img-design").style.width = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[0])*0.56 + "px";
            document.getElementById("img-design").style.height = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[1])*0.56 + "px";
            style_id = pro_pro["st"].split('!',2)[0];
            
            
            <?php
                $style = getStylebyId($style_id);
                echo 'style_cost =' . $style["style_cost"] . ";";
                echo 'e = document.getElementById("size-select");';
                echo 'document.getElementById("style-of-shirt").innerHTML = document.getElementById("size-select").options[document.getElementById("size-select").selectedIndex].text + " • '. $style["style_name"] . '";';
            ?>
            
            var str = '';
            str += document.getElementById("quantity").value + ' x (' + style_cost + " + " + size_costs["sc" + document.getElementById("size-select").value] + ")";
            document.getElementById("quantity-price").innerHTML = str;
            document.getElementById("size_id_post").value = document.getElementById("size-select").value;
            document.getElementById("quantity_post").value = document.getElementById("quantity").value;
            document.getElementById("color_id_post").value = pro_pro["cl"].split('!',2)[0];
            
            changedSurface("<?php echo $isFront;?>");
            
	    } 
	    
	    	
        
        
	    function changedSurface(obj)
        {
            if(obj == "btn_truoc")
            {
                document.getElementById("img-style").style.backgroundImage = "url('/image/StyleImage/s" + style_id + ".png')";
                if(pro_pro["d"].split(",")[0] != "None")
                {
                    document.getElementById("img-design").src  = "/image/Design/" + pro_pro["d"].split(",")[0];
                    document.getElementById("img-design").style.visibility = "visible";
                }
                else
                {
                    document.getElementById("img-design").src  = "";
                    document.getElementById("img-design").style.visibility = "hidden";
                }
                document.getElementById("btn_truoc").disabled = true;
                document.getElementById("btn_sau").disabled = false;
                
                
            document.getElementById("img-design").style.marginLeft = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[0])*0.56 + "px";
            document.getElementById("img-design").style.marginTop = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[1])*0.56 + "px";
            document.getElementById("img-design").style.width = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[0])*0.56 + "px";
            document.getElementById("img-design").style.height = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[1])*0.56 + "px";
                
            }
            else
            {
                document.getElementById("img-style").style.backgroundImage = "url('/image/StyleImage/sh" + style_id + ".png')";
                if(pro_pro["d"].split(",")[1] != "None")
                {
                    document.getElementById("img-design").src  = "/image/Design/" + pro_pro["d"].split(",")[1];
                    document.getElementById("img-design").style.visibility = "visible";
                }
                else
                {
                    document.getElementById("img-design").src  = "";
                    document.getElementById("img-design").style.visibility = "hidden";
                }
                
            document.getElementById("img-design").style.marginLeft = parseInt(pro_pro["s"].split('@',2)[0].split('!',2)[0])*0.56 + "px";
            document.getElementById("img-design").style.marginTop = parseInt(pro_pro["s"].split('@',2)[0].split('!',2)[1])*0.56 + "px";
            document.getElementById("img-design").style.width = parseInt(pro_pro["s"].split('@',2)[1].split('!',2)[0])*0.56 + "px";
            document.getElementById("img-design").style.height = parseInt(pro_pro["s"].split('@',2)[1].split('!',2)[1])*0.56 + "px";
            }
        }
        function sizechange(value,text)
        {
            var str = '';
            str += document.getElementById("quantity").value + ' x (' + style_cost + " + " + size_costs["sc" + value] + ")";
            document.getElementById("quantity-price").innerHTML = str;
            document.getElementById("style-of-shirt").innerHTML = document.getElementById("size-select").options[document.getElementById("size-select").selectedIndex].text + document.getElementById("style-of-shirt").innerHTML.substring(document.getElementById("style-of-shirt").innerHTML.indexOf(" • "));
            document.getElementById("size_id_post").value = value;
            
        }
        function quantityChange(value)
        {
            var str = '';
            str += value + ' x (' + style_cost + " + " + size_costs["sc" + document.getElementById("size-select").value] + ")";
            document.getElementById("quantity-price").innerHTML = str;
            document.getElementById("quantity_post").value = value;
        }
	    Init();
  </script>
 


</body>
</html>