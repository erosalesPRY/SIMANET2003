<%@ Page language="c#" Codebehind="DetallePrestamoBancario.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.PrestamosBancarios.DetallePrestamoBancario" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			function Mostrar()
			{
				window.alert("sss");
				//oncontextmenu="return false" 
			}
		</script>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TBODY>
					<tr>
						<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD class="RutaPaginaActual" vAlign="top" width="744"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de Préstamo Bancario</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="773" border="0">
								<TR>
									<TD bgColor="#000080" colSpan="9"><asp:label id="Label18" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">DETALLE DE PRÉSTAMO</asp:label></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle"><asp:label id="Label1" runat="server" Width="96px">Nro Préstamo :</asp:label></TD>
									<TD><asp:textbox id="txtNroPrestamo" runat="server" CssClass="normalDetalle" Width="121px" MaxLength="15"></asp:textbox></TD>
									<TD><cc1:requireddomvalidator id="rfvNroPrestamo" runat="server" Width="8px" ControlToValidate="txtNroPrestamo"
											ErrorMessage="*">*</cc1:requireddomvalidator></TD>
									<TD class="HeaderDetalle"><asp:label id="Label6" runat="server">Moneda :</asp:label></TD>
									<TD id="CellddlbMoneda" style="WIDTH: 122px" runat="server"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normalDetalle" Width="80px"></asp:dropdownlist></TD>
									<TD></TD>
									<TD class="HeaderDetalle"><asp:label id="Label4" runat="server">Situación :</asp:label></TD>
									<TD id="CellddlbSituacion" style="WIDTH: 109px" runat="server"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normalDetalle" Width="120px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle"><asp:label id="Label9" runat="server">Monto :</asp:label></TD>
									<TD><ew:numericbox id="nMontoPtm" runat="server" CssClass="normalDetalle" Width="118px" MaxLength="15"
											DecimalPlaces="3" PlacesBeforeDecimal="8" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True"></ew:numericbox></TD>
									<TD><cc1:requireddomvalidator id="rfvMonto" runat="server" Width="8px" ControlToValidate="nMontoPtm" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
									<TD class="HeaderDetalle"><asp:label id="Label3" runat="server" ToolTip="Tasa Efectiva Anual">T.E.A % :</asp:label></TD>
									<TD style="WIDTH: 122px"><ew:numericbox id="txtTasaInteres" runat="server" CssClass="normalDetalle" Width="80px" MaxLength="12"
											DecimalPlaces="3" PlacesBeforeDecimal="8" AutoFormatCurrency="True" DollarSign=" " PositiveNumber="True"></ew:numericbox></TD>
									<TD><cc1:requireddomvalidator id="rfvTasaInteres" runat="server" Width="8px" ControlToValidate="txtTasaInteres"
											ErrorMessage="*">*</cc1:requireddomvalidator></TD>
									<TD class="HeaderDetalle"><asp:label id="Label16" runat="server" Width="96px">Tipo de Cambio :</asp:label></TD>
									<TD style="WIDTH: 109px"><ew:numericbox id="nTipoCambio" runat="server" CssClass="normalDetalle" Width="118px" MaxLength="8"
											DecimalPlaces="2" PlacesBeforeDecimal="5" AutoFormatCurrency="True" DollarSign=" "></ew:numericbox></TD>
									<TD><cc1:requireddomvalidator id="rfvTipoCambio" runat="server" Width="17px" ControlToValidate="nTipoCambio" ErrorMessage="*">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="HEIGHT: 17px"><asp:label id="Label17" runat="server"> Modalidad :</asp:label></TD>
									<TD id="CellddlbModalidad" style="WIDTH: 586px; HEIGHT: 17px" colSpan="7" runat="server"><asp:dropdownlist id="ddlbModalidad" runat="server" CssClass="normalDetalle" Width="580px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 17px"></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle" style="HEIGHT: 15px"><asp:label id="Label5" runat="server" Width="159px">Centro de Operaciones :</asp:label></TD>
									<TD id="CellddlbCentroOperativo" style="WIDTH: 586px; HEIGHT: 15px" colSpan="7" runat="server"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normalDetalle" Width="580px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 15px"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle" style="HEIGHT: 16px"><asp:label id="Label2" runat="server">ENTIDAD FINANCIERA :</asp:label></TD>
									<TD id="CellddlbEntidadFinanciera" style="WIDTH: 586px; HEIGHT: 16px" colSpan="7" runat="server"><asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="normalDetalle" Width="580px"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 16px"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle"><asp:label id="Label7" runat="server" Width="110px">Fecha Préstamo :</asp:label></TD>
									<TD><ew:calendarpopup id="CalFechaPrestamo" runat="server" CssClass="normaldetalle" Width="64px" ShowGoToToday="True"
											ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif"
											NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar"
											GoToTodayText="Hoy :" AllowArbitraryText="False" CalendarLocation="Bottom" DisableTextboxEntry="False">
