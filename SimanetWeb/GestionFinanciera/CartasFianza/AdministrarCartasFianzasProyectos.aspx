<%@ Page language="c#" Codebehind="AdministrarCartasFianzasProyectos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.AdministrarCartasFianzasProyectos" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="../../js/date.js" type="text/javascript"></script>
		<script src="../../js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script src="../../js/Menu/MenuSP.js" type="text/javascript"></script>
		<script>
		function txtBuscarFZA_ItemDataBound(sender,e,dr)
		{
			LimpiarTexto();
			$O('txtMoneda').value = dr["Moneda"].toString();
			$O('txtMonto').value = new SIMA.Numero(parseFloat(dr["MontoProyecto"])).toString(2,true,' ');			

			var d1 = Date.parse(dr["FechaInicioProyecto"].toString()); 
			$O('txtFecha').value = d1.toString('dd-MM-yyyy');
			$O('hCodigo').value = dr["IdProyectoContrato"].toString();

			LlenarFianzas();			
		}
				
		function LimpiarTexto()
		{
			//$O('txtProyecto').value = "";
			$O('txtMoneda').value = "";
			$O('txtMonto').value = "";
			$O('txtFecha').value = "";
		}			
						
		function LlenarFianzas()
		{
			if ($O('hCodigo').value.length>0)
			{
				try{
					var oDataTable = new System.Data.DataTable("tbl");
					oDataTable=(new Controladora.OperacionesFinancieras.CCartaFianza()).ConsultarFianzasPorProyecto($O('hCodigo').value);
				
					oDataGrid = new DataGrid($O('gridFianzas'));
					oDataGrid.DataSource = oDataTable;
					oDataGrid.EventHandleItemDataBound =gridFianzas_ItemDataBound;
					oDataGrid.DataBind();
				}
				catch(error){
					window.alert("No existen Fianzas para Proyecto");
				}
			}
		}
		
		function gridFianzas_ItemDataBound(sender,e){
			var dr = e.Item.DataItem;
			if(dr.Item("EOF")==false){
				e.Item.cells(0).innerText=e.Item.rowIndex;
				e.Item.cells(1).innerText=dr.Item("nrocartafianza");
				e.Item.cells(1).align = "left";

				e.Item.cells(2).innerText=dr.Item("Banco");
				e.Item.cells(2).align = "left";

				e.Item.cells(3).innerText=new SIMA.Numero(parseFloat(dr.Item("ImporteOriginal"))).toString(2,true,' ');
				e.Item.cells(3).align = "right";
				
				e.Item.cells(4).innerText=dr.Item("moneda");
				e.Item.cells(4).align = "center";

				e.Item.cells(5).innerText=new SIMA.Numero(parseFloat(dr.Item("Saldo"))).toString(2,true,' ');				
				e.Item.cells(5).align = "right";

				//var d2 = Date.parse(dr.Item("FechaApertura")); 
				//window.alert(dr.Item("FechaApertura"));
				//e.Item.cells(6).innerText = d2.toString('dd-MM-yyyy');
				e.Item.cells(6).innerText = dr.Item("FechaApertura");
				e.Item.cells(6).align = "center";
				/*e.Item.cells(6).innerText=dr.Item("FechaApertura");
				e.Item.cells(6).align = "center";*/

				//var d3 = Date.parse(dr.Item("FechaVencimiento")); 
				//e.Item.cells(7).innerText = d3.toString('dd-MM-yyyy');
				e.Item.cells(7).innerText = dr.Item("FechaVencimiento");				
				e.Item.cells(7).align = "center";

				/*e.Item.cells(7).innerText=dr.Item("FechaVencimiento");
				e.Item.cells(7).align = "center";*/

				e.Item.cells(8).innerText=dr.Item("Estado");
				e.Item.cells(8).align = "center";
		
				e.Item.Id = dr.Item("idFianza");
				
				SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,ColocarIdFianza);
			}		
		}

		function ColocarIdFianza(Celda)
		{
			document.forms[0].hIdFianza.value = Celda.Id;
		}		
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();LlenarFianzas();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu2" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 12px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión Financiera>Operaciones financieras></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Asignación de Fianzas a Proyecto</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="left">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="760" align="center" border="0">
										<TR>
											<TD noWrap colSpan="4">
												<asp:textbox id="txtBuscarFZA" runat="server" Width="100%" TextMode="MultiLine" Height="48px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 167px" bgColor="#000080" colSpan="4"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="160px" Height="8px">DETALLE:</asp:label></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD class="HeaderDetalle" noWrap style="WIDTH: 126px"><asp:label id="Label4" runat="server">MONEDA:</asp:label></TD>
											<TD width="100%" colSpan="3"><asp:textbox id="txtMoneda" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
													BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR class="AlternateItemDetalle">
											<TD class="HeaderDetalle" style="WIDTH: 126px"><asp:label id="Label9" runat="server">Monto:</asp:label></TD>
											<TD width="100%" colSpan="3"><asp:textbox id="txtMonto" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
													BorderStyle="None"></asp:textbox></TD>
										</TR>
										<TR class="ItemDetalle">
											<TD class="HeaderDetalle" noWrap style="WIDTH: 126px"><asp:label id="Label10" runat="server">fecha:</asp:label></TD>
											<TD width="100%" colSpan="3"><asp:textbox id="txtFecha" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
													BorderStyle="None"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE class="normal" id="Table4" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD vAlign="top" align="left" colSpan="3">
												<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton><asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton></TD>
													</TR>
												</TABLE>
												<asp:label id="lblFianzas" runat="server" CssClass="subtituloNegrita">Fianzas Emitidas</asp:label></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3"><cc1:datagridweb id="gridFianzas" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0"
													PageSize="7">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<FooterStyle Font-Size="X-Small" Font-Bold="True" CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="1%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="CARTA FIANZA">
															<HeaderStyle Width="9%" VerticalAlign="Middle"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="BANCO">
															<HeaderStyle Width="20%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="IMPORTE">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="MONEDA">
															<HeaderStyle Width="1%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="SALDO">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Right"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="FECHA APERT.">
															<HeaderStyle Width="9%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="FECHA VENC.">
															<HeaderStyle Width="9%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn HeaderText="ESTADO">
															<HeaderStyle Width="8%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="center" colSpan="3"></TD>
										</TR>
									</TABLE>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
													name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
													runat="server"></TD>
										</TR>
									</TABLE>
									<INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hCodigo"
										runat="server"> <INPUT id="hIdProyectoFianza" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hIdProyectoFianza"
										runat="server"> <INPUT id="hIdFianza" style="WIDTH: 24px; HEIGHT: 6px" type="hidden" size="1" name="hIdFianza"
										runat="server">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
				var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="NroContrato";
					oParamBusqueda.Texto="Nro de Contrato";
					oParamBusqueda.CampoAlterno = "ConceptoProyecto";
					oParamBusqueda.LongitudEjecucion=4;
					oParamBusqueda.Tipo="C";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="ConceptoProyecto";
					oParamBusqueda.Texto="Nombre del proyecto";
					oParamBusqueda.CampoAlterno = "MontoProyecto";
					oParamBusqueda.LongitudEjecucion=5;
					oParamBusqueda.Tipo="C";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarProyectoPorConcepto;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
				(new AutoBusqueda('txtBuscarFZA')).CrearPopupOpcion('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
				
		</SCRIPT>
	</body>
</HTML>
