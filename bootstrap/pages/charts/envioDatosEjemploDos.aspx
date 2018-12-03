<%@ Page Language="C#" AutoEventWireup="true" CodeFile="envioDatosEjemploDos.aspx.cs" Inherits="pages_charts_envioDatosEjemploDos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 

    <script src="../../plugins/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../plugins/js/json2.js" type="text/javascript"></script>
    <script src="../../plugins/jQuery/jQuery-2.1.3.min.js" type="text/javascript"></script> 
   
       <script type="text/javascript">
           function HandleIT() {
               var name = document.getElementById('<%=txtname.ClientID %>').value;
               var address = document.getElementById('<%=txtaddress.ClientID %>').value;

               PageMethods.ProcessIT(name, address, onSucess, onError);
               function onSucess(result) 
               {
                   alert(result);
               }

               function onError(result) 
               {
                   alert('Something wrong.');
               }
           }
    </script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Say bye-bey to Postbacks.</p>

        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <asp:TextBox ID="txtname" runat="server"></asp:TextBox>
       
        <asp:TextBox ID="txtaddress" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Button" OnClientClick="HandleIT(); return false;" />

     
    </div>
    </form>
</body>
</html>
