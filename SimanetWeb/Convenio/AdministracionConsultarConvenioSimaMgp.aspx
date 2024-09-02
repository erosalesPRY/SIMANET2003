<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministracionConsultarConvenioSimaMgp.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.Convenio.AdministracionConsultarConvenioSimaMgp" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="HeaderInicio" Src="../ControlesUsuario/HeaderInicio.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Simanet</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<tr>
					<TD vAlign="top"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</tr>
				<TR>
					<TD class="Commands" style="HEIGHT: 1px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Administración ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> CONVENIOS SIMA - MGP</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" vAlign="top" align="center" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="8px" Width="311px"
							ForeColor="Black">Administración Convenios SIMA-MGP</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="780" border="0">
							<TR>
								<TD align="center" bgColor="#f5f5f5">
									<TABLE id="Table8" style="WIDTH: 783px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" border="0">
										<TR>
											<TD align="left" bgColor="#f5f5f5">&nbsp;<asp:label id="lblActividad" runat="server" CssClass="normal">ESTADO:&nbsp;</asp:label><asp:dropdownlist id="ddlbEstado" runat="server" CssClass="normal" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD align="right" bgColor="#f5f5f5"><asp:imagebutton id="ibtnListaProyecto" runat="server" AlternateText="Proyecto" ToolTip="Lista de proyectos"
													ImageUrl="../imagenes/btnActividades.jpg"></asp:imagebutton><asp:imagebutton id="ibtnCronogramaPagos" runat="server" AlternateText="Cronograma de Pagos" ToolTip="Lista de cronograma de pagos"
													ImageUrl="..\imagenes\cronograma_pago.gif"></asp:imagebutton><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="dgConvenio" runat="server" CssClass="HeaderGrilla" Width="780px" align="center"
										ShowFooter="True" PageSize="7" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True"
										RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdConvenioSimaMgp" HeaderText="IdConvenioSimaMgp">
												<HeaderStyle Width="10%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroConvenio" SortExpression="NroConvenio" HeaderText="CONVENIO">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaVencimiento" SortExpression="FechaVencimiento" HeaderText="VENCIMIENTO"
												DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="20%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="SituacionPago" SortExpression="SituacionPago" HeaderText="SITUACION DE PAGO">
												<HeaderStyle Width="40%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left">
									<TABLE id="Table9" style="WIDTH: 783px; HEIGHT: 82px" cellSpacing="1" cellPadding="1" width="783"
										border="0">
										<TR>
											<TD align="left"><asp:label id="lblDescripcion" runat="server" CssClass="normal">DESCRIPCION:</asp:label></TD>
											<TD align="left"><asp:label id="lblObservaciones" runat="server" CssClass="normal">OBSERVACIONES:</asp:label></TD>
										</TR>
										<TR>
											<TD align="left"><asp:textbox id="txtDescripcion" runat="server" CssClass="TextoAzul" Height="60px" Width="100%"
													TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
											<TD align="left"><asp:textbox id="txtObservaciones" runat="server" CssClass="TextoAzul" Height="60px" Width="100%"
													TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
										</TR>
									</TABLE>
									<IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="/SimanetWeb/imagenes/atras.gif"><INPUT id="hIndice" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hCodigo"
										runat="server"><INPUT id="hConv" style="WIDTH: 16px; HEIGHT: 16px" type="hidden" size="1" name="hConv"
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
