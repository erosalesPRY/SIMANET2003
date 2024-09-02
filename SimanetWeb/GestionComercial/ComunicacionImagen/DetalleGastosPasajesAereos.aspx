<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleGastosPasajesAereos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleGastosPasajesAereos" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
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
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Gastos de Pasajes Aereos</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" align="left"><INPUT id="hIdCentroCosto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCentroCosto"
										runat="server"><INPUT id="hIdGrupoCentroCosto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1"
										name="hIdGrupoCentroCosto" runat="server"><INPUT id="hIdValorizacionOrdenTrabajo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden"
										size="1" name="hIdValorizacionOrdenTrabajo" runat="server"><INPUT id="hIdPersonal" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonal"
										runat="server"><INPUT id="hIdPasajeAereo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPasajeAereo"
										runat="server"><INPUT id="hIdMoneda" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPasajeAereo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="520" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center" vAlign="top">
												<TABLE class="normal" id="Table7" cellSpacing="1" cellPadding="1" width="500" align="center"
													border="0">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNroDocumento" runat="server" CssClass="TextoBlanco">Nro. Documento:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtDocumento" runat="server" CssClass="normaldetalle" MaxLength="20" Width="136px"></asp:textbox></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvDocumento" runat="server" ControlToValidate="txtDocumento">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco">Tipo Documento:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:dropdownlist id="ddlbTipoDocumento" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvTipoDocumento" runat="server" ControlToValidate="ddlbTipoDocumento">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblFechaDocumento" runat="server" CssClass="TextoBlanco">Fecha Documento:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:calendarpopup id="CalFechaDocumento" runat="server" CssClass="normaldetalle" Width="88px" ImageUrl="../../imagenes/BtPU_Mas.gif"
																ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True">
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
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNombres" runat="server" CssClass="TextoBlanco">Personal:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtPersonal" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="80"
																ReadOnly="True"></asp:textbox>
															<asp:imagebutton id="ibtnBuscarPersonal" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif" CausesValidation="False"
																CssClass="normaldetalle"></asp:imagebutton></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvPersonal" runat="server" ControlToValidate="txtPersonal">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblPasajeAereo" runat="server" CssClass="TextoBlanco">Pasaje Aereo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtPasajeAereo" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="500"
																ReadOnly="True"></asp:textbox>
															<asp:imagebutton id="ibtnBuscarPasajeAereo" runat="server" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False" CssClass="normaldetalle"></asp:imagebutton></TD>
														<TD class="normal" bgColor="#ffffff">
															<cc2:requireddomvalidator id="rfvPasajeAereo" runat="server" ControlToValidate="txtPasajeAereo">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">Monto:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="txtMonto" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="4"
																RealNumber="False" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4"></ew:numericbox></TD>
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="20"
																ReadOnly="True"></asp:textbox></TD>
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" align="center" bgColor="#f0f0f0" colSpan="5" height="1">
															<asp:RadioButtonList id="rblTipoGasto" runat="server" CssClass="normaldetalle" Width="336px" RepeatDirection="Horizontal"
																AutoPostBack="True">
																<asp:ListItem Value="Centro de Costo" Selected="True">Centro de Costo</asp:ListItem>
																<asp:ListItem Value="Orden de Trabajo">Orden de Trabajo</asp:ListItem>
															</asp:RadioButtonList></TD>
														<TD class="normal" align="center" height="1" rowSpan="1"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCentroCosto" runat="server" CssClass="TextoBlanco">Centro de Costo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtCentroCosto" runat="server" CssClass="normaldetalle" Width="336px" ReadOnly="True"></asp:textbox>
															<asp:imagebutton id="ibtnBuscarCentroCosto" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False"></asp:imagebutton></TD>
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblOT" runat="server" CssClass="TextoBlanco" Visible="False">Orden de Trabajo:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:TextBox id="txtOT" runat="server" CssClass="normaldetalle" Width="336px" ReadOnly="True"
																Visible="False"></asp:TextBox>
															<asp:imagebutton id="ibtnBuscarOT" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False" Visible="False"></asp:imagebutton></TD>
														<TD class="normal" bgColor="#ffffff"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="120px" EnableClientScript="False"
													DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table8" width="180" border="0">
										<TR>
											<TD width="94">
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
													Height="22px"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></SPAN></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal></SCRIPT>
	</body>
</HTML>
