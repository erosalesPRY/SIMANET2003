<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleCostoManoObra.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleCostoManoObra" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
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
					<TD colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Costos de Mano de Obra</asp:label></TD>
							</TR>
							<TR>
								<TD align="right">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<TR>
											<TD></TD>
											<TD>
												<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="500" align="center" border="1">
													<TR>
														<TD class="normal" style="WIDTH: 293px" vAlign="middle" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 293px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblManoObra" runat="server" CssClass="TextoBlanco">Mano de Obra:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" bgColor="#dddddd" colSpan="4" id="CellddlbManoObra"
															runat="server"><asp:dropdownlist id="ddlbManoObra" runat="server" CssClass="normalDetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvTipoManoObra" runat="server" ControlToValidate="ddlbManoObra">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 293px; HEIGHT: 25px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblCO" runat="server" CssClass="TextoBlanco">Centro Operativo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 25px" bgColor="#f0f0f0" colSpan="4"
															id="CellddlbCentroOperativo" runat="server"><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normalDetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 25px"><cc1:requireddomvalidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 293px; HEIGHT: 25px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblCosto" runat="server" CssClass="TextoBlanco">Costo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 25px" bgColor="#dddddd" colSpan="4">
															<ew:numericbox id="nbCosto" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="18"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="15"></ew:numericbox></TD>
														<TD class="normal" style="HEIGHT: 25px"><cc1:requireddomvalidator id="rfvCosto" runat="server" ControlToValidate="nbCosto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 293px; HEIGHT: 25px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px; HEIGHT: 25px" bgColor="#f0f0f0" colSpan="4"
															id="CellddlbMoneda" runat="server"><asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normalDetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 25px"><cc1:requireddomvalidator id="rfvMoneda" runat="server" ControlToValidate="ddlbMoneda">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 293px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco"> Descripcion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" CssClass="normalDetalle" Width="336px" MaxLength="2000"
																Height="54px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"><cc1:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD colSpan="5" align="center">
															<cc1:domvalidationsummary id="vSum" runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List"
																ShowMessageBox="True"></cc1:domvalidationsummary>
														</TD>
													</TR>
													<TR>
														<TD align="left" colSpan="5">
															<TABLE id="Table1" cellSpacing="0" cellPadding="0" border="0">
																<TR>
																	<TD id="CellibtnAtras" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
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
