<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="AdministrarObservacionesVentas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.AdministrarObservacionesVentas" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Observaciones de Ventas Mensual</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> ADMINISTRACIÓN DE OBSERVACIONES DE VENTAS MENSUAL</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="lblCentroOperativo" runat="server" CssClass="normal">Centro de Operaciones</asp:label></TD>
											<TD class="SmallFont">
												<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normal" Width="136px" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD>
												<asp:label id="Label1" runat="server" CssClass="normal">Tipo de Observación</asp:label></TD>
											<TD class="SmallFont">
												<asp:dropdownlist id="ddblTipoObservacion" runat="server" CssClass="normal" AutoPostBack="True" Width="136px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0">
															<asp:ImageButton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:ImageButton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="280"></TD>
														<TD bgColor="#f0f0f0">
															<asp:ImageButton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:ImageButton></TD>
														<TD bgColor="#f0f0f0" style="WIDTH: 86px">
															<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" Width="780px" RowPositionEnabled="False" AutoGenerateColumns="False"
													AllowSorting="True" AllowPaging="True" RowHighlightColor="#E0E0E0" ShowFooter="True" DataKeyField="IDOBSERVACIONES"
													CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="Nro" FooterText="Total"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDOBSERVACIONES"></asp:BoundColumn>
														<asp:BoundColumn DataField="PERIODO" SortExpression="PERIODO" HeaderText="PERIODO"></asp:BoundColumn>
														<asp:BoundColumn DataField="MES" SortExpression="MES" HeaderText="MES"></asp:BoundColumn>
														<asp:BoundColumn DataField="centrooperativo" SortExpression="centrooperativo" HeaderText="CO"></asp:BoundColumn>
														<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACION"></asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
