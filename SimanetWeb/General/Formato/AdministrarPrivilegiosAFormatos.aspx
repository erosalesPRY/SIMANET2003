<%@ Page language="c#" Codebehind="AdministrarPrivilegiosAFormatos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarPrivilegiosAFormatos" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPrivilegiosAFormatos</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="552" style="MARGIN-TOP: 5px; MARGIN-LEFT: 15px">
				<TR>
					<TD>
						<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="300" align="left">
							<TR>
								<TD class="headerDetalle" noWrap>
									<asp:label style="Z-INDEX: 0" id="Label2" runat="server" Font-Bold="True">Centro Operativo:</asp:label></TD>
								<TD width="100%">
									<asp:DropDownList id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="100%"></asp:DropDownList></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD class="headerDetalle"><asp:label style="Z-INDEX: 0" id="Label1" runat="server" Font-Bold="True">BUSCAR USUARIO:</asp:label></TD>
				</TR>
				<TR>
					<TD><INPUT style="Z-INDEX: 0; WIDTH: 100%; HEIGHT: 22px" id="txtBuscar" size="72" name="txtBuscar"></TD>
				</TR>
				<TR>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD>
						<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" RowPositionEnabled="False" Height="1px" Width="100%" CssClass="HeaderGrilla">
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
								<asp:BoundColumn DataField="Descripcion" HeaderText="TIPO DE INFORMACION">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Left"></FooterStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="2%"></HeaderStyle>
									<HeaderTemplate>
										<asp:Image style="Z-INDEX: 0" id="Image1" runat="server" ImageUrl="/SimanetWeb/imagenes/Navegador/btnDescripcion.gif"></asp:Image>
									</HeaderTemplate>
									<ItemTemplate>
