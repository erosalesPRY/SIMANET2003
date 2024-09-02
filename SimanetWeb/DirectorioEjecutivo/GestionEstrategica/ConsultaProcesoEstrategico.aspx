<%@ Page language="c#" Codebehind="ConsultaProcesoEstrategico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaProcesoEstrategico" %>
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
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" border="0"> <!-- fwtable fwsrc="PROCESO ESTRATEGICO v1.png" fwbase="ProcesoEstrategico.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
								<TR>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="107" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="7" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="112" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="44" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="91" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="26" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="64" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="22" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="95" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="50" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="112" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="30" border="0"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD colSpan="12"><IMG height="88" alt="" src="../../imagenes/ProcesoEstrategico_r1_c1.gif" width="760"
											border="0" name="ProcesoEstrategico_r1_c1"></TD>
									<TD><IMG height="88" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD background="../../imagenes/ProcesoEstrategico_r2_c1.gif" rowSpan="23"><P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>
											<IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></P>
									</TD>
									<TD colSpan="11" rowSpan="2">
										<P align="center">
											<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul"></asp:Label></P>
									</TD>
									<TD><IMG height="33" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="21"><IMG height="338" alt="" src="../../imagenes/ProcesoEstrategico_r4_c2.gif" width="7"
											border="0" name="ProcesoEstrategico_r4_c2"></TD>
									<TD rowSpan="2"><A onmouseover="MM_swapImage('ProcesoEstrategico_r4_c3','','../../imagenes/ProcesoEstrategico_r4_c3_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r4_c3.gif" width="112"
												border="0" name="ProcesoEstrategico_r4_c3" id="imgObjetoSocial" runat="server"></A></TD>
									<TD colSpan="7" rowSpan="5"><IMG height="84" alt="" src="../../imagenes/ProcesoEstrategico_r4_c4.gif" width="392"
											border="0" name="ProcesoEstrategico_r4_c4"></TD>
									<TD><A onmouseover="MM_swapImage('ProcesoEstrategico_r4_c11','','../../imagenes/ProcesoEstrategico_r4_c11_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="33" alt="" src="../../imagenes/ProcesoEstrategico_r4_c11.gif" width="112"
												border="0" name="ProcesoEstrategico_r4_c11" id="imgMarcoLegal" runat="server"></A></TD>
									<TD rowSpan="21"><IMG height="338" alt="" src="../../imagenes/ProcesoEstrategico_r4_c12.gif" width="30"
											border="0" name="ProcesoEstrategico_r4_c12"></TD>
									<TD><IMG height="33" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="2"><IMG height="28" alt="" src="../../imagenes/ProcesoEstrategico_r5_c11.gif" width="112"
											border="0" name="ProcesoEstrategico_r5_c11"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="2"><IMG height="28" alt="" src="../../imagenes/ProcesoEstrategico_r6_c3.gif" width="112"
											border="0" name="ProcesoEstrategico_r6_c3"></TD>
									<TD><IMG height="27" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r7_c11','','../../imagenes/ProcesoEstrategico_r7_c11_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r7_c11.gif" width="112"
												border="0" name="ProcesoEstrategico_r7_c11" id="imgPoliticasGenerales" runat="server"></A></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r8_c3','','../../imagenes/ProcesoEstrategico_r8_c3_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r8_c3.gif" width="112"
												border="0" name="ProcesoEstrategico_r8_c3" id="imgMision" runat="server"></A></TD>
									<TD><IMG height="22" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="16"><IMG height="254" alt="" src="../../imagenes/ProcesoEstrategico_r9_c4.gif" width="44"
											border="0" name="ProcesoEstrategico_r9_c4"></TD>
									<TD colSpan="2" rowSpan="5"><A onmouseover="MM_swapImage('ProcesoEstrategico_r9_c5','','../../imagenes/ProcesoEstrategico_r9_c5_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="62" alt="" src="../../imagenes/ProcesoEstrategico_r9_c5.gif" width="117"
												border="0" name="ProcesoEstrategico_r9_c5" id="imgDiagnosticoSituacional" runat="server"></A></TD>
									<TD rowSpan="10"><IMG height="99" alt="" src="../../imagenes/ProcesoEstrategico_r9_c7.gif" width="64"
											border="0" name="ProcesoEstrategico_r9_c7"></TD>
									<TD colSpan="2" rowSpan="5"><A onmouseover="MM_swapImage('ProcesoEstrategico_r9_c8','','../../imagenes/ProcesoEstrategico_r9_c8_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="62" alt="" src="../../imagenes/ProcesoEstrategico_r9_c8.gif" width="117"
												border="0" name="ProcesoEstrategico_r9_c8" id="imgOGenerales" runat="server"></A></TD>
									<TD rowSpan="16"><IMG height="254" alt="" src="../../imagenes/ProcesoEstrategico_r9_c10.gif" width="50"
											border="0" name="ProcesoEstrategico_r9_c10"></TD>
									<TD><IMG height="11" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><IMG height="28" alt="" src="../../imagenes/ProcesoEstrategico_r10_c11.gif" width="112"
											border="0" name="ProcesoEstrategico_r10_c11"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD><IMG height="26" alt="" src="../../imagenes/ProcesoEstrategico_r11_c3.gif" width="112"
											border="0" name="ProcesoEstrategico_r11_c3"></TD>
									<TD><IMG height="26" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r12_c3','','../../imagenes/ProcesoEstrategico_r12_c3_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r12_c3.gif" width="112"
												border="0" name="ProcesoEstrategico_r12_c3" id="imgVision" runat="server"></A></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r13_c11','','../../imagenes/ProcesoEstrategico_r13_c11_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r13_c11.gif" width="112"
												border="0" name="ProcesoEstrategico_r13_c11" id="imgLineamientosGenerales" runat="server"></A></TD>
									<TD><IMG height="23" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD colSpan="2" rowSpan="5"><IMG height="37" alt="" src="../../imagenes/ProcesoEstrategico_r14_c5.gif" width="117"
											border="0" name="ProcesoEstrategico_r14_c5"></TD>
									<TD colSpan="2" rowSpan="5"><IMG height="37" alt="" src="../../imagenes/ProcesoEstrategico_r14_c8.gif" width="117"
											border="0" name="ProcesoEstrategico_r14_c8"></TD>
									<TD><IMG height="10" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="2"><IMG height="25" alt="" src="../../imagenes/ProcesoEstrategico_r15_c3.gif" width="112"
											border="0" name="ProcesoEstrategico_r15_c3"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="2"><IMG height="25" alt="" src="../../imagenes/ProcesoEstrategico_r16_c11.gif" width="112"
											border="0" name="ProcesoEstrategico_r16_c11"></TD>
									<TD><IMG height="24" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r17_c3','','../../imagenes/ProcesoEstrategico_r17_c3_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r17_c3.gif" width="112"
												border="0" name="ProcesoEstrategico_r17_c3" id="imgValores" runat="server"></A></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r18_c11','','../../imagenes/ProcesoEstrategico_r18_c11_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r18_c11.gif" width="112"
												border="0" name="ProcesoEstrategico_r18_c11" id="imgAlineamiento" runat="server"></A></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="6"><IMG height="155" alt="" src="../../imagenes/ProcesoEstrategico_r19_c5.gif" width="91"
											border="0" name="ProcesoEstrategico_r19_c5"></TD>
									<TD colSpan="3" rowSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r19_c6','','../../imagenes/ProcesoEstrategico_r19_c6_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r19_c6.gif" width="112"
												border="0" name="ProcesoEstrategico_r19_c6" id="IMG2"></A></TD>
									<TD rowSpan="6"><IMG height="155" alt="" src="../../imagenes/ProcesoEstrategico_r19_c9.gif" width="95"
											border="0" name="ProcesoEstrategico_r19_c9"></TD>
									<TD><IMG height="32" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="5"><IMG height="123" alt="" src="../../imagenes/ProcesoEstrategico_r20_c3.gif" width="112"
											border="0" name="ProcesoEstrategico_r20_c3"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="4"><IMG height="122" alt="" src="../../imagenes/ProcesoEstrategico_r21_c11.gif" width="112"
											border="0" name="ProcesoEstrategico_r21_c11"></TD>
									<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD colSpan="3"><IMG height="28" alt="" src="../../imagenes/ProcesoEstrategico_r22_c6.gif" width="112"
											border="0" name="ProcesoEstrategico_r22_c6"></TD>
									<TD><IMG height="28" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD colSpan="3"><A onmouseover="MM_swapImage('ProcesoEstrategico_r23_c6','','../../imagenes/ProcesoEstrategico_r23_c6_f2.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/ProcesoEstrategico_r23_c6.gif" width="112"
												border="0" name="ProcesoEstrategico_r23_c6" id="imgIdentidad" runat="server"></A></TD>
									<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD colSpan="3"><IMG height="59" alt="" src="../../imagenes/ProcesoEstrategico_r24_c6.gif" width="112"
											border="0" name="ProcesoEstrategico_r24_c6"></TD>
									<TD><IMG height="59" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<P>&nbsp;</P>
		<P align="center">&nbsp;</P>
	</body>
</HTML>
