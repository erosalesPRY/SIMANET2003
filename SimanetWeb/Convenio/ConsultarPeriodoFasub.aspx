<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="ConsultarPeriodoFasub.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.ConsultarPeriodoFasub" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarPeriodoFasub</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<! Begin Smooth Blend Pages IN and OUT -->
		<META http-equiv="Page-Enter" content="BlendTrans(Duration=0.4)">
		<META http-equiv="Site-Exit" content="BlendTrans(Duration=0.4)">
		<! End Smooth Blend Pages IN and OUT --><LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body style="OVERFLOW-Y: scroll; OVERFLOW-X: hidden; WIDTH: 100%" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Convenio ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> PERIODO DE UNIDADES DE APOYO UNIDADES</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="720" border="0">
							<TR>
								<TD align="center" width="100%">
									<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD bgColor="#f5f5f5">
												<asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario">APOYO UNIDADES</asp:label><BR>
												<asp:imagebutton id="ibtnFiltro" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="/SimanetWeb/imagenes/filtroporseleccion.jpg">
												<asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="/SimanetWeb/imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f5f5f5"></TD>
											<TD bgColor="#f5f5f5">&nbsp;</TD>
											<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif" Visible="False"
													CausesValidation="False"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" AllowSorting="True" AutoGenerateColumns="False"
										AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Width="100%" ShowFooter="True"
										PageSize="9">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDPERIODOAPOYOFASUB" HeaderText="IdPeriodoApoyoFasub"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IDUNIDADAPOYO" HeaderText="IdUnidadApoyo"></asp:BoundColumn>
											<asp:BoundColumn DataField="PERIODO" SortExpression="PERIODO" HeaderText="PERIODO">
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="ASIGNADO NS"
												DataFormatString="{0:# ### ### ##0.00}">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="EJECUTADO NS"
												DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEnEjecucion" SortExpression="MontoEnEjecucion" HeaderText="EN EJECUCION NS"
												DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoSaldo" SortExpression="MontoSaldo" HeaderText="SALDO NS" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle Font-Bold="True" HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD width="100%">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="49%"><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
											<TD width="2%"></TD>
											<TD width="49%"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
										</TR>
										<TR>
											<TD width="49%"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="100%" Height="60px"
													TextMode="MultiLine"></asp:textbox></TD>
											<TD width="2%"></TD>
											<TD width="49%"><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="100%" Height="60px"
													TextMode="MultiLine"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center" height="6"><IMG style="WIDTH: 100px" height="6" src="../imagenes/spacer.gif" width="100"></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hOrdenGrilla" style="WIDTH: 48px; HEIGHT: 22px" type="hidden" size="2" runat="server"><INPUT id="hCodigo" type="hidden" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
