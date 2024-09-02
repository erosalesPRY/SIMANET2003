<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DefaultAdministrarObjetivosEspecificos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.DefaultAdministrarObjetivosEspecificos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			function CargarTabs()
			{
				
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				
				oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";
				var urlPagina;
				var Parametros;
				var KEYQIDPLANESTRATEGICO="idPLEstr";
				var KEYQidObjGen = "idObjGen";
				var KEYQCodObjGen = "CodObjGen";
				var KEYQObjGenNombre = "ObjGenNombre"
				var KEYQIDCENTROOPERATIVO = "IdCentro";
				var KEYQPLEstrNombre = "PLEstrNombre";
				urlPagina = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionEstrategica/PlanEstrategico/AdministrarPlanEstrategicoObjetivosEspecificos.aspx?";
					
					
					
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						Parametros = KEYQIDPLANESTRATEGICO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDPLANESTRATEGICO]
									+ signoAmperson.toString() 
									+ KEYQidObjGen + SignoIgual.toString() + oPagina.Request.Params[KEYQidObjGen]
									+ signoAmperson.toString() 
									+ KEYQCodObjGen + SignoIgual.toString() + oPagina.Request.Params[KEYQCodObjGen]
									+ signoAmperson.toString()
									+ KEYQObjGenNombre + SignoIgual.toString() + oPagina.Request.Params[KEYQObjGenNombre]
									+ signoAmperson.toString()
									+ KEYQPLEstrNombre + SignoIgual.toString() + oPagina.Request.Params[KEYQPLEstrNombre]
									+ signoAmperson.toString();
										
									
						
							/*Sima Peru*/
							OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru;
																		
							oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString(),urlPagina + Parametros + OtrPrm ,"Consultar " + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString());
							oTabStrip.Tabs.Adicionar(oTab);
					
						
						/*Sima Callao*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idCallao.toString();
								
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString(),urlPagina + Parametros + OtrPrm ,"Consultar " + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString());
						oTabStrip.Tabs.Adicionar(oTab);
						/*Sima Chimbote*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idChimbote.toString();
								
					
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString(),urlPagina + Parametros + OtrPrm ,"Consultar " + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString());
						oTabStrip.Tabs.Adicionar(oTab);
						
						/*Sima Iquitos*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idIquitos.toString();
						
						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString(),urlPagina + Parametros + OtrPrm ,"Consultar " + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString())
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%" style="HEIGHT: 19px">
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Objetivos Especificos</asp:label>
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Estrategica></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
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
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
