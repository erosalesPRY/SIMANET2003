<%@ Page language="c#" Codebehind="DetalleConsultaAlineamientoEstrategico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.DetalleConsultaAlineamientoEstrategico" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleConsultaAlineamientoEstrategico</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Proceso Estratégico > Consultar Alineamiento Estratégico >  Detalle Consulta Alineamiento Estratégico</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image2" runat="server" Width="48px" Height="24px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="782" align="center" border="0">
							<TR>
								<TD>
									<P align="center">
										<asp:Label id="lblTituloPagina" runat="server" CssClass="TituloPrincipalAzul"></asp:Label></P>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:Image id="Image1" runat="server" Width="48px" Height="24px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 1px">
									<TABLE id="Table4" borderColor="#ffffff" cellSpacing="0" cellPadding="1" width="100%" bgColor="#f0f0f0"
										border="2">
										<TR>
											<TD style="WIDTH: 19px" bgColor="#f0f0f0">
												<asp:Label id="lblCodigoObjGeneral" runat="server" CssClass="normaldetalle" Width="20px"></asp:Label></TD>
											<TD bgColor="#f0f0f0">
												<asp:Label id="lblContenidoObjGeneral" runat="server" CssClass="NormalDetalle" Width="100%"
													Height="2px"></asp:Label></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 5px">
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
										ShowFooter="True" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INSTITUCION" SortExpression="INSTITUCION" HeaderText="ORGANISMO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="REFERENCIA" SortExpression="REFERENCIA" HeaderText="REFERENCIA">
												<HeaderStyle Width="70%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" bgColor="#f5f5f5" border="0">
										<TR>
											<TD class="TitFiltros" style="WIDTH: 35px" bgColor="#f5f5f5">
												<asp:label id="lblObjeto" runat="server" CssClass="normal">Descripcion:</asp:label></TD>
											<TD class="combos" bgColor="#f5f5f5">
												<asp:textbox id="txtObjeto" runat="server" CssClass="normal" Height="56px" Width="100%" TextMode="MultiLine"
													ReadOnly="True" BorderStyle="Groove"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
								</TD>
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
