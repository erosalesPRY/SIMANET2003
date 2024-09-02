<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetallePresentesOtorgadosFamiliares.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.DetallePresentesOtorgadosFamiliares" %>
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
								<TD class="Commands" style="HEIGHT: 11px" width="100%" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Comunicación e Imagen > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registro de Presentes Otorgados a Familiares</asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="280" align="center" border="0">
										<TR>
											<TD style="HEIGHT: 108px"></TD>
											<TD vAlign="top" align="center">
												<TABLE class="normal" id="Table7" cellSpacing="1" cellPadding="1" width="260" align="center"
													border="0">
													<TR>
														<TD class="normal" align="left" bgColor="#000080" colSpan="5">
															<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
														<TD class="normal" align="left"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblNombres" runat="server" CssClass="TextoBlanco">Nombres:</asp:label>
														</TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:textbox id="txtNombres" runat="server" CssClass="normal" Width="136px" MaxLength="80"></asp:textbox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvNombres" runat="server" ControlToValidate="txtNombres">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblApellidoPaterno" runat="server" CssClass="TextoBlanco" Width="94px">Apellido Paterno:</asp:label></TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4">
															<asp:TextBox id="txtApellidoPaterno" runat="server" CssClass="normal" MaxLength="80" Width="136px"></asp:TextBox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvApellidoPaterno" runat="server" ControlToValidate="txtApellidoPaterno">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:label id="lblApellidoMaterno" runat="server" CssClass="TextoBlanco" Width="97px">Apellido Materno:</asp:label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<asp:TextBox id="txtApellidoMaterno" runat="server" CssClass="normal" MaxLength="80" Width="136px"></asp:TextBox></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<P align="left">
																<asp:Label id="lblPresente" runat="server" CssClass="TextoBlanco">Presente</asp:Label></P>
														</TD>
														<TD class="normal" bgColor="#f0f0f0" colSpan="4" id="CellddlbPresente" runat="server">
															<asp:DropDownList id="ddlbPresente" runat="server" CssClass="normal" Width="136px"></asp:DropDownList></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvPresente" runat="server" ControlToValidate="ddlbPresente">*</cc2:RequiredDomValidator></TD>
													</TR>
													<TR>
														<TD class="normal" vAlign="top" bgColor="#335eb4">
															<asp:Label id="lblCantidad" runat="server" CssClass="TextoBlanco"> Cantidad</asp:Label></TD>
														<TD class="normal" bgColor="#dddddd" colSpan="4">
															<ew:NumericBox id="nbCantidad" runat="server" CssClass="normal" MaxLength="22" Width="136px"></ew:NumericBox></TD>
														<TD class="normal">
															<cc2:RequiredDomValidator id="rfvCantidad" runat="server" ControlToValidate="nbCantidad">*</cc2:RequiredDomValidator></TD>
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
