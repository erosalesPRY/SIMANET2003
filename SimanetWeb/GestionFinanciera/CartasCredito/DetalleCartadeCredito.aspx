<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetalleCartadeCredito.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.DetalleCartadeCredito" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="SetFocusInicial('txtNroDocumento'); ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<SCRIPT language="javascript" src="../../js/wz_tooltip.js"></SCRIPT>
			<SCRIPT language="javascript" src="../../js/tip_balloon.js"></SCRIPT>
			<table style="HEIGHT: 416px" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<TBODY>
					<tr>
						<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
					</tr>
					<tr>
						<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
					</tr>
					<TR>
						<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Carta de Crédito</asp:label></TD>
					</TR>
					<TR>
						<TD vAlign="top" align="center" width="100%">
							<TABLE id="Table1" style="WIDTH: 707px; HEIGHT: 416px" cellSpacing="0" cellPadding="0"
								width="707" border="0">
								<TR>
									<TD style="WIDTH: 60px" bgColor="#000080" colSpan="6"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="25"
											Height="16px" Width="304px">DETALLE ADMINISTRACION DE CARTA DE CRÉDITO</asp:label></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px"><asp:label id="lblInformeEmitido" runat="server">Nro C.D.I:</asp:label></TD>
									<TD style="WIDTH: 216px"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="240px" MaxLength="40"></asp:textbox></TD>
									<TD style="WIDTH: 1px"><cc1:requireddomvalidator id="rfvNroDocumento" runat="server" Width="8px" ControlToValidate="txtNroDocumento">*</cc1:requireddomvalidator></TD>
									<TD class="headerDetalle" style="WIDTH: 67px; HEIGHT: 15px"><asp:label id="Label2" runat="server">CREDITO :</asp:label></TD>
									<td id="CellddlbTipoCredito" runat="server"><asp:dropdownlist id="ddlbTipoCredito" runat="server" CssClass="normaldetalle" Height="24px" Width="100%"></asp:dropdownlist></td>
									<TD></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 15px"><asp:label id="Label10" runat="server" DESIGNTIMEDRAGDROP="39" Width="144px">Entidad Financiera :</asp:label></TD>
									<TD id="TD1" style="WIDTH: 216px; HEIGHT: 15px" runat="server"><asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="41"
											Width="240px"></asp:dropdownlist></TD>
									<TD style="WIDTH: 1px; HEIGHT: 15px"></TD>
									<TD class="headerDetalle" style="WIDTH: 67px; HEIGHT: 15px"><asp:label id="Label1" runat="server">Situación :</asp:label></TD>
									<TD style="WIDTH: 208px; HEIGHT: 15px"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Height="24px" Width="100%"></asp:dropdownlist></TD>
									<TD style="HEIGHT: 15px"></TD>
								</TR>
								<tr class="AlternateItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px"><asp:label id="Label3" runat="server" Width="136px">Nro Orden de Compra:</asp:label></TD>
									<TD style="WIDTH: 216px"><INPUT class="normaldetalle" id="txtNroOrdenCompra" style="WIDTH: 240px; HEIGHT: 22px"
											readOnly size="34" runat="server"></TD>
									<TD style="WIDTH: 1px"><asp:imagebutton id="imgBtnBuscarOrdendeCompra" runat="server" ToolTip="Buscar Orden de Compra" CausesValidation="False"
											ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
									<TD class="headerDetalle" style="WIDTH: 67px"><asp:label id="Label9" runat="server" Width="56px">Moneda:</asp:label></TD>
									<TD style="WIDTH: 208px"><asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="100%" BackColor="AliceBlue"
											BorderStyle="Groove" ReadOnly="True"></asp:textbox></TD>
									<TD></TD>
								</tr>
								<TR class="ItemDetalle">
									<TD colSpan="5">
										<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
													align="center"><asp:label id="Label6" runat="server" ToolTip="Centro de Operaciones">CO:</asp:label></TD>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"><asp:label id="Label8" runat="server">Proveedor:</asp:label></TD>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"><asp:label id="Label5" runat="server" Width="80px">Valor FOB :</asp:label></TD>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"><asp:label id="Label18" runat="server" Width="72px">Gastos OC:</asp:label></TD>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"><asp:label id="Label20" runat="server" Width="56px">Total OC:</asp:label></TD>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"><asp:label id="Label11" runat="server" ToolTip="Tipo de Cambio">TC :</asp:label></TD>
												<TD class="headerDetalle" style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"><asp:label id="Label19" runat="server" ToolTip="Contra valor Dolar:">CV :</asp:label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px; HEIGHT: 9px"><asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" Width="112px" BackColor="AliceBlue"
														BorderStyle="Groove" ReadOnly="True"></asp:textbox></TD>
												<TD style="WIDTH: 205px; HEIGHT: 9px"><asp:textbox id="txtProveedor" runat="server" CssClass="normaldetalle" Width="222px" BackColor="AliceBlue"
														BorderStyle="Groove" ReadOnly="True"></asp:textbox></TD>
												<TD><ew:numericbox id="nImporte" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="3"
														BackColor="AliceBlue" BorderStyle="Groove" ReadOnly="True" TextAlign="Right" DecimalPlaces="2"
														DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True"></ew:numericbox></TD>
												<TD><ew:numericbox id="nGastos" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="3"
														BackColor="AliceBlue" BorderStyle="Groove" ReadOnly="True" TextAlign="Right" DecimalPlaces="2"
														DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True"></ew:numericbox></TD>
												<TD><ew:numericbox id="NTotalOC" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="3"
														BackColor="AliceBlue" BorderStyle="Groove" ReadOnly="True" TextAlign="Right" DecimalPlaces="2"
														DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True"></ew:numericbox></TD>
												<TD style="HEIGHT: 9px"><ew:numericbox id="nTipoCambio" runat="server" CssClass="normaldetalle" Width="40px" MaxLength="4"
														BackColor="AliceBlue" BorderStyle="Groove" ReadOnly="True" TextAlign="Right" DecimalPlaces="2" DollarSign=" " AutoFormatCurrency="True"
														PositiveNumber="True" PlacesBeforeDecimal="2"></ew:numericbox></TD>
												<TD style="HEIGHT: 9px"><ew:numericbox id="nContravalor" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="4"
														BackColor="AliceBlue" BorderStyle="Groove" ReadOnly="True" TextAlign="Right" DecimalPlaces="2" DollarSign=" " AutoFormatCurrency="True"
														PositiveNumber="True" PlacesBeforeDecimal="2"></ew:numericbox></TD>
											</TR>
											<TR>
												<TD class="headerDetalle" style="WIDTH: 108px; HEIGHT: 1px" colSpan="7"><asp:label id="Label15" runat="server" ToolTip="Descipción del Pedido:">Pedido:</asp:label></TD>
											</TR>
											<TR>
												<TD width="100%" colSpan="7"><asp:textbox id="txtDescripcionOC" runat="server" CssClass="normaldetalle" Width="100%" BackColor="AliceBlue"
														BorderStyle="Groove" ReadOnly="True"></asp:textbox></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 108px"><asp:textbox id="txtidCentroOperativo" runat="server" Width="16px"></asp:textbox></TD>
												<TD style="WIDTH: 205px"></TD>
												<TD><INPUT id="hPeriodo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hPeriodo"
														runat="server"><INPUT id="hNroOC" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNroOC"
														runat="server"></TD>
												<TD></TD>
												<TD><INPUT id="hIdPais" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPais"
														runat="server"></TD>
												<TD></TD>
												<TD><asp:imagebutton id="imgbtnMostrarGastosOC" runat="server" ToolTip="En construcción" CausesValidation="False"
														ImageUrl="../../imagenes/BtPU_Mas.gif" Visible="False"></asp:imagebutton></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="HEIGHT: 84px"></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 16px"><asp:label id="Label14" runat="server">Pais:</asp:label></TD>
									<TD style="HEIGHT: 16px" width="210"><asp:textbox id="txtPais" runat="server" CssClass="normaldetalle" Width="240px" BorderStyle="Groove"
											ReadOnly="True"></asp:textbox></TD>
									<TD style="WIDTH: 1px; HEIGHT: 16px"></TD>
									<TD style="WIDTH: 67px; HEIGHT: 16px" colSpan="2"><IMG id="imgbtnBuscar" alt="" src="../../imagenes/BtPU_Mas.gif" runat="server"></TD>
									<TD style="HEIGHT: 16px"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px"><asp:label id="Label16" runat="server" Width="112px">Fecha de Emisión:</asp:label></TD>
									<TD style="WIDTH: 216px"><ew:calendarpopup id="CalFechaEmite" runat="server" CssClass="normaldetalle" Height="22px" Width="88px"
											ImageUrl="../../imagenes/BtPU_Mas.gif" BorderStyle="None" ForeColor="Navy" Font-Names="Arial" DisableTextboxEntry="False"
											PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" CalendarWidth="2">
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
									<TD style="WIDTH: 1px"></TD>
									<TD class="headerDetalle" style="WIDTH: 67px"><asp:label id="Label17" runat="server" Width="130px">Dias de Validez:</asp:label></TD>
									<TD style="WIDTH: 208px"><ew:numericbox id="nDiasValidos" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="12"
											DollarSign=" " PositiveNumber="True" RealNumber="False"></ew:numericbox></TD>
									<TD></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px"><asp:label id="Label4" runat="server" Width="138px"> Fecha de Vencimiento:</asp:label></TD>
									<TD style="WIDTH: 216px"><asp:label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="86px" BorderStyle="None">00-00-0000</asp:label></TD>
									<TD style="WIDTH: 1px"></TD>
									<TD class="headerDetalle" style="WIDTH: 67px"><asp:label id="Label7" runat="server" Width="112px"> Importe CDI:</asp:label></TD>
									<TD style="WIDTH: 208px"><ew:numericbox id="nMontoCC" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="12"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True"></ew:numericbox></TD>
									<TD><cc1:requireddomvalidator id="rfvnMontoCC" runat="server" Width="8px" ControlToValidate="nMontoCC">*</cc1:requireddomvalidator></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 24px"><asp:label id="Label12" runat="server" Width="152px">Comisión de Apertura (%):</asp:label></TD>
									<TD style="WIDTH: 216px; HEIGHT: 24px"><ew:numericbox id="nComisionApertura" runat="server" CssClass="normaldetalle" Width="96px" MaxLength="10"
											DecimalPlaces="5" DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True">0</ew:numericbox></TD>
									<TD style="WIDTH: 1px; HEIGHT: 24px"></TD>
									<TD class="headerDetalle" style="WIDTH: 67px; HEIGHT: 24px"><asp:label id="Label13" runat="server" Width="168px">Comisión de Negociación (%):</asp:label></TD>
									<TD style="WIDTH: 208px; HEIGHT: 24px"><ew:numericbox id="nComisionNegociacion" runat="server" CssClass="normaldetalle" Width="115px"
											MaxLength="10" DecimalPlaces="5" DollarSign=" " AutoFormatCurrency="True" PositiveNumber="True">0</ew:numericbox></TD>
									<TD style="HEIGHT: 24px"></TD>
								</TR>
								<TR class="AlternateItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 23px"><asp:label id="lblObservacion" runat="server">Observaciones:</asp:label></TD>
									<TD style="HEIGHT: 23px" colSpan="4"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="94px" Width="100%"
											MaxLength="80" TextMode="MultiLine"></asp:textbox></TD>
									<TD style="HEIGHT: 23px"></TD>
								</TR>
								<TR class="ItemDetalle">
									<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 5px"></TD>
									<TD id="IdCO" style="WIDTH: 216px; HEIGHT: 5px" runat="server"></TD>
									<TD style="WIDTH: 1px; HEIGHT: 5px"></TD>
									<TD align="right" width="10%" colSpan="2">
										<TABLE id="Table2" style="WIDTH: 182px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="182"
											align="right" border="0">
											<TR>
												<TD width="50%"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
												<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
											</TR>
										</TABLE>
									</TD>
									<TD style="HEIGHT: 5px"></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 60px" align="center" colSpan="6"><asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
								</TR>
							</TABLE>
							<cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" ShowMessageBox="True" DisplayMode="List"
								EnableClientScript="False"></cc1:domvalidationsummary></TD>
					</TR>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TBODY></TABLE>
	</body>
</HTML>
