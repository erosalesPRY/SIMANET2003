<%@ Page language="c#" Codebehind="DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleValorizacionOrdenTrabajoConvenioSimaMgpADM" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Simanet</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial2();" rightMargin="0" onunload="SubirHistorial();"
		oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9) return false">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR vAlign="baseline" bgColor="#eff7fa">
					<TD vAlign="baseline">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD vAlign="top" bgColor="#eff7fa"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenio SIMA MGP > Administración > Proyecto > Valorizaciones ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle valorización</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="740" align="center" border="0">
							<TR bgColor="#000080">
								<TD><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> CONVENIO SIMA - MGP:</asp:label><INPUT id="hNombreUnidad" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hIdUnidadDependenciaCliente" style="WIDTH: 16px; HEIGHT: 10px" type="hidden"
										size="1" name="hCodigo" runat="server"><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center" width="100%">
									<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
										width="100%" align="center" border="0">
										<TR>
											<TD width="100%">
												<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD>
															<table id="Table6" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" border="1">
																<tr bgColor="#dddddd">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">CENTRO OPERATIVO:&nbsp; </asp:label></td>
																	<td><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Enabled="False"></asp:dropdownlist></td>
																</tr>
																<tr bgColor="#f0f0f0">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblNroValorizacion" runat="server" CssClass="TextoBlanco">NUMERO DE VALORIZACION:&nbsp;</asp:label></td>
																	<td><asp:textbox id="txtNroValorizacion" runat="server" CssClass="normaldetalle" MaxLength="8"></asp:textbox><cc1:requireddomvalidator id="rqdvNroValorizacion" runat="server" ControlToValidate="txtNroValorizacion">*</cc1:requireddomvalidator></td>
																</tr>
																<tr bgColor="#dddddd">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblNroOrdenTrabajo" runat="server" CssClass="TextoBlanco">NUMERO DE ORDEN DE TRABAJO:&nbsp;</asp:label></td>
																	<td><asp:textbox id="txtNroOrdenTrabajo" runat="server" CssClass="normaldetalle" MaxLength="8"></asp:textbox></td>
																</tr>
																<tr bgColor="#f0f0f0">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblAlias" runat="server" CssClass="TextoBlanco">ALIAS:&nbsp; </asp:label></td>
																	<td><asp:textbox id="txtAlias" runat="server" CssClass="normaldetalle" MaxLength="12"></asp:textbox></td>
																</tr>
																<tr bgColor="#dddddd">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblUnidadNaval" runat="server" CssClass="TextoBlanco">UNIDAD NAVAL:&nbsp;  </asp:label></td>
																	<td><asp:textbox id="txtUnidadNaval" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="226px"></asp:textbox><asp:imagebutton id="ibtnBuscarUnidad" Runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:imagebutton><cc1:requireddomvalidator id="rqdvUnidadNaval" runat="server" ControlToValidate="txtUnidadNaval">*</cc1:requireddomvalidator></td>
																</tr>
																<tr bgColor="#f0f0f0">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblPrecioVenta" runat="server" CssClass="TextoBlanco">PRECIO DE VENTA. NS:&nbsp;   </asp:label></td>
																	<td><ew:numericbox id="nbPrecioVenta" runat="server" CssClass="normaldetalle" MaxLength="15" Width="120px"
																			PositiveNumber="True" PlacesBeforeDecimal="12"></ew:numericbox></td>
																</tr>
																<tr bgColor="#dddddd">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco">ESTADO:&nbsp;   </asp:label></td>
																	<td><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normaldetalle"></asp:dropdownlist></td>
																</tr>
																<TR id="ControlTablaFilaFechaInicio" bgColor="#f0f0f0" runat="server">
																	<TD style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblFechaIncio" runat="server" CssClass="TextoBlanco">FECHA DE INICIO:&nbsp;</asp:label></TD>
																	<TD><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="combos" Width="80px" ImageUrl="../imagenes/BtPU_Mas.gif"
																			MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aplicar" Culture="Spanish (Chile)"
																			Text="..." ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="La Fecha de Hoy:"
																			ClearDateText="Limpiar Fecha" NullableLabelText="Limpiar Fecha" Nullable="True">
																			<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
																				BackColor="Transparent"></SelectedDateStyle>
																			<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																				BackColor="White"></ClearDateStyle>
																			<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																				BackColor="White"></HolidayStyle>
																		</ew:calendarpopup></TD>
																</TR>
																<TR id="ControlTablaFilaFechaTermino" bgColor="#dddddd" runat="server">
																	<TD style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblFechaTermino" runat="server" CssClass="TextoBlanco">FECHA DE TERMINO:&nbsp;</asp:label></TD>
																	<TD><ew:calendarpopup id="CalFechaTermino" runat="server" CssClass="combos" Width="80px" ImageUrl="../imagenes/BtPU_Mas.gif"
																			MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aplicar" Culture="Spanish (Chile)"
																			Text="..." ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="La Fecha de Hoy:"
																			ClearDateText="Limpiar Fecha" NullableLabelText="Limpiar Fecha" Nullable="True">
																			<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
																				BackColor="Yellow"></SelectedDateStyle>
																			<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																				BackColor="White"></ClearDateStyle>
																			<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																				BackColor="White"></HolidayStyle>
																		</ew:calendarpopup><asp:comparevalidator id="cpdvFechaOrdenTrabajo" runat="server" ControlToValidate="CalFechaTermino" Operator="GreaterThanEqual"
																			ControlToCompare="CalFechaInicio" Type="Date" ErrorMessage="CompareValidator">*</asp:comparevalidator></TD>
																</TR>
																<tr id="ControlTablaFilaAvanceFisico" bgColor="#f0f0f0" runat="server">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblAvanceFisico" runat="server" CssClass="TextoBlanco">AVANCE FISICO (%):&nbsp;</asp:label></td>
																	<td><ew:numericbox id="nbAvanceFisico" runat="server" CssClass="normaldetalle" MaxLength="5" Width="96px"
																			PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox></td>
																</tr>
																<tr id="ControlTablaFilaDocumentoAprobacion" bgColor="#dddddd" runat="server">
																	<td style="WIDTH: 221px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblDocumentoAprobación" runat="server" CssClass="TextoBlanco">DOCUMENTO DE APROBACION:&nbsp; </asp:label></td>
																	<td><asp:textbox id="txtDocumentoAprobacion" runat="server" CssClass="normaldetalle" MaxLength="150"
																			Width="100%" TextMode="MultiLine"></asp:textbox></td>
																</tr>
																<tr id="ControlTableFilaNroDocumentoAprovacion" bgColor="#f0f0f0" runat="server">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblNroDocumentoAprobacion" runat="server" CssClass="TextoBlanco">NRO DE DOCUMENTO DE APROBACION:&nbsp; </asp:label></td>
																	<td><asp:textbox id="txtNroDocumentoAprobacion" runat="server" CssClass="normaldetalle" MaxLength="20"
																			Width="226px"></asp:textbox></td>
																</tr>
																<tr id="ControlTableFilaNroDocumentoReferencia" bgColor="#dddddd" runat="server">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblFechaAprobacionDocumento" runat="server" CssClass="TextoBlanco"> FECHA DE APROBACION DOCUMENTO:&nbsp; </asp:label></td>
																	<td><ew:calendarpopup id="CalFechaAprobacionDocumento" runat="server" CssClass="combos" Width="80px" ImageUrl="../imagenes/BtPU_Mas.gif"
																			MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aplicar" Culture="Spanish (Chile)"
																			Text="..." ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="La Fecha de Hoy:"
																			ClearDateText="Limpiar Fecha" NullableLabelText="Limpiar Fecha" Nullable="True">
																			<TextboxLabelStyle CssClass="normaldetalle"></TextboxLabelStyle>
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
																				BackColor="Yellow"></SelectedDateStyle>
																			<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																				BackColor="White"></ClearDateStyle>
																			<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
																				BackColor="White"></HolidayStyle>
																		</ew:calendarpopup></td>
																</tr>
																<tr id="ControlTablaFilaActaAprobacion" bgColor="#f0f0f0" runat="server">
																	<td style="WIDTH: 221px" align="right" bgColor="#335eb4"><asp:label id="lblActaAprobación" runat="server" CssClass="TextoBlanco">CON ACTA DE APROBACION:&nbsp; </asp:label></td>
																	<td><asp:checkbox id="ckbActaAprovacion" runat="server" CssClass="normal"></asp:checkbox></td>
																</tr>
																<tr bgColor="#dddddd">
																	<td style="WIDTH: 221px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco"> DESCRIPCION:&nbsp; </asp:label></td>
																	<td><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="100%"
																			TextMode="MultiLine" Height="72px"></asp:textbox></td>
																</tr>
																<TR>
																	<TD style="WIDTH: 221px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">OBSERVACIONES:&nbsp; </asp:label></TD>
																	<TD><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="100%"
																			TextMode="MultiLine" Height="72px"></asp:textbox></TD>
																</TR>
															</table>
														</TD>
													</TR>
													<TR>
														<TD style="HEIGHT: 16px" align="center"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD style="WIDTH: 358px" align="right"><INPUT id="objHistorial" type="hidden"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																	<td style="WIDTH: 73px" width="73"></td>
																	<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial(); HistorialIrAtras();"
																			alt="" src="/SimanetWeb/imagenes/bt_cancelar.gif"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Width="136px" EnableClientScript="False"
										DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 769px"></TD>
							</TR>
						</TABLE>
						<IMG height="10" src="../imagenes/spacer.gif" width="120">
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
