<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DetalleProyectoConvenioSimaMgpADM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleProyectoConvenioSimaMgpADM" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3">
						<uc1:HeaderInicio id="HeaderInicio1" runat="server"></uc1:HeaderInicio></td>
				</tr>
				<tr>
					<td vAlign="top" width="15%" bgColor="#f6f6f6">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu><br>
						<P>&nbsp;</P>
					</td>
					<td bgColor="#2b1700"></td>
					<td vAlign="top" width="85%">
						<TABLE id="Tablen" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td width="9" style="WIDTH: 9px"></td>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colspan="2">
												<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Convenios</asp:label>
												<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Proyecto del Convenio</asp:label></TD>
										</TR>
										<TR align="center">
											<TD colspan="2" style="HEIGHT: 49px">
												<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="100%" Height="100%">Proyecto del Convenio...</asp:Label></TD>
										</TR>
										<TR>
											<TD align="right" style="WIDTH: 156px">
												<asp:Label id="lblNroProyecto" runat="server" CssClass="normal" Width="100%">Número de Proyecto:</asp:Label></TD>
											<TD>
												<ew:NumericBox id="NumericBox1" runat="server" CssClass="normal"></ew:NumericBox></TD>
										</TR>
										<TR>
											<TD align="right" style="WIDTH: 156px" valign="top">
												<asp:Label id="lblProyectoAdenda" runat="server" CssClass="normal" Width="100%">Proyecto Adenda:</asp:Label></TD>
											<TD>
												<asp:TextBox id="TextBox1" runat="server" CssClass="normal" Width="100%" TextMode="MultiLine"
													Height="80px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD align="right" style="WIDTH: 156px">
												<asp:Label id="lblMontoAsignado" runat="server" CssClass="normal" Width="100%">Monto Asignado S/.</asp:Label></TD>
											<TD>
												<ew:NumericBox id="NumericBox2" runat="server" CssClass="normal"></ew:NumericBox></TD>
										</TR>
										<TR>
											<TD align="right" style="WIDTH: 156px" valign="top">
												<asp:Label id="lblObservaciones" runat="server" CssClass="normal" Width="100%">Observaciones:</asp:Label></TD>
											<TD>
												<asp:TextBox id="TextBox2" runat="server" CssClass="normal" Width="100%" TextMode="MultiLine"
													Height="88px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD>
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD style="WIDTH: 202px"></TD>
														<TD style="WIDTH: 11px"></TD>
														<TD></TD>
													</TR>
													<TR align="center">
														<TD style="WIDTH: 202px">
															<asp:imagebutton id="ibtnAceptar" runat="server" CssClass="normal" AlternateText="Aceptar" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 11px"></TD>
														<TD>
															<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</TABLE>
					</td>
				</tr>
				<TR align="center">
					<TD bgColor="#5891ae" colSpan="3"><asp:label id="lblTexto" runat="server" CssClass="TextoFooter">© SIMA 2004</asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
