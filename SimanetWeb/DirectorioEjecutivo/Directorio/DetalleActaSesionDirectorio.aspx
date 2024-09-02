<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleActaSesionDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.DetalleActaSesionDirectorio" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
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
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="Commands" vAlign="top"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de la Dirección ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Acta de Sesión de Directorio</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center">
						<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" align="center" border="1">
							<tr>
								<td class="normal" bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></td>
							</tr>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="1" cellPadding="1" align="center" border="0">
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDetalle" runat="server" CssClass="TextoBlanco" Width="60px">Detalle:</asp:label></TD>
														<TD class="normal" vAlign="top" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtDetalle" runat="server" CssClass="normaldetalle" Width="408px" MaxLength="1500"
																TextMode="MultiLine" Height="136px"></asp:textbox></TD>
														<TD class="normal" vAlign="top"><cc1:requireddomvalidator id="rfvDetalle" runat="server" ControlToValidate="txtDetalle">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 17px" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblArchivoAdjunto" runat="server" CssClass="TextoBlanco">Archivo Acta: </asp:label></TD>
														<TD class="normal" style="HEIGHT: 17px" vAlign="top" bgColor="#dddddd" colSpan="4"><INPUT class="normaldetalle" id="filMyFile" style="WIDTH: 408px; HEIGHT: 20px" type="file"
																size="48" name="filMyFile" runat="server"></TD>
														<TD class="normal" style="HEIGHT: 17px" vAlign="top"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" colSpan="6">
															<TABLE id="Table7" height="25" cellSpacing="0" cellPadding="0" align="center" border="0">
																<TR>
																	<TD align="center">&nbsp;&nbsp;&nbsp;
																		<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;<SPAN class="normal">
																			<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif" style="CURSOR: hand"></SPAN></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary><INPUT id="hDocActa" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hDocActa"
													runat="server"></TD>
											<TD vAlign="bottom" align="center"></TD>
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
