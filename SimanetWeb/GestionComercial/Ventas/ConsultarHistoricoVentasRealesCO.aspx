<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarHistoricoVentasRealesCO.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarHistoricoVentasRealesCO" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta del Historico de Ventas Ejecutadas por Centro Operativo</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">CONSULTA DEL HISTORICO DE VENTAS EJECUTADAS POR CENTRO DE OPERACIONES Y LINEA DE NEGOCIO</asp:label></TD>
							</TR>
							<TR>
								<TD align="right"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center">&nbsp;</TD>
											<TD align="center">&nbsp;</TD>
											<TD align="center">&nbsp;</TD>
										</TR>
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="615">&nbsp;&nbsp;</TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton>
															<asp:image id="imgExposicion" runat="server" Height="25px" ImageUrl="../../imagenes/ley1.gif"
																ToolTip="Presentacion"></asp:image>
															<asp:imagebutton id="ibtnGraficoBarraPorCOyLN" runat="server" ImageUrl="../../imagenes/bar.jpg" ToolTip="Historico de Ventas Ejecutadas de Sima-Peru"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<div style="WIDTH: 780px; HEIGHT: 99px; OVERFLOW: auto" align="center"><cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" ShowFooter="True" RowHighlightColor="#E0E0E0"
														RowPositionEnabled="False" DESIGNTIMEDRAGDROP="68">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb></div>
												<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160">
											</TD>
										</TR>
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<DIV style="Z-INDEX: 0; WIDTH: 780px; HEIGHT: 245px; OVERFLOW: auto" align="center"><cc1:datagridweb id="dgConsultaLN" runat="server" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0"
														RowPositionEnabled="False" DESIGNTIMEDRAGDROP="68">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb></DIV>
											</TD>
										</TR>
										<TR>
											<TD align="center" width="100%" colSpan="3"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD align="left" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
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
		</TD></TR>
	</body>
</HTML>
