<%@ Page language="c#" Codebehind="DetalleInversiones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones.DetalleInversiones" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<script>
			function txtCol_onKeyDown(){
				ObjetoProximo(window.event.keyCode,window.event.srcElement.id);
			}
			
			function ObjetoProximo(_keyCode,objActual){
				var NombreObjProx="grid__";				
				var CarFila = "ctl";
				var CarCol = "txtCol"
				//la Posicion 2 y 3 Obtienen los datos necesarios para saltar de un obj a otro
				var arrDato = objActual.split('_');
				var Nro=0;
				var NroProx;
				try{
					switch(_keyCode){
						case 37://Izquierda
							NroProx = arrDato[3].toString().replace(CarCol,'');
							Nro = eval(parseInt(NroProx,10) -1);
							NombreObjProx = NombreObjProx + arrDato[2].toString() + "_" + CarCol + Nro;
							break;
						case 38://Arriba
							NroProx = arrDato[2].toString().replace(CarFila,'');
							Nro = eval(parseInt(NroProx,10) -1);
							NombreObjProx = NombreObjProx + CarFila + Nro + "_" +  arrDato[3].toString();
							break;
						case 39://Derecha
							NroProx = arrDato[3].toString().replace(CarCol,'');
							Nro = eval(parseInt(NroProx,10) +1);
							NombreObjProx = NombreObjProx + arrDato[2].toString() + "_" + CarCol + Nro;					
							break;
						case 40://Abajo
							NroProx = arrDato[2].toString().replace(CarFila,'');
							Nro = eval(parseInt(NroProx,10) +1);
							NombreObjProx = NombreObjProx + CarFila + Nro + "_" +  arrDato[3].toString();					
							break;
						case 13://Enter
							ObjetoProximo(39,objActual);
							break;
					}
					$O(NombreObjProx).focus();
				}
				catch(error){}
			}
			/*-----------------------------------------------------------------------------------------------------*/
			/*-----------------------------------------------------------------------------------------------------*/
			var EstadodeValorActual = false;
			function AsignarEventodeSalidayCambio(){
				var objgrid = $O("grid");
				if(objgrid !=undefined){
					for(var i=1;i<= objgrid.rows.length-1;i++){
						var objTxtD = objgrid.rows[i].cells[0].children[0];
						objTxtD.onblur = MantenimientoDescripcion;
						objTxtD.onchange = CuandoCambiaValor;
						objTxtD.Tag  = 0;
						for(var c=1;c<=12;c++){
							var objTxt = objgrid.rows[i].cells[c].children[0];
							objTxt.onblur = NewonBlur;
							objTxt.onchange = CuandoCambiaValor;
							objTxt.Tag  = c;
						}
					}
				}
			}
			//Asigna al Objeto Numerico el Evento de cambio OnChange para detectar algun cambio en los montos
			function CuandoCambiaValor(){EstadodeValorActual = true;}

				var KEYQIDCENTROOPERATIVO="idcop";//CentroOPerativo de la pagina de Procesos
				var KEYQIDCENTROCOSTO ="idCC";
				var KEYQPERIODO="Periodo";
				var KEYQIDRUBRO="idRubro";				
				
			function MantenimientoDescripcion(){
				var otxtDescripcion = this;
				var oGridRow = otxtDescripcion.parentElement.parentElement;
				if (EstadodeValorActual == true){
					EstadodeValorActual = false;
					var id = oGridRow.getAttribute("IdDetalleMovCC");
					if(parseInt(id,10)==0){
						oGridRow.removeAttribute("IdDetalleMovCC");
						oGridRow.setAttribute("IdDetalleMovCC",Agregar(otxtDescripcion.value));
					}
					else{
						Modificar(id,otxtDescripcion.value);
					}
				}
			}
			
			
			function Agregar(Descripcion){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oFormatoDetalleMovimientoItemDescBE = new EntidadesNegocio.Presupuesto.FormatoDetalleMovimientoItemDescBE();
					oFormatoDetalleMovimientoItemDescBE.Idformato=24;
					oFormatoDetalleMovimientoItemDescBE.Idrubro = oPagina.Request.Params[KEYQIDRUBRO];
					oFormatoDetalleMovimientoItemDescBE.Idcentrooperativo = oPagina.Request.Params[KEYQIDCENTROOPERATIVO];
					oFormatoDetalleMovimientoItemDescBE.Idcentrocosto = oPagina.Request.Params[KEYQIDCENTROCOSTO];
					oFormatoDetalleMovimientoItemDescBE.Periodo = oPagina.Request.Params[KEYQPERIODO];
					oFormatoDetalleMovimientoItemDescBE.Descripcion = Descripcion;
					
					var Reultado=0;
					try{
						Reultado = (new Controladora.Presupuesto.CFormatoDetalleMovimientoItemDescCC()).Insertar(oFormatoDetalleMovimientoItemDescBE);
					}
					catch(error){
						if(error instanceof SIMA.SIMAExcepcionLog){
							var oSIMAExcepcionLog = new SIMA.SIMAExcepcionLog();
							oSIMAExcepcionLog = error;
							window.alert(oSIMAExcepcionLog.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionIU){
							var oSIMAExcepcionIU = new SIMA.SIMAExcepcionIU();
							oSIMAExcepcionIU=error;
							window.alert(oSIMAExcepcionIU.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionDominio){
							var oSIMAExcepcionDominio = new SIMA.SIMAExcepcionDominio();
							oSIMAExcepcionDominio=error;
							window.alert("BASE DE DATOS\n" + oSIMAExcepcionDominio.Mensaje);
						}
					}
					return Reultado;
			}
			function Modificar(id,Descripcion){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oFormatoDetalleMovimientoItemDescBE = new EntidadesNegocio.Presupuesto.FormatoDetalleMovimientoItemDescBE();
					oFormatoDetalleMovimientoItemDescBE.idDetDesFmtCC=id;
					oFormatoDetalleMovimientoItemDescBE.Descripcion = Descripcion;
					EstadodeValorActual = false;
					var Reultado=0;
					try{
						Reultado = (new Controladora.Presupuesto.CFormatoDetalleMovimientoItemDescCC()).Modificar(oFormatoDetalleMovimientoItemDescBE);
					}
					catch(error){
						if(error instanceof SIMA.SIMAExcepcionLog){
							var oSIMAExcepcionLog = new SIMA.SIMAExcepcionLog();
							oSIMAExcepcionLog = error;
							window.alert(oSIMAExcepcionLog.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionIU){
							var oSIMAExcepcionIU = new SIMA.SIMAExcepcionIU();
							oSIMAExcepcionIU=error;
							window.alert(oSIMAExcepcionIU.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionDominio){
							var oSIMAExcepcionDominio = new SIMA.SIMAExcepcionDominio();
							oSIMAExcepcionDominio=error;
							window.alert("BASE DE DATOS\n" + oSIMAExcepcionDominio.Mensaje);
						}
					}
					return Reultado;
			}
			//Mantenimiento de los movimientos del mes
			function MantenimientoValor(e){
				var otxtDescripcion = e;
				var oGridRow = otxtDescripcion.parentElement.parentElement;
				var oDataGrid = oGridRow.parentElement.parentElement;
				var idCelda = otxtDescripcion.parentElement.cellIndex;
				if (EstadodeValorActual == true){
					EstadodeValorActual = false;
					var id = oGridRow.getAttribute("IdDetalleMovCC");
					if(parseInt(id,10)==0){
						window.alert("Primero deberá de registrar la descripción del Item\n para luego ingresar sus respectivos montos");
						this.value=0;
					}
					else{
						AgregarModificar(id,idCelda,otxtDescripcion.value);
						//Aqui se calcula el total de la columna en proceso
						ActualizarDatosRemotos(idCelda,ObternerTotalPorColumna(oDataGrid,idCelda));
					}
				}			
			}
			
			function ObternerTotalPorColumna(oDataGrid,idColumna){
				var MontoTotal =0;
				for(var i=1;i<=oDataGrid.rows.length-1;i++){
					var oTxtControl = oDataGrid.rows[i].cells[idColumna].children[0];
					var Cantidad = SIMA.Utilitario.Helper.General.Reemplazar(oTxtControl.value,',','');
					MontoTotal = MontoTotal + parseFloat(Cantidad);
				}
				return MontoTotal;
			}
			
			var KEYQIDTIPOINFORMACION="idTipoInfo";
			function AgregarModificar(id,idMes,Monto){
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					var oFormatoDetalleMovimientoDescCCBE = new EntidadesNegocio.Presupuesto.FormatoDetalleMovimientoDescCCBE();
					
					oFormatoDetalleMovimientoDescCCBE.IdDetDesFmtCC = id;
					oFormatoDetalleMovimientoDescCCBE.IdMes = idMes;
					oFormatoDetalleMovimientoDescCCBE.IdTipoInformacion = oPagina.Request.Params[KEYQIDTIPOINFORMACION];
					oFormatoDetalleMovimientoDescCCBE.MontoMes = Monto;
					
					var Reultado=0;
					try{
						Reultado = (new Controladora.Presupuesto.CFormatoDetalleMovimientoDescCC()).InsertarModificar(oFormatoDetalleMovimientoDescCCBE);
					}
					catch(error){
						if(error instanceof SIMA.SIMAExcepcionLog){
							var oSIMAExcepcionLog = new SIMA.SIMAExcepcionLog();
							oSIMAExcepcionLog = error;
							window.alert(oSIMAExcepcionLog.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionIU){
							var oSIMAExcepcionIU = new SIMA.SIMAExcepcionIU();
							oSIMAExcepcionIU=error;
							window.alert(oSIMAExcepcionIU.Mensaje);
						}
						else if(error instanceof SIMA.SIMAExcepcionDominio){
							var oSIMAExcepcionDominio = new SIMA.SIMAExcepcionDominio();
							oSIMAExcepcionDominio=error;
							window.alert("BASE DE DATOS\n" + oSIMAExcepcionDominio.Mensaje);
						}
					}
					return Reultado;
			}


			
			//Evento que se desencadena al Momento de perder el foco el Obj Numerico
			function NewonBlur(){
				NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				MantenimientoValor(this);
			}
			/*------------------------------------------------------------------------------------------------------------------------------------*/
			function ActualizarDatosRemotos(idCell,Monto) {
				var KEYQIDROW="idRow";
				var idFila = (new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[KEYQIDROW];
				var owindRemoto=window.dialogArguments;
				owindRemoto.ActualizarDatosOrigenRemoto(idFila,idCell,Monto);
			}
			/*------------------------------------------------------------------------------------------------------------------------------------*/
			
			
		
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="AsignarEventodeSalidayCambio();ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD align="center" width="100%" colSpan="3">
						<TABLE class="normal" id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD align="center" width="100%" colSpan="3"><cc1:datagridweb id="grid" runat="server" Width="100%" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:TemplateColumn HeaderText="CONCEPTO">
												<HeaderStyle Width="20%"></HeaderStyle>
												<ItemTemplate>
													<asp:TextBox id="txtCol0" runat="server" Width="100%" BorderStyle="None"></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ENE">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol1" runat="server" Width="50px" CssClass="normaldetalle" PlacesBeforeDecimal="15"
														TextAlign="Right" BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18"
														DecimalPlaces="3" DollarSign=" " AutoFormatCurrency="True">13333.00</ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="FEB">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol2" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MAR">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol3" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="ABR">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol4" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="MAY">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol5" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="JUN">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol6" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="JUL">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol7" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="AGO">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol8" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="SET">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol9" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="OCT">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol10" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="NOV">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol11" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
											<asp:TemplateColumn HeaderText="DIC">
												<HeaderStyle Width="6%"></HeaderStyle>
												<ItemTemplate>
													<ew:numericbox id="txtCol12" runat="server" Width="50px" CssClass="normaldetalle" AutoFormatCurrency="True"
														DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent"
														BackColor="Transparent" TextAlign="Right" PlacesBeforeDecimal="15"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb>
									<DIV align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></DIV>
									<asp:label id="Label1" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
							<TR>
								<TD align="left" width="100%" colSpan="3"><INPUT id="hCodigo" style="WIDTH: 24px; HEIGHT: 14px" type="hidden" size="1" value="1"
										name="hCodigo" runat="server" DESIGNTIMEDRAGDROP="194"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</table>
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
		</form>
	</body>
</HTML>
