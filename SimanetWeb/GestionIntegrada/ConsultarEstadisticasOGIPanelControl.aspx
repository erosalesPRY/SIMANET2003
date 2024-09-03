<%@ Page language="c#" Codebehind="ConsultarEstadisticasOGIPanelControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.ConsultarEstadisticasOGIPanelControl" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEstadisticasOGIPanelControl</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<style> #chartdiv { WIDTH: 100%; HEIGHT: 500px } .amcharts-graph-g2 .amcharts-graph-stroke { stroke-dasharray: 3px 3px; stroke-linejoin: round; stroke-linecap: round; -webkit-animation: am-moving-dashes 1s linear infinite; animation: am-moving-dashes 1s linear infinite } .lastBullet { -webkit-animation: am-pulsating 1s ease-out infinite; animation: am-pulsating 1s ease-out infinite } .amcharts-graph-column-front { -webkit-transition: all .3s .3s ease-out; transition: all .3s .3s ease-out } .amcharts-graph-column-front:hover { -webkit-transition: all .3s ease-out; transition: all .3s ease-out; fill: #084B8A; stroke: #424242 } .amcharts-graph-g3 { stroke-dasharray: 0 \0/; stroke-linejoin: round; stroke-linecap: round; -webkit-animation: am-draw 1s; animation: am-draw 1s; stroke-dashoffset: 0 \0/ } </style>
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/amcharts.js"></script>
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/serial.js"></script>
		<script type="text/javascript" src="http://www.amcharts.com/lib/3/themes/none.js"></script>
		<script type="text/javascript" src="/SimanetWeb/js/Graph/GraphChart.js"></script>
		<script type="text/javascript" src="/SimanetWeb/js/@Import.js"></script>
		<script type="text/javascript" src="/SimanetWeb/js/@RegEXT.js"></script>
		<script>
		var oGraphChartCollectionDatosBar = new GraphChart.CollectionDataBar();
		
		var oDataTable = (new Controladora.OGI.CSAMNTAD()).ResumenAnualdeIndicadores(60);
				for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
					var oDataRow = oDataTable.Rows.Items[f];
					var oGraphChartDatosBE = new GraphChart.DataBarBE();
						oGraphChartDatosBE.Fecha=oDataRow.Item("FECHA");
						oGraphChartDatosBE.BarValue=oDataRow.Item("VALOR");
						oGraphChartDatosBE.BarName="";
						oGraphChartDatosBE.RedPointValue=oDataRow.Item("META");
					oGraphChartCollectionDatosBar.dataBar.add(oGraphChartDatosBE);
					}
			
		var chartData = oGraphChartCollectionDatosBar.dataBar.getAll();
		  
		  //NUEVO 
		  
		  var oGraphChartCategoryAxisBE = new GraphChart.CategoryAxisBE();
		  oGraphChartCategoryAxisBE.GroupBy="MM";
		  
		  
		  var oGraphChartCollectionEjes = new GraphChart.CollectionEjes();
		
			var oGraphChartEjesBE = new GraphChart.EjesBE();
				oGraphChartEjesBE.Id="Eje1";
				oGraphChartEjesBE.Titulo="%";
			oGraphChartCollectionEjes.Cejes.Add(oGraphChartEjesBE);
			
			
		  var oGraphChartCollectionGraficos = new GraphChart.CollectionGraficos();
			
			var oGraphChartGraficosBE = new GraphChart.GraficosBE();
				/*oGraphChartGraficosBE.Id="g1";
				oGraphChartGraficosBE.Titulo="% imple.";
				oGraphChartGraficosBE.Value="distance";
				oGraphChartGraficosBE.TipoGrafico="column";
				oGraphChartGraficosBE.TipoBordeGrafico="round";
				oGraphChartGraficosBE.EjeBase="Eje1";
			oGraphChartCollectionGraficos.graficos.add(oGraphChartGraficosBE);
			
			oGraphChartGraficosBE = new GraphChart.GraficosBE();*/
				oGraphChartGraficosBE.Id="g2";
				oGraphChartGraficosBE.Titulo="IMPLEMENTADO";
				oGraphChartGraficosBE.Value="latitude";
				oGraphChartGraficosBE.TipoGrafico="line";
				oGraphChartGraficosBE.TipoBordeGrafico="round";
				oGraphChartGraficosBE.EjeBase="Eje1";
			oGraphChartCollectionGraficos.graficos.add(oGraphChartGraficosBE);
			
			oGraphChartGraficosBE = new GraphChart.GraficosBE();
				oGraphChartGraficosBE.Id="g3";
				oGraphChartGraficosBE.Titulo="META";
				oGraphChartGraficosBE.Value="duration";
				oGraphChartGraficosBE.TipoGrafico="line";
				oGraphChartGraficosBE.TipoBordeGrafico="square";
				oGraphChartGraficosBE.EjeBase="Eje1";
			oGraphChartCollectionGraficos.graficos.add(oGraphChartGraficosBE);
			
			
			var oGraphChartCursorBE = new GraphChart.CursorBE();
			oGraphChartCursorBE.GroupBy="MM";
			
			var oGraphChartLegendBE = new GraphChart.LegendBE();
			
			
			var oGraphChartPeriodoBE = new GraphChart.PeriodoBE();
			oGraphChartPeriodoBE.GroupBy="MM";

			oGraphChartPeriodoBE.Ejes=oGraphChartCollectionEjes;
			oGraphChartPeriodoBE.Graficos=oGraphChartCollectionGraficos;
			oGraphChartPeriodoBE.Categoria=oGraphChartCategoryAxisBE;
			oGraphChartPeriodoBE.Cursor=oGraphChartCursorBE;
			oGraphChartPeriodoBE.Leyenda=oGraphChartCategoryAxisBE;
			oGraphChartPeriodoBE.Render("chartdiv");
		  
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD class="TituloPrincipal" align="center"><asp:label id="lblTitulo" runat="server"> ACCIONES CORRECTIVAS / PREVENTIVAS IMPLEMENTADAS</asp:label></TD>
				</TR>
			</table>
			<div id="chartdiv"></div>
			<table style="Z-INDEX: 0" id="Table55" border="0" cellSpacing="1" cellPadding="1" align="center"
				width="100%">
				<tr>
					<TD class="normaldetalle" align="left"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="X-Small"> DATA RESUMEN POR PERIODOS DE CONTROL</asp:label></TD>
				</tr>
				<TR class="ItemDetalle">
					<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" AutoGenerateColumns="False" width="100%"
							RowHighlightColor="#E0E0E0">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle Height="30px" CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="LEYENDA" HeaderText="  ">
									<HeaderStyle Width="8%"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Middle"
										BackColor="#3458B1"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ENERO" HeaderText="ENE-18">
									<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FEBRERO" HeaderText="FEB-18">
									<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MARZO" HeaderText="MAR-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Left" VerticalAlign="Top"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="ABRIL" HeaderText="ABR-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MAYO" HeaderText="MAY-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="JUNIO" HeaderText="JUN-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="JULIO" HeaderText="JUL-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AGOSTO" HeaderText="AGO-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SEPTIEMBRE" HeaderText="SEP-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OCTUBRE" HeaderText="OCT-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NOVIEMBRE" HeaderText="NOV-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="DICIEMBRE" HeaderText="DIC-18">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
