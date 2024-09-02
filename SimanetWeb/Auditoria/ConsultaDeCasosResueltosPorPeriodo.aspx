<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaDeCasosResueltosPorPeriodo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.ConsultaDeCasosResueltosPorPeriodo" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" align="center" border="0" DESIGNTIMEDRAGDROP="154">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registros de Casos Resueltos por A&ntilde;o</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="130" align="center"
										bgColor="#f5f5f5" border="0" DESIGNTIMEDRAGDROP="27">
										<TR>
											<TD class="SmallFont" style="WIDTH: 133px" align="center"><asp:label id="lblPeriodo" runat="server" CssClass="normal">Periodo</asp:label></TD>
											<TD class="SmallFont"></TD>
										</TR>
										<TR>
											<TD class="combos" style="WIDTH: 133px" align="center"><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normal" Width="108px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD class="combos"><cc2:requireddomvalidator id="rfvPeriodo" runat="server" ControlToValidate="ddlbPeriodo" InitialValue="%">*</cc2:requireddomvalidator></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 11px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="565"></TD>
														<TD bgColor="#f0f0f0">&nbsp;</TD>
														<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" Width="780px" align="center" ShowFooter="True" PageSize="7"
													AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
													RowPositionEnabled="False" CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdAccionCorrectiva" SortExpression="IdAccionCorrectiva"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="10px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="Descripcion" HeaderText="ACCION CORRECTIVA">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<ItemTemplate>
																<asp:LinkButton id="hlkId" runat="server" CommandName="Edit">LinkButton</asp:LinkButton>
															</ItemTemplate>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:TemplateColumn>
														<asp:BoundColumn Visible="False" DataField="Observacion" SortExpression="Observacion" HeaderText="OBSERVACION">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="InformeEmitido" SortExpression="InformeEmitido" HeaderText="INFORME">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="CO">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Area" SortExpression="Area" HeaderText="AREA">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FI" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaFin" SortExpression="FechaFin" HeaderText="FT" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="55px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="PorcAvance" SortExpression="PorcAvance" HeaderText="%" DataFormatString="{0:##0.00}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<IMG style="WIDTH: 606px; HEIGHT: 16px" height="16" src="../imagenes/spacer.gif" width="606"></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="tDetalle" cellSpacing="0" cellPadding="0" width="70%" align="center" border="1"
										runat="server">
										<TR>
											<TD></TD>
											<TD>
												<TABLE class="normal" id="Table3" style="WIDTH: 469px" cellSpacing="1" cellPadding="1"
													width="469" align="center" border="0">
													<TR>
														<TD class="normal" align="center" colSpan="6"></TD>
													</TR>
													<TR>
														<TD class="normal"><asp:label id="lblInformeEmitido" runat="server" CssClass="TextoNegroNegrita" Width="104px">Informe Emitido:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px" colSpan="4"><asp:label id="lblInformeEmitidoData" runat="server" Width="328px" Height="3px"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal"><asp:label id="lblCentroOperativo" runat="server" CssClass="TextoNegroNegrita">Centro Operativo:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px"><asp:label id="lblCentroOperativoData" runat="server" Width="187px"></asp:label></TD>
														<TD class="normal"></TD>
														<TD class="normal" style="WIDTH: 96px"><asp:label id="lblArea" runat="server" CssClass="TextoNegroNegrita">Area:</asp:label></TD>
														<TD style="WIDTH: 95px"><asp:label id="lblAreaData" runat="server" Width="196px"></asp:label></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="normal"><asp:label id="lblDescripcion" runat="server" CssClass="TextoNegroNegrita">Descripci&oacute;n:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" colSpan="4"><asp:label id="lblDescripcionData" runat="server" Width="328px"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal"><asp:label id="lblObservacion" runat="server" CssClass="TextoNegroNegrita">Observaci&oacute;n:</asp:label></TD>
														<TD class="normal" style="WIDTH: 352px" colSpan="4"><asp:label id="lblObservacionData" runat="server" Width="328px"></asp:label></TD>
														<TD class="normal"></TD>
													</TR>
													<TR>
														<TD class="normal"><asp:label id="lblPorcentajeAvance" runat="server" CssClass="TextoNegroNegrita">% de Avance:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px"><asp:label id="lblPorcentajeAvanceData" runat="server"></asp:label></TD>
														<TD class="normal"></TD>
														<TD class="normal" style="WIDTH: 96px"></TD>
														<TD style="WIDTH: 95px"></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="normal"><asp:label id="lblFechaInicio" runat="server" CssClass="TextoNegroNegrita">Fecha de Inicio:</asp:label></TD>
														<TD class="normal" style="WIDTH: 139px"><asp:label id="lblFechaInicioData" runat="server"></asp:label></TD>
														<TD class="normal"></TD>
														<TD class="normal" style="WIDTH: 96px"><asp:label id="lblFechaFin" runat="server" CssClass="TextoNegroNegrita" Width="76px">Fecha de Fin:</asp:label></TD>
														<TD style="WIDTH: 95px"><asp:label id="lblFechaFinData" runat="server"></asp:label></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="bottom" align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<asp:imagebutton id="ibtnAtras" runat="server" ImageUrl="../imagenes/atras.gif" CausesValidation="False"></asp:imagebutton></TD>
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
