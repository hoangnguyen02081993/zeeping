<?php
    include('../../config/config.php'); // Them thu vien
    if(isset($_POST["submit"])) {
        if(!isset($_POST["username"]))
        {
            echo '<script>
                window.location.assign(\'http://zeeping.com/customer/index.php?a=1.0\');
            </script>';
        }
        if(!check_username($_POST["username"]))
        {
            echo '<script>
                window.location.assign(\'http://zeeping.com/customer/index.php?a=1.0\');
            </script>';
        }
        
        // Check if image file uploaded
        $user = getUserInfo($_POST["username"]);
        $uploadimage = $user["userimage"];
        if (!$_FILES['avatar']['size'] == 0 && $_FILES['avatar']['error'] == 0)
        {
            // Check if image file is a actual image or fake image
            $check = getimagesize($_FILES["avatar"]["tmp_name"]);
            if($check !== false) {
                $target_dir = "image/UserImage/";
                $target_file = $target_dir . basename($_FILES["avatar"]["name"]);
                $imageFileType = pathinfo($target_file,PATHINFO_EXTENSION);
                if($imageFileType == "jpg" || $imageFileType == "png" || $imageFileType == "jpeg"
                || $imageFileType == "gif" || $imageFileType == "JPG" || $imageFileType == "PNG" || $imageFileType == "JPEG"
                || $imageFileType == "GIF") {
                    if ($_FILES["avatar"]["size"] <= 10000000) {
                        $target_file = "../../" . $target_dir . $_POST["username"] . '.' . $imageFileType;
                        if (file_exists($target_file)) {
                            unlink($target_file);
                        }
                        if (move_uploaded_file($_FILES["avatar"]["tmp_name"], $target_file)) {
                            $uploadimage = getWebUrl() . '/' . $target_dir . $_POST["username"] . '.' . $imageFileType;
                        }
                        else
                        {
                            $uploadimage = '';
                        }
                    }
                }
            }
        }
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
        $UserInfo["fullname"] = $_POST["fullname"];
        $UserInfo["postalcode"] = $_POST["postalcode"];
        $UserInfo["streetaddress"] = $_POST["streetaddress"];
        $UserInfo["city"] = $_POST["city"];
        $UserInfo["province"] = $_POST["province"];
        $UserInfo["country"] = $_POST["country"];
        $UserInfo["phone_number"] = $_POST["phone_number"];
        $UserInfo["userimage"] = $uploadimage;
        $UserInfo["usernamemd5"] = $user["usernamemd5"];
        
        
        if(UpdateUser($UserInfo))
        {
            //echo 'Update thanh cong';
            
            
            echo '<script>
                alert("Change info successfully");
            </script>';
        }
        else
        {
            //echo 'Update that bai';
            echo '<script>
                alert("Change info failed");
            </script>';
        }
        echo '<script>
            window.location.assign(\'http://zeeping.com/customer/index.php?a=1.0\');
        </script>';
    }
    
?>