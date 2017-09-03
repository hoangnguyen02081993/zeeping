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
    
  <div class="checkout-panel">
    <div class="panel-body">
      <h2 class="title">Checkout</h2>

      <div class="progress-bar">
        <div class="step active"></div>
        <div class="step active"></div>
        <div class="step"></div>
        <div class="step"></div>
      </div>

        <div class="order-summary-1">
              <div name="img-blackground" id="img-background" style="width:170px;height:200px">
                        <div name="img-style" id="img-style" style="width:170px;height:200px;background-size:cover">
                            <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                        </div> 
                    </div>
          <div class="order-summary-infor-1">
            <div class="order-summary-infor-columns">
              <div class="order-summary-infor-name"> <?php echo $product["product_title"]; ?> </div>
              <div class="order-summary-infor-style"> <?php echo $size[0]["size_name"] . ' - ' . $color["color_name"]; ?> </div>
            </div>
            <div class="order-summary-infor-qty-price"> <?php echo $OrderInfo["quantity"] . ' x $' . (getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]); ?> </div>  
          </div>  

      </div>
         <div class="order-summary-2">
          <div class="order-summary-infor-2">
              <div class="order-summary-infor-ship"> Shipping </div>
              <div class="order-summary-infor-ship-price"> <?php echo '$'. getCostShipCountry($country,$OrderInfo["quantity"]); ?> </div>
          </div>
        </div>

         <div class="order-summary-3">
          <div class="order-summary-infor-3">
              <div class="order-summary-infor-subtotal"> Sub-total </div>
              <div class="order-summary-infor-subtotal-price"> <?php echo '$'. (getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"]; ?> </div> 
          </div>         
        </div>
         <hr  width="95%" align="center" style="margin-left:35px" /> 
          <div class="order-summary-4">
            <div class="order-summary-infor-4">
              <div class="order-summary-infor-total"> Order Total </div>
              <div class="order-summary-infor-total-price"> <?php echo '$' . ((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"])); ?> </div> 
            </div>         
        </div>         
    </div>

    <div class="panel-footer">
      <form name="frmCheckoutPre" action="./confirm.php" method="post">    
        <button class="btn back-btn">Back</button>
        <input type="hidden" name="g" value="<?php echo $_POST["g"]; ?>"></input>
      </form>
      <div id="paypal-button-container" style="width:200px"></div>
      <div id="hidden_form_container" style="display:none;"></div>
      <button class="btn back-btn" Onclick="postRefreshPage();">NextStep</button>
    </div>
  </div>
    
  <script>
        paypal.Button.render({

            env: 'production', // sandbox | production

            style: {
            label: 'pay', // checkout | credit | pay
            size:  'responsive',    // small | medium | responsive
            shape: 'rect',     // pill | rect
            color: 'blue'      // gold | blue | silver
            },

            // PayPal Client IDs - replace with your own
            // Create a PayPal app: https://developer.paypal.com/developer/applications/create
            client: {
                sandbox:    '',
                production: 'Af7fdfBnWNndQRMPo7leIWO5iOYElaxjWJxj3pkTcjqPB6TpteMUGuweZtH8P4j4ahHhF-70-V_N3CcZ'
            },

            // Show the buyer a 'Pay Now' button in the checkout flow
            commit: true,

            // payment() is called when the button is clicked
            payment: function(data, actions) {

                // Make a call to the REST api to create the payment
                return actions.payment.create({
                    transactions: [
                        {
                            amount: { total: '<?php if($testpaypal == "0") {echo round(((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"])),2,PHP_ROUND_HALF_UP);} else { echo '1.00'; } ?>', currency: 'USD' }
                        }
                    ]
                });
            },

            // onAuthorize() is called when the buyer approves the payment
            onAuthorize: function(data, actions) {

                // Make a call to the REST api to execute the payment
                return actions.payment.execute().then(function() {
                    function postRefreshPage () {
                      var theForm, inputg;
                      theForm = document.createElement("form");
                      theForm.action = "./action/checkoutaction.php";
                      theForm.method = "post";
                      inputg = document.createElement("input");
                      inputg.type = "hidden";
                      inputg.name = "g";
                      inputg.value = "<?php echo $_POST["g"];?>";
                      inputc = document.createElement("input");
                      inputc.type = "hidden";
                      inputc.name = "c";
                      inputc.value = "<?php echo ((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"]));?>";
                      inputdata = document.createElement("input");
                      inputdata.type = "hidden";
                      inputdata.name = "data";
                      inputdata.value = data;
                      theForm.appendChild(inputdata);
                      theForm.appendChild(inputg);
                      theForm.appendChild(inputc);
                      document.getElementById("hidden_form_container").appendChild(theForm);
                      theForm.submit();
                    }
                    postRefreshPage();
                });
            }
        }, '#paypal-button-container');
        function Init()
        {
            <?php
                echo $product["style_design"] . ';';
                echo 'var product_design = "' . $product["product_image_design"] . '";';
            ?>
            if(product_design.split(",")[0] != "None")
            {
                document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + product_design.split(",")[0];
                document.getElementById("img-design").style.visibility = "visible";
                
                document.getElementById("img-design").style.marginLeft = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[0].split('!',2)[0] * 0.32) + "px";
                document.getElementById("img-design").style.marginTop = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[0].split('!',2)[1] * 0.32) + "px";
                document.getElementById("img-design").style.width = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[1].split('!',2)[0] * 0.32) + "px";
                document.getElementById("img-design").style.height = (product_pro["s<?php echo $OrderInfo["style_id"]; ?>"]["t"].split('@',2)[1].split('!',2)[1] * 0.32) + "px";
            }
            else
            {
                document.getElementById("img-design").src  = "";
                document.getElementById("img-design").style.visibility = "hidden";
            }
            
            document.getElementById("img-background").style.backgroundColor = "<?php echo $color["color_value"]; ?>";
            document.getElementById("img-style").style.backgroundImage = "url(\'http://zeeping.com/image/StyleImage/s<?php echo $OrderInfo["style_id"]; ?>.png\')";
        }
        Init();
        function postRefreshPage () {
          var theForm, inputg;
          theForm = document.createElement("form");
          theForm.action = "./action/checkoutaction.php";
          theForm.method = "post";
          inputg = document.createElement("input");
          inputg.type = "hidden";
          inputg.name = "g";
          inputg.value = "<?php echo $_POST["g"];?>";
          inputc = document.createElement("input");
          inputc.type = "hidden";
          inputc.name = "c";
          inputc.value = "<?php echo ((getCostafterPromosion($style["style_cost"],$promosion) + $size[0]["size_additional_cost"]) * $OrderInfo["quantity"] + getCostShipCountry($country,$OrderInfo["quantity"]));?>";
          theForm.appendChild(inputg);
          theForm.appendChild(inputc);
          document.getElementById("hidden_form_container").appendChild(theForm);
          theForm.submit();
        }
  </script>
</body>
</html>

