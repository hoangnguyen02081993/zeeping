function reload_product_image(IschangedStyle,obj){
    if(IschangedStyle == true){
        isfront = isfrontdefault;
        style_id = obj;
        var lstColor = product_pro["s" + obj]["cl"].split(",");
        var i = 0;
        var content_color_region = "";
        var startColor = true;
        for(i = 0; i < lstColor.length; i++){
            content_color_region += "<div";
            if(startColor){
                content_color_region += " id=\"c" + lstColor[i] + "\" name=\"c" + lstColor[i] + "\" style=\"border-color:#8B4513;";
                startColor = false;
            }
            else
            {
                content_color_region += " id=\"c" + lstColor[i] + "\" name=\"c" + lstColor[i] + "\" style=\"border-color:#DDDDDD;";
            }
            content_color_region += "float:left;width:30px;height:30px;margin-left:10px;margin-top:10px;border-style:solid;border-width: 5px;background-color:" + color_pro["c" + lstColor[i]] + "\" onclick=\"reload_product_image(false,this.id)\"></div>";
        }
        document.getElementById("color_region").innerHTML = content_color_region;
        
        changedSurface();
        reload_product_image(false,"c" + lstColor[0]);
        
        t = product_pro["s" + obj]["t"];
        s = product_pro["s" + obj]["s"]
        
    }
    else{
        var searchEles = document.getElementById("color_region").children;
        for(var i = 0; i < searchEles.length; i++) {
            searchEles[i].style.borderColor  = "#DDDDDD";
        }
        document.getElementById(obj).style.borderColor  = "#8B4513";
        document.getElementById("img-background").style.backgroundColor = document.getElementById(obj).style.backgroundColor;
        cl = obj.substr(1) + "!" + document.getElementById(obj).style.backgroundColor;
    }
}
function changedSurface()
{
    if(isfront == false)
    {
        isfront = true;
        document.getElementById("img-style").style.backgroundImage = "url('/image/StyleImage/s" + style_id + ".png')";
        if(product_design.split(",")[0] != "None")
        {
            document.getElementById("img-design").src  = "/image/Design/" + product_design.split(",")[0];
            document.getElementById("img-design").style.visibility = "visible";
        }
        else
        {
            document.getElementById("img-design").src  = "";
            document.getElementById("img-design").style.visibility = "hidden";
        }
        
        
        document.getElementById("img-design").style.marginLeft = (parseInt(product_pro["s" + style_id]["t"].split('@',2)[0].split('!',2)[0])*100/530) + "%";
        document.getElementById("img-design").style.marginTop = (parseInt(product_pro["s" + style_id]["t"].split('@',2)[0].split('!',2)[1])*100/530) + "%";
        document.getElementById("img-design").style.width = (parseInt(product_pro["s" + style_id]["t"].split('@',2)[1].split('!',2)[0])*100/530) + "%";
        document.getElementById("img-design").style.height = (parseInt(product_pro["s" + style_id]["t"].split('@',2)[1].split('!',2)[1])*100/630) + "%";
        
    }
    else
    {
        isfront = false;
        document.getElementById("img-style").style.backgroundImage = "url('/image/StyleImage/sh" + style_id + ".png')";
        if(product_design.split(",")[1] != "None")
        {
            document.getElementById("img-design").src  = "/image/Design/" + product_design.split(",")[1];
            document.getElementById("img-design").style.visibility = "visible";
        }
        else
        {
            document.getElementById("img-design").src  = "";
            document.getElementById("img-design").style.visibility = "hidden";
        }
        
        document.getElementById("img-design").style.marginLeft = (parseInt(product_pro["s" + style_id]["s"].split('@',2)[0].split('!',2)[0])*100/530) + "%";
        document.getElementById("img-design").style.marginTop = (parseInt(product_pro["s" + style_id]["s"].split('@',2)[0].split('!',2)[1])*100/530) + "%";
        document.getElementById("img-design").style.width = (parseInt(product_pro["s" + style_id]["s"].split('@',2)[1].split('!',2)[0])*100/530) + "%";
        document.getElementById("img-design").style.height = (parseInt(product_pro["s" + style_id]["s"].split('@',2)[1].split('!',2)[1])*100/630) + "%";
    }
}
function getValue()
{
    var value = "";
    value += "var pro_pro = {";
    var style_list =  document.getElementById("product_style");
    value += "st: \"" + style_list.options[style_list.selectedIndex].value + "!" + style_list.options[style_list.selectedIndex].text + "\",";
    value += "cl: \"" + cl + "\",";
    value += "t: \"" + t + "\",";
    value += "s: \"" + s + "\",";
    value += "d: \"" + product_design + "\"}";
    
    document.getElementById("proInfo").value = value;
    return true;
}
function ChooseDes(id)
{
    var des1 = document.getElementById("des1");
    var des2 = document.getElementById("des2");
    var des3 = document.getElementById("des3");
    if(id == 1)
    {
        des1.style.color = "#000000";
        des1.style.borderBottom = "2px solid #000000";
        
        des2.style.color = "";
        des2.style.borderBottom = "";
        
        des3.style.color = "";
        des3.style.borderBottom = "";
        
        document.getElementById("desc-content").innerHTML = desc1content;
    }
    else if(id == 2)
    {
        des2.style.color = "#000000";
        des2.style.borderBottom = "2px solid #000000";
        
        des1.style.color = "";
        des1.style.borderBottom = "";
        
        des3.style.color = "";
        des3.style.borderBottom = "";
        
        document.getElementById("desc-content").innerHTML = desc2content;
    }
    else if(id == 3)
    {
        des3.style.color = "#000000";
        des3.style.borderBottom = "2px solid #000000";
        
        des1.style.color = "";
        des1.style.borderBottom = "";
        
        des2.style.color = "";
        des2.style.borderBottom = "";
        
        document.getElementById("desc-content").innerHTML = desc3content;
    }
}