<%@ Page language="c#" Codebehind="AdministrarFormatoDetalleMovimientoporPeriodoItem.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarFormatoDetalleMovimientoporPeriodoItem" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar movimiento de formato a nivel de items</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script>
		
			var KEYQIDFORMATO="idFormato";
			var KEYQIDRUBRO ="idRubro";
		
			var TIPONODOPRINCIPAL=0;
			var KEYQTIPONODOPRINCIPAL="TipoNodoPrincipal";
			var NODOSELECCIONADO="NodoSeleccionado";
			var KEYQNOMBREFORMATO="NFormato";
			var KEYQIDREPORTE = "IdReporte";
			var KEYQRUBRONOMBRE= "RubroNombre";
			var KEYQPERIODO = "Periodo";
			var KEYQREQCC ="ReqCC";
			
			var IDCENTROOPERATIVO="idcop";
			var KEYQIDCENTROCOSTO ="idCC";
			var KEYQIDTIPOINFO ="idTipoInfo";
			var KEYQNROFILAINI="NroFilaIni";
			
		</script>
		<script>
			function CollapseCol(e,DataGrid,Cell){
				var arrPath = e.src.toString().split('/');
				var Path = "/simanetweb/imagenes/tree/";
				
				var Icono = ((arrPath[arrPath.length-1]=="plusCol.gif")?"minusCol.gif":"plusCol.gif");
				var vista = ((arrPath[arrPath.length-1]=="plusCol.gif")?"block":"none");
				Cell.colSpan = ((arrPath[arrPath.length-1]=="plusCol.gif")?4:1);
				
				e.src= Path +Icono;
				
				for(var f=1;f<=DataGrid.rows.length-1;f++){
					for(c=parseInt(e.ColIni,10);c<=(parseInt(e.ColIni,10)+2);c++){
						var idxCell = ((f==1)?c-1:c);
						DataGrid.rows[f].cells[idxCell].style.display=vista;
					}
				}				
			}
			function OnClickCollpase(){
				var oNPluMinus = $O('hNombreImgTrim');
				var oimg = $O(oNPluMinus.value);
				CollapseCol(oimg,$O('grid'),oimg.parentElement.parentElement.parentElement.parentElement.parentElement);
			}
		</script>
		<script>//Para el calculo de 
		var NroRowIni = 2;
		var EstadodeValorActual = false;
		function AsignarEventodeSalidayCambio(){
				var DataGrid = $O("grid");
				for(var f=NroRowIni;f<=DataGrid.rows.length-1;f++){
					for(var c=1;c<=16;c++){
						if((c>=1 && c<=3)||(c>=5 && c<=7)||(c>=9 && c<=11)||(c>=13 && c<=15)){
							var oNumericMonto = DataGrid.rows[f].cells[c].children[0]; 
							oNumericMonto.cellIndex = c;
							oNumericMonto.rowIndex = f;
							oNumericMonto.onblur =NewonBlur;
							oNumericMonto.onchange = CuandoCambiaValor;
						}
					}
				}
			}
			//Asigna al Objeto Numerico el Evento de cambio OnChange para detectar algun cambio en los montos
			function CuandoCambiaValor(){EstadodeValorActual = true;}
			//Evento que se desencadena al Momento de perder el foco el Obj Numerico
			function NewonBlur(){
				NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true){ 
					//Guardar en la base de datos
					var DataGrid = $O('grid');
					var idReg=DataGrid.rows[this.rowIndex].IDDETDESFMTCC;
					var idMes = this.idMes;
					this.tag = this.value.replace(",","");
					var Monto = ObtenerMontoTotal(DataGrid,this);
					//Actualiza en la base de datos
					Modificar(idReg,idMes,this.tag);
					//Actualizacion remota.
					MandarActualizacionRemota(this,Monto);				
					EstadodeValorActual = false;
				}
			}
			
			function MandarActualizacionRemota(e,Monto){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var DATA ={NombreNumericMonto:"",value:0};
					var arrNombre = e.id.toString().split('_');
					DATA.NombreNumericMonto=arrNombre[0] + "__ctl" + oPagina.Request.Params[KEYQNROFILAINI] + "_" + arrNombre[arrNombre.length-1];
					DATA.value=Monto;
					var VentanaRemota = window.opener;
					VentanaRemota.document.body.Tag = "Remoto";
					VentanaRemota.document.body.DATA = DATA;//Envia la data
					VentanaRemota.document.body.onclick();//inicia el calculo remoto en el web form que llamo
			}

			function ObtenerMontoTotal(DataGrid,e){
				var Acumulado=0;
				for(var f=NroRowIni;f<=DataGrid.rows.length-1;f++){
					if(parseInt(DataGrid.rows[f].IDDETDESFMTCC,10)==0)return Acumulado;
					var idxCell = e.cellIndex;
					var objNB=DataGrid.rows[f].cells[idxCell].children[0];
					Acumulado += parseFloat(objNB.tag);
				}
				return 	Acumulado;
			}
			
			function EnfocarSiguienteCelda(e){
				var keyEnter = 13;
				var keyTab= 9;
				var keyUp= 38;
				var keyDown= 40;
				//Considerado para la navegacion hacia abajo
				var DataGrid = $O("grid");
				
				DataGrid.EnfocarAbajo=function(){
					try{
						var objNBSiguiente =  this.rows[idxrowAbajo].cells[idxcell].children[0];
						objNBSiguiente.focus();
					}
					catch(error){
					}
				}
				DataGrid.EnfocarArriba=function(){
					try{
						var objNBSiguiente =  this.rows[idxrowArriba].cells[idxcell].children[0];
						objNBSiguiente.focus();
					}
					catch(error){}
				}
				DataGrid.EnfocarDerecha=function(){
					try{
						var objNBSiguiente =  this.rows[idxrow].cells[idxcellDerecha].children[0];
						objNBSiguiente.focus();
					}
					catch(error){}
				}
				//Establece el valor ingresado a la propiedad que sera utilizada para el calculo
				e.tag = e.value;
				var idxrow = e.rowIndex;
				var idxcell = e.cellIndex;  
				
				
				
				var idxrowArriba = ((idxrow == NroRowIni)?NroRowIni:idxrow-1) ;  
				var idxrowAbajo = ((idxrow == DataGrid.rows.length-1)?NroRowIni:idxrow+1) ;  
				
				var idxcellDerecha = 0;
				if(e.parentElement.cellIndex==15){idxcellDerecha=1;}
				else if((idxcell==3)||(idxcell==7)||(idxcell==11)){idxcellDerecha = idxcell+2;}
				else{idxcellDerecha = idxcell+1;}
					
				var idxcellIzquierda = ((e.parentElement.cellIndex==1)?1:e.parentElement.cellIndex-1);  
				//Ejecuta el desplazamiento
				if (event.keyCode==keyEnter || event.keyCode==keyDown){DataGrid.EnfocarAbajo();}
				else if(event.keyCode==keyTab){DataGrid.EnfocarDerecha();}
				else if (event.keyCode==keyUp){DataGrid.EnfocarArriba();}
			}
		</script>
		<script>
			function txtBuscar_ItemDataBound(sender,e,dr){
				Agregar(dr["idDetDesFmtCC"].toString());
			}
			function AgregarDescripcion(){
				var otxtBuscar = $O('txtBuscar');
				if(confirm("Desea crear una nueva descripcion para luego usarlo en la especificacion del formato")==true){
					var oFormatoDetalleMovimientoDescripcionItemBE = new EntidadesNegocio.General.FormatoDetalleMovimientoDescripcionItemBE();
					oFormatoDetalleMovimientoDescripcionItemBE.Descripcion = otxtBuscar.value;
					Agregar((new Controladora.General.CFormatoDetalleMovimientoDescripcionItem()).Insertar(oFormatoDetalleMovimientoDescripcionItemBE));
					otxtBuscar.value="";
				}
			}
			function Agregar(idReg){
					HabilitarFilaEditable(idReg);
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oFormatoDetalleMovimientoCentroCostoItemBE = new EntidadesNegocio.General.FormatoDetalleMovimientoCentroCostoItemBE();
					oFormatoDetalleMovimientoCentroCostoItemBE.IdDetDesFmtCC=idReg;
					oFormatoDetalleMovimientoCentroCostoItemBE.Idformato = oPagina.Request.Params[KEYQIDFORMATO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idreporte = 1;
					oFormatoDetalleMovimientoCentroCostoItemBE.Idrubro = oPagina.Request.Params[KEYQIDRUBRO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idcentrooperativo = oPagina.Request.Params[IDCENTROOPERATIVO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idcentrocosto = ((parseInt(oPagina.Request.Params[KEYQREQCC],10)==0)?-1:oPagina.Request.Params[KEYQIDCENTROCOSTO]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idtipoinformacion =oPagina.Request.Params[KEYQIDTIPOINFO];
				(new Controladora.General.CFormatoDetalleMovimientoCentroCostoItem()).Insertar(oFormatoDetalleMovimientoCentroCostoItemBE);
			}

			function Modificar(idReg,idMes,Monto){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oFormatoDetalleMovimientoCentroCostoItemBE = new EntidadesNegocio.General.FormatoDetalleMovimientoCentroCostoItemBE();
					oFormatoDetalleMovimientoCentroCostoItemBE.IdDetDesFmtCC=idReg;
					oFormatoDetalleMovimientoCentroCostoItemBE.Idformato = oPagina.Request.Params[KEYQIDFORMATO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idreporte = 1;
					oFormatoDetalleMovimientoCentroCostoItemBE.Idrubro = oPagina.Request.Params[KEYQIDRUBRO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idcentrooperativo = oPagina.Request.Params[IDCENTROOPERATIVO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idcentrocosto =((parseInt(oPagina.Request.Params[KEYQREQCC],10)==0)?-1:oPagina.Request.Params[KEYQIDCENTROCOSTO]);
					oFormatoDetalleMovimientoCentroCostoItemBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Idmes = idMes;
					oFormatoDetalleMovimientoCentroCostoItemBE.Idtipoinformacion =oPagina.Request.Params[KEYQIDTIPOINFO];
					oFormatoDetalleMovimientoCentroCostoItemBE.Montomes = Monto;
				(new Controladora.General.CFormatoDetalleMovimientoCentroCostoItem()).Modificar(oFormatoDetalleMovimientoCentroCostoItemBE);
			}
			
			function HabilitarFilaEditable(id){
				var DataGrid = $O("grid");
					for(var f=NroRowIni;f<=DataGrid.rows.length-1;f++){
						if(parseInt(DataGrid.rows[f].IDDETDESFMTCC,0)==0){
							DataGrid.rows[f].IDDETDESFMTCC = id;
							DataGrid.rows[f].cells[0].innerText= $O('txtBuscar').value;
							DataGrid.rows[f].style.display="block";
							return;
						}
					}
			
			}
		</script>
	</HEAD>
	<body onkeydown="if((event.keyCode==13)||(event.keyCode==9)){return false;}" onload="AsignarEventodeSalidayCambio();OnClickCollpase();"
		bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD style="HEIGHT: 39px" align="center" bgColor="#000080">
						<asp:Label id="lblRubro" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White"></asp:Label></TD>
				</TR>
				<TR>
					<TD align="left" style="HEIGHT: 18px" bgColor="#dcdcdc">
						<TABLE style="Z-INDEX: 0; WIDTH: 640px; HEIGHT: 32px" id="Table2" border="0" cellSpacing="0"
							cellPadding="0" width="640" align="left">
							<TR>
								<TD style="WIDTH: 102px" class="headerDetalle">
									<asp:Label id="Label1" runat="server" Font-Bold="True">CONCEPTO:</asp:Label></TD>
								<TD style="WIDTH: 384px">
									<asp:TextBox id="txtBuscar" runat="server" Width="100%"></asp:TextBox></TD>
								<TD><INPUT id="ibtnAgregar" value="Agregar" type="button" onclick="AgregarDescripcion();" style="WIDTH: 64px; HEIGHT: 24px"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="left"><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="Descripcion" HeaderText="CONCEPTO">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ENERO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nEnero" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="FEBRERO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nFebrero" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MARZO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nMarzo" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="TOTAL">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="ABRIL">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nAbril" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MAYO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nMayo" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="JUNIO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nJunio" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="TOTAL">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="JULIO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nJulio" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="AGOSTO">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nAgosto" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="SETIEMBRE">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nSetiembre" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="TOTAL">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="OCTUBRE">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nOctubre" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="NOVIEMBRE">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nNoviembre" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DICIEMBRE">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemTemplate>
										<ew:numericbox style="Z-INDEX: 0" id="nDiciembre" runat="server" Width="104px" PlacesBeforeDecimal="15"
											TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
											DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True" CssClass="normaldetalle"></ew:numericbox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn HeaderText="TOTAL">
									<HeaderStyle Width="4.3%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><INPUT style="DISPLAY: none" id="txtDescripcion"><asp:label id="lblResultado" runat="server"></asp:label><INPUT style="WIDTH: 85px; HEIGHT: 22px" id="hidFilaSeleccionada" size="8" type="hidden"><INPUT style="WIDTH: 77px; HEIGHT: 22px" id="hNroNivel" size="7" type="hidden"><INPUT style="Z-INDEX: 0; WIDTH: 77px; HEIGHT: 22px" id="hNombreImgTrim" size="7" type="hidden"
							name="Hidden1" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
				var KEYQNOMBRE="Nombre";
				var KEYIDTIPOLETRA = "TipoLetra";
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
				var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="Descripcion";
					oParamBusqueda.Texto="Concepto";
					oParamBusqueda.LongitudEjecucion=2;
					oParamBusqueda.Tipo="C";
					oParamBusqueda.Ancho=100;
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ListarFormatoMovimientoDescripcionItem;
					oParamBusqueda.ParaBusqueda=false;
					oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

				(new AutoBusqueda('txtBuscar')).Crear('/' + ApplicationPath + '/General/Procesar.aspx?',oParamCollecionBusqueda);
		
		</SCRIPT>
	</body>
</HTML>
