<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleVentasReales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarDetalleVentasReales" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta Detallada de Ventas Ejecutadas</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DETALLADA DE VENTAS EJECUTADAS</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0">
															<asp:ImageButton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:ImageButton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="460"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" ShowFooter="True" RowPositionEnabled="False" AutoGenerateColumns="False"
													AllowSorting="True" AllowPaging="True" RowHighlightColor="#E0E0E0" Width="780px" CssClass="HeaderGrilla"
													PageSize="7">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDVENTAREAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="SECTOR" SortExpression="SECTOR" HeaderText="SECTOR"></asp:BoundColumn>
														<asp:BoundColumn DataField="LINEANEGOCIO" SortExpression="LINEANEGOCIO" HeaderText="LN"></asp:BoundColumn>
														<asp:BoundColumn DataField="cliente" SortExpression="cliente" HeaderText="CLIENTE">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="proyecto" SortExpression="proyecto" HeaderText="PROYECTO" FooterText="Monto Total:">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MONTOPRECIOVENTASOLES" SortExpression="MONTOPRECIOVENTASOLES" HeaderText="MONTO"
															FooterText="Monto" DataFormatString="{0:###,##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="780" border="0" class="normal">
										<TR>
											<TD align="center" colSpan="2" rowSpan="1">
												<asp:label id="lblObservaciones" runat="server" CssClass="TituloPrincipal"> OBSERVACIONES DEL MES</asp:label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2">
												<cc1:datagridweb id="dgObservaciones" runat="server" CssClass="HeaderGrilla" Width="780px" RowHighlightColor="#E0E0E0"
													AllowPaging="True" AutoGenerateColumns="False" RowPositionEnabled="False" ShowFooter="True" PageSize="3">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="Nro" FooterText="Total:"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDOBSERVACIONES"></asp:BoundColumn>
														<asp:BoundColumn DataField="OBSERVACION" SortExpression="OBSERVACION" HeaderText="OBSERVACIONES">
															<HeaderStyle Width="95%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultadoObservaciones" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="2"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
													style="CURSOR: hand"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top"></TD>
							</TR>
						</TABLE>
					</TD>
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
