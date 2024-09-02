<%@ Page language="c#" Codebehind="DetalleCargosPorFianza.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.DetalleCargosPorFianza" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Detalle de Carta Fianza</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body scroll="no" topMargin="20" leftMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; WIDTH: 507px; BORDER-BOTTOM: #999999 1px solid"
				cellSpacing="1" cellPadding="1" width="507" align="center" border="0">
				<TR>
					<TD style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 24px"
						vAlign="middle" colSpan="6" bgColor="#000080"><asp:label id="Label1" runat="server" Height="8px" Font-Names="Bookman Old Style" Font-Size="X-Small"
							Font-Bold="True" CssClass="TextoAzul" ForeColor="White">CARTA FIANZA</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 20px" colSpan="6">
						<TABLE id="Table2" style="WIDTH: 505px; HEIGHT: 208px" cellSpacing="1" cellPadding="1"
							width="505" align="center" border="0">
							<TR class="ItemDetalle">
								<TD width="20%" class="HeaderDetalle"><asp:label id="Label2" runat="server" DESIGNTIMEDRAGDROP="120" Width="112px">Nro Carta Fianza :</asp:label></TD>
								<TD width="90%" colSpan="5">
									<asp:textbox id="txtNroFianza" runat="server" DESIGNTIMEDRAGDROP="106" Width="120px" BorderStyle="Groove"
										Font-Bold="True" CssClass="normaldetalle"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD width="20%" class="HeaderDetalle"><asp:label id="Label3" runat="server" DESIGNTIMEDRAGDROP="121" Width="120px">Centro Operativo :</asp:label></TD>
								<TD width="90%" colSpan="5"><asp:textbox id="txtCentroOperativo" runat="server" DESIGNTIMEDRAGDROP="125" BorderStyle="Groove"
										Width="400px" CssClass="normaldetalle"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD width="20%" class="HeaderDetalle"><asp:label id="Label4" runat="server" DESIGNTIMEDRAGDROP="122">Entidad Financiera:</asp:label></TD>
								<TD width="90%" colSpan="5"><asp:textbox id="txtBanco" runat="server" DESIGNTIMEDRAGDROP="126" BorderStyle="Groove" Width="400px"
										CssClass="normaldetalle"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD width="20%" class="HeaderDetalle"><asp:label id="Label5" runat="server">Beneficiario:</asp:label></TD>
								<TD width="90%" colSpan="5"><asp:textbox id="txtBeneficiario" runat="server" BorderStyle="Groove" Width="400px" CssClass="normaldetalle"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="100%" colSpan="6">
									<TABLE id="Table3" style="HEIGHT: 84px" cellSpacing="1" cellPadding="1" width="100%" align="left"
										border="0">
										<TR style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 24px; BACKGROUND-COLOR: #f0f0f0">
											<TD class="HeaderDetalle" style="WIDTH: 135px"><asp:label id="Label6" runat="server" DESIGNTIMEDRAGDROP="602" Font-Bold="True">Monto de la Fianza :</asp:label></TD>
											<TD align="center" colSpan="2" width="30%" class="HeaderDetalle">
												<asp:label id="Label16" runat="server" DESIGNTIMEDRAGDROP="195" Font-Bold="True">Monto (Gastos) :</asp:label></TD>
											<TD align="center" colSpan="4" class="HeaderDetalle">
												<asp:label id="Label7" runat="server" Font-Bold="True"> Moneda :</asp:label></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD width="135" style="WIDTH: 135px; HEIGHT: 3px">&nbsp;
												<asp:textbox id="nMontoFza" runat="server" CssClass="normaldetalle" Height="20px" Width="120px"
													BorderStyle="Groove"></asp:textbox></TD>
											<TD align="left" colSpan="2" width="30%" style="HEIGHT: 3px">&nbsp;
												<ew:numericbox id="nMontoCargo" runat="server" CssClass="normaldetalle" Width="120px" BorderStyle="Groove"
													PlacesBeforeDecimal="2" PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="2"
													TextAlign="Right" MaxLength="4" ReadOnly="True" Font-Bold="True"></ew:numericbox></TD>
											<TD colSpan="4" align="left" width="40%" style="HEIGHT: 3px">&nbsp;
												<asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Font-Bold="True" Width="120px"
													BorderStyle="Groove"></asp:textbox></TD>
										</TR>
										<TR style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 24px; BACKGROUND-COLOR: #f0f0f0">
											<TD class="HeaderDetalle" style="WIDTH: 135px">
												<asp:label id="Label12" runat="server">Fecha de Inicio :</asp:label></TD>
											<TD style="WIDTH: 112px" colSpan="2" class="HeaderDetalle">
												<asp:label id="Label9" runat="server" Width="143px">Fecha de la Ult. Renovación:</asp:label></TD>
											<TD class="HeaderDetalle">
												<asp:label id="Label10" runat="server">Fecha Actual:</asp:label></TD>
											<TD colSpan="3" class="HeaderDetalle">
												<asp:label id="Label11" runat="server">Vencimiento:</asp:label></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD style="WIDTH: 135px; HEIGHT: 26px">&nbsp;
												<ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="combos" Font-Bold="True" Font-Size="Small"
													Height="21px" Width="64px" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)"
													PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif">
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
											<TD style="HEIGHT: 26px" colSpan="2" width="30%">&nbsp;
												<ew:calendarpopup id="CalFechaRenovacion" runat="server" CssClass="combos" Height="21px" Width="64px"
													ImageUrl="../../imagenes/BtPU_Mas.gif" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage"
													ShowGoToToday="True">
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
											<TD style="HEIGHT: 26px">&nbsp;
												<ew:calendarpopup id="CalFechaActual" runat="server" CssClass="combos" Height="21px" Width="64px"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
													ImageUrl="../../imagenes/BtPU_Mas.gif">
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
											<TD style="HEIGHT: 26px" colSpan="3">&nbsp;
												<ew:calendarpopup id="CalFechaVencimiento" runat="server" CssClass="combos" Height="21px" Width="64px"
													ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
													ImageUrl="../../imagenes/BtPU_Mas.gif">
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
										</TR>
										<TR style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 24px; BACKGROUND-COLOR: #f0f0f0">
											<TD style="WIDTH: 135px"></TD>
											<TD colSpan="2" width="30%"></TD>
											<TD class="HeaderDetalle">
												<asp:label id="Label8" runat="server" Width="94px">Dias de existencia :</asp:label></TD>
											<TD colSpan="3" class="HeaderDetalle">
												<asp:label id="Label15" runat="server" Width="104px">Por Vencer dentro de:</asp:label></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD style="WIDTH: 135px"></TD>
											<TD colSpan="2" width="30%"></TD>
											<TD>&nbsp;
												<asp:textbox id="txtDiasTranscurridos" runat="server" Height="20px" BorderStyle="Groove" Width="88px"
													CssClass="normaldetalle"></asp:textbox></TD>
											<TD colSpan="3">&nbsp;
												<asp:textbox id="txtDiasporVencer" runat="server" CssClass="normaldetalle" Height="19px" Width="47px"
													BorderStyle="Groove"></asp:textbox>
												<asp:label id="Label13" runat="server" CssClass="TextoAzul">Dias</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 24px; BACKGROUND-COLOR: #f0f0f0">
					<TD style="BORDER-RIGHT: #ffffff 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #ffffff 1px solid; HEIGHT: 24px; BACKGROUND-COLOR: #f0f0f0"
						colSpan="6"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
