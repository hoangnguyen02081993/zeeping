<?php  
    include("./config/config.php"); 
    global $WebUrl;
    $WebUrl = getWebUrl();
    $WebUrlWWW = getWebUrlWWW();
    $curentUrl = curPageURL($_SERVER);
    $params = getParameterWeb($WebUrl,$WebUrlWWW,$curentUrl);
    global $Menus ;
    $Menus = getAllMenuWeb();
    if(sizeof($params) == 1)
    {
        if(!$params[0] == "")
        {
            if($params[0] == "FAQ")
            {
                include("./source/specialform/FAQ.php");
                return;
            }
            else if($params[0] == "Testimonials")
            {
                include("./source/specialform/Testimonial.php");
                return;
            }
            else if($params[0] == "sitemap.xml")
            {
                include("./source/specialform/sitemap.php");
                return;
            }
            else
            {
                foreach($Menus as $menu)
                {
                    if($menu["link"] == $params[0])
                    {
                        global $Menu;
                        $Menu = $menu;
                        if($Menu["isPage"] == 1)
                        {
                            include("./page.php");
                    }
                        else
                        {
                            include("./catogary.php");
                        }
                        return;
                    }
                }
                include("./404.php");
                return;
            }
        }
    }
    else if(sizeof($params) == 2)
    {
        if($params[0] == "products")
        {
            if(IsHaveProduct($params[1]))
            {
                global $linkproduct;
                $linkproduct = $params[1];
                include("./products.php");
                return;
            }
        }
        if($params[0] == "search")
        {
            global $searchhashtag;
            $searchhashtag = $params[1];
            include("./search.php");
            return;
        }    
        include("./404.php");
        return;
    }
    else
    {
        include("./404.php");
        return;
    }
    global $IsIndex;
    $IsIndex = true;
