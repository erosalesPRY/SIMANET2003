<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="PopupImpresionConsultarGestionesDirectorio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio.PopupImpresionConsultarGestionesDirectorio" %>
<%@ Register TagPrefix="uc1" TagName="FooterImpresion" Src="../../ControlesUsuario/FooterImpresion.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server" onkeydown="return verificarBackspace()">
			<TABLE class="xsolid" id="Table1" cellSpacing="0" cellPadding="0" width="725" align="center"
				border="0">
				<TR>
					<TD align="center" class="TituloPrincipal"><asp:label id="lblTitulo" runat="server"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD class="xsolid" align="center">
									<cc1:datagridweb id="grid" runat="server" AllowSorting="True" RowHighlightColor="#E0E0E0" CssClass="HeaderGrilla"
										AllowPaging="True" AutoGenerateColumns="False" Width="689px" PageSize="5">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="Gestion" SortExpression="Gestion" HeaderText="GESTION">
<HeaderStyle Width="30%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FechaGestion" SortExpression="FechaGestion" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center">
</ItemStyle>

<FooterStyle HorizontalAlign="Left">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DescripcionGestion" SortExpression="DescripcionGestion" HeaderText="DESCRIPCION">
<HeaderStyle Width="60%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
