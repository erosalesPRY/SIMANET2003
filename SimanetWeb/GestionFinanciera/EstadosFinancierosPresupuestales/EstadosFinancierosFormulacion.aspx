<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="EstadosFinancierosFormulacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.EstadosFinancierosFormulacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
			<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema>
			<LINK href="../../styles.css" type=text/css rel=stylesheet >
			<LINK href="../../Stylos/Temas.css" type=text/css rel=stylesheet >
				<SCRIPT language=javascript src="../../js/JSFrameworkSima.js"></SCRIPT>
				<SCRIPT language=javascript src="../../js/jscript.js"></SCRIPT>
				<SCRIPT language=javascript src="../../js/General.js"></SCRIPT>
				<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			var KEYQIDNUEVOFORMATO = "NuevoFormato";
			function VistaPrevia(e)
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oHtml = new SIMA.Utilitario.Helper.General.Html();
				/**/
				oPrinter = new SIMA.Utilitario.Helper.Prints();
				oPrinter.htmlTablaContenedora= document.all["tblCabeceraPrint"];

				/*Crea el titulo principal del reporte*/
				ohtmlFuente = oHtml.CrearFuente();
				with (ohtmlFuente)
				{
					innerText = "ESTADOS FINANCIEROS";
					setAttribute("face","arial"); 
					setAttribute("size","4");
					setAttribute("color","black");
				}
				/*Crea la Cabecera y agrega un Objeto de tipo Font*/
				oCabecera = new SIMA.Utilitario.Helper.CabeceraPagina();
				oCabecera.CenterTop(ohtmlFuente);

				ohtmlFuente = oHtml.CrearFuente();
				
				//window.alert(document.location.search);
				
				with (ohtmlFuente)
				{
					innerText = oPagina.Request.Params["NombreCentro"].toUpperCase();
					setAttribute("face","arial"); 
					setAttribute("size","2");
					setAttribute("color","black");
				}
				oCabecera.CenterCenter(ohtmlFuente);
				
				ohtmlFuente = oHtml.CrearFuente();
				with (ohtmlFuente)
				{
					innerText = "PERIODO :" + oPagina.Request.Params["NombreMes"] + " DEL " + oPagina.Request.Params["efFecha"].split('/')[2] ;
					setAttribute("face","arial"); 
					setAttribute("size","2");
					setAttribute("color","black");
				}
				oCabecera.CenterDown(ohtmlFuente);


				//Adicion al cabcera configurada
				oPrinter.ConfigurarCabecera(oCabecera);
				
				oPrinter.VistaPrevia(e,Cabecera,FilaMenu,FilaToolBar,CeldaAbajo);
			}	
			
			/**/
			function OcultarCabecerayMenu()
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if (oPagina.Request.Params[KEYQIDNUEVOFORMATO]=="true")
				{
					oHeader = document.all["Cabecera"];
					oMenu = document.all["FilaMenu"];
					oibtnImprimir = document.all["ImgImprimir"];
					oibtnAtras = document.all["ibtnAtras"];
					oRuta = document.all["Ruta"];
					oHeader.style.display = "none";
					oMenu.style.display = "none";
					oRuta.style.display = "none";
					oibtnImprimir.style.display = "none";
					oibtnAtras.src =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/imagenes/RetornarAlFormato.GIF";
					oibtnAtras.parentElement.align = "right";
				}
			}			
		</script>
</HEAD>
<body bottomMargin=0 leftMargin=0 topMargin=0 onload="OcultarCabecerayMenu();ObtenerHistorial2();"
rightMargin=0 onunload=SubirHistorial();>
<form id=Form1 method=post runat="server">
<table id ="tblCabeceraPrint" cellSpacing=0 cellPadding=1 width="100%" align=center border=0>
  <tr id=Cabecera>
    <td width="100%" colSpan=3><uc1:header id=Header1 runat="server"></uc1:header></td></tr>
  <TR id=FilaMenu>
    <TD width="100%" colSpan=3><uc1:menu id=Menu1 runat="server"></uc1:menu></TD></TR>
  <TR id="Ruta">
    <TD class=RutaPaginaActual width="100%" colSpan=3><asp:label id=lblRutaPagina runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera Presupuestales > Estados Financieros></asp:label><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD></TR>
  <TR>
    <TD align=center colSpan=3>
      <TABLE id=Table1 cellSpacing=1 cellPadding=1 width="100%" border=0 
      >
        <TR>
          <TD width="100%">
            <TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%" border=0 
            >
              <TR id=FilaToolBar bgColor=#f0f0f0>
                <TD style="WIDTH: 9px"><IMG height=22 src="../../imagenes/tab_izq.gif" width=4 ></TD>
                <TD style="WIDTH: 70px"><asp:label id=Label3 runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" Width="65px" ForeColor="Navy">PERIODO :</asp:label></TD>
                <TD style="WIDTH: 1px" vAlign=middle><asp:label id=lblPeriodo runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" Width="32px" ForeColor="Navy">2005</asp:label></TD>
                <TD align=center width="100%"><asp:label id=Label1 runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" Width="363px" ForeColor="Navy">EN MILES DE NUEVOS SOLES</asp:label></TD>
                <td><IMG id=ImgImprimir onclick=VistaPrevia(this); alt="" src="../../imagenes/bt_imprimir.gif" ></td>
                <TD align=right width=4><IMG height=22 src="../../imagenes/tab_der.gif" width=4 ></TD></TR></TABLE><cc1:datagridweb id=grid runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" DataKeyField="IdRubro">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PEnero" SortExpression="PEnero" HeaderText="ENE">
<HeaderStyle HorizontalAlign="Center" Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PFebrero" SortExpression="PFebrero" HeaderText="FEB">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PMarzo" SortExpression="PMarzo" HeaderText="MAR">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PAbril" SortExpression="PAbril" HeaderText="ABR">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PMayo" SortExpression="PMayo" HeaderText="MAY">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PJunio" SortExpression="PJunio" HeaderText="JUN">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PJulio" SortExpression="PJulio" HeaderText="JUL">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PAgosto" SortExpression="PAgosto" HeaderText="AGO">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PSetiembre" SortExpression="PSetiembre" HeaderText="SET">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="POctubre" SortExpression="POctubre" HeaderText="OCT">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PNoviembre" SortExpression="PNoviembre" HeaderText="NOV">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="PDiciembre" SortExpression="PDiciembre" HeaderText="DIC">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn HeaderText="TOTAL">
<HeaderStyle Width="5.3%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb></TD></TR>
        <TR id=CeldaAbajo>
          <TD ><INPUT id=objHistorial 
            style="WIDTH: 96px; HEIGHT: 16px" type=hidden size=10 
            ><asp:imagebutton id=ibtnImprimir runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></TD></TR>
        <TR>
          <TD></TD></TR></TABLE></TD></TR>
  <TR>
    <TD align=center colSpan=3>
      <TABLE id=Table2 style="HEIGHT: 26px" cellSpacing=1 
      cellPadding=1 width="100%" border=0>
        <TR>
          <TD><IMG id=ibtnAtras style="CURSOR: hand" 
            onclick=ReemplazaHistorial();HistorialIrAtras(); alt="" 
            src="../../imagenes/atras.gif"></TD></TR></TABLE></TD></TR></table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
</form>
	</body>
</HTML>
