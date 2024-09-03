<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarSctr.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarSctr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Personal ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración Programación Trabajos Contratista></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">PROGRAMACIÓN DE TRABAJOS CONTRATISTAS</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
										align="left">
										<TR>
											<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif" style="Z-INDEX: 0"></asp:imagebutton></TD>
											<TD><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroPorSeleccion.JPG" style="Z-INDEX: 0"></TD>
											<TD><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.." style="Z-INDEX: 0"></asp:imagebutton></TD>
											<TD width="100%" align="left">
												<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="300" align="left">
													<TR>
														<TD></TD>
														<TD width="300"></TD>
														<TD>
															<asp:imagebutton style="Z-INDEX: 0" id="imgBtnLstEquipos" runat="server" ImageUrl="../../imagenes/btnEquipos.JPG"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
											<TD><asp:imagebutton id="ibtnProgramacionTrabajadores" runat="server" AlternateText="Trabajadores" ImageUrl="../../imagenes/ibtnProgramacion.gif"
													style="Z-INDEX: 0"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" style="Z-INDEX: 0"></asp:imagebutton></TD>
											<TD><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif" style="Z-INDEX: 0"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="1%">
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" PageSize="6"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False"
										AllowSorting="True" Height="1px" Width="100%">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDocumentodeRef" SortExpression="NroDocumentodeRef" HeaderText="NRO DOC. REF.">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroProveedor" SortExpression="NroProveedor" HeaderText="NRO R.U.C">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocialProveedor" SortExpression="RazonSocialProveedor" HeaderText="RAZON SOCIAL">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreNave" SortExpression="NombreNave" HeaderText="Nombre Nave">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="9%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD style="BORDER-BOTTOM: gainsboro 1px solid" colSpan="2" align="center">
																<asp:Label id="LBLFECHA" runat="server" CssClass="HeaderGrilla" Height="14px" BorderStyle="None">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD width="50%" noWrap align="center">
																<asp:Label id="Label12" runat="server" CssClass="HeaderGrilla" Height="14px" BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" width="50%" noWrap align="center">
																<asp:Label id="Label22" runat="server" CssClass="HeaderGrilla" Height="9px" BorderStyle="None">TERMINO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD noWrap align="center">
																<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" noWrap align="center">
																<asp:Label id="lblFechaTermino" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="9%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left"
														height="100%">
														<TR>
															<TD style="BORDER-BOTTOM: gainsboro 1px solid" colSpan="2" align="center">
																<asp:Label id="LBLHORA" runat="server" CssClass="HeaderGrilla" Height="14px" BorderStyle="None">HORA</asp:Label></TD>
														</TR>
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="Label1" runat="server" CssClass="HeaderGrilla" Height="14px" BorderStyle="None">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" width="50%" align="center">
																<asp:Label id="Label2" runat="server" CssClass="HeaderGrilla" Height="9px" BorderStyle="None">TERMINO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD align="center">
																<asp:Label id="lblHInicio" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" align="center">
																<asp:Label id="lblhFin" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="NroTrab" HeaderText="NRO TRAB.">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f0f0f0"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="55"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" colSpan="4"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hCodigo1" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo1"
										runat="server"><INPUT id="hCodigo2" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo2"
										runat="server"><INPUT id="hNroRuc" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo2"
										runat="server"><INPUT id="hRazonSocial" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo2"
										runat="server"><INPUT id="hFInicio" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo2"
										runat="server"><INPUT id="hFTermino" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo2"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hModo" size="1" type="hidden"
										name="hCodigo2" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hidUsuarioRegistro" size="1" type="hidden"
										name="hCodigo2" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal></SCRIPT>
	</body>
</HTML>
