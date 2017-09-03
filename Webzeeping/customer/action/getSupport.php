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
    $supportInfo = array(
                    'name' => "",
                    'mail' => "",
                    'phonenumber' => "",
                    'message' => ""
                    );
    $supportInfo["name"] = $_POST["name"];
    $supportInfo["mail"] = $_POST["mail"];
    $supportInfo["phonenumber"] = $_POST["phonenumber"];
    $supportInfo["message"] = $_POST["message"];
    if(AddSupportFeedback($supportInfo))
    {
        echo 'Your request is sent. We will feedback you soon';
    }
    else
    {
        echo 'Your request isn\'t sent.Please try again';
    }
}
else
{
    echo '404 Error';
}
?>

</body>
</html>