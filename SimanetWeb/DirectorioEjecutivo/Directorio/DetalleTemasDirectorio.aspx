<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleTemasDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.DetalleTemasDirectorio" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio > Gestión de la Dirección</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Obligación del Directorio</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" align="center" border="1"
							width="600">
							<tr>
								<td class="normal" bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD></TD>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center"
													border="0">
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">C.O.:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="224px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label class="" id="Label2" runat="server" CssClass="TextoBlanco"> Obligación:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtFuente" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="490px"
																TextMode="MultiLine" Height="72px"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvFuente" runat="server" ControlToValidate="txtFuente">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label class="" id="Label5" runat="server" CssClass="TextoBlanco">Tema:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtTema" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="490px"
																Height="72px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvTema" runat="server" ControlToValidate="txtTema">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label class="" id="Label6" runat="server" CssClass="TextoBlanco">Referencia:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtReferencia" runat="server" CssClass="normaldetalle" MaxLength="100" Width="100%"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label class="" id="lblNroPedido" runat="server" CssClass="TextoBlanco"> Nro. Acuerdo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtNroAcuerdo" runat="server" CssClass="normaldetalle" MaxLength="20" Width="150px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha Acuerdo:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><ew:calendarpopup id="CalFechaAcuerdo" runat="server" CssClass="normaldetalle" ClearDateText="Limpiar Fecha"
																DisableTextboxEntry="False" NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
																GoToTodayText="Hoy :" AllowArbitraryText="False" Width="80px" ImageUrl="../../imagenes/BtPU_Mas.gif" PadSingleDigits="True" Culture="Spanish (Chile)"
																ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblSituacion" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="224px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Archivo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 100%" type="file" size="48" name="filMyFile"
																runat="server"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDetalle" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="100%"
																TextMode="MultiLine" Height="80px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top"></TD>
														<TD class="normal" colSpan="4"></TD>
														<TD class="normal"></TD>
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
												<cc1:domvalidationsummary id="vSum" runat="server" ShowMessageBox="True" DisplayMode="List" EnableClientScript="False"></cc1:domvalidationsummary><INPUT id="hDocumento" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDocActa"
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
