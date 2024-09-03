<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="DetalleStockMaterialPorArea.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleStockMaterialPorArea" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleStockMaterialPorArea</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="80%" align="center">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" align="right">
							<TR>
								<TD>
									<asp:Label id="Label1" runat="server" Font-Bold="True" Font-Size="Smaller">BUSCAR:</asp:Label></TD>
								<TD width="80%">
									<asp:TextBox id="txtBuscar" runat="server" Width="90%" BorderWidth="1px" BorderColor="Gray" CssClass="NormalDetalle"></asp:TextBox></TD>
								<TD><INPUT style="Z-INDEX: 0" id="cmdAgregarVale" value="Vale de Salida" type="button" runat="server"></TD>
								<TD width="20%" align="right"><INPUT style="Z-INDEX: 0; WIDTH: 144px; HEIGHT: 24px" id="cmdEntregaMaterialPorArea" value="Entrega de Materiales"
										type="button" name="cmdEntregaMaterial" runat="server"></TD>
								<TD align="right"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="15" CssClass="HeaderGrilla">
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Left"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cod_mat" HeaderText="COD MATERIAL">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="des_det" HeaderText="DES MATERIAL">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NroItems" HeaderText="NRO&lt;BR&gt;ITEM(S)">
									<HeaderStyle HorizontalAlign="Center" Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantEnVSM" HeaderText="CANT&lt;BR&gt;EN&lt;BR&gt;VSM">
									<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantRegistrada" HeaderText="REG.">
									<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CantAtendida" HeaderText="ATEN.">
									<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="StockActual" HeaderText="EN&lt;BR&gt;STOCK">
									<HeaderStyle HorizontalAlign="Center" Width="3%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD><INPUT style="WIDTH: 72px; HEIGHT: 23px" id="hGCodItem" size="6" type="hidden" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
