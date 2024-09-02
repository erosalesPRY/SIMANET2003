<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarCartaFianzaporBancoDetalle.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianzaporBancoDetalle" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
	</HEAD>
	<body oncontextmenu="return true" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td bgColor="#eff7fa" vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Detalle de Carta Fianza por Banco</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%">
						<DIV align="center">
							<TABLE id="TblTabs" class="tabla" border="0" cellSpacing="0" cellPadding="0" width="100%"
								bgColor="#f5f5f5" align="center" runat="server">
								<TR>
									<TD style="WIDTH: 37px; HEIGHT: 16px"><asp:label id="Label2" runat="server" CssClass="TituloPrincipal">FIANZA   :</asp:label></TD>
									<TD vAlign="baseline"><asp:label id="lblSituacion" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
									<TD style="WIDTH: 60px" vAlign="baseline"><asp:label id="Label1" runat="server" CssClass="TituloPrincipal">BANCO   :</asp:label></TD>
									<TD vAlign="baseline"><asp:label id="lblEntidad" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center">
						<TABLE id="Table1" class="normal" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD colSpan="3" align="center">
									<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR bgColor="#f0f0f0">
											<TD><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../imagenes/filtrar.gif"></asp:imagebutton><IMG style="Z-INDEX: 0" id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg" runat="server">
												<asp:imagebutton style="Z-INDEX: 0" id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
													ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
											<TD style="WIDTH: 1px"></TD>
											<TD></TD>
											<TD align="left"></TD>
											<TD></TD>
											<TD></TD>
											<TD width="4" align="right"><IMG src="../../imagenes/tab_der.gif" width="4" height="22"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" DESIGNTIMEDRAGDROP="59" PageSize="7" Width="100%" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True" ShowFooter="True">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle HorizontalAlign="Center" Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreCentro" SortExpression="NombreCentro" HeaderText="CO">
												<HeaderStyle HorizontalAlign="Center" Width="3%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD FINANCIERA">
												<HeaderStyle Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Beneficiario" SortExpression="Beneficiario" HeaderText="BENEFICIARIO">
												<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="nrocartafianza" SortExpression="nrocartafianza" HeaderText="N.F">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="FECHAS">
												<HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Bottom"></ItemStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-RIGHT: #cccccc 1px solid; DISPLAY: none" align="center" width="10%"
																rowSpan="2">
																<asp:Label id="Label4" runat="server" ToolTip="Numero de la Última Renovación" Width="28px"
																	Font-Bold="True">NRO<BR>U.R</asp:Label></TD>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" width="80%" colSpan="3">
																<asp:Label id="lblFechas" runat="server" CssClass="HeaderGrilla" Height="3px" BorderStyle="None"
																	Font-Bold="True">FECHA</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="51" height="3">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" ToolTip="Fecha de Apertura" DESIGNTIMEDRAGDROP="175"
																	Width="51px" BorderStyle="None" Font-Bold="True">INICIO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="51" height="3">
																<asp:Label id="Label3" runat="server" CssClass="HeaderGrilla" ToolTip="Fecha de Renovación"
																	Width="50px" BorderStyle="None" Font-Bold="True">RENOVA.</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="51" height="3">
																<asp:Label id="Label5" tabIndex="3" runat="server" CssClass="HeaderGrilla" ToolTip="Fecha de vencimiento"
																	Width="50px" BorderStyle="None" Font-Bold="True">VENCE</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table3" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD style="DISPLAY: none" vAlign="bottom" align="center" width="14%">
																<asp:Label id="lblNroRenov" runat="server" CssClass="ItemGrillaSinColor" DESIGNTIMEDRAGDROP="228"
																	Width="31px" Height="18px">0</asp:Label></TD>
															<TD vAlign="middle" align="center" width="51">
																<asp:Label id="lblFechaIni" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" align="center" width="51">
																<asp:Label id="lblFechaRenov" runat="server" CssClass="normaldetalle" DESIGNTIMEDRAGDROP="386"
																	Width="58px" Height="12px">Label</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" vAlign="middle" align="center" width="51">
																<asp:Label id="lblFechaVence" runat="server" CssClass="normaldetalle" Width="58px" Height="12px">Label</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:BoundColumn DataField="NroDiasFaltantes" SortExpression="NroDiasFaltantes" HeaderText="DIAS">
												<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="MontoFza" SortExpression="MontoFza" HeaderText="MONTO">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="EstadoCartaFianza" SortExpression="EstadoCartaFianza" HeaderText="ESTADO">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="observacion" SortExpression="observacion" HeaderText="DESCRIPCION">
												<HeaderStyle Width="30%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="INTERES" SortExpression="INTERES" HeaderText="COSTO COMISION">
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="tasint" SortExpression="tasint" HeaderText="  TASA COM. INICIAL"></asp:BoundColumn>
											<asp:BoundColumn DataField="tasvig" SortExpression="tasvig" HeaderText="TASA COM. VIGENTE"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD colSpan="3" align="left">
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD vAlign="top" align="center"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" CssClass="TextoNegroNegrita">RESUMEN POR  MONEDA :</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center"><cc1:datagridweb style="Z-INDEX: 0" id="gridResumenMoneda" runat="server" PageSize="7" Width="168px"
													RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
															<HeaderStyle HorizontalAlign="Center" Width="5%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="MontoFza" SortExpression="MontoFza" HeaderText="MONTO">
															<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 591px" vAlign="top" align="left"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" CssClass="TituloPrincipal" Visible="False">DESCRIPCIÓN</asp:label><asp:textbox style="Z-INDEX: 0" id="txtDescripcionFZA" runat="server" CssClass="normaldetalle"
													Width="764px" Visible="False" Height="50px" TextMode="MultiLine" BorderStyle="Groove"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD width="764" colSpan="3" align="left"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPagina" value="0" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="WIDTH: 32px; HEIGHT: 22px" id="hGridPaginaSort" size="1" type="hidden" name="hGridPagina"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hPeriodo" size="1" type="hidden"
										name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 32px; HEIGHT: 22px" id="hIdCartaFianza" size="1" type="hidden"
										name="hGridPagina" runat="server"></TD>
							</TR>
							<TR>
								<TD width="764" colSpan="3" align="left">
									<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
										<TR>
											<TD vAlign="top" align="left">
												<div style="Z-INDEX: 0; WIDTH: 100%; HEIGHT: 450px; OVERFLOW: auto"><asp:datagrid style="Z-INDEX: 0" id="gridBitacora" runat="server" Width="100%" AutoGenerateColumns="False">
														<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
														<ItemStyle CssClass="ItemGrilla"></ItemStyle>
														<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
														<Columns>
															<asp:TemplateColumn HeaderText="FECHA">
																<HeaderStyle Width="80px"></HeaderStyle>
																<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
																<ItemTemplate>
																	<asp:TextBox onblur="GrabarBitacora(this);" id="txtFecha" runat="server" Width="80px" rel="calendar"
																		CssClass="normaldetalle" BorderWidth="1px" BorderStyle="Dashed"></asp:TextBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn HeaderText="DESCRIPCION">
																<HeaderStyle Width="80%"></HeaderStyle>
																<ItemTemplate>
																	<asp:TextBox onblur="GrabarBitacora(this);" id="txtDescripcion" runat="server" CssClass="normaldetalle"
																		Width="100%" Height="100px" TextMode="MultiLine" BorderStyle="Dashed" BorderWidth="1px"></asp:TextBox>
																</ItemTemplate>
															</asp:TemplateColumn>
															<asp:TemplateColumn>
																<HeaderStyle Width="5%"></HeaderStyle>
																<ItemTemplate>
																	<IMG id="imgEliminaBitacora" onclick="EliminarBitacora(this);" src="../../imagenes/Filtro/Eliminar.gif"
																		runat="server">
																</ItemTemplate>
															</asp:TemplateColumn>
														</Columns>
													</asp:datagrid></div>
											</TD>
										</TR>
									</TABLE>
									<IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../../imagenes/atras.gif">
								</TD>
							</TR>
						</TABLE>
						<asp:button id="btnMostrarBitacora" runat="server" Visible="False" Text="Button"></asp:button></TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<script>
				function CargaBitacora(Periodo,IdCartaFianza){
					jNet.get("hPeriodo").value=Periodo;
					jNet.get("hIdCartaFianza").value=IdCartaFianza;
					var oDataTable = (new Controladora.OperacionesFinancieras.CCartaFianzaBitacora()).ListarBitacora(Periodo,IdCartaFianza);
					for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
						var oDataRow = oDataTable.Rows.Items[f];
						window.alert(oDataRow.Item("Fecha"));
					}										
				}
		
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
					Ext.each(textBoxes, function(item, id, all){   
						var cl = new Ext.form.DateField({   
							format: 'd/m/Y',
							allowBlank : false,   
							applyTo: item   
						});
					}); 
					  
			function GrabarBitacora(e){
				var orow;
				if(e.id.toString().indexOf("txtFecha")!=-1){
					orow =jNet.get(e.parentNode.parentNode.parentNode);
					if(e.value==orow.attr("FECHA")){return false;}
					orow.attr("FECHA",e.value);
				}
				else{
					orow =jNet.get(e.parentNode.parentNode);
					if(e.value==orow.attr("DESCRIPCION")){return false;}
					orow.attr("DESCRIPCION",e.value);
				}
				orow = jNet.get(orow);
				var otxtFecha =  orow.cells[0].childNodes[0].childNodes[0];
				if(otxtFecha.value.length==0){
					Ext.MessageBox.alert('MENSAJE', 'para que se registre los datos se debera de ingresar el dato fecha', function(btn){});
					return;
				}
				
				var oCartaFianzaBitacoraBE = new EntidadesNegocio.OperacionesFinancieras.CartaFianzaBitacoraBE();
				oCartaFianzaBitacoraBE.IdBitacora=orow.attr("IDBITACORA")
				oCartaFianzaBitacoraBE.IdCartaFianza=jNet.get("hIdCartaFianza").value;
				oCartaFianzaBitacoraBE.Periodo=jNet.get("hPeriodo").value;
				oCartaFianzaBitacoraBE.Fecha=orow.attr("FECHA");
				oCartaFianzaBitacoraBE.Descripcion=orow.attr("DESCRIPCION");
				oCartaFianzaBitacoraBE.IdEstado=1

				var oCartaFianzaBitacoraTAD= new AccesoDatos.Transacional.OperacionesFinancieras.CartaFianzaBitacoraTAD();
				orow.attr("IDBITACORA",oCartaFianzaBitacoraTAD.InsertarModificar(oCartaFianzaBitacoraBE));
				
				//orow.attr("IDBITACORA",(new Controladora.OperacionesFinancieras.CCartaFianzaBitacora()).InsertarModificar(oProyectoPerfilBitacoraBE));
				orow.cells[2].childNodes[0].style.display="block";
				
			}

			function EliminarBitacora(e){
				var orow = e.parentNode.parentNode;
				var oDataGrid = orow.parentNode;
				orow = jNet.get(orow);
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						var oProyectoPerfilBitacoraBE = new EntidadesNegocio.Estrategica.ProyectoPerfilBitacoraBE();
						oProyectoPerfilBitacoraBE.IdBitacora = orow.attr("IDBITACORA")
						oProyectoPerfilBitacoraBE.IdProyectoPerfil = orow.attr("IDPROYECTOPERFIL");
						oProyectoPerfilBitacoraBE.Fecha = orow.attr("FECHA");
						oProyectoPerfilBitacoraBE.Descripcion = orow.attr("DESCRIPCION");
						oProyectoPerfilBitacoraBE.IdEstado = 0;
						
						(new Controladora.Estrategica.CProyectoPerfilBitacora()).Insertar(oProyectoPerfilBitacoraBE);
						oDataGrid.removeChild(orow);
					}
				});				
			}
		</script>
	</body>
</HTML>
