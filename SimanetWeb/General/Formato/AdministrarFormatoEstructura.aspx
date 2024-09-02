<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarFormatoEstructura.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarFormatoEstructura" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>AdministrarFormato</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<!--<SCRIPT language="javascript" src="http://localhost/SimanetJS/DragDrop/TableRow/tablednd.js"></SCRIPT>-->
		<style>.ContextImg { Z-INDEX: 3; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; POSITION: relative; HEIGHT: 45px }
	.imgCirc { Z-INDEX: 1; BACKGROUND-REPEAT: no-repeat; POSITION: absolute; TOP: -2px; left-30: }
	</style>
		<script>
			var jSIMA = jQuery.noConflict();			
		</script>
		<script>
		
			var TIPONODOPRINCIPAL=0;
			var KEYQTIPONODOPRINCIPAL="TipoNodoPrincipal";
			var NODOSELECCIONADO="NodoSeleccionado";
			var KEYQIDFORMATO="IdFormato";
			var KEYQIDRUBRO="IdRubro";
			var KEYQNOMBREFORMATO="NFormato";
			var KEYQIDREPORTE = "IdReporte";
			var KEYQRUBRONOMBRE= "RubroNombre";
			var KEYQPERIODO = "Periodo";
			var KEYQNROORDEN="Orden";
			var KEYQNRONIVEL="NroNivel";
			var URLPAGINA =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/DetalleRubro.aspx?";
			var URLLISTAUSUARIO =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/ListaUsuarioFormatoPrivilegio.aspx?";
			
			
			var URLPAGINAFORMUALCONTABLE =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/GestionFinanciera/EstadosFinancieros/AdministrarFormulaFinanciera.aspx?";
			
			var URLPAGINANOTACONTABLE =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarRelacionFormatoRubroNotaContab.aspx?";
			var URLPAGINAFORMULAENTRERUBROS =  SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/FormulaOperacionesEntreRubros.aspx?";
			var URLPAGINAFORMATOSDISPONIBLES = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/ListarFormatosDisponibles.aspx?";
			var oRow;
			
			
			function AgregarNodo(){
				if(TIPONODOPRINCIPAL.toString().Igual('0')==true){
					if($O('hidFilaSeleccionada').value.length==0){window.alert("Seleccionar un nivel o nodo"); return false;}
					var oDataGrid = $O('grid');
					oRow = oDataGrid.rows[$O('hidFilaSeleccionada').value];
				}
				else{
					oRow = null;
				}
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros = "";
				with(SIMA.Utilitario.Constantes.General.Caracter){
					Parametros = KEYQIDFORMATO + SignoIgual + oPagina.Request.Params[KEYQIDFORMATO] 
								+ signoAmperson 
								+ KEYQNOMBREFORMATO + SignoIgual + oPagina.Request.Params[KEYQNOMBREFORMATO] 
								+ signoAmperson 
								+ KEYQNRONIVEL + SignoIgual + ((oRow==null)?"99":oRow.NRONIVEL + '.' + oRow.IDULTNIVELNEW)
								+ signoAmperson 
								+ KEYQTIPONODOPRINCIPAL + SignoIgual +  TIPONODOPRINCIPAL
								+ signoAmperson 
								+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.N;
				}
				oPagina.Response.ShowDialogoModal(URLPAGINA + Parametros,580,280);
				ActualizarPagina();
			}

			function ModificarNodo(){
				var oDataGrid = $O('grid');
				var oRow = oDataGrid.rows[$O('hidFilaSeleccionada').value];
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros = "";
				with(SIMA.Utilitario.Constantes.General.Caracter){
					Parametros = KEYQIDFORMATO + SignoIgual + oPagina.Request.Params[KEYQIDFORMATO] 
								+ signoAmperson 
								+ KEYQNOMBREFORMATO + SignoIgual + oPagina.Request.Params[KEYQNOMBREFORMATO] 
								+ signoAmperson 
								+ KEYQIDRUBRO + SignoIgual +  oRow.IDRUBRO
								+ signoAmperson 
								+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.M;
				}
				oPagina.Response.ShowDialogoModal(URLPAGINA + Parametros,580,280);
				ActualizarPagina();
				
			}
			
			function ActualizarPagina(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oPagina.Request.Params.Remove(oPagina,NODOSELECCIONADO);
				oPagina.Url = oPagina.Url + SIMA.Utilitario.Constantes.General.Caracter.signoAmperson + NODOSELECCIONADO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + $O('hNroNivel').value;
				window.location.href=oPagina.Url;
			}
			
			function ObtenerRowId(e){
				TIPONODOPRINCIPAL=0;
				return e.rowIndex;
				//return e;
			}
	
			function RestauraNodoSeleccionado(){
				try{
					var oDataGrid = $O("grid");
					oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var NodoValor = oPagina.Request.Params[NODOSELECCIONADO];
					if (NodoValor!= undefined){
						var arrNiveles = NodoValor.split(".");
						var UltElemento = arrNiveles.length-1;
						var Indice=0;
						var stNivelFind =ElaborarNiveles(Indice,arrNiveles);
						for(var Fila=1;Fila<=oDataGrid.rows.length-1;Fila++){
							if (oDataGrid.rows[Fila].NRONIVEL.toString().Igual(stNivelFind)==true){
								if (Indice<UltElemento){
									var objTblNodo = oDataGrid.rows[Fila].cells(0).children[0];
									objTblNodo.Click=function(){
										var ObjImg = this.rows[0].cells[(this.rows[0].cells.length-3)].children[0];
										ObjImg.onclick();
										objTblNodo.parentElement.parentElement.onclick();
									}
									objTblNodo.Click();
									Indice++;
									stNivelFind =ElaborarNiveles(Indice,arrNiveles);
								}
							}
						}
					}
				}
				catch(error){
					TIPONODOPRINCIPAL=0;
				}
			}
			
			function ElaborarNiveles(Indice,arrNiveles){
				var stNivelFind="";
				for(var i=0;i<=Indice;i++){	stNivelFind += arrNiveles[i] + ".";}
				return stNivelFind.substring(0,stNivelFind.length-1);
			}	
			function ModificarDescripcion(){
				var RowIndex=$O('hidFilaSeleccionada').value;
				var oDataGrid = $O('grid');
				var oRow = oDataGrid.rows[RowIndex];
				var oNodo = oRow.children[0].children[0];
				var CellNodoText=oNodo.rows[0].cells[oNodo.rows[0].cells.length-1];
				var otxtDescripcion = $O('txtDescripcion');
				otxtDescripcion.style.position="absolute";
				otxtDescripcion.style.left = tableDnD.getPosition(CellNodoText).x;
				otxtDescripcion.style.top = tableDnD.getPosition(oRow).y;
				otxtDescripcion.style.width = CellNodoText.offsetWidth;
				otxtDescripcion.style.height = oRow.offsetHeight;
				otxtDescripcion.style.display="block";
				otxtDescripcion.CellNodoText = CellNodoText;
				otxtDescripcion.CellNodoAttr = oRow;
				otxtDescripcion.className="normaldetalle";
				otxtDescripcion.focus();
				otxtDescripcion.value = CellNodoText.innerText;
				
				otxtDescripcion.onblur=function(){
					this.style.display="none";
				}
				otxtDescripcion.onkeydown=function(){
					if(event.keyCode==13){
						var oFormatoEstructuraBE = EstablecerData(this.CellNodoAttr,this.value);//new EntidadesNegocio.General.FormatoEstructuraBE();
						oFormatoEstructuraBE.Idestado = 1;
						if((new Controladora.General.CFormatoEstructura()).Modificar(oFormatoEstructuraBE)==1){
							this.CellNodoText.innerText =this.value;	
						}									
						this.style.display="none";
					}
					else if(event.keyCode==27){
						this.style.display="none";
					}
				}
			}
			
			function EstablecerData(oRow,Texto){
				var oFormatoEstructuraBE = new EntidadesNegocio.General.FormatoEstructuraBE();
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oFormatoEstructuraBE.Idformato= oPagina.Request.Params[KEYQIDFORMATO];
				oFormatoEstructuraBE.Idrubro= oRow.IDRUBRO;
				oFormatoEstructuraBE.Nombre = Texto;
				oFormatoEstructuraBE.Idtipolinea = oRow.IDTIPOLINEA;
				oFormatoEstructuraBE.Flgvermonto = oRow.VERMONTO;
				oFormatoEstructuraBE.Idprioridad = oRow.PRIORIDAD;
				return oFormatoEstructuraBE;
			}
			
			function EliminarRubro(){
				if(confirm("Desea ud. eliminar este rubro ahora?")==true){
					var oDataGrid = $O('grid');
					var RowIndex=$O('hidFilaSeleccionada').value;
					var oRow = oDataGrid.rows[RowIndex];
					var oNodo = oRow.children[0].children[0];
					var CellNodoText=oNodo.rows[0].cells[oNodo.rows[0].cells.length-1];
					var oFormatoEstructuraBE = EstablecerData(oRow,CellNodoText.innerText);
					oFormatoEstructuraBE.Idestado = 0;
					if((new Controladora.General.CFormatoEstructura()).Eliminar(oFormatoEstructuraBE)==1){
						document.location.reload();//Se elimino rubro
					}
				}
			}	
						
			function DocumentoOnKeyDown(){
				if(event.keyCode==113){
					ModificarDescripcion();
				}
			}
		</script>
		<script>
			var Ventana;
			function FormulaPorRubro(oRow){
				var KEYQPRIODIRDAD="IdPrioridad";
				var KEYQNROFILAINI="NroFilaIni";
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros = "";
				with(SIMA.Utilitario.Constantes.General.Caracter){
					Parametros = KEYQIDFORMATO + SignoIgual + oPagina.Request.Params[KEYQIDFORMATO] 
								+ signoAmperson 
								+ KEYQNOMBREFORMATO + SignoIgual + oPagina.Request.Params[KEYQNOMBREFORMATO] 
								+ signoAmperson 
								+ KEYQRUBRONOMBRE + SignoIgual + oRow.NOMBRE
								+ signoAmperson 
								+ KEYQIDRUBRO + SignoIgual +  oRow.IDRUBRO
								/*+ signoAmperson 
								+ KEYQPRIODIRDAD + SignoIgual +  oRow.PRIORIDAD*/
								+ signoAmperson 
								+ KEYQNROORDEN + SignoIgual +  oRow.ORDEN
								+ signoAmperson 
								+ KEYQNROFILAINI + SignoIgual + oRow.rowIndex;
				}
				if(Ventana==undefined){
					Ventana = (new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(URLPAGINAFORMULAENTRERUBROS + Parametros,460,410);
				}
				else{
					try{
						if(Ventana.document.location.href){}
					}
					catch(error){
						Ventana = (new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(URLPAGINAFORMULAENTRERUBROS + Parametros,460,410);
					}
				}
			}
			
			function FormulaPorCuentas(oRow){
				var FormulaEntreRubro=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'FormRxR');
				if(FormulaEntreRubro==1){return false;}
				
				var KEYQIDGRUPOFORMATOINTERCONEX="IdGpInterConex";
				var KEYQIDFORMATOCONECTADO="IdFormatoConec";
				var KEYQIDREPORTECONECTADO="IdReporteConec";
				
				var KEYQREQCTATABLE="ReqCta";
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros = "";
				with(SIMA.Utilitario.Constantes.General.Caracter){
					Parametros = KEYQIDFORMATO + SignoIgual + oPagina.Request.Params[KEYQIDFORMATO] 
								+ signoAmperson 
								+ KEYQIDREPORTE + SignoIgual + oPagina.Request.Params[KEYQIDREPORTE] 
								+ signoAmperson 
								+ KEYQNOMBREFORMATO + SignoIgual + oPagina.Request.Params[KEYQNOMBREFORMATO] 
								+ signoAmperson 
								+ KEYQIDRUBRO + SignoIgual +  oRow.IDRUBRO
								+ signoAmperson 
								+ KEYQRUBRONOMBRE + SignoIgual + ""
								+ signoAmperson 
								+ KEYQPERIODO + SignoIgual + oPagina.Request.Params[KEYQPERIODO]
								+ signoAmperson 
								+ KEYQIDGRUPOFORMATOINTERCONEX + SignoIgual + oRow.IDGRUPOINTERCONEX
								+ signoAmperson 
								+ KEYQIDFORMATOCONECTADO + SignoIgual + oRow.IDFORMATOCONECTADO
								+ signoAmperson 
								+ KEYQIDREPORTECONECTADO + SignoIgual + oRow.IDREPORTECONECTADO;
								
				}
				
				HistorialIrAdelante();
				
			
				var urlDestino ="";
				if(oPagina.Request.Params[KEYQREQCTATABLE]=="1"){
					urlDestino = URLPAGINAFORMUALCONTABLE;
				} 
				else if(oPagina.Request.Params[KEYQREQCTATABLE]=="2"){
					urlDestino = URLPAGINANOTACONTABLE;
				}
				else{
					urlDestino = URLPAGINAFORMATOSDISPONIBLES;
				}
				
				(new SIMA.Utilitario.Helper.Response()).ShowDialogoOnTop(urlDestino + Parametros,700,400);
			
			}
			
			function AgregarRubroAFormula(e){
				var FormulaEntreRubro=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'FormRxR');			
				if(FormulaEntreRubro==0){return false;}
				
				
				var NodoTree = e.cells[0].children[0];
				var TextNodo = NodoTree.rows[0].cells[NodoTree.rows[0].cells.length-1].innerText;
				var obody = Ventana.frames.document.body;
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oFormatoFormulaBE = new EntidadesNegocio.General.FormatoFormulaBE();
					oFormatoFormulaBE.Idformato = oPagina.Request.Params[KEYQIDFORMATO];
					oFormatoFormulaBE.Idrubrodestino = e.IDRUBRO;
					oFormatoFormulaBE.IdOperadorMat= 0;
					oFormatoFormulaBE.Orden = 0;
					oFormatoFormulaBE.Idestado =1;
				//Transporta los datos a la ventana remota
				obody.Tag="Remoto";
				obody.DATOS ={Texto:TextNodo,BaseBE:oFormatoFormulaBE};
				obody.onclick();
			}	
			
			function AgregarPrivilegioAUsuario(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros = KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDFORMATO];
			
					var URLDETALLETRABAJADOR = '/' + ApplicationPath + '/General/Formato/AdministrarPrivilegiosAFormatos.aspx?' + Parametros;
					(new SIMA.Utilitario.Helper.Response()).ShowDialogoModal(URLDETALLETRABAJADOR,600,300,this);
					
					LoadUsuarioProvilegio()
					//if(localStorage.getItem("IDAREAD")!=null){
			}
			
			function ErrorLoadImg(e,PathyFotos){
				try{
					e.src = PathyFotos;
				}catch(Error){
					alert(Error);
					e.src = '/SimanetWeb/imagenes/Navegador/UnChecked.png';
				}
			}			
			
			function CargarPrivilegios(e){
				var KEYQIDUSUARIO="IdUser";
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var Parametros = KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + oPagina.Request.Params[KEYQIDFORMATO]
								+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
								+ KEYQIDUSUARIO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + e.id;
			
					var URLDETALLETRABAJADOR = '/' + ApplicationPath + '/General/Formato/AdministrarPrivilegiosAFormatos.aspx?' + Parametros;
					(new SIMA.Utilitario.Helper.Response()).ShowDialogoModal(URLDETALLETRABAJADOR,600,300,this);
				
			}
			
			
		</script>
