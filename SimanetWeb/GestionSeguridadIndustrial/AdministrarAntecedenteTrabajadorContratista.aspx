<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarAntecedenteTrabajadorContratista.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarAntecedenteTrabajadorContratista" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Administrar Programación</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<script>
			function Eliminar(){
				Ext.MessageBox.confirm('ELIMINAR', 'Desea Ud. Hacer efectiva la eliminación de este registro ahora?', function(btn){
								if(btn=="yes"){
									__doPostBack('ibtnEliminar',jNet.get('hIdAntecedente').value);
								}
							});
			}
		</script>
</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión de Personal ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Antecedentes></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD bgColor="#000080" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"> ANTECEDENTES</asp:label></TD>
							</TR>
							<TR>
								<TD align="left">
									<TABLE id="Table6" border="0" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
										align="left">
										<TR>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../imagenes/filtroPorSeleccion.JPG"></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD width="100%" align="left">
												<TABLE id="Table4" border="0" cellSpacing="0" cellPadding="0" width="300" align="left">
													<TR>
														<TD></TD>
														<TD width="300">
															<asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="AdministrarStockMaterialPorArea.aspx" Visible="False">HyperLink</asp:HyperLink>&nbsp;
															<asp:HyperLink style="Z-INDEX: 0" id="HyperLink2" runat="server" NavigateUrl="AdministrarProgramacionCapacitacion.aspx"
																Visible="False">Personal sima</asp:HyperLink></TD>
														<TD></TD>
													</TR>
												</TABLE>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton>
											</TD>
											<TD></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD>
												<asp:Image style="Z-INDEX: 0" id="btnElimina" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:Image></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="1%"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" AllowSorting="True"
										AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0" RowPositionEnabled="False" PageSize="15"
										ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="25px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDNI" SortExpression="NroDNI" HeaderText="NRO DOC.">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombres" SortExpression="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Hora" SortExpression="Hora" HeaderText="HORA">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreArea" SortExpression="NombreArea" HeaderText="LUGAR DE TRABAJO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreAntecedente" SortExpression="NombreAntecedente" HeaderText="TIPO ANTECEDENTE">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DescripcionEventoCritico" SortExpression="DescripcionEventoCritico" HeaderText="EVENTO CRITICO">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="OBSERVACIONES">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="55"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<INPUT style="Z-INDEX: 0; WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden"
				name="hGridPaginaSort" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3"
				type="hidden" name="hGridPagina" runat="server"> <INPUT style="Z-INDEX: 0; WIDTH: 57px; HEIGHT: 22px" id="hIdAntecedente" size="4" type="hidden"
				name="hIdAntecedente" runat="server">
		</form>
		<SCRIPT>		
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
