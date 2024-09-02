<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleValorizacionOrdenTrabajoConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleValorizacionOrdenTrabajoConvenio" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Simanet</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial2();" rightMargin="0" onunload="SubirHistorial();"
		oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9) return false">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD width="100%">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración de Convenio SIMA - MGP> Proyecto > Valorizaciones ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> REGISTRAR VALORIZACION</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR bgColor="#000080">
								<TD class="TituloPrincipal"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> CONVENIO SIMA - MGP:</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD>
												<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<tr>
														<td bgColor="#335eb4" colSpan="2"><asp:label id="lblProyecto" runat="server" CssClass="TextoBlanco">PROYECTO:</asp:label></td>
													</tr>
													<tr>
														<td colSpan="2"><asp:textbox id="txtDescripcionProyecto" runat="server" CssClass="normal" Height="48px" TextMode="MultiLine"
																Width="100%" ReadOnly="True"></asp:textbox></td>
													</tr>
													<tr bgColor="#dddddd">
														<td align="center" colSpan="2"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></td>
													</tr>
													<tr>
														<td bgColor="#335eb4" colSpan="2"><asp:label id="lblSubTitulo" runat="server" CssClass="TextoBlanco">REGISTRAR VALORIZACION DEL PROYECTO CONVENIO:</asp:label></td>
													</tr>
													<tr bgColor="#f0f0f0">
														<td align="center" colSpan="2"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="160"></td>
													</tr>
													<TR bgColor="#dddddd">
														<TD align="right" bgColor="#335eb4"><asp:label id="lblDivision" runat="server" CssClass="TextoBlanco">DIVISION: &nbsp;</asp:label></TD>
														<TD align="center">
															<TABLE id="Table6" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" align="center"
																border="1">
																<TR>
																	<TD width="40"><asp:dropdownlist id="ddlbDivision" runat="server" CssClass="normaldetalle"></asp:dropdownlist></TD>
																	<TD align="right" width="100" bgColor="#335eb4"><asp:label id="lblNumero" runat="server" CssClass="TextoBlanco">NUMERO: &nbsp;</asp:label></TD>
																	<TD align="left"><ew:numericbox id="nbNumero" runat="server" CssClass="normaldetalle" Width="56px" RealNumber="False"
																			PositiveNumber="True" MaxLength="6"></ew:numericbox><cc1:requireddomvalidator id="rqdvNumero" runat="server" ErrorMessage="==> Número no fue Ingresado" ControlToValidate="nbNumero">*</cc1:requireddomvalidator></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD align="center" colSpan="2">
															<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/bt_cancelar.gif"></TD>
													</TR>
													<TR>
														<TD align="center" width="100%" colSpan="2">
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<INPUT id="objHistorial" type="hidden" name="objHistorial">
								</TD>
							</TR>
							<TR>
								<TD><cc1:domvalidationsummary id="DomValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"
										EnableClientScript="False"></cc1:domvalidationsummary></TD>
							</TR>
						</TABLE>
						<IMG style="HEIGHT: 10px" height="3" src="../imagenes/spacer.gif" width="120">
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
