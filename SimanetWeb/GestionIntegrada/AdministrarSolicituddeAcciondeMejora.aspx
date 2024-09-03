<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarSolicituddeAcciondeMejora.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionIntegrada.AdministrarSolicituddeAcciondeMejora" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarSolicituddeAcciondeMejora</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<script>
			/*function EliminarDestinatario(e,IdDestino){
				var tblItem = e.parentNode.parentNode.parentNode.parentNode;
				var CellContext = tblItem.parentNode;
				//window.alert('Ud no puede eliminar el Destino de la SAM');		
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
									if(btn=="yes"){
										(new Controladora.OGI.CSAMDestino()).Eliminar(IdDestino);
										CellContext.removeChild(tblItem);
									}
								});					
			}*/			
			function grid_onClick(e){
			
			}
			function EnviarCorreoEliminacion(idSam, idDestino){
				jNet.get('hIdSAM').value = idSam;
				jNet.get('hIdDestino').value = idDestino;
				//(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('MiVentana','tblDestino','Ingresar Motivo',380,220,wind_ibtn_Aceptar);
				(new System.Ext.UI.WebControls.Windows()).DialogoDescripcion('Solicitud de Eliminación','Desea Ud. enviar un mensaje de correo al responsable de control para la eliminación del destinatario ahora?',500,ConfirmarEnvio,'hIdSAM');
			}
			
			function ConfirmarEnvio(btn, text){
				if(btn=='ok'){
					var oSAMDestinoBE= new EntidadesNegocio.OGI.SAMDestinoBE();
						oSAMDestinoBE.IdSam = jNet.get('hIdSAM').value;
						oSAMDestinoBE.IdDestino =jNet.get('hIdDestino').value;
						oSAMDestinoBE.MotivoEliminacion = text;
						var dtEnviaCorreo=(new Controladora.OGI.CSAMDestino()).EnviarCorreo(oSAMDestinoBE);					
				}
			}
			
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onunload="SubirHistorial();"
		onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td style="HEIGHT: 23px" bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD style="HEIGHT: 22px" class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Integrada></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Administrar Solicitud de Acción de Mejora</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%">
							<TR bgColor="#f0f0f0">
								<TD>
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="../imagenes/filtrar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnFiltrarSeleccion" title="NroCDI" onclick="FiltroporSeleccion(1);"
													alt="Aplicar Filtro por Selección" src="../imagenes/filtroporseleccion.jpg"></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD></TD>
											<TD width="100%">
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnImprimir" runat="server" ImageUrl="../imagenes/bt_imprimir.gif"
													Visible="False"></asp:imagebutton></TD>
											<TD></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"
													CausesValidation="False"></asp:imagebutton></TD>
											<TD>
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminar" runat="server" ImageUrl="../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="100%" ShowFooter="True" PageSize="20"
										RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle Height="30px" CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CodigoSAM" SortExpression="CodigoSAM" HeaderText="N&#176; de Registro">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA EMIS.">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="DESTINATARIO">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DescripcionHallazgo" SortExpression="DescripcionHallazgo" HeaderText="DECRIPCION&lt;BR&gt;HALLAZGO">
												<HeaderStyle Width="40%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="FuenteReporte" SortExpression="FuenteReporte" HeaderText="FUENTE">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreTipoAccion" SortExpression="NombreTipoAccion" HeaderText="ACCION">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreLugarDetectado" SortExpression="NombreLugarDetectado" HeaderText="DETECTADO EN">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="EST">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgEstado" runat="server"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
						</TABLE>
						<!--Cuadro Creado -->
						<div id="myContent" class="x-hidden">
						</div>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="center">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hidCentro" size="1" type="hidden"
										name="hidCentro" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hCodigo" size="1" type="hidden"
										name="hCodigo" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hIdSAM" size="1" type="hidden"
										name="hIdSAM" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 16px; HEIGHT: 22px" id="hIdDestino" size="1" type="hidden"
										name="hIdDestino" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
