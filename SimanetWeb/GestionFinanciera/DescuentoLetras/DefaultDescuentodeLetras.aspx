<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc3" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DefaultDescuentodeLetras.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras.DefaultDescuentodeLetras" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<!--oncontextmenu="return false" -->
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Descuento de Letras</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="middle" width="100%" align="center">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="542" border="0" style="WIDTH: 542px; HEIGHT: 112px">
							<TR>
								<TD>
									<asp:Image id="ibtnDescuentoLetrasporCobrar" runat="server" ImageUrl="../../imagenes/btnDescuentoLetrasPorCobrar.gif"
										onmouseover="this.src='../../imagenes/btnDescuentoLetrasPorCobrar_f2.gif'" onmouseout="this.src='../../imagenes/btnDescuentoLetrasPorCobrar.gif'"></asp:Image></TD>
								<TD style="WIDTH: 231px"><IMG style="WIDTH: 199px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="199"></TD>
								<TD align="right">
									<asp:Image id="ibtnDescuentoLetrasporPagar" runat="server" ImageUrl="../../imagenes/btnDescuentoLetrasPorPagar.gif"
										onmouseover="this.src='../../imagenes/btnDescuentoLetrasPorPagar_f2.gif'" onmouseout="this.src='../../imagenes/btnDescuentoLetrasPorPagar.gif'"></asp:Image></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="tblAtras" cellSpacing="1" cellPadding="1" width="543" border="0" runat="server"
							style="WIDTH: 543px; HEIGHT: 23px">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
