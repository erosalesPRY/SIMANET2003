<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="ConsultaDetalleCliente.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Cliente.ConsultaDetalleCliente" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultaDetalleCliente</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center">
						<SPAN class="normal"></SPAN><SPAN class="normal">
							<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TR>
									<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Clientes > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta Detalle de Clientes </asp:label></TD>
								</TR>
								<TR>
									<TD align="center"><SPAN class="normal"></SPAN><SPAN class="normal">
											<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="400" border="1">
												<TR>
													<TD class="TituloPrincipalBlanco" bgColor="#000080" colSpan="4" rowSpan="1">
														<asp:label id="lblTitulo" runat="server"></asp:label></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblNacionalidad" runat="server" CssClass="TextoBlanco">Nacionalidad :</asp:label></TD>
													<TD vAlign="top" bgColor="#f0f0f0">
														<asp:radiobuttonlist id="rblNacionalidad" runat="server" CssClass="normaldetalle" RepeatDirection="Horizontal"
															AutoPostBack="True" BackColor="Transparent" Enabled="False">
															<asp:ListItem Value="1" Selected="True">PERUANO</asp:ListItem>
															<asp:ListItem Value="2">Extranjero</asp:ListItem>
														</asp:radiobuttonlist>
														<asp:textbox id="txtNacionalidad" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															ReadOnly="True" Width="170px" Visible="False"></asp:textbox></TD>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblTipoClienteLegal" runat="server" CssClass="TextoBlanco" Width="120px">Tipo Cliente Legal :</asp:label></TD>
													<TD vAlign="top" bgColor="#f0f0f0">
														<asp:radiobuttonlist id="rblTipoClienteLegal" runat="server" CssClass="normaldetalle" RepeatDirection="Horizontal"
															AutoPostBack="True" BackColor="Transparent" Enabled="False">
															<asp:ListItem Value="0" Selected="True">Juridico</asp:ListItem>
															<asp:ListItem Value="1">Natural</asp:ListItem>
														</asp:radiobuttonlist>
														<asp:textbox id="txtTipoClienteLegal" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															ReadOnly="True" Width="170px" Visible="False"></asp:textbox>
														<cc2:requireddomvalidator id="rfvTipoClienteLegal" runat="server" ControlToValidate="rblTipoClienteLegal">*</cc2:requireddomvalidator></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblNombre" runat="server" CssClass="TextoBlanco" Visible="False">Nombre :</asp:label>
														<asp:label id="lblRazonSocial" runat="server" CssClass="TextoBlanco">Razon Social :</asp:label></TD>
													<TD vAlign="top" bgColor="#dddddd" colSpan="3">
														<asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" Width="330px" Height="36px"
															TextMode="MultiLine" ReadOnly="True"></asp:textbox>
														<cc2:requireddomvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombre">*</cc2:requireddomvalidator></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="Label1" runat="server" CssClass="TextoBlanco">Cliente Comercial:</asp:label></TD>
													<TD vAlign="top" bgColor="#dddddd" colSpan="3">
														<asp:RadioButton id="rbtSI" runat="server" CssClass="normaldetalle" AutoPostBack="True" Text="SI"></asp:RadioButton>
														<asp:RadioButton id="rbtNO" runat="server" CssClass="normaldetalle" AutoPostBack="True" Text="NO"></asp:RadioButton><BR>
														<asp:textbox id="txtClienteComercial" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															Visible="False" Width="170px" ReadOnly="True"></asp:textbox></TD>
												</TR>
												<TR>
													<TD id="CellApellidoPaternolbl" vAlign="top" bgColor="#335eb4" runat="server">
														<asp:label id="lblApellidoPaterno" runat="server" CssClass="TextoBlanco" Visible="False">Apellido Paterno :</asp:label></TD>
													<TD id="cellApellidoPaterno" vAlign="top" bgColor="#f0f0f0" runat="server">
														<asp:textbox id="txtApellidoPaterno" runat="server" CssClass="normaldetalle" Width="170px" Visible="False"
															ReadOnly="True"></asp:textbox>
														<cc2:requireddomvalidator id="rfvApellidoPaterno" runat="server" ControlToValidate="txtApellidoPaterno">*</cc2:requireddomvalidator></TD>
													<TD id="cellApellidoMaternolbl" vAlign="top" bgColor="#335eb4" runat="server">
														<asp:label id="lblApellidoMaterno" runat="server" CssClass="TextoBlanco" Visible="False">Apellido Materno :</asp:label></TD>
													<TD id="cellApellidoMaterno" vAlign="top" bgColor="#f0f0f0" runat="server">
														<asp:textbox id="txtApellidoMaterno" runat="server" CssClass="normaldetalle" Width="170px" Visible="False"
															ReadOnly="True"></asp:textbox>
														<cc2:requireddomvalidator id="rfvApellidoMaterno" runat="server" ControlToValidate="txtApellidoMaterno">*</cc2:requireddomvalidator></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblRuc" runat="server" CssClass="TextoBlanco">Nro RUC:</asp:label></TD>
													<TD vAlign="top" bgColor="#dddddd">
														<ew:numericbox id="txtRUC" runat="server" CssClass="normaldetalle" Width="170px" MaxLength="11"
															ReadOnly="True"></ew:numericbox>
														<cc2:requireddomvalidator id="rfvRuc" runat="server" ControlToValidate="txtRUC">*</cc2:requireddomvalidator></TD>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblClasificacion" runat="server" CssClass="TextoBlanco">Tipo Clasificacion :</asp:label></TD>
													<TD id="CellddlbClasifcacion" vAlign="top" bgColor="#dddddd" runat="server" class="normaldetalle">
														<asp:dropdownlist id="ddlbClasifcacion" runat="server" CssClass="normaldetalle" Width="172px" ForeColor="Black"
															BackColor="Transparent"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblPais" runat="server" CssClass="TextoBlanco">Pais:</asp:label></TD>
													<TD id="CellddlbPais" vAlign="top" bgColor="#f0f0f0" runat="server">
														<asp:textbox id="txtPais" runat="server" CssClass="normaldetalle" BackColor="Transparent" ReadOnly="True"
															Width="170px" Visible="False"></asp:textbox>
														<asp:dropdownlist id="ddlbPais" runat="server" CssClass="normaldetalle" AutoPostBack="True" BackColor="Transparent"
															Width="172px" ForeColor="Black" Enabled="False"></asp:dropdownlist>
														<cc2:requireddomvalidator id="rfvPais" runat="server" ControlToValidate="ddlbPais">*</cc2:requireddomvalidator></TD>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblDepartamento" runat="server" CssClass="TextoBlanco">Departamento :</asp:label></TD>
													<TD id="cellddlbDepartamento" vAlign="top" bgColor="#f0f0f0" runat="server">
														<asp:textbox id="txtDepartamento" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															ReadOnly="True" Width="170px" Visible="False"></asp:textbox>
														<asp:dropdownlist id="ddlbDepartamento" runat="server" CssClass="normaldetalle" AutoPostBack="True"
															BackColor="Transparent" Width="172px" ForeColor="Black" Enabled="False"></asp:dropdownlist>
														<cc2:requireddomvalidator id="rfvDepartamento" runat="server" ControlToValidate="ddlbDepartamento">*</cc2:requireddomvalidator></TD>
												</TR>
												<TR>
													<TD id="cellProvincialbl" vAlign="top" bgColor="#335eb4" runat="server">
														<asp:label id="lblProvincia" runat="server" CssClass="TextoBlanco">Provincia :</asp:label></TD>
													<TD id="CellddlbProvincia" vAlign="top" bgColor="#dddddd" runat="server">
														<asp:dropdownlist id="ddlbProvincia" runat="server" CssClass="normaldetalle" AutoPostBack="True" BackColor="Transparent"
															Width="172px" ForeColor="Black" Enabled="False"></asp:dropdownlist>
														<cc2:requireddomvalidator id="rfvProvincia" runat="server" ControlToValidate="ddlbProvincia">*</cc2:requireddomvalidator>
														<asp:textbox id="txtProvincia" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															ReadOnly="True" Width="170px" Visible="False"></asp:textbox></TD>
													<TD id="cellDistritolbl" vAlign="top" bgColor="#335eb4" runat="server">
														<asp:label id="lblDistrito" runat="server" CssClass="TextoBlanco">Distrito :</asp:label></TD>
													<TD id="cellddlbDistrito" vAlign="top" bgColor="#dddddd" runat="server">
														<asp:dropdownlist id="ddlbDistrito" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															Width="172px" ForeColor="Black" Enabled="False"></asp:dropdownlist>
														<asp:textbox id="txtDistrito" runat="server" CssClass="normaldetalle" BackColor="Transparent"
															ReadOnly="True" Width="170px" Visible="False"></asp:textbox>
														<cc2:requireddomvalidator id="rfvDistrito" runat="server" ControlToValidate="ddlbDistrito">*</cc2:requireddomvalidator></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblDireccion" runat="server" CssClass="TextoBlanco">Direccion:</asp:label></TD>
													<TD vAlign="top" bgColor="#f0f0f0" colSpan="3">
														<asp:textbox id="txtDireccion" runat="server" CssClass="normaldetalle" Width="340px" Height="30px"
															TextMode="MultiLine" ReadOnly="True"></asp:textbox></TD>
												</TR>
												<TR>
													<TD id="cellRepresentantelbl" vAlign="top" bgColor="#335eb4" runat="server">
														<asp:label id="lblRepresentante" runat="server" CssClass="TextoBlanco" Visible="False">Representante :</asp:label></TD>
													<TD id="cellRepresentante" vAlign="top" bgColor="#dddddd" colSpan="3" runat="server">
														<asp:textbox id="txtRepresentante" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="340px"
															Visible="False"></asp:textbox>
														<asp:imagebutton id="ibtnDetalleRepresentante" runat="server" Visible="False" CausesValidation="False"
															ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
												</TR>
												<TR>
													<TD id="cellContactolbl" style="HEIGHT: 38px" vAlign="top" bgColor="#335eb4" runat="server">
														<asp:label id="lblContacto" runat="server" CssClass="TextoBlanco" Visible="False">Contacto:</asp:label></TD>
													<TD id="cellContacto" vAlign="top" bgColor="#f0f0f0" colSpan="3" runat="server">
														<asp:textbox id="txtContacto" runat="server" CssClass="normaldetalle" ReadOnly="True" Width="340px"
															Visible="False"></asp:textbox>
														<asp:imagebutton id="ibtnDetalleContacto" runat="server" Visible="False" CausesValidation="False"
															ImageUrl="../../imagenes/BtPU_Mas.gif"></asp:imagebutton></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblCorreoElectronico" runat="server" CssClass="TextoBlanco">E-mail:</asp:label></TD>
													<TD vAlign="top" bgColor="#dddddd" colSpan="3">
														<asp:textbox id="txtCorreoElectronico" runat="server" CssClass="normaldetalle" Width="340px"></asp:textbox></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblTelefono" runat="server" CssClass="TextoBlanco">Telefono 1:</asp:label></TD>
													<TD vAlign="top" bgColor="#f0f0f0">
														<asp:textbox id="txtTelefono" runat="server" CssClass="normaldetalle" Width="170px" ReadOnly="True"></asp:textbox></TD>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblCelular" runat="server" CssClass="TextoBlanco">Telefono 2:</asp:label></TD>
													<TD style="WIDTH: 647px" bgColor="#f0f0f0">
														<asp:textbox id="txtCelular" runat="server" CssClass="normaldetalle" Width="170px" ReadOnly="True"></asp:textbox></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblNroFax" runat="server" CssClass="TextoBlanco">Nro Fax:</asp:label></TD>
													<TD vAlign="top" bgColor="#dddddd">
														<asp:textbox id="txtNroFax" runat="server" CssClass="normaldetalle" Width="170px" ReadOnly="True"></asp:textbox></TD>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblTipoCliente" runat="server" CssClass="TextoBlanco">Tipo Cliente :</asp:label></TD>
													<TD id="CellddlbTipoCliente" vAlign="top" bgColor="#dddddd" runat="server" class="normaldetalle">
														<asp:dropdownlist id="ddlbTipoCliente" runat="server" CssClass="normaldetalle" Width="172px" ForeColor="Black"
															BackColor="Transparent" Enabled="False"></asp:dropdownlist>
														<cc2:requireddomvalidator id="rfvTipoCliente" runat="server" ControlToValidate="ddlbTipoCliente">*</cc2:requireddomvalidator></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4" style="HEIGHT: 14px">
														<asp:label id="lblTipoActividad" runat="server" CssClass="TextoBlanco">TipoActividad :</asp:label></TD>
													<TD id="CellddlbTipoActividad" vAlign="top" bgColor="#f0f0f0" colSpan="3" runat="server"
														style="HEIGHT: 14px" class="normaldetalle">
														<asp:dropdownlist id="ddlbTipoActividad" runat="server" CssClass="normaldetalle" Width="340px" ForeColor="Black"></asp:dropdownlist></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
													<TD vAlign="top" bgColor="#dddddd" colSpan="3">
														<asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="340px" Height="56px"
															TextMode="MultiLine"></asp:textbox></TD>
												</TR>
												<TR>
													<TD vAlign="top" bgColor="#335eb4">
														<asp:label id="lblPromotor" runat="server" CssClass="TextoBlanco">Promotor:</asp:label></TD>
													<TD vAlign="top" bgColor="#f0f0f0" colSpan="3">
														<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="340px" RowPositionEnabled="False"
															RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" PageSize="2">
															<ItemStyle CssClass="ItemGrilla"></ItemStyle>
															<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
															<FooterStyle CssClass="FooterGrilla"></FooterStyle>
															<Columns>
																<asp:BoundColumn HeaderText="Nro">
																	<HeaderStyle Width="5%"></HeaderStyle>
																	<ItemStyle HorizontalAlign="Center"></ItemStyle>
																</asp:BoundColumn>
																<asp:BoundColumn DataField="razonsocial" HeaderText="Nombre">
																	<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
																</asp:BoundColumn>
															</Columns>
															<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
														</cc1:datagridweb></TD>
												</TR>
												<TR>
													<TD class="normal" id="TdCeldaCancelar" vAlign="top" colSpan="5" runat="server" style="HEIGHT: 20px"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
												</TR>
												<TR>
													<TD class="normal" vAlign="top" align="center" colSpan="5"><INPUT id="hIdCliente" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" value="0"
															name="hIdProyecto" runat="server">
														<asp:ValidationSummary id="vSum" runat="server" Width="100px" EnableClientScript="False" DisplayMode="List"
															ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
												</TR>
											</TABLE>
										</SPAN>
										<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
											runat="server"></TD>
								</TR>
							</TABLE>
						</SPAN><SPAN class="normal">
							<asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></SPAN>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SPAN class="normal"></SPAN>
	</body>
</HTML>
