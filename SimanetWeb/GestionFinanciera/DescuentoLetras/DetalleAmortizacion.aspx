<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleAmortizacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.DetalleAmortizacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<!--oncontextmenu="return false" -->
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Amortización de Letras en Descuento</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="522" border="0" style="WIDTH: 522px; HEIGHT: 167px">
							<TR>
								<TD bgColor="#000080" colSpan="9">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="304px" Height="16px">DETALLE AMORTIZACIÓN DE DE LETRAS</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 11px">
									<asp:label id="Label18" runat="server">Fecha de Inicio:</asp:label></TD>
								<TD style="WIDTH: 114px; HEIGHT: 11px">
									<ew:calendarpopup id="CalFecha" runat="server" CssClass="normaldetalle" Width="64px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar"
										MonthYearPopupCancelText="Cancelar" NullableLabelText="Seleccione una fecha:" PadSingleDigits="True"
										Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True">
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
								<TD style="WIDTH: 2px; HEIGHT: 11px"></TD>
								<TD class="HeaderDetalle" style="WIDTH: 24px; HEIGHT: 11px">
									<asp:label id="Label4" runat="server">Situación :</asp:label></TD>
								<TD style="WIDTH: 105px; HEIGHT: 11px" colSpan="4">
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="128px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 11px"></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 11px">
									<asp:label id="Label9" runat="server" Width="123px">Monto :</asp:label></TD>
								<TD style="WIDTH: 114px; HEIGHT: 11px">
									<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="104px" TextAlign="Right"
										AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2"
										MaxLength="15">0</ew:numericbox></TD>
								<TD style="WIDTH: 2px; HEIGHT: 11px">
									<cc1:requireddomvalidator id="rfvMonto" tabIndex="3" runat="server" Width="8px" ControlToValidate="nMonto">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle" style="WIDTH: 24px; HEIGHT: 11px">
									<asp:label id="Label3" runat="server" Width="104px">Monto Interés :</asp:label></TD>
								<TD style="WIDTH: 105px; HEIGHT: 11px" colSpan="4">
									<ew:numericbox id="nMontoInteres" runat="server" CssClass="normaldetalle" Width="127px" TextAlign="Right"
										AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="8" DecimalPlaces="2"
										MaxLength="15">0</ew:numericbox></TD>
								<TD style="HEIGHT: 11px">
									<cc1:requireddomvalidator id="rfvMontoInteres" tabIndex="3" runat="server" Width="8px" ControlToValidate="nMontoInteres">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px">
									<asp:label id="Label10" runat="server">Observación :</asp:label></TD>
								<TD colSpan="7" align="left">
									<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" Width="386px"
										TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"></TD>
								<TD style="HEIGHT: 47px" colSpan="7" rowSpan="2">
									<TABLE id="ToolBar" cellSpacing="1" cellPadding="1" width="112" align="right" border="0"
										runat="server">
										<TR>
											<TD>
												<P align="right">
													<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
											</TD>
											<TD>
												<P align="right"><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></P>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 47px" rowSpan="2"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="tblAtras" cellSpacing="1" cellPadding="1" width="541" border="0" runat="server"
							style="WIDTH: 541px; HEIGHT: 23px">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" ShowMessageBox="True" EnableClientScript="False"
							DisplayMode="List"></cc1:domvalidationsummary></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
