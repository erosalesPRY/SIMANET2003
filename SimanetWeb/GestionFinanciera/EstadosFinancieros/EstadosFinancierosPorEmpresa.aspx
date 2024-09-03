<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="EstadosFinancierosPorEmpresa.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.EstadosFinancierosPorEmpresa" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
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
			
			
			//function OcultarCabecerayMenu()	{
			function OcultarMeses()	{
				//window.aler();
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				if (oPagina.Request.Params[KEYQIDNUEVOFORMATO]=="true")
				{
					oHeader = document.all["Cabecera"];
					oMenu = document.all["FilaMenu"];
					oibtnImprimir = document.all["ImgImprimir"];
					oibtnAtras = document.all["ibtnAtras"];
					oRuta = document.all["Ruta"];
					oHeader.style.display = "none";
					oMenu.style.display = "none";
					oibtnImprimir.style.display = "none";
					oRuta.style.display = "none";
					oibtnAtras.src =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/imagenes/RetornarAlFormato.GIF";
					oibtnAtras.parentElement.align = "right";
					/**/
					var NroMes = oPagina.Request.Params["efFecha"].split('/')[1];
					var ColumnaIni = eval(parseInt(parseFloat(NroMes))+6);
					var oDataGrid= document.all["grid"];
					
					var NroColspan= parseInt(parseFloat(NroMes));
					oDataGrid.rows[0].cells(oDataGrid.rows[0].cells.length-1).colSpan = (NroColspan+3);
					oDataGrid.rows[1].cells(oDataGrid.rows[1].cells.length-3).colSpan = NroColspan;

					var ColIniH =(4 + parseInt(parseFloat(NroMes)));
					for(var Col=ColIniH;Col <=oDataGrid.rows[2].cells.length-1;Col++){oDataGrid.rows[2].cells(Col).style.display="none";}
					
					for(var Fil=3;Fil<= oDataGrid.rows.length-1;Fil++)
					{
						for(var Col=ColumnaIni;Col<=17;Col++){oDataGrid.rows[Fil].cells(Col).style.display="none";}
					}
				}
			}
			
		</script>
	</HEAD>
	<body oncontextmenu="return false" bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial2();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr id="Cabecera">
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR id="FilaMenu">
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR id="Ruta">
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE class="normal" id="Table2" cellSpacing="1" cellPadding="4" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 302px">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
													<TR id="FilaToolBar">
														<TD style="WIDTH: 63px"><asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True"
																DESIGNTIMEDRAGDROP="151">PERIODO :</asp:label></TD>
														<TD style="WIDTH: 34px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
																Font-Bold="True">[Periodo]</asp:label></TD>
														<TD style="WIDTH: 26px"><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True"
																DESIGNTIMEDRAGDROP="174">MES :</asp:label></TD>
														<TD><asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True"
																DESIGNTIMEDRAGDROP="132">[Mes]</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="WIDTH: 1px"></TD>
											<TD vAlign="bottom">&nbsp;</TD>
											<TD align="center"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True">EN MILES DE NUEVOS SOLES</asp:label></TD>
											<TD style="WIDTH: 209px" align="right"><IMG style="WIDTH: 110px; HEIGHT: 16px" height="16" src="../../imagenes/spacer.gif" width="110">&nbsp;<IMG id="ImgImprimir" onclick="VistaPrevia(this);" alt="" src="../../imagenes/bt_imprimir.gif"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<TABLE id="grid" style="BORDER-TOP-WIDTH: 1px; BORDER-RIGHT: #999999 1px solid; BORDER-BOTTOM: #999999 1px solid"
										cellSpacing="1" cellPadding="1" width="100%" bgColor="buttonface" border="0" runat="server">
										<TR class="HeaderGrilla">
											<TD vAlign="middle" width="20%" rowSpan="3"><asp:label id="Label2" runat="server" Width="128px">CONCEPTO</asp:label></TD>
											<TD style="DISPLAY: none" colSpan="2"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD colSpan="15"><asp:label id="lblCentro" runat="server">Label</asp:label></TD>
										</TR>
										<TR class="HeaderGrilla">
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD vAlign="middle" width="85" rowSpan="2">PPTO</TD>
											<TD colSpan="12">REAL</TD>
											<TD vAlign="middle" width="85" rowSpan="2">TOT</TD>
											<TD vAlign="middle" width="85" rowSpan="2">SAL</TD>
										</TR>
										<TR class="HeaderGrilla">
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD style="DISPLAY: none"></TD>
											<TD width="85">ENE</TD>
											<TD width="85">FEB</TD>
											<TD width="85">MAR</TD>
											<TD width="85">ABR</TD>
											<TD width="85">MAY</TD>
											<TD width="85">JUN</TD>
											<TD width="85">JUL</TD>
											<TD width="85">AGO</TD>
											<TD width="85">SET</TD>
											<TD width="85">OCT</TD>
											<TD width="85">NOV</TD>
											<TD width="85">DIC</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR id="CeldaAbajo">
								<TD align="left" width="100%" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial();HistorialIrAtras();"
										alt="" src="../../imagenes/atras.gif">&nbsp;
									<asp:HyperLink id="lnkGrafico" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
										Width="64px" Target="_blank">Gráficos</asp:HyperLink></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><asp:imagebutton id="ibtnImprimir" runat="server" Visible="False" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton><INPUT id="objHistorial" type="hidden" name="objHistorial">
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
