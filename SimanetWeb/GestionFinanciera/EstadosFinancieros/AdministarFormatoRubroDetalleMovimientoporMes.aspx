<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministarFormatoRubroDetalleMovimientoporMes.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.AdministarFormatoRubroDetalleMovimientoporMes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
			var idObj=0;
			//Variable que contienen parte de el Nombre del Objeto numerico y sisrve para obtener un nombre de control posible
			var NombreDefault1 = "grid__ctl";
			var NombreDefault2 = "_nMonto";
			var EstadodeValorActual = false;

			function EnfocarSiguienteCelda(objthis)
			{
				var NroObj = objthis.id.replace(NombreDefault1,"").replace(NombreDefault2,"");
				var objgrid = document.all["grid"];
				
				if (event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn 
					|| event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyDown
					|| event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyTab)
				{
					var NroObjSiguiente = (parseInt(NroObj)+1);
					if ((NroObj-1) == objgrid.rows.length)
					{NroObjSiguiente=2;}

					var NombreObjSiguiente = NombreDefault1 + NroObjSiguiente + NombreDefault2;
					var objSiguiente = document.all[NombreObjSiguiente];
					if (objSiguiente != undefined){objSiguiente.focus();}
					
				}
				else if (event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyUp)
				{
					var NroObjAnterior = (parseInt(NroObj)-1);
					var NombreObjAnterior = NombreDefault1 + NroObjAnterior + NombreDefault2;
					var objAnterior = document.all[NombreObjAnterior];
					if (objAnterior != undefined){objAnterior.focus();}
				}
				
				/*else if (event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyControl
						 || event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyInsert)//Tecla Control o Insert
				{
					this.RedireccionarCalculadora(objthis);
				}*/

			}
			
			function AsignarEventodeSalidayCambio()
			{
				var objgrid = document.all["grid"];
				for(var i=1;i<= objgrid.rows.length-2;i++)
				{
					var objNMonto = objgrid.rows[i].cells(2).children[0];
					if (objNMonto!= undefined)
					{
						objNMonto.onblur =NewonBlur;
						objNMonto.onchange = CuandoCambiaValor;
					}
				}
			}

			
			
			function CuandoCambiaValor(){EstadodeValorActual = true;}
			//Evento que se desencadena al Momento de perder el foco el Obj Numerico
			function NewonBlur()
			{
				NumericBox_IE_ParseAdd(this, ' ', ',', '.');
				if (EstadodeValorActual == true)//Si se ha cambiado algun valor para que vuelva a recalcular
				{ 
					var e = window.event.srcElement;
					objfila = e.parentElement.parentElement;
					/*Actualiza el Atributo*/
					objfila.cells(0).removeAttribute("MONTO");
					objfila.cells(0).setAttribute("MONTO",this.value);
					
					CFormatoRubroDetalleMovimientoTAD(objfila);
					EstadodeValorActual = false;
				}
			}

			function RedireccionarCalculadora(objthis)
			{
				var URLCALCULADORA = "Calculadora.aspx";
				var Datos="";
				Datos=window.showModalDialog(URLCALCULADORA,window,"dialogWidth:255px;dialogHeight:220px"); 
				if(Datos!=null)	{objthis.value =Datos;}
			}
			
			
			var PERIODO="Periodo";
			var MES="idMes";
			var KEYQIDCENTRO = "IdCentro";
			var KEYQIDRUBRODETALLE = "IdrubroDetalle";
			var KEYQIDRUBRODETALLEMOVIMIENTO = "IdrubroDetalleMov";
			var KEYQIDTIPOINFORMACION = "idTipoInfo";
			
			function CFormatoRubroDetalleMovimientoTAD(e)
			{
				/*e representa a la Fila seleccionada que contiene el objeto TXT editado*/
				switch(e.cells(0).getAttribute("Modo"))
				{
					case SIMA.Utilitario.Enumerados.ModoPagina.N.toString():
						Agregar(e);
						break;
					case SIMA.Utilitario.Enumerados.ModoPagina.M.toString():
						Modificar(e);
						break;
				}
			}
			function Agregar(e)
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oFormatoRubroDetalleMovimientoBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.EstadosFinancieros.FormatoRubroDetalleMovimientoBE();
				with(oFormatoRubroDetalleMovimientoBE)
				{
					Periodo = oPagina.Request.Params[PERIODO];
					IdMes = oPagina.Request.Params[MES];
					IdCentroOperativo = oPagina.Request.Params[KEYQIDCENTRO];
					IdRubroDetalle = e.cells(0).getAttribute("idRubroDetalle");
					IdRubroDetalleMovimiento = e.cells(0).getAttribute("idRubroMovimiento");
					IdTipoInformacion = oPagina.Request.Params[KEYQIDTIPOINFORMACION];
					Monto = e.cells(0).getAttribute("MONTO");
				}			
				oFormatoRubroDetalleMovimientoTAD = new SIMA.AccesoDatos.Transaccional.GestionFinanciera.FormatoRubroDetalleMovimientoTAD();
				oFormatoRubroDetalleMovimientoTAD.Insertar(oFormatoRubroDetalleMovimientoBE,e);
			}
			function Modificar(e)
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oFormatoRubroDetalleMovimientoBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.EstadosFinancieros.FormatoRubroDetalleMovimientoBE();
				with(oFormatoRubroDetalleMovimientoBE)
				{
					Periodo = oPagina.Request.Params[PERIODO];
					IdMes = oPagina.Request.Params[MES];
					IdCentroOperativo = oPagina.Request.Params[KEYQIDCENTRO];
					IdRubroDetalle = e.cells(0).getAttribute("idRubroDetalle");
					IdRubroDetalleMovimiento = e.cells(0).getAttribute("idRubroMovimiento");
					IdTipoInformacion = oPagina.Request.Params[KEYQIDTIPOINFORMACION];
					Monto = e.cells(0).getAttribute("MONTO");
				}
				oFormatoRubroDetalleMovimientoTAD = new SIMA.AccesoDatos.Transaccional.GestionFinanciera.FormatoRubroDetalleMovimientoTAD();
				oFormatoRubroDetalleMovimientoTAD.Modificar(oFormatoRubroDetalleMovimientoBE,e);
			}
			
			function RetornarPantallaAnterior()
			{
				var NODOSELECCIONADO="NodoSeleccionado";
				ReemplazarParametrodeHistorial(NODOSELECCIONADO, (new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[NODOSELECCIONADO]);
			}
			
			
		</script>
</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();AsignarEventodeSalidayCambio();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="Label2" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera > Estados Financieros></asp:label><asp:label id="Label3" runat="server" CssClass="RutaPaginaActual"> Administración de Detalle de Conceptos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE class="tabla" id="TblTabs" cellSpacing="0" cellPadding="0" width="100%" align="center"
							bgColor="#f5f5f5" border="0" runat="server">
							<TR>
								<TD style="WIDTH: 361px; HEIGHT: 14px" colSpan="2"><asp:label id="Label1" runat="server" CssClass="TituloPrincipalBlanco" DESIGNTIMEDRAGDROP="61"
										ForeColor="Black" Font-Bold="True" Width="440px">CONCEPTO :</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="center">
									<TABLE id="Table9" style="HEIGHT: 25px" cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR bgColor="#f0f0f0">
											<TD><IMG id="ibtnFiltrarSeleccion" title="DESCRIPCION" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
													src="../../imagenes/filtroporseleccion.jpg"></TD>
											<TD style="WIDTH: 32px" vAlign="middle"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ToolTip="Eliminar Filtro.." ImageUrl="../../imagenes/filtroEliminar.GIF"></asp:imagebutton></TD>
											<TD style="WIDTH: 49px" vAlign="middle"><asp:label id="Label4" runat="server" CssClass="normaldetalle" Font-Bold="True" Width="53px"> Buscar :</asp:label></TD>
											<TD style="WIDTH: 333px" vAlign="middle"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
													title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; BORDER-BOTTOM: #999999 1px groove"
													type="text" size="20" name="txtBuscar"></TD>
											<TD style="WIDTH: 99px" vAlign="middle"></TD>
											<TD style="WIDTH: 19px"><asp:imagebutton id="ibtnAgregar" runat="server" ToolTip="Permite Agregar una descripción nueva.."
													ImageUrl="../../imagenes/bt_agregar.gif" CausesValidation="False"></asp:imagebutton></TD>
											<TD></TD>
											<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
										</TR>
									</TABLE>
									<cc1:datagridweb id="grid" runat="server" Width="100%" AllowPaging="True" PageSize="9" AllowSorting="True"
										AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" RowPositionEnabled="False">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle Height="25px" CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" SortExpression="DESCRIPCION" HeaderText="DETALLE">
												<HeaderStyle Width="80%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn HeaderText="MONTO">
												<ItemTemplate>
													<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="125px" PlacesBeforeDecimal="15" AutoFormatCurrency="True" DollarSign=" " DecimalPlaces="3" MaxLength="18" BorderStyle="None" BorderColor="Transparent" BackColor="Transparent" TextAlign="Right"></ew:numericbox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center"><INPUT id="hCodigo" style="WIDTH: 74px; HEIGHT: 22px" type="hidden" size="7" name="hCodigo"
										runat="server" DESIGNTIMEDRAGDROP="480"><INPUT id="hTrama" style="WIDTH: 74px; HEIGHT: 22px" type="hidden" size="7" name="hTrama"
										runat="server" DESIGNTIMEDRAGDROP="70"><INPUT id="hGridPaginaSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hGridPagina"
										runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
										name="hGridPagina" runat="server" DESIGNTIMEDRAGDROP="61"></TD>
							</TR>
							<TR>
								<TD align="right"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="RetornarPantallaAnterior();HistorialIrAtras();" alt="" src="../../imagenes/RetornarAlFormato.GIF"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			SIMA.Utilitario.Error.TiempoEsperadePagina();
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
