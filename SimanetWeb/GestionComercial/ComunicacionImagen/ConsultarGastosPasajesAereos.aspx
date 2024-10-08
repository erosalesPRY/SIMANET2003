<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarGastosPasajesAereos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.ConsultarGastosPasajesAereos" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
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
					<TD colSpan="3" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3" vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gesti�n Comercial > Comunicaci�n e Imagen > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Gastos de Pasajes Aereos</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE GASTOS DE PASAJES AEREOS</asp:label></TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="450" bgColor="#f5f5f5"
										border="0">
										<TR bgColor="#ffffff">
											<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
											<TD class="combos"></TD>
											<TD class="combos"></TD>
											<TD class="combos"></TD>
											<TD class="combos"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD class="SmallFont"><asp:label id="lblFechaInicio" runat="server" CssClass="normal">Fecha de Inicio</asp:label></TD>
											<TD class="SmallFont"><asp:label id="lblFechaFin" runat="server" CssClass="normal">Fecha de Fin</asp:label></TD>
											<TD class="SmallFont"></TD>
											<TD class="SmallFont"></TD>
										</TR>
										<TR>
											<TD class="TitFiltros">&nbsp;</TD>
											<TD class="combos"><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="combos" AllowArbitraryText="False"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif">
													<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
													<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></WeekdayStyle>
													<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="#FF8A00"></MonthHeaderStyle>
													<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
														BackColor="AntiqueWhite"></OffMonthStyle>
													<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></GoToTodayStyle>
													<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="LightGoldenrodYellow"></TodayDayStyle>
													<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="Gray"></DayHeaderStyle>
													<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="LightGray"></WeekendStyle>
													<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="#FF8A00"></SelectedDateStyle>
													<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></ClearDateStyle>
													<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></HolidayStyle>
												</ew:calendarpopup></TD>
											<TD class="combos"><ew:calendarpopup id="CalFechaFin" runat="server" CssClass="combos" AllowArbitraryText="False" ShowGoToToday="True"
													ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif">
													<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
													<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></WeekdayStyle>
													<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="#FF8A00"></MonthHeaderStyle>
													<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
														BackColor="AntiqueWhite"></OffMonthStyle>
													<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></GoToTodayStyle>
													<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="LightGoldenrodYellow"></TodayDayStyle>
													<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="Gray"></DayHeaderStyle>
													<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="LightGray"></WeekendStyle>
													<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="#FF8A00"></SelectedDateStyle>
													<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></ClearDateStyle>
													<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
														BackColor="White"></HolidayStyle>
												</ew:calendarpopup></TD>
											<TD class="combos"><cc2:comparedomvalidator id="cvFechas" runat="server" ControlToValidate="CalFechaInicio" ControlToCompare="CalFechaFin"
													Operator="LessThanEqual">*</cc2:comparedomvalidator></TD>
											<TD class="combos">
												<P align="right"><asp:imagebutton id="ibtnConsultar" runat="server" CssClass="boton" ImageUrl="../../imagenes/consultar.gif"></asp:imagebutton>&nbsp;&nbsp;
												</P>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" colSpan="3" vAlign="top">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selecci�n"
																src="../../imagenes/filtroPorSeleccion.JPG"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="450"></TD>
														<TD bgColor="#f0f0f0">
															<P align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></P>
														</TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" ShowFooter="True"
													AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
													RowPositionEnabled="False" PageSize="7">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
														<asp:BoundColumn DataField="NombreCentroOperativo" SortExpression="NombreCentroOperativo" HeaderText="CO"></asp:BoundColumn>
														<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO"></asp:BoundColumn>
														<asp:BoundColumn DataField="NombrePersonal" SortExpression="NombrePersonal" HeaderText="PERSONAL">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NombreAerolinea" SortExpression="NombreAerolinea" HeaderText="AEROLINEA">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Ruta" SortExpression="Ruta" HeaderText="RUTA"></asp:BoundColumn>
														<asp:BoundColumn DataField="NombreCentroCosto" SortExpression="NombreCentroCosto" HeaderText="CC / OT">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO" DataFormatString="{0:###,##0.00}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA"></asp:BoundColumn>
														<asp:BoundColumn DataField="FechaGasto" SortExpression="FechaGasto" HeaderText="FECHA GASTO" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="3" vAlign="top">
												<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160"></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<cc1:datagridweb id="dgResumen" runat="server" CssClass="HeaderGrilla" Width="200px" PageSize="3"
													RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA"></asp:BoundColumn>
														<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO TOTAL" DataFormatString="{0:###,##0.00}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<cc2:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3" vAlign="top"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
