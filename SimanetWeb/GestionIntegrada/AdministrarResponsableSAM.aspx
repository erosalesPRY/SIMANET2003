<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarResponsableSAM.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarResponsableSAM" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar responsable SAM</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
			var Permitir=0;
			var IdArea=0;
			function txtPersonal_ItemDataBound(sender,e,dr){
				var strNombreArea =document.getElementById('txtArea').value; 
				if((Permitir==1)&&(strNombreArea.length>0)){
					Ext.MessageBox.confirm('Confirmar', 'Desea ud. agregar a ' +  dr["ApellidosyNombres"] + ' como responsable de ' + strNombreArea  + ' ahora?', function(btn){
										if(btn=="yes"){
											var oSAMResponsableBE = new EntidadesNegocio.OGI.SAMResponsableBE();
												oSAMResponsableBE.IdArea = IdArea;
												oSAMResponsableBE.IdUsuario = dr["IdUsuario"]
												oSAMResponsableBE.IdEstado = 1;
												oSAMResponsableBE.IdTipoResponsable=1;
												
											(new Controladora.OGI.CSAMResponsable()).InsAct(oSAMResponsableBE);
											document.getElementById("txtPersonal").value="";
											ObtenerDatosResposables();
											
										}
									});

					
					
				}
			}
				
			function txtArea_ItemDataBound(sender,e,dr){
				Permitir=1;
				IdArea = dr["IdArea"];
				ObtenerDatosResposables();
			}
			
			function ObtenerDatosResposables(){
				var oDataTable = new System.Data.DataTable();
					oDataTable= (new Controladora.OGI.CSAMResponsable()).ListarTodos(IdArea);
					LoadDataGrid(oDataTable);
			}
				
			function LoadDataGrid(oDataTable){
					try{
						oDataGrid = new DataGrid($O('grid'));
						oDataGrid.DataSource = oDataTable;
						oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
						oDataGrid.DataBind();
					}
					catch(error){
						window.alert("No existen registros de responsables");
					}
			}
			
			function grid_ItemDataBound(sender,e){
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
						estilo = ((dr.Item("IdEstado")=='0')?"line-through":"");
						
						e.Item.cells(0).innerText=e.Item.rowIndex;
						e.Item.cells(0).style.textDecoration = estilo;
						
						e.Item.cells(1).align = "left";
						e.Item.cells(1).innerText=dr.Item("ApellidosyNombres");
						e.Item.cells(1).style.textDecoration = estilo;
						
						e.Item.cells(2).align = "left";
						e.Item.cells(2).innerText=dr.Item("NombreArea");
						e.Item.cells(2).style.textDecoration = estilo;
						e.Item.cells(3).align="center";
						e.Item.cells(3).appendChild(CreaIMGEliminar(dr.Item("IdArea").toString(),dr.Item("IdUsuario").toString()));
						
						SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					}
				}
					
				function CreaIMGEliminar(IdArea,IdUsuario){
					var oImg = document.createElement("IMG");
					oImg.src='/' + ApplicationPath + '/imagenes/Filtro/Eliminar.gif';
					oImg.IdArea=IdArea;
					oImg.IdUsuario=IdUsuario;
					
					oImg.onclick=EliminarResponsable;
					return oImg;
				}											
				
				function EliminarResponsable(){
					var oimg = window.event.srcElement;
					Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar el responsable seleccionado ahora?', function(btn){
										if(btn=="yes"){
											var oSAMResponsableBE = new EntidadesNegocio.OGI.SAMResponsableBE();
												oSAMResponsableBE.IdArea = oimg.IdArea;
												oSAMResponsableBE.IdUsuario = oimg.IdUsuario
												oSAMResponsableBE.IdEstado = 0;
												oSAMResponsableBE.IdTipoResponsable=1;
											(new Controladora.OGI.CSAMResponsable()).InsAct(oSAMResponsableBE);
											document.getElementById("txtPersonal").value="";
											ObtenerDatosResposables();
											
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
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración Responsable SAM></asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" border="0" cellSpacing="5" cellPadding="5" width="780">
							<TR>
								<TD align="center">
								</TD>
							</TR>
							<TR>
								<TD bgColor="#000080" align="center"><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco"> RESPONSABLE POR AREA</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
										<TR>
											<TD class="HeaderDetalle">
												<asp:label style="Z-INDEX: 0" id="Label7" runat="server">Area de responsabilidad:</asp:label></TD>
											<TD width="100%">
												<asp:textbox style="Z-INDEX: 0" id="txtArea" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" colSpan="3">
												<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco">BUSCAR RESPONSABLE A AGREGAR</asp:label></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label id="Label6" runat="server"> APELLIDOS Y NOMBRES:</asp:label></TD>
											<TD width="100%"><asp:textbox id="txtPersonal" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Width="100%"
										RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True"
										Height="1px">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="ApellidosyNombres" SortExpression="ApellidosyNombres" HeaderText="APELLIDOS Y NOMBRES">
												<HeaderStyle Width="50%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreArea" HeaderText="AREA DE TRABAJO">
												<HeaderStyle Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemTemplate>
													<IMG style="Z-INDEX: 0" id="imgEliminar" src="../imagenes/Filtro/Eliminar.gif" runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle Visible="False" HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="55"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hGridPagina" value="0" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hGridPaginaSort" size="1" type="hidden" name="hGridPagina"
										runat="server"><INPUT style="WIDTH: 16px; HEIGHT: 16px" id="hCodigo" size="1" type="hidden" name="hCodigo"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
					
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oParamCollecionBusquedaP = new ParamCollecionBusqueda();
					var oParamBusquedaP = new ParamBusqueda();
						oParamBusquedaP.Nombre='ApellidosyNombres';
						oParamBusquedaP.Texto='Apellidos y Nombres';
						oParamBusquedaP.LongitudEjecucion=1;
						oParamBusquedaP.Tipo='C';
						oParamBusquedaP.CampoAlterno = 'NombreCentroOperativo';
						oParamBusquedaP.LongitudEjecucion=4;
						oParamCollecionBusquedaP.Agregar(oParamBusquedaP);

						oParamBusquedaP = new ParamBusqueda();
						oParamBusquedaP.Nombre='idProceso';
						oParamBusquedaP.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
						oParamBusquedaP.Tipo='Q';
						oParamCollecionBusquedaP.Agregar(oParamBusquedaP);

						(new AutoBusqueda('txtPersonal')).Crear('/' + ApplicationPath + '/GestionIntegrada/Procesar.aspx?',oParamCollecionBusquedaP);
						
					
							
						//Configuracion de Busqueda para Areas
						var	oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre="NombreArea";
								oParamBusqueda.Texto="Nombre Area";
								oParamBusqueda.LongitudEjecucion=2;
								oParamBusqueda.Tipo="C";
								oParamBusqueda.CampoAlterno='NombreCentro';
							oParamCollecionBusqueda.Agregar(oParamBusqueda);

								oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre="idProceso";
								oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarAreaPorCentro;
								oParamBusqueda.Tipo="Q";
							oParamCollecionBusqueda.Agregar(oParamBusqueda);
							(new AutoBusqueda('txtArea')).Crear('/' + ApplicationPath + '/GestionIntegrada/Procesar.aspx?',oParamCollecionBusqueda);

							
							
												
						
		</SCRIPT>
	</body>
</HTML>
