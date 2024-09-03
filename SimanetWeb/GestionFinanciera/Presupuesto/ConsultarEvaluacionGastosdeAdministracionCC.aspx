<%@ Page language="c#" Codebehind="ConsultarEvaluacionGastosdeAdministracionCC.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarEvaluacionGastosdeAdministracionCC" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarEvaluacionGastosdeAdministracionCC</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<style>.opaco5Porc { FILTER: alpha(opacity=80); opacity: .8 }
			.Activo { FILTER: alpha(opacity=100); opacity: .10 }
			.FondoTablaMasterInactivo { BACKGROUND: url(Imagenes/Skin1/Fondo1.jpg) left center; FILTER: alpha(opacity=60); opacity: .6 }
			.FondoTablaMaster { BACKGROUND: url(Imagenes/Skin1/Fondo1.jpg) left center }
			.Buscar { BORDER-RIGHT: #7b9ebd 1px solid; BORDER-TOP: #7b9ebd 1px solid; PADDING-LEFT: 20px; FONT-SIZE: 12px; BACKGROUND: url(simanetweb/imagenes/Filtro/imgBuscar.gif) white no-repeat 0px 1px; BORDER-LEFT: #7b9ebd 1px solid; WIDTH: 100%; COLOR: #333333; PADDING-TOP: 3px; BORDER-BOTTOM: #7b9ebd 1px solid; FONT-FAMILY: Arial; HEIGHT: 22px }
			.FotoSeleccionada { BORDER-RIGHT: #0000ff 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #0000ff 1px solid; PADDING-LEFT: 0px; FILTER: alpha(opacity=30); BORDER-LEFT: #0000ff 1px solid; CURSOR: hand; BORDER-BOTTOM: #0000ff 1px solid; opacity: .3 }
			.FotoNoSeleccionada { BORDER-RIGHT: #0000ff 1px solid; PADDING-RIGHT: 0px; BORDER-TOP: #0000ff 1px solid; PADDING-LEFT: 0px; BORDER-LEFT: #0000ff 1px solid; CURSOR: hand; BORDER-BOTTOM: #0000ff 1px solid; BACKGROUND-COLOR: lightsteelblue }
		</style>
		<script>
			var ParentDocument = window.parent.document.body.document;
			var tbl = ParentDocument.all["tblResumen"];		
			tbl.style.display="block";
			tbl = ParentDocument.all["tblResumenMensual"];
			tbl.style.display="none";
		</script>		
		<script>
		//<!--<div style="overflow:auto; width:450px; height:200px; align:left;">-->
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
				var KEYQPPTO = "VISTAPPTO";
				var KEYQUIENLLAMA = "QLlama";
				
				var PrcTerminado=false;
				var eImg;
				var oNodoItem;
				
			function ObtenerDetalleaNiveldeCuenta5Dig()
			{
				PrcTerminado=false;
				//Datos del Objeto TreeviewList
				eImg = window.event.srcElement;//Objeto Imagen
				
				oNodoItem = new SIMA.Utilitario.Helper.General.Treeview.Nodo.Item();
				oNodoItem = eImg.getAttribute("oNodoItem");
				oDataGridFilaActual = oNodoItem.DataGridFila;
			
				//Se obtiene la relacion de cuentas contable a nivel de 5 dig;
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				
				var UrlPaginaProceso =PathApp + "/GestionFinanciera/Presupuesto/Procesar.aspx?"; 
				//var UrlDetalle =PathApp + "/GestionFinanciera/Presupuesto/ConsultarEvaluacionGastosdeAdministracionGrupoCC.aspx?"; 
				var Parametros;
				var strListaParametros;
				
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = PROCESO + SignoIgual.toString()+ SIMA.Utilitario.Constantes.General.ProcesoCallBack.EvaluacionPrespuestalCentrosdeCostoDetalleCta5Dig.toString()
									+ signoAmperson.toString()
									+ KEYQUIENLLAMA				+ SignoIgual.toString() + oPagina.Request.Params[KEYQUIENLLAMA]
									+ signoAmperson.toString()
									+ KEYQPPTO					+ SignoIgual.toString() + oPagina.Request.Params[KEYQPPTO]
									+ signoAmperson.toString()
									+ KEYQTIPOPRESUPUESTO		+ SignoIgual.toString() + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
									+ signoAmperson.toString()
									+ KEYQIDCENTROOPERATIVOP	+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
									+ signoAmperson.toString()
									+ KEYQIDGRUPOCC				+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDGRUPOCC]
									+ signoAmperson.toString()
									+ KEYQIDCENTROCOSTO			+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROCOSTO]
									+ signoAmperson.toString()
									+ KEYQPERIODO				+ SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO]
									+ signoAmperson.toString()
									+ KEYQMES					+ SignoIgual.toString() + oPagina.Request.Params[KEYQMES]
									+ signoAmperson.toString()
									+ KEYQCUENTA3DIG			+ SignoIgual.toString() + oDataGridFilaActual.getAttribute("CuentaContable3Dig");
									
				}
				strListaParametros = SIMA.Utilitario.Constantes.General.ProcesoCallBack.EvaluacionPrespuestalCentrosdeCostoDetalleCta5Dig.toString();
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
					for(var i=0;i<= arrDataEveluacion.length-1;i++)
					{
						oEvaluacionPartida5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionPartida5DigBE();
						oEvaluacionPartida5DigBE = arrDataEveluacion.ObtenerEntidad(i);
						//Carga la Grilla con los elementos encontrados
						with(oEvaluacionPartida5DigBE)
						{
							var DigGrupoCta = CuentaContable.charAt(2);
							oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,CuentaContable + " " + NombreCuenta,false,null, ((DigGrupoCta =='1' || DigGrupoCta =='3')?MostrarListadoporNaturalezadeGasto:null),eImg);
							//Adiciona una nueva propiedad que contendra laEntidad de Negocio
							oDataGridFilaNueva.BaseBE = oEvaluacionPartida5DigBE;
							
							otblCentro = ohtml.CrearTabla(1,3);
							otblCentro.width="100%";
							otblCentro.height="100%";
							otblCentro.className="ItemGrillaSinColor";
							otblCentro.cellSpacing=0;otblCentro.cellPadding=0;
							otblCentro.border=0;
							with(otblCentro.rows[0])
							{
								height = "100%";
								cells(0).width = "33.33%";cells(0).innerText = oEvaluacionPartida5DigBE.MontoPresupuestado;
								cells(0).height = "100%";
								cells(0).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).width = "33.33%";cells(1).innerText = oEvaluacionPartida5DigBE.MontoEjecutado;
								cells(1).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(1).height = "100%";
								cells(1).style.borderLeft = "1px #cccccc solid";
								
								cells(2).width = "33.33%";cells(2).innerText = oEvaluacionPartida5DigBE.MontoSaldo;
								cells(2).align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
								cells(2).height = "100%";
								cells(2).style.borderLeft = "1px #cccccc solid";
							}
							otblCentro.deleteRow(1);//Elimina una fila de mas creada  por error del metodo creartabla 
							//Agrega la tabla creada para su respectivo nodo
							oDataGridFilaNueva.cells(1).appendChild(otblCentro);//Celda de Sima Peru;
						}
					}
					arrDataEveluacion.Remover();
					SIMA.Utilitario.Helper.General.Treeview.Nodo.Enumerar(oNodoItem.DataGrid);
					//window.status = PrcTerminado;
				}
			}
			
		
			var arrDataEveluacion = new Array();
			arrDataEveluacion.CargarDatos= function(oEvaluacionPartida5DigBE,Estado){
				if (Estado==false)
				{
					this[this.length] = new Array();
					this[this.length-1] = oEvaluacionPartida5DigBE;
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
			
			
			function MostrarListadoporNaturalezadeGasto()
			{
				eImg = window.event.srcElement;
				otblNodo = eImg.parentElement.parentElement.parentElement;
				oFilaContenedora = otblNodo.parentElement.parentElement;
				
				oEvaluacionPartida5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionPartida5DigBE();
				oEvaluacionPartida5DigBE = oFilaContenedora.BaseBE;
				
				switch(oEvaluacionPartida5DigBE.CuentaContable.charAt(2))
				{
					case '1':
						DetallePorNaturalezaGastoMaterialesoServicios(oEvaluacionPartida5DigBE.CuentaContable);
						break;
					case '3':
						DetallePorNaturalezaGastoMaterialesoServicios(oEvaluacionPartida5DigBE.CuentaContable);
						break;
					case '5'://Relacion de servicios
						break;
				}
			}
			

			function DetallePorNaturalezaGastoMaterialesoServicios(pCuentaContable)
			{
				var KEYQCUENTA5DIG="Cta5Dig";
				var Parametros;
				var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
				var UrlPaginaDetalleMovimientoMateriales =PathApp + "/GestionFinanciera/Presupuesto/ConsultarMovimientoMaterialesoServiciosPorCentroCosto.aspx?"; 
				
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = KEYQIDCENTROCOSTO 	+ SignoIgual.toString() + oPagina.Request.Params[KEYQIDCENTROCOSTO]
								+ signoAmperson.toString()
								+ KEYQPERIODO + SignoIgual.toString() + oPagina.Request.Params[KEYQPERIODO]
								+ signoAmperson.toString()
								+ KEYQMES + SignoIgual.toString() + oPagina.Request.Params[KEYQMES]
								+ signoAmperson.toString()
								+ KEYQCUENTA5DIG + SignoIgual.toString() + pCuentaContable;
					oPagina.Response.ShowDialogoModal(UrlPaginaDetalleMovimientoMateriales + Parametros,800,300);
					
				}
			}
			
/*******************************************************************************************************************************************/
/*Array de Datos de Personal*/			
/*******************************************************************************************************************************************/
			var arrDataPersonal = new Array();
			arrDataPersonal.ArrTmpBase= new Array();
			arrDataPersonal.ArrFiltrado= new Array();
			arrDataPersonal.ColumnaMatriz = 5;
			
			arrDataPersonal.IncreDecre = 0;
			arrDataPersonal.PosicionUltimoElemento=0;
			
			arrDataPersonal.NroCtrlImagen =0;
			arrDataPersonal.PathFotos="";
			arrDataPersonal.Extension= ".JPG";
			arrDataPersonal.idtblLista ="tblLstPersonal";
			
			arrDataPersonal.otblImg;
			arrDataPersonal.objtblToolBar;
			arrDataPersonal.Iniciar = function(){
				try{
					arrDataPersonal.IncreDecre=0;
					arrDataPersonal.PosicionUltimoElemento=0;
					this.objtblToolBar=document.all["tblToolMaster"];
					ohData = document.all["hListadePersonal"];
					this.ObtenerDatos(ohData.value);
					this.CrearCtrlImagen();
				}
				catch(e){}
			}
			
			arrDataPersonal.ObtenerDatos=function(ostrData){
				this.PathFotos = document.all["hPathFotos"].value;
				var PatronRegistro = "[@]";
				var PatronCampo="||";
				oDataTable = ostrData.toString().split(PatronRegistro);
				oDataTable.pop(oDataTable.length);
				
				for(var i=0;i<= oDataTable.length-1;i++){
					oArrRegistro = oDataTable[i].split(PatronCampo);
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					with(oPersonalBE)
					{
						Identificador = i;
						idPersonal = oArrRegistro[0];
						NroPersonal = oArrRegistro[1];
						ApellidosyNombres = oArrRegistro[2];
						Especialidad = oArrRegistro[3];
						DNI = oArrRegistro[4];
					}
					this[this.length] = new Array();
					this[this.length-1] = oPersonalBE;
					/*Realiza unBackup del Array para luego ser restaurado*/
					this.ArrTmpBase[this.ArrTmpBase.length]= new Array();
					this.ArrTmpBase[this.ArrTmpBase.length-1] = oPersonalBE;
				}
			}
			arrDataPersonal.CrearCtrlImagen= function(){
				var AnchoBase=40;
				var AltoBase =41;
				var NroColumnas=0;
				this.NroCtrlImagen =0;
				try{
					var oimgList = document.all[this.idtblLista];
					this.objtblToolBar.rows[0].cells(this.ColumnaMatriz).removeChild(oimgList);
				}
				catch(e){}
				oPanel = this.objtblToolBar.rows[0].cells(this.ColumnaMatriz);//Esta es la celda en donde se ubicaran los objs de imagenes
				NroColumnas = Math.floor((oPanel.offsetWidth-150) /AnchoBase);
				//NroColumnas = (NroColumnas-1); //Nro de Imagenes a Mostrar
				this.NroCtrlImagen = ((parseInt(NroColumnas)>= (this.length))? (this.length):NroColumnas);
				
				oHtml = new SIMA.Utilitario.Helper.General.Html();
				otblImg = oHtml.CrearTabla(1,this.NroCtrlImagen);
				otblImg.setAttribute("UNSELECTABLE","on");
				otblImg.id=this.idtblLista;
				otblImg.border=0;
				otblImg.cellPadding=1;
				otblImg.cellSpacing=1;
				//otblImg.border = "1px ##999999 solid";
				otblImg.deleteRow(1);//Elimina una fila de mas creada  por error del metodo creartabla 
				for(var i=0;i<=this.NroCtrlImagen-1;i++){
					oimg = oHtml.CrearImagen();
					oimg.id = "img" + i;
					oimg.src = this.PathFotos + "sinfoto" + this.Extension;
					oimg.style.width = AnchoBase + "px";
					oimg.style.height = AltoBase + "px";
					oimg.hspace=1;oimg.vspace=1;
					oimg.style.border = "1px #ffffff solid";
					//otblImg.rows[0].cells(i).style.paddingLeft="8px";
					otblImg.rows[0].cells(i).style.border = "1px  DimGray solid";
					otblImg.rows[0].cells(i).appendChild(oimg);
				}
				oPanel.appendChild(otblImg);
				
				//Carga los primeros elementos de personal a la lista
				this.DesplazarImagenes(0);
				/*Nro de Persona*/
				var oLbl = document.all["Label2"];
				oLbl.innerText = "Total de Personas: (" + this.NroCtrlImagen.toString() +  " de " + this.ArrTmpBase.length.toString() + ")";
				oLbl.noWrap = false;
				if (this.ArrTmpBase.length==0){oPanel.innerText="<No existen registros de personal para este centro de costo>";}
			}

		function EfectoReflejo(oImgBase,Left,Top){
			var oHtml = new SIMA.Utilitario.Helper.General.Html();
			var Posicion= arrDataPersonal.BuscarPocision(oImgBase);
			var objImg;
			objImg =document.all["Clon" + oImgBase.id];
			if (objImg==undefined){
				objImg = oHtml.CrearImagen();
				objImg.id = "Clon" + oImgBase.id;
			}
				
				objImg.style.position="absolute";
				objImg.src=oImgBase.src;
				objImg.style.left = Posicion[0]-1;//
				objImg.style.top =  Posicion[1]+ 55 ;//oImgBase.style.top;
				objImg.style.height= oImgBase.style.height;
				objImg.style.width= (parseInt(oImgBase.style.width.toString().replace("px","")) + 3) + "px";
				objImg.style.border = "1px gray solid";
				objImg.hspace=1;objImg.vspace=1;
				objImg.style.filter="alpha(style=1, opacity=0, finishOpacity=50, startX=0, startY=10, finishX=0, finishY=80) flipH() flipV()";
				document.body.appendChild(objImg);
				
		}
			
			
			arrDataPersonal.DesplazarImagenes=function(Posicion){
				var otblImg = document.all[this.idtblLista];
				for(var i=0;i<=this.NroCtrlImagen-1;i++){
					oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this[i];
					var oimg = otblImg.rows[0].cells(i).children[0];
					oimg.className="FotoNoSeleccionada";
					oimg.onerror= function(event){
										this.src = SIMA.Utilitario.Constantes.ImgDefault;
									};

					oimg.src = this.PathFotos + oPersonalBE.DNI + this.Extension;
					oimg.Tag = oPersonalBE;

					this.PosicionUltimoElemento =  oPersonalBE.Identificador;
					
					EfectoReflejo(oimg);
					
					oimg.onclick = function(){
						otblMaster = document.all["Table3"];
						otblMaster.className="FondoTablaMasterInactivo";
						oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
						oPersonalBE = this.Tag;
						var URLDETALLEPERSONAL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Personal/DetallePersonal.aspx?";
						var KEYQLLAMADA = "QuienLLama";
						var KEYQID        = "IDCO";
						oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						
						with (SIMA.Utilitario.Constantes.General.Caracter){
							var Parametros =  KEYQLLAMADA + SignoIgual.toString() + "ESTADOSFINANCIEROS" + signoAmperson.toString() + KEYQID + SignoIgual.toString() + oPersonalBE.NroPersonal;
							}
						/*Metodos Esternos*/
						//PopupDeEspera();
						(new SIMA.Grafico.Imagen.Efecto()).Click(this,50,true);
						HistorialIrAdelantePersonalizado("txtBuscar");
						/**/
						oPagina.Response.Redirect(URLDETALLEPERSONAL + Parametros);
					}
					oimg.oncopy=function(){
						return false;
					}
					oimg.oncontextmenu=function(){
						return false;
					}
					oimg.onmouseout = function(){
						this.className="FotoNoSeleccionada";
						var objtblDatos = document.all["tblDatos"];
						objtblDatos.style.display="none";
						var odivMonitor = document.all["divMonitor"];
						odivMonitor.style.display="none";						
					}
					oimg.onmouseover = function(){
						
						
					
						this.className="FotoSeleccionada";
						var odivMonitor = document.all["divMonitor"];
						odivMonitor.style.display="block";
						odivMonitor.style.width = eval(this.width+3)+"px";
						odivMonitor.style.height = eval(this.height+2)+"px";
						 var arrPos= arrDataPersonal.BuscarPocision(this);
						 odivMonitor.style.left =  (arrPos[0] + 2)+ "px";
						 odivMonitor.style.top =  (arrPos[1] + 2) + "px";
						 
						 /*Perfil y Datos*/
						 var objtblDatos = document.all["tblDatos"];
						 objtblDatos.style.display="block";
						 objtblDatos.style.left =  ((arrPos[0]/2)+ (parseInt(objtblDatos.style.width.replace("px"))/2))  + "px";
						 objtblDatos.style.top = (arrPos[1] - parseInt(objtblDatos.style.height.replace("px")))+ "px";						 
						 /**/
						 var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
						 oPersonalBE = this.Tag;
						 /**/
						 var oimgPersonal = document.all["imgPersonal"];
						 oimgPersonal.src = this.src;
						 var olblApellidosyNombres = document.all["lblApellidosyNombres"];
						 var olblEspecilidad = document.all["LblEspecilidad"];
						 var otxtBuscar = document.all["txtBuscar"];
						 var valor =oPersonalBE.ApellidosyNombres.toString().substring(0,29);
						 var newHTML = valor.replace(otxtBuscar.value.toUpperCase(),"<a style='BORDER-RIGHT: #0000ff 1px solid; BORDER-TOP: #0000ff 1px solid; BORDER-LEFT: #0000ff 1px solid; BORDER-BOTTOM: #0000ff 1px solid; BACKGROUND-COLOR: lightsteelblue; FONT-WEIGHT: bold; COLOR: mediumblue; TEXT-DECORATION: underline'>" + otxtBuscar.value.toUpperCase() + "</a>")  + "...";
						 olblApellidosyNombres.innerHTML= newHTML;
						 olblEspecilidad.innerText = oPersonalBE.Especialidad.toString();
						 
					}
				}
			}
			
			
			
			arrDataPersonal.BuscarPocision = function (obj) {
				var curleft = curtop = 0;
				if (obj.offsetParent) {
					curleft = obj.offsetLeft;curtop = obj.offsetTop;
					while (obj = obj.offsetParent) {
						curleft += obj.offsetLeft;curtop += obj.offsetTop;
					}
				}
				return [curleft,curtop];
			}
			/*Navega */
			arrDataPersonal.Siguiente = function(){
				var otblImg = document.all[this.idtblLista];
				arrDataPersonal.IncreDecre ++;
				this.IncreDecre = (((this.PosicionUltimoElemento+1) == (this.length))? (this.IncreDecre-1):this.IncreDecre);
				for(var i=0;i<=this.NroCtrlImagen-1;i++)
				{
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this[arrDataPersonal.IncreDecre + i];					
					this.PosicionUltimoElemento = oPersonalBE.Identificador;
					
					var oimg = otblImg.rows[0].cells(i).children[0];
					oimg.src = this.PathFotos + oPersonalBE.NroPersonal + this.Extension;
					oimg.Tag = oPersonalBE;
					oimg.className="FotoSeleccionada";			
					/*Imagenes efecto de reflejo*/
					var oimgEfe = document.all["Clon" +oimg.id];
					oimgEfe.src = oimg.src;
					setTimeout("arrDataPersonal.EfectoFade('" + ((this.NroCtrlImagen-1)- i) + "')",500);
				}
			}
			arrDataPersonal.Anterior = function(){
				var otblImg = document.all[this.idtblLista];
				arrDataPersonal.IncreDecre --;
				this.IncreDecre = ((arrDataPersonal.IncreDecre > 0)? (this.IncreDecre):0);
				for(var i=0;i<=this.NroCtrlImagen-1;i++){
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this[arrDataPersonal.IncreDecre + i];					
					this.PosicionUltimoElemento = oPersonalBE.Identificador;
					var oimg = otblImg.rows[0].cells(i).children[0];
					oimg.src = this.PathFotos + oPersonalBE.NroPersonal + this.Extension;
					oimg.Tag = oPersonalBE;
					oimg.className="FotoSeleccionada";
					/*Imagenes efecto de reflejo*/
					var oimgEfe = document.all["Clon" +oimg.id];
					oimgEfe.src = oimg.src;					
					setTimeout("arrDataPersonal.EfectoFade('" + i + "')",500);
				}
			}
			arrDataPersonal.EfectoFade=function(idx){
				var otblImg = document.all[this.idtblLista];
				otblImg.rows[0].cells(parseInt(idx)).children[0].className="opaco5Porc";
			}
			
			arrDataPersonal.Buscar=function(e){
				//Atras Borrar 8 //	window.alert(event.keyCode);
				var odivMonitor = document.all["divMonitor"];
				odivMonitor.style.display="none";
				if (e.value.length >0){
					if (event.keyCode==8)//BackDelete
					{
						this.ArrFiltrado.Truncate();
						this.RemoverEfecto();
						this.Reestablecer();
						this.CrearCtrlImagen();
						
					}
					for(var i=0;i<=this.length-1;i++){
						var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
						oPersonalBE = this[i];
						var Nombres = oPersonalBE.ApellidosyNombres.toString();
						if ((parseInt(Nombres.toUpperCase().indexOf(e.value.toUpperCase()))!=-1)&& (this.ArrFiltrado.Buscar(Nombres)==false)){
							this.ArrFiltrado[this.ArrFiltrado.length] = new Array();
							this.ArrFiltrado[this.ArrFiltrado.length-1] = oPersonalBE;
						}
					}
					this.RepintarImagenes();
				}
				else				
				{
					this.ArrFiltrado.Truncate();
					this.RemoverEfecto();
					this.Reestablecer();
					this.CrearCtrlImagen();
				}
			}
			
			arrDataPersonal.RepintarImagenes = function(){
				var oimgList = document.all[this.idtblLista];
				this.RemoverEfecto();//Remueve las Imagenes que poseen el efecto de reflejo
				this.objtblToolBar.rows[0].cells(this.ColumnaMatriz).removeChild(oimgList);
				//Elimina todos los Registro
				this.Refrescar();
				this.CrearCtrlImagen();
				this.ArrFiltrado.Truncate();
			}
			arrDataPersonal.RemoverEfecto=function(){
				var oimgList = document.all[this.idtblLista];
				for(var c=0;c<=oimgList.rows[0].cells.length-1;c++){
					var NombreImg = oimgList.rows[0].cells(c).children[0].id;
					var oimg = document.all["Clon" + NombreImg];
					document.body.removeChild(oimg);//Elimina las Imagenes de Reflejo
				}
			}
			
			arrDataPersonal.Truncate = function(){
				try{
					var Long = this.length-1;
					for(e=0;e<=Long;e++){this.pop();}
				}
				catch(e){}
			}
			
			arrDataPersonal.Refrescar= function(){
				this.Truncate();
				for(e=0;e<=this.ArrFiltrado.length-1;e++){
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = this.ArrFiltrado[e];
					oPersonalBE.Identificador = e;
					this[this.length] = new Array();
					this[this.length-1]=oPersonalBE;
				}
			}
			
			arrDataPersonal.Reestablecer= function(){
				var oimgList = document.all[this.idtblLista];
				this.objtblToolBar.rows[0].cells(this.ColumnaMatriz).removeChild(oimgList);			
				this.Truncate();
				for(e=0;e<=this.ArrTmpBase.length-1;e++){
					this[this.length] = new Array();
					this[this.length-1]=this.ArrTmpBase[e];
				}
			}
			
			/*Busca en el arrar Filtrado */
			arrDataPersonal.ArrFiltrado.Buscar= function(valor){
				for(var b=0;b<=arrDataPersonal.ArrFiltrado.length-1;b++){
					var oPersonalBE = new SIMA.EntidaddeNegocioBE.Personal.PersonalBE();
					oPersonalBE = arrDataPersonal.ArrFiltrado[b];
					var strNombres = oPersonalBE.ApellidosyNombres.toString();
					if (strNombres.toUpperCase() == valor.toString().toUpperCase()){return true;}
				}
				return false;
			}
			arrDataPersonal.ArrFiltrado.Truncate = function(){
				try{
					var Long = arrDataPersonal.ArrFiltrado.length-1;
					for(e=0;e<=Long;e++){arrDataPersonal.ArrFiltrado.pop();}
				}
				catch(e){}
			}
			
			/*Para mostrar u Ocultar la Lista de Personar del Centro de costos*/

			function MostraryOcultarListadePersonal(){
				var otblContenedor = document.all["CellContenedor"];
				var Mostrar = "";
				var olblMostrar = document.all["lblMostrar"];
				if (olblMostrar.innerText=='Mostrar Relación de Personal'){
					olblMostrar.innerText='Ocultar Relación de Personal';
					Mostrar="block";
				}
				else{
					olblMostrar.innerText='Mostrar Relación de Personal';
					Mostrar="none";
				}
				 MostrarOcultar(otblContenedor,Mostrar);
			}
			function MostrarOcultar(objContenedor,Display){
				for(var i=0;i<=objContenedor.children.length-1;i++){
					var objChild = objContenedor.children[i];
					objChild.style.display = Display;
					try{
						if(objChild.id.substring(0,3)=="img"){
							var objImgReflejo = document.all["Clon" + objChild.id];
							objImgReflejo.style.display = Display;
						}
					}
					catch(e){}
					MostrarOcultar(objChild,Display);
				}
			}
		</script>
		<script language="vbscript">
			Function ExportToExcel2003()
				Dim sHTML, oExcel, oBook
				'sHTML = document.all.item(objToExport).outerhtml
				sHTML = document.all.item("grid").outerhtml
				Set oExcel = CreateObject("Excel.Application")
				Set oBook = oExcel.Workbooks.Add
				oBook.HTMLProject.HTMLProjectItems("Sheet1").Text = sHTML
				oBook.HTMLProject.RefreshDocument
				oExcel.Visible = true
				oExcel.UserControl = true
			End Function
			
			'onunload="if((new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[KEYQUIENLLAMA]!=0){SubirHistorial();}"
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" onresize="arrDataPersonal.Buscar(document.all['txtBuscar']);"
		bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" onload="MostraryOcultarListadePersonal();try{arrDataPersonal.Iniciar();ObtenerHistorial();}catch(e){}">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblContenedor" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Evaluación Presupuestal por Centro de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="NombreCuenta" HeaderText="NATURALEZA DE GASTO">
									<HeaderStyle Width="55%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="SIMA-PERU">
									<HeaderTemplate>
										<TABLE id="Table4" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-BOTTOM: #cccccc 1px solid" align="center" colSpan="3">
													<asp:Label id="lblEmpresa" runat="server" CssClass="headergrilla" BorderStyle="None">EVALUACION</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="33.33%">
													<asp:Label id="lblHPPTO" runat="server" CssClass="HeaderGrilla" BorderStyle="None">Presupuesto</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%">
													<asp:Label id="lblHEjecutado" runat="server" CssClass="HeaderGrilla" BorderStyle="None">Ejecutado</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid" align="center" width="33.33%">
													<asp:Label id="lblHSaldo" runat="server" CssClass="HeaderGrilla" BorderStyle="None">Saldo</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD class="ItemGrillaSinColor" align="right" width="33.33%">
													<asp:Label id="lblPrespuesto" runat="server">0.00</asp:Label></TD>
												<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" align="right"
													width="33.33%">
													<asp:Label id="lblEjecutado" runat="server">0.00</asp:Label></TD>
												<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" align="right"
													width="33.33%">
													<asp:Label id="lblSaldo" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
											<TR>
												<TD class="ItemGrillaSinColor" align="right" width="33.33%">
													<asp:Label id="lblPrespuestoF" runat="server">0.00</asp:Label></TD>
												<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" align="right"
													width="33.33%">
													<asp:Label id="lblEjecutadoF" runat="server">0.00</asp:Label></TD>
												<TD class="ItemGrillaSinColor" style="BORDER-LEFT: #cccccc 1px solid" align="right"
													width="33.33%">
													<asp:Label id="lblSaldoF" runat="server">0.00</asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD id="ToolBarPersonal" align="center"><INPUT id="hListadePersonal" style="WIDTH: 138px; HEIGHT: 22px" type="hidden" size="17"
							runat="server"><INPUT id="hPathFotos" style="WIDTH: 138px; HEIGHT: 22px" type="hidden" size="17" name="Hidden1"
							runat="server">
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 19px" align="left" bgColor="#ffffff">
						<TABLE id="Table3" style="WIDTH: 216px; HEIGHT: 24px" cellSpacing="1" cellPadding="1" width="216"
							align="left" border="1" class="opaco5Porc">
							<TR>
								<TD style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; PADDING-LEFT: 10px; BORDER-LEFT: gray 1px solid; CURSOR: hand; BORDER-BOTTOM: gray 1px solid; BACKGROUND-COLOR: lightsteelblue">
									<asp:label id="lblMostrar" runat="server" CssClass="TituloPrincipal" Font-Bold="True" Font-Names="Arial"
										Font-Size="X-Small">Mostrar Relación de Personal </asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD id="CellContenedor" align="center">
						<TABLE class="Alternateitemgrilla" id="tblToolMaster" style="BORDER-RIGHT: dimgray 1px solid; PADDING-RIGHT: 5px; BORDER-TOP: dimgray 1px solid; PADDING-LEFT: 5px; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/imgToolCenter.gif); BORDER-LEFT: dimgray 1px solid; BORDER-BOTTOM: dimgray 1px solid; BACKGROUND-REPEAT: repeat-x"
							cellSpacing="3" cellPadding="0" width="100%" border="0">
							<TR>
								<TD vAlign="middle" align="left" width="3%"><IMG alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnPrimeroDisable.gif"></TD>
								<TD vAlign="middle" align="left" width="3%"><IMG onclick="arrDataPersonal.Anterior()" alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnAnterior.gif">
								</TD>
								<TD width="5%">
									<TABLE id="Table6" cellSpacing="0" cellPadding="0" width="100" align="left" border="0">
										<TR>
											<TD noWrap><INPUT class="Buscar" id="txtBuscar" onkeyup="arrDataPersonal.Buscar(this);" style="BACKGROUND-IMAGE: url(/SimanetWeb/imagenes/Filtro/imgBuscar.gif); WIDTH: 100%; BACKGROUND-REPEAT: no-repeat; HEIGHT: 22px"
													type="text" size="14" runat="server"></TD>
										</TR>
										<TR>
											<TD noWrap><asp:label id="Label2" runat="server" CssClass="TituloPrincipal" ForeColor="Navy" BorderStyle="None"
													BackColor="Transparent">...</asp:label></TD>
										</TR>
									</TABLE>
								</TD>
								<TD width="3%" align="left" vAlign="middle"><IMG onclick="arrDataPersonal.Siguiente()" alt="" src="/SimaNetWeb/imagenes/Navegador/ibtnSiguiente.gif"></TD>
								<TD width="3%" align="left" vAlign="middle"><IMG alt="" width="22" align="left" height="21" src="/SimaNetWeb/imagenes/Navegador/ibtnUltimoDisable.gif">
								</TD>
								<TD style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid"
									align="center" width="70%"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<TABLE id="tblDatos" style="BACKGROUND-POSITION: center center; DISPLAY: none; LEFT: 120px; BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Otros/ToolTips.gif); WIDTH: 312px; BACKGROUND-REPEAT: no-repeat; POSITION: absolute; TOP: 290px; HEIGHT: 264px"
				cellSpacing="1" cellPadding="1" width="312" border="0">
				<TR>
					<TD style="PADDING-LEFT: 15px; PADDING-TOP: 10px; HEIGHT: 39px"><asp:label id="lblApellidosyNombres" runat="server" CssClass="TituloPrincipal" ForeColor="Gray">Label</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 159px" vAlign="middle" align="center"><IMG class="FotoNoSeleccionada" id="imgPersonal" style="BORDER-RIGHT: gray 1px solid; BORDER-TOP: gray 1px solid; BORDER-LEFT: gray 1px solid; BORDER-BOTTOM: gray 1px solid"
							height="154" alt="" hspace="1" src="file:///C:\Documents and Settings\erosales\Escritorio\ToolBarFotos\5733.jpg" width="128" vspace="1"
							border="0"></TD>
				</TR>
				<TR>
					<TD style="PADDING-RIGHT: 5px; PADDING-LEFT: 5px">
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD style="PADDING-LEFT: 12px; HEIGHT: 19px"><asp:label id="Label1" runat="server" CssClass="TituloPrincipal" ForeColor="Gray" BorderStyle="None"
										BackColor="Transparent">ESPECIALIDAD :</asp:label></TD>
							</TR>
							<TR>
								<TD style="PADDING-LEFT: 12px"><asp:label id="LblEspecilidad" runat="server" CssClass="TituloPrincipal" ForeColor="Gray" BorderStyle="None"
										BackColor="Transparent">ESPECILIDAD</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			<div class="FondoSuave" id="divMonitor" style="BORDER-RIGHT: #0000ff 1px solid; BORDER-TOP: #0000ff 1px solid; DISPLAY: none; LEFT: 50px; BORDER-LEFT: #0000ff 1px solid; WIDTH: 48px; BORDER-BOTTOM: #0000ff 1px solid; POSITION: absolute; TOP: 280px; HEIGHT: 20px; BACKGROUND-COLOR: transparent"></div>
		</form>
	</body>
</HTML>
