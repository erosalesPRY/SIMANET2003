<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc2" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleLetradeCambio.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.LetrasdeCambio.DetalleLetradeCambio" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script src="/SimaNetWeb/js/date.js" type="text/javascript"></script>
		<style>UNKNOWN { FONT: 12px sans-serif }
		</style>
		<script>
		function Calculo(strNombreFechaIni,strNombreFechaFin,strControlDestino)
		{
			var CarArray="-";
			var Fini = document.all[strNombreFechaIni].value; 
			var Ffin = document.all[strNombreFechaFin].value; 
			var ArrayFini = Fini.split(CarArray);
			var ArrayFfin = Ffin.split(CarArray);
			var oFini = new Date(ArrayFini[2],ArrayFini[1],ArrayFini[0]); 
			var oFfin = new Date(ArrayFfin[2],ArrayFfin[1],ArrayFfin[0]); 
			var operacion =(oFini-oFfin)/86400000; 
			document.all[strControlDestino].value =Math.abs(operacion);
			//return  Math.abs(operacion);
		}
		


		function TotalizarFacturas(){
			var oDataGrid = $O("grid");
			var ImporteTotal=0;
			for(var i=1;i<=oDataGrid.rows.length-2;i++){
				var Importe = oDataGrid.rows[i].cells[4].innerText.toString().replace(',','').replace(' ','');		
				ImporteTotal = parseFloat(ImporteTotal) + parseFloat(Importe);
			}
			oDataGrid.rows[oDataGrid.rows.length-1].cells[1].innerText = new SIMA.Numero(parseFloat(ImporteTotal)).toString(2,true,' ');
			//$doPostBack('Grabar','hPostback');
		}
		
		</script>
		<script>
			var idCentro = 0;
			var idClienteProveedor =0;
			var idMoneda = 0;
			function consumerName_ItemDataBound(sender,e,dr){
				var oDataGrid = $O("grid");
				var NroFilas = oDataGrid.rows.length-1;
				var Clase = oDataGrid.rows[NroFilas-1].className.toString().toUpperCase();

				var oFila = oDataGrid.insertRow(NroFilas);
				var oCell0 = document.createElement("TD");
				oCell0.innerText = dr["Factura"].toString()
				oCell0.align="left";
				oFila.appendChild(oCell0);
				//Centro Operativo
				oCell0 = document.createElement("TD");	
				oCell0.innerText = dr["NombreCentro"].toString()
				oCell0.align="left";
				oFila.appendChild(oCell0);
				//Razon Social
				oCell0 = document.createElement("TD");	
				oCell0.innerHTML = dr["RazonSocial"].toString()
				oCell0.align="left";
				oFila.appendChild(oCell0);
				//Moneda
				oCell0 = document.createElement("TD");	
				oCell0.innerText = dr["Moneda"].toString()
				oCell0.align="left";
				oFila.appendChild(oCell0);
				//Monto Neto
				oCell0 = document.createElement("TD");
				oCell0.noWrap = true;	
				oCell0.innerText = new SIMA.Numero(parseFloat(dr["Monto_Neto"])).toString(2,true,' ');
				oCell0.align="right";
				oFila.appendChild(oCell0);
				//Tipo de cambio
				oCell0 = document.createElement("TD");	
				oCell0.innerText = new SIMA.Numero(parseFloat(dr["Tipo_Cambio"])).toString(2,true,' ');
				oCell0.align="right";
				oFila.appendChild(oCell0);
				
				//Imagen Eliminar
				var oImgEli = document.createElement("IMG");	
				oImgEli.onclick =function(){Eliminar(this.parentElement.parentElement);}
				oImgEli.onmousemove =function(){this.src="/SimanetWeb/Imagenes/Tree/CloseWindowB.gif";}
				oImgEli.onmouseout =function(){this.src="/SimanetWeb/Imagenes/Tree/CloseWindowA.gif";}
				
				oImgEli.src="/SimanetWeb/Imagenes/Tree/CloseWindowA.gif";
				oCell0 = document.createElement("TD");	
				oCell0.appendChild(oImgEli);
				oCell0.align="center";
				oFila.appendChild(oCell0);
				
				//Cambia el Centro Operativo
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				
				idCentro  = dr["idCentroOperativo"].toString();
				idClienteProveedor = ((parseFloat(oPagina.Request.Params[KEYIDTIPOLETRA],10)==0)?dr["idCliente"].toString():dr["idProveedor"].toString());
				idMoneda  = dr["idMoneda"].toString();
				
				oFila.setAttribute("Estado","N");
				oFila.setAttribute("idCentroOperativo",dr["idCentroOperativo"].toString());
				oFila.setAttribute("NroSerie",dr["NroSerie"].toString());
				oFila.setAttribute("Nrofactura",dr["Nrofactura"].toString());
				oFila.setAttribute("TipoCambio",dr["Tipo_Cambio"].toString());
				
				if (Clase == "ITEMGRILLA"){oFila.className = "Alternateitemgrilla";}
				else{oFila.className = "Itemgrilla";}
				
				TotalizarFacturas();
			}
			function ObteneridRegistro(){
				var strLst="";
				var ohListaFacturas = $O('hListaFacturas');
				var oDataGrid = $O('grid');
				for(var i=1;i<=oDataGrid.rows.length-2;i++){
					if(oDataGrid.rows[i].getAttribute("Estado") !="M"){
						strLst = strLst + oDataGrid.rows[i].getAttribute("idCentroOperativo")
										+ ","
										+ oDataGrid.rows[i].getAttribute("NroSerie")
										+ ","
										+ oDataGrid.rows[i].getAttribute("Nrofactura")
										+ ","
										+ oDataGrid.rows[i].getAttribute("TipoCambio") + ";";
					}
				}
				if(strLst.length>0){
					ohListaFacturas.value = strLst.substring(0,strLst.length-1);
				}
			}
			
			function AsignarEvento(){
				var oCalFechaInicio = $O('CalFechaInicio');
				var objN = $O('NDiasPlazo');
				objN.onblur=function(){
					NumericBox_IE_ParseAdd(this, ' ', ',', '.');
					var oCalFechaVencimiento = $O('CalFechaVencimiento');
					var arrFecha = oCalFechaInicio.value.toString().split('-');
					var d1 = new Date(parseInt(arrFecha[2],10),  parseInt((arrFecha[1]-1),10),parseInt(arrFecha[0],10)); 
					var d2 = d1;
					oCalFechaVencimiento.innerText =d2.add(parseInt(this.value,10)).days().toString('dd-MM-yyyy'); 
				}
			}
			function CalcularVencimiento(Fecha,id){
					var oNDiasPlazo = $O('NDiasPlazo');
					var arrFecha = Fecha.toString().split('/');
					var d1 = new Date(parseInt(arrFecha[2],10), parseInt(arrFecha[0]-1,10),parseInt(arrFecha[1],10)); 
					var d2 = d1;
					var oCalFechaVencimiento = $O('CalFechaVencimiento');
					oCalFechaVencimiento.innerText =d2.add(parseInt(oNDiasPlazo.value,10)).days().toString('dd-MM-yyyy'); 
			}
			
			function Eliminar(e,id){
				var otbl=e.parentNode;
				if(id==undefined){
					otbl.removeChild(e);
				}
				else{ 
					if(window.confirm("Esta Ud. Seguro de Eliminar esta factura " +  e.getAttribute("NroSerie") + "-" + e.getAttribute("Nrofactura"))){
						window.alert("Eliminar " + id);
						otbl.removeChild(e);
					}
				}
				TotalizarFacturas();
			}
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="AsignarEvento();ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Letras</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table3" style="WIDTH: 742px; HEIGHT: 256px" cellSpacing="1" cellPadding="1"
							width="742" border="0">
							<TR>
								<TD style="WIDTH: 734px" bgColor="#000080" colSpan="10"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="304px">DETALLE DE LETRAS</asp:label></TD>
								<TD bgColor="#000080"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 16px"><asp:label id="Label16" runat="server" Width="100px">Facturas:</asp:label></TD>
								<TD width="100%" colSpan="9"><cc2:datagridweb id="grid" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
										RowHighlightColor="#E0E0E0" PageSize="3">
										<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO DOC">
												<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreCentro" HeaderText="CO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="RazonSocial" HeaderText="CLIENTE/PROVEEDOR">
												<HeaderStyle Width="10%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Right"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Monto" HeaderText="IMPORTE">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Tipo_Cambio" HeaderText="TC">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="ELI">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemTemplate>
													<IMG id="imgEliminar" alt="" src="/SimanetWeb/Imagenes/Tree/CloseWindowA.gif" runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc2:datagridweb></TD>
								<TD style="HEIGHT: 16px" vAlign="top" align="left"><IMG id="IbtnAgregarFact" alt="" src="../../imagenes/BtPU_Mas.gif" align="left"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 16px"><asp:label id="Label1" runat="server" Width="100px" ToolTip="Nro del Documento de Referencia">Nro Doc:</asp:label></TD>
								<TD style="WIDTH: 103px; HEIGHT: 16px"><asp:textbox id="txtNroDocumento" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"></asp:textbox></TD>
								<TD style="WIDTH: 2px; HEIGHT: 16px"><cc1:requireddomvalidator id="rfvNroReferencia" runat="server" Width="8px" ControlToValidate="txtNroDocumento"
										ErrorMessage="No se ha ingresado Nro de Docuemento de la Letra">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle" style="WIDTH: 67px; HEIGHT: 16px"><asp:label id="Label4" runat="server">Situación :</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 16px"><asp:dropdownlist id="ddlbSituacion" runat="server" CssClass="normaldetalle" Width="119px"></asp:dropdownlist></TD>
								<TD class="HeaderDetalle" style="WIDTH: 103px; HEIGHT: 16px" colSpan="3"><asp:label id="Label11" runat="server" Width="112px">Tipo de Trabajo :</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 16px" colSpan="2"><asp:dropdownlist id="ddlbTipoTrabajo" runat="server" CssClass="normaldetalle" Width="101px"></asp:dropdownlist></TD>
								<TD style="HEIGHT: 16px"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 17px"><asp:label id="Label18" runat="server" Width="97px">Fecha de Inicio:</asp:label></TD>
								<TD style="WIDTH: 103px; HEIGHT: 17px"><ew:calendarpopup id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="72px" ImageUrl="../../imagenes/BtPU_Mas.gif"
										CalendarLocation="Bottom" AllowArbitraryText="False" GoToTodayText="Hoy :" MonthYearPopupApplyText="Aceptar" MonthYearPopupCancelText="Cancelar"
										NullableLabelText="Seleccione una fecha:" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True"
										JavascriptOnChangeFunction="CalcularVencimiento">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD style="WIDTH: 2px; HEIGHT: 17px"></TD>
								<TD class="HeaderDetalle" style="WIDTH: 67px; HEIGHT: 17px"><asp:label id="Label2" runat="server" Width="96px">DIAS DE PLAZO:</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 17px"><ew:numericbox id="NDiasPlazo" runat="server" CssClass="normaldetalle" Width="88px" MaxLength="8"
										DecimalPlaces="2" PlacesBeforeDecimal="3" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right" BackColor="White">0</ew:numericbox></TD>
								<TD class="HeaderDetalle" style="WIDTH: 103px; HEIGHT: 17px" colSpan="3"><asp:label id="Label8" runat="server" Width="118px">Fecha Vencimiento :</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 17px" align="right" colSpan="2"><asp:label id="CalFechaVencimiento" runat="server">00-00-0000</asp:label></TD>
								<TD style="HEIGHT: 17px"></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px; HEIGHT: 16px"><asp:label id="Label7" runat="server">DIAS QUE VENCE:</asp:label></TD>
								<TD id="CellddlbTipoTrabajo" style="WIDTH: 103px; HEIGHT: 16px" runat="server"><ew:numericbox id="nDiasVence" runat="server" CssClass="normaldetalle" Width="88px" MaxLength="8"
										DecimalPlaces="2" PlacesBeforeDecimal="3" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right" BackColor="#E0E0E0" ReadOnly="True">0</ew:numericbox></TD>
								<TD style="WIDTH: 2px; HEIGHT: 16px"></TD>
								<TD class="HeaderDetalle" style="WIDTH: 67px; HEIGHT: 16px"><asp:label id="Label3" runat="server" Width="103px">Tasa de Interés :</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 16px"><ew:numericbox id="nTasaInteres" runat="server" CssClass="normaldetalle" Width="88px" MaxLength="8"
										DecimalPlaces="2" PlacesBeforeDecimal="2" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right">0</ew:numericbox><cc1:requireddomvalidator id="rfvTasaInteres" tabIndex="3" runat="server" Width="8px" ControlToValidate="nTasaInteres"
										ErrorMessage="No se ha ingresado la tasa de interés de la letra">*</cc1:requireddomvalidator></TD>
								<TD class="HeaderDetalle" style="WIDTH: 103px; HEIGHT: 16px" colSpan="3"><asp:label id="Label9" runat="server" Width="123px">Importe Letra:</asp:label></TD>
								<TD style="WIDTH: 100px; HEIGHT: 16px" colSpan="2"><ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="100%" MaxLength="15"
										DecimalPlaces="2" PlacesBeforeDecimal="8" PositiveNumber="True" DollarSign=" " AutoFormatCurrency="True" TextAlign="Right">0</ew:numericbox></TD>
								<TD style="HEIGHT: 16px"><cc1:requireddomvalidator id="rfvMontoEstablecido" tabIndex="3" runat="server" Width="8px" ControlToValidate="nMonto"
										ErrorMessage="No se ha ingresado el Importe de la Letra">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 133px"><asp:label id="Label10" runat="server">GARANTIA :</asp:label></TD>
								<TD align="left" width="100%" colSpan="9"><asp:textbox id="txtObservacion" runat="server" CssClass="normaldetalle" Height="44px" Width="100%"
										TextMode="MultiLine"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"></TD>
								<TD align="left" width="100%" colSpan="9" rowSpan="2"><TABLE id="ToolBar" cellSpacing="1" cellPadding="1" width="112" align="right" border="0"
										runat="server">
										<TR>
											<TD>
												<P align="right"><asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></P>
											</TD>
											<TD>
												<P align="right"><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
														runat="server"></P>
											</TD>
										</TR>
									</TABLE>
									<INPUT id="hPostback" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" name="hPostback"
										runat="server"><INPUT id="consumerName" style="DISPLAY: none; WIDTH: 264px; HEIGHT: 21px" type="text"
										size="38" name="consumerName">&nbsp; <INPUT id="hListaFacturas" style="WIDTH: 56px; HEIGHT: 22px" type="hidden" size="4" name="hPostback"
										runat="server"> <INPUT id="hMontoTotalFac" style="WIDTH: 33px; HEIGHT: 22px" type="hidden" size="1" runat="server"
										value="0">
								</TD>
								<TD></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="tblAtras" style="WIDTH: 760px; HEIGHT: 23px" cellSpacing="1" cellPadding="1"
							width="760" border="0" runat="server">
							<TR>
								<TD align="left"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" width="100%"><cc1:domvalidationsummary id="Vresumen" runat="server" Height="24px" Width="160px" DisplayMode="List" EnableClientScript="False"
							ShowMessageBox="True"></cc1:domvalidationsummary></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			var KEYQIDCENTRO="IdCentro";
			//var KEYQIDCLIENTE="IdCliente";
			var KEYQIDCLIENTEPROVEEDOR="IdClienteProveedor";
			var KEYQIDMONEDA="IdMoneda";
			var KEYIDTIPOLETRA = "TipoLetra";
			var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
			
			$O('IbtnAgregarFact').onclick=function(){
					var oParamCollecionBusqueda = new ParamCollecionBusqueda();
						var oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="RazonSocial";
						oParamBusqueda.CampoAlterno="Factura";
						oParamBusqueda.Tipo="C";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre=KEYIDTIPOLETRA;
						oParamBusqueda.Valor=oPagina.Request.Params[KEYIDTIPOLETRA];
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);
					
						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre="idProceso";
						oParamBusqueda.Valor=50;
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);
					
						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre=KEYQIDCLIENTEPROVEEDOR;
						oParamBusqueda.Valor=idClienteProveedor;
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);

						oParamBusqueda = new ParamBusqueda();
						oParamBusqueda.Nombre=KEYQIDMONEDA;
						oParamBusqueda.Valor=idMoneda;
						oParamBusqueda.Tipo="Q";
					oParamCollecionBusqueda.Agregar(oParamBusqueda);
					
					(new AutoBusqueda('consumerName')).CrearDialogo('/SimaNetWeb/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda,50,100);
			}
		</SCRIPT>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
