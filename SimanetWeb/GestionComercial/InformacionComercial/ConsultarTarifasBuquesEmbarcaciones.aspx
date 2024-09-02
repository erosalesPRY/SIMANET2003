<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarTarifasBuquesEmbarcaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.ConsultarTarifasBuquesEmbarcaciones" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
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
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Tarifas de Buques y Embarcaciones</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> REGISTRO DE TARIFAS DE BUQUES Y EMBARCACIONES</asp:label><INPUT id="hCodigo" style="WIDTH: 16px" type="hidden" size="1" name="hCodigo" runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD class="TitFiltros">&nbsp;
												<asp:label id="lblClasifEmbarcacion" runat="server" CssClass="normal" Width="128px">Clasificacion Embarcacion</asp:label></TD>
											<TD class="combos">
												<asp:dropdownlist id="ddlbClasificacionEmbarcacion" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
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
											<TD vAlign="middle"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroPorSeleccion.JPG"></TD>
											<TD bgColor="#f0f0f0" vAlign="middle">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="452" style="WIDTH: 452px; HEIGHT: 8px"></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" DataKeyField="IdTarifaEmbarcacion"
										ShowFooter="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False"
										AllowSorting="True" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
												<FooterStyle HorizontalAlign="Center"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DescripcionTrabajo" SortExpression="DescripcionTrabajo" HeaderText="DESCRIPCION">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DETALLE">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Embarcacion" SortExpression="Embarcacion" HeaderText="TIPO EMBARCACION">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Costo" SortExpression="Costo" HeaderText="COSTO" DataFormatString="{0:##.00}">
												<HeaderStyle Width="7%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD><IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
