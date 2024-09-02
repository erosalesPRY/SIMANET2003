<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="InformeLegal.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.InformeLegal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InformeLegal</title>
		<meta http-equiv="Content-Type" content="text/html;">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
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
	<body bgcolor="#ffffff" onunload="SubirHistorial();" onload="ObtenerHistorial();MM_preloadImages('../imagenes/Gestion_Legal_r3_c4_s2.gif','../imagenes/Gestion_Legal_r3_c6_s2.gif','../imagenes/Gestion_Legal_r5_c4_s2.gif','../imagenes/Gestion_Legal_r6_c6_s2.gif');"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table style="DISPLAY: inline-table" border="0" cellpadding="0" cellspacing="0" width="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<!-- fwtable fwsrc="Gestion_Legal.png" fwpage="Página 1" fwbase="Gestion_Legal.png" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
				<TR>
					<TD>
						<DIV align="center">
						</DIV>
						<DIV align="center">
							<table style="DISPLAY: inline-table" border="0" cellpadding="0" cellspacing="0" width="760">
								<!-- fwtable fwsrc="Gestion_Legal.png" fwpage="Página 1" fwbase="Gestion_Legal.png" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
								<tr>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="84" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="83" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="148" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="224" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="189" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="31" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="7"><img name="gestion_legal_r1_c1" src="../imagenes/gestion_legal_r1_c1.gif" width="760"
											height="98" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="98" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="4"><img name="gestion_legal_r2_c1" src="../imagenes/gestion_legal_r2_c1.gif" width="316"
											height="59" border="0" alt=""></td>
									<td rowspan="6"><img name="gestion_legal_r2_c5" src="../imagenes/gestion_legal_r2_c5.gif" width="224"
											height="254" border="0" alt=""></td>
									<td colspan="2"><img name="gestion_legal_r2_c6" src="../imagenes/gestion_legal_r2_c6.gif" width="220"
											height="59" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="59" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="6" colspan="3"><img name="gestion_legal_r3_c1" src="../imagenes/gestion_legal_r3_c1.gif" width="168"
											height="236" border="0" alt=""></td>
									<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('gestion_legal_r3_c4','','../imagenes/gestion_legal_r3_c4_s2.gif',1);"><img name="gestion_legal_r3_c4" src="../imagenes/gestion_legal_r3_c4.gif" width="148"
												height="38" border="0" alt="" id="ibtnCasosLegales" runat="server"></a></td>
									<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('gestion_legal_r3_c6','','../imagenes/gestion_legal_r3_c6_s2.gif',1);"><img name="gestion_legal_r3_c6" src="../imagenes/gestion_legal_r3_c6.gif" width="189"
												height="38" border="0" alt="" id="ibtnContratos" runat="server"></a></td>
									<td rowspan="8"><img name="gestion_legal_r3_c7" src="../imagenes/gestion_legal_r3_c7.gif" width="31"
											height="303" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="38" border="0" alt=""></td>
								</tr>
								<tr>
									<td><img name="gestion_legal_r4_c4" src="../imagenes/gestion_legal_r4_c4.gif" width="148"
											height="74" border="0" alt=""></td>
									<td rowspan="2"><img name="gestion_legal_r4_c6" src="../imagenes/gestion_legal_r4_c6.gif" width="189"
											height="75" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="74" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2"><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('gestion_legal_r5_c4','','../imagenes/gestion_legal_r5_c4_s2.gif',1);"><img name="gestion_legal_r5_c4" src="../imagenes/gestion_legal_r5_c4.gif" width="148"
												height="38" border="0" alt="" id="ibtnRegistroInmuebles" runat="server"></a></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								</tr>
								<tr>
									<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('gestion_legal_r6_c6','','../imagenes/gestion_legal_r6_c6_s2.gif',1);"><img name="gestion_legal_r6_c6" src="../imagenes/gestion_legal_r6_c6.gif" width="189"
												height="37" border="0" alt="" id="ibtnEspeciales" runat="server"></a></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="37" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="4"><img name="gestion_legal_r7_c4" src="../imagenes/gestion_legal_r7_c4.gif" width="148"
											height="153" border="0" alt=""></td>
									<td rowspan="4"><img name="gestion_legal_r7_c6" src="../imagenes/gestion_legal_r7_c6.gif" width="189"
											height="153" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="45" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="3"><img name="gestion_legal_r8_c5" src="../imagenes/gestion_legal_r8_c5.gif" width="224"
											height="108" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="41" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2"><img name="gestion_legal_r9_c1" src="../imagenes/gestion_legal_r9_c1.gif" width="1" height="67"
											border="0" alt=""></td>
									<td valign="top"><p style="MARGIN:0px"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
												src="../imagenes/atras.gif"></p>
									</td>
									<td rowspan="2"><img name="gestion_legal_r9_c3" src="../imagenes/gestion_legal_r9_c3.gif" width="83"
											height="67" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="19" border="0" alt=""></td>
								</tr>
								<tr>
									<td><img name="gestion_legal_r10_c2" src="../imagenes/gestion_legal_r10_c2.gif" width="84"
											height="48" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="48" border="0" alt=""></td>
								</tr>
							</table>
						</DIV>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
