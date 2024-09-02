<%@ Page language="c#" Codebehind="AdministrarRegistroProyectoOtros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.AdministrarRegistroProyectoOtros" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 20px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Historico de Proyectos ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">METAL MECANICA</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 236px" vAlign="top" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">ADMINISTRAR REGISTRO DE PROYECTOS MM</asp:label>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroPorSeleccion.JPG">
									<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregarPuentes" runat="server" ImageUrl="../../imagenes/btnAgregarPuentes.JPG"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/btnAgregarOtros.jpg"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
							</TR>
						</TABLE>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="15" Width="780px" AllowPaging="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle HorizontalAlign="Center" Width="5px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IDPROYECTO" SortExpression="IDPROYECTO" HeaderText="ID PROYECTO">
												<HeaderStyle Width="78px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE" SortExpression="NOMBRE" HeaderText="NOMBRE">
												<HeaderStyle Width="230px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LINEAPRODUCTO" SortExpression="LINEAPRODUCTO" HeaderText="LINEA DE PRODUCTO">
												<HeaderStyle Width="78px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBREBUQUE" SortExpression="NOMBREBUQUE" HeaderText="TIPO DE PRODUCTO">
												<HeaderStyle Width="80px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRECLIENTE" SortExpression="NOMBRECLIENTE" HeaderText="CLIENTE">
												<HeaderStyle Width="220px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="FECHAACUERDO" SortExpression="FECHAACUERDO" HeaderText="FECHA ACUERDO"
												DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="78px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SIGLA1" SortExpression="SIGLA1" HeaderText="C.O">
												<HeaderStyle Width="50px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hIDREGISTROPROYECTOOTROS" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1"
										name="hCodigo" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hProyectosOtros" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hGridPagina" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hGridPagina"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
