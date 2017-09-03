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
            echo '404 ERROR';
            return;
        }
        if(UpdateOrderStep3($_POST["g"],$_POST["c"]))
        {
            echo '<div id="hidden_form_container" style="display:none;"></div>';
            echo '<script>
                function postRefreshPage () {
                  var theForm, inputg;
                  theForm = document.createElement("form");
                  theForm.action = "../finish.php";
                  theForm.method = "post";
                  inputg = document.createElement("input");
                  inputg.type = "hidden";
                  inputg.name = "g";
                  inputg.value = "'. $_POST["g"] .'";
                  theForm.appendChild(inputg);
                  document.getElementById("hidden_form_container").appendChild(theForm);
                  theForm.submit();
                }
                postRefreshPage();
            </script>';
        }
        else
        {
            echo '404 ERROR';
            return;
        }
    }
    else
    {
        echo '404 ERROR';
        return;
    }

?>