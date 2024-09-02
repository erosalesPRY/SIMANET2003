<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarPlanEstrategicoAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico.AdministrarPlanEstrategicoAccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPlanEstrategicoAccion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" bgColor="#f0f0f0"
													border="0">
													<TR>
													</TR>
													<TR>
														<TD bgColor="#ffffff" colSpan="10">
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="2" borderColor="#ffffff">
																<TR>
																	<TD style="WIDTH: 62px; HEIGHT: 17px">
																		<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="128px">PLAN ESTRATEGICO:</asp:Label></TD>
																	<TD style="WIDTH: 62px; HEIGHT: 17px"><asp:label id="lblPlanBase" runat="server" CssClass="TituloPrincipalBlanco" Width="70px" ForeColor="Navy"></asp:label></TD>
																	<TD style="HEIGHT: 17px"><asp:label id="lblNombrePlanBase" runat="server" CssClass="TituloPrincipalBlanco" Height="2px"
																			Width="100%" ForeColor="Navy"></asp:label></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 139px" width="139">
																		<asp:Label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" Width="128px" ForeColor="Navy">OBJETIVO GENERAL:</asp:Label></TD>
																	<TD width="100"><asp:label id="lblObjGral" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"></asp:label></TD>
																	<TD><asp:label id="lblNombreObjGral" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
																			Width="100%"></asp:label></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 139px" width="139">
																		<asp:Label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Width="136px" ForeColor="Navy">OBJETIVO ESPECIFICO:</asp:Label></TD>
																	<TD width="100"><asp:label id="lblObjEsp" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"></asp:label></TD>
																	<TD><asp:label id="lblNombreObjEsp" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
																			Width="100%"></asp:label></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 28px"></TD>
														<TD colSpan="4">
															<asp:Label id="Label5" runat="server" Width="136px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">ACCION</asp:Label></TD>
														<TD width="100%"></TD>
														<TD style="WIDTH: 100px"></TD>
														<TD style="WIDTH: 186px"></TD>
														<TD></TD>
														<TD></TD>
														<TD align="right" width="4"></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD style="WIDTH: 28px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroporseleccion.jpg" title="Descripcion"></TD>
														<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD style="WIDTH: 2px">
															<asp:label id="Label4" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
														<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
																title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
																type="text" size="20" name="txtBuscar"></TD>
														<td style="WIDTH: 100px"><A class="normaldetalle" href="javascript:history.go(0)">Refrescar</A></td>
														<TD style="WIDTH: 186px"></TD>
														<TD>
															<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD>
															<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" AllowPaging="True" AllowSorting="True"
													AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="7">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CODIGO" SortExpression="CODIGO" HeaderText="CODIGO">
															<HeaderStyle Width="3%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
															<HeaderStyle Width="60%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CO" SortExpression="CO" HeaderText="CO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="Indicadores">
															<ItemTemplate>
																<cc1:datagridweb id="gridIndicadores" runat="server" Width="100%" PageSize="7" RowHighlightColor="#E0E0E0"
																	AutoGenerateColumns="False" CellPadding="0" ShowHeader="False">
																	<PagerStyle CssClass="PagerGrilla" Wrap="False" Mode="NumericPages"></PagerStyle>
																	<AlternatingItemStyle Wrap="False" CssClass="Alternateitemgrilla"></AlternatingItemStyle>
																	<EditItemStyle Wrap="False"></EditItemStyle>
																	<FooterStyle Wrap="False" CssClass="FooterGrilla"></FooterStyle>
																	<SelectedItemStyle Wrap="False"></SelectedItemStyle>
																	<ItemStyle Wrap="False" CssClass="ItemGrilla"></ItemStyle>
																	<Columns>
																		<asp:BoundColumn DataField="DESCRIPCION" HeaderText="INDICADOR">
																			<HeaderStyle Width="40%"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn HeaderText="Total">
																			<HeaderStyle Width="15%"></HeaderStyle>
																			<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																	<HeaderStyle Wrap="False" Height="26px" CssClass="HeaderGrilla"></HeaderStyle>
																</cc1:datagridweb>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
										</TR>
										<TR>
											<TD align="right"><INPUT id="hCodigo" type="hidden" size="1" runat="server" NAME="hCodigo"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF"></TD>
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
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
