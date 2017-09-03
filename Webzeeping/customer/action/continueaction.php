<div id="hidden_form_container" style="display:none;"></div>
<script>
<?php
    if(isset($_GET["g"]))
    {
        include('../../config/config.php'); // Them thu vien
        if(IsHaveOrder($_GET["g"]))
        {
            echo '
            function postRefreshPage () {
                  var theForm, inputg;
                  theForm = document.createElement("form");
                  theForm.action = "../../order/delivery.php";
                  theForm.method = "post";
                  inputa = document.createElement("input");
                  inputa.type = "hidden";
                  inputa.name = "isaction";
                  inputa.value = "1";
                  theForm.appendChild(inputa);
                  inputg = document.createElement("input");
                  inputg.type = "hidden";
                  inputg.name = "g";
                  inputg.value = "'. $_GET["g"] .'";
                  theForm.appendChild(inputg);
                  document.getElementById("hidden_form_container").appendChild(theForm);
                  theForm.submit();
            }
            postRefreshPage();';
        }
        else
        {
            echo 'window.location="http://zeeping.com/customer/index.php?a=3.2";';
        }
    }
?>
</script>