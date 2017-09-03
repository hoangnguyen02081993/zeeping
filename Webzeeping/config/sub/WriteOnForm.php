<?php

//function write document website
function writePostFormbyProductLink($product_link)
{
    global $WebUrl;
    
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

        $result .= '<script>
                    ' . $order_product["style_design"] . ';
                    var product_design = "' . $order_product["product_image_design"] . '";
                    ' .$color_list . ';
                    var style_id = "";
                    var cl = "";
                    var t = "";
                    var s = "";
                    var isfront = true;
                    var desc1content = "' . $order_product["product_content"] . '";
                    var desc2content = "(Đây là thông tin infomation)";
                    var desc3content = "(Đây là thông tin Review)";
        </script>
        <link href="' . $WebUrl . '/source/css/product-style.css" rel="stylesheet" type="text/css" media="all" />
    <div class="top-box top-box-product" style="padding-left:0%;padding-right:0%">
        <div class="col_1_of_3 span_2_of_3_pro box-shadow-none" > 
            <div class="inner_content clearfix width-height-100" style="padding:0px">
				<div name="image-region" class="width-height-100"> 
                    <div name="img-blackground" id="img-background" class="width-height-100">
                        <div name="img-style" id="img-style" class="width-height-100" style="background-image: url(\'http://zeeping.com/image/StyleImage/s'. explode (",", $style_list)[0] . '.png\')">
                            <img name="img-design" id="img-design" src=""></img>
                            <img name="img-front-behide" id="img-front-behide" src="http://zeeping.com/image/common/front-behide.png" onclick="changedSurface()"></img>
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
                    <form name="frmLinkProduct" action="http://zeeping.com/order/action/trackingpage.php" method="post">
                        <input type="hidden" name="product_link" value="' . $order_product["product_link"] . ' "></input>
                        <button class="btn-buy" type="submit" name="submit" value="Buy with Teespring" >
                        <a style="color:#fff">Teespring</a>
                        </button>
                    </form><br>
                    <form name="frmBuyDirect" ';
                global $username; 
                if($username == '')
		        {
                    $result .= 'action="http://zeeping.com/customer/confirminfo.php" method="post" onsubmit="return getValue()">
                                <input type="hidden" name="product_link" value="' . $order_product["product_link"] . ' "></input>'; // thong so link teespring
		        }
		        else
		        {
		            $result .= 'action="http://zeeping.com/order/delivery.php" method="post" onsubmit="return getValue()">
		                        <input type="hidden" name="product_link" value="' . $order_product["product_link"] . ' "></input>
            		            <input type="hidden" name="title" value="' . $order_product["product_title"] . ' "></input>
            		            <input type="hidden" name="username" value="' . $username . '"></input>
            		            <input type="hidden" name="product_id" value="' . $product_id . ' "></input>'; // thong so title
		        }
                                
                    $result .= '<button class="btn-buy" type="submit" name="submit" value="Buy with Zeeping" 
                                style="margin-bottom:15px;margin-top:0px"><a style="color:#fff"> Discount </a>
                                </button>       
                                <input type="hidden" name="isaction" value="1"></input>
                                <input type="hidden" id="proInfo" name="proInfo" value=""></input>
                    </form>';
                //if($username == '')
		        //{
                //    global $wp;
		      //       $result .= '<form name="frmLogin1" action="http://zeeping.com/customer/login.php" method="post" style="width:100%">                          
            //                        <input class="input-login" type="submit" name="action" value="LOGIN" style="margin-top:10px;margin-bottom:15px;font-size:100%;margin-left:70%"></input>
             //                       <input type="hidden" name="url" value="'. curPageURL($_SERVER) .'"></input>
              //                  </form></div>';
		       // }
            $result .= '</div>
        </div>
        <div class="clear"></div>
    </div>
    
    <div class="top-box top-box-product">
        <div class="col_1_of_3 span_2_of_3_content box-shadow-none" > 
        <hr/>
            <div class="inner_content clearfix">
                <table>
                    <tr>
                        <th><span id="des1" class="tabdes" onclick="ChooseDes(1)">Description</span></th>
                        <th><span id="des2" class="tabdes" onclick="ChooseDes(2)">Information</span></th>
                        <th><span id="des3" class="tabdes" onclick="ChooseDes(3)">Review</th>
                    </tr>
                </table>
                <br/>
                <span id="desc-content">' . $order_product["product_content"]  . '</span>
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
    //$echostring .= '<div id="loginregion" style="width:100%;height:40px">';
    
    if(isset($COOKIE["session_id"]))
    {
        $ip = get_client_ip($SERVER);
        $username = check_issignin($COOKIE["session_id"],$ip);
        if($username != '')
        {
            $Userfullname = getUserFullname($username);
            //height:35px;width:150px;margin:0px;background-color:#4cb1ca
            $echostring .= '
            <form action="http://zeeping.com/customer/index.php"  method="POST">
                <button type="submit" name="action" value="Login" style="background-color:Transparent;background-repeat:no-repeat;border: none;cursor:pointer;overflow:hidden;outline:none;">
                    <div>
                         
                        <span style="color:#fff;font-size:1.325em"><a href="http://zeeping.com/customer/" style="color:#fff;font-size:1.325em">'. $Userfullname .'</a></span>
                    </div>
                </button>
            </form>'; 
        }
        else
        {
            $echostring .= '
            <form action="http://zeeping.com/customer/login.php"  method="POST">
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
            <form action="http://zeeping.com/customer/login.php"  method="POST">
                <input type="hidden" name="url" value="'. curPageURL($SERVER) . '"/>
                <button type="submit" name="action" value="Login" style="background-color:Transparent;background-repeat:no-repeat;border: none;cursor:pointer;overflow:hidden;outline:none;">
                    <div>
                        
                        <span style="color:#fff;font-size:1.325em">  My Account</span>
                    </div>
                </button>
            </form>
        '; 
    }
    
    //$echostring .= '</div>';
    
    echo $echostring;
    
    return $username;
}

?>