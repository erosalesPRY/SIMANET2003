<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarSaldodeCtaySubCtaBancariaporCentroDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasBancarias.ConsultarSaldodeCtaySubCtaBancariaporCentroDetalle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1" width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle  de Saldo de Cuenta y Sub Cuenta Bancaria</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="767" border="0">
							<TR>
								<TD align="left" width="100%" colSpan="3">
									<asp:label id="lblFecha" runat="server" CssClass="TituloPrincipal"></asp:label>&nbsp;&nbsp;&nbsp;
									<asp:label id="LblCentro" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 51px">
												<asp:imagebutton id="ibtnFiltar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD style="WIDTH: 1px"><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../imagenes/filtroporseleccion.jpg" runat="server">&nbsp;</TD>
											<TD style="WIDTH: 409px">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD align="right">
												<asp:imagebutton id="ibtnImprimir" runat="server" Width="73px" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" DESIGNTIMEDRAGDROP="47" Width="765px" AllowPaging="True"
										AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="7" ShowFooter="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="8%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nrocuentabancaria" SortExpression="nrocuentabancaria" HeaderText="NRO DE CTA">
												<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SALDO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="100%" colSpan="4">
																<asp:Label id="Label2" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="93" BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="25%">
																<asp:Label id="lblCallao" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="102" BorderStyle="None">SIMA-CALLAO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																<asp:Label id="lblChimbote" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="115" 
 BorderStyle="None">SIMA-CHIMBOTE</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																<asp:Label id="lblIquitos" runat="server" CssClass="HeaderGrilla" BorderStyle="None">SIMA-IQUITOS S.R.Ltda.</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																<asp:Label id="lblTotal" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="133" BorderStyle="None">TOTAL</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="25%">
																<asp:Label id="lblCallaoS" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="268" 
 BorderStyle="None">Label</asp:Label></TD>
															<TD align="right" width="25%">
																<asp:Label id="lblChimboteS" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="289" 
 BorderStyle="None">Label</asp:Label></TD>
															<TD align="right" width="25%">
																<asp:Label id="lblIquitosS" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="334" 
 BorderStyle="None">Label</asp:Label></TD>
															<TD align="right" width="25%">
																<asp:Label id="TotalS" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="None">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<P align="center">
										<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="605" border="0">
											<TR>
												<TD>
													<asp:label id="Label1" runat="server" CssClass="TituloPrincipal">RESUMEN POR MONEDA</asp:label></TD>
											</TR>
											<TR>
												<TD>
													<cc1:datagridweb id="gridResumenM" runat="server" Width="640px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="headerGrilla"></FooterStyle>
														<Columns>
															<asp:BoundColumn DataField="Moneda" HeaderText="M">
																<HeaderStyle Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															</asp:BoundColumn>
															<asp:TemplateColumn HeaderText="SALDO">
																<HeaderStyle Font-Bold="True" VerticalAlign="Middle"></HeaderStyle>
																<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
																<HeaderTemplate>
																	<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
																		<TR>
																			<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																				align="center" width="100%" colSpan="4">
																				<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="93" BorderStyle="None">SALDO</asp:Label></TD>
																		</TR>
																		<TR>
																			<TD align="center" width="25%">
																				<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="102" BorderStyle="None">SIMA-CALLAO</asp:Label></TD>
																			<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																				<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="115" BorderStyle="None">SIMA-CHIMBOTE</asp:Label></TD>
																			<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																				<asp:Label id="Label4" runat="server" CssClass="HeaderGrilla" BorderStyle="None">SIMA-IQUITOS S.R.Ltda.</asp:Label></TD>
																			<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="25%">
																				<asp:Label id="Label3" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="133" BorderStyle="None">TOTAL</asp:Label></TD>
																		</TR>
																	</TABLE>
																</HeaderTemplate>
																<ItemTemplate>
																	<TABLE id="Table5" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
																		border="0">
																		<TR>
																			<TD align="right" width="25%">
																				<asp:Label id="lblCallaoSR" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="268" 
 BorderStyle="None">Label</asp:Label></TD>
																			<TD align="right" width="25%">
																				<asp:Label id="lblChimboteSR" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="289" 
 BorderStyle="None">Label</asp:Label></TD>
																			<TD align="right" width="25%">
																				<asp:Label id="lblIquitosSR" runat="server" CssClass="normaldetalle" Width="100%" DESIGNTIMEDRAGDROP="334" 
 BorderStyle="None">Label</asp:Label></TD>
																			<TD align="right" width="25%">
																				<asp:Label id="TotalSR" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="None">Label</asp:Label></TD>
																		</TR>
																	</TABLE>
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb></TD>
											</TR>
										</TABLE>
									</P>
								</TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
