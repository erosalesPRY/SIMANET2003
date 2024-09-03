<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarInduccionSI.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarInduccionSI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación Trabajadores Contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración evaluación inducción></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 1097px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="1097">
							<TR>
								<TD align="left">
									<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
										align="left">
										<TR>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../imagenes/filtroPorSeleccion.JPG"></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ToolTip="Eliminar Filtro.."
													ImageUrl="../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
											<TD width="100%" align="left">
												<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="300" align="left">
													<TR>
														<TD></TD>
														<TD width="300">
															<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="AdministrarFichaInduccion.aspx">HyperLink</asp:HyperLink></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
											<TD></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"
													Visible="False"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="1%" align="center">
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" PageSize="15"
										ShowFooter="True" AllowPaging="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" Height="1px" Width="100%">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="30px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDNI" SortExpression="NroDNI" HeaderText="NRO DNI">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombres" SortExpression="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="5%"></HeaderStyle>
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
																<asp:Label id="Label22" runat="server" CssClass="HeaderGrilla" Height="9px" BorderStyle="None">VENCIMIENTO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
														<TR>
															<TD noWrap align="center">
																<asp:Label id="lblFechaInicio" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: gainsboro 1px solid" noWrap align="center">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Disponible" HeaderText="DISPONIBLE">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Aprobado" HeaderText="APROBADO">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="55"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hGridPaginaSort" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 16px" id="hGridPagina" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: block" align="center"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
