<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleInventarioPC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InventarioPC.DetalleInventarioPC" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>	
			//function OcultarDetalle()
			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD bgColor="lightgrey" height="23"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Inventario Informatico </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle Inventario de PC</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table7" cellSpacing="0" cellPadding="0" width="700" align="center" border="0">
								<TR>
									<TD id="TD1" runat="server">
										<P align="center">
											<TABLE id="Table8" cellSpacing="0" cellPadding="0" width="700" border="0">
												<TR>
													<TD>
														<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
													</TD>
												</TR>
												<TR>
													<TD id="TD3" runat="server">
														<DIV align="center">
															<TABLE id="Table10" cellSpacing="1" cellPadding="1" width="700" align="center" border="0">
																<TR>
																	<TD width="677" bgColor="#000080" colSpan="2"><asp:label id="lblDatosGenerales" runat="server" CssClass="TituloPrincipalBlanco">PC</asp:label></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD id="TD21" width="200" bgColor="#335eb4" runat="server"><asp:label id="Label18" runat="server" CssClass="TextoBlanco" Width="88px">PROCESADOR:</asp:label></TD>
																	<TD class="normaldetalle" id="tdProcesador" width="472" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlProcesador" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"></asp:dropdownlist><asp:imagebutton id="ibtnAgregarProcesador" runat="server" ToolTip="Agregar Nuevo Procesador" ImageUrl="../../imagenes/BtPlus.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator5" runat="server" ErrorMessage="Debe seleccionar un procesador"
																			ControlToValidate="ddlProcesador">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD id="TD22" width="200" bgColor="#335eb4" runat="server"><asp:label id="Label19" runat="server" CssClass="TextoBlanco" Width="88px">RESPONSABLE:</asp:label></TD>
																	<TD id="TD2" width="472" bgColor="#f0f0f0" runat="server">
																		<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="300" align="left" border="0">
																			<TR>
																				<TD><asp:textbox id="txtJefeProyectos" runat="server" CssClass="normaldetalle" Width="310px" Height="17px"
																						MaxLength="200" ReadOnly="True" BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>
																				<TD vAlign="top"><asp:imagebutton id="ibtnVerDetallePersonal" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/btnVerDetalle.jpg"
																						CausesValidation="False" Visible="False"></asp:imagebutton><asp:imagebutton id="ibtnDestinatario" runat="server" CssClass="normaldetalle" ImageUrl="../../imagenes/BtPU_Mas.gif"
																						CausesValidation="False" Visible="False"></asp:imagebutton><asp:checkbox id="chkNoContratado" runat="server" CssClass="ResultadoBusqueda" Text="No Contratado"
																						AutoPostBack="True"></asp:checkbox></TD>
																			</TR>
																		</TABLE>
																	</TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Debe elegir un responsable"
																			ControlToValidate="txtJefeProyectos">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD id="tdAreaEtiqueta" width="200" bgColor="#335eb4" runat="server"><asp:label id="Label20" runat="server" CssClass="TextoBlanco" Width="48px">AREA:</asp:label></TD>
																	<TD id="tdAreaContenido" width="472" bgColor="#dddddd" runat="server"><asp:textbox id="txtArea" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"
																			MaxLength="200" ReadOnly="True" BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD id="tdCOEtiqueta" width="200" bgColor="#335eb4" runat="server"><asp:label id="Label21" runat="server" CssClass="TextoBlanco" Width="48px" ToolTip="CENTRO OPERATIVO">CO:</asp:label></TD>
																	<TD id="tdCOContenido" width="472" bgColor="#f0f0f0" runat="server"><asp:textbox id="txtCO" runat="server" CssClass="normaldetalle" Width="409px" Height="17px" MaxLength="200"
																			ReadOnly="True" BorderStyle="Solid" BorderWidth="1px"></asp:textbox></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD id="TD25" width="200" bgColor="#335eb4" runat="server"><asp:label id="Label22" runat="server" CssClass="TextoBlanco" Width="76px">TIPO DE PC:</asp:label></TD>
																	<TD class="normaldetalle" id="tdTipo" width="472" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlTipo" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"></asp:dropdownlist><asp:imagebutton id="ibtnTipoPC" runat="server" ToolTip="Agregar Nuevo Tipo de PC" ImageUrl="../../imagenes/BtPlus.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator8" runat="server" ErrorMessage="Debe seleccionar tipo de pc"
																			ControlToValidate="ddlTipo">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD id="TD26" width="200" bgColor="#335eb4" runat="server"><asp:label id="Label23" runat="server" CssClass="TextoBlanco" Width="64px">DESCRIPCION:</asp:label></TD>
																	<TD width="472" bgColor="#f0f0f0"><asp:textbox id="txtDescripcion" runat="server" CssClass="normaldetalle" Width="409px" Height="40px"
																			MaxLength="2000" BorderStyle="Solid" BorderWidth="1px" TextMode="MultiLine"></asp:textbox></TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Debe ingresar una descripcion"
																			ControlToValidate="txtDescripcion">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD width="677" bgColor="#000080" colSpan="2"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco">DATOS DE LA PC</asp:label></TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD style="HEIGHT: 17px" width="200" bgColor="#335eb4"><asp:label id="Label7" runat="server" CssClass="TextoBlanco" Width="64px">MEMORIA:</asp:label></TD>
																	<TD class="normaldetalle" id="tdMemoria" style="HEIGHT: 17px" width="472" bgColor="#dddddd"
																		runat="server" cssclass="normaldetalle"><asp:dropdownlist id="ddlMemoria" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"></asp:dropdownlist><asp:imagebutton id="ibtnMemoria" runat="server" ToolTip="Agregar Nueva Memoria" ImageUrl="../../imagenes/BtPlus.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD style="HEIGHT: 17px"><asp:requiredfieldvalidator id="RequiredFieldValidator9" runat="server" ErrorMessage="Debe seleccionar una memoria"
																			ControlToValidate="ddlMemoria" InitialValue="&amp;">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD width="200" bgColor="#335eb4"><asp:label id="Label8" runat="server" CssClass="TextoBlanco" Width="40px">DISCO:</asp:label></TD>
																	<TD class="normaldetalle" id="tdDisco" width="472" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlDisco" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"></asp:dropdownlist><asp:imagebutton id="ibtnDisco" runat="server" ToolTip="Agregar Nuevo Disco" ImageUrl="../../imagenes/BtPlus.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator10" runat="server" ErrorMessage="Debe seleccionar un disco"
																			ControlToValidate="ddlDisco" InitialValue="&amp;">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD width="200" bgColor="#335eb4"><asp:label id="Label9" runat="server" CssClass="TextoBlanco" Width="72px">MARCA CPU:</asp:label></TD>
																	<TD class="normaldetalle" id="tdMarca" width="472" bgColor="#dddddd" runat="server"><asp:dropdownlist id="ddlMarca" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"></asp:dropdownlist><asp:imagebutton id="ibtnMarcaCPU" runat="server" ToolTip="Agregar Nueva Marca CPU" ImageUrl="../../imagenes/BtPlus.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator11" runat="server" ErrorMessage="Debe seleccionar marca cpu"
																			ControlToValidate="ddlMarca" InitialValue="&amp;">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD width="200" bgColor="#335eb4"><asp:label id="Label10" runat="server" CssClass="TextoBlanco" Width="80px">MODELO CPU:</asp:label></TD>
																	<TD class="normaldetalle" id="tdModelo" width="472" bgColor="#f0f0f0" runat="server"><asp:dropdownlist id="ddlModelo" runat="server" CssClass="normaldetalle" Width="409px" Height="17px"></asp:dropdownlist><asp:imagebutton id="ibtnModeloCPU" runat="server" ToolTip="Agregar Nuevo Modelo CPU" ImageUrl="../../imagenes/BtPlus.gif"
																			CausesValidation="False"></asp:imagebutton></TD>
																	<TD><asp:requiredfieldvalidator id="RequiredFieldValidator12" runat="server" ErrorMessage="Debe seleccionar modeo CPU"
																			ControlToValidate="ddlModelo" InitialValue="&amp;">*</asp:requiredfieldvalidator></TD>
																</TR>
																<TR>
																	<TD colSpan="2">
																		<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="672" border="0" runat="server">
																			<TR>
																				<TD width="100" bgColor="#000080" colSpan="2">
																					<asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco">SOFTWARE</asp:label></TD>
																				<TD width="100" bgColor="#000080" colSpan="2">
																					<asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco">HARDWARE</asp:label></TD>
																			</TR>
																			<TR>
																				<TD width="100" bgColor="#335eb4">
																					<asp:label id="Label15" runat="server" CssClass="TextoBlanco" Width="28px">NOMBRE:</asp:label></TD>
																				<TD width="236" bgColor="#f0f0f0">
																					<asp:dropdownlist id="ddlSoftware" runat="server" CssClass="normaldetalle" Width="210px" Height="17px"></asp:dropdownlist>
																					<asp:imagebutton id="ibtnNuevoSoftware" runat="server" ToolTip="Agregar Software" ImageUrl="../../imagenes/BtPlus.gif"
																						CausesValidation="False"></asp:imagebutton></TD>
																				<TD width="100" bgColor="#335eb4">
																					<asp:label id="Label17" runat="server" CssClass="TextoBlanco" Width="33px" DESIGNTIMEDRAGDROP="1536">NOMBRE:</asp:label></TD>
																				<TD width="236" bgColor="#f0f0f0">
																					<asp:dropdownlist id="ddlHardware" runat="server" CssClass="normaldetalle" Width="210px" Height="17px"></asp:dropdownlist>
																					<asp:imagebutton id="ibtnNuevoHardware" runat="server" ToolTip="Agregar Hardware" ImageUrl="../../imagenes/BtPlus.gif"
																						CausesValidation="False"></asp:imagebutton></TD>
																			</TR>
																			<TR>
																				<TD width="100" bgColor="#335eb4">
																					<asp:label id="Label16" runat="server" CssClass="TextoBlanco" Width="80px">LICENCIA:</asp:label></TD>
																				<TD width="236" bgColor="#f0f0f0">
																					<asp:dropdownlist id="ddlLicencia" runat="server" CssClass="normaldetalle" Width="210px" Height="17px"></asp:dropdownlist>
																					<asp:imagebutton id="ibtnLicencia" runat="server" ToolTip="Agregar Nueva Licencia" ImageUrl="../../imagenes/BtPlus.gif"
																						CausesValidation="False"></asp:imagebutton></TD>
																				<TD width="100" bgColor="#335eb4"></TD>
																				<TD width="236" bgColor="#f0f0f0"></TD>
																			</TR>
																			<TR>
																				<TD width="100" bgColor="#335eb4"></TD>
																				<TD width="236" bgColor="#f0f0f0">
																					<asp:imagebutton id="ibtnAgregarSoftware" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"
																						CausesValidation="False"></asp:imagebutton></TD>
																				<TD width="100" bgColor="#335eb4"></TD>
																				<TD width="236" bgColor="#f0f0f0">
																					<asp:imagebutton id="ibtnAgregarHardware" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"
																						CausesValidation="False"></asp:imagebutton></TD>
																			</TR>
																			<TR>
																			</TR>
																		</TABLE>
																	</TD>
																	<TD></TD>
																</TR>
																<TR>
																	<TD width="677" colSpan="2">
																		<TABLE id="Table9" cellSpacing="0" cellPadding="0" width="100%" border="0">
																			<TR>
																				<TD width="344" bgColor="#000080"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco">LISTA DE SOFTWARE</asp:label></TD>
																				<TD bgColor="#000080"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="152">LISTA DE HARDWARE</asp:label></TD>
																			</TR>
																			<TR>
																				<TD vAlign="top" align="left" width="344">
																					<P align="left"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="320px" DESIGNTIMEDRAGDROP="155"
																							PageSize="5" ShowFooter="True" AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
																							RowPositionEnabled="False">
																							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																							<Columns>
																								<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
																									<ItemStyle HorizontalAlign="Center"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="NOMBRESW" SortExpression="NOMBRESW" HeaderText="NOMBRE SOFTWARE">
																									<ItemStyle HorizontalAlign="Center"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="LICENCIA" SortExpression="LICENCIA" HeaderText="LICENCIA">
																									<ItemStyle HorizontalAlign="Center"></ItemStyle>
																								</asp:BoundColumn>
																							</Columns>
																							<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
																						</cc1:datagridweb></P>
																				</TD>
																				<TD vAlign="top" align="left">
																					<P align="right"><cc1:datagridweb id="grid2" runat="server" CssClass="HeaderGrilla" Width="330px" PageSize="5" ShowFooter="True"
																							AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
																							<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
																							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
																							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
																							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
																							<Columns>
																								<asp:BoundColumn HeaderText="NRO" FooterText="Total:">
																									<ItemStyle HorizontalAlign="Center"></ItemStyle>
																								</asp:BoundColumn>
																								<asp:BoundColumn DataField="NOMBREHW" SortExpression="NOMBREHW" HeaderText="NOMBRE HARDWARE">
																									<ItemStyle HorizontalAlign="Center"></ItemStyle>
																								</asp:BoundColumn>
																							</Columns>
																							<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
																						</cc1:datagridweb></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD width="344">
																					<P align="center"><asp:label id="lblResultado1" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
																				</TD>
																				<TD>
																					<P align="center"><asp:label id="lblResultado2" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
																				</TD>
																			</TR>
																			<TR>
																				<TD width="344"><asp:image id="Image1" runat="server" Width="320px" Height="5px" ImageUrl="../../imagenes/spacer.gif"></asp:image></TD>
																				<TD><asp:image id="Image2" runat="server" Width="340px" Height="5px" ImageUrl="../../imagenes/spacer.gif"></asp:image></TD>
																			</TR>
																		</TABLE>
																	</TD>
																	<TD></TD>
																</TR>
															</TABLE>
														</DIV>
													</TD>
												</TR>
											</TABLE>
										</P>
										<DIV align="center"><cc2:domvalidationsummary id="DomValidationSummary1" runat="server" DisplayMode="List" ShowMessageBox="True"></cc2:domvalidationsummary></DIV>
									</TD>
								</TR>
								<TR>
									<TD id="TdCeldaCancelar" runat="server">
										<P align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
												runat="server"></P>
									</TD>
								</TR>
								<TR>
									<TD id="tdAceptar" runat="server">
										<P align="center"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></P>
									</TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
			<INPUT id="hIdArea" type="hidden" size="1" name="hIdArea" runat="server"><INPUT id="hIdJefeProyecto" type="hidden" size="1" value="0" name="hIdJefeProyecto" runat="server"><INPUT id="hIdResponsable" type="hidden" size="1" value="0" name="hIdResponsable" runat="server"><INPUT id="hGridPaginaSort" style="WIDTH: 16px; HEIGHT: 14px" type="hidden" size="1" name="hGridPagina"
				runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 16px" type="hidden" size="1" value="0"
				name="hGridPagina" runat="server">
			<asp:textbox id="txtNada" runat="server" Width="24px" BorderWidth="0px" ForeColor="White">.</asp:textbox>
			<P></P>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
