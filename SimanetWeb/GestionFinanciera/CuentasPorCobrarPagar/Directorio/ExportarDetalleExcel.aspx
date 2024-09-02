<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ExportarDetalleExcel.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ExportarDetalleExcel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExportarDetalleExcel</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<DIV align="center">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
					<TR>
						<TD colSpan="3">
							<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_exportar.gif"></asp:imagebutton></TD>
					</TR>
					<TR>
						<TD colSpan="3">
							<cc1:datagridweb id="grid" runat="server" ShowFooter="True" AllowSorting="True" RowHighlightColor="#E0E0E0"
								Width="100%" PageSize="7" AutoGenerateColumns="False">
								<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
								<Columns>
									<asp:BoundColumn HeaderText="NRO." FooterText="TOTAL:">
										<HeaderStyle Width="1%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Center"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="CLIENTE">
										<HeaderStyle Width="18%"></HeaderStyle>
										<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
										<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Num_Doc_Ana" SortExpression="Num_Doc_Ana" HeaderText="FACTURA">
										<HeaderStyle Width="8%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
										<HeaderStyle Width="13%"></HeaderStyle>
										<ItemStyle HorizontalAlign="Right"></ItemStyle>
									</asp:BoundColumn>
									<asp:BoundColumn Visible="False" HeaderText="FECHA VENC.">
										<HeaderStyle Width="10%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:TemplateColumn SortExpression="Descripcion" HeaderText="CONCEPTO">
										<ItemTemplate>
											<asp:TextBox id="txtDescripcion" runat="server" CssClass="normalDetalle" Width="100%" TextMode="MultiLine"
												ReadOnly="True" BorderWidth="0px" Rows="3" BackColor="Transparent" BorderColor="Transparent"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
								<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							</cc1:datagridweb></TD>
					</TR>
					<TR>
						<TD></TD>
						<TD></TD>
						<TD></TD>
					</TR>
				</TABLE>
			</DIV>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
