<%@ Page language="c#" Codebehind="AdministrarBitacoraActividades.aspx.cs" AutoEventWireup="false" Inherits="SimaNetWeb.DirectorioEjecutivo.PlanGestion.AdministrarBitacoraActividades" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="750" align="center" border="0"
				style="WIDTH: 750px; HEIGHT: 240px">
				<TR vAlign="baseline" align="left">
					<TD width="100%">
						<uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="99%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Estratégica > Plan Estratégico >  Despliegue de Plan Estratégico > Actividad ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> BITACORA</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"> [BITACORA PROYECTO DE ACTIVIDAD]</asp:label>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top">
						<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD style="HEIGHT: 13px" align="right" bgColor="#f5f5f5">
									<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton>
									<asp:imagebutton id="Imagebutton1" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton>
									<asp:imagebutton id="ibtnImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif" Visible="False"
										CausesValidation="False"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center">
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="7"
										AllowPaging="True" ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla" BackColor="#FFFFFF"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="NRO">
												<HeaderStyle Width="27px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="FechaBitacora" SortExpression="FechaBitacora" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="65px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right" VerticalAlign="Bottom"></FooterStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</FORM>
		<SCRIPT>
					<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
