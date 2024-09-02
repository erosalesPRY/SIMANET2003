<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleObservacionesControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleObservacionesControl" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD>
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" align="center" border="0" width="100%">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Observaciones de Control</asp:label></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
								<TD align="center"><SPAN class="normal"></SPAN>
									<TABLE class="normal" id="Table3" cellSpacing="0" cellPadding="0" align="center" border="1"
										width="548" borderColor="#ffffff">
										<TR>
											<TD class="TituloPrincipalBlanco" colSpan="8" align="left" vAlign="top" bgColor="#000080"
												rowSpan="1"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label><asp:label id="lblDatos" runat="server"></asp:label></TD>
											<TD class="TituloPrincipalBlanco" style="HEIGHT: 14px" vAlign="top" align="left"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label2" runat="server" CssClass="TextoBlanco">Responsable:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4">
												<asp:textbox id="txtPersonal" runat="server" CssClass="normaldetalle" Width="460px" ReadOnly="True"></asp:textbox>
												<asp:image id="ibtnBuscarPersonal" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:image></TD>
											<TD class="normal">
												<cc1:requireddomvalidator id="rfvResponsable" runat="server" ControlToValidate="txtPersonal">*</cc1:requireddomvalidator></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label3" runat="server" CssClass="TextoBlanco">Situación:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4">
												<asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Height="70px" Width="248px"></asp:dropdownlist></TD>
											<TD class="normal"></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Descripción:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4">
												<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" TextMode="MultiLine"
													Height="50px" MaxLength="500" Width="480px"></asp:textbox></TD>
											<TD class="normal">
												<cc1:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">
												<asp:label id="lblConcepto" runat="server" CssClass="TextoBlanco" Width="83px"> Observación:</asp:label></TD>
											<TD class="normal" bgColor="#f0f0f0" colSpan="4" rowSpan="1">
												<asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" TextMode="MultiLine"
													Height="100px" MaxLength="8000" Width="478px"></asp:textbox></TD>
											<TD class="normal">
												<cc1:requireddomvalidator id="rfvObservacion" runat="server" ControlToValidate="txtObservacion">*</cc1:requireddomvalidator></TD>
											<TD class="normal" bgColor="#f0f0f0"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4">f
												<asp:label id="Label4" runat="server" CssClass="TextoBlanco">Acción:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4">
												<asp:textbox id="txtAccion" runat="server" CssClass="normaldetalle" TextMode="MultiLine" Height="50px"
													MaxLength="500" Width="480px"></asp:textbox></TD>
											<TD class="normal"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" width="583" align="center" border="0">
										<TR>
											<TD align="center"><INPUT id="hIdPersonal" style="WIDTH: 9px; HEIGHT: 22px" type="hidden" size="1" name="hIdPersonal"
													runat="server">&nbsp;
												<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;&nbsp;&nbsp;
												<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"
													style="CURSOR: hand"> <SPAN class="normal"></SPAN>
											</TD>
										</TR>
									</TABLE>
									<SPAN class="normal"></SPAN>
								</TD>
							</TR>
						</TABLE>
						<cc1:DomValidationSummary id="vSum" runat="server" Width="88px" Height="22px" ShowMessageBox="True" EnableClientScript="False"
							DisplayMode="List"></cc1:DomValidationSummary></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
