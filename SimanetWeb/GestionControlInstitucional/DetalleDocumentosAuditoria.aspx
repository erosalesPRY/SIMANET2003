<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleDocumentosAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstituacional.DetalleDocumentosAuditoria" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Registro documento de auditoría</title>
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
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Documentos de Auditoría</asp:label></TD>
							</TR>
						</TABLE>
				<TR>
					<TD vAlign="top" align="center"><SPAN class="normal"></SPAN>
						<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
							width="700" align="center" border="1">
							<TR>
								<TD class="TituloPrincipalBlanco" align="left" width="475" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" style="HEIGHT: 6px" bgColor="#335eb4"><asp:label id="Label10" runat="server" CssClass="TextoBlanco">Organismo:</asp:label></TD>
								<TD class="normal" style="HEIGHT: 6px" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbOrganismo" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"
										AutoPostBack="True"></asp:dropdownlist></TD>
								<TD class="normal" style="HEIGHT: 6px" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" style="HEIGHT: 15px" bgColor="#335eb4"><asp:label id="Label11" runat="server" CssClass="TextoBlanco" Width="140px"> Sub-Organismo</asp:label></TD>
								<TD class="normal" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddblSubOrganismo" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"
										AutoPostBack="True"></asp:dropdownlist></TD>
								<TD class="normal" style="HEIGHT: 15px" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" style="HEIGHT: 15px" bgColor="#335eb4" noWrap><asp:label id="Label2" runat="server" CssClass="TextoBlanco" Width="148px">Acción de Control:</asp:label></TD>
								<TD class="normal" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbActividad" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" style="HEIGHT: 15px" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Periodo:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normaldetalle" Height="70px" Width="64px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" style="HEIGHT: 16px" bgColor="#335eb4"><asp:label id="Label8" runat="server" CssClass="TextoBlanco">Centro Operativo:</asp:label></TD>
								<TD class="normal" style="HEIGHT: 16px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" style="HEIGHT: 16px" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label5" runat="server" CssClass="TextoBlanco">Nro. Documento:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="250px" MaxLength="50"></asp:textbox></TD>
								<TD class="normal" colSpan="2"><cc1:requireddomvalidator id="rfvNroDocumento" runat="server" ControlToValidate="txtNroDocumento">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label4" runat="server" CssClass="TextoBlanco">Fecha Documento:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><ew:calendarpopup id="CalFechaDocumento" runat="server" CssClass="normaldetalle" Width="80px" AllowArbitraryText="False"
										GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False"
										ClearDateText="Limpiar Fecha" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../imagenes/BtPU_Mas.gif">
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
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label6" runat="server" CssClass="TextoBlanco">Fecha Inicio:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4"><ew:calendarpopup id="calFechaInicio" runat="server" CssClass="normaldetalle" Width="80px" AllowArbitraryText="False"
										GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False"
										ClearDateText="Limpiar Fecha" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../imagenes/BtPU_Mas.gif">
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
								<TD class="normal" bgColor="#f0f0f0" colSpan="4"><ew:calendarpopup id="calFechaTermino" runat="server" CssClass="normaldetalle" Width="80px" AllowArbitraryText="False"
										GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False"
										ClearDateText="Limpiar Fecha" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../imagenes/BtPU_Mas.gif"
										Nullable="True">
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
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label9" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4" width="100%"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
								<TD class="normal" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco"> Descripción:</asp:label></TD>
								<TD class="normal" bgColor="#dddddd" colSpan="4" width="100%"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Height="50px" Width="100%"
										MaxLength="1500" TextMode="MultiLine"></asp:textbox></TD>
								<TD class="normal" colSpan="2"><cc1:requireddomvalidator id="rfvObservacion" runat="server" ControlToValidate="txtObservaciones">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">Situación Actual:</asp:label></TD>
								<TD class="normal" bgColor="#f0f0f0" colSpan="4" width="100%"><asp:textbox id="txtSituacionActual" runat="server" CssClass="normaldetalle" Height="50px" Width="100%"
										MaxLength="1500" TextMode="MultiLine"></asp:textbox></TD>
								<TD class="normal" colSpan="2"><cc1:requireddomvalidator id="rfvSituacionActual" runat="server" ControlToValidate="txtSituacionActual">*</cc1:requireddomvalidator></TD>
							</TR>
						</TABLE>
						<TABLE id="Table7" width="630" align="center" border="0">
							<TR>
								<TD align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif">
									<INPUT id="hIdPersonal" style="WIDTH: 9px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonal"
										runat="server"> <SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
						<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" DisplayMode="List" EnableClientScript="False"
							ShowMessageBox="True"></cc1:domvalidationsummary></TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE></TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
