<%@ Page language="c#" Codebehind="DetalleDescuento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.DetalleDescuento" %>
<%@ Register TagPrefix="cc3" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Detalle de Descuento de Letras</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="708" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="9">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="304px" Height="16px">DETALLE DE DESCUENTO DE LETRAS</asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px">
									<asp:label id="Label1" runat="server" Width="100px" ToolTip="Nro del Documento de Referencia">Nro Doc:</asp:label></TD>
								<TD>
									<asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="124px" MaxLength="15"></asp:textbox></TD>
								<TD style="WIDTH: 11px">
									<cc1:requireddomvalidator id="rfvNroDocumento" runat="server" Width="8px" ControlToValidate="txtNroDocumento">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle">
									<asp:label id="Label4" runat="server">Situación :</asp:label></TD>
								<TD>
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="100%"></asp:dropdownlist></TD>
								<TD style="WIDTH: 9px" colSpan="3"><INPUT id="txtidCuentaBancoCentro" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
										runat="server"></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px">
									<asp:label id="Label12" runat="server" Width="48px" ToolTip="Fecha de Desembolso">FD :</asp:label></TD>
								<TD>
									<ew:calendarpopup id="CalFechaDesembolso" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
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
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle">
									<asp:label id="Label11" runat="server">CUENTA BCO :</asp:label></TD>
								<TD>
									<asp:TextBox id="txtCuentaBCO" runat="server" CssClass="normaldetalle" Width="128px"></asp:TextBox>
									<asp:image id="ibtnBuscarCuentaBCO" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:image></TD>
								<TD style="WIDTH: 9px">
									<cc1:requireddomvalidator id="rfvCuentaBCO" runat="server" Width="8px" ControlToValidate="txtCuentaBCO">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle">
									<asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
								<TD>
									<asp:TextBox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="Groove"
										BackColor="AliceBlue"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px">
									<asp:label id="Label5" runat="server" Width="80px" ToolTip="Centro de Operaciones">CO :</asp:label></TD>
								<TD>
									<asp:TextBox id="txtCentro" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
										BorderStyle="Groove" BackColor="AliceBlue"></asp:TextBox></TD>
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle">
									<asp:label id="Label13" runat="server" Width="80px" ToolTip="Entidad Financiera">EF :</asp:label></TD>
								<TD colSpan="4">
									<asp:TextBox id="txtEntidadFinanciera" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
										BorderStyle="Groove" BackColor="AliceBlue"></asp:TextBox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 11px">
									<asp:label id="Label14" runat="server">tasa de interes %</asp:label></TD>
								<TD style="HEIGHT: 11px">
									<ew:numericbox id="nTasaInteres" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="8"
										DecimalPlaces="2" PlacesBeforeDecimal="3" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True"
										TextAlign="Right">0</ew:numericbox></TD>
								<TD style="WIDTH: 11px; HEIGHT: 11px"></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 11px">
									<asp:label id="Label19" runat="server">monto interes :</asp:label></TD>
								<TD style="HEIGHT: 11px">
									<ew:numericbox id="nMontoInteresBCO" runat="server" CssClass="normaldetalle" Width="150px" MaxLength="15"
										DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True"
										TextAlign="Right">0</ew:numericbox></TD>
								<TD style="WIDTH: 9px; HEIGHT: 11px"></TD>
								<TD class="HeaderDetalle" style="HEIGHT: 11px">
									<asp:label id="Label15" runat="server" Width="80px" ToolTip="Monto de desembolso :">MD :</asp:label></TD>
								<TD style="HEIGHT: 11px">
									<ew:numericbox id="nMontoDesembolso" runat="server" CssClass="normaldetalle" Width="118px" MaxLength="15"
										ReadOnly="True" DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" "
										AutoFormatCurrency="True" TextAlign="Right" BorderStyle="Groove" BackColor="AliceBlue">0</ew:numericbox></TD>
								<TD style="HEIGHT: 11px"></TD>
							</TR>
							<TR class="ItemDetalle" id="rowTotalesLetras" runat="server">
								<TD class="HeaderDetalle" style="WIDTH: 133px">
									<asp:label id="Label16" runat="server" Width="112px">monto de letras :</asp:label></TD>
								<TD>
									<ew:numericbox id="nMontoLetras" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
										ReadOnly="True" DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" "
										AutoFormatCurrency="True" TextAlign="Right" BorderStyle="Groove" BackColor="AliceBlue">0</ew:numericbox></TD>
								<TD style="WIDTH: 11px"></TD>
								<TD class="HeaderDetalle">
									<asp:label id="Label20" runat="server" Width="110px">amortizado</asp:label></TD>
								<TD>
									<ew:numericbox id="nMontoAmortizado" runat="server" CssClass="normaldetalle" Width="150px" MaxLength="15"
										ReadOnly="True" DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" "
										AutoFormatCurrency="True" TextAlign="Right" BorderStyle="Groove" BackColor="AliceBlue">0</ew:numericbox></TD>
								<TD style="WIDTH: 9px"></TD>
								<TD class="HeaderDetalle">
									<asp:label id="Label21" runat="server" Width="110px">saldo :</asp:label></TD>
								<TD>
									<ew:numericbox id="nMontoSaldo" runat="server" CssClass="normaldetalle" Width="118px" MaxLength="15"
										ReadOnly="True" DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" "
										AutoFormatCurrency="True" TextAlign="Right" BorderStyle="Groove" BackColor="AliceBlue">0</ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px">
									<asp:label id="Label10" runat="server">Aplicación :</asp:label></TD>
								<TD colSpan="7" align="left">
									<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" Width="100%"
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
