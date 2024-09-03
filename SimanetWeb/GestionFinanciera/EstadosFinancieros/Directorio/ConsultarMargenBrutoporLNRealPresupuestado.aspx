<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Page language="c#" Codebehind="ConsultarMargenBrutoporLNRealPresupuestado.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarMargenBrutoporLNRealPresupuestado" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
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
				function ClosePopupSL(id)
				{
					if (id==1)
					{
						ppLiquidez.style.display="none";
					}
					else
					{
						ppSolvensia.style.display="none";
					}
					//onclick="parent.ClosePopupSolvenciaLiquidez();"
					
				}
				var vCallao="";
				var vChimbote="";
				var vIquitos="";
				var vPeru="";
				function AsignarValor()
					{
						var oCallao = document.all["hObsCallao"];
						vCallao = oCallao.value;
						var oChimbote = document.all["hObsChimbote"];
						vChimbote = oChimbote.value;
						var oIquitos= document.all["hObsIquitos"];
						vIquitos = oIquitos.value;
						var oPeru= document.all["hObsPeru"];
						vPeru = oPeru.value;
					}		
			function MostrarValor(observacion)
			{
					
				
				var strValor ="";
				
					strValor= Reemplazar(observacion,'¿','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'/P',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				
				
				document.all["campo1"].value=strValor;
			}					
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR bgColor="#f0f0f0">
								<TD align="left">
									<TABLE id="Table0" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 52px"><asp:label id="Label3" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 36px"><asp:label id="lblPeriodo" runat="server" Font-Bold="True" Width="32px" ForeColor="Navy" CssClass="TituloPrincipalBlanco"> 2005</asp:label></TD>
											<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="Navy" CssClass="TituloPrincipalBlanco">MES :</asp:label></TD>
											<TD style="WIDTH: 88px"><asp:label id="lblMes" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">Periodo :</asp:label></TD>
											<TD align="center"><asp:label id="Label1" runat="server" Font-Bold="True" Width="373px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">EN MILES DE NUEVOS SOLES</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px" colSpan="5">
												<asp:label id="Label8" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="373px"
													Font-Bold="True">ANALISIS MARGEN BRUTO POR LINEA DE NEGOCIOS</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
										ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn Visible="False" HeaderText="NRO">
												<HeaderStyle Width="3%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
												<HeaderStyle Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="REAL">
												<HeaderStyle Width="30%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="4">
																<asp:Label id="lblDelMesSeleccionado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL FEBRERO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="25%">
																<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" BorderStyle="None">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
																<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="VENTAS - COSTOS">UTILIDAD BRUTA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
																<asp:Label id="Label4" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="UTILIDAD / VENTA * 100">VAR (%)</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table2" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="25%">
																<asp:Label id="lblRealVenta" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblRealCosto" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblRealUtilidades" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">UTILIDAD BRUTA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblRealPorcentajes" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">%</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="25%">
																<asp:Label id="lblSumRealVentas" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblSumRealCosto" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblSumRealUtil" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">UTILIDAD BRUTA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblSumRealUtilPorc" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None"></asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="PRESUPUESTADO">
												<HeaderStyle Width="30%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="4">
																<asp:Label id="lblPresupuestado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUPUESTADO FEBRERO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="25%">
																<asp:Label id="Label15" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
																<asp:Label id="Label16" runat="server" CssClass="HeaderGrilla" BorderStyle="None">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
																<asp:Label id="Label17" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="VENTAS - COSTOS">UTILIDAD BRUTA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="25%">
																<asp:Label id="Label18" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="UTILIDAD / VENTA * 100">VAR (%)</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="25%">
																<asp:Label id="lblPresupVenta" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblPresupCosto" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblPresupUtilidades" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">UTILIDAD BRUTA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblPresupPorcentajes" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">%</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="25%">
																<asp:Label id="lblSumPresupVenta" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VENTAS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblSumPresupCosto" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">COSTOS</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblSumPresupUtilidades" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">UTILIDAD BRUTA</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="25%">
																<asp:Label id="lblSumPresupPorcentajes" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None"></asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="VARIACION">
												<HeaderStyle Width="15%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="2">
																<asp:Label id="lblProyectado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">VARIACION UTILIDAD BRUTA</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="50%">
																<asp:Label id="Label11" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="UTILIDAD REAL - UTILIDAD PRESUPUESTADA">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="50%">
																<asp:Label id="Label12" runat="server" CssClass="HeaderGrilla" BorderStyle="None" ToolTip="(UTILIDAD REAL /  UTILIDAD PRESUPUESTADA) - 1">VAR (%)</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblVariacionenSoles" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">SOLES</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="50%">
																<asp:Label id="lblVariacionenPorcentajes" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">%</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="50%">
																<asp:Label id="lblSumVariacionenSoles" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">SOLES</asp:Label></TD>
															<TD align="right" width="50%">
																<asp:Label id="lblSumVariacionenPorcentajes" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None"></asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label11" runat="server" Height="1px" Font-Size="XX-Small">OBSERVACIONES:</asp:label></TD>
							</TR>
							<TR>
								<TD><TEXTAREA id="campo1" style="FONT-SIZE: 10px; WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 64px"
										name="campo1" rows="4" readOnly cols="101" runat="server"></TEXTAREA></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="right" colSpan="3"><IMG id="Img1" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/RetornarAlFormato.GIF"></TD>
				</TR>
			</table>
			<SCRIPT>
				SIMA.Utilitario.Error.TiempoEsperadePagina();
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