?>
<?php include("./source/header.php"); ?>
<div class="main">
	<div class="wrap">
		<div class="section group">
		  <div class="cont span_2_of_3">
		  	<h2 class="head" style="font-size:1.5em;color:#000000;font-weight: bold">Featured Products</h2>
		  	<?php
		  	    $Pros = getFeaturedProducts(6);
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
					                </div>
                                    <div class="sale-box "><span class="on_sale title_shop zeeping-color">Featured</span></div>	
                                    <div class="price">
					                    <div class="cart-left">
							                <p class="title">'.$Pro["product_title"].'</p>
							                <div class="price1">
							                    <span class="actual">'.$Pro["rangcost"].'</span>
							                </div>
						                </div>
						                <img class="cart-right"  </img>
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
		    <h2 class="head" style="font-size:1.5em;color:#000000;font-weight: bold">News Products</h2>
		  	<?php
		  	    $Pros = getNewProducts(9);
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
					                </div>
                                    <div class="sale-box"><span class="on_sale title_shop">New</span></div>	
                                    <div class="price">
					                    <div class="cart-left">
							                <p class="title">'.$Pro["product_title"].'</p>
							                <div class="price1">
							                    <span class="actual">'.$Pro["rangcost"].'</span>
							                </div>
						                </div>
						                <img class="cart-right" </img>
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
		  	
	        <h2 class="head" style="font-size:1.5em;color:#000000;font-weight: bold">Best Seller</h2>	
            <?php
		  	    $Pros = getBestSellerProducts(6);
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
					                </div>
                                    <div class="sale-box"><span class="on_sale title_shop">Best Seller</span></div>	
                                    <div class="price">
					                    <div class="cart-left">
							                <p class="title">'.$Pro["product_title"].'</p>
							                <div class="price1">
							                    <span class="actual">'.$Pro["rangcost"].'</span>
							                </div>
						                </div>
						                <img class="cart-right"</img>
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
	             <link href="<?php echo $WebUrl . '/' ?>source/css/default.css" rel="stylesheet" type="text/css" media="all" />
	             <link href="<?php echo $WebUrl . '/' ?>source/css/nivo-slider.css" rel="stylesheet" type="text/css" media="all" />
				  <script src="<?php echo $WebUrl . '/' ?>source/js/jquery.nivo.slider.js"></script>
				    <script type="text/javascript">
				    $(window).load(function() {
				        $('#slider').nivoSlider();
				    });
				    </script>
		    <div class="slider-wrapper theme-default">
              <div id="slider" class="nivoSlider">
                <img src="<?php echo $WebUrl . '/' ?>image/common/mockup1.png"  alt="" />
               	<img src="<?php echo $WebUrl . '/' ?>image/common/mockup2.png"  alt="" />
                <img src="<?php echo $WebUrl . '/' ?>image/common/mockup3.png"  alt="" />
              </div>
             </div>
             </div>
           <div class="top-border"> </div>
			<div class="sidebar-bottom">
			    <a href="<?php echo $WebUrl . '/customer/support.php'; ?>"><div class="subscribe"><input type="submit" value="Contact Us"></div></a>
			</div>
			<br/>
			<br/>
			<div class="sidebar-bottom">
			    <script>
		            function validatereview() {
		                if (document.getElementById("tabnamereview").value == "") {
		                    alert("Please fill your name");
		                    return false;
		                }
		                if (document.getElementById("tacommentreview").value == "") {
		                    alert("Please fill your comment");
		                    return false;
		                }
		                if (document.getElementById("ipuserreview").value == "") {
		                   alert("Please login to review");
		                   return false;
		                }
			            return true;
		            }
			    </script>
			    <form id="reviewform" action="<?php echo $WebUrl . '/' ?>source/specialform/reviewaction.php" method="post" onsubmit="return validatereview()">
			        <?php
			            global $username;
			            $userinfo = getUserInfo($username);
			        ?>
			        <ul>
			        <div style="width:100%; background-color:#3baeff;height:40px;padding-top:15px"><span>REVIEW</span></div>
			        <br/>
			        <li border: solid> </li>
                    <li style="text-align:left">Name: </li>
                    <li style="text-align:left"><textarea id="tabnamereview" rows="1" cols="30"  style="font-size:16px; height:25px; width:100%" form="reviewform" name="name" ><?php echo $userinfo["fullname"]; ?></textarea></li>
                    <br/>
                    <li style="text-align:left">Comment: </li>
                    <li style="text-align:left"><textarea id="tacommentreview" rows="5" cols="30"  style="font-size:16px; width:100%" form="reviewform" name="comment"></textarea></li>
                    </ul>
                    <input id="ipuserreview" type="hidden" name="user" value="<?php echo $userinfo["usernamemd5"]; ?>">
                    <div class="subscribe" ><input type="submit" name="Send" value="Send"   ></div>
                </form>
			</div>
	    </div>
	   
	   
	   <div cont span_3_of_3>

	<a href="<?php echo $WebUrl . '/' ?>"><img style="width:100%"src="<?php echo $WebUrl . '/' ?>image/common/banner-mid.png" /></a>
	   </div>  
            <div class="clear"></div>
			
            <div class="top-box" style="padding-top:3%">
            <blockquote class="col_3_of_3 span_3_of_3">
           <h2 style="font-size:1.325em;text-align:center;color:#777;margin-top:1%">The release of Zeeping</h2>
            <div class="inner_content clearfix" style="text-align:justify">
            
                 Understanding the increasing demand for shopping and constantly aiming to improve the shopping experience in world market. 
                 <br><br>ZEEPING is released as specialized online T-shirt store website, now we mainly serve T-shirt with Army designs (veteran, military, navy us,..).
                 <br><br>The final aim, ZEEPING will become online store where you can find and buy anything.
             
            </div>
            </blockquote>
            </div>
            
            <div class="top-box">
            <blockquote class="col_3_of_3 span_3_of_3">
            <h2 style="font-size:1.325em;text-align:center;color:#777;margin-top:1%">Zeeping supply designed fashionable and meaningful T-shirt with high quality</h2>
            <div class="inner_content clearfix" style="text-align:justify">
            
                 ZEEPING is a specialized online T-shirt store website, we supply designed fashionable and meaningful T-shirt with high quality.
                 <br><br>We are the go-to-place for anyone looking to realize their creative ideas on designs.
                 <br><br>Moreover, we always ready to receive your ideas design from you with special price to design.
                
            </div>
            </blockquote>
            </div>
            
            <div class="top-box">
            <blockquote class="col_3_of_3 span_3_of_3">
            <h2 style="font-size:1.325em;text-align:center;color:#777;margin-top:1%">Zeeping with the trend of military style tshirt</h2>
            <div class="inner_content clearfix" style="text-align:justify">
            
                 At ZEEPING, you will easily find the fashion item that suits each individual needs of each person and especially always adhere to fashion trends and even on over the world.
                 <br><br>Not only is it easy to choose style, when shopping at ZEEPING fashion, you can also refer to and compare the different the same product, ensuring the find the item that you actually pleasure but also extremely suitable for his pocketbook.
                 
            </div>
            </blockquote>
            </div>
            
			<div class="clear"></div>
            
			
	    <div class="top-box">
	    <blockquote class="col_3_of_3 span_3_of_3">
            <h2 style="font-size:1.325em;text-align:center;color:#777;margin-top:1%">Zeeping-where you find quality of military t-shirt and principal services</h2>
            <div class="inner_content clearfix" style="text-align:justify">
           
                 Proudly developed from the leading online shopping website ZEEPING will continue to affirm the location of shopping destination.
                 <br><br>In addition to the diversified and varied product range, ZEEPING Online is always investing in upgrading services from aftermarket policies, professional customer care team, delivery, payment methods and security. 
                 <br><br>Especially if the product is damaged after deliver, you can get your money back with a free 30 days return policy. 
				 <br><br>Sure, you will have satisfaction with quality products and services in each shopping at ZEEPING.
				 
            </div>
            </blockquote>
            </div>
	    
	    <div class="top-box">	
            <blockquote class="col_3_of_3 span_3_of_3">
            <h2 style="font-size:1.325em;text-align:center;color:#777;margin-top:1%">Zeeping has many promotion</h2>
            <div class="inner_content clearfix" style="text-align:justify">
                 With policy, “ more buy more discount “.  ZEEPING always gives customer the best condition to get more clothing for yourself. We have many level discount for our loyal customer from “ Normal Member … Super Golden Member “ , you can get 25% discount with highest level.
                 <br><br>Now, you can the primary promotion at HERE!
                 
            </div>
            </blockquote>
            </div>
            
            
            
            <div class="clear"></div>
	    </div>
			
	<div class="clear"></div>		
	</div>
	</div>
	</div>
	
