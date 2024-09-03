<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DefaultConcepto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.DefaultConcepto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultConcepto</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
		<script>
			function CargarTabs()
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";
				var urlPaginaAdministraEF;
				var Parametros;
				var QIDEMP = "idEmp";
				var pidReporte =1;
					
				urlPaginaAdministraEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/Directorio/AdministrarConceptoEstadosFinancieros.aspx?";
				
					
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
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.BalanceGeneral.toString(),urlPaginaAdministraEF + Parametros +ParametrosFormato ,"Administrar " + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.BalanceGeneral.toString());
						oTab.Tag = 0;
						oTab.EventHandle = TabSeleccionado;						
						oTabStrip.Tabs.Adicionar(oTab);

					
						/*Estado de Ganancias y Perdidas*/
						ParametrosFormato = signoAmperson.toString()
											+ "idFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.GananciasyPerdidas.toString() 
											+ signoAmperson.toString()
											+ "NFormato" + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.GananciasyPerdidas.toString()
											+ signoAmperson.toString()
											+ "Acumulado=0";
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.GananciasyPerdidas.toString(),urlPaginaAdministraEF + Parametros +ParametrosFormato ,"Administrar " + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.GananciasyPerdidas.toString());
						oTab.Tag = 1;
						oTab.EventHandle = TabSeleccionado;
						oTabStrip.Tabs.Adicionar(oTab);
							
						/*Flujo de Caja*/
						ParametrosFormato = signoAmperson.toString()
											+ "idFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.FlujodeCaja.toString() 
											+ signoAmperson.toString()
											+ "NFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.FlujodeCaja.toString() 
											+ signoAmperson.toString()
											+ "Acumulado=0";
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.FlujodeCaja.toString(),urlPaginaAdministraEF + Parametros +ParametrosFormato ,"Administrar " + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.FlujodeCaja.toString());
						oTab.Tag = 2;
						oTab.EventHandle = TabSeleccionado;						
						oTabStrip.Tabs.Adicionar(oTab);

						/*Ingresos y Egresos*/
						ParametrosFormato = signoAmperson.toString()
											+ "idFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.IngresosyEgresos.toString() 
											+ signoAmperson.toString()
											+ "NFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.IngresosyEgresos.toString() 
											+ signoAmperson.toString()
											+ "Acumulado=0";
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.IngresosyEgresos.toString(),urlPaginaAdministraEF + Parametros +ParametrosFormato ,"Administrar " + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.IngresosyEgresos.toString());
						oTab.Tag = 3;
						oTab.EventHandle = TabSeleccionado;

						oTabStrip.Tabs.Adicionar(oTab);
						
						/* Ctas por Cobrar y Pagar*/
						ParametrosFormato = signoAmperson.toString()
											+ "idFormato" + SignoIgual.toString() +SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Codigo.CtasPorCobrarPagar.toString() 
											+ signoAmperson.toString()
											+ "NFormato" + SignoIgual.toString() + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.CtasporCobraryPagar.toString() 
											+ signoAmperson.toString()
											+ "Acumulado=0";
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.CtasporCobraryPagar.toString(),urlPaginaAdministraEF + Parametros +ParametrosFormato ,"Administrar " + SIMA.Utilitario.Constantes.Financiera.FormatoEstadosFinancieros.Nombre.CtasporCobraryPagar.toString());
						oTab.Tag = 4;
						oTab.EventHandle = TabSeleccionado;						
						oTabStrip.Tabs.Adicionar(oTab);
					}
				var objTabSeleccionado = document.all["hTabSeleccionado"];
				
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(((objTabSeleccionado.value.length==0)?0:objTabSeleccionado.value)).Click();
			}
			function TabSeleccionado()
			{
				var objTabSeleccionado = document.all["hTabSeleccionado"];
				objTabSeleccionado.value = this.Tag ;
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Conceptos de Estados Financieros</asp:label></TD>
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
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" style="HEIGHT: 20px" align="left" width="100%">....</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"><INPUT id="hTabSeleccionado" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" runat="server"
										NAME="hTabSeleccionado"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPaginaSort" runat="server">
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
