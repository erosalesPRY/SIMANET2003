<%@ Page language="c#" Codebehind="ListadodeRestricciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.ListadodeRestricciones" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarFichaMedicaRestricciones</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE style="Z-INDEX: 0; WIDTH: 648px" id="Table2" border="0" cellSpacing="0" cellPadding="0"
				width="648">
				<tr>
					<td align="left">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
							<TR>
								<TD></TD>
								<TD></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap>
									<asp:Label id="Label1" runat="server">Nro Documento:</asp:Label></TD>
								<TD>
									<asp:Label id="lblNroDoc" runat="server"></asp:Label></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" noWrap>
									<asp:Label id="Label2" runat="server">Apellidos y Nombres:</asp:Label></TD>
								<TD width="100%">
									<asp:Label id="lblApellidosyNombres" runat="server"></asp:Label></TD>
								<TD></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD noWrap></TD>
								<TD width="100%"></TD>
								<TD></TD>
								<TD></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD vAlign="top" width="1%" align="center">
						<cc1:datagridweb id="gridRestric" runat="server" CssClass="HeaderGrilla" Height="1px" Width="100%"
							AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="15">
							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
							<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Left"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="RESTRICCIONES">
									<HeaderStyle Width="50%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Cumplir">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemTemplate>
										<asp:Image id="imgCHK" runat="server" ImageUrl="/SimanetWeb/imagenes/Filtro/aprobar.gif"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="No&lt;br&gt;Cumple">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkCumple" runat="server" Text=" "></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="Periodo" HeaderText="PERIODO"></asp:BoundColumn>
								<asp:BoundColumn DataField="IdNoRestriccion" HeaderText="IDNR"></asp:BoundColumn>
								<asp:BoundColumn DataField="IdRestriccion" HeaderText="RESTR"></asp:BoundColumn>
							</Columns>
							<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
