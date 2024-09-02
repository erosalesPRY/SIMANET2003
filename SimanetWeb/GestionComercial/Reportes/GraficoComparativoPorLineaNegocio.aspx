<%@ Page language="c#" Codebehind="GraficoComparativoPorLineaNegocio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.GraficoComparativoPorLineaNegocio" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
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
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Gráfico Comparativo de Ventas Colocadas</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="351" border="0" style="WIDTH: 351px; HEIGHT: 386px">
							<TR>
								<TD align="center" colSpan="6"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6">
									<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
										<TR>
											<TD>
												<asp:label id="lblVista" runat="server" CssClass="normal">Vista:</asp:label></TD>
											<TD>
												<asp:dropdownlist id="ddlbVista" runat="server" CssClass="normal" AutoPostBack="True" Width="136px"></asp:dropdownlist></TD>
											<TD>
												<asp:label id="lblTipo" runat="server" CssClass="normal">Tipo:</asp:label></TD>
											<TD width="100%">
												<asp:dropdownlist id="ddlbTipo" runat="server" CssClass="normal" AutoPostBack="True" Width="136px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6">
									<TABLE id="Table3" style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5); DISPLAY: none"
										cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ul.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"
												vAlign="top" align="right">
												<asp:image id="Image2" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/gaWindow/ul.gif"></asp:image></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/um.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ur.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ml.gif); BACKGROUND-POSITION-X: left; BACKGROUND-REPEAT: repeat-y"></TD>
											<TD>
												<asp:image id="imgCallao" runat="server" BackColor="#699FD5" borderwidth="0" visible="False"></asp:image></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/mr.gif); BACKGROUND-REPEAT: repeat-y; BACKGROUND-POSITION: left top"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/bl.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/bm.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/br.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"
												vAlign="top" align="left">
												<asp:image id="Image1" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/gaWindow/br.gif"></asp:image></TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" style="BORDER-BOTTOM: dimgray 1px; BORDER-LEFT: dimgray 1px; WIDTH: 56px; HEIGHT: 48px; BORDER-TOP: dimgray 1px; BORDER-RIGHT: dimgray 1px"
										bgColor="whitesmoke">
										<TR>
											<TD>
												<DIV id="divContextCallao" style="BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid"></DIV>
											</TD>
											<TD>
												<DIV id="divContextChimbote" style="BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid"></DIV>
											</TD>
										</TR>
										<TR>
											<TD vAlign="middle" align="center" colSpan="2" style="BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid">
												<DIV id="divContextIquitos"></DIV>
												&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6"><IMG height="8" src="../../imagenes/spacer.gif" width="360"></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6">
									<TABLE id="Table5" style="FILTER: alpha(style=1, opacity=100, finishOpacity=70, startX=0,finishX=0, startY=90,finishY=5); DISPLAY: none"
										cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ul.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"
												vAlign="top" align="right"><asp:image id="Image7" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/gaWindow/ul.gif"></asp:image></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/um.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ur.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/ml.gif); BACKGROUND-POSITION-X: left; BACKGROUND-REPEAT: repeat-y"></TD>
											<TD><asp:image id="imgIquitos" runat="server" visible="False" borderwidth="0" BackColor="#699FD5"></asp:image></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/mr.gif); BACKGROUND-REPEAT: repeat-y; BACKGROUND-POSITION: left top"></TD>
										</TR>
										<TR>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/bl.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/bm.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top"></TD>
											<TD style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/gaWindow/br.gif); BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left top"
												vAlign="top" align="left"><asp:image id="Image4" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/gaWindow/br.gif"></asp:image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" colSpan="6">
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
															<DIV id="divContextPeru"></DIV>
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
								<TD align="left" colSpan="6"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<INPUT id="RutaArchivo" type="hidden" name="RutaArchivo" runat="server"><INPUT id="NombreArchivoTXTCallao" style="WIDTH: 76px; HEIGHT: 22px" type="hidden" size="7"
							name="NombreArchivoTXTCallao" runat="server"><INPUT id="NombreArchivoTXTChimbote" style="WIDTH: 84px; HEIGHT: 22px" type="hidden" size="8"
							name="NombreArchivoTXTChimbote" runat="server"><INPUT id="NombreArchivoTXTIquitos" style="WIDTH: 83px; HEIGHT: 22px" type="hidden" size="8"
							name="NombreArchivoTXTIquitos" runat="server"><INPUT id="NombreArchivoTXTPeru" style="WIDTH: 83px; HEIGHT: 22px" type="hidden" size="8"
							name="NombreArchivoTXTPeru" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</SCRIPT>
		<script type="text/javascript">
			
			var oRutaArchivo = $O("RutaArchivo");//document.all["RutaArchivo"];
			//var Ancho= (window.screen.width-80);
			//var Alto = (window.screen.height-350);
			var Ancho= (window.screen.availWidth-80);
			var Alto = (window.screen.availHeight-550);
			
			try{
				var oNombreArchivoTXT = $O("NombreArchivoTXTCallao");//document.all["NombreArchivoTXT"];	
				var so = new SWFObject(oRutaArchivo.value + "open-flash-chart.swf", "flash", 360 , 260, "8", "#FFFFFF");
				so.addVariable("data",oRutaArchivo.value + oNombreArchivoTXT.value);
				so.write("divContextCallao");

				var oNombreArchivoTXT = $O("NombreArchivoTXTChimbote");
				var so = new SWFObject(oRutaArchivo.value + "open-flash-chart.swf", "flash", 360 , 260, "8", "#FFFFFF");
				so.addVariable("data",oRutaArchivo.value + oNombreArchivoTXT.value);
				so.write("divContextChimbote");

				var oNombreArchivoTXT = $O("NombreArchivoTXTIquitos");
				var so = new SWFObject(oRutaArchivo.value + "open-flash-chart.swf", "flash", 360 , 260, "8", "#FFFFFF");
				so.addVariable("data",oRutaArchivo.value + oNombreArchivoTXT.value);
				so.write("divContextIquitos");
				
				var oddlbVista = $O("ddlbVista");
				if(oddlbVista.selectedIndex==0){
					$O("divContextCallao").style.display="block";
					$O("divContextChimbote").style.display="block";
					$O("divContextIquitos").style.display="block";
					$O("tblPeru").style.display="none";
				}
				else{
					$O("divContextCallao").style.display="none";
					$O("divContextChimbote").style.display="none";
					$O("divContextIquitos").style.display="none";
					$O("tblPeru").style.display="block";
				}
				
				$O("ddlbVista").style.display="none";
				$O("lblVista").style.display="none";
			}
			catch(error){}

				
		</script>
	</body>
</HTML>
