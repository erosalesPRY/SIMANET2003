<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleProgramacionActividades.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstituacional.DetalleProgramacionActividades" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Programación de Inspecciones</asp:label></TD>
							</TR>
						</TABLE>
				<TR>
					<TD vAlign="top" align="center"><SPAN class="normal"></SPAN>
						<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
							width="650" align="center" border="1">
							<TR>
								<TD class="TituloPrincipalBlanco" align="left" width="475" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label1" runat="server" CssClass="TextoBlanco"> Organismo:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4">
									<asp:dropdownlist id="ddlbOrganismo" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label5" runat="server" CssClass="TextoBlanco">Nro. Documento:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" MaxLength="50" Width="250px"></asp:textbox></TD>
								<TD class="normal" colSpan="2"><cc1:requireddomvalidator id="rfvNroDocumento" runat="server" ControlToValidate="txtNroDocumento">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label10" runat="server" CssClass="TextoBlanco">ARCHIVO REFERENCIA:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><INPUT class="normaldetalle" id="flArchivoReferencia" style="WIDTH: 100%; HEIGHT: 22px"
										type="file" size="63" runat="server"></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label4" runat="server" CssClass="TextoBlanco">Fecha Documento:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><ew:calendarpopup id="CalFechaDocumento" runat="server" CssClass="normaldetalle" Width="80px" ImageUrl="../imagenes/BtPU_Mas.gif"
										PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" ClearDateText="Limpiar Fecha" DisableTextboxEntry="False"
										NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" AllowArbitraryText="False">
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
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label8" runat="server" CssClass="TextoBlanco">Centro Operativo:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4">
									<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Tipo:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbTipoDocumento" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label9" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4">
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label3" runat="server" CssClass="TextoBlanco">Período:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4">
									<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normaldetalle" Height="70px" Width="64px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label6" runat="server" CssClass="TextoBlanco">Fecha Inicio:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:calendarpopup id="calFechaInicio" runat="server" CssClass="normaldetalle" Width="80px" ImageUrl="../imagenes/BtPU_Mas.gif"
										PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" ClearDateText="Limpiar Fecha" DisableTextboxEntry="False"
										NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" AllowArbitraryText="False">
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
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label7" runat="server" CssClass="TextoBlanco">Fecha Término:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4">
									<ew:calendarpopup id="calFechaTermino" runat="server" CssClass="normaldetalle" Width="80px" AllowArbitraryText="False"
										GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:"
										DisableTextboxEntry="False" ClearDateText="Limpiar Fecha" ShowGoToToday="True" ControlDisplay="TextBoxImage"
										Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../imagenes/BtPU_Mas.gif" Nullable="True">
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
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4">
									<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Asunto:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4">
									<asp:textbox id="txtAsunto" runat="server" CssClass="normaldetalle" Height="50px" MaxLength="1500"
										Width="100%" TextMode="MultiLine"></asp:textbox></TD>
								<TD class="normal" colSpan="2">
									<cc1:requireddomvalidator id="rfvAsunto" runat="server" ControlToValidate="txtAsunto">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco"> Observaciones:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Height="50px" MaxLength="1500"
										Width="500px" TextMode="MultiLine"></asp:textbox></TD>
								<TD class="normal"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" width="630" align="center" border="0">
							<TR>
								<TD align="center">
									<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif">
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
						<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" ShowMessageBox="True" EnableClientScript="False"
							DisplayMode="List"></cc1:domvalidationsummary></TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
