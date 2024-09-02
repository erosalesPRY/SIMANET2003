<%@ Page language="c#" Codebehind="DefaultAdministrarObservacionesCtasCobrarPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.DefaultAdministrarObservacionesCtasCobrarPagar" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
				var KEYQIDCENTROOPERATIVO = "IdCentro";
				
				var KEYQCONCEPTO = "concepto";
				var KEYQSUBCUENTARUBRO = "subcuentarubro";
				var KEYQSUBCUENTA = "subcuenta";
			
			
				var OBJDDBLCONCEPTO=document.forms[0].elements["ddlbConcepto"];
				var OBJDDBLSUBCUENTARUBRO=document.forms[0].elements["ddblSubCuentaRubro"];
				var OBJDDBLSUBCUENTA=document.forms[0].elements["ddblSubCuenta"];
				
				urlPaginaConsultarEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/CuentasPorCobrarPagar/Directorio/AdministrarObservacionesCuentasPorCobrarPagar.aspx?";
				
				
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						Parametros =KEYQCONCEPTO + SignoIgual.toString() + OBJDDBLCONCEPTO.value
									+ signoAmperson.toString()
									+ KEYQSUBCUENTARUBRO + SignoIgual.toString() + OBJDDBLSUBCUENTARUBRO.value
									+ signoAmperson.toString()
									+ KEYQSUBCUENTA + SignoIgual.toString() + OBJDDBLSUBCUENTA.value
									+ signoAmperson.toString();
									
												
						
						/*Sima Peru*/
						/*OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru
								+ signoAmperson.toString() 
								+ QIDEMP + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru;
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString());
						oTab.Tag = 0;
						oTab.EventHandle = TabSeleccionado;		
						oTabStrip.Tabs.Adicionar(oTab);*/
						
						/*Sima Iquitos*/
						/*OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idIquitos.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato +  SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString())*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idIquitos
								+ signoAmperson.toString() 
								+ QIDEMP + SignoIgual.toString() + '0';
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString());
						oTab.Tag = 0;
						oTab.EventHandle = TabSeleccionado;		
						oTabStrip.Tabs.Adicionar(oTab);
						
						/*Sima Callao*/
						/*OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idCallao.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString());
						oTabStrip.Tabs.Adicionar(oTab);*/
						
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idCallao
								+ signoAmperson.toString() 
								+ QIDEMP + SignoIgual.toString() + '0';
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString());
						oTab.Tag = 1;
						oTab.EventHandle = TabSeleccionado;		
						oTabStrip.Tabs.Adicionar(oTab);
					
						/*Sima Chimbote*/
						/*OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idChimbote.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString()						
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString());
						oTabStrip.Tabs.Adicionar(oTab);*/
						
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idChimbote
								+ signoAmperson.toString() 
								+ QIDEMP + SignoIgual.toString() + '0';
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString());
						oTab.Tag = 2;
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
		onunload="SubirHistorial();" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Financiera > Administrar Observaciones de Cuentas Por Cobrar y Pagar</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="left" width="100%">
									<DIV align="center">
										<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" align="center" bgColor="#f5f5f5"
											border="0">
											<TR bgColor="#ffffff">
												<TD class="TitFiltros"><IMG height="14" src="../../../imagenes/TitFiltros.gif" width="82"></TD>
												<TD class="combos"></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 22px">
													<asp:label id="lblTipoPersona" runat="server" CssClass="normal">Concepto:</asp:label></TD>
												<TD class="SmallFont" style="HEIGHT: 22px">
													<asp:dropdownlist id="ddlbConcepto" runat="server" CssClass="normal" Width="233px" AutoPostBack="True"></asp:dropdownlist></TD>
												<TD class="SmallFont" style="HEIGHT: 22px">
													<asp:ImageButton id="btnComsultar" runat="server" ImageUrl="../../../imagenes/consultar.gif"></asp:ImageButton></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 22px" bgColor="#dddddd">
													<asp:label id="lblCuentaRubro" runat="server" CssClass="normal">Sub Cuenta:</asp:label></TD>
												<TD class="SmallFont" style="HEIGHT: 22px" bgColor="#dddddd">
													<asp:dropdownlist id="ddblSubCuentaRubro" runat="server" CssClass="normal" Width="233px" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD class="TitFiltros" id="TD3" style="HEIGHT: 26px" runat="server">
													<asp:label id="lblSubCuenta" runat="server" CssClass="normal">Sub Cuenta:</asp:label></TD>
												<TD class="combos" style="HEIGHT: 26px">
													<asp:dropdownlist id="ddblSubCuenta" runat="server" CssClass="normal" Width="233px" Height="32px"></asp:dropdownlist></TD>
												<TD class="combos" id="TD4" style="HEIGHT: 26px" runat="server"></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD align="left" width="100%">
									<DIV align="left">
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" width="100%" align="left">....</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<INPUT id="hTabSeleccionado" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hTabSeleccionado"
							runat="server">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
