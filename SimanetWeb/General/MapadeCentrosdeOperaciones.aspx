<%@ Page language="c#" Codebehind="MapadeCentrosdeOperaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.MapadeCentrosdeOperaciones" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML 
xmlns:mbrsc>
  <HEAD>
		<title>SIMANET</title>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../styles.css" type=text/css rel=stylesheet >
<SCRIPT language=javascript src="../js/jscript.js"></SCRIPT>

<SCRIPT language=javascript src="../js/General.js"></SCRIPT>

<script language=JavaScript1.2>

				function high(which2){
				theobject=which2
				highlighting=setInterval("highlightit(theobject)",50)
				}
				function low(which2){
				clearInterval(highlighting)
				which2.filters.alpha.opacity=20
				}



				function highlightit(cur2){
				if (cur2.filters.alpha.opacity<100)
				cur2.filters.alpha.opacity+=5
				else if (window.highlighting)
				clearInterval(highlighting)
				}
		</script>

<script language=JavaScript>
<!--
function MM_findObj(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}

function MM_swapImage() { //v3.0
  var i,j=0,x,a=MM_swapImage.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
     
}
function MM_swapImgRestore() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages() { //v3.0
 var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
   var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
   if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function UbicarMenu(strid,strVisible)
{
	var obj = document.all["MenuCentro"];
	var objCentroCh = document.all["trChimbote"];
	var objCentroC = document.all["trCallao"];
	
   if (strid=="PeruCallao")
   {
		obj.style.visibility=strVisible;
		objCentroCh.style.visibility="hidden";
		objCentroC.style.visibility="visible";
	}
	else if(strid=="PeruChimbote")
	{
		obj.style.visibility=strVisible;
		objCentroCh.style.visibility="visible";
		objCentroC.style.visibility="hidden";
	}
	else
	{
		obj.style.visibility="hidden";
		objCentroCh.style.visibility="hidden";
		objCentroC.style.visibility="hidden";
	}
	obj.style.left = window.event.x;
	obj.style.top = window.event.y;
}
//-->
		</script>
</HEAD>
<body oncontextmenu="return false" bottomMargin=0 bgColor=#ffffff leftMargin=0 
topMargin=0 
onload="MM_preloadImages('imagenes/SimaPeru_r2_c4_f2.gif','imagenes/SimaPeru_r5_c2_f2.gif','imagenes/SimaPeru_r7_c3_f2.gif');" 
rightMargin=0>
<form id=Form1 method=post runat="server">
<table cellSpacing=0 cellPadding=0 width="100%" align=center border=0>
  <tr>
    <td width="100%" colSpan=1><uc1:header id=Header1 runat="server"></uc1:header></TD></TR>
  <tr>
    <td vAlign=top width="100%" bgColor=#eff7fa><uc1:menu id=Menu1 runat="server"></uc1:menu></TD></TR>
  <TR>
    <TD class=RutaPaginaActual style="HEIGHT: 14px" vAlign=top width="100%" 
    ><asp:label id=lblRutaPagina runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera> Información Financiera ></asp:label><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> Tipo de Cambio</asp:label></TD></TR>
  <TR>
    <TD style="HEIGHT: 14px" vAlign=top width="100%"><IMG style="WIDTH: 160px; HEIGHT: 8px" height=8 src="../imagenes/spacer.gif" width=160 ></TD></TR>
				<!--AQUI VA EL MAPA Y SU CONFIGURACION LINEA DE INICIO 56 AL 109-->
  <TR>
    <TD vAlign=top align=center width="100%">
      <table id=htmlMapa style="FILTER: alpha(opacity=100)" cellSpacing=0 
      cellPadding=0 width=760 border=0>
							<!-- fwtable fwsrc="PeruAnimado.png" fwbase="SimaPeru.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
        <tr>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=275 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=14 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=18 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=26 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=11 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=38 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=107 border=0 ></TD>
          <td><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=271 border=0 ></TD>
          <td style="WIDTH: 2px"><IMG height=1 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td colSpan=8><IMG height=81 alt="" src="../imagenes/CentrosOp/SimaPeru_r1_c1.gif" width=760 border=0 name=SimaPeru_r1_c1 ></TD>
          <td style="WIDTH: 2px"><IMG height=81 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td colSpan=3 rowSpan=3><IMG height=103 alt="" src="../imagenes/CentrosOp/SimaPeru_r2_c1.gif" width=307 border=0 name=SimaPeru_r2_c1 ></TD>
          <td colSpan=4 rowSpan=2><A onmouseover="UbicarMenu('','visible');MM_swapImage('SimaPeru_r2_c4','','../imagenes/CentrosOp/SimaPeru_r2_c4_f2.gif',1);" onmouseout="UbicarMenu('','hidden');MM_swapImgRestore();" href="#" ><IMG height=101 alt="" src="../imagenes/CentrosOp/SimaPeru_r2_c4.gif" width=182 border=0 name=SimaPeru_r2_c4 ></A></TD>
          <td rowSpan=7><IMG height=379 alt="" src="../imagenes/CentrosOp/SimaPeru_r2_c8.gif" width=271 border=0 name=SimaPeru_r2_c8 ></TD>
          <td style="WIDTH: 2px"><IMG height=2 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td style="WIDTH: 2px"><IMG height=99 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td colSpan=4><IMG height=2 alt="" src="../imagenes/CentrosOp/SimaPeru_r4_c4.gif" width=182 border=0 name=SimaPeru_r4_c4 ></TD>
          <td style="WIDTH: 2px"><IMG height=2 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td rowSpan=4><IMG height=276 alt="" src="../imagenes/CentrosOp/SimaPeru_r5_c1.gif" width=275 border=0 name=SimaPeru_r5_c1 ></TD>
          <td colSpan=3><A onmouseover="UbicarMenu('PeruChimbote','visible');MM_swapImage('SimaPeru_r5_c2','','../imagenes/CentrosOp/SimaPeru_r5_c2_f2.gif',1);" onmouseout="UbicarMenu('PeruChimbote','hidden');MM_swapImgRestore();" href="#" ><IMG height=28 alt="" src="../imagenes/CentrosOp/SimaPeru_r5_c2.gif" width=58 border=0 name=SimaPeru_r5_c2 ></A></TD>
          <td colSpan=3 rowSpan=2><IMG height=32 alt="" src="../imagenes/CentrosOp/SimaPeru_r5_c5.gif" width=156 border=0 name=SimaPeru_r5_c5 ></TD>
          <td style="WIDTH: 2px"><IMG height=28 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td colSpan=3><IMG height=4 alt="" src="../imagenes/CentrosOp/SimaPeru_r6_c2.gif" width=58 border=0 name=SimaPeru_r6_c2 ></TD>
          <td style="WIDTH: 2px"><IMG height=4 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td rowSpan=2><IMG height=244 alt="" src="../imagenes/CentrosOp/SimaPeru_r7_c2.gif" width=14 border=0 name=SimaPeru_r7_c2 ></TD>
          <td colSpan=4><A onclick="UbicarMenu('PeruCallao','Visible');" onmouseover="MM_swapImage('SimaPeru_r7_c3','','../imagenes/CentrosOp/SimaPeru_r7_c3_f2.gif',1);" onmouseout="MM_swapImgRestore();" href="#" ><IMG height=63 alt="" src="../imagenes/CentrosOp/SimaPeru_r7_c3.gif" width=93 border=0 name=SimaPeru_r7_c3 ></A></TD>
          <td rowSpan=2><IMG height=244 alt="" src="../imagenes/CentrosOp/SimaPeru_r7_c7.gif" width=107 border=0 name=SimaPeru_r7_c7 ></TD>
          <td style="WIDTH: 2px"><IMG height=63 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR>
        <tr>
          <td colSpan=4><IMG height=181 alt="" src="../imagenes/CentrosOp/SimaPeru_r8_c3.gif" width=93 border=0 name=SimaPeru_r8_c3 ></TD>
          <td style="WIDTH: 2px"><IMG height=181 alt="" src="../imagenes/CentrosOp/spacer.gif" width=1 border=0 ></TD></TR></TABLE></TD></TR>
  <TR>
    <TD vAlign=top align=center width="100%"><asp:label id=lblResultado runat="server" CssClass="ResultadoBusqueda"></asp:label></TD></TR>
  <TR>
    <TD vAlign=top width=592><IMG height=5 src="../imagenes/spacer.gif" width=592 > 
      <div class=U id=MenuCentro 
      style="LEFT: 40px; BACKGROUND-IMAGE: url(http://localhost/SimaNetWeb/imagenes/FranjaMenu.gif); WIDTH: 150px; BACKGROUND-REPEAT: repeat-y; POSITION: absolute; TOP: 400px" 
      >
      <TABLE id=Table1 cellSpacing=1 cellPadding=1 width=208 border=0 
      >
        <TR class=W id=trPeru onmouseover=oPopupMenu.MouseOver(this); 
        onmouseout=oPopupMenu.MouseOut(this);>
          <TD style="WIDTH: 40px; HEIGHT: 22px"></TD>
          <TD style="HEIGHT: 22px">SIMA PERU</TD></TR>
        <TR class=W id=trCallao onmouseover=oPopupMenu.MouseOver(this); 
        onmouseout=oPopupMenu.MouseOut(this);>
          <TD style="WIDTH: 40px"></TD>
          <TD>SIMA CALLAO</TD></TR>
        <TR class=W id=trChimbote onmouseover=oPopupMenu.MouseOver(this); 
        onmouseout=oPopupMenu.MouseOut(this);>
          <TD style="WIDTH: 40px"></TD>
          <TD>SIMA 
  CHIMBOTE</TD></TR></TABLE></DIV></TD></TR></TABLE>&nbsp; </FORM>
<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>

	</body>
</HTML>
