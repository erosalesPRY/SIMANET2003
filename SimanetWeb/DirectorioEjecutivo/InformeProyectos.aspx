<%@ Page language="c#" Codebehind="InformeProyectos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.InformeProyectos" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InformeProyectos.gif</title>
		<meta http-equiv="Content-Type" content="text/html;">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" bgcolor="#ffffff"
		onunload="SubirHistorial();" onload="ObtenerHistorial(); MM_preloadImages('../imagenes/GestionProyectos_r2_c2_f2.gif','../imagenes/GestionProyectos_r3_c6_f2.gif','../imagenes/GestionProyectos_r6_c3_f2.gif','../imagenes/GestionProyectos_r7_c7_f2.gif');">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" DESIGNTIMEDRAGDROP="173"
				height="24">
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
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" border="0"> <!-- fwtable fwsrc="INFORME DE PROYECTOS.png" fwbase="GestionProyectos.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
								<TR>
									<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="149" border="0"></TD>
									<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="136" border="0"></TD>
									<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="288" border="0"></TD>
									<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="136" border="0"></TD>
									<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="51" border="0"></TD>
									<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD colSpan="5"><IMG height="232" alt="" src="../imagenes/imgGestionProyectos1.gif" width="760" border="0"
											name="GestionProyectos_r1_c1"></TD>
									<TD><IMG height="232" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD rowSpan="2" background="../imagenes/imgGestionProyectos2.gif">
										<P><BR>
											<BR>
											<BR>
											<BR>
											<BR>
											<BR>
											<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></P>
									</TD>
									<TD><A onmouseover="MM_swapImage('btnEnEjecucionDirectorio','','../imagenes/btnEnEjecucionDirectorio_O.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="37" alt="" src="../imagenes/btnEnEjecucionDirectorio.gif" width="136" border="0"
												name="btnEnEjecucionDirectorio" id="ibtnEnEjecucion" runat="server"></A></TD>
									<TD rowSpan="2"><IMG height="228" alt="" src="../imagenes/imgGestionProyectos3.gif" width="288" border="0"
											name="GestionProyectos_r2_c3"></TD>
									<TD><A onmouseover="MM_swapImage('btnProyectoMarinaDirectorio','','../imagenes/btnProyectoMarinaDirectorio_O.gif',1);"
											onmouseout="MM_swapImgRestore();" href="#"><IMG height="37" alt="" src="../imagenes/btnProyectoMarinaDirectorio.gif" width="136"
												border="0" name="btnProyectoMarinaDirectorio" id="ibtnConveniosMGP" runat="server"></A></TD>
									<TD rowSpan="2"><IMG height="228" alt="" src="../imagenes/imgGestionProyectos4.gif" width="51" border="0"
											name="GestionProyectos_r2_c5"></TD>
									<TD><IMG height="37" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
								</TR>
								<TR>
									<TD><IMG height="191" alt="" src="../imagenes/imgGestionProyectos5.gif" width="136" border="0"
											name="GestionProyectos_r3_c2"></TD>
									<TD><IMG height="191" alt="" src="../imagenes/imgGestionProyectos6.gif" width="136" border="0"
											name="GestionProyectos_r3_c4"></TD>
									<TD><IMG height="191" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
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
	</body>
</HTML>
