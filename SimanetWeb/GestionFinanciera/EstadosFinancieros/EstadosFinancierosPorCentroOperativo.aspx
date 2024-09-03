<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="ParametroContable" Src="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Page language="c#" Codebehind="EstadosFinancierosPorCentroOperativo.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.EstadosFinancierosPorCentroOperativo" %>
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
						var oPeru = document.all["hObsPeru"];
						vPeru = oPeru.value;
					}
					
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
					innerText = "PERIODO :" + oPagina.Request.Params["NombreMes"] + " DEL " + oPagina.Request.Params["efFecha"].split('/')[2] ;
					setAttribute("face","arial"); 
					setAttribute("size","2");
					setAttribute("color","black");
				}
				oCabecera.CenterCenter(ohtmlFuente);
				//Adicion al cabcera configurada
				oPrinter.ConfigurarCabecera(oCabecera);
				
				oPrinter.VistaPrevia(e,Cabecera,FilaMenu,FilaToolBar,CeldaAbajo);
			}
					
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial2();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr id="Cabecera">
					<td width="100%" colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR id="FilaMenu">
					<TD width="100%" colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" width="100%" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Estados Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE  class="normal" id="Table2" style="WIDTH: 770px; HEIGHT: 212px" cellSpacing="0" cellPadding="4"
							width="770" border="0">
							<TR>
								<TD style="WIDTH: 786px" align="center" width="786" colSpan="3">
									<TABLE id="Table3" style="HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0" id="FilaToolBar">
											<TD style="WIDTH: 145px"></TD>
											<TD width="100%">
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
													<TR>
														<TD style="WIDTH: 63px">
															<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="151"
																Font-Bold="True" ForeColor="Navy">PERIODO :</asp:label></TD>
														<TD style="WIDTH: 34px">
															<asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True"
																ForeColor="Navy">[Periodo]</asp:label></TD>
														<TD style="WIDTH: 37px">
															<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="174"
																Font-Bold="True" ForeColor="Navy">MES :</asp:label></TD>
														<TD>
															<asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" Font-Bold="True" ForeColor="Navy">[Mes]</asp:label></TD>
													</TR>
												</TABLE>
												<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"></asp:imagebutton>
											</TD>
											<TD vAlign="bottom">&nbsp;</TD>
											<TD></TD>
											<TD style="WIDTH: 209px" align="right"></TD>
											<TD><IMG id="ImgImprimir" onclick="VistaPrevia(this);" alt="" src="../../imagenes/bt_imprimir.gif"></TD>
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
											<asp:BoundColumn DataField="CallaoEjecucionRealDelmesAnterior" HeaderText="Mes&lt;br&gt;Anterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoEjecucionRealDelmesActual" HeaderText="Mes&lt;br&gt;Actual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoPresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CallaoProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteEjecucionRealDelmesAnterior">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteEjecucionRealDelmesActual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteEjecucionRealAcumulado">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimbotePresupuestoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ChimboteProyectadoAnual">
												<HeaderStyle Width="7%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR id="CeldaAbajo">
								<TD style="WIDTH: 786px" align="left" width="786" colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="ReemplazaHistorial();HistorialIrAtras();"
										alt="" src="../../imagenes/atras.gif"><INPUT id="hObsCallao" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsCallao"
										runat="server"><INPUT id="hObsChimbote" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsChimbote"
										runat="server"><INPUT id="hObsIquitos" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsIquitos"
										runat="server"><INPUT id="hObsPeru" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hObsPeru"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 10px" align="center" colSpan="3">
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><INPUT id="objHistorial" type="hidden" name="objHistorial"></TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
