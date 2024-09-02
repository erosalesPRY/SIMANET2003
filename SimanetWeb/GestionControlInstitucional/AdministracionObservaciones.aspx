<%@ Page language="c#" Codebehind="AdministracionObservaciones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministracionObservaciones" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
			</TABLE>
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="Commands" style="HEIGHT: 8px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Observaciones</asp:label></TD>
				</TR>
			</TABLE></TD></TR><tr>
				<td>
					<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="780" align="center"
						border="0">
						<TR>
							<TD vAlign="top" align="center" colSpan="3">
								<TABLE id="Table5" style="WIDTH: 590px; HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="590"
									border="0">
									<TR>
										<TD bgColor="#f0f0f0"><IMG height="22" src="../imagenes/tab_izq.gif" width="8" style="WIDTH: 8px; HEIGHT: 22px"></TD>
										<TD bgColor="#f0f0f0"><IMG style="WIDTH: 588px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="588"></TD>
										<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
										<TD bgColor="#f0f0f0"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
										<TD bgColor="#f0f0f0"></TD>
										<TD align="right" width="4"><IMG height="25" src="../imagenes/tab_der.gif" width="4"></TD>
									</TR>
								</TABLE>
								<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" ShowFooter="True" AllowPaging="True"
									AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="780px" PageSize="7">
<AlternatingItemStyle CssClass="AlternateItemGrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn HeaderText="NRO.">
<HeaderStyle Width="5%">
</HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Personal" SortExpression="Personal" HeaderText="RESPONSABLE">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Situacion" SortExpression="Situacion" HeaderText="SITUACION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="DescripcionObservacion" SortExpression="DescripcionObservacion" HeaderText="DESCRIPCION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Accion" SortExpression="Accion" HeaderText="ACCION">
<ItemStyle HorizontalAlign="Left">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
								</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
						</TR>
					</TABLE></TABLE>
					<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
					</SCRIPT>
					<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
						<TR>
							<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"
									style="CURSOR: hand"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hCodigo"
									runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
									name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
									runat="server"></TD>
						</TR>
					</TABLE>
		</form>
	</body>
</HTML>
