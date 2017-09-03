<?php include("./source/header.php"); ?>
    <?php
        global $Menu; 
        $Pagecontent = getPagecontentbyId($Menu["id"]);
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
            @media (max-width:1024px)
            {
                .box_1 {
                    width:100%;
                }
            }
        </style>
		<!-- PAGE CONTENT BEGINS -->
            <div class="box_1">
                <div style="border:4px solid #f9f9f9; background-color:#fff; padding:20px 15px;">
                    <div class="tc" style="padding:8px; text-align: center">
                        <font class="f5 f6" style=" color:#000; font-size:20px"><strong><?php echo $Pagecontent["title"]; ?></strong></font><br></div>
                        <?php echo $Pagecontent["content"]; ?>
                     
                    </div>
                </div>
            </div>

    </div>
</div>	         
<?php include("./source/footer.php"); ?>