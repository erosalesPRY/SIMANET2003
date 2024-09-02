<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAcuerdoSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.DetalleAcuerdoSesionDirectorio" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onunload="SubirHistorial();"
		onload="ObtenerHistorial();">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top">
						<asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio > Gestión de la Dirección</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Acuerdo de Sesión de Directorio</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" align="center" border="1" borderColor="#ffffff">
							<tr>
								<td class="normal" bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px">
												<TABLE class="normal" id="Table3" cellSpacing="1" cellPadding="1" align="center" border="0">
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="Label3" runat="server" CssClass="TextoBlanco">C.O.:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="224px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label class="" id="lblNroAcuerdo" runat="server" CssClass="TextoBlanco">Nro. de Acuerdo:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#dddddd"><asp:textbox id="txtNumeroAcuerdo" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="224px"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvNroAcuerdo" runat="server" ControlToValidate="txtNumeroAcuerdo">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblSituacion" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="224px"></asp:dropdownlist></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvSituacion" runat="server" ControlToValidate="ddlbSituacion" InitialValue="%">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:calendarpopup id="CalFecha" runat="server" CssClass="normaldetalle" Width="80px" ImageUrl="../../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
																AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
																NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False" ClearDateText="Limpiar Fecha">
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
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblTema" runat="server" CssClass="TextoBlanco">ASUNTO:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#f0f0f0">
															<asp:textbox id="txtTema" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="416px"
																Height="80px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvTema" runat="server" ControlToValidate="txtTema">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Acuerdo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtAcuerdo" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="416px"
																TextMode="MultiLine" Height="80px"></asp:textbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvAcuerdo" runat="server" ControlToValidate="txtAcuerdo" InitialValue="%">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblArchivoAdjunto" runat="server" CssClass="TextoBlanco">Archivo: </asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 100%; HEIGHT: 20px" type="file"
																size="48" name="filMyFile" runat="server"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top"></TD>
														<TD class="normal" colSpan="4"></TD>
														<TD class="normal" style="HEIGHT: 13px"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" colSpan="6">
															<TABLE id="Table7" height="25" cellSpacing="0" cellPadding="0" align="center" border="0">
																<TR>
																	<TD align="center">&nbsp;&nbsp;&nbsp;
																		<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;<SPAN class="normal">
																			<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
																				style="CURSOR: hand"></SPAN></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary><INPUT id="hDocActa" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDocActa"
													runat="server"></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<span class="normal"></span><span class="normal"></span>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			<p>&nbsp;</p>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
