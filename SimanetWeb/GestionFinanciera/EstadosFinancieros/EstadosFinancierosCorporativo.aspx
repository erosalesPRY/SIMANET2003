<%@ Page language="c#" Codebehind="EstadosFinancierosCorporativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.EstadosFinancierosCorporativo" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
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
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
			var oMiPopup = window.createPopup();
				//Dialogo de Espera
				function showPopupSolvenciaLiquidez(intPopup) 
				{
					var intPopupWidth = 342;
					var intPopupHeight = 130;
					var xleft= event.x; //(window.screen.width/2) - (intPopupWidth/2);
					var yTop=  event.y;//(window.screen.height/2) - (intPopupHeight/2);
					//oMiPopup.style.font.size=10;
					oMiPopup.document.body.innerHTML= parseInt(intPopup)==1? ppLiquidez.innerHTML:ppSolvensia.innerHTML;
					
					oMiPopup.show(xleft, yTop, intPopupWidth, intPopupHeight,document.body);
				}
				
				function ClosePopupSolvenciaLiquidez() 
				{
					if (oMiPopup.isOpen)
					{oMiPopup.hide();}
					
				}
				function ShowPopupLS(id)
				{
					if (id==1)
					{
						ppSolvensia.style.display="none";
						ppLiquidez.style.display="block";
						ppLiquidez.style.left=window.event.x;
						ppLiquidez.style.top=window.event.y;
					}
					else
					{
						ppLiquidez.style.display="none";
						ppSolvensia.style.display="block";
						ppSolvensia.style.left=window.event.x;
						ppSolvensia.style.top=window.event.y;
					}
				}
				function ClosePopupSL(id){
					if (id==1){
						ppLiquidez.style.display="none";
					}
					else{
						ppSolvensia.style.display="none";
					}
				}
				var vCallao="";
				var vChimbote="";
				var vIquitos="";
				var vPeru="";
				function AsignarValor(){
						var oCallao = document.all["hObsCallao"];
						vCallao = oCallao.value;
						var oChimbote = document.all["hObsChimbote"];
						vChimbote = oChimbote.value;
						var oIquitos= document.all["hObsIquitos"];
						vIquitos = oIquitos.value;
						var oPeru= document.all["hObsPeru"];
						vPeru = oPeru.value;
				}				
		</script>
		<script language="javascript">
			var wind="";
			function MostrarIndicadores(URLPAGINA){
				var EXTENSION = ".xls";
				 try{
					if (wind && wind.open && !wind.closed) wind.close();
				 }catch(error){}
				wind = (new SIMA.Utilitario.Helper.Window()).AbrirExcel(URLPAGINA + EXTENSION);
				wind.window.focus();				 
			}
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
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3" style="HEIGHT: 183px">
						<TABLE class="normal" id="Table2" cellSpacing="1" cellPadding="4" width="780" border="0">
							<TR>
								<TD style="WIDTH: 786px" align="center" width="786" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 27px" cellSpacing="0" cellPadding="0" width="770" border="0">
										<TR bgColor="#f0f0f0">
											<TD style="WIDTH: 145px"></TD>
											<TD width="100%">
												<TABLE id="Table7" style="WIDTH: 656px; HEIGHT: 27px" cellSpacing="1" cellPadding="1" width="656"
													align="left" border="0">
													<TR>
														<TD style="WIDTH: 46px"></TD>
														<TD style="WIDTH: 35px"></TD>
														<TD style="WIDTH: 24px"></TD>
														<TD style="WIDTH: 78px"></TD>
														<TD style="WIDTH: 97px"></TD>
														<TD>
															<P align="right">
																<asp:imagebutton id="btnGO" runat="server" ImageUrl="../../imagenes/btnGO.jpg" Visible="False"></asp:imagebutton>
																<asp:imagebutton id="btnVentasCostos" runat="server" ImageUrl="../../imagenes/btnVentaCosto.jpg"
																	Visible="False"></asp:imagebutton></P>
														</TD>
													</TR>
													<TR>
														<TD style="WIDTH: 46px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" DESIGNTIMEDRAGDROP="331"
																Width="80%" ForeColor="Navy">PERIODO :</asp:label></TD>
														<TD style="WIDTH: 35px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True"
																DESIGNTIMEDRAGDROP="392" Width="32px" ForeColor="Navy"> 2005</asp:label></TD>
														<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Navy">MES :</asp:label></TD>
														<TD style="WIDTH: 78px"><asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" DESIGNTIMEDRAGDROP="250"
																Width="80%" ForeColor="Navy">Periodo :</asp:label></TD>
														<TD style="WIDTH: 97px"></TD>
														<TD><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" Width="80%"
																ForeColor="Navy">EN MILES DE NUEVOS SOLES</asp:label></TD>
													</TR>
												</TABLE>
												<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton>
											</TD>
											<TD vAlign="bottom">&nbsp;</TD>
											<TD></TD>
											<TD style="WIDTH: 209px" align="right"></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="770px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="CONCEPTO" SortExpression="CONCEPTO" HeaderText="CONCEPTO">
												<HeaderStyle Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruEjecucionRealDelmesAnterior" HeaderText="Mes&lt;br&gt;Anterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruEjecucionRealDelmesActual" HeaderText="Mes&lt;br&gt;Actual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Font-Bold="True" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruPresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PeruProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosEjecucionRealDelmesAnterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosEjecucionRealDelmesActual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Font-Bold="True" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosPresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IquitosProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3" style="HEIGHT: 130px">
						<TABLE id="lblSollvenciaLiquidez" style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #ffffff 1px solid; BORDER-TOP: #ffffff 1px solid; BORDER-RIGHT: #999999 1px solid"
							cellSpacing="0" cellPadding="0" width="770" border="1" runat="server">
							<TR class="ItemGrilla">
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 218px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="left">&nbsp;
									<asp:label id="lblLiquidez" runat="server" DESIGNTIMEDRAGDROP="399" Width="216px">LIQUIDEZ</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezMesAnteriorP" runat="server" DESIGNTIMEDRAGDROP="401" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 64px; HEIGHT: 19px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezDelMesP" runat="server" DESIGNTIMEDRAGDROP="402" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 62px; HEIGHT: 19px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezPresupuestoP" runat="server" DESIGNTIMEDRAGDROP="403" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 52px; HEIGHT: 19px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezMesAnteriorI" runat="server" DESIGNTIMEDRAGDROP="404" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 38px; HEIGHT: 19px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezDelMesI" runat="server" DESIGNTIMEDRAGDROP="405" Width="76px">0.00</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblLiquidezPresupuestoI" runat="server" DESIGNTIMEDRAGDROP="406" Width="76px">0.00</asp:label></TD>
							</TR>
							<TR class="AlternateItemGrilla">
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 227px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="left"><asp:label id="lblSolvencia" runat="server" Width="231px">SOLVENCIA</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblSolvenciaMesAnteriorP" runat="server" DESIGNTIMEDRAGDROP="419" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblSolvenciaDelMesP" runat="server" DESIGNTIMEDRAGDROP="422" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblSolvenciaPresupuestoP" runat="server" DESIGNTIMEDRAGDROP="423" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblSolvenciaMesAnteriorI" runat="server" DESIGNTIMEDRAGDROP="424" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblSolvenciaDelMesI" runat="server" DESIGNTIMEDRAGDROP="425" Width="76px">0.00%</asp:label></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="right"><asp:label id="lblSolvenciaPresupuestoI" runat="server" Width="76px">0.00%</asp:label></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 227px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="left"></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"></TD>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 50px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"></TD>
							</TR>
							<TR>
								<TD style="BORDER-BOTTOM: buttonface 1px solid; BORDER-LEFT: buttonface 1px solid; WIDTH: 227px; BORDER-TOP: buttonface 1px solid; BORDER-RIGHT: buttonface 1px solid"
									align="left" colSpan="7">
									<P align="right">&nbsp;</P>
								</TD>
							</TR>
						</TABLE>
						<BR>
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="770" border="0">
							<TR>
								<TD>
									<P align="right">
										<asp:HyperLink id="lnkHistPeru" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
											Width="104px" Target="_blank" Visible="False">Histórico Perú</asp:HyperLink>
										<asp:HyperLink id="lnkHistorIquitos" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
											Width="110px" Target="_blank" Visible="False">Histórico Iquitos</asp:HyperLink>
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<IMG style="PADDING-RIGHT: 20px; CURSOR: hand" src="../../imagenes/Otros/ibtnIndicadorFinanciero.gif"
											onclick="startExcel();" id="ibtnIndicadores" runat="server">
										<asp:imagebutton id="ibtnProyPorLiquidar" runat="server" ImageUrl="../../imagenes/btnProyectosPorLiquidar.jpg"
											Visible="False"></asp:imagebutton>
										<asp:imagebutton id="ibtnCtasPorCobrar" runat="server" ImageUrl="../../imagenes/btncuentasPorCobrarPagarnuevo.jpg"
											Visible="False"></asp:imagebutton></P>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 1px" align="center" colSpan="3">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="770" border="0">
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hObsCallao" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsCallao"
										runat="server"><INPUT id="hObsChimbote" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsChimbote"
										runat="server"><INPUT id="hObsIquitos" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsIquitos"
										runat="server"><INPUT id="hObsPeru" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsPeru"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<div id="ppLiquidez" style="POSITION: absolute; BACKGROUND-COLOR: #ffffff; WIDTH: 440px; DISPLAY: none; HEIGHT: 106px; LEFT: 50px">
							<TABLE class="normaldetalle" id="Table4" style="WIDTH: 444px; HEIGHT: 88px; LEFT: 150px"
								cellSpacing="1" cellPadding="1" width="444" border="1">
								<TR class="ItemGrilla">
									<TD style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BACKGROUND-COLOR: #cccccc; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid"
										vAlign="middle" align="left">
										<TABLE id="Table5" style="WIDTH: 432px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="432"
											align="right" border="0">
											<TR class="ItemGrilla">
												<TD style="WIDTH: 415px; COLOR: navy" vAlign="middle">DEFINICIÓN DE LIQUIDEZ</TD>
												<TD vAlign="middle" align="right"><IMG id="imgClose" onmouseover="this.src='../../imagenes/tree/CloseWindowB.gif'" onclick="ClosePopupSL(1);"
														onmouseout="this.src='../../imagenes/tree/CloseWindowA.gif'" src="../../imagenes/tree/CloseWindowA.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid"
										align="left">
										<P align="justify">La empresa puede hacer frente a sus obligaciones de corto 
											plazo.La Liquidez se mide mediante el ratio :&nbsp;&nbsp;<FONT style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid"
												color="#0033ff" size="1">ACTIVO CORRIENTE / PASIVO CORRIENTE</FONT><br>
											Los límites aceptables de este ratio se fijan entre <FONT color="#0000ff">1.7</FONT>
											y <FONT color="#0000ff">1.9.</FONT> No debe ser menor a 1.</P>
									</TD>
								</TR>
							</TABLE>
						</div>
						<!---Solvensia-->
						<div id="ppSolvensia" style="POSITION: absolute; BACKGROUND-COLOR: #ffffff; DISPLAY: none">
							<TABLE class="normaldetalle" id="Table4" style="WIDTH: 342px; HEIGHT: 76px" cellSpacing="1"
								cellPadding="1" width="342" border="1">
								<TR class="ItemGrilla">
									<TD style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BACKGROUND-COLOR: #cccccc; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid"
										vAlign="middle" align="left">
										<TABLE id="Table5" style="WIDTH: 336px; HEIGHT: 22px" cellSpacing="1" cellPadding="1" width="336"
											align="right" border="0">
											<TR class="ItemGrilla">
												<TD style="WIDTH: 318px; COLOR: navy" vAlign="middle">DEFINICIÓN DE SOLVENCIA</TD>
												<TD vAlign="middle" align="right"><IMG id="imgClose" onmouseover="this.src='../../imagenes/tree/CloseWindowB.gif'" onclick="ClosePopupSL(0);"
														onmouseout="this.src='../../imagenes/tree/CloseWindowA.gif'" src="../../imagenes/tree/CloseWindowA.gif"></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid"
										align="left">
										<P align="justify">Grado de compromiso del Patrimonio frente a su Pasivo total 
											(Obligaciones) En este caso la Solvencia se mide por:&nbsp;<br>
											<FONT style="BORDER-BOTTOM: #999999 1px solid; BORDER-LEFT: #999999 1px solid; BORDER-TOP: #999999 1px solid; BORDER-RIGHT: #999999 1px solid"
												color="#0033ff" size="1">(PASIVO TOTAL/PATRIMONIO)*100.</FONT><br>
											El límite máximo aceptable de este ratio es de 60%.</P>
									</TD>
								</TR>
							</TABLE>
						</div>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
		<SCRIPT>
				var odgrid = jNet.get('grid');
				for(var i=1;i<=odgrid.rows.length-1;i++){
					var Concepto = jNet.get(odgrid.rows[i].cells[0]).getAttribute("CONCEPTO");
					if(Concepto!=null){
							new Ext.ToolTip({
									target: odgrid.rows[i].cells[0].id,
									title: odgrid.rows[i].cells[0].getAttribute("TITULO"),
									width:400,
									html: Concepto,
									trackMouse:true,
									dismissDelay: 15000 // auto hide after 15 seconds
								});						
						
					}
				}
		</SCRIPT>
	</body>
</HTML>
