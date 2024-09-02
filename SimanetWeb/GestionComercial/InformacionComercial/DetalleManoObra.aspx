<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleManoObra.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleManoObra" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
						<table borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="550" align="center"
							border="0">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Mano de Obra</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label>
									<TABLE class="normal" id="Table3" borderColor="#ffffff" height="112" cellSpacing="0" cellPadding="0"
										width="550" align="center" border="1">
										<TR>
											<TD class="normal" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
										</TR>
										<TR>
											<TD class="normal" style="WIDTH: 153px; HEIGHT: 45px" bgColor="#335eb4" colSpan="1"><asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion :</asp:label></TD>
											<TD class="normal" style="WIDTH: 576px; HEIGHT: 45px" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="200" Width="555px"></asp:textbox></TD>
											<TD class="normal" style="HEIGHT: 45px" align="left" colSpan="1"><cc1:requireddomvalidator id="rfvDescripcion" runat="server" InitialValue="%" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" style="WIDTH: 153px" vAlign="middle" bgColor="#335eb4"><asp:label id="lblTipoManoObra" runat="server" CssClass="TextoBlanco" Width="96px" Height="24px">Tipo Mano Obra:</asp:label></TD>
											<TD class="normal" style="WIDTH: 576px" bgColor="#f0f0f0" colSpan="4"><asp:dropdownlist id="ddlbTipoManoObra" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
											<TD class="normal"><cc1:requireddomvalidator id="rfvTipoManoObra" runat="server" InitialValue="%" ControlToValidate="ddlbTipoManoObra">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD align="right" colSpan="5">
												<TABLE borderColor="#ffffff" cellSpacing="0" cellPadding="0" border="1">
													<TR>
														<TD align="center"><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
														<TD align="center"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD align="left" colSpan="5"><cc1:domvalidationsummary id="vSum" runat="server" Width="88px" Height="22px" ShowMessageBox="True" DisplayMode="List"
													EnableClientScript="False"></cc1:domvalidationsummary></TD>
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
