<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleVentasPresupuestadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarDetalleVentasPresupuestadas" %>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"></asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:label id="lblCentroOperativo" runat="server" CssClass="Titulosecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:label id="lblAno" runat="server" CssClass="Titulosecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<TABLE class="normal" id="Table8" cellSpacing="0" cellPadding="0" width="550" align="center"
										border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD colSpan="4">
															<P align="right">&nbsp;</P>
														</TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../../imagenes/filtroPorSeleccion.JPG">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0" colSpan="4">
															<P align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></P>
														</TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="750px" ShowFooter="True"
													RowPositionEnabled="False" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
													RowHighlightColor="#E0E0E0" PageSize="7">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Left" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
															<HeaderStyle HorizontalAlign="Center" Width="1px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IdVenta" HeaderText="IDVENTA"></asp:BoundColumn>
														<asp:BoundColumn DataField="SECTOR" SortExpression="SECTOR" HeaderText="SECTOR">
															<HeaderStyle Width="6%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="LN" SortExpression="LN" HeaderText="LN">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RAZONSOCIAL" SortExpression="RAZONSOCIAL" HeaderText="CLIENTE">
															<HeaderStyle Width="35%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PROYECTO" SortExpression="PROYECTO" HeaderText="PROYECTO" FooterText="TOTAL MONTO">
															<HeaderStyle Width="35%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MONTO" SortExpression="MONTO" HeaderText="MONTO" FooterText="MONTO">
															<HeaderStyle Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FECHA" SortExpression="FECHA" HeaderText="FECHA">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<P align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
														name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
														runat="server"></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
