<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleAccionCorrectiva.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.DetalleAccionCorrectiva" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<TR>
					<TD colSpan="1">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<table cellSpacing="0" cellPadding="0" width="764" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Detalle de Plan Anual de Control</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" align="center" border="0">
										<TR>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="764" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="center" colSpan="6">
															<asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 18px" vAlign="top" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label>
															<asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 18px" vAlign="top" bgColor="#335eb4">
															<asp:label class="" id="lblInformeEmitido" runat="server" CssClass="TextoBlanco" Width="96px">Informe Emitido:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 18px" colSpan="4" bgColor="#dddddd">
															<asp:textbox id="txtInformeEmitido" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="1500"></asp:textbox></TD>
														<TD class="normal" style="HEIGHT: 18px">
															<cc1:RequiredDomValidator id="rfvInformeEmitido" runat="server" ControlToValidate="txtInformeEmitido">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 21px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco" Width="96px">Centro Operativo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 21px" colSpan="4" bgColor="#f0f0f0">
															<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="336px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 21px">
															<cc1:RequiredDomValidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 21px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblArea" runat="server" CssClass="TextoBlanco">Area:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 21px" colSpan="4" bgColor="#dddddd">
															<asp:dropdownlist id="ddlbArea" runat="server" CssClass="normaldetalle" Width="336px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 21px">
															<cc1:RequiredDomValidator id="rfvArea" runat="server" ControlToValidate="ddlbArea" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 28px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Acci&oacute;n Correctiva:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 28px" colSpan="4" bgColor="#f0f0f0">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="600px" MaxLength="1500"
																TextMode="MultiLine" Height="45px"></asp:textbox></TD>
														<TD class="normal" style="HEIGHT: 28px">
															<cc1:RequiredDomValidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 32px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco">Observaci&oacute;n:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 32px" colSpan="4" bgColor="#dddddd">
															<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="600px" MaxLength="1500"
																TextMode="MultiLine" Height="45px"></asp:textbox></TD>
														<TD class="normal" style="HEIGHT: 32px"></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 20px" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblPorcentajeAvance" runat="server" CssClass="TextoBlanco">% de Avance:</asp:Label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 20px" colSpan="4" bgColor="#f0f0f0">
															<ew:NumericBox id="txtPorcentajeAvance" runat="server" CssClass="normaldetalle" Width="56px" MaxLength="3"
																RealNumber="False" PositiveNumber="True" TextAlign="Right"></ew:NumericBox></TD>
														<TD class="normal" style="HEIGHT: 20px">
															<cc1:RequiredDomValidator id="rfvPorcentajeAvance" runat="server" ControlToValidate="txtPorcentajeAvance">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 21px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblFechaInicio" runat="server" CssClass="TextoBlanco" Width="72px"> Fecha Inicio:</asp:label></TD>
														<TD class="normal" style="HEIGHT: 21px" colSpan="4" bgColor="#dddddd">
															<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
															</ew:calendarpopup>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 21px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblFechaFin" runat="server" CssClass="TextoBlanco" Visible="False">Fecha de Fin:</asp:label></TD>
														<TD class="normal" style="HEIGHT: 21px" bgColor="#f0f0f0" colSpan="4">
															<ew:calendarpopup id="CalFechaFin" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
																Visible="False">
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
													<TR>
														<TD class="normal" vAlign="top" colSpan="5" align="right">
															<TABLE id="Table1" border="1" cellSpacing="0" cellPadding="0" borderColor="#ffffff">
																<TR>
																	<TD><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																	<TD><asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:DomValidationSummary id="vSum" runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc1:DomValidationSummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN><SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</table>
			<p>&nbsp;</p>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
