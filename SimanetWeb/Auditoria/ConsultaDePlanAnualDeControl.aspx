<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultaDePlanAnualDeControl.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Auditoria.ConsultaDePlanAnualDeControl" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="1">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD class="Commands" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Registros del Plan Anual de Control</asp:label></TD>
							</TR>
							<TR>
								<TD align="left" class="normal">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="200" align="center" bgColor="#f5f5f5"
										border="0">
										<TR>
											<TD>
												<asp:label id="lblPeriodo" runat="server" CssClass="normal">Periodo</asp:label></TD>
											<TD>
												<asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="normal" Width="132px" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD>
												<cc2:RequiredDomValidator id="rfvPeriodo" runat="server" ControlToValidate="ddlbPeriodo" InitialValue="%">*</cc2:RequiredDomValidator></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="center" width="100%" colSpan="3">
												<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="550" border="0">
													<TR>
														<TD bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif" CausesValidation="False"></asp:imagebutton></TD>
														<TD style="WIDTH: 11px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG style="HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="570"></TD>
														<TD bgColor="#f0f0f0">&nbsp;</TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif" CausesValidation="False"></asp:imagebutton></TD>
														<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
													</TR>
												</TABLE>
												<cc1:DataGridWeb id="grid" runat="server" align="center" ShowFooter="True" PageSize="7" Width="780px"
													RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False"
													AllowSorting="True" CssClass="HeaderGrilla">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn Visible="False" DataField="IdProgramacionAuditoria" SortExpression="IdProgramacionAuditoria"></asp:BoundColumn>
														<asp:BoundColumn HeaderText="NRO">
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO">
															<HeaderStyle Width="90px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Denominacion" SortExpression="Denominacion" HeaderText="DENOMINACION">
															<HeaderStyle Width="200px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" DataField="observacion" SortExpression="observacion" HeaderText="OBSERVACION">
															<HeaderStyle Width="200px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UnidadMedida" SortExpression="UnidadMedida" HeaderText="UM">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="FlgEnero" HeaderText="E">
															<ItemTemplate>
																<asp:Label id="lblMes1" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgFebrero" HeaderText="F">
															<ItemTemplate>
																<asp:Label id="lblMes2" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgMarzo" HeaderText="M">
															<ItemTemplate>
																<asp:Label id="lblMes3" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgAbril" HeaderText="A">
															<ItemTemplate>
																<asp:Label id="lblMes4" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgMayo" HeaderText="M">
															<ItemTemplate>
																<asp:Label id="lblMes5" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgJunio" HeaderText="J">
															<ItemTemplate>
																<asp:Label id="lblMes6" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgJulio" HeaderText="J">
															<ItemTemplate>
																<asp:Label id="lblMes7" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgAgosto" HeaderText="A">
															<ItemTemplate>
																<asp:Label id="lblMes8" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgSetiembre" HeaderText="S">
															<ItemTemplate>
																<asp:Label id="lblMes9" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgOctubre" HeaderText="O">
															<ItemTemplate>
																<asp:Label id="lblMes10" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgNoviembre" HeaderText="N">
															<ItemTemplate>
																<asp:Label id="lblMes11" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn SortExpression="FlgDiciembre" HeaderText="D">
															<ItemTemplate>
																<asp:Label id="lblMes12" runat="server" Font-Bold="True"></asp:Label>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="PorcAvance" SortExpression="PorcAvance" HeaderText="%" DataFormatString="{0:##0.00}">
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="OBSERV.">
															<HeaderStyle Width="20px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
															<ItemTemplate>
																<asp:ImageButton id="ibtnObservacion" runat="server" ImageUrl="../imagenes/BtPU_Mas.gif"></asp:ImageButton>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:DataGridWeb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
										</TR>
									</TABLE>
									<asp:imagebutton id="ibtnAtras" runat="server" CausesValidation="False" ImageUrl="../imagenes/atras.gif"></asp:imagebutton>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD>&nbsp;</TR></TABLE> &nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
