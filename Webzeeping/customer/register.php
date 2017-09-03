<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Zeeping - Register</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
    <link rel="stylesheet" href="css/style-register.css">
    <meta name="robots" content="noindex,follow" />
    <?php include('../config/config.php'); ?>
</head>
<body>

<?php
    if(!isset($_GET["u"]))
    {
        echo '404 ERROR';
    }
    else
    {
        $conn = db_connect();
        $sql_querty = 'SELECT `username`, `isenable` FROM `order_user` WHERE `usernamemd5` = \'' . $_GET["u"] . '\'';
        $user = mysql_query($sql_querty,$conn);
        $count = mysql_num_rows($user);
        if($count == 0)
        {
            echo '404 ERROR';
        }
        else
        {
            //$row=mysql_fetch_array($user);
            $isenable = mysql_fetch_assoc($user)["isenable"];
            //$isenable = $row["isenable"];
            if($isenable == 1)
            {
                echo 'Tai khoan da dc kich hoat';
            }
            else
            {
echo '<form name="frmActive" action="./action/activeaccount.php" method="post" onsubmit="return validateForm()">
<div class="checkout-panel">
    <div class="panel-body">
        <h2 class="title">Register</h2>
        <div class="input-confirmation">
	
            <div class="column-1">
                <input type="password" name="newpass" placeholder="New Pass" id="newpass" required />
	  
                <input type="password" name="confirmpass" placeholder="Confirm Pass" id="confirmpass" required/>
          
                <input type="text" name="firstname" placeholder="First Name "id="firstname" required/>
          
                <input type="text" name="lastname" placeholder="Last Name "id="lastname" required/>
	  
	            <input type="text" name="postalcode" placeholder="Postal code" id="postalcode" required/>     
          
            </div>
	        <div class="column-2">
          
                <input type="text" name="phone_number" placeholder="Phone Number"id="phone_number" required/>
          
                <input type="text" name="streetaddress" placeholder="Street Address"id="streetaddress" required/>
          
                <input type="text" name="city" placeholder="City" id="city" required/>
	  
                <input type="text" name="province" placeholder="Province" id="province" required/>  

                <select class="country-select" name="country" id="country" data-default="United States" required>
                    ';                               
			        $sql_querty = 'SELECT `country_id`, `country_name`, `country_region` FROM `order_country`';
                    $countryList = mysql_query($sql_querty,$conn);
                    while($row=mysql_fetch_array($countryList)){
                    echo'<option value="' . $row["country_id"] . '">' . $row["country_name"] .'</option>
                    ';    
                    }
                        echo'
                </select> 
		    
          
            </div>
        </div>

    </div>
<div class="panel-footer">
     <input type="hidden" name="isaction" value="1" ></input>
     <input type="hidden" name="usernamemd5" value="' . $_GET["u"] . '" ></input>
    <input type="submit" class="btn next-btn" name="action" value="Finish" ></input>
</div>
</form>';
echo '<script>
function validateForm() {
    var newpass = document.forms["frmActive"]["newpass"].value;
    var confirmpass = document.forms["frmActive"]["confirmpass"].value;
    if (newpass != confirmpass || newpass == "") {
        alert("New password and confirm password is incorrect");
        document.forms["frmActive"]["newpass"].value = "";
        document.forms["frmActive"]["confirmpass"].value = "";
        return false;
    }
    else
    {
        return true;
    }
}
</script>';
            }
        }
        db_disconnect($conn);
    }
?>

    
    
</body>
</html>