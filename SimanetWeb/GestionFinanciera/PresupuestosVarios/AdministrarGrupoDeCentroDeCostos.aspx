<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarGrupoDeCentroDeCostos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.AdministrarGrupoDeCentroDeCostos" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarGrupoDeCentroDeCostos</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" onload="ObtenerHistorial(); " rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de grupos de Centros de Costos</asp:label><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Financiera    > Administrar Grupo de Centro de Costos</asp:label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">ADMINISTRACION DE GRUPO DE CENTROS DE COSTOS</asp:label></P>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
							runat="server"><INPUT id="hNombre" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNombre"
							runat="server"><INPUT id="hNroGrupoCC" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNroGrupoCC"
							runat="server"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
							<TR>
								<TD></TD>
								<TD>
									<P align="left"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" CausesValidation="False"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
											src="../../imagenes/filtroPorSeleccion.JPG">
										<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
											ToolTip="Eliminar Filtro.."></asp:imagebutton><IMG style="WIDTH: 208px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="208">
										<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton><asp:imagebutton id="ibtnCentroCosto" runat="server" ImageUrl="..\..\imagenes\btnCentroCosto.JPG"></asp:imagebutton></P>
								</TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><cc1:datagridweb id="dgGrupoCentroCostos" runat="server" Height="1px" Width="700px" AutoGenerateColumns="False"
										AllowPaging="True" RowHighlightColor="#E0E0E0" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nroGrupoCC" SortExpression="nroGrupoCC" HeaderText="NRO Grupo">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="Grupo de Centro de Costos">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD>
									<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
								</TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
