<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarConceptosPorPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministrarConceptosPorPagar" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc3" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Conceptos por Pagar></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración de Conceptos Por Pagar</asp:label></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
							<TR>
								<TD width="100%">
									<table id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario">CONCEPTOS POR PAGAR</asp:label></td>
											<td style="WIDTH: 337px"></td>
											<td align="right"></td>
										</tr>
										<tr height="8">
											<td colspan="3" width="100%">
												<TABLE class="tabla" id="Table4" cellSpacing="0" cellPadding="0" width="600" align="center"
													bgColor="#f5f5f5">
													<TR bgColor="#ffffff">
														<TD class="TitFiltros" style="WIDTH: 89px" width="89"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
														<TD class="combos" style="WIDTH: 59px" width="59"></TD>
														<TD></TD>
														<TD class="combos" style="WIDTH: 73px" width="73"></TD>
														<TD class="combos" style="WIDTH: 62px" width="62"></TD>
														<TD class="combos" width="24"></TD>
														<TD class="combos" width="316"></TD>
													</TR>
													<TR bgColor="#f5f5f5">
														<TD class="TitFiltros" style="WIDTH: 89px" align="right">
															<asp:label id="lblPeriodoInicial" runat="server" CssClass="normal"> INCIO:&nbsp;</asp:label></TD>
														<TD style="WIDTH: 59px">
															<asp:dropdownlist id="ddlbPeriodoInicial" runat="server" CssClass="normal"></asp:dropdownlist></TD>
														<TD>
															<cc3:comparedomvalidator id="cbvPeriodos" runat="server" ControlToValidate="ddlbPeriodoFinal" ControlToCompare="ddlbPeriodoInicial"
																Type="Integer" Operator="GreaterThanEqual" Display="Dynamic">*</cc3:comparedomvalidator></TD>
														<TD style="WIDTH: 73px" align="right">
															<asp:label id="lblPeriodoFinal" runat="server" CssClass="normal">FINAL:&nbsp;</asp:label></TD>
														<TD style="WIDTH: 62px">
															<asp:dropdownlist id="ddlbPeriodoFinal" runat="server" CssClass="normal"></asp:dropdownlist></TD>
														<TD></TD>
														<TD>
															<asp:button id="btnConsultar" runat="server" CssClass="normal" Text="Consultar"></asp:button></TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td align="center" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
													<TR>
														<TD style="WIDTH: 6px" bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="4"></TD>
														<TD style="WIDTH: 6px" bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 72px" bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 70px" bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
														<TD style="WIDTH: 6px"><IMG height="22" src="../imagenes/tab_der.gif" width="6"></TD>
													</TR>
												</TABLE>
												<cc2:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													AllowSorting="True" AllowPaging="True" PageSize="9" Width="100%" ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="35px"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="Periodo" HeaderText="PERIODO">
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<ItemTemplate>
																<asp:HyperLink id="hlkId" runat="server">Periodo</asp:HyperLink>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="ConceptoDescripcion" HeaderText="DESCRIPCION">
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoPorPagar" SortExpression="MontoPorPagar" HeaderText="POR PAGAR NS"
															DataFormatString="{0:# ### ### ##0.00}">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc2:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></td>
										</tr>
										<tr>
											<td align="center" colSpan="3"><IMG style="WIDTH: 160px; HEIGHT: 10px" height="1" src="../imagenes/spacer.gif" width="160"></td>
										</tr>
										<tr>
											<td align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 25px; HEIGHT: 15px" type="hidden" size="9" runat="server"></td>
											<td></td>
											<td></td>
										</tr>
										<tr>
											<td colspan="3" align="center"><IMG style="WIDTH: 160px; HEIGHT: 10px" height="1" src="../imagenes/spacer.gif" width="160"></td>
										</tr>
										<tr>
											<td></td>
											<td style="WIDTH: 337px">
												<cc3:domvalidationsummary id="DomValidationSummary1" runat="server" Width="91px" ShowMessageBox="True" EnableClientScript="False"
													DisplayMode="List" Height="26px"></cc3:domvalidationsummary></td>
											<td></td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<script language="javascript" type="text/javascript">
					document.all["hCodigo"].value='';
				</script>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
