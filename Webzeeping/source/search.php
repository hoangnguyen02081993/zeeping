<?php
    include('../config/config.php');
    $WebUrl = getWebUrl();
    if(!isset($_POST["submit"]))
    {
        header('Location: ' . $WebUrl);
    }
    if(!isset($_POST["s"]))
    {
        header('Location: ' . $WebUrl);
    }
    $link = str_replace(" ","-",removeAllspecialcharwithoutSpace($_POST["s"])); // get link with search
    $ipaddress = get_client_ip($_SERVER); //get client ip
    //update DB with link and search string
    InsertSearchSesssion($_POST["s"],$link,$ipaddress);
    header('Location: ' . $WebUrl . '/search/' . $link);
?>