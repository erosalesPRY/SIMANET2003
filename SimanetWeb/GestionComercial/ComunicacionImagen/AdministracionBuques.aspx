<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministracionBuques.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.AdministracionBuques" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
			<TR>
				<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
			</TR>
			<tr>
				<td colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
			</tr>
			<TR>
				<TD colSpan="3">
					<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
						<TR>
							<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gesti�n Comercial > Comunicaci�n e Imagen > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Buques</asp:label></TD>
						</TR>
						<TR>
							<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> ADMINISTRACION DE BUQUES</asp:label></TD>
						</TR>
						<TR>
							<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
									runat="server"><INPUT id="hDescripcion" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDescripcion"
									runat="server"></TD>
						</TR>
						<TR>
							<TD align="center">
								<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" bgColor="#f5f5f5" border="0">
									<TR bgColor="#ffffff">
										<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
										<TD class="combos"></TD>
									</TR>
									<TR>
										<TD></TD>
										<TD class="SmallFont"><asp:label id="lblLugar" runat="server" CssClass="normal">Lugar:</asp:label></TD>
									</TR>
									<TR>
										<TD class="TitFiltros">&nbsp;</TD>
										<TD class="combos"><asp:dropdownlist id="ddlbLugar" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
							<TD vAlign="top" align="center">
								<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
									<TR>
										<TD>
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f0f0f0"
												border="0">
												<TR>
													<TD bgColor="#f0f0f0" colSpan="2"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4">
														<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selecci�n"
															src="../../imagenes/filtroPorSeleccion.JPG"></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
															ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="100"></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFoto" runat="server" ImageUrl="../../imagenes/ibtnFoto.jpg"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnVideo" runat="server" ImageUrl="../../imagenes/ibtnVideo.jpg"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
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
													<asp:BoundColumn Visible="False" DataField="IdBuque"></asp:BoundColumn>
													<asp:BoundColumn DataField="IdLineaNegocio" SortExpression="IdLineaNegocio" HeaderText="LN">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="NombreBuque" SortExpression="NombreBuque" HeaderText="NOMBRE">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="EN SIMA?">
														<ItemTemplate>
															<asp:Image id="imgEnSima" runat="server" Width="20px" Height="20px"></asp:Image>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="PosicionBuque" SortExpression="PosicionBuque" HeaderText="POSICION">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
														<FooterStyle HorizontalAlign="Right"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="IdTrabajoActual" SortExpression="IdTrabajoActual" HeaderText="TRABAJO">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="NombreOficialMando" SortExpression="NombreOficialMando" HeaderText="OFICIAL">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="IdGrado" SortExpression="IdGrado" HeaderText="GRADO">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="FOTO?">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:Image id="imgFoto" runat="server" Width="20px" Height="20px"></asp:Image>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn HeaderText="VIDEO?">
														<ItemStyle HorizontalAlign="Center"></ItemStyle>
														<ItemTemplate>
															<asp:Image id="imgVideo" runat="server" Width="20px" Height="20px"></asp:Image>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											</cc1:datagridweb></TD>
									</TR>
									<TR>
										<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
									</TR>
									<TR>
										<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
									</TR>
								</TABLE>
							</TD>
						</TR>
						<TR>
						</TR>
					</TABLE>
				</TD>
			</TR>
			<tr>
			</tr>
			<TR bgColor="#5891ae">
			</TR>
		</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
