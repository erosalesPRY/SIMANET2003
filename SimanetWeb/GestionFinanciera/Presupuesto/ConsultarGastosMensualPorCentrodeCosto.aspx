<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarGastosMensualPorCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarGastosMensualPorCentrodeCosto" %>
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
		<script>
			var ParentDocument = window.parent.document.body.document;
			var tbl = ParentDocument.all["tblResumen"];		
			tbl.style.display="none";
			tbl = ParentDocument.all["tblResumenMensual"];
			tbl.style.display="block";
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
				var KEYQMODO="Modo";
				var KEYQPPTO = "VISTAPPTO";
				var KEYQUIENLLAMA = "QLlama";
				var oNodoItem;
				
			function NodeItem_OnClick(e){
				if(e==undefined)e = window.event.srcElement;//Objeto Imagen
				
				oNodoItem = new SIMA.Utilitario.Helper.General.Treeview.Nodo.Item();
				oNodoItem = e.getAttribute("oNodoItem");
				oDataGridFilaActual = oNodoItem.DataGridFila;
			
				//Se obtiene la relacion de cuentas contable a nivel de 5 dig;
				oPagina= new SIMA.Utilitario.Helper.General.Pagina();
				
				var Parametros;
				var strListaParametros;
				var oDataTable = new System.Data.DataTable("Table");
				try{
					oDataTable = (new Controladora.Presupuesto.CEvaluacion()).ConsultarEvaluacionMensualCentrosdeCostoDetalleCta5Dig(oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
																																,oPagina.Request.Params[KEYQIDCENTROOPERATIVO]
																																,oPagina.Request.Params[KEYQIDGRUPOCC]
																																,oPagina.Request.Params[KEYQIDCENTROCOSTO]
																																,oPagina.Request.Params[KEYQPERIODO]
																																,oDataGridFilaActual.getAttribute("CuentaContable3Dig")
																																);
						for (var i=0; i <= oDataTable.Rows.Items.length-1; i++){
							dr = oDataTable.Rows.Items[i];
							if(dr.Item("EOF")==false){
								var DigGrupoCta = dr.Item("CuentaContable").toString().charAt(2);
								oDataGridFilaNueva = SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(i,dr.Item("CuentaContable") + " " + dr.Item("NombreCuenta"),false,null, ((DigGrupoCta =='10' || DigGrupoCta =='30')?MostrarListadoporNaturalezadeGasto:null),e);
								oDataGridFilaNueva.cells[1].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.ENERO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[2].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.FEBRERO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[3].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.MARZO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[4].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.ABRIL))).toString(2,true,' ');
								oDataGridFilaNueva.cells[5].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.MAYO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[6].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.JUNIO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[7].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.JULIO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[8].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.AGOSTO))).toString(2,true,' ');
								oDataGridFilaNueva.cells[9].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.SETIEMBRE))).toString(2,true,' ');
								oDataGridFilaNueva.cells[10].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.OCTUBRE))).toString(2,true,' ');
								oDataGridFilaNueva.cells[11].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.NOVIEMBRE))).toString(2,true,' ');
								oDataGridFilaNueva.cells[12].innerText = (new SIMA.Numero(dr.Item(SIMA.Utilitario.Enumerados.Mes.Nombre.DICIEMBRE))).toString(2,true,' ');
				
								var Collecion= new Enumerator(oDataGridFilaNueva.cells);
								for(Collecion.moveFirst(); !Collecion.atEnd(); Collecion.moveNext()){
									if(parseInt(Collecion.item().CellIndex,10) >=1){
										Collecion.item().align = SIMA.Utilitario.Constantes.Html.Atributos.Alineacion.Derecha.toString();
									}
								}
								delete Collecion;
								Collecion = null;
							}
						}																																
					
				}
				catch(error){
					window.alert(error.description);
				}				
				return "Cargado";
			}
			
			function MostrarListadoporNaturalezadeGasto(){
				window.alert("Mostrar detalle");
			}
			
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" 
		bottomMargin="0" bgColor="gainsboro" leftMargin="0" topMargin="0" onload="try{ObtenerHistorial();}catch(e){}">
		<form id="Form1" method="post" runat="server">
			<TABLE id="tblContenedor" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto> Evaluación Presupuestal por Centro de Costo</asp:label></TD>
				</TR>
				<TR>
					<TD align="left"><cc1:datagridweb id="grid" runat="server" ShowFooter="True" Width="100%" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" PageSize="7">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="NombreCuenta" HeaderText="NATURALEZA DE GASTO">
									<HeaderStyle Width="20%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Enero" HeaderText="ENE">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Febrero" HeaderText="FEB">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Marzo" HeaderText="MAR">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Abril" HeaderText="ABR">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Mayo" HeaderText="MAY">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Junio" HeaderText="JUN">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Julio" HeaderText="JUL">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Agosto" HeaderText="AGO">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Setiembre" HeaderText="SET">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Octubre" HeaderText="OCT">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Noviembre" HeaderText="NOV">
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Top"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Diciembre" HeaderText="DIC">
									<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD id="ToolBarPersonal" align="center"><INPUT id="hListadePersonal" style="WIDTH: 138px; HEIGHT: 22px" type="hidden" size="17"
							runat="server" NAME="hListadePersonal"><INPUT id="hPathFotos" style="WIDTH: 138px; HEIGHT: 22px" type="hidden" size="17" name="Hidden1"
							runat="server">
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
			var ParentDocument = window.parent.document.body.document;
			var Collecion= new Enumerator($O("grid").rows[0].cells);
			for(Collecion.moveFirst(); !Collecion.atEnd(); Collecion.moveNext()){
				var _idx = Collecion.item().cellIndex;
				var _Ancho = parseInt(Collecion.item().offsetWidth,10) + ((_idx==0)?280:0);
				ParentDocument.all["tblResumenMensual"].rows[0].cells[_idx].width = _Ancho + "px";
			}
			delete Collecion;
			Collecion = null;			
					
		</script>		
	</body>
</HTML>
