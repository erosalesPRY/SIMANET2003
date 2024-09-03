<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio._Default" %>
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
				var KEYQIDFORMATO = "IdFormato";
				var KEYQIDREPORTE = "idReporte";
				var KEYQNOMBREFORMATO = "NFormato"
				var KEYQIDCENTROOPERATIVO = "IdCentro";
				var pidReporte =1;
				var KEYQIDFECHA = "efFecha";
				var KEYQIDNIVELEXPANDE = "NivelExp";
				var KEYQIDCLASIFICACIONRUBRO = "RubroClasf";
				var NOMBRECENTRO ="NombreCentro";
				var KEYQESOBSERVACION="Observacion";
					urlPaginaConsultarEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/Directorio/ConsultarEstadosFinancierosPorCentro.aspx?";
					
					
					
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						Parametros = KEYQIDFORMATO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDFORMATO]
									+ signoAmperson.toString() 
									+ KEYQIDREPORTE + SignoIgual.toString() + pidReporte
									+ signoAmperson.toString()
									+ KEYQNOMBREFORMATO + SignoIgual.toString() + oPagina.Request.Params[KEYQNOMBREFORMATO].toString().toUpperCase()
									+ signoAmperson.toString()
									+ KEYQIDFECHA + SignoIgual.toString() + oPagina.Request.Params[KEYQIDFECHA]
									+ signoAmperson.toString()
									+ KEYQIDNIVELEXPANDE + SignoIgual.toString() + oPagina.Request.Params[KEYQIDNIVELEXPANDE]
									+ signoAmperson.toString()
									+ KEYQESOBSERVACION + SignoIgual.toString() + oPagina.Request.Params[KEYQESOBSERVACION]	
									+ signoAmperson.toString()
									+ KEYQIDCLASIFICACIONRUBRO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDCLASIFICACIONRUBRO]
									+ signoAmperson.toString();
										
									
						var NombreFormato = oPagina.Request.Params[KEYQNOMBREFORMATO] + " de ";
						var obs = oPagina.Request.Params[KEYQESOBSERVACION];

						/*
						if( obs.toString() == "0" || obs.toString() == "false")
						{*/
							/*Sima Peru*/
							OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru
									+ signoAmperson.toString() 
									+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString()
									+ signoAmperson.toString()
									+ QIDEMP + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idPeru;
									
							oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombrePeru.toString());
							oTabStrip.Tabs.Adicionar(oTab);
					/*	}*/
						/*Sima Iquitos*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idIquitos.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato +  SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreIquitos.toString())
						oTabStrip.Tabs.Adicionar(oTab);
						/*Sima Callao*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idCallao.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString()
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreCallao.toString());
						oTabStrip.Tabs.Adicionar(oTab);
						/*Sima Chimbote*/
						OtrPrm = KEYQIDCENTROOPERATIVO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.idChimbote.toString()
								+ signoAmperson.toString() 
								+ NOMBRECENTRO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString()						
								+ signoAmperson.toString()
								+ QIDEMP + SignoIgual.toString() + '0';

						oTab = new SIMA.Utilitario.Helper.General.Tab(SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString(),urlPaginaConsultarEF + Parametros + OtrPrm ,"Consultar " + NombreFormato + SIMA.Utilitario.Constantes.General.CentrosOperativo.NombreChimbote.toString());
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Estados Financieros</asp:label>
						<asp:label id="lblNombreFormato" runat="server" CssClass="RutaPaginaActual">Consultar Estados Financieros</asp:label></TD>
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
