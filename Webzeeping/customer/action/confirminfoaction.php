<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Zeeping - Register</title>
    <link rel="stylesheet" href="../css/style-register.css">
    <meta name="robots" content="noindex,follow" />
</head>
<body>
<?php

include('../../config/config.php'); // Them thu vien

//Check xem thuc su co phai file duoc goi tu form active hay ko
if(isset($_POST["submit"]))
{
    // Check again Tai khoan da dc active chua
    $MailInfo = array(
        'email' => "",
        'style_id' => "",
        'color_id' => "",
        'product_id' => ""
    );
            
            
    $MailInfo["email"] = $_POST["email"];
    $MailInfo["style_id"] = $_POST["style_id"];
    $MailInfo["color_id"] = $_POST["color_id"];
    $MailInfo["product_id"] = $_POST["product_id"];
            
    AddTrackingMail($MailInfo);
    
    header('Location: '. $_POST["url"]);
}
else
{
    echo '404 Error';
}



?>

</body>
</html>