<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Register - Zeeping</title>

		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />

		<!-- bootstrap & fontawesome -->
		<link rel="stylesheet" href="assets/css/bootstrap.min.css" />
		<link rel="stylesheet" href="assets/font-awesome/4.5.0/css/font-awesome.min.css" />

		<!-- page specific plugin styles -->

		<!-- text fonts -->
		<link rel="stylesheet" href="assets/css/fonts.googleapis.com.css" />
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
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
		<script src="assets/js/ace-extra.min.js"></script>

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
		<?php include('../config/config.php'); ?>
	</head>
	
<body>
<?php
    if(!isset($_GET["u"]))
    {
        echo '404 ERROR';
    }
    else
    {
        $conn = db_connect();
        $sql_querty = 'SELECT `username`, `isenable` FROM `order_user` WHERE `usernamemd5` = \'' . $_GET["u"] . '\'';
        $user = mysql_query($sql_querty,$conn);
        $count = mysql_num_rows($user);
        if($count == 0)
        {
            echo '404 ERROR';
        }
        else
        {
            //$row=mysql_fetch_array($user);
            $isenable = mysql_fetch_assoc($user)["isenable"];
            //$isenable = $row["isenable"];
            if($isenable == 1)
            {
                echo 'Tai khoan da dc kich hoat';
            }
            else
            {
echo '<form name="frmActive" action="./action/activeaccount.php" method="post" onsubmit="return validateForm()">
<div class="page-content"style="padding-top:5%">
						
    <div class="row" >
												
									<div class="col-sm-10 col-sm-offset-2" >
									    <div class="widget-header widget-header-large col-sm-8" style="margin:2%">
												<h3 class="widget-title grey lighter ">
													<img  src="http://zeeping.com/image/common/logo.png" style="height:49.2px;width:90.5px;margin-right:35%"></img>
													<b class="col-sm-5" style="font-size:1.325em">Register </b>
												</h3>

											</div>
											
										<div class="widget-box transparent">
											

											<div class="widget-body">
												<div class="widget-main padding-24">
													<div class="row">
														<div class="col-sm-5">
															

															<div>
																<ul class="list-unstyled spaced" >
																    <li >
																        <input  style="width:70%;height:6%" type="password" name="newpass" placeholder="New Pass" id="newpass" required />
																    </li>
																    
																    <li >
																        <input  style="width:70%;height:6%" type="password" name="confirmpass" placeholder="Confirm Pass" id="confirmpass" required />
																    </li>
																    
																    <li >
																       <input  style="width:70%;height:6%" type="text" name="firstname" placeholder="First Name" id="firstname" required />
																    </li>
																    
																    <li >
																        <input  style="width:70%;height:6%" type="text" name="lastname" placeholder="Last Name" id="lastname" required />
																    </li>
																    
																    <li >
																        <input  style="width:70%;height:6%" type="text" name="postalcode" placeholder="Postal Code" id="postalcode" required />
																    </li>
                                                                    
                                                                        
                                                                    
																</ul>
															</div>
														</div><!-- /.col -->

														<div class="col-sm-5">
														

															<div>
																<ul class="list-unstyled  spaced">
																	<li >
																        <input  style="width:70%;height:6%" type="tel" name="phone_number" placeholder="Phone Number" id="phone_number" required />
																    </li>
																    
																    <li >
																        <input  style="width:70%;height:6%" type="text" name="streetaddress" placeholder="Street Address" id="streetaddress" required />
																    </li>
																    
																    <li >
																        <input  style="width:70%;height:6%" type="text" name="city" placeholder="City" id="city" required />
																    </li>
																    
																    <li >
																        <input  style="width:70%;height:6%" type="text" name="province" placeholder="Province/State" id="province" required />
																    </li>
																    
																    <li >
																        <select style="width:70%;height:6%" name="country" id="country" data-default="United States" required>
                                                                            ';                               
                                                        			        $sql_querty = 'SELECT `country_id`, `country_name`, `country_region` FROM `order_country`';
                                                                            $countryList = mysql_query($sql_querty,$conn);
                                                                            while($row=mysql_fetch_array($countryList)){
                                                                            echo'<option value="' . $row["country_id"] . '">' . $row["country_name"] .'</option>
                                                                            ';    
                                                                            }
                                                                                echo'
                                                                        </select> 
																    </li>
																</ul>
															</div>
														</div><!-- /.col -->
													</div><!-- /.row -->

													<div class="space"></div>

													

													

													<div class="row col-sm-9" style="padding-right:3%">
													    <div class="hr hr8 hr-double hr-dotted"></div>
														<div class="wizard-actions">
    														    <input type="hidden" name="isaction" value="1" ></input>
                                                                <input type="hidden" name="usernamemd5" value="' . $_GET["u"] . '" ></input>
															

															<button  class="btn-register"  name="action" value="Finish" type="submit">
															Next
															<i class="ace-icon fa fa-arrow-right icon-on-right"></i>
															</button>
											            </div>
														
												</div>
												
											</div>
										</div>
									</div>
								</div>
								</form>';
								echo '<script>
function validateForm() {
    var newpass = document.forms["frmActive"]["newpass"].value;
    var confirmpass = document.forms["frmActive"]["confirmpass"].value;
    if (newpass != confirmpass || newpass == "") {
        alert("New password and confirm password is incorrect");
        document.forms["frmActive"]["newpass"].value = "";
        document.forms["frmActive"]["confirmpass"].value = "";
        return false;
    }
    else
    {
        return true;
    }
}
</script>';
            }
        }
        db_disconnect($conn);
    }
?>

 
<style>
    .btn-register{
        background-color:#f62f5e;
        font-size:16px;
        color:#fff;
        width: 163px;
        height: 48px;
        cursor: pointer;
        transition: all .2s ease-in-out;
        letter-spacing: 1px;
        border: none;
        border-radius: 23px;
    }
    .btn-register:hover{
        background-color:#f62f5e;
        font-size:16px;
        color:#fff;
        width: 163px;
        height: 48px;
        cursor: pointer;
        transition: all .2s ease-in-out;
        letter-spacing: 1px;
        border: none;
        border-radius: 23px;
        transform: scale(1.1); 
    }
</style>

</body>
</html>