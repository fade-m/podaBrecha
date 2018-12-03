<%@ Page Language="C#" AutoEventWireup="true" CodeFile="envioDatosEjemploTres.aspx.cs" Inherits="pages_charts_envioDatosEjemploTres" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 
 
    <script src="../../plugins/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../plugins/js/json2.js" type="text/javascript"></script>
    <script src="../../plugins/jQuery/jQuery-2.1.3.min.js" type="text/javascript"></script> 
   

       <script type="text/javascript">
        
           $(document).ready(function () { 

               $.ajax({

                   type: "POST",
                   url: "envioDatosEjemploTres.aspx/GetDataCuatro", 
                   contentType: "application/json; charset=utf-8", 
                   dataType: "json", 
                   success: function (response) {

                       var myArray = new Array();

                       var names = response.d;

                       myArray = response.d;


                       alert(myArray);

                   },

                   failure: function (response) {

                       alert(response.d);

                   }

               });

           });

 </script>



</head>
<body>
    <form id="frm"  >

    <div id="Content">
 
    </div>

 

</form>

</body>
</html>
