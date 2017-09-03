<?php
    include("../config/config.php"); 
    global $WebUrl;
    $WebUrl = getWebUrl();
    include("../source/header.php");
    
    if(!isset($_GET["id"]))
    {
        echo "Error 404";
        return;
    }
    
    $Collection = getCollectionbyId($_GET["id"]);
    $ImageCollectgionsRoot = getImageCollectgionsRoot();
?>
<div class="toogle" style="margin:30px">
    <div style="width:100%;margin: 0 auto;font-family: Arial;">
        <style type="text/css" scoped>
            strong {
                font-weight: bold;
            }
            .box_1 {
		        border: 1px solid #DDD;
		        width: 1024px;
		        margin: 0 auto;
		        font-family: Arial;
            }
            .featureimagecollection
            {
                width:40%;
                height:300px;
            }
            .titlecollection
            {
                width:50%;
                height:300px;
            }
            @media (max-width:1024px)
            {
                .box_1 {
                    width:100%;
                }
            }
            @media (max-width:640px)
            {
                .featureimagecollection
                {
                    width:100%;
                }
                .titlecollection
                {
                    width:100%;
                }
            }
        </style>
		<!-- PAGE CONTENT BEGINS -->
            <div class="box_1">
                <div style="border:4px solid #f9f9f9; background-color:#fff; padding:20px 15px;">
                    <div class="tc" style="padding:8px">
                        <span style="font-size:25pt;color:#00B2BF"><?php echo $Collection["title"]; ?></span><br/>
                        <span style="font-size:10pt;font-style:italic;"><?php echo "Created Date : " . $Collection["createdDate"] . " - by Zeeping"; ?></span><br/>
                        <span style="font-weight: bold;font-size:12pt"><?php echo $Collection["description"]; ?></span>
                        <br/>
                        <br/>
                        <div>
                            <?php echo $Collection["content"]; ?>
                        </div>
                     
                    </div>
                </div>
            </div>

    </div>
</div>	         
<?php
    include("../source/footer.php");
?>