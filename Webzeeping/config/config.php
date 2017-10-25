<?php


/* define region*/

// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define('zee_DB_NAME', 'Zeeping');

/** MySQL database username */
define('zee_DB_USER', 'zeepinguserdb');

/** MySQL database password */
define('zee_DB_PASSWORD', 'Asd@12345');

/** MySQL hostname */
define('zee_DB_HOST', 'localhost');


include('sub/database.php');
include('sub/functions.php');
include('sub/WriteOnForm.php');

//Include SendMailPackage
include('srcmail/Exception.php');
include('srcmail/SMTP.php');
include('srcmail/PHPMailer.php');

?>