<?php

/*---------------------------------------connect DB-----------------------------------------------------------------------------------*/
function db_connect()
{
    $conn=mysql_connect(constant("zee_DB_HOST"), constant("zee_DB_USER"), constant("zee_DB_PASSWORD")) or die("can't connect database");
    mysql_select_db(constant("zee_DB_NAME"),$conn);
    return $conn;
}
function db_disconnect($conn)
{
    mysql_close($conn);
}


/*------------------------------check invalid-----------------------------------------------------------------------------------------*/


function check_issignin($session_id,$ip)
{
    //echo "<script>";
	//echo "alert(\" username: " . $session_id . ":" . $ip . "\")";
	//echo "</script>";
    $result = '';
    $conn = db_connect();
    
    $sql_query = "SELECT username from order_session where session_id = '" . $session_id . "' and ip = '" . $ip . "' LIMIT 1";
    
    $rs_query = mysql_query($sql_query,$conn);
    if(mysql_num_rows($rs_query) == 1)
    {
        $rs_query = mysql_fetch_assoc($rs_query);  
        $result = $rs_query["username"];
        
        // update last_time of this session
        $sql_query = "UPDATE `order_session` SET `last_time`= NOW() where session_id = '" . $session_id . "' and ip = '" . $ip . "'";
        mysql_query($sql_query,$conn);
        
        // delete any other session time out
        $sql_query = "DELETE FROM `order_session` WHERE DATE_ADD(last_time, INTERVAL 1 HOUR) < NOW()";
        mysql_query($sql_query,$conn);
    }
    
    db_disconnect($conn);
    
    return $result;
}
function check_username($username)
{
    $result = false;
    $conn = db_connect();
    
    $sql_query = "SELECT username from `order_user` where `username` = '" . $username . "' and `isenable` = true LIMIT 1";
    
    $rs_query = mysql_query($sql_query,$conn);
    if(mysql_num_rows($rs_query) == 1)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function IsHaveOrder($guid)
{
    $result = false;
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order` where `guid` = '" . $guid . "' and ischeckoutcompleted = False";
    
    $rs_query = mysql_query($sql_query,$conn);
    if(mysql_num_rows($rs_query) > 0)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function IsOrderComplete($guid)
{
    $result = -1;
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order` where `guid` = '" . $guid . "'";
    
    $rs_query = mysql_query($sql_query,$conn);
    if(mysql_num_rows($rs_query) == 1)
    {
        if(mysql_fetch_assoc($rs_query)["ischeckoutcompleted"])
        {
            $result = 0;
        }
        else
        {
            $result = 1;
        }
    }
    
    db_disconnect($conn);
    
    return $result;
}
function IsHaveProduct($product_link)
{
    $result = false;
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order_product` where `linkProduct` = '" . $product_link . "'";
    
    $rs_query = mysql_query($sql_query,$conn);
    if(mysql_num_rows($rs_query) == 1)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}


/*------------------------------select----------------------------------------------------------------------------------------------*/


function getUserInfo($username)
{
    
    $conn = db_connect();
    
    $sql_query = "SELECT * from order_user where username = '". $username ."' LIMIT 1" ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $rs_query = mysql_fetch_assoc($rs_query);
    
    db_disconnect($conn);
    
    return $rs_query;
    
    
}
function getUserFullname($username)
{
    $fullname = '';
    
    $conn = db_connect();
    
    $sql_query = "SELECT fullname from order_user where username = '". $username ."' LIMIT 1" ;
    
    $rs_query = mysql_query($sql_query,$conn);
    if(mysql_num_rows($rs_query) == 1)
    {
        $fullname = mysql_fetch_assoc($rs_query)["fullname"];
    }
    
    db_disconnect($conn);
    
    return $fullname;
    
    
}
function getSizes($condition)
{
    $SizeList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product_size` " . $condition . " order by size_id"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($SizeList, $row);
    }
    
    db_disconnect($conn);
    
    return $SizeList;
}
function getOrderbyGuid($guid)
{
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order` where `guid` = '". $guid ."' LIMIT 1" ;
    
    $rs_query = mysql_query($sql_query,$conn);
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getProductbyId($id)
{
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product` where `product_id` = '". $id ."' LIMIT 1" ;
    
    $rs_query = mysql_query($sql_query,$conn);
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getColorbyId($id)
{
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product_color` where `color_id` = '". $id ."' LIMIT 1" ;
    
    $rs_query = mysql_query($sql_query,$conn);
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}

function getStylebyId($style_id)
{

    $conn = db_connect();
    
    $sql_query = "SELECT * from `order_product_style` where `style_id` = '". $style_id ."' LIMIT 1" ;
    
    $rs_query = mysql_query($sql_query,$conn);
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
} 
function getStatus()
{
    $OrderList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order_status`";
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($OrderList, $row);
    }
    
    db_disconnect($conn);
    
    return $OrderList;
}
function getOrder($guid)
{
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order` where `guid` = '" . $guid . "' LIMIT 1";
    $rs_query = mysql_query($sql_query,$conn);
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getOrderbyUser($username)
{
    
    $OrderList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * from `order` where `username` = '" . $username . "'";
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($OrderList, $row);
    }
    
    db_disconnect($conn);
    
    return $OrderList;
}
function getCountry()
{
    $CountryList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_country`";
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($CountryList, $row);
    }
    
    db_disconnect($conn);
    
    return $CountryList;
}
function getCountrybyId($country_id)
{
 
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_country` where `country_id` = '" . $country_id . "' LIMIT 1";
    
    $rs_query = mysql_query($sql_query,$conn);
    
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getCostShipCountry($country,$count)
{
    $result = 0.0;
    
    if($count > 0)
    {
        $result += $country["ship_cost"] + (($count - 1) * $country["ship_per_item_cost"]);
    }
    
    return $result;
}
function getPromosions()
{
    $PromosionList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_user_promosion` order by id"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($PromosionList, $row);
    }
    
    db_disconnect($conn);
    
    return $PromosionList;
}
function getPromosionbyUser($username)
{
    $user = getUserInfo($username);
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_user_promosion` where `promosion_begin` <= " . $user["promosion_money"] . " and `promosion_end` >= " . $user["promosion_money"]  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getCostafterPromosion($cost,$promosion)
{
    return $cost - ($cost * $promosion["promosion_value"]) / 100;
}
function getIsTestPayPal()
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_options` where `option_name` = 'IsTestPayPal'"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $result = mysql_fetch_assoc($rs_query)["option_value"];
    
    db_disconnect($conn);
    
    return $result;
}
function getWebUrl()
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_options` where `option_name` = 'WebUrl'"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $result = mysql_fetch_assoc($rs_query)["option_value"];
    
    db_disconnect($conn);
    
    return $result;
}
function getWebUrlWWW()
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_options` where `option_name` = 'WebUrlWWW'"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $result = mysql_fetch_assoc($rs_query)["option_value"];
    
    db_disconnect($conn);
    
    return $result;
}
function getContentProductRoot()
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_options` where `option_name` = 'ContentProductRoot'"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $result = mysql_fetch_assoc($rs_query)["option_value"];
    
    db_disconnect($conn);
    
    return $result;
}
function getImageProductRoot()
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_options` where `option_name` = 'IamgeProductRoot'"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $result = mysql_fetch_assoc($rs_query)["option_value"];
    
    db_disconnect($conn);
    
    return $result;
}
function getImageCollectgionsRoot()
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_options` where `option_name` = 'PathImageCollections'"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $result = mysql_fetch_assoc($rs_query)["option_value"];
    
    db_disconnect($conn);
    
    return $result;
}
function getAllMenuWeb()
{
    $MenuList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `web_menu_group` order by `stt`"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($MenuList, $row);
    }
    
    db_disconnect($conn);
    
    return $MenuList;
}
function getSearchSession($searhlink,$ip)
{
    $result = "0";
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `web_search_session` where `link` = '" . $searhlink . "' and `ip` = '" . $ip . "' LIMIT 1"  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $sql_query = "DELETE FROM `web_search_session` where `link` = '" . $searhlink . "' and `ip` = '" . $ip . "'"  ;
    
    
    mysql_query($sql_query,$conn);
    
    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getNewProducts($count)
{
    $ProList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product` order by `createdDate` desc LIMIT " . $count  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($ProList, $row);
    }
    
    db_disconnect($conn);
    
    return $ProList;
}
function getFeaturedProducts($count)
{
    $ProList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product` where `isFeaturedProduct` = 1 order by `createdDate` desc LIMIT " . $count  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($ProList, $row);
    }
    
    db_disconnect($conn);
    
    return $ProList;
}
function getBestSellerProducts($count)
{
    $ProList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product` order by `sellerCount` LIMIT " . $count  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($ProList, $row);
    }
    
    db_disconnect($conn);
    
    return $ProList;
}
function getCatogaryProducts($count,$catogary_id)
{
    $ProList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `order_product` where Catogarys like '%," . $catogary_id . "' 
                                                   or Catogarys like '" . $catogary_id . ",%'
                                                   or Catogarys like '%," . $catogary_id . ",%'
                                                   or Catogarys = '" . $catogary_id . "' order by `createdDate` desc LIMIT " . $count  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($ProList, $row);
    }
    
    db_disconnect($conn);
    
    return $ProList;
}
function getRelatedProducts($count,$catogary)
{
    $ProList = array();
    
    $conn = db_connect();
    
    $catogaryArray = explode(",",$catogary);
    
    $sql_query = "SELECT * FROM `order_product` where ";
    foreach($catogaryArray as $catogary)
    {
        $sql_query .= "`Catogarys` like '%" . $catogary . "%' or ";
    }
    $sql_query = substr($sql_query,0,strlen($sql_query) - 3);
    $sql_query .= " order by `createdDate` desc LIMIT " . $count  ;
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($ProList, $row);
    }
    
    db_disconnect($conn);
    
    return $ProList;
}
function getSearchProduct($count, $searchlink)
{
    $ProList = array();
    
    $conn = db_connect();
    
    $HashtagArray = explode("-",$searchlink);
    
    $sql_query = "SELECT * FROM `order_product` where ";
    foreach($HashtagArray as $Hashtag)
    {
        $sql_query .= "`hashtag` like '%" . $Hashtag . "%' or ";
    }
    $sql_query = substr($sql_query,0,strlen($sql_query) - 3);
    $sql_query .= " order by `createdDate` desc LIMIT " . $count  ;
    $rs_query = mysql_query($sql_query,$conn);
        
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($ProList, $row);
    }
    
    db_disconnect($conn);
    
    return $ProList;
}

