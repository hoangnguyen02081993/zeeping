<?php

    if(!isset($_POST["submit"]))
    {
        return;
    }
    if(!isset($_POST["email"]))
    {
        return;
    }
    
    include("../../config/config.php");
    
    $fullname = getUserFullname($_POST["email"]);
    if($fullname == "")
    {
        return;
    }
    
    
    $forgotinfo = ExistedForgot($_POST["email"]);
    $IsSend = false;
    if($forgotinfo == null)
    {
        $forgotinfo = Array(
            "username"    => $_POST["email"],
            "newpassword" => substr(getGUID(),0,8),
            "fullname"    => $fullname,
            );
        $IsSend = InsertForgotPassword($forgotinfo);
    }
    else
    {
        $IsSend = checkExprieMinutes($forgotinfo["createddate"],5);
        if($IsSend)
        {
            $forgotinfo["newpassword"] = substr(getGUID(),0,8);
            UpdateForgot($forgotinfo);
        }
    }
    
    if($IsSend)
    {
        $gmailinfo = getUserGmailSupport();
        
        $mail = new PHPMailer\PHPMailer\PHPMailer();
    
        $mail->IsSMTP(); // telling the class to use SMTP
        //$mail->SMTPDebug  = 2;                     // enables SMTP debug information (for testing)
                                                   // 1 = errors and messages
                                                   // 2 = messages only
        $mail->SMTPAuth   = true;                  // enable SMTP authentication
        $mail->SMTPSecure = "tls";                 
        $mail->Host       = "smtp.gmail.com";      // SMTP server
        $mail->Port       = 587;                   // SMTP port
        $mail->Username   = $gmailinfo["user"];  // username
        $mail->Password   = $gmailinfo["password"];            // password
    
        $mail->SetFrom($gmailinfo["user"], 'Zeeping');
    
        $mail->Subject    = "[Zeeping] Reset password !";
    
        $mail->isHTML(true);
    
        $body = 'Dear ' . $forgotinfo["fullname"] . ',<br/><br/>
                 We received your password change request.<br/>
                 Your new password: <span style="color:blue">' . $forgotinfo["newpassword"] . '</span><br/>
                 Please login and change your password.<br/><br/>
                 Support Link: <a href="http://zeeping.com/customer/support.php">http://zeeping.com/customer/support.php</a><br/>
                 <span style="font-size:8pt;font-style:italic">(This is an automatic mail. Doesn\'t reply. Thanks)</span><br/><br/>
                 <img src="http://zeeping.com/image/common/logo.jpg" style="width:200px;height:100px"></img>';
    
        $mail->Body = $body;
    
        $mail->AddAddress($_POST["email"], "Hoang");
    
        $mail->Send();
        
        echo "OK";
    }
    else
    {
        echo "ERROR";
    }
    
?>