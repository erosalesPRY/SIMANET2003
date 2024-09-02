<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleCostoMateriales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleCostoMateriales" %>
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
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td colspan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Información Comercial > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Costos de Materiales</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD style="HEIGHT: 108px">
												<TABLE class="normal" id="Table3" style="WIDTH: 500px; HEIGHT: 248px" cellSpacing="0" cellPadding="0"
													width="500" align="center" border="1" borderColor="#ffffff">
													<TR>
														<TD align="center" colSpan="6">
															<asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label>
															<asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4" style="HEIGHT: 16px">
															<asp:label id="lblTipoMaterial" runat="server" CssClass="TextoBlanco">Tipo Material:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px; HEIGHT: 16px" colSpan="4" bgColor="#dddddd"
															id="CellddlbTipoMaterial" runat="server">
															<asp:dropdownlist id="ddlbTipoMaterial" runat="server" CssClass="normaldetalle" Width="336px"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 16px">
															<cc1:RequiredDomValidator id="rfvTipoMaterial" runat="server" ControlToValidate="ddlbTipoMaterial" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4">
															<asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco" Width="96px">Centro Operativo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px" bgColor="#f0f0f0" colSpan="4" id="CellddlbCentroOperativo"
															runat="server">
															<asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal">
															<cc1:RequiredDomValidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4">
															<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Ubigeo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px" colSpan="4" bgColor="#dddddd" id="CellddlbUbigeo"
															runat="server">
															<asp:dropdownlist id="ddlbUbigeo" runat="server" CssClass="normaldetalle" Width="336px"></asp:dropdownlist></TD>
														<TD class="normal">
															<cc1:RequiredDomValidator id="rfvUbigeo" runat="server" ControlToValidate="ddlbUbigeo" InitialValue="%">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4" style="HEIGHT: 19px">
															<asp:label id="lblCosto" runat="server" CssClass="TextoBlanco">Costo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px; HEIGHT: 19px" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="nbCosto" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="3"
																RealNumber="False" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="3"></ew:numericbox></TD>
														<TD class="normal" style="HEIGHT: 19px">
															<cc1:RequiredDomValidator id="rfvCosto" runat="server" InitialValue="%" ControlToValidate="nbCosto">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4">
															<asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" style="WIDTH: 110px" bgColor="#dddddd" colSpan="4" id="CellddlbMoneda"
															runat="server">
															<asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD>
															<cc1:RequiredDomValidator id="rfvMoneda" runat="server" InitialValue="%" ControlToValidate="ddlbMoneda">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4">
															<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco"> Descripcion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="2000"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal">
															<cc1:RequiredDomValidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD align="right" colSpan="5">
														</TD>
													</TR>
													<TR>
														<TD align="center" colSpan="5">
															<cc1:domvalidationsummary id="vSum" runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List"
																ShowMessageBox="True"></cc1:domvalidationsummary></TD>
													</TR>
													<TR>
														<TD align="left" colSpan="5">
															<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" border="0">
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
