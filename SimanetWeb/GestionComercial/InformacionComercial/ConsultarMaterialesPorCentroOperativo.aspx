<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarMaterialesPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.ConsultarMaterialesPorCentroOperativo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarMaterialesPorCentroOperativo</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header style="Z-INDEX: 0" id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu style="Z-INDEX: 0" id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR>
								<TD class="Commands" colSpan="3">&nbsp;
									<asp:label id="lblRuta_Pagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Informacion Comercial > </asp:label><asp:label id="lblPage" runat="server"> Consultar materiales por centro operativo</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">MATERIALES POR CENTRO OPERATIVO</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE id="Table3" class="normal" border="0" cellSpacing="0" cellPadding="0" width="550">
										<TR>
											<TD width="100%" colSpan="3" align="right">
												<TABLE id="Table4" class="tabla" border="0" cellSpacing="0" cellPadding="0" width="620"
													bgColor="#f5f5f5" align="center">
													<TR bgColor="#ffffff">
														<TD style="HEIGHT: 8px" class="combos" width="121"><IMG src="../../imagenes/TitFiltros.gif" width="82" height="14"></TD>
														<TD style="WIDTH: 169px; HEIGHT: 8px" class="combos" width="169"></TD>
														<TD style="WIDTH: 170px; HEIGHT: 8px" class="combos" width="170"></TD>
														<TD style="HEIGHT: 8px" class="combos" width="171" align="right"></TD>
													</TR>
													<TR>
														<TD></TD>
														<TD><asp:label id="lblFechaInicio" runat="server" CssClass="normal">Fecha de Inicio</asp:label><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" NullableLabelText="Seleccione una fecha:"
																AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" Width="72px" GoToTodayText="Hoy :"
																MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" VisibleDate="2013-05-22" SelectedDate="2013-05-22">
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
														<TD class="Small"><asp:label id="lblFechaFin" runat="server" CssClass="normal">Fecha de Fin</asp:label><ew:calendarpopup id="CalFechaFin" runat="server" CssClass="normaldetalle" NullableLabelText="Seleccione una fecha:"
																AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" Width="72px" GoToTodayText="Hoy :"
																MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" VisibleDate="2013-05-23" SelectedDate="2013-05-23">
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
														<TD><asp:imagebutton id="ibtnConsultar" runat="server" ImageUrl="../../imagenes/ibtnConsultarCliente.gif"
																ImageAlign="Left"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 2px" class="SmallFont" bgColor="#f5f5f5" width="100%" colSpan="3"
												align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" AllowSorting="True"
													AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="4">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="FEC_EMISION" SortExpression="FEC_EMISION" HeaderText="EMISION">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MATERIAL" SortExpression="MATERIAL" HeaderText="MATERIAL">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UND_MED" SortExpression="UND_MED" HeaderText="UM">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="GRAVADO">
															<HeaderStyle Width="15%"></HeaderStyle>
															<HeaderTemplate>
																<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																	<TR>
																		<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																			align="center" width="100%" colSpan="4">
																			<asp:Label id="Label2" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="93" BorderStyle="None">STOCK GRAVADO</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD align="center" width="25%">
																			<asp:Label id="lblStkGrv" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="102" BorderStyle="None">MONTO</asp:Label></TD>
																		<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																			<asp:Label id="lblPrcPmdSolGrv" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PROM. PRECIO (S/.)</asp:Label></TD>
																	</TR>
																</TABLE>
															</HeaderTemplate>
															<ItemTemplate>
																<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
																	border="0">
																	<TR>
																		<TD align="right" width="25%">
																			<asp:Label id="STOCK_GRAVADO" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="268"
																				BorderStyle="None">Label</asp:Label></TD>
																		<TD align="right" width="25%">
																			<asp:Label id="PRC_PMD_SOLES_GRA" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="289"
																				BorderStyle="None">Label</asp:Label></TD>
																	</TR>
																</TABLE>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="EXONERADO">
															<HeaderStyle Width="15%"></HeaderStyle>
															<HeaderTemplate>
																<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																	<TR>
																		<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																			align="center" width="100%" colSpan="4">
																			<asp:Label id="Label1" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="93" BorderStyle="None">STOCK EXONERADO</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD align="center" width="25%">
																			<asp:Label id="lblStkExo" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="102" BorderStyle="None">MONTO</asp:Label></TD>
																		<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																			<asp:Label id="lblPrcPmdSolExo" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PROM. PRECIO (S/.)</asp:Label></TD>
																	</TR>
																</TABLE>
															</HeaderTemplate>
															<ItemTemplate>
																<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
																	border="0">
																	<TR>
																		<TD align="right" width="25%">
																			<asp:Label id="STOCK_EXONERADO" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="268"
																				BorderStyle="None">Label</asp:Label></TD>
																		<TD align="right" width="25%">
																			<asp:Label id="PRC_PMD_SOLES_EXO" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="289"
																				BorderStyle="None">Label</asp:Label></TD>
																	</TR>
																</TABLE>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="ULTIMA COMPRA">
															<HeaderStyle Width="15%"></HeaderStyle>
															<HeaderTemplate>
																<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																	<TR>
																		<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																			align="center" width="100%" colSpan="4">
																			<asp:Label id="Label3" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="93" BorderStyle="None">ULTIMA COMPRA</asp:Label></TD>
																	</TR>
																	<TR>
																		<TD align="center" width="25%">
																			<asp:Label id="lblPrcUltCmpSol" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="102"
																				BorderStyle="None">PRECIO (S/.)</asp:Label></TD>
																		<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																			<asp:Label id="lblFchUltCmp" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FECHA</asp:Label></TD>
																	</TR>
																</TABLE>
															</HeaderTemplate>
															<ItemTemplate>
																<TABLE id="Table10" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
																	border="0">
																	<TR>
																		<TD align="right" width="25%">
																			<asp:Label id="PRC_ULT_COMPRA_SOLES" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="268"
																				BorderStyle="None">Label</asp:Label></TD>
																		<TD align="right" width="25%">
																			<asp:Label id="FEC_ULT_COMPRA" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="289"
																				BorderStyle="None">Label</asp:Label></TD>
																	</TR>
																</TABLE>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="FEC_ULT_SALIDA" SortExpression="FEC_ULT_SALIDA" HeaderText="ULTIMA SALIDA">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UBICACION" SortExpression="UBICACION" HeaderText="UBICACION">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="3" align="left"><IMG style="CURSOR: hand" id="Img1" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
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
