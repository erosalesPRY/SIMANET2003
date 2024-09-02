<%@ Page language="c#" Codebehind="ConsultarCartaFianzaDetalleRenovacionyGasto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.ConsultarCartaFianzaDetalleRenovacionyGasto" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script src="/SimaNetWeb/js/Menu/MenuSP.js" type="text/javascript"></script>
		<script>
				var TotalCargo=0;
				var _idDet=0;
				var ImporteDolar=0;
				var ImporteSoles=0;
				
				function txtBuscarFZA_ItemDataBound(sender,e,dr){
					TotalCargo=0;
					_idDet=0;
					ImporteDolar=0;
					ImporteSoles=0;
					
					LimpiarTexto();
					$O('txtCentroOperativo').value = dr["NombreCentroOperativo"].toString();
					$O('txtBanco').value = dr["EntidadFinanciera"].toString();
					$O('txtBeneficiario').value = dr["ClienteProveedor"].toString();
					$O('txtTipo').value = dr["Tipo"].toString();
					$O('txtProyecto').value = dr["ConceptoProyecto"].toString();
					$O('txtConcepto').value = dr["Concepto"].toString();
					$O('txtNroCartaFianza').value = dr["nrocartafianza"].toString();
					$O('txtNroCartaFianza').title = dr["idCartaFianza"].toString();
					$O('hidCFza').value = dr["idCartaFianza"].toString();
					$O('hPeriodo').value = dr["Periodo"].toString();
					$O('hidCentroOperativo').value = dr["idCentroOperativo"].toString();
					
					var oDataTable = new System.Data.DataTable("tblGrupoCC");
					oDataTable=(new Controladora.OperacionesFinancieras.CCartaFianza()).ConsultarRenovacionCartaFianza(dr["idCartaFianza"].toString(),dr["Periodo"].toString());
					LlenarGrillaRenovacion(oDataTable);
				}

				function LimpiarTexto(){
					$O('txtCentroOperativo').value = "";
					$O('txtBanco').value = "";
					$O('txtBeneficiario').value = "";
					$O('txtTipo').value = "";
					$O('txtProyecto').value ="";
					$O('txtConcepto').value ="";
					$O('txtNroCartaFianza').value ="";
				}
				
				function LlenarGrillaRenovacion(oDataTable){
					try{
						oDataGrid = new DataGrid($O('gridRenovaciones'));
						oDataGrid.DataSource = oDataTable;
						oDataGrid.EventHandleItemDataBound =gridRenovaciones_ItemDataBound;
						oDataGrid.DataBind();
						
						var oDataGrid = $O('gridRenovaciones');
						oDataGrid.rows[1].onclick();
						var oRow = oDataGrid.insertRow();
						var _Col = document.createElement("TD");
						_Col.colSpan=6;
						_Col.innerText="TOTAL GASTO:";
						_Col.align="center";
						oRow.appendChild(_Col);
						_Col = document.createElement("TD");
						_Col.innerText = new SIMA.Numero(parseFloat(TotalCargo)).toString(2,true,' ');
						_Col.align="right";
						_Col.noWrap = true;
						oRow.appendChild(_Col);
						oRow.className="FooterGrilla";						
						
					}
					catch(error){
						window.alert("No existen Renovaciones de Fianzas");
					}
				}
				
				function gridRenovaciones_ItemDataBound(sender,e){
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
							e.Item.cells(0).innerText=e.Item.rowIndex;
							e.Item.cells(1).align = "right";
							e.Item.cells(1).innerText=dr.Item("FechaApertura");
							e.Item.cells(2).innerText=dr.Item("FechaVencimiento");
							e.Item.cells(2).align = "right";
							e.Item.cells(3).innerText=dr.Item("EstadoFza");
							e.Item.cells(4).innerText=dr.Item("Moneda");
							e.Item.cells(5).innerText=new SIMA.Numero(parseFloat(dr.Item("MontoCartaFza"))).toString(2,true,' ');
							e.Item.cells(5).align = "right";
							e.Item.cells(6).innerText=new SIMA.Numero(parseFloat(dr.Item("MontoCargo"))).toString(2,true,' ');
							e.Item.cells(6).align = "right";
							e.Item.setAttribute("IDDET",dr.Item("idDetCF"));
							e.Item.setAttribute("IDCARTAFZA",dr.Item("idCartaFza"));
							e.Item.setAttribute("PERIODO",dr.Item("Periodo"));
							e.Item.setAttribute("IDCENTRO",dr.Item("idCentroOperativo"));
							e.Item.setAttribute("MONEDADESC",dr.Item("MonedaDesc"));
							e.Item.setAttribute("CONCEPTO",dr.Item("Concepto"));
							e.Item.setAttribute("OBSERVACION",dr.Item("Observacion"));
							
							SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,LlenarGrillaCargos);
							TotalCargo = parseFloat(TotalCargo) + parseFloat(dr.Item("MontoCargo"));
					}
				}
				
				
				function LlenarGrillaCargos(e){
					_idDet = e.IDDET;
					$O('txtConcepto').value = e.CONCEPTO + e.OBSERVACION;
					var oDataTable=(new Controladora.OperacionesFinancieras.CCartaFianza()).ConsultarCartaFianzaNotadeCargo(e.IDCENTRO,e.IDDET,e.IDCARTAFZA,e.PERIODO);
					try{
						var _DataGrid = $O('gridCargos');
						_DataGrid.rows[0].cells[6].innerText= e.MONEDADESC;
						oDataGrid = new DataGrid(_DataGrid);
						
						oDataGrid.DataSource = oDataTable;
						oDataGrid.EventHandleItemDataBound =gridCargos_ItemDataBound;
						oDataGrid.DataBind();
					}
					catch(error){
						window.alert("No existen Renovaciones de Fianzas");
					}
					if(parseFloat(ImporteDolar)!=0){
						var oDataGrid = $O('gridCargos');
						var oRow = oDataGrid.insertRow();
						var _Col = document.createElement("TD");
						_Col.colSpan=5;
						_Col.innerText="TOTAL:";
						_Col.align="center";
						oRow.appendChild(_Col);
						_Col = document.createElement("TD");
						_Col.innerText = new SIMA.Numero(parseFloat(ImporteDolar)).toString(2,true,' ');
						_Col.align="right";
						_Col.noWrap = true;
						oRow.appendChild(_Col);
						_Col = document.createElement("TD");
						_Col.innerText = new SIMA.Numero(parseFloat(ImporteSoles)).toString(2,true,' ');
						_Col.align="right";
						_Col.noWrap = true;
						oRow.appendChild(_Col);
						oRow.className="FooterGrilla";
						ImporteDolar=0;
						ImporteSoles=0;
					}
				}
				function gridCargos_ItemDataBound(sender,e){
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
						if(dr.Item("Periodo")!=0){
							e.Item.cells(0).innerText=e.Item.rowIndex;
							e.Item.cells(1).align = "right";
							e.Item.cells(1).innerText=dr.Item("Fecha");
							e.Item.cells(1).noWrap = true;
							e.Item.cells(2).innerText=dr.Item("Motivo");
							e.Item.cells(2).align = "left";
							e.Item.cells(2).noWrap = true;
							e.Item.cells(3).innerText=dr.Item("Moneda");

							e.Item.cells(4).innerText=new SIMA.Numero(parseFloat(dr.Item("TipoCambio"))).toString(2,true,' ');
							e.Item.cells(4).align = "right";
							e.Item.cells(4).noWrap = true;	
							//Dolares
							e.Item.cells(5).innerText=new SIMA.Numero(parseFloat(dr.Item("MontoCambio"))).toString(2,true,' ');
							e.Item.cells(5).align = "right";
							e.Item.cells(5).noWrap = true;	
							//Soles
							e.Item.cells(6).innerText=new SIMA.Numero(parseFloat(dr.Item("MontoNota"))).toString(2,true,' ');
							e.Item.cells(6).align = "right";
							e.Item.cells(6).noWrap = true;	

							if(dr.Item("idDetCF") == _idDet){
								//e.Item.style.background="#CCCC00";
							}
							ImporteDolar = parseFloat(ImporteDolar)+ parseFloat(dr.Item("MontoCambio"));
							ImporteSoles = parseFloat(ImporteSoles)+ parseFloat(dr.Item("MontoNota"));
							
							SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
						}
					}
				}
				//oncontextmenu="return false" 
		</script>
	</HEAD>
	<body onkeypress="if (event.keyCode==13)return false" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr id="Cabecera">
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Carta Fianza</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" style="WIDTH: 768px; HEIGHT: 160px" cellSpacing="0" cellPadding="0"
							width="768" align="center" border="0">
							<TR>
								<TD noWrap align="right" width="100%" colSpan="4">
									<INPUT style="WIDTH: 27px; HEIGHT: 22px" id="hidCFza" size="1" type="hidden" runat="server">
									<INPUT style="WIDTH: 27px; HEIGHT: 22px" id="hPeriodo" size="1" type="hidden" runat="server">
									<asp:ImageButton id="ImgImprimir" runat="server" ImageUrl="../../imagenes/bt_imprimir.gif"></asp:ImageButton>
								</TD>
							</TR>
							<TR>
								<TD noWrap width="100%" colSpan="4"><asp:textbox id="txtBuscarFZA" runat="server" TextMode="MultiLine" Width="100%" Height="32px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 167px; HEIGHT: 10px" bgColor="#000080" colSpan="4"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="160px" Height="8px">DETALLE CARTA FIANZA:</asp:label></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap><asp:label id="Label1" runat="server" Width="120px">NRO CARTA FIANZA:</asp:label></TD>
								<TD width="100%"><asp:textbox id="txtNroCartaFianza" runat="server" CssClass="normaldetalle" Width="128px" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
								<TD colSpan="2"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap><asp:label id="Label2" runat="server" Width="120px">CENTRO OPERATIVO:</asp:label></TD>
								<TD width="100%"><asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" Width="408px" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
								<TD class="HeaderDetalle"><asp:label id="Label11" runat="server">TIPO:</asp:label></TD>
								<TD><asp:textbox id="txtTipo" runat="server" CssClass="normaldetalle" BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap><asp:label id="Label4" runat="server">BANCO:</asp:label></TD>
								<TD width="100%" colSpan="3"><asp:textbox id="txtBanco" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px"><asp:label id="Label9" runat="server">BENEFICIARIO:</asp:label></TD>
								<TD width="100%" colSpan="3"><asp:textbox id="txtBeneficiario" runat="server" CssClass="normaldetalle" Width="100%" BorderStyle="None"
										BackColor="Transparent"></asp:textbox></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap><asp:label id="Label10" runat="server">PROYECTO:</asp:label></TD>
								<TD width="100%" colSpan="3"><asp:textbox id="txtProyecto" runat="server" CssClass="normaldetalle" TextMode="MultiLine" Width="100%"
										Height="40px" BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px; HEIGHT: 3px" noWrap><asp:label id="Label13" runat="server">CONCEPTO:</asp:label></TD>
								<TD style="HEIGHT: 3px" width="100%" colSpan="3"><asp:textbox id="txtConcepto" runat="server" CssClass="normaldetalle" TextMode="MultiLine" Width="100%"
										Height="56px" BorderStyle="None" BackColor="Transparent"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 160px" vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="HEIGHT: 140px" cellSpacing="0" cellPadding="0" width="768" border="0">
							<TR>
								<TD style="WIDTH: 326px" bgColor="#000080"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" Width="232px" Height="8px">1era FIANZA Y RENOVACIONES:</asp:label></TD>
								<TD bgColor="#000080"><asp:label id="Label5" runat="server" CssClass="TituloPrincipalBlanco" Width="152px" Height="8px">NOTAS DE CARGO:</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 326px" vAlign="top" align="left" height="100%"><cc1:datagridweb id="gridRenovaciones" runat="server" Width="386px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										PageSize="9">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Wrap="False" Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FECHA APE">
												<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FECHA VENC">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="SIT.">
												<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MONEDA">
												<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="IMPORTE">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CARGO">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
								<TD vAlign="top" align="left" height="100%"><cc1:datagridweb id="gridCargos" runat="server" Width="380px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										PageSize="9">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FECHA">
												<HeaderStyle HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MOTIVO">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="M">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="T.C">
												<HeaderStyle Width="5%"></HeaderStyle>
												<ItemStyle Wrap="False"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CAMBIO">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="SOLES">
												<HeaderStyle Width="5%"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 326px" vAlign="top" align="left" height="100%"><INPUT id="hidCentroOperativo" type="hidden" runat="server">
								</TD>
								<TD vAlign="top" align="right" height="100%"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				var KEYIDTIPOLETRA = "TipoLetra";
						var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
							var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="nrocartafianza";
							oParamBusqueda.Texto="Nro de Carta Fianza";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.Ancho=100;
							oParamBusqueda.CampoAlterno = "ConceptoProyecto";
							
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ConceptoProyecto";
							oParamBusqueda.Texto="Nombre del Proyecto";
							oParamBusqueda.LongitudEjecucion=5;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.Ancho=300;
							oParamBusqueda.CampoAlterno="nrocartafianza";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ClienteProveedor";
							oParamBusqueda.Texto="Razon Social";
							oParamBusqueda.LongitudEjecucion=3;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.Ancho=300;
							oParamBusqueda.CampoAlterno="nrocartafianza";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarFianzaDetallePorNro;
							oParamBusqueda.ParaBusqueda=false;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
						
						
						(new AutoBusqueda('txtBuscarFZA')).CrearPopupOpcion('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
		
						//Muestra la Cartfa Fianza que fue consultada y vista en previo del reporte
						if($O('txtBuscarFZA').value.length>0){
							var oDataTable = new System.Data.DataTable("tblGrupoCC");
							oDataTable=(new Controladora.OperacionesFinancieras.CCartaFianza()).ConsultarRenovacionCartaFianza($O('hidCFza').value,$O('hPeriodo').value);
							LlenarGrillaRenovacion(oDataTable);
						}				
		</SCRIPT>
	</body>
</HTML>
