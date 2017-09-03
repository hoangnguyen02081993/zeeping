<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Mail Collection</title>
  <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
  <link rel="stylesheet" href="css/style-confirminfo.css">
</head>
<body>
<?php
    if(!isset($_POST["proInfo"]))
    {
        echo 'Error 404';
        return;
    }
?>
        
    	<div class="checkout-panel">
            <div class="panel-body" >
               <h2 class="title">Register-Email</h2>
    	
    
    		<div class="input-confirmation">
    		    <div class="column-1" style="width:530px">
        		    <div name="image-region" style="float:left;width:530px" > 
                        <div name="img-blackground" id="img-background" style="width:530px;height:630px">
                            <div name="img-style" id="img-style" style="width:530px;height:630px">
                                <img name="img-design" id="img-design" style="width:50px;height:60px" src=""></img>
                            </div> 
                        <button class="btn" id="btn_truoc" type="button" style="float:left;margin-top:5px;margin-left:25%;width:20%;height:40px;color:#000000" onclick="changedSurface(this.id)">Front</button>
                        <button class="btn" id="btn_sau"type="button" style="float:left;margin-top:5px;margin-left:8%;width:20%;height:40px;color:#000000" onclick="changedSurface(this.id)">Behind</button>
                        </div> 
                    </div>
    		    </div>
    
    		    <div class="column-2" style="width:400px">
    			    <form name="frmBuyDirect" action="./action/confirminfoaction.php" method="post" >
        				<div style="margin-top:10px"> <span> Your Email </span> </div>
                  
                  				<input type="email" name="email" id="email" required />
                  
                  		<h1> Product </h1>
                  		<div style="width:400px;height:80px"><h3 id="pro_name" style="float:left"></h3> <div id="div_color" style="float:left;width:40px;height:40px;margin-left:20px;margin-top:10px;border-style:solid;border-width: 5px"></div> </div>
                  		<hr/> 
        				<div> <i>Please make sure that you choose this T-shirt to buy with Teespring at our store. We’ll check and supply Zeeping’s account for you if you were completely bought  at our website. <br/><br/>Unless you make sure that T- shirt, please come back to choose fit size, color for you. <i></div>	
                        <hr/>
                        <input type="hidden" id="style_id" name="style_id" value=""></input>
                        <input type="hidden" id="color_id" name="color_id" value=""></input>
                        <?php echo'<input type="hidden" name="url" value="'.$_POST["product_link"].'"></input>'; ?>
                        <button class="btn next-btn" style="float:right" type="submit" name="submit" value="Next Step">Next Step</button>
                    </form>
    	        </div>	
    		     
           
        </div>
        <script>
            <?php echo $_POST["proInfo"]. ';'; ?>
            var style_id = "";
            function Init()
            {
                document.getElementById("img-background").style.backgroundColor = pro_pro["cl"].split('!',2)[1];
                document.getElementById("img-style").style.backgroundImage  = "url('http://zeeping.com/image/StyleImage/s" + pro_pro["st"].split('!',2)[0] + ".png')";
                if(pro_pro["d"].split(",")[1] != "None")
                {
                    document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + pro_pro["d"].split(",")[1];
                    document.getElementById("img-design").style.visibility = "visible";
                }
                else
                {
                    document.getElementById("img-design").src  = "";
                    document.getElementById("img-design").style.visibility = "hidden";
                }
                
                document.getElementById("img-design").style.marginLeft = pro_pro["t"].split('@',2)[0].split('!',2)[0] + "px";
                document.getElementById("img-design").style.marginTop = pro_pro["t"].split('@',2)[0].split('!',2)[1] + "px";
                document.getElementById("img-design").style.width = pro_pro["t"].split('@',2)[1].split('!',2)[0] + "px";
                document.getElementById("img-design").style.height = pro_pro["t"].split('@',2)[1].split('!',2)[1] + "px";
                
                document.getElementById("pro_name").innerHTML = pro_pro["st"].split('!',2)[1];
                document.getElementById("div_color").style.backgroundColor = pro_pro["cl"].split('!',2)[1];
                document.getElementById("div_color").style.borderColor = "#8B4513";
                
                style_id = pro_pro["st"].split('!',2)[0];
                
                document.getElementById("style_id").value = style_id;
                document.getElementById("color_id").value = pro_pro["cl"].split('!',2)[0];
                
                changedSurface("btn_truoc");
            }
            function changedSurface(obj)
            {
                if(obj == "btn_truoc")
                {
                    document.getElementById("img-style").style.backgroundImage = "url('http://zeeping.com/image/StyleImage/s" + style_id + ".png')";
                    if(pro_pro["d"].split(",")[0] != "None")
                    {
                        document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + pro_pro["d"].split(",")[0];
                        document.getElementById("img-design").style.visibility = "visible";
                    }
                    else
                    {
                        document.getElementById("img-design").src  = "";
                        document.getElementById("img-design").style.visibility = "hidden";
                    }
                    document.getElementById("btn_truoc").disabled = true;
                    document.getElementById("btn_sau").disabled = false;
                    
                    
                    document.getElementById("img-design").style.marginLeft = pro_pro["t"].split('@',2)[0].split('!',2)[0] + "px";
                    document.getElementById("img-design").style.marginTop = pro_pro["t"].split('@',2)[0].split('!',2)[1] + "px";
                    document.getElementById("img-design").style.width = pro_pro["t"].split('@',2)[1].split('!',2)[0] + "px";
                    document.getElementById("img-design").style.height = pro_pro["t"].split('@',2)[1].split('!',2)[1] + "px";
                    
                }
                else
                {
                    document.getElementById("img-style").style.backgroundImage = "url('http://zeeping.com/image/StyleImage/sh" + style_id + ".png')";
                    if(pro_pro["d"].split(",")[1] != "None")
                    {
                        document.getElementById("img-design").src  = "http://zeeping.com/image/Design/" + pro_pro["d"].split(",")[1];
                        document.getElementById("img-design").style.visibility = "visible";
                    }
                    else
                    {
                        document.getElementById("img-design").src  = "";
                        document.getElementById("img-design").style.visibility = "hidden";
                    }
                    document.getElementById("btn_truoc").disabled = false;
                    document.getElementById("btn_sau").disabled = true;
                    
                    document.getElementById("img-design").style.marginLeft = pro_pro["s"].split('@',2)[0].split('!',2)[0] + "px";
                    document.getElementById("img-design").style.marginTop = pro_pro["s"].split('@',2)[0].split('!',2)[1] + "px";
                    document.getElementById("img-design").style.width = pro_pro["s"].split('@',2)[1].split('!',2)[0] + "px";
                    document.getElementById("img-design").style.height = pro_pro["s"].split('@',2)[1].split('!',2)[1] + "px";
                }
            }
            Init();
        </script>
      </div>
    
    

</body>

</html>
