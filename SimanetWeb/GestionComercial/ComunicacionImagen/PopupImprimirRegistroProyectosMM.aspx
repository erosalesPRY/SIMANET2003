<%@ Page language="c#" Codebehind="PopupImprimirRegistroProyectosMM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen.PopupImprimirRegistroProyectosMM" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>PopupImprimirRegistroProyectosMM</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3" style="HEIGHT: 41px">
						<P align="center">
							<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> PROYECTOS METAL MECANICA</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<P align="center">
							<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" RowPositionEnabled="False"
								RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Width="750px" PageSize="7">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn Visible="False" HeaderText="NRO" FooterText="Total:"></asp:BoundColumn>
									<asp:BoundColumn Visible="False" DataField="idproyectoMM" HeaderText="idRegistroProyectoMM"></asp:BoundColumn>
									<asp:BoundColumn DataField="NOMBREPROYECTO" HeaderText="PROYECTO">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
										<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TIPOPRODUCTO" HeaderText="TIPO PRODUCTO"></asp:BoundColumn>
									<asp:BoundColumn DataField="cliente" HeaderText="CLIENTE">
										<HeaderStyle Width="30%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FECHAACUERDO" HeaderText="FECHA DE ACUERDO" DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="20%"></HeaderStyle>
									</asp:BoundColumn>
								</Columns>
								<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							</cc1:datagridweb></P>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<P align="center">
							<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
