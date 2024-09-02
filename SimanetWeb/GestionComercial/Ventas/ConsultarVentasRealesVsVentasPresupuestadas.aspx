<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultarVentasRealesVsVentasPresupuestadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarVentasRealesVsVentasPresupuestadas" %>
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
					<TD colSpan="3">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TBODY>
								<TR>
									<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
										<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label>
										<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Ventas Ejecutadas vs Ventas Presupuestadas</asp:label></TD>
								</TR>
								<TR>
									<TD class="TituloPrincipal" colSpan="3" align="center">
										<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE VENTAS REALES VS VENTAS PRESUPUESTADAS (En Miles)</asp:label></TD>
								</TR>
								<TR>
									<TD align="right"></TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:label id="lblCallao" runat="server" CssClass="Titulosecundario">SIMA-CALLAO</asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="3">
													<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
														<TR>
															<TD bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
															<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="670"></TD>
															<TD bgColor="#f0f0f0"></TD>
															<TD bgColor="#f0f0f0">
																<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
															<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
														</TR>
													</TABLE>
													<cc1:datagridweb id="dgConsultaLogroCallao" runat="server" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
														RowPositionEnabled="False" DESIGNTIMEDRAGDROP="68" Width="780px" CssClass="HeaderGrilla">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="titulo" HeaderText="LOGRO">
																<HeaderStyle Width="100px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="enero" HeaderText="ENE">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="febrero" HeaderText="FEB">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="marzo" HeaderText="MAR">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="abril" HeaderText="ABR">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="mayo" HeaderText="MAY">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="junio" HeaderText="JUN">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="julio" HeaderText="JUL">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="agosto" HeaderText="AGO">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="setiembre" HeaderText="SET">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="octubre" HeaderText="OCT">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="noviembre" HeaderText="NOV">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="diciembre" HeaderText="DIC">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="total" HeaderText="TOTAL">
																<HeaderStyle Width="80px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb>
													<asp:label id="lblResultadoCallao" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center">
										<asp:label id="lblChimbote" runat="server" CssClass="Titulosecundario"> SIMA-CHIMBOTE</asp:label>
									</TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="normal" id="Table6" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD align="center" width="100%" colSpan="3">
													<cc1:datagridweb id="dgConsultaLogroChimbote" runat="server" CssClass="HeaderGrilla" Width="780px"
														DESIGNTIMEDRAGDROP="68" RowPositionEnabled="False" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="titulo" HeaderText="LOGRO">
																<HeaderStyle Width="100px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="enero" HeaderText="ENE">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="febrero" HeaderText="FEB">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="marzo" HeaderText="MAR">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="abril" HeaderText="ABR">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="mayo" HeaderText="MAY">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="junio" HeaderText="JUN">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="julio" HeaderText="JUL">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="agosto" HeaderText="AGO">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="setiembre" HeaderText="SET">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="octubre" HeaderText="OCT">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="noviembre" HeaderText="NOV">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="diciembre" HeaderText="DIC">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:BoundColumn DataField="total" HeaderText="TOTAL">
																<HeaderStyle Width="80px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb>
													<asp:label id="lblResultadoChimbote" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblIquitos" runat="server" CssClass="Titulosecundario"> SIMA-IQUITOS S.R.L TDA.</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<cc1:datagridweb id="dgConsultaLogroIquitos" runat="server" CssClass="HeaderGrilla" Width="780px"
										DESIGNTIMEDRAGDROP="68" RowPositionEnabled="False" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="titulo" HeaderText="LOGRO">
												<HeaderStyle Width="100px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="enero" HeaderText="ENE">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="febrero" HeaderText="FEB">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="marzo" HeaderText="MAR">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="abril" HeaderText="ABR">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="mayo" HeaderText="MAY">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="junio" HeaderText="JUN">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="julio" HeaderText="JUL">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="agosto" HeaderText="AGO">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="setiembre" HeaderText="SET">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="octubre" HeaderText="OCT">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="noviembre" HeaderText="NOV">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="diciembre" HeaderText="DIC">
												<HeaderStyle Width="50px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="total" HeaderText="TOTAL">
												<HeaderStyle Width="80px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultadoIquitos" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										style="CURSOR: hand"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				</TD></TR>
			</TABLE>
			</TD></TR></TBODY></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
