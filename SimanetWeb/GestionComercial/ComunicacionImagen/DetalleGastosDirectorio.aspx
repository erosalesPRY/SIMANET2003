<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleGastosDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleGastosDirectorio" %>
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
					<TD colSpan="3" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Gastos de Directorio</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" align="left"><INPUT id="hIdCentroCosto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCentroCosto"
										runat="server"><INPUT id="hIdGrupoCentroCosto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="hIdGrupoCentroCosto" runat="server"></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="480" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD vAlign="top" align="center">
												<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="460" align="center" border="1"
													borderColor="#ffffff">
													<TBODY>
														<TR>
															<TD class="normal" align="left" bgColor="#000080" colSpan="5">
																<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
															<TD class="normal" align="left"></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha Gasto:</asp:label></TD>
															<TD class="normal" colSpan="4" bgColor="#dddddd">
																<ew:calendarpopup id="calFecha" runat="server" CssClass="normaldetalle" PadSingleDigits="True" Culture="Spanish (Chile)"
																	ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" ImageUrl="../../imagenes/BtPU_Mas.gif"
																	Width="72px">
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
															</TD>
															<TD class="normal"></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco">Tipo Documento</asp:label></TD>
															<TD class="normal" colSpan="4" bgColor="#f0f0f0">
																<asp:dropdownlist id="ddlbTipoDocumento" runat="server" CssClass="normaldetalle" Width="120px"></asp:dropdownlist>
															</TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvTipoDocumento" runat="server" ControlToValidate="ddlbTipoDocumento">*</cc2:requireddomvalidator></TD>
														</TR>
														<TR>
															<TD class="normal" style="HEIGHT: 21px" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblFechaDocumento" runat="server" CssClass="TextoBlanco">Fecha Documento :</asp:label></TD>
															<TD class="normal" style="HEIGHT: 21px" colSpan="4" bgColor="#dddddd">
																<ew:calendarpopup id="calFechaDocumento" runat="server" CssClass="normaldetalle" PadSingleDigits="True"
																	Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" ImageUrl="../../imagenes/BtPU_Mas.gif"
																	Width="72px">
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
															</TD>
															<TD class="normal" style="HEIGHT: 21px"></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblDocumento" runat="server" CssClass="TextoBlanco"> Nro Documento:</asp:label>
															</TD>
															<TD class="normal" colSpan="4" bgColor="#f0f0f0">
																<asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="136px"></asp:textbox>
															</TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvNroDocumento" runat="server" Width="2px" ControlToValidate="txtNroDocumento">*</cc2:requireddomvalidator></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblCentroCosto" runat="server" CssClass="TextoBlanco">Centro de Costo:</asp:label></TD>
															<TD class="normal" colSpan="4" bgColor="#dddddd">
																<asp:textbox id="txtCentroCosto" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox>
																<asp:imagebutton id="ibtnBuscarCentroCosto" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																	CausesValidation="False"></asp:imagebutton></TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvCentroCosto" runat="server" ControlToValidate="txtCentroCosto">*</cc2:requireddomvalidator></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblLugar" runat="server" CssClass="TextoBlanco">Lugar:</asp:label></TD>
															<TD class="normal" colSpan="4" bgColor="#f0f0f0">
																<asp:textbox id="txtLugar" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="500"></asp:textbox></TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvLugar" runat="server" ControlToValidate="txtLugar">*</cc2:requireddomvalidator></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion del Gasto:</asp:label></TD>
															<TD class="normal" colSpan="4">
																<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="2000"
																	Height="56px" TextMode="MultiLine"></asp:textbox></TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc2:requireddomvalidator></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">Monto:</asp:label></TD>
															<TD class="normal" colSpan="4" bgColor="#dddddd">
																<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="19"
																	PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="12"></ew:numericbox></TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvMonto" runat="server" ControlToValidate="nMonto">*</cc2:requireddomvalidator></TD>
														</TR>
														<TR>
															<TD class="normal" vAlign="top" bgColor="#335eb4">
																<asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
															<TD class="normal" colSpan="4" bgColor="#f0f0f0">
																<asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
															<TD class="normal">
																<cc2:requireddomvalidator id="rfvMoneda" runat="server" ControlToValidate="ddlbMoneda">*</cc2:requireddomvalidator></TD>
														</TR>
													</TBODY>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" Height="16px" EnableClientScript="False"
													DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary>
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
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
