<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarResumenProgramacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Legal.ConsultarResumenProgramacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 24px" colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Resumen de Programaciones</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
													<TR>
														<TD style="WIDTH: 199px" bgColor="#f0f0f0"></TD>
														<TD style="WIDTH: 94px" bgColor="#f0f0f0"></TD>
														<TD vAlign="top" bgColor="#f0f0f0">&nbsp;<IMG height="8" src="../imagenes/spacer.gif" width="450"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
														<TD bgColor="#f0f0f0"></TD>
													</TR>
												</TABLE>
												<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" PageSize="7"
													RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle VerticalAlign="Top">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Organismo" SortExpression="Organismo" HeaderText="ORGANISMO" FooterText="Total:">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn HeaderText="TOTAL">
<HeaderStyle Width="8%" VerticalAlign="Bottom">
</HeaderStyle>

<HeaderTemplate>
<TABLE id=Table4 style="HEIGHT: 28px" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" align=center colSpan=2>
<asp:Label id=lblSP runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px" BorderStyle="None">SP</asp:Label></TD></TR>
<TR>
<TD align=center width="50%">
<asp:Label id=Label8888 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" Height="3px" BorderStyle="None">PRO.</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="50%">
<asp:Label id=Label11111 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" Height="3px" BorderStyle="None">SUP.</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table5 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblProcesoSP runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblSuperadoSP runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</ItemTemplate>

<FooterTemplate>
<TABLE id=Table1 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblTProcesoSP runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblTSuperadoSP runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderStyle Width="8%">
</HeaderStyle>

<HeaderTemplate>
<TABLE id=Table10 style="HEIGHT: 28px" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" align=center colSpan=2>
<asp:Label id=lblSC runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px" BorderStyle="None">SC</asp:Label></TD></TR>
<TR>
<TD align=center width="50%">
<asp:Label id=Label1 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" Height="3px" BorderStyle="None">PRO.</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="50%">
<asp:Label id=Label2 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" Height="3px" BorderStyle="None">SUP.</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table12 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblProcesoSC runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblSuperadoSC runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</ItemTemplate>

<FooterTemplate>
<TABLE id=Table1 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblTProcesoSC runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblTSuperadoSC runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderStyle Width="8%">
</HeaderStyle>

<HeaderTemplate>
<TABLE id=Table10 style="HEIGHT: 28px" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" align=center colSpan=2>
<asp:Label id=lblSCH runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px" BorderStyle="None">SCH</asp:Label></TD></TR>
<TR>
<TD align=center width="50%">
<asp:Label id=Label3 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" Height="3px" BorderStyle="None">PRO.</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="50%">
<asp:Label id=Label4 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" Height="3px" BorderStyle="None">SUP.</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table12 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblProcesoSCH runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblSuperadoSCH runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</ItemTemplate>

<FooterTemplate>
<TABLE id=Table1 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblTProcesoSCH runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblTSuperadoSCH runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderStyle Width="8%">
</HeaderStyle>

<HeaderTemplate>
<TABLE id=Table10 style="HEIGHT: 28px" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" align=center colSpan=2>
<asp:Label id=lblSI runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px" BorderStyle="None">SI</asp:Label></TD></TR>
<TR>
<TD align=center width="50%">
<asp:Label id=Label5 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" Height="3px" BorderStyle="None">PRO.</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="50%">
<asp:Label id=Label6 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" Height="3px" BorderStyle="None">SUP.</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table12 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblProcesoSI runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblSuperadoSI runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</ItemTemplate>

<FooterTemplate>
<TABLE id=Table1 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblTProcesoSI runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblTSuperadoSI runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</FooterTemplate>
</asp:TemplateColumn>
<asp:TemplateColumn>
<HeaderTemplate>
<TABLE id=Table10 style="HEIGHT: 28px" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; WIDTH: 230px; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc" align=center colSpan=2>
<asp:Label id=lblHTotal3 runat="server" CssClass="HeaderGrilla" Font-Bold="True" Height="3px" BorderStyle="None">TOTAL</asp:Label></TD></TR>
<TR>
<TD align=center width="50%">
<asp:Label id=Label7 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="315" Font-Bold="True" Height="3px" BorderStyle="None">PRO.</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=center width="50%">
<asp:Label id=Label10 runat="server" CssClass="HeaderGrilla" DESIGNTIMEDRAGDROP="503" Font-Bold="True" Height="3px" BorderStyle="None">SUP.</asp:Label></TD></TR></TABLE>
</HeaderTemplate>

<ItemTemplate>
<TABLE id=Table12 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblTotalProceso runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblTotalSuperado runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</ItemTemplate>

<FooterTemplate>
<TABLE id=Table1 height="100%" cellSpacing=0 cellPadding=0 width="100%" align=left border=0>
<TR>
<TD align=right width="50%">
<asp:Label id=lblTTotalProceso runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="315" Height="3px" BorderStyle="None" Width="70px">DEL MES</asp:Label></TD>
<TD style="BORDER-LEFT: #cccccc 1px solid" align=right width="50%">
<asp:Label id=lblTTotalSuperado runat="server" CssClass="FooterGrilla" DESIGNTIMEDRAGDROP="503" Height="3px" BorderStyle="None" Width="78px">AL MES</asp:Label></TD></TR></TABLE>
</FooterTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
						</TABLE>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD vAlign="top"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE></TD></TR></TABLE></form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
