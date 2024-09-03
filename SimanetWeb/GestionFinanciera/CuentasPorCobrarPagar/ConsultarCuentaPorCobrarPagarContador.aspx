<%@ Page language="c#" Codebehind="ConsultarCuentaPorCobrarPagarContador.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarCuentaPorCobrarPagarContador" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarCuentaPorCobrarPagarContador</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="2" cellPadding="0" width="100%" border="0">
				<TR>
					<TD align="center"><asp:datagrid id="dgDatosResumen" runat="server" AutoGenerateColumns="False" Width="800px" ShowFooter="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle Font-Bold="True" CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="PERIODO" HeaderText="A&#209;O" FooterText="TOTAL">
									<HeaderStyle Width="130px"></HeaderStyle>
									<FooterStyle Font-Bold="True" HorizontalAlign="Left"></FooterStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<TABLE id="Table7" style="FONT-SIZE: 10px; COLOR: #ffffff; FONT-FAMILY: Arial; BACKGROUND-COLOR: #335eb4"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #ece9d8 1px solid" align="center" colSpan="2">CALLAO</TD>
											</TR>
											<TR>
												<TD style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: #ece9d8 1px solid; BORDER-LEFT-WIDTH: 1px; BORDER-BOTTOM-WIDTH: 1px; WIDTH: 40%"
													align="center" colSpan="1" rowSpan="1">CANTIDAD</TD>
												<TD style="WIDTH: 60%" align="center" colSpan="1" rowSpan="1">MONTO</TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table3" style="FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial" cellSpacing="0"
											cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id=lblCCallao runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SCallaoCantidad") %>'>
													</asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id=lblMCallao runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SCallaoMonto") %>'>
													</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE class="FooterGrilla" id="Table2" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id="lblTCCallao" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id="lblTMCallao" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<TABLE id="Table4" style="FONT-SIZE: 10px; COLOR: #ffffff; FONT-FAMILY: Arial; BACKGROUND-COLOR: #335eb4"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #ece9d8 1px solid" align="center" colSpan="2">CHIMBOTE</TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="center" colSpan="1" rowSpan="1">CANTIDAD</TD>
												<TD style="WIDTH: 60%" align="center" colSpan="1" rowSpan="1">MONTO</TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table6" style="FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial" cellSpacing="0"
											cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id=lblCChimbote runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SChimboteCantidad") %>'>
													</asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id=lblMChimbote runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SChimboteMonto") %>'>
													</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE class="FooterGrilla" id="Table2" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id="lblTCChimbote" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id="lblTMChimbote" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<TABLE id="Table10" style="FONT-SIZE: 10px; COLOR: #ffffff; FONT-FAMILY: Arial; BACKGROUND-COLOR: #335eb4"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #ece9d8 1px solid" align="center" colSpan="2">PERU</TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="center" colSpan="1" rowSpan="1">CANTIDAD</TD>
												<TD style="WIDTH: 60%" align="center" colSpan="1" rowSpan="1">MONTO</TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table8" style="FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial" cellSpacing="0"
											cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id=lblCPeru runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPeruCantidad") %>'>
													</asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id=lblMPeru runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SPeruMonto") %>'>
													</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE class="FooterGrilla" id="Table2" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; WIDTH: 150px; COLOR: #000080; FONT-FAMILY: Arial; HEIGHT: 17px"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id="lblTCPeru" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id="lblTMPeru" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderTemplate>
										<TABLE id="Table9" style="FONT-SIZE: 10px; COLOR: #ffffff; FONT-FAMILY: Arial; BACKGROUND-COLOR: #335eb4"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #ece9d8 1px solid" align="center" colSpan="2">IQUITOS</TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="center" colSpan="1" rowSpan="1">CANTIDAD</TD>
												<TD style="WIDTH: 60%" align="center" colSpan="1" rowSpan="1">MONTO</TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table11" style="FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial" cellSpacing="0"
											cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id=lblCIquitos runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SIquitosCantidad") %>'>
													</asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id=lblMIquitos runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SIquitosMonto") %>'>
													</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE class="FooterGrilla" id="Table2" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id="lblTCIquitos" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id="lblTMIquitos" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<ItemStyle Font-Bold="True"></ItemStyle>
									<HeaderTemplate>
										<TABLE id="Table9" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #ffffff; FONT-FAMILY: Arial; BACKGROUND-COLOR: #335eb4"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #ece9d8 1px solid" align="center" colSpan="2">TOTAL</TD>
											</TR>
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="center" colSpan="1" rowSpan="1">CANTIDAD</TD>
												<TD style="WIDTH: 60%" align="center" colSpan="1" rowSpan="1">MONTO</TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table11" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id="lblTCantidadP" runat="server"></asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id="lblTMontoP" runat="server"></asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterStyle Font-Bold="True"></FooterStyle>
									<FooterTemplate>
										<TABLE class="FooterGrilla" id="Table2" style="FONT-WEIGHT: bold; FONT-SIZE: 10px; COLOR: #000080; FONT-FAMILY: Arial"
											cellSpacing="0" cellPadding="0" width="160" border="0">
											<TR>
												<TD style="BORDER-RIGHT: #ece9d8 1px solid; WIDTH: 40%" align="right">
													<asp:Label id="lblTCantidad" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
												<TD style="WIDTH: 60%" align="right" colSpan="1" rowSpan="1">
													<asp:Label id="lblTMonto" runat="server" CssClass="FooterGrilla" Font-Bold="True"></asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
						</asp:datagrid></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="1" rowSpan="1"><asp:imagebutton id="ImageButton1" runat="server" ImageUrl="../../imagenes/RetornarAlFormato.GIF"></asp:imagebutton></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
