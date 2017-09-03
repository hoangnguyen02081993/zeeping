<?php 
    include("./source/header.php");
    global $searchhashtag;
    $searchsession = getSearchSession($searchhashtag,get_client_ip($_SERVER));
?>
<div class="main">
	<div class="wrap">
		<div class="section group">
		  <div class="cont span_2_of_3">
		  	<h2 class="head"><?php echo 'Product for "' . (($searchsession == null) ? $searchhashtag : $searchsession["name"]) . '"'; ?></h2>
		  	<?php
		  	    $Pros = getSearchProduct(100, $searchhashtag);
		  	    $index = 0;
		  	    foreach($Pros as $Pro)
		  	    {
		  	        if($index == 0)
		  	        {
		  	            echo '<div class="top-box">';
		  	        }
		  	        
		  	            echo '
		  	            <div class="col_1_of_3 span_1_of_3"> 
			                <a href="' . $ContPro . '/' . $Pro["linkProduct"] . '">
				                <div class="inner_content clearfix">
					                <div class="product_image">
						                <img src="'. $ImagPro . '/' . $Pro["linkFeaturedImage"] .'" alt=""/>
					                </div>'.
                                    (checkExprieDay($Pro["createdDate"],2) ? '' : '<div class="sale-box"><span class="on_sale title_shop">New</span></div>') .
                                    '<div class="price">
					                    <div class="cart-left">
							                <p class="title">'.$Pro["product_title"].'</p>
							                <div class="price1">
							                    <span class="actual">'.$Pro["rangcost"].'</span>
							                </div>
						                </div>
						                <div class="cart-right"> </div>
						                <div class="clear"></div>
					                </div>				
                                </div>
                            </a>
				        </div>';
		  	        if($index == 2)
		  	        {
		  	            echo '<div class="clear"></div>
			            </div>';
		  	            $index = 0;
		  	        }
		  	        else
		  	        {
		  	            $index++;
		  	        }
		  	        
		  	    }
		  	    if($index != 0)
		  	    {
		  	        echo '<div class="clear"></div>
			        </div>';
		  	    }
		  	?>
		  </div>
			<div class="rsidebar span_1_of_left">
				<div class="top-border"> </div>
				 <div class="border">
	             <link href="css/default.css" rel="stylesheet" type="text/css" media="all" />
	             <link href="css/nivo-slider.css" rel="stylesheet" type="text/css" media="all" />
				  <script src="js/jquery.nivo.slider.js"></script>
				    <script type="text/javascript">
				    $(window).load(function() {
				        $('#slider').nivoSlider();
				    });
				    </script>
		    <div class="slider-wrapper theme-default">
              <div id="slider" class="nivoSlider">
                <img src="<?php echo $WebUrl . '/' ?>images/t-img1.jpg"  alt="" />
               	<img src="<?php echo $WebUrl . '/' ?>images/t-img2.jpg"  alt="" />
                <img src="<?php echo $WebUrl . '/' ?>images/t-img3.jpg"  alt="" />
              </div>
             </div>
             </div>
           <div class="top-border"> </div>
			<div class="sidebar-bottom">
			    <a href="<?php echo $WebUrl . '/customer/support.php'; ?>"><div class="subscribe"><input type="submit" value="Contact Us"></div></a>
			</div>
	    </div>
	   <div class="clear"></div>
	</div>
	</div>
	</div>
<?php include("./source/footer.php"); ?>