<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleGastosRepresentacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleGastosRepresentacion" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Gastos de Representacion</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" align="left"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center">
												<TABLE class="normal" id="Table7" cellSpacing="0" cellPadding="0" width="480" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblOnomastico" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:calendarpopup id="calFechaEntrega" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Peru)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
																AllowArbitraryText="False">
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
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNombres" runat="server" CssClass="TextoBlanco">Nombres:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtPromotor" runat="server" CssClass="normaldetalle" Width="336px" ReadOnly="True"
																MaxLength="80"></asp:textbox>
															<asp:imagebutton id="ibtnBuscarPromotor" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif" CausesValidation="False"
																CssClass="normaldetalle"></asp:imagebutton></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvNombres" runat="server" ControlToValidate="txtPromotor">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblPresente" runat="server" CssClass="TextoBlanco">Presente:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:dropdownlist id="ddlbPresente" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist>
														</TD>
														<TD class="normal" bgColor="#ffffff">
															<P>
																<cc2:requireddomvalidator id="rfvPresente" runat="server" ControlToValidate="ddlbPresente">*</cc2:requireddomvalidator></P>
														</TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCantidad" runat="server" CssClass="TextoBlanco" Width="64px" Height="16px">Cantidad Entregada:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="nbCantidad" runat="server" CssClass="normaldetalle" Width="111px" MaxLength="22"
																PositiveNumber="True"></ew:numericbox></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvCantidad" runat="server" ControlToValidate="nbCantidad">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco">Tipo Documento:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:dropdownlist id="ddlbTipoDocumento" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvTipoDocumento" runat="server" ControlToValidate="ddlbTipoDocumento">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblFechaDocumento" runat="server" CssClass="TextoBlanco" Width="72px" Height="10px">Fecha Documento:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:calendarpopup id="calFechaDocumento" runat="server" CssClass="normaldetalle" ShowGoToToday="True"
																ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif"
																Width="109px" SelectedDate="2005-09-09" GoToTodayText="Hoy:" MonthYearPopupApplyText="Aceptar"
																MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:">
																<TextboxLabelStyle CssClass="normalDetalle"></TextboxLabelStyle>
																<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																	BackColor="White"></WeekdayStyle>
																<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="Navy"></MonthHeaderStyle>
																<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
																	BackColor="White"></OffMonthStyle>
																<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
																	BackColor="White"></GoToTodayStyle>
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
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNroDocumento" runat="server" CssClass="TextoBlanco">Nro Documento:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtDocumento" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="20"></asp:textbox></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvDocumento" runat="server" ControlToValidate="txtDocumento">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblMotivo" runat="server" CssClass="TextoBlanco">Motivo:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtMotivo" runat="server" CssClass="normaldetalle" Width="336px" Height="56px"
																TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvMotivo" runat="server" ControlToValidate="txtMotivo">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="2000"
																Height="56px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" Height="30px" EnableClientScript="False"
													DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table8" width="180" border="0">
										<TR>
											<TD width="94">
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
													Height="22px"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></SPAN></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
