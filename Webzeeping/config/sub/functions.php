<?php

/**function region */

// functon chuc nang
function get_client_ip($SERVER) {
    $ipaddress = '';
    if (isset($SERVER['HTTP_CLIENT_IP']))
        $ipaddress = $SERVER['HTTP_CLIENT_IP'];
    else if(isset($SERVER['HTTP_X_FORWARDED_FOR']))
        $ipaddress = $SERVER['HTTP_X_FORWARDED_FOR'];
    else if(isset($SERVER['HTTP_X_FORWARDED']))
        $ipaddress = $SERVER['HTTP_X_FORWARDED'];
    else if(isset($SERVER['HTTP_FORWARDED_FOR']))
        $ipaddress = $SERVER['HTTP_FORWARDED_FOR'];
    else if(isset($SERVER['HTTP_FORWARDED']))
        $ipaddress = $SERVER['HTTP_FORWARDED'];
    else if(isset($SERVER['REMOTE_ADDR']))
        $ipaddress = $SERVER['REMOTE_ADDR'];
    else
        $ipaddress = 'UNKNOWN';
    return $ipaddress;
}
function curPageURL($SERVER) {
     $pageURL = 'https';
     
     $pageURL .= "://";
     if ($SERVER["SERVER_PORT"] != "443") {
      $pageURL .= $SERVER["SERVER_NAME"].":".$SERVER["SERVER_PORT"].$SERVER["REQUEST_URI"];
     } else {
      $pageURL .= $SERVER["SERVER_NAME"].$SERVER["REQUEST_URI"];
     }
     return $pageURL;
}
function isGuid($guid)
{
    if (preg_match('/^\{?[A-Z0-9]{8}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{4}-[A-Z0-9]{12}\}?$/', $guid)) {
        return true;
    } else {
        return false;
    }
}
function getGUID(){
    if (function_exists('com_create_guid')){
        return com_create_guid();
    }else{
        mt_srand((double)microtime()*10000);//optional for php 4.2.0 and up.
        $charid = strtoupper(md5(uniqid(rand(), true)));
        $hyphen = chr(45);// "-"
        $uuid = ''
            .substr($charid, 0, 8).$hyphen
            .substr($charid, 8, 4).$hyphen
            .substr($charid,12, 4).$hyphen
            .substr($charid,16, 4).$hyphen
            .substr($charid,20,12);
        return $uuid;
    }
}
function checkLoginAction($SERVER, $COOKIE)
{
    $username= '';
    
    if(isset($COOKIE["session_id"]))
    {
        $ip = get_client_ip($SERVER);
        $username = check_issignin($COOKIE["session_id"],$ip);
        if($username == '')
        {
            echo '<div id="hidden_form_container" style="display:none;"></div>';
            echo '<script>
                function postRefreshPage () {
                  var theForm, inputg;
                  theForm = document.createElement("form");
                  theForm.action = "login.php";
                  theForm.method = "post";
                  inputg = document.createElement("input");
                  inputg.type = "hidden";
                  inputg.name = "url";
                  inputg.value = "'. curPageURL($SERVER) .'";
                  theForm.appendChild(inputg);
                  document.getElementById("hidden_form_container").appendChild(theForm);
                  theForm.submit();
                }
                postRefreshPage();
            </script>';
        }
    }
    else
    {
        echo '<div id="hidden_form_container" style="display:none;"></div>';
        echo '<script>
            function postRefreshPage () {
              var theForm, inputg;
              theForm = document.createElement("form");
              theForm.action = "login.php";
              theForm.method = "post";
              inputg = document.createElement("input");
              inputg.type = "hidden";
              inputg.name = "url";
              inputg.value = "'. curPageURL($SERVER) .'";
              theForm.appendChild(inputg);
              document.getElementById("hidden_form_container").appendChild(theForm);
              theForm.submit();
            }
            postRefreshPage();
        </script>';
    }
    
    return $username;
}
function getObjbyCondition($list,$columnName,$value)
{
    foreach($list as $item)
    {
        if($item[$columnName] == $value)
        {
            return $item;
        }
    }
    return null;
}
function getObjsbyCondition($list,$columnName,$value)
{
    $List = array();
    foreach($list as $item)
    {
        if($item["$columnName"] == $value)
        {
            array_push($List, $item);
        }
    }
    return $List;
}
function OrderbyObjsbyCondition($list,$columnName)
{
    //uasort($list, function($a, $b) {
    //    if ( $a[$columnName] == $b[$columnName] ) 
    //        return 0; 
    //    else if ( $a[$columnName] < $b[$columnName] ) 
    //        return -1; 
    //    else 
    //        return 1;
    //});
    return $list;
}
function getParameterWeb($WebUrl,$WebUrlWWW,$CurrWebURL)
{
    $ParamsL = str_replace($WebUrlWWW . '/' , "", str_replace($WebUrl . '/', "", $CurrWebURL));
    return explode ("/", $ParamsL);
}
function removeAllspecialchar($str)
{
    return str_replace(" ","", preg_replace('/[^a-zA-Z0-9]/','',$str));
}
function checkExprieDay($day,$count)
{
    $cpmDate = date('Y-m-d') ; //current date
    return ((strtotime($cpmDate) - strtotime($day)) / (60 * 60 * 24) > $count) ? true : false;
}
function checkExprieMinutes($day,$count)
{
    $cpmDate = date('Y-m-d h:i:s') ; //current date
    echo "cpmDate " . $cpmDate . "\n";
    echo (strtotime($cpmDate) - strtotime($day)) / 60;
    return ((strtotime($cpmDate) - strtotime($day)) / 60  > $count) ? true : false;
}
function removeAllspecialcharwithoutSpace($str)
{
    return preg_replace('/[^a-zA-Z0-9 ]/','',$str);
}
?>