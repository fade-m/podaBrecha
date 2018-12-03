<%@ Page Language="C#" AutoEventWireup="true" CodeFile="envioDatosEjemplo.aspx.cs" Inherits="pages_charts_envioDatosEjemplo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 

       <script src="../../plugins/js/jquery-1.4.2.min.js" type="text/javascript"></script>
        <script src="../../plugins/js/json2.js" type="text/javascript"></script>
    <script src="../../plugins/jQuery/jQuery-2.1.3.min.js" type="text/javascript"></script> 
   
    <script type="text/javascript">
        function HandleIT() {
            $.ajax({
                type: "POST",
                url: "envioDatosEjemplo.aspx/GetAllCoordinates",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json" 
                ,
                success: function (dataLlegada) { 
                    $("#dvLegend").html("");
                    var data = eval(dataLlegada);
                    var el = document.createElement('canvas'); 
                    for (var i = 0; i < data.length; i++) {
                        var div = $("<div />");
                        div.css("margin-bottom", "10px");
                        div.html("<span style = 'display:inline-block;height:10px;width:10px'></span> " + data[i].text);
                        $("#dvLegend").append(div);
                    }

                } 
                ,

                failure: function (msg) {
                    $('#output').text(msg);
                }
            });
        }
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
           
            <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="HandleIT(); return false;" />

         

         <table border="0" cellpadding="0" cellspacing="0">
        <tr>
         <td>
                <div id="dvLegend">
                </div>
            </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
