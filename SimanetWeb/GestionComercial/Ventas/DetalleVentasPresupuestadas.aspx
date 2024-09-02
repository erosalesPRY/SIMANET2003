<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleVentasPresupuestadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.DetalleVentasPresupuestadas" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<P><uc1:menu id="Menu1" runat="server"></uc1:menu></P>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Ventas Presupuestadas</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center">
												<TABLE class="normal" id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="465" align="center" border="1">
													<TR>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD vAlign="top" bgColor="#335eb4"><asp:label id="lblProyecto" runat="server" CssClass="TextoBlanco">Proyecto:</asp:label></TD>
														<TD bgColor="#dddddd" colSpan="4"><asp:textbox id="txtProyecto" runat="server" CssClass="normaldetalle" TextMode="MultiLine" MaxLength="2000"
																Width="336px" Height="56px"></asp:textbox></TD>
														<TD bgColor="#ffffff"><cc2:requireddomvalidator id="rfvProyecto" runat="server" ControlToValidate="txtProyecto">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
																runat="server"></TD>
														<TD class="normal" colSpan="4"><asp:radiobuttonlist id="rblTipoPromotor" runat="server" CssClass="normaldetalle" Width="297px" RepeatDirection="Horizontal"
																AutoPostBack="True">
																<asp:ListItem Value="rbSeleccionarCliente" Selected="True">Seleccionar Cliente</asp:ListItem>
																<asp:ListItem Value="rbIngresarCliente">Ingresar Cliente</asp:ListItem>
															</asp:radiobuttonlist></TD>
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
													</TR>
													<TR>
														<TD vAlign="top" bgColor="#335eb4"><asp:label id="lblCliente" runat="server" CssClass="TextoBlanco"> Cliente:</asp:label></TD>
														<TD bgColor="#dddddd"><asp:textbox id="txtCliente" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarCliente" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif" CausesValidation="False"></asp:imagebutton></TD>
														<TD bgColor="#dddddd"><cc2:requireddomvalidator id="rfvCliente" runat="server" ControlToValidate="txtCliente">*</cc2:requireddomvalidator></TD>
														<TD bgColor="#dddddd"><asp:label id="lblSector" runat="server" CssClass="normaldetalle" Visible="False">Sector:</asp:label></TD>
														<TD bgColor="#dddddd" id="CellddlbSector" runat="server" class="normaldetalle"><asp:dropdownlist id="ddlbSector" runat="server" CssClass="normaldetalle" Width="136px" Visible="False"></asp:dropdownlist></TD>
														<TD bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">Centro de Operación:</asp:label></TD>
														<TD class="normaldetalle" bgColor="#f0f0f0" id="CellddlbCentroOperativo" runat="server"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" bgColor="#f0f0f0"><cc2:requireddomvalidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo">*</cc2:requireddomvalidator></TD>
														<TD class="normal" bgColor="#f0f0f0"><asp:label id="lblLineaNegocio" runat="server" CssClass="normaldetalle">Linea Negocio:</asp:label></TD>
														<TD bgColor="#f0f0f0" id="CellddlbLineaNegocio" runat="server" class="normaldetalle"><asp:dropdownlist id="ddlbLineaNegocio" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD bgColor="#ffffff"><cc2:requireddomvalidator id="rfvLineaNegocio" runat="server" ControlToValidate="ddlbLineaNegocio">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD vAlign="top" bgColor="#335eb4"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">Monto:</asp:label></TD>
														<TD class="normaldetalle"><ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" MaxLength="19" Width="136px"
																DollarSign=" " PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="12"></ew:numericbox></TD>
														<TD bgColor="#dddddd"><cc2:requireddomvalidator id="rfvMonto" runat="server" ControlToValidate="nMonto">*</cc2:requireddomvalidator></TD>
														<TD bgColor="#dddddd"><asp:label id="lblMoneda" runat="server" CssClass="normaldetalle">Moneda:</asp:label></TD>
														<TD bgColor="#dddddd" id="CellddlbMoneda" runat="server" class="normaldetalle"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD bgColor="#ffffff"><cc2:requireddomvalidator id="rfvMoneda" runat="server" ControlToValidate="ddlbMoneda">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0"><ew:calendarpopup id="calFecha" runat="server" CssClass="combos" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
																PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False">
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
														<TD class="normal" bgColor="#f0f0f0" style="HEIGHT: 24px"></TD>
														<TD class="normal" style="WIDTH: 96px; HEIGHT: 24px" bgColor="#f0f0f0"><asp:label id="lblVersion" runat="server" CssClass="normaldetalle">Versión:</asp:label></TD>
														<TD bgColor="#f0f0f0" id="CellddlbVersion" runat="server" class="normaldetalle">
															<asp:dropdownlist id="ddlbVersion" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD bgColor="#ffffff" style="HEIGHT: 24px"><cc2:requireddomvalidator id="rfvVersion" runat="server" ControlToValidate="ddlbVersion">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD vAlign="top" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion:</asp:label></TD>
														<TD bgColor="#dddddd" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" TextMode="MultiLine"
																MaxLength="2000" Width="336px" Height="56px"></asp:textbox></TD>
														<TD bgColor="#ffffff" style="HEIGHT: 61px"></TD>
													</TR>
													<TR>
														<TD id="TdCeldaCancelar" vAlign="top" colSpan="6" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
														<TD bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD vAlign="top"></TD>
														<TD colSpan="4"></TD>
														<TD bgColor="#ffffff"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" Height="42px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="180" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD id="CellibtnCancelar" runat="server"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
