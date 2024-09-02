<%@ Page language="c#" Codebehind="DetalleOrdenTrabajoComoperpac.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleOrdenTrabajoComoperpac" %>
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
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Producción >  Administrar Periodos Convenios COMPOPERPAC > Admini strar Orden de Trabajo ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">DETALLE ORDEN DE TRABAJO</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table10" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD bgColor="#000080">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">REGISTRAR ORDEN DE TRABAJO</asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD align="right" bgColor="#335eb4">
									<asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">CENTRO OPERATIVO:</asp:label></TD>
								<TD style="WIDTH: 227px; HEIGHT: 10px" bgColor="#dddddd">
									<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="225px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1px" align="right" width="165" bgColor="#335eb4">
									<asp:label id="lblDivicion" runat="server" CssClass="TextoBlanco">ORDEN DE TRABAJO:</asp:label></TD>
								<TD style="WIDTH: 227px; HEIGHT: 1px" bgColor="#f0f0f0">
									<asp:dropdownlist id="ddlbDivision" runat="server" CssClass="normaldetalle"></asp:dropdownlist>
									<ew:numericbox id="nbNumero" runat="server" CssClass="normaldetalle" Width="56px" RealNumber="False"
										PositiveNumber="True" MaxLength="6"></ew:numericbox>
									<cc1:requireddomvalidator id="rqdvNumero" runat="server" ControlToValidate="nbNumero" Height="8px">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 165px" align="right" bgColor="#335eb4">
									<asp:Label id="lblMontoAsignado" runat="server" CssClass="TextoBlanco">MONTO ASIGNADO:</asp:Label></TD>
								<TD style="WIDTH: 227px" bgColor="#dddddd">
									<ew:numericbox id="nbMontoAsignado" runat="server" CssClass="normaldetalle" Width="120px" PositiveNumber="True"
										MaxLength="15" TextAlign="Right" PlacesBeforeDecimal="11"></ew:numericbox>
									<asp:DropDownList id="ddlbMoneda" runat="server" CssClass="normaldetalle"></asp:DropDownList></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 165px" align="right" bgColor="#335eb4">
									<asp:Label id="lblEstado" runat="server" CssClass="TextoBlanco">ESTADO:</asp:Label></TD>
								<TD style="WIDTH: 227px" bgColor="#f0f0f0">
									<asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normaldetalle" Width="200px"></asp:dropdownlist></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 165px" align="right" bgColor="#335eb4">
									<asp:Label id="lblFechaPresupuesto" runat="server" CssClass="TextoBlanco"> FECHA PRESUPUESTO:</asp:Label></TD>
								<TD style="WIDTH: 227px" bgColor="#dddddd">
									<ew:calendarpopup id="CalFechaPresupuesto" runat="server" CssClass="combos" Width="72px" MonthYearPopupCancelText="Cancelar"
										MonthYearPopupApplyText="Aplicar" NullableLabelText="Seleccione Fecha" GoToTodayText="Fecha de hoy:"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										ImageUrl="../imagenes/BtPU_Mas.gif">
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
								<TD style="WIDTH: 165px" vAlign="top" align="right" bgColor="#335eb4">
									<asp:Label id="lblDescripcion" runat="server" CssClass="TextoBlanco">DESCRIPCION:</asp:Label></TD>
								<TD style="WIDTH: 227px" bgColor="#f0f0f0">
									<asp:TextBox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="552px" MaxLength="2000"
										Height="54px" TextMode="MultiLine"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 165px" vAlign="top" align="right" bgColor="#335eb4">
									<asp:Label id="lblObservaciones" runat="server" CssClass="TextoBlanco">OBSERVACIONES:</asp:Label></TD>
								<TD style="WIDTH: 227px" bgColor="#dddddd">
									<asp:TextBox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="552px" MaxLength="2000"
										Height="60px" TextMode="MultiLine"></asp:TextBox></TD>
							</TR>
						</TABLE>
						<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD align="center" height="14">&nbsp;
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;
									<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center">
									<cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Width="243px" Height="6px" DisplayMode="List"
										ShowMessageBox="True" EnableClientScript="False"></cc1:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
								<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
			<BR>
		</form>
	</body>
</HTML>
