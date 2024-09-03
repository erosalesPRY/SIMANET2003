<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarFormatoDetalleFormula.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.ConsultarFormatoDetalleFormula" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarFormatoDetalleFormula</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<div style=" WIDTH: 100%; HEIGHT: 285px; OVERFLOW: auto; TOP: 48px">
				<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="581px" BorderStyle="Ridge" BackColor="Transparent"
					RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" ShowFooter="True">
					<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
					<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
					<FooterStyle CssClass="FooterGrilla"></FooterStyle>
					<ItemStyle CssClass="ItemGrilla"></ItemStyle>
					<Columns>
						<asp:BoundColumn DataField="CuentaContable" HeaderText="CUENTA">
							<HeaderStyle Width="5%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="NombreCuenta" HeaderText="NOMBRE">
							<HeaderStyle Width="80%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
							<FooterStyle Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="MontoMes" HeaderText="MONTO">
							<HeaderStyle Width="20%"></HeaderStyle>
							<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
							<FooterStyle Font-Bold="True" Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
						</asp:BoundColumn>
					</Columns>
					<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
				</cc1:datagridweb>
			</div>
		</form>
	</body>
</HTML>
