<%@ Page language="c#" Codebehind="ConsultarEvaluacionPresupuestalPorCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarEvaluacionPresupuestalPorCentrodeCosto" %>
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
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>
			//Desplazamiento de las columnas de la grilla
			function ScrollColumnas(ModoDesplazo)
			{
				var oGridCtrl = document.all["grid"];
				var ohIdMes = document.all["hidMes"];
				var idMes = parseInt(ohIdMes.value);
				
				switch(ModoDesplazo)
				{
					case "Izquierda":
						if (idMes >=7)
						{
							NroColOcultar =  (idMes -6);
							for(var fila=0;fila<= oGridCtrl.rows.length-1;fila++)
							{
								oGridCtrl.rows[fila].cells(NroColOcultar).style.display="block";
								oGridCtrl.rows[fila].cells(idMes).style.display="none";
							}
							idMes = (parseInt(ohIdMes.value) -1);
							ohIdMes.value = idMes
						}
						break;
					case "Derecha":
							if (idMes<=11 && idMes>6)
							{
								idMes ++;
								NroColMostrar =  Math.abs(idMes -6);
								for(var fila=0;fila<= oGridCtrl.rows.length-1;fila++)
								{
									oGridCtrl.rows[fila].cells(idMes).style.display="block";
									oGridCtrl.rows[fila].cells(NroColMostrar).style.display="none";
								}
							}
							else if(idMes==6)
							{
								idMes++;
								for(var fila=0;fila<= oGridCtrl.rows.length-1;fila++)
								{
									oGridCtrl.rows[fila].cells(idMes).style.display="block";
									oGridCtrl.rows[fila].cells(1).style.display="none";
								}								
							}
							ohIdMes.value = idMes
						break;
				}
			}
		</script>
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
				var KEYQCUENTA5DIG="Cta5Dig";
				var KEYQMONTO="Monto";
				
				var PrcTerminado=false;
				var e;
				var oNodoItem;
				
			function ObtenerDetalleaNiveldeCuenta5Dig()
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
				//var UrlDetalle =PathApp + "/GestionFinanciera/Presupuesto/ConsultarEvaluacionGastosdeAdministracionGrupoCC.aspx?"; 
				var Parametros;
				var strListaParametros;
				
				
				with (SIMA.Utilitario.Constantes.General.Caracter)
				{
					Parametros = PROCESO + SignoIgual.toString()+ SIMA.Utilitario.Constantes.General.ProcesoCallBack.PrespuestoFormulacionVSEjecucionPorCentrosdeCostoCta5Dig.toString()
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
				
				strListaParametros = SIMA.Utilitario.Constantes.General.ProcesoCallBack.PrespuestoFormulacionVSEjecucionPorCentrosdeCostoCta5Dig.toString();
				/*Crea Una Instancia del Objeto PostBack*/
				oDataGrid = oNodoItem.DataGrid;
				oCallBack = new SIMA.Utilitario.Helper.General.CallBack();
				oCallBack.CargarDocumentoXML(UrlPaginaProceso + Parametros,strListaParametros,oDataGrid);
				
				MostrarDatosFormulacion();
				return "Cargado";
			}
			var idProcesoTmr;//Sirve para identificar el proceso para luego liquidarlo y no quede en memoria ejecutandose;
			function MostrarDatosFormulacion()
			{
				if (PrcTerminado==false)
				{
					idProcesoTmr= setTimeout("MostrarDatosFormulacion();",50);
					window.status = PrcTerminado + "   " + oNodoItem.DataStatus;
					
				}
				else
				{
					ohtml = new SIMA.Utilitario.Helper.General.Html();
					clearInterval(idProcesoTmr);//Fuerza para terminar el proceso lanzado por el temporizador
					for(var i=0;i<= arrDataFormulacion.length-1;i++)
					{
						oEvaluacionPresupuestal5DigBE = new SIMA.EntidaddeNegocioBE.GestionFinanciera.Presupuesto.EvaluacionPresupuestal5DigBE();
						oEvaluacionPresupuestal5DigBE = arrDataFormulacion.ObtenerEntidad(i);
						//Carga la Grilla con los elementos encontrados
						with(oEvaluacionPresupuestal5DigBE)
						{
							
							oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,CuentaContable + " " + NombreCuenta,false,null,null,e);
							
							oNodoItem = ObtenerNodoItem(oDataGridFilaNueva);
							
							oDataGridFilaNueva.cells(3).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Enero,3));
							oDataGridFilaNueva.cells(4).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Febrero,4));
							oDataGridFilaNueva.cells(5).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Marzo,5));
							oDataGridFilaNueva.cells(6).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Abril,6));
							oDataGridFilaNueva.cells(7).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Mayo,7));
							oDataGridFilaNueva.cells(8).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Junio,8));
							oDataGridFilaNueva.cells(9).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Julio,9));
							oDataGridFilaNueva.cells(10).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Agosto,10));
							oDataGridFilaNueva.cells(11).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Setiembre,11));
							oDataGridFilaNueva.cells(12).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Octubre,12));
							oDataGridFilaNueva.cells(13).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Noviembre,13));
							oDataGridFilaNueva.cells(14).appendChild(CrearInputPorMes(oNodoItem,CuentaContable,Diciembre,14));
							
							//oDataGridFilaNueva.cells(13).innerText = Total;
							
						}
					}
					
					arrDataFormulacion.Remover();
					SIMA.Utilitario.Helper.General.Treeview.Nodo.Enumerar(oNodoItem.DataGrid);
					window.status = PrcTerminado;
				}
				oDataGrid = oNodoItem.DataGrid;
				oDataGrid.rows[oDataGrid.rows.length-1].className = "HeaderGrilla";
				
				ohtml = new SIMA.Utilitario.Helper.General.Html();
			}
			function CrearInputPorMes(oNodoItem,CuentaContable,Monto,NroCol)
			{
				ohtml = new SIMA.Utilitario.Helper.General.Html();
				//Lista de Columnas por Mes
				otxtNumero = new ohtml.CrearInputNumerico();
				otxtNumero.id = "Txt_" + oNodoItem.IdNivel + "_" + NroCol;
				otxtNumero.onkeydown=MoverPuntero;
				otxtNumero.className = "normaldetalle";
				otxtNumero.style.width = "100%";
				otxtNumero.maxlength="12";
				otxtNumero.className ="normalCelda";
				otxtNumero.style.align="left";
				otxtNumero.Tag = NroCol;
				otxtNumero.ColMes = NroCol;
				otxtNumero.ColumnaInicial=1;
				otxtNumero.ColumnaFinal=12;
				
				otxtNumero.ViejoValor = Monto;
				otxtNumero.Cuenta5Dig = CuentaContable;
				//otxtNumero.value =FormatNumber(Monto, 2, true,true, true);
				otxtNumero.value =Monto;
				otxtNumero.style.background ="Transparent";
				otxtNumero.style.border ="none";
				return 	otxtNumero;
			}
			
			function MoverPuntero()
			{
				if (event.keyCode == 13)
				{
					if (this.style.border !="")
					{
					
							this.style.border ="none";
							this.select();
					}
					else
					{
						if (this.NroColumnaSiguiente>=6){document.all["btnMostrarDer"].onclick();}
						objCell = this.DataGrid.rows[this.NroFilaActual].cells(this.NroColumnaSiguiente);//Despalza el Scroll hacia la derecha
						objCell.children[0].focus();
					}
				}
				else if (event.keyCode == 38)//Flecha Arriba
				{
					if (this.style.border =="")
					{
						try
						{
						objCell = this.DataGrid.rows[this.NroFilaAnterior].cells(this.ColMes);
						objCell.children[0].focus();
						}
						catch(e)
						{return true;}
					}
				}				
				else if (event.keyCode == 39)//Flecha a la derecha
				{
					if (this.style.border =="")
					{
						this.NroColumnaSiguiente=(this.NroColumnaSiguiente==0)?12:this.NroColumnaSiguiente;
						try
						{
							if (this.NroColumnaSiguiente>=6 && this.NroColumnaSiguiente<=11){document.all["btnMostrarDer"].onclick();}
							objCell = this.DataGrid.rows[this.NroFilaActual].cells(this.NroColumnaSiguiente);
							objCell.children[0].focus();
						}
						catch(e)
						{return true;}

					}
				}
				else if (event.keyCode == 40)//Flecha Abajo
				{
					if (this.style.border =="")
					{
						try
						{
							objCell = this.DataGrid.rows[this.NroFilaSiguente].cells(this.ColMes);
							objCell.children[0].focus();
						}
						catch(e)
						{return true;}
					}
				}								
				else if(event.keyCode == 37)//FechaIzquierda
				{
						this.NroColumnaAnterior=(this.NroColumnaAnterior==0)?1:this.NroColumnaAnterior;
						try
						{
							if (this.NroColumnaActual<=7){document.all["btnMostrarIzq"].onclick();}
							objCell = this.DataGrid.rows[this.NroFilaActual].cells(this.NroColumnaAnterior);
							objCell.children[0].focus();
						}
						catch(e)
						{return true;}
					
					
				}
				else if (event.keyCode == 27)//la Tecla Escape
				{
					this.value = this.ViejoValor;
					this.select();
				}
				else  
				{
					if (window.event.keyCode <= 12 || ((window.event.keyCode >= 48 && window.event.keyCode <= 57)|| (window.event.keyCode==46) || (window.event.keyCode>=96 && window.event.keyCode <=105) ))
					{
						this.style.border ="1.5pt inset";
					}
					return (window.event.keyCode <= 12 || ((window.event.keyCode >= 48 && window.event.keyCode <= 57)|| (window.event.keyCode==46) || (window.event.keyCode>=96 && window.event.keyCode <=105) ));
				}
			}
			/*--------------------------------------------------------------*/
			/*--------------------------------------------------------------*/
			function ObtenerNodoItem(oFilaActual)//Es utilizado para obtener informacion de nodo para luego crear los txtbox 
			{
					otblNodoRaiz = oFilaActual.cells[0].children[0];
					NroColPenultima = (otblNodoRaiz.rows[0].cells.length-2);
					oimg = otblNodoRaiz.rows[0].cells(NroColPenultima).children[0];
					oNodoItem = oimg.getAttribute("oNodoItem");
					return oNodoItem;
			}
			
			/*--------------------------------------------------------------*/
			/*--------------------------------------------------------------*/
			function ObtenerIdFilaNodoPrincipal(oNodoItemPadre)
			{
				
				oDataGrid = oNodoItemPadre.DataGrid;
				idNivelNodoBuscar = oNodoItemPadre.IdNivel;
				for(var i=1;i<=oDataGrid.rows.length-1;i++)
				{
					oFila = oDataGrid.rows[i];
					if (oFila.IdNivel.substring(0,idNivelNodoBuscar.length) == idNivelNodoBuscar)
					{
						return i;
					}
				}
			}			
			/*--------------------------------------------------------------*/
			/* Totalizar Rubro		es invocado desde el proceso callBack	*/
			/*--------------------------------------------------------------*/
			function TotalizarRubro(oFilaActual,ArrMonto,NroColumna)
			{
				oNodoItem = ObtenerNodoItem(oFilaActual);
				oNodoItemPadre = oNodoItem.NodoPadre;
				oDataGrid = oNodoItem.DataGrid;
				idFilaResumen = ObtenerIdFilaNodoPrincipal(oNodoItemPadre);
				idFilaActual = ObtenerIdFilaNodoPrincipal(oNodoItem);
				
				oDataGrid.rows[parseInt(idFilaResumen)].cells(parseInt(NroColumna)).innerText = ArrMonto[0];
				oDataGrid.rows[parseInt(idFilaResumen)].cells(13).innerText = ArrMonto[1];
				oDataGrid.rows[parseInt(idFilaActual)].cells(13).innerText = ArrMonto[2];
			}
			/*--------------------------------------------------------------*/
			/*--------------------------------------------------------------*/
			
			
			/*Utilizados en los procesos remotos CALLBACK*/	
			var arrDataFormulacion = new Array();
			arrDataFormulacion.CargarDatos= function(oFormulacionPartida5DigBE,Estado){
				if (Estado==false)
				{
					this[this.length] = new Array();
					this[this.length-1] = oFormulacionPartida5DigBE;
				}
				PrcTerminado = Estado
			}
			arrDataFormulacion.ObtenerEntidad = function(Indice){
				return this[Indice];
			}
			
			
			arrDataFormulacion.Remover = function(){
				try
				{
					Long = this.length-1;
					for (var i=0;i<=Long;i++){this.pop();} 
				}
				catch(error){}
			}


		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Presupuesto> Administración Presupuestal por Centro de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="HeaderGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="NombreCuenta" HeaderText="NATURALEZA DE GASTO">
									<HeaderStyle Width="35%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="PPTO&lt;BR&gt;ANUAL"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="PPTO&lt;BR&gt;AL&lt;BR&gt;MES"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="ENERO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="FEBRERO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="MARZO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="ABRIL">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="MAYO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="JUNIO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="JULIO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="AGOSTO">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="SETIEMBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="OCTUBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="NOVIEMBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="DICIEMBRE">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="TOTAL&lt;BR&gt;REAL">
									<HeaderStyle Width="7.14%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn HeaderText="VARIACION&lt;BR&gt;AL&lt;BR&gt;MES"></asp:BoundColumn>
								<asp:BoundColumn HeaderText="SALDO"></asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
							<TR>
								<TD width="45%"><INPUT id="hidMes" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" runat="server"
										NAME="hidMes">&nbsp;</TD>
								<TD>
									<TABLE id="tblTool" cellSpacing="0" cellPadding="0" width="85%" align="left" border="0">
										<TR>
											<TD><IMG onmouseup="this.src='../../imagenes/QuitarC.GIF';" onmousedown="this.src='../../imagenes/Quitar.GIF';"
													id="btnMostrarIzq" onmouseover="this.src='../../imagenes/QuitarB.GIF';" onclick="ScrollColumnas('Izquierda');"
													onmouseout="this.src='../../imagenes/QuitarA.GIF';" src="../../imagenes/QuitarA.GIF"
													name="btnQuitar"></TD>
											<TD width="90%"><FONT></FONT></TD>
											<TD><IMG onmouseup="this.src='../../imagenes/AgregarC.GIF';" onmousedown="this.src='../../imagenes/Agregar.GIF';"
													id="btnMostrarDer" onmouseover="this.src='../../imagenes/AgregarB.GIF';" onclick="ScrollColumnas('Derecha');"
													onmouseout="this.src='../../imagenes/AgregarA.GIF';" src="../../imagenes/AgregarA.GIF"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
