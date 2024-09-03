<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarAuditoria.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarAuditoria" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Auditoria</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script>
			function grid_onClick(e){
			
			}
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%">
						<uc1:Header id="Header1" runat="server"></uc1:Header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" vAlign="top" width="100%" bgColor="#eff7fa">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Auditoria</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR bgColor="#f0f0f0">
								<TD>
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD width="100%"></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"
													CausesValidation="False"></asp:imagebutton></TD>
											<TD></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" ShowFooter="True" PageSize="15"
										RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="30px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" HeaderText="CENTRO"></asp:BoundColumn>
											<asp:BoundColumn DataField="CodigoAUD" SortExpression="CodigoAUD" HeaderText="CODIGO">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreAuditoria" SortExpression="NombreAuditoria" HeaderText="TIPO AUDITORIA">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaDesde" SortExpression="FechaDesde" HeaderText="FECHA DESDE">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaHasta" SortExpression="FechaHasta" HeaderText="FECHA HASTA">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DECRIPCION">
												<HeaderStyle Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD><INPUT style="WIDTH: 48px; HEIGHT: 22px" id="hIdDestino" size="2" type="hidden" runat="server"
										NAME="hIdDestino"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
