<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarVentasReales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.AdministrarVentasReales" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script language="JavaScript">
		function AbriExcel()
		{
			window.open("AdministrarVentasRealesExcel.aspx","","dependent:yes, Width=790,Height=540,scrollbars=yes, statusbar=yes, resizable=yes; top=0,left=0");
		}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Ventas Colocadas</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> ADMINISTRACIÓN DE VENTAS COLOCADAS</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD class="SmallFont"><asp:label id="lblCentroOperativo" runat="server" CssClass="normal">Centro de Operaciones</asp:label></TD>
											<TD class="SmallFont"><asp:label id="lblAño" runat="server" CssClass="normal">Año</asp:label></TD>
										</TR>
										<TR>
											<TD class="TitFiltros">&nbsp;</TD>
											<TD class="combos"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normal" Width="136px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="combos"><asp:dropdownlist id="ddlbAño" runat="server" CssClass="normal" Width="70px" AutoPostBack="True" ForeColor="Black"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table5" cellSpacing="0" cellPadding="0" width="550" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="WIDTH: 67px; HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="WIDTH: 69px; HEIGHT: 18px" bgColor="#f0f0f0"><asp:imagebutton id="IbtnCierre" runat="server" ForeColor="White" ToolTip="Hacer Click para Grabar Informe al Directorio"
																BorderColor="White" BackColor="White" ImageAlign="Top" ImageUrl="../../imagenes/tit_csesion.gif" Visible="False"></asp:imagebutton></TD>
														<TD style="WIDTH: 1px; HEIGHT: 18px" bgColor="#f0f0f0"></TD>
														<TD style="HEIGHT: 18px" bgColor="#f0f0f0"><asp:image id="BtnActivado" runat="server" ImageUrl="../../imagenes/tit_csesionVerde.gif" Visible="False"></asp:image></TD>
														<TD style="HEIGHT: 18px" align="right" width="4"></TD>
													</TR>
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltro" runat="server" Width="74px" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ToolTip="Eliminar Filtro.." ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
														<TD style="WIDTH: 67px" bgColor="#f0f0f0"><asp:imagebutton id="ibtnExportar" runat="server" ImageUrl="../../imagenes\ibtnIconoExcel.jpg"></asp:imagebutton><asp:imagebutton id="Imagebutton1" runat="server" Width="73px" Height="6px"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnProyectosEnCartera" runat="server" ImageUrl="../../imagenes/ibtnProyectosEnCartera.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 69px" bgColor="#f0f0f0"><asp:imagebutton id="ibtnObservaciones" runat="server" ImageUrl="../../imagenes/ibtnObservaciones.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 1px" bgColor="#f0f0f0">
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" DataKeyField="IDVENTAREAL"
													ShowFooter="True" RowPositionEnabled="False" AutoGenerateColumns="False" AllowSorting="True"
													AllowPaging="True" RowHighlightColor="#E0E0E0">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="Nro" FooterText="Total:"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDVENTAREAL"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="CENTROOPERATIVO" SortExpression="CENTROOPERATIVO" HeaderText="CO"></asp:BoundColumn>
														<asp:BoundColumn DataField="LINEANEGOCIO" SortExpression="LINEANEGOCIO" HeaderText="LN"></asp:BoundColumn>
														<asp:BoundColumn DataField="SECTOR" SortExpression="SECTOR" HeaderText="SECTOR"></asp:BoundColumn>
														<asp:BoundColumn DataField="RAZONSOCIAL" SortExpression="RAZONSOCIAL" HeaderText="CLIENTE">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="PROYECTO" FooterText="Monto Total en Soles:">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MONTOPRECIOVENTASOLES" SortExpression="MONTOPRECIOVENTASOLES" HeaderText="MONTO EN SOLES"
															DataFormatString="{0:###,##0.00}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FECHA" SortExpression="FECHA" HeaderText="FECHA">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><BR>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3"><asp:datagrid id="gridReporte" runat="server" CssClass="HeaderGrilla" Width="1px" Height="1px"
													AutoGenerateColumns="False" PageSize="1">
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<Columns>
														<asp:BoundColumn DataField="IDVENTAREAL" HeaderText="IDVENTAREAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="IDPROYECTOTRABAJO" HeaderText="IDPROYECTOTRABAJO"></asp:BoundColumn>
														<asp:BoundColumn DataField="CENTROOPERATIVO" HeaderText="CENTROOPERATIVO"></asp:BoundColumn>
														<asp:BoundColumn DataField="LINEANEGOCIO" HeaderText="LINEANEGOCIO"></asp:BoundColumn>
														<asp:BoundColumn DataField="SECTOR" HeaderText="SECTOR"></asp:BoundColumn>
														<asp:BoundColumn DataField="RAZONSOCIAL" HeaderText="RAZONSOCIAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION"></asp:BoundColumn>
														<asp:BoundColumn DataField="MONTOPRECIOVENTASOLES" HeaderText="MONTOPRECIOVENTASOLES"></asp:BoundColumn>
														<asp:BoundColumn DataField="BUENAPRO" HeaderText="BUENAPRO"></asp:BoundColumn>
														<asp:BoundColumn DataField="PROMOTOR" HeaderText="PROMOTOR"></asp:BoundColumn>
														<asp:BoundColumn DataField="ESTADO" HeaderText="ESTADO"></asp:BoundColumn>
														<asp:BoundColumn DataField="INICIO CONTRACTUAL" HeaderText="INICIO CONTRACTUAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="FIN CONTRACTUAL" HeaderText="FIN CONTRACTUAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="INICIO REAL" HeaderText="INICIO REAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="FIN REAL" HeaderText="FIN REAL"></asp:BoundColumn>
														<asp:BoundColumn DataField="UTILIDAD" HeaderText="UTILIDAD"></asp:BoundColumn>
													</Columns>
													<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</asp:datagrid></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
									<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 31px" align="center"></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
						</TABLE>
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
