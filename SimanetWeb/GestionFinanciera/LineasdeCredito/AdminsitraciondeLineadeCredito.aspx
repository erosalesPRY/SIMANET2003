<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdminsitraciondeLineadeCredito.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito.AdminsitraciondeLineadeCredito" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" align="left" width="100%">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Línea de Crédito</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"
							DESIGNTIMEDRAGDROP="113"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="674" border="0"
							style="WIDTH: 674px">
							<TR>
								<TD style="HEIGHT: 15px">
									<asp:dropdownlist id="ddlbEstadoLineaCredito" runat="server" CssClass="NormalDetalle" Width="200px"
										AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 15px"></TD>
								<TD style="HEIGHT: 15px"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="670" border="0" style="WIDTH: 670px; HEIGHT: 22px">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 115px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg"></TD>
											<TD style="WIDTH: 673px">&nbsp;
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 330px"><IMG style="WIDTH: 430px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="430"
													DESIGNTIMEDRAGDROP="113"></TD>
											<TD style="WIDTH: 214px">
												<asp:imagebutton id="ibtnAgregar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" AllowPaging="True" Width="671px" ShowFooter="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn SortExpression="id" HeaderText="COD">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<ItemTemplate>
<asp:HyperLink id=hlkNroID runat="server" ForeColor="Blue">Nro</asp:HyperLink>
</ItemTemplate>
</asp:TemplateColumn>
<asp:BoundColumn DataField="NombreEmpresa" SortExpression="NombreEmpresa" HeaderText="EMPRESA">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NombreEntidadfinanciera" SortExpression="NombreEntidadfinanciera" HeaderText="BANCO">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NombreLineaCredito" SortExpression="NombreLineaCredito" HeaderText="LINEA DE CREDITO">
<HeaderStyle HorizontalAlign="Center" Width="8%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="montoautorizado" SortExpression="montoautorizado" HeaderText="MONTO AUTORIZADO.">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="fechavencimiento" SortExpression="fechavencimiento" HeaderText="VENCE">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="ESTADO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"
										DESIGNTIMEDRAGDROP="113"></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592">
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
