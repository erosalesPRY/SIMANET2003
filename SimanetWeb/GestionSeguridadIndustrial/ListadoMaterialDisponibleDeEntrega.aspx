<%@ Page language="c#" Codebehind="ListadoMaterialDisponibleDeEntrega.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.ListadoMaterialDisponibleDeEntrega" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ListadoMaterialDisponibleDeEntrega</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD align="left">
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
							<TR>
								<TD class="HEADERGRILLA" noWrap></TD>
								<TD width="100%" align="center">
									<asp:Label id="lblNombreArea" runat="server" Font-Bold="True">Label</asp:Label></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HEADERGRILLA" noWrap><asp:label id="Label1" runat="server">Buscar Material:</asp:label></TD>
								<TD width="100%"><asp:textbox id="txtBuscarMatEnt" runat="server" Width="100%" BorderWidth="1px" BorderColor="Gray"
										CssClass="NormalDetalle"></asp:textbox></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD>
						<div style="HEIGHT:420px; OVERFLOW:scroll">
							<cc1:datagridweb style="Z-INDEX: 0" id="gridMatEnt" runat="server" Width="100%" CssClass="HeaderGrilla"
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
						</div>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
