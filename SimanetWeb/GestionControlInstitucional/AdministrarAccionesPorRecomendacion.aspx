<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarAccionesPorRecomendacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionControlInstitucional.AdministrarAccionesPorRecomendacion" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarAccionesPorRecomendacion</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
			function Eliminar(e){
				var oTBLItem = jNet.get(e.parentNode.parentNode.parentNode.parentNode);
					if(oTBLItem.attr("IDANEXO")!='0'){
						Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
											if(btn=="yes"){
												(new Controladora.OCI.CAnexoAccionRecomendacion()).Eliminar(oTBLItem.attr("IDANEXO"),oTBLItem.attr("PERIODO"));
												jNet.get('cellListAnexos').removeChild(oTBLItem);
											}
										});					
					
					}
			}
			
			
			function AbrirDocumento(e){
				var oTBLItem = jNet.get(e.parentNode.parentNode.parentNode.parentNode);
				var Ext = oTBLItem.attr("EXTENSION");
					if((Ext=='jpg')||(Ext=='gif')||(Ext=='bmp')||(Ext=='png')){
						var URL='/' + ApplicationPath +'/GestionIntegrada/VistaPrevia.aspx?' + SIMA.Utilitario.Constantes.KEYQNOMBREIMGPREVIO +  SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oTBLItem.attr("IDACCION") + '_' + oTBLItem.attr("NOMBRE");
						(new System.Ext.UI.WebControls.Windows()).Dialogo('VISTA PREVIA',URL,this,window.screen.width-100,window.screen.height-100);
					}
					else{
						(new SIMA.Utilitario.Helper.Window()).AbrirExcel(jNet.get('hRutaHTTP').value + oTBLItem.attr("IDACCION") + '_' + oTBLItem.attr("NOMBRE"));
					}
			}
			
			
			function MsgEliminar(){
				if(jNet.get("hCodigo").value.length!=0){
					Ext.MessageBox.confirm('Eliminar Accion', 'Desea ud eliminar este registro ahora?'
											, function(btn){
												if(btn=='yes'){
													__doPostBack('ibtnEliminar','');
												}
											  });
				}
				else{
					Ext.MessageBox.show({title: "SELECCIONAR",msg: "Ud. no ha seleccionado registro a ser eliminado",buttons: Ext.MessageBox.OK,fn: function(){},icon:  Ext.MessageBox.INFO});
				}
			}
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<TABLE style="Z-INDEX: 0" id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%"
							align="left">
							<TR>
								<TD style="HEIGHT: 8px" class="Commands" colSpan="3">
									<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >  Gestión de Control Institucional ></asp:label>
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Acciones de Observación</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD colSpan="3" align="center">
						<TABLE style="Z-INDEX: 0; WIDTH: 942px" border="0">
							<TR>
								<TD>
									<TABLE style="Z-INDEX: 0" id="Table5" border="0" cellSpacing="0" cellPadding="0" width="100%"
										align="left">
										<TR>
											<TD bgColor="#000080" colSpan="3">
												<asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
										</TR>
										<TR>
											<TD bgColor="#000080" colSpan="3"><IMG style="Z-INDEX: 0; WIDTH: 142px; HEIGHT: 8px" src="../imagenes/spacer.gif" width="142"
													height="8"></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<TABLE style="Z-INDEX: 0" id="Table6" border="0" cellSpacing="1" cellPadding="1" width="100%"
													align="left">
													<TR>
														<TD vAlign="top" align="left">
															<asp:label style="Z-INDEX: 0" id="Label1" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
																BackColor="White">OBSERVACION:</asp:label></TD>
														<TD width="100%">
															<asp:label style="Z-INDEX: 0" id="LblObservacion" runat="server" CssClass="Normal" ForeColor="Black">OBSERVACION:</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD bgColor="#000080" colSpan="3"><IMG style="Z-INDEX: 0; WIDTH: 142px" src="../imagenes/spacer.gif" width="142" height="2"></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<TABLE style="Z-INDEX: 0" id="Table7" border="0" cellSpacing="1" cellPadding="1" width="100%"
													align="left">
													<TR>
														<TD vAlign="top" align="left">
															<asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
																BackColor="White">RECOMENDACIÓN:</asp:label></TD>
														<TD width="100%">
															<asp:label style="Z-INDEX: 0" id="LblRecomendacion" runat="server" CssClass="Normal" ForeColor="Black">RECOMENDACION</asp:label></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" bgColor="#f0f0f0"
										align="left">
										<TR>
											<TD width="100%"></TD>
											<TD><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif" style="Z-INDEX: 0"></asp:imagebutton></TD>
											<TD><IMG id="ibtnEliminarJS" alt="" src="../imagenes/bt_eliminar.gif" onclick="MsgEliminar()"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" AllowSorting="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" Width="100%">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO.">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NroDocumento" SortExpression="NroDocumento" HeaderText="DOCUMENTO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ANEXO">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:TemplateColumn>
										</Columns>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 14px" id="hCodigo" size="1" type="hidden"
										name="hCodigo" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
										name="hGridPaginaSort" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 56px; HEIGHT: 22px" id="hRutaHTTP" size="4" type="hidden"
										runat="server"><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif" style="Z-INDEX: 0"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
