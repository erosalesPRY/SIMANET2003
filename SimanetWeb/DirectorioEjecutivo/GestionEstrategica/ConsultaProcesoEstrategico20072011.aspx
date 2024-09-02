<%@ Page language="c#" Codebehind="ConsultaProcesoEstrategico20072011.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaProcesoEstrategico20072011" %>
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
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();" rightMargin="0">
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
						<DIV align="center">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="960" border="0">
								<TR>
									<TD noWrap>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="960" align="center" border="0">
											<TR>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="114" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="12" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="30" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="12" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="4" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="27" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="4" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="16" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="2" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="8" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="40" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="24" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="5" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="2" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="8" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="3" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="29" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="39" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="7" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="2" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="17" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="16" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="12" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="28" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="14" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="29" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="34" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="29" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="9" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="4" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="29" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="7" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="26" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="15" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="15" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="13" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="30" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="5" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="23" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="5" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="11" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="27" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="4" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="8" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="4" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="28" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="14" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="12" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="16" border="0"></TD>
												<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="57"><IMG height="108" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r1_c1.gif" width="960"
														border="0" name="ProcesoEstrategico2007_2011_r1_c1"></TD>
												<TD><IMG height="108" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD rowSpan="43"><IMG height="602" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r2_c1.gif" width="114"
														border="0" name="ProcesoEstrategico2007_2011_r2_c1"></TD>
												<TD rowSpan="42"><IMG height="560" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r2_c2.gif" width="12"
														border="0" name="ProcesoEstrategico2007_2011_r2_c2"></TD>
												<TD colSpan="53"><IMG height="14" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r2_c3.gif" width="806"
														border="0" name="ProcesoEstrategico2007_2011_r2_c3"></TD>
												<TD rowSpan="42"><IMG height="560" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r2_c56.gif"
														width="12" border="0" name="ProcesoEstrategico2007_2011_r2_c56"></TD>
												<TD rowSpan="43"><IMG height="602" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r2_c57.gif"
														width="16" border="0" name="ProcesoEstrategico2007_2011_r2_c57"></TD>
												<TD><IMG height="14" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="8" rowSpan="3"><IMG height="35" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r3_c3.gif" width="115"
														border="0" name="ProcesoEstrategico2007_2011_r3_c3"></TD>
												<TD colSpan="5" rowSpan="3"><IMG height="35" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r3_c11.gif" width="85"
														border="0" name="ProcesoEstrategico2007_2011_r3_c11"></TD>
												<TD colSpan="19"><IMG height="9" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r3_c16.gif" width="305"
														border="0" name="ProcesoEstrategico2007_2011_r3_c16"></TD>
												<TD colSpan="7" rowSpan="3"><IMG height="35" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r3_c35.gif" width="103"
														border="0" name="ProcesoEstrategico2007_2011_r3_c35"></TD>
												<TD colSpan="14" rowSpan="3"><IMG height="35" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r3_c42.gif" width="198"
														border="0" name="ProcesoEstrategico2007_2011_r3_c42"></TD>
												<TD><IMG height="9" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="9" rowSpan="2"><IMG height="26" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r4_c16.gif" width="112"
														border="0" name="ProcesoEstrategico2007_2011_r4_c16"></TD>
												<TD colSpan="10"><IMG height="19" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r4_c25.gif" width="193"
														border="0" name="ProcesoEstrategico2007_2011_r4_c25"></TD>
												<TD><IMG height="19" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="10"><IMG height="7" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r5_c25.gif" width="193"
														border="0" name="ProcesoEstrategico2007_2011_r5_c25"></TD>
												<TD><IMG height="7" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="53"><IMG height="18" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r6_c3.gif" width="806"
														border="0" name="ProcesoEstrategico2007_2011_r6_c3"></TD>
												<TD><IMG height="18" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="6" rowSpan="3"><A onmouseover="MM_swapImage('pe_finemp','','../../imagenes/pe_finemp_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_finemp.gif" width="95" border="0" name="pe_finemp"
															id="btnFilosofiaEmpresarial" runat="server"></A></TD>
												<TD colSpan="4"><IMG height="12" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r7_c9.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r7_c9"></TD>
												<TD colSpan="10" rowSpan="3"><A onmouseover="MM_swapImage('pe_diasit','','../../imagenes/pe_diasit_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_diasit.gif" width="165" border="0" name="pe_diasit"
															id="btnDiagnosticoSituacional" runat="server"></A></TD>
												<TD colSpan="3"><IMG height="12" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r7_c23.gif" width="35"
														border="0" name="ProcesoEstrategico2007_2011_r7_c23"></TD>
												<TD colSpan="5" rowSpan="3"><A onmouseover="MM_swapImage('pe_forest','','../../imagenes/pe_forest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_forest.gif" width="94" border="0" name="pe_forest"
															id="btnFormulacionEstrategica" runat="server"></A></TD>
												<TD><IMG height="12" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r7_c31.gif" width="34"
														border="0" name="ProcesoEstrategico2007_2011_r7_c31"></TD>
												<TD colSpan="6" rowSpan="3"><A onmouseover="MM_swapImage('pe_plapro','','../../imagenes/pe_plapro_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_plapro.gif" width="93" border="0" name="pe_plapro"
															id="btnPlaneamientoProgramatico" runat="server"></A></TD>
												<TD colSpan="2"><IMG height="12" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r7_c38.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r7_c38"></TD>
												<TD colSpan="6" rowSpan="3"><A onmouseover="MM_swapImage('pe_impope','','../../imagenes/pe_impope_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_impope.gif" width="95" border="0" name="pe_impope"
															id="btnImplementacionOperacional" runat="server"></A></TD>
												<TD colSpan="3"><IMG height="12" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r7_c46.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r7_c46"></TD>
												<TD colSpan="7" rowSpan="3"><A onmouseover="MM_swapImage('pe_segevaest','','../../imagenes/pe_segevaest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_segevaest.gif" width="96" border="0" name="pe_segevaest"
															id="btnSeguimientoyEvaluacionEstrategica" runat="server"></A></TD>
												<TD><IMG height="12" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="16" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r8_c9.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r8_c9"></TD>
												<TD colSpan="3"><IMG height="16" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r8_c23.gif" width="35"
														border="0" name="ProcesoEstrategico2007_2011_r8_c23"></TD>
												<TD><IMG height="16" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r8_c31.gif" width="34"
														border="0" name="ProcesoEstrategico2007_2011_r8_c31"></TD>
												<TD colSpan="2"><IMG height="16" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r8_c38.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r8_c38"></TD>
												<TD colSpan="3"><IMG height="16" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r8_c46.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r8_c46"></TD>
												<TD><IMG height="16" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="11" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r9_c9.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r9_c9"></TD>
												<TD colSpan="3"><IMG height="11" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r9_c23.gif" width="35"
														border="0" name="ProcesoEstrategico2007_2011_r9_c23"></TD>
												<TD><IMG height="11" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r9_c31.gif" width="34"
														border="0" name="ProcesoEstrategico2007_2011_r9_c31"></TD>
												<TD colSpan="2"><IMG height="11" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r9_c38.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r9_c38"></TD>
												<TD colSpan="3"><IMG height="11" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r9_c46.gif" width="33"
														border="0" name="ProcesoEstrategico2007_2011_r9_c46"></TD>
												<TD><IMG height="11" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="2"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c3.gif" width="41"
														border="0" name="ProcesoEstrategico2007_2011_r10_c3"></TD>
												<TD colSpan="2"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c5.gif" width="16"
														border="0" name="ProcesoEstrategico2007_2011_r10_c5"></TD>
												<TD colSpan="9"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c7.gif" width="143"
														border="0" name="ProcesoEstrategico2007_2011_r10_c7"></TD>
												<TD colSpan="4"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c16.gif"
														width="18" border="0" name="ProcesoEstrategico2007_2011_r10_c16"></TD>
												<TD colSpan="8"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c20.gif"
														width="150" border="0" name="ProcesoEstrategico2007_2011_r10_c20"></TD>
												<TD><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c28.gif"
														width="14" border="0" name="ProcesoEstrategico2007_2011_r10_c28"></TD>
												<TD colSpan="5"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c29.gif"
														width="114" border="0" name="ProcesoEstrategico2007_2011_r10_c29"></TD>
												<TD colSpan="2"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c34.gif"
														width="13" border="0" name="ProcesoEstrategico2007_2011_r10_c34"></TD>
												<TD colSpan="7"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c36.gif"
														width="114" border="0" name="ProcesoEstrategico2007_2011_r10_c36"></TD>
												<TD><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c43.gif"
														width="13" border="0" name="ProcesoEstrategico2007_2011_r10_c43"></TD>
												<TD colSpan="7"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c44.gif"
														width="112" border="0" name="ProcesoEstrategico2007_2011_r10_c44"></TD>
												<TD colSpan="3"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c51.gif"
														width="16" border="0" name="ProcesoEstrategico2007_2011_r10_c51"></TD>
												<TD colSpan="2"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r10_c54.gif"
														width="42" border="0" name="ProcesoEstrategico2007_2011_r10_c54"></TD>
												<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD rowSpan="17"><IMG height="227" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c3.gif"
														width="11" border="0" name="ProcesoEstrategico2007_2011_r11_c3"></TD>
												<TD colSpan="4"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c4.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r11_c4"></TD>
												<TD colSpan="2" rowSpan="17"><IMG height="227" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c8.gif"
														width="15" border="0" name="ProcesoEstrategico2007_2011_r11_c8"></TD>
												<TD colSpan="2" rowSpan="29"><IMG height="385" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c10.gif"
														width="27" border="0" name="ProcesoEstrategico2007_2011_r11_c10"></TD>
												<TD colSpan="2" rowSpan="27"><IMG height="365" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c12.gif"
														width="10" border="0" name="ProcesoEstrategico2007_2011_r11_c12"></TD>
												<TD colSpan="8"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c14.gif" width="150"
														border="0" name="ProcesoEstrategico2007_2011_r11_c14"></TD>
												<TD colSpan="2" rowSpan="27"><IMG height="365" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c22.gif"
														width="9" border="0" name="ProcesoEstrategico2007_2011_r11_c22"></TD>
												<TD colSpan="2" rowSpan="24"><IMG height="315" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c24.gif"
														width="33" border="0" name="ProcesoEstrategico2007_2011_r11_c24"></TD>
												<TD rowSpan="24"><IMG height="315" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c26.gif"
														width="12" border="0" name="ProcesoEstrategico2007_2011_r11_c26"></TD>
												<TD colSpan="3"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r11_c27"></TD>
												<TD rowSpan="24"><IMG height="315" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c30.gif"
														width="11" border="0" name="ProcesoEstrategico2007_2011_r11_c30"></TD>
												<TD><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c31.gif" width="34"
														border="0" name="ProcesoEstrategico2007_2011_r11_c31"></TD>
												<TD rowSpan="13"><IMG height="186" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c32.gif"
														width="11" border="0" name="ProcesoEstrategico2007_2011_r11_c32"></TD>
												<TD colSpan="7"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c33.gif" width="115"
														border="0" name="ProcesoEstrategico2007_2011_r11_c33"></TD>
												<TD rowSpan="7"><IMG height="98" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c40.gif"
														width="11" border="0" name="ProcesoEstrategico2007_2011_r11_c40"></TD>
												<TD colSpan="4"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c41.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r11_c41"></TD>
												<TD colSpan="2" rowSpan="7"><IMG height="98" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c45.gif"
														width="16" border="0" name="ProcesoEstrategico2007_2011_r11_c45"></TD>
												<TD rowSpan="27"><IMG height="365" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c47.gif"
														width="23" border="0" name="ProcesoEstrategico2007_2011_r11_c47"></TD>
												<TD colSpan="2" rowSpan="13"><IMG height="186" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c48.gif"
														width="16" border="0" name="ProcesoEstrategico2007_2011_r11_c48"></TD>
												<TD colSpan="5"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c50.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r11_c50"></TD>
												<TD rowSpan="13"><IMG height="186" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r11_c55.gif"
														width="14" border="0" name="ProcesoEstrategico2007_2011_r11_c55"></TD>
												<TD><IMG height="8" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><A onmouseover="MM_swapImage('pe_objsoc','','../../imagenes/pe_objsoc_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_objsoc.gif" width="73" border="0" name="pe_objsoc"
															id="btnObjetoSocial" runat="server"></A></TD>
												<TD rowSpan="9"><IMG height="131" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r12_c14.gif"
														width="40" border="0" name="ProcesoEstrategico2007_2011_r12_c14"></TD>
												<TD colSpan="6"><A onmouseover="MM_swapImage('pe_matdia','','../../imagenes/pe_matdia_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_matdia.gif" width="71" border="0" name="pe_matdia"
															id="btnMatrizDeDiagnostico" runat="server"></A></TD>
												<TD rowSpan="9"><IMG height="131" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r12_c21.gif"
														width="39" border="0" name="ProcesoEstrategico2007_2011_r12_c21"></TD>
												<TD colSpan="3"><A onmouseover="MM_swapImage('pe_esttemest','','../../imagenes/pe_esttemest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_esttemest.gif" width="71" border="0" name="pe_esttemest"
															id="btnEstablecerTemasEstrategicos" runat="server"></A></TD>
												<TD rowSpan="11"><IMG height="174" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r12_c31.gif"
														width="34" border="0" name="ProcesoEstrategico2007_2011_r12_c31"></TD>
												<TD colSpan="4"><A onmouseover="MM_swapImage('pe_estmet','','../../imagenes/pe_estmet_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_estmet.gif" width="71" border="0" name="pe_estmet"
															id="btnEstablecerMetas" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="6"><IMG height="90" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r12_c37.gif"
														width="44" border="0" name="ProcesoEstrategico2007_2011_r12_c37"></TD>
												<TD colSpan="4"><A onmouseover="MM_swapImage('pe_forplaope','','../../imagenes/pe_forplaope_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_forplaope.gif" width="73" border="0" name="pe_forplaope"
															id="btnFormulacionPlanOperativo" runat="server"></A></TD>
												<TD colSpan="5"><A onmouseover="MM_swapImage('pe_tabman','','../../imagenes/pe_tabman_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_tabman.gif" width="71" border="0" name="pe_tabman"
															id="btnTableroDeMando" runat="server"></A></TD>
												<TD><IMG height="38" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r13_c4.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r13_c4"></TD>
												<TD colSpan="6" rowSpan="2"><IMG height="6" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r13_c15.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r13_c15"></TD>
												<TD colSpan="3"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r13_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r13_c27"></TD>
												<TD colSpan="4"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r13_c33.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r13_c33"></TD>
												<TD colSpan="4"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r13_c41.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r13_c41"></TD>
												<TD colSpan="5"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r13_c50.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r13_c50"></TD>
												<TD><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_mis','','../../imagenes/pe_mis_f2.gif',1);" onmouseout="MM_swapImgRestore();"
														href="#"><IMG height="39" alt="" src="../../imagenes/pe_mis.gif" width="73" border="0" name="pe_mis"
															id="btnMision" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="2"><A onmouseover="MM_swapImage('pe_forobjgen','','../../imagenes/pe_forobjgen_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_forobjgen.gif" width="71" border="0" name="pe_forobjgen"
															id="btnFormularObjetivosGenerales" runat="server"></A></TD>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_estindges','','../../imagenes/pe_estindges_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_estindges.gif" width="71" border="0" name="pe_estindges"
															id="btnEstablecerIndicadoresDeGestion" runat="server"></A></TD>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_forpreanu','','../../imagenes/pe_forpreanu_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_forpreanu.gif" width="73" border="0" name="pe_forpreanu"
															id="btnFormulacionPresupuestoAnual" runat="server"></A></TD>
												<TD colSpan="5" rowSpan="2"><A onmouseover="MM_swapImage('pe_avaplaope','','../../imagenes/pe_avaplaope_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_avaplaope.gif" width="71" border="0" name="pe_avaplaope"
															id="btnAvanceDelPlanOperativo" runat="server"></A></TD>
												<TD><IMG height="2" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="6"><A onmouseover="MM_swapImage('pe_ananor','','../../imagenes/pe_ananor_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="37" alt="" src="../../imagenes/pe_ananor.gif" width="71" border="0" name="pe_ananor"
															id="btnAnalisisNormativo" runat="server"></A></TD>
												<TD><IMG height="37" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r16_c4.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r16_c4"></TD>
												<TD colSpan="6"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r16_c15.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r16_c15"></TD>
												<TD colSpan="3"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r16_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r16_c27"></TD>
												<TD colSpan="4"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r16_c33.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r16_c33"></TD>
												<TD colSpan="4" rowSpan="2"><IMG height="9" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r16_c41.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r16_c41"></TD>
												<TD colSpan="5"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r16_c50.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r16_c50"></TD>
												<TD><IMG height="5" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_vis','','../../imagenes/pe_vis_f2.gif',1);" onmouseout="MM_swapImgRestore();"
														href="#"><IMG height="39" alt="" src="../../imagenes/pe_vis.gif" width="73" border="0" name="pe_vis"
															id="btnVision" runat="server"></A></TD>
												<TD colSpan="6" rowSpan="2"><A onmouseover="MM_swapImage('pe_linest','','../../imagenes/pe_linest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_linest.gif" width="71" border="0" name="pe_linest"
															id="btnLineamientosEstrategicos" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="2"><A onmouseover="MM_swapImage('pe_aliest','','../../imagenes/pe_aliest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_aliest.gif" width="71" border="0" name="pe_aliest"
															id="btnAlineamientoEstrategico" runat="server"></A></TD>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_esttabman','','../../imagenes/pe_esttabman_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_esttabman.gif" width="71" border="0" name="pe_esttabman"
															id="btnEstablecerElTableroDeMando" runat="server"></A></TD>
												<TD colSpan="5" rowSpan="2"><A onmouseover="MM_swapImage('pe_avapre','','../../imagenes/pe_avapre_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_avapre.gif" width="71" border="0" name="pe_avapre"
															id="btnAvancePresupuesto" runat="server"></A></TD>
												<TD><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD rowSpan="22"><IMG height="287" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r18_c37.gif"
														width="11" border="0" name="ProcesoEstrategico2007_2011_r18_c37"></TD>
												<TD colSpan="5" rowSpan="20"><IMG height="267" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r18_c38.gif"
														width="74" border="0" name="ProcesoEstrategico2007_2011_r18_c38"></TD>
												<TD rowSpan="20"><IMG height="267" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r18_c43.gif"
														width="13" border="0" name="ProcesoEstrategico2007_2011_r18_c43"></TD>
												<TD colSpan="3" rowSpan="20"><IMG height="267" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r18_c44.gif"
														width="46" border="0" name="ProcesoEstrategico2007_2011_r18_c44"></TD>
												<TD><IMG height="35" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r19_c4.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r19_c4"></TD>
												<TD colSpan="6" rowSpan="2"><IMG height="6" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r19_c15.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r19_c15"></TD>
												<TD colSpan="3"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r19_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r19_c27"></TD>
												<TD colSpan="4"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r19_c33.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r19_c33"></TD>
												<TD colSpan="5"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r19_c50.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r19_c50"></TD>
												<TD><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_val','','../../imagenes/pe_val_f2.gif',1);" onmouseout="MM_swapImgRestore();"
														href="#"><IMG height="40" alt="" src="../../imagenes/pe_val.gif" width="73" border="0" name="pe_val"
															id="btnValores" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="2"><A onmouseover="MM_swapImage('pe_estobjesp','','../../imagenes/pe_estobjesp_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="40" alt="" src="../../imagenes/pe_estobjesp.gif" width="71" border="0" name="pe_estobjesp"
															id="btnEstablecerObjetivosEspecificos" runat="server"></A></TD>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('pe_preest','','../../imagenes/pe_preest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="40" alt="" src="../../imagenes/pe_preest.gif" width="71" border="0" name="pe_preest"
															id="btnPresupuestoEstrategico" runat="server"></A></TD>
												<TD colSpan="5" rowSpan="2"><A onmouseover="MM_swapImage('pe_avaplaest','','../../imagenes/pe_avaplaest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="40" alt="" src="../../imagenes/pe_avaplaest.gif" width="71" border="0" name="pe_avaplaest"
															id="btnAvanceDelPlanEstrategico" runat="server"></A></TD>
												<TD><IMG height="2" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><A onmouseover="MM_swapImage('pe_aprest','','../../imagenes/pe_aprest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_aprest.gif" width="71" border="0" name="pe_aprest"
															id="btnApreciacionEstrategica" runat="server"></A></TD>
												<TD rowSpan="12"><IMG height="138" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r21_c18.gif"
														width="8" border="0" name="ProcesoEstrategico2007_2011_r21_c18"></TD>
												<TD colSpan="3"><A onmouseover="MM_swapImage('pe_macent','','../../imagenes/pe_macent_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_macent.gif" width="71" border="0" name="pe_macent"
															id="btnMacroEntorno" runat="server"></A></TD>
												<TD><IMG height="38" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r22_c4.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r22_c4"></TD>
												<TD colSpan="4"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r22_c14.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r22_c14"></TD>
												<TD colSpan="3"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r22_c19.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r22_c19"></TD>
												<TD colSpan="3"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r22_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r22_c27"></TD>
												<TD colSpan="4" rowSpan="2"><IMG height="9" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r22_c33.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r22_c33"></TD>
												<TD colSpan="5" rowSpan="2"><IMG height="9" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r22_c50.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r22_c50"></TD>
												<TD><IMG height="5" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="3"><A onmouseover="MM_swapImage('pe_ide','','../../imagenes/pe_ide_f2.gif',1);" onmouseout="MM_swapImgRestore();"
														href="#"><IMG height="40" alt="" src="../../imagenes/pe_ide.gif" width="73" border="0" name="pe_ide"
															id="btnIdentidad" runat="server"></A></TD>
												<TD colSpan="4" rowSpan="3"><A onmouseover="MM_swapImage('pe_micent','','../../imagenes/pe_micent_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="40" alt="" src="../../imagenes/pe_micent.gif" width="71" border="0" name="pe_micent"
															id="btnMicroEntorno" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="3"><A onmouseover="MM_swapImage('pe_entesp','','../../imagenes/pe_entesp_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="40" alt="" src="../../imagenes/pe_entesp.gif" width="71" border="0" name="pe_entesp"
															id="btnEntornoEspecifico" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="2"><A onmouseover="MM_swapImage('pe_estacc','','../../imagenes/pe_estacc_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_estacc.gif" width="71" border="0" name="pe_estacc"
															id="btnEstablecerAcciones" runat="server"></A></TD>
												<TD rowSpan="12"><IMG height="133" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r23_c31.gif"
														width="34" border="0" name="ProcesoEstrategico2007_2011_r23_c31"></TD>
												<TD><IMG height="4" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="2" rowSpan="16"><IMG height="199" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r24_c32.gif"
														width="40" border="0" name="ProcesoEstrategico2007_2011_r24_c32"></TD>
												<TD colSpan="2" rowSpan="16"><IMG height="199" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r24_c34.gif"
														width="13" border="0" name="ProcesoEstrategico2007_2011_r24_c34"></TD>
												<TD rowSpan="16"><IMG height="199" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r24_c36.gif"
														width="29" border="0" name="ProcesoEstrategico2007_2011_r24_c36"></TD>
												<TD colSpan="4" rowSpan="15"><IMG height="191" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r24_c48.gif"
														width="47" border="0" name="ProcesoEstrategico2007_2011_r24_c48"></TD>
												<TD rowSpan="18"><IMG height="208" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r24_c52.gif"
														width="8" border="0" name="ProcesoEstrategico2007_2011_r24_c52"></TD>
												<TD colSpan="3" rowSpan="20"><IMG height="234" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r24_c53.gif"
														width="46" border="0" name="ProcesoEstrategico2007_2011_r24_c53"></TD>
												<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="3" rowSpan="2"><IMG height="4" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r25_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r25_c27"></TD>
												<TD><IMG height="2" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="2"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r26_c4.gif" width="73"
														border="0" name="ProcesoEstrategico2007_2011_r26_c4"></TD>
												<TD colSpan="4" rowSpan="3"><IMG height="7" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r26_c14.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r26_c14"></TD>
												<TD colSpan="3" rowSpan="3"><IMG height="7" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r26_c19.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r26_c19"></TD>
												<TD><IMG height="2" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="3" rowSpan="3"><A onmouseover="MM_swapImage('pe_estact','','../../imagenes/pe_estact_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="40" alt="" src="../../imagenes/pe_estact.gif" width="71" border="0" name="pe_estact"
															id="btnEstablecerActividades" runat="server"></A></TD>
												<TD><IMG height="3" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="2" rowSpan="16"><IMG height="193" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r28_c3.gif"
														width="41" border="0" name="ProcesoEstrategico2007_2011_r28_c3"></TD>
												<TD rowSpan="13"><IMG height="164" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r28_c5.gif"
														width="12" border="0" name="ProcesoEstrategico2007_2011_r28_c5"></TD>
												<TD colSpan="4" rowSpan="12"><IMG height="158" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r28_c6.gif"
														width="46" border="0" name="ProcesoEstrategico2007_2011_r28_c6"></TD>
												<TD><IMG height="2" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="2"><A onmouseover="MM_swapImage('e_idepriopo','','../../imagenes/e_idepriopo_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/e_idepriopo.gif" width="71" border="0" name="e_idepriopo"
															id="btnIdentificacionyPriorizacionDeOportunidades" runat="server"></A></TD>
												<TD colSpan="3" rowSpan="2"><A onmouseover="MM_swapImage('pe_facclaexi','','../../imagenes/pe_facclaexi_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_facclaexi.gif" width="71" border="0" name="pe_facclaexi"
															id="btnFactoresClavesDeExito" runat="server"></A></TD>
												<TD><IMG height="35" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="3" rowSpan="2"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r30_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r30_c27"></TD>
												<TD><IMG height="3" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="2"><IMG height="10" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r31_c14.gif"
														width="71" border="0" name="ProcesoEstrategico2007_2011_r31_c14"></TD>
												<TD colSpan="3" rowSpan="2"><IMG height="10" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r31_c19.gif"
														width="71" border="0" name="ProcesoEstrategico2007_2011_r31_c19"></TD>
												<TD><IMG height="2" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="3" rowSpan="2"><A onmouseover="MM_swapImage('pe_estmetseg','','../../imagenes/pe_estmetseg_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_estmetseg.gif" width="71" border="0" name="pe_estmetseg"
															id="btnEstablecerMetodoSeguimiento" runat="server"></A></TD>
												<TD><IMG height="8" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD rowSpan="5"><IMG height="88" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r33_c14.gif"
														width="40" border="0" name="ProcesoEstrategico2007_2011_r33_c14"></TD>
												<TD colSpan="6" rowSpan="2"><A onmouseover="MM_swapImage('pe_anafoda','','../../imagenes/pe_anafoda_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="38" alt="" src="../../imagenes/pe_anafoda.gif" width="71" border="0" name="pe_anafoda"
															id="btnAnalisisFODA" runat="server"></A></TD>
												<TD rowSpan="7"><IMG height="108" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r33_c21.gif"
														width="39" border="0" name="ProcesoEstrategico2007_2011_r33_c21"></TD>
												<TD><IMG height="30" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="3"><IMG height="8" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r34_c27.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r34_c27"></TD>
												<TD><IMG height="8" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="6"><IMG height="5" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r35_c15.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r35_c15"></TD>
												<TD colSpan="2" rowSpan="5"><IMG height="70" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r35_c24.gif"
														width="33" border="0" name="ProcesoEstrategico2007_2011_r35_c24"></TD>
												<TD rowSpan="5"><IMG height="70" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r35_c26.gif"
														width="12" border="0" name="ProcesoEstrategico2007_2011_r35_c26"></TD>
												<TD rowSpan="5"><IMG height="70" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r35_c27.gif"
														width="28" border="0" name="ProcesoEstrategico2007_2011_r35_c27"></TD>
												<TD rowSpan="5"><IMG height="70" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r35_c28.gif"
														width="14" border="0" name="ProcesoEstrategico2007_2011_r35_c28"></TD>
												<TD colSpan="3" rowSpan="5"><IMG height="70" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r35_c29.gif"
														width="74" border="0" name="ProcesoEstrategico2007_2011_r35_c29"></TD>
												<TD><IMG height="5" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="6"><A onmouseover="MM_swapImage('pe_matest','','../../imagenes/pe_matest_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="39" alt="" src="../../imagenes/pe_matest.gif" width="71" border="0" name="pe_matest"
															id="btnMatrizDeEstrategias" runat="server"></A></TD>
												<TD><IMG height="39" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="6"><IMG height="6" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r37_c15.gif" width="71"
														border="0" name="ProcesoEstrategico2007_2011_r37_c15"></TD>
												<TD><IMG height="6" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="2" rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c12.gif"
														width="10" border="0" name="ProcesoEstrategico2007_2011_r38_c12"></TD>
												<TD colSpan="3" rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c14.gif"
														width="69" border="0" name="ProcesoEstrategico2007_2011_r38_c14"></TD>
												<TD colSpan="3" rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c17.gif"
														width="13" border="0" name="ProcesoEstrategico2007_2011_r38_c17"></TD>
												<TD rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c20.gif"
														width="29" border="0" name="ProcesoEstrategico2007_2011_r38_c20"></TD>
												<TD rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c22.gif"
														width="7" border="0" name="ProcesoEstrategico2007_2011_r38_c22"></TD>
												<TD rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c23.gif"
														width="2" border="0" name="ProcesoEstrategico2007_2011_r38_c23"></TD>
												<TD rowSpan="2"><IMG height="20" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r38_c38.gif"
														width="7" border="0" name="ProcesoEstrategico2007_2011_r38_c38"></TD>
												<TD colSpan="9" rowSpan="5"><A onmouseover="MM_swapImage('peretaliact','','../../imagenes/peretaliact_f2.gif',1);"
														onmouseout="MM_swapImgRestore();" href="#"><IMG height="42" alt="" src="../../imagenes/peretaliact.gif" width="149" border="0" name="peretaliact"
															id="btnRetroalimentacionyActualizacion" runat="server"></A></TD>
												<TD><IMG height="12" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="4" rowSpan="3"><IMG height="17" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r39_c48.gif"
														width="47" border="0" name="ProcesoEstrategico2007_2011_r39_c48"></TD>
												<TD><IMG height="8" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="33"><IMG height="6" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r40_c6.gif" width="503"
														border="0" name="ProcesoEstrategico2007_2011_r40_c6"></TD>
												<TD><IMG height="6" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="34" rowSpan="3"><IMG height="29" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r41_c5.gif" width="515"
														border="0" name="ProcesoEstrategico2007_2011_r41_c5"></TD>
												<TD><IMG height="3" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="5" rowSpan="2"><IMG height="26" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r42_c48.gif"
														width="55" border="0" name="ProcesoEstrategico2007_2011_r42_c48"></TD>
												<TD><IMG height="13" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="9"><IMG height="13" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r43_c39.gif"
														width="149" border="0" name="ProcesoEstrategico2007_2011_r43_c39"></TD>
												<TD><IMG height="13" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
											<TR>
												<TD colSpan="55"><IMG height="42" alt="" src="../../imagenes/ProcesoEstrategico2007_2011_r44_c2.gif" width="830"
														border="0" name="ProcesoEstrategico2007_2011_r44_c2"></TD>
												<TD><IMG height="42" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
											</TR>
										</TABLE>
										<IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
