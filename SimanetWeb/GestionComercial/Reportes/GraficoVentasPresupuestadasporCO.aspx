<%@ Page language="c#" Codebehind="GraficoVentasPresupuestadasporCO.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.GraficoVentasPresupuestadasporCO" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>GraficoVentasPresupuestadasporCO</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Visual" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<asp:label id="lblAno" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5)"
										cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ul.gif); BACKGROUND-REPEAT: no-repeat"
												vAlign="top" align="right">
												<asp:Image id="Image2" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/gaWindow/ul.gif"></asp:Image></TD>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/um.gif); BACKGROUND-REPEAT: repeat-x"></TD>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ur.gif); BACKGROUND-REPEAT: no-repeat"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-POSITION-X: left; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ml.gif); BACKGROUND-REPEAT: repeat-y"></TD>
											<TD>
												<asp:image id="ChartImage" runat="server" visible="False" borderwidth="0" BackColor="#699FD5"></asp:image></TD>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/mr.gif); BACKGROUND-REPEAT: repeat-y"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/bl.gif); BACKGROUND-REPEAT: no-repeat"></TD>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/bm.gif); BACKGROUND-REPEAT: repeat-x"></TD>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/br.gif); BACKGROUND-REPEAT: no-repeat"
												vAlign="top" align="left">
												<asp:Image id="Image1" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/gaWindow/br.gif"></asp:Image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
