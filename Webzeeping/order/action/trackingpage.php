<?php
    include('../../config/config.php');
    if(isset($_POST["product_link"]))
    {
        $ipaddress = get_client_ip($_SERVER);
 
        $date = date("Y-m-d h:i:sa");
        $sql_query = '';
    
        if(isset($_POST["tracking_mail"]))
        {
            $sql_query = "INSERT INTO `order_guest_tracking`(`tracking_ip`, `tracking_mail`, `tracking_time`) VALUES ('" . $ipaddress . "','" . $_POST["tracking_main"] . "','" . $date . "')";
        }
        else
        {
            $sql_query = "INSERT INTO `order_guest_tracking`(`tracking_ip`, `tracking_time`) VALUES ('" . $ipaddress . "','" . $date . "')";
        }
    
        $conn =  db_connect();
        $rs = mysql_query($sql_query,$conn);
        db_disconnect($conn);
        echo $_POST["product_link"];
        header('Location: '. $_POST["product_link"]);
    }
    else
    {
        echo "Error 404";
    }
?>