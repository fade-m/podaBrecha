using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pages_charts_envioDatosEjemplo : System.Web.UI.Page
{

    List<double> mylats = new List<double>();
    List<Coordinates> mycoordinates = new List<Coordinates>();

    protected void Page_Load(object sender, EventArgs e)
    {
        mylats.Add(44.05);
        mylats.Add(45.05);
        mycoordinates.Add(new Coordinates(43.773062, -81.531944)); //0 Auburn
        mycoordinates.Add(new Coordinates(43.553447, -81.393425)); //1 Seaforth
        mycoordinates.Add(new Coordinates(43.740623, -81.7075967)); //2 Goderich
        mycoordinates.Add(new Coordinates(43.677386, -81.30209));   //3 Walton
        Session["data"] = mycoordinates;

    }

    public class Coordinates
    {
        public double mylat;
        public double mylng;
        public Coordinates(double latitude, double longitude)
        {
            this.mylat = latitude;
            this.mylng = longitude;
        }
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
   
    public static List<Coordinates> GetAllCoordinates(List<Coordinates> mycoordinates)
    {
        List<Coordinates> data2 = (List<Coordinates>)HttpContext.Current.Session["data"];
        return data2;
 
    }

 
    [System.Web.Script.Services.ScriptMethod]
    [System.Web.Services.WebMethod]
    public static List<double> GetAllLatitudes(List<double> mylats)
    {
        return mylats;
    }



}