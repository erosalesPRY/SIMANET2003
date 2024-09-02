<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarVentasRealesPorPeriodosVsVentasPresupuestadasActual" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Ventas Ejecutadas por Peridos vs Ventas Presupuestadas Actual</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE VENTAS EJECUTADAS POR PERIODOS VS VENTA PRESUPUESTADA ACTUAL</asp:label></TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center">&nbsp;</TD>
											<TD align="center">&nbsp;</TD>
											<TD align="center">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="670"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" Width="780px" DESIGNTIMEDRAGDROP="68"
													RowPositionEnabled="False" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="centrooperativo" HeaderText="CO" FooterText="TOTALES">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Center"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Periodo4" FooterText="TotalPeriodo4">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblMontoPeriodo4" runat="server" CssClass="normal" ForeColor="Navy">MontoPeriodo4</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Periodo3" FooterText="TotalPeriodo3">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblMontoPeriodo3" runat="server" CssClass="normal" ForeColor="Navy">MontoPeriodo3</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Periodo2" FooterText="TotalPeriodo2">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblMontoPeriodo2" runat="server" CssClass="normal" ForeColor="Navy">MontoPeriodo2</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="Periodo1" FooterText="TotalPeriodo1">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblMontoPeriodo1" runat="server" CssClass="normal" ForeColor="Navy">MontoPeriodo1</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="PeriodoActual" FooterText="TotalPeriodoActual">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<ItemTemplate>
																<asp:Label id="lblMontoPeriodoActual" runat="server" CssClass="normal" ForeColor="Navy">MontoPeriodoActual</asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="total" HeaderText="TOTAL" FooterText="TotalCorporativo">
															<HeaderStyle Width="120px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
