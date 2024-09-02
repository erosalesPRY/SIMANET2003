<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="BuscarProyecto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.BuscarProyecto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" vAlign="top" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PROYECTOS POR TIPO</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f5f5f5"
							border="0" align=left>
							<TR>
								<TD class="TitFiltros" style="WIDTH: 301px" align="left">
<asp:label id=lblApellidoPaterno runat="server" CssClass="normal">DESCRIPCION</asp:label></TD>
								<TD class="combos" align="center"></TD>
								<TD class="combos" align="center"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" style="WIDTH: 301px">
<asp:textbox id=txtDescripcion runat="server" Width="552px"></asp:textbox></TD>
								<TD class="combos"></TD>
          <TD class=combos></TD>
          <TD class=combos>
<asp:imagebutton id=btnBuscar runat="server" Width="87px" ImageUrl="../imagenes/bt_Buscar.GIF" Height="22px"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="650" align="center"
							border="0">
							<TR>
								<TD vAlign="top" align="center" colSpan="3"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="650px" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="7" ShowFooter="True">
<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>

<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<Columns>
<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DESCRIPCION" FooterText="Total:">
<HeaderStyle Width="65%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CLIENTE" SortExpression="CLIENTE" HeaderText="CLIENTE">
<HeaderStyle Width="35%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="MontoValorizadoSoles" HeaderText="VALORIZADO"></asp:BoundColumn>
</Columns>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table8" width="650" align="center" border="0">
							<TR>
								<TD align="center">
									<SPAN class="normal">
										<asp:imagebutton id="imgAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>&nbsp;&nbsp;
										<SPAN class="normal">
											<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="../imagenes/bt_cancelar.gif"></asp:image></SPAN></SPAN><SPAN class="normal"></SPAN></TD>
							</TR>
						</TABLE>
						<INPUT id="hIdProyecto" type="hidden" size="1" runat="server"><INPUT id="hNombre" type="hidden" size="1" name="Hidden1" runat="server"></TD>
				</TR>
  <TR>
    <TD style="DISPLAY: none" vAlign=top><asp:dropdownlist id="ddlTipoProyecto" runat="server" CssClass="normal" Width="328px" AutoPostBack="True"></asp:dropdownlist>
<asp:label id=lblTipoProyecto runat="server" CssClass="normal">Tipo de Proyecto</asp:label></TD></TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
			function PonerTexto()
			{ 
				opener.document.forms[0].hIdProyecto.value = document.forms[0].hIdProyecto.value;
				opener.document.forms[0].txtNombreProyecto.value = document.forms[0].hNombre.value;

				window.close();
			} 
			</SCRIPT>
		</form>
	</body>
</HTML>
