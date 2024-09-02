<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DefaultGraficosVentasPresupuesto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.DefaultGraficosVentasPresupuesto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultCentrosdeCosto</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			var URLREPORTEPRESUPUESTOVSVENTASPORPERIODO= "../Reportes/GraficoVentasVSPresupuestoPorPeriodo.aspx?";
			var KEYOPTIONGRAFICO="OPGRAPH";
			var VERSION = "IdVersion";
			var ANO = "Ano";	
				
			function CargarTabs()
			{
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
					
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
				
				var Parametros;
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros =  VERSION + SignoIgual.toString() + oPagina.Request.Params[VERSION]
									+ signoAmperson.toString()
									+ ANO + SignoIgual.toString() + oPagina.Request.Params[ANO]
									+ signoAmperson.toString()
									+ KEYOPTIONGRAFICO + SignoIgual.toString();
				}
				
				var ArrData;
				var ArrDataUrl;
				ArrData = ["Gráfica de Barras","Gráfica de Lineas"];
				ArrDataUrl=[URLREPORTEPRESUPUESTOVSVENTASPORPERIODO + Parametros + "2" ,URLREPORTEPRESUPUESTOVSVENTASPORPERIODO + Parametros + "3"];
							   
				var ArrDataTollTips = ["Análisis Ventas vs Presupuesto en Barras","Análisis Ventas vs Presupuesto en Lineas"];
				for (var i=0;i<=ArrData.length-1;i++)
				{
					oTab = new SIMA.Utilitario.Helper.General.Tab(ArrData[i],ArrDataUrl[i],ArrDataTollTips[i]);
					oTabStrip.Tabs.Adicionar(oTab);
				}
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(0).Click();
			}
			
		</script>
	</HEAD>
	<body onload="ObtenerHistorial();CargarTabs();" bottomMargin="0" leftMargin="0" topMargin="0"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1" id="tdHeader" runat="server"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa" id="tdMenu" runat="server"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos por Grupos de Centros de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD id="divContenedor" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
