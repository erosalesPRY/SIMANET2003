<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AcuerdosPermanentes.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.AcuerdosPermanentes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AcuerdoDirectorio.gif</title>
		<meta http-equiv="Content-Type" content="text/html;">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		
		
		
		<script language="JavaScript"><!--
		
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
	<body bottomMargin="0" bgColor="#ffffff" leftMargin="0" topMargin="0" onunload="SubirHistorial();"
		onload="ObtenerHistorial();MM_preloadImages('../imagenes/AcuerdoPermanente_r2_c2_f2.gif','../imagenes/AcuerdoPermanente_r2_c4_f2.gif');"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" DESIGNTIMEDRAGDROP="78">
				<TR>
					<TD><uc1:headerinicio id="HeaderInicio1" runat="server"></uc1:headerinicio></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD>
						<TABLE cellSpacing="0" cellPadding="0" width="760" align="center" border="0"> <!-- fwtable fwsrc="Acuerdo de Directorio v1.png" fwbase="AcuerdoDirectorio.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<tr>
								<td><img src="../imagenes/spacer.gif" width="144" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="153" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="272" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="147" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="44" height="1" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="5"><img name="AcuerdoPermanente_r1_c1" src="../imagenes/AcuerdoPermanente_r1_c1.gif" width="760"
										height="226" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="226" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="3" background="../imagenes/AcuerdoPermanente_r2_c1.gif">
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></P>
								</td>
								<td rowspan="2"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('AcuerdoPermanente_r2_c2','','../imagenes/AcuerdoPermanente_r2_c2_f2.gif',1);"><img name="AcuerdoPermanente_r2_c2" src="../imagenes/AcuerdoPermanente_r2_c2.gif" width="153"
											height="45" border="0" alt="" runat="server" id="ibtnSimaPeru"></a></td>
								<td rowspan="3"><img name="AcuerdoPermanente_r2_c3" src="../imagenes/AcuerdoPermanente_r2_c3.gif" width="272"
										height="234" border="0" alt=""></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('AcuerdoPermanente_r2_c4','','../imagenes/AcuerdoPermanente_r2_c4_f2.gif',1);"><img name="AcuerdoPermanente_r2_c4" src="../imagenes/AcuerdoPermanente_r2_c4.gif" width="147"
											height="38" border="0" alt="" id="ibtnSimaIquitos" runat="server"></a></td>
								<td rowspan="3"><img name="AcuerdoPermanente_r2_c5" src="../imagenes/AcuerdoPermanente_r2_c5.gif" width="44"
										height="234" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="38" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="2"><img name="AcuerdoPermanente_r3_c4" src="../imagenes/AcuerdoPermanente_r3_c4.gif" width="147"
										height="196" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="7" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="AcuerdoPermanente_r4_c2" src="../imagenes/AcuerdoPermanente_r4_c2.gif" width="153"
										height="189" border="0" alt=""></td>
								<td><img src="../imagenes/spacer.gif" width="1" height="189" border="0" alt=""></td>
							</tr>
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
