<%@ Page language="c#" Codebehind="ConsultarSaldoPorCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Control.ConsultarSaldoPorCentrodeCosto" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script src="/SimaNetWeb/js/Menu/MenuSP.js" type="text/javascript"></script>
		<script>
				var TotalCargo=0;
				var _idDet=0;
				var ImporteDolar=0;
				var ImporteSoles=0;
				var KEYQIDCENTROOPERATIVO='idCeo';
				var KEYNROCENTROCOSTO='NroCC';
				var KEYCTATIPO='DigCta';
				var URLPAGDETALLE = SIMA.Utilitario.Helper.General.ObtenerPathApp() +  "/GestionFinanciera/Presupuesto/Control/ConsultarSaldoPorCentrodeCostoDetalleporNaturaleza.aspx?"
				
				function txtBuscar_ItemDataBound(sender,e,dr){
					if(dr["NroCentroCosto"]!=undefined){
						MostrarResultadoSegunCriterio(dr["idCentroOperativo"].toString(),dr["NroCentroCosto"].toString(),"0");
					}
					else{
						MostrarResultadoSegunCriterio(dr["idCentroOperativo"].toString(),"0",dr["NroGrupoCentroCosto"].toString());
					}
				}
				
				function MostrarResultadoSegunCriterio(idCentroOperativo,NroCentroCosto,NroGrupoCentrodeCosto){
					var oDataTable = new System.Data.DataTable("tblGrupoCC");
					oDataTable=(new Controladora.Presupuesto.CControl()).ConsultarControlPorGrupooCentroCosto(idCentroOperativo,NroGrupoCentrodeCosto,NroCentroCosto);
					
					try{
						oDataGrid = new DataGrid($O('grid'));
						oDataGrid.DataSource = oDataTable;
						oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
						oDataGrid.DataBind();
					}
					catch(error){
						window.alert("No existen Renovaciones de Fianzas");
					}
				
				}
				
				function ObtenerToolTips(dr,strNomCol){
					var ImportePPTO = new SIMA.Numero(parseFloat(dr.Item("PPTO_" + strNomCol))).toString(2,true,' ');
					var ImporteReal = new SIMA.Numero(parseFloat(dr.Item("GASTO_" + strNomCol))).toString(2,true,' ');
					var strTitulo = "PRESUPUESTO : " + ImportePPTO + " GASTO : " +  ImporteReal;
					return strTitulo;
				}
				
				function grid_ItemDataBound(sender,e){
					var _ddlCentroOperativo = $O('ddlCentroOperativo');
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
						e.Item.cells(0).innerText=dr.Item("CC");
						e.Item.CentroCosto =dr.Item("CC");
						e.Item.cells(0).align = "center";
						e.Item.cells(0).noWrap = true;
						e.Item.cells(1).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_CL"))).toString(2,true,' ');
						e.Item.cells(1).title=ObtenerToolTips(dr,"CL");
						
						e.Item.cells(1).Cuenta="CL";
						e.Item.cells(1).align = "right";
						e.Item.cells(1).noWrap = true;
						e.Item.cells(1).onclick = DetalleporCuenta;
						e.Item.cells(2).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_UE"))).toString(2,true,' ');
						e.Item.cells(2).title=ObtenerToolTips(dr,"UE");
						e.Item.cells(2).Cuenta="UE";
						e.Item.cells(2).align = "right";
						e.Item.cells(2).noWrap = true;
						e.Item.cells(2).onclick = DetalleporCuenta;
						e.Item.cells(3).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_MI"))).toString(2,true,' ');
						e.Item.cells(3).title=ObtenerToolTips(dr,"MI");
						e.Item.cells(3).Cuenta="MI";
						e.Item.cells(3).align = "right";
						e.Item.cells(3).noWrap = true;
						e.Item.cells(3).onclick = DetalleporCuenta;
						e.Item.cells(4).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_UA"))).toString(2,true,' ');
						e.Item.cells(4).title=ObtenerToolTips(dr,"UA");
						e.Item.cells(4).Cuenta="UA";
						e.Item.cells(4).align = "right";
						e.Item.cells(4).noWrap = true;
						e.Item.cells(4).onclick = DetalleporCuenta;
						e.Item.cells(5).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_CF"))).toString(2,true,' ');
						e.Item.cells(5).title=ObtenerToolTips(dr,"CF");
						e.Item.cells(5).Cuenta="CF";
						e.Item.cells(5).align = "right";
						e.Item.cells(5).noWrap = true;
						e.Item.cells(5).onclick = DetalleporCuenta;
						e.Item.cells(6).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_SRV"))).toString(2,true,' ');
						e.Item.cells(6).title=ObtenerToolTips(dr,"SRV");
						e.Item.cells(6).align = "right";
						e.Item.cells(6).noWrap = true;
						e.Item.cells(6).Cuenta=dr.Item("CuentaContableAsignada") +"5";
						e.Item.cells(6).onclick = DetalleporCuenta;

						//Honorarios profesionales
						e.Item.cells(7).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_HP"))).toString(2,true,' ');
						e.Item.cells(7).title=ObtenerToolTips(dr,"HP");
						e.Item.cells(7).Cuenta="HP";
						e.Item.cells(7).align = "right";
						e.Item.cells(7).noWrap = true;
						e.Item.cells(7).Cuenta="25";
						e.Item.cells(7).onclick = DetalleporCuenta;
						
						e.Item.cells(8).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_MAT"))).toString(2,true,' ');
						e.Item.cells(8).title=ObtenerToolTips(dr,"MAT");
						e.Item.cells(8).Cuenta="MAT";
						e.Item.cells(8).align = "right";
						e.Item.cells(8).noWrap = true;
						e.Item.cells(8).onclick = DetalleporCuenta;
						e.Item.cells(9).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_AF"))).toString(2,true,' ');
						e.Item.cells(9).title=ObtenerToolTips(dr,"AF");
						e.Item.cells(9).Cuenta="AF";
						e.Item.cells(9).align = "right";
						e.Item.cells(9).noWrap = true;
						e.Item.cells(9).onclick = DetalleporCuenta;
						e.Item.cells(10).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_TOTAL"))).toString(2,true,' ');
						e.Item.cells(10).title=ObtenerToolTips(dr,"TOTAL");
						e.Item.cells(10).Cuenta="0";
						e.Item.cells(10).align = "right";
						e.Item.cells(10).noWrap = true;
						e.Item.cells(10).onclick = DetalleporCuenta;
						e.Item.cells(11).innerText=new SIMA.Numero(parseFloat(dr.Item("SLD_IN"))).toString(2,true,' ');
						e.Item.cells(11).title=ObtenerToolTips(dr,"IN");
						e.Item.cells(11).Cuenta="IN";
						e.Item.cells(11).align = "right";
						e.Item.cells(11).noWrap = true;
						e.Item.cells(11).onclick = DetalleporCuenta;
						SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					}
				}
				
				function DetalleporCuenta(){
					var _ddlCentroOperativo = $O('ddlCentroOperativo');
					var Cuenta = this.Cuenta;
					var CentroCosto = this.parentElement.CentroCosto;
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					with(SIMA.Utilitario.Constantes.General.Caracter){
							oPagina.Response.ShowDialogoModal(URLPAGDETALLE 
																+ KEYQIDCENTROOPERATIVO + SignoIgual.toString() + _ddlCentroOperativo.options[_ddlCentroOperativo.selectedIndex].value
																+ signoAmperson.toString()
																+ KEYNROCENTROCOSTO + SignoIgual.toString() + CentroCosto
																+ signoAmperson.toString()
																+ KEYCTATIPO + SignoIgual.toString() + Cuenta
																,window.screen.width,400);
					}
					
				}
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr id="Cabecera">
					<td width="100%" style="HEIGHT: 23px"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%">
						<uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera> Presupuesto> Control></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Partida por Centrode Costo</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 160px" vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="HEIGHT: 140px" cellSpacing="0" cellPadding="0" width="768" border="0">
							<TR>
								<TD width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
										<TR>
											<TD class="Headerdetalle" style="WIDTH: 96px"><asp:label id="Label1" runat="server" Width="120px">centro operativo</asp:label></TD>
											<TD vAlign="top" align="left" rowSpan="2"><asp:textbox id="txtBuscar" runat="server" Width="568px" Height="24px"></asp:textbox><IMG style="Z-INDEX: 0" align="right" src="../../../imagenes/ibtnIconoExcel.jpg" width="30"
													height="25"><IMG style="Z-INDEX: 0" border="0" align="right" src="../../../imagenes/ibtnIconoExcel.jpg"
													width="30" height="25"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 96px"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="Headerdetalle" vAlign="top" align="center" width="100%" height="100%"><asp:label id="Label2" runat="server" Width="184px">SALDOS DE CENTROS DE COSTO</asp:label></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="right" width="100%" height="100%"><cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="9" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO CC">
												<HeaderStyle Wrap="False" Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="COMBUSTIBLE&lt;BR&gt;LUBRICANTE">
												<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="UTILES DE&lt;BR&gt;ESCRITORIO">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MATERIAL DE&lt;BR&gt;IMPRENTA">
												<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="UTLIES DE &lt;BR&gt;ASEO">
												<HeaderStyle Wrap="False" Width="5%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CAFETERIA">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="SERVICIO&lt;BR&gt;PRESTADO POR &lt;BR&gt;TERCERO">
												<HeaderStyle Wrap="False" Width="10%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="HONORARIOS&lt;BR&gt;PROFESIONALES">
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="MATERIA PRIMA&lt;BR&gt; Y MATERIALES">
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="A.F.&lt;BR&gt;MENOR&lt;BR&gt;CUANTIA">
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="TOTAL">
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="A.F.&lt;BR&gt;INVERSION">
												<ItemStyle Wrap="False" HorizontalAlign="Right"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD vAlign="top" align="right" width="100%" height="100%"><INPUT id="hNroCentroCosto" style="WIDTH: 83px; HEIGHT: 22px" type="hidden" size="8" runat="server"><INPUT id="hidCentroOperativo" style="WIDTH: 99px; HEIGHT: 22px" type="hidden" size="11"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"></TD>
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
				var IDCENTROOPERATIVO="idcop";
				function ActualizarParametros(){
						var otxtBuscar = $O('txtBuscar');
						//otxtBuscar.value="";
						otxtBuscar.focus();

						var oParamCollecionBusqueda = new ParamCollecionBusqueda(1);//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
							var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NroCentroCosto";
							oParamBusqueda.Texto="Nro de Centro de Costo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno = "NombreCentroCosto";
							
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NombreCentroCosto";
							oParamBusqueda.Texto="Nombre de Centro de Costo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno="NroCentroCosto";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NroGrupoCentroCosto";
							oParamBusqueda.Texto="Numero de Grupo de Centro de Costo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno="NombreGrupoCentroCosto";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NombreGrupoCentroCosto";
							oParamBusqueda.Texto="Nombre de Grupo de Centro de Costo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno="NroGrupoCentroCosto";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ListarCentrodeCosto;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
							var _ddlCentroOperativo = $O('ddlCentroOperativo');
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre=IDCENTROOPERATIVO;
							oParamBusqueda.Valor=_ddlCentroOperativo.options[_ddlCentroOperativo.selectedIndex].value;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
						(new AutoBusqueda('txtBuscar')).CrearPopupOpcion('/SimaNetWeb/GestionFinanciera/Presupuesto/Procesar.aspx?',oParamCollecionBusqueda);
						
				}
				
				ActualizarParametros();
				var oddlCentroOperativo = $O('ddlCentroOperativo');
				MostrarResultadoSegunCriterio(oddlCentroOperativo.options[oddlCentroOperativo.selectedIndex].value,$O('hNroCentroCosto').value,"0");
		</SCRIPT>
	</body>
</HTML>
