<%@ Page language="c#" Codebehind="PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio</title>
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
  </HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Visual" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
				<TR>
					<TD align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
  <TR>
    <TD align=center>
<asp:label id=lblTitulo1 runat="server" CssClass="TituloPrincipal"></asp:label></TD></TR>
				<TR>
					<TD align="center"><IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../../imagenes/spacer.gif" width="160"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<asp:image id="ChartImage" runat="server" borderwidth="0" visible="False"></asp:image></TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
