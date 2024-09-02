<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarInventarioImagen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarInventarioImagen" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Filtros.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> CONSULTAR ARTICULOS</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTAR INVENTARIO</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table4" style="WIDTH: 782px; HEIGHT: 160px" cellSpacing="0" cellPadding="0"
										width="782" border="0">
										<TR>
											<TD>
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f0f0f0"
													border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="2">
															<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD align="right" bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" Width="780px" BorderStyle="Dotted"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="3%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDINVENTARIOIMAGEN" HeaderText="IDINVENTARIOIMAGEN"></asp:BoundColumn>
														<asp:BoundColumn DataField="DETALLE" SortExpression="DETALLE" HeaderText="GRUPO">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBGRUPO" SortExpression="SUBGRUPO" HeaderText="SUBGRUPO"></asp:BoundColumn>
														<asp:BoundColumn DataField="NOMBRE" SortExpression="NOMBRE" HeaderText="TEMA">
															<HeaderStyle Width="27%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="CONTENIDO">
															<HeaderStyle Width="32%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NOMBREIDIOMA" SortExpression="NOMBREIDIOMA" HeaderText="IDIOMA"></asp:BoundColumn>
														<asp:BoundColumn DataField="Minimo" SortExpression="Minimo" HeaderText="Stock Minimo"></asp:BoundColumn>
														<asp:BoundColumn DataField="UNIDADES" SortExpression="UNIDADES" HeaderText="STOCK ACTUAL"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD align="center">
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center"><INPUT id="hOrdenGrilla" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
