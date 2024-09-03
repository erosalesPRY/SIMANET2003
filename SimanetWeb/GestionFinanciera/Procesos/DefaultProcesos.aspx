<%@ Page language="c#" Codebehind="DefaultProcesos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Procesos.DefaultProcesos" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultAdministrarEstadosFinancieros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			function CargarTabs()
			{
				var PathPaginas = SIMA.Utilitario.Helper.General.ObtenerPathApp()+ "/GestionFinanciera/Procesos/";
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";
				var urlPaginaAdministraEF;
				var Parametros;
				var QIDEMP = "idEmp";
				var pidReporte =1;
				var KEYQIDGRUPOPROCESO = "idGrpProceso";
				var KEYQIDMODULO = "idModulo";
				
					/*	var NombreControlCEOP = "_ctl4_trCentroOperativo";
						objFilaCEOP = document.all[NombreControlCEOP];
						objFilaCEOP.style.display = SIMA.Utilitario.Constantes.Html.Atributos.Display.None.toString();
					*/	
						//urlPaginaAdministraEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/ConsultaDeEstadosFinancierosPERU.aspx?";
					
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						Parametros = "idReporte" + SignoIgual.toString() + pidReporte
									+ signoAmperson.toString()
									+ "idEmp" + SignoIgual.toString() + oPagina.Request.Params[QIDEMP];
					
					
					
						/*Balance General*/
						var ParametrosFormato = signoAmperson.toString()
												+ "idFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.BalanceGeneral.toString() 
												+ signoAmperson.toString()
												+ "NFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.BalanceGeneral.toString() 
												+ signoAmperson.toString()
												+ "Acumulado=1";
												
						var urlPaginaProceso = PathPaginas + "ProcesosEstadosFinancieros.aspx?";
						
						urlPaginaProceso = PathPaginas + "ProcesosEstadosFinancieros.aspx?";
						var objTrama = document.all["hListaProcesos"];
						var arrDataGrupoProcesos = objTrama.value.toString().split('[@]');
						
						arrDataGrupoProcesos.idGrupoProceso= function(index){
							return this[index].split(';')[0];
						}
						arrDataGrupoProcesos.DescripcionGrupoProceso= function(index){
							return this[index].split(';')[1];
						}
						function GrupodeProcesosBE(idTab,idGrupoProceso,DescripcionGrupoProceso){
							this.idTab = idTab;
							this.idGrupoProceso =idGrupoProceso;
							this.DescripcionGrupoProceso = DescripcionGrupoProceso;
						}
						
						for(var i=0;i<= arrDataGrupoProcesos.length-1;i++)
						{
							oGrupodeProcesosBE = new GrupodeProcesosBE(i,arrDataGrupoProcesos.idGrupoProceso(i),arrDataGrupoProcesos.DescripcionGrupoProceso(i));
							with(SIMA.Utilitario.Constantes.General.Caracter)
							{
								var Parametros = KEYQIDMODULO + SignoIgual.toString() +  oPagina.Request.Params[KEYQIDMODULO]
												+ signoAmperson.toString()
												+ KEYQIDGRUPOPROCESO + SignoIgual.toString() + oGrupodeProcesosBE.idGrupoProceso;
								
								oTab = new SIMA.Utilitario.Helper.General.Tab(oGrupodeProcesosBE.DescripcionGrupoProceso,urlPaginaProceso + Parametros ,"Procesos de " + oGrupodeProcesosBE.DescripcionGrupoProceso);
								oTab.Tag = oGrupodeProcesosBE;
								oTab.EventHandle = TabSeleccionado;
								oTabStrip.Tabs.Adicionar(oTab);
							}
						}
						
					}
				var objTabSeleccionado = document.all["hTabSeleccionado"];
				
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(((objTabSeleccionado.value.length==0)?0:objTabSeleccionado.value)).Click();
			}
			function TabSeleccionado()
			{
				var objTabSeleccionado = document.all["hTabSeleccionado"];
				oGrupodeProcesosBE = new GrupodeProcesosBE();
				oGrupodeProcesosBE = this.Tag;
				objTabSeleccionado.value = GrupodeProcesosBE.idTab;
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="CargarTabs();ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 650px; HEIGHT: 109px" cellSpacing="1" cellPadding="1"
							width="650" border="0">
							<TR>
								<TD align="left" width="100%">
									<DIV align="left">
										<TABLE class="tabla" id="TblTabs" style="HEIGHT: 36px" cellSpacing="0" cellPadding="0"
											width="100%" align="left" bgColor="#f5f5f5" border="0" runat="server">
											<TR>
												<TD></TD>
												<TD style="WIDTH: 371px"><asp:panel id="Panel" runat="server" Width="368px">Panel</asp:panel></TD>
												<TD vAlign="bottom" align="left"></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" style="HEIGHT: 20px" align="left" width="100%">....</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hTabSeleccionado" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hTabSeleccionado"
										runat="server"><INPUT id="hListaProcesos" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="hTabSeleccionado"
										runat="server"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
