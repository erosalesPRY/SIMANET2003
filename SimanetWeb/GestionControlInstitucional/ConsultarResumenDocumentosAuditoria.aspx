<%@ Page language="c#" Codebehind="ConsultarResumenDocumentosAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Legal.ConsultarResumenDocumentosAuditoria" %>
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
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Resumen de Observaciones</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD style="HEIGHT: 8px" align="center" bgColor="#f0f0f0">
															<P align="left"><asp:label id="Label2" runat="server" CssClass="TextoAzulNegrita" Width="56px">Organismo:</asp:label><asp:dropdownlist id="ddblOrganismo" runat="server" CssClass="normaldetalle" Width="184px" Height="70px"
																	AutoPostBack="True"></asp:dropdownlist><asp:label id="Label9" runat="server" CssClass="TextoAzulNegrita">Situación:</asp:label><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="176px" Height="70px"
																	AutoPostBack="True"></asp:dropdownlist><asp:label id="Label1" runat="server" CssClass="TextoAzulNegrita">Obs. sin seguimiento:</asp:label><asp:dropdownlist id="ddblObsSinSeguimiento" runat="server" CssClass="normaldetalle" Width="184px"
																	Height="70px" AutoPostBack="True"></asp:dropdownlist></P>
														</TD>
													</TR>
													<TR>
														<TD align="center" bgColor="#f0f0f0">
															<P align="right"><asp:imagebutton id="btnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
																	alt="Aplicar Filtro por Selección" src="../imagenes/filtroPorSeleccion.JPG">
																<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																	ToolTip="Eliminar Filtro.."></asp:imagebutton><IMG style="WIDTH: 469px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="469">
																<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></P>
														</TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" AllowSorting="True"
													AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" PageSize="15" ShowFooter="True"
													HorizontalAlign="Center">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Organismo" SortExpression="ORGANISMO" HeaderText="ORGANISMO">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SUBORGANISMO" SortExpression="SUBORGANISMO" HeaderText="SUB ORGANISMO">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="actividad" SortExpression="actividad" HeaderText="ACCION DE CONTROL">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="periodo" SortExpression="periodo" HeaderText="A&#209;O">
															<HeaderStyle Width="11%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SP" SortExpression="SP" HeaderText="SP.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SC" SortExpression="SC" HeaderText="SC.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SCH" SortExpression="SCH" HeaderText="SCH.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="SI" SortExpression="SI" HeaderText="SI.">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Total" HeaderText="TOTAL">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="idOrganismo" HeaderText="idOrganismo"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="idSubOrganismo" HeaderText="idSubOrganismo"></asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<P></P>
												<P align="center">
<cc1:datagridweb id=gridResumen runat="server" CssClass="HeaderGrilla" Width="300px" HorizontalAlign="Center" ShowFooter="True" PageSize="4" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="SITUACION" SortExpression="SITUACION" HeaderText="SITUACION" FooterText="TOTAL">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SP" SortExpression="SP" HeaderText="SP">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SC" SortExpression="SC" HeaderText="SC">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SCH" SortExpression="SCH" HeaderText="SCH">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SI" SortExpression="SI" HeaderText="SI">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TOTAL" HeaderText="TOTAL">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
</cc1:datagridweb></P>
											</TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<td width="15%">&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></td>
								<TD vAlign="top"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE></TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
