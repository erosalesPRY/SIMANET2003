<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleObservacionesVentas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.DetalleObservacionesVentas" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Observaciones Mensuales de Ventas</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center">
												<TABLE class="normal" id="Table7" cellSpacing="0" cellPadding="0" width="469" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">Centro de Operaciones:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px" bgColor="#dddddd" colSpan="4"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal"><cc2:requireddomvalidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">Tipo Observacion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbTipoObservacion" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 12px" vAlign="top" bgColor="#335eb4">
															<P><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">Fecha:</asp:label></P>
															<P>fFECHA DE CIERRE</P>
														</TD>
														<TD class="normal" style="WIDTH: 110px; HEIGHT: 12px" bgColor="#f0f0f0" colSpan="4"><ew:calendarpopup id="calFecha" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
																AllowArbitraryText="False" ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
														<TD class="normal" style="HEIGHT: 12px">
															<cc2:requireddomvalidator id="rfvTipoObservacion" runat="server" ControlToValidate="ddlbTipoObservacion">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco"> Observacion :</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Width="336px" Height="112px"
																MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"><cc2:requireddomvalidator id="rfvObservacion" runat="server" ControlToValidate="txtObservacion">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" align="center" bgColor="#335eb4" colSpan="5"><asp:label id="lblInfo" runat="server" CssClass="TextoBlanco">LA FECHA SIRVE PARA ESPECIFICAR SOLO EL PERIODO Y EL MES DE LA OBSERVACION</asp:label></TD>
														<TD class="normal" vAlign="top" align="center"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" Width="100px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table8" border="0">
										<TR>
											<TD vAlign="middle"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
													Height="22px"></asp:imagebutton></TD>
											<TD vAlign="middle"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
						<IMG height="5" src="../imagenes/spacer.gif" width="592"></TD>
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
