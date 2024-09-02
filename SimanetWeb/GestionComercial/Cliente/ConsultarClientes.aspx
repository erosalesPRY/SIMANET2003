<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarClientes.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Cliente.ConsultarClientes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarClientes</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Clientes > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Clientes</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE CLIENTES</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hGridPagina" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server"><INPUT id="hopcion" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" value="1"
										name="hGridPagina" runat="server"><INPUT id="hRangoFecha" style="WIDTH: 20px; HEIGHT: 22px" type="hidden" size="1" value="-1"
										name="hGridPagina" runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="780" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="75"></TD>
											<TD class="combos"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD align="left" vAlign="top">
												<asp:label id="lblPais" runat="server" CssClass="normal" Width="50px">País</asp:label>
												<asp:dropdownlist id="ddlbPais" runat="server" CssClass="normal" Width="220px" ForeColor="Black"></asp:dropdownlist><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="7"></TD>
											<TD width="300" vAlign="middle">
												<asp:label id="lblActividad" runat="server" CssClass="normal" Width="50px">Actividad</asp:label>
												<asp:dropdownlist id="ddlbActividad" runat="server" CssClass="normal" Width="235px" ForeColor="Black"></asp:dropdownlist></TD>
											<TD vAlign="top">
												<asp:label id="lblProducto" runat="server" CssClass="normal" Width="50px">Producto</asp:label>
												<asp:dropdownlist id="ddlbProducto" runat="server" CssClass="normal" Width="280px" ForeColor="Black"></asp:dropdownlist></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left">
												<asp:label id="lblFechaInicio" runat="server" CssClass="normal" Width="90px">Fecha de Inicio</asp:label>
												<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="72px" ClearDateText="Limpiar Fecha"
													AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
													PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
													MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" Nullable="True">
													<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
													<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></WeekdayStyle>
													<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="Navy"></MonthHeaderStyle>
													<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="White"></OffMonthStyle>
													<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
														BackColor="#F0F0F0"></GoToTodayStyle>
													<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
														ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
													<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="#335EB4"></DayHeaderStyle>
													<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
														ForeColor="IndianRed" BackColor="White"></WeekendStyle>
													<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="CornflowerBlue"></SelectedDateStyle>
													<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></ClearDateStyle>
													<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></HolidayStyle>
												</ew:calendarpopup></TD>
											<TD vAlign="top" width="300">
												<asp:label id="lblFechaFin" runat="server" CssClass="normal" Width="80px">Fecha de Fin</asp:label>
												<ew:calendarpopup id="CalFechaFin" runat="server" CssClass="normaldetalle" Width="72px" ClearDateText="Limpiar Fecha"
													AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
													PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
													MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" Nullable="True">
													<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
													<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></WeekdayStyle>
													<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="Navy"></MonthHeaderStyle>
													<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="White"></OffMonthStyle>
													<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
														BackColor="#F0F0F0"></GoToTodayStyle>
													<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
														ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
													<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="#335EB4"></DayHeaderStyle>
													<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
														ForeColor="IndianRed" BackColor="White"></WeekendStyle>
													<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
														BackColor="CornflowerBlue"></SelectedDateStyle>
													<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></ClearDateStyle>
													<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></HolidayStyle>
												</ew:calendarpopup></TD>
											<TD vAlign="top">
												<asp:checkbox id="ckbExclusion" runat="server" CssClass="normal" Text="Exclusión" TextAlign="Left"
													Visible="False"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left">
												<asp:label id="lblNombre" runat="server" CssClass="normal" Width="80px">Razón Social</asp:label>
												<asp:textbox id="txtRazonSocial" runat="server"></asp:textbox><BR>
											</TD>
											<TD vAlign="middle" width="300">
												<asp:label id="lblAstillero" runat="server" CssClass="normal">Astillero</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="7">
												<asp:checkbox id="ckbSC" runat="server" CssClass="normal" Text="SC" TextAlign="Left" ToolTip="Sima - Callao"></asp:checkbox>
												<asp:checkbox id="ckbSCH" runat="server" CssClass="normal" Text="SCH" TextAlign="Left" ToolTip="Sima - Chimbote"></asp:checkbox>
												<asp:checkbox id="ckbSI" runat="server" CssClass="normal" Text="SI" TextAlign="Left" ToolTip="Sima - Iquitos"></asp:checkbox></TD>
											<TD vAlign="middle">
												<asp:label id="lblLineaNegocio" runat="server" CssClass="normal">Linea Negocio</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="10">
												<asp:checkbox id="ckbCN" runat="server" CssClass="normal" Text="CN" TextAlign="Left" ToolTip="Construcciones Navales"></asp:checkbox>
												<asp:checkbox id="ckbRN" runat="server" CssClass="normal" Text="RN" TextAlign="Left" ToolTip="Reparaciones Navales"></asp:checkbox>
												<asp:checkbox id="ckbAE" runat="server" CssClass="normal" Text="AE" TextAlign="Left" ToolTip="Armas y Electronica"></asp:checkbox>
												<asp:checkbox id="ckbMM" runat="server" CssClass="normal" Text="MM" TextAlign="Left" ToolTip="Metal Mecanica"></asp:checkbox>
												<asp:checkbox id="ckbSV" runat="server" CssClass="normal" Text="SV" TextAlign="Left" ToolTip="Servicios"></asp:checkbox></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left">&nbsp;
												<asp:imagebutton id="ibtnConsultar" runat="server" CssClass="boton" ImageUrl="../../imagenes/ibtnConsultarCliente.gif"
													ImageAlign="Left"></asp:imagebutton>
												<asp:imagebutton id="ibtnEliminarFiltroConsulta" runat="server" CssClass="boton" ImageUrl="../../imagenes/btnEliminarConsulta.jpg"
													ImageAlign="Left"></asp:imagebutton></TD>
											<TD vAlign="top" width="300">
												<asp:imagebutton id="ibtnConsultarTodosClientes" runat="server" CssClass="boton" ImageUrl="../../imagenes/ibtnConsultarTodosClientes.gif"
													ImageAlign="Left" Visible="False"></asp:imagebutton>
												<asp:checkbox id="chkTipoComercial" runat="server" CssClass="normal" Width="128px" Text="Clientes Comerciales"
													AutoPostBack="True"></asp:checkbox></TD>
											<TD vAlign="top"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="600" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG" runat="server"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD align="right" bgColor="#f0f0f0">&nbsp;&nbsp; <IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="420">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" AllowSorting="True"
													AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle HorizontalAlign="Left" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="IDCLIENTE" SortExpression="IdCliente" HeaderText="IDCLIENTE"></asp:BoundColumn>
														<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="RAZON SOCIAL">
															<HeaderStyle Width="50%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Utilidad" SortExpression="Utilidad" HeaderText="UTILIDAD">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Clasificacion" SortExpression="Clasificacion" HeaderText="CLASIFICACION">
															<HeaderStyle Width="15%"></HeaderStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3">&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
										<TR>
											<TD align="right" colSpan="3">
												<asp:imagebutton id="ibtnCuadroSatis" runat="server" ImageUrl="../../imagenes/btnCuadroSatisfaccion.gif"
													Visible="False"></asp:imagebutton>
												<asp:label id="lblCantClientes" runat="server" Visible="False">Cantidad Clientes</asp:label><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="10">
												<asp:textbox id="txtCantClientes" runat="server" Width="100px" ReadOnly="True" Visible="False"></asp:textbox>
											</TD>
										</TR>
									</TABLE>
									<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 31px" align="center"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 18px" align="center"></TD>
							</TR>
						</TABLE>
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
				</TR>
			</TABLE>
		</form>
		<P align="left"></P>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
