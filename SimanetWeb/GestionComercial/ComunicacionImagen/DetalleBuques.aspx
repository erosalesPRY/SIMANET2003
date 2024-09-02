<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleBuques.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetalleBuques" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
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
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Buques</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hIdGrado" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdGrado"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="500" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD vAlign="top" align="center">
												<TABLE class="normal" id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													width="470" align="center" border="1">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco">Nombre:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" MaxLength="200" Width="336px"></asp:textbox></TD>
														<TD class="normal"><cc2:requireddomvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombre">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblEnTrabajos" runat="server" CssClass="TextoBlanco" Width="94px">En Trabajos?:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:checkbox id="chkEnTrabajos" runat="server" CssClass="normaldetalle"></asp:checkbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblPosicionBuque" runat="server" CssClass="TextoBlanco" Width="97px">Posicion Buque:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtPosicionBuque" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" style="HEIGHT: 9px" vAlign="top" bgColor="#335eb4">
															<P align="left"><asp:label id="lblTrabajoActual" runat="server" CssClass="TextoBlanco">Trabajo Actual:</asp:label></P>
														</TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4" id="CellddlbTrabajoActual" runat="server"><asp:dropdownlist id="ddlbTrabajoActual" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 29px"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblOficialAlMando" runat="server" CssClass="TextoBlanco"> Oficial al Mando:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtOficialAlMando" runat="server" CssClass="normaldetalle" MaxLength="200" Width="336px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblGradoOficial" runat="server" CssClass="TextoBlanco">Grado Oficial:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtGradoOficial" runat="server" CssClass="normaldetalle" MaxLength="80" Width="336px"
																ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarGrado" runat="server" CssClass="normaldetalle" CausesValidation="False"
																ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4" style="HEIGHT: 36px"><asp:label id="lblLineaNegocio" runat="server" CssClass="TextoBlanco">Linea de Negocio:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4" style="HEIGHT: 36px" id="CellddlbLineaNegocio"
															runat="server"><asp:dropdownlist id="ddlbLineaNegocio" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
														<TD class="normal" style="HEIGHT: 36px"><cc2:requireddomvalidator id="rfvLineaNegocio" runat="server" ControlToValidate="ddlbLineaNegocio">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																TextMode="MultiLine" Height="54px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" id="TdCeldaCancelar" align="left" colSpan="6" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" ShowMessageBox="True" DisplayMode="List" EnableClientScript="False"></cc2:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table8" width="180" border="0">
										<TR>
											<TD><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													runat="server"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
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
