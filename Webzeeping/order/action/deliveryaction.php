<?php
    include('../../config/config.php');
    if(!isset($_POST["g"]))
    {
        echo '404 ERROR ';
        return;
    }
    
    if($_POST["g"] == "")
    {
        $OrderInfo = array(
                    'guid' => getGUID(),
                    'product_id' => $_POST["product_id"],
                    'style_id' => $_POST["style_id"],
                    'color_id' => $_POST["color_id"],
                    'size_id' => $_POST["size_id"],
                    'quantity' => $_POST["quantity"],
                    'username' => $_POST["username"]
        );
        if(InsertOrderStep1($OrderInfo))
        {
            echo '<div id="hidden_form_container" style="display:none;"></div>';
            echo '<script>
                function postRefreshPage () {
                  var theForm, inputg;
                  theForm = document.createElement("form");
                  theForm.action = "../confirm.php";
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
            echo '404 ERROR ';
            return;
        }
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
                    'size_id' => $_POST["size_id"],
                    'quantity' => $_POST["quantity"]
        );
        if(UpdateOrderStep1($OrderInfo))
        {
            echo '<div id="hidden_form_container" style="display:none;"></div>';
            echo '<script>
                function postRefreshPage () {
                  var theForm, inputg;
                  theForm = document.createElement("form");
                  theForm.action = "../confirm.php";
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