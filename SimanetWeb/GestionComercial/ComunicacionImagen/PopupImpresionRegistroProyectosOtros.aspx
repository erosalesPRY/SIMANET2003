<%@ Page language="c#" Codebehind="PopupImpresionRegistroProyectosOtros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PopupImpresionRegistroProyectosOtros" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD style="HEIGHT: 236px" vAlign="top" align="center">
						<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> IMPRIMIR PROYECTOS MM</asp:label>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="778" border="0">
							<TR>
								<TD>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="15" Width="100%" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Width="5px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="IDPROYECTO" SortExpression="IDPROYECTO" HeaderText="ID PROYECTO">
												<HeaderStyle Width="120px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRE" SortExpression="NOMBRE" HeaderText="NOMBRE">
												<HeaderStyle Width="250px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LINEAPRODUCTO" SortExpression="LINEAPRODUCTO" HeaderText="LINEA PRODUCTO">
												<HeaderStyle Width="71px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBRECLIENTE" SortExpression="NOMBRECLIENTE" HeaderText="CLIENTE">
												<HeaderStyle Width="260px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FECHAACUERDO" SortExpression="FECHAACUERDO" HeaderText="FIRMA ACUERDO"
												DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="74px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" style="HEIGHT: 12px">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
