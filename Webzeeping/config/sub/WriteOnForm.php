<?php

//function write document website
function writePostFormbyProductLink($product_link)
{
    global $WebUrl;
    global $username;
    
    
    $RateList = getproductRatebyPI($product_id);
    
    $result = '';

    $conn = db_connect();
    
    $sql_query = "SELECT * from order_product where `linkProduct`='" . $product_link ."'";
    $rs_order_product = mysql_query($sql_query,$conn);
    
    if(mysql_num_rows($rs_order_product) == 1)
    {
        $order_product = mysql_fetch_assoc($rs_order_product);
        
        
        $style_list = $order_product["style_list"];
        $color_list = $order_product["color_list"];
        $product_id = $order_product["product_id"];
	$isfront = $order_product["isFrontVision"];
        $result .="
<style>
    div.stars {
  width: 270px;
}

input.star { display: none; }

label.star {
  float: right;
  padding: 10px;
  font-size: 36px;
  color: #444;
  transition: all .2s;
}

input.star:checked ~ label.star:before {
  content: '\\f005';
  color: #FD4;
  transition: all .25s;
}

input.star-5:checked ~ label.star:before {
  color: #FE7;
  text-shadow: 0 0 20px #952;
}

input.star-1:checked ~ label.star:before { color: #F62; }

label.star:hover { transform: rotate(-15deg) scale(1.3); }

label.star:before {
  content: '\\f006';
  font-family: FontAwesome;
}
</style>";
        $result .= '<script>
                    ' . $order_product["style_design"] . ';
                    var product_design = "' . $order_product["product_image_design"] . '";
                    ' .$color_list . ';
                    var style_id = "";
                    var cl = "";
                    var t = "";
                    var s = "";
                    var isfront = "' . !$isfront . '";
                    var isfrontdefault = "' . !$isfront . '";
                    var desc1content = "' . $order_product["product_content"] . '";
                    var desc2content = "ZPC: ' . $order_product["product_id"] . '";
                    var desc3content = "There are ' . ((count($RateList) == 0) ? 'any ' : count($RateList)) . ' people(s) review this product      \
        <div><div class=\"stars\" style=\"float:left\">      \
  <form action=\"\">      \
    <input class=\"star star-5\" id=\"star-5\" type=\"radio\" name=\"star\" ' . (($username == '') ? 'disabled' :((getObjbyCondition($RateList,"username", $username) != null) ? 'disabled' : '')) . '/>      \
    <label class=\"star star-5\" for=\"star-5\"></label>      \
    <input class=\"star star-4\" id=\"star-4\" type=\"radio\" name=\"star\" ' . (($username == '') ? 'disabled' :((getObjbyCondition($RateList,"username", $username) != null) ? 'disabled' : '')) . '/>      \
    <label class=\"star star-4\" for=\"star-4\"></label>      \
    <input class=\"star star-3\" id=\"star-3\" type=\"radio\" name=\"star\" ' . (($username == '') ? 'disabled' :((getObjbyCondition($RateList,"username", $username) != null) ? 'disabled' : '')) . '/>      \
    <label class=\"star star-3\" for=\"star-3\"></label>      \
    <input class=\"star star-2\" id=\"star-2\" type=\"radio\" name=\"star\" ' . (($username == '') ? 'disabled' :((getObjbyCondition($RateList,"username", $username) != null) ? 'disabled' : '')) . '/>      \
    <label class=\"star star-2\" for=\"star-2\"></label>      \
    <input class=\"star star-1\" id=\"star-1\" type=\"radio\" name=\"star\" ' . (($username == '') ? 'disabled' :((getObjbyCondition($RateList,"username", $username) != null) ? 'disabled' : '')) . '/>      \
    <label class=\"star star-1\" for=\"star-1\"></label>      \
  </form>      \
</div>        \
      ' . (($username == '') ? '' : ((getObjbyCondition($RateList,"username", $username) != null) ? '<span style=\"font-size:10pt;\"><i>(You are already review)</i></span>' :'<button type=\"submit\" name=\"submit\" style=\"float:left;margin-left:10px;margin-top:20px\"> Review IT</button>     \ ')) .
      '<div class=\"clear\"></div></div>      \
<div><span style=\"font-size:10pt;\"><i>(This result is average of all reviews)</i></span></div>";
                    
        </script>
        <link href="' . $WebUrl . '/source/css/product-style.css" rel="stylesheet" type="text/css" media="all" />
    <div class="top-box top-box-product" style="padding-left:0%;padding-right:0%">
        <div class="col_1_of_3 span_2_of_3_pro box-shadow-none" > 
            <div class="inner_content clearfix width-height-100" style="padding:0px">
				<div name="image-region" class="width-height-100"> 
                    <div name="img-blackground" id="img-background" class="width-height-100">
                        <div name="img-style" id="img-style" class="width-height-100" style="background-image: url(\'/image/StyleImage/s'. explode (",", $style_list)[0] . '.png\')">
                            <img name="img-design" id="img-design" src=""></img>
                            <img name="img-front-behide" id="img-front-behide" src="/image/common/front-behide.png" onclick="changedSurface()"></img>
                        </div> 
                    </div> 
                </div>
			</div>
        </div>
        <div class="col_1_of_3 span_1_of_3_properity box-shadow-none">
            <div class="inner_content clearfix">
                <span id="product_title" >'. $order_product["product_title"] .'</span></h1><hr/>
                <div id="content-region">
                    <br><div class="collection-title"><strong>Style:</strong></div>
                    <select name="product_style" id="product_style" onchange="reload_product_image(true,this.value)" form="frmBuyDirect">';
                        $sql_query = "SELECT * from order_product_style";
                    
                        if($style_list != "")
                        {
                            $sql_query .= " WHERE style_id IN (" . $style_list . ")";
                        }   
                        
                        $rs_order_product_style = mysql_query($sql_query,$conn);
                        while($row=mysql_fetch_array($rs_order_product_style)){
                            $result .= '<option value="'. $row["style_id"] .'">' . $row["style_name"] . ' - ' . $row["style_cost"] . '$</option>';
                        }
                    $result .= '</select><br>
                    <div class="collection-title"><strong>Color:</strong></div><br>
                    <div id="color_region"></div><br>
                    <form name="frmLinkProduct" action="/order/action/trackingpage.php" method="post">
                        <input type="hidden" name="product_link" value="' . $order_product["product_link"] . ' "></input>
                        <button class="btn-buy" type="submit" name="submit" value="Buy with Teespring" >
                        <a style="color:#fff">Teespring</a>
                        </button>
                    </form><br>
                    <form name="frmBuyDirect" ';
                if($username == '')
		        {
                    $result .= 'action="/customer/confirminfo.php" method="post" onsubmit="return getValue()">
                                <input type="hidden" name="product_link" value="' . $order_product["product_link"] . ' "></input>'; // thong so link teespring
		        }
		        else
		        {
		            $result .= 'action="/order/delivery.php" method="post" onsubmit="return getValue()">
		                        <input type="hidden" name="product_link" value="' . $order_product["product_link"] . ' "></input>
            		            <input type="hidden" name="title" value="' . $order_product["product_title"] . ' "></input>
            		            <input type="hidden" name="username" value="' . $username . '"></input>'; // thong so title
		        }
                                
                    $result .= '<button class="btn-buy" type="submit" name="submit" value="Buy with Zeeping" 
                                style="margin-bottom:15px;margin-top:0px"><a style="color:#fff"> Discount </a>
                                </button>       
                                <input type="hidden" name="isaction" value="1"></input>
                                <input type="hidden" id="proInfo" name="proInfo" value=""></input>
                                <input type="hidden" name="product_id" value="' . $product_id . ' "></input>
								<input type="hidden" name="vision" value="' . $isfront . '"></input>
                    </form>';
            $result .= '</div>
        </div>
        <div class="clear"></div>
    </div>
    
    <div class="top-box top-box-product">
        <div class="col_1_of_3 span_2_of_3_content box-shadow-none" > 
        
            <div class="inner_content clearfix">
            <hr/>
                <table>
                    <tr>
                        <th><span id="des1" class="tabdes" onclick="ChooseDes(1)">Description</span></th>
                        <th><span id="des2" class="tabdes" onclick="ChooseDes(2)">Information</span></th>
                        <th><span id="des3" class="tabdes" onclick="ChooseDes(3)">Review</th>
                    </tr>
                </table>
                
                <br/>
                <span id="desc-content">' . $order_product["product_content"]  . '</span><hr/>
                
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <script src="' . $WebUrl . '/source/js/product-script.js"></script>
    <script>
        fbq("track", "Purchase", {
        value: 247.35,
        currency: "USD"
        });
        reload_product_image(true,' . split (",", $style_list)[0] . ');
        ChooseDes(1);
    </script>
    ';
    
    }
    
    db_disconnect($conn);
    
    return $result;
}
function writeLoginMain($SERVER, $COOKIE)
{
    
    $username= '';
    
    $echostring = '';
    
    if(isset($COOKIE["session_id"]))
    {
        $ip = get_client_ip($SERVER);
        $username = check_issignin($COOKIE["session_id"],$ip);
        if($username != '')
        {
            $Userfullname = getUserFullname($username);
            $echostring .= '
            <form action="/customer/index.php"  method="POST">
                <button type="submit" name="action" value="Login" style="background-color:Transparent;background-repeat:no-repeat;border: none;cursor:pointer;overflow:hidden;outline:none;">
                    <div>
                         
                        <span style="color:#fff;font-size:1.325em"><a href="/customer/" style="color:#fff;font-size:1.325em">'. $Userfullname .'</a></span>
                    </div>
                </button>
            </form>'; 
        }
        else
        {
            $echostring .= '
            <form action="/customer/login.php"  method="POST">
                <input type="hidden" name="url" value="'. curPageURL($SERVER) . '"/>
                <button type="submit" name="action" value="Login" style="background-color:Transparent;background-repeat:no-repeat;border: none;cursor:pointer;overflow:hidden;outline:none"">
                    <div>
                        
                        <span style="color:#fff;font-size:1.325em">  My Account</span>
                    </div>
                </button>
            </form>'; 
        }
    }
    else
    {
        $echostring .= '
            <form action="/customer/login.php"  method="POST">
                <input type="hidden" name="url" value="'. curPageURL($SERVER) . '"/>
                <button type="submit" name="action" value="Login" style="background-color:Transparent;background-repeat:no-repeat;border: none;cursor:pointer;overflow:hidden;outline:none;">
                    <div>
                        
                        <span style="color:#fff;font-size:1.325em">  My Account</span>
                    </div>
                </button>
            </form>
        '; 
    }
    
    echo $echostring;
    
    return $username;
}

?>