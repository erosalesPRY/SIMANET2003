<%@ Page language="c#" Codebehind="ConsultarProgramaActividades.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarProgramaActividades" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Simanet</title>
		<meta name="vs_showGrid" content="False">
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src='="../js/@Import.js"'></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración > Convenio</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> CONSULTAR PROGRAMA ACTIVIDADES</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" colSpan="2">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"> PROGRAMA</asp:label></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f5f5f5" colSpan="2">
									<cc1:datagridweb id="dgConvenio" runat="server" CssClass="HeaderGrilla" Width="100%" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="7"
										ShowFooter="True" align="center">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="UNIDAD" SortExpression="UNIDAD" HeaderText="UNIDAD">
												<HeaderStyle Width="7%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NROCASCO" SortExpression="NROCASCO" HeaderText="CASCO">
												<HeaderStyle Width="7%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ST" SortExpression="ST" HeaderText="VALORIZACION">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="OT" SortExpression="OT" HeaderText="O/T">
												<HeaderStyle Width="7%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MONTOAPROBADO" SortExpression="MONTOAPROBADO" HeaderText="MONTO APROBADO (S/.)" 
 DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="20%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE style="Z-INDEX: 0; HEIGHT: 28px" id="Table7" border="0" cellSpacing="0" cellPadding="0"
														width="100%" align="left">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid; BORDER-RIGHT-WIDTH: 1px; WIDTH: 230px; HEIGHT: 10px; BORDER-RIGHT-COLOR: #cccccc; BORDER-LEFT-COLOR: #cccccc; BORDER-LEFT-WIDTH: 1px"
																colSpan="2" align="center">
																<asp:Label id="lblHTotal" runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px" 
 BorderStyle="None">AVANCE FISICO</asp:Label></TD>
														</TR>
														<TR>
															<TD width="50%" align="center">
																<asp:Label id="Label8888" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" 
 Height="3px" BorderStyle="None">%</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="50%" align="center">
																<asp:Label id="Label11111" runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" 
 Font-Bold="True" Height="3px" BorderStyle="None">S/.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE style="Z-INDEX: 0" id="Table9" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left" height="100%">
														<TR>
															<TD width="50%" align="right">
																<asp:Label id="lblPorcen" runat="server" CssClass="normaldetalle" Width="70px" DESIGNTIMEDRAGDROP="315" 
 Height="3px" BorderStyle="None">DEL MES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="50%" align="right">
																<asp:Label id="lblSoles" runat="server" CssClass="normaldetalle" Width="78px" DESIGNTIMEDRAGDROP="503" 
 Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE style="Z-INDEX: 0" id="Table13" border="0" cellSpacing="0" cellPadding="0" width="100%"
														align="left" height="100%">
														<TR>
															<TD width="50%" align="right"></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" width="50%" align="right">
																<asp:Label id="lblTSoles" runat="server" CssClass="FooterGrilla" Width="78px" DESIGNTIMEDRAGDROP="503" 
 Height="3px" BorderStyle="None">AL MES</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD width="50%" colSpan="2"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 15px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
