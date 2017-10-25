<!DOCTYPE html>
<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Register - Zeeping</title>
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
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
    if(!isset($_POST["proInfo"]) || !isset($_POST["product_link"]) || !isset($_POST["product_id"]))
    {
        echo 'Error 404';
        return;
    }
    
?>
        
<div class="page-content">
  
    <div class="row">				
		<div class="col-sm-10 col-sm-offset-1">
									   
			<div class="widget-box transparent">
											
				<div class="widget-body">
												
					<div class="row">
							<div class="col-xs-12 col-sm-12 pricing-box">
                                 <div class="widget-box widget-color-dark">
                                    <div class="widget-header">
                                    	<h5 class="widget-title bigger lighter">E-Mail Register</h5>
                                    </div>
                                                <div class="widget-body">
                                    			    <div class="col-sm-6">
                                						<div>
                                							<ul class="list-unstyled spaced" style="height:400px">
                                								<div name="img-blackground" id="img-background" style="width:280px;height:353px">
                                                                    <div name="img-style" id="img-style" style="width:280px;height:353px;background-size:cover">
                                                                            <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                                                                    </div> 
                                                                         <button class="btn" id="btn_truoc" type="button" style="float:left;margin-left:13%;width:30%;height:40px;color:#000000" onclick="changedSurface(this.id)">Front</button>
                                                                         <button class="btn" id="btn_sau"type="button" style="float:left;margin-left:15%;width:30%;height:40px;color:#000000" onclick="changedSurface(this.id)">Behind</button>
                                                                </div>
                                                            </ul>
                                						</div>
                                					</div><!-- /.col -->
                                				<div class="col-sm-6">   
                                    				<ul class="list-unstyled spaced2" style="padding-top:5%">
                                    				    
                                    					<li>
                                							<b><span style="font-size:25px">Your E-Mail</span></b>
                                						</li>
                                            			<li>
                                            				<span>
                                            					<img src="http://zeeping.com/image/common/logo.png" style="height:49.2px;width:90.5px;margin-right:3%"></img>
                                                            	<input type="email" form="frmBuyDirect" name="email" id="email" placeholder="E-Mail" style="width:250px" required />
                                                            	
                                                            </span>
                                            			</li>
                                            	
                                                        <li>
                                            			<div style="width:400px;height:80px"><h3 id="pro_name" style="float:left"></h3> <div id="div_color" style="float:left;width:40px;height:40px;margin-left:20px;margin-top:10px;border-style:solid;border-width: 5px">
                                    					</div> 
                                    					</div>
                                            			</li>
                                                    	<li>
                                            	<div class="hr hr8 hr-double hr-dotted"></div>
                                					 <i>Please make sure that you choose this T-shirt to buy with Teespring at our store. We’ll check and supply Zeeping’s account for you if you were completely bought  at our website. 
                                					 <br/><br/>Unless you make sure that T- shirt, please come back to choose fit size, color for you. 
                                					 <br/><br/>Sign in for a <strong>10% discount </strong>on your next purchase <i>
                                						<div class="hr hr8 hr-double hr-dotted"></div>
                                            		</li>
                                                </ul>
                                    	    </div>
                                    										
                                    												<div>
                                    												    <form name="frmBuyDirect" id="frmBuyDirect" action="./action/confirminfoaction.php" method="post" >
                                    												    <button class="btn btn-block btn-inverse" type="submit" name="submit" value="Next Step">
                                    												        
                                                                                  		    <input type="hidden" id="style_id" name="style_id" value=""></input>
                                                                                            <input type="hidden" id="color_id" name="color_id" value=""></input>
                                                                                            <input type="hidden" id="color_id" name="product_id" value="<?php echo $_POST["product_id"]; ?>"></input>
                                                                                            <?php echo'<input type="hidden" name="url" value="'.$_POST["product_link"].'"></input>'; ?>
                                    														<i class="ace-icon fa fa-shopping-cart bigger-110" ></i>
                                    														<span >Buy</span>
                                    													</form>
                                    													</a>
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