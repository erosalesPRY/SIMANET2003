<%@ Page language="c#" Codebehind="DetalleAdministrarOrganismoAccionSubAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.DetalleAdministrarOrganismoAccionSubAccion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleAdministrarOrganismoAccionSubAccion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional > Detalle Administracion</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE class="normal" id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0"
							width="400" align="center" border="1">
							<TR>
								<TD class="TituloPrincipalBlanco" align="left" width="475" bgColor="#000080" colSpan="5"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="14px">Detalle</asp:label></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 2px" bgColor="#335eb4"><asp:label id="Label2" runat="server" CssClass="TextoBlanco"> ORGANISMO:</asp:label></TD>
								<TD class="normal" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtOrganismo" runat="server" CssClass="normaldetalle" MaxLength="500" Width="308px"></asp:textbox></TD>
								<TD class="normal" style="HEIGHT: 15px" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 2px" bgColor="#335eb4">
									<asp:label id="Label1" runat="server" CssClass="TextoBlanco">descripcion:</asp:label></TD>
								<TD class="normal" style="HEIGHT: 15px" bgColor="#f0f0f0" colSpan="4">
									<asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" MaxLength="500" Width="308px"
										TextMode="MultiLine"></asp:textbox></TD>
								<TD class="normal" style="HEIGHT: 15px" colSpan="2"></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 2px" colSpan="7"></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 2px" colSpan="7">
									<DIV align="center">
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
											<TR>
												<TD>
													<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
												</TD>
												<TD><IMG id="ibtnCancelar" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"></TD>
											</TR>
										</TABLE>
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
