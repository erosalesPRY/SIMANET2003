<%@ Page language="c#" Codebehind="DetalleStockMaterialPorAreaValeSalida.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleStockMaterialPorAreaValeSalida" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleStockMaterialPorAreaValeSalida</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD align="right">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" align="right">
							<TR>
								<TD></TD>
								<TD width="80%"></TD>
								<TD></TD>
								<TD width="20%" align="right"></TD>
								<TD align="right"><INPUT style="Z-INDEX: 0" id="cmdEliminar" value="Eliminar" type="button" name="Button1"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" CssClass="HeaderGrilla"
							PageSize="15" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							AllowSorting="True">
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
								<asp:BoundColumn DataField="nro_vsm" HeaderText="NRO VALE.">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="cod_mat" HeaderText="COD MATERIAL">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="des_det" HeaderText="DES MATERIAL">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Talla" HeaderText="TALLA">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
									<FooterStyle HorizontalAlign="Left"></FooterStyle>
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
						</cc1:datagridweb>
					</TD>
				</TR>
				<TR>
					<TD><INPUT style="WIDTH: 72px; HEIGHT: 23px" id="hGCodItem" size="6" type="hidden" runat="server"
							NAME="hGCodItem"><INPUT style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 23px" id="hAtendidos" value="0" size="6"
							type="hidden" name="hAtendidos" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
