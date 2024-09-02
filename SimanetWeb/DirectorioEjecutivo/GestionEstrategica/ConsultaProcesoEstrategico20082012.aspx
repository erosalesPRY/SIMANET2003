<%@ Page language="c#" Codebehind="ConsultaProcesoEstrategico20082012.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaProcesoEstrategico20082012" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaProcesoEstrategico</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script language="JavaScript" type="text/javascript">
<!--
function MM_findObj2(n, d) { //v4.01
  var p,i,x;  if(!d) d=document; if((p=n.indexOf("?"))>0&&parent.frames.length) {
    d=parent.frames[n.substring(p+1)].document; n=n.substring(0,p);}
  if(!(x=d[n])&&d.all) x=d.all[n]; for (i=0;!x&&i<d.forms.length;i++) x=d.forms[i][n];
  for(i=0;!x&&d.layers&&i<d.layers.length;i++) x=MM_findObj2(n,d.layers[i].document);
  if(!x && d.getElementById) x=d.getElementById(n); return x;
}
function MM_swapImage2() { //v3.0
  var i,j=0,x,a=MM_swapImage2.arguments; document.MM_sr=new Array; for(i=0;i<(a.length-2);i+=3)
   if ((x=MM_findObj2(a[i]))!=null){document.MM_sr[j++]=x; if(!x.oSrc) x.oSrc=x.src; x.src=a[i+2];}
}
function MM_swapImgRestore2() { //v3.0
  var i,x,a=document.MM_sr; for(i=0;a&&i<a.length&&(x=a[i])&&x.oSrc;i++) x.src=x.oSrc;
}

function MM_preloadImages2() { //v3.0
 var d=document; if(d.images){ if(!d.MM_p) d.MM_p=new Array();
   var i,j=d.MM_p.length,a=MM_preloadImages.arguments; for(i=0; i<a.length; i++)
   if (a[i].indexOf("#")!=0){ d.MM_p[j]=new Image; d.MM_p[j++].src=a[i];}}
}

