<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleAdquisicionesTerceros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorEjecutivo.Director.DetalleAdquisicionesTerceros" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
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
					<TD class="Commands" vAlign="top"><asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio > Gestión de la Dirección</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Adquisiciones de Terceros</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
							<tr>
								<td class="normal" bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center"
													border="0">
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:calendarpopup id="CalFechaAdquisicion" runat="server" CssClass="normaldetalle" ClearDateText="Limpiar Fecha"
																DisableTextboxEntry="False" NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
																GoToTodayText="Hoy :" AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
																ImageUrl="../../imagenes/BtPU_Mas.gif" Width="80px">
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
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblTema" runat="server" CssClass="TextoBlanco">Objeto:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtObjeto" runat="server" CssClass="normaldetalle" Width="447px" TextMode="MultiLine"
																Height="54px" MaxLength="1500"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvObjeto" runat="server" ControlToValidate="txtObjeto">*</cc1:requireddomvalidator></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDetalle" runat="server" CssClass="TextoBlanco">Proveedor:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtEntidad" runat="server" CssClass="normaldetalle" Width="100%" TextMode="MultiLine"
																ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"><asp:image id="ibtnBuscarPromotor" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvProveedor" runat="server" ControlToValidate="txtEntidad">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">Proyecto:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtProyecto" runat="server" CssClass="normaldetalle" Width="100%" TextMode="MultiLine"
																Height="54px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"><asp:image id="ibtnBuscarProyecto" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvProyecto" runat="server" ControlToValidate="txtProyecto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 16px" vAlign="top" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">Tipo Mercado:</asp:label></TD>
														<TD class="normal" style="HEIGHT: 16px" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbTipoMercado" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 16px"></TD>
														<TD class="normal" style="HEIGHT: 16px"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">Monto:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:numericbox id="txtMonto" runat="server" CssClass="normaldetalle" Width="160px" MaxLength="19"></ew:numericbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvMonto" runat="server" ControlToValidate="txtMonto">*</cc1:requireddomvalidator></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label4" runat="server" CssClass="TextoBlanco">Tipo Adquisición:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbTipoAdquisicion" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label5" runat="server" CssClass="TextoBlanco">Fecha Orden:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:calendarpopup id="calFechaOrden" runat="server" CssClass="normaldetalle" ClearDateText="Limpiar Fecha"
																DisableTextboxEntry="False" NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
																GoToTodayText="Hoy :" AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
																ImageUrl="../../imagenes/BtPU_Mas.gif" Width="80px">
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
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label6" runat="server" CssClass="TextoBlanco">Nro. Compra:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtNroCompra" runat="server" CssClass="normaldetalle" Width="152px"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvNroCompra" runat="server" ControlToValidate="txtNroCompra">*</cc1:requireddomvalidator></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top"></TD>
														<TD class="normal" colSpan="4"></TD>
														<TD class="normal"></TD>
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
														<TD class="normal" vAlign="top"></TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" ShowMessageBox="True" DisplayMode="List" EnableClientScript="False"></cc1:domvalidationsummary><INPUT id="hIdTablaEntidad" style="WIDTH: 9px; HEIGHT: 22px" type="hidden" size="1" name="hIdTablaEntidad"
													runat="server"><INPUT id="hIdEntidad" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="hIdEntidad"
													runat="server"><INPUT id="hIdCodigo" style="WIDTH: 14px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
													runat="server"><INPUT id="hNumero" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="hNumero"
													runat="server"><INPUT id="hIdProyecto" style="WIDTH: 8px; HEIGHT: 16px" type="hidden" size="1" name="hIdProyecto"
													runat="server"><INPUT id="txtCliente" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="txtCliente"
													runat="server"></TD>
											<TD vAlign="bottom" align="center"></TD>
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
