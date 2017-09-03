<!--A Design by W3layouts
Author: W3layout
Author URL: http://w3layouts.com
License: Creative Commons Attribution 3.0 Unported
License URL: http://creativecommons.org/licenses/by/3.0/
-->
<!DOCTYPE HTML>


<?php
    global $WebUrl;
    global $ContPro;
    $ContPro = $WebUrl . '/' . getContentProductRoot();
    global $ImagPro;
    $ImagPro = $WebUrl . '/' . getImageProductRoot();
    
    
?>

<html>
<head>
<title>Zeeping</title>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="<?php echo $WebUrl;  ?>/source/css/style.css" rel="stylesheet" type="text/css" media="all" />
<link href="<?php echo $WebUrl; ?>/source/css/form.css" rel="stylesheet" type="text/css" media="all" />
<link href='http://fonts.googleapis.com/css?family=Exo+2' rel='stylesheet' type='text/css'>
<script type="text/javascript" src="<?php echo $WebUrl ?>/source/js/jquery1.min.js"></script>
<!-- start menu -->
<link href="<?php echo $WebUrl; ?>/source/css/megamenu.css" rel="stylesheet" type="text/css" media="all" />
<script type="text/javascript" src="<?php echo $WebUrl  ?>/source/js/megamenu.js"></script>
<script>$(document).ready(function(){$(".megamenu").megamenu();});</script>
<link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
<!--start slider -->
    <link rel="stylesheet" href="<?php echo $WebUrl . '' ?>/source/css/fwslider.css" media="all">
    <script src="<?php echo $WebUrl;  ?>/source/js/jquery-ui.min.js"></script>
    <script src="<?php echo $WebUrl;  ?>/source/js/css3-mediaqueries.js"></script>
    <script src="<?php echo $WebUrl;  ?>/source/js/fwslider.js"></script>
    <script src="<?php echo $WebUrl;  ?>/source/js/script.js"></script>
<!--end slider -->
<script src="<?php echo $WebUrl; ?>/source/js/jquery.easydropdown.js"></script>

<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-97459916-1', 'auto');
  ga('send', 'pageview');
  


</script>


<!-- Facebook Pixel Code -->
<script>
!function(f,b,e,v,n,t,s){if(f.fbq)return;n=f.fbq=function(){n.callMethod?
n.callMethod.apply(n,arguments):n.queue.push(arguments)};if(!f._fbq)f._fbq=n;
n.push=n;n.loaded=!0;n.version='2.0';n.queue=[];t=b.createElement(e);t.async=!0;
t.src=v;s=b.getElementsByTagName(e)[0];s.parentNode.insertBefore(t,s)}(window,
document,'script','https://connect.facebook.net/en_US/fbevents.js');
fbq('init', '1150066615114177'); // Insert your pixel ID here.
fbq('track', 'PageView');
</script>
<noscript><img height="1" width="1" style="display:none"
src="https://www.facebook.com/tr?id=1150066615114177&ev=PageView&noscript=1"
/></noscript>
 <!--DO NOT MODIFY -->
<!-- End Facebook Pixel Code -->
<style>
    .zeeping-color
    {
    }
</style>
    
