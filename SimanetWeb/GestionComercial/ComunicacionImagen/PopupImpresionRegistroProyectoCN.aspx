<%@ Page language="c#" Codebehind="PopupImpresionRegistroProyectoCN.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PopupImpresionRegistroProyectoCN" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> IMPRIMIR PROYECTOS CN</asp:label><BR>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Width="780px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
												<HeaderStyle Width="5px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="idRegistroProyectoCN" HeaderText="idRegistroProyectoCN"></asp:BoundColumn>
											<asp:BoundColumn DataField="idHistorico" SortExpression="idHistorico" HeaderText="ID PROYECTO">
												<HeaderStyle Width="120px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CO" SortExpression="CO" HeaderText="CO">
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nombre" SortExpression="Nombre" HeaderText="NOMBRE">
												<HeaderStyle Width="170px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="Buque" SortExpression="Buque" HeaderText="TIPO PRODUCTO">
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="LINEAPRODUCTO" SortExpression="LINEAPRODUCTO" HeaderText="LINEA DE PRODUCTO">
												<HeaderStyle Width="78px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="CLIENTE">
												<HeaderStyle Width="250px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="fechafirmaacuerdo" SortExpression="fechafirmaacuerdo" HeaderText="FECHA ACUERDO"
												DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="79px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><BR>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label>
								</TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
				</TR>
				<TR bgColor="#5891ae">
				</TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
