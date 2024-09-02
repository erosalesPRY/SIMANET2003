<%@ Page language="c#" Codebehind="PlaneamientoEstrategico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlaneamientoEstrategico" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PlaneamientoEstrategico.gif</title>
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
	<body bgcolor="#ffffff" bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0"
		onunload="SubirHistorial();" onload="ObtenerHistorial();MM_preloadImages('../imagenes/GestionEstrategica_r2_c2_f2.gif','../imagenes/GestionEstrategica_r2_c4_f2.gif');">
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
							<table border="0" cellpadding="0" cellspacing="0" width="760" align="center">
								<tr>
									<td><img src="../imagenes/spacer.gif" width="147" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="175" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="226" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="175" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="37" height="1" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
								</tr>
								<tr>
									<td colspan="5"><img name="GestionEstrategica_r1_c1" src="../imagenes/GestionEstrategica_r1_c1.gif" width="760"
											height="215" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="215" border="0" alt=""></td>
								</tr>
								<tr>
									<td rowspan="2" background="../imagenes/GestionEstrategica_r2_c1.gif">
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P>&nbsp;</P>
										<P><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></P>
									</td>
									<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('GestionEstrategica_r2_c2','','../imagenes/GestionEstrategica_r2_c2_f2.gif',1);"><img name="GestionEstrategica_r2_c2" src="../imagenes/GestionEstrategica_r2_c2.gif" width="175"
												height="45" border="0" alt="" id="imgProcesoEstrategico" runat="server"></a></td>
									<td rowspan="2"><img name="GestionEstrategica_r2_c3" src="../imagenes/GestionEstrategica_r2_c3.gif" width="226"
											height="245" border="0" alt=""></td>
									<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('GestionEstrategica_r2_c4','','../imagenes/GestionEstrategica_r2_c4_f2.gif',1);"><img name="GestionEstrategica_r2_c4" src="../imagenes/GestionEstrategica_r2_c4.gif" width="175"
												height="45" border="0" alt="" id="imgPlanEstrategico" runat="server"></a></td>
									<td rowspan="2"><img name="GestionEstrategica_r2_c5" src="../imagenes/GestionEstrategica_r2_c5.gif" width="37"
											height="245" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="45" border="0" alt=""></td>
								</tr>
								<tr>
									<td><img name="GestionEstrategica_r3_c2" src="../imagenes/GestionEstrategica_r3_c2.gif" width="175"
											height="200" border="0" alt=""></td>
									<td><img name="GestionEstrategica_r3_c4" src="../imagenes/GestionEstrategica_r3_c4.gif" width="175"
											height="200" border="0" alt=""></td>
									<td><img src="../imagenes/spacer.gif" width="1" height="200" border="0" alt=""></td>
								</tr>
							</table>
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
