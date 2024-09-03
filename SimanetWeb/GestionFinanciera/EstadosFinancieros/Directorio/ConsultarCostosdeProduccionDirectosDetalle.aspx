<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Page language="c#" Codebehind="ConsultarCostosdeProduccionDirectosDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarCostosdeProduccionDirectosDetalle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
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
											<TD style="WIDTH: 52px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
													Font-Bold="True">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 36px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
													Width="32px" Font-Bold="True"> 2005</asp:label></TD>
											<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True">MES :</asp:label></TD>
											<TD style="WIDTH: 88px"><asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
													Font-Bold="True">Periodo :</asp:label></TD>
											<TD align="center"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="373px"
													Font-Bold="True">EN NUEVOS DE NUEVOS SOLES</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px" colSpan="5"><asp:label id="lblLN" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="373px"
													Font-Bold="True"></asp:label></TD>
										</TR>
										<TR>
											<TD colSpan="5">
												<asp:label id="Label4" runat="server" Font-Bold="True" Width="56px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CLIENTE :</asp:label>
												<asp:Label id="lblCliente" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco"></asp:Label></TD>
										</TR>
										<TR>
											<TD colSpan="5">
												<asp:label id="Label5" runat="server" Font-Bold="True" Width="56px" ForeColor="Navy" CssClass="TituloPrincipalBlanco">SERVICIO :</asp:label>
												<asp:Label id="lblServicio" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco"></asp:Label></TD>
										</TR>
										<TR>
											<TD colSpan="5">
												<asp:Label id="lblDescripcionCosto" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="70%" border="0">
										<TR>
											<TD>
												<asp:imagebutton id="ibtnFiltrar" runat="server" CausesValidation="False" ImageUrl="../../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../../../imagenes/filtroPorSeleccion.JPG">
												<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
										</TR>
										<TR>
											<TD><cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													ShowFooter="True" CssClass="HeaderGrilla" PageSize="7" AllowPaging="True" AllowSorting="True">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="5%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="DESCRIPCION">
															<HeaderStyle Width="50%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="CANTIDAD" SortExpression="CANTIDAD" HeaderText="CANTIDAD" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="PRECIO UNITARIO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="UNIDAD" SortExpression="UNIDAD" HeaderText="UNIDAD DE MEDIDA">
															<HeaderStyle Width="10%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="monto" SortExpression="monto" HeaderText="MONTO" DataFormatString="{0:# ### ### ##0.00}">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
															<FooterStyle HorizontalAlign="Right"></FooterStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
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
