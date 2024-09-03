<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Page language="c#" Codebehind="ConsultarDetalledeRubroCuenta5Digitos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarDetalledeRubroCuenta5Digitos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
		<script>
			function  MostrarDescripciondeRubro()
			{
				//"/GestionFinanciera/EstadosFinancieros/GlosaEstadosFinancieros.aspx?"
				var URLDETALLECONCEPTO = "/GestionFinanciera/EstadosFinancieros/Directorio/ConsultarFormatoRubroMovimientoVCV2.aspx?";
				var KEYQNOMBRERUBRO = "NRubro";
				var KEYQIDFORMATO = "IdFormato";
				var KEYQIDRUBRO = "IdRubro";
				var KEYQIDFECHA = "efFecha";
				var KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
				var KEYQIDIDTIPOINFORMACION ="idTipoInfo";
				var KEYQIDINTERFAZ = "interfaz";
				
				
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				
				var e = window.event.srcElement
				var tblNodo =e.parentElement.parentElement.parentElement;//tblNodo
				var FilaPrincipal = tblNodo.parentElement.parentElement;

				var strData = FilaPrincipal.getAttribute("OBSERVACIONES");
				var NombreRubro = FilaPrincipal.getAttribute("NOMBRERUBRO");
				var idRubro = FilaPrincipal.getAttribute("IDRUBRO");
				var Parametros="";
				
				with(SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = KEYQIDFORMATO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDFORMATO]
								+ signoAmperson.toString() 
								+ KEYQIDRUBRO + SignoIgual.toString() + idRubro
								+ signoAmperson.toString() 
								+ KEYQNOMBRERUBRO + SignoIgual.toString() +  NombreRubro
								+ signoAmperson.toString() 
								+ KEYQIDFECHA + SignoIgual.toString() +  oPagina.Request.Params[KEYQIDFECHA]
								+ signoAmperson.toString() 
								+ KEYQIDCENTROOPERATIVO + SignoIgual.toString() +  oPagina.Request.Params["IdCentro"]
								+ signoAmperson.toString() 
								+ KEYQIDIDTIPOINFORMACION + SignoIgual.toString() +  '0'
								+ signoAmperson.toString() 
								+ KEYQIDINTERFAZ + SignoIgual.toString() +  '0';
				}
				
				var Datos=new Array();
				//Datos=window.showModalDialog(ObtenerPathAppWeb()+ "/Editor/Editor.aspx",strData,"dialogWidth:630px;dialogHeight:400px"); 
				Datos=window.showModalDialog(ObtenerPathAppWeb()+ URLDETALLECONCEPTO + Parametros ,strData,"dialogWidth:630px;dialogHeight:400px"); 
				
			}
			
			function RetornarPantallaAnterior()
			{
				var NODOSELECCIONADO="NodoSeleccionado";
				ReemplazarParametrodeHistorial(NODOSELECCIONADO, (new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[NODOSELECCIONADO]);
			}
			
			function MostrarValor()
			{	
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				var KEYQDESCRIPCIONOBSERVACION="DescripcionObservacion";
				var mdiPadre = oPagina.Request.Params[KEYQDESCRIPCIONOBSERVACION];
				
				var strValor ="";
				//if (parseInt(idCentro) ==2)
				
					strValor= Reemplazar(mdiPadre,'¿','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				
				
				document.all["campo1"].value=strValor;
			}		
			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="right" colSpan="3">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" border="0" width="100%">
							<TR bgColor="#f0f0f0">
								<TD align="left">
									<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 52px" colSpan="3">
												<asp:label id="Label4" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CONCEPTO :</asp:label></TD>
											<TD style="WIDTH: 88px" colSpan="2">
												<asp:label id="lblConcepto" runat="server" Font-Bold="True" Width="376px" ForeColor="Navy"
													CssClass="TituloPrincipalBlanco">CONCEPTO :</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px">
												<asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
													Font-Bold="True">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 36px">
												<asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
													Width="32px" Font-Bold="True"> 2005</asp:label></TD>
											<TD style="WIDTH: 24px">
												<asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True">MES :</asp:label></TD>
											<TD style="WIDTH: 88px">
												<asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
													Font-Bold="True">Periodo :</asp:label></TD>
											<TD align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" HeaderText="NRO">
												<HeaderStyle Width="3%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CONCEPTO">
												<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="DEL MES">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblDelMes" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FEBRERO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="28.33%">
																<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
																<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblDelMesVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesRealF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblDelMesPPTOF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblDelMesVarF" runat="server" CssClass="FooterGrilla" BorderStyle="None" Visible="False">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ACUMULADO">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblAcumulado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">ACUMULADO</asp:Label></TD>
														</TR>
														<TR>
															<TD noWrap align="center" width="28.33%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="28.33%">
																<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="center" width="20.33%">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblAcumVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumRealF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="28.33%">
																<asp:Label id="lblAcumPPTOF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" noWrap align="right" width="20.33%">
																<asp:Label id="lblAcumVarF" runat="server" CssClass="FooterGrilla" BorderStyle="None" Visible="False">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label11" runat="server" Font-Size="XX-Small" Height="1px">OBSERVACIONES:</asp:label></TD>
							</TR>
							<TR>
								<TD><TEXTAREA id="campo1" style="FONT-SIZE: 10px; WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 64px"
										name="campo1" rows="4" readOnly cols="101" runat="server"></TEXTAREA></TD>
							</TR>
						</TABLE>
						<IMG id="Img1" onclick="RetornarPantallaAnterior();HistorialIrAtras();" alt="" src="../../../imagenes/RetornarAlFormato.GIF">
					</TD>
				</TR>
			</table>
			<SCRIPT>
				SIMA.Utilitario.Error.TiempoEsperadePagina();
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
