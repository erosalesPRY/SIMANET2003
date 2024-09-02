<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaDeAgendaDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.ConsultaDeAgendaDirectorio" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();MM_preloadImages('../../imagenes/SesionDirectorio_r2_c2_f2.jpg','../../imagenes/SesionDirectorio_r3_c2_f2.jpg','../../imagenes/SesionDirectorio_r4_c2_f2.jpg','../../imagenes/SesionDirectorio_r5_c2_f2.jpg','../../imagenes/SesionDirectorio_r7_c8_f2.jpg');"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" onkeydown="return verificarBackspace()" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" align="center" border="0"> <!-- fwtable fwsrc="PANTALLA INICIAL SESION DIRECTORIO V1.png" fwbase="SesionDirectorio.gif" fwstyle="Dreamweaver" fwdocid = "81027332" fwnested="0" -->
							<tr>
								<td><img src="../../imagenes/spacer.gif" width="18" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="94" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="17" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="146" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="205" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="46" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="33" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="170" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="31" height="1" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="1" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="9" background="../../imagenes/SesionDirectorio_r1_c1.jpg" vAlign="bottom"
									align="center">
									<TABLE id="TablaSesion" cellSpacing="0" cellPadding="0"
										width="730" border="0">
              <TR>
                <TD width=70>
<asp:Label id=Label1 runat="server" CssClass="TextoAzulTituloDirectorio">Nro. Sesión:</asp:Label></TD>
                <TD>
<asp:Label id=lblNroSesion runat="server" CssClass="TextoAzulNegritaDirectorio"></asp:Label></TD></TR>
										<TR>
											<TD width=70>
<asp:Label id=Label3 runat="server" CssClass="TextoAzulTituloDirectorio">Fecha:</asp:Label></TD>
											<TD >
												<asp:Label id="lblFecha" runat="server" CssClass="TextoAzulNegritaDirectorio"></asp:Label></TD>
										</TR>
              <TR>
                <TD width=70>
												<asp:Label id="Label4" runat="server" CssClass="TextoAzulTituloDirectorio">Hora:</asp:Label></TD>
                <TD>
												<asp:Label id="lblHora" runat="server" CssClass="TextoAzulNegritaDirectorio"></asp:Label></TD></TR>
										<TR>
											<TD width=70>
<asp:Label id=Label2 runat="server" CssClass="TextoAzulTituloDirectorio">Lugar:</asp:Label></TD>
											<TD>
												<asp:Label id="lblLugar" runat="server" CssClass="TextoAzulNegritaDirectorio"></asp:Label></TD>
										</TR>
              <TR>
                <TD width=70></TD>
                <TD>
<asp:Label id=lblLugar1 runat="server" CssClass="TextoAzulNegritaDirectorio"></asp:Label></TD></TR>
									</TABLE>
								</td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="167" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="6"><img name="SesionDirectorio_r2_c1" src="../../imagenes/SesionDirectorio_r2_c1.jpg" width="18"
										height="208" border="0" alt=""></td>
								<td colspan="5"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('SesionDirectorio_r2_c2','','../../imagenes/SesionDirectorio_r2_c2_f2.jpg',1);"><img name="SesionDirectorio_r2_c2" src="../../imagenes/SesionDirectorio_r2_c2.jpg" width="508"
											height="44" border="0" alt="" id="ibtnLecturaActas" runat="server"></a></td>
								<td rowspan="5" colspan="3"><img name="SesionDirectorio_r2_c7" src="../../imagenes/SesionDirectorio_r2_c7.jpg" width="234"
										height="204" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="44" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="4"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('SesionDirectorio_r3_c2','','../../imagenes/SesionDirectorio_r3_c2_f2.jpg',1);"><img name="SesionDirectorio_r3_c2" src="../../imagenes/SesionDirectorio_r3_c2.jpg" width="462"
											height="45" border="0" alt="" id="ibtnInformes" runat="server"></a></td>
								<td rowspan="8"><img name="SesionDirectorio_r3_c6" src="../../imagenes/SesionDirectorio_r3_c6.jpg" width="46"
										height="249" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="45" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="3"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('SesionDirectorio_r4_c2','','../../imagenes/SesionDirectorio_r4_c2_f2.jpg',1);"><img name="SesionDirectorio_r4_c2" src="../../imagenes/SesionDirectorio_r4_c2.jpg" width="257"
											height="45" border="0" alt="" id="ibtnInformesDirectorEjecutivo" runat="server"></a></td>
								<td rowspan="7"><img name="SesionDirectorio_r4_c5" src="../../imagenes/SesionDirectorio_r4_c5.jpg" width="205"
										height="204" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="45" border="0" alt=""></td>
							</tr>
							<tr>
								<td><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('SesionDirectorio_r5_c2','','../../imagenes/SesionDirectorio_r5_c2_f2.jpg',1);"><img name="SesionDirectorio_r5_c2" src="../../imagenes/SesionDirectorio_r5_c2.jpg" width="94"
											height="45" border="0" alt="" id="ibtnPedidos" runat="server"></a></td>
								<td rowspan="3" colspan="2"><img name="SesionDirectorio_r5_c3" src="../../imagenes/SesionDirectorio_r5_c3.jpg" width="163"
										height="74" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="45" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="2"><img name="SesionDirectorio_r6_c2" src="../../imagenes/SesionDirectorio_r6_c2.jpg" width="94"
										height="29" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="25" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="4"><img name="SesionDirectorio_r7_c7" src="../../imagenes/SesionDirectorio_r7_c7.jpg" width="33"
										height="89" border="0" alt=""></td>
								<td rowspan="2"><a href="#" onMouseOut="MM_swapImgRestore();" onMouseOver="MM_swapImage('SesionDirectorio_r7_c8','','../../imagenes/SesionDirectorio_r7_c8_f2.jpg',1);"><img name="SesionDirectorio_r7_c8" src="../../imagenes/SesionDirectorio_r7_c8.jpg" width="170"
											height="44" border="0" alt="" id="ibtnBitacoraSesiones" runat="server"></a></td>
								<td rowspan="4"><img name="SesionDirectorio_r7_c9" src="../../imagenes/SesionDirectorio_r7_c9.jpg" width="31"
										height="89" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="4" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="2" colspan="3" background="../../imagenes/SesionDirectorio_r8_c1.jpg">
									<P><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif" style="CURSOR: hand"></P>
								</td>
								<td rowspan="3"><img name="SesionDirectorio_r8_c4" src="../../imagenes/SesionDirectorio_r8_c4.jpg" width="146"
										height="85" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="40" border="0" alt=""></td>
							</tr>
							<tr>
								<td rowspan="2"><img name="SesionDirectorio_r9_c8" src="../../imagenes/SesionDirectorio_r9_c8.jpg" width="170"
										height="45" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="6" border="0" alt=""></td>
							</tr>
							<tr>
								<td colspan="3"><img name="SesionDirectorio_r10_c1" src="../../imagenes/SesionDirectorio_r10_c1.jpg"
										width="129" height="39" border="0" alt=""></td>
								<td><img src="../../imagenes/spacer.gif" width="1" height="39" border="0" alt=""></td>
							</tr>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
