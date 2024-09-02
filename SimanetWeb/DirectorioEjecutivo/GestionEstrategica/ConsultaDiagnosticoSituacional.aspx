<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultaDiagnosticoSituacional.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Gestion_Estrategica.ConsultaDiagnosticoSituacional" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb"%>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaDiagnosticoSituacional</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
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
					<TD class="commands">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Proceso Estratégico >  Consultar Diagnostico Situacional</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<asp:Image id="Image1" runat="server" ImageUrl="../../imagenes/spacer.gif" Width="48px" Height="24px"></asp:Image></DIV>
					</TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalAzul">DIAGNOSTICO SITUACIONAL</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image2" runat="server" ImageUrl="../../imagenes/spacer.gif" Width="48px" Height="24px"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
								<TR>
									<TD style="HEIGHT: 2px" bgColor="#f0f0f0">
										<P align="left">
											<asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
												alt="Aplicar Filtro por Selección" src="../../imagenes/filtroPorSeleccion.JPG">
											<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></P>
									</TD>
									<TD style="HEIGHT: 2px" bgColor="#f0f0f0">
										<P align="right">
											<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:imagebutton></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="2">
										<P align="center">
											<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" ShowFooter="True"
												AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
												RowPositionEnabled="False" Width="780px">
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
													<asp:BoundColumn DataField="PARAMETRO" SortExpression="PARAMETRO" HeaderText="PARAMETRO">
														<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<FooterStyle HorizontalAlign="Left"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="ANALISIS" SortExpression="ANALISIS" HeaderText="ANALISIS">
														<ItemStyle HorizontalAlign="Left"></ItemStyle>
													</asp:BoundColumn>
													<asp:TemplateColumn HeaderText="ANEXO">
														<HeaderStyle Width="30px"></HeaderStyle>
														<ItemTemplate>
															<asp:Image id="imgAnexo" runat="server" ImageUrl="../../imagenes/ley1.gif" Height="18px"></asp:Image>
														</ItemTemplate>
													</asp:TemplateColumn>
												</Columns>
												<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											</cc1:datagridweb></P>
									</TD>
								</TR>
								<TR>
									<TD>
										<P><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></P>
									</TD>
									<TD></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
