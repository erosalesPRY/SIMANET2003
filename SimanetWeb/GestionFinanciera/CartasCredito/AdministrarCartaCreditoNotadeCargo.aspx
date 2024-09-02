<%@ Page language="c#" Codebehind="AdministrarCartaCreditoNotadeCargo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.AdministrarCartaCreditoNotadeCargo" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<!--oncontextmenu="return false"-->
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
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
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Cartas de Crédito (Notas de Cargo)</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="644" border="0">
							<TR>
								<TD style="WIDTH: 60px" bgColor="#000080" colSpan="6">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px"
										DESIGNTIMEDRAGDROP="25">DETALLE ADMINISTRACION DE CARTA DE CRÉDITO</asp:label></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px">
									<asp:label class="" id="lblInformeEmitido" runat="server">Nro C.D.I:</asp:label></TD>
								<TD style="WIDTH: 216px">
									<asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="240px" MaxLength="40"></asp:textbox></TD>
								<TD style="WIDTH: 1px"></TD>
								<TD style="WIDTH: 67px" colSpan="2"></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 18px">
									<asp:label class="" id="Label10" runat="server" DESIGNTIMEDRAGDROP="39">Banco :</asp:label></TD>
								<TD style="WIDTH: 216px; HEIGHT: 18px" id="CellddlbEntidadFinanciera" runat="server">
									<asp:dropdownlist id="ddlbEntidadFinanciera" runat="server" CssClass="normaldetalle" Width="240px"
										DESIGNTIMEDRAGDROP="41"></asp:dropdownlist></TD>
								<TD style="WIDTH: 1px; HEIGHT: 18px"></TD>
								<TD class="headerDetalle" style="WIDTH: 67px; HEIGHT: 18px">
									<asp:label class="" id="Label1" runat="server">Situación</asp:label></TD>
								<TD style="WIDTH: 208px; HEIGHT: 18px" id="CellddlbSituacion" runat="server">
									<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Height="24px" Width="102px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 18px"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 15px">
									<asp:label id="Label3" runat="server" Width="136px">Nro Orden de Compra:</asp:label></TD>
								<TD style="WIDTH: 216px; HEIGHT: 15px" id="CellddlbOrdenCompra" runat="server">
									<asp:dropdownlist id="ddlbOrdenCompra" runat="server" CssClass="normaldetalle" Width="240px" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 1px; HEIGHT: 15px"></TD>
								<TD class="headerDetalle" style="WIDTH: 67px; HEIGHT: 15px">
									<asp:label class="" id="Label9" runat="server" Width="56px">Moneda:</asp:label></TD>
								<TD style="WIDTH: 208px; HEIGHT: 15px">
									<asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="102px" ReadOnly="True"
										BorderStyle="Groove" BackColor="AliceBlue"></asp:textbox></TD>
								<TD style="HEIGHT: 15px"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD colSpan="5">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="649" align="left" border="0">
										<TR>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
												align="center">
												<asp:label id="Label6" runat="server" ToolTip="Centro de Operaciones">CO</asp:label></TD>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc">
												<asp:label id="Label8" runat="server">Proveedor:</asp:label></TD>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc">
												<asp:label id="Label5" runat="server" Width="80px">Valor FOB :</asp:label></TD>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc">
												<asp:label id="Label18" runat="server" Width="72px">Gastos OC:</asp:label></TD>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc">
												<asp:label id="Label20" runat="server" Width="56px">Total OC:</asp:label></TD>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc">
												<asp:label id="Label11" runat="server" ToolTip="Tipo de Cambio">TC</asp:label></TD>
											<TD class="headerDetalle" style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc">
												<asp:label id="Label19" runat="server" ToolTip="Contra valor Dolar:">CV</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 108px; HEIGHT: 9px">
												<asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" Width="112px" ReadOnly="True"
													BorderStyle="Groove" BackColor="AliceBlue"></asp:textbox></TD>
											<TD style="WIDTH: 205px; HEIGHT: 9px">
												<asp:textbox id="txtProveedor" runat="server" CssClass="normaldetalle" Width="222px" ReadOnly="True"
													BorderStyle="Groove" BackColor="AliceBlue"></asp:textbox></TD>
											<TD>
												<ew:numericbox id="nImporte" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="3"
													ReadOnly="True" BorderStyle="Groove" BackColor="AliceBlue" PositiveNumber="True" AutoFormatCurrency="True"
													DollarSign=" " DecimalPlaces="2" TextAlign="Right"></ew:numericbox></TD>
											<TD>
												<ew:numericbox id="nGastos" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="3"
													ReadOnly="True" BorderStyle="Groove" BackColor="AliceBlue" PositiveNumber="True" AutoFormatCurrency="True"
													DollarSign=" " DecimalPlaces="2" TextAlign="Right"></ew:numericbox></TD>
											<TD>
												<ew:numericbox id="NTotalOC" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="3"
													ReadOnly="True" BorderStyle="Groove" BackColor="AliceBlue" PositiveNumber="True" AutoFormatCurrency="True"
													DollarSign=" " DecimalPlaces="2" TextAlign="Right"></ew:numericbox></TD>
											<TD style="HEIGHT: 9px">
												<ew:numericbox id="nTipoCambio" runat="server" CssClass="normaldetalle" Width="40px" MaxLength="4"
													ReadOnly="True" BorderStyle="Groove" BackColor="AliceBlue" PositiveNumber="True" AutoFormatCurrency="True"
													DollarSign=" " DecimalPlaces="2" TextAlign="Right" PlacesBeforeDecimal="2"></ew:numericbox></TD>
											<TD style="HEIGHT: 9px">
												<ew:numericbox id="nContravalor" runat="server" CssClass="normaldetalle" Width="70px" MaxLength="4"
													ReadOnly="True" BorderStyle="Groove" BackColor="AliceBlue" PositiveNumber="True" AutoFormatCurrency="True"
													DollarSign=" " DecimalPlaces="2" TextAlign="Right" PlacesBeforeDecimal="2"></ew:numericbox></TD>
										</TR>
										<TR>
											<TD class="headerDetalle" style="WIDTH: 108px; HEIGHT: 1px" colSpan="7">
												<asp:label id="Label15" runat="server" ToolTip="Descipción del Pedido:">Pedido:</asp:label></TD>
										</TR>
										<TR>
											<TD width="100%" colSpan="7">
												<asp:textbox id="txtDescripcionOC" runat="server" CssClass="normaldetalle" Width="100%" ReadOnly="True"
													BorderStyle="Groove" BackColor="AliceBlue"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 108px"></TD>
											<TD style="WIDTH: 205px"></TD>
											<TD></TD>
											<TD></TD>
											<TD><INPUT id="hIdPais" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPais"
													runat="server"></TD>
											<TD></TD>
											<TD>
												<asp:imagebutton id="imgbtnMostrarGastosOC" runat="server" Visible="False" ImageUrl="../../imagenes/BtPU_Mas.gif"
													CausesValidation="False" ToolTip="En construcción"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="HEIGHT: 84px"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 16px">
									<asp:label id="Label14" runat="server">Pais:</asp:label></TD>
								<TD style="HEIGHT: 16px" width="210">
									<asp:textbox id="txtPais" runat="server" CssClass="normaldetalle" Width="240px" ReadOnly="True"
										BorderStyle="Groove"></asp:textbox></TD>
								<TD style="WIDTH: 1px; HEIGHT: 16px"></TD>
								<TD style="WIDTH: 67px; HEIGHT: 16px" colSpan="2"></TD>
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px">
									<asp:label id="Label16" runat="server" Width="112px">Fecha de Emisión:</asp:label></TD>
								<TD style="WIDTH: 216px">
									<ew:calendarpopup id="CalFechaEmite" runat="server" CssClass="normaldetalle" Height="22px" Width="88px"
										BorderStyle="None" DisableTextboxEntry="False" ImageUrl="../../imagenes/BtPU_Mas.gif" PadSingleDigits="True"
										Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" CalendarWidth="2"
										Text=" ">
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
								<TD style="WIDTH: 1px"></TD>
								<TD class="headerDetalle" style="WIDTH: 67px">
									<asp:label id="Label17" runat="server" Width="130px">Dias de Validez:</asp:label></TD>
								<TD style="WIDTH: 208px">
									<ew:numericbox id="nDiasValidos" runat="server" CssClass="normaldetalle" Width="102px" MaxLength="12"
										PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="3"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px">
									<asp:label id="Label4" runat="server" Width="138px"> Fecha de Vencimiento:</asp:label></TD>
								<TD style="WIDTH: 216px">
									<asp:label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="86px" BorderStyle="None">00-00-0000</asp:label></TD>
								<TD style="WIDTH: 1px"></TD>
								<TD class="headerDetalle" style="WIDTH: 67px">
									<asp:label id="Label7" runat="server" Width="112px"> Importe CDI:</asp:label></TD>
								<TD style="WIDTH: 208px">
									<ew:numericbox id="nMontoCC" runat="server" CssClass="normaldetalle" Width="102px" MaxLength="12"
										PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="3"></ew:numericbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 24px">
									<asp:label id="Label12" runat="server" Width="152px">Comisión de Apertura (%):</asp:label></TD>
								<TD style="WIDTH: 216px; HEIGHT: 24px">
									<ew:numericbox id="nComisionApertura" runat="server" CssClass="normaldetalle" Width="96px" MaxLength="10"
										PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="5">0</ew:numericbox></TD>
								<TD style="WIDTH: 1px; HEIGHT: 24px"></TD>
								<TD class="headerDetalle" style="WIDTH: 67px; HEIGHT: 24px">
									<asp:label id="Label13" runat="server" Width="168px">Comisión de Negociación (%):</asp:label></TD>
								<TD style="WIDTH: 208px; HEIGHT: 24px">
									<ew:numericbox id="nComisionNegociacion" runat="server" CssClass="normaldetalle" Width="102px"
										MaxLength="10" PositiveNumber="True" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="5">0</ew:numericbox></TD>
								<TD style="HEIGHT: 24px"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 23px">
									<asp:label id="lblObservacion" runat="server">Observaciones:</asp:label></TD>
								<TD style="WIDTH: 216px; HEIGHT: 23px" colSpan="4">
									<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="37px" Width="528px"
										MaxLength="80" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="HEIGHT: 23px"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="headerDetalle" style="WIDTH: 60px; HEIGHT: 5px">
									<asp:textbox id="txtidCentroOperativo" runat="server" Width="16px" Visible="False"></asp:textbox></TD>
								<TD id="IdCO" style="WIDTH: 216px; HEIGHT: 5px" runat="server"></TD>
								<TD style="WIDTH: 1px; HEIGHT: 5px"></TD>
								<TD align="right" width="10%" colSpan="2">
								</TD>
								<TD style="HEIGHT: 5px"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6" width="100%">
									<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="687" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" style="HEIGHT: 22px">
										<TR bgColor="#f0f0f0">
											<TD></TD>
											<TD>
												<asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="25"
													Width="584px" Height="16px" ForeColor="Navy">ADMINISTRACION DE CARGO</asp:label></TD>
											<TD>&nbsp;</TD>
											<TD style="WIDTH: 107px"></TD>
											<TD style="WIDTH: 107px">
												<asp:imagebutton id="ibtnAdicionar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" PageSize="7" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaCancelacion" SortExpression="FechaCancelacion" HeaderText="FECHA">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="U.M">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="MONTO">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 17px" vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="686" border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
