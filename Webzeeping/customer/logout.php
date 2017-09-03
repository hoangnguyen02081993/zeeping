<?php
  
    include('../config/config.php');
    if(isset($_COOKIE["session_id"]))
    {
        $ip = get_client_ip($_SERVER);
        $del_result = del_session($_COOKIE["session_id"], $ip);
		if($del_result == true)
		{
		    setcookie("session_id", "", time()-3600);
		    
            if(isset($_POST["url"]))
            {
                header('Location: '. $_POST["url"]);
            }
            else
            {
                header('Location: http://www.zeeping.com/');
            }
		}
		else
		{
		    echo "<script>";
	        echo "alert(\" Error \")";
	        echo "</script>";
		    header('Location: http://www.zeeping.com/');
		}
    }
    else
    {
        header('Location: http://www.zeeping.com/');
    }
  ?>