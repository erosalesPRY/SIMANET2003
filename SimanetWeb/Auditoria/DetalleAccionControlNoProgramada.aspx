<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAccionControlNoProgramada.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.DetalleAccionControlNoProgramada" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
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
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<TABLE cellSpacing="0" cellPadding="0" width="764" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Detalle de Acción de Control No Programada</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" align="center" border="0">
										<TR>
											<TD></TD>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="764" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="center" colSpan="6"><asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco">Código:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#f0f0f0"><asp:textbox id="txtCodigo" runat="server" CssClass="normaldetalle" MaxLength="15"></asp:textbox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvCodigo" runat="server" ErrorMessage="RequiredDomValidator" ControlToValidate="txtCodigo">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblInformeEmitido" runat="server" CssClass="TextoBlanco"> Solicitante:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#dddddd"><asp:textbox id="txtSolicitante" runat="server" CssClass="normaldetalle" MaxLength="15" Width="336px"
																Height="20px"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvSolicitante" runat="server" ControlToValidate="txtSolicitante">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px; HEIGHT: 22px" bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco" Width="104px">Centro Operativo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px; HEIGHT: 22px" colSpan="4" bgColor="#f0f0f0"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="336px" Height="22px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 22px"><cc1:requireddomvalidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo" InitialValue="%">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblArea" runat="server" CssClass="TextoBlanco">Area:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" colSpan="4" bgColor="#dddddd"><asp:textbox id="txtArea" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="336px"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvArea" runat="server" ControlToValidate="txtArea">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco" Width="96px">Acción Correctiva:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" colSpan="4" bgColor="#f0f0f0"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="576px"
																Height="60px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco">Observación:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#dddddd"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="576px"
																Height="60px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblPorcentajeAvance" runat="server" CssClass="TextoBlanco">% de Avance:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" colSpan="4" bgColor="#f0f0f0"><ew:numericbox id="txtPorcentajeAvance" runat="server" CssClass="normaldetalle" MaxLength="3" Width="56px"
																PositiveNumber="True" RealNumber="False" TextAlign="Right"></ew:numericbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvPorcentajeAvance" runat="server" ControlToValidate="txtPorcentajeAvance">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblFechaInicio" runat="server" CssClass="TextoBlanco">Fecha de Inicio:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" colSpan="4" bgColor="#dddddd"><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
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
															</ew:calendarpopup></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 104px" bgColor="#335eb4"><asp:label id="lblFechaFin" runat="server" CssClass="TextoBlanco" Visible="False">Fecha de Fin:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" bgColor="#f0f0f0" colSpan="4">
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
														<TD class="normal" align="right" colSpan="5">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
																<TR>
																	<TD>
																		<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																	<TD><asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="normal" colSpan="6">
															<cc1:domvalidationsummary id="vSum" runat="server" Height="52px" EnableClientScript="False" DisplayMode="List"
																ShowMessageBox="True"></cc1:domvalidationsummary></TD>
													</TR>
												</TABLE>
											</TD>
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
