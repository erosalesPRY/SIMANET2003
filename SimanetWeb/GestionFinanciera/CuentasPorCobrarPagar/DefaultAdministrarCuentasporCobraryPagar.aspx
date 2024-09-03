<%@ Page language="c#" Codebehind="DefaultAdministrarCuentasporCobraryPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.DefaultAdministrarCuentasporCobraryPagar" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DefaultAdministrarCuentasporCobraryPagar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<!--<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>-->
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			function CargarTabs()
			{
				oGenerica = new SIMA.Clases.Generica();
				
				var NombreCTRLCentroOperativo = "_ctl4_ddlbCentroOperativo";
				var NombreCTRLPeriodo = "_ctl4_ddlbPeriodo";
				var NombreCTRLMes="_ctl4_ddlbMes";
				
				cbCentroOperativo = oGenerica.CreaIntanciaObjeto(NombreCTRLCentroOperativo);
				cbPeriodo = oGenerica.CreaIntanciaObjeto(NombreCTRLPeriodo);
				cbMes = oGenerica.CreaIntanciaObjeto(NombreCTRLMes);
								
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";
				var urlPaginaAdministraCuentasporCobraryPagar;
				var Parametros;
				var ParametroGeneral;
				var KEYQIDCENTRO="idCentro";
				var KEYQPERIODO="Periodo";
				var KEYQMES="Mes";
				var KEYQTIPOFINFORMACION="idTipoInfo";
				var KEYQDIGCUENTA="DigCta";
				var NOMBREOPCION ="NombreOP";
				
				urlPaginaAdministraCuentasporCobraryPagar = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/CuentasPorCobrarPagar/AdministrarCuentasCobraryPagar.aspx?";
					
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						/*Definicion del parametro general*/
						ParametroGeneral = KEYQIDCENTRO + SignoIgual.toString() + cbCentroOperativo.options[cbCentroOperativo.options.selectedIndex].value.toString()
										+ signoAmperson.toString() 
										+ KEYQPERIODO + SignoIgual.toString() + cbPeriodo.options[cbPeriodo.options.selectedIndex].value.toString()
										+ signoAmperson.toString() 
										+ KEYQMES + SignoIgual.toString() + cbMes.options[cbMes.options.selectedIndex].value.toString()
										+ signoAmperson.toString() 
										+ KEYQDIGCUENTA + SignoIgual.toString() + "0"
										+ signoAmperson.toString();
									
						/*Cuentas por cobrar*/
						Parametros = ParametroGeneral + KEYQTIPOFINFORMACION + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.CuentasPorCobrar.id.toString() + signoAmperson.toString() + NOMBREOPCION + SignoIgual.toString() + "cuentas por cobrar";
								
						oTab = new SIMA.Utilitario.Helper.General.Tab("Cuentas por Cobrar",urlPaginaAdministraCuentasporCobraryPagar + Parametros ,"Administrar Cuentas por Cobrar");
						oTabStrip.Tabs.Adicionar(oTab);

					
						/*Cuentas por Pagar*/
						Parametros = ParametroGeneral + KEYQTIPOFINFORMACION + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.CuentasPorPagar.id.toString()+ signoAmperson.toString() + NOMBREOPCION + SignoIgual.toString() + "cuentas por pagar";
						
						oTab = new SIMA.Utilitario.Helper.General.Tab("Cuentas por Pagar",urlPaginaAdministraCuentasporCobraryPagar + Parametros ,"Administrar Cuentas por Pagar" );
						oTabStrip.Tabs.Adicionar(oTab);
							
					}
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(0).Click();
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Cuentas por Cobrar y Pagar</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 643px; HEIGHT: 73px" cellSpacing="1" cellPadding="1" width="643"
							border="0">
							<TR>
								<TD align="left" width="100%">
									<DIV align="left">
										<TABLE class="tabla" id="TblTabs" style="HEIGHT: 36px" cellSpacing="0" cellPadding="0"
											width="100%" align="left" bgColor="#f5f5f5" border="0" runat="server">
											<TR>
												<TD></TD>
												<TD style="WIDTH: 371px"><asp:panel id="Panel" runat="server" Width="368px">Panel</asp:panel></TD>
												<TD vAlign="bottom" align="left"><asp:button id="btnConsultar" style="FONT-SIZE: 8pt; COLOR: #ffffcc; FONT-FAMILY: Arial Narrow; BACKGROUND-COLOR: #306898"
														runat="server" Text="Consultar"></asp:button></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" align="left" width="100%">...</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPaginaSort"
							runat="server">
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
