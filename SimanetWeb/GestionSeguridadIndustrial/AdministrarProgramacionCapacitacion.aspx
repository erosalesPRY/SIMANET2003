<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministrarProgramacionCapacitacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarProgramacionCapacitacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarPersona_Contratista_Visita</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" scroll="no" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Seguridad Industrial ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración  Programación de Capacitación</asp:label></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 818px; HEIGHT: 75px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
							width="818" align="center">
							<TR>
								<TD align="right">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD></TD>
											<TD></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD width="100%" noWrap align="right"><asp:label id="Label1" runat="server" Font-Bold="True" Font-Size="10pt">Buscar: (Apellidos y Nombres)</asp:label></TD>
											<TD width="100%" align="left"><asp:textbox id="txtApellidos" runat="server" Width="328px"></asp:textbox></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnEliminarProg" onclick="EliminarProgramacion()" alt=""
													src="../imagenes/bt_eliminar.gif" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Width="100%"
										PageSize="20" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
										RowPositionEnabled="False">
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
											<asp:BoundColumn DataField="NroProg" HeaderText="NRO  PROG">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Fecha" HeaderText="FECHA">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="right"><asp:button id="btnBuscar" runat="server" Text="Button"></asp:button><INPUT style="Z-INDEX: 0; WIDTH: 75px; HEIGHT: 23px" id="hIdPersonal" value="0" size="7"
										type="hidden" name="hPeriodo" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 75px; HEIGHT: 23px" id="hPeriodo" value="0" size="7" type="hidden"
										name="hPeriodo" runat="server"><INPUT style="WIDTH: 75px; HEIGHT: 23px" id="hNroProg" value="0" size="7" type="hidden"
										name="hNroDoc" runat="server">
									<asp:button id="btnEliminar" runat="server" Text="Button"></asp:button><INPUT style="Z-INDEX: 0; WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3"
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
			function EliminarProg(){
				if((jNet.get('hPeriodo').value!='0')&&(jNet.get('hNroProg').value!='0')){
					Ext.MessageBox.confirm('ELIMINAR', 'Desea Ud. Hacer efectiva la eliminación de este registro ahora?', function(btn){
									if(btn=="yes"){
										__doPostBack('btnEliminar','');
									}
								});
				}
				else{
					Ext.MessageBox.alert('PERSONAL', 'No se ha seleccionado registro a ser eliminado', function(btn){});
				}
			}
	
			function txtApellidos_ItemDataBound(sender,e,dr){
				jNet.get('hIdPersonal').value=dr["idpersonal"];
				__doPostBack('btnBuscar','');
			}			
			
			var oParamCollecionBusqueda = new ParamCollecionBusqueda();
				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre='Nombres';
				oParamBusqueda.Texto='Apellidos y Nombres';
				oParamBusqueda.LongitudEjecucion=1;
				oParamBusqueda.Tipo='C';
				oParamBusqueda.CampoAlterno = 'NroPersonal';
				oParamBusqueda.LongitudEjecucion=4;
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre='idProceso';
				oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
				oParamBusqueda.Tipo='Q';
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

				(new AutoBusqueda("txtApellidos")).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);		
			
		</script>
	</body>
</HTML>
