<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarTarifasBuquesEmbarcaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.AdministrarTarifasBuquesEmbarcaciones" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" colSpan="3">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de Tarifas de Buques y Embarcaciones</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table6" style="WIDTH: 335px; HEIGHT: 40px" cellSpacing="0" cellPadding="0"
										width="335" bgColor="#f5f5f5" border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros" style="WIDTH: 112px" width="112"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos" width="121"></TD>
											<TD class="combos" style="WIDTH: 14px" width="25"></TD>
										</TR>
										<TR>
											<TD class="TitFiltros" style="WIDTH: 112px">&nbsp;
												<asp:label id="lblClasifEmbarcacion" runat="server" CssClass="normal" Width="128px">Clasificacion Embarcacion</asp:label></TD>
											<TD class="combos">
												<asp:dropdownlist id="ddlbClasificacionEmbarcacion" runat="server" CssClass="normal" Width="168px"
													AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="combos" style="WIDTH: 14px"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0" style="WIDTH: 115px" vAlign="middle">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="345" style="WIDTH: 345px; HEIGHT: 8px"></TD>
											<TD bgColor="#f0f0f0">
												<asp:ImageButton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:ImageButton></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="780px" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
										AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" ShowFooter="True" DataKeyField="IdTarifaEmbarcacion"
										CssClass="HeaderGrilla">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<FooterStyle HorizontalAlign="Center">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DETALLE">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Embarcacion" SortExpression="Embarcacion" HeaderText="TIPO EMBARCACION">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Costo" SortExpression="Costo" HeaderText="COSTO" DataFormatString="{0:##.00}">
<HeaderStyle Width="7%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px" type="hidden" size="1" name="hCodigo" runat="server"></TD>
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
