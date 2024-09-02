<%@ Page language="c#" Codebehind="GraficoVentasPresupuestadasporTipoCliente.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.GraficoVentasPresupuestadasporTipoCliente" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>GraficoVentasPresupuestadasporTipoCliente</title>
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
					<TD align="center"><IMG style="WIDTH: 360px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="360"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" border="0">
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
												<DIV id="flashcontent">&nbsp;</DIV>
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
          <TD align=center><IMG style="WIDTH: 360px; HEIGHT: 7px" height=7 
            src="../../imagenes/spacer.gif" width=360></TD></TR>
							<TR>
								<TD align="center"><cc1:datagridweb id="dgConsulta" runat="server" CssClass="HeaderGrilla" ShowFooter="True" Width="200px"
										RowPositionEnabled="False" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" PageSize="1">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="TIPOCLIENTE" HeaderText="TIPO CLIENTE">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PORCENTAJE" HeaderText="PORCENTAJE %" FooterText="100%" DataFormatString="{0:###,##0.00}">
												<HeaderStyle Width="17%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="RutaArchivo" type="hidden" name="Hidden1" runat="server"><INPUT id="NombreArchivoTXT" type="hidden" name="NombreArchivoTXT" runat="server"></TD>
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
				so.addVariable("height", (window.screen.height-400));
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
