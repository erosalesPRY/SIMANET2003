<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarSubprocesoObjEspAccion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.ConsultarSubprocesoObjEspAccion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarSubprocesoObjEspAccion</title>
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
					<TD class="Commands">
						<P style="COLOR: white" align="left">
							<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label>
							<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Acciones</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image1" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<P align="center">
							<asp:Label id="Label1" runat="server" CssClass="TituloPrincipalAzul">ACCIONES</asp:Label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<DIV align="left">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="735" align="center" border="0">
								<TR>
									<TD>
										<P align="left">
											<asp:Image id="Image2" runat="server" ImageUrl="../../imagenes/spacer.gif" Height="16px" Width="72px"></asp:Image></P>
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 46px">
										<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
											border="2">
											<TR>
												<TD style="WIDTH: 109px; HEIGHT: 2px" width="109">
													<asp:label id="lblProceso" runat="server" CssClass="normaldetalle" Width="90px"></asp:label></TD>
												<TD style="HEIGHT: 2px">
													<asp:Label id="lblNombreProceso" runat="server" CssClass="normaldetalle"></asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 109px; HEIGHT: 15px" width="109">
													<asp:label id="lblSubProceso" runat="server" CssClass="normaldetalle" Width="90px"></asp:label></TD>
												<TD style="HEIGHT: 2px">
													<asp:Label id="lblNombreSubProceso" runat="server" CssClass="normaldetalle"></asp:Label></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 109px; HEIGHT: 2px" width="109">
													<asp:label id="lblObjetivoEspecifico" runat="server" CssClass="normaldetalle" Width="90px"></asp:label></TD>
												<TD style="HEIGHT: 2px">
													<asp:Label id="lblNombreObjetivoEspecifico" runat="server" CssClass="normaldetalle"></asp:Label></TD>
											</TR>
											<TR>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<P align="center">
											<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" PageSize="7" ShowFooter="True"
												AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
												RowPositionEnabled="False">
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
													<asp:BoundColumn DataField="CODIGOACCION" SortExpression="CODIGOACCION" HeaderText="ACCION">
														<ItemStyle VerticalAlign="Middle"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
														<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<FooterStyle HorizontalAlign="Left"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="AF" SortExpression="AF" HeaderText="AF">
														<HeaderStyle Width="5%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="PESO" SortExpression="PESO" HeaderText="PESO">
														<HeaderStyle Width="5%"></HeaderStyle>
														<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											</cc1:datagridweb></P>
									</TD>
								</TR>
								<TR>
									<TD>
										<P align="center">
											<asp:Label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:Label></P>
									</TD>
								</TR>
								<TR>
									<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
									</TD>
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
