<%@ Page language="c#" Codebehind="AdministrarRelacionFormatoRubroNotaContab.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarRelacionFormatoRubroNotaContab" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Vincular Rubro y Nota Contable</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script language="javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD height="100%" vAlign="top">
						<TABLE style="Z-INDEX: 0; HEIGHT: 133px" id="Table1" border="0" cellSpacing="1" cellPadding="1"
							width="100%" align="left">
							<TR>
								<TD width="100%">
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="616" style="WIDTH: 616px; HEIGHT: 233px">
										<TR>
											<TD align="left">
												<asp:Label id="Label1" runat="server">BUSCAR NOTA CONTABLE</asp:Label></TD>
										</TR>
										<TR>
											<TD align="center">
												<asp:TextBox id="txtBuscarNota" runat="server" Width="100%"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD height="100%" vAlign="top" align="left">
												<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" CssClass="HeaderGrilla"
													Height="1px" RowPositionEnabled="False" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
													AllowSorting="True">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle Height="23px" CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle Height="30px" CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Codigo" HeaderText="CODIGO">
															<HeaderStyle Width="5%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Descripcion" HeaderText="NOTA CONTABLE">
															<HeaderStyle Width="60%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="Formula">
															<HeaderStyle Width="30%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="OP. MAT">
															<ItemTemplate>
																<asp:DropDownList id="DropDownList1" runat="server">
																	<asp:ListItem Value="0"></asp:ListItem>
																	<asp:ListItem Value="1">SUMA</asp:ListItem>
																	<asp:ListItem Value="2">RESTA</asp:ListItem>
																</asp:DropDownList>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:TemplateColumn>
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemTemplate>
																<asp:Image id="ibtnElimnar" runat="server" ImageUrl="/SimanetWeb/imagenes/Filtro/Eliminar.gif"></asp:Image>
															</ItemTemplate>
														</asp:TemplateColumn>
													</Columns>
													<PagerStyle Visible="False" HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
												</cc1:datagridweb>
											</TD>
										</TR>
										<TR>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="right">&nbsp;</TD>
							</TR>
							<TR>
								<TD>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				var KEYQIDFORMATO="IdFormato";
				var KEYQIDREPORTE = "IdReporte";
				var KEYQIDRUBRO="IdRubro";
				
				function txtBuscarNota_ItemDataBound(sender,e,dr){
					InsAct(dr["IdNota"].toString(),1,1);
					LlenarGrilla();
				}
				function InsAct(IdNota,IdOperadorMat,IdEstado){
					var oFormatoReporteNotaContableBE = new EntidadesNegocio.General.FormatoReporteNotaContableBE();
					oFormatoReporteNotaContableBE.IdFormato=Page.Request.Params[KEYQIDFORMATO];
					oFormatoReporteNotaContableBE.IdReporte=Page.Request.Params[KEYQIDREPORTE];
					oFormatoReporteNotaContableBE.IdRubro=Page.Request.Params[KEYQIDRUBRO];
					oFormatoReporteNotaContableBE.IdNota=IdNota;	
					oFormatoReporteNotaContableBE.IdOperadorMat=IdOperadorMat;
					oFormatoReporteNotaContableBE.IdEstado=1;
					
					(new Controladora.General.CFormatoReporteNotaContable()).InsAct(oFormatoReporteNotaContableBE);
				}
				
				var	oParamCollecionBusqueda = new ParamCollecionBusqueda();
				var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="Descripcion";
					oParamBusqueda.Texto="Descripcion";
					oParamBusqueda.LongitudEjecucion=2;
					oParamBusqueda.Tipo="C";
					oParamBusqueda.CampoAlterno='Codigo';
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarNotaContab;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				(new AutoBusqueda('txtBuscarNota')).Crear('/' + ApplicationPath + '/General/Procesar.aspx?',oParamCollecionBusqueda);
				
				
				function grid_ItemDataBound(sender,e){
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
							e.Item.cells(0).innerText=e.Item.rowIndex;
							e.Item.cells(1).align = "left";
							e.Item.cells(1).innerHTML=((dr.Item("IdEstado")=='1')? dr.Item("Codigo"):"<strike>" + dr.Item("Codigo") + "</strike>");
							e.Item.cells(2).align = "left";
							e.Item.cells(2).innerHTML= ((dr.Item("IdEstado")=='1')? dr.Item("Descripcion"):"<strike>" + dr.Item("Descripcion") + "</strike>");
							e.Item.cells(3).align = "left";
							//e.Item.cells(3).innerText=dr.Item("Formula");
														
							var dt =(new Controladora.General.CNotaContableFormula()).ListarFormula(dr.Item("IdNota"));
							for (x=0;x<=dt.Rows.Items.length-1;x++){
								var dr2 =dt.Rows.Items[x];
								if (dr2.Item("EOF")==false){
									e.Item.cells(3).appendChild(CrearTblItm(dr2.Item("IdFormulaNota"), ((dr.Item("IdEstado")=='1')? dr2.Item("Formula"):"<strike>" + dr2.Item("Formula") + "</strike>"),dr2.Item("Formula")));
								}
							}					
							
							jSIMA(e.Item).attr("IDNOTA",dr.Item("IdNota"));

							
							var oddl = CrearCombo();
							oddlOperadorMat = new System.Web.UI.WebControls.DropDownList(oddl);
							oddlOperadorMat.FindByValue(dr.Item("IdOperadorMat"));
							e.Item.cells(4).appendChild(oddl);
							
							
							
							e.Item.cells(5).align = "right";
							var oImg = SIMA.Utilitario.Helper.General.CrearImgEliminar();
							
							jSIMA(oImg).click(function(){
								var lImg = this;
												Ext.MessageBox.confirm('ELIMINAR NOTA', 'Desea Ud. eliminar esta NOTA CONTABLE  ahora?', function(btn){
															if(btn=="yes"){
																var oFormatoReporteNotaContableBE = new EntidadesNegocio.General.FormatoReporteNotaContableBE();
																	oFormatoReporteNotaContableBE.IdFormato=Page.Request.Params[KEYQIDFORMATO];
																	oFormatoReporteNotaContableBE.IdReporte=Page.Request.Params[KEYQIDREPORTE];
																	oFormatoReporteNotaContableBE.IdRubro=Page.Request.Params[KEYQIDRUBRO];
																	oFormatoReporteNotaContableBE.IdNota=jSIMA(lImg.parentNode.parentNode).attr("IDNOTA");
																	oFormatoReporteNotaContableBE.IdEstado=0;
																	oFormatoReporteNotaContableBE.IdOperadorMat=0;
																	(new Controladora.General.CFormatoReporteNotaContable()).InsAct(oFormatoReporteNotaContableBE);
																	LlenarGrilla();
															}
													});
											}
										  );
										  
							if(dr.Item("IdEstado")=='1'){
								jSIMA(e.Item.cells(5)).append(oImg);
							}
							//e.Item.cells(3).innerText=dr.Item("Importe");
							SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,function(){});
					}
				}
				
				function CrearCombo(xrow){
						var ddl = document.createElement("SELECT");
						var Opciones=document.createElement("OPTION");
						Opciones.appendChild(document.createTextNode("Ninguno"));
						Opciones.value=0;
						ddl.appendChild(Opciones);
						
						Opciones=document.createElement("OPTION");
						Opciones.appendChild(document.createTextNode("Suma"));
						Opciones.value=1;
						ddl.appendChild(Opciones);

						Opciones=document.createElement("OPTION");
						Opciones.appendChild(document.createTextNode("Resta"));
						Opciones.value=2;
						ddl.appendChild(Opciones);
						ddl.onchange = function(){
							var xrow  = this.parentNode.parentNode;
							//Actualiza la Base de dats
							InsAct(jSIMA(xrow).attr("IDNOTA"),this.options.value,1);
						}
					return ddl;
				}
				
				
				function CrearTblItm(IdNotaFormula,Codigo,Descripcion){
					var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,1));
						IdObj = "obj" + IdNotaFormula;
						HTMLTable.align="left";
						HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
						HTMLTable.attr("id",IdObj);
						HTMLTable.className="BaseItemInGrid";
						HTMLTable.border=0;
						HTMLTable.rows[0].cells[0].innerHTML=Codigo;
						HTMLTable.rows[0].cells[0].noWrap=true;				
					return HTMLTable;
				}
				
				function LlenarGrilla(){
					try{
						var oDataTable = new System.Data.DataTable("tbl");
						var oDataTable = (new Controladora.General.CFormatoReporteNotaContable()).Listar(Page.Request.Params[KEYQIDFORMATO],Page.Request.Params[KEYQIDREPORTE],Page.Request.Params[KEYQIDRUBRO]);

						oDataGrid = new DataGrid($O('grid'));
						oDataGrid.DataSource = oDataTable;
						oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
						oDataGrid.DataBind();
					}
					catch(error){
					
						window.alert("Error al cargar datos de formula");
					}		
				}
				 LlenarGrilla();
				//
		</SCRIPT>
	</body>
</HTML>
