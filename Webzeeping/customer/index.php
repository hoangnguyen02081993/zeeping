<!DOCTYPE html>
<html lang="en">
	<head>
		<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
		<meta charset="utf-8" />
		<title>Dashboard - Zeeping User</title>

		<meta name="description" content="overview &amp; stats" />
		<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
        <link rel="shortcut icon" href="<?php echo $WebUrl;  ?>/image/common/logo.ico" type="image/x-icon" />
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
		<script src="assets/js/ace-extra.min.js"></script>

		<!-- HTML5shiv and Respond.js for IE8 to support HTML5 elements and media queries -->

		<!--[if lte IE 8]>
		<script src="assets/js/html5shiv.min.js"></script>
		<script src="assets/js/respond.min.js"></script>
		<![endif]-->
	</head>

	<body class="no-skin">
		 <?php
	        include('../config/config.php');
	        $username = checkLoginAction($_SERVER, $_COOKIE);
	        $user = getUserInfo($username);
	        function IsActive($a_current)
	        {
	            if(!isset($_GET["a"]) && $a_current == 0.0)
	            {
	                echo "active";
	            }
	            else if($a_current == $_GET["a"])
	            {
	                echo "active";
	            }
	        }
	        function IsOpen($a_current)
	        {
	            if(!isset($_GET["a"]))
	            {
	                return;
	            }
	            if($_GET["a"] - $a_current < 1.0 && $_GET["a"] - $a_current > 0)
	            {
	                echo "open";
	            }
	        }
	    ?>
		<div id="navbar" class="navbar navbar-default          ace-save-state">
			<div class="navbar-container ace-save-state" id="navbar-container">
				<button type="button" class="navbar-toggle menu-toggler pull-left" id="menu-toggler" data-target="#sidebar">
					<span class="sr-only">Toggle sidebar</span>

					<span class="icon-bar"></span>

					<span class="icon-bar"></span>

					<span class="icon-bar"></span>
				</button>

				<div class="navbar-header pull-left">
					<a href="http://zeeping.com" class="navbar-brand">
						<img src="http://zeeping.com/image/common/logo.png" style="height:45;width:82.77px;margin-right:35%"></img>
					</a>
				</div>

				<div class="navbar-buttons navbar-header pull-right" role="navigation">
					<ul class="nav ace-nav">
						

						

						<li class="light-blue dropdown-modal">
							<a data-toggle="dropdown" href="#" class="dropdown-toggle">
								<img class="nav-user-photo" src="<?php echo ($user["userimage"] == "" ? "http://zeeping.com/image/UserImage/Default/noimagefound.png" : $user["userimage"]);?>" alt="<?php echo $user["fullname"];?>" />
								<span class="user-info">
									<small>Welcome,</small>
									<?php echo $user["fullname"];?>
								</span>

								<i class="ace-icon fa fa-caret-down"></i>
							</a>

							<ul class="user-menu dropdown-menu-right dropdown-menu dropdown-yellow dropdown-caret dropdown-close">
								<li>
									<a href="index.php?a=1.0">
										<i class="ace-icon fa fa-user"></i>
										Profile
									</a>
								</li>

								<li class="divider"></li>

								<li>
									<a href="logout.php">
										<i class="ace-icon fa fa-power-off"></i>
										Logout
									</a>
								</li>
							</ul>
						</li>
					</ul>
				</div>
			</div><!-- /.navbar-container -->
		</div>

		<div class="main-container ace-save-state" id="main-container">
			<script type="text/javascript">
				try{ace.settings.loadState('main-container')}catch(e){}
			</script>

			<div id="sidebar" class="sidebar                  responsive                    ace-save-state">
				<script type="text/javascript">
					try{ace.settings.loadState('sidebar')}catch(e){}
				</script>

				<div class="sidebar-shortcuts" id="sidebar-shortcuts">

					<div class="sidebar-shortcuts-mini" id="sidebar-shortcuts-mini">
						<span class="btn btn-success"></span>

						<span class="btn btn-info"></span>

						<span class="btn btn-warning"></span>

						<span class="btn btn-danger"></span>
					</div>
				</div><!-- /.sidebar-shortcuts -->

				<ul class="nav nav-list">
					<li class="<?php IsActive(0.0); ?>">
						<a href="index.php">
							<i class="menu-icon fa fa-tachometer"></i>
							<span class="menu-text"> Dashboard </span>
						</a>

						<b class="arrow"></b>
					</li>

					<li class="<?php IsActive(1.0); ?>">
						<a href="index.php?a=1.0">
							<i class="menu-icon fa fa-user"></i>
							<span class="menu-text">
								Profile
							</span>
						</a>
					</li>
					<li class="<?php IsActive(2.0); ?>">
						<a href="index.php?a=2.0">
							<i class="menu-icon fa fa-desktop"></i>
							<span class="menu-text">
								User Infomation
							</span>
						</a>
					</li>

					<li class="<?php IsOpen(3.0); ?>">
						<a href="index.php?a=3.0" class="dropdown-toggle">
							<i class="menu-icon fa fa-list"></i>
							<span class="menu-text"> Order </span>

							<b class="arrow fa fa-angle-down"></b>
						</a>

						<b class="arrow"></b>

						<ul class="submenu">
							<li class="<?php IsActive(3.1); ?>">
								<a href="index.php?a=3.1">
									<i class="menu-icon fa fa-caret-right"></i>
									Completed
								</a>

								<b class="arrow"></b>
							</li>

							<li class="<?php IsActive(3.2); ?>">
								<a href="index.php?a=3.2">
									<i class="menu-icon fa fa-caret-right"></i>
									UnCompleted
								</a>

								<b class="arrow"></b>
							</li>
						</ul>
					</li>

					<li class="<?php IsActive(4.0); ?>">
						<a href="index.php?a=4.0">
							<i class="menu-icon fa fa-pencil-square-o"></i>
							<span class="menu-text"> Change Password </span>

						</a>
					</li>

					<li class="<?php IsActive(5.0); ?>">
						<a href="index.php?a=5.0">
							<i class="menu-icon fa fa-list-alt"></i>
							<span class="menu-text"> User Guide </span>
						</a>

						<b class="arrow"></b>
					</li>
					<li class="<?php IsActive(6.0); ?>">
						<a href="logout.php">
							<i class="menu-icon fa fa-power-off"></i>
							<span class="menu-text"> Log out </span>
						</a>

						<b class="arrow"></b>
					</li>
					
				</ul><!-- /.nav-list -->

				<div class="sidebar-toggle sidebar-collapse" id="sidebar-collapse">
					<i id="sidebar-toggle-icon" class="ace-icon fa fa-angle-double-left ace-save-state" data-icon1="ace-icon fa fa-angle-double-left" data-icon2="ace-icon fa fa-angle-double-right"></i>
				</div>
			</div>

			<div class="main-content">
				<div class="main-content-inner">
					<div class="breadcrumbs ace-save-state" id="breadcrumbs">

						<div class="nav-search" id="nav-search">
							<form class="form-search">
								<span class="input-icon">
									<input type="text" placeholder="Search ..." class="nav-search-input" id="nav-search-input" autocomplete="off" />
									<i class="ace-icon fa fa-search nav-search-icon"></i>
								</span>
							</form>
						</div><!-- /.nav-search -->
					</div>

					<div class="page-content">
					<?php
					if(!isset($_GET["a"]))
					{
					echo '<h1>Over view</h1>
					<p>Zeeping is a specialized online T-shirt store website, we supply designed fashionable and meaningful T-shirt with high quality. Moreover, we will deliver our products around the world with Teespring.com support</p>
<p>With cooperation with Teespring which is best website seller about designed T-shirt. And Zeeping’s creation staffs who bring wonderful online shopping experience for all customers. Especially, we always have interesting promotion programs for customers</p>
<p>For the customers who doesn’t have Zeeping’account<br>
	Step1: Choose any products which you love by yourself<br>
	Step2: Now, you have two ways to buy product you like<br>
_ Click button “Teespring”. After, automatically send to Teespring.com and you can buy product directly<br>
		_ If you would like to discount for following buying, click button “Discount”. Then, you fill out your e-mails and automatically send to Teespring.com and you buy. Then, we are going to supply Zeeping’s account to your e-mails and you can receive accumulation point discount. ( We will supply Zeeping’account within 6 hours when you traded completely)</p>
<p>For the customers who have Zeeping’account<br>
	Now, you are Zeeping’patrons and you are going to be received attractive promotion<br>
	Please log in your account which we sended .You can buy any products at Zeeping.com.<br>
Then, you order directly at Zeeping.store with button “Add to cart” .<br>
Next to, you fill out your discount code which we will supply to your e-mails when you already bought any Zeeping’products.<br>
Finally, you pay by Visa or Master Card or Paypal to Zeeping store and we commit Teespring which delivered to you at your place which you fill out. </p>
<p>	Especially, when you have Zeeping’s account. If you want to print any designed T-shirts with the best price, please send to Zeeping’s store about images, quotes, outlines, ideas you love. Next to, you design and sell designed T-shirt for you.</p>';
                    }
                    else
                    {
                        if($_GET["a"] == 0.0)
                        {
                            echo '<h1>Over view</h1>
					<p>Zeeping is a specialized online T-shirt store website, we supply designed fashionable and meaningful T-shirt with high quality. Moreover, we will deliver our products around the world with Teespring.com support</p>
<p>With cooperation with Teespring which is best website seller about designed T-shirt. And Zeeping’s creation staffs who bring wonderful online shopping experience for all customers. Especially, we always have interesting promotion programs for customers</p>
<p>For the customers who doesn’t have Zeeping’account<br>
	Step1: Choose any products which you love by yourself<br>
	Step2: Now, you have two ways to buy product you like<br>
_ Click button “Teespring”. After, automatically send to Teespring.com and you can buy product directly<br>
		_ If you would like to discount for following buying, click button “Discount”. Then, you fill out your e-mails and automatically send to Teespring.com and you buy. Then, we are going to supply Zeeping’s account to your e-mails and you can receive accumulation point discount. ( We will supply Zeeping’account within 6 hours when you traded completely)</p>
<p>For the customers who have Zeeping’account<br>
	Now, you are Zeeping’patrons and you are going to be received attractive promotion<br>
	Please log in your account which we sended .You can buy any products at Zeeping.com.<br>
Then, you order directly at Zeeping.store with button “Add to cart” .<br>
Next to, you fill out your discount code which we will supply to your e-mails when you already bought any Zeeping’products.<br>
Finally, you pay by Visa or Master Card or Paypal to Zeeping store and we commit Teespring which delivered to you at your place which you fill out. </p>
<p>	Especially, when you have Zeeping’s account. If you want to print any designed T-shirts with the best price, please send to Zeeping’s store about images, quotes, outlines, ideas you love. Next to, you design and sell designed T-shirt for you.</p>';
                        }
                        else if($_GET["a"] == 1.0)
                        {
                            echo '<h2 class="title">Profile</h2>
        <div class="input-confirmation">
	            <form name="frmActive" action="./action/changeInfoaction.php" method="post" enctype="multipart/form-data">
	            <input type="hidden" name="username" value="'. $user["username"] .'"/>
	            
	            <img height="150" id="imageavartar" class="thumbnail inline no-margin-bottom" alt="" src="'. ($user["userimage"] == "" ? "http://zeeping.com/image/UserImage/Default/noimagefound.png" : $user["userimage"]) .'">
                <input type="file" id="fileavatar" name="avatar" accept="image/*"/>
                
                <label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Fullname </label>
                <div class="col-sm-9">
					<input type="text" name="fullname" id="fullname" placeholder="Full name" class="col-xs-10 col-sm-5" required value="' . $user["fullname"] . '">
				</div>
                
	            <label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Postal code </label>
                <div class="col-sm-9">
					<input type="text" name="postalcode" id="postalcode" placeholder="Postal code" class="col-xs-10 col-sm-5" required value="' . $user["postal_code"] . '">
				</div>  
				
				
				<label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Phone Number </label>
                <div class="col-sm-9">
					<input type="text" name="phone_number" id="phone_number" placeholder="Phone Number" class="col-xs-10 col-sm-5" required value="' . $user["phone_number"] . '">
				</div>
				
				<label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Street Address </label>
                <div class="col-sm-9">
					<input type="text" name="streetaddress" id="streetaddress" placeholder="Street Address" class="col-xs-10 col-sm-5" required value="' . $user["street_address"] . '">
				</div>
				
				<label class="col-sm-2 control-label no-padding-right" for="form-field-1"> City </label>
                <div class="col-sm-9">
					<input type="text" name="city" id="city" placeholder="City" class="col-xs-10 col-sm-5" required value="' . $user["city"] . '">
				</div>
				
				<label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Province </label>
                <div class="col-sm-9">
					<input type="text" name="province" id="province" placeholder="Province" class="col-xs-10 col-sm-5" required value="' . $user["province"] . '">
				</div>
                
                <label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Country </label>
                 <div class="col-sm-9">
                <select class="col-xs-10 col-sm-5" name="country" id="form-field-select-1" data-default="United States" required>
                    ';                               
			        $CountryList = getCountry();
					        foreach ($CountryList as $country)
					        {
					            if($user["country_id"] == $country["country_id"])
					            {
					               echo '<option class="country" value="'. $country["country_id"] .'" selected>'. $country["country_name"] .'</option>
					                '; 
					            }
					            else
					            {
					                echo '<option class="country" value="'. $country["country_id"] .'">'. $country["country_name"] .'</option>
					                ';
					            }
					        }
                        echo'
                </select> 
                </div>
                
                <button class="btn btn-info" type="submit" name="submit" value="submit">
					<i class="ace-icon fa fa-check bigger-110"></i>
					Save Profile
				</button>
		        </form>
		        <script>
		            document.getElementById("fileavatar").onchange = function (evt) {
                        var tgt = evt.target || window.event.srcElement,
                            files = tgt.files;
                    
                        // FileReader support
                        if (FileReader && files && files.length) {
                            var fr = new FileReader();
                            fr.onload = function () {
                                document.getElementById("imageavartar").src = fr.result;
                            }
                            fr.readAsDataURL(files[0]);
                        }
                    
                        // Not supported
                        else {
                            // fallback -- perhaps submit the input to an iframe and temporarily store
                            // them on the server until the user\'s session ends.
                        }
                    }
                </script>
        </div>';
                        }
                        else if($_GET["a"] == 2.0)
                        {
                            $Promosion = getPromosionbyUser($user["username"]);
                            echo '
                            <label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Level </label>
                            <div class="col-sm-9">
					            <input type="text" id="form-input-readonly" placeholder="City" class="col-xs-10 col-sm-5" value="'. $Promosion["name"] .'" readonly>
				            </div>
				            <label class="col-sm-2 control-label no-padding-right" for="form-field-1"> Promotion </label>
                            <div class="col-sm-9">
					            <input type="text" "id="form-input-readonly" placeholder="City" class="col-xs-10 col-sm-5" value="'. $Promosion["promosion_value"] .'%" readonly>
				            </div>
                            ';
                        }
                        else if($_GET["a"] == 3.1)
                        {
                            $Orders = getOrderbyUser($user["username"]);
                            $Orders = getObjsbyCondition($Orders,"ischeckoutcompleted",1);
                            $Sizes = getSizes("");
                            $Statuss = getStatus();
                            $products;
                            if(count($Orders) > 0)
                            {
                                $condition = "`product_id` IN (";
                                
                                foreach($Orders as $order)
                                {
                                    $condition .= $order["product_id"] . ","; 
                                }
                                $condition = substr($condition,0,-1);
                                
                                $condition .= ")";
                                
                                
                                $products = getProductbyCondition($condition);
                                
                            }
                            $ContPro = getWebUrl() . '/' . getContentProductRoot();
                            echo '<div class="row">
									<div class="col-xs-12">
										<h3 class="header smaller lighter blue">Completed Order</h3>

										<div class="clearfix">
											<div class="pull-right tableTools-container"></div>
										</div>
										<div class="table-header">
											Results for "All completed Order"
										</div>

										<!-- div.table-responsive -->

										<!-- div.dataTables_borderWrap -->
										<div>
											<table id="dynamic-table" class="table table-striped table-bordered table-hover">
												<thead>
													<tr>
														<th class="center">
															<label class="pos-rel">
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
														</th>
														<th class="hidden-480">Product</th>
														<th class="hidden-480">Quantity</th>
														<th class="hidden-480">Size</th>
														<th class="hidden-480">Price</th>

														<th>
															<i class="ace-icon fa fa-clock-o bigger-110 hidden-480"></i>
															Buyed Date
														</th>
														<th class="hidden-480">Status</th>
													</tr>
												</thead>

												<tbody>';
												foreach($Orders as $order)
												{
												    $product = getObjbyCondition($products,"product_id",$order["product_id"]);
												    echo'<tr>
														<td class="center">
															<label class="pos-rel">
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
														</td>

														<td class="hidden-480"><a href="' . $ContPro . '/' . $product["linkProduct"] . '">' . $order["product_id"] . ' - ' . $product["product_name"] .'</a></td>
														<td class="hidden-480">'. $order["quantity"] .'</td>
														<td class="hidden-480">' . getObjbyCondition($Sizes,"size_id",$order["size_id"])["size_name"] . '</td>
														<td>$' . $order["cost"] . '</td>
                                                        <td>' . $order["createDate"] . '</td>
														<td class="hidden-480">
															    <span class="' . getObjbyCondition($Statuss,"id",$order["isOrderCompleted"])["cssclass"] . '">'. getObjbyCondition($Statuss,"id",$order["isOrderCompleted"])["name"] .'</span>
														</td>

														
													</tr>
													';
												}
												echo'</tbody>
											</table>
										</div>
									</div>
								</div>';
                        }
                        else if($_GET["a"] == 3.2)
                        {
                            $Orders = getOrderbyUser($user["username"]);
                            $Orders = getObjsbyCondition($Orders,"ischeckoutcompleted",0);
                            $Sizes = getSizes("");
                            $Statuss = getStatus();
                            $products;
                            if(count($Orders) > 0)
                            {
                                $condition = "`product_id` IN (";
                                
                                foreach($Orders as $order)
                                {
                                    $condition .= $order["product_id"] . ","; 
                                }
                                $condition = substr($condition,0,-1);
                                
                                $condition .= ")";
                                
                                
                                $products = getProductbyCondition($condition);
                                
                            }
                            $ContPro = getWebUrl() . '/' . getContentProductRoot();
                            echo '<div class="row">
									<div class="col-xs-12">
										<h3 class="header smaller lighter blue">UnCompleted Order</h3>

										<div class="clearfix">
											<div class="pull-right tableTools-container"></div>
										</div>
										<div class="table-header">
											Results for "All Uncompleted Order"
										</div>

										<!-- div.table-responsive -->

										<!-- div.dataTables_borderWrap -->
										<div>
											<table id="dynamic-table" class="table table-striped table-bordered table-hover">
												<thead>
													<tr>
														<th class="center">
															<label class="pos-rel">
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
														</th>
														<th class="hidden-480">Product</th>
														<th class="hidden-480">Quantity</th>
														<th class="hidden-480">Size</th>
														<th class="hidden-480">Price</th>

														<th>
															<i class="ace-icon fa fa-clock-o bigger-110 hidden-480"></i>
															Created Date
														</th>
														<th class="hidden-480">Action</th>
													</tr>
												</thead>

												<tbody>';
												foreach($Orders as $order)
												{
												    $product = getObjbyCondition($products,"product_id",$order["product_id"]);
												    echo'<tr>
														<td class="center">
															<label class="pos-rel">
																<input type="checkbox" class="ace" />
																<span class="lbl"></span>
															</label>
														</td>

														<td class="hidden-480"><a href="' . $ContPro . '/' . $product["linkProduct"] . '">' . $order["product_id"] . ' - ' . $product["product_name"] .'</a></td>
														<td class="hidden-480">'. $order["quantity"] .'</td>
														<td class="hidden-480">' . getObjbyCondition($Sizes,"size_id",$order["size_id"])["size_name"] . '</td>
														<td>' . $order["cost"] . '</td>
                                                        <td>' . $order["createDate"] . '</td>
														<td>
															<div class="hidden-sm hidden-xs action-buttons">

																<a href="./action/continueaction.php?g='. $order["guid"] .'" class="tooltip-success" data-rel="tooltip" title="Continue">
																	<span class="green">
																		<i class="ace-icon fa fa-pencil-square-o bigger-120"></i>
																	</span>
															    </a>

																<a href="./action/deleteaction.php?g='. $order["guid"] .'" class="tooltip-error" data-rel="tooltip" title="Delete">
																	<span class="red">
																		<i class="ace-icon fa fa-trash-o bigger-120"></i>
																	</span>
																</a>
															</div>

															<div class="hidden-md hidden-lg">
																<div class="inline pos-rel">
																	<button class="btn btn-minier btn-yellow dropdown-toggle" data-toggle="dropdown" data-position="auto">
																		<i class="ace-icon fa fa-caret-down icon-only bigger-120"></i>
																	</button>

																	<ul class="dropdown-menu dropdown-only-icon dropdown-yellow dropdown-menu-right dropdown-caret dropdown-close">

																		<li>
																			<a href="./action/continueaction.php?g='. $order["guid"] .'" class="tooltip-success" data-rel="tooltip" title="Continue">
																				<span class="green">
																					<i class="ace-icon fa fa-pencil-square-o bigger-120"></i>
																				</span>
																			</a>
																		</li>

																		<li>
																			<a href="./action/action.php?g='. $order["guid"] .'" class="tooltip-error" data-rel="tooltip" title="Delete">
																				<span class="red">
																					<i class="ace-icon fa fa-trash-o bigger-120"></i>
																				</span>
																			</a>
																		</li>
																	</ul>
																</div>
															</div>
														</td>

														
													</tr>
													';
												}
												echo'</tbody>
											</table>
										</div>
									</div>
								</div>';
                        }
                        else if($_GET["a"] == 4.0)
                        {
                            echo'<div class="col-sm-offset-1 col-sm-10">
											<div class="well well-sm">
												<!-- -
		<button type="button" class="close" data-dismiss="alert">&times;</button>
		&nbsp; -->
												<div class="inline middle blue bigger-110"> Your profile is 100% complete </div>

												&nbsp; &nbsp; &nbsp;
												<div style="width:200px;" data-percent="100%" class="inline middle no-margin progress progress-striped active pos-rel">
													<div class="progress-bar progress-bar-success" style="width:100%"></div>
												</div>
											</div><!-- /.well -->

											<div class="space"></div>

											<form class="form-horizontal" name="frmActive" action="./action/changepasswordaction.php" method="post" onsubmit="return validateForm()" >
											    <input type="hidden" name="username" value="'. $user["username"] .'"/>
												<div class="tabbable">
													<ul class="nav nav-tabs padding-16">

														<li class="active">
															<a data-toggle="tab" href="#edit-password" aria-expanded="true">
																<i class="blue ace-icon fa fa-key bigger-125"></i>
																Password
															</a>
														</li>
													</ul>

													<div class="tab-content profile-edit-tab-content">
														<div id="edit-password" class="tab-pane active">
															<div class="space-10"></div>
                                                                <div class="form-group">
															    	<label class="col-sm-3 control-label no-padding-right" for="form-field-pass1">Old Password</label>
    
															    	<div class="col-sm-9">
															    		<input type="password" name="oldpassword" id="form-field-oldpass" required>
															    	</div>
															    </div>
    
															    <div class="form-group">
															    	<label class="col-sm-3 control-label no-padding-right" for="form-field-pass1">New Password</label>
    
															    	<div class="col-sm-9">
															    		<input type="password" name="password" id="form-field-pass1" required>
															    	</div>
															    </div>
    
															    <div class="space-4"></div>
    
															    <div class="form-group">
															    	<label class="col-sm-3 control-label no-padding-right" for="form-field-pass2">Confirm Password</label>
    
															    	<div class="col-sm-9">
															    		<input type="password" name="confirmpassword" id="form-field-pass2" required>
															    	</div>
															    </div>
														</div>
													</div>
												</div>

												<div class="clearfix form-actions">
													<div class="col-md-offset-3 col-md-9">
														<button class="btn btn-info" type="submot" name="submit">
															<i class="ace-icon fa fa-check bigger-110"></i>
															Save
														</button>
													</div>
												</div>
											</form>
										</div>
										<script>
										    function validateForm() {
                                                var newpass = document.forms["frmActive"]["form-field-pass1"].value;
                                                var confirmpass = document.forms["frmActive"]["form-field-pass2"].value;
                                                if (newpass != confirmpass || newpass == "") {
                                                    alert("New password and confirm password is incorrect");
                                                    document.forms["frmActive"]["form-field-pass1"].value = "";
                                                    document.forms["frmActive"]["form-field-pass2"].value = "";
                                                    return false;
                                                }
                                                else
                                                {
                                                    return true;
                                                }
                                            }
										</script>
										';
                        }
                        else
                        {
                            echo '<h1>Over view</h1>
					<p>Zeeping is a specialized online T-shirt store website, we supply designed fashionable and meaningful T-shirt with high quality. Moreover, we will deliver our products around the world with Teespring.com support</p>
<p>With cooperation with Teespring which is best website seller about designed T-shirt. And Zeeping’s creation staffs who bring wonderful online shopping experience for all customers. Especially, we always have interesting promotion programs for customers</p>
<p>For the customers who doesn’t have Zeeping’account<br>
	Step1: Choose any products which you love by yourself<br>
	Step2: Now, you have two ways to buy product you like<br>
_ Click button “Teespring”. After, automatically send to Teespring.com and you can buy product directly<br>
		_ If you would like to discount for following buying, click button “Discount”. Then, you fill out your e-mails and automatically send to Teespring.com and you buy. Then, we are going to supply Zeeping’s account to your e-mails and you can receive accumulation point discount. ( We will supply Zeeping’account within 6 hours when you traded completely)</p>
<p>For the customers who have Zeeping’account<br>
	Now, you are Zeeping’patrons and you are going to be received attractive promotion<br>
	Please log in your account which we sended .You can buy any products at Zeeping.com.<br>
Then, you order directly at Zeeping.store with button “Add to cart” .<br>
Next to, you fill out your discount code which we will supply to your e-mails when you already bought any Zeeping’products.<br>
Finally, you pay by Visa or Master Card or Paypal to Zeeping store and we commit Teespring which delivered to you at your place which you fill out. </p>
<p>	Especially, when you have Zeeping’s account. If you want to print any designed T-shirts with the best price, please send to Zeeping’s store about images, quotes, outlines, ideas you love. Next to, you design and sell designed T-shirt for you.</p>';
                        }
                    }
        ?>
					</div><!-- /.page-content -->
				</div>
			</div><!-- /.main-content -->

			<div class="footer">
				<div class="footer-inner">
					<div class="footer-content">
						<span class="bigger-120">
							<a href="http://zeeping.com"><span class="blue bolder">Zeeping</span></a>
							Application &copy; 2017-2018
						</span>

						&nbsp; &nbsp;
						<span class="action-buttons">
							<a href="#">
								<i class="ace-icon fa fa-twitter-square light-blue bigger-150"></i>
							</a>

							<a href="#">
								<i class="ace-icon fa fa-facebook-square text-primary bigger-150"></i>
							</a>

							<a href="#">
								<i class="ace-icon fa fa-rss-square orange bigger-150"></i>
							</a>
						</span>
					</div>
				</div>
			</div>

			<a href="#" id="btn-scroll-up" class="btn-scroll-up btn btn-sm btn-inverse">
				<i class="ace-icon fa fa-angle-double-up icon-only bigger-110"></i>
			</a>
		</div><!-- /.main-container -->

		<!-- basic scripts -->

		<!--[if !IE]> -->
		<script src="assets/js/jquery-2.1.4.min.js"></script>

		<!-- <![endif]-->

		<!--[if IE]>
