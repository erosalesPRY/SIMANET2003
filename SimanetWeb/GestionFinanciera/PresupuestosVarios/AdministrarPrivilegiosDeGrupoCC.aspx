<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarPrivilegiosDeGrupoCC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PresupuestosVarios.AdministrarPrivilegiosDeGrupoCC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPrivilegiosDeGrupoCC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Administrar Privilegios de Grupo de Centro de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 29px" colSpan="3">
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">ADMINISTRACION DE PRIVILEGIOS DE GRUPOS DE CENTROS DE COSTOS</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" colSpan="3">
						<P align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
								runat="server"></P>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" colSpan="3">
						<DIV align="center">
							<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
								<TR>
									<TD><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD bgColor="#f0f0f0"></TD>
									<TD bgColor="#f0f0f0">
										<asp:label id="lblLugar" runat="server" CssClass="normal">Tipo de Presupuesto:</asp:label></TD>
								</TR>
								<TR>
									<TD bgColor="#f0f0f0"></TD>
									<TD bgColor="#f0f0f0">
										<asp:dropdownlist id="ddblTipoPresupuesto" runat="server" CssClass="combos" AutoPostBack="True" Width="234px"></asp:dropdownlist></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 30px" colSpan="3">
						<DIV align="left"><INPUT id="hNroGrupoCC" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNroGrupoCC"
								runat="server"></DIV>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
								<TR>
									<TD></TD>
									<TD>
										<DIV align="center">
											<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" border="0">
												<TR>
													<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
													<TD><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
															src="../../imagenes/filtroPorSeleccion.JPG"></TD>
													<TD></TD>
													<TD><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
															ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
													<TD bgColor="#f0f0f0"><IMG style="WIDTH: 481px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="481"></TD>
												</TR>
											</TABLE>
										</DIV>
										<cc1:datagridweb id="dgGrupoCentroCostos" runat="server" Width="704px" Height="1px" AutoGenerateColumns="False"
											AllowPaging="True" RowHighlightColor="#E0E0E0" PageSize="7">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO">
													<HeaderStyle Width="2%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Grupocc" SortExpression="nombre" HeaderText="Grupo de Centro de Costos">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Nombre" SortExpression="usuario" HeaderText="Usuario Asignado">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD>
										<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
									<TD></TD>
								</TR>
								<TR>
									<TD></TD>
									<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
