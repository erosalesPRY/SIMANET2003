<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleFotos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleFotos" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" width="100%" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Fotos</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD vAlign="top" align="center">
												<TABLE class="normal" id="Table7" cellSpacing="0" cellPadding="0" width="470" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblCodigoCaja" runat="server" CssClass="TextoBlanco">Codigo de Caja:</asp:label>
														</TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtCodigoCaja" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="80"></asp:textbox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvCodigoCaja" runat="server" ControlToValidate="txtCodigoCaja">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblRutaFisica" runat="server" CssClass="TextoBlanco" Width="94px">Ruta Fisica:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtRutaFisica" runat="server" CssClass="normaldetalle" MaxLength="200" Width="336px"></asp:textbox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvRutaFisica" runat="server" ControlToValidate="txtRutaFisica">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4" style="HEIGHT: 9px">
															<P align="left">
																<asp:Label id="lblFormato" runat="server" CssClass="TextoBlanco"> Formato:</asp:Label></P>
														</TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4" id="CellddlbFormato" runat="server">
															<asp:DropDownList id="ddlbFormato" runat="server" CssClass="normaldetalle" Width="136px"></asp:DropDownList></TD>
														<TD class="normal" style="HEIGHT: 29px">
															<cc2:RequiredDomValidator id="rfvFormato" runat="server" ControlToValidate="ddlbFormato">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblCantidadDeFotos" runat="server" CssClass="TextoBlanco"> Cantidad de Fotos:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="nbCantidadFotos" runat="server" CssClass="normaldetalle" MaxLength="8" Width="136px"
																RealNumber="False" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="8"></ew:numericbox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvCantidadFotos" runat="server" ControlToValidate="nbCantidadFotos">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblDigitalizado" runat="server" CssClass="TextoBlanco"> Digitalizado?:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:CheckBox id="chkDigitalizado" runat="server" CssClass="normaldetalle"></asp:CheckBox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblAvance" runat="server" CssClass="TextoBlanco"> Avance (%):</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:numericbox id="nbAvance" runat="server" CssClass="normaldetalle" MaxLength="3" Width="136px"
																RealNumber="False" PositiveNumber="True" DecimalPlaces="2" PlacesBeforeDecimal="3"></ew:numericbox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvAvance" runat="server" ControlToValidate="nbAvance">*</cc2:RequiredDomValidator>
															<cc2:RangeDomValidator id="rvAvance" runat="server" ControlToValidate="nbAvance" MinimumValue="0" MaximumValue="100">*</cc2:RangeDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																Height="54px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																Height="54px" TextMode="MultiLine"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" colSpan="6" id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table8" width="180" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
