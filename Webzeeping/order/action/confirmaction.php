<?php
    include('../../config/config.php');
    if(!isset($_POST["g"]))
    {
        echo '404 ERROR';
        return;
    }
    else if(isGuid($_POST["g"]))
    {
        if(!IsHaveOrder($_POST["g"]))
        {
            echo '404 ERROR 3';
            return;
        }
        
        $OrderInfo = array(
                    'guid' => $_POST["g"],
                    'firstname' => $_POST["firstname"],
                    'lastname' => $_POST["lastname"],
                    'email' => $_POST["email"],
                    'phone_number' => $_POST["phone_number"],
                    'street_address' => $_POST["street_address"],
                    'apt_suite_other' => $_POST["apt_suite_other"],
                    'city' => $_POST["city"],
                    'province' => $_POST["province"],
                    'country_id' => $_POST["country_id"],
                    'postal_code' => $_POST["postal_code"]
        );
        if(UpdateOrderStep2($OrderInfo))
        {
            echo '<div id="hidden_form_container" style="display:none;"></div>';
            echo '<script>
                function postRefreshPage () {
                  var theForm, inputg;
                  theForm = document.createElement("form");
                  theForm.action = "../checkout.php";
                  theForm.method = "post";
                  inputg = document.createElement("input");
                  inputg.type = "hidden";
                  inputg.name = "g";
                  inputg.value = "'. $OrderInfo["guid"] .'";
                  theForm.appendChild(inputg);
                  document.getElementById("hidden_form_container").appendChild(theForm);
                  theForm.submit();
                }
                postRefreshPage();
            </script>';
        }
        else
        {
            echo '404 ERROR 4';
            return;
        }
    }
    else
    {
        echo '404 ERROR 5';
        return;
    }

?>