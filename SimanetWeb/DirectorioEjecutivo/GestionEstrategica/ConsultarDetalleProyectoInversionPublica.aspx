<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleProyectoInversionPublica.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica.ConsultarDetalleProyectoInversionPublica" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Proyectos de Investigación ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle del Proyecto></asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" align="center">
							<TR>
								<TD style="WIDTH: 762px" width="762">
									<table id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr bgColor="#000080">
											<td colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="100%"> [DETALLE DEL PROYECTO]</asp:label></td>
										</tr>
										<tr>
											<td colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="1">
													<TR bgColor="#dddddd">
														<TD align="left" width="180" bgColor="#335eb4"><asp:label id="lblCodigoProyecto" runat="server" CssClass="TextoBlanco">CODIGO DE PROYECTO:&nbsp&nbsp&nbsp</asp:label></TD>
														<TD width="600"><asp:textbox id="txtCodigoProyecto" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
																ReadOnly="True"></asp:textbox></TD>
														<TD width="10"></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD align="left" width="180" bgColor="#335eb4"><asp:label id="lblDescripcionAbreviada" runat="server" CssClass="TextoBlanco">PROYECTO:&nbsp&nbsp&nbsp</asp:label></TD>
														<TD width="600"><asp:textbox id="txtDescripcionAbreviada" runat="server" CssClass="normaldetalle" Width="350px"
																MaxLength="50"></asp:textbox></TD>
														<TD><cc3:requireddomvalidator id="RqdvDescripcionAbreviada" runat="server" ControlToValidate="txtDescripcionAbreviada">*</cc3:requireddomvalidator></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD align="left" width="180" bgColor="#335eb4"><asp:label id="lblNombreArea" runat="server" CssClass="TextoBlanco" Width="136px">AREA RESPONSABLE:</asp:label></TD>
														<TD width="600"><asp:dropdownlist id="ddldArea" runat="server" CssClass="normaldetalle" Width="350px"></asp:dropdownlist></TD>
														<TD><cc3:requireddomvalidator id="RqdvArea" runat="server" ControlToValidate="ddldArea">*</cc3:requireddomvalidator></TD>
													</TR>
													<tr>
														<td colSpan="3">
															<table id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr bgColor="#f0f0f0">
																	<td vAlign="top" align="left">
																		<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="390" border="1">
																			<TR bgColor="#f0f0f0">
																				<TD style="WIDTH: 162px; HEIGHT: 43px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblMontoAsignado" runat="server" CssClass="TextoBlanco">MONTO ASIGNADO:</asp:label></TD>
																				<TD style="WIDTH: 192px; HEIGHT: 43px"><asp:textbox id="txtMontoAsignado" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="50"
																						ReadOnly="True"></asp:textbox><ew:numericbox id="nbMontoAsignado" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
																						Visible="False" PositiveNumber="True" PlacesBeforeDecimal="11" DecimalPlaces="2" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
																				<TD style="WIDTH: 7px; HEIGHT: 43px"></TD>
																			</TR>
																			<TR bgColor="#dddddd">
																				<TD style="WIDTH: 162px; HEIGHT: 15px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">MONEDA:</asp:label></TD>
																				<TD style="WIDTH: 192px; HEIGHT: 15px"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle"></asp:dropdownlist></TD>
																				<TD style="WIDTH: 7px; HEIGHT: 15px"></TD>
																			</TR>
																			<TR bgColor="#f0f0f0">
																				<TD style="WIDTH: 162px; HEIGHT: 20px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblTipoCambio" runat="server" CssClass="TextoBlanco">TIPO DE CAMBIO:</asp:label></TD>
																				<TD style="WIDTH: 192px; HEIGHT: 20px"><asp:textbox id="txtTipoCambio" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="50"
																						ReadOnly="True"></asp:textbox></TD>
																				<TD style="WIDTH: 7px; HEIGHT: 20px"></TD>
																			</TR>
																			<TR bgColor="#dddddd">
																				<TD style="WIDTH: 162px; HEIGHT: 20px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblMontoAsignadoSoles" runat="server" CssClass="TextoBlanco">MONTO ASIGNADO EN NS</asp:label></TD>
																				<TD style="WIDTH: 192px; HEIGHT: 20px"><asp:textbox id="txtMontoAsignadoSoles" runat="server" CssClass="normaldetalle" Width="120px"
																						MaxLength="50" ReadOnly="True"></asp:textbox></TD>
																				<TD style="WIDTH: 7px; HEIGHT: 20px"></TD>
																			</TR>
																			<TR bgColor="#f0f0f0">
																				<TD style="WIDTH: 162px; HEIGHT: 16px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblFinanciamiento" runat="server" CssClass="TextoBlanco">FUENTE DE FINANCIAMIENTO:</asp:label></TD>
																				<TD style="WIDTH: 192px; HEIGHT: 16px"><asp:dropdownlist id="ddlbFuenteFinanciamiento" runat="server" CssClass="normaldetalle" Width="180px"></asp:dropdownlist></TD>
																				<TD style="WIDTH: 7px; HEIGHT: 16px"></TD>
																			</TR>
																			<TR>
																				<TD style="WIDTH: 162px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblFechaInicio" runat="server" CssClass="TextoBlanco">FECHA DE INICIO:</asp:label></TD>
																				<TD style="WIDTH: 192px"><asp:textbox id="txtFechaInicio" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="15"
																						ReadOnly="True"></asp:textbox><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="combos" Width="103px" Visible="False"
																						Culture="Spanish (Chile)" Text="..." PadSingleDigits="True" ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="La Fecha de hoy:"
																						ImageUrl="../../imagenes/BtPU_Mas.gif">
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
																				<TD style="WIDTH: 7px"></TD>
																			</TR>
																			<TR id="ControlTablaFilaFechaTermino" bgColor="#f0f0f0" runat="server">
																				<TD style="WIDTH: 162px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblFechaTermino" runat="server" CssClass="TextoBlanco">FECHA DE TERMINO:</asp:label></TD>
																				<TD style="WIDTH: 192px"><asp:textbox id="txtFechaTermino" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="15"
																						ReadOnly="True"></asp:textbox><ew:calendarpopup id="CalFechaTermino" runat="server" CssClass="combos" Width="103px" Visible="False"
																						Culture="Spanish (Chile)" Text="..." PadSingleDigits="True" ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="La Fecha de hoy:"
																						ImageUrl="../../imagenes/BtPU_Mas.gif" NullableLabelText="Seleccionar una Fecha" ClearDateText="Limpiar Fecha" Nullable="True">
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
																				<TD style="WIDTH: 7px"></TD>
																			</TR>
																			<TR id="ControlTablaFilaEstado" bgColor="#dddddd" runat="server">
																				<TD style="WIDTH: 162px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco">ESTADO:</asp:label></TD>
																				<TD style="WIDTH: 192px"><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normaldetalle"></asp:dropdownlist></TD>
																				<TD style="WIDTH: 7px"></TD>
																			</TR>
																			<TR id="ControlTablaFilaAvanceFisicoUltimo" bgColor="#f0f0f0" runat="server">
																				<TD style="WIDTH: 162px" align="left" width="162" bgColor="#335eb4"><asp:label id="lblAvanceFisicoUltimoDirectorio" runat="server" CssClass="TextoBlanco">AVANCE FISICO ANT:</asp:label></TD>
																				<TD style="WIDTH: 192px"><asp:textbox id="txtAvanceFisicoUltimoDirectorio" runat="server" CssClass="normaldetalle" Width="50px"
																						MaxLength="15" ReadOnly="True"></asp:textbox><ew:numericbox id="nbAvanceFisicoAnterior" runat="server" CssClass="normal" Width="50px" MaxLength="5"
																						PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox><asp:label id="lblSignoPorcentaje1" runat="server" Font-Size="X-Small">(%)</asp:label></TD>
																				<TD style="WIDTH: 7px"><cc3:rangedomvalidator id="rrdvAvanceFisicoAnterior" runat="server" ControlToValidate="nbAvanceFisicoAnterior"
																						MinimumValue="0" MaximumValue="100" ErrorMessage="RangeDomValidator">*</cc3:rangedomvalidator></TD>
																			</TR>
																			<TR id="ControlTablaFilaAvanceFisicoActual" bgColor="#dddddd" runat="server">
																				<TD style="WIDTH: 162px; HEIGHT: 22px" vAlign="middle" align="left" width="162" bgColor="#335eb4"><asp:label id="lblAvanceFisicoActual" runat="server" CssClass="TextoBlanco">AVANCE FISICO ACT:</asp:label></TD>
																				<TD style="WIDTH: 192px; HEIGHT: 22px"><asp:textbox id="txtAvanceFisicoActual" runat="server" CssClass="normaldetalle" Width="50px"
																						MaxLength="15" ReadOnly="True"></asp:textbox><ew:numericbox id="nbAvanceFisicoActual" runat="server" CssClass="normal" Width="50px" MaxLength="5"
																						PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox><asp:label id="lblSignoPorcentaje2" runat="server" Font-Size="X-Small">(%)</asp:label></TD>
																				<TD style="HEIGHT: 7px"><cc3:rangedomvalidator id="rrdvAvanceFisicoActual" runat="server" ControlToValidate="nbAvanceFisicoActual"
																						MinimumValue="0" MaximumValue="100" ErrorMessage="RangeDomValidator">*</cc3:rangedomvalidator></TD>
																			</TR>
																			<TR id="ControlTablaFilaRutaImagen" bgColor="#f0f0f0" runat="server">
																				<TD style="WIDTH: 162px" vAlign="middle" align="left" width="162" bgColor="#335eb4"><asp:label id="lblRutaImagen" runat="server" CssClass="TextoBlanco" Visible="False">RUTA DE LA IMAGEN:</asp:label></TD>
																				<TD><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 184px; HEIGHT: 17px" type="file"
																						size="11" name="filMyFile" runat="server"></TD>
																				<TD></TD>
																			</TR>
																		</TABLE>
																	</td>
																	<td vAlign="middle" align="center" bgColor="#f0f0f0"><asp:image id="imgProyecto" runat="server" Width="310px" Height="232px"></asp:image></td>
																</tr>
															</table>
														</td>
													</tr>
													<TR bgColor="#f0f0f0">
														<TD vAlign="top" align="left" width="180" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">DESCRIPCION DETALLADA:&nbsp&nbsp&nbsp</asp:label></TD>
														<TD width="600"><asp:textbox id="txtDescripcionDetallada" runat="server" CssClass="normaldetalle" Width="100%"
																MaxLength="2000" Height="60px" TextMode="MultiLine"></asp:textbox></TD>
														<TD></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD align="right" width="180" bgColor="#335eb4"></TD>
														<TD width="600"><INPUT id="hImagen" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hImagen"
																runat="server"></TD>
														<TD></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD align="right" width="180" bgColor="#335eb4"></TD>
														<TD width="600"></TD>
														<TD></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD align="right" width="180" bgColor="#335eb4"></TD>
														<TD width="600"></TD>
														<TD></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD align="right" width="180" bgColor="#335eb4"></TD>
														<TD width="600"></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td align="center" colSpan="3"><IMG style="WIDTH: 160px; HEIGHT: 10px" height="1" src="../imagenes/spacer.gif" width="160"></td>
										</tr>
										<tr>
											<td align="center" colSpan="3">
												<table id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td align="right"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></td>
														<td width="20"></td>
														<td align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></td>
													</tr>
												</table>
												<cc3:domvalidationsummary id="DomValidationSummary1" runat="server" EnableClientScript="False" ShowMessageBox="True"
													DisplayMode="List"></cc3:domvalidationsummary></td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
