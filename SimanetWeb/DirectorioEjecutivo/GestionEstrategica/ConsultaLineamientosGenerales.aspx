<%@ Page language="c#" Codebehind="ConsultaLineamientosGenerales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaLineamientosGenerales" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaLineamientosGenerales</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial(),MM_preloadImages('imagenes/LineamientoEstrategico_r4_c3_f2.gif','imagenes/LineamientoEstrategico_r4_c5_f2.gif','imagenes/LineamientoEstrategico_r6_c3_f2.gif','imagenes/LineamientoEstrategico_r6_c5_f2.gif','imagenes/LineamientoEstrategico_r8_c3_f2.gif','imagenes/LineamientoEstrategico_r8_c5_f2.gif');"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" align="center" border="0"> <!-- fwtable fwsrc="LINEAMIENTOS GENERALES.png" fwbase="LineamientoEstrategico.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<TR>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="103" border="0"></TD>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="145" border="0"></TD>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="112" border="0"></TD>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="127" border="0"></TD>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="112" border="0"></TD>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="161" border="0"></TD>
								<TD><IMG height="1" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD colSpan="6"><IMG height="86" alt="" src="../../imagenes/LineamientoEstrategico_r1_c1.gif" width="760"
										border="0" name="LineamientoEstrategico_r1_c1"></TD>
								<TD><IMG height="86" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD background="../../imagenes/LineamientoEstrategico_r2_c1.gif" rowSpan="8">
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></P>
								</TD>
								<TD colSpan="5">
									<P align="center">
										<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul"></asp:Label></P>
								</TD>
								<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD colSpan="5"><IMG height="40" alt="" src="../../imagenes/LineamientoEstrategico_r3_c2.gif" width="657"
										border="0" name="LineamientoEstrategico_r3_c2"></TD>
								<TD><IMG height="40" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD rowSpan="7"><IMG height="300" alt="" src="../../imagenes/LineamientoEstrategico_r4_c2.gif" width="145"
										border="0" name="LineamientoEstrategico_r4_c2"></TD>
								<TD><A onmouseover="MM_swapImage('LineamientoEstrategico_r4_c3','','../../imagenes/LineamientoEstrategico_r4_c3_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/LineamientoEstrategico_r4_c3.gif" width="112"
											border="0" name="LineamientoEstrategico_r4_c3" id="ibtnCongemar" runat="server"></A></TD>
								<TD rowSpan="7"><IMG height="300" alt="" src="../../imagenes/LineamientoEstrategico_r4_c4.gif" width="127"
										border="0" name="LineamientoEstrategico_r4_c4"></TD>
								<TD><A onmouseover="MM_swapImage('LineamientoEstrategico_r4_c5','','../../imagenes/LineamientoEstrategico_r4_c5_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/LineamientoEstrategico_r4_c5.gif" width="112"
											border="0" name="LineamientoEstrategico_r4_c5" id="ibtnFuerzasNavales" runat="server"></A></TD>
								<TD rowSpan="7"><IMG height="300" alt="" src="../../imagenes/LineamientoEstrategico_r4_c6.gif" width="161"
										border="0" name="LineamientoEstrategico_r4_c6"></TD>
								<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><IMG height="35" alt="" src="../../imagenes/LineamientoEstrategico_r5_c3.gif" width="112"
										border="0" name="LineamientoEstrategico_r5_c3"></TD>
								<TD><IMG height="35" alt="" src="../../imagenes/LineamientoEstrategico_r5_c5.gif" width="112"
										border="0" name="LineamientoEstrategico_r5_c5"></TD>
								<TD><IMG height="35" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><A onmouseover="MM_swapImage('LineamientoEstrategico_r6_c3','','../../imagenes/LineamientoEstrategico_r6_c3_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/LineamientoEstrategico_r6_c3.gif" width="112"
											border="0" name="LineamientoEstrategico_r6_c3" id="ibtnJemgemar" runat="server"></A></TD>
								<TD><A onmouseover="MM_swapImage('LineamientoEstrategico_r6_c5','','../../imagenes/LineamientoEstrategico_r6_c5_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/LineamientoEstrategico_r6_c5.gif" width="112"
											border="0" name="LineamientoEstrategico_r6_c5" id="ibtnDireccionEjecutiva" runat="server"></A></TD>
								<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><IMG height="31" alt="" src="../../imagenes/LineamientoEstrategico_r7_c3.gif" width="112"
										border="0" name="LineamientoEstrategico_r7_c3"></TD>
								<TD><IMG height="31" alt="" src="../../imagenes/LineamientoEstrategico_r7_c5.gif" width="112"
										border="0" name="LineamientoEstrategico_r7_c5"></TD>
								<TD><IMG height="31" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><A onmouseover="MM_swapImage('LineamientoEstrategico_r8_c3','','../../imagenes/LineamientoEstrategico_r8_c3_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/LineamientoEstrategico_r8_c3.gif" width="112"
											border="0" name="LineamientoEstrategico_r8_c3" id="ibtnComiteEvaluacion" runat="server"></A></TD>
								<TD><A onmouseover="MM_swapImage('LineamientoEstrategico_r8_c5','','../../imagenes/LineamientoEstrategico_r8_c5_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG height="34" alt="" src="../../imagenes/LineamientoEstrategico_r8_c5.gif" width="112"
											border="0" name="LineamientoEstrategico_r8_c5" id="ibtnRequerimientosElaboracion" runat="server"></A></TD>
								<TD><IMG height="34" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD rowSpan="2"><IMG height="132" alt="" src="../../imagenes/LineamientoEstrategico_r9_c3.gif" width="112"
										border="0" name="LineamientoEstrategico_r9_c3"></TD>
								<TD rowSpan="2"><IMG height="132" alt="" src="../../imagenes/LineamientoEstrategico_r9_c5.gif" width="112"
										border="0" name="LineamientoEstrategico_r9_c5"></TD>
								<TD><IMG height="91" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><IMG height="41" alt="" src="../../imagenes/LineamientoEstrategico_r10_c1.gif" width="103"
										border="0" name="LineamientoEstrategico_r10_c1"></TD>
								<TD><IMG height="41" alt="" src="../../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
