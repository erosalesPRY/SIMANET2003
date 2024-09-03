<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarCuentasporCobraryPagarResumen.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarCuentasporCobraryPagarResumen" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarCuentasporCobraryPagarResumen</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<script>
			/*Variables Globales*/
			var ExtensionImg = ".GIF";
			var NombreImgPlus = "PLUS";
			var NombreImgClose = "MINUS";
			/*Variables Globales para las Columnas de los Centros Operativo*/
			var NombreColumnaCentroMes = "Col[N]Delmes";
			var NombreColumnaCentroTotal = "Col[N]Total";
			var NombreTablaHeader = "tblCol[N]";
			
		</script>
		<script>
			function ObtenerCuentasPorPagarOCobrar3Dig(strListaParametros,e)
			{
				var PROCESO ="idProceso";
				var PROCESOCUENTASPORPAGAR ="PCuentasporPagar";
				var PERIODO = "Periodo";
				var MES = "Mes";
				var DIGCTA = "DigCta";
				var TIPOCAMBIO = "tc";
				var KEYQMODO = "Modo";

				/*Objeto que luego sera reestaurado*/
				var objvDefault = document.all["hValoresRestaurados"];
				objvDefault.value = strListaParametros +"[P]" + e.id;
				
				
				var dbgrid = document.all["grid"];
				var arrParametros = strListaParametros.split(";");
				
				var NroFila = ObteneridFila(dbgrid,"idFilaSVR",arrParametros[3]);
				
				
				var PathPaginaProceso = ObtenerPathAppWeb()+ "/GestionFinanciera/CuentasPorCobrarPagar/Procesar.aspx?" 
				+ PERIODO + "=" + arrParametros[1] 
				+ "&" + MES + "=" + arrParametros[2]  
				+ "&" + DIGCTA +"=0" 
				+ "&" + PROCESO + "=" + arrParametros[0]
				+ "&" + TIPOCAMBIO + "=" + arrParametros[4]
				+ "&" + KEYQMODO + "=" + SIMA.Utilitario.Enumerados.ModoPagina.C.toString();
				
				
				var EstadoActual = ObtenerEstadoNodo(e);
				var NewPathImg = ((EstadoActual==NombreImgPlus)? e.src.toUpperCase().replace(NombreImgPlus + ExtensionImg,NombreImgClose+ ExtensionImg): e.src.replace(NombreImgClose + ExtensionImg,NombreImgPlus + ExtensionImg));
				e.src =NewPathImg;
				
				if (dbgrid.rows[NroFila].getAttribute("NodoEstado") == "NoCargado")
				{
					oCallBack = new SIMA.Utilitario.Helper.General.CallBack();
					oCallBack.CargarDocumentoXML(PathPaginaProceso,strListaParametros);
					dbgrid.rows[NroFila].removeAttribute("NodoEstado");
					dbgrid.rows[NroFila].setAttribute("NodoEstado","Cargado") ;
				}
				else
				{
					window.setInterval("PopupDeEsperaClose();",800);
					PopupDeEspera();
					var Display = (EstadoActual == NombreImgPlus)?"block":"none";
					
					for(var i=NroFila;i <= dbgrid.rows.length-1;i++)
					{
						if (parseInt(dbgrid.rows[i].getAttribute("idFilaPadre"))==parseInt(arrParametros[3]))
						{
							dbgrid.rows[i].style.display=Display;
						}
					}
				}
				
			}
			
			/*de la Fila Seleccionada restaura el Nodo*/
			function RestaurarNodoExpande()
			{
				var objvDefault = document.all["hValoresRestaurados"];
				var arrValoresDefault = objvDefault.value.split("[P]");
				if (objvDefault.value.length >0)
				{
					var objImgPlusMinus = document.all[arrValoresDefault[1]];
					ObtenerCuentasPorPagarOCobrar3Dig(arrValoresDefault[0],objImgPlusMinus);
				}
			}
			

			function VistaPrevia(e)
			{
				oHtml = new SIMA.Utilitario.Helper.General.Html();
				/*Crea el titulo principal del reporte*/
				ohtmlFuente = oHtml.CrearFuente();
				with (ohtmlFuente)
				{
					innerText = "CUENTAS POR COBRAR Y PAGAR";
					setAttribute("face","arial"); 
					setAttribute("size","4");
					setAttribute("color","black");
				}
				/*Crea la Cabecera y agrega un Objeto de tipo Font*/
				oCabecera = new SIMA.Utilitario.Helper.CabeceraPagina();
				oCabecera.CenterTop(ohtmlFuente);

				oPrinter = new SIMA.Utilitario.Helper.Prints();
				oPrinter.htmlTablaContenedora= document.all["tblCabeceraPrint"];
				oPrinter.ConfigurarCabecera(oCabecera);
				oPrinter.VistaPrevia(e,Cabecera,FilaMenu);
			}		
			/*function pruebaaa()
			{
				var INDICADORDEPROCESO="IdProceso";
				var CTAPORPAGAR = 1;
				var CTAPORCOBRAR = 2;
				window.open("/SimaNetWeb/GestionFinanciera/CuentasPorCobrarPagar/Procesar.aspx?" +"Modo=C&IdProceso=1&Periodo=2006&Mes=11&DigCta=0");
				
			}	*/
			function AbrirArchivoXLS()
			{
				//var strPathFile = "http://simanet-eddy/simanetweb/Archivos/CuentasPC.xls";//document.forms[0].elements['hRutaDocumento'].value;
				var strPathFile = document.forms[0].elements['hRutaDocumento'].value;
				window.open(strPathFile,'miwin','Width=790,Height=560,scrollbars=true,top=0,left=0');
				return false;
			}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();RestaurarNodoExpande();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" id="tblCabeceraPrint">
				<tr id="Cabecera">
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar de Cuentas por Cobrar y Pagar</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" style="WIDTH: 782px; HEIGHT: 15px" cellSpacing="0" cellPadding="0"
							width="782" align="center" bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD style="WIDTH: 46px" align="right"><asp:label id="Label4" runat="server" CssClass="TextoNegroNegrita" Width="65px">PERIODO :</asp:label></TD>
								<TD style="WIDTH: 18px"><asp:label id="lblPeriodo" runat="server" CssClass="TextoNegroNegrita" Width="64px">PERIODO :</asp:label></TD>
								<TD style="WIDTH: 9px"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="37px" Height="5px">MES :</asp:label></TD>
								<TD style="WIDTH: 37px" vAlign="top"><asp:label id="lblMes" runat="server" CssClass="TextoNegroNegrita" Width="115px" Height="7px">MES :</asp:label></TD>
								<TD vAlign="top" width="20%"><IMG style="WIDTH: 400px; HEIGHT: 12px" height="12" src="/SimaNetWeb/imagenes/spacer.gif"
										width="400"></TD>
								<TD vAlign="top" align="right"><IMG id="IbtnImprimir" onclick="VistaPrevia(this);" alt="" src="../../imagenes/bt_imprimir.gif"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table6" cellSpacing="1" cellPadding="1" width="783" border="0">
							<TR>
								<TD align="left"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server"> <INPUT id="hNombreControlCol" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1"
										name="hNombreControlCol" runat="server">
									<cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" ShowFooter="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="43%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SIMA-CALLAO">
												<HeaderStyle Width="14.25%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="tblCol2" style="WIDTH: 100%; HEIGHT: 37px" cellSpacing="0" cellPadding="0" align="left"
														border="0">
														<TR>
															<TD vAlign="middle" align="center" colSpan="3"><IMG id="btnPlusCallao" style="DISPLAY: none" onclick="MostrarOcultarColCentro(2,this);"
																	src="../../imagenes/tree/Plus.gif">
																<asp:Label id="lblSimaCallao" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">SIMA CALLAO</asp:Label></TD>
														</TR>
														<TR>
															<TD id="Col2Almes" style="DISPLAY: none" align="center" width="33.33%">
																<asp:Label id="lblAlMesdeCallao" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">AL MES DE</asp:Label></TD>
															<TD id="Col2Delmes" style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center"
																width="33.33%">
																<asp:Label id="lblDelMesCallao" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">AL MES DE</asp:Label></TD>
															<TD id="Col2Total" style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center"
																width="33.33%">
																<asp:Label id="lblTotalCallao" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">TOTAL</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA-CHIMBOTE">
												<HeaderStyle Width="14.25%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="tblCol3" style="WIDTH: 100%; HEIGHT: 37px" cellSpacing="0" cellPadding="0" align="left"
														border="0">
														<TR>
															<TD vAlign="middle" align="center" colSpan="3"><IMG id="btnPlusChimbote" style="DISPLAY: none" onclick="MostrarOcultarColCentro(3,this);"
																	src="../../imagenes/tree/Plus.gif">
																<asp:Label id="lblSimaChimbote" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">SIMA CHIMBOTE</asp:Label></TD>
														</TR>
														<TR>
															<TD id="Col3Almes" style="DISPLAY: none" align="center" width="33.33%">
																<asp:Label id="lblAlMesdeChimbote" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">AL MES DE</asp:Label></TD>
															<TD id="Col3Delmes" style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center"
																width="33.33%">
																<asp:Label id="lblDelMesChimbote" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">DEL MES DE</asp:Label></TD>
															<TD id="Col3Total" style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center"
																width="33.33%">
																<asp:Label id="lblTotalChimbote" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">TOTAL</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA-IQUITOS">
												<HeaderStyle Width="14.25%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="tblCol4" style="WIDTH: 100%; HEIGHT: 37px" cellSpacing="0" cellPadding="0" align="left"
														border="0">
														<TR>
															<TD vAlign="middle" align="center" colSpan="3"><IMG id="btnPlusIquitos" style="DISPLAY: none" onclick="MostrarOcultarColCentro(4,this);"
																	src="../../imagenes/tree/Plus.gif">
																<asp:Label id="lblSimaIquitos" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">SIMA IQUITOS</asp:Label></TD>
														</TR>
														<TR>
															<TD id="Col4Almes" style="DISPLAY: none" align="center" width="33.33%">
																<asp:Label id="lblAlMesdeIquitos" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">AL MES DE</asp:Label></TD>
															<TD id="Col4Delmes" style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center"
																width="33.33%">
																<asp:Label id="lblDelMesIquitos" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">DEL MES DE</asp:Label></TD>
															<TD id="Col4Total" style="DISPLAY: none; BORDER-LEFT: #cccccc 1px solid" align="center"
																width="33.33%">
																<asp:Label id="lblTotalIquitos" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None" 
 Font-Bold="True">TOTAL</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn HeaderText="TOTAL">
												<HeaderStyle Width="14.25%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><IMG style="WIDTH: 250px; HEIGHT: 12px" height="12" src="/SimaNetWeb/imagenes/spacer.gif"
										width="250"></TD>
							</TR>
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">&nbsp;<INPUT id="hValoresRestaurados" style="WIDTH: 123px; HEIGHT: 22px" type="hidden" size="15"
										name="hValoresRestaurados" runat="server">&nbsp; <INPUT id="hRutaDocumento" style="WIDTH: 123px; HEIGHT: 22px" type="hidden" size="15" name="hValoresRestaurados"
										runat="server">
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="629" border="0" style="WIDTH: 629px; HEIGHT: 28px">
										<TR>
											<TD></TD>
											<TD><INPUT id="ibtnPantallaPropuesta" type="button" value="Pantalla Propuesta" runat="server"></TD>
											<TD style="WIDTH: 353px"><INPUT class="normaldetalle" id="filMyFileDocumento" style="WIDTH: 358px; HEIGHT: 17px"
													type="file" size="40" name="filMyFile" runat="server"></TD>
											<TD>
												<asp:Button id="ibtnGuardar" runat="server" Text="Guardar" Width="71px"></asp:Button></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">&nbsp;
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="445" border="0" style="DISPLAY: none">
										<TR class="HEADERGRILLA">
											<TD>RESUMEN</TD>
										</TR>
										<TR>
											<TD><cc1:datagridweb id="dbGridResumen" runat="server" Width="445px" PageSize="7" AllowSorting="True"
													AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
															<HeaderStyle Width="30%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="SIMA-PERU S.A">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="SIMA-IQUITOS">
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="TOTAL">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD align="center"><IMG style="WIDTH: 250px; HEIGHT: 12px" height="12" src="/SimaNetWeb/imagenes/spacer.gif"
													width="250"></TD>
										</TR>
										<TR>
											<TD align="center">
												<TABLE id="Table2" style="DISPLAY: none; WIDTH: 217px; HEIGHT: 12px" cellSpacing="1" cellPadding="1"
													width="217" align="center" border="1">
													<TR class="Alternateitemgrilla">
														<TD class="HeaderGrilla"><asp:label id="Label5" runat="server" Height="2px">TIPO DE CAMBIO .</asp:label></TD>
														<TD align="left"><asp:textbox id="txtTCVenta" runat="server" CssClass="Textoazul" Width="70px" ReadOnly="True"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="592"></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
