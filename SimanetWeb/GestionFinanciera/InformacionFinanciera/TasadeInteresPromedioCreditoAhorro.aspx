<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="TasadeInteresPromedioCreditoAhorro.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.InformacionFinanciera.TasadeInteresPromedioCreditoAhorro" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td style="HEIGHT: 4px" width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 3px" vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 2px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Información Financiera</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%" height="100%"><IFRAME id="myContent" style="WIDTH: 100%; HEIGHT: 95%" align="middle" frameBorder="no"
							scrolling="auto" runat="server"> </IFRAME>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="right" width="100%" height="100%"><asp:imagebutton id="ibtnCancelar" runat="server" ImageUrl="../../imagenes/atras.gif" CausesValidation="False"></asp:imagebutton></TD>
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
