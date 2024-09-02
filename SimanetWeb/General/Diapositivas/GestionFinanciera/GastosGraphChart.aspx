<%@ Page language="c#" Codebehind="GastosGraphChart.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Diapositivas.GestionFinanciera.GastosGraphChart" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML lang="en" class="no-js cookie_used_false">
	<HEAD>
		<title>GastosGraphChart</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta charset="UTF-8">
		<LINK rel="stylesheet" type="text/css" href="../../../styles.css">
		<script type="text/javascript" src="/SimaNetWeb/js/@Import.js"></script>
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/easyui/jquery.min.js"></script>
		<script type="text/javascript" src="/SIMANETCOMPLEMENTOS/JQuery/easyui/jquery.easyui.min.js"></script>
		<script type="text/javascript" src="http://localhost/SimaNetWeb/js/JQuery/js/JQueryPlugInSIMA.js"></script>
		<script src="http://localhost/SimaNetWeb/General/Diapositivas/JsGraphChart/amcharts.js"></script>
		<script src="http://localhost/SimaNetWeb/General/Diapositivas/JsGraphChart/pie.js"></script>
		<script src="http://localhost/SimaNetWeb/General/Diapositivas/JsGraphChart/light.js"></script>
		<script src="http://localhost/SimaNetWeb/General/Diapositivas/GestionFinanciera/GestionFinancieraCodbehind.js"></script>
		<style>#chartdiv { WIDTH: 800px; HEIGHT: 100%}
	.amcharts-chart-div A { DISPLAY: none }
	.legend-title { FONT-FAMILY: Verdana; MARGIN-LEFT: 20px; FONT-WEIGHT: bold }
	#legend { WIDTH: 100%; FLOAT: left; HEIGHT: 100%; MARGIN-LEFT: 10px }
	#legend .legend-item { MARGIN: 10px; FONT-SIZE: 15px; CURSOR: pointer; FONT-WEIGHT: bold }
	#legend .legend-item .legend-value { MARGIN-LEFT: 22px; FONT-SIZE: 12px; FONT-WEIGHT: normal }
	#legend .legend-item .legend-marker { BORDER-BOTTOM: #ccc 1px solid; BORDER-LEFT: #ccc 1px solid; WIDTH: 12px; DISPLAY: inline-block; HEIGHT: 12px; BORDER-TOP: #ccc 1px solid; MARGIN-RIGHT: 10px; BORDER-RIGHT: #ccc 1px solid }
	#legend .disabled .legend-marker { opacity: 0.5; bakground: #ddd }
	.Contenedor{WIDTH:100%; MARGIN: 5px 0px 50px; BORDER-BOTTOM: #eee 1px solid; BORDER-LEFT: #eee 1px solid;  HEIGHT: 50px; BORDER-TOP: #eee 1px solid; BORDER-RIGHT: #eee 1px solid}
		</style>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table align=center border=0 class="Contenedor">
				<tr>
					<td style="WIDTH: 20%">
						<div id="legend"></div>
					</td>
					<td style="WIDTH: 80%">
						<div style="WIDTH: 90.66%; HEIGHT: 328px" id="chartdiv"></div>
					</td>
				</tr>
			</table>
			
			<script>
			
				var KEYQPERIODO="Periodo";
				var KEYQMES="IdMes";
				var KEYQIDTIPOINFORMACION = "idTipoInfo";
				var KEYQIDFORMATO="IdFormato";
				var KEYQIDREPORTE = "IdReporte";
				var KEYQIDRUBRO ="IdRubro";
				var IDCENTROOPERATIVO="idcop";
				var KEYQLSTCONCEPTO="LstCon";
				var KEYQTITULO="TitRep";
				
			
				function addLegendLabel(e) {
					oGraphChart.ChartSource.customLegend=document.getElementById('legend');
				var legend=document.getElementById('legenddiv');
					for(var i in e.chart.chartData){
						var row = e.chart.chartData[i];
						var color =e.chart.colors[i];
						var percent = Math.round(row.percents*100)/100;
						var value = row.value;
						oGraphChart.ChartSource.customLegend.innerHTML+='<div class="legend-item" id="legend-item-'+ i + '" onclick="toggleSlice(' + i +');" onmouseover="hoverSlice(' + i +');" onmouseout="blurSilce(' + i +');" style="color:'
																			+ color +';FONT-SIZE: 7pt;"><div class="legend-marker" style="background:' + color +'"></div>' 
																			+ row.title +'<div class="legend-value">'+ value + '|' + percent + '%</div></div>';
														
						//e.chart.legendDiv.appendChild(legend)
					}
				}	
				function toggleSlice(item){
					
					oGraphChart.ChartSource.clickSlice(item);	
				}	
				function hoverSlice(item){
					oGraphChart.ChartSource.rollOverSlice(item);
				}
				function blurSlice(item){
					oGraphChart.ChartSource.rollOutSlice(item);
				}
				
			
				var oGraphChart = new GraphChart();
				
					var oGraphChartLegendaBE = new GraphChart.LegendaBE();
					oGraphChartLegendaBE.MaxColumn=2;
					oGraphChartLegendaBE.Posicion=GraphChart.Enumerado.Legenda.Posicion.Bottom;
					oGraphChartLegendaBE.MarkerSize=5;
					oGraphChartLegendaBE.MargenTop=10;
					
					
				
					var oGraphChartGraficoBE =  new GraphChart.GraficoBE();
					oGraphChartGraficoBE.Tipo = GraphChart.Enumerado.Tipo.Pie3D;
					oGraphChartGraficoBE.Tema = GraphChart.Enumerado.Tema.Light;
					
				
					var oGraphChartTituloBE=new GraphChart.TituloBE();
						oGraphChartTituloBE.Text="GASTOS DE ADMINSTRACION";
						oGraphChartTituloBE.FontBold=true;
					oGraphChartGraficoBE.Titulo.Add(oGraphChartTituloBE);
							
						oGraphChartTituloBE=new GraphChart.TituloBE();
						oGraphChartTituloBE.Text=Page.Request.Params[KEYQTITULO];
						oGraphChartTituloBE.FontBold=false;
					oGraphChartGraficoBE.Titulo.Add(oGraphChartTituloBE);
				
				//oGraphChartGraficoBE.DataCollection=DATACOLLECTION;
				/*--------------------------------Carga de Datos-------------------------------------*/
				var oDataTable = (new Controladora.General.CFormato()).ObtenerResumenDirectorio(Page.Request.Params[KEYQIDFORMATO],Page.Request.Params[KEYQIDREPORTE],Page.Request.Params[KEYQPERIODO],Page.Request.Params[KEYQMES],'2;3',Page.Request.Params[KEYQIDTIPOINFORMACION],Page.Request.Params[KEYQLSTCONCEPTO]);
				for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
					var oDataRow = oDataTable.Rows.Items[f];
					var GraphChartData=new GraphChart.DataBE();
						GraphChartData.TextField = oDataRow.Item("Concepto");
						//GraphChartData.ValueField = ((oDataRow.Item("MesActual")==0)?520:(oDataRow.Item("MesActual")/1000));
						GraphChartData.ValueField = oDataRow.Item("MesActual");
					oGraphChartGraficoBE.DataCollection.Add(GraphChartData);
				}			
			
				/*--------------------------------Carga de Datos-------------------------------------*/
				
				oGraphChartGraficoBE.ToolTips="[[title]]<br><span style='font-size:14px'><b>[[value]]</b> ([[percents]]%)</span>";
				oGraphChartGraficoBE.Angulo=20;
				//oGraphChartGraficoBE.LegendaBE=oGraphChartLegendaBE.Render();
				oGraphChartGraficoBE.EventHandle=addLegendLabel;
				
				oGraphChart.GraficoBE= oGraphChartGraficoBE;
				oGraphChart.Render("chartdiv");

					/*$("#chartdiv").each(function(index,value) { 
										alert(value.innerHTML);
									}
								);*/
				
				
				
				
				
			</script>
		</form>
	</body>
</HTML>
