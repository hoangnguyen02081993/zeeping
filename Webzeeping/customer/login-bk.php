<!DOCTYPE html>
<html >
<head>
    
  <meta charset="UTF-8">
  <title>Login</title>
  <?php
  
    include('../config/config.php');
    
    if(isset($_POST["submit"]))
    {
        
        $ip = get_client_ip($_SERVER);
        
        $conn = db_connect();
        $str_q = "call sp_checksignin('". $_POST["username"] . "','" . md5($_POST["password"]) . "', @session_id,'" . $ip ."')";
        $result = mysql_query($str_q,$conn);
        $session_id = mysql_fetch_assoc($result)["session1"];
        db_disconnect($conn);
        
        if($session_id != -1)
        {
            setcookie('session_id', $session_id, time() + 3600, "/");
            $WebUrl = getWebUrl();
            $WebUrlWWW = getWebUrlWWW();
            if(isset($_POST["url"]))
            {
                header('Location: '. str_replace($WebUrlWWW,$WebUrl,$_POST["url"]));
            }
            else
            {
                header('Location: ' . $WebUrl);
            }
        }
        else
        {
            echo '<script>
                alert("User or Password is incorrect");
            </script>';
        }
        
    }
    if(isset($_COOKIE["session_id"]))
    {
        $session_id = $_COOKIE["session_id"];
		$ip = get_client_ip($_SERVER);
		$username = check_issignin($session_id,$ip);
		if($username != '')
		{
		    $WebUrl = getWebUrl();
            $WebUrlWWW = getWebUrlWWW();
            if(isset($_POST["url"]))
            {
                header('Location: '. str_replace($WebUrlWWW,$WebUrl,$_POST["url"]));
            }
            else
            {
                header('Location: ' . $WebUrl);
            }
		}
    }
  ?>
  
      <!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->

		<!-- text fonts -->
		<link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />

		<!-- ace styles -->
		<link rel="stylesheet" href="assets/css/ace.min.css" class="ace-main-stylesheet" id="main-ace-style" />

		<!--[if lte IE 9]>
			<link rel="stylesheet" href="assets/css/ace-part2.min.css" class="ace-main-stylesheet" />
		<![endif]-->
		<link rel="stylesheet" href="assets/css/ace-skins.min.css" />
		<link rel="stylesheet" href="assets/css/ace-rtl.min.css" />

		<!--[if lte IE 9]>
		  <link rel="stylesheet" href="assets/css/ace-ie.min.css" />
		<![endif]-->

		<!-- inline styles related to this page -->

		<!-- ace settings handler -->
      <link rel="stylesheet" href="css/style-login.css">

  
</head>

<body>
  <div class="wrapper">
	<div class="container">
		<h1>Welcome</h1>
		
		<form  name="frmLogin" action="./login.php" method="POST" class="form login">
			<input id="login__username" type="text" name="username" placeholder="Username">
			<input id="login__password" type="password" name="password" placeholder="Password">
			
			<input type="submit" id="btn_submit" name="submit" value="Login">
			
			<?php
    		    if(isset($_POST["url"]))
    		    {
    		        echo "<input type=\"hidden\" name=\"url\" value=\"". $_POST["url"] ."\"/>";
    		    }
    		?>
		</form>
	</div>
	
	<ul class="bg-bubbles">
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
		<li></li>
	</ul>
</div>

</body>
</html>
