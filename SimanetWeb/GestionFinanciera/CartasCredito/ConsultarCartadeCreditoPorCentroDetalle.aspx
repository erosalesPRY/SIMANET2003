<%@ Page language="c#" Codebehind="ConsultarCartadeCreditoPorCentroDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.ConsultarCartadeCreditoPorCentroDetalle" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Cartas de Crédito por Centro</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" style="WIDTH: 758px; HEIGHT: 136px" cellSpacing="0" cellPadding="0"
							width="758" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<P align="left"><asp:label id="LblEntidad" runat="server" Font-Size="Small" Font-Bold="True" BorderStyle="None"
											BorderWidth="1px">Label</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE style="WIDTH: 754px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="754" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 103px"><asp:imagebutton id="ibtnFiltar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 136px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg"></TD>
											<TD style="WIDTH: 143px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 635px"><IMG style="WIDTH: 438px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="438"></TD>
											<TD style="WIDTH: 186px"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="756px" ShowFooter="True" PageSize="7" DESIGNTIMEDRAGDROP="398">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="footerGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="BANCO">
<HeaderStyle Width="3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NroCDI" SortExpression="NroCDI" HeaderText="N&#186; CDI">
<HeaderStyle Width="5%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NroOrdenCompra" SortExpression="NroOrdenCompra" HeaderText="N&#186; O/COMPRA">
<HeaderStyle Width="5%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NProveedor" SortExpression="NProveedor" HeaderText="PROVEEDOR">
<HeaderStyle Width="40%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
<HeaderStyle Width="5%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoCCredito" SortExpression="MontoCCredito" HeaderText="MONTO">
<HeaderStyle Width="8%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TipodeCambio" SortExpression="TipodeCambio" HeaderText="T.C">
<HeaderStyle Width="2%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="DOLARIZADO">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom">
</ItemStyle>

<HeaderTemplate>
<TABLE class=HEADERGRILLA id=Table3 cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" width="100%" colSpan=2>
<asp:Label id=Label2 runat="server" DESIGNTIMEDRAGDROP="168">MONTO DOLARIZADO</asp:Label></TD></TR>
<TR>
<TD width="50%">
<asp:Label id=Label3 runat="server" DESIGNTIMEDRAGDROP="182">CREDITO</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" width="50%">
<asp:Label id=Label4 runat="server">CARGOS</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table5 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblMontoCredito runat="server" CssClass="ItemGrillaSinColor" Width="65px" Height="15px">0.0</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align=right width="50%">
<asp:Label id=lblMontoCargo runat="server" CssClass="ItemGrillaSinColor" DESIGNTIMEDRAGDROP="209" Width="64px" Height="13px">0.0</asp:Label></TD></TR></TABLE>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="FechaVencimiento" SortExpression="FechaVencimiento" HeaderText="VENCE">
<HeaderStyle Width="10%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="NRO DIAS">
<HeaderStyle VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 27px" vAlign="top" align="center" width="100%">
						<TABLE id="Table2" style="WIDTH: 761px" cellSpacing="1" cellPadding="1" width="761" border="0">
							<TR bgColor="#f0f0f0">
								<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
									vAlign="top" align="left" width="20%"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita">RESUMEN POR MONEDA:</asp:label></TD>
								<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
									vAlign="top" align="left" width="80%"><asp:label id="Label10" runat="server" CssClass="TextoNegroNegrita" DESIGNTIMEDRAGDROP="452"
										Width="208px">RESUMEN POR BANCO Y MONEDA :</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left"><cc1:datagridweb id="gridResumenMoneda" runat="server" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										Width="150px" PageSize="7">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="footerGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cantidad" SortExpression="Cantidad" HeaderText="CANT">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoCCredito" SortExpression="MontoCCredito" HeaderText="MONTO">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
								<TD vAlign="top" align="left"><cc1:datagridweb id="gridResumen" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="192px" PageSize="5">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="footerGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="BANCO">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cantidad" SortExpression="Cantidad" HeaderText="CANT">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoCCredito" SortExpression="MontoCCredito" HeaderText="MONTO">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" style="WIDTH: 768px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="768"
							border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hCampoFiltro" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; WIDTH: 18px; BORDER-BOTTOM: #000000 1px solid; HEIGHT: 22px"
										type="hidden" size="1" name="hCampoFiltro" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
