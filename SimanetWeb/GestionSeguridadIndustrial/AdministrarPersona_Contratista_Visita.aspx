<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarPersona_Contratista_Visita.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarPersona_Contratista_Visita" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPersona_Contratista_Visita</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" scroll="no" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands">
						<asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Seguridad Industrial ></asp:label>
						<asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Personal (contratista-visitas)></asp:label></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 818px; HEIGHT: 75px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
							width="818" align="center">
							<TR>
								<TD align="right">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../imagenes/filtroPorSeleccion.JPG"></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD width="100%"></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="btnNroRel" runat="server" ImageUrl="../imagenes/btnCambiarNro.gif"></asp:imagebutton></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnEliminarProg" onclick="EliminarProgramacion()" alt=""
													src="../imagenes/bt_eliminar.gif" runat="server"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="300" align="right">
										<TR>
											<TD align="right"></TD>
											<TD align="right"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
										Width="100%" PageSize="20">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDNI" HeaderText="NRO  DOC">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidoyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Nacionalidad" HeaderText="NACIONALIDAD">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="right"><INPUT style="Z-INDEX: 0; WIDTH: 75px; HEIGHT: 23px" id="hApellidosyNombres" size="7" type="hidden"
										name="Hidden1" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 75px; HEIGHT: 23px" id="hIdReg" size="7" type="hidden"
										name="Hidden1" runat="server"><INPUT style="WIDTH: 75px; HEIGHT: 23px" id="hNroDoc" size="7" type="hidden" runat="server">
									<asp:Button id="btnEliminar" runat="server" Text="Button"></asp:Button><INPUT style="Z-INDEX: 0; WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden"
										name="hGridPaginaSort" runat="server"><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<script>
			function Eliminar(){
				Ext.MessageBox.confirm('ELIMINAR', 'Desea Ud. Hacer efectiva la eliminación de este registro ahora?', function(btn){
								if(btn=="yes"){
									__doPostBack('btnEliminar','');
								}
							});
			}
			
			function  MostrarOcultar(visible){
				jNet.get('btnNroRel').css('display',visible);
			}
		</script>
	</body>
</HTML>
