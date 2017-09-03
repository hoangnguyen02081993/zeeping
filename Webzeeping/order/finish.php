<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Zeeping - Checkout</title>
  <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
  <link rel="stylesheet" href="css/style-checkout-new.css">
  <script src="https://www.paypalobjects.com/api/checkout.js"></script>
  <?php include('../config/config.php'); ?>
</head>
<body>
    <?php
        if(!isset($_POST["g"]))
        {
            echo '404 ERROR';
            return;
        }
        else if(!isGuid($_POST["g"]))
        {
            echo '404 ERROR';
            return;
        }
    ?>
  <div class="checkout-panel">
    <div class="panel-body">
      <h2 class="title">Finish</h2>

      <div class="progress-bar">
        <div class="step active"></div>
        <div class="step active"></div>
        <div class="step active"></div>
        <div class="step"></div>
      </div>
      <div class="checkout-panel">
        <?php

            $status = IsOrderComplete($_POST["g"]);
            if($status == -1)
            {
                echo '404 ERROR';
            }
            else if($status == 0)
            {
                echo "Your order is completed<br/>";
                echo "Clink <a href=\"http://zeeping.com\">here</a> to go zeeping.com";
            }
            else
            {
                echo "Your order is not completed";
            }
        ?>
      </div>
    </div>
  </div>
</body>
</html>

