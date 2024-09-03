<%@ Page language="c#" Codebehind="AdministrarKardexPorPersona.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarKardexPorPersona" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarKardexPorPersona</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../js/ZKFinger4500.js"></SCRIPT>
		<SCRIPT language="javascript" src="/SimaNetWeb/js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="/SimaNetWeb/js/JQuery/js/jquery.maphilight.js"></SCRIPT>
		<style> .ContextScan { Z-INDEX: 3; POSITION: relative; WIDTH: 250px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 80px } .imgScan { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; LEFT: 1px } .txtCodMat { Z-INDEX: 2; POSITION: absolute; BORDER-BOTTOM-STYLE: none; BORDER-RIGHT-STYLE: none; BACKGROUND-COLOR: transparent; WIDTH: 192px; BORDER-TOP-STYLE: none; HEIGHT: 24px; FONT-SIZE: 14pt; BORDER-LEFT-STYLE: none; TOP: 70px; FONT-WEIGHT: bold; LEFT: 50px } </style>
		<style>
			.ContextImgHuella { Z-INDEX: 3; POSITION: relative; WIDTH: 65px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 65px }
			.imgCircHuella { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<style>
			.ContextHuellaScan { Z-INDEX: 3; POSITION: relative; WIDTH: 65px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 65px }
			.FondoHuellaScan { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<style>
			.tabs { BACKGROUND-IMAGE: url(http://localhost/SimanetWeb/imagenes/Navegador/drop-under.gif) !important }
			.new-topic { BACKGROUND-IMAGE: url(http://SIMANETCOMPLEMENTOS/ext-3.2.1/examples/forum/message_edit.png) !important }
			.cellClass { BACKGROUND-IMAGE: url(http://10.10.90.115/SimanetWeb/imagenes/Navegador/Reformular.png); PADDING-LEFT: 20px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-POSITION: left center }
		</style>
		<style>
					.ContextImg { Z-INDEX: 3; POSITION: relative; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 45px }
					.imgCirc { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<style>
			.Parrafo{BORDER-BOTTOM: #0000ff 1px solid; BORDER-LEFT: #0000ff 1px solid; PADDING-BOTTOM: 5px; BACKGROUND-COLOR: #ffffcc; PADDING-LEFT: 5px; BORDER-TOP: #0000ff 1px solid; BORDER-RIGHT: #0000ff 1px solid; PADDING-TOP: 5px;}
		</style>
		<SCRIPT>
			var jSIMA = jQuery.noConflict();
		</SCRIPT>
		</SCRIPT>
		<script>
			function PersonalInfoBE(CODIGOPERSONA,NROHUELLAS,NROPERSONAL,IDHUELLA,CONREGHUELLA){
				this.CodigoPersona=CODIGOPERSONA;
				this.NroHuellas=NROHUELLAS;
				this.NroPersonal= NROPERSONAL;
				this.IdHuella=IDHUELLA;
				this.ConRegHuella=CONREGHUELLA;
			}
			var oPersonalInfoBE=new PersonalInfoBE();
			var ManagerProcess= new Object();
			ManagerProcess.Enum = new Object();
			ManagerProcess.Enum.Opcion = {
                 LectoraBarra: "1",
                 BotonOpcion: "2",
                 Ninguno:"3"
             }
            ManagerProcess.InvocadoDesde=ManagerProcess.Enum.Opcion.Ninguno;
            
			ManagerProcess.IdPrcTxtFind=0;
			ManagerProcess.TxtFindEnfocado=false;
			ManagerProcess.EnfocarTxtFind=function(mSeg){
				this.IdPrcTxtFind = window.setTimeout("ManagerProcess.TxtFindEnfocado=true; ManagerProcess.SetFocus('txtFindBar');",((mSeg!=undefined)?mSeg:1500));
			}


			ManagerProcess.SetFocus=function(txtFocus){
				if(ManagerProcess.TxtFindEnfocado==true){
					try{
						document.getElementById(txtFocus).focus();
						document.getElementById('ImgCodBar').src='/' + ApplicationPath + '/imagenes/Navegador/ReaderBar.gif';
					}
					catch(error){//Reinicia el elfoque
						ManagerProcess.EnfocarTxtFind();
					}
				}
			}
			
			ManagerProcess.KillEnfocarTxtFind=function(){
				ManagerProcess.TxtFindEnfocado=false;
				window.clearInterval(this.IdPrcTxtFind);
			}
			ManagerProcess.IdPrcCallEntregaMat=0;
			ManagerProcess.CallDetalleEntregaMaterial=function(){
				ManagerProcess.IdPrcCallEntregaMat=window.setTimeout("EntregaProductoConLectoradeBarra.ReaderLstMaterial();",2000);
			}
			ManagerProcess.KillCallDetalleEntregaMaterial=function(){
				window.clearTimeout(ManagerProcess.IdPrcCallEntregaMat);
			}
			


			var msgPersonal="No se ha seleccionado un registro de Personal";
			var KEYQIDAREA="IdArea";
			var KEYCODENTREGA = "CodEnt";
			var KEYCODITEM = "CodItem";
			var KEYQCODPERSONA="CodPers";
			var KEYQCLASEMAT="ClasMat";
			var KEYQCODMAT="CodMat";
			var KEYQNOMHUELLA="NomHuella";
			var KEYQIMGHUELLASELECT="HuellaSelect";
			var oTabClaseBE;
			var KEYQNROITEMS = "NroItemConf";
			
			var AdministrarHuellaPersonal = new Object();
			var SplahLecturaHuella=new Object();
			var ListarMaterialesPorPersona=new Object();
			var AdministrarKardexPorPersona = new Object();
			var ListadoMaterialDisponibleDeEntrega=new Object();
			var DetalleMaterialDisponibledeEntrega=new Object();
			var AdministrarTomadeHuella = new Object();
			var EntregaProductoConLectoradeBarra = new Object();
			 
			
			ListadoMaterialDisponibleDeEntrega.yo=null;
			DetalleMaterialDisponibledeEntrega.yo=null;
			SplahLecturaHuella.yo=null;
			AdministrarHuellaPersonal.yo=null;
			AdministrarTomadeHuella.yo=null;
			EntregaProductoConLectoradeBarra.yo=null;
			
			SplahLecturaHuella.Aceptar=function(hWind){
				_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Stop);
				hWind.close();
			}
			
			var opMenu=0;
			function MnuOP_txtBuscar_OnClick(MnuID,Data){
				opMenu = parseInt(MnuID.replace('itmMnu',''));
			}
			function txtBuscar_ItemDataBound(sender,e,dr){
				oPersonalInfoBE.CodigoPersona = dr["PTRCODTRA"].toString();
				oPersonalInfoBE.NroPersonal=dr["PTRNROLE"].toString();
				oPersonalInfoBE.ConRegHuella=false;
				jNet.get('hCodTrabAct').value = oPersonalInfoBE.CodigoPersona;
				AdministrarKardexPorPersona.CargarClaseMaterial(oPersonalInfoBE.CodigoPersona);
				jNet.get('imgFoto').src=jNet.get('hRutaFoto').value + oPersonalInfoBE.NroPersonal + ".jpg";
				//Cargar el cache de huellas Solo Para estabecer a true la existencia de huellas para este trabajador
				AdministrarKardexPorPersona.CargarHuellasAlCache();
			}
			

			AdministrarKardexPorPersona.CargarHuellasAlCache=function(){
				/*Carga Informacion de las Huellas del Trabajador*/
				try{
					var oDataTable = (new Controladora.SeguridadIndustrial.CCCTT_Huella()).ListarPorTrabajador(oPersonalInfoBE.CodigoPersona);
					var oDataRow =oDataTable.Rows.Items[0];
						if(oDataRow.Item("EOF")==true){//Obtiene informacion de Huellas del reloj
							Ext.MessageBox.confirm('Actualizar huella', 'Personal no cuenta con huella registrada, desea obtener las huellas de los dispositivo de marcaci�n ahora?', 
										function(btn){
											if(btn=="yes"){
												AdministrarKardexPorPersona.LecturadeHuelladelRelogMarcador();
											}
										});
							
						}
						
						_ZKFinger4500.Collection.removeAll();
						
						oDataTable.forEach(function(oDataRow){
												if(oDataRow.Item("EOF")==false){
													var oZKFingerUpHuellaBE=new ZKHuellaBE();
													oZKFingerUpHuellaBE.Codigo= oDataRow.Item("COD_TRABAJADOR").toString();//Codigo del trabajador y tipo de huella
													oZKFingerUpHuellaBE.strBase64= oDataRow.Item("HUELLA_M1");
													oZKFingerUpHuellaBE.IdVersion= oDataRow.Item("ID_VER");
													oZKFingerUpHuellaBE.Id= oDataRow.Item("ID_HUELLA");
													_ZKFinger4500.Collection.add(oZKFingerUpHuellaBE);
													oPersonalInfoBE.ConRegHuella=true;											
												}
											});						
				}
				catch(oSIMAExcepcion){
					if(oSIMAExcepcion instanceof SIMA.Utilitario.Error.SIMAExcepcionDominio){
						Ext.MessageBox.alert('CAPA DE DATOS', oSIMAExcepcion.Mensaje);
					}
					else if(oSIMAExcepcion instanceof ZKFingerError){
						Ext.MessageBox.alert('ZKfinger', oSIMAExcepcion.toString());
					}
					else{
						Ext.MessageBox.alert('ALERTA', oSIMAExcepcion.message);
					}
				}
			}
			
			
			var arrRelog; 
			var Puerto;
			var idPrc=0;
			var idx=0;
			var NroHuellasObtenidas=0;
			AdministrarKardexPorPersona.LecturadeHuelladelRelogMarcador=function(){
				arrRelog =new Array("10.12.20.12", "10.12.89.10", "10.12.36.10","10.12.44.10","10.12.44.11","10.10.106.10","10.10.105.10","10.12.88.10","10.12.20.11"); 
				Puerto = "4370";
				if(idx<=(arrRelog.length-1)){
					var strEncontrados = ((NroHuellasObtenidas>0)?"(" + NroHuellasObtenidas +")":"");
					(new System.Ext.UI.WebControls.Windows()).loadMask(true,Ext.getBody(),"Please wait...Obteniendo registros de Huellas desde el :" + arrRelog[idx] + " <br> encontradas: " + strEncontrados );
					idPrc = window.setTimeout("AdministrarKardexPorPersona.ObtenerHuella();",4000);
				}
				else{
					if(NroHuellasObtenidas>0){
						AdministrarKardexPorPersona.CargarHuellasAlCache();
						NroHuellasObtenidas=0;
					}
				}
			}
			
			
			
			AdministrarKardexPorPersona.ObtenerHuella=function(){
				var oDataHuella= (new Controladora.SeguridadIndustrial.CCCTT_Huella()).ObtenerRegistroDelRelog(oPersonalInfoBE.CodigoPersona,arrRelog[idx],Puerto);
				oDataHuella.forEach(function(oDataRow){
										if(oDataRow.Item("EOF")==false){
											//Ggrabar huella obtenida
											var oPersonalHuellaBE =  new EntidadesNegocio.Personal.PersonalHuellaBE();
												oPersonalHuellaBE.CodigoPersona = oPersonalInfoBE.CodigoPersona;
												oPersonalHuellaBE.IdHuella = oDataRow.Item("ID_HUELLA").toString();
												oPersonalHuellaBE.Huella1 = oDataRow.Item("HUELLA_M1");
												oPersonalHuellaBE.Huella2 = 'Directo del reloj';
												oPersonalHuellaBE.PorcCalidad='98';
												oPersonalHuellaBE.Existe=1;
												oPersonalHuellaBE.IdVersion = 10;
												oPersonalHuellaBE.IdOrigen = 1;
												(new Controladora.SeguridadIndustrial.CCTT_HuellaPersona()).ActInsertar(oPersonalHuellaBE);
												NroHuellasObtenidas++;
										}
									});
				window.clearTimeout(idPrc);
				(new System.Ext.UI.WebControls.Windows()).loadMask(false);
				idx++;
				AdministrarKardexPorPersona.LecturadeHuelladelRelogMarcador();
			}
			
						
				
			AdministrarKardexPorPersona.CargarClaseMaterial=function(CodigoPer){
				var oTabMaster = (new System.Ext.UI.WebControls.Tabs('tabMaster'));
				oTabMaster.RemoveAll();
				
				var oDataTable = (new Controladora.SeguridadIndustrial.CCCTT_KardexPersona()).ListarClase(CodigoPer);
				oDataTable.forEach(function(oDataRow){
										if(oDataRow.Item("EOF")==false){
											var NomTab = 'Tab'+(f+1);
											oTabMaster.Agregar(NomTab,oDataRow.Item("NOMBRECLASE"),{CodigoPersona:CodigoPer,CodigoClase:oDataRow.Item("CODIGOCLASE"),NombreClase:oDataRow.Item("NOMBRECLASE"),Load:false},false);
											if(oDataRow.Item("ITEMSNUEVOS")>0){
												var tab = Ext.getCmp(NomTab);
												tab.setTitle(oDataRow.Item("NOMBRECLASE") + ' (' + oDataRow.Item("ITEMSNUEVOS") + ')New <img src="http://10.10.90.115/simanetweb/imagenes/Navegador/CarCompra.gif">');
											}
										}
									});
					wTabPanel.setActiveTab(0);
			}
			
			
			
			AdministrarKardexPorPersona.IdTabSelected="";
			
			AdministrarKardexPorPersona.ListarMaterialDisponible=function(CodigoMaterial){
				if (ValidaSeleccionTrabajador()){
					var URLDISPONIBLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/ListadoMaterialDisponibleDeEntrega.aspx?' + KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPersonalInfoBE.CodigoPersona
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + jNet.get('hCodArea').value
					+ ((CodigoMaterial==undefined)?"": SIMA.Utilitario.Constantes.General.Caracter.signoAmperson + KEYQCODMAT + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoMaterial);
					
					if(ManagerProcess.InvocadoDesde==ManagerProcess.Enum.Opcion.LectoraBarra){ EntregaProductoConLectoradeBarra.yo.close();}
					
					ListadoMaterialDisponibleDeEntrega.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("MATERIALES DISPONIBLES PARA ENTREGA",URLDISPONIBLE  ,this,795,520,ListadoMaterialDisponibleDeEntrega.Aceptar,AdministrarKardexPorPersona.onClose);
				}
				else{
					jNet.get('imgFoto').src= '/' + ApplicationPath +'/imagenes/Navegador/UserActivo.gif';
					AdministrarKardexPorPersona.CargarClaseMaterial("");
					
					Ext.MessageBox.alert('ALERTA', msgPersonal);
				}
			}
			
			ListadoMaterialDisponibleDeEntrega.Aceptar=function(wHandle){
				wHandle.close();
			}
			
			AdministrarKardexPorPersona.onClose=function(hwind){
				try{
					if(ManagerProcess.InvocadoDesde==ManagerProcess.Enum.Opcion.LectoraBarra){
						CodMaterialReader="";
						ManagerProcess.TxtFindEnfocado=true;
						AdministrarKardexPorPersona.EntregaProductoConLectoradeBarra();
					}
				}
				catch(Error){
				}
			}
			
			
			
			function ValidaSeleccionTrabajador(){
				return((jNet.get('hCodTrabAct').value !='0')&&(jNet.get('txtBuscar').value.toString().length>0))
			}
			
			AdministrarKardexPorPersona.EntregaProductoConLectoradeBarra=function(){
				if (ValidaSeleccionTrabajador()){
					var URLENTREGAXLECTORA = '/' + ApplicationPath + '/GestionSeguridadIndustrial/EntregaProductoConLectoradeBarra.aspx?';
					var params=KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPersonalInfoBE.CodigoPersona;
					EntregaProductoConLectoradeBarra.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("ENTREGA DE PRODUCTOS",URLENTREGAXLECTORA + params ,this,370,230,AdministrarHuellaPersonal.Aceptar,EntregaProductoConLectoradeBarra.onClose);
					ManagerProcess.EnfocarTxtFind();
				}
				else{
					Ext.MessageBox.alert('ALERTA', msgPersonal);
				}
				
			}


			EntregaProductoConLectoradeBarra.onClose=function(wHandle){
				ManagerProcess.KillEnfocarTxtFind();
			}
			
			EntregaProductoConLectoradeBarra.Aceptar=function(wHandle){
				wHandle.close();
			}
			
			var CodMaterialReader="";
			var BloqueoLectura = false;
			//Metodo invocado desde el evento onKeyPress del control txtFind
			EntregaProductoConLectoradeBarra.BuscarProducto=function(e){
				if(window.event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn){
					e.value = e.value.toString().substring(0,10);
					if(CodMaterialReader==e.value) {return;}
					CodMaterialReader=e.value;
alert();
					
					jNet.get('ImgCodBar').src= '/' + ApplicationPath + '/imagenes/Navegador/FindForBar.gif';
					ManagerProcess.CallDetalleEntregaMaterial();
				}
				
			}
			

			
			EntregaProductoConLectoradeBarra.ReaderLstMaterial=function(){
					ManagerProcess.TxtFindEnfocado=false;
					var CodArea = jNet.get('hCodArea').value;
					var Encontrado=false;
					var oDataTable = (new Controladora.SeguridadIndustrial.CCCTT_KardexPersona()).ListarMaterialAEntrega(CodArea,CodMaterialReader);				
					if(oDataTable!=undefined){
						oDataTable.forEach(function(oDataRow){
												if((oDataRow.Item("EOF")==false)&&(oDataRow.Item("STOCKACTUAL")!='0')){//Llama al detalle de material a entregar
														if(oDataTable.Rows.Items.length==1){//Si solo existe un registro
															ManagerProcess.InvocadoDesde=ManagerProcess.Enum.Opcion.LectoraBarra;
															DetalleMaterialDisponibledeEntrega.Ingresar(oDataRow.Item("COD_ITEM"),oPersonalInfoBE.CodigoPersona,CodArea);
														}
														else{//para el caso existan muchos registros
															ManagerProcess.InvocadoDesde=ManagerProcess.Enum.Opcion.LectoraBarra;
															AdministrarKardexPorPersona.ListarMaterialDisponible(CodMaterialReader);	
														}
														
													
													jNet.get('txtFindBar').value='';
													jNet.get('ImgCodBar').src= '/' + ApplicationPath + '/imagenes/Navegador/ReaderBar.gif';
													CodMaterialReader="";
													Encontrado=true;
													ManagerProcess.KillCallDetalleEntregaMaterial();//Kill Proceso
													return;	
												}
											});
						if(Encontrado==false){//Llama al detalle de material a entregar
							ManagerProcess.KillEnfocarTxtFind();
							Ext.MessageBox.alert('ALERTA', "Material no existe o no cuenta con Stock disponible", function(btn){jNet.get('txtFindBar').value='';ManagerProcess.EnfocarTxtFind(1);});
						}
					}
					else{
						ManagerProcess.KillEnfocarTxtFind();
						Ext.MessageBox.alert('ALERTA', "Material no existe o no cuenta con Stock disponible", function(btn){jNet.get('txtFindBar').value='';ManagerProcess.EnfocarTxtFind(1);});
					}
					jNet.get('ImgCodBar').src= '/' + ApplicationPath + '/imagenes/Navegador/ReaderBar.gif';
					CodMaterialReader="";
			}
			
			

			
			/*Llama al scaner*/
			var IdPrcConfigMapHuella=0;
			AdministrarKardexPorPersona.RegistrarHuella=function(){
				if (ValidaSeleccionTrabajador()){
					var URLREGISTRAMARCA = '/' + ApplicationPath + '/GestionSeguridadIndustrial/AdministrarHuellaPersonal.aspx?';
					var params=KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPersonalInfoBE.CodigoPersona;
					AdministrarHuellaPersonal.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("REGISTRAR HUELLA",URLREGISTRAMARCA + params ,this,370,260,AdministrarHuellaPersonal.Aceptar);
					IdPrcConfigMapHuella = window.setTimeout("ConfigMap(true);",1000);
				}
				else{					
					Ext.MessageBox.alert('ALERTA', msgPersonal);
				}
			}
			
			AdministrarKardexPorPersona.ConfirmarRecibido=function(){
				var URLHUELLA='/' + ApplicationPath + '/GestionSeguridadIndustrial/SplahLecturaHuella.aspx?';
				var params=KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPersonalInfoBE.CodigoPersona;
				try{
					if(oPersonalInfoBE.ConRegHuella==true){//Si cuenta con informacion de config de huella 
						if(oPersonalInfoBE.CodigoPersona !='0'){
							var NroMatCofirm = (new Controladora.SeguridadIndustrial.CCCTT_KardexPersona()).ListarMaterialConfirmar(oPersonalInfoBE.CodigoPersona,"",jNet.get('hCodArea').value);
							if(NroMatCofirm!='0'){
								ModoLecturadeHuella='C';
								params = params + SIMA.Utilitario.Constantes.General.Caracter.signoAmperson + KEYQNROITEMS + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + NroMatCofirm;
								SplahLecturaHuella.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("DAR CONFORMIDAD DE RECEPCI�N",URLHUELLA + params ,this,580,330,SplahLecturaHuella.Aceptar);
								window.setTimeout("ConfigMap(false);",1300);//para mostrar las huellas 
								
								//Valida la huella
								_ZKFinger4500.Version=_ZKFinger4500.Enum.Huella.Version.v10;
								_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Init);
							}
							else{
								Ext.MessageBox.alert('ALERTA', 'No cuenta con informaci�n de entrega a confirmar');
							}
						}
						else{
							Ext.MessageBox.alert('ALERTA', msgPersonal);
						}
					}
					else{//Si no cuenta con Reg de Configuracion de huella, para crear el reg de huellas por persona
						AdministrarKardexPorPersona.RegistrarHuella();//Invoca al Formulario de administracion de Huellas
					}
				}
				catch(SIMAExcepcionDominio){
					Ext.MessageBox.alert('ALERTA', SIMAExcepcionDominio.toString());
				}
			}
			
			
			
			var DescImgHuellaSelec="";
			var NroMarca=0;
			var ModoLecturadeHuella='C';
			function ConfigMap(OnclickTrue){
				jSIMA('.map').maphilight({fillColor: '008800'});
				var map = document.getElementById('image-map'); 
				var areas = map.getElementsByTagName('area');
				
				//if(OnclickTrue==true){
					for (var i = 0; i < areas.length; i++){
						var area = areas[i];
						var id = area.id;
						/*La presionar un dedo de la imagen */
						jSIMA('#' + id).click(function(e) {
								if(OnclickTrue==true){
									DescImgHuellaSelec=e.target.title;
									NomImgSelec = e.target.id;
									oPersonalInfoBE.IdHuella = e.target.idHuella;
									NroMarca=1;
									e.preventDefault();
									//Activar Lector de Huellas
									ModoLecturadeHuella='N';
									var params=KEYQNOMHUELLA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + DescImgHuellaSelec
												+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
												+ KEYQIMGHUELLASELECT + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + NomImgSelec ;
												
									var URLREGISTRAMARCA = '/' + ApplicationPath + '/GestionSeguridadIndustrial/AdministrarTomadeHuella.aspx?';
									AdministrarTomadeHuella.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("IDENTIFICAR HUELLA(registro)",URLREGISTRAMARCA + params ,this,580,390,AdministrarTomadeHuella.Aceptar);
									_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Init);
								}
							});
					}
				//}
				//Stop el proceso de abrir la venta de mapa de huellas
				window.clearTimeout(IdPrcConfigMapHuella);
			}
			
			
			AdministrarTomadeHuella.Aceptar=function(wHandle){
				if((Huella.Collection==null)||(Huella.Collection.length==0)){wHandle.close();}//Sale y noo graba
				var oPersonalHuellaBE =new EntidadesNegocio.Personal.PersonalHuellaBE();
					oPersonalHuellaBE = Huella.Collection.getMaxCalidad();
					try{
						if(oPersonalHuellaBE.Existe==_ZKFinger4500.Enum.VerificaHuella.Estado.Existe){
							//Verifica si tambien existe en la base de Datos
							Ext.MessageBox.confirm('Actualizar huella', 'La huella tomada para registrar ya existe, desea reeplazarlo ahora?', 
										function(btn){
											if(btn=="yes"){
												(new Controladora.SeguridadIndustrial.CCTT_HuellaPersona()).ActInsertar(oPersonalHuellaBE);
											}
										});
						}
						else{
							//Registra en la Bse de Datos la Huella tomada
							(new Controladora.SeguridadIndustrial.CCTT_HuellaPersona()).ActInsertar(oPersonalHuellaBE);
						}
						AdministrarKardexPorPersona.CargarHuellasAlCache();
					}
					catch(oSIMAExcepcion ){
						if(oSIMAExcepcion instanceof SIMA.Utilitario.Error.SIMAExcepcionDominio){
							Ext.MessageBox.alert('CAPA DE DATOS', oSIMAExcepcion.ToString());
						}
						else if(oSIMAExcepcion instanceof ZKFingerError){
							Ext.MessageBox.alert('ZKfinger', oSIMAExcepcion.toString());
						}
						else{
							Ext.MessageBox.alert('ALERTA', oSIMAExcepcion.message);
						}
					}
				_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Stop);	
				wHandle.close();
			}
			
			
			AdministrarHuellaPersonal.Aceptar=function(wHandle){
				ModoLecturadeHuella='C';
				wHandle.close();
			}
			
			
			
			
			DetalleMaterialDisponibledeEntrega.Ingresar=function(CodigoItem,CodigoPersona,CodigoArea){
				var URLDISPONIBLEDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/DetalleMaterialDisponibledeEntrega.aspx?';
				var params= KEYCODITEM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoItem
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoPersona
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ KEYQIDAREA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoArea
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.N;
																					
				DetalleMaterialDisponibledeEntrega.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("DETALLE DE MATERIAL A ENTREGAR",URLDISPONIBLEDETALLE + params ,this,640,230,DetalleMaterialDisponibledeEntrega.Aceptar,DetalleMaterialDisponibledeEntrega.onClose);
				window.setTimeout("ConfigCampoFecha();",900);
			}
			
			DetalleMaterialDisponibledeEntrega.Aceptar=function(wHandle){
				try{
					//Valida que el registro de cantidada entregada no sea mayor al stock
					var cantStock=parseInt(jNet.get('hCantEnStock').value);
					var cantEntregada=parseInt(jNet.get('hCantAtendida').value);
					var cantPorEntregar=parseInt(jNet.get('txtCantEntrega').value);
					//var CantTotal = (cantEntregada+cantPorEntregar);
					var CantTotal = (cantPorEntregar);
					if(jNet.get('hModo').value=='N'){
						if(CantTotal>cantStock){
							Ext.MessageBox.alert('Validaci�n', 'La suma entre la CANTIDAD ENTREGADA:(' + cantEntregada.toString() + ') y la CANTIDAD POR ATENDER: (' + cantPorEntregar + ') no debe exceder el STOCK:('+ cantStock.toString() +') permitido.<br>intente ingresar una cantidad menor');
							return false;
						}
					}
					var oStockMaterialEntregaBE  = new EntidadesNegocio.GestionSeguridadIndustrial.StockMaterialEntregaBE();
					
					oStockMaterialEntregaBE.CodEntrega = jNet.get('hCodEntrega').value;
					oStockMaterialEntregaBE.CodItem = jNet.get('hCodItem').value;
					oStockMaterialEntregaBE.CodTrabajador = jNet.get('hCodTrabajador').value;
					oStockMaterialEntregaBE.Cantidad = jNet.get('txtCantEntrega').value;
					oStockMaterialEntregaBE.FechaEntrega= jNet.get('calFEntrega').value;
					if((jNet.get('hModo').value=='M')&&(jNet.get('hEstadoEntrega').value=="3")){//Por Coonfirmar la recepcion
						(new Controladora.SeguridadIndustrial.CCCTT_KardexPersona()).InsertarUpdate(oStockMaterialEntregaBE);
					}
					else if(jNet.get('hModo').value=='N'){
						(new Controladora.SeguridadIndustrial.CCCTT_KardexPersona()).InsertarUpdate(oStockMaterialEntregaBE);
					}
					else{
						Ext.MessageBox.alert('Validaci�n', 'La modificaci�n no se efectuo, el material ya fue  recepcionado y confirmado');
					}
					//Refresca
					AdministrarKardexPorPersona.CargarClaseMaterial(jNet.get('hCodTrabAct').value);
					if(DetalleMaterialDisponibledeEntrega!=null){DetalleMaterialDisponibledeEntrega.yo.close();}
					if(ListadoMaterialDisponibleDeEntrega.yo!=null){ListadoMaterialDisponibleDeEntrega.yo.close();}
					
				}
				catch(SIMAExcepcionDominio){
					Ext.MessageBox.alert('Validaci�n', SIMAExcepcionDominio.toString());
				}
				
				wHandle.close()
			}

			

			DetalleMaterialDisponibledeEntrega.onClose=function(hwind){
				try{
					if(ManagerProcess.InvocadoDesde==ManagerProcess.Enum.Opcion.LectoraBarra){
						ManagerProcess.TxtFindEnfocado=true;
						ManagerProcess.EnfocarTxtFind(1);
					}
						
				}
				catch(Error){
				}
			}
			
			function ConfigCampoFecha(){
					var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
						Ext.each(textBoxes, function(item, id, all){   
							var cl = new Ext.form.DateField({   
								format: 'd/m/Y',
								allowBlank : false,
								applyTo: item,
								width:80  
							});
						});   	
			}
			
			
			
			
			
			
			DetalleMaterialDisponibledeEntrega.Modificar=function(CodigoPersona,ClaseMaterial,CodigoEntrega,CodigoItem){
				var URLDISPONIBLEDETALLE = '/' + ApplicationPath + '/GestionSeguridadIndustrial/DetalleMaterialDisponibledeEntrega.aspx?';
				var params= KEYCODENTREGA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoEntrega
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + CodigoPersona
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ KEYQCLASEMAT + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  ClaseMaterial
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ KEYCODITEM + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual +  CodigoItem
							+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
							+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.M;
							
				DetalleMaterialDisponibledeEntrega.yo=(new System.Ext.UI.WebControls.Windows()).Detalle("MATERIAL ENTREGADO",URLDISPONIBLEDETALLE + params ,this,640,230,DetalleMaterialDisponibledeEntrega.Aceptar);
				window.setTimeout("ConfigCampoFecha();",800);
			}

			DetalleMaterialDisponibledeEntrega.Devolucion=function(CodEntrega,CantDevolver){
				var CantDevoOLD = CantDevolver;
				Ext.MessageBox.confirm('Actualizar Stock', 'Desea realizar la devoluci�n de este producto al Stock del almacen?', 
										function(btn){
											if(btn=="yes"){
												Ext.MessageBox.prompt('ACTUALIZA STOCK', 'ingrese la cantidad que desea realizar la devoluci�n:', 
																		function(btn, text){
																			if(btn=='ok'){
																				if(parseInt(text)<=	parseInt(CantDevolver)){
																					//Actualizar
																						
																				}
																				else{
																					Ext.MessageBox.alert('Validaci�n','No es posible realizar la anualci�n por que la cantidad(' + text + ') excede a lo entregado(' + CantDevolver  + ') ');
																				}
																			}
																		}
																		,true,20,CantDevolver);
											}
										}
									);
				//Ext.MessageBox.alert('Validaci�n', CodEntrega);
			}
			
			
			ListarMaterialesPorPersona.Eliminar=function(IdEntrega){
				Ext.MessageBox.confirm('Actualizar Stock', 'Desea realizar Eliminar registro de entrega ahora?', 
										function(btn){
											if(btn=="yes"){
												alert('Se enviara correo para su aprobacion de eliminaci�n :' +  IdEntrega);
											}
										}
									);

				
			}
		
			
		</script>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onunload="SubirHistorial();" onload="ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top">
						<TABLE style="WIDTH: 70%" id="Table2" border="0" cellSpacing="1" cellPadding="1" align="center">
							<TR>
								<TD align="center"><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Font-Size="X-Small" Font-Bold="True">REGISTRO DE EQUIPOS DE SEGURIDAD / EMERGENCIA UTILES DE ESCRITORIO, etc.</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD noWrap vAlign="top" colSpan="2">
												<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
													<TR>
														<TD rowspan="2" noWrap>
															<div class='ContextImg'>
																<IMG style="WIDTH: 64px; HEIGHT: 66px" class="imgCirc" alt="" src="/SimaNetWeb/imagenes/Navegador/EfectCircular.gif"
																	width="64" height="54"> <IMG style="WIDTH: 64px; HEIGHT: 64px" id="imgFoto" alt="" src="/SimaNetWeb/imagenes/Navegador/UserActivo.gif"
																	width="62" height="52">
															</div>
														</TD>
														<TD width="90%" vAlign="bottom" align="left">
															<asp:label style="Z-INDEX: 0" id="Label1" runat="server" Font-Bold="True" Font-Size="X-Small">APELLIDOS Y NOMBRES:</asp:label></TD>
														<TD width="5%" rowspan="2"><IMG style="Z-INDEX: 0" id="cmdEntregaMaterial" alt="" src="/SimaNetWeb/imagenes/Navegador/btnAgregarUsuario.png"
																height="50" runat="server" title="Entregar material"></TD>
													</TR>
													<TR>
														<TD width="90%" vAlign="top" align="left">
															<asp:textbox style="Z-INDEX: 0" id="txtBuscar" runat="server" BorderColor="Gray" BorderWidth="1px"
																Width="97%"></asp:textbox></TD>
													</TR>
												</TABLE>
											</TD>
											<TD style="PADDING-LEFT: 20px; HEIGHT: 64px" width="5%"><IMG style="Z-INDEX: 0" id="imgEntregaxLectora" title="Entregar material" alt="" src="/SimaNetWeb/imagenes/Navegador/btnCodBarra.gif"
													height="50" runat="server"></TD>
											<TD style="PADDING-LEFT: 30px" width="50"></TD>
											<TD style="PADDING-LEFT: 30px" width="100%"><IMG style="Z-INDEX: 0" id="ImgConfirma" title="Confirma recepci�n de materiales" 
													alt="" src="/SimaNetWeb/imagenes/Navegador/AprobarMarca.gif" height="50" runat="server"></TD>
											<TD width="100%" style="PADDING-LEFT: 30px"><IMG style="Z-INDEX: 0;display:none " id="imgAdmHuella" title="Admnistrar Huella" onclick="AdministrarKardexPorPersona.ConfirmarRecibido();"
													alt="" src="/SimaNetWeb/imagenes/Navegador/AdmHuella.gif" height="50" runat="server">&nbsp;
											</TD>
											<TD style="PADDING-LEFT: 30px" width="100%"><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/ibtnAtras.gif" style="width:50px;"></TD>
										</TR>
										<TR>
											<TD noWrap></TD>
											<TD width="100%">
												<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
													<TR>
														<TD>
															<asp:label style="Z-INDEX: 0" id="Label3" runat="server" Font-Bold="True" Font-Size="X-Small">ALMACEN:</asp:label></TD>
														<TD style="PADDING-LEFT: 5px" width="100%">
															<asp:label style="Z-INDEX: 0" id="lblAlmacen" runat="server" Font-Bold="True" Font-Size="X-Small">:</asp:label></TD>
														<TD style="PADDING-LEFT: 5px" width="100%"></TD>
														<TD style="PADDING-LEFT: 5px" width="100%" noWrap></TD>
													</TR>
												</TABLE>
											</TD>
											<TD width="100%"></TD>
											<TD width="100%" align="center"></TD>
											<TD width="100%" align="center"></TD>
											<TD width="100%" title="Agregar Materiales" align="center"></TD>
											<TD width="100%" align="center"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 23px" id="TabStrip"></TD>
							</TR>
							<TR>
								<TD></TD>
							</TR>
							<TR>
								<TD><INPUT style="WIDTH: 72px; HEIGHT: 22px" id="hLstClass" size="6" type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 22px" id="hCodTrabAct" size="6" type="hidden"
										name="Hidden1" runat="server" value="0"><INPUT style="WIDTH: 56px; HEIGHT: 22px" id="hCodArea" size="4" type="hidden" runat="server"><INPUT id="hRutaFoto" type="hidden" runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
			
			Ext.state.Manager.setProvider(new Ext.state.CookieProvider());
				var wTabPanel = new Ext.TabPanel({
							id:'tabMaster'
							,deferredRender:true
							,enableTabScroll: true
							,renderTo:'TabStrip'
							,width:window.screen.width-20
							,height:window.screen.height-130
							,activeTab:0
							,defaults:{autoScroll: true}
							,listeners: {'tabchange': function(tabPanel, tab){
															try{
																oTabClaseBE =  tab.BaseBE;
																AdministrarKardexPorPersona.IdTabSelected=tab.id;
																var NombreContext = "Context" + AdministrarKardexPorPersona.IdTabSelected;
																if(oTabClaseBE.Load==false){
																		var URLLOCAL = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionSeguridadIndustrial/ListarMaterialesPorPersona.aspx?" 
																		var params = KEYQCODPERSONA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oTabClaseBE.CodigoPersona 
																					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
																					+ KEYQCLASEMAT + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oTabClaseBE.CodigoClase;
																
																		jNet.get(NombreContext).load(URLLOCAL,params,function(Estado){});			
																	oTabClaseBE.Load=true;
																}
															} 
															catch(error){
																//Ext.MessageBox.alert('ERROR',  error.description, function(btn){});
															}
													}
										} 
										
						})
						
		
		
		
		var oParamCollecionBusqueda = new ParamCollecionBusqueda();
					var	oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre='ptrCodAnt';
						oParamBusqueda.Texto='Nro de Porta Retrato';
						oParamBusqueda.LongitudEjecucion=2;
						oParamBusqueda.Tipo='C';
						oParamBusqueda.CampoAlterno = 'ApellidosYNombres';
						oParamBusqueda.LongitudEjecucion=2;
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
						oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ptrCodTra";
							oParamBusqueda.Texto="Nro Personal 07";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.CampoAlterno="ApellidosYNombres";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
						oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ptrNRole";
							oParamBusqueda.Texto="Nro DNI";
							oParamBusqueda.LongitudEjecucion=5;
							oParamBusqueda.CampoAlterno="ApellidosYNombres";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="ApellidosYNombres";
							oParamBusqueda.Texto="Apellidos y Nombres";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.CampoAlterno="ptrCodAnt";
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);


						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre='idProceso';
						oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonaCriterioO7;
						oParamBusqueda.Tipo='Q';
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtBuscar')).CrearPopupOpcion('/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);
					
		
		</script>
		<script>
					
				var PathImgFinger = '/' + ApplicationPath + '/imagenes/Navegador/Finger/';	
				
				var Huella = new Object();
				Huella.Collection = new Array();
				
				Huella.Collection.add=function(oPersonaHuella){
					this[this.length]= new Array();
					this[this.length-1]=oPersonaHuella;
				}
				
				Huella.Collection.getMaxCalidad=function(){
					var oBE=null;
					var PorDefault=0;
					var Idx=0;
					var IndiceReturn = 0;
						for (var key in this){
							if (this[key] instanceof Function) {}
							else{
								var objBE = this[key];
								if(PorDefault<objBE.PorcCalidad){
									PorDefault=objBE.PorcCalidad;
									IndiceReturn=Idx;	
								}
								Idx++;
							}
						}
						oBE = this[IndiceReturn];
						this.removeAll();
						return oBE;
				}
				
				Huella.Collection.removeAll=function(){
					while(this.length){
						this.pop();
					}
				}
		

		
				SplahLecturaHuella.ActualizaConformidad=function(IdHuella){
					_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Stop);
					var oStockMaterialEntregaBE  = new EntidadesNegocio.GestionSeguridadIndustrial.StockMaterialEntregaBE();
						oStockMaterialEntregaBE.CodTrabajador = jNet.get('hCodTrabAct').value;
						/*Obtener Codigo de Huella*/
						oStockMaterialEntregaBE.CodigoHuella = SplahLecturaHuella.ObtenerCodigoHuella(IdHuella);
						(new Controladora.SeguridadIndustrial.CCCTT_KardexPersona()).ActEstMatRecepcionado(oStockMaterialEntregaBE);
						//Actualiza la lista de maeriales de la pantalla
						AdministrarKardexPorPersona.CargarClaseMaterial(jNet.get('hCodTrabAct').value);
						window.clearTimeout(IdPrcConformidad);
						SplahLecturaHuella.yo.close();
				}
		
				SplahLecturaHuella.ObtenerCodigoHuella=function(IdHuella){
					var strCodigo="";
					var oDataTable = (new Controladora.SeguridadIndustrial.CCCTT_Huella()).ListarPorTrabajador(oPersonalInfoBE.CodigoPersona);
					oDataTable.forEach(function(oDataRow){
										if(oDataRow.Item("ID_HUELLA").toString().Igual(IdHuella)){
											strCodigo=oDataRow.Item("COD_HUELLA");
										}
									});
					return strCodigo;
				}
		
		
		
				function ZKFinger4500_OnReader(Modo) {
					
				}
				function ZKFinger4500_OnInit(IdEstado) {
					if (IdEstado == _ZKFinger4500.Enum.ActiveX.Estado.Creado) {
						(new System.Ext.UI.WebControls.Windows()).loadMask(true,Ext.getBody(),'Creando componente activeX...',400);
					}
				}
			
				function ZKFinger4500_OnDetectarHuella(LaHuellaCambio){
					if(LaHuellaCambio==true){//Si detecta un cambio de huella
						if(ModoLecturadeHuella=='N'){
							_ZKFinger4500.VerificaHuella(oPersonalInfoBE.CodigoPersona);	
						}
						else{
							_ZKFinger4500.VerificaHuellaInColleccion();
						}
					}
				}
				
				var IdPrcConformidad=0;
				function ZKFinger4500_OnResultVerifica(oZKHuellaBE){
					if(ModoLecturadeHuella=='N'){
						if(NroMarca<=4){
							var nomImg = "imgHuella" + NroMarca;
							jNet.get(nomImg).src= oZKHuellaBE.PathImagen;
							for(var p=1;p<=4;p++){
								jNet.get('Img'+p).src = PathImgFinger + p + '.gif';
							}
							jNet.get('Img'+NroMarca).src=PathImgFinger + NroMarca + 'Select.gif';
							jNet.get('lbl'+NroMarca).innerText =  oZKHuellaBE.Calidad + '%';
							
							var oPersonalHuellaBE =  new EntidadesNegocio.Personal.PersonalHuellaBE();

							oPersonalHuellaBE.CodigoPersona = oPersonalInfoBE.CodigoPersona;
							oPersonalHuellaBE.IdHuella = oPersonalInfoBE.IdHuella;
							oPersonalHuellaBE.Huella1 = oZKHuellaBE.strBase64;
							oPersonalHuellaBE.Huella2 = 'Aqui debe ir HuellaCodificada';
							oPersonalHuellaBE.PorcCalidad=oZKHuellaBE.Calidad;
							oPersonalHuellaBE.Existe=oZKHuellaBE.IdEstado;
							oPersonalHuellaBE.IdVersion = oZKHuellaBE.IdVersion;	
							oPersonalHuellaBE.IdOrigen = 2;	
							Huella.Collection.add(oPersonalHuellaBE);
							//Cierre e inicializa
							_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Stop);	
							_ZKFinger4500.Reader(_ZKFinger4500.Enum.Reader.Modo.Init);
							
							NroMarca++;
						}
						else{
							Ext.MessageBox.alert('LECTURA DE HUELLA','Registro de huella no existe.');
						}						
					}
					else{
							var objHuellaContext = document.getElementById('tblHuella');
							objHuellaContext.rows[0].cells[0].style.display="none";
							objHuellaContext.rows[1].cells[0].style.display="block";
							var oIdHuellaSelect=oZKHuellaBE.Id;
							if (oZKHuellaBE.IdEstado == _ZKFinger4500.Enum.VerificaHuella.Estado.Existe) {//Ya existe
								document.getElementById("imgHuella").src = oZKHuellaBE.PathImagen;
								IdPrcConformidad=window.setTimeout("SplahLecturaHuella.ActualizaConformidad('" + oZKHuellaBE.Id + "');",800);
							}
							else if (oZKHuellaBE.IdEstado == _ZKFinger4500.Enum.VerificaHuella.Estado.NoExiste) {//Crear Huella
									document.getElementById("imgHuella").src = oZKHuellaBE.PathImagen;
									Ext.MessageBox.alert('Validaci�n','Registro de huella incorrecto o no existe',UnloadAlert);
							}
							else {
								Ext.MessageBox.alert('ERROR DE LECTURA','Lector de Huella no reconocido');
							}
					}
				}
				
				function ObtenerVersionHuella(oZKFingerUpHuellaBE){
						/*if((oZKFingerUpHuellaBE.Codigo==oPersonalInfoBE.CodigoPersona)&&(oZKFingerUpHuellaBE.IdHuella==oPersonalInfoBE.IdHuella)){
								oPersonalHuellaBE.IdVersion = oZKFingerUpHuellaBE.IdVersion;
						}*/
				}
				
				
				
				function UnloadAlert(btn){
					var objHuellaContext = document.getElementById('tblHuella');
						objHuellaContext.rows[0].cells[0].style.display="block";
						objHuellaContext.rows[1].cells[0].style.display="none";
				}
				
				function ZKFinger4500_OnStatus(oZKFingerDispositivo){
					document.getElementById("lblStatusScanHuella").innerHTML = oZKFingerDispositivo.HtmlStatus;
					if(oZKFingerDispositivo.IdStatus==_ZKFinger4500.Enum.Dispositivo.Estatus.Sensornotbeenconnected){
						jNet.get('imgHuellaScan').src='/' + ApplicationPath + '/imagenes/Navegador/Finger/Error1.gif';
						jNet.get('lblAviso').style.display="none";
					}
				}
				
				
				
				var _ZKFinger4500 = new ZKFinger4500();
				//Define las rutas de trabajo para la creacion y validacion de huellas
				_ZKFinger4500.PathFileHuellasIMG = "x:\\img\\";
				_ZKFinger4500.PathFileHuellasImgHTTP = "http://10.10.90.115/imgHuella/img/";
				_ZKFinger4500.PathFileHuellas = "x:\\Huella\\";
				_ZKFinger4500.PathFileHuellasTEMP = "x:\\tmp\\";
				_ZKFinger4500.Version=_ZKFinger4500.Enum.Huella.Version.v10;

				
				//Enlaza eventos
				_ZKFinger4500.EventHandle_Init = ZKFinger4500_OnInit;
				_ZKFinger4500.EventHandle_Reader = ZKFinger4500_OnReader;
				_ZKFinger4500.EventHandle_DetectarHuella = ZKFinger4500_OnDetectarHuella;
				_ZKFinger4500.EventHandle_ResultVerifica = ZKFinger4500_OnResultVerifica;
				_ZKFinger4500.EventHandle_Status = ZKFinger4500_OnStatus;
				_ZKFinger4500.Inicializa();

		</script>
	</body>
</HTML>
