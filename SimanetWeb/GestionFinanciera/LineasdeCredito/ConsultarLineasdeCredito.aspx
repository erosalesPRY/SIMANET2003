<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarLineasdeCredito.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito.ConsultarLineasdeCredito" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Línea de Crédito</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><IMG style="WIDTH: 160px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="160"
							DESIGNTIMEDRAGDROP="131"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="571" border="0"
							style="WIDTH: 571px">
							<TR>
								<TD style="HEIGHT: 13px"></TD>
								<TD style="HEIGHT: 13px"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD><IMG height="8" src="../imagenes/spacer.gif" width="250"></TD>
											<TD>&nbsp;</TD>
											<TD style="WIDTH: 101px"></TD>
											<TD style="WIDTH: 101px"></TD>
											<TD><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" AllowPaging="True" Width="100%" PageSize="12" ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="Alternateitemgrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="0%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nombreentidad" SortExpression="nombreentidad" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle HorizontalAlign="Center" Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAutorizadoEnDolar" SortExpression="MontoAutorizadoEnDolar" HeaderText="AUTORIZADO EN DOLARES">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="UtilizadoAlCambioDelDolar" SortExpression="UtilizadoAlCambioDelDolar"
												HeaderText="UTILIZADO AL CAMBIO DOLARES">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DisponibleEnDolar" SortExpression="DisponibleEnDolar" HeaderText="DISPONIBLE EN  DOLARES">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SITUACION" SortExpression="SITUACION" HeaderText="SITUACION">
												<HeaderStyle Width="15%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
