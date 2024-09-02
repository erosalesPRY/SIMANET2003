<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleMaterial.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleMaterial" %>
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
					<td colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="550" align="center" border="1" borderColor="#ffffff">
							<TR>
								<TD class="Commands" style="HEIGHT: 19px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Materiales</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="3">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="550" align="center" border="1"
										borderColor="#ffffff">
										<TR>
											<TD class="normal" bgColor="#000080" colSpan="5">
												<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label>
												<asp:label id="lblDatos" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
										</TR>
										<TR>
											<TD class="normal" style="WIDTH: 153px" bgColor="#335eb4" colSpan="1">
												<asp:label id="lblDescripcion" runat="server" CssClass="TextoBlanco">Descripcion :</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4">
												<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="200" Width="400px"></asp:textbox></TD>
											<TD class="normal" align="center" colSpan="1">
												<cc1:requireddomvalidator id="rfvDescripcion" runat="server" InitialValue="%" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" style="WIDTH: 153px" vAlign="middle" bgColor="#335eb4">
												<asp:label id="lblTipoMaterial" runat="server" CssClass="TextoBlanco">Tipo Material:</asp:label></TD>
											<TD class="normal" style="WIDTH: 162px" bgColor="#f0f0f0" colSpan="4">
												<asp:dropdownlist id="ddlbTipoMaterial" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
											<TD class="normal">
												<cc1:requireddomvalidator id="rfvTipoMaterial" runat="server" InitialValue="%" ControlToValidate="ddlbTipoMaterial">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" style="WIDTH: 153px; HEIGHT: 15px" vAlign="middle" bgColor="#335eb4">
												<asp:label id="lblUnidaddeMedida" runat="server" CssClass="TextoBlanco">Unidad de Medida:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4" style="HEIGHT: 15px">
												<asp:dropdownlist id="ddlbUnidadMedida" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
											<TD class="normal" style="HEIGHT: 15px">
												<cc1:requireddomvalidator id="rfvUnidadMedida" runat="server" InitialValue="%" ControlToValidate="ddlbUnidadMedida">*</cc1:requireddomvalidator></TD>
										</TR>
										<TR>
											<TD class="normal" vAlign="middle" align="right" colSpan="5">
												<TABLE borderColor="#ffffff" cellSpacing="0" cellPadding="0" border="1">
													<TR>
														<TD align="right">
															<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif" Height="22px"></asp:imagebutton></TD>
														<TD align="right"><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="right">
									<cc1:domvalidationsummary id="vSum" runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List"
										ShowMessageBox="True"></cc1:domvalidationsummary>
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
