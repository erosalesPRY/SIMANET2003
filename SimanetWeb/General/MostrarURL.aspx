<%@ Page language="c#" Codebehind="MostrarURL.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.MostrarURLaspx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MostrarURLaspx</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="1"><uc1:header id="Header2" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 2px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informativo></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Información</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%" height="100%"><IFRAME id="myContent" style="WIDTH: 100%; HEIGHT: 95%" align="middle" frameBorder="no"
							scrolling="auto" runat="server"> </IFRAME>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right" width="100%" height="100%"><asp:imagebutton id="ibtnAtras" runat="server" CausesValidation="False" ImageUrl="../imagenes/atras.gif"></asp:imagebutton></TD>
				</TR>
				<tr>
					<td vAlign="top" width="592"></td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