<script src="assets/js/jquery-1.11.3.min.js"></script>
<![endif]-->
		<script type="text/javascript">
			if('ontouchstart' in document.documentElement) document.write("<script src='assets/js/jquery.mobile.custom.min.js'>"+"<"+"/script>");
		</script>
		<script src="assets/js/bootstrap.min.js"></script>

		<!-- page specific plugin scripts -->

		<!--[if lte IE 8]>
		  <script src="assets/js/excanvas.min.js"></script>
		<![endif]
		<script src="assets/js/jquery-ui.custom.min.js"></script>
		<script src="assets/js/jquery.ui.touch-punch.min.js"></script>
		<script src="assets/js/jquery.easypiechart.min.js"></script>
		<script src="assets/js/jquery.sparkline.index.min.js"></script>
		<script src="assets/js/jquery.flot.min.js"></script>
		<script src="assets/js/jquery.flot.pie.min.js"></script>
		<script src="assets/js/jquery.flot.resize.min.js"></script>-->

		<!-- ace scripts -->
		<script src="assets/js/ace-elements.min.js"></script>
		<script src="assets/js/ace.min.js"></script>

		<!-- page specific plugin scripts -->
		<script src="assets/js/jquery.dataTables.min.js"></script>
		<script src="assets/js/jquery.dataTables.bootstrap.min.js"></script>
		<script src="assets/js/dataTables.buttons.min.js"></script>
		<script src="assets/js/buttons.flash.min.js"></script>
		<script src="assets/js/buttons.html5.min.js"></script>
		<script src="assets/js/buttons.print.min.js"></script>
		<script src="assets/js/buttons.colVis.min.js"></script>
		<script src="assets/js/dataTables.select.min.js"></script>

		

		<!-- inline scripts related to this page -->
		<script type="text/javascript">
		    <?php
		        if($_GET["a"] == 4.0 || $_GET["a"] == 1.0 || $_GET["a"] == 2.0)
		        {
			        include('./source/scriptform.php');
		        }
		        else if($_GET["a"] == 3.1 || $_GET["a"] == 3.2 )
		        {
		            include('./source/scripttable.php');
		        }
		    ?>
		</script>
	</body> 
<style>
    .navbar {
    margin: 0;
    padding-left: 0;
    padding-right: 0;
    border-width: 0;
    border-radius: 0;
    -webkit-box-shadow: none;
    box-shadow: none;
    min-height: 45px;
    background: #3baeff;
}
</style>
</html> 
    