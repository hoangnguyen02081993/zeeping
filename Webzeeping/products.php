<?php include("./source/header.php"); ?>

<?php 
    global $linkproduct;
    echo '<div class="mens">    
        <div class="main">
            <div class="wrap">' . 
                writePostFormbyProductLink($linkproduct) .
            '</div>
        </div>
    </div>';

?>

<div class="wrap">
<?php
    $conn = db_connect();
    $sql_query = "SELECT * from order_product where `linkProduct`='" . $linkproduct ."'";
    $rs_order_product = mysql_query($sql_query,$conn);
    db_disconnect($conn);
    $order_product = mysql_fetch_assoc($rs_order_product);
    
    echo '<h2 class="head">Related for ' . $order_product["product_name"] . '</h2>';
    $Pros = getRelatedProducts(3, $order_product["Catogarys"]);
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
					</div>' .
                    (checkExprieDay($Pro["createdDate"],2) ? '' : '<div class="sale-box "><span class="on_sale title_shop zeeping-color">New</span></div>') .
                    '<div class="price">
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
</div>
</div>
<?php include("./source/footer.php"); ?>