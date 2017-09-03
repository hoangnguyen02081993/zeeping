<?php include("./source/header.php"); ?>
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
                        <font class="f5 f6" style=" color:#000; font-size:24pt"><strong>FAQ</strong></font><br><br>
                    </div>
                    <style type="text/css" scoped>
                        strong {
                            font-weight: bold;
                        }
                        .question{
                            font-size: smaller;
                            font-size:14pt;
                            margin-bottom:10px;
                        }
                        .answer {
                            font-size: smaller;
                            font-size:10pt 
                        }
                    </style>    
                    
                    <?php
                        $FAQs = getFAQs(20);
                        
                        $index = 1;
                        foreach($FAQs as $FAQ)
		  	            {
		  	                echo '<div><strong><span class="question">' . $index . '. ' . $FAQ["question"] . '</span></strong></div>
		  	                <div><span style="answer" style="font-size: smaller;">' . $FAQ["answer"] . '&nbsp;</span></div>
                            <div><span style="answer"><br></span></div>
		  	                ';
		  	                $index++;
		  	            }
                    ?>
                    
                    

                    </div>
                </div>
            </div>

    </div>
</div>	
<?php include("./source/footer.php"); ?>
		
