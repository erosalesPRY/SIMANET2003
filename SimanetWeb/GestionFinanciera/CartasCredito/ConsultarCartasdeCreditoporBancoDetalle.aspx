<%@ Page language="c#" Codebehind="ConsultarCartasdeCreditoporBancoDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.ConsultarCartasdeCreditoporBancoDetalle" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Cartas de Crédito por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="772" border="0">
							<TR>
								<TD style="WIDTH: 792px" align="center" width="792" colSpan="3">
									<P align="left">&nbsp;<asp:label id="LblEntidad" runat="server" CssClass="TextoNegroNegrita" Font-Bold="True">Label</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 792px" align="center" width="792" colSpan="3">
									<TABLE style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 80px"><asp:imagebutton id="ibtnFiltar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 100px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg"></TD>
											<TD style="WIDTH: 143px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 409px"><IMG style="WIDTH: 384px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="384"></TD>
											<TD style="WIDTH: 186px" align="right"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" DESIGNTIMEDRAGDROP="398" PageSize="7" ShowFooter="True"
										Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="footerGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreCentro" SortExpression="NombreCentro" HeaderText="CO">
												<HeaderStyle Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="BANCO">
												<HeaderStyle VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroCDI" SortExpression="NroCDI" HeaderText="DOCUMENTO">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroOrdenCompra" SortExpression="NroOrdenCompra" HeaderText="OC">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NProveedor" SortExpression="NProveedor" HeaderText="PROVEEDOR">
												<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FECHA">
												<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table3" style="WIDTH: 144px; HEIGHT: 48px" cellSpacing="0" cellPadding="0" width="144"
														align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="100%" colSpan="2">
																<asp:Label id="lblFecha" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="168" BorderStyle="None">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="lblFInicio" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="182"
																	BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="lblFVence" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">VENCE</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="144" align="left"
														border="0">
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle" Width="65px" Height="15px">00-00-2000</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="64px" DESIGNTIMEDRAGDROP="209"
																	Height="13px">00-00-2000</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="DIAS">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TipodeCambioDelDia" SortExpression="TipodeCambioDelDia" HeaderText="TC">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="IMPORTE">
												<HeaderStyle Width="5%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table3" style="HEIGHT: 48px" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="100%" colSpan="2">
																<asp:Label id="lblImporte" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="168"
																	BorderStyle="None">IMPORTE</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="lblIOrigen" runat="server" CssClass="HEADERGRILLA" DESIGNTIMEDRAGDROP="182"
																	BorderStyle="None">ORIGEN</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="lblIDolarizado" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">DOLARIZADO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblImporteOrigen" runat="server" CssClass="normaldetalle" Width="65px" Height="15px">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblImporteDolarizado" runat="server" CssClass="normaldetalle" Width="64px" DESIGNTIMEDRAGDROP="209"
																	Height="13px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblFImporteOrigen" runat="server" CssClass="normaldetalle" Width="65px" Height="15px"
																	Visible="False">TOTAL</asp:Label></TD>
															<TD align="right" width="50%">
																<asp:Label id="lblFImporteDolarizado" runat="server" CssClass="normaldetalle" Width="64px"
																	DESIGNTIMEDRAGDROP="209" Height="13px">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" vAlign="top" align="center" width="100%">
						<TABLE id="Table9" cellSpacing="1" cellPadding="1" width="779" border="0">
							<TR>
								<TD align="left">
									<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD vAlign="middle" align="left">
												<asp:Label id="Label6" runat="server" CssClass="TituloPrincipal">DESCRIPCIÓN</asp:Label></TD>
											<TD vAlign="top" align="left">
												<asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita">RESUMEN POR MONEDA:</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 575px" vAlign="top" align="left">
												<asp:TextBox id="txtDescripcion" runat="server" Width="100%" BorderStyle="Groove" TextMode="MultiLine"
													CssClass="normaldetalle"></asp:TextBox></TD>
											<TD vAlign="top" align="left">
												<cc1:datagridweb id="gridResumenMoneda" runat="server" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
													Width="100%" PageSize="7">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="footerGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Cantidad" SortExpression="Cantidad" HeaderText="CANT">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoCCredito" SortExpression="MontoCCredito" HeaderText="MONTO">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" style="WIDTH: 768px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="768"
							border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hCampoFiltro" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; WIDTH: 18px; BORDER-BOTTOM: #000000 1px solid; HEIGHT: 22px"
										type="hidden" size="1" name="hCampoFiltro" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
