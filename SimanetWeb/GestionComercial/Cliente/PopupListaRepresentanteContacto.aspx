<%@ Page language="c#" Codebehind="PopupListaRepresentanteContacto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Cliente.PopupListaRepresentanteContacto" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<TITLE>PopupListaRepresentanteContacto</TITLE>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" vAlign="top" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Clientes > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de</asp:label></TD>
				</TR>
				<TR>
					<TD class="TituloPrincipal" vAlign="top" align="center" colSpan="3"><asp:label id="lblTituloPrincipal" runat="server" CssClass="TituloPrincipal"> LISTA DE</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" colSpan="3"><INPUT id="hCodigo" type="hidden" size="1" name="hCodigo" runat="server"></TD>
				</TR>
				<TR>
					<TD class="TituloPrincipal" vAlign="top" align="center" colSpan="3">
						<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"><asp:label id="lblNombre" runat="server" CssClass="normal" Width="80px">Nombre</asp:label></TD>
								<TD class="combos" width="300"><asp:textbox id="txtNombre" runat="server" Width="250px"></asp:textbox><IMG height="8" src="../../imagenes/spacer.gif" width="7"></TD>
								<TD class="combos"><asp:label id="lblApellidopaterno" runat="server" CssClass="normal" Width="80px">Apellido Paterno</asp:label></TD>
								<TD class="combos"><asp:textbox id="txtApellidoPaterno" runat="server" Width="250px"></asp:textbox></TD>
								<TD class="combos"><asp:imagebutton id="ibtnConsultar" runat="server" CssClass="boton" ImageUrl="../../imagenes/ibtnConsultarCliente.gif"
										ImageAlign="Right"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE class="normal" id="Table5" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" colSpan="3">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif" Visible="False"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" style="VISIBILITY: hidden" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroPorSeleccion.JPG" runat="server"></TD>
											<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													Visible="False" ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 258px" bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="50"></TD>
											<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="5">
												<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
											<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" RowHighlightColor="#E0E0E0"
										AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Id" HeaderText="Id"></asp:BoundColumn>
											<asp:BoundColumn DataField="Nombres" SortExpression="Nombre" HeaderText="NOMBRE">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidoPaterno" SortExpression="ApellidoPaterno" HeaderText="APELLIDO PATERNO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidoMaterno" SortExpression="ApellidoMaterrno" HeaderText="APELLIDO MATERNO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">&nbsp;</TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<tr>
					<td vAlign="top"></td>
				</tr>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
