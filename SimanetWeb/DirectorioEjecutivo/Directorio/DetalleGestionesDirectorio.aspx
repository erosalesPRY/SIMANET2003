<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleGestionesDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.DetalleGestionesDirectorio" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0" width="100%" align="center">
							<TR>
								<TD class="Commands" style="WIDTH: 590px; HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Gestiones de Directorio</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center"></TD>
							</TR>
							<TR>
								<TD align="center"><SPAN class="normal"></SPAN>
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff"
										width="480">
										<TR>
											<TD class="TituloPrincipalBlanco" vAlign="top" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
											<TD class="normal" style="WIDTH: 298px; HEIGHT: 16px" colSpan="4"></TD>
											<TD class="normal" style="WIDTH: 27px; HEIGHT: 16px" colSpan="2"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
											<TD class="normal" colSpan="4" bgColor="#dddddd">
												<ew:calendarpopup id="CalFechaGestion" runat="server" CssClass="normaldetalle" Width="80px" ImageUrl="../../imagenes/BtPU_Mas.gif"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
													AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
													NullableLabelText="Seleccione una fecha:" DisableTextboxEntry="False">
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
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Gestión:</asp:label></TD>
											<TD class="normal" colSpan="4" rowSpan="1" bgColor="#f0f0f0">
												<asp:textbox id="txtGestion" runat="server" CssClass="normaldetalle" Width="400px" MaxLength="400"
													Height="80px" TextMode="MultiLine"></asp:textbox></TD>
											<TD class="normal" colSpan="2"><cc1:requireddomvalidator id="rfvGestion" runat="server" ControlToValidate="txtGestion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4"><asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco" Width="94px"> Descripción:</asp:label></TD>
											<TD class="normal" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="400px" MaxLength="1500"
													TextMode="MultiLine" Height="120px"></asp:textbox></TD>
											<TD class="normal"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" border="0" align="center" width="510">
										<TR>
											<TD align="center">&nbsp;
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;
												<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													style="CURSOR: hand"> <SPAN class="normal"></SPAN>
											</TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<cc1:DomValidationSummary id="vSum" runat="server" Width="88px" Height="22px" ShowMessageBox="True" EnableClientScript="False"
							DisplayMode="List"></cc1:DomValidationSummary>
					</td>
				</tr>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
