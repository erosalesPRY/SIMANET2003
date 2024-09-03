<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarLetrasRenovaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.AdministrarLetrasRenovaciones" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarLetrasRenovaciones</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="1" height="100%">
				<TR>
					<TD bgColor="#000080">
						<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco">RENOVACION</asp:Label></TD>
				</TR>
				<TR>
					<TD align="left">
						<TABLE id="Table3" style="WIDTH: 536px; HEIGHT: 18px" cellSpacing="1" cellPadding="1" width="536"
							align="left" border="0">
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 84px">
									<asp:Label id="Label5" runat="server">Monto Letra :</asp:Label></TD>
								<TD align="right">
									<asp:Label id="lblMontoLetra" runat="server" Width="73px" CssClass="normaldetalle">0.00</asp:Label></TD>
								<TD class="HeaderDetalle" style="WIDTH: 87px">
									<asp:Label id="Label6" runat="server">Amortizar:</asp:Label></TD>
								<TD style="WIDTH: 93px">
									<ew:numericbox id="nMonto" runat="server" Width="120px" CssClass="normaldetalle" DecimalPlaces="2"
										PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right"
										MaxLength="15">0</ew:numericbox></TD>
								<TD class="HeaderDetalle">
									<asp:Label id="Label7" runat="server">Saldo</asp:Label></TD>
								<TD align="right">
									<asp:Label id="lblSaldo" runat="server" Width="69px" CssClass="normaldetalle">0.00</asp:Label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="left" width="100%" height="100%">
						<cc2:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" PageSize="7">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="FECHAS">
									<HeaderStyle Width="30%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="2">
													<asp:Label id="Label4" runat="server" CssClass="HEADERGRILLA" Height="10px" BorderStyle="None">FECHA</asp:Label></TD>
											</TR>
											<TR>
												<TD width="50%">
													<asp:Label id="Label2" runat="server" CssClass="HEADERGRILLA" Height="13px">RENOVACION</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="50%">
													<asp:Label id="Label3" runat="server" CssClass="HEADERGRILLA" Height="10px" BorderStyle="None">VENCIMIENTO</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD width="50%">
													<ew:calendarpopup id="cFechaRenovacion" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
														ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
														NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
														GoToTodayText="Hoy :" AllowArbitraryText="False" CalendarLocation="Bottom">
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
												<TD style="BORDER-LEFT: #cccccc 1px solid" width="50%">
													<ew:calendarpopup id="CalFechaVencimiento" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
														ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True"
														NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
														GoToTodayText="Hoy :" AllowArbitraryText="False" CalendarLocation="Bottom">
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
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MONTO">
									<HeaderStyle Width="30%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="2">
													<asp:Label id="Label8" runat="server" CssClass="HEADERGRILLA" Height="6px" BorderStyle="None">MONTO</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="50%">
													<asp:Label id="Label9" runat="server" CssClass="HEADERGRILLA" Height="6px" BorderStyle="None">INTERES</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="50%">
													<asp:Label id="Label10" runat="server" CssClass="HEADERGRILLA" Height="9px" BorderStyle="None">RENOVACION</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="300" align="left" border="0">
											<TR>
												<TD width="50%">
													<ew:numericbox id="nInteres" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
														TextAlign="Right" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="8"
														DecimalPlaces="2">0</ew:numericbox></TD>
												<TD width="50%">
													<ew:numericbox id="nMontoRenovacion" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
														TextAlign="Right" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True" PlacesBeforeDecimal="8"
														DecimalPlaces="2">0</ew:numericbox></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACIONES">
									<HeaderStyle Width="40%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc2:datagridweb>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
