<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarPresentesOtorgadosPorTipoPersona.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarPresentesOtorgadosPorTipoPersona" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_snapToGrid" content="False">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Presentes Otorgados</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE PRESENTES OTORGADOS</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hNombreClientePersonal" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="hNombreClientePersonal" runat="server"><INPUT id="hIdTablaOrigen" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdTablaOrigen"
										runat="server"><INPUT id="hIdOrigen" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdOrigen"
										runat="server"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD class="SmallFont">
												<asp:label id="lblTipoPersona" runat="server" CssClass="normal">Tipo Persona</asp:label></TD>
										</TR>
										<TR>
											<TD class="TitFiltros">&nbsp;</TD>
											<TD class="combos">
												<asp:dropdownlist id="ddlbTipoPersona" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0">
															<asp:ImageButton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:ImageButton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="330"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnImprimir" runat="server" CausesValidation="False" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0">
															<asp:ImageButton id="ibtnPresentesFamiliares" runat="server" ImageUrl="../../imagenes/btnPresenteFamiliares.gif"></asp:ImageButton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" Width="780px" DESIGNTIMEDRAGDROP="68" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
													ShowFooter="True" CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDLISTAPROTOCOLAR" SortExpression="IDLISTAPROTOCOLAR"></asp:BoundColumn>
														<asp:BoundColumn DataField="NombreCentroOperativo" SortExpression="NombreCentroOperativo" HeaderText="CO"></asp:BoundColumn>
														<asp:BoundColumn DataField="Cargo" SortExpression="Cargo" HeaderText="CARGO">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Grado" SortExpression="Grado" HeaderText="GRADO">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NombreClientePersonal" SortExpression="NombreClientePersonal" HeaderText="APELLIDOS Y NOMBRES">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Telefono" SortExpression="Telefono" HeaderText="TELEFONO"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="NombreTipoPersona" SortExpression="NombreTipoPersona"
															HeaderText="TIPO PERSONA"></asp:BoundColumn>
														<asp:BoundColumn DataField="NombreArticulo" SortExpression="NombreArticulo" HeaderText="PRESENTE OTORGADO">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CantidadAtendida" SortExpression="CantidadAtendida" HeaderText="CANTIDAD ENTREGADA"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDTABLAORIGEN"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDORIGEN"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDCODIGO"></asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
													Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" height="19" alt=""
													src="../../imagenes/atras.gif" width="84"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
				<TR bgColor="#5891ae" align="center">
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
