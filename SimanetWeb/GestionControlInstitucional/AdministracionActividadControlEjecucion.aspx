<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AdministracionActividadControlEjecucion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministracionActividadControlEjecucion" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control Institucional ></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Administracion de las Actividades de Control</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
							runat="server"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f0f0f0"
										border="0">
										<TR>
											<TD bgColor="#f0f0f0" colSpan="2"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4">
												<asp:ImageButton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:ImageButton></TD>
											<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../imagenes/filtroPorSeleccion.JPG"></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="280"></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" BorderStyle="Dotted"
										Width="780px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdActividadCtrlEjec"></asp:BoundColumn>
											<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Denominacion" SortExpression="Denominacion" HeaderText="ACTIVIDAD DE CONTROL">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroMetaProgramada" SortExpression="NroMetaProgramada" HeaderText="META">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcentajeAvanceProgramado" SortExpression="PorcentajeAvanceProgramado"
												HeaderText="% PROGRAMADO"></asp:BoundColumn>
											<asp:BoundColumn DataField="NroUnidadesEjecutadas" SortExpression="NroUnidadesEjecutadas" HeaderText="NRO UNIDADES">
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcentajeAvanceEjecutado" SortExpression="PorcentajeAvanceEjecutado"
												HeaderText="% EJECUTADO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="ESTADO"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="E"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="F"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="M"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="A"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="M"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="J"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="J"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="A"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="S"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="O"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="N"></asp:BoundColumn>
											<asp:BoundColumn HeaderText="D"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:ImageButton id="ibtnAtras" runat="server" ImageUrl="../imagenes/atras.gif"></asp:ImageButton></TD>
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
