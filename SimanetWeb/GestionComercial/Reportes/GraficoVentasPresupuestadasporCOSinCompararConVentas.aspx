<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="GraficoVentasPresupuestadasporCOSinCompararConVentas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.GraficoVentasPresupuestadasporCOSinCompararConVentas" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>GraficoVentasPresupuestadasporCOSinCompararConVentas</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/swfobject.js"></SCRIPT>
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
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="644" border="0" style="WIDTH: 644px; HEIGHT: 134px">
        <TR>
          <TD align=center><IMG style="WIDTH: 130px" height=19 
            src="../../imagenes/spacer.gif" width=130></TD></TR>
							<TR>
								<TD align="center">
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
												<DIV id="flashcontent"><STRONG>You need to upgrade your Flash Player</STRONG>
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
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label>
									<div id="dvCrak"></div>
								</TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="RutaArchivo" type="hidden" name="Hidden1" runat="server"><INPUT id="NombreArchivoConfig" type="hidden" name="NombreArchivoTXT" runat="server"><INPUT id="NombreArchivoData" type="hidden" name="NombreArchivoTXT" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script type="text/javascript">
			// <![CDATA[
			var PathGeneral = $O("RutaArchivo").value;
			var PathFileXMLSetting = PathGeneral + $O("NombreArchivoConfig").value;
			var PathFileXMLData = PathGeneral + $O("NombreArchivoData").value;
			var PathFileFlash=PathGeneral + "ampie.swf";
			
			var ampie=new Object();
			var so = new SWFObject(PathFileFlash, "ampie", (window.screen.width -70), (window.screen.height -250), "8", "#D6D6D6");
			so.addVariable("path", PathGeneral);
			so.addVariable("settings_file", escape(PathFileXMLSetting));
			so.addVariable("data_file", escape(PathFileXMLData));		
			so.addVariable("preloader_color", "#999999");
			so.write("flashcontent");

			(new SWFObject(PathGeneral + "color.swf", "ampie", "142", "20", "8", "#D6D6D6")).write("dvCrak");

			// ]]>
				(function(){
					var xLeft = ((window.screen.height>600)?"27px":"32px")
					var oDvCrak = $O("dvCrak");
					oDvCrak.style.position = "absolute";
					oDvCrak.style.left =xLeft;
					oDvCrak.style.top ="170px"				
				})()
		</script>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
