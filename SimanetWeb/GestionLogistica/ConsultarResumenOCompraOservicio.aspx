<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarResumenOCompraOservicio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionLogistica.ConsultarResumenOCompraOservicio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarResumenOCompraOservicio</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" onkeydown="KeyPagina()"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
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
						<TABLE style="WIDTH: 800px" id="Table2" border="0" cellSpacing="1" cellPadding="1" width="800"
							align="center" height="10">
							<TR>
								<TD>
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD class="headerDetalle"><asp:label id="Label1" runat="server" CssClass="normaldetalle" ForeColor="White">Periodo</asp:label></TD>
											<TD class="headerDetalle">
												<asp:label id="Label2" runat="server" CssClass="normaldetalle" ForeColor="White">Mes</asp:label></TD>
											<TD class="headerDetalle" width="100%">
												<asp:label id="Label3" runat="server" ForeColor="White" CssClass="normaldetalle">Proveedor</asp:label></TD>
										</TR>
										<TR>
											<TD>
												<asp:dropdownlist id="ddlPeriodo" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD>
												<asp:dropdownlist id="ddlMes" runat="server" AutoPostBack="True"></asp:dropdownlist></TD>
											<TD id="d">
												<asp:textbox id="txtBuscar" runat="server" Height="22px" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD id="cellContextPRV"></TD>
										</TR>
										<TR>
											<TD></TD>
											<TD></TD>
											<TD align="right" style="PADDING-TOP: 5px">
												<asp:ImageButton id="ImgImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"></asp:ImageButton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD vAlign="top" width="100%" align="left"><cc1:datagridweb id="grid" runat="server" Width="100%" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" PageSize="15">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="TITULO" SortExpression="TITULO" HeaderText="DOCUMENTO">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="CANCELADO">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="LblSCancelado" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="PENDIENTE">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="LblSPendiente" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="TOTAL SOLES">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblTotalSoles" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="CANCELADO">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="LblDCancelado" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="PENDIENTE">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="LblDPendiente" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="TOTAL DOLARES">
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
												<ItemTemplate>
													<asp:Label id="lblTotalDolares" runat="server">Label</asp:Label>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hNroRUC" size="6" type="hidden" runat="server">
						<asp:button id="btnAceptar" runat="server" Text="Button" Visible="False"></asp:button><INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hLstProveedor" size="6" type="hidden" name="Hidden1"
							runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				function KeyPagina(){
					/*if((event.keyCode==13)&&(jNet.get('txtBuscar').value.length==0)){
						jNet.get('hNroRUC').value="0";
						__doPostBack('btnAceptar', '');
					}*/
				}

				function CrearCtrlDestino(NroProveedor,RazonSocial){
					var HTMLTable = jNet.get((new SIMA.Utilitario.Helper.General.Html()).CrearTabla(1,2));
					IdObj = "obj" + NroProveedor;
					HTMLTable.align="left";
					HTMLTable.style.cssText="MARGIN-BOTTOM: 5px; MARGIN-LEFT: 5px";
					HTMLTable.attr("id",IdObj);
					HTMLTable.attr("NROPROVEEDOR",NroProveedor);
					HTMLTable.attr("RSOCIAL",RazonSocial);
					HTMLTable.className="BaseItemInGrid";
					HTMLTable.border=0;
					HTMLTable.rows[0].cells[0].innerText=RazonSocial;
					HTMLTable.rows[0].cells[0].noWrap=true;
					var oIMG = SIMA.Utilitario.Helper.General.CrearImgEliminar(1);
					oIMG.onclick=function(){
						var oTBLItem = jNet.get(this.parentNode.parentNode.parentNode.parentNode);
							Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este criterio ahora?', function(btn){
											if(btn=="yes"){
												jNet.get('cellContextPRV').removeChild(oTBLItem);
												jNet.get("hNroRUC").value=(new Proveedor()).ObtenerListado(true);
												jNet.get("hLstProveedor").value=(new Proveedor()).ObtenerListado();
												 __doPostBack('btnAceptar', '');
											}
										});
					}
					jNet.get(HTMLTable.rows[0].cells[1]).insert(oIMG);
					jNet.get('cellContextPRV').insert(HTMLTable);
				}
				
				function Proveedor(){
					this.ObtenerListado=function(SoloRuc){
						var Lista="";
						var ocellContextPRV = jNet.get('cellContextPRV');
						for(var i=0;i<=ocellContextPRV.children.length-1;i++){
							var obj = jNet.get(ocellContextPRV.children[i]);
							
							Lista += ((SoloRuc==true)?obj.attr("NROPROVEEDOR"): obj.attr("NROPROVEEDOR") + '*' + obj.attr("RSOCIAL")) + ';';
						}
						if(Lista.length>0){Lista=Lista.substring(0,Lista.length-1);}
						return Lista;
					}
					this.RestaurarListado=function(){
						var Lst = jNet.get("hLstProveedor").value;
						if(Lst.length>0){
							var arrCtrl = Lst.split(';');
							for(var i=0;i<=arrCtrl.length-1;i++){
								var ProveedorBE = arrCtrl[i].split('*');
								CrearCtrlDestino(ProveedorBE[0],ProveedorBE[1]);
							}
						}
					}
				}
				
				function txtBuscar_ItemDataBound(sender,e,dr){
					jNet.get('txtBuscar').value='';
					CrearCtrlDestino(dr["NROPROVEEDOR"],dr["RAZONSOCIAL"]);
					jNet.get("hNroRUC").value=(new Proveedor()).ObtenerListado(true);
					jNet.get("hLstProveedor").value=(new Proveedor()).ObtenerListado();
					 __doPostBack('btnAceptar', '');
				}

						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
						var	oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="RAZONSOCIAL";
							oParamBusqueda.Texto="Razon social";
							oParamBusqueda.LongitudEjecucion=5;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.Ancho=300;
							oParamBusqueda.CampoAlterno="NROPROVEEDOR";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ListarDatosProveedor;
							oParamBusqueda.ParaBusqueda=false;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
						
						
						//(new AutoBusqueda('txtBuscar')).CrearPopupOpcion('/' + ApplicationPath + '/GestionLogistica/Procesar.aspx?',oParamCollecionBusqueda);
						(new AutoBusqueda('txtBuscar')).Crear('/' + ApplicationPath + '/GestionLogistica/Procesar.aspx?',oParamCollecionBusqueda);
		
						//Muestra la Cartfa Fianza que fue consultada y vista en previo del reporte
					
				(new Proveedor()).RestaurarListado();
		
		
		</SCRIPT>
	</body>
</HTML>
