<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarVentasRealesDesagregadaMensual.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarVentasRealesDesagregadaMensual" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
							<TBODY>
								<TR>
									<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Ventas Colocadas Desagregada</asp:label></TD>
								</TR>
								<TR>
									<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal" style="Z-INDEX: 0"> CONSULTA DE VENTAS COLOCADAS TOTALES CORRESPONDIENTE AL MES DE</asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="200" bgColor="#f5f5f5"
											border="0">
											<TR bgColor="#ffffff">
												<TD class="TitFiltros"><IMG height="14" src="../../imagenes/TitFiltros.gif" width="82"></TD>
												<TD class="combos"></TD>
											</TR>
											<TR>
												<TD></TD>
												<TD class="SmallFont">
													<asp:label id="lblTipo" runat="server" CssClass="normal">Tipo</asp:label></TD>
											</TR>
											<TR>
												<TD class="TitFiltros">&nbsp;</TD>
												<TD class="combos">
													<asp:dropdownlist id="ddlbTipo" runat="server" CssClass="normal" Width="136px" AutoPostBack="True"></asp:dropdownlist></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="3">
													<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
														<TR>
															<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
															<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="680"></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
															<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
														</TR>
													</TABLE>
													<cc1:datagridweb id="dgConsultaMensual" runat="server" CssClass="HeaderGrilla" Width="780px" RowHighlightColor="#E0E0E0"
														AutoGenerateColumns="False" RowPositionEnabled="False">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="lineanegocio" HeaderText="LN">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="totalcallao" HeaderText="SIMAC">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="totalchimbote" HeaderText="SIMACH">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="totaliquitos" HeaderText="SIMAI">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="total" HeaderText="TOTAL">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="ppto" HeaderText="PPTO">
																<HeaderStyle Width="120px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="logro" HeaderText="% LOGRO">
																<HeaderStyle Width="60px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb>
													<asp:label id="lblResultadoMensual" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
					</TD>
				</TR>
				</TD></TR></TABLE>
			</TD></TR></TBODY></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
