<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetallePresentesOtorgadosPorTipoPersona.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetallePresentesOtorgadosPorTipoPersona" %>
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
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Presentes Otorgados</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><INPUT id="hIdCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdCodigo"
										runat="server"><INPUT id="hIdOrigen" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdOrigen"
										runat="server"><INPUT id="hIdTablaOrigen" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdTablaOrigen"
										runat="server"></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD align="center">
												<TABLE class="normal" id="Table7" cellSpacing="0" cellPadding="0" width="500" align="center"
													border="1" borderColor="#ffffff">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNombres" runat="server" CssClass="TextoBlanco">Nombres:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtEntidad" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="336px"
																MaxLength="80"></asp:textbox>
															<asp:ImageButton id="ibtnBuscarEntidad" runat="server" CausesValidation="False" ImageUrl="../../imagenes/BtPU_Mas.gif"
																CssClass="normaldetalle"></asp:ImageButton></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvNombres" runat="server" ControlToValidate="txtEntidad">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblCentroOperativo" runat="server" CssClass="TextoBlanco">Centro de Operaciones:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4" id="CellddlbCentroOperativo" runat="server">
															<asp:DropDownList id="ddlbCentroOperativo" runat="server" CssClass="normaldetalle" Width="136px" Height="5px"></asp:DropDownList></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvCentroOperativo" runat="server" ControlToValidate="ddlbCentroOperativo">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblTipoDocumento" runat="server" CssClass="TextoBlanco">Tipo Documento:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4" id="CellddlbTipoDocumento" runat="server">
															<asp:DropDownList id="ddlbTipoDocumento" runat="server" CssClass="normaldetalle" Width="136px" Height="5px"></asp:DropDownList></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblDirectiva" runat="server" CssClass="TextoBlanco">Nro Directiva:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:textbox id="txtDirectiva" runat="server" CssClass="normaldetalle" MaxLength="20" Width="136px"></asp:textbox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblPresente" runat="server" CssClass="TextoBlanco">Presente:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4" id="CellddlbPresente" runat="server">
															<asp:DropDownList id="ddlbPresente" runat="server" CssClass="normaldetalle" Width="136px"></asp:DropDownList></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvPresente" runat="server" ControlToValidate="ddlbPresente">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblCantidad" runat="server" CssClass="TextoBlanco">Cantidad Entregada:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<ew:NumericBox id="nbCantidad" runat="server" CssClass="normaldetalle" MaxLength="4" Width="136px"
																RealNumber="False"></ew:NumericBox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvCantidad" runat="server" ControlToValidate="nbCantidad">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Detalle del Presente:</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:TextBox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																TextMode="MultiLine" Height="56px"></asp:TextBox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:Label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:TextBox id="txtObservaciones" runat="server" CssClass="normaldetalle" MaxLength="2000" Width="336px"
																TextMode="MultiLine" Height="56px"></asp:TextBox></TD>
														<TD class="normal"></TD>
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
												<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
													Height="22px"></asp:imagebutton></TD>
											<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
													runat="server"></TD>
											<TD id="TdCeldaCancelar" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
