<%@ Page language="c#" Codebehind="DetalleProyectodeInversion.aspx.cs" validateRequest = false AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.Proyecto.DetalleProyectodeInversion" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DetalleProyectodeInversion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/mint"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Upload/si.files.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<STYLE title="text/css" type="text/css">.SI-FILES-STYLIZED LABEL.cabinet {
	WIDTH: 110px; DISPLAY: block; BACKGROUND: url(/SimaNetWeb/imagenes/Navegador/BtnOpciones/AnexarArchivo.bmp) no-repeat 0px 0px; HEIGHT: 22px; OVERFLOW: hidden; CURSOR: pointer
}
.SI-FILES-STYLIZED LABEL.cabinet INPUT.file {
	POSITION: relative; FILTER: progid:DXImageTransform.Microsoft.Alpha(opacity=0); WIDTH: auto; HEIGHT: 100%; opacity: 0; -moz-opacity: 0
}
		</STYLE>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="Z-INDEX: 0; HEIGHT: 432px" id="Table2" border="0" cellSpacing="0" cellPadding="0"
							width="798">
							<TR>
								<TD style="PADDING-LEFT: 8px; WIDTH: 535px; HEIGHT: 28px" bgColor="#000080" colSpan="4"><asp:label style="Z-INDEX: 0" id="lblTitulo" runat="server" Width="304px" CssClass="TituloPrincipalBlanco"
										Height="16px">DETALLE PROYECTO DE INVERSION</asp:label></TD>
								<TD style="WIDTH: 140px; HEIGHT: 28px" bgColor="#000080"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="headerDetalle" BorderStyle="None">CODIGO :</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtCodigoPIP" runat="server" Width="100%" CssClass="normaldetalle"
										ReadOnly="True"></asp:textbox></TD>
								<TD></TD>
								<TD></TD>
								<TD align="center"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" CssClass="headerDetalle" BorderStyle="None">NOMBRE:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px" colSpan="3"><asp:textbox style="Z-INDEX: 0" id="txtNombre" runat="server" Width="100%" CssClass="normaldetalle"
										Height="50px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
								<TD style="BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; PADDING-RIGHT: 5px; MARGIN-BOTTOM: 6px; HEIGHT: 373px; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid; PADDING-TOP: 5px"
									rowSpan="7" align="center"><asp:image style="Z-INDEX: 0" id="imgFoto" ondblclick="SIMA.Utilitario.Helper.Estrategica.PopupImgPrevio(this,jNet.get('HNombreImagen').value ,window.screen.width-100,window.screen.height-100);"
										runat="server" Width="290px" Height="310px" BorderStyle="Dashed" ImageUrl="/SIMANETWEB/imagenes/spacer.gif" BorderColor="Gray"
										BackColor="#E0E0E0" BorderWidth="1px" DescriptionUrl="Imagen proyecto" ImageAlign="TextTop"></asp:image></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" CssClass="headerDetalle" BorderStyle="None">CODIGO PC:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtCodigoInterno" runat="server" Width="100%" CssClass="normaldetalle"></asp:textbox></TD>
								<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="headerDetalle" BorderStyle="None">CENTRO OPERACIÓN:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px" id="CellddlCentroOperativo" runat="server"><asp:dropdownlist style="Z-INDEX: 0" id="ddlCentroOperativo" runat="server" Width="100%" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" Width="95px" CssClass="headerDetalle"
										Height="38px" BorderStyle="None">OTS Y VALORIZACIONES:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px" colSpan="3"><asp:datagrid style="Z-INDEX: 0" id="gridOtsVals" runat="server" Width="100%" AutoGenerateColumns="False">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="nro_val_tbj" HeaderText="NRO VAL.">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="cod_ots" HeaderText="NRO OTs.">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="est_tbj" HeaderText="EST">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<ItemTemplate>
													<IMG style="Z-INDEX: 0" id="ImgVerDetVal" onclick="SIMA.Utilitario.Helper.Estrategica.VentanaValorizacionOTs(this,this.parentNode.parentNode.cells[0].innerText);"
														alt="" src="../../imagenes/BtPU_Mas.gif">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" Width="119px" CssClass="headerDetalle"
										BorderStyle="None">COMPONENTES:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px" colSpan="3"><asp:textbox style="Z-INDEX: 0" id="txtComponentes" runat="server" Width="100%" Height="104px"
										TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" CssClass="headerDetalle" BorderStyle="None">CODIGO SNIP:</asp:label></TD>
								<TD><asp:textbox style="Z-INDEX: 0" id="txtCodigoSNIP" runat="server" Width="100%" CssClass="normaldetalle"
										ReadOnly="True"></asp:textbox></TD>
								<TD>
									<TABLE style="Z-INDEX: 0" id="Table7" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR>
											<TD width="50%" align="center"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnVerDatosMEF" onclick="SIMA.Utilitario.Helper.Estrategica.VentanaMINDEF(this,jNet.get('txtCodigoSNIP').value);"
													alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnSNIP.gif"></TD>
											<TD class="headerDetalle" width="50%" noWrap><asp:label style="Z-INDEX: 0" id="Label9" runat="server" Width="100%" CssClass="headerDetalle"
													BorderStyle="None">FECHA INSCRIP.</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD style="PADDING-RIGHT: 5px"><asp:textbox style="Z-INDEX: 0" id="FechaInscripcion" runat="server" Width="100%" CssClass="normaldetalle"
										rel="calendar"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label18" runat="server" CssClass="headerDetalle" BorderStyle="None">FUENTE FINANC.:</asp:label></TD>
								<TD id="CellddlFuenteFinanciamiento" runat="server"><asp:dropdownlist style="Z-INDEX: 0" id="ddlFuenteFinanciamiento" runat="server" Width="100%" CssClass="normaldetalle"></asp:dropdownlist></TD>
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Width="112px" CssClass="headerDetalle"
										BorderStyle="None"> NIVEL ACTUAL:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px" id="CellddlNivelActual" runat="server"><asp:dropdownlist style="Z-INDEX: 0" id="ddlNivelActual" runat="server" Width="100%" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="headerDetalle" BorderStyle="None">ETAPA</asp:label></TD>
								<TD id="CellddlEtapa" runat="server"><asp:dropdownlist style="Z-INDEX: 0" id="ddlEtapa" runat="server" Width="100%" CssClass="normaldetalle"></asp:dropdownlist></TD>
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label21" runat="server" Width="112px" CssClass="headerDetalle"
										BorderStyle="None"> NIVEL APROBADO:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px" id="CellddlNivelAprobacion" runat="server"><asp:dropdownlist style="Z-INDEX: 0" id="ddlNivelAprobacion" runat="server" Width="100%" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label20" runat="server" CssClass="headerDetalle" BorderStyle="None">MONTO INV. TOT:</asp:label></TD>
								<TD><ew:numericbox style="Z-INDEX: 0" id="nMontoInveTotal" runat="server" Width="100%" CssClass="normaldetalle"
										PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="15" TextAlign="Right"
										DecimalPlaces="2" MaxLength="18">0</ew:numericbox></TD>
								<TD style="WIDTH: 114px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label19" runat="server" CssClass="headerDetalle" BorderStyle="None">MONTO EXP. TEC.:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px"><ew:numericbox style="Z-INDEX: 0" id="nMontoExpTecnico" runat="server" Width="100%" CssClass="normaldetalle"
										PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="15" TextAlign="Right" DecimalPlaces="2"
										MaxLength="18">0</ew:numericbox></TD>
								<TD style="BORDER-BOTTOM: dimgray 1px solid; BORDER-LEFT: dimgray 1px solid; BORDER-TOP: dimgray 1px solid; BORDER-RIGHT: dimgray 1px solid"
									align="center"><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUFile" class="file" size="1" type="file" name="FUFile" runat="server"></LABEL></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label17" runat="server" CssClass="headerDetalle" BorderStyle="None">AÑO PPTO:</asp:label></TD>
								<TD id="CellddlPeriodo" runat="server"><asp:dropdownlist style="Z-INDEX: 0" id="ddlPeriodo" runat="server" Width="100%" CssClass="normaldetalle"></asp:dropdownlist></TD>
								<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label12" runat="server" Width="136px" CssClass="headerDetalle"
										BorderStyle="None">MONTO. PPTO. ANUAL:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px"><ew:numericbox style="Z-INDEX: 0" id="nPresupuesto" runat="server" Width="100%" CssClass="normaldetalle"
										PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="15" TextAlign="Right" DecimalPlaces="2"
										MaxLength="18">0</ew:numericbox></TD>
								<TD align="right"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label11" runat="server" CssClass="headerDetalle" BorderStyle="None">AVANCE ECONO.:</asp:label></TD>
								<TD><ew:numericbox style="Z-INDEX: 0" id="nAvanceEconomico" runat="server" Width="100%" CssClass="normaldetalle"
										DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="3" TextAlign="Right" DecimalPlaces="2"
										MaxLength="6">0</ew:numericbox></TD>
								<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label15" runat="server" CssClass="headerDetalle" BorderStyle="None">AVANCE FISICO:</asp:label></TD>
								<TD style="PADDING-RIGHT: 5px"><ew:numericbox style="Z-INDEX: 0" id="nAvanceFisico" runat="server" Width="100%" CssClass="normaldetalle"
										PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="3" TextAlign="Right" DecimalPlaces="2"
										MaxLength="6">0</ew:numericbox></TD>
								<TD align="right"><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="310"
										height="5"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label13" runat="server" CssClass="headerDetalle" BorderStyle="None">DESCRIPCION:</asp:label></TD>
								<TD colSpan="4"><asp:textbox style="Z-INDEX: 0" id="txtDescripcion" runat="server" Width="100%" CssClass="normaldetalle"
										Height="72px" ReadOnly="True" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label14" runat="server" CssClass="headerDetalle" BorderStyle="None">SIT. ACTUAL:</asp:label></TD>
								<TD colSpan="4"><asp:textbox style="Z-INDEX: 0" id="txtSituacion" runat="server" Width="100%" CssClass="normaldetalle"
										Height="64px" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 126px" class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label16" runat="server" CssClass="headerDetalle" BorderStyle="None">GANT</asp:label></TD>
								<TD colSpan="3">
									<TABLE style="Z-INDEX: 0" id="Table4" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR>
											<TD width="100%"><asp:textbox style="Z-INDEX: 0" id="txtDiagrama" runat="server" Width="100%" CssClass="normaldetalle"
													ReadOnly="True"></asp:textbox></TD>
											<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="imgOpenArchivo" onclick="(new SIMA.Utilitario.Helper.Window()).AbrirAchivo(jNet.get('hPathArchivo').value + jNet.get('txtDiagrama').value);"
													alt="" src="../../imagenes/tree/search.gif"></TD>
										</TR>
									</TABLE>
								</TD>
								<TD align="left"><LABEL class="cabinet"><INPUT style="Z-INDEX: 0" id="FUDiagrama" class="file" size="1" type="file" name="FUDiagrama"
											runat="server"></LABEL></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 126px"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="HNombreImagen" size="1" type="hidden"
										name="HNombreImagen" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdObjetivoEspecifico" value="0"
										size="1" type="hidden" name="hIdObjetivoEspecifico" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hPathArchivo" size="1" type="hidden"
										name="HNombreImagen" runat="server"></TD>
								<TD style="WIDTH: 151px"><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="100"
										height="5"></TD>
								<TD><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="100"
										height="5"></TD>
								<TD><IMG style="Z-INDEX: 0; HEIGHT: 5px" alt="" src="/SIMANETWEB/imagenes/spacer.gif" width="100"
										height="5"></TD>
								<TD align="right">
									<TABLE style="Z-INDEX: 0; WIDTH: 182px; HEIGHT: 30px" id="Table3" border="0" cellSpacing="1"
										cellPadding="1" width="182" align="right">
										<TR>
											<TD width="50%"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD width="50%"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SCRIPT>
			(new System.Ext.UI.WebControls.EditorHtml()).FromTextBox('txtComponentes');
			
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
			Ext.each(textBoxes, function(item, id, all){   
				var cl = new Ext.form.DateField({   
					format: 'd/m/Y',
					allowBlank : false,   
					applyTo: item   
				});
			});   
			
			//Tooltips
			(new System.Ext.UI.WebControls.TooTips()).TipTitle('txtCodigoInterno','CODIGO PC','Ingrese aqui el codigo del proyecto generado en UNISYS(Mod. de proyectos)',250);
			
	
			var oFUFile = jNet.get('FUFile');
				oFUFile.addEvent("change",function(){
					jNet.get("imgFoto").src = this.value;
					var arrNOMBREIMG = this.value.toString().split(String.fromCharCode(92));
					jNet.get('HNombreImagen').value = arrNOMBREIMG[arrNOMBREIMG.length-1];
				});

			var oFUDiagrama = jNet.get('FUDiagrama');
				oFUDiagrama.addEvent("change",function(){
					var arrNOMBREIMG = this.value.toString().split(String.fromCharCode(92));
					jNet.get('txtDiagrama').value = arrNOMBREIMG[arrNOMBREIMG.length-1];
							
				});
				
				

		</SCRIPT>
		<SCRIPT language="javascript" type="text/javascript">
			// <![CDATA[
					SI.Files.stylizeAll();
			// ]]>
		</SCRIPT>
		<SCRIPT>
						function txtCodigoInterno_ItemDataBound(sender,e,dr){
							
							var oDataTable = new System.Data.DataTable("tblValOts");
							oDataTable=(new Controladora.Estrategica.CProyectoGeneral()).ListadodeOtsyValorizacionesporProyecto(ListItem.value,dr["COD_PRY"]);
								try{
									var oDataGrid = new DataGrid(jNet.get('gridOtsVals'));
									oDataGrid.DataSource = oDataTable;
									oDataGrid.EventHandleItemDataBound =gridOtsVals_ItemDataBound;
									oDataGrid.DataBind();
									//Remover la Ultima fila
									oDataGrid.RemoverFila(oDataTable.Rows.Items.length);
								}
								catch(error){
									Ext.MessageBox.alert('VALORZACIONES Y OTS', 'No existen registro de valorizaciones', function(btn){});
								}							
						}
						function gridOtsVals_ItemDataBound(sender,e){
							var dr = e.Item.DataItem;
							if(dr.Item("EOF")==false){
								e.Item.cells[0].align = "left";
								e.Item.cells[0].innerText=dr.Item("NRO_VAL_TBJ");
								e.Item.cells[1].align = "left";
								e.Item.cells[1].innerText=dr.Item("COD_OTS");
								e.Item.cells[2].align = "center";
								e.Item.cells[2].innerText=dr.Item("EST_TBJ");
								var oImg =  jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearImagen('../../imagenes/BtPU_Mas.gif'));
								oImg.addEvent("click",function(e){
												e = this||e;
												SIMA.Utilitario.Helper.Estrategica.VentanaValorizacionOTs(e,e.parentNode.parentNode.cells[0].innerText);
											});
								e.Item.cells[3].appendChild(oImg);								
								SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
							}
						}
		
		
						/*function txtBuscarObjetivo_ItemDataBound(sender,e,dr){
							jNet.get('hIdObjetivoEspecifico').value = dr["IdOEspecificos"].toString();
							jNet.get('lblCodigoOEstr').innerText = dr["CodigoOEspecificos"].toString();
						}
						
						var KEYQIDCENTROOPERATIVO="IdCeo";
						//Definicion de 
						function ReconfiguraBusquedaObjetivo(){
							jNet.get('hIdObjetivoEspecifico').value = "";
							jNet.get('lblCodigoOEstr').innerText = "";
							jNet.get('txtBuscarObjetivo').innerText = "";
							ReconfiguracionBaseOE();
						}
						function ReconfiguracionBaseOE(){
							var oddlCentroOperativo= new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo');
							var ListItem = oddlCentroOperativo.ListItem();
						
							var oParamCollecionBusqueda1 = new ParamCollecionBusqueda();
							var oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre="NombreoEspecificos";
								oParamBusqueda.Texto="Nombre";
								oParamBusqueda.LongitudEjecucion=4;
								oParamBusqueda.Tipo="C";
								oParamBusqueda.CampoAlterno = "CodigoOEspecificos";
								oParamBusqueda.LongitudEjecucion=4;
							oParamCollecionBusqueda1.Agregar(oParamBusqueda);

								oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre=KEYQIDCENTROOPERATIVO;
								oParamBusqueda.Valor=ListItem.value;
								oParamBusqueda.Tipo="Q";
							oParamCollecionBusqueda1.Agregar(oParamBusqueda);

								oParamBusqueda = new ParamBusqueda();
								oParamBusqueda.Nombre="idProceso";
								oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarObjetivoEspecifico;
								oParamBusqueda.Tipo="Q";
							oParamCollecionBusqueda1.Agregar(oParamBusqueda);
							(new AutoBusqueda('txtBuscarObjetivo')).Crear('/' + ApplicationPath + '/GestionEstrategica/Proyecto/Procesar.aspx?',oParamCollecionBusqueda1);
						}
						
					ReconfiguracionBaseOE();*/
					
					//busqueda de proyectos en UNISYS
					
					function ConfigurarBusqueda(){
						var oddlCentroOperativo= new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo');
						var ListItem = oddlCentroOperativo.ListItem();

						oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="cod_pry";
							oParamBusqueda.Texto="CodigoPC";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno = "des_pry";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="IdCeo";
							oParamBusqueda.Valor=ListItem.value;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
		
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarProyectosUNISYS;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						(new AutoBusqueda('txtCodigoInterno')).Crear('/' + ApplicationPath + '/GestionEstrategica/Proyecto/Procesar.aspx?',oParamCollecionBusqueda);
					}
					
					ConfigurarBusqueda();
			
		
		</SCRIPT>
	</body>
</HTML>