function getFAQs($count)
{
    $FAQList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `web_page_FAQ` order by `id` LIMIT " . $count  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($FAQList, $row);
    }
    
    db_disconnect($conn);
    
    return $FAQList;
}
function getPagecontentbyId($id)
{
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `web_menu_page` where `relatedmenu` = " . $id . " LIMIT 1";
    
    $rs_query = mysql_query($sql_query,$conn);

    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
function getTestimonials($count)
{
    $TestimonialList = array();
    
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `web_page_testimonial` order by `createdate` LIMIT " . $count  ;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    $row;
    while($row=mysql_fetch_array($rs_query)){
        array_push($TestimonialList, $row);
    }
    
    db_disconnect($conn);
    
    return $TestimonialList;
}
function getCollectionbyId($id)
{
    
  
    $conn = db_connect();
    
    $sql_query = "SELECT * FROM `web_collections` where `id` = " . $id . " LIMIT 1";
    
    $rs_query = mysql_query($sql_query,$conn);

    db_disconnect($conn);
    
    return mysql_fetch_assoc($rs_query);
}
/*------------------------------insert-----------------------------------------------------------------------------------------*/


function AddSupportFeedback($supportInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "INSERT INTO `order_user_support`(`name`, `mail`, `phonenumber`, `message`) VALUES (";
    
    $sql_query .= "'" . str_replace("'", "\'", $supportInfo["name"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $supportInfo["mail"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $supportInfo["phonenumber"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $supportInfo["message"]) . "'";
    
    $sql_query .= ")";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function AddTrackingMail($MailInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "INSERT INTO `order_mail_tracking`( `email`, `style_id`, `color_id`, `date`) VALUES ('". $_POST["email"] . "','" . $_POST["style_id"] . "','" .  $_POST["color_id"] . "',NOW())";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function InsertOrderStep1($OrderInfo)
{
    $result = false;
    
    $User = getUserInfo($OrderInfo["username"]);
    
    if($User == null)
    {
        return false;
    }
    
    
    $conn = db_connect();
    
    $sql_query = "INSERT INTO `order`(`guid`, `product_id`, `style_id`, `color_id`, `size_id`, `quantity`, `username`, `email`, `firstname`, `lastname`, `street_address`, `apt_suite_other`, `city`, `postal_code`, `country_id`, `phone_number`, `province`) VALUES (";
    
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["guid"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["product_id"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["style_id"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["color_id"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["size_id"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["quantity"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $OrderInfo["username"]) . "',";
    $sql_query .= "'" . $User["email"] . "',";
    $sql_query .= "'" . explode(" ",$User["fullname"])[0] . "',";
    $sql_query .= "'" . explode(" ",$User["fullname"])[1] . "',";
    $sql_query .= "'" . $User["street_address"] . "',";
    $sql_query .= "'" . $User["apt_suite_other"] . "',";
    $sql_query .= "'" . $User["city"] . "',";
    $sql_query .= "'" . $User["postal_code"] . "',";
    $sql_query .= "'" . $User["country_id"] . "',";
    $sql_query .= "'" . $User["phone_number"] . "',";
    $sql_query .= "'" . $User["province"] . "'";
    
    
    
    $sql_query .= ")";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}

function InsertSearchSesssion($name,$link,$ip)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "INSERT INTO `web_search_session`(`name`, `link`, `ip`) VALUES (";
    
    $sql_query .= "'" . str_replace("'", "\'", $name) . "',";
    $sql_query .= "'" . $link . "',";
    $sql_query .= "'" . $ip . "'";
    
    $sql_query .= ")";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function InsertReview($reviewInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "INSERT INTO `web_page_testimonial`(`testimonial`, `createguest`, `createuser`) VALUES (";
    
    $sql_query .= "'" . str_replace("'", "\'", $reviewInfo["comment"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $reviewInfo["name"]) . "',";
    $sql_query .= "'" . str_replace("'", "\'", $reviewInfo["username"]) . "'";
    $sql_query .= ")";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}


/*------------------------------update-----------------------------------------------------------------------------------------*/


function UpdateUser($UserInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order_user` SET ";
    
    
    if(isset($UserInfo["newpass"])) { $sql_query .= "`password`= '" . md5($UserInfo["newpass"]) . "',"; }
    $sql_query .= "`fullname`= '" . str_replace("'", "\'", $UserInfo["fullname"]) . "',";
    $sql_query .= "`postal_code`= '" . str_replace("'", "\'", $UserInfo["postalcode"]) . "',";
    $sql_query .= "`street_address`= '" . str_replace("'", "\'", $UserInfo["streetaddress"]) . "',";
    $sql_query .= "`city`= '" . str_replace("'", "\'", $UserInfo["city"]) . "',";
    $sql_query .= "`province`= '" . str_replace("'", "\'", $UserInfo["province"]) . "',";
    $sql_query .= "`phone_number`= '" . str_replace("'", "\'", $UserInfo["phone_number"]) . "',";
    $sql_query .= "`country_id`= '" . str_replace("'", "\'", $UserInfo["country"]) . "',";
    $sql_query .= "`userimage`= '" . $UserInfo["userimage"] . "',";
    $sql_query .= "`isenable`= '1'";
    
    $sql_query .= "WHERE `usernamemd5` = '" . $UserInfo["usernamemd5"] . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function UpdateUserPromosion($usernane, $Addition_promosion)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order_user` SET ";
    
    
    $sql_query .= "`promosion_money`= `promosion_money` + " . $Addition_promosion;
    
    $sql_query .= "WHERE `username` = '" . $usernane . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function UpdateUserPassword($UserInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order_user` SET ";
    
    
    $sql_query .= "`password`= '" . md5($UserInfo["password"]) . "'";
    $sql_query .= "WHERE `usernamemd5` = '" . $UserInfo["usernamemd5"] . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function UpdateProductSellerCount($product_id, $count)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order_product` SET ";
    
    
    $sql_query .= "`sellerCount`= `sellerCount` + " . $count;
    
    $sql_query .= " WHERE `product_id` = '" . $product_id . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function UpdateOrderStep1($OrderInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order` SET ";
    
    
    $sql_query .= "`size_id`= '" . str_replace("'", "\'", $OrderInfo["size_id"]) . "',";
    $sql_query .= "`quantity`= '" . str_replace("'", "\'", $OrderInfo["quantity"]) . "'";
    
    $sql_query .= "WHERE `guid` = '" . $OrderInfo["guid"] . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function UpdateOrderStep2($OrderInfo)
{
    $result = false;
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order` SET ";
    
    
    $sql_query .= "`firstname`= '" . str_replace("'", "\'", $OrderInfo["firstname"]) . "',";
    $sql_query .= "`lastname`= '" . str_replace("'", "\'", $OrderInfo["lastname"]) . "',";
    $sql_query .= "`email`= '" . str_replace("'", "\'", $OrderInfo["email"]) . "',";
    $sql_query .= "`phone_number`= '" . str_replace("'", "\'", $OrderInfo["phone_number"]) . "',";
    $sql_query .= "`street_address`= '" . str_replace("'", "\'", $OrderInfo["street_address"]) . "',";
    $sql_query .= "`apt_suite_other`= '" . str_replace("'", "\'", $OrderInfo["apt_suite_other"]) . "',";
    $sql_query .= "`city`= '" . str_replace("'", "\'", $OrderInfo["city"]) . "',";
    $sql_query .= "`province`= '" . str_replace("'", "\'", $OrderInfo["province"]) . "',";
    $sql_query .= "`country_id`= '" . str_replace("'", "\'", $OrderInfo["country_id"]) . "',";
    $sql_query .= "`postal_code`= '" . str_replace("'", "\'", $OrderInfo["postal_code"]) . "'";
    
    $sql_query .= "WHERE `guid` = '" . $OrderInfo["guid"] . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}
function UpdateOrderStep3($guid,$cost)
{
    $result = false;
    
    $OrderInfo = getOrder($guid);
    $style = getStylebyId($OrderInfo["style_id"]);
    if(UpdateProductSellerCount($OrderInfo["product_id"],$OrderInfo["quantity"]) == false)
    {
        return false;
    }
    if(UpdateUserPromosion($OrderInfo["username"],$style["style_cost"] * $OrderInfo["quantity"]) == false)
    {
        return false;
    }
    
    
    $conn = db_connect();
    
    $sql_query = "UPDATE `order` SET ";
    
    $sql_query .= "`ischeckoutcompleted`= '1', `cost` = " . $cost;
    
    $sql_query .= "WHERE `guid` = '" . $guid . "'";
    
    //echo $sql_query;
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    db_disconnect($conn);
    
    return $result;
}

/*------------------------------delete-----------------------------------------------------------------------------------------*/


function del_session($session_id,$ip)
{
    $result = false;
    $conn = db_connect();
    
    $sql_query = "DELETE FROM `order_session` WHERE session_id = '" . $session_id ."' and ip = '" . $ip . "'";
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    
    db_disconnect($conn);
    
    return $result;
}
function deleteOrder($guid)
{
        $result = false;
    $conn = db_connect();
    
    $sql_query = "DELETE FROM `order` WHERE guid = '" . $guid ."'";
    
    $rs_query = mysql_query($sql_query,$conn);
    
    if($rs_query == true)
    {
        $result = true;
    }
    
    
    db_disconnect($conn);
    
    return $result;
}
?>