<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarSubproceso.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.ConsultarSubproceso" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarSubproceso</title>
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
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta de Subprocesos</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image1" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">DESARROLLO DEL SUBPROCESO</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<asp:Image id="Image2" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" border="0" width="780">
								<tr>
									<td colSpan="1" rowSpan="1">
										<TABLE id="Table3" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
											border="2">
											<TR>
												<TD style="HEIGHT: 2px" width="90"><asp:label id="lblProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
												<TD style="HEIGHT: 2px"><asp:label id="lblNombreProceso" runat="server" CssClass="normaldetalle"></asp:label></TD>
											</TR>
											<TR>
											</TR>
										</TABLE>
									</td>
								</tr>
								<TR>
									<TD></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<DIV align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" PageSize="7" ShowFooter="True"
												AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
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
													<asp:BoundColumn DataField="CODIGOSUBPROCESO" SortExpression="CODIGOSUBPROCESO" HeaderText="SUB PROCESO">
														<ItemStyle VerticalAlign="Middle"></ItemStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
														<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														<FooterStyle HorizontalAlign="Left"></FooterStyle>
													</asp:BoundColumn>
													<asp:BoundColumn DataField="RESPONSABLE" SortExpression="RESPONSABLE" HeaderText="RESPONSABLE">
														<HeaderStyle Width="10%"></HeaderStyle>
													</asp:BoundColumn>
												</Columns>
												<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
											</cc1:datagridweb></DIV>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								</TR>
								<TR>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">&nbsp;</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
