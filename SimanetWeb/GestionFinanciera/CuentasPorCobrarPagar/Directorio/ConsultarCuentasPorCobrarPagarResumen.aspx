<%@ Page language="c#" Codebehind="ConsultarCuentasPorCobrarPagarResumen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ConsultarCuentasPorCobrarPagarResumen" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
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
				var KEYIDTIPOCUENTANAME = "IDTIPOCUENTA";
				var KEYFLAGDIRECTORIO = "FlagDirectorio";
				var pidPorCobrar = 0;
				var pidPorPagar = 1;
				
					urlPaginaConsultarEF = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/cuentasPorCobrarPagar/ConsultarCuentaPorCobrarPagarContador.aspx?";
		
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						
						/*Por Cobrar*/
						OtrPrm = KEYIDTIPOCUENTANAME + SignoIgual.toString() + pidPorCobrar
								+ signoAmperson.toString()+ KEYFLAGDIRECTORIO + SignoIgual.toString() + 
								oPagina.Request.Params[KEYFLAGDIRECTORIO];
								
						oTab = new SIMA.Utilitario.Helper.General.Tab("Por Cobrar ",urlPaginaConsultarEF + OtrPrm ,"Por Cobrar " );
						oTabStrip.Tabs.Adicionar(oTab);
						/*Por Pagar*/
						OtrPrm = KEYIDTIPOCUENTANAME + SignoIgual.toString() + pidPorPagar
								+ signoAmperson.toString()+ KEYFLAGDIRECTORIO + SignoIgual.toString() + 
								oPagina.Request.Params[KEYFLAGDIRECTORIO];
								
						oTab = new SIMA.Utilitario.Helper.General.Tab("Por Pagar ",urlPaginaConsultarEF + OtrPrm ,"Por Pagar " );
						oTabStrip.Tabs.Adicionar(oTab);
					}
				oTabStrip.RepintarTabs();
				oTabStrip.Tabs.Tab(0).Click();
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR id="id1">
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="id2">
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center" vAlign="top" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR id="id3">
								<TD class="Commands" style="HEIGHT: 20px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Cuentas Por Cobrar y Pagar</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR id="id4">
														<TD bgColor="#f0f0f0">&nbsp;
															<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita">Período:</asp:label>
															<asp:label id="lblPeriodo" runat="server" CssClass="SubtituloNegrita"></asp:label>
															<asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita">Mes:</asp:label>
															<asp:label id="lblMes" runat="server" CssClass="SubtituloNegrita"></asp:label></TD>
														<TD bgColor="#f0f0f0" align="right"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4, id5);"
																alt="" src="../../../imagenes/bt_imprimir.gif"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" ShowFooter="True" PageSize="7" Width="100%" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowSorting="True">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO" FooterText="DIFERENCIA:">
															<HeaderStyle Width="22%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SimaCallao" HeaderText="CALLAO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SimaChimbote" HeaderText="CHIMBOTE" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SimaPeru" HeaderText="PERU" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SimaIquitos" HeaderText="IQUITOS" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Total" HeaderText="TOTAL" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
									<p></p>
								</TD>
							</TR>
							<TR>
								<td id="divContenedor" width="100%" align="left"></td>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR id="id5">
								<TD vAlign="top"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"
										style="CURSOR: hand"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
