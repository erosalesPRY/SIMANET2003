<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarDetalleExamenMedico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarDetalleExamenMedico" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación Trabajadores Contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
				var KEYQPERIODO ="Periodo";
				var KEYQIDEXAMEN ="idExa";
				var KEYQNOMTRAB ="NomTrab";
				var KEYQIDESTADO ="IdEst";
				var KEYQIDRESTRICCION ="IdRestr";
		
			function AgregarRestriccion(IdRestriccion,oCHK){
				var IdEstado=((oCHK.checked==true)?1:0);
					
					
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oExamenMedicoRestricionesBE =new EntidadesNegocio.GestionSeguridadIndustrial.ExamenMedicoRestricionesBE();
				
				oExamenMedicoRestricionesBE.Periodo=oPagina.Request.Params[KEYQPERIODO].toString();
				oExamenMedicoRestricionesBE.Idexamen=oPagina.Request.Params[KEYQIDEXAMEN].toString();
				oExamenMedicoRestricionesBE.IdRestriccion=IdRestriccion;
				oExamenMedicoRestricionesBE.IdEstado=IdEstado;
				(new Controladora.SeguridadIndustrial.CCTT_InduccionEvaluacionfunction()).InsertarUpdate(oExamenMedicoRestricionesBE);
				
				
			}
		</script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración info  adicional examen médico></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE style="WIDTH: 1097px" id="Table2" border="0" cellSpacing="0" cellPadding="0" width="1097">
							<TR>
								<TD align="left">
									<TABLE style="Z-INDEX: 0; WIDTH: 100%; HEIGHT: 200px" id="Table5" border="0" cellSpacing="5"
										cellPadding="5" width="812">
										<TR>
											<TD style="HEIGHT: 41px" bgColor="#000080" align="center"><asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"
													Width="160px" Height="8px">DETALLE EXAMEN MEDICO</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left">
												<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%"
													align="left">
													<TR>
														<TD class="HeaderGrilla" noWrap><asp:label id="Label1" runat="server" CssClass="HeaderGrilla" Height="8px">Apellidos y Nombres</asp:label></TD>
														<TD width="100%" colSpan="5"><asp:textbox id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Height="8px">CENTRO MEDICO</asp:label></TD>
														<TD colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtCentroMedico" runat="server" CssClass="normaldetalle"
																Width="100%"></asp:textbox></TD>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Height="8px">TIPO EMO:</asp:label></TD>
														<TD colSpan="5"><asp:textbox id="txtTipoEMO" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" Height="8px">APTITUD:</asp:label></TD>
														<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtNombreAptitud" runat="server" CssClass="normaldetalle"
																Width="100%"></asp:textbox></TD>
														<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label9" runat="server" Height="8px">TOXICOLOGICO:</asp:label></TD>
														<TD width="50%"><asp:textbox style="Z-INDEX: 0" id="txtNombreToxicologico" runat="server" CssClass="normaldetalle"
																Width="100%"></asp:textbox></TD>
														<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" Height="8px">HABILITADO:</asp:label></TD>
														<TD><asp:label style="Z-INDEX: 0" id="LblHabilitado" runat="server" CssClass="normaldetalle" Height="8px"
																Font-Bold="True"></asp:label></TD>
														<TD></TD>
														<TD></TD>
													</TR>
													<TR>
														<TD class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" Height="8px">FECHA INICIO:</asp:label></TD>
														<TD><asp:textbox id="txtFechaInicio" runat="server" CssClass="normaldetalle"></asp:textbox></TD>
														<TD class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label4" runat="server" Height="8px">FECHA VENCIMIENTO:</asp:label></TD>
														<TD><asp:textbox id="txtFechaVencimiento" runat="server" CssClass="normaldetalle"></asp:textbox></TD>
														<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" Height="8px">DISPONIBLE:</asp:label></TD>
														<TD><asp:label style="Z-INDEX: 0" id="LblDisponible" runat="server" CssClass="normaldetalle" Height="8px"
																Font-Bold="True"></asp:label></TD>
														<TD></TD>
														<TD></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="DISPLAY: none" colSpan="4" align="left"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdTrabajador" size="1" type="hidden" name="hIdTrabajador"
													runat="server"><INPUT style="WIDTH: 24px; HEIGHT: 22px" id="hIdCentroMedico" size="1" type="hidden" name="hIdCentroMedico"
													runat="server">
												<TABLE style="Z-INDEX: 0; WIDTH: 424px; HEIGHT: 34px" id="WDetalleCM" border="0">
													<TR>
														<TD class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" CssClass="HeaderGrilla" Height="8px">Nombre Centro Medico:</asp:label></TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtNombreCM" runat="server" Width="100%"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="1%" align="center"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" Height="1px" PageSize="15"
										ShowFooter="True" AllowPaging="True" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="descripcion" SortExpression="descripcion" HeaderText="RESTRICCIONES">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="chkRestriccion" runat="server" Text=" "></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="55"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="DISPLAY: block" align="center"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
