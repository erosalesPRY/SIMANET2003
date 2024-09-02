<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="VentasPresupuestadaAcumuadaLineaNegocio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.VentasPresupuestadaAcumuadaLineaNegocio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>VentasPresupuestadaAcumuadaLineaNegocio</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/swfobject.js"></SCRIPT>
		<script>
			function mostrar()
			{
				window.open("PopupImpresionVentasPresupuestadaAcumuadaLineaNegocio.aspx","MIDATA","width=750,height=500");
			}
		</script>
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
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Grafico Comparativo por Linea de Negocio</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTituloAno1" runat="server" CssClass="TituloPrincipal"></asp:label><asp:label id="lblTituloAno" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="right">
									<TABLE class="tabla" id="Table7" style="WIDTH: 248px; HEIGHT: 29px" cellSpacing="0" cellPadding="0"
										width="248" align="left" bgColor="#f5f5f5" border="0">
										<TR>
											<TD style="WIDTH: 126px">
												<asp:label id="lblTipo" runat="server" CssClass="normal" Width="72px">Tipo de Sector</asp:label></TD>
											<TD class="SmallFont">
												<asp:dropdownlist id="ddlbTipo" runat="server" CssClass="normal" Width="136px" AutoPostBack="True"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" style="DISPLAY: none; FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5)"
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
									<TABLE id="Table4" style="FILTER: alpha(style=1, opacity=20, finishOpacity=70, startX=0,finishX=0, startY= 0,finishY=0); WIDTH: 47px; HEIGHT: 40px"
										cellSpacing="0" cellPadding="0" width="47" bgColor="darkgray" border="0">
										<TR>
											<TD style="WIDTH: 17px"><IMG src="/SimaNetWeb/imagenes/Otros/Bordes/HeaderLeft.gif"></TD>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/HeaderCenter.gif); BACKGROUND-REPEAT: repeat-x"></TD>
											<TD style="BACKGROUND-POSITION: right top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/HeaderRight.gif); BACKGROUND-REPEAT: no-repeat"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/CenterLeft.gif); WIDTH: 17px; BACKGROUND-REPEAT: repeat-y"></TD>
											<TD>
												<DIV id="flashcontent">x
												</DIV>
											</TD>
											<TD style="BACKGROUND-POSITION: right top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/CenterRight.gif); BACKGROUND-REPEAT: repeat-y"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-POSITION: left bottom; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterLeft.gif); WIDTH: 17px; BACKGROUND-REPEAT: no-repeat"></TD>
											<TD style="BACKGROUND-POSITION: left bottom; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterCenter.gif); BACKGROUND-REPEAT: repeat-x"></TD>
											<TD style="BACKGROUND-POSITION: right bottom; BACKGROUND-IMAGE: url(http://localhost/WebDemoIni/BORDES/FooterRight.gif); BACKGROUND-REPEAT: no-repeat"><IMG src="/SimaNetWeb/imagenes/Otros/Bordes/FooterRight.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><INPUT id="RutaArchivo" type="hidden" name="Hidden1" runat="server"><INPUT id="NombreArchivoTXT" type="hidden" name="NombreArchivoTXT" runat="server"></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script type="text/javascript">
			var oNombreArchivoTXT = $O("NombreArchivoTXT");
			var oRutaArchivo = $O("RutaArchivo");
			try{
				var so = new SWFObject(oRutaArchivo.value + "open-flash-chart.swf", "flash", ""+ (window.screen.width-80), (window.screen.height-300), "8", "#FFFFFF");
				so.addVariable("width", (window.screen.width-80));
				so.addVariable("height", (window.screen.height-300));
				so.addVariable("data",oRutaArchivo.value + oNombreArchivoTXT.value);
				so.addParam("allowScriptAccess", "sameDomain");
				so.write("flashcontent");
			}
			catch(error){}
		</script>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