<?php include("./source/footer.php"); ?>

<style>
blockquote{
  display:block;
  background: #fff;
  padding: 15px 20px 15px 45px;
  margin: 0 0 20px;
  position: relative;
  
  /*Font*/
  font-family: Georgia, serif;
  font-size: 16px;
  line-height: 1.2;
  color: #666;
  text-align: justify;
  
  /*Borders - (Optional)*/
  border-left: 15px solid #c76c0c;
  border-right: 2px solid #c76c0c;
  
  /*Box Shadow - (Optional)*/
  -moz-box-shadow: 2px 2px 15px #ccc;
  -webkit-box-shadow: 2px 2px 15px #ccc;
  box-shadow: 2px 2px 15px #ccc;
}

blockquote::before{
  content: "\201C"; /*Unicode for Left Double Quote*/
  
  /*Font*/
  font-family: Georgia, serif;
  font-size: 60px;
  font-weight: bold;
  color: #999;
  
  /*Positioning*/
  position: absolute;
  left: 10px;
  top:5px;
}

blockquote::after{
  /*Reset to make sure*/
  content: "";
}

blockquote a{
  text-decoration: none;
  background: #eee;
  cursor: pointer;
  padding: 0 3px;
  color: #c76c0c;
}

blockquote a:hover{
 color: #666;
}

blockquote em{
  font-style: italic;
}
</style>