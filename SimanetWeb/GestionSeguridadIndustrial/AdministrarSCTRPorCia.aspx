<%@ Page language="c#" Codebehind="AdministrarSCTRPorCia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarSCTRPorCia" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarSCTRPorCia</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13)return false" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="1" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad>Administración</asp:label>
						<asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual">>SCTR></asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
