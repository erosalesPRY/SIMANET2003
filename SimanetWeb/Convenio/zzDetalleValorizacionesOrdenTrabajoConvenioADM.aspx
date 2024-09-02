<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleValorizacionesOrdenTrabajoConvenioADM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.DetalleValorizacionesOrdenTrabajoConvenioADM" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
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
								<td width="11" style="WIDTH: 11px"></td>
								<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR align="center">
											<TD colspan="2">
												<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipal" Width="100%">Convenio SIMA - MGP...</asp:Label>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px">
												<asp:Label id="lblProyecto" runat="server" CssClass="normal" Width="100%">Proyecto:</asp:Label></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD colspan="2">
												<asp:TextBox id="txtProyecto" runat="server" CssClass="normal" Width="100%" TextMode="MultiLine"
													Height="56px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD align="right" style="WIDTH: 197px">
												<asp:Label id="lblNroValorizacion" runat="server" CssClass="normal" Width="100%">Número de Valorización:</asp:Label></TD>
											<TD>
												<asp:TextBox id="txtNroValorizacion" runat="server" CssClass="normal"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD align="right" style="WIDTH: 197px">
												<asp:Label id="lblPorcAvanceFisico" runat="server" CssClass="normal">Porcentaje de Avance Físico:</asp:Label></TD>
											<TD>
												<ew:NumericBox id="nbPorcAvanceFisico" runat="server" Width="131px"></ew:NumericBox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 197px; HEIGHT: 47px"></TD>
											<TD style="HEIGHT: 47px">
												<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD style="WIDTH: 131px"></TD>
														<TD style="WIDTH: 15px"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD style="WIDTH: 131px">
															<asp:imagebutton id="ibtnAceptar" runat="server" CssClass="normal" AlternateText="Aceptar" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 15px"></TD>
														<TD>
															<asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" CausesValidation="False"></asp:imagebutton>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
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
