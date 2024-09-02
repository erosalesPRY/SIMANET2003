<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleAccionesControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleAccionesControl" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" align="center" border="0" width="100%">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Acciones de Observación</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD align="center"><SPAN class="normal"></SPAN>
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" align="center" border="1"
										width="600" borderColor="#ffffff">
										<TR>
											<TD class="TituloPrincipalBlanco" colSpan="8" align="left" vAlign="top" bgColor="#000080"
												rowSpan="1"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server"></asp:label></TD>
											<TD class="TituloPrincipalBlanco" vAlign="top" align="left"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label3" runat="server" CssClass="TextoBlanco">Documento:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4">
												<asp:textbox id="txtDocumento" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="500"></asp:textbox></TD>
											<TD class="normal">
												<cc1:requireddomvalidator id="rfvDocumento" runat="server" ControlToValidate="txtDocumento">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4">
												<ew:calendarpopup id="CalFechaAccion" runat="server" CssClass="normaldetalle" Width="80px" ImageUrl="../imagenes/BtPU_Mas.gif"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
													AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
													NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False" ClearDateText="Limpiar Fecha">
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
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Archivo:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4"><INPUT id="filMyFile" style="WIDTH: 490px; HEIGHT: 22px" type="file" size="62" name="FileTexto"
													runat="server"></TD>
											<TD class="normal"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Descripción:</asp:label></TD>
											<TD class="normal" colSpan="4" rowSpan="1" bgColor="#f0f0f0">
												<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="490px" MaxLength="500"
													Height="100px" TextMode="MultiLine"></asp:textbox></TD>
											<TD class="normal"><cc1:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco" Width="83px"> Situación:</asp:label></TD>
											<TD class="normal" colSpan="4" bgColor="#dddddd"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" MaxLength="8000" TextMode="MultiLine"
													Height="104px" Width="490px"></asp:textbox></TD>
											<TD class="normal">
												<cc1:requireddomvalidator id="rfvObservacion" runat="server" ControlToValidate="txtObservacion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label5" runat="server" CssClass="TextoBlanco" Width="83px">Opinon de la oci</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4">
												<asp:textbox id="txtOpinion" runat="server" CssClass="normaldetalle" MaxLength="8000" Width="490px"
													TextMode="MultiLine" Height="104px"></asp:textbox></TD>
											<TD class="normal"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" border="0" align="center" width="590">
										<TR>
											<TD align="center">&nbsp;
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;
												<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"
													style="CURSOR: hand"> <SPAN class="normal"></SPAN>
											</TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
						<cc1:DomValidationSummary id="vSum" runat="server" Width="88px" Height="22px" ShowMessageBox="True" EnableClientScript="False"
							DisplayMode="List"></cc1:DomValidationSummary></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
