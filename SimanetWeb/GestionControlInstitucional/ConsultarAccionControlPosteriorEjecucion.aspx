<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarAccionControlPosteriorEjecucion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.ConsultarAccionControlPosteriorEjecucion" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión de Control Institucional > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Ejecuciones de las Acciones de Control Posterior</asp:label></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="780" align="center" bgColor="#f0f0f0"
										border="0">
										<TR>
											<TD bgColor="#f0f0f0" colSpan="2"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4">
												<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0"><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../imagenes/filtroPorSeleccion.JPG"></TD>
											<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0"><IMG height="8" src="../../imagenes/spacer.gif" width="460"></TD>
											<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" Width="780px" BorderStyle="Dotted"
										ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdAccionCtrlPosteriorEjec"></asp:BoundColumn>
											<asp:BoundColumn DataField="Codigo" SortExpression="Codigo" HeaderText="CODIGO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Denominacion" SortExpression="Denominacion" HeaderText="ACCION DE CONTROL">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MetaProgramada" SortExpression="MetaProgramada" HeaderText="META" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Estado" SortExpression="Estado" HeaderText="ESTADO"></asp:BoundColumn>
											<asp:BoundColumn DataField="Etapa" SortExpression="Etapa" HeaderText="ETAPA">
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="PorcentajeAvanceTotal" SortExpression="PorcentajeAvanceTotal" HeaderText="%"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaInicio" SortExpression="FechaInicio" HeaderText="FECHA INICIO" DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
											<asp:BoundColumn DataField="FechaTermino" SortExpression="FechaTermino" HeaderText="FECHA TERMINO"
												DataFormatString="{0:dd-MM-yyyy}"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="NroRealIntegrantesOCI" SortExpression="NroRealIntegrantesOCI"
												HeaderText="INTEGRANTES OCI"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="NroRealIntegrantesEspecialistas" SortExpression="NroRealIntegrantesEspecialistas"
												HeaderText="INTEGRANTES ESPECIALISTAS"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CostoRealOCI" SortExpression="CostoRealOCI" HeaderText="COSTO OCI"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CostoRealEspecialistas" SortExpression="CostoRealEspecialistas"
												HeaderText="COSTO ESPECIALISTAS" DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="NumeroRealHH" SortExpression="NumeroRealHH" HeaderText="NUMERO HH"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn DataField="MontoExaminado" SortExpression="MontoExaminado" HeaderText="MONTO EXAMINADO"
												DataFormatString="{0:# ### ### ##0.00}"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES"></asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:TextBox id="txtObservaciones" runat="server" Width="780px" TextMode="MultiLine" ReadOnly="True"
										CssClass="normal"></asp:TextBox></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
