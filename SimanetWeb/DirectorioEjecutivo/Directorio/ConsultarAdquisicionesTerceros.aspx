<%@ Page language="c#" Codebehind="ConsultarAdquisicionesTerceros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultarAdquisicionesTerceros" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js?ver=Basico"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3" vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro Adquisiciones con Terceros</asp:label></TD>
							</TR>
							<TR>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD bgColor="#f0f0f0">&nbsp;
															<asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
																src="../../imagenes/filtroPorSeleccion.JPG" style="Z-INDEX: 0; CURSOR: hand"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.." style="Z-INDEX: 0"></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0" width="100%"></TD>
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnBases" runat="server" ToolTip="Flujograma de Procesos" ImageUrl="../../imagenes/ley1.gif"
																Height="19px"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
													Width="780px" ShowFooter="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO.">
															<HeaderStyle Width="5%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CentroOperativo" SortExpression="CentroOperativo" HeaderText="C.O.">
															<HeaderStyle Width="1%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaOrden" SortExpression="FechaOrden" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="ObjetoAdquisicion" SortExpression="ObjetoAdquisicion" HeaderText="CONCEPTO">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Proveedor" SortExpression="Proveedor" HeaderText="PROVEEDOR">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoAdquisicion" SortExpression="MontoAdquisicion" HeaderText="MONTO"
															DataFormatString="{0:###,##0.00}">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TipoMercado" SortExpression="TipoMercado" HeaderText="MERCADO">
															<HeaderStyle Width="9%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb>
												<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Width="56px" Height="7px"></asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" bgColor="#f5f5f5" border="0">
													<TR>
														<TD class="TitFiltros" bgColor="#f5f5f5">
															<asp:label id="lblObjeto" runat="server" CssClass="normal"> Proyecto:</asp:label></TD>
														<TD class="combos" bgColor="#f5f5f5">
															<asp:textbox id="txtObjeto" runat="server" CssClass="normal" Width="728px" TextMode="MultiLine"
																ReadOnly="True"></asp:textbox></TD>
													</TR>
												</TABLE>
												<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD vAlign="top" align="center">
															<asp:label id="Label11" runat="server" Width="350px" Font-Size="X-Small" Font-Bold="True" BackColor="#335EB4"
																ForeColor="White"> Valorización de Adquisiciones</asp:label></TD>
													</TR>
													<TR>
														<TD vAlign="top" align="center">
															<P>
																<cc1:datagridweb id="gridResumen" runat="server" CssClass="HeaderGrilla" Width="350px" AutoGenerateColumns="False"
																	RowHighlightColor="#E0E0E0" PageSize="3">
																	<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
																	<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																	<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																	<FooterStyle CssClass="headerGrilla"></FooterStyle>
																	<Columns>
																		<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Cantidad" SortExpression="Cantidad" HeaderText="CANTIDAD">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="MontoAdquisicion" SortExpression="MontoAdquisicion" HeaderText="TOTAL">
																			<ItemStyle HorizontalAlign="Right"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																	<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
																</cc1:datagridweb></P>
															<P>
																<cc1:datagridweb id="gridPeriodo" runat="server" CssClass="HeaderGrilla" Width="350px" AutoGenerateColumns="False"
																	AllowPaging="True" RowHighlightColor="#E0E0E0" PageSize="3">
																	<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
																	<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																	<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																	<FooterStyle CssClass="headerGrilla"></FooterStyle>
																	<Columns>
																		<asp:BoundColumn DataField="PERIODO" SortExpression="PERIODO" HeaderText="PERIODO"></asp:BoundColumn>
																		<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="MONEDA">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="Cantidad" SortExpression="Cantidad" HeaderText="CANTIDAD">
																			<ItemStyle HorizontalAlign="Center"></ItemStyle>
																		</asp:BoundColumn>
																		<asp:BoundColumn DataField="MontoAdquisicion" SortExpression="MontoAdquisicion" HeaderText="TOTAL">
																			<ItemStyle HorizontalAlign="Right"></ItemStyle>
																		</asp:BoundColumn>
																	</Columns>
																	<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
																</cc1:datagridweb></P>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD vAlign="top"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
													style="CURSOR: hand"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
													name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
													runat="server"></TD>
										</TR>
									</TABLE>
									<INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hDescripcion" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hDescripcion"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TD></TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
