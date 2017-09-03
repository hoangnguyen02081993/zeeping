<?php
    include('../../config/config.php');
    if(isset($_POST["Send"]))
    {
        if(isset($_POST["name"]) and $_POST["name"]!="" )
        {
            if(isset($_POST["comment"]) and $_POST["comment"]!="" )
            {   
                $reviewInfo = array(
                                    'comment' => "",
                                    'name' => ""
                                     );
                $reviewInfo["comment"] = $_POST["comment"];
                $reviewInfo["name"] = $_POST["name"];
        
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
            }
            else
            {
                echo '<script>
                alert("Please fill you COMMENT!");
                </script>';
            }
        }
        else
        {
            echo '<script>
            alert("Please fill your NAME!");
            </script>';
        }
    }

    echo '<script>
    window.location.assign(\'http://zeeping.com/\');
    </script>';

?>