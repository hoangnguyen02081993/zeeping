<?php
    include('../../config/config.php');
    
    if(!isset($_POST["Send"]))
    {
        echo '<script>
        window.location.assign(\'http://zeeping.com/\');
        </script>';
        return;
    }
    
    
    if(!isset($_POST["user"]))
    {
        echo '<script>
        window.location.assign(\'http://zeeping.com/\');
        </script>';
        return;
    }
    $userinfo;    
    $conn = db_connect();
    $sql_querty = 'SELECT `username` FROM `order_user` WHERE `usernamemd5` = \'' . $_POST["user"] . '\' and `isenable` = 1';
    $user = mysql_query($sql_querty,$conn);
    db_disconnect($conn);
    $count = mysql_num_rows($user);
    if($count == 0)
    {
        return;
    }
    $userinfo = mysql_fetch_assoc($user);
    
    
    
    
    if(!isset($_POST["name"]) or $_POST["name"] == "")
    {
        return;
    }
    
    if(!isset($_POST["comment"]) or $_POST["comment"] == "" )
    {
        return;
    }

    $reviewInfo = array(
                        'comment' => "",
                        'name' => "",
                        'username' => ""
                         );
    $reviewInfo["comment"] = $_POST["comment"];
    $reviewInfo["name"] = $_POST["name"];
    $reviewInfo["username"] = $userinfo["username"];
        
    if(InsertReview($reviewInfo))
    {
        //echo 'Insert thanh cong';
        echo '<script>
            alert("Command successfully. Thanks");
        </script>';
    }
    else
    {
        //echo 'Insert that bai';
        echo '<script>
            alert("Command failed. Please try again!");
        </script>';
    }


    echo '<script>
    window.location.assign(\'http://zeeping.com/\');
    </script>';
?>