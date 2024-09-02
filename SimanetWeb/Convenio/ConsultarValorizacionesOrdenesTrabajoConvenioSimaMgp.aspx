<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarValorizacionesOrdenesTrabajoConvenioSimaMgp" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="False" name="vs_showGrid">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"> </SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" type="text/javascript">
			function LlenarCeldaTabla(ptxtValor)
			{
				objMontoPresupuesto=document.all["CeldaMontoPresupuesto"];
				objMontoPresupuesto.innerText=ptxtValor;
				return;
			}
		</SCRIPT>
	</HEAD>
	<body style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<FORM id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Convenio>Proyecto del Convenio></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Valorizaciones y Ordenes de Trabajo</asp:label></TD>
							</TR>
							<TR>
								<td>
									<table id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<tr>
											<TD class="TituloSecundario" style="WIDTH: 429px" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario" DESIGNTIMEDRAGDROP="30"> CONVENIO SIMA - MGP...</asp:label></TD>
											<td align="right"></td>
										</tr>
									</table>
								</td>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="tabla" id="Table4" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5"
										border="0">
										<tr>
											<td align="center" bgColor="#ffffff" colSpan="6"><TABLE class="tabla" id="Table5" cellSpacing="0" cellPadding="0" width="780" bgColor="#f5f5f5"
													border="0">
													<tr>
														<td colSpan="6"><asp:label id="lblProyectoDescripcion" runat="server" CssClass="normal">PROYECTO:</asp:label></td>
													</tr>
													<tr>
														<td colSpan="6"><asp:textbox id="txtProyectoDescripcion" runat="server" CssClass="normal" TextMode="MultiLine"
																Width="100%"></asp:textbox></td>
													</tr>
													<tr>
														<td bgColor="#ffffff" colSpan="6"><asp:label id="lblTituloSecundario" runat="server" CssClass="TituloSecundario" Width="100%"> VALORIZACIONES</asp:label></td>
													</tr>
													<TR>
														<TD class="TitFiltros" width="300"><asp:label id="Label3" runat="server" CssClass="normal">CENTRO DE OPERACION:&nbsp;</asp:label><asp:dropdownlist id="ddlbCentroOperativo" runat="server" CssClass="normal" Width="160px"></asp:dropdownlist></TD>
														<TD class="combos"><asp:label id="lblEstado" runat="server" CssClass="normal">ESTADO:&nbsp;</asp:label><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist><asp:button id="btnConsultar" runat="server" CssClass="normal" Text="Consultar"></asp:button></TD>
														<TD class="combos"></TD>
														<TD class="combos"></TD>
														<TD class="combos" width="20"></TD>
														<TD class="combos" align="right"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif" CausesValidation="False"
																Visible="False"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table6" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" width="100%"><cc1:datagridweb id="dgOrdenTrabajo" runat="server" CssClass="HeaderGrilla" Width="100%" PageSize="7"
													AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
													ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="30px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroValorizacion" SortExpression="NroValorizacion" HeaderText="VALORIZACION">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroOrdenTrabajo" SortExpression="NroOrdenTrabajo" HeaderText="TRABAJO">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Alias" SortExpression="Alias" HeaderText="ALIAS">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPrecioVentaSoles" SortExpression="MontoPrecioVentaSoles" HeaderText="PRESUPUESTO NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="ESTADO">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PorcAvanceFisico" SortExpression="PorcAvanceFisico" HeaderText="% ACT"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="UnidadNaval" HeaderText="UnidadNaval"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoCostoDirecto" HeaderText="MontoCostoDirecto"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoCostoIndirecto" HeaderText="MontoCostoIndirecto"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoCostoTotal" HeaderText="MontoCostoTotal"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="MontoSaldo" HeaderText="MotonSaldo"></asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="Descripcion" HeaderText="Descripcion"></asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<td style="WIDTH: 352px" vAlign="top"><table id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr>
																	<td colSpan="2"><asp:label id="lblUnidadNaval" runat="server" CssClass="normal">UNIDAD NAVAL:</asp:label></td>
																</tr>
																<tr>
																	<td colSpan="2"><asp:textbox id="txtUnidadNaval" runat="server" CssClass="TextoAzul" Width="100%" ReadOnly="True"></asp:textbox></td>
																</tr>
																<tr>
																	<td><asp:label id="lblPresupuesto" runat="server" CssClass="normal" Width="100%">PRESUPUESTO NS:</asp:label></td>
																	<td></td>
																</tr>
																<tr>
																	<td vAlign="top" align="left" width="150">
																		<table id="Table11" height="20" cellSpacing="0" cellPadding="0" width="100%" borderColorLight="#afcdd8"
																			border="1">
																			<tr>
																				<td class="TextoAzul" id="CeldaMontoPresupuesto" borderColor="#afcdd8" align="right"
																					width="100%"></td>
																			</tr>
																		</table>
																		<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif">
																	</td>
																</tr>
															</table>
														</td>
														<TD style="WIDTH: 10px" width="10"></TD>
														<TD vAlign="top" colSpan="2">
															<table id="Table10" cellSpacing="0" cellPadding="0" width="100%" border="0">
																<tr>
																	<td><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></td>
																</tr>
																<tr>
																	<td><asp:textbox id="txtDescripcion" runat="server" CssClass="TextoAzul" TextMode="MultiLine" Width="100%"
																			ReadOnly="True" Height="58px"></asp:textbox></td>
																</tr>
															</table>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<tr>
											<td></td>
										</tr>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<IMG height="8" src="../imagenes/spacer.gif" width="200" align="middle"></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
