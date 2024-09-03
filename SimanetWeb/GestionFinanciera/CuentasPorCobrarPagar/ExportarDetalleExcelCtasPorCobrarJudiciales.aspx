<%@ Page language="c#" Codebehind="ExportarDetalleExcelCtasPorCobrarJudiciales.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ExportarDetalleExcelCtasPorCobrarJudiciales" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExportarDetalleExcelCtasPorCobrarJudiciales</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<!--<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>-->
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			&nbsp;
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" border="0">
				<TR id="id1">
					<TD colSpan="2"></TD>
				</TR>
				<TR id="id4">
					<TD style="HEIGHT: 21px" align="left" bgColor="#f0f0f0">&nbsp;
						<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\imagenes\bt_exportar.gif"></asp:imagebutton></TD>
					<TD style="HEIGHT: 21px" align="right" bgColor="#f0f0f0"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<cc1:datagridweb id="grid" runat="server" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
							ShowFooter="True" Width="100%">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle HorizontalAlign="Right" CssClass="FooterGrillaEF"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SUBCUENTA" SortExpression="subcuenta" HeaderText="SUB CUENTA">
									<HeaderStyle Width="10%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="DEUDOR">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="nroentidad" SortExpression="nroentidad" HeaderText="IDENT.">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="num_doc_ana" SortExpression="num_doc_ana" HeaderText="REFERENCIA">
									<HeaderStyle Width="10%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="fecha" SortExpression="fecha" HeaderText="FECHA">
									<HeaderStyle Width="12%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="saldo" SortExpression="saldo" HeaderText="SALDO">
									<HeaderStyle Width="12%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="concepto" SortExpression="concepto" HeaderText="CONCEPTO">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn Visible="False" DataField="observaciones" SortExpression="observaciones" HeaderText="OBSERVACIONES">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb><BR>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR id="id5">
					<TD align="left" colSpan="2"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
