<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministracionProyectoConvenio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionProyectoConvenio" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Simanet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/general.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top" width="100%"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 12px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración > Convenio</asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> ADMINISTRAR ACTIVIDADES</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" colSpan="2">
									<asp:label id="lblTitulo" runat="server" CssClass="TituloSecundario"> CONVENIO SIMA - MGP</asp:label></TD>
							</TR>
							<TR>
								<TD bgColor="#f5f5f5"></TD>
								<TD align="right" bgColor="#f5f5f5">
									<asp:imagebutton style="Z-INDEX: 0" id="ibtnPrograma" runat="server" ImageUrl="../imagenes/ibtnDocumentos.jpg"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f5f5f5" colSpan="2">
									<cc1:datagridweb id="dgConvenio" runat="server" CssClass="HeaderGrilla" Width="100%" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False"
										PageSize="7" ShowFooter="True" align="center">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="2%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdProyectoConvenio"></asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoAsignado" SortExpression="MontoAsignado" HeaderText="ASIGNADO (S/.)" 
 DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MONTOAPROBADO" SortExpression="MONTOAPROBADO" HeaderText="APROBADO (S/.)" 
 DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MONTOPAGADO" SortExpression="MONTOPAGADO" HeaderText="PAGADO (S/.)" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEjecutado" SortExpression="MontoEjecutado" HeaderText="EJECUTADO (S/.)" 
 DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoEnEjecucion" SortExpression="MontoEnEjecucion" HeaderText="EN EJECUCION (S/.)" 
 DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="AVANCEECONOMICO" SortExpression="AVANCEECONOMICO" HeaderText="AVANCE ECONOMICO (S/.)" 
 DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoSaldo" SortExpression="MontoSaldo" HeaderText="SALDO (S/.)" DataFormatString="{0:# ### ### ##0.00}">
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
								<TD>
									<asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
							</TR>
							<TR>
								<TD width="50%">
									<asp:textbox id="txtDescripcion" runat="server" CssClass="TextoAzul" Width="100%" TextMode="MultiLine"
										ReadOnly="True" Height="60px"></asp:textbox></TD>
								<TD>
									<asp:textbox id="txtObservaciones" runat="server" CssClass="TextoAzul" Width="100%" TextMode="MultiLine"
										ReadOnly="True" Height="60px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="50%" colSpan="2"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT id="hCodigo" style="WIDTH: 15px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hIndice" style="WIDTH: 15px; HEIGHT: 15px" type="hidden" size="1" name="hCodigo"
										runat="server"></TD>
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
