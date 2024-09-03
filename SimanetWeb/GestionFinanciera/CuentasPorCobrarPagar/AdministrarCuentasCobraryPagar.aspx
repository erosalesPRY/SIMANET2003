<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="AdministrarCuentasCobraryPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.AdministrarCuentasCobraryPagar" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarCuentasCobraryPagar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
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
			}
			
			function AsignarEventodeSalidayCambio()
			{
				var objgrid = document.all["grid"];
				for(var i=1;i<= objgrid.rows.length-1;i++)
				{
					var objNMonto = objgrid.rows[i].cells(3).children[0];
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
					objfila.removeAttribute("Monto");
					objfila.setAttribute("Monto",this.value);
					
					CCuentasporPagaryCobrar3Dig(objfila);
					EstadodeValorActual = false;
				}
			}
			//Administracion

			var KEYQIDCENTRO = "idCentro";
			var KEYQPERIODO="Periodo";
			var KEYQMES="Mes";
			var KEYQIDTIPOINFORMACION = "idTipoInfo";
			var KEYQDIGCUENTA="DigCta";
				
			function CCuentasporPagaryCobrar3Dig(e)
			{
				/*e representa a la Fila seleccionada que contiene el objeto TXT editado*/
				switch(e.getAttribute("Modo"))
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
				oCuentasporPagaryCobrar3DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.CuentasporCobraryPagar.CuentasporPagaryCobrar3DigBE();
				with(oCuentasporPagaryCobrar3DigBE)
				{
					idTipoDato			= oPagina.Request.Params[KEYQIDTIPOINFORMACION];
					idCentroOperativo	= oPagina.Request.Params[KEYQIDCENTRO];
					cuentaContable		= e.cells(1).innerText;
					periodo				= oPagina.Request.Params[KEYQPERIODO];
					mes					= oPagina.Request.Params[KEYQMES];
					montoMes			= e.getAttribute("Monto");
				}			
				oCuentasporPagaryCobrar3DigTAD = new SIMA.AccesoDatos.Transaccional.GestionFinanciera.CuentasporPagaryCobrar3DigTAD();
				oCuentasporPagaryCobrar3DigTAD.Insertar(oCuentasporPagaryCobrar3DigBE,e);
			}
			
			function Modificar(e)
			{
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oCuentasporPagaryCobrar3DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.CuentasporCobraryPagar.CuentasporPagaryCobrar3DigBE();
				with(oCuentasporPagaryCobrar3DigBE)
				{
					idTipoDato			= oPagina.Request.Params[KEYQIDTIPOINFORMACION];
					idCentroOperativo	= oPagina.Request.Params[KEYQIDCENTRO];
					cuentaContable		= e.cells(1).innerText;
					periodo				= oPagina.Request.Params[KEYQPERIODO];
					mes					= oPagina.Request.Params[KEYQMES];
					montoMes			= e.getAttribute("Monto");
				}			
				oCuentasporPagaryCobrar3DigTAD = new SIMA.AccesoDatos.Transaccional.GestionFinanciera.CuentasporPagaryCobrar3DigTAD();
				oCuentasporPagaryCobrar3DigTAD.Modificar(oCuentasporPagaryCobrar3DigBE,e);
			}
			
			

		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();AsignarEventodeSalidayCambio();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="Commands" style="HEIGHT: 19px"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar saldos de cuentas contable</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<DIV align="center">
							<TABLE id="Table2" style="WIDTH: 639px; HEIGHT: 69px" cellSpacing="0" cellPadding="0" width="639"
								align="center" border="0">
								<TR>
									<TD><cc1:datagridweb id="grid" runat="server" CssClass="headerGrilla" PageSize="12" AllowSorting="True"
											AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" Width="100%">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrillaEF"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO">
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="CuentaContable" SortExpression="CuentaContable" HeaderText="CUENTA">
													<HeaderStyle Width="2%" VerticalAlign="Middle"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="NombreCuenta" SortExpression="NombreCuenta" HeaderText="NOMBRE">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="SALDO">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<ItemTemplate>
														<ew:numericbox id="nMonto" runat="server" CssClass="normaldetalle" Width="100%" TextAlign="Right"
															BackColor="Transparent" BorderColor="Transparent" BorderStyle="None" MaxLength="18" DecimalPlaces="3"
															DollarSign=" " AutoFormatCurrency="True" PlacesBeforeDecimal="15"></ew:numericbox>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD>
										<P align="center"><INPUT id="hGridPagina" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" value="0"
												name="hGridPagina" runat="server"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Height="16px"></asp:label><INPUT id="hGridPaginaSort" style="WIDTH: 15px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
												runat="server"></P>
									</TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
