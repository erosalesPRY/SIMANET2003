<%@ Page language="c#" Codebehind="AdministrarAgrupacionPAMC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.AdministrarAgrupacionPAMC" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarAgrupacionPAMC</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="left"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD align="left"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" align="left"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPaginaActual">Inicio > Gestión Estrátegica >  Proyectos Apoyo a la Mejora de la Competitividad > Nivel >  </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR COMPONENTES</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label><BR>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="left" bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" Visible="False"></asp:imagebutton>
									<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.." Visible="False"></asp:imagebutton></TD>
								<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="btnProyectos" runat="server" ImageUrl="../../imagenes/btnProyectos.gif"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0" colSpan="2"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" AllowSorting="True"
										ShowFooter="True" AutoGenerateColumns="False" PageSize="7" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Left" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="COMPONENTE">
												<HeaderStyle HorizontalAlign="Center" Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AVANCE" SortExpression="AVANCE" HeaderText="Avance %" DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0" colSpan="2"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">No exiten Registros</asp:label></TD>
							</TR>
							<TR>
								<TD><IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="Hidden3"
										runat="server"><INPUT id="hNombre" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="Hidden3"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
