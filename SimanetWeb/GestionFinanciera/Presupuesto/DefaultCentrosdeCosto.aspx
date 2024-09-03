<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DefaultCentrosdeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.DefaultCentrosdeCosto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultCentrosdeCosto</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
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
				var KEYTIPOINFORMACION = "TipoInfo";
				
				/*Parametros complementarios para actualizacion en UNISYS*/
				var NROCENTROOPERATIVO="Nrocop";
				var KEYQNROGRUPOCC = "NroGrpCC";
				
			function CambiarImgBotonAtras()
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if (oPagina.Request.Params[KEYQUIENLLAMA] != undefined)
				{
					var objBtn = document.all["ibtnAtras"];
					objBtn.src = objBtn.src.replace("atras","RetornarAlFormato");
					
					objBtn.parentElement
					objBtn.parentElement.align = "right";
				}
			}
				

			function ObtenerListadodeCentrosdeCosto()
			{
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();				
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				
				//Oculta la Tabla resumen y solo se mostrar cuando el modo sea de consulta
				document.all["tblResumen"].style.display =  (oPagina.Request.Params[KEYQMODO]=="C")?"block":"none";
				
				var UrlPaginaProceso =PathApp + "/GestionFinanciera/Presupuesto/Procesar.aspx?"; 
				
				var Parametros;
				var strListaParametros;
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = PROCESO + SignoIgual.toString()+ SIMA.Utilitario.Constantes.General.ProcesoCallBack.EvaluacionPrespuestalListarCentrosdeCosto.toString()
									+ signoAmperson.toString()
									+ KEYQUIENLLAMA		+ SignoIgual.toString() + oPagina.Request.Params[KEYQUIENLLAMA]
									+ signoAmperson.toString()
									+ KEYQTIPOPRESUPUESTO		+ SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
									+ signoAmperson.toString()
									+ KEYQIDCENTROOPERATIVOP	+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
									+ signoAmperson.toString()
									+ KEYQIDGRUPOCC				+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDGRUPOCC]
									+ signoAmperson.toString()
									+ KEYQPERIODO				+ SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO]
									+ signoAmperson.toString()
									+ KEYQTIPOOPCION			+ SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOOPCION]
									+ signoAmperson.toString()
									+ NROCENTROOPERATIVO		+ SignoIgual.toString() + oPagina.Request.Params[NROCENTROOPERATIVO]
									+ signoAmperson.toString()
									+ KEYQNROGRUPOCC			+ SignoIgual.toString() + oPagina.Request.Params[KEYQNROGRUPOCC];
					
				}
				
				strListaParametros = SIMA.Utilitario.Constantes.General.ProcesoCallBack.EvaluacionPrespuestalListarCentrosdeCosto.toString();
				/*Crea Una Instancia del Objeto PostBack*/
				(new SIMA.Utilitario.Helper.General.CallBack()).CargarDocumentoXML(UrlPaginaProceso + Parametros,strListaParametros);
			}
			
			//Llamado por el proceso remoto
			function TabSeleccionado(){
				var oCentroCostoBE = this.Tag;
				jNet.get('hIdCentroCostoSelect').value=oCentroCostoBE.Id;
				jNet.get('hTabSeleccionado').value=oCentroCostoBE.Index;
			}				
				
				
			function PaginaAtras()
			{
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				if(oPagina.Request.Params[KEYQUIENLLAMA] !=0){
					var urlPaginaResumenPPTO="DefaultGrupoCC.aspx?" 
						+ KEYQPERIODO + "=" +  oPagina.Request.Params[KEYQPERIODO]
						+ "&" + KEYQMES + "=" + oPagina.Request.Params[KEYQMES]
						+ "&" + KEYQIDGRUPOCC + "=" + oPagina.Request.Params[KEYQIDGRUPOCC]
						+ "&" + KEYQTIPOPRESUPUESTO + "=" + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
						+ "&" + KEYQIDCENTROOPERATIVO + "=" + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
						+ "&" + KEYQCENTROOPERATIVONOMBRE + "=" + oPagina.Request.Params[KEYQCENTROOPERATIVONOMBRE]
						+ "&" + KEYQMODO + "=" + oPagina.Request.Params[KEYQMODO]
						+ "&" + KEYQPPTO + "=" + oPagina.Request.Params[KEYQPPTO]
						+ "&" + KEYQVISTA + "=" + oPagina.Request.Params[KEYQVISTA];
					window.location.href = urlPaginaResumenPPTO;
				}
				else
				{
					HistorialIrAtras();
				}
			}
			var strHistorial="";
			function PermanecerHistorial(){
				//strHistorial=window.clipboardData.getData('Text');
				strHistorial=localStorage.getItem('History');
			}
			function SubirHst(){
				//window.clipboardData.setData('Text',strHistorial);
				localStorage.setItem('History',strHistorial);
			}
			


			function UnLoadExt(wMindefault){
				ObtenerListadodeCentrosdeCosto();
				wMindefault.close();
			}
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="PermanecerHistorial();ObtenerHistorial();SubirHst();CambiarImgBotonAtras();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td id="tdHeader" width="100%" runat="server"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td id="tdMenu" bgColor="#eff7fa" vAlign="top" width="100%" runat="server"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos por Grupos de Centros de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR>
								<TD width="100%" align="left">
									<TABLE style="HEIGHT: 33px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR bgColor="#f0f0f0">
											<TD style="HEIGHT: 15px" id="tdCentro" colSpan="2" runat="server"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="128px">CENTRO OPERATIVO :</asp:label></TD>
											<TD style="WIDTH: 121px; HEIGHT: 15px" id="tdCentro1" colSpan="2" runat="server"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoNegroNegrita" Width="120px"> ....:</asp:label></TD>
											<TD style="WIDTH: 144px; HEIGHT: 15px"><asp:label id="Label2" runat="server" CssClass="TextoNegroNegrita" Width="161px">GRUPO CENTRO DE COSTO :</asp:label></TD>
											<TD style="HEIGHT: 15px" width="100%"><asp:label id="lblNombreGrupoCC" runat="server" CssClass="TextoNegroNegrita">CENTRO OPERATIVO :</asp:label></TD>
											<TD style="HEIGHT: 15px">
												<TABLE style="Z-INDEX: 0" id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%"
													align="right">
													<TR>
														<TD noWrap><asp:checkbox id="chk1" runat="server" CssClass="normaldetalle" Checked="True" Text="Nat. 1"></asp:checkbox></TD>
														<TD noWrap><asp:checkbox id="chk2" runat="server" CssClass="normaldetalle" Checked="True" Text="Nat. 3" style="Z-INDEX: 0"></asp:checkbox></TD>
														<TD noWrap>
															<asp:checkbox style="Z-INDEX: 0" id="chk3" runat="server" CssClass="normaldetalle" Text="Nat. 5"
																Checked="True"></asp:checkbox></TD>
														<TD><asp:imagebutton style="Z-INDEX: 0" id="ImgImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR id="trPeriodo" bgColor="#f0f0f0" runat="server">
											<TD style="WIDTH: 34px"><asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="80%">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 70px"><asp:label id="lblPeriodo" runat="server" CssClass="TextoNegroNegrita" Width="80%">Periodo :</asp:label></TD>
											<TD style="WIDTH: 45px"><asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita">MES :</asp:label></TD>
											<TD style="WIDTH: 76px"><asp:label id="lblMes" runat="server" CssClass="TextoNegroNegrita" Width="80px">Mes :</asp:label></TD>
											<TD style="WIDTH: 144px"></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="imgXLS" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"></asp:imagebutton></TD>
											<TD><INPUT style="WIDTH: 16px; HEIGHT: 22px" id="hTabSeleccionado" size="1" type="hidden" value="0"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hIdCentroCostoSelect" size="1"
													type="hidden" name="Hidden1" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedorTab" width="100%" align="left"></TD>
							</TR>
							<TR>
								<TD width="100%" align="left">
									<TABLE style="BORDER-BOTTOM: silver 1px solid; BORDER-LEFT: silver 1px solid; HEIGHT: 19px; BORDER-TOP: silver 1px solid; BORDER-RIGHT: silver 1px solid"
										id="tblResumen" class="ItemGrilla" border="0" cellSpacing="1" cellPadding="1" width="100%"
										align="left" runat="server">
										<TR>
											<TD width="47%">RESUMEN</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" align="right">100</TD>
										</TR>
									</TABLE>
									<TABLE style="BORDER-BOTTOM: silver 1px solid; BORDER-LEFT: silver 1px solid; DISPLAY: none; HEIGHT: 19px; BORDER-TOP: silver 1px solid; BORDER-RIGHT: silver 1px solid"
										id="tblResumenMensual" class="ItemGrilla" border="0" cellSpacing="1" cellPadding="1"
										width="100%" align="left" runat="server">
										<TR>
											<TD width="62%">RESUMEN</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" width="13%" noWrap align="right">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" noWrap align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" noWrap align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" noWrap align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" noWrap align="right" width="13%">100</TD>
											<TD style="BORDER-LEFT: silver 1px solid" noWrap align="right" width="13%">100</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="PaginaAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
			ObtenerListadodeCentrosdeCosto();
		</SCRIPT>
	</body>
</HTML>
