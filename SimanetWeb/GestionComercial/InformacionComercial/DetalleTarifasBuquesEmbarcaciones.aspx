<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleTarifasBuquesEmbarcaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleTarifasBuquesEmbarcaciones" %>
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
					<TD colSpan="3" align="center">
						<table cellSpacing="0" cellPadding="0" width="780" align="center" border="0" borderColor="#ffffff">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Tarifas de Buques y Embarcaciones</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<TR>
											<TD></TD>
											<TD align="center">
												<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD align="center">
												<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 174px; HEIGHT: 28px" vAlign="middle" bgColor="#335eb4">
															<asp:label id="lblClasificacionEmbarcacion" runat="server" CssClass="TextoBlanco" Width="168px">Clasificacion Embarcacion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 171px; HEIGHT: 28px" bgColor="#dddddd" colSpan="4" id=CellddlbClasificacionEmbarcacion runat="server">
															<asp:dropdownlist id="ddlbClasificacionEmbarcacion" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 28px">
															<cc1:RequiredDomValidator id="rfvClasificacionEmbarcacion" runat="server" InitialValue="%" ControlToValidate="ddlbClasificacionEmbarcacion">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4" style="WIDTH: 174px">
															<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco"> Descripcion:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="376px" MaxLength="2000"
																TextMode="MultiLine" Height="32px"></asp:textbox></TD>
														<TD class="normal">
															<cc1:RequiredDomValidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4" style="WIDTH: 174px">
															<asp:label id="lblDetalle" runat="server" CssClass="TextoBlanco"> Detalle :</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtDetalle" runat="server" CssClass="normaldetalle" Width="376px" MaxLength="2000"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal">
															<cc1:RequiredDomValidator id="rfvDetalle" runat="server" ControlToValidate="txtDetalle">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" style="WIDTH: 174px; HEIGHT: 33px" vAlign="middle" bgColor="#335eb4">
															<asp:label id="lblCosto" runat="server" CssClass="TextoBlanco">Costo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 171px; HEIGHT: 33px" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtCosto" runat="server" CssClass="normaldetalle" Width="136px" MaxLength="20"></asp:textbox></TD>
														<TD style="HEIGHT: 33px">
															<cc1:RequiredDomValidator id="rfvCosto" runat="server" ControlToValidate="txtCosto">*</cc1:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" bgColor="#335eb4" style="WIDTH: 174px; HEIGHT: 16px">
															<asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" style="WIDTH: 171px; HEIGHT: 16px" bgColor="#dddddd" colSpan="4" id=CellddlbMoneda runat="server">
															<asp:dropdownlist id="ddlbMoneda" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD style="HEIGHT: 16px">
															<cc1:RequiredDomValidator id="rfvMoneda" runat="server" InitialValue="%" ControlToValidate="ddlbMoneda">*</cc1:RequiredDomValidator></TD>
													</TR>
                    <TR>
                      <TD class=normal id=CellibtnAtras vAlign=middle align=left 
                      colSpan=5 runat="server">
                        <TABLE id=Table1 cellSpacing=0 cellPadding=0 border=0>
                          <TR>
                            <TD></TD></TR></TABLE><IMG id=ibtnAtras 
                        style="CURSOR: hand" onclick=HistorialIrAtras(); alt="" 
                        src="../../imagenes/atras.gif"></TD></TR>
													<TR>
														<TD class="normal" vAlign="middle" align="right" colSpan="5">
															<TABLE borderColor="#ffffff" cellSpacing="0" cellPadding="0" border="1">
																<TR>
																	<TD>
																		<asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
																	<TD id=CellibtnCancelar runat="server"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="middle" align="left" colSpan="5">
															<cc1:domvalidationsummary id="vSum" runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List"
																ShowMessageBox="True"></cc1:domvalidationsummary></TD>
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
