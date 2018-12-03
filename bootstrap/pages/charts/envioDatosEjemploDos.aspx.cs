using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_charts_envioDatosEjemploDos : System.Web.UI.Page
{

     

    protected void Page_Load(object sender, EventArgs e)
    {
        

    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static string ProcessIT(string name, string address)
    {
        string result = "Welcome Mr. " + name + ". Your address is '" + address + "'.";
        return result;
    }


    


}