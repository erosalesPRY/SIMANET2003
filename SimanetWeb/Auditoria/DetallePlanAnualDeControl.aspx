<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetallePlanAnualDeControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.DetallePlanAnualDeControl" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
			</table>
			<table cellSpacing="0" cellPadding="0" width="780" border="0" align="center">
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="764" align="center" border="0">
							<tr>
								<td class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Detalle de Plan Anual de Control</asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="764" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px">
												<TABLE class="normal" id="Table3" style="HEIGHT: 306px" cellSpacing="0" cellPadding="0"
													width="764" align="center" border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="center" colSpan="6"><asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 12px" bgColor="#000080" colSpan="4"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" id="TD1" style="HEIGHT: 12px" bgColor="#335eb4"><asp:label id="lblCodigo" runat="server" CssClass="TextoBlanco">Codigo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px; HEIGHT: 12px" colSpan="3" bgColor="#dddddd"><asp:textbox id="txtCodigo" runat="server" CssClass="normaldetalle" MaxLength="15" Width="120px"></asp:textbox></TD>
														<TD class="normal" style="HEIGHT: 12px">
															<cc1:RequiredDomValidator id="rfvCodigo" runat="server" ControlToValidate="txtCodigo">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 11px" bgColor="#335eb4"><asp:label id="lblUnidadMedida" runat="server" CssClass="TextoBlanco" Width="93px">Unidad de Medida:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px; HEIGHT: 11px" colSpan="3" bgColor="#f0f0f0"><asp:dropdownlist id="ddlbUnidadMedida" runat="server" CssClass="normaldetalle" Width="150px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 11px"><asp:requiredfieldvalidator id="rfvUnidadMedida" runat="server" ControlToValidate="ddlbUnidadMedida" InitialValue="%">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 11px" bgColor="#335eb4"><asp:label id="lblPeriodo" runat="server" CssClass="TextoBlanco">Periodo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px; HEIGHT: 11px" colSpan="3" bgColor="#dddddd"><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normaldetalle" Width="150px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 11px">
															<cc1:RequiredDomValidator id="rfvPeriodo" runat="server" ControlToValidate="ddlbPeriodo" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 11px" bgColor="#335eb4"><asp:label id="lblPorcentajeAvance" runat="server" CssClass="TextoBlanco" Width="68px">% de Avance:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px; HEIGHT: 11px" colSpan="3" bgColor="#f0f0f0">
															<ew:NumericBox id="txtPorcentajeAvance" runat="server" MaxLength="3" Width="50px" PositiveNumber="True"
																CssClass="normaldetalle" RealNumber="False" Enabled="False" TextAlign="Right"></ew:NumericBox></TD>
														<TD class="normal" style="HEIGHT: 11px">
															<asp:requiredfieldvalidator id="rfvPorcentajeAvance" runat="server" ControlToValidate="txtPorcentajeAvance"
																InitialValue="%">*</asp:requiredfieldvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 35px" bgColor="#335eb4">
															<asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco">Denominación:</asp:label></TD>
														<TD class="normal" style="WIDTH: 466px; HEIGHT: 35px" colSpan="3" bgColor="#dddddd">
															<asp:textbox id="txtDenominacion" runat="server" CssClass="normaldetalle" Height="56px" TextMode="MultiLine"
																Width="600px" MaxLength="1500"></asp:textbox></TD>
														<TD class="normal" style="HEIGHT: 35px">
															<cc1:RequiredDomValidator id="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 38px" bgColor="#335eb4">
															<asp:label id="lblObservacion" runat="server" CssClass="TextoBlanco">Observación:</asp:label></TD>
														<TD class="normal" style="WIDTH: 466px; HEIGHT: 38px" colSpan="3" bgColor="#f0f0f0">
															<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="600px"
																TextMode="MultiLine" Height="56px"></asp:textbox></TD>
													</TR>
													<TR>
														<TD class="normal">
															<asp:label id="lblMetas" runat="server" CssClass="TextoBlanco" Visible="False">Metas:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" colSpan="3">
															<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="300" border="0">
																<TR>
																	<TD>
																		<asp:CheckBox id="cbxEnero" runat="server" CssClass="normaldetalle" Text="E" Visible="False" ToolTip="Enero"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxFebrero" runat="server" CssClass="normaldetalle" Text="F" Visible="False"
																			ToolTip="Febrero"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxMarzo" runat="server" CssClass="normaldetalle" Text="M" Visible="False" ToolTip="Marzo"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxAbril" runat="server" CssClass="normaldetalle" Text="A" Visible="False" ToolTip="Abril"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxMayo" runat="server" CssClass="normaldetalle" Text="M" Visible="False" ToolTip="Mayo"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxJunio" runat="server" CssClass="normaldetalle" Text="J" Visible="False" ToolTip="Junio"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxJulio" runat="server" CssClass="normaldetalle" Text="J" Visible="False" ToolTip="Julio"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxAgosto" runat="server" CssClass="normaldetalle" Text="A" Visible="False"
																			ToolTip="Agosto"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxSeptiembre" runat="server" CssClass="normaldetalle" Text="S" Visible="False"
																			ToolTip="Agosto"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxOctubre" runat="server" CssClass="normaldetalle" Text="O" Visible="False"
																			ToolTip="Octubre"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxNoviembre" runat="server" CssClass="normaldetalle" Text="N" Visible="False"
																			ToolTip="Noviembre"></asp:CheckBox></TD>
																	<TD>
																		<asp:CheckBox id="cbxDiciembre" runat="server" CssClass="normaldetalle" Text="D" Visible="False"
																			ToolTip="Diciembre"></asp:CheckBox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="normal" align="right" colSpan="4">
															<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="1" borderColor="#ffffff">
																<TR>
																	<TD><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif" Height="22px"></asp:imagebutton></TD>
																	<TD><asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" Height="22px"
																			CausesValidation="False"></asp:imagebutton></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:DomValidationSummary id="vSum" runat="server" EnableClientScript="False" ShowMessageBox="True" DisplayMode="List"></cc1:DomValidationSummary>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
