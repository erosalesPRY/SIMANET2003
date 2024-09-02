<%@ Page language="c#" Codebehind="AdministrarDisenodeInforme.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Informes.AdministrarDisenodeInforme" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td>
						<uc1:Header id="Header1" runat="server"></uc1:Header></td>
				</tr>
				<tr>
					<td vAlign="top" bgColor="#eff7fa">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Reportes></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Diseñar reporte</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
					</TD>
				</TR>
			</table>
		</form>
	</body>
</HTML>
