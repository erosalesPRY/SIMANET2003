<%@ Page language="c#" Codebehind="DetalleCartadeCreditoNotadeCargo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.DetalleCartadeCreditoNotadeCargo" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Carta de Crédito (Nota de Cargo)</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><IMG style="WIDTH: 250px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="250"
							DESIGNTIMEDRAGDROP="213"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="727" border="0" style="WIDTH: 727px; HEIGHT: 193px">
							<TR>
								<TD style="WIDTH: 583px; HEIGHT: 27px" bgColor="#000080" colSpan="9">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="424px">DETALLE ADMINISTRACION NOTA DE CARGO (CARTA DE CRÉDITO)</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 120px" class="Headerdetalle">
									<asp:label class="" id="lblInformeEmitido" runat="server" Width="136px">Fecha de Cancelacion:</asp:label></TD>
								<TD>
									<ew:calendarpopup id="CalFechaCancelacion" runat="server" CssClass="normaldetalle" Height="22px" Width="70px"
										ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
										ImageUrl="../../imagenes/BtPU_Mas.gif" CalendarWidth="2" DisableTextboxEntry="False" Font-Names="Arial"
										ForeColor="Navy" BorderStyle="None" CalendarLocation="Bottom">
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
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="Gray"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="LightGray"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="#FF8A00"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD></TD>
								<TD class="Headerdetalle">
									<asp:label class="" id="Label1" runat="server" Width="110px">Situación:</asp:label></TD>
								<TD width="163" style="WIDTH: 163px">
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="134px" Height="24px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 21px"></TD>
								<TD class="Headerdetalle">
									<asp:label class="" id="Label9" runat="server" Width="56px">Moneda:</asp:label></TD>
								<TD>
									<asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="112px"></asp:dropdownlist></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 120px" class="Headerdetalle">
									<asp:label class="" id="Label3" runat="server" Width="56px">Monto:</asp:label></TD>
								<TD>
									<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="90px" MaxLength="15"
										DecimalPlaces="2" DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True" PlacesBeforeDecimal="8"></ew:numericbox></TD>
								<TD>
									<cc1:RequiredDomValidator id="rfvMonto" runat="server" Width="9px" ControlToValidate="nMonto">*</cc1:RequiredDomValidator></TD>
								<TD class="Headerdetalle">
									<asp:label class="" id="Label10" runat="server" Width="96px">Monto Interés:</asp:label></TD>
								<TD style="WIDTH: 163px" width="163">
									<ew:numericbox id="nMontoInteres" runat="server" CssClass="normaldetalle" Width="128px" MaxLength="15"
										DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True" PlacesBeforeDecimal="8"></ew:numericbox></TD>
								<TD style="WIDTH: 21px">
									<cc1:RequiredDomValidator id="rfvnMontoInteres" runat="server" Width="16px" ControlToValidate="nMontoInteres">*</cc1:RequiredDomValidator></TD>
								<TD>
									<asp:label id="Label11" runat="server" Width="80px" Visible="False">Tipo de Cambio:</asp:label></TD>
								<TD>
									<ew:numericbox id="nTipoCambio" runat="server" CssClass="normaldetalle" Width="112px" MaxLength="8"
										DecimalPlaces="2" DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True" PlacesBeforeDecimal="4"
										Visible="False">0</ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 120px" class="Headerdetalle">
									<asp:label id="Label2" runat="server">Concepto:</asp:label></TD>
								<TD colSpan="7">
									<asp:textbox id="txtConcepto" runat="server" CssClass="normaldetalle" Height="54px" Width="100%"
										MaxLength="60" TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD vAlign="top" align="right" width="80%" colSpan="8"><TABLE id="Table2" style="WIDTH: 182px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="182"
										align="right" border="0">
										<TR>
											<TD width="50%">
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 1px"></TD>
							</TR>
							<TR>
								<TD id="IdCO" runat="server" style="WIDTH: 120px"></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD style="WIDTH: 163px">
									<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
								<TD style="WIDTH: 21px"></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<cc1:domvalidationsummary id="Vresumen" runat="server" Width="160px" Height="24px" ShowMessageBox="True" DisplayMode="List"
							EnableClientScript="False"></cc1:domvalidationsummary>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
