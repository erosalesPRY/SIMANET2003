<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarRegistroProyectos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarRegistroProyectos" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" class="normal">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<td colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" colSpan="3">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Consulta de Proyectos Construccion Naval</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">CONSULTA DE PROYECTOS CONSTRUCCION NAVAL</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD bgColor="#f0f0f0">
												<asp:ImageButton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:ImageButton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroPorSeleccion.JPG">
												<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0" style="WIDTH: 221px" align="right">
												<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" Width="780px" AllowPaging="True" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" CssClass="HeaderGrilla"
										ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdRegistroProyectoCN"></asp:BoundColumn>
											<asp:BoundColumn DataField="NombreProyecto" SortExpression="NombreProyecto" HeaderText="PROYECTO">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Cliente" SortExpression="Cliente" HeaderText="ARMADOR">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Clasificacion" SortExpression="Clasificacion" HeaderText="CLASIFICACION"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Subclasificacion" SortExpression="Subclasificacion" HeaderText="SUB CLASIFICACION"></asp:BoundColumn>
											<asp:BoundColumn DataField="Peso" SortExpression="Peso" HeaderText="PESO"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaQuilla" SortExpression="FechaQuilla" HeaderText="FECHA QUILLA" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaLanzamiento" SortExpression="FechaLanzamiento" HeaderText="FECHA LANZAMIENTO"
												DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaEntrega" SortExpression="FechaEntrega" HeaderText="FECHA ENTREGA"
												DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="CodigoCO" SortExpression="CodigoCO" HeaderText="CODIGO"></asp:BoundColumn>
											<asp:BoundColumn DataField="CodigoSimaPeru" SortExpression="CodigoSimaPeru" HeaderText="CODIGO SIMA PERU"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
