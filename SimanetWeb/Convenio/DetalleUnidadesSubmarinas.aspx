<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DetalleUnidadesSubmarinas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleUnidadesSubmarinas" %>
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
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR align="left">
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR align="left">
					<TD style="HEIGHT: 23px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR align="left">
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración Unidades de Apoyo> Administración Periodos> Administración Proyectos></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle del Proyecto</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD>
									<table id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" align="center"
										border="0">
										<tr bgColor="#000080">
											<td colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> DETALLE DEL PROYECTO</asp:label></td>
										</tr>
										<tr>
											<td colSpan="3" align="center">
												<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="780" border="1">
													<TR bgColor="#dddddd">
														<TD style="WIDTH: 156px; HEIGHT: 22px" align="left" width="156" bgColor="#335eb4"><asp:label id="lblNombreProyecto" runat="server" CssClass="TextoBlanco">PROYECTO:</asp:label></TD>
														<TD style="HEIGHT: 22px"><asp:textbox id="txtNombreProyecto" runat="server" CssClass="normaldetalle" MaxLength="50" Width="320px"></asp:textbox>
															<cc2:requireddomvalidator id="RqdvNombreProyecto" runat="server" ControlToValidate="txtNombreProyecto" ErrorMessage="*">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD style="WIDTH: 156px" align="left" width="156" bgColor="#335eb4"><asp:label id="lblMontoAsignado" runat="server" CssClass="TextoBlanco"> MONTO ASIGNADO:</asp:label></TD>
														<TD><ew:numericbox id="nbMontoAsignado" runat="server" CssClass="normaldetalle" MaxLength="15" Width="100px"
																PositiveNumber="True" PlacesBeforeDecimal="11" DecimalPlaces="2" AutoFormatCurrency="True"
																DollarSign=" "></ew:numericbox></TD>
													</TR>
													<TR id="ControlTablaFilaMontoEjecutado" bgColor="#dddddd" runat="server">
														<TD style="WIDTH: 156px; HEIGHT: 1px" align="left" width="156" bgColor="#335eb4"><asp:label id="lblMontoEjecutado" runat="server" CssClass="TextoBlanco">MONTO EJECUTADO:</asp:label></TD>
														<TD><ew:numericbox id="nbMontoEjecutado" runat="server" CssClass="normaldetalle" MaxLength="15" Width="100px"
																PositiveNumber="True" PlacesBeforeDecimal="11" DecimalPlaces="2" AutoFormatCurrency="True"
																DollarSign=" "></ew:numericbox></TD>
													</TR>
													<TR id="ControlTablaFilaMontoEnEjecucion" bgColor="#f0f0f0" runat="server">
														<TD align="left" width="156" bgColor="#335eb4"><asp:label id="lblMontoEnEjecucion" runat="server" CssClass="TextoBlanco">MONTO EN EJECUCION:</asp:label></TD>
														<TD><ew:numericbox id="nbMontoEnEjecucion" runat="server" CssClass="normaldetalle" MaxLength="15" Width="100px"
																PositiveNumber="True" PlacesBeforeDecimal="11" DecimalPlaces="2" AutoFormatCurrency="True"
																DollarSign=" "></ew:numericbox></TD>
													</TR>
													<TR id="ControlTablaFilaMontoComprometido" bgColor="#dddddd" runat="server">
														<TD style="WIDTH: 156px" align="left" width="156" bgColor="#335eb4"><asp:label id="lblMontoComprometido" runat="server" CssClass="TextoBlanco">MONTO COMPROMETIDO:</asp:label></TD>
														<TD><ew:numericbox id="nbMontoComprometido" runat="server" CssClass="normaldetalle" MaxLength="15"
																Width="100px" PositiveNumber="True" PlacesBeforeDecimal="11" DecimalPlaces="2" AutoFormatCurrency="True"
																DollarSign=" "></ew:numericbox></TD>
													</TR>
													<TR bgColor="#f0f0f0">
														<TD vAlign="top" align="left" width="156" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">DESCRIPCION:</asp:label></TD>
														<TD><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="100%"
																TextMode="MultiLine" Height="60px"></asp:textbox></TD>
													</TR>
													<TR bgColor="#dddddd">
														<TD style="WIDTH: 156px" vAlign="top" align="left" width="156" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco"> OBSERVACIONES:</asp:label></TD>
														<TD colSpan="2"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="100%"
																TextMode="MultiLine" Height="60px"></asp:textbox></TD>
													</TR>
												</TABLE>
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif">
											</td>
										</tr>
										<TR>
											<TD style="WIDTH: 756px" align="center" colSpan="3"><IMG style="WIDTH: 160px; HEIGHT: 10px" height="1" src="../imagenes/spacer.gif" width="160"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 757px" align="center" colSpan="3">
												<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD align="right"></TD>
														<TD width="20"></TD>
														<TD align="left"></TD>
														<TD align="right"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" Height="42px" EnableClientScript="False" ShowMessageBox="True"
													DisplayMode="List"></cc2:domvalidationsummary>
											</TD>
										</TR>
									</table>
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
