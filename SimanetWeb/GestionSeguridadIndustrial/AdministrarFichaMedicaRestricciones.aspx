<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarFichaMedicaRestricciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarFichaMedicaRestricciones" %>
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
			<TABLE style="Z-INDEX: 0; WIDTH: 648px; HEIGHT: 456px" id="Table2" border="0" cellSpacing="0" cellPadding="0"
				width="648">
				<TR>
					<TD vAlign="top" width="1%" align="center">
						<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Height="1px" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="15">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle Height="25px" CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO">
<HeaderStyle Width="1%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="RESTRICCIONES">
<HeaderStyle Width="50%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:TemplateColumn>
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemTemplate>
										<asp:CheckBox id="chkRestriccion" runat="server" Text=" "></asp:CheckBox>
									
</ItemTemplate>
</asp:TemplateColumn>
</Columns>

<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
			</TABLE>
		</form>
	
	</body>
</HTML>
