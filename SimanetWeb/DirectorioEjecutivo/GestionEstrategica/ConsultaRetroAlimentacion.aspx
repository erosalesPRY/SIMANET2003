<%@ Page language="c#" Codebehind="ConsultaRetroAlimentacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaRetroAlimentacion" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaRetroAlimentacion</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript">
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

		</SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Proceso Estratégico > Consultar  Retroalimentación</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<table border="0" cellpadding="0" cellspacing="0" width="760" align="center">
							<!-- fwtable fwsrc="RETRO ALIMENTACION.png" fwbase="RetroAlimentacion.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<tr>
								<td><img src="../../imagenes/spacer.gif" width="103" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="133" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="112" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="150" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="112" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="150" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="6"><img name="RetroAlimentacion_r1_c1" src="../../imagenes/RetroAlimentacion_r1_c1.gif"
										width="760" height="86" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="86" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="8" background="../../imagenes/RetroAlimentacion_r2_c1.gif">
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P>&nbsp;</P>
									<P><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
									</P>
								</td>
								<td colspan="5" background="../../imagenes/RetroAlimentacion_r2_c2.gif">
									<P align="center">
										<asp:Label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul"></asp:Label></P>
								</td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="70" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="5"><img name="RetroAlimentacion_r3_c2" src="../../imagenes/RetroAlimentacion_r3_c2.gif"
										width="657" height="8" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="8" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="6"><img name="RetroAlimentacion_r4_c2" src="../../imagenes/RetroAlimentacion_r4_c2.gif"
										width="133" height="296" border="0" alt=""></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('RetroAlimentacion_r4_c3','','../../imagenes/RetroAlimentacion_r4_c3_f2.gif',1);"><img name="RetroAlimentacion_r4_c3" src="../../imagenes/RetroAlimentacion_r4_c3.gif"
											width="112" height="34" border="0" alt="" id="ibtnIndicadoresGestion" runat="server"></a></td>
								<td rowspan="6"><img name="RetroAlimentacion_r4_c4" src="../../imagenes/RetroAlimentacion_r4_c4.gif"
										width="150" height="296" border="0" alt=""></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('RetroAlimentacion_r4_c5','','../../imagenes/RetroAlimentacion_r4_c5_f2.gif',1);"><img name="RetroAlimentacion_r4_c5" src="../../imagenes/RetroAlimentacion_r4_c5.gif"
											width="112" height="34" border="0" alt="" id="ibtnActasReunion" runat="server"></a></td>
								<td rowspan="6"><img name="RetroAlimentacion_r4_c6" src="../../imagenes/RetroAlimentacion_r4_c6.gif"
										width="150" height="296" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="RetroAlimentacion_r5_c3" src="../../imagenes/RetroAlimentacion_r5_c3.gif"
										width="112" height="47" border="0" alt=""></td>
								<td><img name="RetroAlimentacion_r5_c5" src="../../imagenes/RetroAlimentacion_r5_c5.gif"
										width="112" height="47" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="47" border="0" alt=""></td>
							</tr>
							<tr>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('RetroAlimentacion_r6_c3','','../../imagenes/RetroAlimentacion_r6_c3_f2.gif',1);"><img name="RetroAlimentacion_r6_c3" src="../../imagenes/RetroAlimentacion_r6_c3.gif"
											width="112" height="34" border="0" alt="" id="ibtnBalanceScorecard" runat="server"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('RetroAlimentacion_r6_c5','','../../imagenes/RetroAlimentacion_r6_c5_f2.gif',1);"><img name="RetroAlimentacion_r6_c5" src="../../imagenes/RetroAlimentacion_r6_c5.gif"
											width="112" height="34" border="0" alt="" id="ibtnAcuerdosReunion" runat="server"></a></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="RetroAlimentacion_r7_c3" src="../../imagenes/RetroAlimentacion_r7_c3.gif"
										width="112" height="41" border="0" alt=""></td>
								<td><img name="RetroAlimentacion_r7_c5" src="../../imagenes/RetroAlimentacion_r7_c5.gif"
										width="112" height="41" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="41" border="0" alt=""></td>
							</tr>
							<tr>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('RetroAlimentacion_r8_c3','','../../imagenes/RetroAlimentacion_r8_c3_f2.gif',1);"><img name="RetroAlimentacion_r8_c3" src="../../imagenes/RetroAlimentacion_r8_c3.gif"
											width="112" height="34" border="0" alt="" id="ibtnDescripcionGrafica" runat="server"></a></td>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('RetroAlimentacion_r8_c5','','../../imagenes/RetroAlimentacion_r8_c5_f2.gif',1);"><img name="RetroAlimentacion_r8_c5" src="../../imagenes/RetroAlimentacion_r8_c5.gif"
											width="112" height="34" border="0" alt="" id="ibtnCursoProcesos" runat="server"></a></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="34" border="0" alt=""></td>
							</tr>
							<tr>
								<td><img name="RetroAlimentacion_r9_c3" src="../../imagenes/RetroAlimentacion_r9_c3.gif"
										width="112" height="106" border="0" alt=""></td>
								<td><img name="RetroAlimentacion_r9_c5" src="../../imagenes/RetroAlimentacion_r9_c5.gif"
										width="112" height="106" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="106" border="0" alt=""></td>
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
