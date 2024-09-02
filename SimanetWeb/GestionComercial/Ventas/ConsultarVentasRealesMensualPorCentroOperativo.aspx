<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarVentasRealesMensualPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarVentasRealesMensualPorCentroOperativo" %>
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
									<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Ventas Ejecutadas</asp:label></TD>
								</TR>
								<TR>
									<TD class="TituloPrincipal" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> CONSULTA DE VENTAS EJECUTADAS (En Miles)</asp:label><asp:label id="lblCentroOperativo" runat="server" CssClass="Titulosecundario"></asp:label></TD>
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
															<TD bgColor="#398094"></TD>
															<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
															<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
														</TR>
													</TABLE>
													<cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0"
														AutoGenerateColumns="False" RowPositionEnabled="False" Width="780px">
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
														<Columns>
															<asp:BoundColumn DataField="lineanegocio" HeaderText="LN">
																<HeaderStyle HorizontalAlign="Center" Width="90px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Enero">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbEnero" runat="server">ENE</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesEnero" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Febrero">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbFebrero" runat="server">FEB</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesFebrero" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Marzo">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbMarzo" runat="server">MAR</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesMarzo" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Abril">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbAbril" runat="server">ABR</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesAbril" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Mayo">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbMayo" runat="server">MAY</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesMayo" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Junio">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbJunio" runat="server">JUN</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesJunio" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Julio">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbJulio" runat="server">JUL</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesJulio" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Agosto">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbAgosto" runat="server">AGO</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesAgosto" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Setiembre">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbSetiembre" runat="server">SET</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesSetiembre" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Octubre">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbOctubre" runat="server">OCT</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesOctubre" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Noviembre">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbNoviembre" runat="server">NOV</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesNoviembre" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="Diciembre">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbDiciembre" runat="server">DIC</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblVentasRealesDiciembre" runat="server" CssClass="normal" ForeColor="Navy">Ventas</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:BoundColumn DataField="total" HeaderText="TOTAL">
																<HeaderStyle Width="65px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="Ppto">
																<HeaderStyle Width="75px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbPpto" runat="server">PPTO</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblPpto" runat="server" CssClass="normal" ForeColor="Navy">Ppto</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="PorcLogro">
																<HeaderStyle Width="50px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
																<HeaderTemplate>
																	<asp:HyperLink id="hlkbPorcLogro" runat="server">%Logro</asp:HyperLink>
																</HeaderTemplate>
																<ItemTemplate>
																	<asp:Label id="lblPorcLogro" runat="server" CssClass="normal" ForeColor="Navy">Logro</asp:Label>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD align="center"><asp:label id="lblTituloLogro" runat="server" CssClass="Titulosecundario">LOGRO DE VENTAS</asp:label></TD>
								</TR>
								<TR>
									<TD align="center">
										<TABLE class="normal" id="Table6" cellSpacing="0" cellPadding="0" width="780" border="0">
											<TR>
												<TD align="center" colSpan="3"><cc1:datagridweb id="dgConsultaLogro" runat="server" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0"
														AutoGenerateColumns="False" RowPositionEnabled="False" Width="780px">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle HorizontalAlign="Right" CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="titulo" HeaderText="LOGRO">
																<HeaderStyle Width="90px"></HeaderStyle>
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
																<HeaderStyle Width="90px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right"></ItemStyle>
															</asp:BoundColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb></TD>
											</TR>
											<TR>
												<TD align="center" width="100%" colSpan="3"><asp:label id="lblResultadoLogro" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
											</TR>
											<TR>
												<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
												</TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
					</TD>
				</TR>
				</TD></TR></TABLE>
			</TD></TR></TBODY></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
