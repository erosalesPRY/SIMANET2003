<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarGastosDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarGastosDirectorio" %>
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
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<td colspan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD vAlign="top" width="100%">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Gastos de Directorio</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE GASTOS DE DIRECTORIO</asp:label>
								</TD>
							</TR>
							<TR>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" border="0">
										<TR>
										</TR>
										<TR>
											<TD align="center" vAlign="top">
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD>
															<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
																<TR>
																	<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:ImageButton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:ImageButton></TD>
																	<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																			src="../../imagenes/filtroPorSeleccion.JPG"></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																			ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
																	<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="450"></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
																	<TD align="center" width="4" colSpan="1"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
																</TR>
															</TABLE>
															<cc1:DataGridWeb id="grid" runat="server" PageSize="7" Width="780px" AllowPaging="True" AllowSorting="True"
																AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" CssClass="HeaderGrilla"
																ShowFooter="True">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
																	<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO"></asp:BoundColumn>
																	<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DETALLE GASTO">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Lugar" SortExpression="Lugar" HeaderText="LUGAR">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="CENTRO COSTO">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO" DataFormatString="{0:###,##0.00}">
																		<ItemStyle HorizontalAlign="Right"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="UM"></asp:BoundColumn>
																	<asp:BoundColumn DataField="FechaGasto" SortExpression="FechaGasto" HeaderText="FECHA DE GASTO" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc1:DataGridWeb></TD>
													</TR>
												</TABLE>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">&nbsp;
											</TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center">
												<cc1:datagridweb id="dgResumen" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" Width="200px" PageSize="3">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA"></asp:BoundColumn>
														<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO TOTAL" DataFormatString="{0:###,##0.00}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
													style="CURSOR: hand"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
