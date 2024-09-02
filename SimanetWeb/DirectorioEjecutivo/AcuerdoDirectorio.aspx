<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AcuerdoDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.AcuerdoDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Acuerdos Directorio</title>
		<meta http-equiv="Content-Type" content="text/html;">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		
		<script language="JavaScript">

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
		</script>
</HEAD>
	<body bgcolor="#ffffff" onLoad="ObtenerHistorial();MM_preloadImages('../imagenes/acu_directorio_r3_c4_s2.gif','../imagenes/acu_directorio_r3_c7_s2.gif','../imagenes/acu_directorio_r5_c5_s2.gif','../imagenes/acu_directorio_r5_c7_s2.gif');"
		onunload="SubirHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" DESIGNTIMEDRAGDROP="78">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0"> <!-- fwtable fwsrc="Acuerdo de Directorio v1.png" fwbase="AcuerdoDirectorio.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<!-- fwtable fwsrc="Acuerdo de Directorio.png" fwpage="Página 1" fwbase="acu_directorio.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<tr>
								<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="84" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="83" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="147" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="224" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="189" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="31" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="8"><img name="acu_directorio_r1_c1" src="../imagenes/acu_directorio_r1_c1.gif" width="760"
										height="98" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="98" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="5"><img name="acu_directorio_r2_c1" src="../imagenes/acu_directorio_r2_c1.gif" width="316"
										height="59" border="0" alt=""></td>
								<td rowspan="6"><img name="acu_directorio_r2_c6" src="../imagenes/acu_directorio_r2_c6.gif" width="224"
										height="254" border="0" alt=""></td>
								<td colspan="2"><img name="acu_directorio_r2_c7" src="../imagenes/acu_directorio_r2_c7.gif" width="220"
										height="59" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="59" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="6" colspan="3"><img name="acu_directorio_r3_c1" src="../imagenes/acu_directorio_r3_c1.gif" width="168"
										height="236" border="0" alt=""></td>
								<td colspan="2"><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('acu_directorio_r3_c4','','../imagenes/acu_directorio_r3_c4_s2.gif',1);"><img name="acu_directorio_r3_c4" src="../imagenes/acu_directorio_r3_c4.gif" width="148"
											height="38" border="0" alt="" id="ibtnSimaPeru" runat="server"></a></td>
								<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('acu_directorio_r3_c7','','../imagenes/acu_directorio_r3_c7_s2.gif',1);"><img name="acu_directorio_r3_c7" src="../imagenes/acu_directorio_r3_c7.gif" width="189"
											height="38" border="0" alt="" id="ibtnPermanentes" runat="server"></a></td>
								<td rowspan="8"><img name="acu_directorio_r3_c8" src="../imagenes/acu_directorio_r3_c8.gif" width="31"
										height="303" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="38" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="2"><img name="acu_directorio_r4_c4" src="../imagenes/acu_directorio_r4_c4.gif" width="148"
										height="74" border="0" alt=""></td>
								<td><img name="acu_directorio_r4_c7" src="../imagenes/acu_directorio_r4_c7.gif" width="189"
										height="74" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="74" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="6"><img name="acu_directorio_r5_c4" src="../imagenes/acu_directorio_r5_c4.gif" width="1"
										height="191" border="0" alt=""></td>
								<td><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('acu_directorio_r5_c5','','../imagenes/acu_directorio_r5_c5_s2.gif',1);"><img name="acu_directorio_r5_c5" src="../imagenes/acu_directorio_r5_c5.gif" width="147"
											height="38" border="0" alt="" id="ibtnSimaIquitos" runat="server"></a></td>
								<td rowspan="2"><a href="javascript:;" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('acu_directorio_r5_c7','','../imagenes/acu_directorio_r5_c7_s2.gif',1);"><img name="acu_directorio_r5_c7" src="../imagenes/acu_directorio_r5_c7.gif" width="189"
											height="44" border="0" alt="" id="ibtnTemas" runat="server"></a></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="38" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="5"><img name="acu_directorio_r6_c5" src="../imagenes/acu_directorio_r6_c5.gif" width="147"
										height="153" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="6" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="4"><img name="acu_directorio_r7_c7" src="../imagenes/acu_directorio_r7_c7.gif" width="189"
										height="147" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="39" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="3"><img name="acu_directorio_r8_c6" src="../imagenes/acu_directorio_r8_c6.gif" width="224"
										height="108" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="41" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="2"><img name="acu_directorio_r9_c1" src="../imagenes/acu_directorio_r9_c1.gif" width="1"
										height="67" border="0" alt=""></td>
								<td valign="top" bgcolor="#e3e3e3"><p style="MARGIN:0px"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
											src="../imagenes/atras.gif"></p>
								</td>
								<td rowspan="2"><img name="acu_directorio_r9_c3" src="../imagenes/acu_directorio_r9_c3.gif" width="83"
										height="67" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="19" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="acu_directorio_r10_c2" src="../imagenes/acu_directorio_r10_c2.gif" width="84"
										height="48" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="48" border="0" alt=""></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
