<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Zeeping - Delivery</title>
  <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
  <link rel="stylesheet" href="css/style-delivery.css">
  <?php include('../config/config.php'); ?>
<meta name="robots" content="noindex,follow" />
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
            if(isset($_POST["proInfo"]))
            {
                $product_link = $_POST["product_link"];
                $product_id = $_POST["product_id"];
                $title = $_POST["title"];
                $style_id = substr($_POST["proInfo"],strpos($_POST["proInfo"], 'st: "') + 5,strpos($_POST["proInfo"], '!') - strpos($_POST["proInfo"], 'st: "') - 5);
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
	<div class="checkout-panel">
        <div class="panel-body" >
           <h2 class="title">Delivery</h2>
	        <div class="progress-bar">
	        	<div class="step first"></div>
	        	<div class="step "></div>
	        	<div class="step "></div>
	        	<div class="step "></div>
                </div>  
        
	        	<div class="input-confirmation">
	        	    <div name="img-blackground" id="img-background" style="width:390px;height:463px">
                        <div name="img-style" id="img-style" style="width:390px;height:463px;background-size:cover">
                            <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                        </div> 
                        <button class="btn" id="btn_truoc" type="button" style="float:left;margin-top:5px;margin-left:25%;width:20%;height:40px;color:#000000" onclick="changedSurface(this.id)">Front</button>
                        <button class="btn" id="btn_sau"type="button" style="float:left;margin-top:5px;margin-left:8%;width:20%;height:40px;color:#000000" onclick="changedSurface(this.id)">Behind</button>
                    </div>
        
	        	    <div class="column-2">
	        		<div> 
	        		    <a  class="link" href="<?php echo $product_link; ?>" target="_blank" title="<?php echo $title; ?>"><?php echo $title; ?></a>
	        		</div>
        
                    <div class="style-of-shirt" id="style-of-shirt"></div>
        
	        	<div class="row">
	        		<div class="size-text">
	        			Size:</div>
	        	 
 	        		<div>                                  
                    <select class="size-select" id="size-select" onchange="sizechange(this.value,this.text)">
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
	        		   <div class="qty-text">Qty: </div>
                                   <div class="qty-select">
                                	<input class="quantity" id="quantity" type="number" min="0" max="999" pos="0" value="<?php echo $quantity; ?>" onchange="quantityChange(this.value)">
	        		   </div>
	        		</div>
	        		<div class="row">
	        		   <div class="qty-price" id="quantity-price"></div>
                                   
	        		</div>
	        		
	        		
	        	</div>
	</div>	
		   
       
    </div>
  	    <div class="panel-footer">
  	        <form name="frmDeliveryNext" id="frmDeliveryNext" action="./action/deliveryaction.php" method="post">
      		    <input type="hidden" name="style_id" value="<?php echo $style_id; ?>"></input>
      		    <input type="hidden" id="color_id_post" name="color_id" value="<?php echo split ("!", $cl)[0]; ?>"></input>
      		    <input type="hidden" id="size_id_post" name="size_id" value=""></input>
      		    <input type="hidden" id="quantity_post" name="quantity" value=""></input>
      		    <input type="hidden" id="product_id_post" name="product_id" value="<?php echo $product_id; ?>"></input>
      		    <input type="hidden" name="username" value="<?php if(isset($_POST["username"])) { echo $_POST["username"];  } ?>"></input>
      		    <input type="hidden" name="g" value="<?php if(isset($_POST["g"])) { echo $_POST["g"];  } ?>"></input>
      		</form>
      		<button class="btn next-btn" tyle="submit" form="frmDeliveryNext" >Next Step</button>
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
            
            document.getElementById("img-design").style.marginLeft = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[0])*73/100 + "px";
            document.getElementById("img-design").style.marginTop = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[1])*73/100 + "px";
            document.getElementById("img-design").style.width = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[0])*73/100 + "px";
            document.getElementById("img-design").style.height = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[1])*73/100 + "px";
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
                
                
            document.getElementById("img-design").style.marginLeft = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[0])*73/100 + "px";
            document.getElementById("img-design").style.marginTop = parseInt(pro_pro["t"].split('@',2)[0].split('!',2)[1])*73/100 + "px";
            document.getElementById("img-design").style.width = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[0])*73/100 + "px";
            document.getElementById("img-design").style.height = parseInt(pro_pro["t"].split('@',2)[1].split('!',2)[1])*73/100 + "px";
                
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
                
            document.getElementById("img-design").style.marginLeft = parseInt(pro_pro["s"].split('@',2)[0].split('!',2)[0])*73/100 + "px";
            document.getElementById("img-design").style.marginTop = parseInt(pro_pro["s"].split('@',2)[0].split('!',2)[1])*73/100 + "px";
            document.getElementById("img-design").style.width = parseInt(pro_pro["s"].split('@',2)[1].split('!',2)[0])*73/100 + "px";
            document.getElementById("img-design").style.height = parseInt(pro_pro["s"].split('@',2)[1].split('!',2)[1])*73/100 + "px";
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
  </div>
</body>
</html>
