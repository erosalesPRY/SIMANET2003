<%@ Page language="c#" Codebehind="EstadosFinancierosPorEmpresaDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.EstadosFinancierosPorEmpresaDetalle" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
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
</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table style="HEIGHT: 312px" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Cuentas Bancarias></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table4" style="WIDTH: 617px; HEIGHT: 123px" cellSpacing="1" cellPadding="1"
							width="617" border="0">
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 769px"></TD>
											<TD style="WIDTH: 392px" vAlign="bottom">&nbsp;</TD>
											<TD style="WIDTH: 388px"></TD>
											<TD style="WIDTH: 209px" align=right><IMG 
                  id=Img1 style="CURSOR: hand" onclick=HistorialIrAtras(); 
                  alt="" src="../../imagenes/atras.gif"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 48px"
										cellSpacing="1" cellPadding="1" width="100%" border="0">
										<TR>
											<TD class="headergrilla" colSpan="1" rowSpan="2" style="HEIGHT: 49px" vAlign="bottom"><asp:label id="Label2" runat="server">CONCEPTO</asp:label></TD>
											<TD class="headergrilla" colSpan="2"><asp:label id="Label1" runat="server" DESIGNTIMEDRAGDROP="160">REAL</asp:label></TD>
										</TR>
										<TR>
											<TD class="headergrilla" style="HEIGHT: 24px"><asp:label id="LblAlMesT" runat="server">AL MES </asp:label></TD>
											<TD class="headergrilla" style="HEIGHT: 24px"><asp:label id="lblDelMesT" runat="server">DEL MES</asp:label></TD>
										</TR>
										<TR class="ItemGrilla">
											<TD id="lblConcepto" vAlign="middle" width="40%" runat="server"></TD>
											<TD id="lblAlMes" vAlign="middle" align="right" width="21%" runat="server"></TD>
											<TD id="lblDelMes" vAlign="middle" align="right" width="21%" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<cc1:datagridweb id="gridResumen" runat="server" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
							Width="618px">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="CUENTA">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="hlkCuentaRes" runat="server" Width="81px">Cuenta</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NombreCuenta" SortExpression="NombreCuenta" HeaderText="NOMBRE CUENTA">
									<HeaderStyle Width="50%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AlmesAnterior" SortExpression="AlmesAnterior" HeaderText="MES ANTERIOR">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AlmesActual" SortExpression="AlmesActual" HeaderText="MES ACTUAL">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<cc1:datagridweb id="grid" runat="server" Width="618px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:TemplateColumn HeaderText="CUENTA">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="hlkCuenta" runat="server" Width="81px">Cuenta</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NombreCuenta" SortExpression="NombreCuenta" HeaderText="NOMBRE CUENTA">
									<HeaderStyle Width="50%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AlmesAnterior" SortExpression="AlmesAnterior" HeaderText="MES ANTERIOR">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="AlmesActual" SortExpression="AlmesActual" HeaderText="MES ACTUAL">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table1" style="WIDTH: 621px; HEIGHT: 23px" cellSpacing="1" cellPadding="1" width="621"
							border="0">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3"></TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
