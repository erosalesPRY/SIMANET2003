<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleCostoEmbarcacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleCostoEmbarcacion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
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
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Detalle de Costo de Embarcaciones</asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<TR>
											<TD></TD>
											<TD>
												<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="530" align="center"
													border="1" borderColor=#ffffff>
													<TR>
														<TD class="normal" align="center" colSpan="6"><asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD vAlign="middle" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label>
															<asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco" BackColor="Transparent"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 113px; HEIGHT: 66px" vAlign="top" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco"> Descripcion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 66px" colSpan="4" bgColor="#dddddd"><asp:textbox id="txtDescripcion" runat="server" CssClass="normalDetalle" Height="54px" TextMode="MultiLine"
																MaxLength="2000" Width="376px"></asp:textbox></TD>
														<TD class="normal" style="HEIGHT: 66px"><cc1:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 113px; HEIGHT: 29px" vAlign="top" bgColor="#335eb4"><asp:label id="lblTipoEmbarcacion" runat="server" CssClass="TextoBlanco">Tipo Embarcacion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 29px" colSpan="4" bgColor="#f0f0f0"
															id="CellddlbTipoEmbarcacion" runat="server"><asp:dropdownlist id="ddlbTipoEmbarcacion" runat="server" CssClass="normalDetalle" Width="136px" BackColor="Transparent"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 29px"><cc1:requireddomvalidator id="rfvTipoEmbarcacion" runat="server" ControlToValidate="ddlbTipoEmbarcacion">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" style="WIDTH: 113px" bgColor="#335eb4"><asp:label id="lblCO" runat="server" CssClass="TextoBlanco" Width="103px">Centro Operativo :</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" colSpan="4" bgColor="#dddddd" id="CellddlbCentroOperativo"
															runat="server"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normalDetalle" Width="136px" BackColor="Transparent"></asp:dropdownlist></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" style="WIDTH: 113px" bgColor="#335eb4"><asp:label id="lblCosto" runat="server" CssClass="TextoBlanco">Costo x KG.:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" colSpan="4" bgColor="#f0f0f0">
															<ew:numericbox id="nbCosto" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="18"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="15"></ew:numericbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvCosto" runat="server" ControlToValidate="nbCosto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" style="WIDTH: 113px" bgColor="#335eb4"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" colSpan="4" bgColor="#dddddd" id="CellddlbMoneda"
															runat="server"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normalDetalle" Width="136px" BackColor="Transparent"></asp:dropdownlist></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvMoneda" runat="server" ControlToValidate="ddlbMoneda">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD align="center" colSpan="5">
															<cc1:domvalidationsummary id="vSum" runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List"
																ShowMessageBox="True"></cc1:domvalidationsummary></TD>
													</TR>
													<TR>
														<TD id="TdCeldaCancelar" align="left" colSpan="5" runat="server">
															<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
																<TR>
																	<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD align="center" colSpan="5">
															<TABLE id="Table8" width="180" border="0">
																<TR>
																	<TD>
																		<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																	<TD id="CellibtnCancelar" runat="server"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</table>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
