<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="GraficoPresupuestoIniciaYFinalYVentasPorPeriodo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Reportes.GraficoPresupuestoIniciaYFinalYVentasPorPeriodo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>GraficoVentasVSPresupuestoPorPeriodo</title>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../styles.css" type=text/css rel=stylesheet >
<SCRIPT language=javascript src="../../js/General.js"></SCRIPT>

<SCRIPT language=javascript src="../../js/swfobject.js"></SCRIPT>

<SCRIPT language=javascript src="../../js/Historial.js"></SCRIPT>
</HEAD>
<body bottomMargin=0 leftMargin=0 topMargin=0 onload=ObtenerHistorial(); 
onunload=SubirHistorial();>
<form id=Visual method=post runat="server">
<TABLE id=Table1 cellSpacing=0 cellPadding=0 width="100%" border=0>
  <TR>
    <TD vAlign=top align=left>
      <TABLE id=Table2 cellSpacing=0 cellPadding=0 width="100%" border=0 
      >
        <TR>
          <TD align=left><uc1:header id=Header1 runat="server"></uc1:header></TD></TR>
        <TR>
          <TD align=left><uc1:menu id=Menu1 runat="server"></uc1:menu></TD></TR>
        <TR>
          <TD class=RutaPaginaActual align=left><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos por Grupos de Centros de Costos</asp:label><asp:label id=lblRutaPagina runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label></TD></TR>
        <TR>
          <TD align=center><IMG style="WIDTH: 160px; HEIGHT: 16px" height=16 src="../../imagenes/spacer.gif" width=160 ></TD></TR>
        <TR>
          <TD align=center>
            <TABLE id=Table4 
            style="FILTER: alpha(style=1, opacity=20, finishOpacity=70, startX=0,finishX=0, startY= 0,finishY=0); WIDTH: 47px; HEIGHT: 40px" 
            cellSpacing=0 cellPadding=0 width=47 bgColor=darkgray border=0 
            >
              <TR>
                <TD style="WIDTH: 17px"><IMG src="/SimaNetWeb/imagenes/Otros/Bordes/HeaderLeft.gif" ></TD>
                <TD 
                style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/HeaderCenter.gif); BACKGROUND-REPEAT: repeat-x" 
                ></TD>
                <TD 
                style="BACKGROUND-POSITION: right top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/HeaderRight.gif); BACKGROUND-REPEAT: no-repeat" 
                ></TD></TR>
              <TR>
                <TD 
                style="BACKGROUND-POSITION: left top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/CenterLeft.gif); WIDTH: 17px; BACKGROUND-REPEAT: repeat-y" 
                ></TD>
                <TD>
                  <table 
                  style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid" 
                  >
                    <tr>
                      <td>
                        <div id=divContext 
                    ></DIV></TD></TR></TABLE></TD>
                <TD 
                style="BACKGROUND-POSITION: right top; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/CenterRight.gif); BACKGROUND-REPEAT: repeat-y" 
                ></TD></TR>
              <TR>
                <TD 
                style="BACKGROUND-POSITION: left bottom; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterLeft.gif); WIDTH: 17px; BACKGROUND-REPEAT: no-repeat" 
                ></TD>
                <TD 
                style="BACKGROUND-POSITION: left bottom; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterCenter.gif); BACKGROUND-REPEAT: repeat-x" 
                ></TD>
                <TD 
                style="BACKGROUND-POSITION: right bottom; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/Bordes/FooterRight.gif); BACKGROUND-REPEAT: no-repeat" 
                ><IMG src="/SimaNetWeb/imagenes/Otros/Bordes/FooterRight.gif" ></TD></TR></TABLE>
            <DIV id=dvCrak></DIV></TD></TR>
        <TR>
          <TD align=center><INPUT id=hPPTOColor 
            type=hidden value=#ffff33 runat="server"><INPUT 
            id=hVentaColor type=hidden value=#660000 
            runat="server"><IMG style="WIDTH: 160px; HEIGHT: 16px" height=16 src="../../imagenes/spacer.gif" width=160 ><INPUT id=RutaArchivo 
            type=hidden name=Hidden1 runat="server"><INPUT 
            id=NombreArchivoTXT type=hidden name=NombreArchivoTXT 
             runat="server"></TD></TR>
        <TR>
          <TD align=center><asp:label id=lblResultado runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD></TR></TABLE><IMG id=ibtnAtras onclick=HistorialIrAtras(); alt="" src="../../imagenes/atras.gif" >&nbsp; 
</TD></TR></TABLE></FORM>
<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>

<script type=text/javascript>
			var oNombreArchivoTXT =$O("NombreArchivoTXT");
			var oRutaArchivo = $O("RutaArchivo");
			try{
				var so = new SWFObject(oRutaArchivo.value + "open-flash-chart.swf", "flash", ""+ (window.screen.width-80), (window.screen.height-300), "8", "#FFFFFF");
				so.addVariable("width", (window.screen.width-80));
				so.addVariable("height", (window.screen.height-300));
				so.addVariable("data",oRutaArchivo.value + oNombreArchivoTXT.value);
				so.addParam("allowScriptAccess", "sameDomain");
				so.write("divContext");
			}
			catch(error){}

				
		</script>

	</body>
</HTML>
