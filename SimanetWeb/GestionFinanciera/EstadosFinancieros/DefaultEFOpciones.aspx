<%@ Page language="c#" Codebehind="DefaultEFOpciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.DefaultEFOpciones" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script language="JavaScript">
		<!-- 
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 20px" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ..</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></A>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="655" border="0">
							<TR>
								<TD width="25%"></TD>
								<TD vAlign="middle" align="center" width="50%"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Width="272px" Font-Bold="True"
										ForeColor="Navy" BackColor="Transparent">ESTADOS FINANCIEROS</asp:label></TD>
								<TD width="25%"></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 37px" width="25%"><INPUT id="hValorChbx" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hValorChbx"
										runat="server"></TD>
								<TD style="HEIGHT: 37px" vAlign="middle" align="center" width="50%"><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" Width="67px" ForeColor="Navy"
										BackColor="Transparent">PERIODO :</asp:label><asp:dropdownlist id="ddlbPeriodo" runat="server" CssClass="combos" AutoPostBack="True"></asp:dropdownlist><asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" BackColor="Transparent">MES :</asp:label><asp:dropdownlist id="dddblMes" runat="server" CssClass="combos" AutoPostBack="True">
										<asp:ListItem Value="1">Enero</asp:ListItem>
										<asp:ListItem Value="2">Febrero</asp:ListItem>
										<asp:ListItem Value="3">Marzo</asp:ListItem>
										<asp:ListItem Value="4">Abril</asp:ListItem>
										<asp:ListItem Value="5">Mayo</asp:ListItem>
										<asp:ListItem Value="6">Junio</asp:ListItem>
										<asp:ListItem Value="7">Julio</asp:ListItem>
										<asp:ListItem Value="8">Agosto</asp:ListItem>
										<asp:ListItem Value="9">Setiembre</asp:ListItem>
										<asp:ListItem Value="10">Octubre</asp:ListItem>
										<asp:ListItem Value="11">Noviembre</asp:ListItem>
										<asp:ListItem Value="12">Diciembre</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="HEIGHT: 37px" align="right" width="25%"><asp:checkbox id="chbxFlag" runat="server" CssClass="NormalMayuscula" ForeColor="Navy" AutoPostBack="True"
										Text="VER NUEVOS SOLES"></asp:checkbox></TD>
							</TR>
							<TR>
								<TD width="25%"><A onmouseover="MM_displayStatusMsg('GANANCIAS Y PERDIDAS');MM_swapImage('ibtnGananciasyPerdidas','','../../imagenes/btnGananciaPerdidas_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnGananciasyPerdidas" height="37" alt="" src="../../imagenes/btnGananciaPerdidas.gif"
											width="167" border="0" name="btnGananciaPerdidas" runat="server"></A>
								</TD>
								<TD vAlign="middle" align="center" width="50%" rowSpan="5"><IMG style="WIDTH: 200px; HEIGHT: 222px" height="222" src="../../imagenes/EscudoSimaDorado3.jpg"
										width="200">
								</TD>
								<TD width="25%"><A onmouseover="MM_displayStatusMsg('ADM. CONCEPTOS');MM_swapImage('imgAdmConceptos','','../../imagenes/btnAdmCuentaB.JPG',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A><A onmouseover="MM_displayStatusMsg('BALANCE GENERAL');MM_swapImage('ibtnBalanceGeneral','','../../imagenes/btnBalanceGeneral_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnBalanceGeneral" height="36" alt="" src="../../imagenes/btnBalanceGeneral.gif"
											width="167" border="0" name="btnBalanceGeneral" runat="server"></A><A onmouseover="MM_displayStatusMsg('ADM. CONCEPTOS');MM_swapImage('imgAdmConceptos','','../../imagenes/btnAdmCuentaB.JPG',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="imgAdmConceptos" height="36" alt="" src="../../imagenes/btnAdmConcep.JPG" width="167"
											border="0" name="imgAdmConceptos" runat="server"></A></TD>
							</TR>
							<TR>
								<TD width="25%"></TD>
								<TD align="center" width="25%"><A onmouseover="MM_displayStatusMsg('ADM. CONCEPTOS');MM_swapImage('imgAdmConceptos','','../../imagenes/btnAdmCuentaB.JPG',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"></A></TD>
							</TR>
							<TR>
								<TD width="25%"><A onmouseover="MM_displayStatusMsg('FLUJO DE CAJA');MM_swapImage('ibtnFlujoCaja','','../../imagenes/btnFlujoCaja_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnFlujoCaja" height="36" alt="" src="../../imagenes/btnFlujoCaja.gif" width="167"
											border="0" name="btnFlujoCaja" runat="server"></A>
								</TD>
								<TD width="25%"><A onmouseover="MM_displayStatusMsg('INGRESOS Y EGRESOS');MM_swapImage('ibtnIngresosyEgresos','','../../imagenes/btnIngresosEgresos_O.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnIngresosyEgresos" height="35" alt="" src="../../imagenes/btnIngresosEgresos.gif"
											width="167" border="0" name="btnProyectosPorProvisionarLiquidar" runat="server"></A>
								</TD>
							</TR>
							<TR>
								<TD width="25%"></TD>
								<TD width="25%"></TD>
							</TR>
							<TR>
								<TD width="25%"><A onmouseover="MM_displayStatusMsg('CUENTAS POR COBRAR/PAGAR');MM_swapImage('ibtnCtasPorCobraryPagar','','../../imagenes/btnCuentasPorCobrarPagar_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnCtasPorCobraryPagar" height="37" alt="" src="../../imagenes/btnCuentasPorCobrarPagar.gif"
											width="167" border="0" name="btnCuentasPorCobrarPagar" runat="server"></A>
								</TD>
								<TD width="25%"><A onmouseover="MM_displayStatusMsg('PROVISIONAR LIQUIDAR');MM_swapImage('ibtnProyectosProvisionarLiquidar','','../../imagenes/btnProyectosPorProvisionarLiquidar_f2.gif',1);return document.MM_returnValue"
										onmouseout="MM_swapImgRestore();" href="#"><IMG id="ibtnProyectosProvisionarLiquidar" height="35" alt="" src="../../imagenes/btnProyectosPorProvisionarLiquidar.gif"
											width="167" border="0" name="btnProyectosPorProvisionarLiquidar" runat="server"></A>
								</TD>
							</TR>
							<TR>
								<TD width="25%"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								<TD width="25%" align="center">
									<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="../../General/Diapositivas/ArchivoPPT.aspx?idPresent=1">Nueva versión</asp:HyperLink></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
