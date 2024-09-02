<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetallerPeriodoApoyoFasub.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetallerPeriodoApoyoFasub" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR width="100%">
					<TD vAlign="baseline" width="100%">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración de Convenio SIMA - MGP> Proyecto ></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Proyecto</asp:label></TD>
				</TR>
				<TR width="100%">
					<TD align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="720" align="center" border="0">
							<TR>
								<TD align="center" style="HEIGHT: 191px">
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="HEIGHT: 149px">
												<TABLE class="normal" id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="100%" border="1">
													<TR bgColor="#000080">
														<TD colSpan="2">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> CONVENIO SIMA - MGP:</asp:label></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD style="WIDTH: 171px" align="right" bgColor="#335eb4">
															<asp:label id="lblNroProyecto" runat="server" CssClass="TextoBlanco"> PERIODO:</asp:label>&nbsp;</TD>
														<TD>
															<ew:numericbox id="nbNroProyecto" runat="server" CssClass="normaldetalle" Width="88px" MaxLength="3"
																PositiveNumber="True" RealNumber="False"></ew:numericbox>
															<cc1:requireddomvalidator id="rqdvProyecto" runat="server" ControlToValidate="nbNroProyecto">*</cc1:requireddomvalidator>
														</TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD style="WIDTH: 171px" vAlign="top" align="right" bgColor="#335eb4">&nbsp;
															<asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="69px">DESCRIPCION: &nbsp;</asp:label>&nbsp;</TD>
														<TD>
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="544px" MaxLength="1500"
																TextMode="MultiLine" Height="56px"></asp:textbox></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD style="WIDTH: 171px" align="right" bgColor="#335eb4" vAlign="top">
															<asp:label id="lblEstado" runat="server" CssClass="TextoBlanco"> OBSERVACIONES:</asp:label>&nbsp;</TD>
														<TD>
															<asp:textbox id="Textbox1" runat="server" CssClass="normaldetalle" MaxLength="1500" Width="544px"
																Height="56px" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;
						<IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial(); HistorialIrAtras();"
							alt="" src="/SimanetWeb/imagenes/bt_cancelar.gif">
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<cc1:domvalidationsummary id="DomValidationSummary1" runat="server" Width="196px" DisplayMode="List" ShowMessageBox="True"
			EnableClientScript="False" Height="24px"></cc1:domvalidationsummary><INPUT id="objHistorial" type="hidden" name="objHistorial" style="WIDTH: 8px; HEIGHT: 22px"
			size="1">
	</body>
</HTML>
