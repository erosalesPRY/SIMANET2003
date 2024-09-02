<%@ Page language="c#" Codebehind="ExportarDetalleExcelCtasCobrarReclamosTerceros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ExportarDetalleExcelCtasCobrarReclamosTerceros" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
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
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
				<TR id="id1">
					<TD style="HEIGHT: 24px" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" vAlign="top" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD align="center" vAlign="top">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD bgColor="#f0f0f0" colSpan="4">
															<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_exportar.gif"></asp:imagebutton></TD>
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
														<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="CLIENTE">
															<HeaderStyle Width="18%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Num_Doc_Ana" SortExpression="Num_Doc_Ana" HeaderText="FACTURA">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="13%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn Visible="False" HeaderText="FECHA VENC.">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn SortExpression="Descripcion" HeaderText="CONCEPTO">
															<ItemTemplate>
																<asp:TextBox id="txtDescripcion" runat="server" CssClass="normalDetalle" Width="100%" TextMode="MultiLine"
																	ReadOnly="True" BorderWidth="0px" Rows="3" BackColor="Transparent" BorderColor="Transparent"></asp:TextBox>
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
								<TR id="id5">
									<TD vAlign="top"></TD>
								</TR>
								<TR id="id6">
									<TD vAlign="top"></TD>
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
