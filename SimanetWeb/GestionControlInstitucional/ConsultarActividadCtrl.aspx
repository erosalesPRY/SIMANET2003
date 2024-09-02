<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarActividadCtrl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.ConsultarActividadCtrl" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colspan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colspan="1"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Control Institucional ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Actividades de Control</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE ACTIVIDADES DE CONTROL</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" width="780">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0" align="center" style="WIDTH: 86px">
															<asp:imagebutton id="ibtn_filtrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0" style="WIDTH: 111px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../imagenes/filtroporseleccion.jpg" runat="server"></TD>
														<TD bgColor="#f0f0f0" style="WIDTH: 20px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../imagenes/spacer.gif" width="285" style="WIDTH: 285px; HEIGHT: 8px"></TD>
														<TD bgColor="#f0f0f0" align="center"></TD>
														<TD bgColor="#f0f0f0" align="center"></TD>
														<TD bgColor="#f0f0f0" align="right">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" ShowFooter="True" PageSize="7" AllowPaging="True" AllowSorting="True"
													AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px" align="center" DataKeyField="IdActividadCtrl"
													CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle Font-Names="Arial" CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle Font-Names="Arial" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdActividadCtrl" SortExpression="IdAccionCtrlPosterior" 
 HeaderText="IdActividadCtrl">
															<HeaderStyle HorizontalAlign="Center"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<FooterStyle HorizontalAlign="Center"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="NRO"></asp:BoundColumn>
														<asp:BoundColumn DataField="CODIGO" SortExpression="CODIGO" HeaderText="CODIGO">
															<HeaderStyle Width="100px"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Denominacion" SortExpression="Denominacion" HeaderText="DENOMINACI&#211;N">
															<HeaderStyle Width="250px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UNIDADMEDIDA" SortExpression="UNIDADMEDIDA" HeaderText="UNID.">
															<HeaderStyle Width="100px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Meta1erTrimestre" SortExpression="Meta1erTrimestre" HeaderText="META 1ER TRIM"></asp:BoundColumn>
														<asp:BoundColumn DataField="Meta2doTrimestre" SortExpression="Meta2doTrimestre" HeaderText="META 2DO TRIM"></asp:BoundColumn>
														<asp:BoundColumn DataField="Meta3erTrimestre" SortExpression="Meta3erTrimestre" HeaderText="META 3ER TRIM"></asp:BoundColumn>
														<asp:BoundColumn DataField="Meta4toTrimestre" SortExpression="Meta4toTrimestre" HeaderText="META 4TO TRIM"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="E"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="F"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="M"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="A"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="M"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="J"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="J"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="A"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="S"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="O"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="N"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="D"></asp:BoundColumn>
														<mbrsc:RowSelectorColumn Visible="False" HeaderText="SEL." SelectionMode="Single">
															<HeaderStyle Width="15px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</mbrsc:RowSelectorColumn>
													</Columns>
													<PagerStyle Font-Names="Arial" HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<P></P>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 16px" type="hidden" size="1" name="hCodigo" runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
