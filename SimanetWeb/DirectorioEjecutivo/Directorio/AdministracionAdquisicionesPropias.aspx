<%@ Page language="c#" Codebehind="AdministracionAdquisicionesPropias.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.AdministracionAdquisicionesPropias" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarAdquisicionesPropias</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Sesion ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Adquisiciones Propias</asp:label></TD>
							</TR>
							<TR>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="95%" border="0">
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminarFiltro" runat="server" ToolTip="Eliminar Filtro.."
																ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0">&nbsp;<IMG src="../../imagenes/spacer.gif" width="470" height="8"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="12" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AllowSorting="True" Width="100%" ShowFooter="True"
													AutoGenerateColumns="False" style="Z-INDEX: 0">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO.">
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Licitaciones" SortExpression="CODIGOPROCESO" HeaderText="COD. PROCESO">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="C.O.">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FechaAdquisicionPropia" SortExpression="FechaAdquisicionPropia" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="ObjetoAdquisicion" SortExpression="ObjetoAdquisicion" HeaderText="OBJETO ADQUISICION">
<HeaderStyle Width="40%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RAZONSOCIAL" SortExpression="RAZONSOCIAL" HeaderText="PROVEEDOR">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TipoMoneda" SortExpression="TipoMoneda" HeaderText="MONEDA">
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoAdquisicionPropia" SortExpression="MontoAdquisicionPropia" HeaderText="MONTO" DataFormatString="{0:###,##0.00}">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Width="56px" Height="7px"></asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5" border="0">
													<TR>
														<TD class="TitFiltros" bgColor="#f5f5f5">
															<asp:label id="lblObjeto" runat="server" CssClass="normal"> Proyecto:</asp:label></TD>
														<TD class="combos" bgColor="#f5f5f5" width="100%">
															<asp:textbox id="txtObjeto" runat="server" CssClass="normal" Width="100%" TextMode="MultiLine"
																ReadOnly="True"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="85%" border="0">
										<TR>
											<TD vAlign="top"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
													style="CURSOR: hand"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
													name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
													runat="server"></TD>
										</TR>
									</TABLE>
									<INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hDescripcion" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hDescripcion"
										runat="server">
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
