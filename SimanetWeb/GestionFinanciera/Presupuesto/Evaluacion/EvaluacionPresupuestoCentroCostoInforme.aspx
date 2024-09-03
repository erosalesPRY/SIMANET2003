<%@ Page language="c#" Codebehind="EvaluacionPresupuestoCentroCostoInforme.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Evaluacion.EvaluacionPresupuestoCentroCostoInforme" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		 <meta content="text/html; charset=iso-8859-1" http-equiv=Content-Type> 
		<LINK rel="stylesheet" type="text/css" href="../../../styles.css">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script>
				var PROCESO ="idProceso";
				var KEYQPERIODO="PERIODO";
				var KEYQIDMES="IDMES";
				var IDCENTROOPERATIVO="idcop";
				var KEYQIDNROCENTROCOSTOS ="NroCC";
				var KEYQFILTRADO ="Filtrado";

				var URLPAGDETALLE = SIMA.Utilitario.Helper.General.ObtenerPathApp() +  "/GestionFinanciera/Presupuesto/Procesar.aspx?"
				
				function txtBuscar_ItemDataBound(sender,e,dr){
					$O('hidGrupoCentroCosto').value=dr["idGrupoCentroCosto"].toString();
					LlenarGrillaOrdenamientoPaginacion();
				}
				function LlenarGrillaOrdenamientoPaginacion(){
					if($O('hidGrupoCentroCosto').value.toString().length>0){
						var oDataTable = new System.Data.DataTable("tblGrupoCC");
						var TablaTipodeInforacion=45;
						oDataTable= (new Controladora.General.CentroCosto()).ListarAccesoUsuarioCentroCostoSeleccionado($O('hidGrupoCentroCosto').value,$O('hUser').value,TablaTipodeInforacion);
						try{
							oDataGrid = new DataGrid($O('grid'));
							oDataGrid.DataSource = oDataTable;
							oDataGrid.EventHandleItemDataBound =grid_ItemDataBound;
							oDataGrid.DataBind();
						}
						catch(error){
							window.alert("No existen Centros de Costos otorgados");
						}					
					}
				}
				
				function grid_ItemDataBound(sender,e){
					var _ddlCentroOperativo = $O('ddlCentroOperativo');
					var dr = e.Item.DataItem;
					if(dr.Item("EOF")==false){
						e.Item.cells(0).innerText=dr.Item("NroCentroCosto");
						e.Item.cells(0).NroCentroCosto =dr.Item("NroCentroCosto");
						e.Item.cells(0).align = "center";
						e.Item.cells(0).noWrap = true;
						e.Item.cells(0).onclick = LanzarReportedeEvaluacion;
						
						e.Item.cells(0).style.color="#0000ff";
						e.Item.cells(0).style.textDecoration = SIMA.Utilitario.Constantes.Html.Estilo.UnderLine.toString();
						e.Item.cells(0).style.cursor = SIMA.Utilitario.Constantes.Html.Estilo.Cursor.Hand.toString();
						
						e.Item.cells(1).innerText=dr.Item("NombreCentroCosto");
						e.Item.cells(1).noWrap = true;
						e.Item.cells(1).align = "left";
						
						SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					}
				}
				
				function LanzarReportedeEvaluacion(){
					var _ddlCentroOperativo = $O('ddlCentroOperativo');
					var CentroCosto = this.NroCentroCosto;
					var _ddlMes = $O('ddlMes');
					var _ddlPeriodo = $O('ddlPeriodo');
					var _ddlCuenta = $O('ddlCuenta');
					
					$O('hIdCuenta').value = _ddlCuenta.options[_ddlCuenta.selectedIndex].value;
					
					var KEYQIDCTA="CtaDig"
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					HistorialIrAdelantePersonalizado("ddlPeriodo;ddlMes;hUser;txtBuscar;ddlCentroOperativo;hidGrupoCentroCosto;hIdCuenta;txtBuscar");
					
					
					with(SIMA.Utilitario.Constantes.General.Caracter){
							oPagina.Response.Redirect(URLPAGDETALLE 
																+ PROCESO + SignoIgual.toString() + SIMA.Utilitario.Constantes.General.ProcesoCallBack.rptEvaluacionPresupuestalPorCC
																+ signoAmperson.toString()
																+ KEYQPERIODO + SignoIgual.toString() + _ddlPeriodo.options[_ddlPeriodo.selectedIndex].value
																+ signoAmperson.toString()
																+ KEYQIDMES + SignoIgual.toString() + _ddlMes.options[_ddlMes.selectedIndex].value
																+ signoAmperson.toString()
																+ IDCENTROOPERATIVO + SignoIgual.toString() + _ddlCentroOperativo.options[_ddlCentroOperativo.selectedIndex].value
																+ signoAmperson.toString()
																+ KEYQIDNROCENTROCOSTOS + SignoIgual.toString() + CentroCosto
																+ signoAmperson.toString()
																+ KEYQIDCTA + SignoIgual.toString() + $O('hIdCuenta').value
																+ signoAmperson.toString()
																+ KEYQFILTRADO + SignoIgual.toString() + ((jNet.get('chkDistinct').checked==true)?1:0)
													  );
													  //+ KEYQIDCTA + SignoIgual.toString() + _ddlCuenta.options[_ddlCuenta.selectedIndex].value
					}
					
				}
				
				function AgregarOpciones(){
					var _ddlCentroOperativo = $O('ddlCentroOperativo');
					if(_ddlCentroOperativo.options[_ddlCentroOperativo.selectedIndex].value=='1'){
						var oddlCuenta = new System.Web.UI.WebControls.DropDownList('ddlCuenta');
						oddlCuenta.SelectedIndexChanged=ActualizarParametros;
						oddlCuenta.AgregarOpcion('96','96');
						oddlCuenta.DataBind();
						var item = oddlCuenta.FindByValue($O('hIdCuenta').value);
					}
					else{
						var oddlCuenta = new System.Web.UI.WebControls.DropDownList('ddlCuenta');
						oddlCuenta.SelectedIndexChanged=ActualizarParametros;
						oddlCuenta.AgregarOpcion('91','91');
						oddlCuenta.AgregarOpcion('92','92');
						oddlCuenta.AgregarOpcion('97','97');
						oddlCuenta.DataBind();
						
						var item = oddlCuenta.FindByValue($O('hIdCuenta').value);
					}
					ActualizarParametros();
				}
				
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" oncontextmenu="return true"
		onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<tr id="Cabecera">
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera> Presupuesto> Control></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Partida por Centrode Costo</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 160px" vAlign="top" width="100%" align="center">
						<TABLE style="HEIGHT: 140px" id="Table1" border="0" cellSpacing="0" cellPadding="0" width="768">
							<TR>
								<TD width="100%">
									<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%" align="left">
										<TR>
											<TD style="WIDTH: 51px" class="Headerdetalle"><asp:label id="Label3" runat="server" Width="48px">PERIODO</asp:label></TD>
											<TD style="WIDTH: 63px" class="Headerdetalle"><asp:label id="Label4" runat="server" Width="56px">MES</asp:label></TD>
											<TD style="WIDTH: 83px" class="Headerdetalle"><asp:label id="Label1" runat="server" Width="32px">C.O.</asp:label></TD>
											<TD style="WIDTH: 47px" class="Headerdetalle"><asp:label id="Label5" runat="server" Width="38px">Cuenta</asp:label></TD>
											<TD vAlign="top" rowSpan="2" align="left"><asp:textbox id="txtBuscar" runat="server" Width="100%" Height="19px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 51px"><asp:dropdownlist id="ddlPeriodo" runat="server" CssClass="normaldetalle" Width="56px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 63px"><asp:dropdownlist id="ddlMes" runat="server" CssClass="normaldetalle" Width="72px" Height="16px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 83px"><asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="80px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 47px"><asp:dropdownlist id="ddlCuenta" runat="server" CssClass="normaldetalle" Width="48px"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="Headerdetalle" height="100%" vAlign="top" width="100%" align="center"><asp:label id="Label2" runat="server" Width="184px">SALDOS DE CENTROS DE COSTO</asp:label></TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="100%" align="right"><cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="9" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO CC">
												<HeaderStyle Wrap="False" Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="NOMBRE DE CENTRO DE COSTO">
												<HeaderStyle Wrap="False" HorizontalAlign="Center" Width="10%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD height="100%" vAlign="top" width="100%" align="right">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD>
												<asp:CheckBox id="chkDistinct" runat="server" CssClass="normaldetalle" Text="Solo 100, 300 y 500"></asp:CheckBox></TD>
											<TD><INPUT style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 22px" id="hIdCuenta" size="6" type="hidden"
													name="Hidden1" runat="server"><INPUT id="hidGrupoCentroCosto" type="hidden" name="Hidden1" runat="server" style="Z-INDEX: 0"><INPUT style="Z-INDEX: 0; WIDTH: 99px; HEIGHT: 22px" id="hUser" size="11" type="hidden"
													runat="server"></TD>
											<TD align="right"><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"
													style="Z-INDEX: 0"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 2px" vAlign="top" width="100%" align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
				var KEYIDTIPOLETRA = "TipoLetra";
				
				function ActualizarParametros(){
						var otxtBuscar = $O('txtBuscar');
						otxtBuscar.focus();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda(1);//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
							var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NombreGrupoCentroCosto";
							oParamBusqueda.Texto="Nombre de Grupo de Centro de Costo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.LongitudEjecucion=4;
							oParamBusqueda.CampoAlterno="NroGrupoCentroCosto";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="NroGrupoCentroCosto";
							oParamBusqueda.Texto="Numero de Grupo de Centro de Costo";
							oParamBusqueda.Tipo="C";
							oParamBusqueda.CampoAlterno="NombreGrupoCentroCosto";
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
						
						(new AutoBusqueda('txtBuscar')).CrearPopupOpcion(SIMA.Utilitario.Helper.General.ObtenerPathApp() + '/GestionFinanciera/Presupuesto/Procesar.aspx?',oParamCollecionBusqueda);
						
				}
				
				ActualizarParametros();
				LlenarGrillaOrdenamientoPaginacion();
				
				AgregarOpciones();
		</SCRIPT>
	</body>
</HTML>