&nbsp; 
<asp:CheckBox id="chkAsignado" runat="server"></asp:CheckBox>
</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn>
									<HeaderStyle Width="2%"></HeaderStyle>
									<HeaderTemplate>
										<asp:Image id="Image1" runat="server" ImageUrl="/SimanetWeb/imagenes/Navegador/CorreoSend2.png"></asp:Image>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkEmail" runat="server" Text=" "></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<PagerStyle Visible="False" HorizontalAlign="Center" CssClass="PagerGrilla"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
					var KEYQIDFORMATO = "IdFormato";
					var KEYQIDUSUARIO="IdUser";
					function txtBuscar_ItemDataBound(sender,e,dr){
						var oddlCentroOperativo = jNet.get('ddlCentroOperativo');
						var	IdFormato=Page.Request.Params[KEYQIDFORMATO];
						var	IdUsuarioPrivilegio= dr["IdUsuario"].toString();
						
						if(IdUsuarioPrivilegio!="0"){
							CargarTipoInformacion(IdFormato,IdUsuarioPrivilegio);
						}
						else{
							alert('No es posible asignar privilegios a esta persona, No cuenta con accesos al aplicativo.')
						}
					}
					
					//Busqueda de personas  para conocimiento
						/*-------------------------------------------------------------------------------------------------------------*/
						var oParamCollecionBusquedaP = new ParamCollecionBusqueda();
						var oParamBusquedaP = new ParamBusqueda();
							oParamBusquedaP.Nombre="ApellidosyNombresEmail";
							oParamBusquedaP.Texto="Apellidos y Nombres";
							oParamBusquedaP.LongitudEjecucion=1;
							oParamBusquedaP.Tipo="C";
							oParamBusquedaP.CampoAlterno = "NroPersonal";
							oParamBusquedaP.LongitudEjecucion=4;
							oParamCollecionBusquedaP.Agregar(oParamBusquedaP);

							oParamBusquedaP= new ParamBusqueda();
							oParamBusquedaP.Nombre="idProceso";
							oParamBusquedaP.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
							oParamBusquedaP.Tipo="Q";
							oParamCollecionBusquedaP.Agregar(oParamBusquedaP);
						(new AutoBusqueda('txtBuscar')).Crear('/' + ApplicationPath + '/Personal/Visitas/Proceso.aspx?',oParamCollecionBusquedaP);
						

					function grid_ItemDataBound(sender,e){
						var dr = e.Item.DataItem;
						if(dr.Item("EOF")==false){
								e.Item.cells(0).innerText=e.Item.rowIndex;
								e.Item.cells(1).align = "right";
								e.Item.cells(1).innerText=dr.Item("Descripcion");
								e.Item.cells(2).align = "left";
								
								var NameCHK = "chk"+e.Item.rowIndex;
								var Chk=((dr.Item("Acceso")=="1")?true:false);
								
								var objchk = jSIMA('<input />', { type: 'checkbox', id: NameCHK, value: '',checked:Chk,IdTipoInfo:dr.Item("Codigo"),IdFormato:dr.Item("IdFormato"),IdUsuPriv:dr.Item("IdUsuarioPrivilegio")});
									objchk.appendTo(e.Item.cells(2));
									
								//Envio de Mensaje
								NameCHK = "chkMsg"+e.Item.rowIndex;
								Chk=((dr.Item("MsgAlert")=="1")?true:false);
								
								objchk = jSIMA('<input />', { type: 'checkbox', id: NameCHK, value: '',checked:Chk,IdTipoInfo:dr.Item("Codigo"),IdFormato:dr.Item("IdFormato"),IdUsuPriv:dr.Item("IdUsuarioPrivilegio")});
								objchk.appendTo(e.Item.cells(3));
										
								SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,function(){});
						}
					}
						
						
					function CargarTipoInformacion(IdFormato,IdUsuario){
						var IdCentroOperativo =new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo');
						var Litem = IdCentroOperativo.ListItem();
						
						if(IdUsuario==undefined){return false;}

						try{
							
							var oDataTable = new System.Data.DataTable("tbl");
								oDataTable=(new Controladora.General.CFormatoPrivilegio()).ListarAccesoSegunPrivilegioUsuario(IdFormato,IdUsuario,Litem.value);

							oDataGrid = new DataGrid($O('grid'));
							oDataGrid.DataSource = oDataTable;
							oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
							oDataGrid.DataBind();
							
							jSIMA("input[type='checkbox']").change(function() {
								var oFormatoPrivilegioBE = new EntidadesNegocio.General.FormatoPrivilegioBE();
								
								if(this.id.toString().length==7){
									oFormatoPrivilegioBE.MsgAlert = ((this.checked==true)?1:0);
									var chkMsg = this.parentNode.parentNode.cells[2].children[0];
									oFormatoPrivilegioBE.Acceso=((chkMsg.checked==true)?1:0);
								}
								else{
									oFormatoPrivilegioBE.Acceso=((this.checked==true)?1:0);
									var chkMsg = this.parentNode.parentNode.cells[3].children[0];
									oFormatoPrivilegioBE.MsgAlert = ((chkMsg.checked==true)?1:0);
								}
								oFormatoPrivilegioBE.IdTipoInformacion=jSIMA(this).attr("IdTipoInfo");
								oFormatoPrivilegioBE.IdUsuario=jSIMA(this).attr("IdUsuPriv");
								oFormatoPrivilegioBE.IdFormato=jSIMA(this).attr("IdFormato");
								oFormatoPrivilegioBE.IdCentroOperativo= Litem.value;
								(new Controladora.General.CFormatoPrivilegio()).InsAct(oFormatoPrivilegioBE);
								
							 });
							
						}
						catch(error){
							window.alert("No existen privilegios otorgados");
						}								
					}
					
					if(Page.Request.Params[KEYQIDUSUARIO]!=undefined){
						CargarTipoInformacion(Page.Request.Params[KEYQIDFORMATO],Page.Request.Params[KEYQIDUSUARIO]);
					}
					
						
		</SCRIPT>
	</body>
</HTML>
