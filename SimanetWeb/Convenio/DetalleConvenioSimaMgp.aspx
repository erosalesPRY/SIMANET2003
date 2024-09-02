<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionConvenioSimaMgp" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Simanet</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR width="100%">
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración >  Convenios SIMA - MGP ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> DETALLE DE CONVENIO</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table8" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="726" border="1">
							<TR>
								<TD style="WIDTH: 170px; HEIGHT: 18px" align="left" bgColor="#000080" colSpan="4"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="White"> DETALLE CONVENIO:</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 170px; HEIGHT: 18px" align="right" bgColor="#335eb4"><asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco">PERIODO:</asp:label>&nbsp;</TD>
								<TD style="WIDTH: 174px" bgColor="#f0f0f0"><ew:numericbox id="nbPeriodo" runat="server" CssClass="normaldetalle" RealNumber="False" PositiveNumber="True"
										MaxLength="4" Width="88px"></ew:numericbox><cc1:requireddomvalidator id="rqdvPeriodo" runat="server" ControlToValidate="nbPeriodo">*</cc1:requireddomvalidator><cc1:rangedomvalidator id="rdvPeriodo" runat="server" ControlToValidate="nbPeriodo" MinimumValue="2000"
										MaximumValue="2050">*</cc1:rangedomvalidator></TD>
								<TD style="WIDTH: 102px" align="right" bgColor="#335eb4"><asp:label id="lblNumero" runat="server" CssClass="TextoBlanco">NUMERO: &nbsp;</asp:label></TD>
								<TD bgColor="#f0f0f0"><ew:numericbox id="nbNumero" runat="server" CssClass="normaldetalle" RealNumber="False" PositiveNumber="True"
										MaxLength="2" Width="56px"></ew:numericbox><cc1:requireddomvalidator id="rqdvNumero" runat="server" ControlToValidate="nbNumero" ErrorMessage="==> Número no fue Ingresado">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 170px" align="right" bgColor="#335eb4"><asp:label id="lblNroConvenio" runat="server" CssClass="TextoBlanco" Width="73px" Height="8px"> CONVENIO:</asp:label>&nbsp;</TD>
								<TD style="WIDTH: 174px" bgColor="#dddddd"><asp:textbox id="txtNroConvenio" runat="server" CssClass="normaldetalle" Width="88px" BackColor="WhiteSmoke"
										ReadOnly="True"></asp:textbox></TD>
								<TD style="WIDTH: 102px" bgColor="#dddddd"></TD>
								<TD bgColor="#dddddd"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table9" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="726" border="1">
							<TR>
								<TD style="WIDTH: 165px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco" Width="74px" Height="16px"> DESCRIPCION:</asp:label></TD>
								<TD style="WIDTH: 233px; HEIGHT: 59px" bgColor="#f0f0f0"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="538px"
										Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px; HEIGHT: 13px" align="right" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco" Width="52px" Height="8px"> ESTADO:</asp:label></TD>
								<TD style="WIDTH: 233px; HEIGHT: 13px" bgColor="#dddddd"><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normaldetalle" Width="144px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" align="right" bgColor="#335eb4"><asp:label id="lblSitucionPago" runat="server" CssClass="TextoBlanco"> SITUACION DE PAGO:</asp:label></TD>
								<TD style="WIDTH: 233px" bgColor="#f0f0f0"><asp:dropdownlist id="ddlbSituacionPago" runat="server" CssClass="normaldetalle" Width="144px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" align="right" bgColor="#335eb4"><asp:label id="lblFechaVencimiento" runat="server" CssClass="TextoBlanco"> VENCIMIENTO:</asp:label>&nbsp;</TD>
								<TD style="WIDTH: 233px" bgColor="#dddddd"><ew:calendarpopup id="CalFechaVencimiento" runat="server" Width="72px" ImageUrl="../imagenes/BtPU_Mas.gif"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" PadSingleDigits="True" Culture="Spanish (Chile)">
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
							</TR>
							<TR>
								<TD style="WIDTH: 160px" align="right" bgColor="#335eb4">
									<asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="116px">MONTO AUTORIZADO:</asp:label>&nbsp;&nbsp;&nbsp;
								</TD>
								<TD style="WIDTH: 233px" bgColor="#f0f0f0">
									<ew:numericbox id="nbMontoAUTORIZADO" runat="server" CssClass="normaldetalle" Width="120px" MaxLength="15"
										PositiveNumber="True" DecimalPlaces="3" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco"> OBSERVACIONES:</asp:label>&nbsp;</TD>
								<TD style="WIDTH: 233px" bgColor="#f0f0f0"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="538px"
										Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" bgColor="#335eb4" vAlign="top" align="right">
									<asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="TextoBlanco" Width="120px">CONTRA CARTA FIANZA</asp:label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox style="Z-INDEX: 0" id="txtCartaFianza" runat="server" CssClass="normaldetalle" Width="120px"
										MaxLength="15" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" DecimalPlaces="3"></ew:numericbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" bgColor="#335eb4" vAlign="top" align="right">
									<asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="TextoBlanco"> OBSERVACIONES FIANZA:</asp:label></TD>
								<TD style="WIDTH: 233px" bgColor="#f0f0f0">
									<asp:textbox style="Z-INDEX: 0" id="txtObservacionesFianza" runat="server" CssClass="normaldetalle"
										Width="538px" MaxLength="2000" Height="56px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 160px" bgColor="#335eb4" vAlign="top" align="right">
									<asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="TextoBlanco">Archivo:</asp:label></TD>
								<TD style="WIDTH: 233px" bgColor="#f0f0f0"><INPUT style="Z-INDEX: 0; WIDTH: 448px; HEIGHT: 22px" id="filContrato" class="normaldetalle"
										size="55" type="file" name="filContrato" runat="server"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" style="HEIGHT: 106px" cellSpacing="0" cellPadding="0" width="730" border="0">
							<TR>
								<TD style="HEIGHT: 12px" align="center" colSpan="3"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"><BR>
									<cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Width="120px" Height="2px" DisplayMode="List"
										ShowMessageBox="True" EnableClientScript="False"></cc1:domvalidationsummary><INPUT style="Z-INDEX: 0" id="hContrato" size="1" type="hidden" name="hContrato" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</FORM>
	</body>
</HTML>
