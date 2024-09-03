<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="DetalleReporteFormulaContable.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.DetalleReporteFormulaContable" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE id="Table5" style="WIDTH: 583px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="583"
							border="0" DESIGNTIMEDRAGDROP="279">
							<TR bgColor="#f0f0f0">
								<TD>
									<P align="left"><asp:label id="Label5" runat="server" Font-Bold="True">RESUMEN</asp:label></P>
								</TD>
								<TD></TD>
								<TD>&nbsp;</TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<TABLE id="tblCabecera" style="BORDER-RIGHT: #999999 1px solid; BORDER-TOP: white 1px solid; WIDTH: 582px; BORDER-BOTTOM: #999999 1px solid; HEIGHT: 14px"
							cellSpacing="1" cellPadding="0" width="582" bgColor="#ffffff" border="0" runat="server">
							<TR class="HeaderGrilla">
								<TD style="WIDTH: 54px">CUENTA</TD>
								<TD style="WIDTH: 275px; HEIGHT: 24px">NOMBRE</TD>
								<TD style="WIDTH: 105px; HEIGHT: 24px">MONTO</TD>
								<TD style="DISPLAY: none; HEIGHT: 24px">Al MES</TD>
							</TR>
							<TR class="ItemGrilla">
								<TD style="WIDTH: 54px">
									<P align="left">&nbsp;</P>
								</TD>
								<TD id="lblConcepto" style="WIDTH: 275px" align="left" runat="server">
									<P align="left">&nbsp;</P>
								</TD>
								<TD id="lblMontoMes" style="WIDTH: 105px" align="right" runat="server"></TD>
								<TD id="lblMontoAcumulado" style="DISPLAY: none" align="right" runat="server">
									<P align="left">&nbsp;</P>
								</TD>
							</TR>
							<TR class="ItemGrilla" id="row2Dig" runat="server">
								<TD id="lblCuenta2Dig" style="FONT-WEIGHT: normal; WIDTH: 54px" runat="server"></TD>
								<TD id="lblConcepto2Dig" style="WIDTH: 275px" align="left" runat="server"></TD>
								<TD id="lblMontoMes2Dig" style="WIDTH: 105px" align="right" runat="server"></TD>
								<TD id="lblMontoAcumulado2Dig" style="DISPLAY: none" align="right" runat="server"></TD>
							</TR>
							<TR class="ItemGrilla" id="row3Dig" runat="server">
								<TD id="lblCuenta3Dig" style="WIDTH: 54px" runat="server"></TD>
								<TD id="lblConcepto3Dig" style="WIDTH: 275px" align="left" runat="server"></TD>
								<TD id="lblMontoMes3Dig" style="WIDTH: 105px" align="right" runat="server"></TD>
								<TD id="lblMontoAcumulado3Dig" style="DISPLAY: none" align="right" runat="server"></TD>
							</TR>
							<TR class="ItemGrilla" id="row5Dig" runat="server">
								<TD id="lblCuenta5Dig" style="WIDTH: 54px" runat="server"></TD>
								<TD id="lblConcepto5Dig" style="WIDTH: 275px" align="left" runat="server"></TD>
								<TD id="lblMontoMes5Dig" style="WIDTH: 105px" align="right" runat="server"></TD>
								<TD id="lblMontoAcumulado5Dig" style="DISPLAY: none" align="right" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE id="Table3" style="WIDTH: 583px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="583"
							border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD style="WIDTH: 466px"><asp:label id="Label2" runat="server" Width="392px" Font-Bold="True">Movimiento Detalle de Cuenta</asp:label></TD>
								<TD style="WIDTH: 88px">&nbsp;</TD>
								<TD style="WIDTH: 109px"></TD>
								<TD></TD>
								<TD><asp:imagebutton id="ibtnImprimir" runat="server" Visible="False" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="581px" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" BackColor="Transparent" BorderStyle="Ridge">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:TemplateColumn SortExpression="CuentaContable" HeaderText="CUENTA">
									<HeaderStyle Font-Bold="True" Width="5%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="hlkCuentaContable" runat="server">HyperLink</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn SortExpression="NombreCuenta" HeaderText="NOMBRE/DESCRIPCION">
									<HeaderStyle Font-Bold="True" Width="50%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<asp:HyperLink id="hlkNombreCuenta" runat="server">NombreCuenta</asp:HyperLink>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="MontoMes" HeaderText="MONTO">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3"><asp:label id="lblResultado" runat="server" DESIGNTIMEDRAGDROP="346" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE id="Table7" style="WIDTH: 580px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="580"
							border="0">
							<TR>
								<TD>
									<P align="right"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/BtnSubirNivel.GIF"></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			SIMA.Utilitario.Error.TiempoEsperadePagina();
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
