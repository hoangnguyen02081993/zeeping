<?php
    include('../../config/config.php'); // Them thu vien
    if(isset($_POST["submit"])) {
        if(!isset($_POST["username"]))
        {
            echo '<script>
                window.location.assign(\'http://zeeping.com/customer/index.php?a=4.0\');
            </script>';
        }
        if(!check_username($_POST["username"]))
        {
            echo '<script>
                window.location.assign(\'http://zeeping.com/customer/index.php?a=4.0\');
            </script>';
        }
        
        // Check if image file uploaded
        $user = getUserInfo($_POST["username"]);
        if(md5($_POST["oldpassword"]) != $user["password"])
        {
            echo '<script>
                alert("Old password is incorrect");
                window.location.assign(\'http://zeeping.com/customer/index.php?a=4.0\');
            </script>';
        }
        $UserInfo = array(
                    'password' => "",
                    'usernamemd5' => ""
                    );
        $UserInfo["password"] = $_POST["password"];
        $UserInfo["usernamemd5"] = $user["usernamemd5"];
        
        
        if(UpdateUserPassword($UserInfo))
        {
            //echo 'Update thanh cong';
            
            
            echo '<script>
                alert("Change password successfully");
            </script>';
        }
        else
        {
            //echo 'Update that bai';
            echo '<script>
                alert("Change password failed");
            </script>';
        }
        echo '<script>
            window.location.assign(\'http://zeeping.com/customer/index.php?a=4.0\');
        </script>';
    }
    
?>