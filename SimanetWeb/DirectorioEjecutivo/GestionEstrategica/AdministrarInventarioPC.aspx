<%@ Page language="c#" Codebehind="AdministrarInventarioPC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.AdministrarInventarioPC" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarInventarioPC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD id="TD2" runat="server"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD id="TD3" runat="server"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" id="TD1" runat="server"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Inventario Informatico </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Inventario de PC</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P style="COLOR: white" align="left">&nbsp;
							<asp:imagebutton id="ImageButton2" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="20px"></asp:imagebutton></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P id="P1" align="center"><asp:label id="Label1" runat="server" CssClass="TituloPrincipal"> ADMINISTRACION INVENTARIO PC</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:imagebutton id="ImageButton1" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="20px"></asp:imagebutton></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="735" align="center" border="0">
							<TR>
								<TD id="TD4" align="left" runat="server">
									<P id="P3" align="left" runat="server"><asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
											src="../../imagenes/filtroPorSeleccion.JPG">
										<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
											ToolTip="Eliminar Filtro.."></asp:imagebutton></P>
								</TD>
								<TD align="right">
									<P id="P2" align="right" runat="server"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif" Visible="true"></asp:imagebutton><IMG id="ImgImprimir" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,TD1, TD2, TD3, TD5, P3, P2);"
											alt="" src="../../imagenes/bt_imprimir.gif"></P>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="2"><ALTERNATINGITEMSTYLE CssClass="AlternateItemGrillaJustificado"><ALTERNATINGITEMSTYLE CssClass="AlternateItemGrillaJustificado"></ALTERNATINGITEMSTYLE>
										<ITEMSTYLE CssClass="ItemGrillaJustificado"></ITEMSTYLE>
										<HEADERSTYLE CssClass="HeaderGrilla" HorizontalAlign="Center"></HEADERSTYLE>
										<FOOTERSTYLE CssClass="FooterGrilla" HorizontalAlign="Right"></FOOTERSTYLE>
										<COLUMNS>
											<ASP:BOUNDCOLUMN HeaderText="NRO" DataField="IDOGENERALES">
												<HEADERSTYLE Width="2%"></HEADERSTYLE>
												<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
												<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN Visible="False" HeaderText="IDOGENERALES" DataField="IDOGENERALES"></ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN HeaderText="OG" DataField="OG">
												<HEADERSTYLE Width="10%"></HEADERSTYLE>
												<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN HeaderText="DESCRIPCION" DataField="DESCRIPCION" SortExpression="DESCRIPCION">
												<ITEMSTYLE VerticalAlign="Middle"></ITEMSTYLE>
												<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
											</ASP:BOUNDCOLUMN>
											<ASP:BOUNDCOLUMN HeaderText="TIPO" DataField="TIPOOBJETIVO" SortExpression="TIPO">
												<HEADERSTYLE Width="20%"></HEADERSTYLE>
												<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
												<FOOTERSTYLE HorizontalAlign="Left" VerticalAlign="Top"></FOOTERSTYLE>
											</ASP:BOUNDCOLUMN>
										</COLUMNS>
										<PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE>
										<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" ShowFooter="True"
											AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
											RowPositionEnabled="False">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="IDINVENTARIOPC" HeaderText="IDINVENTARIOPC"></asp:BoundColumn>
												<asp:BoundColumn DataField="PROCESADOR" SortExpression="PROCESADOR" HeaderText="PROCESADOR">
													<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CO" SortExpression="CO" HeaderText="CO">
													<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="AREA" SortExpression="AREA" HeaderText="AREA">
													<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RESPONSABLE" SortExpression="RESPONSABLE" HeaderText="RESPONSABLE">
													<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TIPO" SortExpression="TIPO" HeaderText="TIPO">
													<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb>
										<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
									</ALTERNATINGITEMSTYLE><ITEMSTYLE CssClass="ItemGrillaJustificado"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla" HorizontalAlign="Center"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla" HorizontalAlign="Right"></FOOTERSTYLE><COLUMNS><ASP:BOUNDCOLUMN HeaderText="NRO" DataField="IDOGENERALES"><HEADERSTYLE Width="2%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="OG" DataField="OG">
											<HEADERSTYLE Width="10%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="DESCRIPCION" DataField="DESCRIPCION" SortExpression="DESCRIPCION">
											<ITEMSTYLE VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="TIPO" DataField="TIPOOG">
											<HEADERSTYLE Width="25%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left" VerticalAlign="Top"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 305px; HEIGHT: 9px" align="center"><INPUT id="hGridPaginaSort" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 16px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server">&nbsp; <INPUT id="hGridIndex" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="hGridIndex"
										runat="server"></TD>
								<TD style="HEIGHT: 9px" align="center"></TD>
							</TR>
							<TR>
								<TD id="TD5" style="WIDTH: 305px" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								<TD></TD>
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
	</body>
</HTML>
