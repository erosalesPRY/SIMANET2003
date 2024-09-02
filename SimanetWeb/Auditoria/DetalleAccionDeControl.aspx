<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleAccionDeControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.DetalleAccionDeControl" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<tr>
								<td class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de Acciones de Control </asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE class="tabla" id="Table4" cellSpacing="0" cellPadding="0" width="300" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD class="SmallFont" height="14"><asp:label id="Label1" runat="server" CssClass="normal">Periodo</asp:label></TD>
											<TD class="SmallFont" height="14"><asp:label id="lblAccion" runat="server" CssClass="normal">Acci&oacute;n</asp:label></TD>
										</TR>
										<TR>
											<TD class="combos"><asp:dropdownlist id="ddlbPeriodoFiltro" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="combos"><asp:dropdownlist id="ddlbAccion" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="tDetalle" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780"
										align="center" border="0" runat="server">
										<TR>
											<TD>
												<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="500" align="center" border="1">
													<TR>
														<TD class="normal" align="center" colSpan="6"><asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label>
															<TABLE id="Table8" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
																<TR>
																	<TD bgColor="#000080" colSpan="11">
																		<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">ACCIONES DE CONTROL </asp:label></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4" style="WIDTH: 88px">
																		<asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco">Codigo:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:textbox id="txtCodigo" runat="server" CssClass="normaldetalle" MaxLength="15" Width="95px"></asp:textbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvCodigo" runat="server" Visible="False" ControlToValidate="txtCodigo">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco">Periodo:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normaldetalle" Width="95px"></asp:dropdownlist></TD>
																	<TD style="WIDTH: 3px">
																		<cc1:requireddomvalidator id="rfvPeriodo" runat="server" ControlToValidate="ddlbPeriodo" InitialValue="%">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4" style="WIDTH: 70px">
																		<asp:label id="lblUnidadMedida" runat="server" CssClass="TextoBlanco" Width="72px">Unidad de Medida:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<asp:dropdownlist id="ddlbUnidadMedida" runat="server" CssClass="normaldetalle" Width="150px"></asp:dropdownlist></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvUnidadMedida" runat="server" ControlToValidate="ddlbUnidadMedida" InitialValue="%">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="lblPorcentajeAvance" runat="server" CssClass="TextoBlanco">% de Avance:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<ew:numericbox id="txtPorcentajeAvance" runat="server" CssClass="normaldetalle" MaxLength="5" Width="30px"
																			PositiveNumber="True" Enabled="False" TextAlign="Right"></ew:numericbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvPorcentajeAvance" runat="server" ControlToValidate="txtPorcentajeAvance">*</cc1:requireddomvalidator></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4" style="WIDTH: 88px">
																		<asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco">Denominaci&oacute;n:</asp:label></TD>
																	<TD colSpan="4" bgColor="#dddddd">
																		<asp:textbox id="txtDenominacion" runat="server" CssClass="normaldetalle" Height="48px" MaxLength="1500"
																			Width="256px" TextMode="MultiLine"></asp:textbox></TD>
																	<TD style="WIDTH: 3px">
																		<cc1:requireddomvalidator id="rfvDenominacion" runat="server" Height="16px" ControlToValidate="txtDenominacion">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4" style="WIDTH: 70px">
																		<asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco">Observaci&oacute;n:</asp:label></TD>
																	<TD colSpan="4" bgColor="#dddddd">
																		<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" MaxLength="1500"
																			Width="256px" TextMode="MultiLine"></asp:textbox></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4" style="WIDTH: 88px">
																		<asp:label id="lblMontoAuditar" runat="server" CssClass="TextoBlanco" Width="72px">Monto a ser Auditado (S/.):</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<ew:numericbox id="txtMontoAuditar" runat="server" CssClass="normaldetalle" Width="50px" MaxLength="8"
																			PositiveNumber="True" TextAlign="Right"></ew:numericbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvMontoAuditar" runat="server" ControlToValidate="txtMontoAuditar">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="lblCosto" runat="server" CssClass="TextoBlanco" Width="65px">Costo (S/.):</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<ew:numericbox id="txtCosto" runat="server" CssClass="normaldetalle" Width="50px" MaxLength="8"
																			PositiveNumber="True" TextAlign="Right"></ew:numericbox></TD>
																	<TD style="WIDTH: 3px">
																		<cc1:requireddomvalidator id="rfvCosto" runat="server" ControlToValidate="txtCosto">*</cc1:requireddomvalidator></TD>
																	<TD style="WIDTH: 70px" bgColor="#335eb4">
																		<asp:label id="lblNroIntegrantes" runat="server" CssClass="TextoBlanco" Width="65px">Nro. de Integrantes:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<ew:numericbox id="txtNroIntegrantes" runat="server" CssClass="normaldetalle" Width="30px" MaxLength="3"
																			PositiveNumber="True" TextAlign="Right" RealNumber="False"></ew:numericbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvNroIntegrantes" runat="server" ControlToValidate="txtNroIntegrantes">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4">
																		<asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="65px">Nro. de Hras. Hombre:</asp:label></TD>
																	<TD bgColor="#f0f0f0">
																		<ew:numericbox id="txtNroHorasHombre" runat="server" CssClass="normaldetalle" Width="30px" MaxLength="5"
																			PositiveNumber="True" TextAlign="Right"></ew:numericbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvNroHorasHombre" runat="server" ControlToValidate="txtNroHorasHombre">*</cc1:requireddomvalidator></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4" style="WIDTH: 88px">
																		<asp:label id="lblObjetivo" runat="server" CssClass="TextoBlanco">Objetivo:</asp:label></TD>
																	<TD colSpan="4" bgColor="#dddddd">
																		<asp:textbox id="txtObjetivo" runat="server" CssClass="normaldetalle" Height="44px" MaxLength="1500"
																			Width="256px" TextMode="MultiLine"></asp:textbox></TD>
																	<TD style="WIDTH: 3px">
																		<cc1:requireddomvalidator id="rfvObjetivo" runat="server" ControlToValidate="txtObjetivo">*</cc1:requireddomvalidator></TD>
																	<TD bgColor="#335eb4" style="WIDTH: 70px">
																		<asp:label id="lblAreasExaminar" runat="server" CssClass="TextoBlanco">Areas a ser Examinadas:</asp:label></TD>
																	<TD colSpan="4" bgColor="#dddddd">
																		<asp:textbox id="txtAreasExaminar" runat="server" CssClass="normaldetalle" Height="44px" MaxLength="1500"
																			Width="256px" TextMode="MultiLine"></asp:textbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvAreasExaminar" runat="server" ControlToValidate="txtAreasExaminar">*</cc1:requireddomvalidator></TD>
																</TR>
																<TR>
																	<TD bgColor="#335eb4" style="WIDTH: 88px">
																		<asp:label id="lblLineamientos" runat="server" CssClass="TextoBlanco">Lineamientos:</asp:label></TD>
																	<TD colSpan="10" bgColor="#f0f0f0">
																		<asp:textbox id="txtLineamientos" runat="server" CssClass="normal" MaxLength="15" Width="650"></asp:textbox></TD>
																	<TD>
																		<cc1:requireddomvalidator id="rfvLineamientos" runat="server" ControlToValidate="txtLineamientos">*</cc1:requireddomvalidator></TD>
																</TR>
																<TR>
																	<TD align="center" bgColor="#000080" colSpan="5">
																		<asp:label id="lblSubTituloFechas" runat="server" CssClass="TituloPrincipalBlanco">Alcance (Periodo)</asp:label></TD>
																	<TD style="WIDTH: 3px"></TD>
																	<TD align="center" bgColor="#000080" colSpan="5">
																		<asp:label id="lblSubTituloFechasCronograma" runat="server" CssClass="TituloPrincipalBlanco">Cronograma de Ejecución</asp:label></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD align="center" colSpan="5" bgColor="#dddddd">
																		<TABLE id="Table6" borderColor="#ffffff" cellSpacing="0" cellPadding="0" align="center"
																			border="1">
																			<TR>
																				<TD align="center" bgColor="#335eb4">
																					<asp:label id="lblFechaInicio" runat="server" CssClass="TextoBlanco">Desde:</asp:label></TD>
																				<TD align="center" bgColor="#335eb4">
																					<asp:label id="lblFechaFin" runat="server" CssClass="TextoBlanco">Hasta:</asp:label></TD>
																			</TR>
																			<TR>
																				<TD align="center">
																					<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
																						Width="72px" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
																						<TextboxLabelStyle CssClass="normal"></TextboxLabelStyle>
																						<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="White"></WeekdayStyle>
																						<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																							BackColor="#404040"></MonthHeaderStyle>
																						<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Gray"
																							BackColor="WhiteSmoke"></OffMonthStyle>
																						<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="White"></GoToTodayStyle>
																						<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="LightGoldenrodYellow"></TodayDayStyle>
																						<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="Silver"></DayHeaderStyle>
																						<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="LightGray"></WeekendStyle>
																						<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																							BackColor="#404040"></SelectedDateStyle>
																						<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="White"></ClearDateStyle>
																						<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="White"></HolidayStyle>
																					</ew:calendarpopup></TD>
																				<TD align="center">
																					<ew:calendarpopup id="CalFechaFin" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
																						Width="72px" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
																			</TR>
																		</TABLE>
																	</TD>
																	<TD style="WIDTH: 3px"></TD>
																	<TD align="center" colSpan="5" bgColor="#dddddd">
																		<TABLE id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0" border="1">
																			<TR>
																				<TD align="center" bgColor="#335eb4">
																					<asp:label id="lblFechaInicioCronograma" runat="server" CssClass="TextoBlanco">Desde:</asp:label></TD>
																				<TD align="center" bgColor="#335eb4">
																					<asp:label id="lblFechaFinCronograma" runat="server" CssClass="TextoBlanco">Hasta:</asp:label></TD>
																			</TR>
																			<TR>
																				<TD align="center">
																					<ew:calendarpopup id="CalFechaInicioCronograma" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
																						Width="72px" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
																						<SelectedDateStyle Font-Size="Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							CssClass="normal" BackColor="#FF8A00"></SelectedDateStyle>
																						<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="White"></ClearDateStyle>
																						<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																							BackColor="White"></HolidayStyle>
																					</ew:calendarpopup></TD>
																				<TD align="center">
																					<ew:calendarpopup id="CalFechaFinCronograma" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
																						Width="72px" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
																			</TR>
																		</TABLE>
																	</TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD align="center" bgColor="#000080" colSpan="5">
																		<asp:label class="" id="lblMetas" runat="server" CssClass="TituloPrincipalBlanco">Metas</asp:label></TD>
																	<TD style="WIDTH: 3px"></TD>
																	<TD align="center" bgColor="#000080" colSpan="5">
																		<asp:label class="" id="lblCronograma" runat="server" CssClass="TituloPrincipalBlanco">Cronograma de Avances por Mes</asp:label></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD bgColor="#f0f0f0" style="WIDTH: 88px">
																		<asp:button id="btnAgregarMeta" runat="server" CausesValidation="False" Text="Agregar"></asp:button></TD>
																	<TD colSpan="4" bgColor="#f0f0f0">
																		<div style="OVERFLOW: auto; WIDTH: 260px; HEIGHT: 70px">
																			<asp:datagrid id="grid" runat="server" CssClass="normaldetalle" Width="240px" AllowPaging="True"
																				AllowSorting="True" AutoGenerateColumns="False">
																				<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																				<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																				<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																				<Columns>
																					<asp:BoundColumn Visible="False" DataField="IdProgramacionAuditoriaMeta" SortExpression="IdProgramacionAuditoriaMeta"
																						HeaderText="IdProgramacionAuditoriaMeta"></asp:BoundColumn>
																					<asp:TemplateColumn HeaderText="FECHA">
																						<HeaderStyle Width="100%"></HeaderStyle>
																						<ItemTemplate>
																							<ew:calendarpopup id="calFecha" runat="server" CssClass="combos" Width="72px" PadSingleDigits="True"
																								Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" ImageUrl="../imagenes/BtPU_Mas.gif">
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
																							</ew:calendarpopup>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="AVANCE">
																						<ItemTemplate>
																							<ew:numericbox id="txt" runat="server" CssClass="normal" Width="61px" MaxLength="3" PositiveNumber="True"
																								TextAlign="Right" RealNumber="False"></ew:numericbox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																					<asp:TemplateColumn HeaderText="Eliminar">
																						<ItemStyle HorizontalAlign="Center"></ItemStyle>
																						<ItemTemplate>
																							<asp:CheckBox id="cbxEliminar" runat="server" AutoPostBack="True"></asp:CheckBox>
																						</ItemTemplate>
																					</asp:TemplateColumn>
																				</Columns>
																				<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
																			</asp:datagrid></div>
																	</TD>
																	<TD style="WIDTH: 3px"></TD>
																	<TD align="center" colSpan="5" bgColor="#f0f0f0">
																		<TABLE class="bordeexterno" id="Table2" cellSpacing="1" cellPadding="1" border="0">
																			<TR>
																				<TD class="normal">
																					<asp:checkbox id="cbxEnero" runat="server" CssClass="normaldetalle" Text="E" ToolTip="Enero"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxFebrero" runat="server" CssClass="normaldetalle" Text="F" ToolTip="Febrero"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxMarzo" runat="server" CssClass="normaldetalle" Text="M" ToolTip="Marzo"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxAbril" runat="server" CssClass="normaldetalle" Text="A" ToolTip="Abril"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxMayo" runat="server" CssClass="normaldetalle" Text="M" ToolTip="Mayo"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxJunio" runat="server" CssClass="normaldetalle" Text="J" ToolTip="Junio"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxJulio" runat="server" CssClass="normaldetalle" Text="J" ToolTip="Julio"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxAgosto" runat="server" CssClass="normaldetalle" Text="A" ToolTip="Agosto"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxSeptiembre" runat="server" CssClass="normaldetalle" Text="S" ToolTip="Septiembre"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxOctubre" runat="server" CssClass="normaldetalle" Text="O" ToolTip="Octubre"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxNoviembre" runat="server" CssClass="normaldetalle" Text="N" ToolTip="Noviembre"></asp:checkbox></TD>
																				<TD class="normal">
																					<asp:checkbox id="cbxDiciembre" runat="server" CssClass="normaldetalle" Text="D" ToolTip="Diciembre"></asp:checkbox></TD>
																			</TR>
																		</TABLE>
																	</TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD align="right" colSpan="11">
																		<TABLE id="Table5" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
																			<TR>
																				<TD>
																					<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																				<TD>
																					<asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" CausesValidation="False" ImageUrl="../imagenes/bt_cancelar.gif"></asp:imagebutton></TD>
																			</TR>
																		</TABLE>
																	</TD>
																	<TD colSpan="4"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"
													Height="52px" Width="100px"></cc1:domvalidationsummary></TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<asp:imagebutton id="ibtnAtras" runat="server" CausesValidation="False" ImageUrl="../imagenes/atras.gif"></asp:imagebutton></TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
