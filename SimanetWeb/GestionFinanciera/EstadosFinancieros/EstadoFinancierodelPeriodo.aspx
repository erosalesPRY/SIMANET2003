<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="EstadoFinancierodelPeriodo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.EstadoFinancierodelPeriodo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="HEIGHT: 304px">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3" style="HEIGHT: 8px" align="center">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="756" border="0"
							style="WIDTH: 756px; HEIGHT: 206px">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 1px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 201px"></TD>
											<TD style="WIDTH: 437px"></TD>
											<TD style="WIDTH: 248px">&nbsp;</TD>
											<TD style="WIDTH: 209px" align="right"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial(); HistorialIrAtras();"
													alt="" src="../../imagenes/atras.gif"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG style="WIDTH: 1px; HEIGHT: 22px" height="22" src="../../imagenes/tab_der.gif" width="1"></TD>
										</TR>
									</TABLE>
									<ITEMSTYLE CssClass="ItemGrilla"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla"></FOOTERSTYLE><COLUMNS>
										<ASP:TEMPLATECOLUMN HeaderText="CONCEPTO">
											<HEADERSTYLE Font-Bold="True" Width="75%"></HEADERSTYLE>
											<ITEMSTYLE VerticalAlign="Middle" HorizontalAlign="Left"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="MONTO">
											<ITEMSTYLE VerticalAlign="Middle" HorizontalAlign="Right"></ITEMSTYLE>
											<HEADERTEMPLATE></HEADERTEMPLATE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="DET">
											<HEADERSTYLE Font-Bold="True" Width="5%"></HEADERSTYLE>
											<ITEMSTYLE VerticalAlign="Middle" HorizontalAlign="Center"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="FORM">
											<HEADERSTYLE Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE Font-Bold="True" VerticalAlign="Middle" HorizontalAlign="Center"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										DataKeyField="IdRubro">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrillaNormal"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="CONCEPTO">
												<HeaderStyle Font-Bold="True" Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<TABLE class="ItemGrillaSinColor" id="Table6" style="HEIGHT: 20px" cellSpacing="0" cellPadding="0"
														width="100%" align="left" border="0">
														<TR>
															<TD>
																<asp:HyperLink id="hlkConcepto" runat="server">Modificar</asp:HyperLink></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Enero" SortExpression="Enero" HeaderText="ENE">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Febrero" SortExpression="Febrero" HeaderText="FEB">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Marzo" SortExpression="Marzo" HeaderText="MAR">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Abril" SortExpression="Abril" HeaderText="ABR">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Mayo" SortExpression="Mayo" HeaderText="MAY">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Junio" SortExpression="Junio" HeaderText="JUNIO">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Julio" SortExpression="Julio" HeaderText="JUL">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Agosto" SortExpression="Agosto" HeaderText="AGO">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Setiembre" SortExpression="Setiembre" HeaderText="SET">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Octubre" SortExpression="Octubre" HeaderText="OCT">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Noviembre" SortExpression="Noviembre" HeaderText="NOV">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Diciembre" SortExpression="Diciembre" HeaderText="DIC">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="TotalEjecutado" SortExpression="TotalEjecutado" HeaderText="TOTAL">
												<HeaderStyle Width="6.6%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center" width="100%">
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
