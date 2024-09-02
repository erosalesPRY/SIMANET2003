<%@ Page language="c#" Codebehind="AdministrarTerminosReferenciaPAMC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.AdministrarTerminosReferenciaPAMC" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarTerminosReferenciaPAMC</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="left">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD align="left">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands" align="left">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPaginaActual">Inicio > Gesti�n Estr�tegica >  Proyectos Apoyo a la Mejora de la Competitividad > Nivel >  Agrupaci�n >  Detalle Agrup. >  </asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR T.D.R.</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblSeguimiento" runat="server" CssClass="TituloPrincipal"></asp:label><BR>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="left" bgColor="#f0f0f0">
									<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selecci�n"
										src="../../imagenes/filtroPorSeleccion.JPG">
									<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD align="right" bgColor="#f0f0f0">
									<asp:imagebutton id="btnConsultores" runat="server" ImageUrl="../../imagenes/btnConsultores.JPG"></asp:imagebutton>
									<asp:imagebutton id="btnActividades" runat="server" ImageUrl="../../imagenes/btnActividad.gif"></asp:imagebutton>
									<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton>
									<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0" colSpan="2">
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" AllowSorting="True"
										ShowFooter="True" AutoGenerateColumns="False" PageSize="7" AllowPaging="True" RowHighlightColor="#E0E0E0"
										RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="t.d.r.">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRELARGO" SortExpression="NOMBRELARGO" HeaderText="TERMINOS DE REFERENCIA">
												<HeaderStyle Width="47%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NCONSULTORES" SortExpression="NCONSULTORES" HeaderText="#CONSULTORES">
												<HeaderStyle Width="8%"></HeaderStyle>
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
								<TD align="center" bgColor="#f0f0f0" colSpan="2">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda">No exiten Registros</asp:label></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 40px; HEIGHT: 22px" type="hidden" size="1" name="Hidden3"
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
		</FORM>
	</body>
</HTML>
