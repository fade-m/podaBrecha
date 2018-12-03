<%@ Page Language="C#" AutoEventWireup="true" CodeFile="graficaCharCinco.aspx.cs" Inherits="pages_charts_graficaCharCinco" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <meta charset="UTF-8">
   
    <meta content='width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no' name='viewport'>
    <!-- Bootstrap 3.3.2 -->
    <link href="../../bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <!-- Theme style -->
    <link href="../../dist/css/AdminLTE.min.css" rel="stylesheet" type="text/css" />
    <!-- AdminLTE Skins. Choose a skin from the css/skins
         folder instead of downloading all of them to reduce the load. -->
    <link href="../../dist/css/skins/_all-skins.min.css" rel="stylesheet" type="text/css" />
     <!-- jQuery 2.1.3 -->
    <script src="../../plugins/jQuery/jQuery-2.1.3.min.js"></script>
   <!-- ChartJS 1.0.1 -->
    <script src="../../plugins/chartjs/Chart.min.js" type="text/javascript"></script>
    <script src="../../plugins/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../plugins/js/json2.js" type="text/javascript"></script> 


    <!-- AdminLTE App --> 
    <!-- page script -->
    <script>
        $(function () {
            /* ChartJS
            * -------
            * Here we will create a few charts using ChartJS
            */



            var areaChartData = {
                labels: ["Enero", "Febrero", "MArzo", "Abril", "Mayo", "Junio", "Julio"],
                datasets: [
            {
                label: "Electronics",
                fillColor: "rgba(210, 214, 222, 1)",
                strokeColor: "rgba(210, 214, 222, 1)",
                pointColor: "rgba(210, 214, 222, 1)",
                pointStrokeColor: "#c1c7d1",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(220,220,220,1)",
                data: [50, 59, 80, 81, 56, 55, 40]
            },
            {
                label: "Digital Goods",
                fillColor: "rgba(60,141,188,0.9)",
                strokeColor: "rgba(60,141,188,0.8)",
                pointColor: "#3b8bba",
                pointStrokeColor: "rgba(60,141,188,1)",
                pointHighlightFill: "#fff",
                pointHighlightStroke: "rgba(60,141,188,1)",
                data: [100, 48, 40, 19, 86, 27, 90]
            },
            {
                label: "Chapulines",
                fillColor: "rgba(110,115,222,0.9)",
                strokeColor: "rgba(60,141,188,0.8)",
                pointColor: "#000000",
                pointStrokeColor: "rgba(60,141,188,1)",
                pointHighlightFill: "#fffCCC",
                pointHighlightStroke: "rgba(60,141,188,1)",
                data: [75, 20, 60, 50, 10, 80, 40]
            }
          ]
            };




            //-------------
            //- BAR CHART -
            //-------------
            var barChartCanvas = $("#barChart").get(0).getContext("2d");
            var barChart = new Chart(barChartCanvas);
            var barChartData = areaChartData;
            barChartData.datasets[1].fillColor = "#00a65a";
            barChartData.datasets[1].strokeColor = "#00a65a";
            barChartData.datasets[1].pointColor = "#00a65a";
            var barChartOptions = {
                //Boolean - Whether the scale should start at zero, or an order of magnitude down from the lowest value
                scaleBeginAtZero: true,
                //Boolean - Whether grid lines are shown across the chart
                scaleShowGridLines: true,
                //String - Colour of the grid lines
                scaleGridLineColor: "rgba(0,0,0,.05)",
                //Number - Width of the grid lines
                scaleGridLineWidth: 1,
                //Boolean - Whether to show horizontal lines (except X axis)
                scaleShowHorizontalLines: true,
                //Boolean - Whether to show vertical lines (except Y axis)
                scaleShowVerticalLines: true,
                //Boolean - If there is a stroke on each bar
                barShowStroke: true,
                //Number - Pixel width of the bar stroke
                barStrokeWidth: 2,
                //Number - Spacing between each of the X value sets
                barValueSpacing: 5,
                //Number - Spacing between data sets within X values
                barDatasetSpacing: 1,
                //String - A legend template
                //Boolean - whether to make the chart responsive
                responsive: true,
                maintainAspectRatio: false
            };

            barChartOptions.datasetFill = false;
            barChart.Bar(barChartData, barChartOptions);




        });



        function LoadVarianceChart() {
            var data;
            $.ajax({
                type: "POST",
                url: "graficaCharCinco.aspx/GetVarianceChart",
                data: "",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    $("#dvVarianceChart").html("");
                    var obj = r.d;
                    console.log(obj);
                    data = obj;

                    var el = document.createElement('canvas');
                    $("#dvVarianceChart")[0].appendChild(el);

                    //Fix for IE 8
                    if ($.browser.msie && $.browser.version == "8.0") {
                        G_vmlCanvasManager.initElement(el);
                    }
                    var ctx = el.getContext('2d');
                    ctx.canvas.width = 300;
                    ctx.canvas.height = 300;
                    var userStrengthsChart;
                    userStrengthsChart = new Chart(ctx).Bar(data);
                },
                failure: function (response) {
                    alert('There was an error.');
                }
            });
        }
    </script>


     



</head>
<body>
    <form id="form1" runat="server">
    <div>
       <div class="wrapper"> 
      <!-- Content Wrapper. Contains page content -->
          <div class="content-wrapper"> 
            <section class="content"> 
                <div class="col-md-6"> 
                 <!-- BAR CHART -->
                  <div class="box box-success">
                    <div class="box-header with-border">
                      <h3 class="box-title">Bar Chart</h3>
                      <div class="box-tools pull-right">
                        <button class="btn btn-box-tool" data-widget="collapse"><i class="fa fa-minus"></i></button>
                        <button class="btn btn-box-tool" data-widget="remove"><i class="fa fa-times"></i></button>
                      </div>
                    </div>
                    <div class="box-body">
                      <div class="chart">
                        <canvas id="barChart" height="230"></canvas>
                      </div>
                    </div><!-- /.box-body -->
                  </div><!-- /.box -->
                    
              </div><!-- /.row --> 
            </section><!-- /.content -->
          </div><!-- /.content-wrapper --> 
    </div><!-- ./wrapper -->

    </div>
    </form>
</body>
</html>
