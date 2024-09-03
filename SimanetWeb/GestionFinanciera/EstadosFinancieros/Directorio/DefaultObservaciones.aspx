<%@ Page language="c#" Codebehind="DefaultObservaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.DefaultObservaciones" %>
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
				
				var KEYQANO = "ano";
				var KEYQMES = "mes";
			
				var NOMBRECENTRO ="NombreCentro";
				var OBJDDBLAMO=document.forms[0].elements["ddblAno"];
				var OBJDDBLMES=document.forms[0].elements["ddblMes"];
				
				urlPaginaConsultarEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/Directorio/AdministrarMotivoManoObraImproductiva.aspx?";
				
				
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						Parametros =KEYQANO + SignoIgual.toString() + OBJDDBLAMO.value
									+ signoAmperson.toString()
									+ KEYQMES + SignoIgual.toString() + OBJDDBLMES.value
									+ signoAmperson.toString();
									
												
						
						/*Sima Peru*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru;
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString());
						oTabStrip.Tabs.Adicionar(oTab);
						
						/*Sima Iquitos*/
						/*OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idIquitos.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato +  SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString())*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idIquitos
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString());
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
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString());
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
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString(),
								urlPaginaConsultarEF + Parametros + OtrPrm,
								SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString());
						oTabStrip.Tabs.Adicionar(oTab);
						
					}
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(0).Click();
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción > Administrar Motivos de Mano de Obra Improductiva</asp:label></TD>
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
													<P align="right">
														<asp:label id="lblTipoPersona" runat="server" CssClass="normal">Mes:</asp:label></P>
												</TD>
												<TD class="SmallFont" style="HEIGHT: 22px">
													<asp:dropdownlist id="ddblMes" runat="server" CssClass="normal" Width="130px">
														<asp:ListItem Value="1">Enero</asp:ListItem>
														<asp:ListItem Value="2">Febrero</asp:ListItem>
														<asp:ListItem Value="3">Marzo</asp:ListItem>
														<asp:ListItem Value="4">Abril</asp:ListItem>
														<asp:ListItem Value="5">Mayo</asp:ListItem>
														<asp:ListItem Value="6">Junio</asp:ListItem>
														<asp:ListItem Value="7">Julio</asp:ListItem>
														<asp:ListItem Value="8">Agosto</asp:ListItem>
														<asp:ListItem Value="9">Setiembre</asp:ListItem>
														<asp:ListItem Value="10">Octubre</asp:ListItem>
														<asp:ListItem Value="11">Noviembre</asp:ListItem>
														<asp:ListItem Value="12">Diciembre</asp:ListItem>
													</asp:dropdownlist></TD>
											</TR>
											<TR>
												<TD style="HEIGHT: 22px" bgColor="#dddddd">
													<P align="right">
														<asp:label id="lblCuentaRubro" runat="server" CssClass="normal">Año:</asp:label></P>
												</TD>
												<TD class="SmallFont" style="HEIGHT: 22px" bgColor="#dddddd">
													<asp:dropdownlist id="ddblAno" runat="server" CssClass="normal" Width="128px"></asp:dropdownlist></TD>
												<TD class="SmallFont" style="HEIGHT: 22px" bgColor="#dddddd">
													<asp:ImageButton id="btnComsultar" runat="server" ImageUrl="../../../imagenes/consultar.gif"></asp:ImageButton></TD>
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
						<INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPaginaSort"
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
