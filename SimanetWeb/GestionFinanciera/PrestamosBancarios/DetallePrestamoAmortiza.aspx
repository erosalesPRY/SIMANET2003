<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetallePrestamoAmortiza.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios.DetallePrestamoAmortiza" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<!--oncontextmenu="return false" -->
  </HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="HEIGHT: 384px">
				<TBODY>
					<tr>
						<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD vAlign="top" width="100%" class="RutaPaginaActual" style="HEIGHT: 20px">
							<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina" DESIGNTIMEDRAGDROP="150">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPagina">Detalle de Amortización de Préstamo></asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" width="100%" align="center">
							<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="730" border="0">
								<TR>
									<TD bgColor="#000080" colSpan="9">
										<asp:label id="Label18" runat="server" CssClass="TituloPrincipalBlanco" Width="304px" Height="16px">DETALLE DE PRÉSTAMO</asp:label></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label1" runat="server" Width="104px">Nro Préstamo :</asp:label></TD>
									<TD>
										<asp:textbox id="txtNroPrestamo" runat="server" Width="121px" MaxLength="15" CssClass="normal"></asp:textbox></TD>
									<TD></TD>
									<TD class="HeaderDetalle" style="WIDTH: 102px">
										<asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
									<TD id="CellddlbMoneda" runat="server">
										<asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="combos" Width="121px"></asp:dropdownlist></TD>
									<TD></TD>
									<TD class="HeaderDetalle">
										<asp:label id="Label4" runat="server">Situación :</asp:label></TD>
									<TD id="CellddlbSituacion" runat="server">
										<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="combos" Width="120px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label9" runat="server">Monto :</asp:label></TD>
									<TD>
										<ew:numericbox id="nMontoPtm" runat="server" CssClass="normal" Width="118px" MaxLength="9" PositiveNumber="True"
											DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="2" TextAlign="Right"></ew:numericbox></TD>
									<TD></TD>
									<TD class="HeaderDetalle" style="WIDTH: 102px">
										<asp:label id="Label3" runat="server" ToolTip="Tasa Efectiva Anual">T.E.A :</asp:label></TD>
									<TD>
										<ew:numericbox id="txtTasaInteres" runat="server" CssClass="normal" Width="118px" MaxLength="5"
											PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="2" DecimalPlaces="2"
											TextAlign="Right"></ew:numericbox></TD>
									<TD></TD>
									<TD class="HeaderDetalle">
										<asp:label id="Label16" runat="server" Width="96px">Tipo de Cambio :</asp:label></TD>
									<TD>
										<ew:numericbox id="Numericbox1" runat="server" CssClass="normal" Width="118px" MaxLength="5" DollarSign=" "
											AutoFormatCurrency="True" PlacesBeforeDecimal="3" TextAlign="Right"></ew:numericbox></TD>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label15" runat="server" Width="112px">Fecha Inicio :</asp:label></TD>
									<TD>
										<ew:calendarpopup id="CalFechaPrestamo" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
											AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
											NullableLabelText="Seleccione una fecha:">
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
									<TD></TD>
									<TD class="HeaderDetalle" style="WIDTH: 102px">
										<asp:label id="Label14" runat="server" Width="104px"> Vencimiento :</asp:label></TD>
									<TD>
										<ew:calendarpopup id="CalFechaVencimiento" runat="server" CssClass="normaldetalle" Width="72px" NullableLabelText="Seleccione una fecha:"
											MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" AllowArbitraryText="False"
											ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
											ImageUrl="../../imagenes/BtPU_Mas.gif">
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
									<TD colSpan="3">
										<ew:numericbox id="nDiasPlazo" runat="server" CssClass="normal" Width="32px" MaxLength="3" TextAlign="Right"
											PositiveNumber="True" Visible="False" RealNumber="False"></ew:numericbox>
										<asp:label id="Label11" runat="server" Width="90px" Visible="False">Días de Plazo :</asp:label></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label17" runat="server"> Modalidad :</asp:label></TD>
									<TD colSpan="7" id="CellddlbModalidad" runat="server">
										<asp:dropdownlist id="ddlbModalidad" runat="server" CssClass="combos" Width="600px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label5" runat="server" Width="120px">Centro Operativo :</asp:label></TD>
									<TD colSpan="7" id="CellddlbCentroOperativo" runat="server">
										<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="combos" Width="600px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label2" runat="server" Width="120px">ENTIDAD FINANCIERA :</asp:label></TD>
									<TD colSpan="7" id="CellddlbEntidadFinanciera" runat="server">
										<asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="combos" Width="600px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle" id="rowConceptoTitulo" runat="server">
									<TD class="HeaderDetalle" style="WIDTH: 115px">
										<asp:label id="Label13" runat="server">Concepto :</asp:label></TD>
									<TD colSpan="7">
										<asp:textbox id="txtConcepto" runat="server" CssClass="normal" Height="24px" Width="600px" TextMode="MultiLine"></asp:textbox></TD>
									<TD></TD>
								</TR>
							</TABLE>
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="739" align="center" border="0">
								<TR bgColor="#f0f0f0">
									<TD style="HEIGHT: 23px" bgColor="#000080" colSpan="13">
										<asp:label id="Label8" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="456px">AMORTIZACIÓN</asp:label></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="WIDTH: 51px">
										<asp:label id="Label22" runat="server" DESIGNTIMEDRAGDROP="525" Width="112px">Fecha Pago :</asp:label></TD>
									<TD width="20%">
										<ew:calendarpopup id="CalFechaPago" runat="server" CssClass="normaldetalle" Height="20px" Width="88px"
											NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
											GoToTodayText="Hoy :" AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage"
											Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" CalendarLocation="Bottom">
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
									<TD style="WIDTH: 9px"></TD>
									<TD class="HeaderDetalle" style="WIDTH: 96px">
										<asp:label id="Label19" runat="server" Width="40px">SITUACIÓN :</asp:label></TD>
									<TD id="CellddlbSituacionAmortiza" runat="server" width="10%">
										<asp:dropdownlist id="ddlbSituacionAmortiza" runat="server" CssClass="combos" Width="146px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 7px"></TD>
									<TD class="HeaderDetalle">
										<asp:label id="Label20" runat="server"> Monto:</asp:label></TD>
									<TD width="10%">
										<ew:numericbox id="nMontoAmortiza" runat="server" CssClass="normal" Width="145px" MaxLength="18"
											PlacesBeforeDecimal="15" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="3"></ew:numericbox></TD>
									<TD style="WIDTH: 13px">
										<cc1:requireddomvalidator id="rfvMontoAmortiza" runat="server" Width="8px" ControlToValidate="nMontoAmortiza"
											ErrorMessage="*">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="AlternateItemDetalle" id="rowAmortiza1" runat="server">
									<TD class="HeaderDetalle" style="WIDTH: 51px">
										<asp:label id="Label10" runat="server" Width="136px">Fecha Amortizacion :</asp:label></TD>
									<TD width="20%">
										<ew:calendarpopup id="CalFechaAmortiza" runat="server" CssClass="normaldetalle" Height="20px" Width="88px"
											NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
											GoToTodayText="Hoy :" AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage"
											Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif" CalendarLocation="Bottom">
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
									<TD style="WIDTH: 9px"></TD>
									<TD class="HeaderDetalle" style="WIDTH: 96px">
										<asp:label id="Label7" runat="server" Width="100px">Monto Interés :</asp:label></TD>
									<TD width="10%">
										<ew:numericbox id="nMontoInteres" runat="server" CssClass="normal" Width="100%" MaxLength="12"
											PlacesBeforeDecimal="6" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" DecimalPlaces="2">0</ew:numericbox></TD>
									<TD style="WIDTH: 7px">
										<cc1:requireddomvalidator id="rfvMontoInteres" runat="server" Width="8px" ErrorMessage="*" ControlToValidate="nMontoInteres">*</cc1:requireddomvalidator></TD>
									<TD colSpan="3">
										<asp:CheckBox id="chkCancelado" runat="server" Width="111px" BorderStyle="None" Text="CANCELADO"></asp:CheckBox></TD>
								</TR>
								<TR class="AlternateItemDetalle" id="rowAmortiza2" runat="server">
									<TD class="HeaderDetalle" style="WIDTH: 51px">
										<asp:label id="Label12" runat="server">Observación :</asp:label></TD>
									<TD width="10%" colSpan="10">
										<asp:textbox id="txtObservacion" runat="server" CssClass="normal" Height="64px" Width="100%"
											MaxLength="60" TextMode="MultiLine"></asp:textbox></TD>
								</TR>
								<TR class="AlternateItemDetalle" id="rowToolbar" runat="server">
									<TD vAlign="top" align="right" width="100%"></TD>
									<TD vAlign="top" align="right" width="100%" colSpan="11">
										<asp:imagebutton id="Imagebutton1" runat="server" Height="0px" ImageUrl="../../imagenes/bt_cancelar.gif"
											CausesValidation="False"></asp:imagebutton>
										<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="208" align="right" border="0">
											<TR>
												<TD align="right">
													<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD align="right"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 10px" vAlign="top" align="center" width="100%">
							<TABLE id="tblAtras" style="DISPLAY: none; HEIGHT: 26px" cellSpacing="1" cellPadding="1"
								width="739" border="0" runat="server">
								<TR>
									<TD align="left" width="100%"><IMG id="ibtnGoBack" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD style="HEIGHT: 10px" vAlign="top" align="center" width="100%">
							<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
					</TR>
				</TBODY>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
