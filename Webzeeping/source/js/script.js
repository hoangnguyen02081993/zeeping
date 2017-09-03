function BlinkText()
{
   
    farbbibliothek = new Array();
    farbbibliothek[0] = new Array("#FF0000","#FF1100","#FF2200","#FF3300","#FF4400","#FF5500","#FF6600","#FF7700","#FF8800","#FF9900","#FFaa00","#FFbb00","#FFcc00","#FFdd00","#FFee00","#FFff00","#FFee00","#FFdd00","#FFcc00","#FFbb00","#FFaa00","#FF9900","#FF8800","#FF7700","#FF6600","#FF5500","#FF4400","#FF3300","#FF2200","#FF1100");
    farbbibliothek[1] = new Array("#00FF00","#000000","#00FF00","#00FF00");
    farbbibliothek[2] = new Array("#00FF00","#FF0000","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00","#00FF00");
    farbbibliothek[3] = new Array("#FF0000","#FF4000","#FF8000","#FFC000","#FFFF00","#C0FF00","#80FF00","#40FF00","#00FF00","#00FF40","#00FF80","#00FFC0","#00FFFF","#00C0FF","#0080FF","#0040FF","#0000FF","#4000FF","#8000FF","#C000FF","#FF00FF","#FF00C0","#FF0080","#FF0040");
    farbbibliothek[4] = new Array("#FF0000","#EE0000","#DD0000","#CC0000","#BB0000","#AA0000","#990000","#880000","#770000","#660000","#550000","#440000","#330000","#220000","#110000","#000000","#110000","#220000","#330000","#440000","#550000","#660000","#770000","#880000","#990000","#AA0000","#BB0000","#CC0000","#DD0000","#EE0000");
    farbbibliothek[5] = new Array("#000000","#000000","#000000","#FF0000","#FF0000","#FF0000");
    //farbbibliothek[6] = new Array("#0000FF","#FFFF00");
    
    // Thuộc tính
    this.id = '';
    this.text = '';
    this.farbsatz = 1;
    this.farben = farbbibliothek[4];
    this.Buchstabe = new Array();
    this.interval = '';
    var _this = this;
     
    this.farbschrift = function()
    {
        for(var i=0 ; i<this.Buchstabe.length; i++)
        {
            document.all[this.id + "_" + i].style.color=this.farben[i];
            }
        this.farbverlauf();
    }
    this.string2array = function()
    {
        this.Buchstabe = new Array();
        while(this.farben.length<this.text.length)
        {
            this.farben = this.farben.concat(this.farben);
        }
        k=0;
        while(k<=this.text.length)
        {
            this.Buchstabe[k] = this.text.charAt(k);
            k++;
        }
    }
    this.divserzeugen = function()
    {
        var str = "";
        for(var i=0 ; i<this.Buchstabe.length; i++)
        {
            str += "<span style='font-size:20px;font-weight:bold' id='" + this.id + "_" + i + "' class='" + this.id + "_" + i+"'>"+ this.Buchstabe[i] + "<\/span>";
        }
        document.getElementById(this.id).innerHTML = str;
        this.farbschrift();
        //setInterval(this.farbschrift(),50);
    }
    this.farbverlauf = function()
    {
        for(var i=0 ; i< this.farben.length; i++)
        {
            this.farben[i-1]=this.farben[i];
        }
        this.farben[this.farben.length-1]=this.farben[-1];
    
        setTimeout(function(){
            _this.farbschrift();
        },100);
        //setInterval(this.farbschrift(),50);
    }
    //
    this.farbtauscher = function()
    {
        this.farben = farbbibliothek[this.farbsatz];
        while(this.farben.length<this.text.length)
        {
            this.farben = this.farben.concat(this.farben);
        }
        this.farbsatz=Math.floor(Math.random()*(farbbibliothek.length-0.0001));
    }
         
    this.start = function(id,text){
        this.id = id;
        this.text = text;
        this.string2array();
        this.divserzeugen();
        this.interval = setInterval(function(){
            _this.farbtauscher();
        },5000);
    }
    
    //var sefl = this;
    
    // Phải return this thì mới tạo mới được đối tượng
    return this;
}   