function mmLoadMenus2() {
  if (window.mm_menu_0916230029_0) return;
  window.mm_menu_0916230029_0 = new Menu("root",142,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0916230029_0.addMenuItem("Establecer&nbsp;Temas&nbsp;Estrat&eacute;gicos","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230029_0.addMenuItem("Formular&nbsp;Objetivos&nbsp;Estrat&eacute;gicos","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230029_0.addMenuItem("Alineamiento&nbsp;Estrat&eacute;gico","alert('EN CONSTRUCCIÓN');");
   mm_menu_0916230029_0.hideOnMouseOut=true;
   mm_menu_0916230029_0.menuBorder=0;
   mm_menu_0916230029_0.menuLiteBgColor='#ffffff';
   mm_menu_0916230029_0.menuBorderBgColor='#555555';
   mm_menu_0916230029_0.bgColor='#555555';
  window.mm_menu_0916230142_2 = new Menu("root",114,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0916230142_2.addMenuItem("Matriz&nbsp;de&nbsp;Estrategias","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230142_2.addMenuItem("Plan&nbsp;Estrat&eacute;gico","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230142_2.addMenuItem("Indicadores&nbsp;de&nbsp;Gesti&oacute;n","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230142_2.addMenuItem("Tablero&nbsp;de&nbsp;Mando&nbsp;Integral","alert('EN CONSTRUCCIÓN');");
   mm_menu_0916230142_2.hideOnMouseOut=true;
   mm_menu_0916230142_2.menuBorder=0;
   mm_menu_0916230142_2.menuLiteBgColor='#ffffff';
   mm_menu_0916230142_2.menuBorderBgColor='#555555';
   mm_menu_0916230142_2.bgColor='#555555';
    window.mm_menu_0916222953_0_1 = new Menu("Identidad",104,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,0,0,true,false,true,0,true,true);
    mm_menu_0916222953_0_1.addMenuItem("Rese&ntilde;a&nbsp;Hist&oacute;rica","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208AIDENTIDAD_RESEÑA.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Escudo","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208BIDENTIDAD_ESCUDO.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Lema","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208CLEMA.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Logotipo","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208DLOGOTIPO.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Himno","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208EHIMNO.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Valse","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208FVALSE.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Polca","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208GPOLCA.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Marinera","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208HMARINERA.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Mural","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208IMURAL.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Cadena&nbsp;de&nbsp;Valor","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208JCADENA_VALOR.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Mapa&nbsp;de&nbsp;Procesos","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208KMAPA_PROCESOS.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("Diagrama&nbsp;de&nbsp;Influencia","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/208LDIAGRAMA_INFLUENCIA.pdf');");
    mm_menu_0916222953_0_1.addMenuItem("L&iacute;neas&nbsp;de&nbsp;Negocio","alert('EN CONSTRUCCIÓN');");
     mm_menu_0916222953_0_1.hideOnMouseOut=true;
     mm_menu_0916222953_0_1.menuBorder=0;
     mm_menu_0916222953_0_1.menuLiteBgColor='#ffffff';
     mm_menu_0916222953_0_1.menuBorderBgColor='#555555';
     mm_menu_0916222953_0_1.bgColor='#555555';
  window.mm_menu_0916222953_0 = new Menu("root",62,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,0,0,true,false,true,0,true,true);
  mm_menu_0916222953_0.addMenuItem("Descripci&oacute;n","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/201ROL.pdf');");
  mm_menu_0916222953_0.addMenuItem("Objeto&nbsp;Social","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/202OBJETO_SOCIAL.pdf');");
  mm_menu_0916222953_0.addMenuItem("Misi&oacute;n","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/203MISION.pdf');");
  mm_menu_0916222953_0.addMenuItem("Visi&oacute;n","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/205VISION.pdf');");
  mm_menu_0916222953_0.addMenuItem("Valores","MM_openBrWindow2('../../estrategico/planeamiento/1FILOSOFIA_EMPRESARIAL/206VALORES.pdf');");
  mm_menu_0916222953_0.addMenuItem(mm_menu_0916222953_0_1);
   mm_menu_0916222953_0.hideOnMouseOut=true;
   mm_menu_0916222953_0.childMenuIcon="../../imagenes/procestra2008_2012/arrows.gif";
   mm_menu_0916222953_0.menuBorder=0;
   mm_menu_0916222953_0.menuLiteBgColor='#ffffff';
   mm_menu_0916222953_0.menuBorderBgColor='#555555';
   mm_menu_0916222953_0.bgColor='#555555';
    window.mm_menu_0916224159_1_1 = new Menu("Lineamientos&nbsp;Estrat&eacute;gicos",88,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,0,0,true,false,true,0,true,true);
    mm_menu_0916224159_1_1.addMenuItem("De&nbsp;MINDEF","MM_openBrWindow2('#');");
    mm_menu_0916224159_1_1.addMenuItem("De&nbsp;CONGEMAR","MM_openBrWindow2('#');");
    mm_menu_0916224159_1_1.addMenuItem("De&nbsp;FONAFE","MM_openBrWindow2('#');");
    mm_menu_0916224159_1_1.addMenuItem("De&nbsp;COMOPERPAC","MM_openBrWindow2('#');");
    mm_menu_0916224159_1_1.addMenuItem("De&nbsp;COMOPERAMA","MM_openBrWindow2('#');");
    mm_menu_0916224159_1_1.addMenuItem("De&nbsp;DES","MM_openBrWindow2('../../estrategico/planeamiento/2DIAGNOSTICO_SITUACIONAL/211eLineamientos_DES.doc');");
     mm_menu_0916224159_1_1.hideOnMouseOut=true;
     mm_menu_0916224159_1_1.menuBorder=0;
     mm_menu_0916224159_1_1.menuLiteBgColor='#ffffff';
     mm_menu_0916224159_1_1.menuBorderBgColor='#555555';
     mm_menu_0916224159_1_1.bgColor='#555555';
  window.mm_menu_0916224159_1 = new Menu("root",124,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,0,0,true,false,true,0,true,true);
  mm_menu_0916224159_1.addMenuItem("Matriz&nbsp;de&nbsp;Diagnostico","MM_openBrWindow2('../../estrategico/planeamiento/2DIAGNOSTICO_SITUACIONAL/209Matriz_Diagnóstico.doc');");
  mm_menu_0916224159_1.addMenuItem("An&aacute;lisis&nbsp;Normativo","MM_openBrWindow2('../../estrategico/planeamiento/2DIAGNOSTICO_SITUACIONAL/210Analisis_Normativo.doc');");
  mm_menu_0916224159_1.addMenuItem(mm_menu_0916224159_1_1);
  mm_menu_0916224159_1.addMenuItem("Apreciaci&oacute;n&nbsp;Estrat&eacute;gica","MM_openBrWindow2('#');");
  mm_menu_0916224159_1.addMenuItem("Macro&nbsp;Entorno","MM_openBrWindow2('#');");
  mm_menu_0916224159_1.addMenuItem("Micro&nbsp;Entorno","MM_openBrWindow2('#');");
  mm_menu_0916224159_1.addMenuItem("Entorno&nbsp;Especifico","MM_openBrWindow2('#');");
  mm_menu_0916224159_1.addMenuItem("Factores&nbsp;Claves&nbsp;de&nbsp;&Eacute;xito","MM_openBrWindow2('#');");
  mm_menu_0916224159_1.addMenuItem("An&aacute;lisis&nbsp;FODA","MM_openBrWindow2('#');");
   mm_menu_0916224159_1.hideOnMouseOut=true;
   mm_menu_0916224159_1.childMenuIcon="../../imagenes/procestra2008_2012/arrows.gif";
   mm_menu_0916224159_1.menuBorder=0;
   mm_menu_0916224159_1.menuLiteBgColor='#ffffff';
   mm_menu_0916224159_1.menuBorderBgColor='#555555';
   mm_menu_0916224159_1.bgColor='#555555';
  window.mm_menu_0916230425_3 = new Menu("root",125,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,-5,7,true,false,true,0,true,true);
  mm_menu_0916230425_3.addMenuItem("Tablero&nbsp;de&nbsp;Mando","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230425_3.addMenuItem("Avance&nbsp;Plan&nbsp;Operativo","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230425_3.addMenuItem("Avance&nbsp;del&nbsp;Presupuesto","alert('EN CONSTRUCCIÓN');");
  mm_menu_0916230425_3.addMenuItem("Avance&nbsp;del&nbsp;Plan&nbsp;Estrat&eacute;gico","alert('EN CONSTRUCCIÓN');");
   mm_menu_0916230425_3.hideOnMouseOut=true;
   mm_menu_0916230425_3.menuBorder=0;
   mm_menu_0916230425_3.menuLiteBgColor='#ffffff';
   mm_menu_0916230425_3.menuBorderBgColor='#555555';
   mm_menu_0916230425_3.bgColor='#555555';
    window.mm_menu_0916230226_4_1 = new Menu("Plan<br>Operativo",27,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,0,0,true,false,true,0,true,true);
    mm_menu_0916230226_4_1.addMenuItem("2008","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_1.addMenuItem("2009","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_1.addMenuItem("2010","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_1.addMenuItem("2011","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_1.addMenuItem("2012","MM_openBrWindow2('#');");
     mm_menu_0916230226_4_1.hideOnMouseOut=true;
     mm_menu_0916230226_4_1.menuBorder=0;
     mm_menu_0916230226_4_1.menuLiteBgColor='#ffffff';
     mm_menu_0916230226_4_1.menuBorderBgColor='#555555';
     mm_menu_0916230226_4_1.bgColor='#555555';
    window.mm_menu_0916230226_4_2 = new Menu("Presupuesto<br>Anual",27,13,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","middle",2,0,1000,0,0,true,false,true,0,true,true);
    mm_menu_0916230226_4_2.addMenuItem("2008","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_2.addMenuItem("2009","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_2.addMenuItem("2010","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_2.addMenuItem("2011","MM_openBrWindow2('#');");
    mm_menu_0916230226_4_2.addMenuItem("2012","MM_openBrWindow2('#');");
     mm_menu_0916230226_4_2.hideOnMouseOut=true;
     mm_menu_0916230226_4_2.menuBorder=0;
     mm_menu_0916230226_4_2.menuLiteBgColor='#ffffff';
     mm_menu_0916230226_4_2.menuBorderBgColor='#555555';
     mm_menu_0916230226_4_2.bgColor='#555555';
  window.mm_menu_0916230226_4 = new Menu("root",65,25,"Arial, Verdana, Helvetica, sans-serif",9,"#000000","#000000","#f0f0f0","#d5eef5","left","top",2,0,1000,0,0,true,false,true,0,true,true);
  mm_menu_0916230226_4.addMenuItem(mm_menu_0916230226_4_1);
  mm_menu_0916230226_4.addMenuItem(mm_menu_0916230226_4_2);
   mm_menu_0916230226_4.hideOnMouseOut=true;
   mm_menu_0916230226_4.childMenuIcon="../../imagenes/procestra2008_2012/arrows.gif";
   mm_menu_0916230226_4.menuBorder=0;
   mm_menu_0916230226_4.menuLiteBgColor='#ffffff';
   mm_menu_0916230226_4.menuBorderBgColor='#555555';
   mm_menu_0916230226_4.bgColor='#555555';

  mm_menu_0916230226_4.writeMenus();
} // mmLoadMenus2()
function MM_openBrWindow2(theURL,winName,features) { //v2.0
var hz=window.screen.height
	if(hz==600)
		window.open(theURL, 'miwin','toolbar=yes,scrollbars=yes,resizable=yes,width=790,height=570');
	else if(hz==768)
	 	window.open(theURL, 'miwin','toolbar=yes,scrollbars=yes,resizable=yes,Width=1020,Height=705');
	else if (hz==1024)
		window.open(theURL, 'miwin','toolbar=yes,scrollbars=yes,resizable=yes,Width=1270,Height=1000');
}
//-->
		</script>
		<script language="JavaScript" src="../../js/mm_menu.js" type="text/javascript"></script>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<script language="JavaScript" type="text/javascript">mmLoadMenus2();</script>
						<table cellSpacing="0" cellPadding="0" width="640" align="center" border="0">
							<!-- fwtable fwsrc="PROEST3.png" fwbase="diagestr2008_2012.png" fwstyle="Dreamweaver" fwdocid = "351600152" fwnested="0" -->
							<tr>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="79" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="6" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="9" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="24" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="38" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="13" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="38" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="21" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="10" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="17" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="10" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="8" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="25" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="18" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="15" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="34" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="10" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="10" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="41" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="9" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="42" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="21" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="40" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="17" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="42" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="14" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="7" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="8" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="3" border="0"></td>
								<td><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="30"><IMG id="procest_2008_2012_01" height="75" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_01.png"
										width="640" border="0" name="procest_2008_2012_01"></td>
								<td><IMG height="75" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="20"><IMG id="procest_2008_2012_02" height="246" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_02.png"
										width="79" border="0" name="procest_2008_2012_02"></td>
								<td colSpan="28"><IMG id="procest_2008_2012_03" height="8" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_03.gif"
										width="558" border="0" name="procest_2008_2012_03"></td>
								<td rowSpan="23"><IMG id="procest_2008_2012_36" height="285" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_36.png"
										width="3" border="0" name="procest_2008_2012_36"></td>
								<td><IMG height="8" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="2"><IMG id="procest_2008_2012_05" height="4" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_05.gif"
										width="15" border="0" name="procest_2008_2012_05"></td>
								<td colSpan="5" rowSpan="2"><IMG id="procest_2008_2012_06" height="21" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_06.gif"
										width="134" border="0" name="procest_2008_2012_06"></td>
								<td><IMG id="procest_2008_2012_07" height="4" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_07.gif"
										width="11" border="0" name="procest_2008_2012_07"></td>
								<td colSpan="2" rowSpan="4"><IMG id="procest_2008_2012_08" height="36" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_08.gif"
										width="27" border="0" name="procest_2008_2012_08"></td>
								<td colSpan="5" rowSpan="2"><IMG id="procest_2008_2012_09" height="21" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_09.gif"
										width="76" border="0" name="procest_2008_2012_09"></td>
								<td colSpan="8" rowSpan="2"><IMG id="procest_2008_2012_10" height="21" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_10.gif"
										width="207" border="0" name="procest_2008_2012_10"></td>
								<td colSpan="3" rowSpan="2"><IMG id="procest_2008_2012_11" height="21" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_11.gif"
										width="73" border="0" name="procest_2008_2012_11"></td>
								<td rowSpan="14"><IMG id="procest_2008_2012_12" height="163" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_12.gif"
										width="7" border="0" name="procest_2008_2012_12"></td>
								<td rowSpan="19"><IMG id="procest_2008_2012_13" height="238" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_13.gif"
										width="8" border="0" name="procest_2008_2012_13"></td>
								<td><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="18"><IMG id="procest_2008_2012_14" height="234" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_14.gif"
										width="6" border="0" name="procest_2008_2012_14"></td>
								<td rowSpan="13"><IMG id="procest_2008_2012_15" height="159" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_15.gif"
										width="9" border="0" name="procest_2008_2012_15"></td>
								<td rowSpan="3"><IMG id="procest_2008_2012_21" height="32" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_21.gif"
										width="11" border="0" name="procest_2008_2012_21"></td>
								<td><IMG height="17" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="5"><IMG id="procest_2008_2012_20" height="4" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_20.gif"
										width="134" border="0" name="procest_2008_2012_20"></td>
								<td colSpan="2" rowSpan="2"><IMG id="procest_2008_2012_29" height="15" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_29.gif"
										width="18" border="0" name="procest_2008_2012_29"></td>
								<td colSpan="4" rowSpan="4"><A onmouseover="MM_showMenu(window.mm_menu_0916230029_0,92,0,null,'de_forest');MM_swapImage2('de_forest','','../../imagenes/procestra2008_2012/de_forest_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();MM_startTimeout();" href="../../estrategico/3Formulacion_Estrategica.doc"
										target="_blank"><IMG id="de_forest" height="47" alt="" src="../../imagenes/procestra2008_2012/de_forest.gif"
											width="92" border="0" name="de_forest"></A></td>
								<td colSpan="2" rowSpan="2"><IMG id="procest_2008_2012_30" height="15" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_30.gif"
										width="20" border="0" name="procest_2008_2012_30"></td>
								<td colSpan="3" rowSpan="4"><A onmouseover="MM_swapImage2('de_objes','','../../imagenes/procestra2008_2012/de_objest_f2.gif',1)"
										onmouseout="MM_swapImgRestore2()" href="../../estrategico/4Objetivos_Estrategicos.doc" target="_blank"><IMG id="de_objes" height="47" alt="" src="../../imagenes/procestra2008_2012/de_objes.gif"
											width="92" border="0" name="de_objes" runat="server"></A></td>
								<td rowSpan="2"><IMG id="procest_2008_2012_33" height="15" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_33.gif"
										width="21" border="0" name="procest_2008_2012_33"></td>
								<td colSpan="3" rowSpan="4"><A onmouseover="MM_showMenu(window.mm_menu_0916230142_2,99,0,null,'de_plapro');MM_swapImage2('de_plapro','','../../imagenes/procestra2008_2012/de_plapro_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();MM_startTimeout();" href="../../estrategico/5Planeamiento_Programatico.doc"
										target="_blank"><IMG id="de_plapro" height="47" alt="" src="../../imagenes/procestra2008_2012/de_plapro.gif"
											width="99" border="0" name="de_plapro"></A></td>
								<td rowSpan="11"><IMG id="procest_2008_2012_37" height="131" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_37.gif"
										width="14" border="0" name="procest_2008_2012_37"></td>
								<td><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="10"><IMG id="procest_2008_2012_16" height="127" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_16.gif"
										width="24" border="0" name="procest_2008_2012_16"></td>
								<td colSpan="3" rowSpan="3"><A onmouseover="MM_showMenu(window.mm_menu_0916222953_0,89,0,null,'de_filemp');MM_swapImage2('de_filemp','','../../imagenes/procestra2008_2012/de_filemp_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();MM_startTimeout();" href="../../estrategico/1Filosofia_Empresarial.doc"
										target="_blank"><IMG id="de_filemp" height="43" alt="" src="../../imagenes/procestra2008_2012/de_filemp.gif"
											width="89" border="0" name="de_filemp"></A></td>
								<td><IMG id="procest_2008_2012_22" height="11" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_22.gif"
										width="21" border="0" name="procest_2008_2012_22"></td>
								<td><IMG height="11" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="6"><IMG id="procest_2008_2012_23" height="18" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_23.gif"
										width="77" border="0" name="procest_2008_2012_23"></td>
								<td colSpan="2"><IMG id="procest_2008_2012_31" height="18" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_31.gif"
										width="20" border="0" name="procest_2008_2012_31"></td>
								<td><IMG id="procest_2008_2012_34" height="18" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_34.gif"
										width="21" border="0" name="procest_2008_2012_34"></td>
								<td><IMG height="18" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="4"><IMG id="procest_2008_2012_24" height="56" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_24.gif"
										width="21" border="0" name="procest_2008_2012_24"></td>
								<td rowSpan="9"><IMG id="procest_2008_2012_25" height="109" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_25.gif"
										width="11" border="0" name="procest_2008_2012_25"></td>
								<td colSpan="2" rowSpan="10"><IMG id="procest_2008_2012_26" height="138" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_26.gif"
										width="27" border="0" name="procest_2008_2012_26"></td>
								<td rowSpan="9"><IMG id="procest_2008_2012_27" height="109" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_27.gif"
										width="10" border="0" name="procest_2008_2012_27"></td>
								<td rowSpan="8"><IMG id="procest_2008_2012_28" height="98" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_28.gif"
										width="8" border="0" name="procest_2008_2012_28"></td>
								<td colSpan="2" rowSpan="8"><IMG id="procest_2008_2012_32" height="98" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_32.gif"
										width="20" border="0" name="procest_2008_2012_32"></td>
								<td rowSpan="3"><IMG id="procest_2008_2012_35" height="51" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_35.gif"
										width="21" border="0" name="procest_2008_2012_35"></td>
								<td><IMG height="14" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td><IMG id="procest_2008_2012_17" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_17.gif"
										width="38" border="0" name="procest_2008_2012_17"></td>
								<td><IMG id="procest_2008_2012_18" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_18.gif"
										width="13" border="0" name="procest_2008_2012_18"></td>
								<td><IMG id="procest_2008_2012_19" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_19.gif"
										width="38" border="0" name="procest_2008_2012_19"></td>
								<td colSpan="4" rowSpan="7"><IMG id="procest_2008_2012_50" height="84" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_50.gif"
										width="92" border="0" name="procest_2008_2012_50"></td>
								<td colSpan="3"><IMG id="diagestr2008_2012_r9_c20" height="26" alt="" src="../../imagenes/procestra2008_2012/diagestr2008_2012_r9_c20.gif"
										width="92" border="0" name="diagestr2008_2012_r9_c20"></td>
								<td><IMG id="procest_2008_2012_40" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_40.gif"
										width="40" border="0" name="procest_2008_2012_40"></td>
								<td><IMG id="procest_2008_2012_39" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_39.gif"
										width="17" border="0" name="procest_2008_2012_39"></td>
								<td><IMG id="procest_2008_2012_38" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_38.gif"
										width="42" border="0" name="procest_2008_2012_38"></td>
								<td><IMG height="26" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="3" rowSpan="5"><A onmouseover="MM_showMenu(window.mm_menu_0916224159_1,89,0,null,'de_diasit');MM_swapImage2('de_diasit','','../../imagenes/procestra2008_2012/de_diasit_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();MM_startTimeout();" href="../../estrategico/2Diagnostico_Situacional.doc"
										target="_blank"><IMG id="de_diasit" height="45" alt="" src="../../imagenes/procestra2008_2012/de_diasit.gif"
											width="89" border="0" name="de_diasit"></A></td>
								<td colSpan="3" rowSpan="5"><A onmouseover="MM_showMenu(window.mm_menu_0916230425_3,92,0,null,'de_segcon');MM_swapImage2('de_segcon','','../../imagenes/procestra2008_2012/de_segcon_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();MM_startTimeout();" href="../../estrategico/7Seguimiento_Evaluacion.doc"
										target="_blank"><IMG id="de_segcon" height="45" alt="" src="../../imagenes/procestra2008_2012/de_segcon.gif"
											width="92" border="0" name="de_segcon"></A></td>
								<td colSpan="3" rowSpan="5"><A onmouseover="MM_showMenu(window.mm_menu_0916230226_4,99,0,null,'de_impope');MM_swapImage2('de_impope','','../../imagenes/procestra2008_2012/de_impope_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();MM_startTimeout();" href="../../estrategico/6Implementacion_Operacional.doc"
										target="_blank"><IMG id="de_impope" height="45" alt="" src="../../imagenes/procestra2008_2012/de_impope.gif"
											width="99" border="0" name="de_impope"></A></td>
								<td><IMG height="11" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="3"><IMG id="procest_2008_2012_41" height="21" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_41.gif"
										width="21" border="0" name="procest_2008_2012_41"></td>
								<td><IMG height="5" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td><IMG id="procest_2008_2012_47" height="12" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_47.gif"
										width="21" border="0" name="procest_2008_2012_47"></td>
								<td><IMG height="12" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="3"><IMG id="procest_2008_2012_46" height="30" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_46.gif"
										width="21" border="0" name="procest_2008_2012_46"></td>
								<td><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td rowSpan="2"><IMG id="procest_2008_2012_57" height="26" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_57.gif"
										width="21" border="0" name="procest_2008_2012_57"></td>
								<td><IMG height="13" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="3"><IMG id="procest_2008_2012_42" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_42.gif"
										width="89" border="0" name="procest_2008_2012_42"></td>
								<td><IMG id="procest_2008_2012_55" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_55.gif"
										width="41" border="0" name="procest_2008_2012_55"></td>
								<td rowSpan="5"><IMG id="procest_2008_2012_59" height="79" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_59.gif"
										width="9" border="0" name="procest_2008_2012_59"></td>
								<td><IMG id="procest_2008_2012_56" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_56.gif"
										width="42" border="0" name="procest_2008_2012_56"></td>
								<td colSpan="3"><IMG id="procest_2008_2012_61" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_61.gif"
										width="99" border="0" name="procest_2008_2012_61"></td>
								<td><IMG height="13" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="5"><IMG id="procest_2008_2012_43" height="11" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_43.gif"
										width="134" border="0" name="procest_2008_2012_43"></td>
								<td colSpan="8"><IMG id="procest_2008_2012_51" height="11" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_51.gif"
										width="161" border="0" name="procest_2008_2012_51"></td>
								<td colSpan="6"><IMG id="procest_2008_2012_58" height="11" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_58.gif"
										width="176" border="0" name="procest_2008_2012_58"></td>
								<td><IMG height="11" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="3" rowSpan="5"><IMG id="procest_2008_2012_44" height="75" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_44.gif"
										width="71" border="0" name="procest_2008_2012_44"></td>
								<td rowSpan="3"><IMG id="procest_2008_2012_45" height="55" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_45.gif"
										width="13" border="0" name="procest_2008_2012_45"></td>
								<td colSpan="3" rowSpan="2"><IMG id="procest_2008_2012_48" height="42" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_48.gif"
										width="70" border="0" name="procest_2008_2012_48"></td>
								<td colSpan="3"><IMG id="procest_2008_2012_52" height="29" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_52.gif"
										width="43" border="0" name="procest_2008_2012_52"></td>
								<td><IMG id="procest_2008_2012_53" height="29" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_53.gif"
										width="18" border="0" name="procest_2008_2012_53"></td>
								<td colSpan="5"><IMG id="procest_2008_2012_54" height="29" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_54.gif"
										width="110" border="0" name="procest_2008_2012_54"></td>
								<td colSpan="7" rowSpan="5"><IMG id="procest_2008_2012_60" height="75" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_60.gif"
										width="183" border="0" name="procest_2008_2012_60"></td>
								<td><IMG height="29" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td><IMG id="procest_2008_2012_70" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_70.gif"
										width="10" border="0" name="procest_2008_2012_70"></td>
								<td colSpan="8" rowSpan="3"><A onmouseover="MM_swapImage2('de_retact','','../../imagenes/procestra2008_2012/de_retact_f2.gif',1);"
										onmouseout="MM_swapImgRestore2();" href="../../estrategico/8Retroalimentacion_Actualizacion.doc" target="_blank"><IMG id="de_retact" height="37" alt="" src="../../imagenes/procestra2008_2012/de_retact.gif"
											width="137" border="0" name="de_retact" runat="server"></A></td>
								<td colSpan="2"><IMG id="procest_2008_2012_64" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_64.gif"
										width="51" border="0" name="procest_2008_2012_64"></td>
								<td><IMG height="13" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="4"><IMG id="procest_2008_2012_69" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_69.gif"
										width="80" border="0" name="procest_2008_2012_69"></td>
								<td colSpan="2"><IMG id="procest_2008_2012_63" height="13" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_63.gif"
										width="51" border="0" name="procest_2008_2012_63"></td>
								<td><IMG height="13" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="5" rowSpan="2"><IMG id="procest_2008_2012_72" height="20" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_72.gif"
										width="93" border="0" name="procest_2008_2012_72"></td>
								<td colSpan="3" rowSpan="2"><IMG id="procest_2008_2012_62" height="20" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_62.gif"
										width="60" border="0" name="procest_2008_2012_62"></td>
								<td><IMG height="11" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="8"><IMG id="procest_2008_2012_71" height="9" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_71.gif"
										width="137" border="0" name="procest_2008_2012_71"></td>
								<td><IMG height="9" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="29"><IMG id="procest_2008_2012_65" height="6" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_65.png"
										width="637" border="0" name="procest_2008_2012_65"></td>
								<td><IMG height="6" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="29"><IMG id="procest_2008_2012_66" height="25" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_66.png"
										width="637" border="0" name="procest_2008_2012_66"></td>
								<td><IMG height="25" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
							<tr>
								<td colSpan="29"><IMG id="procest_2008_2012_67" height="8" alt="" src="../../imagenes/procestra2008_2012/procest_2008_2012_67.png"
										width="637" border="0" name="procest_2008_2012_67"></td>
								<td><IMG height="8" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
