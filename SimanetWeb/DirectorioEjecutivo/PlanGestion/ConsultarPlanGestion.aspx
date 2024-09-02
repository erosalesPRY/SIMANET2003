<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarPlanGestion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.ConsultarPlanGestion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarPlanGestion</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script language="JavaScript">
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

//-->
		</script>
	</HEAD>
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ObtenerHistorial(),MM_preloadImages('../../imagenes/ConusltarPlanGestion_r4_c4_f2.gif','../../imagenes/ConusltarPlanGestion_r4_c10_f2.gif','../../imagenes/ConusltarPlanGestion_r4_c16_f2.gif','../../imagenes/ConusltarPlanGestion_r4_c21_f2.gif','../../imagenes/ConusltarPlanGestion_r4_c27_f2.gif','../../imagenes/ConusltarPlanGestion_r4_c32_f2.gif','../../imagenes/ConusltarPlanGestion_r4_c38_f2.gif','../../imagenes/ConusltarPlanGestion_r6_c15_f2.gif','../../imagenes/ConusltarPlanGestion_r6_c28_f2.gif','../../imagenes/ConusltarPlanGestion_r8_c3_f2.gif','../../imagenes/ConusltarPlanGestion_r8_c9_f2.gif','../../imagenes/ConusltarPlanGestion_r8_c22_f2.gif','../../imagenes/ConusltarPlanGestion_r8_c28_f2.gif','../../imagenes/ConusltarPlanGestion_r8_c34_f2.gif','../../imagenes/ConusltarPlanGestion_r8_c40_f2.gif','../../imagenes/ConusltarPlanGestion_r10_c28_f2.gif','../../imagenes/ConusltarPlanGestion_r12_c15_f2.gif','../../imagenes/ConusltarPlanGestion_r12_c28_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c2_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c6_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c12_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c18_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c24_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c30_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c36_f2.gif','../../imagenes/ConusltarPlanGestion_r14_c42_f2.gif');"
		rightMargin="0" onunload="onunload=SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<P>
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
					<TR>
						<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
					</TR>
					<TR>
						<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
					</TR>
					<TR>
						<TD><table border="0" cellpadding="0" cellspacing="0" width="760" align="center">
								<tr>
									<td><img src="../../imagenes/spacer.gif" width="24" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="34" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="14" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="32" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="11" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="18" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="19" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="9" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="33" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="12" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="26" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="9" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="7" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="37" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="10" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="32" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="10" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="4" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="33" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="13" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="29" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="5" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="4" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="12" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="30" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="8" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="30" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="9" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="3" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="14" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="24" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="11" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="28" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="8" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="9" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="16" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="19" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="11" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="25" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="25" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="30" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="20" height="1" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="45"><img name="ConusltarPlanGestion_r1_c1" src="../../imagenes/ConusltarPlanGestion_r1_c1.gif"
											width="760" height="35" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="45">
										<P align="center">
											<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">PLAN DE GESTION</asp:label></P>
									</td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="29" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="45"><img name="ConusltarPlanGestion_r3_c1" src="../../imagenes/ConusltarPlanGestion_r3_c1.gif"
											width="760" height="16" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="16" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="4" colspan="3"><img name="ConusltarPlanGestion_r4_c1" src="../../imagenes/ConusltarPlanGestion_r4_c1.gif"
											width="72" height="147" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c4','','../../imagenes/ConusltarPlanGestion_r4_c4_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c4" src="../../imagenes/ConusltarPlanGestion_r4_c4.gif"
												width="80" height="35" border="0" alt="" id="PG01" runat="server"></a></td>
									<td rowspan="4" colspan="2"><img name="ConusltarPlanGestion_r4_c8" src="../../imagenes/ConusltarPlanGestion_r4_c8.gif"
											width="10" height="147" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c10','','../../imagenes/ConusltarPlanGestion_r4_c10_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c10" src="../../imagenes/ConusltarPlanGestion_r4_c10.gif"
												width="80" height="35" border="0" alt="" id="PG02" runat="server"></a></td>
									<td rowspan="2" colspan="2"><img name="ConusltarPlanGestion_r4_c14" src="../../imagenes/ConusltarPlanGestion_r4_c14.gif"
											width="8" height="76" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c16','','../../imagenes/ConusltarPlanGestion_r4_c16_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c16" src="../../imagenes/ConusltarPlanGestion_r4_c16.gif"
												width="80" height="35" border="0" alt="" id="PG03" runat="server"></a></td>
									<td rowspan="10"><img name="ConusltarPlanGestion_r4_c20" src="../../imagenes/ConusltarPlanGestion_r4_c20.gif"
											width="10" height="289" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c21','','../../imagenes/ConusltarPlanGestion_r4_c21_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c21" src="../../imagenes/ConusltarPlanGestion_r4_c21.gif"
												width="79" height="35" border="0" alt="" id="PG04" runat="server"></a></td>
									<td rowspan="4" colspan="2"><img name="ConusltarPlanGestion_r4_c25" src="../../imagenes/ConusltarPlanGestion_r4_c25.gif"
											width="9" height="147" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c27','','../../imagenes/ConusltarPlanGestion_r4_c27_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c27" src="../../imagenes/ConusltarPlanGestion_r4_c27.gif"
												width="80" height="35" border="0" alt="" id="PG05" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r4_c31" src="../../imagenes/ConusltarPlanGestion_r4_c31.gif"
											width="9" height="76" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c32','','../../imagenes/ConusltarPlanGestion_r4_c32_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c32" src="../../imagenes/ConusltarPlanGestion_r4_c32.gif"
												width="80" height="35" border="0" alt="" id="PG06" runat="server"></a></td>
									<td rowspan="4"><img name="ConusltarPlanGestion_r4_c37" src="../../imagenes/ConusltarPlanGestion_r4_c37.gif"
											width="8" height="147" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r4_c38','','../../imagenes/ConusltarPlanGestion_r4_c38_f2.gif',1);"><img name="ConusltarPlanGestion_r4_c38" src="../../imagenes/ConusltarPlanGestion_r4_c38.gif"
												width="80" height="35" border="0" alt="" id="PG07" runat="server"></a></td>
									<td rowspan="4" colspan="3"><img name="ConusltarPlanGestion_r4_c43" src="../../imagenes/ConusltarPlanGestion_r4_c43.gif"
											width="75" height="147" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="3" colspan="4"><img name="ConusltarPlanGestion_r5_c4" src="../../imagenes/ConusltarPlanGestion_r5_c4.gif"
											width="80" height="112" border="0" alt=""></td>
									<td rowspan="3" colspan="4"><img name="ConusltarPlanGestion_r5_c10" src="../../imagenes/ConusltarPlanGestion_r5_c10.gif"
											width="80" height="112" border="0" alt=""></td>
									<td colspan="4"><img name="ConusltarPlanGestion_r5_c16" src="../../imagenes/ConusltarPlanGestion_r5_c16.gif"
											width="80" height="41" border="0" alt=""></td>
									<td rowspan="3" colspan="4"><img name="ConusltarPlanGestion_r5_c21" src="../../imagenes/ConusltarPlanGestion_r5_c21.gif"
											width="79" height="112" border="0" alt=""></td>
									<td colspan="4"><img name="ConusltarPlanGestion_r5_c27" src="../../imagenes/ConusltarPlanGestion_r5_c27.gif"
											width="80" height="41" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r5_c32" src="../../imagenes/ConusltarPlanGestion_r5_c32.gif"
											width="80" height="41" border="0" alt=""></td>
									<td rowspan="3" colspan="5"><img name="ConusltarPlanGestion_r5_c38" src="../../imagenes/ConusltarPlanGestion_r5_c38.gif"
											width="80" height="112" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="41" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="8"><img name="ConusltarPlanGestion_r6_c14" src="../../imagenes/ConusltarPlanGestion_r6_c14.gif"
											width="7" height="213" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r6_c15','','../../imagenes/ConusltarPlanGestion_r6_c15_f2.gif',1);"><img name="ConusltarPlanGestion_r6_c15" src="../../imagenes/ConusltarPlanGestion_r6_c15.gif"
												width="80" height="35" border="0" alt="" id="PP17" runat="server"></a></td>
									<td rowspan="8"><img name="ConusltarPlanGestion_r6_c19" src="../../imagenes/ConusltarPlanGestion_r6_c19.gif"
											width="1" height="213" border="0" alt=""></td>
									<td rowspan="8"><img name="ConusltarPlanGestion_r6_c27" src="../../imagenes/ConusltarPlanGestion_r6_c27.gif"
											width="12" height="213" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r6_c28','','../../imagenes/ConusltarPlanGestion_r6_c28_f2.gif',1);"><img name="ConusltarPlanGestion_r6_c28" src="../../imagenes/ConusltarPlanGestion_r6_c28.gif"
												width="80" height="35" border="0" alt="" id="PP18" runat="server"></a></td>
									<td rowspan="2" colspan="4"><img name="ConusltarPlanGestion_r6_c33" src="../../imagenes/ConusltarPlanGestion_r6_c33.gif"
											width="77" height="71" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="5" colspan="4"><img name="ConusltarPlanGestion_r7_c15" src="../../imagenes/ConusltarPlanGestion_r7_c15.gif"
											width="80" height="113" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r7_c28" src="../../imagenes/ConusltarPlanGestion_r7_c28.gif"
											width="80" height="36" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="36" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="6" colspan="2"><img name="ConusltarPlanGestion_r8_c1" src="../../imagenes/ConusltarPlanGestion_r8_c1.gif"
											width="58" height="142" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r8_c3','','../../imagenes/ConusltarPlanGestion_r8_c3_f2.gif',1);"><img name="ConusltarPlanGestion_r8_c3" src="../../imagenes/ConusltarPlanGestion_r8_c3.gif"
												width="75" height="35" border="0" alt="" id="PP04" runat="server"></a></td>
									<td rowspan="6" colspan="2"><img name="ConusltarPlanGestion_r8_c7" src="../../imagenes/ConusltarPlanGestion_r8_c7.gif"
											width="20" height="142" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r8_c9','','../../imagenes/ConusltarPlanGestion_r8_c9_f2.gif',1);"><img name="ConusltarPlanGestion_r8_c9" src="../../imagenes/ConusltarPlanGestion_r8_c9.gif"
												width="80" height="35" border="0" alt="" id="PP11" runat="server"></a></td>
									<td rowspan="6"><img name="ConusltarPlanGestion_r8_c13" src="../../imagenes/ConusltarPlanGestion_r8_c13.gif"
											width="9" height="142" border="0" alt=""></td>
									<td rowspan="6"><img name="ConusltarPlanGestion_r8_c21" src="../../imagenes/ConusltarPlanGestion_r8_c21.gif"
											width="4" height="142" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r8_c22','','../../imagenes/ConusltarPlanGestion_r8_c22_f2.gif',1);"><img name="ConusltarPlanGestion_r8_c22" src="../../imagenes/ConusltarPlanGestion_r8_c22.gif"
												width="80" height="35" border="0" alt="" id="PP13" runat="server"></a></td>
									<td rowspan="6"><img name="ConusltarPlanGestion_r8_c26" src="../../imagenes/ConusltarPlanGestion_r8_c26.gif"
											width="4" height="142" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r8_c28','','../../imagenes/ConusltarPlanGestion_r8_c28_f2.gif',1);"><img name="ConusltarPlanGestion_r8_c28" src="../../imagenes/ConusltarPlanGestion_r8_c28.gif"
												width="80" height="35" border="0" alt="" id="PP14" runat="server"></a></td>
									<td rowspan="6"><img name="ConusltarPlanGestion_r8_c33" src="../../imagenes/ConusltarPlanGestion_r8_c33.gif"
											width="14" height="142" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r8_c34','','../../imagenes/ConusltarPlanGestion_r8_c34_f2.gif',1);"><img name="ConusltarPlanGestion_r8_c34" src="../../imagenes/ConusltarPlanGestion_r8_c34.gif"
												width="80" height="35" border="0" alt="" id="PPC13" runat="server"></a></td>
									<td rowspan="6"><img name="ConusltarPlanGestion_r8_c39" src="../../imagenes/ConusltarPlanGestion_r8_c39.gif"
											width="16" height="142" border="0" alt=""></td>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r8_c40','','../../imagenes/ConusltarPlanGestion_r8_c40_f2.gif',1);"><img name="ConusltarPlanGestion_r8_c40" src="../../imagenes/ConusltarPlanGestion_r8_c40.gif"
												width="80" height="35" border="0" alt="" id="PPC04" runat="server"></a></td>
									<td rowspan="6" colspan="2"><img name="ConusltarPlanGestion_r8_c44" src="../../imagenes/ConusltarPlanGestion_r8_c44.gif"
											width="50" height="142" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="5" colspan="4"><img name="ConusltarPlanGestion_r9_c3" src="../../imagenes/ConusltarPlanGestion_r9_c3.gif"
											width="75" height="107" border="0" alt=""></td>
									<td rowspan="5" colspan="4"><img name="ConusltarPlanGestion_r9_c9" src="../../imagenes/ConusltarPlanGestion_r9_c9.gif"
											width="80" height="107" border="0" alt=""></td>
									<td rowspan="5" colspan="4"><img name="ConusltarPlanGestion_r9_c22" src="../../imagenes/ConusltarPlanGestion_r9_c22.gif"
											width="80" height="107" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r9_c28" src="../../imagenes/ConusltarPlanGestion_r9_c28.gif"
											width="80" height="3" border="0" alt=""></td>
									<td rowspan="5" colspan="5"><img name="ConusltarPlanGestion_r9_c34" src="../../imagenes/ConusltarPlanGestion_r9_c34.gif"
											width="80" height="107" border="0" alt=""></td>
									<td rowspan="5" colspan="4"><img name="ConusltarPlanGestion_r9_c40" src="../../imagenes/ConusltarPlanGestion_r9_c40.gif"
											width="80" height="107" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="3" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r10_c28','','../../imagenes/ConusltarPlanGestion_r10_c28_f2.gif',1);"><img name="ConusltarPlanGestion_r10_c28" src="../../imagenes/ConusltarPlanGestion_r10_c28.gif"
												width="80" height="35" border="0" alt="" id="PP15" runat="server"></a></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="5"><img name="ConusltarPlanGestion_r11_c28" src="../../imagenes/ConusltarPlanGestion_r11_c28.gif"
											width="80" height="4" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="4" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r12_c15','','../../imagenes/ConusltarPlanGestion_r12_c15_f2.gif',1);"><img name="ConusltarPlanGestion_r12_c15" src="../../imagenes/ConusltarPlanGestion_r12_c15.gif"
												width="80" height="35" border="0" alt="" id="PP12" runat="server"></a></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r12_c28','','../../imagenes/ConusltarPlanGestion_r12_c28_f2.gif',1);"><img name="ConusltarPlanGestion_r12_c28" src="../../imagenes/ConusltarPlanGestion_r12_c28.gif"
												width="80" height="35" border="0" alt="" id="PP16" runat="server"></a></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="4"><img name="ConusltarPlanGestion_r13_c15" src="../../imagenes/ConusltarPlanGestion_r13_c15.gif"
											width="80" height="30" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r13_c28" src="../../imagenes/ConusltarPlanGestion_r13_c28.gif"
											width="80" height="30" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="30" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c1" src="../../imagenes/ConusltarPlanGestion_r14_c1.gif"
											width="24" height="91" border="0" alt=""></td>
									<td colspan="3"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c2','','../../imagenes/ConusltarPlanGestion_r14_c2_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c2" src="../../imagenes/ConusltarPlanGestion_r14_c2.gif"
												width="80" height="35" border="0" alt="" id="PA21" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c5" src="../../imagenes/ConusltarPlanGestion_r14_c5.gif"
											width="11" height="91" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c6','','../../imagenes/ConusltarPlanGestion_r14_c6_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c6" src="../../imagenes/ConusltarPlanGestion_r14_c6.gif"
												width="80" height="35" border="0" alt="" id="PA22" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c11" src="../../imagenes/ConusltarPlanGestion_r14_c11.gif"
											width="12" height="91" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c12','','../../imagenes/ConusltarPlanGestion_r14_c12_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c12" src="../../imagenes/ConusltarPlanGestion_r14_c12.gif"
												width="80" height="35" border="0" alt="" id="PA23" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c17" src="../../imagenes/ConusltarPlanGestion_r14_c17.gif"
											width="10" height="91" border="0" alt=""></td>
									<td colspan="5" id="PA24"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c18','','../../imagenes/ConusltarPlanGestion_r14_c18_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c18" src="../../imagenes/ConusltarPlanGestion_r14_c18.gif"
												width="80" height="35" border="0" alt="" id="PA24" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c23" src="../../imagenes/ConusltarPlanGestion_r14_c23.gif"
											width="13" height="91" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c24','','../../imagenes/ConusltarPlanGestion_r14_c24_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c24" src="../../imagenes/ConusltarPlanGestion_r14_c24.gif"
												width="80" height="35" border="0" alt="" id="PA25" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c29" src="../../imagenes/ConusltarPlanGestion_r14_c29.gif"
											width="8" height="91" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c30','','../../imagenes/ConusltarPlanGestion_r14_c30_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c30" src="../../imagenes/ConusltarPlanGestion_r14_c30.gif"
												width="80" height="35" border="0" alt="" id="PA26" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c35" src="../../imagenes/ConusltarPlanGestion_r14_c35.gif"
											width="11" height="91" border="0" alt=""></td>
									<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c36','','../../imagenes/ConusltarPlanGestion_r14_c36_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c36" src="../../imagenes/ConusltarPlanGestion_r14_c36.gif"
												width="80" height="35" border="0" alt="" id="PA27" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c41" src="../../imagenes/ConusltarPlanGestion_r14_c41.gif"
											width="11" height="91" border="0" alt=""></td>
									<td colspan="3"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('ConusltarPlanGestion_r14_c42','','../../imagenes/ConusltarPlanGestion_r14_c42_f2.gif',1);"><img name="ConusltarPlanGestion_r14_c42" src="../../imagenes/ConusltarPlanGestion_r14_c42.gif"
												width="80" height="35" border="0" alt="" id="PA28" runat="server"></a></td>
									<td rowspan="2"><img name="ConusltarPlanGestion_r14_c45" src="../../imagenes/ConusltarPlanGestion_r14_c45.gif"
											width="20" height="91" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="35" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="3" background="../../imagenes/ConusltarPlanGestion_r15_c2.gif">
										<IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
											width="80" style="CURSOR: hand"></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r15_c6" src="../../imagenes/ConusltarPlanGestion_r15_c6.gif"
											width="80" height="56" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r15_c12" src="../../imagenes/ConusltarPlanGestion_r15_c12.gif"
											width="80" height="56" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r15_c18" src="../../imagenes/ConusltarPlanGestion_r15_c18.gif"
											width="80" height="56" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r15_c24" src="../../imagenes/ConusltarPlanGestion_r15_c24.gif"
											width="80" height="56" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r15_c30" src="../../imagenes/ConusltarPlanGestion_r15_c30.gif"
											width="80" height="56" border="0" alt=""></td>
									<td colspan="5"><img name="ConusltarPlanGestion_r15_c36" src="../../imagenes/ConusltarPlanGestion_r15_c36.gif"
											width="80" height="56" border="0" alt=""></td>
									<td colspan="3"><img name="ConusltarPlanGestion_r15_c42" src="../../imagenes/ConusltarPlanGestion_r15_c42.gif"
											width="80" height="56" border="0" alt=""></td>
									<td><img src="../../imagenes/spacer.gif" width="1" height="56" border="0" alt="" style="CURSOR: hand"></td>
								</tr>
							</table>
						</TD>
					</TR>
				</TABLE>
			</P>
		</form>
		<script>
		<asp:Literal id="ltlMensaje" Runat="server" EnableViewState="False"></asp:Literal>
		</script>
	</body>
</HTML>
