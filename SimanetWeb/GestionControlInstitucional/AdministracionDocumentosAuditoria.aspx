<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="AdministracionDocumentosAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministracionDocumentosAuditoria" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<tr>
					<td vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 23px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Documentos de Auditoría</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" align="center"
										border="0">
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="6" style="HEIGHT: 8px">
															<P align="center">
																<asp:label id="Label1" runat="server" CssClass="TextoAzulNegrita">Obs. sin seguimiento:</asp:label>
																<asp:dropdownlist id="ddblObsSinSeguimiento" runat="server" CssClass="normaldetalle" Width="248px"
																	Height="70px" AutoPostBack="True"></asp:dropdownlist></P>
														</TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 8px" bgColor="#f0f0f0" colSpan="6"></TD>
													</TR>
													<TR>
														<TD bgColor="#f0f0f0" colSpan="6">
															<P align="right">
																<asp:imagebutton id="btnOrganismos" runat="server" ImageUrl="../imagenes/btnOrganismos.jpg"></asp:imagebutton>
																<asp:imagebutton id="btnSubAcciones" runat="server" ImageUrl="../imagenes/btnSubOrganismo.jpg"></asp:imagebutton>
																<asp:imagebutton id="btnAcciones" runat="server" ImageUrl="../imagenes/ibtnAccion.jpg"></asp:imagebutton>
																<asp:imagebutton id="btnAsociar" runat="server" ImageUrl="../imagenes/btnAsociar.jpg"></asp:imagebutton></P>
														</TD>
													</TR>
													<TR>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="btnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton><IMG height="8" src="../imagenes/spacer.gif" width="207" style="WIDTH: 207px; HEIGHT: 8px"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAcciones" runat="server" ImageUrl="../imagenes/btnObservaciones.jpg"></asp:imagebutton>
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" PageSize="4"
													Width="780px" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
													RowPositionEnabled="False">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Organismo" SortExpression="Organismo" HeaderText="ORGANISMO">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBORGANISMO" SortExpression="SUBORGANISMO" HeaderText="SUB ORGANISMO">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Actividad" SortExpression="Actividad" HeaderText="ACCION CONTROL">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Periodo" SortExpression="Periodo" HeaderText="A&#209;O">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="DESCRIPCION">
															<HeaderStyle Width="25%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="C.O.">
															<HeaderStyle Width="3%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FECHA INIC."
															DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="12%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERM."
															DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="12%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="0%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD class="TitFiltros" bgColor="#f5f5f5"><asp:label id="lblSituacion" runat="server" CssClass="normal" Width="56px">Situación Actual:</asp:label></TD>
											<TD class="combos" bgColor="#f5f5f5"><asp:textbox id="txtSituacion" runat="server" CssClass="normal" Width="725px" Height="41px" TextMode="MultiLine"
													ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD>
												<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
											</TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
													name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
													runat="server">
											</TD>
										</TR>
									</TABLE>
									<INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hDescripcion" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hDescripcion"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