<TextboxLabelStyle CssClass="NormalDetalle">
</TextboxLabelStyle>

<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black" BackColor="White">
</WeekdayStyle>

<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White" BackColor="Navy">
</MonthHeaderStyle>

<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White" BackColor="White">
</OffMonthStyle>

<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy" BackColor="#F0F0F0">
</GoToTodayStyle>

<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True" ForeColor="#335EB4" BackColor="LightSteelBlue">
</TodayDayStyle>

<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White" BackColor="#335EB4">
</DayHeaderStyle>

<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True" ForeColor="IndianRed" BackColor="White">
</WeekendStyle>

<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White" BackColor="CornflowerBlue">
</SelectedDateStyle>

<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black" BackColor="White">
</ClearDateStyle>

<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black" BackColor="White">
</HolidayStyle>
										</ew:calendarpopup></TD>
									<TD></TD>
									<TD class="HeaderDetalle"><asp:label id="Label8" runat="server" Width="116px">Fecha Vencimiento :</asp:label></TD>
									<TD style="WIDTH: 122px"><ew:calendarpopup id="CalFechaVencimiento" runat="server" CssClass="normaldetalle" Width="56px" ShowGoToToday="True"
											ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True" ImageUrl="../../imagenes/BtPU_Mas.gif"
											NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :"
											AllowArbitraryText="False" CalendarLocation="Bottom">
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
									<TD style="WIDTH: 122px" colSpan="6"><asp:checkbox id="chkPlazo" runat="server" Text="LARGO PLAZO"></asp:checkbox></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="HeaderDetalle"><asp:label id="Label29" runat="server" Width="120px">APLICACION :</asp:label></TD>
									<TD id="CellddlDestino" style="WIDTH: 586px" colSpan="7" runat="server"><asp:dropdownlist id="ddlDestino" runat="server" CssClass="normalDetalle" Width="264px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="HeaderDetalle"><asp:label id="Label30" runat="server" Width="58px">DESTINO :</asp:label></TD>
									<TD id="CellddlbCentroOperativoDestino" style="WIDTH: 586px" colSpan="7" runat="server"><asp:dropdownlist id="ddlbCentroOperativoDestino" runat="server" CssClass="normalDetalle" Width="264px"></asp:dropdownlist></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle" id="rowConceptoTitulo" runat="server">
									<TD class="HeaderDetalle"><asp:label id="Label10" runat="server">OBSERVACION :</asp:label></TD>
									<TD style="WIDTH: 586px" colSpan="7"></TD>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle" id="rowConceptoValor" runat="server">
									<TD style="WIDTH: 714px" colSpan="8"><asp:textbox id="txtConcepto" runat="server" CssClass="normalDetalle" Height="64px" Width="100%"
											MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle" id="rowToolbar" runat="server">
									<TD style="WIDTH: 714px" colSpan="8">
										<TABLE id="Table1" style="WIDTH: 204px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="204"
											align="right" border="0">
											<TR>
												<TD align="right"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD align="right"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
											</TR>
										</TABLE>
										<asp:label id="Label11" runat="server" Width="80px" Visible="False">Días de Plazo :</asp:label><ew:numericbox id="nDiasPlazo" runat="server" CssClass="normal" Width="118px" MaxLength="3" PositiveNumber="True"
											Visible="False" RealNumber="False"></ew:numericbox></TD>
									<TD></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD id="AdmAmortiza" vAlign="top" align="center" width="100%" runat="server">
							<TABLE id="tblCabecera" cellSpacing="0" cellPadding="0" width="776" border="0" runat="server">
								<TR bgColor="#f0f0f0">
									<TD><IMG style="WIDTH: 8px; HEIGHT: 22px" height="22" src="../../imagenes/tab_izq.gif" width="8"></TD>
									<TD style="WIDTH: 210px"><asp:label id="Label19" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px"
											ForeColor="Black">CRONOGRAMA DE PAGOS</asp:label></TD>
									<TD style="WIDTH: 399px">&nbsp;</TD>
									<TD style="WIDTH: 273px"></TD>
									<TD style="WIDTH: 116px"></TD>
									<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
									<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
								</TR>
							</TABLE>
							<cc2:datagridweb id="grid" runat="server" Width="776px" ShowFooter="True" AllowSorting="True" AutoGenerateColumns="False"
								RowHighlightColor="#E0E0E0">
								<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<FooterStyle CssClass="footergrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NRO">
										<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FechaPago" SortExpression="FechaPago" HeaderText="FV">
										<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn HeaderText="DIAS">
										<HeaderStyle HorizontalAlign="Center" Width="15%" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
										<HeaderTemplate>
											<TABLE id="Table4" style="HEIGHT: 85px" height="61" cellSpacing="1" cellPadding="1" width="100%"
												align="left" border="0">
												<TR>
													<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="2" height="5">
														<asp:Label id="Label21" runat="server" CssClass="HEADERGRILLA" BorderStyle="None" DESIGNTIMEDRAGDROP="327">DIAS</asp:Label></TD>
												</TR>
												<TR>
													<TD align="center">
														<asp:Label id="Label20" runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias de Plazo" BorderStyle="None" DESIGNTIMEDRAGDROP="342">P</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
														<asp:Label id="Label15" runat="server" CssClass="HEADERGRILLA" ToolTip="Nro de Dias Restantes para su vencimiento" BorderStyle="None">V</asp:Label></TD>
												</TR>
											</TABLE>
										</HeaderTemplate>
										<ItemTemplate>
											<TABLE id="Table8" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
												border="0">
												<TR>
													<TD align="center">
														<asp:Label id="lblDiasPlazo" runat="server" CssClass="normaldetalle" Width="30px" BorderStyle="None">00</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" align="center">
														<asp:Label id="lblDiasFaltantes" runat="server" CssClass="normaldetalle" Width="30px" BorderStyle="None" DESIGNTIMEDRAGDROP="527">00</asp:Label></TD>
												</TR>
											</TABLE>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="IMPORTES">
										<HeaderStyle HorizontalAlign="Center" Width="45%" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
										<HeaderTemplate>
											<TABLE id="Table9" height="100%" cellSpacing="1" cellPadding="1" width="100%" align="left"
												border="0">
												<TR>
													<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="5">
														<asp:Label id="Label24" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">MONTO</asp:Label></TD>
												</TR>
												<TR>
													<TD style="BORDER-RIGHT: #cccccc 1px solid" align="center" width="25%" rowSpan="2">
														<asp:Label id="Label22" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">SALDO</asp:Label></TD>
													<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" width="33%" colSpan="3">
														<asp:Label id="Label26" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">TOTAL</asp:Label></TD>
												</TR>
												<TR>
													<TD align="center" width="25%">
														<asp:Label id="Label23" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">POR AMORTIZAR</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
														<asp:Label id="Label25" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">INTERES</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
														<asp:Label id="Label27" runat="server" CssClass="HEADERGRILLA" BorderStyle="None">PAGADO</asp:Label></TD>
												</TR>
											</TABLE>
										</HeaderTemplate>
										<ItemTemplate>
											<TABLE id="Table11" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
												border="0">
												<TR>
													<TD noWrap align="right" width="25%">
														<asp:Label id="lblSaldo" runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None">0.00</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="25%">
														<asp:Label id="lblAmortizado" runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None">0.00</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="25%">
														<asp:Label id="lblInteres" runat="server" CssClass="normaldetalle" Width="54px" DESIGNTIMEDRAGDROP="475" BorderStyle="None">0.00</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="25%">
														<asp:Label id="lblPagado" runat="server" CssClass="normaldetalle" Width="54px" DESIGNTIMEDRAGDROP="475" BorderStyle="None">0.00</asp:Label></TD>
												</TR>
											</TABLE>
										</ItemTemplate>
										<FooterTemplate>
											<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
												border="0">
												<TR>
													<TD align="right" width="25%">
														<asp:Label id="Label31" runat="server" CssClass="normaldetalle" Width="54px" BorderStyle="None"></asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="25%">
														<asp:Label id="lblTotalAmortizado" runat="server" CssClass="footerGrilla" Width="54px" BorderStyle="None">0.00</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="25%">
														<asp:Label id="lblTotalInteres" runat="server" CssClass="footerGrilla" Width="54px" DESIGNTIMEDRAGDROP="475" BorderStyle="None">0.00</asp:Label></TD>
													<TD style="BORDER-LEFT: #cccccc 1px solid" noWrap align="right" width="25%">
														<asp:Label id="lblTotalPagado" runat="server" CssClass="footerGrilla" Width="54px" DESIGNTIMEDRAGDROP="475" BorderStyle="None">0.00</asp:Label></TD>
												</TR>
											</TABLE>
										</FooterTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="1%"></HeaderStyle>
										<HeaderTemplate>
											<asp:Label id="Label28" runat="server" CssClass="headergrilla" ToolTip="Cuota Amortizada" BorderStyle="None">A</asp:Label>
										</HeaderTemplate>
										<ItemTemplate>
											<asp:Image id="imgCheck" runat="server" ImageUrl="../../imagenes/tree/CheckTrue.GIF"></asp:Image>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:BoundColumn DataField="observacion" SortExpression="observacion" HeaderText="OBSERVACION">
										<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
							</cc2:datagridweb></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%"></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="776" border="0">
								<TR>
									<TD id="toolAtras" align="left" width="100%" runat="server"><IMG id="ibtnGoBack" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								</TR>
							</TABLE>
						</TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%"><cc1:domvalidationsummary id="Vresumen" runat="server" Height="30px" Width="94px" EnableClientScript="False"
								DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
					</TR>
				</TBODY>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
