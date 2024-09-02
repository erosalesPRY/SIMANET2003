<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarVentaMensualUnisys.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarVentaMensualUnisys" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
							<TR>
								<TD style="HEIGHT: 12px" class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" Width="424px" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas > Mensual (OTS Generadas Sistema Unisys)</asp:label></TD>
							</TR>
							<TR>
								<TD class="TituloPrincipal" colSpan="3" align="center"><asp:label id="lblTitulo" runat="server" Width="941px" CssClass="TituloPrincipal">REPORTE DE VENTAS COLOCADAS X MES (OTS GENERADAS SISTEMA UNISYS)</asp:label><asp:label style="Z-INDEX: 0" id="CENTROOPERATIVO" runat="server" CssClass="Titulosecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 17px" align="center"><asp:label id="lblAno" runat="server" CssClass="Titulosecundario"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table4" class="normal" border="0" cellSpacing="0" cellPadding="0" width="550">
										<TR>
											<TD style="HEIGHT: 200px" colSpan="3" align="left">
												<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="780">
													<TR>
														<TD bgColor="#f0f0f0"><IMG src="../../imagenes/tab_izq.gif" width="4" height="22"></TD>
														<TD bgColor="#f0f0f0" align="right"><IMG style="WIDTH: 837px; HEIGHT: 9px" src="../../imagenes/spacer.gif" width="837" height="9"></TD>
														<TD bgColor="#f0f0f0">
															<P align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></P>
														</TD>
														<TD bgColor="#f0f0f0"><IMG src="../../imagenes/tab_der.gif" width="4" height="22"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="dgConsulta" runat="server" Width="780px" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0"
													RowPositionEnabled="False" DESIGNTIMEDRAGDROP="68" AllowPaging="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn DataField="ORDEN" HeaderText="ORDEN"></asp:BoundColumn>
														<asp:BoundColumn DataField="TIPO" HeaderText="TIPO CLIENTE" FooterText="TOTAL" DataFormatString="TIPO">
															<HeaderStyle Width="50px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ENERO" HeaderText="Enero" DataFormatString="ENERO"></asp:BoundColumn>
														<asp:BoundColumn DataField="FEBRERO" HeaderText="Febrero" DataFormatString="FEBRERO"></asp:BoundColumn>
														<asp:BoundColumn DataField="MARZO" HeaderText="Marzo" DataFormatString="MARZO"></asp:BoundColumn>
														<asp:BoundColumn DataField="ABRIL" HeaderText="Abril" DataFormatString="ABRIL"></asp:BoundColumn>
														<asp:BoundColumn DataField="MAYO" HeaderText="Mayo" DataFormatString="MAYO"></asp:BoundColumn>
														<asp:BoundColumn DataField="JUNIO" HeaderText="Junio" DataFormatString="JUNIO"></asp:BoundColumn>
														<asp:BoundColumn DataField="JULIO" HeaderText="Julio" DataFormatString="JULIO"></asp:BoundColumn>
														<asp:BoundColumn DataField="AGOSTO" HeaderText="Agosto" DataFormatString="AGOSTO"></asp:BoundColumn>
														<asp:BoundColumn DataField="SETIEMBRE" HeaderText="Setiembre" DataFormatString="SETIEMBRE"></asp:BoundColumn>
														<asp:BoundColumn DataField="OCTUBRE" HeaderText="Octubre" DataFormatString="OCTUBRE"></asp:BoundColumn>
														<asp:BoundColumn DataField="NOVIEMBRE" HeaderText="Noviembre" DataFormatString="NOVIEMBRE"></asp:BoundColumn>
														<asp:BoundColumn DataField="DICIEMBRE" HeaderText="Diciembre" DataFormatString="DICIEMBRE"></asp:BoundColumn>
														<asp:BoundColumn DataField="TOTAL" HeaderText="TOTAL" DataFormatString="TOTAL"></asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb><IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><IMG style="WIDTH: 160px; HEIGHT: 24px" src="../../imagenes/spacer.gif" width="160" height="24"></TD>
							</TR>
						</TABLE>
						<IMG src="../imagenes/spacer.gif" width="592" height="5"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
