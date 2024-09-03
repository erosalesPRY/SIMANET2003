<%@ Page language="c#" Codebehind="EstadosFinancierosProyectados.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales.EstadosFinancierosProyectados" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			var KEYQIDNUEVOFORMATO = "NuevoFormato";
					
			function VistaPrevia(e)
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oHtml = new SIMA.Utilitario.Helper.General.Html();
				/**/
				oPrinter = new SIMA.Utilitario.Helper.Prints();
				oPrinter.htmlTablaContenedora= document.all["tblCabeceraPrint"];

				/*Crea el titulo principal del reporte*/
				ohtmlFuente = oHtml.CrearFuente();
				with (ohtmlFuente)
				{
					innerText = "ESTADOS FINANCIEROS";
					setAttribute("face","arial"); 
					setAttribute("size","4");
					setAttribute("color","black");
				}
				/*Crea la Cabecera y agrega un Objeto de tipo Font*/
				oCabecera = new SIMA.Utilitario.Helper.CabeceraPagina();
				oCabecera.CenterTop(ohtmlFuente);

				ohtmlFuente = oHtml.CrearFuente();
				
				//window.alert(document.location.search);
				
				with (ohtmlFuente)
				{
					innerText = oPagina.Request.Params["NombreCentro"].toUpperCase();
					setAttribute("face","arial"); 
					setAttribute("size","2");
					setAttribute("color","black");
				}
				oCabecera.CenterCenter(ohtmlFuente);
				
				ohtmlFuente = oHtml.CrearFuente();
				with (ohtmlFuente)
				{
					innerText = "PERIODO :" + oPagina.Request.Params["NombreMes"] + " DEL " + oPagina.Request.Params["efFecha"].split('/')[2] ;
					setAttribute("face","arial"); 
					setAttribute("size","2");
					setAttribute("color","black");
				}
				oCabecera.CenterDown(ohtmlFuente);


				//Adicion al cabcera configurada
				oPrinter.ConfigurarCabecera(oCabecera);
				
				oPrinter.VistaPrevia(e,Cabecera,FilaMenu,FilaToolBar,CeldaAbajo);
			}	
			
			function OcultarCabecerayMenu()
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if (oPagina.Request.Params[KEYQIDNUEVOFORMATO]=="true")
				{
					$O("Cabecera").style.display = "none";
					$O("Cabecera1").style.display = "none";					
					$O("FilaMenu").style.display = "none";
					$O("ImgImprimir").style.display = "none";
					//$O("Ruta").style.display = "none";
					oibtnAtras = $O("ibtnAtras");
					oibtnAtras.src =  "../../imagenes/RetornarAlFormato.GIF";
					oibtnAtras.parentElement.align = "right";
				}
			}							
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial2();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr id="Cabecera">
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR id="FilaMenu">
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3" id="Cabecera1"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0" id="FilaToolBar">
											<TD style="WIDTH: 2px"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
											<TD style="WIDTH: 76px" vAlign="middle">
												<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" DESIGNTIMEDRAGDROP="1229"
													Width="72px" ForeColor="Navy">PERIODO :</asp:Label></TD>
											<TD style="WIDTH: 58px" vAlign="middle">
												<asp:Label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True"
													DESIGNTIMEDRAGDROP="1231" ForeColor="Navy">Periodo :</asp:Label></TD>
											<TD vAlign="middle" align="center" width="100%" colSpan="2">
												<asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Navy">EN MILES DE NUEVOS SOLES</asp:label></TD>
											<td><IMG id="ImgImprimir" onclick="VistaPrevia(this);" alt="" src="../../imagenes/bt_imprimir.gif"></td>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<TABLE id="grid" cellSpacing="1" cellPadding="0" width="100%" bgColor="buttonface" border="0"
										runat="server">
										<TR class="Headergrilla">
											<TD vAlign="middle" width="131" rowSpan="3" style="WIDTH: 131px">
												<asp:Label id="Label4" runat="server" Width="125px">CONCEPTO</asp:Label></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD colSpan="14" id="lblEmpresa" runat="server">SIMA PERU S.A</TD>
										</TR>
										<TR class="Headergrilla">
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD colSpan="12">REAL</TD>
											<TD style="WIDTH: 71px" align="center">PROYECTADO</TD>
											<TD vAlign="middle" rowSpan="2" runat="server" id="ColumnaTotal">TOTAL</TD>
										</TR>
										<TR class="Headergrilla">
											<TD style="DISPLAY: none">.</TD>
											<TD style="DISPLAY: none">.</TD>
											<TD style="DISPLAY: none">.</TD>
											<TD style="DISPLAY: none">.</TD>
											<TD width="85">ENE</TD>
											<TD width="85">FEB</TD>
											<TD width="85">MAR</TD>
											<TD width="85">ABR</TD>
											<TD width="85">MAY</TD>
											<TD width="85">JUN</TD>
											<TD width="85">JULI</TD>
											<TD width="85">AGO</TD>
											<TD width="85">SET</TD>
											<TD width="85">OCT</TD>
											<TD width="85">NOV</TD>
											<TD width="85">DIC</TD>
											<TD width="71" style="WIDTH: 71px">SUB</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR id="CeldaAbajo">
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial();HistorialIrAtras();"
										alt="" src="../../imagenes/atras.gif">
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<asp:Label id="Label2" runat="server" CssClass="TextoAzul" Font-Bold="True" Font-Size="X-Small"
							Visible="False">MES :</asp:Label>
						<asp:Label id="lblMes" runat="server" CssClass="TextoAzul" Font-Bold="True" Font-Size="X-Small"
							Visible="False">Periodo :</asp:Label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><INPUT id="objHistorial" type="hidden" name="objHistorial"></TD>
				</TR>
			</table>
			<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				OcultarCabecerayMenu();				
			</SCRIPT>
		</form>
	</body>
</HTML>
