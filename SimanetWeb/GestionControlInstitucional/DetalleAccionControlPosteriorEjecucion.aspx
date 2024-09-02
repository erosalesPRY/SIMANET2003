<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleAccionControlPosteriorEjecucion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.GestionControlInstitucional.DetalleAccionControlPosteriorEjecucion" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control Institucional > </asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Detalle de la Ejecucion de las Acciones de Control Posterior</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="600" border="1"
							borderColor="#ffffff">
							<TR>
								<TD bgColor="#000080" colSpan="2">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:label id="lblAccionCtrlPosterior" runat="server" CssClass="TextoBlanco">Accion Control Posterior:</asp:label></TD>
								<TD bgColor="#dddddd">
									<asp:textbox id="txtAccionCtrlPosterior" runat="server" CssClass="normaldetalle" MaxLength="80"
										Width="336px" ReadOnly="True"></asp:textbox>
									<asp:imagebutton id="ibtnBuscarAccionCtrlPosterior" runat="server" CssClass="normaldetalle" ImageUrl="../imagenes/BtPU_Mas.gif"
										CausesValidation="False"></asp:imagebutton></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvAccionCtrlPosterior" runat="server" ControlToValidate="txtAccionCtrlPosterior">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:label id="lblMetaProgramada" runat="server" CssClass="TextoBlanco">Meta Programada:</asp:label></TD>
								<TD bgColor="#f0f0f0">
									<ew:numericbox id="nbMetaProgramada" runat="server" CssClass="normaldetalle" MaxLength="6" Width="136px"
										PositiveNumber="True" PlacesBeforeDecimal="4"></ew:numericbox></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvMetaProgramada" runat="server" ControlToValidate="nbMetaProgramada">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4" style="HEIGHT: 14px">
										<asp:Label id="lblEstadoCtrl" runat="server" CssClass="TextoBlanco">Estado:</asp:Label>
								</TD>
								<TD bgColor="#dddddd" id=CellddlbEstadoCtrl runat="server" class=normaldetalle>
									<asp:DropDownList id="ddlbEstadoCtrl" runat="server" CssClass="normaldetalle" Width="336px"></asp:DropDownList></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvEstadoCtrl" runat="server" ControlToValidate="ddlbEstadoCtrl">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblEtapa" runat="server" CssClass="TextoBlanco">Etapa:</asp:Label></TD>
								<TD bgColor="#f0f0f0" id=CellddlbEtapa runat="server" class=normaldetalle>
									<asp:DropDownList id="ddlbEtapa" runat="server" CssClass="normaldetalle" Width="336px"></asp:DropDownList></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvEtapa" runat="server" ControlToValidate="ddlbEtapa">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblPorcentajeAvanceTotal" runat="server" CssClass="TextoBlanco">Porcentaje Avance Total:</asp:Label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox id="nbPorcentajeAvanceTotal" runat="server" CssClass="normaldetalle" MaxLength="5"
										Width="136px" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="3"></ew:numericbox></TD>
								<TD>
									<cc2:RequiredDomValidator id="rfvPorcentajeAvanceTotal" runat="server" ControlToValidate="nbPorcentajeAvanceTotal">*</cc2:RequiredDomValidator></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblFechaInicio" runat="server" CssClass="TextoBlanco">Fecha Inicio:</asp:Label></TD>
								<TD bgColor="#f0f0f0">
									<ew:calendarpopup id="calFechaInicio" runat="server" CssClass="normaldetalle" Width="88px" ImageUrl="../imagenes/BtPU_Mas.gif"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblFechaTermino" runat="server" CssClass="TextoBlanco">Fecha Termino:</asp:Label></TD>
								<TD bgColor="#dddddd">
									<ew:calendarpopup id="calFechaTermino" runat="server" CssClass="normaldetalle" Width="88px" ImageUrl="../imagenes/BtPU_Mas.gif"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										Nullable="True">
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
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblNroRealIntegrantesOCI" runat="server" CssClass="TextoBlanco">Nro Real Integrantes OCI:</asp:Label></TD>
								<TD bgColor="#f0f0f0">
									<ew:numericbox id="nbNroRealIntegrantesOCI" runat="server" CssClass="normaldetalle" MaxLength="4"
										Width="136px" RealNumber="False" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblNroRealIntegrantesEspecialistas" runat="server" CssClass="TextoBlanco">Nro Real Integrantes Especialistas:</asp:Label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox id="nbNroRealIntegrantesEspecialistas" runat="server" CssClass="normaldetalle" MaxLength="4"
										Width="136px" RealNumber="False" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblCostoRealOCI" runat="server" CssClass="TextoBlanco">Costo Real OCI:</asp:Label></TD>
								<TD bgColor="#f0f0f0">
									<ew:numericbox id="nbCostoRealOCI" runat="server" CssClass="normaldetalle" MaxLength="15" Width="136px"
										PositiveNumber="True" DecimalPlaces="4" PlacesBeforeDecimal="10"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblCostoRealEspecialistas" runat="server" CssClass="TextoBlanco">Costo Real Especialistas:</asp:Label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox id="nbCostoRealEspecialistas" runat="server" CssClass="normaldetalle" MaxLength="15"
										Width="136px" PositiveNumber="True" DecimalPlaces="4" PlacesBeforeDecimal="10"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblNumeroRealHH" runat="server" CssClass="TextoBlanco">Numero Real HH:</asp:Label></TD>
								<TD bgColor="#f0f0f0">
									<ew:numericbox id="nbNumeroRealHH" runat="server" CssClass="normaldetalle" MaxLength="6" Width="136px"
										PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblMontoExaminado" runat="server" CssClass="TextoBlanco">MontoExaminado:</asp:Label></TD>
								<TD bgColor="#dddddd">
									<ew:numericbox id="nbMontoExaminado" runat="server" CssClass="normaldetalle" MaxLength="15" Width="136px"
										PositiveNumber="True" DecimalPlaces="4"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD bgColor="#335eb4">
									<asp:Label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:Label></TD>
								<TD bgColor="#f0f0f0">
									<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="4000" Width="336px"
										TextMode="MultiLine" Height="54px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD id="TdCeldaCancelar" align="left" colSpan="3" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><INPUT id="hIdAccionControlPosterior" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="hIdAccionControlPosterior" runat="server">
									<cc2:domvalidationsummary id="vSum" runat="server" ShowMessageBox="True" DisplayMode="List" EnableClientScript="False"></cc2:domvalidationsummary></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3">
									<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../imagenes/bt_aceptar.gif"
										Height="22px"></asp:imagebutton>
									<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" CausesValidation="False" ImageUrl="../imagenes/bt_cancelar.gif"
										Height="22px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
</TD></TR>
	</body>
</HTML>