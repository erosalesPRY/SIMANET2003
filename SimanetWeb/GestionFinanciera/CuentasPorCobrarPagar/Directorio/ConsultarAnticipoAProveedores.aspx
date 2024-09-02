<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarAnticipoAProveedores.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ConsultarAnticipoAProveedores" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR id="id1">
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="id2">
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center" vAlign="top" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR id="id3">
								<TD class="Commands" style="HEIGHT: 20px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera > Consultar Cuentas por Cobrar y Pagar >  Consultar Sub-Cuentas Por Cobrar y Pagar ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle Sub-Cuentas Por Cobrar y Pagar</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="4">
															<asp:label id="lblPrimario" runat="server" CssClass="SubtituloNegrita"></asp:label></TD>
													</TR>
													<TR id="id4">
														<TD bgColor="#f0f0f0">
															<asp:imagebutton id="ibtnFiltrar" runat="server" CausesValidation="False" ImageUrl="../../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
																alt="Aplicar Filtro por Selección" src="../../../imagenes/filtroPorSeleccion.JPG">
															<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../../imagenes/filtroEliminar.GIF"
																ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
														<TD bgColor="#f0f0f0" vAlign="top" align="right">
															<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_abrir.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" PageSize="7" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													AllowSorting="True" ShowFooter="True" AllowPaging="True">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO." FooterText="TOTAL:">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="PROVEEDOR">
															<HeaderStyle Width="18%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="7%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
															<FooterStyle Wrap="False"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="7%"></HeaderStyle>
															<ItemStyle Wrap="False"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Num_Doc_Ana" SortExpression="Num_Doc_Ana" HeaderText="OC/OS">
															<HeaderStyle Width="7%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="CONCEPTO">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemTemplate>
																<asp:TextBox id="txtConcepto" runat="server" CssClass="normalDetalle" Width="100%" BorderColor="Transparent"
																	BackColor="Transparent" BorderStyle="None" TextMode="MultiLine" Height="37px"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn HeaderText="OBSERVACIONES">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemTemplate>
																<asp:TextBox id="txtObservaciongr" runat="server" CssClass="normalDetalle" Width="100%" Height="37px"
																	TextMode="MultiLine" BorderStyle="None" BackColor="Transparent" BorderColor="Transparent"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
								</TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TBODY>
								<TR id="id6">
									<TD vAlign="top"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"
											style="CURSOR: hand"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
											name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
											runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
											runat="server"></TD>
								</TR>
							</TBODY>
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
