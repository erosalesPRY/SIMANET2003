<%@ Page language="c#" Codebehind="DetalleAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.DetalleAccion" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleAccion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de Acciones de Plan de Gestión</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 18px">
						<P align="left"><INPUT id="hidCargoLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCargoLider"
								runat="server"><INPUT id="hIdAreaLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdAreaLider"
								runat="server"><INPUT id="hIdPersonalLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonalLider"
								runat="server"><INPUT id="hNombreLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNombreLider"
								runat="server"></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image1" runat="server" Width="48px" Height="24px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" style="HEIGHT: 310px" cellSpacing="0" cellPadding="0" width="780" align="center"
							border="0">
							<TR>
								<TD style="HEIGHT: 233px">
									<P align="center">
										<TABLE id="Table2" style="WIDTH: 737px; HEIGHT: 223px" borderColor="#ffffff" cellSpacing="0"
											cellPadding="0" width="737" align="center" border="1" runat="server">
											<TR>
											</TR>
											<TR>
												<TD colSpan="3" style="WIDTH: 710px">
													<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
														border="3">
														<TR>
															<TD width="90">
																<asp:label id="lblProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
															<TD>
																<asp:label id="lblNombreProceso" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
														</TR>
														<TR>
															<TD width="90">
																<asp:label id="lblSubProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
															<TD>
																<asp:label id="lblNombreSubProceso" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
														</TR>
														<TR>
															<TD width="90">
																<asp:label id="lblOEspecifico" runat="server" CssClass="normaldetalle"></asp:label></TD>
															<TD>
																<asp:label id="lblNombreOEspecifico" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD style="WIDTH: 709px" bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
												<TD width="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Codigo Acción</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#f0f0f0"><asp:textbox id="txtCodigoAccion" runat="server" CssClass="NormalDetalle" ReadOnly="True" BorderStyle="Groove"
														Width="250px"></asp:textbox></TD>
												<TD width="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">Acción Nombre</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#dddddd"><asp:textbox id="txtNombreAccion" runat="server" CssClass="NormalDetalle" BorderStyle="Groove"
														Width="616px"></asp:textbox></TD>
												<TD width="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4">
													<asp:label id="lblLider" runat="server" CssClass="TextoBlanco">Responsable</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#f0f0f0">
													<asp:textbox id="txtLider" runat="server" CssClass="normaldetalle" Width="480px" BorderStyle="Groove"
														ReadOnly="True" MaxLength="80"></asp:textbox>
													<asp:imagebutton id="ibtnBuscarLider" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
														CausesValidation="False"></asp:imagebutton></TD>
												<TD width="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4"><asp:label id="lblAE" runat="server" CssClass="TextoBlanco">AE</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#f0f0f0"><ew:numericbox id="txtAvanceEconomica" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
														Width="100px" MaxLength="6" PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox></TD>
												<TD width="5"><cc2:rangedomvalidator id="RangeDomValidator1" runat="server" ControlToValidate="txtAvanceEconomica" MaximumValue="100.00"
														MinimumValue="00.00" ErrorMessage="Ingrese valores de 0 a 100">*</cc2:rangedomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4"><asp:label id="lblAF" runat="server" CssClass="TextoBlanco">AF</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#dddddd"><ew:numericbox id="txtAvanceFinanciero" runat="server" CssClass="normaldetalle" BorderStyle="Groove"
														Width="100px" MaxLength="6" PositiveNumber="True" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox></TD>
												<TD width="5"><cc2:rangedomvalidator id="RangeDomValidator2" runat="server" ControlToValidate="txtAvanceFinanciero" MaximumValue="100.00"
														MinimumValue="00.00" ErrorMessage="Ingrese valores de 0 a 100">*</cc2:rangedomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4">
													<asp:label id="Label5" runat="server" CssClass="TextoBlanco">año</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#f0f0f0">
													<ew:calendarpopup id="CalFecha" runat="server" CssClass="combos" ImageUrl="../../imagenes/BtPU_Mas.gif"
														Width="72px" Text="..." PadSingleDigits="True" Culture="Spanish (Peru)" ControlDisplay="TextBoxImage"
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
												<TD width="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4">
													<asp:label id="lblCO" runat="server" CssClass="TextoBlanco">inversion</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#f0f0f0">
													<ew:numericbox id="txtInversion" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
														DecimalPlaces="2" PlacesBeforeDecimal="15" PositiveNumber="True" MaxLength="18"></ew:numericbox></TD>
												<TD width="5"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 93px" bgColor="#335eb4">
													<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Peso</asp:label></TD>
												<TD style="WIDTH: 608px" bgColor="#f0f0f0">
													<ew:numericbox id="txtPeso" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
														PositiveNumber="True" MaxLength="6" PlacesBeforeDecimal="3" DecimalPlaces="2"></ew:numericbox></TD>
												<TD width="5">
													<cc2:rangedomvalidator id="Rangedomvalidator3" runat="server" ErrorMessage="Ingrese valores de 0 a 100"
														MinimumValue="00.00" MaximumValue="100.00" ControlToValidate="txtPeso">*</cc2:rangedomvalidator></TD>
											</TR>
											<TR>
											</TR>
											<TR>
											</TR>
											<TR>
											</TR>
											<TR>
											</TR>
										</TABLE>
									</P>
									<DIV align="center">
										<TABLE id="Table8" width="180" align="center" border="0">
											<TR>
												<TD width="94"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
														Height="22px"></asp:imagebutton></TD>
												<TD width="101"><SPAN class="normal"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
															runat="server"></SPAN></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD align="center"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" ShowMessageBox="True" DisplayMode="List"
										EnableClientScript="False"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
