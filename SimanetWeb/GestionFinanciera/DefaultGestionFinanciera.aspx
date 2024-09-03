<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DefaultGestionFinanciera.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DefaultGestionFinanciera" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML xmlns:mbrsc>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="js/jscript.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3"><uc1:Header id="Header1" runat="server"></uc1:Header>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="15%" bgColor="#f6f6f6"><uc1:Menu id="Menu1" runat="server"></uc1:Menu><br>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="85%">&nbsp;
					</td>
				</tr>
				<TR align="center">
					<TD bgColor="#5891ae" colSpan="3"><asp:label id="lblTexto" runat="server" CssClass="TextoFooter">© SIMA 2004</asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		</TD></TR>
	</body>
</HTML>
