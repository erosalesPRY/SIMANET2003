<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarPresentesOtorgadosPorFamiliar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarPresentesOtorgadosPorFamiliar" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td width="100%"><uc1:menu id="Menu2" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Presentes Otorgados a Familiares</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE PRESENTES OTORGADOS A FAMILIARES</asp:label></TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="HEIGHT: 10px" align="center" colSpan="3">
												<asp:label id="lblNombrePersona" runat="server" CssClass="titulosecundario"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3" vAlign="top">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD>
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
																<TR>
																	<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:ImageButton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:ImageButton></TD>
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
															<cc1:datagridweb id="grid" runat="server" PageSize="7" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
																AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" Width="780px" CssClass="HeaderGrilla"
																ShowFooter="True">
																<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																<Columns>
																	<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
																	<asp:BoundColumn Visible="False" DataField="IdListaProtocolarFamiliares" SortExpression="IdListaProtocolarFamiliares"
																		HeaderText="IdListaProtocolarFamiliares"></asp:BoundColumn>
																	<asp:BoundColumn DataField="ApellidoPaterno" SortExpression="ApellidoPaterno" HeaderText="APELLIDO PATERNO"></asp:BoundColumn>
																	<asp:BoundColumn DataField="ApellidoMaterno" SortExpression="ApellidoMaterno" HeaderText="APELLIDO MATERNO"></asp:BoundColumn>
																	<asp:BoundColumn DataField="Nombres" SortExpression="Nombres" HeaderText="NOMBRES">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="NombreArticulo" SortExpression="NombreArticulo" HeaderText="PRESENTE OTORGADO">
																		<ItemStyle HorizontalAlign="Left"></ItemStyle>
																	</asp:BoundColumn>
																	<asp:BoundColumn DataField="CantidadAtendida" SortExpression="CantidadAtendida" HeaderText="CANTIDAD ENTREGADA"></asp:BoundColumn>
																</Columns>
																<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
															</cc1:datagridweb></TD>
													</TR>
													<TR>
														<TD align="center">
															<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
													</TR>
													<TR>
														<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" height="19" alt=""
																src="../../imagenes/atras.gif" width="84"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
