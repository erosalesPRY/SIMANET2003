<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarHistoricoPromotores.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.ConsultarHistoricoPromotores" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		
		<script language="javascript">
		
		function Ocultar()
		{
			$O('ibtnFiltrarSeleccion').style.display = "none";
		}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();Ocultar();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table7" height="456" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 18px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal</asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Promotores</asp:label>&nbsp;</TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<td vAlign="top" align="left" colSpan="8">&nbsp;
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></td>
													</TR>
													<TR>
														<TD align="left" bgColor="#f0f0f0">
															<asp:ImageButton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif" Visible="False"></asp:ImageButton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG" style="CURSOR: hand">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.." Visible="False"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0" align="right">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="gridContratos" runat="server" CssClass="HeaderGrilla" ShowFooter="True" AllowSorting="True"
													AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
													Width="80%">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NROCONTRATO" SortExpression="NROCONTRATO" HeaderText="NRO. CONTRATO">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FECHAINICIOCONTRATO" SortExpression="FECHAINICIOCONTRATO" HeaderText="FECHA INICIO" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FECHATERMINOCONTRATO" SortExpression="FECHATERMINOCONTRATO" HeaderText="FECHA TERMINO" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TOTALVENTAS" SortExpression="TOTALVENTAS" HeaderText="TOTAL VENTAS (S/.)" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RETRIBUCION" SortExpression="RETRIBUCION" HeaderText="RETRIB. ECON. ($)" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:ButtonColumn Text="Detalle" CommandName="Select"></asp:ButtonColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla">
</HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3">
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3">
												<asp:label id="lblSubtitulo" runat="server" CssClass="SubTituloNegrita"></asp:label></TD>
										</TR>
									</TABLE>
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5" border="0">
										<TR>
											<TD class="TitFiltros" bgColor="#f5f5f5">
												<P align="left">&nbsp;</P>
											</TD>
											<TD align="center">
												<cc2:datagridweb id="gridProyectos" runat="server" CssClass="HeaderGrilla" ShowFooter="True" AllowSorting="True"
													AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
													Width="80%">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CLIENTE" SortExpression="CLIENTE" HeaderText="CLIENTE FINAL">
<HeaderStyle Width="30%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Trabajo" SortExpression="Trabajo" HeaderText="TRABAJO EFECTUADO">
<HeaderStyle Width="30%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="precioventa" SortExpression="precioventa" HeaderText="MONTO DE VENTA (S/.)" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RETRIBUCION" SortExpression="RETRIBUCION" HeaderText="RETRIB. ECON. ($)" DataFormatString="{0:# ### ### ##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla">
</HeaderStyle>
												</cc2:datagridweb></TD>
										</TR>
									</TABLE>
									<TABLE width="100%">
										<TR>
											<TD align="left" width="700"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
													style="CURSOR: hand"></TD>
										</TR>
									</TABLE>
									<INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 8px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hDescripcion" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hDescripcion"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE></TD></TR></TABLE>
		</form>
		<P>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
</TD></TR></P>
		<P>&nbsp;</P>
	</body>
</HTML>
