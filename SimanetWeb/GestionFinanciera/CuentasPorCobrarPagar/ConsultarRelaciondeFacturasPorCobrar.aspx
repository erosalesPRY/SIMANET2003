<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarRelaciondeFacturasPorCobrar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarRelaciondeFacturasPorCobrar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarRelaciondeFacturasPorCobrar</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
			function AsignaEventoKeyDown(EventTarget)
			{
				if (window.event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn.toString())
				{
					oWindow = new SIMA.Utilitario.Helper.Window();
					oWindow.EventHandle(EventTarget);
				}
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 23px"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 19px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Documentos por Cobrar</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="782" align="center" border="0">
								<TR>
									<TD style="HEIGHT: 16px"></TD>
									<TD>
										<TABLE id="Table5" style="HEIGHT: 37px" cellSpacing="1" cellPadding="1" width="100%" align="left"
											bgColor="#f5f5f5" border="0">
											<TR>
												<TD width="80%" colSpan="4">
													<asp:Label id="lblFecha" runat="server" CssClass="TextoNegroNegrita">PERIODO :</asp:Label></TD>
												<TD align="left"></TD>
											</TR>
											<TR>
												<TD width="2%">
													<asp:Label id="Label4" runat="server" CssClass="TextoNegroNegrita">CONCEPTO :</asp:Label></TD>
												<TD width="80%" colSpan="4">
													<asp:Label id="lblConcepto" runat="server" CssClass="TextoNegroNegrita">Label</asp:Label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 16px"></TD>
									<TD>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD style="WIDTH: 54px">
													<asp:label id="Label2" runat="server" CssClass="normaldetalle" Width="51px" Font-Bold="True"> Buscar :</asp:label></TD>
												<TD style="WIDTH: 98px">
													<asp:TextBox id="txtBuscar" runat="server" Width="290px" CssClass="InputFind"></asp:TextBox></TD>
												<TD style="WIDTH: 3px">
													<P align="left">&nbsp;</P>
												</TD>
												<TD style="WIDTH: 63px" align="right">
													<P align="left"><IMG height="8" src="../imagenes/spacer.gif" width="250"></P>
												</TD>
												<TD>
													<asp:Button id="ibtnAceptar" runat="server" Text="Aceptar"></asp:Button></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD align="center">
										<cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="15" AllowPaging="True" AllowSorting="True"
											AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrillaEF"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO">
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="RAZON SOCIAL">
													<HeaderStyle Width="17%" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="LINEA DE NEGOCIO">
													<HeaderStyle Width="22%"></HeaderStyle>
													<ItemStyle VerticalAlign="Bottom"></ItemStyle>
													<HeaderTemplate>
														<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
															<TR class="headerGrilla">
																<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																	align="center" colSpan="5">
																	<asp:Label id="Label6" runat="server">LÍNEA DE NEGOCIO</asp:Label></TD>
															</TR>
															<TR class="headerGrilla">
																<TD align="center" width="20%">
																	<asp:Label id="lblCN" runat="server" ToolTip="Construcciones Navales (12101)">CN</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																	<asp:Label id="lblRN" runat="server" ToolTip="Reparaciones Navales  (12105,12110)">RN</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																	<asp:Label id="lblMM" runat="server" ToolTip="Metal Mecanica (12115,12116)">MM</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																	<asp:Label id="lblAE" runat="server" ToolTip="Armas Electrónicas (12130)">AE</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="20%">
																	<asp:Label id="lblRI" runat="server" ToolTip="Reparación Inductrial (12120)">RI</asp:Label></TD>
															</TR>
														</TABLE>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD class="ItemGrillaSinColor" vAlign="middle" noWrap align="right" width="20%">
																	<asp:Label id="lblMontoCNa" runat="server">0.00</asp:Label></TD>
																<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle"
																	noWrap align="right" width="20%">
																	<asp:Label id="lblMontoRNa" runat="server">0.00</asp:Label></TD>
																<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle"
																	noWrap align="right" width="20%">
																	<asp:Label id="lblMontoMMa" runat="server">0.00</asp:Label></TD>
																<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle"
																	noWrap align="right" width="20%">
																	<asp:Label id="lblMontoAEa" runat="server">0.00</asp:Label></TD>
																<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle"
																	noWrap align="right" width="20%">
																	<asp:Label id="lblMontoRIa" runat="server">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</ItemTemplate>
													<FooterTemplate>
														<TABLE id="Table12" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD class="FooterGrillaEF" noWrap align="right" width="20%">
																	<asp:Label id="lblMontoCNaF" runat="server">0.00</asp:Label></TD>
																<TD class="FooterGrillaEF" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
																	width="20%">
																	<asp:Label id="lblMontoRNaF" runat="server">0.00</asp:Label></TD>
																<TD class="FooterGrillaEF" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
																	width="20%">
																	<asp:Label id="lblMontoMMaF" runat="server">0.00</asp:Label></TD>
																<TD class="FooterGrillaEF" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
																	width="20%">
																	<asp:Label id="lblMontoAEaF" runat="server">0.00</asp:Label></TD>
																<TD class="FooterGrillaEF" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
																	width="20%">
																	<asp:Label id="lblMontoRIaF" runat="server">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</FooterTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn HeaderText="OTROS">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle VerticalAlign="Bottom"></ItemStyle>
													<HeaderTemplate>
														<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR class="HeaderGrilla">
																<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																	colSpan="2">
																	<asp:Label id="Label12" runat="server">OTROS</asp:Label></TD>
															</TR>
															<TR class="HeaderGrilla">
																<TD>
																	<asp:Label id="lblMerc" runat="server" ToolTip="Mercadería (12135)">MERC.</asp:Label></TD>
																<TD style="BORDER-LEFT: #cccccc 1px solid">
																	<asp:Label id="lblServ" runat="server" ToolTip="Servicio  (12140)">SERV.</asp:Label></TD>
															</TR>
														</TABLE>
													</HeaderTemplate>
													<ItemTemplate>
														<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD class="ItemGrillaSinColor" vAlign="middle" noWrap align="right" width="50%">
																	<asp:Label id="lblMontoMEa" runat="server">0.00</asp:Label></TD>
																<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle"
																	noWrap align="right" width="50%">
																	<asp:Label id="lblMontoMSa" runat="server">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</ItemTemplate>
													<FooterTemplate>
														<TABLE id="Table10" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
															border="0">
															<TR>
																<TD class="FooterGrillaEF" noWrap align="right" width="50%">
																	<asp:Label id="lblMontoMEaF" runat="server">0.00</asp:Label></TD>
																<TD class="FooterGrillaEF" style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right"
																	width="50%">
																	<asp:Label id="lblMontoMSaF" runat="server">0.00</asp:Label></TD>
															</TR>
														</TABLE>
													</FooterTemplate>
												</asp:TemplateColumn>
												<asp:BoundColumn DataField="MontoTotal" SortExpression="MontoTotal" HeaderText="TOTAL">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<TABLE id="Table4" style="DISPLAY: none; WIDTH: 184px; HEIGHT: 34px" cellSpacing="1" cellPadding="1"
											width="184" align="center" border="1">
											<TR class="ItemGrilla">
												<TD class="HeaderGrilla"><asp:label id="Label5" runat="server">TIPO DE CAMBIO :</asp:label></TD>
												<TD align="left"><asp:textbox id="txtTCVenta" runat="server" CssClass="Textoazul" Width="70px"></asp:textbox></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD></TD>
									<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><INPUT id="hGridPagina" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" value="0"
								name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
								runat="server"></P>
					</TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
