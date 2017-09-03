<script>
    history.pushState({}, "", "http://zeeping.com/customer/index.php?a=3.2");
    if(confirm('Do you really want to delete it?') == false)
    {
        window.location="http://zeeping.com/customer/index.php?a=3.2";
    }
<?php
    if(isset($_GET["g"]))
    {
        include('../../config/config.php'); // Them thu vien
        if(IsHaveOrder($_GET["g"]))
        {
            if(deleteOrder($_GET["g"]))
            {
                echo 'alert("Delete successfully");';
            }
            else
            {
                echo 'alert("Delete Error. Please try again!");';
            }
        }
    }
    echo 'window.location="http://zeeping.com/customer/index.php?a=3.2";';
?>
</script>