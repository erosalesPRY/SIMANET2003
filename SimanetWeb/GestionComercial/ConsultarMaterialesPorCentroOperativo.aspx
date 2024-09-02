<%@ Page language="c#" Codebehind="ConsultarMaterialesPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ConsultarMaterialesPorCentroOperativo" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarMaterialesPorCentroOperativo</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD style="HEIGHT: 1px" align="left">
						<uc1:header style="Z-INDEX: 0" id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 4px">
						<uc1:menu style="Z-INDEX: 0" id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Materiales> </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> MATERIALES POR CENTRO OPERATIVO</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" type="hidden" size="1" name="hCodigo" runat="server"><INPUT id="hGridPagina" type="hidden" size="1" value="0" name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" type="hidden" size="1" name="hGridPagina" runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="780" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD align="right"><asp:label id="lblInicio" runat="server" CssClass="normal" Width="80px" Visible="False">Inicio</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="7"></TD>
											<TD width="150"><asp:textbox id="txtInicio" runat="server" Width="100px" Visible="False"></asp:textbox></TD>
											<TD align="right"><asp:label id="lblFin" runat="server" CssClass="normal" Width="80px" Visible="False">Fin</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="7"></TD>
											<TD width="150"><asp:textbox id="txtFin" runat="server" Width="100px" Visible="False"></asp:textbox></TD>
											<TD><asp:imagebutton id="ibtnConsultar" runat="server" CssClass="boton" ImageAlign="Left" ImageUrl="../../imagenes/ibtnConsultarCliente.gif"
													Visible="False"></asp:imagebutton><asp:imagebutton id="ibtnEliminarFiltroConsulta" runat="server" ImageUrl="../../imagenes/btnEliminarConsulta.jpg"
													ToolTip="Eliminar Filtro.." Visible="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table6" cellSpacing="0" cellPadding="0" width="600" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD style="WIDTH: 87px" bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 100px" bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD align="right" bgColor="#f0f0f0"><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="5"><asp:imagebutton id="ibtnRepresentante" runat="server" ImageUrl="../../imagenes/btnRepresentante.jpg"
																DESIGNTIMEDRAGDROP="67"></asp:imagebutton>
															<asp:imagebutton id="ibtnContacto" runat="server" ImageUrl="../../imagenes/btnContactos.jpg"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" Visible="False"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif" Visible="False"></asp:imagebutton><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" DataKeyField="IDCLIENTE"
													ShowFooter="True" RowPositionEnabled="False" AutoGenerateColumns="False" AllowSorting="True"
													AllowPaging="True" RowHighlightColor="#E0E0E0">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Left" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Emision" SortExpression="Emision" HeaderText="Emisión" FooterText="Total:">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Material" SortExpression="Material" HeaderText="Material">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Medida" SortExpression="Medida" HeaderText="Medida">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="Descripción">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="StockGravado" SortExpression="StockGravado" HeaderText="Stock gravado">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PrecioGravado" SortExpression="PrecioGravado" HeaderText="Precio gravado">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="StockExonerado" SortExpression="StockExonerado" HeaderText="Stock exonerado">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PrecioExonerado" SortExpression="PrecioExonerado" HeaderText="Precio exonerado">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PrecioUltimaCompra" SortExpression="PrecioUltimaCompra" HeaderText="Precio última compra">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaUltimaCompra" SortExpression="FechaUltimaCompra" HeaderText="Fecha última compra">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaUltimaSalida" SortExpression="FechaUltimaSalida" HeaderText="Fecha última salida">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Ubicación" SortExpression="Ubicación" HeaderText="Ubicación">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3">&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
										<TR>
											<TD align="right" colSpan="3"><asp:label id="lblCantClientes" runat="server" Visible="False">Cantidad Clientes</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="10">
												<asp:textbox id="txtCantClientes" runat="server" Width="100px" ReadOnly="True" Visible="False"></asp:textbox></TD>
										</TR>
									</TABLE>
									<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 31px" align="center"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 18px" align="center"></TD>
							</TR>
						</TABLE>
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
