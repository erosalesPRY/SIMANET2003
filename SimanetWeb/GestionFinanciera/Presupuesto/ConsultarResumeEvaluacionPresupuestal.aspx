<%@ Page language="c#" Codebehind="ConsultarResumeEvaluacionPresupuestal.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarResumeEvaluacionPresupuestal" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarResumeEvaluacionPresupuestal</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<style>.BordeIzquierdo { BORDER-LEFT: #cccccc 1px solid }
		</style>
		<script>
				var PROCESO ="idProceso";//Indicador de Proceso 
				var KEYQTIPOPRESUPUESTO ="idtp";
				var KEYQIDCENTROOPERATIVO="idCentro";
				var KEYQIDCENTROOPERATIVOP="idcop";//CentroOPerativo de la pagina de Procesos
				var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
				var KEYQIDGRUPOCC = "idGrpCC";
				var KEYQNOMBREGRUPOCC = "NombreGrpCC";
				var KEYQIDCENTROCOSTO ="idCC";
				var KEYQPERIODO ="Periodo";
				var KEYQMES ="Mes";
				var KEYQCUENTA3DIG="Cta3Dig";
				var KEYQMODO="Modo";
				var PrcTerminado=false;
				var e;
				var oNodoItem;
				var KEYQPPTO = "VISTAPPTO";
				var KEYQVISTA="Vista";
				//var KEYQTIPOOPCION = "Opcion";
				
			function ObtenerDetalledeCentroporTipodePresupuesto()
			{
				
				PrcTerminado=false;
				//Datos del Objeto TreeviewList
				e = window.event.srcElement;//Objeto Imagen
			
				
				oNodoItem = new SIMA.Utilitario.Helper.General.Treeview.Nodo.Item();
				oNodoItem = e.getAttribute("oNodoItem");
				oDataGridFilaActual = oNodoItem.DataGridFila;
				
				
			
				//Se obtiene la relacion de cuentas contable a nivel de 5 dig;
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				
				var UrlPaginaProceso =PathApp + "/GestionFinanciera/Presupuesto/Procesar.aspx?"; 
				var Parametros;
				var strListaParametros;
				
					var idProceso = ((parseInt(oNodoItem.Nivel) ==1)? SIMA.Utilitario.Constantes.General.ProcesoCallBack.PresupuestoporCentroOperativo.toString() 
																													:SIMA.Utilitario.Constantes.General.ProcesoCallBack.PresupuestoporCentroOperativoNivel2.toString());
					
					
					var strListaParametros = idProceso;
				
					//Obtener los datos segun Tipo de presupuesto
					var TIPOPRESUPUESTO ="idtp";
					var IDCENTROOPERATIVO="idcop";
					var PROCESO ="idProceso";
					var	PERIODO = "Periodo";
					var MES = "Mes";
					//---------------------------------------------------------------------------------------------------------------
					oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					
					
					with(SIMA.Utilitario.Constantes.General.Caracter)
					{
						var PathPaginaProceso = SIMA.Utilitario.Helper.General.ObtenerPathApp()+ "/GestionFinanciera/Presupuesto/Procesar.aspx" + signoInterrogacion.toString()
							+ TIPOPRESUPUESTO + SignoIgual.toString() + oDataGridFilaActual.getAttribute("idTipoPresupuesto").toString()
							+ signoAmperson.toString() 
							+ IDCENTROOPERATIVO + SignoIgual.toString() + oDataGridFilaActual.getAttribute("idCentroOperativo").toString()
							+ signoAmperson.toString() 
							+ PERIODO + SignoIgual.toString() + oPagina.Request.Params[PERIODO]
							+ signoAmperson.toString() 
							+ MES + SignoIgual.toString() +  oPagina.Request.Params[MES]
							+ signoAmperson.toString() 
							+ PROCESO + SignoIgual.toString() + idProceso
							+ signoAmperson.toString()
							+ KEYQPPTO + SignoIgual.toString() + oPagina.Request.Params[KEYQPPTO];
					}
					
					
					oDataGrid = oNodoItem.DataGrid;
					oCallBack = new SIMA.Utilitario.Helper.General.CallBack();
					oCallBack.CargarDocumentoXML(PathPaginaProceso,strListaParametros,oDataGrid);
				
				
				MostrarDatos();
				
				return "Cargado";
			}
			
			
			var idProcesoTmr;//Sirve para identificar el proceso para luego liquidarlo y no quede en memoria ejecutandose;
			function MostrarDatos()
			{
				if (PrcTerminado==false)
				{
					idProcesoTmr= setTimeout("MostrarDatos();",50);
					window.status = PrcTerminado + "   " + oNodoItem.DataStatus;
					
				}
				else
				{
					ohtml = new SIMA.Utilitario.Helper.General.Html();
					clearInterval(idProcesoTmr);//Fuerza para terminar el proceso lanzado por el temporizador
					for(var i=0;i<= arrDataEveluacion.length-1;i++)
					{
						oEvaluacionCentroOperativoBE= new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionCentroOperativoBE();
						oEvaluacionCentroOperativoBE = arrDataEveluacion.ObtenerEntidad(i);
						//Carga la Grilla con los elementos encontrados
						with(oEvaluacionCentroOperativoBE)
						{
							var oDataGridFilaNueva;
							var ISNODOPADRE = (IsNodoPadre=='NO')?false:true;
							if (IsNodoPadre=='NO')
							{
								oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,oEvaluacionCentroOperativoBE.Nombre,false,null,MostrarOtros,e);
								oDataGridFilaNueva.Tag = oEvaluacionCentroOperativoBE;
								//FilaContenedora.getAttribute("idTipoPresupuesto")		
							}
							else
							{
								oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,oEvaluacionCentroOperativoBE.Nombre,true,ObtenerDetalledeCentroporTipodePresupuesto,null,e);
							}
							//Parametros finales
							oDataGridFilaNueva.setAttribute("idTipoPresupuesto",oEvaluacionCentroOperativoBE.IdTipoPresupuesto);
							oDataGridFilaNueva.setAttribute("idCentroOperativo",oEvaluacionCentroOperativoBE.IdCentroOperativo);
							oDataGridFilaNueva.setAttribute("NombreCentroOperativo",oEvaluacionCentroOperativoBE.Nombre);
							
							//Datos de Sima Peru
							otblCentro = ohtml.CrearTabla(1,3);
							otblCentro.width="100%";
							otblCentro.className="ItemGrillaSinColor";
							otblCentro.border=0;
							with(otblCentro.rows[0])
							{
								cells(0).width = "33.33%";cells(0).innerText = oEvaluacionCentroOperativoBE.MontoPresupuestadoPeru;
								cells(0).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).width = "33.33%";cells(1).innerText = oEvaluacionCentroOperativoBE.MontoEjecutadoPeru;
								cells(1).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).style.borderLeft = "1px #cccccc solid";
								cells(2).width = "33.33%";cells(2).innerText = oEvaluacionCentroOperativoBE.MontoSaldoPeru;
								cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(2).style.borderLeft = "1px #cccccc solid";
							}
							oDataGridFilaNueva.cells(1).appendChild(otblCentro);//Celda de Sima Peru;
							//Datos de Sima Iquitos
							otblCentro = ohtml.CrearTabla(1,3);
							otblCentro.width="100%";
							otblCentro.className="ItemGrillaSinColor";
							otblCentro.border=0;
							
							
							with(otblCentro.rows[0])
							{
								cells(0).width = "33.33%";cells(0).innerText = oEvaluacionCentroOperativoBE.MontoPresupuestadoIquitos;
								cells(0).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).width = "33.33%";cells(1).innerText = oEvaluacionCentroOperativoBE.MontoEjecutadoIquitos;
								cells(1).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(2).width = "33.33%";cells(2).innerText = oEvaluacionCentroOperativoBE.MontoSaldoIquitos;
								cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
							}
							//Agrega la tabla creada para su respectivo nodo
							oDataGridFilaNueva.cells(2).appendChild(otblCentro);//Celda de Sima Peru;
						}
					}
					arrDataEveluacion.Remover();
					SIMA.Utilitario.Helper.General.Treeview.Nodo.Enumerar(oNodoItem.DataGrid);
					window.status = PrcTerminado;
					
				}
			}			
			
			var arrDataEveluacion = new Array();
			arrDataEveluacion.CargarDatos= function(oEvaluacionCentroOperativoBE,Estado){
				if (Estado==false)
				{
					this[this.length] = new Array();
					this[this.length-1] = oEvaluacionCentroOperativoBE;
				}
				PrcTerminado = Estado
			}
			arrDataEveluacion.ObtenerEntidad = function(Indice){
				return this[Indice];
			}
			arrDataEveluacion.Remover = function(){
				try
				{
					Long = this.length-1;
					for (var i=0;i<=Long;i++){this.pop();} 
				}
				catch(error){}
			}
			
			function MostrarOtros()
			{
				var e = window.event.srcElement;
				/*Obtiene la Fila que contiene el nodo Elemento (1ero la Celda 2do la fila 3er la tableBody 4ta la Tabla 5to la fila)*/
				var FilaContenedora = e.parentElement.parentElement.parentElement.parentElement.parentElement;
				//Entidad que contiene informacion del Nodo
				oEvaluacionCentroOperativoBE= new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionCentroOperativoBE();
				oEvaluacionCentroOperativoBE = FilaContenedora.Tag;//Obtiene la Entidad que se encuentra almacenada en la Propiedad de la fila Seleccionada
				
				var TIPOPRESUPUESTO ="idtp";
				var IDCENTROOPERATIVO="idCentro";
				var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
				var KEYQNOMBREPRESUPUESTO = "NombrePPTO";
				var PERIODO = "Periodo";
				var MES = "Mes";
				var DIGCTA = "digCta";
				var KEYQTABSELECT = "tabSelect";
				var KEYTIPOINFORMACION = "TipoInfo";
				
				oPagina = new	SIMA.Utilitario.Helper.General.Pagina();
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					PaginaGrupoCC = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/Presupuesto/DefaultGrupoCC.aspx?"
					//PaginaGrupoCC = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/Presupuesto/" + ((oPagina.Request.Params[KEYQMODO]=='C')? 'DefaultGrupoCC.aspx':'ConsultarGastosMensualPorGrupodeCC.aspx') + SIMA.Utilitario.Constantes.General.Caracter.signoInterrogacion
										+ KEYQPPTO + SignoIgual.toString() + oPagina.Request.Params[KEYQPPTO]
										+ signoAmperson.toString()
										+ IDCENTROOPERATIVO + SignoIgual.toString() + FilaContenedora.getAttribute("idCentroOperativo")
										+ signoAmperson.toString()
										+ KEYQCENTROOPERATIVONOMBRE + SignoIgual.toString() + FilaContenedora.getAttribute("NombreCentroOperativo")
										+ signoAmperson.toString()
										+ PERIODO + SignoIgual.toString() + oPagina.Request.Params[PERIODO]
										+ signoAmperson.toString()
										+ MES + SignoIgual.toString() + oPagina.Request.Params[MES]
										+ signoAmperson.toString()
										+ KEYQMODO + SignoIgual.toString() +  oPagina.Request.Params[KEYQMODO]
										+ signoAmperson.toString()
										+ KEYQVISTA + SignoIgual.toString() + oPagina.Request.Params[KEYQVISTA]
										+ signoAmperson.toString()
										//+ KEYQTIPOOPCION + SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOOPCION]
										//+ signoAmperson.toString()
										+ KEYTIPOINFORMACION + SignoIgual.toString() + ((oPagina.Request.Params[KEYQMODO]=='C')? 'real':'ppto')
										+ signoAmperson.toString();
										
						switch(FilaContenedora.getAttribute("idTipoPresupuesto"))
						{
							case '1':
								oPagina.Response.TopRedirect(PaginaGrupoCC + TIPOPRESUPUESTO + SignoIgual.toString() + FilaContenedora.getAttribute("idTipoPresupuesto"));
								break;
							case '2;3':
								//oPagina.Response.TopRedirect(PaginaGrupoCC + TIPOPRESUPUESTO + SignoIgual.toString() + oEvaluacionCentroOperativoBE.IdT);
								oPagina.Response.TopRedirect(PaginaGrupoCC + TIPOPRESUPUESTO + SignoIgual.toString() + "2"); //Solo Gastos indirectos
								break;
							default:
								break;
						}
				}
			
			}			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="723" border="0">
							<TR>
								<TD class="commands" align="left">
									<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Resumen Evaluación Presupuestal</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"><cc1:datagridweb id="grid" runat="server" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										AllowSorting="True" PageSize="7" Width="725px">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="NombreTipoPresupuesto" HeaderText="PRESUPUESTO">
												<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="SIMA-PERU">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="3">
																<asp:Label id="lblSimaPeru" runat="server" CssClass="HeaderGrilla" BorderStyle="None" Height="3px">SIMA-PERU S.A</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="33.33%">
																<asp:Label id="lblPresupuestoP" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUPUESTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%">
																<asp:Label id="lblEjecutadoP" runat="server" CssClass="HeaderGrilla" BorderStyle="None">EJECUTADO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%">
																<asp:Label id="lblSaldoP" runat="server" CssClass="HeaderGrilla" BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SIMA-IQUITOS">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0"
														DESIGNTIMEDRAGDROP="434">
														<TR>
															<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="3">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" BorderStyle="None">SIMA-IQUITOS</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="33.33%">
																<asp:Label id="lblPresupuestoI" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUPUESTO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%">
																<asp:Label id="lblEjecutadoI" runat="server" CssClass="HeaderGrilla" BorderStyle="None">EJECUTADO</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%">
																<asp:Label id="lblSaldoI" runat="server" CssClass="HeaderGrilla" BorderStyle="None">SALDO</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
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
		</SCRIPT>
	</body>
</HTML>
