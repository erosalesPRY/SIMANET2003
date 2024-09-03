<%@ Page language="c#" Codebehind="AdministrarCentroDeCostos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.AdministrarCentroDeCostos" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarCentroDeCostos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial(); " onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administracion de Centros de Costos</asp:label><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera > Presupuesto > Administracion de Grupo de Centros de Costos > Administracion de Centros de Costos</asp:label></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">ADMINISTRACION DE CENTROS DE COSTOS</asp:label></P>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblNombreGrupoCC" runat="server" CssClass="TituloPrincipal"></asp:label></P>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
							runat="server"></TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="300" border="0">
								<TR>
									<TD>
										<DIV align="center">
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
												<TR>
													<TD>
														<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" CausesValidation="False"></asp:imagebutton></TD>
													<TD><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
															src="../../imagenes/filtroPorSeleccion.JPG"></TD>
													<TD>
														<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
															ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
													<TD><IMG style="WIDTH: 306px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="306"></TD>
													<TD>
														<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
													<TD>
														<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
												</TR>
											</TABLE>
										</DIV>
										<DIV align="center">
											<cc1:datagridweb id="dgCentroCostos" runat="server" Height="1px" Width="700px" AutoGenerateColumns="False"
												AllowPaging="True" RowHighlightColor="#E0E0E0" PageSize="7">
												<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
												<ItemStyle CssClass="ItemGrilla"></ItemStyle>
												<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												<FooterStyle CssClass="FooterGrilla"></FooterStyle>
												<Columns>
													<asp:BoundColumn HeaderText="NRO">
														<HeaderStyle Width="2%"></HeaderStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="nroCC" SortExpression="nroCC" HeaderText="NRO Centro Costo">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="nombre" SortExpression="nombre" HeaderText="Centro de Costos">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="Anexo" HeaderText="ANEXO"></asp:BoundColumn>
												</Columns>
												<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											</cc1:datagridweb></DIV>
									</TD>
								</TR>
								<TR>
									<TD>
										<P align="center">
											<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></DIV>
									</TD>
								</TR>
							</TABLE>
						</DIV>
						<DIV align="center">
						</DIV>
					</TD>
					<TD></TD>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<DIV align="left">&nbsp;</DIV>
						</DIV>
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
