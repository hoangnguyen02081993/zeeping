<!DOCTYPE html>
<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Register - Zeeping</title>

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
	
	</head>
	
<body>
<?php
    if(!isset($_POST["proInfo"]))
    {
        echo 'Error 404';
        return;
    }
?>
        
<div class="page-content">
  
    <div class="row">				
									<div class="col-sm-10 col-sm-offset-1">
									    <div class="widget-header widget-header-large">
												<h3 class="widget-title grey lighter">
													<img src="http://zeeping.com/image/common/logo.png" style="width:70px;height:70px"></img>
													E-Mail Register
												</h3>

												<div class="widget-toolbar no-border invoice-info">
													<span class="invoice-info-label">Invoice:</span>
													<span class="red">#69696969</span>

													<br>
													<span class="invoice-info-label">Date:</span>
													<span class="blue">20/04/2017</span>
												</div>

												<div class="widget-toolbar hidden-480">
													<a href="#">
														<i class="ace-icon fa fa-print"></i>
													</a>
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
                                                                        <button class="btn" id="btn_truoc" type="button" style="float:left;margin-left:13%;width:30%;height:40px;color:#000000" onclick="changedSurface(this.id)">Front</button>
                                                                        <button class="btn" id="btn_sau"type="button" style="float:left;margin-left:15%;width:30%;height:40px;color:#000000" onclick="changedSurface(this.id)">Behind</button>
                                                                    </div>
                                                                
                                                                    </li>
                                                                    
																</ul>
															</div>
														</div><!-- /.col -->

														<div class="col-sm-6">
															<div class="row">
																<div class="col-xs-11 label label-lg label-success arrowed-in arrowed-right">
																	<b>Information</b>
																</div>
															</div>

															<div>
																<ul class="list-unstyled  spaced">
																    <li>
																        <a style="font-size:20px">Your E-Mail</a>
																    </li>
																    <li>
																        <input type="email" name="email" id="email" required />
																    </li>
																    
																	<li>
																	    <div >
																		 <b><a   style="font-size:25px" href="<?php echo $product_link; ?>" target="_blank" title="<?php echo $title; ?>"><?php echo $title; ?></a></b>
																	    </div>
																	</li>
																	
																	<li>
																	    <div style="width:400px;height:80px"><h3 id="pro_name" style="float:left"></h3> <div id="div_color" style="float:left;width:40px;height:40px;margin-left:20px;margin-top:10px;border-style:solid;border-width: 5px">
																	    </div> 
																	    </div>
																	</li>
																	
																	<li>
																	    <div class="hr hr8 hr-double hr-dotted"></div>
																	    <i>Please make sure that you choose this T-shirt to buy with Teespring at our store. We’ll check and supply Zeeping’s account for you if you were completely bought  at our website. <br/><br/>Unless you make sure that T- shirt, please come back to choose fit size, color for you. <i>
																	    <div class="hr hr8 hr-double hr-dotted"></div>
																	</li>
																	

																</ul>
															</div>
														</div><!-- /.col -->
													</div><!-- /.row -->

													<div class="space"></div>

													

													<div class="hr hr8 hr-double hr-dotted"></div>

													<div class="row">
														<div class="wizard-actions">
    														<form name="frmBuyDirect" action="./action/confirminfoaction.php" method="post" >
                                                      		    <input type="hidden" id="style_id" name="style_id" value=""></input>
                                                                <input type="hidden" id="color_id" name="color_id" value=""></input>
                                                                <input type="hidden" name="url" value="' . $_POST["product_link"] . '"></input>
                                                      		</form>
															
															<button class="btn btn-success btn-next" data-last="Finish" type="submit" name="submit" value="Next Step">
															Next Step
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

