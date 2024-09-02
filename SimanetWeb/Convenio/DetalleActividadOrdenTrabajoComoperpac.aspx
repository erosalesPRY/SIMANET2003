<%@ Page language="c#" Codebehind="DetalleActividadOrdenTrabajoComoperpac.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleActividadOrdenTrabajoComoperpac" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
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
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción >  Administrar Periodos Convenios COMPOPERPAC > Admini strar Orden de Trabajo > Actividades ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Actvidades</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">MANT DE ACTIVIDADES / TRABAJOS / COMPRA DE REPUESTOS..</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="720" border="1" borderColor="#ffffff">
							<TR>
								<TD style="WIDTH: 176px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">DESCRIPCION:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#f0f0f0"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Height="60px" Width="524px"
										TextMode="MultiLine" MaxLength="2000"></asp:textbox></TD>
								<TD vAlign="top" align="left" bgColor="#f0f0f0"><cc1:requireddomvalidator id="rqdvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblDocumentoAprobacion" runat="server" CssClass="TextoBlanco">DOCUMENTO DE APROBACION:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#dddddd"><asp:textbox id="txtDocumentoAprobacion" runat="server" CssClass="normaldetalle" Height="40px"
										Width="100%" TextMode="MultiLine" MaxLength="200"></asp:textbox></TD>
								<TD vAlign="top" align="left" bgColor="#dddddd"><cc1:requireddomvalidator id="rqdvUnidadNaval" runat="server" ControlToValidate="txtUnidadNaval">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblDependenciaNaval" runat="server" CssClass="TextoBlanco">DEPENDENCIA NAVAL:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#f0f0f0"><asp:textbox id="txtUnidadNaval" runat="server" CssClass="normaldetalle" Width="300px" ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarUnidad" ImageUrl="../imagenes/BtPU_Mas.gif" Runat="server" Visible="False"></asp:imagebutton></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblNroValorizacion" runat="server" CssClass="TextoBlanco">NRO DE VALORIZACION:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#dddddd"><asp:dropdownlist id="ddlbDivision" runat="server" CssClass="normaldetalle"></asp:dropdownlist><ew:numericbox id="nbNumeroVal" runat="server" CssClass="normaldetalle" Width="56px" MaxLength="6"
										RealNumber="False" PositiveNumber="True"></ew:numericbox><asp:textbox id="txtNroValorizacion" runat="server" CssClass="normaldetalle" Width="88px" ReadOnly="True"></asp:textbox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblMontoAsignado" runat="server" CssClass="TextoBlanco">MONTO ASIGNADO NS:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#f0f0f0"><ew:numericbox id="nbMontoAsignado" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										PositiveNumber="True" PlacesBeforeDecimal="11"></ew:numericbox></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblFechaInicio" runat="server" CssClass="TextoBlanco">FECHA DE INICIO:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#dddddd"><ew:calendarpopup id="CalFechaIncio" runat="server" CssClass="combos" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
										PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="Fecha de hoy:" MonthYearPopupApplyText="Aplicar"
										MonthYearPopupCancelText="Cancelar">
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
											BackColor="#FF8A00"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblMontoEjecutado" runat="server" CssClass="TextoBlanco">MONTO EJECUTADO NS:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#f0f0f0"><ew:numericbox id="nbMontoEjecutado" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										PositiveNumber="True" PlacesBeforeDecimal="11"></ew:numericbox></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblAvanceFisico" runat="server" CssClass="TextoBlanco">AVANCE FISICO (%):</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#dddddd"><ew:numericbox id="nbAvanceFisico" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										PositiveNumber="True" PlacesBeforeDecimal="11"></ew:numericbox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblFechaTermino" runat="server" CssClass="TextoBlanco">FECHA DE TERMINO:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#f0f0f0"><ew:calendarpopup id="CalFechaTermino" runat="server" CssClass="combos" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
										PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" GoToTodayText="Fecha de hoy:" MonthYearPopupApplyText="Aplicar"
										MonthYearPopupCancelText="Cancelar" NullableLabelText=" " Text=" " Nullable="True" ClearDateText="Limpiar Fecha">
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
											BackColor="#FF8A00"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblDocumento" runat="server" CssClass="TextoBlanco">DOCUMENTO:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#dddddd"><asp:textbox id="txtDocumento" runat="server" CssClass="normaldetalle" Height="40px" Width="100%"
										TextMode="MultiLine" MaxLength="200"></asp:textbox></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 176px" align="right" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">OBSERVACIONES:</asp:label></TD>
								<TD style="WIDTH: 527px" bgColor="#f0f0f0"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Height="60px" Width="100%"
										TextMode="MultiLine" MaxLength="2000"></asp:textbox></TD>
								<TD bgColor="#f0f0f0"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="720" border="1" borderColor="#ffffff">
							<TR>
								<TD align="center"><INPUT id="hNombreUnidad" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton><INPUT id="hIdUnidadDependenciaCliente" style="WIDTH: 16px; HEIGHT: 10px" type="hidden"
										size="1" name="hCodigo" runat="server">
									<asp:imagebutton id="ibtnCancelar" runat="server" Height="22px" Width="87px" ImageUrl="../imagenes/bt_cancelar.gif"
										CausesValidation="False"></asp:imagebutton><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center"><cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Height="2px" Width="120px" DisplayMode="List"
										ShowMessageBox="True" EnableClientScript="False"></cc1:domvalidationsummary></TD>
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
