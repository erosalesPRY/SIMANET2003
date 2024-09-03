<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="EstadosFinancierosEvaluacionResumen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.EstadosFinancierosEvaluacionResumen" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<!--oncontextmenu="return false"-->
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera Presupuestales > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE id="Table4" style="WIDTH: 637px; HEIGHT: 23px" cellSpacing="1" cellPadding="1" width="637"
							border="0">
							<TR>
								<TD style="WIDTH: 46px"><asp:label id="Label3" runat="server" CssClass="TextoAzul">Periodo :</asp:label></TD>
								<TD style="WIDTH: 66px"><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos" AutoPostBack="True"></asp:dropdownlist></TD>
								<TD style="WIDTH: 42px"><asp:label id="Label2" runat="server" CssClass="TextoAzul">Mes :</asp:label></TD>
								<TD style="WIDTH: 78px"><asp:dropdownlist id="dddblMes" runat="server" CssClass="combos" AutoPostBack="True">
										<asp:ListItem Value="1">Enero</asp:ListItem>
										<asp:ListItem Value="2">Febrero</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Abril</asp:ListItem>
										<asp:ListItem Value="5">Mayo</asp:ListItem>
										<asp:ListItem Value="6">Junio</asp:ListItem>
										<asp:ListItem Value="7">Julio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Setiembre</asp:ListItem>
										<asp:ListItem Value="10">Octubre</asp:ListItem>
										<asp:ListItem Value="11">Noviembre</asp:ListItem>
										<asp:ListItem Value="12">Diciembre</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 42px"></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE class="normal" id="Table2" style="WIDTH: 643px; HEIGHT: 169px" cellSpacing="0" cellPadding="0"
							width="643" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 24px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 43px"></TD>
											<TD style="WIDTH: 107px" vAlign="bottom">&nbsp;
											</TD>
											<TD style="WIDTH: 725px"></TD>
											<TD style="WIDTH: 446px"></TD>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<ITEMSTYLE CssClass="ItemGrilla"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla"></FOOTERSTYLE><COLUMNS><ASP:TEMPLATECOLUMN HeaderText="CONCEPTO"><HEADERSTYLE Width="75%" Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Left" VerticalAlign="Middle"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="MONTO">
											<ITEMSTYLE HorizontalAlign="Right" VerticalAlign="Middle"></ITEMSTYLE>
											<HEADERTEMPLATE></HEADERTEMPLATE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="DET">
											<HEADERSTYLE Width="5%" Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
										<ASP:TEMPLATECOLUMN HeaderText="FORM">
											<HEADERSTYLE Font-Bold="True"></HEADERSTYLE>
											<ITEMSTYLE Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<ITEMTEMPLATE></ITEMTEMPLATE>
										</ASP:TEMPLATECOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" Mode="NumericPages"></PAGERSTYLE><cc1:datagridweb id="grid" runat="server" Width="100%" DataKeyField="IdRubro" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="70%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Presupuesto" SortExpression="Presupuesto" HeaderText="PRESUPUESTO">
												<HeaderStyle Font-Underline="True" Font-Bold="True" HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EjecutadoReal" SortExpression="EjecutadoReal" HeaderText="EJECUCION">
												<HeaderStyle Font-Underline="True" Font-Bold="True" Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcEjecutado" SortExpression="PorcEjecutado" HeaderText="% EJEC">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SaldoPPto" SortExpression="SaldoPPto" HeaderText="SALDO">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcSaldoPorEjecutar" SortExpression="PorcSaldoPorEjecutar" HeaderText="%  SALD">
												<HeaderStyle Width="1px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SEP">
												<HeaderStyle Width="1px"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table12" height="100%" cellSpacing="0" cellPadding="0" width="22" align="left"
														border="0">
														<TR>
															<TD align="center" width="50%" height="100%"><IMG style="HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="12"></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table1" height="100%" cellSpacing="0" cellPadding="0" width="22" align="left"
														border="0">
														<TR>
															<TD align="center" width="50%" bgColor="gainsboro"><IMG style="HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="12"></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="Proyectado" SortExpression="Proyectado" HeaderText="PROYECTADO">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
