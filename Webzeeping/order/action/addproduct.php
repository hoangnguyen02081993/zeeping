<?php
    include('../../config/config.php');
    
    if(isset($_POST["isaction"]) && isset($_GET['s']))
    {
        $prodcut = array(
            'product_name' => "",
            'product_image_default' => "",
            'product_title' => "",
            'product_content' => "",
            'product_image' => ""
            );
        
        $product["product_name"] = $_POST["product_name"];
        $product["product_default"] = $_POST["product_default"];
        $product["product_title"] = $_POST["product_title"];
        $product["product_content"] = $_POST["product_content"];
        $product["product_link"] = $_POST["product_link"];
        
        $product_image = '';
        
        $a_key = array_keys($_POST);
        
        
        $ishaveimage = false;
        for($i = 0; $i < sizeof($a_key); $i++)
        {
            if(strpos($a_key[$i], "product_image_") !== false)
            {
                if(isset($_POST[$a_key[$i]]))
                {
                    $product_image .= substr($a_key[$i],14) . chr(254) . $_POST[$a_key[$i]] . chr(253);
                    $ishaveimage = true;
                }
            }
        }
        if($ishaveimage == true)
        {
            $product_image = substr($product_image, 0, -1);
        }
        
        
        $product["product_image"] = $product_image;
        if(AddproductonDB($product) == true)
        {
            echo "thanh cong cmnr";
        }
        else
        {
            echo "Loi cmnr";
        }
    }
    else
    {
        echo "error 404";
    }
?>