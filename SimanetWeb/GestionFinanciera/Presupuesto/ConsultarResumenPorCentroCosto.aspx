<%@ Page language="c#" Codebehind="ConsultarResumenPorCentroCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarResumenPorCentroCosto" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarResumenPorCentroCosto</title>
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
			var KEYQPERIODO = "Periodo";
			var KEYQMES = "Mes";
			var KEYQMODO = "Modo";
			var KEYQPPTO = "VISTAPPTO";
			var KEYQVISTA="Vista";
			var KEYQTIPOPRESUPUESTO ="idtp";
			var KEYQIDCENTROOPERATIVO="idCentro";
			var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
			var KEYQDIGCTA = "digCta";
			var KEYQTIPOOPCION = "Opcion";
			var KEYTIPOINFORMACION = "TipoInfo";	
			function CargarTabs()
			{
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
					
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
				
				
				
				
				var UrlDetalle =PathApp + "/GestionFinanciera/Presupuesto/" + ((oPagina.Request.Params[KEYQVISTA]=='Acumulado')?((oPagina.Request.Params[KEYTIPOINFORMACION]=="ppto")?"ConsultarResumenPorCentroCostoyNaturalezaGasto.aspx":"ConsultarEvaluacionGastosdeAdministracionGrupoCC.aspx"):"ConsultarResumenPorCentroCostoyNaturalezaGasto.aspx")+"?"; 
				var Parametros;
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = KEYQTIPOPRESUPUESTO + SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
									+ signoAmperson.toString()
									+ KEYQPPTO + SignoIgual.toString() + oPagina.Request.Params[KEYQPPTO]
									+ signoAmperson.toString()
									+ KEYQIDCENTROOPERATIVO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
									+ signoAmperson.toString()
									+ KEYQCENTROOPERATIVONOMBRE + SignoIgual.toString() + oPagina.Request.Params[KEYQCENTROOPERATIVONOMBRE]
									+ signoAmperson.toString()
									+ KEYQPERIODO + SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO]
									+ signoAmperson.toString()
									+ KEYQMES + SignoIgual.toString() + oPagina.Request.Params[KEYQMES]
									+ signoAmperson.toString()
									+ KEYQDIGCTA + SignoIgual.toString() + oPagina.Request.Params[KEYQDIGCTA]
									+ signoAmperson.toString()
									+ KEYQVISTA + SignoIgual.toString() + oPagina.Request.Params[KEYQVISTA]
									+ signoAmperson.toString()
									+ KEYQMODO + SignoIgual.toString() + oPagina.Request.Params[KEYQMODO]
									+ signoAmperson.toString()
									+ KEYTIPOINFORMACION + SignoIgual.toString() + oPagina.Request.Params[KEYTIPOINFORMACION]
									+ signoAmperson.toString()
									+ KEYQTIPOOPCION + SignoIgual.toString();
									
				}
				var ArrData;
				var ArrDataUrl;
				switch(oPagina.Request.Params[KEYQTIPOPRESUPUESTO])
				{
					case '1':
						ArrData = ["Materias Primas y Suministros"," Sueldos y Bonificaciones","Suministros Diversos-Env y Embalaje","Leyes Sociales y Otras Remmunerac.","Servicios de Terceros","Tributos y Cargas Divers. de Gestion","Cargas Financieras","Provisiones del Ejercicio"];
						ArrDataUrl=[UrlDetalle + Parametros + "1" ,UrlDetalle + Parametros + "2",UrlDetalle + Parametros + "3",UrlDetalle + Parametros + "4",UrlDetalle + Parametros + "5",UrlDetalle + Parametros + "6",UrlDetalle + Parametros + "7",UrlDetalle + Parametros + "8"];
						break;
					case '2':
						ArrData = ["Materias Primas y Suministros"," Sueldos y Bonificaciones","Suministros Diversos-Env y Embalaje","Leyes Sociales y Otras Remmunerac.","Servicios de Terceros","Tributos y Cargas Divers. de Gestion","Cargas Financieras","Provisiones del Ejercicio"];
						ArrDataUrl=[UrlDetalle + Parametros + "1" ,UrlDetalle + Parametros + "2",UrlDetalle + Parametros + "3",UrlDetalle + Parametros + "4",UrlDetalle + Parametros + "5",UrlDetalle + Parametros + "6",UrlDetalle + Parametros + "7",UrlDetalle + Parametros + "8"];
						break;
					case '3':
						ArrData = ["Materias Primas y Suministros"," Sueldos y Bonificaciones","Suministros Diversos-Env y Embalaje","Leyes Sociales y Otras Remmunerac.","Servicios de Terceros","Tributos y Cargas Divers. de Gestion","Cargas Financieras","Provisiones del Ejercicio"];
						ArrDataUrl=[UrlDetalle + Parametros + "1" ,UrlDetalle + Parametros + "2",UrlDetalle + Parametros + "3",UrlDetalle + Parametros + "4",UrlDetalle + Parametros + "5",UrlDetalle + Parametros + "6",UrlDetalle + Parametros + "7",UrlDetalle + Parametros + "8"];
						break;	
					
				}
							   
				var ArrDataTollTips = ["",""];
				for (var i=0;i<=ArrData.length-1;i++)
				{
					oTab = new SIMA.Utilitario.Helper.General.Tab(ArrData[i],ArrDataUrl[i],ArrDataTollTips[i]);
					oTabStrip.Tabs.Adicionar(oTab);
				}
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(0).Click();
			}
			function PaginaAtras()
			{
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				/*var urlPaginaResumenPPTO="TiposdePresupuestoEvaluacion.aspx?" 
					+ KEYQPERIODO + "=" +  oPagina.Request.Params[KEYQPERIODO]
					+ "&" + KEYQMES + "=" + oPagina.Request.Params[KEYQMES]
					+ "&" + KEYQMODO + "=" + oPagina.Request.Params[KEYQMODO]
					+ "&" + KEYQPPTO + "=" + oPagina.Request.Params[KEYQPPTO];
				window.location.href = urlPaginaResumenPPTO;*/
				var urlPaginaResumenPPTO="DefaultGrupoCC.aspx?" 
					+ KEYQPPTO + "=" + oPagina.Request.Params[KEYQPPTO]
					+ "&" + KEYQIDCENTROOPERATIVO + "=" + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
					+ "&" + KEYQCENTROOPERATIVONOMBRE + "=" + oPagina.Request.Params[KEYQCENTROOPERATIVONOMBRE] 
					+ "&" + KEYQPERIODO + "=" +  oPagina.Request.Params[KEYQPERIODO]
					+ "&" + KEYQMES + "=" + oPagina.Request.Params[KEYQMES]
					+ "&" + KEYQMODO + "=" + oPagina.Request.Params[KEYQMODO]
					+ "&" + KEYQVISTA + "=" + oPagina.Request.Params[KEYQVISTA]
					+ "&" +  KEYTIPOINFORMACION+ "=" +  oPagina.Request.Params[KEYTIPOINFORMACION]
					+ "&" + KEYQTIPOPRESUPUESTO + "=" + oPagina.Request.Params[KEYQTIPOPRESUPUESTO];
				window.location.href = urlPaginaResumenPPTO;
			}
		</script>
	</HEAD>
	<body onload="CargarTabs();ObtenerHistorial();" onunload="SubirHistorial();" bottomMargin="0"
		leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Resumen Presupuestos por Grupos de Centros de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" style="HEIGHT: 117px">
							<TR>
								<TD align="left" width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0"
										style="HEIGHT: 30px">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 34px" colSpan="2">
												<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="128px">CENTRO OPERATIVO :</asp:label></TD>
											<TD style="WIDTH: 31px" colSpan="2">
												<asp:label id="lblCentroOperativo" runat="server" CssClass="TextoNegroNegrita" Width="128px">CENTRO OPERATIVO :</asp:label></TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 34px">
												<asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="80%">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 70px">
												<asp:label id="lblPeriodo" runat="server" CssClass="TextoNegroNegrita" Width="80%">Periodo :</asp:label></TD>
											<TD style="WIDTH: 45px">
												<asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">MES :</asp:label></TD>
											<TD>
												<asp:label id="lblMes" runat="server" CssClass="TextoNegroNegrita" Width="110px">Mes :</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" width="100%" align="left">....</TD>
							</TR>
							<TR>
								<TD align="right" width="100%">
									<TABLE class="ItemGrilla" id="tblResumen" style="BORDER-BOTTOM: silver 1px solid; BORDER-LEFT: silver 1px solid; DISPLAY: none; HEIGHT: 19px; BORDER-TOP: silver 1px solid; BORDER-RIGHT: silver 1px solid"
										cellSpacing="1" cellPadding="1" width="100%" align="left" border="0" runat="server">
										<TR>
											<TD width="62%">RESUMEN</TD>
											<TD style="BORDER-LEFT: silver 1px solid" align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" align="right" width="13%">100</TD>
										</TR>
									</TABLE>
									<asp:ImageButton style="Z-INDEX: 0" id="ibtnResumen" runat="server" ImageUrl="../../imagenes/btn_Resume.JPG"></asp:ImageButton>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="PaginaAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
