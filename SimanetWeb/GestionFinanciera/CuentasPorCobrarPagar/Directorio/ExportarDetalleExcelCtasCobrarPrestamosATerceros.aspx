<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ExportarDetalleExcelCtasCobrarPrestamosATerceros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ExportarDetalleExcelCtasCobrarPrestamosATerceros" %>
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
												<cc1:datagridweb id="grid" runat="server" ShowFooter="True" PageSize="7" Width="100%" RowHighlightColor="#E0E0E0"
													AutoGenerateColumns="False" AllowSorting="True">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="EMPRESA">
															<HeaderStyle Width="18%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
															<HeaderStyle Width="12%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="14%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Amortizado" SortExpression="Amortizado" HeaderText="AMORTIZADO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="14%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="14%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
															<HeaderStyle Width="5%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
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
							<TR id="id5">
								<TD vAlign="top"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			</TR></TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
