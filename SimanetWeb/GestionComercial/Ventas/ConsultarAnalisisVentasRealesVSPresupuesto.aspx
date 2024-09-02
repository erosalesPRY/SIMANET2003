<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarAnalisisVentasRealesVSPresupuesto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.ConsultarAnalisisVentasRealesVSPresupuesto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
			function AsignarEventos(){
				var oibtnGraficoBarraVentasVSPPTO = document.all["ibtnGraficoBarraVentasVSPPTO"];
				var oibtnGraficoBarra2 = document.all["ibtnGraficoBarra2"];
				oibtnGraficoBarraVentasVSPPTO.onmouseout= function(){
					this.src = "/SimaNetWeb/imagenes/Otros/ibtnGraficoBarra.gif";
				}
				oibtnGraficoBarraVentasVSPPTO.onmousemove= function(){
					this.src = "/SimaNetWeb/imagenes/Otros/ibtnGraficoBarraPress.gif";
				}
				
				oibtnGraficoBarra2.onmouseout= function(){
					this.src = "/SimaNetWeb/imagenes/Otros/ibtnGraficoBarraLinea.gif";
				}
				oibtnGraficoBarra2.onmousemove= function(){
					this.src = "/SimaNetWeb/imagenes/Otros/ibtnGraficoBarraLineaPress.gif";
				}
			}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();AsignarEventos();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Ventas > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Análisis de Ventas Reales VS Presupuesto</asp:label></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 12px" colSpan="3">
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="300" align="center" border="0">
										<TR>
											<TD><IMG style="WIDTH: 160px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="160"></TD>
										</TR>
										<TR>
											<TD>
												<asp:imagebutton id="ibtnGraficoBarraVentasVSPPTO" runat="server" ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoBarra.gif"
													ToolTip="Análisis Ventas Reales vs. Presupuesto"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="3">
												<asp:imagebutton id="ibtnGraficoBarra2" runat="server" ToolTip="Barras" ImageUrl="/SimaNetWeb/imagenes/Otros/ibtnGraficoBarraLinea.gif"></asp:imagebutton><IMG height="8" src="../../imagenes/spacer.gif" width="3"></TD>
										</TR>
										<TR>
											<TD>
												<DIV id="divdatagrid" style="OVERFLOW: auto; WIDTH: 780px; HEIGHT: 224px" align="left">
													<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False" RowHighlightColor="#E0E0E0"
														PageSize="8" Width="400px">
														<AlternatingItemStyle Wrap="False" CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle Wrap="False" CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<FooterStyle CssClass="FooterGrilla"></FooterStyle>
														<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													</cc1:datagridweb>
												</DIV>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
				</TR>
				<TR>
					<TD>
						<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			(function(){
				var objDiv = document.all["divdatagrid"];
				objDiv.style.width = (parseInt(screen.width,10)-30) + "px";
			})()
		</SCRIPT>
	</body>
</HTML>
