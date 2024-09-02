<%@ Page language="c#" Codebehind="DetalleConceptosPorPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleConceptosPorPagar" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial2();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Conceptos por Pagar></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRACION</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR>
								<TD width="100%">
									<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr bgcolor="#000080">
											<td><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco">CONCEPTOS POR PAGAR</asp:label></td>
										</tr>
										<tr>
											<td colspan="3" align="center">
												<table id="Table4" cellspacing="0" cellpadding="0" width="100%" border="1" bordercolor="#ffffff">
													<tr bgcolor="#dddddd">
														<td align="right" style="WIDTH: 144px" bgColor="#335eb4">
															<asp:Label id="lblPeriodo" runat="server" CssClass="TextoBlanco">PERIODO:</asp:Label></td>
														<td style="WIDTH: 2px"></td>
														<td>
															<ew:numericbox id="nbPeriodo" runat="server" CssClass="normaldetalle" MaxLength="4" Width="88px"
																PositiveNumber="True" RealNumber="False"></ew:numericbox>
															<cc2:requireddomvalidator id="rqdvPeriodo" runat="server" ControlToValidate="nbPeriodo">*</cc2:requireddomvalidator>
															<asp:RangeValidator id="ragvPeriodo" runat="server" ControlToValidate="nbPeriodo">*</asp:RangeValidator></td>
													</tr>
													<tr bgcolor="#f0f0f0">
														<td align="right" style="WIDTH: 144px" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblConceptoDescripcion" runat="server" CssClass="TextoBlanco">CONCEPTO:</asp:Label></td>
														<td style="WIDTH: 2px"></td>
														<td>
															<asp:TextBox id="txtConceptoPorPagar" runat="server" Width="100%" TextMode="MultiLine" MaxLength="1000"
																CssClass="normaldetalle"></asp:TextBox></td>
													</tr>
													<tr bgcolor="#dddddd">
														<td align="right" style="WIDTH: 144px" bgColor="#335eb4">
															<asp:Label id="lblMontoPorPagar" runat="server" CssClass="TextoBlanco">MONTO POR PAGAR:</asp:Label></td>
														<td style="WIDTH: 2px"></td>
														<td>
															<ew:numericbox id="nbMontoPorPagar" runat="server" CssClass="normaldetalle" MaxLength="15" Width="120px"
																PositiveNumber="True" DecimalPlaces="3" RealNumber="False" DollarSign=" " AutoFormatCurrency="True"></ew:numericbox></td>
													</tr>
												</table>
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/bt_cancelar.gif">
											</td>
										</tr>
										<tr>
											<td colspan="3"><INPUT id="objHistorial" type="hidden" name="objHistorial">
											</td>
										</tr>
									</table>
									<cc2:domvalidationsummary id="DomValidationSummary1" runat="server" Width="136px" DisplayMode="List" ShowMessageBox="True"
										EnableClientScript="False"></cc2:domvalidationsummary>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			<SCRIPT>
								<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
