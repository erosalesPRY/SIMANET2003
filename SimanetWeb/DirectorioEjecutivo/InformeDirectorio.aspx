<%@ Page language="c#" Codebehind="InformeDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.InformeDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InformeDirectorio.gif</title>
		<meta http-equiv="Content-Type" content="text/html;">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>

		
		<script language="JavaScript">
		
<!-- 
function MM_displayStatusMsg(msgStr)  { //v1.0
  status=msgStr;
  document.MM_returnValue = true;
}

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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" bgcolor="#ffffff"
		onunload="SubirHistorial();" onload="ObtenerHistorial();MM_preloadImages('../imagenes/acuerdoDirectorio_r2_c4_s2.gif','../imagenes/acuerdoDirectorio_r2_c7_s2.gif','../imagenes/acuerdoDirectorio_r5_c4_s2.gif','../imagenes/acuerdoDirectorio_r5_c7_s2.gif','../imagenes/acuerdoDirectorio_r7_c4_s2.gif','../imagenes/acuerdoDirectorio_r7_c6_s2.gif');">
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
					<TD>
						<DIV align="center">
						</DIV>
						<DIV align="center">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="760" border="0"> <!-- fwtable fwsrc="DIRECTORIO.png" fwbase="InformeDirectorio.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
								<TR>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="84" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="35" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="168" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="228" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="166" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="76" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								<tr>
									<td colspan="9"><img name="acuerdoDirectorio_r1_c1" src="../imagenes/acuerdoDirectorio_r1_c1.gif" width="760"
											height="133" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="133" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="8" colspan="3"><img name="acuerdoDirectorio_r2_c1" src="../imagenes/acuerdoDirectorio_r2_c1.gif" width="120"
											height="260" border="0" alt=""></td>
									<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_displayStatusMsg('ACUERDOS DE DIRECTORIO');MM_swapImage('acuerdoDirectorio_r2_c4','','../imagenes/acuerdoDirectorio_r2_c4_s2.gif',1);return document.MM_returnValue"><img name="acuerdoDirectorio_r2_c4" src="../imagenes/acuerdoDirectorio_r2_c4.gif" width="168"
												height="38" border="0" alt="" id="ibtnAcuerdos" runat="server"></a></td>
									<td rowspan="5" colspan="2"><img name="acuerdoDirectorio_r2_c5" src="../imagenes/acuerdoDirectorio_r2_c5.gif" width="229"
											height="134" border="0" alt=""></td>
									<td rowspan="2"><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_displayStatusMsg('PERSONAL');MM_swapImage('acuerdoDirectorio_r2_c7','','../imagenes/acuerdoDirectorio_r2_c7_s2.gif',1);return document.MM_returnValue"><img name="acuerdoDirectorio_r2_c7" src="../imagenes/acuerdoDirectorio_r2_c7.gif" width="166"
												height="45" border="0" alt="" id="ibtnGestionLegal" runat="server"></a></td>
									<td rowspan="5" colspan="2"><img name="acuerdoDirectorio_r2_c8" src="../imagenes/acuerdoDirectorio_r2_c8.gif" width="77"
											height="134" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="38" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2"><img name="acuerdoDirectorio_r3_c4" src="../imagenes/acuerdoDirectorio_r3_c4.gif" width="168"
											height="22" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="7" border="0" alt=""></td>
								</tr>
								<tr>
									<td><img name="acuerdoDirectorio_r4_c7" src="../imagenes/acuerdoDirectorio_r4_c7.gif" width="166"
											height="15" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="15" border="0" alt=""></td>
								</tr>
								<tr>
									<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_displayStatusMsg('INFORME DE PROYECTOS');MM_swapImage('acuerdoDirectorio_r5_c4','','../imagenes/acuerdoDirectorio_r5_c4_s2.gif',1);return document.MM_returnValue"><img name="acuerdoDirectorio_r5_c4" src="../imagenes/acuerdoDirectorio_r5_c4.gif" width="168"
												height="45" border="0" alt="" id="ibtnGestionProyectos" runat="server"></a></td>
									<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_displayStatusMsg('CONVENIOS');MM_swapImage('acuerdoDirectorio_r5_c7','','../imagenes/acuerdoDirectorio_r5_c7_s2.gif',1);return document.MM_returnValue"><img name="acuerdoDirectorio_r5_c7" src="../imagenes/acuerdoDirectorio_r5_c7.gif" width="166"
												height="45" border="0" alt="" id="ibtnGestionFinanciera" runat="server"></a></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="45" border="0" alt=""></td>
								</tr>
								<tr>
									<td><img name="acuerdoDirectorio_r6_c4" src="../imagenes/acuerdoDirectorio_r6_c4.gif" width="168"
											height="29" border="0" alt=""></td>
									<td><img name="acuerdoDirectorio_r6_c7" src="../imagenes/acuerdoDirectorio_r6_c7.gif" width="166"
											height="29" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="29" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2"><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_displayStatusMsg('REGISTRO DE INMUEBLES');MM_swapImage('acuerdoDirectorio_r7_c4','','../imagenes/acuerdoDirectorio_r7_c4_s2.gif',1);return document.MM_returnValue"><img name="acuerdoDirectorio_r7_c4" src="../imagenes/acuerdoDirectorio_r7_c4.gif" width="168"
												height="45" border="0" alt="" id="ibtnGestionComercial" runat="server"></a></td>
									<td rowspan="5"><img name="acuerdoDirectorio_r7_c5" src="../imagenes/acuerdoDirectorio_r7_c5.gif" width="228"
											height="193" border="0" alt=""></td>
									<td colspan="3"><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_displayStatusMsg('PROYECTOS DE INVERSION PÚBLICA');MM_swapImage('acuerdoDirectorio_r7_c6','','../imagenes/acuerdoDirectorio_r7_c6_s2.gif',1);return document.MM_returnValue"><img name="acuerdoDirectorio_r7_c6" src="../imagenes/acuerdoDirectorio_r7_c6.gif" width="168"
												height="44" border="0" alt="" id="ibtnVarios" runat="server"></a></td>
									<td rowspan="5"><img name="acuerdoDirectorio_r7_c9" src="../imagenes/acuerdoDirectorio_r7_c9.gif" width="76"
											height="193" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="44" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="4" colspan="3"><img name="acuerdoDirectorio_r8_c6" src="../imagenes/acuerdoDirectorio_r8_c6.gif" width="168"
											height="149" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="3"><img name="acuerdoDirectorio_r9_c4" src="../imagenes/acuerdoDirectorio_r9_c4.gif" width="168"
											height="148" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="81" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2"><img name="acuerdoDirectorio_r10_c1" src="../imagenes/acuerdoDirectorio_r10_c1.gif" width="1"
											height="67" border="0" alt=""></td>
									<td valign="top"><p style="MARGIN:0px"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
												src="../imagenes/atras.gif"></p>
									</td>
									<td rowspan="2"><img name="acuerdoDirectorio_r10_c3" src="../imagenes/acuerdoDirectorio_r10_c3.gif" width="35"
											height="67" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="19" border="0" alt=""></td>
								</tr>
								<tr>
									<td><img name="acuerdoDirectorio_r11_c2" src="../imagenes/acuerdoDirectorio_r11_c2.gif" width="84"
											height="48" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="48" border="0" alt=""></td>
								</tr>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