</head>
<body>
     <div class="header-top zeeping-color">
	   <div class="wrap">
	            
			  
			<div class="cssmenu">
				<ul>
				    <li><a href="http://zeeping.com/about-us">About Zeeping</a></li>|
					<li class="active"><a href="http://zeeping.com/about-shipping">About Shipping</a></li> | 
					<li><a href="http://zeeping.com/about-payment">About Payment</a></li> |
					<li> <a>
					    <?php 
                        global $username; 
                        $username = writeLoginMain($_SERVER, $_COOKIE);
                        ?>
                        </a>
					</li> 
					
				</ul>
			</div>
			<div class="clear"></div>
 		</div>
	</div>
	<div class="header-bottom" >
	    <div class="wrap">
			<div class="header-bottom-left" >
			     <div class="logo" >
					<a href="<?php echo $WebUrl . '/' ?>"><img src="<?php echo $WebUrl . '/' ?>image/common/logo.png" alt="" style="height:49.2px;width:90.5px;text-align: center"/></a>
				</div>
				<div class="menu">
	            <ul class="megamenu skyblue" >
	                <?php 
	                    $Menus = getAllMenuWeb();
	                    //echo '<script>
                        //    alert("Toi day roi");
                        //</script>';
	                    $MenuFloor1s = OrderbyObjsbyCondition(getObjsbyCondition($Menus,"floor",1),"stt");
	                    foreach($MenuFloor1s as $menufloor1)
	                    {
	                        if($menufloor1["isvisible"] == false)
	                        {
	                            continue;
	                        }
	                        echo '<li><a class="color4" ' . (($menufloor1["Isflash"] == 0)? '': ('id="blinker_m_' . removeAllspecialchar($menufloor1["name"]) . '"')) . ' href="'. $WebUrl . '/' . $menufloor1["link"] .'">' . $menufloor1["name"] . '</a>';
	                            if($menufloor1["Isflash"] == 1)
	                            {
	                                echo '<script>
	                                    BlinkText_'. removeAllspecialchar($menufloor1["name"]) .'= new BlinkText();
	                                    BlinkText_'. removeAllspecialchar($menufloor1["name"]) .'.start("blinker_m_' . removeAllspecialchar($menufloor1["name"]) . '","' . $menufloor1["name"] . '");
                                    </script>';
	                            }
	                            $MenuFloor2s = OrderbyObjsbyCondition(getObjsbyCondition(getObjsbyCondition($Menus,"floor",2),"childof", $menufloor1["name"]),"stt");
	                            if(sizeof($MenuFloor2s) > 0)
	                            {
	                                echo '
	                                <div class="megapanel">
			                	        <div class="row">
			                	    	    <div class="col1">
			                	    	        <div class="h_nav">';
			                	    	        foreach($MenuFloor2s as $MenuFloor2)
	                                            {
	                                                if($MenuFloor2["isvisible"] == false)
	                                                {
	                                                    continue;
	                                                }
			                	    	    		echo '<h4>'. $MenuFloor2["name"] .'</h4>';
			                	    	    		$MenuFloor3s = OrderbyObjsbyCondition(getObjsbyCondition(getObjsbyCondition($Menus,"floor",3),"childof", $MenuFloor2["name"]),"stt");
			                	    	    		if(sizeof($MenuFloor2s) > 0)
	                                                {
	                                                    echo'<ul>';
	                                                    foreach($MenuFloor3s as $MenuFloor3)
	                                                    {
			                	    	    		        echo '<li><a href="'. $WebUrl . '/' . $MenuFloor3["link"] .'">'. $MenuFloor3["name"]. '</a></li>';
			                	    	    		    }
			                	    	    		    echo '</ul>';
			                	    	    		}
	                                            }
			                	    	        echo '</div>							
			                	    	    </div>
			                	        </div>
			                	    </div>';
			                				
	                            }
			                echo '</li>';
	                    }
	                ?>
			    </ul>
			</div>
		</div>
		    <div class="header-botton-right" >
		            <form class="search"  name="frmLogin" action="http://zeeping.com/source/search.php" method="POST">	  
				        <input type="text" name="s" class="textbox" value="Search" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Search';}" >
				        <input type="submit" value="Subscribe" id="submit" name="submit">
				        <div id="response"> </div>
		            </form>
		    </div>
     <div class="clear"></div>
     </div>
	</div>
  <!-- start slider -->
  <?php
    global $IsIndex;
    if($IsIndex != "true")
    {
        return;
    }
  ?>
    <div id="fwslider">
        <div class="slider_container">
            <div class="slide"> 
                <!-- Slide image -->
                    <img src="<?php echo $WebUrl . '/' ?>image/common/banner1.jpg" alt=""/>
                <!-- /Slide image -->
                <!-- Texts container -->
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <!-- Text title -->
                        <h4 class="title">Modernity</h4>
                        <!-- /Text title -->
                        
                        <!-- Text description -->
                        <p class="description">The peace comes from strength</p>
                        <!-- /Text description -->
                    </div>
                </div>
                 <!-- /Texts container -->
            </div>
            <!-- /Duplicate to create more slides -->
            <div class="slide">
                <img src="<?php echo $WebUrl . '/' ?>image/common/banner2.jpg" alt=""/>
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <h4 class="title">Love</h4>
                        <p class="description">We save freedom which is for us, but for person behind us</p>
                    </div>
                </div>
            </div>
            <!--/slide -->
                        <!-- /Duplicate to create more slides -->
            <div class="slide">
                <img src="<?php echo $WebUrl . '/' ?>image/common/banner3.jpg" alt=""/>
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <h4 class="title">Memories</h4>
                        <p class="description">We always remember them who sacrifice for America future</p>
                    </div>
                </div>
            </div>
            <!--/slide -->
                        <!-- /Duplicate to create more slides -->
            <div class="slide">
                <img src="<?php echo $WebUrl . '/' ?>image/common/banner4.jpg" alt=""/>
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <h4 class="title">Respect</h4>
                        <p class="description">We respect family, America and freedom which make America great.</p>
                    </div>
                </div>
            </div>
            <!--/slide -->
                        <!-- /Duplicate to create more slides -->
            <div class="slide">
                <img src="<?php echo $WebUrl . '/' ?>image/common/banner5.jpg" alt=""/>
                <div class="slide_content">
                    <div class="slide_content_wrap">
                        <h4 class="title">Victory</h4>
                        <p class="description">We must win to save America safe, strong and great.</p>
                    </div>
                </div>
            </div>
            <!--/slide -->
        </div>
        <div class="timers"></div>
        <div class="slidePrev" style="right: 0px; top: 184px; opacity: 0.5;"><span></span></div>
        <div class="slideNext" style="right: 0px; top: 184px; opacity: 0.5;"><span></span></div>
    </div>
    <!--/slider -->