<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleVentasReales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.DetalleVentasReales" %>
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
					<TD colSpan="3">
						<P><uc1:menu id="Menu1" runat="server"></uc1:menu></P>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Ventas Colocadas</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hIdProyecto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdProyecto"
										runat="server"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center">
												<TABLE class="normal" id="Table7" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
													align="center" border="1">
													<TR>
														<TD class="normal" align="center" colSpan="6"><asp:label id="lblMensaje" runat="server" CssClass="normal" DESIGNTIMEDRAGDROP="162"></asp:label></TD>
													</TR>
													<TR>
														<TD class="normal" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblProyecto" runat="server" CssClass="TextoBlanco">Proyecto:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtProyecto" runat="server" CssClass="normaldetalle" Width="336px" ReadOnly="True"></asp:textbox><asp:imagebutton id="ibtnBuscarProyecto" runat="server" CssClass="normaldetalle" CausesValidation="False"
																ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
														<TD class="normal"><cc2:requireddomvalidator id="rfvProyecto" runat="server" ControlToValidate="txtProyecto">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblCliente" runat="server" CssClass="TextoBlanco"> Cliente:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtCliente" runat="server" CssClass="normaldetalle" Width="336px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblSector" runat="server" CssClass="TextoBlanco">Sector:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtSector" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">Centro de Operaciones:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblLineaNegocio" runat="server" CssClass="TextoBlanco">Linea Negocio:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtLineaNegocio" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblMonto" runat="server" CssClass="TextoBlanco">Monto:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtMonto" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblMoneda" runat="server" CssClass="TextoBlanco">Moneda:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblMontoSoles" runat="server" CssClass="TextoBlanco">Monto en Soles:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtMontoSoles" runat="server" CssClass="normaldetalle" Width="136px" ReadOnly="True"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" align="center" colSpan="5">
															<asp:RadioButtonList id="rblPromotor" runat="server" CssClass="normaldetalle" Width="336px" RepeatDirection="Horizontal"
																AutoPostBack="True">
																<asp:ListItem Value="0">Venta sin Promotor</asp:ListItem>
																<asp:ListItem Value="1" Selected="True">Venta con Promotor</asp:ListItem>
															</asp:RadioButtonList></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="336px" Height="56px"
																TextMode="MultiLine" MaxLength="2000"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4"><asp:label id="lblPromotor" runat="server" CssClass="TextoBlanco">Promotor:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtPromotor" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="336px"></asp:textbox>
															<asp:imagebutton id="ibtnBuscarPromotor" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblEmpresaDestino" runat="server" CssClass="TextoBlanco" Visible="False">Empresa Destino:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtEmpresaDestino" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="336px"
																Visible="False"></asp:textbox>
															<asp:imagebutton id="ibtnBuscarEmpresaDestino" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CausesValidation="False" Visible="False"></asp:imagebutton></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" id="TdCeldaCancelar" vAlign="top" colSpan="5" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
														<TD class="normal"></TD>
													</TR>
												</TABLE>
												<cc2:domvalidationsummary id="vSum" runat="server" Width="100px" EnableClientScript="False" DisplayMode="List"
													ShowMessageBox="True"></cc2:domvalidationsummary></TD>
											<TD style="HEIGHT: 108px" vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="180" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
													Height="22px"></asp:imagebutton>
											</TD>
											<TD id="CellibtnCancelar" runat="server"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif">&nbsp;
											</TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
					</TD>
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
