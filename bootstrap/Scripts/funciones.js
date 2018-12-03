	function validarRadios(objeto)
	{
		var i ; var ret = true;
    	for (i=0;i<objeto.length;i++)
       		if (objeto[i].checked)
    	     	break;
		if( i==objeto.length )
			ret = false;
		return ret;
    }

	function validarCajas( objeto  )
	{
		var ret = true; 
		objeto.value = objeto.value.replace(new RegExp ("[\"\?\<\>\'\"\\\\^\|\`\%]", "gi") ,"");
		objeto.value = objeto.value.toUpperCase();
		if( trim( objeto.value ) == "" )
			ret = false;
		return ret;
	}
	
	function validarCajasLongitud( objeto , longitud )
	{
		var ret = true;
		objeto.value = objeto.value.replace(new RegExp ("[\"\?\<\>\'\"\\\\^\|\`\%]", "gi") ,"");
		if( trim( objeto.value ).length < longitud )
			ret = false;
		//if( objeto.value == valor )
		//	ret = false;
		return ret;
	}
	
	function validarCombos( objeto )
	{
		var ret = true;
		if( objeto.selectedIndex < 1 )
			ret = false;
		return ret;
    }

    function trim(stringToTrim) 
    {
	    return stringToTrim.replace(/^\s+|\s+$/g, "");	
    }
	
	    var pong;

	function makeArray(n)
    {
        this.length = n;
        for (i = 1; i <= n; i++)
        {
            this[i]=0;
        }
        return this;
    }

// standard date display function with y2k compatibility
function displayDate(fecha,hora) {
  var today = new Date(fecha);
  //alert( otro );
  var this_month = new makeArray(12);
  this_month[0]  = "Enero";
  this_month[1]  = "Febrero";
  this_month[2]  = "Marzo";
  this_month[3]  = "Abril";
  this_month[4]  = "Mayo";
  this_month[5]  = "Junio";
  this_month[6]  = "Julio";
  this_month[7]  = "Agosto";
  this_month[8]  = "Septiembre";
  this_month[9]  = "Octubre";
  this_month[10] = "Noviembre";
  this_month[11] = "Diciembre";

  var this_day_e = new makeArray(7);
  this_day_e[0]  = "Domingo";
  this_day_e[1]  = "Lunes";
  this_day_e[2]  = "Martes";
  this_day_e[3]  = "Miercoles";
  this_day_e[4]  = "Jueves";
  this_day_e[5]  = "Viernes";
  this_day_e[6]  = "Sabado";

  
  var day   = today.getDate();
  var month = today.getMonth();
  var year  = today.getYear();
  var dia = today.getDay();
	if (year < 1000) {
       year += 1900; }
  return( " " + this_day_e[dia] + ", " + day + " de " + this_month[month] + " " + year + "," + hora);
}



function mostrar() { 
    // Recogemos la fecha del servidor.
// Pasamos la fecha a javascript
var fecha_js = new Date();
var segundos = fecha_js.getSeconds();
var hora = fecha_js.getHours(); 
var minutos = fecha_js.getMinutes();
   // Ha pasado un segundo
   //segundos++;
   
   if (segundos == 60) {
     segundos = 0;
     minutos++;
     if (minutos == 60) {
       minutos = 0;
       hora++;
       if (hora == 24) {
         hora = 0;
       }
     }
   }
   
   var s = new String( segundos )
   var m = new String( minutos )
   var h = new String( hora )
   
   s = s.length==1? "0"+s:s;
   m = m.length==1? "0"+m:m;
   h = h.length==1? "0"+h:h;

   document.getElementById("fechaHora").innerHTML = displayDate(fecha_js,  h + ":" + m + ":" + s); 
   window.setTimeout("mostrar()",1000); 
}

function imposeMaxLength(Object, MaxLen)
	{	 return (Object.value.length <= MaxLen);	}
	
	function show_hide(id) {
 disp = document.all(id).style.display;
  if(disp == "block")
    document.all(id).style.display = "none";
  else
    document.all(id).style.display = "block";
 }

 function numeros() 
 {
     var key = window.event.keyCode;
     if ((key < 48 || key > 57) && key != 46 && key != 190) 
     {
         window.event.keyCode = 0;
     }
 }  

