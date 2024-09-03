<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="ControlesWeb" Assembly="ControlesWeb" %>
<%@ Page language="c#" Codebehind="ConsultarDetalledeRubroPorNaturalezadeGasto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarDetalledeRubroPorNaturalezadeGasto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<LINK href="../../../Stylos/Temas.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js">  </SCRIPT>
		<SCRIPT language="javascript" src="../../../js/FrameCallBack.js"></SCRIPT>
		<script>
				var PROCESO ="idProceso";//Indicador de Proceso 
				var KEYQIDEMPRESA = "idEmp";
				var KEYQIDCENTROOPERATIVO="IdCentro";
				var KEYQIDFECHA = "efFecha";
				var KEYMODOPAGINA = "Modo";
				var KEYQCUENTA3DIG="Cta3Dig";
				var KEYQIDFORMATO = "IdFormato";
				var KEYQIDRUBRO = "IdRubro";
				var KEYQESOBSERVACION="Observacion";
				var KEYQCUENTACONTABLE="CuentaContable";
				var KEYQIDCENTROOPERATIVO2="IdCentroOperativo";
				var KEYQESFECHACOMPLETA="FechaCompelta";
				var KEYQIDOBSERVACION="IdObservacion";
				var KEYQDESCRIPCIONOBSERVACION="DescripcionObservacion";
				var PrcTerminado=false;
				var e;
				var oNodoItem;
				
			function ObtenerDetalleDeCentrosdeCostoPorNaturaleza()
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
				
				var UrlPaginaProceso =PathApp + "/GestionFinanciera/EstadosFinancieros/Directorio/Procesar.aspx?"; 
				var Parametros;
				var strListaParametros;
				var miFecha=oPagina.Request.Params[KEYQIDFECHA].toString().split('/');
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = PROCESO + SignoIgual.toString()+ SIMA.Utilitario.Constantes.General.ProcesoCallBack.NaturalezaGastosPPTO5Dig.toString()
									+ signoAmperson.toString()
									+ KEYQCUENTA3DIG + SignoIgual.toString() + oDataGridFilaActual.getAttribute[KEYQCUENTA3DIG]
									+ signoAmperson.toString()
									+ KEYQIDFORMATO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDFORMATO]
									+ signoAmperson.toString()
									+ KEYQIDRUBRO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDRUBRO]
									+ signoAmperson.toString()
									+ KEYQIDEMPRESA + SignoIgual.toString() + oPagina.Request.Params[KEYQIDEMPRESA]
									+ signoAmperson.toString()
									+ KEYQIDCENTROOPERATIVO2	+ SignoIgual.toString() + oPagina.Request.Params["IdCentroOperativo"]
									+ signoAmperson.toString()
									+ KEYQIDFECHA				+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDFECHA]
									+ signoAmperson.toString()
									+ KEYMODOPAGINA + SignoIgual.toString() + 'C';
									
				}
				strListaParametros = SIMA.Utilitario.Constantes.General.ProcesoCallBack.NaturalezaGastosPPTO5Dig.toString();
				
				/*Crea Una Instancia del Objeto PostBack*/
				oDataGrid = oNodoItem.DataGrid;
				oCallBack = new SIMA.Utilitario.Helper.General.CallBack();
				oCallBack.CargarDocumentoXML(UrlPaginaProceso + Parametros,strListaParametros,oDataGrid);
				
				MostrarDatos();
				return "Cargado";
			}
			
			
			var idProcesoTmr;//Sirve para identificar el proceso para luego liquidarlo y no quede en memoria ejecutandose;
			function MostrarDatos()
			{
				if (PrcTerminado==false)
				{
					idProcesoTmr= setTimeout("MostrarDatos();",50);
					//window.status = PrcTerminado + "   " + oNodoItem.DataStatus;
				}
				else
				{
					ohtml = new SIMA.Utilitario.Helper.General.Html();
					clearInterval(idProcesoTmr);//Fuerza para terminar el proceso lanzado por el temporizador
					for(var i=0;i<= arrDataEvaluacion.length-1;i++)
					{
						oEvaluacionRubroDetalle5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionRubroDetalle5DigBE();
						oEvaluacionRubroDetalle5DigBE = arrDataEvaluacion.ObtenerEntidad(i);
						//Carga la Grilla con los elementos encontrados
						with(oEvaluacionRubroDetalle5DigBE)
						{
						
							
													
							if(oPagina.Request.Params[KEYQESOBSERVACION]=='1PaginaValorIncial')
							{
								
								oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,CuentaContable + " " + NombreCuenta,false,null, MostrarOtros,e);
							}
							else
							{
							
								oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,CuentaContable + " " + NombreCuenta,false,null, null,e);
							}
							//Adiciona una nueva propiedad que contendra laEntidad de Negocio
							oDataGridFilaNueva.BaseBE = oEvaluacionRubroDetalle5DigBE;
							
							otblCentro = ohtml.CrearTabla(1,3);
							otblCentro.width="100%";
							otblCentro.className="ItemGrillaSinColor";
							otblCentro.border=0;
							with(otblCentro.rows[0])
							{
								cells(0).width = "28.33%";cells(0).innerText = oEvaluacionRubroDetalle5DigBE.EjecucionRealDelmesActual;
								cells(0).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).width = "28.33%";cells(1).innerText = oEvaluacionRubroDetalle5DigBE.PresupuestoDelMesActual;
								cells(1).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).style.borderLeft = "1px #cccccc solid";
								cells(2).width = "20%";cells(2).innerText = oEvaluacionRubroDetalle5DigBE.VariaciondelMes;
								cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(2).style.borderLeft = "1px #cccccc solid";
								
								if(oEvaluacionRubroDetalle5DigBE.VariaciondelMes!="SD")
								{	
									if(parseInt(oEvaluacionRubroDetalle5DigBE.VariaciondelMes)>0)
									{
									}									
									else
									{				
										var strValor ="";
										strValor= Reemplazar(oEvaluacionRubroDetalle5DigBE.VariaciondelMes,'-','');			
										cells(2).width = "20%";cells(2).innerText =strValor;
										cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();						
										cells(2).style.color="#C00000";
										cells(2).style.borderLeft = "1px #cccccc solid";
									}
								}
								
							}
							otblCentro.deleteRow(1);//Elimina una fila de mas creada  por error del metodo creartabla 
							//Agrega la tabla creada para su respectivo nodo
							oDataGridFilaNueva.cells(1).appendChild(otblCentro);//Celda de Sima Peru;
							
							otblCentro = ohtml.CrearTabla(1,3);
							otblCentro.width="100%";
							otblCentro.className="ItemGrillaSinColor";
							otblCentro.border=0;
							with(otblCentro.rows[0])
							{
								cells(0).width = "28.33%";cells(0).innerText = oEvaluacionRubroDetalle5DigBE.EjecucionRealAcumulado;
								cells(0).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).width = "28.33%";cells(1).innerText = oEvaluacionRubroDetalle5DigBE.PresupuestoAcumulado;
								cells(1).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).style.borderLeft = "1px #cccccc solid";
								
								cells(2).width = "20%";cells(2).innerText = oEvaluacionRubroDetalle5DigBE.VariacionAcumulada;
								cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(2).style.borderLeft = "1px #cccccc solid";
								
								if(oEvaluacionRubroDetalle5DigBE.VariacionAcumulada!="SD")
								{	
									if(parseInt(oEvaluacionRubroDetalle5DigBE.VariacionAcumulada)>0)
									{
									}									
									else
									{				
										var strValor ="";
										strValor= Reemplazar(oEvaluacionRubroDetalle5DigBE.VariacionAcumulada,'-','');			
										cells(2).width = "20%";cells(2).innerText =strValor;
										cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();						
										cells(2).style.color="#C00000";
										cells(2).style.borderLeft = "1px #cccccc solid";
									}
								}
							}
							otblCentro.deleteRow(1);//Elimina una fila de mas creada  por error del metodo creartabla 
							//Agrega la tabla creada para su respectivo nodo
							oDataGridFilaNueva.cells(2).appendChild(otblCentro);//Celda de Sima Peru;
							
							oDataGridFilaNueva.Observacion = oEvaluacionRubroDetalle5DigBE.Observacion.toString();
							oDataGridFilaNueva.onclick = function()
							{
								document.forms[0].elements['campo1'].value=this.Observacion;
							}
							
							if(oPagina.Request.Params[KEYQESOBSERVACION]=='1PaginaValorIncial')
							{			
								if(oEvaluacionRubroDetalle5DigBE.Observacion=='')					
								{	
									var oImg = ohtml.CrearImagen("/SimaNetWeb/imagenes/alert.gif");
									oImg.style.width = "20";
									oImg.style.height = "20";
									oDataGridFilaNueva.cells(3).appendChild(oImg);
								}
							}
						}
					}
					
					arrDataEvaluacion.Remover();
					SIMA.Utilitario.Helper.General.Treeview.Nodo.Enumerar(oNodoItem.DataGrid);
					//window.status = PrcTerminado;
				}
			}
			
		
			var arrDataEvaluacion = new Array();
			arrDataEvaluacion.CargarDatos= function(BaseBE,Estado){
				if (Estado==false)
				{
					this[this.length] = new Array();
					this[this.length-1] = BaseBE;
				}
				PrcTerminado = Estado
			}
			arrDataEvaluacion.ObtenerEntidad = function(Indice){
				return this[Indice];
			}
			
			
			arrDataEvaluacion.Remover = function(){
				try
				{
					Long = this.length-1;
					for (var i=0;i<=Long;i++){this.pop();} 
				}
				catch(error){}
			}
			
			
			function RetornarPantallaAnterior()
			{
				var NODOSELECCIONADO="NodoSeleccionado";
				ReemplazarParametrodeHistorial(NODOSELECCIONADO, (new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[NODOSELECCIONADO]);
			}
				function MostrarOtros()
			{
				
				
			
				e = window.event.srcElement;
				otblNodo = e.parentElement.parentElement.parentElement;
				oFilaContenedora = otblNodo.parentElement.parentElement;
				oPagina = new	SIMA.Utilitario.Helper.General.Pagina();
				oEvaluacionRubroDetalle5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionRubroDetalle5DigBE();
				oEvaluacionRubroDetalle5DigBE = oFilaContenedora.BaseBE;
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					var modoPagina;
					if(oEvaluacionRubroDetalle5DigBE.Observacion=='')
					{
						modoPagina='N';
					}
					else
					{
						modoPagina='M';
					}
					Parametros =	KEYQCUENTACONTABLE + SignoIgual.toString() + oEvaluacionRubroDetalle5DigBE.CuentaContable
									+ signoAmperson.toString()
									+ KEYQIDFORMATO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDFORMATO]
									+ signoAmperson.toString()
									+ KEYQIDRUBRO + SignoIgual.toString() + oPagina.Request.Params[KEYQIDRUBRO]
									+ signoAmperson.toString()
									+ KEYQIDEMPRESA + SignoIgual.toString() + oPagina.Request.Params[KEYQIDEMPRESA]
									+ signoAmperson.toString()
									+ KEYQIDCENTROOPERATIVO2	+ SignoIgual.toString() + oPagina.Request.Params["IdCentroOperativo"]
									+ signoAmperson.toString()
									+ KEYQIDFECHA				+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDFECHA]
									+ signoAmperson.toString()
									+ KEYQIDOBSERVACION				+ SignoIgual.toString() + oEvaluacionRubroDetalle5DigBE.IdObservacion
									+ signoAmperson.toString()
									+ KEYQESFECHACOMPLETA		+ SignoIgual.toString() + 'SI'
									+ signoAmperson.toString()
									+ KEYMODOPAGINA + SignoIgual.toString() + modoPagina;
									
				}
				
			
				
				Pagina = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/Directorio/DetalleAdministrarObservacionesEstadosFinancieros.aspx?";
				var Datos=new Array();
				
			
				Datos=window.open(Pagina + Parametros ,'minwin','Width=640px,Height=450px'); 
										
			}
			function MostrarValor()
			{	
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				var mdiPadre = oPagina.Request.Params[KEYQDESCRIPCIONOBSERVACION];
				
				var strValor ="";
				//if (parseInt(idCentro) ==2)
				
					strValor= Reemplazar(mdiPadre,'¿','<');
					strValor= Reemplazar(strValor,'?','>');
					strValor= Reemplazar(strValor,'<P>',' ');
					strValor= Reemplazar(strValor,'</P>',' ');					
					strValor= Reemplazar(strValor,'&NBSP;','');
				
				
				document.all["campo1"].value=strValor;
			}				
			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" colSpan="3">
						<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR bgColor="#f0f0f0">
								<TD align="left">
									<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 52px" colSpan="3"><asp:label id="Label4" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CONCEPTO :</asp:label></TD>
											<TD colSpan="2"><asp:label id="lblConcepto" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CONCEPTO :</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 52px"><asp:label id="Label3" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 36px"><asp:label id="lblPeriodo" runat="server" Font-Bold="True" Width="32px" ForeColor="Navy" CssClass="TituloPrincipalBlanco"> 2005</asp:label></TD>
											<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" Font-Bold="True" ForeColor="Navy" CssClass="TituloPrincipalBlanco">MES :</asp:label></TD>
											<TD style="WIDTH: 88px"><asp:label id="lblMes" runat="server" Font-Bold="True" Width="80%" ForeColor="Navy" CssClass="TituloPrincipalBlanco">Periodo :</asp:label></TD>
											<TD align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb id="grid" runat="server" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0"
										AutoGenerateColumns="False">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn DataField="NombreCuenta" HeaderText="CONCEPTO">
												<HeaderStyle Font-Size="X-Small" Font-Bold="True" Width="25%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="DEL MES">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblDelMes" runat="server" CssClass="HeaderGrilla" BorderStyle="None">FEBRERO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="28.33%">
																<asp:Label id="Label5" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
																<asp:Label id="Label6" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
																<asp:Label id="Label7" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table6" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="28.33%">
																<asp:Label id="lblDelMesReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
																<asp:Label id="lblDelMesPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
																<asp:Label id="lblDelMesVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table9" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="28.33%">
																<asp:Label id="lblDelMesRealF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
																<asp:Label id="lblDelMesPPTOF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
																<asp:Label id="lblDelMesVarF" runat="server" CssClass="FooterGrilla" BorderStyle="None" Visible="False">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ACUMULADO">
												<HeaderStyle Width="23.33%"></HeaderStyle>
												<HeaderTemplate>
													<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
														<TR>
															<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
																align="center" colSpan="3">
																<asp:Label id="lblAcumulado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">ACUMULADO</asp:Label></TD>
														</TR>
														<TR>
															<TD align="center" width="28.33%">
																<asp:Label id="Label8" runat="server" CssClass="HeaderGrilla" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28.33%">
																<asp:Label id="Label9" runat="server" CssClass="HeaderGrilla" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="20.33%">
																<asp:Label id="Label10" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIF.</asp:Label></TD>
														</TR>
													</TABLE>
												</HeaderTemplate>
												<ItemTemplate>
													<TABLE id="Table7" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="28.33%">
																<asp:Label id="lblAcumReal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">REAL</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
																<asp:Label id="lblAcumPPTO" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">PRESUP</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
																<asp:Label id="lblAcumVar" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">VAR(%)</asp:Label></TD>
														</TR>
													</TABLE>
												</ItemTemplate>
												<FooterTemplate>
													<TABLE id="Table95" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
														border="0">
														<TR>
															<TD align="right" width="28.33%">
																<asp:Label id="lblAcumRealF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28.33%">
																<asp:Label id="lblAcumPPTOF" runat="server" CssClass="FooterGrilla" BorderStyle="None">0.00</asp:Label></TD>
															<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="20.33%">
																<asp:Label id="lblAcumVarF" runat="server" CssClass="FooterGrilla" BorderStyle="None" Visible="False">0.00</asp:Label></TD>
														</TR>
													</TABLE>
												</FooterTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn Visible="False">
												<HeaderStyle Width="3%"></HeaderStyle>
												<ItemTemplate>
													<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
						</TABLE>
						<P align="left"><asp:label id="Label11" runat="server" Height="1px" Font-Size="XX-Small">OBSERVACIONES:</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"><TEXTAREA id="campo1" style="FONT-SIZE: 10px; WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 64px"
							name="campo1" rows="4" readOnly cols="101" runat="server"></TEXTAREA></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3"></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="3"><IMG id="Img1" onclick="RetornarPantallaAnterior();HistorialIrAtras();" alt="" src="../../../imagenes/RetornarAlFormato.GIF"></TD>
				</TR>
			</table>
			<SCRIPT>
				SIMA.Utilitario.Error.TiempoEsperadePagina();
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
