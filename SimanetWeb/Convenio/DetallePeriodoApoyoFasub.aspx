<%@ Page language="c#" Codebehind="DetallePeriodoApoyoFasub.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetallePeriodoApoyoFasub" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR width="100%">
					<TD vAlign="baseline" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración de Unidades de Apoyo> Administración de Periodos ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Periodos</asp:label></TD>
				</TR>
				<TR width="100%">
					<TD align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="720" align="center" border="0">
							<TR>
								<TD style="HEIGHT: 191px" align="center">
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD style="HEIGHT: 149px">
												<TABLE class="normal" id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="100%" border="1">
													<TR bgColor="#000080">
														<TD colSpan="2"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="672px"> :</asp:label></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD style="WIDTH: 171px; HEIGHT: 23px" align="right" bgColor="#335eb4"><asp:label id="lblNroProyecto" runat="server" CssClass="TextoBlanco"> PERIODO:</asp:label>&nbsp;</TD>
														<TD style="HEIGHT: 23px"><ew:numericbox id="nbPeriodo" runat="server" CssClass="normaldetalle" Width="88px" PositiveNumber="True"
																MaxLength="4"></ew:numericbox>&nbsp;
															<cc3:requireddomvalidator id="rqdvPeriodo" runat="server" ControlToValidate="nbPeriodo" ErrorMessage="*">*</cc3:requireddomvalidator>&nbsp;
															<cc3:RangeDomValidator id="cmpvPeriodo" runat="server" ErrorMessage="*" ControlToValidate="nbPeriodo" Display="Dynamic"
																MinimumValue="1845" MaximumValue="2050"></cc3:RangeDomValidator></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD style="WIDTH: 171px" vAlign="top" align="right" bgColor="#335eb4">&nbsp;
															<asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco" Width="69px">DESCRIPCION: &nbsp;</asp:label>&nbsp;</TD>
														<TD><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="544px" MaxLength="1500"
																Height="56px" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD style="WIDTH: 171px" vAlign="top" align="right" bgColor="#335eb4"><asp:label id="lblEstado" runat="server" CssClass="TextoBlanco"> OBSERVACIONES:</asp:label>&nbsp;</TD>
														<TD><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="544px" MaxLength="1500"
																Height="56px" TextMode="MultiLine"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="objHistorial" style="WIDTH: 8px; HEIGHT: 22px" type="hidden" size="1" name="objHistorial"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:imagebutton id="ibtnCancelar" runat="server" Width="87px" Height="22px" ImageUrl="../imagenes/bt_cancelar.gif"
							CausesValidation="False"></asp:imagebutton><BR>
						<cc3:domvalidationsummary id="vSum" runat="server" Height="42px" EnableClientScript="False" DisplayMode="List"
							ShowMessageBox="True"></cc3:domvalidationsummary></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
