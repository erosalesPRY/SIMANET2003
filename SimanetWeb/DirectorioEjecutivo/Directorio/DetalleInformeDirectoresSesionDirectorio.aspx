<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleInformeDirectoresSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.DetalleInformeDirectoresSesionDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onunload="SubirHistorial();"
		onload="ObtenerHistorial();">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top">
						<asp:label id="Label1" runat="server" CssClass="RutaPagina">Inicio > Gestión de la Dirección</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Informes de Sesión de Directorio</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table cellSpacing="0" cellPadding="0" align="center" border="1" borderColor="#ffffff">
							<tr>
								<td class="normal" colSpan="3" bgColor="#000080"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="center"
													border="0">
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label class="" id="lblNroInforme" runat="server" CssClass="TextoBlanco">Nro. de Informe:</asp:label></TD>
														<TD class="normal" colSpan="4" vAlign="top" bgColor="#dddddd"><asp:textbox id="txtNumeroInforme" runat="server" CssClass="normaldetalle" MaxLength="1500"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvNroInforme" runat="server" ControlToValidate="txtNumeroInforme">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDetalle" runat="server" CssClass="TextoBlanco">Detalle:</asp:label></TD>
														<TD class="normal" colSpan="4" vAlign="top" bgColor="#f0f0f0"><asp:textbox id="txtDetalle" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="100%"
																TextMode="MultiLine" Height="112px"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvDetalle" runat="server" ControlToValidate="txtDetalle">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Promotor:</asp:label></TD>
														<TD class="normal" vAlign="top" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtReferencia" runat="server" CssClass="normaldetalle" MaxLength="1500" Height="50px"
																TextMode="MultiLine" Width="100%"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblArchivoAdjunto" runat="server" CssClass="TextoBlanco">Archivo Adjunto:</asp:label></TD>
														<TD class="normal" vAlign="top" bgColor="#f0f0f0" colSpan="4"><INPUT class="normaldetalle" id="filMyFile" type="file" size="48" name="filMyFile" runat="server"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top"></TD>
														<TD class="normal" colSpan="4"></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" colSpan="6">
															<TABLE id="Table7" height="25" cellSpacing="0" cellPadding="0" align="center" border="0">
																<TR>
																	<TD align="center">&nbsp;&nbsp;&nbsp;
																		<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;<SPAN class="normal">
																			<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
																				style="CURSOR: hand"></SPAN></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary><INPUT id="hDocActa" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDocActa"
													runat="server"></TD>
											<TD style="WIDTH: 1px; HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<span class="normal"></span><span class="normal"></span>
								</TD>
							</TR>
						</table>
					</td>
				</tr>
			</table>
			<p>&nbsp;</p>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