</HEAD>
	<body onkeydown="DocumentoOnKeyDown();" onunload="SubirHistorial();" onload="RestauraNodoSeleccionado();ObtenerHistorial();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD align="left">
						<table border="0">
							<tr>
								<td align="left">
									<TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" align="left">
										<TR>
											<TD><IMG style="WIDTH: 32px; HEIGHT: 32px" id="ibtnAgregar" title="Agregar Concepto"
													onclick="AgregarNodo();" src="../../imagenes/Navegador/Plus.png" width="32" height="32">
											</TD>
											<TD style="FONT-SIZE: 15pt; WIDTH: 11px" vAlign="top">|</TD>
											<TD><IMG id="ibtnEliminar" title="Eliminar Concepto" onclick="EliminarRubro();" src="../../imagenes/Navegador/Minus.png"
													height="32"></TD>
										</TR>
									</TABLE>
								</td>
								<td style="BORDER-RIGHT: powderblue 1px solid; BORDER-TOP: powderblue 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 10pt; BORDER-LEFT: powderblue 1px solid; WIDTH: 100%; CURSOR: hand; BORDER-BOTTOM: powderblue 1px solid; HEIGHT: 28px"
									id="LstUser" align="center" runat="server"></td>
								<td><IMG style="WIDTH: 32px; HEIGHT: 32px" id="ibtnPrivilegios" title="Asignar privilegios"
										onclick="AgregarPrivilegioAUsuario();" src="../../imagenes/Navegador/btnAgregarUsuario.gif"
										width="32" height="32">
								</td>
							</tr>
						</table>
					</TD>
				</TR>
				<TR>
					<TD id="LstUserOld" align="center" runat="server"></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center"><cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Concepto" HeaderText="CONCEPTO">
									<HeaderStyle Width="60%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="FORM">
									<HeaderStyle Font-Bold="True" Width="2%"></HeaderStyle>
									<ItemStyle Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<ItemTemplate>
										<IMG id="ibtnFormula" alt="" src="../../imagenes/BtPU_Mas.gif" runat="server">
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="NOTA">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><INPUT style="DISPLAY: none" id="txtDescripcion"><asp:label id="lblResultado" runat="server"></asp:label><INPUT style="WIDTH: 85px; HEIGHT: 22px" id="hidFilaSeleccionada" size="8" type="hidden"><INPUT style="WIDTH: 77px; HEIGHT: 22px" id="hNroNivel" size="7" type="hidden"></TD>
				</TR>
				<TR>
					<TD align="center"></TD>
				</TR>
			</TABLE>
			<script>
			
				function OnDropGridRow(sender){
					var  oGrid = $O(sender);
					window.alert(oGrid.oRowSource.PRIORIDAD);
				}
				
				function ActualizarOrden(NroNivel,idNivel){
					var Orden=0;
					var oGrid = $O('grid');
					for(var i=1;i<=oGrid.rows.length-1;i++){
						var xRow = oGrid.rows[i];
						if((xRow.NRONIVEL.substring(0,NroNivel.length)==NroNivel)&&(xRow.NIVEL==idNivel)){
							oPagina = new SIMA.Utilitario.Helper.General.Pagina();
							var oFormatoEstructuraBE = new EntidadesNegocio.General.FormatoEstructuraBE();
							oFormatoEstructuraBE.Idformato =  oPagina.Request.Params[KEYQIDFORMATO];
							oFormatoEstructuraBE.Idrubro = xRow.IDRUBRO;
							oFormatoEstructuraBE.Orden = Orden;
							(new Controladora.General.CFormatoEstructura()).ModificarOrden(oFormatoEstructuraBE);
							Orden++;
						}
					}
				}
				
				
				
				
				function OnDetalleRows(){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oGrid = $O('grid');
					for(var i=2;i<=oGrid.rows.length-1;i++){
							var xRow = oGrid.rows[i];
							var tbl = xRow.cells[0].children[0];
							var CellTxt = tbl.rows[0].cells[tbl.rows[0].cells.length-1];
							//jSIMA(CellTxt).css({"color": "red", "border": "2px solid red"});
							jSIMA(CellTxt).attr("NRONIVEL",jSIMA(xRow).attr("NRONIVEL"));
							jSIMA(CellTxt).attr("IDRUBRO",jSIMA(xRow).attr("IDRUBRO"));
							jSIMA(CellTxt).attr("ItemRow",xRow );
							
							jSIMA(CellTxt).dblclick( function(event) {
									var FormulaEntreRubro=jSIMA.GetClientData(SIMA.Utilitario.Enumerados.TipoSaveClient.Local,'FormRxR');			
									if(FormulaEntreRubro==1){var mRow = jSIMA(this).attr("ItemRow"); AgregarRubroAFormula(mRow);return false;}
									

									var NroNivel = jSIMA(this).attr("NRONIVEL"); 
									var IdRubro = jSIMA(this).attr("IDRUBRO"); 
									with(SIMA.Utilitario.Constantes.General.Caracter){
										Parametros = KEYQIDFORMATO + SignoIgual + oPagina.Request.Params[KEYQIDFORMATO] 
													+ signoAmperson 
													+ KEYQNOMBREFORMATO + SignoIgual + oPagina.Request.Params[KEYQNOMBREFORMATO] 
													+ signoAmperson 
													+ KEYQIDRUBRO + SignoIgual + IdRubro
													+ signoAmperson 
													+ SIMA.Utilitario.Constantes.KEYMODOPAGINA + SignoIgual + SIMA.Utilitario.Enumerados.ModoPagina.M;
									}									
									oPagina.Response.ShowDialogoModal(URLPAGINA + Parametros,580,280);
									
								});
							
							//oPagina.Response.ShowDialogoModal(URLPAGINA + Parametros,560,200);						
					}			
			}
			
		
				
				OnDetalleRows();
				
			</script>
		</form>
		<script>
			function LoadUsuarioProvilegio(){	
				var params = KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Page.Request.Params[KEYQIDFORMATO];
				function Resultado(Estado){}
				jNet.get("LstUser").load(URLLISTAUSUARIO,params,Resultado);
			}
			LoadUsuarioProvilegio();
		
		</script>
	</body>
</HTML>
