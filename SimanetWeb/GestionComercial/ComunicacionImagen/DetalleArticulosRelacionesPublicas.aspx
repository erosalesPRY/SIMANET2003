<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleArticulosRelacionesPublicas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleArticulosRelacionesPublicas" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
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
					<td colSpan="3" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Artículos de Relaciones Públicas</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD vAlign="top" align="center">
												<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="470" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblArticulo" runat="server" CssClass="TextoBlanco"> Articulo:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#dddddd">
															<asp:textbox id="txtArticulo" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="80"></asp:textbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvArticulo" runat="server" ControlToValidate="txtArticulo">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion Articulo:</asp:label></TD>
														<TD class="normal" colSpan="4" bgColor="#f0f0f0">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="336px" MaxLength="2000"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCosto" runat="server" CssClass="TextoBlanco">Costo:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:numericbox id="txtCosto" runat="server" CssClass="normaldetalle" MaxLength="19" Width="136px"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="12"></ew:numericbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvCosto" runat="server" ControlToValidate="txtCosto">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 1px">
															<cc1:requireddomvalidator id="rfvMoneda" runat="server" ControlToValidate="ddlbMoneda">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCantidadMaxima" runat="server" CssClass="TextoBlanco">Cantidad Maxima:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:numericbox id="txtCantidadMaxima" runat="server" CssClass="normaldetalle" MaxLength="4" Width="136px"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4" RealNumber="False"></ew:numericbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvCantidadMaxima" runat="server" ControlToValidate="txtCantidadMaxima">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCantidadMinima" runat="server" CssClass="TextoBlanco">Cantidad Minima:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="txtCantidadMinima" runat="server" CssClass="normaldetalle" MaxLength="4" Width="136px"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4" RealNumber="False"></ew:numericbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvCantidadMinima" runat="server" ControlToValidate="txtCantidadMinima">*</cc1:requireddomvalidator>
															<cc1:comparedomvalidator id="cvCantidadMaximaMinima" runat="server" ControlToValidate="txtCantidadMaxima"
																Type="Integer" ControlToCompare="txtCantidadMinima" Operator="GreaterThanEqual">*</cc1:comparedomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCantidadIngreso" runat="server" CssClass="TextoBlanco">Cantidad Ingreso:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:numericbox id="txtCantidadIngreso" runat="server" CssClass="normaldetalle" MaxLength="4" Width="136px"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4" RealNumber="False"></ew:numericbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvCantidadIngreso" runat="server" ControlToValidate="txtCantidadIngreso">*</cc1:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCantidadEgreso" runat="server" CssClass="TextoBlanco">Cantidad Egreso:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="txtCantidadEgreso" runat="server" CssClass="normaldetalle" MaxLength="4" Width="136px"
																PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="4" RealNumber="False"></ew:numericbox></TD>
														<TD class="normal">
															<cc1:requireddomvalidator id="rfvCantidadEgreso" runat="server" ControlToValidate="txtCantidadEgreso">*</cc1:requireddomvalidator>
															<cc1:comparedomvalidator id="cvCantidadIngresoEgreso" runat="server" ControlToValidate="txtCantidadIngreso"
																Type="Integer" ControlToCompare="txtCantidadEgreso" Operator="GreaterThanEqual">*</cc1:comparedomvalidator></TD>
													</TR>
												</TABLE>
												<cc1:domvalidationsummary id="vSum" runat="server" CssClass="normal" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc1:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table4" width="180" border="0">
										<TR>
											<TD style="WIDTH: 89px" width="89">
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="101"><SPAN class="normal"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></SPAN></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</table>
			<P>&nbsp;</P>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
