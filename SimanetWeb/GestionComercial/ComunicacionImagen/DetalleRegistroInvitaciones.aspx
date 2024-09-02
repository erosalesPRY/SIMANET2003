<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleRegistroInvitaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleRegistroInvitaciones" %>
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
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" align="center" border="0" width="100%">
							<TR>
								<TD class="Commands" width="100%" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Invitaciones</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hIdPersonal" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonal"
										runat="server"><INPUT id="hIdBuque" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdBuque"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD vAlign="top" align="center">
												<TABLE class="normal" id="Table7" cellSpacing="0" cellPadding="0" width="470" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" align="center" colSpan="5">
															<asp:RadioButtonList id="rblTipoPersona" runat="server" CssClass="normaldetalle" RepeatDirection="Horizontal"
																AutoPostBack="True">
																<asp:ListItem Value="1" Selected="True">Registrado</asp:ListItem>
																<asp:ListItem Value="0">No Registrado</asp:ListItem>
															</asp:RadioButtonList></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNombrePersona" runat="server" CssClass="TextoBlanco"> Persona:</asp:label>
														</TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtPersonal" runat="server" CssClass="normaldetalle" Width="315px" MaxLength="80"
																ReadOnly="True"></asp:textbox>
															<asp:ImageButton id="ibtnBuscarPersonal" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False"></asp:ImageButton></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvNombrePersona" runat="server" ControlToValidate="txtPersonal">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblGradoCargo" runat="server" CssClass="TextoBlanco">Cargo y/o Grado:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtGradoCargo" runat="server" CssClass="normaldetalle" MaxLength="200" Width="315px"
																Visible="False"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblFechaLanzamiento" runat="server" CssClass="TextoBlanco"> Fecha Lanzamiento:</asp:Label>
														</TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:calendarpopup id="calFechaLanzamiento" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																ShowGoToToday="True" ControlDisplay="TextBoxImage" Culture="Spanish (Chile)" PadSingleDigits="True">
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
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblNombreBuque" runat="server" CssClass="TextoBlanco">Buque:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtNombreBuque" runat="server" CssClass="normaldetalle" MaxLength="80" Width="315px"
																ReadOnly="True"></asp:textbox>
															<asp:ImageButton id="ibtnBuscarBuque" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False"></asp:ImageButton></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvNombreBuque" runat="server" ControlToValidate="txtNombreBuque">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																Height="54px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																Height="54px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table8" width="180" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													runat="server"></TD>
											<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR bgColor="#5891ae">
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
