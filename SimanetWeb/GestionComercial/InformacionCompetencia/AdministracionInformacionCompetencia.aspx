<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="AdministracionInformacionCompetencia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionCompetencia.AdministracionInformacionCompetencia" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministracionInformacionCompetencia</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<td colSpan="3"><uc1:header id="Header2" runat="server"></uc1:header></td>
							</TR>
							<TR>
								<TD colSpan="3"><uc1:menu id="Men2" runat="server"></uc1:menu></TD>
							</TR>
							<tr>
								<td class="Commands" style="WIDTH: 577px; HEIGHT: 17px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" Width="176px" CssClass="RutaPagina">Inicio > Gestión Comercial  ></asp:label><asp:label id="lblPagina" runat="server" Width="288px" CssClass="RutaPaginaActual" Height="20px"> Administración de Información Competencia</asp:label></td>
							</tr>
							<TR>
								<TD class="Commands" style="WIDTH: 577px; HEIGHT: 23px" colSpan="3">
									<P><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal">TITULO FORMULARIO</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table1" style="HEIGHT: 121px" cellSpacing="0" cellPadding="0" width="780" border="0">
										<TR>
											<TD>
												<TABLE id="Table3" style="HEIGHT: 88px" cellSpacing="1" cellPadding="1" width="780" bgColor="#f5f5f5"
													border="0">
													<TR>
														<TD style="WIDTH: 171px; HEIGHT: 25px">
															<P><asp:label id="lblDato1" runat="server" Width="175px" CssClass="TextoAzul"> Dirección de Página WEB :</asp:label></P>
														</TD>
														<TD style="HEIGHT: 24px"><asp:textbox id="IdURL" runat="server" Width="584px" CssClass="normal"></asp:textbox></TD>
														<TD style="HEIGHT: 24px">
															<P><cc2:requireddomvalidator id="rfvIdURL" runat="server" DESIGNTIMEDRAGDROP="2050" ControlToValidate="IdURL"
																	ErrorMessage="RequiredDomValidator">*</cc2:requireddomvalidator></P>
														</TD>
													</TR>
													<TR>
														<TD>
															<P><asp:label id="lblDato2" runat="server" CssClass="TextoAzul"> Descripción:</asp:label></P>
														</TD>
														<TD>
															<P><asp:textbox id="txtDescripcion" runat="server" Width="584px" CssClass="normal" Height="40px"
																	TextMode="MultiLine"></asp:textbox></P>
														</TD>
														<TD><cc2:requireddomvalidator id="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="RequiredDomValidator">*</cc2:requireddomvalidator></TD>
													</TR>
													<TR>
														<TD><INPUT id="hCodigo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
																runat="server"></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
									<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
										<TR>
											<td style="WIDTH: 11px" bgColor="#f0f0f0"><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></td>
											<TD style="WIDTH: 496px" bgColor="#f0f0f0"><IMG style="WIDTH: 489px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="489"></TD>
											<TD style="WIDTH: 11px" bgColor="#f0f0f0"></TD>
											<TD style="WIDTH: 85px" bgColor="#f0f0f0"></TD>
											<TD style="WIDTH: 83px" bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD bgColor="#f0f0f0">
												<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif" CausesValidation="False"></asp:imagebutton></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="dgArchivo" runat="server" Width="780px" CssClass="HeaderGrilla" ShowFooter="True"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True"
										AllowPaging="True" DataKeyField="IdArchivo">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle HorizontalAlign="Left" CssClass="FooterGrilla" VerticalAlign="Middle"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO.">
												<HeaderStyle Width="35px"></HeaderStyle>
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="IdArchivo" SortExpression="IdArchivo" HeaderText="IdArchivo"></asp:BoundColumn>
											<asp:TemplateColumn SortExpression="RUTA" HeaderText="RUTA">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
												<ItemTemplate>
													<asp:HyperLink id="hlkIdArchivo" runat="server"></asp:HyperLink>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn SortExpression="DESCRIPCION" HeaderText="DESCRIPCION">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblDescripcion" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<mbrsc:RowSelectorColumn HeaderText="Selecci&#243;n" SelectionMode="Single">
												<HeaderStyle Width="60px"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</mbrsc:RowSelectorColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Left" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb>
									<P><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD class="normal" align="center" width="96" colSpan="3"><P><cc2:domvalidationsummary id="vSum" runat="server" Width="780px" DisplayMode="List" EnableClientScript="False"
											ShowMessageBox="True"></cc2:domvalidationsummary></P>
								</TD>
							</TR>
						</table>
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="780" align="center" border="0">
							<TR>
								<TD noWrap><IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
			</TD></TR><TR>
				<TD></TD>
			</TR>
			</TABLE></TABLE></form>
		<SCRIPT>
						<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
