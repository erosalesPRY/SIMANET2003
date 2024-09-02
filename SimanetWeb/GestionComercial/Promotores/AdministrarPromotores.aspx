<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarPromotores.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.AdministrarPromotores" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
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
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Clientes> </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Promotores</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> ADMINISTRACIÓN DE PROMOTORES</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" type="hidden" size="1" name="hCodigo" runat="server"><INPUT id="hGridPagina" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table5" cellSpacing="0" cellPadding="0" width="600" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0" style="WIDTH: 80px"><asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0" style="WIDTH: 106px">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD style="WIDTH: 22px" bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" style="DISPLAY: none" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../../imagenes/filtroPorSeleccion.JPG" runat="server"></TD>
														<TD align="right" bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="5">
															<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="5"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True"
													ShowFooter="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IdPromotor" HeaderText="IdPromotor"></asp:BoundColumn>
														<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="RAZON SOCIAL">
															<HeaderStyle Width="38%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="REPRESENTANTELEGAL" HeaderText="REPRESENTANTE LEGAL">
															<HeaderStyle Width="40%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IdtipoPromotor" HeaderText="IdtipoPromotor"></asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3">&nbsp;<IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
										<TR>
											<TD align="right" colSpan="3">
												<asp:label id="lblCantClientes" runat="server">Cantidad Promotores</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="10">
												<asp:textbox id="txtCantPromotores" runat="server" Width="100px" ReadOnly="True"></asp:textbox></TD>
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
	</body>
</HTML>
