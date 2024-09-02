<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="GraficoVentasRealesCorporativas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.GraficoVentasRealesCorporativas" %>
<!doctype HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Visual</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/swfobject.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Visual" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Gráfico de Ventas Colocadas Corporativa</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" style="WIDTH: 780px; HEIGHT: 128px" cellSpacing="0" cellPadding="0"
							width="780" border="0">
							<TR>
								<TD align="right">
									<TABLE class="tabla" id="Table7" cellSpacing="0" cellPadding="0" width="200" align="left"
										border="0">
										<TR>
											<TD><asp:label id="lblTipo" runat="server" CssClass="normal">Tipo</asp:label></TD>
											<TD class="SmallFont"><asp:dropdownlist id="ddlbTipo" runat="server" CssClass="normal" AutoPostBack="True" Width="136px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="tblPeru" style="FILTER: alpha(style=1, opacity=20, finishOpacity=70, startX=0,finishX=0, startY= 0,finishY=0); WIDTH: 47px; HEIGHT: 40px"
										cellSpacing="0" cellPadding="0" width="47" bgColor="darkgray" border="0">
										<TR>
											<TD style="WIDTH: 17px"><IMG src="/SimaNetWeb/imagenes/Otros/Bordes/HeaderLeft.gif"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/HeaderCenter.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/HeaderRight.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: right top"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/CenterLeft.gif); WIDTH: 17px; BACKGROUND-REPEAT: repeat-y; BACKGROUND-POSITION: left top"></TD>
											<TD>
												<TABLE id="Table8" style="BORDER-BOTTOM: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-RIGHT: black 1px solid">
													<TR>
														<TD>
															<DIV id="divContextGraph"></DIV>
														</TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/CenterRight.gif); BACKGROUND-REPEAT: repeat-y; BACKGROUND-POSITION: right top"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterLeft.gif); WIDTH: 17px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left bottom"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterCenter.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left bottom"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterRight.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: right bottom"><IMG src="/SimaNetWeb/imagenes/Otros/Bordes/FooterRight.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="NombreArchivoConfig" type="hidden" runat="server"><INPUT id="RutaArchivo" type="hidden" name="RutaArchivo" runat="server"><INPUT id="NombreArchivoData" style="WIDTH: 76px; HEIGHT: 22px" type="hidden" size="7"
										runat="server">
									<div id="dvCrak"></div>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
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
			so.write("divContextGraph");

			(new SWFObject(PathGeneral + "color.swf", "ampie", "142", "20", "8", "#D6D6D6")).write("dvCrak");

			// ]]>
				(function(){
					var xLeft = ((window.screen.height>600)?"27px":"32px")
					var oDvCrak = $O("dvCrak");
					oDvCrak.style.position = "absolute";
					oDvCrak.style.left =xLeft;
					oDvCrak.style.top ="185px"
				})()
		</script>
	</body>
</HTML>
