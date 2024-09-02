<%@ Page language="c#" Codebehind="ConsultaIdentidad.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaIdentidad" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaIdentidad</title>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial(),MM_preloadImages('imagenes/Identidad_r3_c3_f2.gif','../../imagenes/Identidad_r3_c5_f2.gif','../../imagenes/Identidad_r3_c7_f2.gif','../../imagenes/Identidad_r5_c3_f2.gif','../../imagenes/Identidad_r5_c5_f2.gif','../../imagenes/Identidad_r5_c7_f2.gif','../../imagenes/Identidad_r7_c3_f2.gif','../../imagenes/Identidad_r7_c5_f2.gif','../../imagenes/Identidad_r7_c7_f2.gif','../../imagenes/Identidad_r9_c3_f2.gif','../../imagenes/Identidad_r9_c5_f2.gif','../../imagenes/Identidad_r9_c7_f2.gif','../../imagenes/Identidad_r11_c5_f2.gif');"
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
					<TD class="commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Proceso Estratégico > Consultar  Identidad</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table border="0" cellpadding="0" cellspacing="0" width="760" align="center">
							<tr>
								<td><img src="../../imagenes/spacer.gif" width="103" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="68" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="112" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="92" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="112" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="85" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="112" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="75" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="9"><img name="Identidad_r1_c1" src="../../imagenes/Identidad_r1_c1.gif" width="760" height="101"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="101" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="10" background="../../imagenes/Identidad_r2_c1.gif">
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P><IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></P>
								</td>
								<td colspan="7" background="../../imagenes/Identidad_r2_c2.gif">
									<P align="center">
										<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul"></asp:Label></P>
								</td>
								<td rowspan="10"><img name="Identidad_r2_c9" src="../../imagenes/Identidad_r2_c9.gif" width="1" height="359"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="42" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="7"><img name="Identidad_r3_c2" src="../../imagenes/Identidad_r3_c2.gif" width="656" height="24"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="24" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="8"><img name="Identidad_r4_c2" src="../../imagenes/Identidad_r4_c2.gif" width="68" height="293"
										border="0" alt=""></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r4_c3','','../../imagenes/Identidad_r4_c3_f2.gif',1);"><img name="Identidad_r4_c3" src="../../imagenes/Identidad_r4_c3.gif" width="112" height="34"
											border="0" alt="" id="ibtnEscudo" runat="server"></a></td>
								<td rowspan="8"><img name="Identidad_r4_c4" src="../../imagenes/Identidad_r4_c4.gif" width="92" height="293"
										border="0" alt=""></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r4_c5','','../../imagenes/Identidad_r4_c5_f2.gif',1);"><img name="Identidad_r4_c5" src="../../imagenes/Identidad_r4_c5.gif" width="112" height="34"
											border="0" alt="" id="ibtnLema" runat="server"></a></td>
								<td rowspan="8"><img name="Identidad_r4_c6" src="../../imagenes/Identidad_r4_c6.gif" width="85" height="293"
										border="0" alt=""></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r4_c7','','../../imagenes/Identidad_r4_c7_f2.gif',1);"><img name="Identidad_r4_c7" src="../../imagenes/Identidad_r4_c7.gif" width="112" height="34"
											border="0" alt="" id="ibtnLogotipo" runat="server"></a></td>
								<td rowspan="8"><img name="Identidad_r4_c8" src="../../imagenes/Identidad_r4_c8.gif" width="75" height="293"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="Identidad_r5_c3" src="../../imagenes/Identidad_r5_c3.gif" width="112" height="19"
										border="0" alt=""></td>
								<td><img name="Identidad_r5_c5" src="../../imagenes/Identidad_r5_c5.gif" width="112" height="19"
										border="0" alt=""></td>
								<td><img name="Identidad_r5_c7" src="../../imagenes/Identidad_r5_c7.gif" width="112" height="19"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="19" border="0" alt=""></td>
							</tr>
							<tr>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r6_c3','','../../imagenes/Identidad_r6_c3_f2.gif',1);"><img name="Identidad_r6_c3" src="../../imagenes/Identidad_r6_c3.gif" width="112" height="34"
											border="0" alt="" id="ibtnReseña" runat="server"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r6_c5','','../../imagenes/Identidad_r6_c5_f2.gif',1);"><img name="Identidad_r6_c5" src="../../imagenes/Identidad_r6_c5.gif" width="112" height="34"
											border="0" alt="" id="ibtnHimno" runat="server"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r6_c7','','../../imagenes/Identidad_r6_c7_f2.gif',1);"><img name="Identidad_r6_c7" src="../../imagenes/Identidad_r6_c7.gif" width="112" height="34"
											border="0" alt="" id="ibtnPolka" runat="server"></a></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="Identidad_r7_c3" src="../../imagenes/Identidad_r7_c3.gif" width="112" height="19"
										border="0" alt=""></td>
								<td><img name="Identidad_r7_c5" src="../../imagenes/Identidad_r7_c5.gif" width="112" height="19"
										border="0" alt=""></td>
								<td><img name="Identidad_r7_c7" src="../../imagenes/Identidad_r7_c7.gif" width="112" height="19"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="19" border="0" alt=""></td>
							</tr>
							<tr>
								<td><A onmouseover="MM_swapImage('Identidad_r10_c5','','../../imagenes/Identidad_r10_c5_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><img name="Identidad_r10_c5" src="../../imagenes/Identidad_r10_c5.gif" width="112" height="34"
											border="0" alt="" id="ibtnCadenaValor" runat="server"></A><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r8_c3','','../../imagenes/Identidad_r8_c3_f2.gif',1);"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r8_c5','','../../imagenes/Identidad_r8_c5_f2.gif',1);"><img name="Identidad_r8_c5" src="../../imagenes/Identidad_r8_c5.gif" width="112" height="34"
											border="0" alt="" id="ibtnLineasNegocio" runat="server"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r8_c7','','../../imagenes/Identidad_r8_c7_f2.gif',1);"><img name="Identidad_r8_c7" src="../../imagenes/Identidad_r8_c7.gif" width="112" height="34"
											border="0" alt="" id="ibtnAlcanceCertificacion" runat="server"></a></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="Identidad_r9_c3" src="../../imagenes/Identidad_r9_c3.gif" width="112" height="18"
										border="0" alt=""></td>
								<td><img name="Identidad_r9_c5" src="../../imagenes/Identidad_r9_c5.gif" width="112" height="18"
										border="0" alt=""></td>
								<td><img name="Identidad_r9_c7" src="../../imagenes/Identidad_r9_c7.gif" width="112" height="18"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="18" border="0" alt=""></td>
							</tr>
							<tr>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r10_c3','','../../imagenes/Identidad_r10_c3_f2.gif',1);"><img name="Identidad_r10_c3" src="../../imagenes/Identidad_r10_c3.gif" width="112" height="34"
											border="0" alt="" id="ibtnDiagramaInfluencia" runat="server"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r10_c5','','../../imagenes/Identidad_r10_c5_f2.gif',1);"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('Identidad_r10_c7','','../../imagenes/Identidad_r10_c7_f2.gif',1);"><img name="Identidad_r10_c7" src="../../imagenes/Identidad_r10_c7.gif" width="112" height="34"
											border="0" alt="" id="ibtnIteraccionProcesos" runat="server"></a></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="Identidad_r11_c3" src="../../imagenes/Identidad_r11_c3.gif" width="112" height="101"
										border="0" alt=""></td>
								<td><img name="Identidad_r11_c5" src="../../imagenes/Identidad_r11_c5.gif" width="112" height="101"
										border="0" alt=""></td>
								<td><img name="Identidad_r11_c7" src="../../imagenes/Identidad_r11_c7.gif" width="112" height="101"
										border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="101" border="0" alt=""></td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
