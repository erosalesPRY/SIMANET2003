<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetalleActividad.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.DetalleActividad" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleActividad</title>
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
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Actividades</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<P align="left"><INPUT id="hidCargoLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hidCargoLider"
								runat="server"><INPUT id="hIdAreaLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdAreaLider"
								runat="server"><INPUT id="hIdPersonalLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonalLider"
								runat="server"><INPUT id="hNombreLider" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hNombreLider"
								runat="server"></P>
					</TD>
				</TR>
				<TR>
					<TD><asp:image id="Image1" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="24px" Width="48px"></asp:image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center"></DIV>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 233px">
									<P align="left">
										<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="565" align="center"
											border="1" runat="server">
											<TR>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#000080" colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
												<TD style="WIDTH: 138px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Codigo Actividad</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:textbox id="txtCodigoActividad" runat="server" CssClass="NormalDetalle" Width="250px" ReadOnly="True"
														BorderStyle="Groove"></asp:textbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco">Nombre Actividad</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtNombreActividad" runat="server" CssClass="NormalDetalle" Width="500px" BorderStyle="Groove"></asp:textbox></TD>
												<TD><cc2:requireddomvalidator id="rfvNombreProceso" runat="server" ControlToValidate="txtNombreActividad">*</cc2:requireddomvalidator></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblLider" runat="server" CssClass="TextoBlanco">Responsable</asp:label></TD>
												<TD bgColor="#dddddd"><asp:textbox id="txtLider" runat="server" CssClass="normaldetalle" Width="480px" ReadOnly="True"
														BorderStyle="Groove" MaxLength="80"></asp:textbox><asp:imagebutton id="ibtnBuscarLider" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
														CausesValidation="False"></asp:imagebutton></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px; HEIGHT: 3px" bgColor="#335eb4"><asp:label id="lblParticipantes" runat="server" CssClass="TextoBlanco">A.F.</asp:label></TD>
												<TD style="HEIGHT: 3px" bgColor="#f0f0f0"><ew:numericbox id="txtAF" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
														MaxLength="6" DecimalPlaces="2" PlacesBeforeDecimal="3" PositiveNumber="True"></ew:numericbox></TD>
												<TD style="HEIGHT: 3px"></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="Label3" runat="server" CssClass="TextoBlanco">año</asp:label></TD>
												<TD bgColor="#f0f0f0"><ew:calendarpopup id="CalFecha" runat="server" CssClass="combos" ImageUrl="../../imagenes/BtPU_Mas.gif"
														Width="72px" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Peru)" PadSingleDigits="True"
														Text="...">
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
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblCO" runat="server" CssClass="TextoBlanco">inversion</asp:label></TD>
												<TD bgColor="#dddddd"><ew:numericbox id="txtInversion" runat="server" CssClass="normaldetalle" Width="100px" BorderStyle="Groove"
														MaxLength="18" DecimalPlaces="2" PlacesBeforeDecimal="15" PositiveNumber="True"></ew:numericbox></TD>
												<TD></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 138px" bgColor="#335eb4"><asp:label id="lblVisibilidad" runat="server" CssClass="TextoBlanco">VISIBILIDAD</asp:label></TD>
												<TD bgColor="#f0f0f0"><asp:dropdownlist id="dllVisibilidad" runat="server" CssClass="NormalDetalle" Width="100px"></asp:dropdownlist></TD>
												<TD></TD>
											</TR>
										</TABLE>
									</P>
									<TABLE id="Table8" width="180" align="center" border="0">
										<TR>
											<TD width="94"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif" Height="22px"
													Width="87px"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></SPAN></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
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
