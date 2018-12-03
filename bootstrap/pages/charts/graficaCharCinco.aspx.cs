using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


public partial class pages_charts_graficaCharCinco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod]
    //public static void  GetImage1()
    //{
    //    string carpetaZoom2 = ConfigurationManager.AppSettings["carpetaZoom"];

    //    string url = carpetaZoom2;
    //    string url2 = "";


       

    //    string cveAreaOPC = HttpContext.Current.Session["cveAreaCapturado"].ToString();
    //    SqlConnection connection3 = new SqlConnection(Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["cnxSistema"].ConnectionString));
    //    string query2 = string.Format("select substring(cveArea,1,5) as cveZona,substring(cveArea,1,2)+'000' as cveDivi,'..\\' + substring(cI.fotoUrlMed,CHARINDEX('fotos',cI.fotoUrlMed),50)  as mejo,'' + substring(cI.fotoUrlOri,CHARINDEX('fotos',cI.fotoUrlOri)+18,50)  as mejoOri ,cI.fotoUrlMed from cargarImagenes as cI   where cI.idStatus=1 and  cI.cveArea='" + cveAreaOPC + "'  and cI.cveConcepto='1'  and substring(CONVERT(varchar,fechaCarga,112),1,6)=substring(CONVERT(varchar,GETDATE(),112),1,6) ");
    //    SqlCommand cmd2 = new SqlCommand(query2, connection3);
    //    SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);

    //    tblData = new DataTable();
    //    adapter2.Fill(tblData);

    //    string FotoUrl = "Hola";
    //    string FotoUrl2 = "Hola";
    //    string k1 = "";
    //    AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[tblData.Rows.Count];
    //    for (int i = 0; i < tblData.Rows.Count; i++)
    //    {
    //        k1 = "";
    //        url2 = "";

    //        FotoUrl = tblData.Rows[i]["mejo"].ToString();
    //        FotoUrl2 = tblData.Rows[i]["mejoOri"].ToString();
    //        url2 = url + FotoUrl2 + "&cveDivi=" + tblData.Rows[i]["cveDivi"].ToString() + "&cveZona=" + tblData.Rows[i]["cveZona"].ToString();
    //        k1 = "<a href=javascript:ventanaSecundaria('" + url2 + "') class='smtxt'>Zoom: " + FotoUrl2 + "</a>";
    //        slides[i] = new AjaxControlToolkit.Slide(FotoUrl, "imagen" + (i + 1).ToString(), "<table><tr><td align='left'>" + k1 + "</td></tr></table>");

    //    }
    //    return slides;


    //}


    //public static string GetVarianceChart()
    //{
    //    DataSet ds = Utility.ExecuteDataTable("GetAdvarienceByBrandFamily", null);
    //    VarianceChartModel bar = new VarianceChartModel();

    //    bar.labels = ds.Tables[0].Rows[0][0].ToString().Split(',');
    //    bar.datasets = new List<datasets>();

    //    for (int i = 1; i < ds.Tables.Count; i++)
    //    {
    //        datasets dataset = new datasets();
    //        dataset.data = Array.ConvertAll(ds.Tables[i].Rows[0][0].ToString().Split(','), decimal.Parse);
    //        dataset.label = "new";
    //        dataset.fillColor = "rgba(220,220,220,0.5)";
    //        dataset.highlightFill = "rgba(220,220,220,0.75)";
    //        dataset.highlightStroke = "rgba(220,220,220,1)";
    //        dataset.strokeColor = "rgba(220,220,220,0.8)";
    //        bar.datasets.Add(dataset);
    //    }

    //    var serializer = new JsonSerializer();
    //    var stringWriter = new StringWriter();
    //    var writer = new JsonTextWriter(stringWriter);
    //    writer.QuoteName = false;
    //    serializer.Serialize(writer, bar);
    //    writer.Close();
    //    var json = stringWriter.ToString();
    //    return json.ToString();
    //}



    //public static string GetChart1(string account)
    //{
    //    SqlParameter[] param = new SqlParameter[] { new SqlParameter("@account", account) };
    //    DataSet ds = Utility.ExecuteDataTable("GetChart1", param);
    //    if (ds.Tables[0].Rows.Count != 0)
    //    {
    //        VarianceChartModel bar = new VarianceChartModel();
    //        bar.labels = ds.Tables[0].Rows[0][0].ToString().Split(',');
    //        bar.datasets = new List<datasets>();

    //        for (int i = 1; i < ds.Tables.Count; i++)
    //        {
    //            string data = ds.Tables[i].Rows[0][0].ToString();
    //            if (!string.IsNullOrEmpty(data))
    //            {
    //                datasets dataset = new datasets();
    //                dataset.data = Array.ConvertAll(data.Split(','), decimal.Parse);
    //                dataset.label = "new";
    //                dataset.fillColor = "rgba(255, 102, 0,0.5)";
    //                dataset.highlightFill = "rgba(255, 102, 0,0.75)";
    //                dataset.highlightStroke = "rgba(255, 102, 0,0.50)";
    //                dataset.strokeColor = "rgba(255, 102, 0,0.8)";
    //                bar.datasets.Add(dataset);
    //            }
    //        }

    //        var serializer = new JsonSerializer();
    //        var stringWriter = new StringWriter();
    //        var writer = new JsonTextWriter(stringWriter);
    //        // writer.QuoteName = false;
    //        serializer.Serialize(writer, bar);
    //        writer.Close();
    //        var json = stringWriter.ToString();
    //        return json.ToString();
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}



    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static List<MesesReal> getDatosReal(int cveIndicador)
    {

       
        SqlConnection connection3 = new SqlConnection(Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["cnxSiager"].ConnectionString));
        string query2 = string.Format("select	max(t.anio) as anio2 ,'Real'+max(t.anio) as anio ,max(t.Enero)as Enero,max(t.Febrero) as Febrero,max(t.Marzo) as Marzo,max(t.Abril) as Abril, max(t.Mayo) as Mayo,max(t.Junio) as Junio,max(t.Julio) as Julio,max(t.Agosto) as Agosto,max(t.Septiembre) as Septiembre,max(t.Octubre) as Octubre,max(t.Noviembre) as Noviembre,max(t.Diciembre) as Diciembre from (SELECT anio,[Enero], [Febrero],[Marzo], [Abril],[Mayo], [Junio],[Julio], [Agosto],[Septiembre], [Octubre],[Noviembre], [Diciembre] FROM(select ca.anio,iv.meta,ROUND(iv.real,2) as real ,cm.mes from [dbo].[indicadoresValores]  as iv , catAnios  as ca, catMeses as cm where iv.cveIndicador ='9'  and iv.cveAnio in (5) and iv.cveAmbito='1' and ca.cveAnio=iv.cveAnio and cm.cveMes=iv.cveMes ) AS SourceTable PIVOT( sum(real) FOR mes IN ([Enero], [Febrero],[Marzo], [Abril],[Mayo], [Junio],[Julio], [Agosto],[Septiembre], [Octubre],[Noviembre], [Diciembre]) ) AS PivotTable )as t ");
        SqlCommand cmd2 = new SqlCommand(query2, connection3);


        List<MesesReal> colList = new List<MesesReal>();
        MesesReal objCol = null;

        SqlDataReader drReader = cmd2.ExecuteReader();  
        while (drReader.Read())  
        {

            objCol.ColEtiqueta = drReader["anio"].ToString();
            objCol.ColAnio = drReader["anio2"].ToString();

            objCol.ColEnero = drReader["Enero"].ToString();
            objCol.ColFebrero = drReader["Febrero"].ToString();
            objCol.ColMarzo = drReader["Marzo"].ToString();
            objCol.ColAbril = drReader["Abril"].ToString();
            objCol.ColMayo = drReader["Mayo"].ToString();
            objCol.ColJunio = drReader["Junio"].ToString();
            objCol.ColJulio = drReader["Julio"].ToString();
            objCol.ColAgosto = drReader["Agosto"].ToString();
            objCol.ColSeptiembre = drReader["Septiembre"].ToString();
            objCol.ColOctubre = drReader["Octubre"].ToString();
            objCol.ColNoviembre = drReader["Noviembre"].ToString();
            objCol.ColDiciembre = drReader["Diciembre"].ToString();
            colList.Add(objCol);
        }
        drReader.Close();
        cmd2.Connection.Close();



        return colList;

    }

    public class MesesReal
    {
        public string ColEtiqueta { get; set; }
        public string ColAnio{ get; set; }
        public string ColEnero { get; set; }
        public string ColFebrero { get; set; }
        public string ColMarzo { get; set; }
        public string ColAbril { get; set; }
        public string ColMayo { get; set; }
        public string ColJunio { get; set; }
        public string ColJulio { get; set; }
        public string ColAgosto{ get; set; }
        public string ColSeptiembre { get; set; }
        public string ColOctubre { get; set; }
        public string ColNoviembre { get; set; }
        public string ColDiciembre { get; set; } 
    }

}