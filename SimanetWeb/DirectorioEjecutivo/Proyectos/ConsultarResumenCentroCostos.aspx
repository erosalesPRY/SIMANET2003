<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarResumenCentroCostos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos.ConsultarResumenCentroCostos" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
<meta name=vs_targetSchema content=http://schemas.microsoft.com/intellisense/ie5><LINK rel=stylesheet type=text/css href="../../styles.css" >
<SCRIPT language=javascript src="../../js/@Import.js"></SCRIPT>
</HEAD>
<body oncontextmenu="return false" onunload=SubirHistorial(); 
onload=ObtenerHistorial(); bottomMargin=0 leftMargin=0 rightMargin=0 topMargin=0>
<form id=Form1 method=post runat="server">
<table border=0 cellSpacing=0 cellPadding=0 width="100%" align=center>
  <tr>
    <td width="100%"><uc1:header id=Header1 runat="server"></uc1:header></td></tr>
  <tr>
    <td bgColor=#eff7fa vAlign=top width="100%"><uc1:menu id=Menu1 runat="server"></uc1:menu></td></tr>
  <TR>
    <TD class=RutaPaginaActual vAlign=top width="100%"><asp:label id=lblRutaPagina runat="server" CssClass="RutaPagina">Inicio > Logística ></asp:label><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> Consultar Resumen Centros de Costo</asp:label></TD></TR>
  <TR>
    <TD vAlign=top width="100%" align=center>
      <TABLE id=Table1 class=normal border=0 cellSpacing=0 cellPadding=0 
      width="100%" DESIGNTIMEDRAGDROP="26">
        <TR>
          <TD width="100%" colSpan=3 align=center>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width="100%" 
            ></TABLE><cc1:datagridweb id=grid runat="server" PageSize="7" ShowFooter="True" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Width="778px">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle Font-Size="X-Small" Font-Bold="True" HorizontalAlign="Right" CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NOM_COD_CC" SortExpression="NOM_COD_CC" HeaderText="CENTRO DE COSTO">
<HeaderStyle Width="40%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="OC" SortExpression="OC" HeaderText="&#211;RDENES COMPRA &lt;br&gt;(S/.)" DataFormatString="{0:###,##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="OS" SortExpression="OS" HeaderText="&#211;RDENES SERVICIO&lt;br&gt;(S/.)" DataFormatString="{0:###,##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TOTAL" SortExpression="TOTAL" HeaderText="TOTAL&lt;br&gt;(S/.)" DataFormatString="{0:###,##0.00}">
<HeaderStyle Width="20%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb><asp:label id=lblResultado runat="server" CssClass="ResultadoBusqueda"></asp:label></TD></TR></TABLE></TD></TR>
  <TR>
    <TD style="HEIGHT: 17px" vAlign=top width="100%" align=center 
    >
      <TABLE style="WIDTH: 766px; HEIGHT: 26px" id=Table6 border=0 cellSpacing=1 
      cellPadding=1 width=766>
        <TR>
          <TD align=left><IMG style="CURSOR: hand" id=ibtnAtras onclick=HistorialIrAtras(); alt="" src="../../imagenes/atras.gif" ><INPUT 
            style="WIDTH: 32px; HEIGHT: 22px" id=hidCentro size=1 type=hidden 
            name=hidCentro runat="server"><INPUT 
            style="WIDTH: 16px; HEIGHT: 22px" id=hCodigo size=1 type=hidden 
            name=hCodigo runat="server" 
            DESIGNTIMEDRAGDROP="20"></TD></TR></TABLE></TD></TR>
  <tr>
    <td vAlign=top width=592></td></tr></table>&nbsp; 
</form>
<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>

	</body>
</HTML>