<script>
            <?php echo $_POST["proInfo"]. ';'; ?>
            var style_id = "";
            function Init()
            {
                document.getElementById("img-background").style.backgroundColor = pro_pro["cl"].split('!',2)[1];
                document.getElementById("img-style").style.backgroundImage  = "url('http://zeeping.com/image/StyleImage/s" + pro_pro["st"].split('!',2)[0] + ".png')";
                if(pro_pro["d"].split(",")[1] != "None")
                {
                    document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + pro_pro["d"].split(",")[1];
                    document.getElementById("img-design").style.visibility = "visible";
                }
                else
                {
                    document.getElementById("img-design").src  = "";
                    document.getElementById("img-design").style.visibility = "hidden";
                }
                
                document.getElementById("img-design").style.marginLeft = pro_pro["t"].split('@',2)[0].split('!',2)[0]*0.56 + "px";
                document.getElementById("img-design").style.marginTop = pro_pro["t"].split('@',2)[0].split('!',2)[1]*0.56 + "px";
                document.getElementById("img-design").style.width = pro_pro["t"].split('@',2)[1].split('!',2)[0]*0.56 + "px";
                document.getElementById("img-design").style.height = pro_pro["t"].split('@',2)[1].split('!',2)[1]*0.56 + "px";
                
                document.getElementById("pro_name").innerHTML = pro_pro["st"].split('!',2)[1];
                document.getElementById("div_color").style.backgroundColor = pro_pro["cl"].split('!',2)[1];
                document.getElementById("div_color").style.borderColor = "#8B4513";
                
                style_id = pro_pro["st"].split('!',2)[0];
                
                document.getElementById("style_id").value = style_id;
                document.getElementById("color_id").value = pro_pro["cl"].split('!',2)[0];
                
                changedSurface("btn_truoc");
            }
            function changedSurface(obj)
            {
                if(obj == "btn_truoc")
                {
                    document.getElementById("img-style").style.backgroundImage = "url('http://zeeping.com/image/StyleImage/s" + style_id + ".png')";
                    if(pro_pro["d"].split(",")[0] != "None")
                    {
                        document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + pro_pro["d"].split(",")[0];
                        document.getElementById("img-design").style.visibility = "visible";
                    }
                    else
                    {
                        document.getElementById("img-design").src  = "";
                        document.getElementById("img-design").style.visibility = "hidden";
                    }
                    document.getElementById("btn_truoc").disabled = true;
                    document.getElementById("btn_sau").disabled = false;
                    
                    
                    document.getElementById("img-design").style.marginLeft = pro_pro["t"].split('@',2)[0].split('!',2)[0]*0.56 + "px";
                    document.getElementById("img-design").style.marginTop = pro_pro["t"].split('@',2)[0].split('!',2)[1]*0.56 + "px";
                    document.getElementById("img-design").style.width = pro_pro["t"].split('@',2)[1].split('!',2)[0]*0.56 + "px";
                    document.getElementById("img-design").style.height = pro_pro["t"].split('@',2)[1].split('!',2)[1]*0.56 + "px";
                    
                }
                else
                {
                    document.getElementById("img-style").style.backgroundImage = "url('http://zeeping.com/image/StyleImage/sh" + style_id + ".png')";
                    if(pro_pro["d"].split(",")[1] != "None")
                    {
                        document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + pro_pro["d"].split(",")[1];
                        document.getElementById("img-design").style.visibility = "visible";
                    }
                    else
                    {
                        document.getElementById("img-design").src  = "";
                        document.getElementById("img-design").style.visibility = "hidden";
                    }
                    document.getElementById("btn_truoc").disabled = false;
                    document.getElementById("btn_sau").disabled = true;
                    
                    document.getElementById("img-design").style.marginLeft = pro_pro["s"].split('@',2)[0].split('!',2)[0]*0.56 + "px";
                    document.getElementById("img-design").style.marginTop = pro_pro["s"].split('@',2)[0].split('!',2)[1]*0.56 + "px";
                    document.getElementById("img-design").style.width = pro_pro["s"].split('@',2)[1].split('!',2)[0]*0.56 + "px";
                    document.getElementById("img-design").style.height = pro_pro["s"].split('@',2)[1].split('!',2)[1]*0.56 + "px";
                }
            }
            Init();
        </script>

</body>
</html>