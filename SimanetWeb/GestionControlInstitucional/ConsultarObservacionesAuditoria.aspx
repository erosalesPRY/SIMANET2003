<%@ Page language="c#" Codebehind="ConsultarObservacionesAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.ConsultarObservacionesAuditoria" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
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
								<TD class="Commands" style="HEIGHT: 23px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Observaciones de Auditoría</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" align="center"
										border="0">
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="3">
															<TABLE id="Table5" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" border="1">
																<TR>
																	<TD bgColor="#000080" colSpan="9">
																		<asp:dropdownlist id="ddlbTipoJuicio" runat="server" CssClass="normal" Width="2px" Height="36px" Visible="False"
																			Enabled="False"></asp:dropdownlist></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label1" runat="server" CssClass="TextoBlanco"> Organismo:</asp:label></TD>
																	<TD bgColor="#dddddd">
																		<asp:textbox id="txtOrganismo" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
																			BorderWidth="0px" BackColor="Transparent" Width="100%"></asp:textbox></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label3" runat="server" CssClass="TextoBlanco">Sub Organismo:</asp:label></TD>
																	<TD bgColor="#dddddd" colSpan="6" rowSpan="1">
																		<asp:textbox id="txtSubOrganismo" runat="server" CssClass="normaldetalle" Width="224px" BackColor="Transparent"
																			BorderWidth="0px" ReadOnly="True"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label8" runat="server" CssClass="TextoBlanco"> Acción Control:</asp:label></TD>
																	<TD bgColor="#f0f0f0" colSpan="8">
																		<asp:textbox id="txtAccionControl" runat="server" CssClass="normaldetalle" Width="296px" BackColor="Transparent"
																			BorderWidth="0px" ReadOnly="True"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Fecha Documento:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:textbox id="txtFechaDocumento" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
																			BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Año:</asp:label></TD>
																	<TD bgColor="#f0f0f0" colSpan="6">
																		<asp:textbox id="txtPeriodo" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
																			BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label6" runat="server" CssClass="TextoBlanco">Fecha Inicio:</asp:label></TD>
																	<TD bgColor="#dddddd">
																		<asp:textbox id="txtFechaInicio" runat="server" CssClass="normaldetalle" ReadOnly="True" BorderWidth="0px"
																			BackColor="Transparent"></asp:textbox></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label7" runat="server" CssClass="TextoBlanco">Fecha Término:</asp:label></TD>
																	<TD bgColor="#dddddd" colSpan="6">
																		<asp:textbox id="txtFechaTermino" runat="server" CssClass="normaldetalle" ReadOnly="True" BorderWidth="0px"
																			BackColor="Transparent" Width="250px"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label2" runat="server" CssClass="TextoBlanco">C.O.</asp:label></TD>
																	<TD bgColor="#f0f0f0" colSpan="8">
																		<asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" ReadOnly="True"
																			BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label9" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
																	<TD bgColor="#dddddd" colSpan="8">
																		<asp:textbox id="txtSituacion" runat="server" CssClass="normaldetalle" ReadOnly="True" MaxLength="200"
																			BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4">
																		<asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco"> Observaciones:</asp:label></TD>
																	<TD bgColor="#f0f0f0" colSpan="8">
																		<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" Height="50px"
																			TextMode="MultiLine" ReadOnly="True" BorderWidth="0px" BackColor="Transparent"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="btnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton><IMG height="8" src="../imagenes/spacer.gif" width="454" style="WIDTH: 454px; HEIGHT: 8px">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
													AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Width="780px" PageSize="7"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACION">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="C.O.">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERM."
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
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD>
												<P align="center">
													<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
											</TD>
										</TR>
										<TR>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
													name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
													runat="server"> <INPUT id="hIdTipoSeguimiento" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
													name="hIdTipoSeguimiento" runat="server">
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
