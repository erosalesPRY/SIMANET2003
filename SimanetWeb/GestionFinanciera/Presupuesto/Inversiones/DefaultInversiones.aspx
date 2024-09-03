<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DefaultInversiones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones.DefaultInversiones" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultCentrosdeCosto</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<script>
				var KEYQMODODETALLE = "MODODETALLE";
				
				var PROCESO ="idProceso";//Indicador de Proceso 
				var KEYQTIPOPRESUPUESTO ="idtp";
				var KEYQIDCENTROOPERATIVO="idCentro";
				var KEYQIDCENTROOPERATIVOP="idcop";//CentroOPerativo de la pagina de Procesos
				var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
				var KEYQIDGRUPOCC = "idGrpCC";
				var KEYQNOMBREGRUPOCC = "NombreGrpCC";
				var KEYQTIPOOPCION = "Opcion";
				var KEYQIDCENTROCOSTO ="idCC";
				var KEYQPERIODO="Periodo";
				var KEYQMES = "Mes";
				var KEYQMODO="Modo";
				var KEYQPPTO = "VISTAPPTO";
				var KEYQUIENLLAMA = "QLlama";
				var KEYQVISTA="Vista";
				
			function ObtenerListadodeCentrosdeCostoInversiones(){
					var Periodo = $O("txtPeriodo").value;
					var URLPAGINATRASNFERENCIA ="ConsultarInversionesPorCentrodeCosto.aspx?";
					var oDataTable = new System.Data.DataTable("tblCC");
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					try{
						oDataTable = (new Controladora.Presupuesto.CEvaluacion()).ConsultarCentroCostoPresupuestoInversion(Periodo);
						
						var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
						oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
						
						oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
						
						with(SIMA.Utilitario.Constantes.General.Caracter){
							for (var i=0; i <= oDataTable.Rows.Items.length-1; i++) 
							{
								dr = oDataTable.Rows.Items[i];
								if(dr.Item("EOF")==false){
									oTab = new SIMA.Utilitario.Helper.General.Tab();
									oTab.Texto = dr.Item("NombreCentrocosto");
									
									var Parametros=KEYQPERIODO + SignoIgual + Periodo
									+ signoAmperson 
									+ KEYQIDGRUPOCC + SignoIgual + dr.Item("NroCentroCosto")
									+ signoAmperson 
									+ KEYQIDCENTROCOSTO + SignoIgual + dr.Item("idcentrocosto");
									
									oTab.Url = URLPAGINATRASNFERENCIA + Parametros;
									oTab.ToolTips = dr.Item("NroCentroCosto")+ " " + dr.Item("NombreCentrocosto");
									oTabStrip.Tabs.Adicionar(oTab);
								}
								else if(dr.Item("EOF")==true){
									//Agregar();
									window.alert("No existen centros de costos en inversiones");
								}
							}
						}
						oTabStrip.RepintarTabs();
						oTabStrip.Tabs.Tab(0).Click();
					}
					catch(error){
						if(error instanceof SIMA.SIMAExcepcionLog){
							var oSIMAExcepcionLog = new SIMA.SIMAExcepcionLog();
							oSIMAExcepcionLog = error;
							window.alert(oSIMAExcepcionLog.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionIU){
							var oSIMAExcepcionIU = new SIMA.SIMAExcepcionIU();
							oSIMAExcepcionIU=error;
							window.alert(oSIMAExcepcionIU.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionDominio){
							var oSIMAExcepcionDominio = new SIMA.SIMAExcepcionDominio();
							oSIMAExcepcionDominio=error;
							window.alert("BASE DE DATOS\n" + oSIMAExcepcionDominio.Mensaje);
						}
					}
			}
			/*-------------------------------------------------------------------------------------------------------------------*/

				

			
		</script>
	</HEAD>
	<body onload="ObtenerHistorial();ObtenerListadodeCentrosdeCostoInversiones();" bottomMargin="0"
		leftMargin="0" topMargin="0" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1" id="tdHeader" runat="server">
						<uc1:Header id="Header1" runat="server"></uc1:Header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa" id="tdMenu" runat="server">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera>Presupuesto></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos Inversiones por Centros de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="left" width="100%" style="HEIGHT: 15px">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0"
										style="HEIGHT: 33px">
										<TR bgColor="#f0f0f0" id="trPeriodo" runat="server">
											<TD style="WIDTH: 34px">
												<asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="80%">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 70px">
												<asp:TextBox id="txtPeriodo" runat="server" Width="64px" CssClass="normaldetalle">2008</asp:TextBox></TD>
											<TD style="WIDTH: 80px">
												<asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita" Width="72px">MES :</asp:label></TD>
											<TD style="WIDTH: 76px">
												<asp:label id="lblMesactual" runat="server" CssClass="TextoNegroNegrita" Width="72px">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 734px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD align="left" width="100%">
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="PaginaAtras();" alt="" src="../../../imagenes/atras.gif">
									<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="../VistaPrevia.aspx" Visible="False">HyperLink</asp:HyperLink></TD>
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
