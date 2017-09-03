<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Zeeping - Register</title>
    <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
    <link rel="stylesheet" href="../css/style-register.css">
    <meta name="robots" content="noindex,follow" />
</head>
<body>
<?php

include('../../config/config.php'); // Them thu vien

//Check xem thuc su co phai file duoc goi tu form active hay ko
if(isset($_POST["isaction"]))
{
    // Check again Tai khoan da dc active chua
    $sql_querty = 'SELECT `username`, `isenable` FROM `order_user` WHERE `usernamemd5` = \'' . $_POST["usernamemd5"] . '\'';
    $conn = db_connect();
    $user = mysql_query($sql_querty,$conn);
    $count = mysql_num_rows($user);
    db_disconnect($conn);
    if($count == 0)
    {
        echo '404 ERROR';
    }
    else
    {
        $isenable = mysql_fetch_assoc($user)["isenable"];
        if($isenable == 1)
        {
            echo 'Tai khoan da dc kich hoat';
        }
        else
        {
            $UserInfo = array(
                    'fullname' => "",
                    'postalcode' => "",
                    'streetaddress' => "",
                    'city' => "",
                    'province' => "",
                    'country' => "",
                    'phone_number' => "",
                    'userimage' => "",
                    'usernamemd5' => ""
                    );
            
            
            $UserInfo["newpass"] = $_POST["newpass"];
            $UserInfo["fullname"] = $_POST["firstname"] . ' ' . $_POST["lastname"];
            $UserInfo["postalcode"] = $_POST["postalcode"];
            $UserInfo["streetaddress"] = $_POST["streetaddress"];
            $UserInfo["city"] = $_POST["city"];
            $UserInfo["province"] = $_POST["province"];
            $UserInfo["country"] = $_POST["country"];
            $UserInfo["phone_number"] = $_POST["phone_number"];
            $UserInfo["userimage"] = '';
            $UserInfo["usernamemd5"] = $_POST["usernamemd5"];
            
            if(UpdateUser($UserInfo))
            {
                //echo 'Update thanh cong';
                
                
                echo '<script>
                    history.pushState({}, "", "http://zeeping.com");
                    alert("Active Successfully");
                    window.location.assign(\'http://zeeping.com\');
                </script>';
            }
            else
            {
                //echo 'Update that bai';
                echo '<script>
                    history.pushState({}, "", "http://zeeping.com");
                    alert("Active Failed. Please try again");
                    window.location.assign(\'http://zeeping.com\');
                </script>';
            }
        }
    }
}
else
{
    echo '404 Error';
}



?>

</body>
</html>