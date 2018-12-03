using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class pages_charts_envioDatosEjemploTres : System.Web.UI.Page
{

     

    protected void Page_Load(object sender, EventArgs e)
    {
        

    }


    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod]
     [WebMethod]
    public static List<nombres> GetData() 
    {

      


        List<nombres> colList = new List<nombres>();
        nombres objCol = null;

        objCol.Nombre = "MExico";
        objCol.apellido = "Barbaro";
        objCol.direccion = "Aztlan"; 
        colList.Add(objCol);

        return colList;

    }

     [WebMethod]
     public static string[] GetDataTres()
     {
         string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

         return weekDays2;

     }

     [WebMethod]
     public static string[,] GetDataCuatro()
     {
         string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };


         return array2Db;

     }

       [WebMethod]
     public static string GetDataDos()
     {

        
         return "This string is from Code behind";

     }

     public class nombres
     {
         public string Nombre { get; set; }
         public string apellido { get; set; }
         public string direccion { get; set; }
        
     }


    


}