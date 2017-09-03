<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <title>Zeeping - Form</title>
  <link href="https://fonts.googleapis.com/css?family=Montserrat:400,700" rel="stylesheet">
  <link rel="stylesheet" href="css/style-supportform.css">
  <script src='https://www.google.com/recaptcha/api.js'></script>
  <script>
    var hoang = false;
    function validateForm() {
        return hoang;
    }
    function verifyCallback( response ) {
        hoang = true;
    };

</script>
<meta name="robots" content="noindex,follow" />
</head>

<body>
<form id="frmSupport" action="./action/getSupport.php" method="post" onsubmit="return validateForm()">
  <div class="checkout-panel">
    <div class="panel-body">
      <h2 class="title">Form</h2>
      <div class="input-confirmation">
	
        <div class="column">
            
		    <div style="margin-top:10px"> <span> Your Name </span> </div>
          
          		<input type="text" name="name" id="yourname" required/>
          
          	<div style="margin-top:10px"> <span> Your Email </span> </div>
          
          		<input type="email" name="mail" id="email" required/>

		    <div style="margin-top:10px"> <span> Phone Number </span> </div>
                <input type="text" name="phonenumber" id="phonenumber" required/>	   
          		
          
        </div>
	        <div class="column-mess">
		        <div style="margin-top:10px"> <span> Your Message </span> </div>
			        <textarea type="text" name="message"  aria-invalid="false" form="frmSupport" required></textarea>
          
	        </div>
	    </div>
	    
    </div>
        <form style="margin-bottom: 10px;justify-content: space-between;float:left;margin-left:9%">
            <div class="g-recaptcha" id="capcharid" style="margin-left:9%" data-sitekey="6Lei7CQUAAAAAL0-FWw-jcfV7V9wTRbZ7uw9QGOX" data-callback="verifyCallback"></div>
        </form>
        
      
   
		    
		    <div class="panel-footer">
		        <input type="hidden" name="isaction" value="1"></input>
      			<input class="btn next-btn" type="submit" name="action" value="Send"></input>
    		</div>
        
</div>
</form>		    
</body>
</html>
