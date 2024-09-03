<%@ Page language="c#" Codebehind="DefaultEstadosFinancieros2.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DefaultEstadosFinancieros2" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<LINK href="Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js">  </SCRIPT>
		<script>
			function CargarPdf()
			{
				ObjAcrobatReader = document.all["myContent"];
				ObjAcrobatReader.src = "http://simanetibmapp/simanetweb/Archivos/Contrato de Comodato Marina.pdf";
				
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="CargarPdf();ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" style="HEIGHT: 360px">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros Presupuestales></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ..</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<EMBED id="myContent" src="http://simanetibmapp/simanetweb/Archivos/Contrato de Comodato Marina.pdf"
							WIDTH="100%" HEIGHT="600" type="application/pdf"> </EMBED>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><IMG alt="" src="../imagenes/AcuerdoDirectorio_r2_c4.gif" useMap="#map1" onclick="ObtenerPunto()">&nbsp;<INPUT id="Text1" type="text" name="Text1" runat="server"></TD>
					<td>
						<MAP NAME="map1">
							<AREA SHAPE="CIRCLE" COORDS="60,56,47" HREF="#" ALT="Cabeza">
							<!--<AREA SHAPE="POLY" COORDS="3,182,36,178,44,165,60,169,66,184,62,196,43,201,35,190,0,193,0,183"
								HREF="#" ALT="Sonajero">-->
						</MAP>
					</td>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
			<INPUT id="txtPuntos" style="WIDTH: 672px; HEIGHT: 22px" type="text" size="106">
		</form>
	</body>
</HTML>
