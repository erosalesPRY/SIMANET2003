<%@ Page language="c#" Codebehind="ConsultarDetalleGastosdeAdministracionPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarDetalleGastosdeAdministracionPorCentroOperativo" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleGastosdeAdministracionPorCentroOperativo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
	</HEAD>
	<body leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><asp:label id="Label4" runat="server" Font-Bold="True" Width="72px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CONCEPTO :</asp:label><asp:label id="lblConcepto" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco"></asp:label><BR>
						<BR>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"><cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowPaging="True">
							<PagerStyle Font-Size="XX-Small" HorizontalAlign="Center" ForeColor="White" BackColor="Highlight"
								CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn Visible="False" HeaderText="NRO" FooterText="TOTAL">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Nombrecentrocosto" HeaderText="CENTRO DE COSTO">
									<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="DEL MES">
									<HeaderStyle Width="23.33%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
													align="center" colSpan="3">
													<asp:Label id="lblDelMes" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FEBRERO</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="28.33%">
													<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
													<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
													<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="28.33%">
													<asp:Label id="lblDelMesReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
													<asp:Label id="lblDelMesPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
													<asp:Label id="lblDelMesVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="28.33%">
													<asp:Label id="lblDelMesRealF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
													<asp:Label id="lblDelMesPPTOF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
													<asp:Label id="lblDelMesVarF" runat="server" CssClass="FooterGrilla" BorderStyle="None" Visible="False">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="ACUMULADO">
									<HeaderStyle Width="23.33%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
													align="center" colSpan="3">
													<asp:Label id="lblAcumulado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">ACUMULADO</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="28.33%">
													<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
													<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
													<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="28.33%">
													<asp:Label id="lblAcumReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
													<asp:Label id="lblAcumPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
													<asp:Label id="lblAcumVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE id="Table95" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="28.33%">
													<asp:Label id="lblAcumRealF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
													<asp:Label id="lblAcumPPTOF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
													<asp:Label id="lblAcumVarF" runat="server" CssClass="FooterGrilla" BorderStyle="None" Visible="False">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn Visible="False">
									<HeaderStyle Width="3%"></HeaderStyle>
									<ItemTemplate>
										<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<asp:label id="Label2" runat="server" Font-Size="XX-Small" Height="1px">OBSERVACIONES:</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"><TEXTAREA id="campo1" style="FONT-SIZE: 10px; WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 64px"
							name="campo1" rows="4" readOnly cols="101" runat="server"></TEXTAREA></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
