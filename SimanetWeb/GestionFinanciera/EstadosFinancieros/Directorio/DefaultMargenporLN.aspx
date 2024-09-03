<%@ Page language="c#" Codebehind="DefaultMargenporLN.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.DefaultMargenporLN" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DefaultMargenporLN</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<SCRIPT language="javascript">(new Script.Import()).Registrar();</SCRIPT>
		<script>
			var KEYQPERIODO = "Periodo";
			var KEYQMES = "Mes";
			var KEYQMODO = "Modo";
			var KEYQPPTO = "VISTAPPTO";
			var KEYQUIENLLAMA = "QLlama";
			
			function CargarTabs()
			{
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
					
				oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
				oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
				
				var KEYQTIPOPRESUPUESTO ="idtp";
				var KEYQIDCENTROOPERATIVO="idCentro";
				var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
				var KEYQDIGCTA = "digCta";
				var KEYQTIPOOPCION = "Opcion";
				
				var UrlDetalle =PathApp + "/GestionFinanciera/Presupuesto/ConsultarEvaluacionGastosdeAdministracionGrupoCC.aspx?"; 
				var Parametros;
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = KEYQUIENLLAMA + SignoIgual.toString() + oPagina.Request.Params[KEYQUIENLLAMA]
									+ signoAmperson.toString()
									+ KEYQTIPOPRESUPUESTO + SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
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
									+ KEYQMODO + SignoIgual.toString() + oPagina.Request.Params[KEYQMODO]
									+ signoAmperson.toString()
									+ KEYQTIPOOPCION + SignoIgual.toString();
									
				}
				
				var ArrData;
				var ArrDataUrl;
				switch(oPagina.Request.Params[KEYQTIPOPRESUPUESTO])
				{
					case '1':
						ArrData = ["Areas Administrativas","Areas de Producción"];
						ArrDataUrl=[UrlDetalle + Parametros + "0" ,UrlDetalle + Parametros + "1"];
						break;
					case '2':
						ArrData = ["División Astillero","Apoyo a la Producción"];
						ArrDataUrl=[UrlDetalle + Parametros + "1",UrlDetalle + Parametros + "0"];
						break;
					case '3':
						ArrData = ["División Astillero","Apoyo a la Producción"];
						ArrDataUrl=[UrlDetalle + Parametros + "0",UrlDetalle + Parametros + "1"];
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
			
			/*
			function PaginaAtras()
			{
				oPagina= (new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[KEYQPERIODO] ;
				var urlPaginaResumenPPTO="TiposdePresupuestoEvaluacion.aspx?" 
					+ KEYQPERIODO + "=" +  oPagina.Request.Params[KEYQPERIODO] 
					+ "&" + KEYQMES + "=" + oPagina.Request.Params[KEYQMES]
					+ "&" + KEYQMODO + "=" + oPagina.Request.Params[KEYQMODO]
					+ "&" + KEYQPPTO + "=" + oPagina.Request.Params[KEYQPPTO];
				window.location.href = urlPaginaResumenPPTO;
			}
			*/
			var strHistorial="";
			function PermanecerHistorial(){
				//strHistorial=window.clipboardData.getData('Text');
				strHistorial=localStorage.getItem('History');
			}
			function SubirHst(){
				//window.clipboardData.setData('Text',strHistorial);
				localStorage.setItem('History',strHistorial);
			}
		</script>
</HEAD>
	<body onload="CargarTabs();PermanecerHistorial();ObtenerHistorial();SubirHst();" onunload="SubirHistorial();"
		bottomMargin="0" leftMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="98%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0" style="HEIGHT: 117px">
							<TR>
								<TD align="left" width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
										style="HEIGHT: 30px">
										<TR bgColor="#f0f0f0">
											<TD colSpan="2">
												<asp:label id="lblCentroOperativo" runat="server" CssClass="TextoNegroNegrita" Width="400px">CENTRO OPERATIVO :</asp:label></TD>
										</TR>
										<TR bgColor="#f0f0f0">
											<TD>
												<asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="64px">PERIODO :</asp:label>
												<asp:label id="lblPeriodo" runat="server" CssClass="TextoNegroNegrita" Width="64px">Periodo :</asp:label>
												<asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">MES :</asp:label>
												<asp:label id="lblMes" runat="server" Width="110px" CssClass="TextoNegroNegrita">Mes :</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" align="center" width="100%">....</TD>
							</TR>
							<TR>
								<TD align="center" width="100%">
									<TABLE class="ItemGrilla" id="tblResumen" style="BORDER-RIGHT: silver 1px solid; BORDER-TOP: silver 1px solid; BORDER-LEFT: silver 1px solid; BORDER-BOTTOM: silver 1px solid; HEIGHT: 19px"
										cellSpacing="1" cellPadding="1" width="100%" align="left" border="0" runat="server">
										<TR>
											<TD width="62%">RESUMEN</TD>
											<TD style="BORDER-LEFT: silver 1px solid" align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" align="right" width="13%">100</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="right"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/RetornarAlFormato.GIF"></TD>
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
