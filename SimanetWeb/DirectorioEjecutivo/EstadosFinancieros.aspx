<%@ Page language="c#" Codebehind="EstadosFinancieros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.EstadosFinancieros" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>EstadosFinancieros.gif</title>
		<meta http-equiv="Content-Type" content="text/html;">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
	
		<script language="JavaScript">
		
<!--
		function MM_displayStatusMsg(msgStr)  { //v3.0
			status=msgStr; document.MM_returnValue = true;
		}

		function MM_displayStatusMsg(msgStr)  { //v3.0
			status=msgStr; document.MM_returnValue = true;
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
	<body bgcolor="#ffffff" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" DESIGNTIMEDRAGDROP="7">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="760" border="0"> <!-- fwtable fwsrc="GESTION FINANCIERA.png" fwbase="GestionFinanciera.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<TR>
								<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="132" border="0"></TD>
								<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="167" border="0"></TD>
								<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="263" border="0"></TD>
								<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="167" border="0"></TD>
								<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="31" border="0"></TD>
								<TD><IMG height="1" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD colSpan="5"><IMG id="ImgGestionFinanciera1" height="155" alt="" src="../imagenes/ImgGestionFinanciera1.gif"
										width="760" border="0" name="ImgGestionFinanciera1"></TD>
								<TD><IMG height="155" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD rowSpan="8" background="../imagenes/ImgGestionFinanciera2.gif"><BR>
									<BR>
									<BR>
									<BR>
									<BR>
									<BR>
									<BR>
									<BR>
									<BR>
									<BR>
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
								<TD><A onmouseover="MM_swapImage('btnBalanceGeneral','','../imagenes/btnBalanceGeneral_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnBalanceGeneral" height="37" alt="" src="../imagenes/btnBalanceGeneral.gif"
											width="167" border="0" name="btnBalanceGeneral" runat="server" style="Z-INDEX: 0"></A><A onmouseover="MM_displayStatusMsg('FINANZA - SIMA IQUITOS S.R. Ltda.');MM_swapImage('btnGananciaPerdidas','','../imagenes/btnGananciaPerdidas_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD rowSpan="8"><IMG id="ImgGestionFinanciera4" height="305" alt="" src="../imagenes/ImgGestionFinanciera3.gif"
										width="263" border="0" name="ImgGestionFinanciera4"></TD>
								<TD><A onmouseover="MM_displayStatusMsg('REGISTRO - CARTAS FIANZAS');MM_swapImage('btnCartasFianzas','','../imagenes/btnCartasFianzas_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnCartasFianzas" height="36" alt="" src="../imagenes/btnCartasFianzas.gif"
											width="167" border="0" name="btnCartasFianzas" runat="server"></A><A onmouseover="MM_displayStatusMsg('REGISTROS - CARTAS DE CRÉDITO');MM_swapImage('btnCuentasPorCobrarPagar','','../imagenes/btnCuentasPorCobrarPagar_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD rowSpan="8"><IMG id="ImgGestionFinanciera6" height="305" alt="" src="../imagenes/ImgGestionFinanciera4.gif"
										width="31" border="0" name="ImgGestionFinanciera6"></TD>
								<TD><IMG height="37" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><A onmouseover="MM_displayStatusMsg('FINANZA - SIMA IQUITOS S.R. Ltda.');MM_swapImage('btnGananciaPerdidas','','../imagenes/btnGananciaPerdidas_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD></TD>
								<TD><IMG height="21" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><A onmouseover="MM_displayStatusMsg('FINANZA - SIMA IQUITOS S.R. Ltda.');MM_swapImage('btnGananciaPerdidas','','../imagenes/btnGananciaPerdidas_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnGananciasyPerdidas" height="36" alt="" src="../imagenes/btnGananciaPerdidas.gif"
											width="167" border="0" name="btnGananciaPerdidas" runat="server" style="Z-INDEX: 0"></A><A onmouseover="MM_displayStatusMsg('REGISTROS - CARTAS FINANZAS AL SIMA PERÚ S.A.');MM_swapImage('btnFlujoCaja','','../imagenes/btnFlujoCaja_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD><A onmouseover="MM_swapImage('btnPrestamosBancarios','','../imagenes/btnPrestamosBancarios_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnPrestamosBancarios" height="36" alt="" src="../imagenes/btnPrestamosBancarios.gif"
											width="167" border="0" name="btnPrestamosBancarios" runat="server"></A><A onmouseover="MM_displayStatusMsg('REGISTRO - CARTAS FIANZAS');MM_swapImage('btnCartasFianzas','','../imagenes/btnCartasFianzas_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD><IMG height="36" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD></TD>
								<TD></TD>
								<TD><IMG height="23" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><A onmouseover="MM_displayStatusMsg('REGISTROS - CARTAS FINANZAS AL SIMA PERÚ S.A.');MM_swapImage('btnFlujoCaja','','../imagenes/btnFlujoCaja_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG style="Z-INDEX: 0" id="ibtnFlujoCaja" border="0" name="btnFlujoCaja" alt="" src="../imagenes/btnFlujoCaja.gif"
											width="167" height="36" runat="server"></A><A onmouseover="MM_swapImage('btnBalanceGeneral','','../imagenes/btnBalanceGeneral_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD><A onmouseover="MM_displayStatusMsg('REGISTROS - CARTAS DE CRÉDITO');MM_swapImage('btnCuentasPorCobrarPagar','','../imagenes/btnCuentasPorCobrarPagar_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnCuentasCobrarPagar" height="37" alt="" src="../imagenes/btnCuentasPorCobrarPagar.gif"
											width="167" border="0" name="btnCuentasPorCobrarPagar" runat="server"></A><A onmouseover="MM_swapImage('btnPrestamosBancarios','','../imagenes/btnPrestamosBancarios_f2.gif',1);"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
								<TD><IMG height="36" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD rowSpan="3"><IMG id="ImgGestionFinanciera3" height="152" alt="" src="../imagenes/ImgGestionFinanciera5.gif"
										width="167" border="0" name="ImgGestionFinanciera3"></TD>
								<TD><IMG height="26" alt="" src="../imagenes/GestionFinanciera_r7_c4.gif" width="167" border="0"
										name="GestionFinanciera_r7_c4"></TD>
								<TD><IMG height="26" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><A onmouseover="MM_displayStatusMsg('REGISTRO - LETRAS AL SIMA PERÚ S.A.');MM_swapImage('btnProyectosPorProvisionarLiquidar','','../imagenes/btnProyectosPorProvisionarLiquidar_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnProyectosProvisionarLiquidar" height="35" alt="" src="../imagenes/btnProyectosPorProvisionarLiquidar.gif"
											width="167" border="0" name="btnProyectosPorProvisionarLiquidar" runat="server"></A></TD>
								<TD><IMG height="35" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
							<TR>
								<TD><IMG id="ImgGestionFinanciera5" height="91" alt="" src="../imagenes/ImgGestionFinanciera6.gif"
										width="167" border="0" name="ImgGestionFinanciera5"></TD>
								<TD><IMG height="91" alt="" src="../imagenes/spacer.gif" width="1" border="0"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			MM_preloadImages('../imagenes/GestionFinanciera_r2_c6_f2.gif','../imagenes/GestionFinanciera_r3_c3_f2.gif','../imagenes/GestionFinanciera_r5_c6_f2.gif','../imagenes/GestionFinanciera_r6_c2_f2.gif','../imagenes/GestionFinanciera_r9_c6_f2.gif','../imagenes/GestionFinanciera_r10_c2_f2.gif','../imagenes/GestionFinanciera_r12_c6_f2.gif');
		</SCRIPT>
	</body>
</HTML>
