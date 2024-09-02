<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarProgramacionActividades.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.ConsultarProgramacionActividades" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
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
								<TD class="Commands" style="HEIGHT: 23px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Programación de Inspecciones</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" align="center"
										border="0">
										<TR>
											<TD style="HEIGHT: 5px" vAlign="top" align="center" bgColor="#f0f0f0" colSpan="3"><asp:label id="Label9" runat="server" CssClass="TextoAzulNegrita">Periodo:</asp:label><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="btnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton><IMG style="WIDTH: 469px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="469">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
													AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" Width="780px" PageSize="7"
													ShowFooter="True">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle Height="20px" CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle Height="22px">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO.">
<HeaderStyle Width="0%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Organismo" SortExpression="Organismo" HeaderText="ORGANISMO">
<HeaderStyle Width="12%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="AsuntoDocumento" SortExpression="AsuntoDocumento" HeaderText="ASUNTO">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="C.O.">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FECHA INIC." DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="12%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERM." DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="12%">
</HeaderStyle>
</asp:BoundColumn>
<asp:TemplateColumn Visible="False">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemTemplate>
																<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
															
</ItemTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn HeaderText="REF">
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemTemplate>
																<IMG id="imgFile" alt="" src="/SimaNetWeb/imagenes/Navegador/File.gif" runat="server">
															
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD class="TitFiltros" bgColor="#f5f5f5"><asp:label id="lblSituacion" runat="server" CssClass="normal" Width="56px"> Observaciones:</asp:label></TD>
											<TD class="combos" bgColor="#f5f5f5"><asp:textbox id="txtSituacion" runat="server" CssClass="normal" Width="700px" Height="41px" TextMode="MultiLine"
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
