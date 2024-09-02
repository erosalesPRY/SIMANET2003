<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="BuscarPais.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.BuscarPais" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<script language="javascript">
				function verificarSelecc()
				{
					if(document.forms[0].elements["hidPais"].length ==0)
					{
						window.alert ("No se ha seleccionado Pais")
						return false;
					}
					else
					{
						opener.document.forms[0].hIdPais.value =document.forms[0].hidPais.value;
						opener.document.forms[0].txtPais.value =document.forms[0].hNombrePais.value;
						window.close();
					}
				}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" scellSpacing="0" cellPadding="0" width="281" align="center" border="0"
				style="WIDTH: 281px; HEIGHT: 377px" cellSpacing=0>
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PAISES</asp:label><INPUT id="hidPais" style="WIDTH: 16px; HEIGHT: 10px" type="hidden" size="1" name="hidPais"
										runat="server"><INPUT id=hNombrePais 
      style="WIDTH: 16px; HEIGHT: 10px" type=hidden size=1 name=hNombrePais 
      runat="server"></TD>
				</TR>
  <TR>
    <TD style="HEIGHT: 2px" colSpan=3><IMG height=14 
      src="../imagenes/TitFiltros.gif" width=82 align=left></TD></TR>
  <TR>
    <TD class=TituloPrincipal align=left colSpan=3>
      <TABLE id=Table4 style="WIDTH: 250px; HEIGHT: 22px" cellSpacing=0 
      cellPadding=0 width=250 border=0>
        <TR bgColor=#f5f5f5>
          <TD style="WIDTH: 12px"><IMG height=22 src="../imagenes/tab_izq.gif" 
            width=4></TD>
          <TD><asp:label id="lblPalabraBusqueda" runat="server" CssClass="normal" Width="122px"> Seleccionar Continente:</asp:label></TD>
          <TD>
<asp:DropDownList id=ddlbContinente runat="server" CssClass="normal" AutoPostBack="True" Width="128px"></asp:DropDownList></TD>
          <TD align=right width=4><IMG height=22 src="../imagenes/tab_der.gif" 
            width=4></TD></TR></TABLE>
           <!--<div id=DIV_HOR style="OVERFLOW-Y:hidden;OVERFLOW-X:scroll;WIDTH:280px;HEIGHT:280px">-->
           <div id=DIV_HOR style="OVERFLOW-Y:scroll;OVERFLOW-X:hidden;WIDTH:280px;HEIGHT:280px">
<cc1:datagridweb id=grid runat="server" Width="265px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="NombreProvincia" SortExpression="NombreProvincia" HeaderText="PAIS">
<HeaderStyle Width="70px">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
									</cc1:datagridweb>
									</div>
									</TD></TR>
  <TR>
    <TD class=TituloPrincipal style="HEIGHT: 3px" align=center colSpan=3>
<asp:label id=lblResultado runat="server" CssClass="ResultadoBusqueda"></asp:label></TD></TR>
  <TR>
					<TD align="center">
						<TABLE id="Table8" width="161" border="0" style="WIDTH: 161px; HEIGHT: 31px">
							<TR>
								<TD align="center"><IMG id="imgAceptar" onclick="verificarSelecc();"
										alt="" dynsrc="../imagenes/bt_aceptar.gif" src="">&nbsp;&nbsp; <SPAN class="normal">
										<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="../imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
					</TD></TR>
			</TABLE>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
