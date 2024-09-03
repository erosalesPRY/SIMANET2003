<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AgregarCentrosdeCostosTransferencias.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AgregarCentrosdeCostosTransferencias" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Buscar Grupo de Centro de Costo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<style type="text/css">DIV.scroll { BORDER-RIGHT: #666 1px solid; BORDER-TOP: #666 1px solid; OVERFLOW: auto; BORDER-LEFT: #666 1px solid; WIDTH: 300px; BORDER-BOTTOM: #666 1px solid; HEIGHT: 100px }
		</style>
		<script>
			var KEYQIDCENTRO = "idCentroOperativo";
			var KEYQIDGRUPOCC="idGrupoCC";
			var KEYQTIPOPRESUPUESTO="idTP";
			var KEYIDREQUERIMIENTO="idrqr";
			var KEYQQUIENLLAMA = "QLLAMA";
			var idMes=0;
			var idCentroOperativo=0;
			var idGrupoCentroCosto=0;
			var idCentroCosto=0;
			
			var stbIndex =0;//para seleccionar el centro operativo que se selecciono en el requerimiento
			function LlenarCombos(){
				CargarMeses();
				CargarTabsCentroOperativos();
			}
			
			
			CargarTabsCentroOperativos=function(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					try{
						var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
						oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
						oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
						oTabStrip.TipoInterfaz = SIMA.Utilitario.Helper.General.Tabs.TipoInterfaz.SoloParaParametros;
						
						var oDataTable=(new Controladora.General.CCentroOperativo()).ListarCentroOperativoAccesoSegunPrivilegioUsuario(414);
						var sNroTab=0;
						with(SIMA.Utilitario.Constantes.General.Caracter){
							for (var i=0; i <= oDataTable.Rows.Items.length-1; i++) 
							{
								dr = oDataTable.Rows.Items[i];
								if(dr.Item("EOF")==false){
									oTab = new SIMA.Utilitario.Helper.General.Tab();
									oTab.Texto = dr.Item("NOMBRE");
									oTab.ToolTips = dr.Item("NOMBRE")+ " " + dr.Item("IDCENTROOPERATIVO");
									oTab.Tag = dr.Item("IDCENTROOPERATIVO");
									oTab.EventHandle=MostrarGruposdeCentrodeCosto;
									oTabStrip.Tabs.Adicionar(oTab);
									if((oPagina.Request.Params[KEYQQUIENLLAMA]!='Transfiere')&& (oPagina.Request.Params[KEYQIDCENTRO])){
										stbIndex =sNroTab;
									}
									sNroTab++;								
								}
							}
						}
						oTabStrip.RepintarTabs();
						oTabStrip.Tabs.Tab(stbIndex).Click();
					}
					catch(error){
					}			
			}
			
			MostrarGruposdeCentrodeCosto=function(){
				var  ohidCentroOperativo = (new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('hidCentroOperativo');
				ohidCentroOperativo.value = this.Tag;
				CargarGrupodeCentrodeCosto(ohidCentroOperativo.value);
				var oddlGrupoCC = document.all["ddlGrupoCC"];
				CargarCentrodeCosto(oddlGrupoCC);
			}
			
			function CargarGrupodeCentrodeCosto(idCentroOperativo){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var oddlGrupoCC = new System.Web.UI.WebControls.DropDownList('ddlGrupoCC');
				var idTipoPresupuesto = oPagina.Request.Params[KEYQTIPOPRESUPUESTO];
				oddlGrupoCC.DataSource = (new Controladora.Presupuesto.CRequerimientos()).RequerimientoListarGruposdeCentrosdeCosto(idTipoPresupuesto,idCentroOperativo);
				oddlGrupoCC.DataTextField = "NombreGrupoCentroCosto";
				oddlGrupoCC.DataValueField = "idGrupoCentroCosto";
				oddlGrupoCC.SelectedIndexChanged = CargarCentrodeCosto;
				oddlGrupoCC.DataBind();
				try{
					ListItem = oddlGrupoCC.FindByValue(oPagina.Request.Params[KEYQIDGRUPOCC]);
				}catch(error){}
			}
			
			function CargarCentrodeCosto(e){
				try{
					idGrupoCentroCosto =e.options[e.selectedIndex].value;
				}
				catch(error){
					idGrupoCentroCosto =this.options[this.selectedIndex].value;
				}
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var idCentroOperativo = (new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('hidCentroOperativo').value;
				var oddlCentroCosto = new System.Web.UI.WebControls.DropDownList('ddlCentroCosto');
				oddlCentroCosto.DataSource = (new Controladora.Presupuesto.CRequerimientos()).RequerimientoListarCentrosdeCosto(oPagina.Request.Params[KEYIDREQUERIMIENTO],oPagina.Request.Params[KEYQTIPOPRESUPUESTO],idCentroOperativo,idGrupoCentroCosto);
				oddlCentroCosto.DataTextField = "NombreCentroCosto";
				oddlCentroCosto.DataValueField = "idCentroCosto";
				oddlCentroCosto.DataBind();
			}
			/*obtiene id*/
			function ObteneridCentroCosto(){
				idCentroCosto = this.options[this.selectedIndex].value;
			}

			function CargarMeses(){
				var fecha=new Date();
				var idMesActual = fecha.getMonth()+1;
				var oddlMes = new System.Web.UI.WebControls.DropDownList('ddlMes');
				var arrDataMes = new Array(12)
				with(SIMA.Utilitario.Enumerados.Mes.Nombre){
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.ENERO] = ENERO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.FEBRERO] = FEBRERO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.MARZO] = MARZO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.ABRIL] = ABRIL.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.MAYO] = MAYO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.JUNIO] = JUNIO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.JULIO] = JULIO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.AGOSTO] = AGOSTO.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.SETIEMBRE] = SETIEMBRE.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.OCTUBRE] = OCTUBRE.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.NOVIEMBRE] = NOVIEMBRE.toString().toUpperCase();
					arrDataMes[SIMA.Utilitario.Enumerados.Mes.Numero.DICIEMBRE] = DICIEMBRE.toString().toUpperCase();					
				}
				for(var i=idMesActual;i<=arrDataMes.length-1;i++){
					oddlMes.AgregarOpcion(arrDataMes[i].toString().toUpperCase(),i);
				}
				
				oddlMes.SelectedIndexChanged =ddlMes_onChange;
				oddlMes.DataBind();
				ListItem = oddlMes.FindByValue(fecha.getMonth()+1);
				//Asiagna el valor del Mes Selecconado
				ddlMes_onChange((new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('ddlMes'));
				//se oculta el ddlMes si el valor es Solicita
				if((new SIMA.Utilitario.Helper.General.Pagina()).Request.Params[KEYQQUIENLLAMA]=="Solicita"){
					oParente = oddlMes.Parent();
					oParente.setAttribute("idMes",ListItem.value);
					oParente.innerText = ListItem.text;
				}				
			}
			ddlMes_onChange=function(e){
				var  oddlMes = (new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('hidMes');
				try{
					oddlMes.value = this.options[this.selectedIndex].value;
				}
				catch(error){
					oddlMes.value = e.options[e.selectedIndex].value;
				}
			}
			
			
			function EntregarDatosWindowRemoto(){
				ArrDatosRemotos[0]=(new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('hidMes').value;
				ArrDatosRemotos[1]=(new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('hidCentroOperativo').value;
				var oddl = (new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('ddlGrupoCC');
				ArrDatosRemotos[2]=oddl.options[oddl.selectedIndex].value;
				oddl = (new SIMA.Utilitario.Helper.General.Html()).CrearInstancia('ddlCentroCosto');
				ArrDatosRemotos[3]=oddl.options[oddl.selectedIndex].value;
				ArrDatosRemotos[4]=ObtenerListadoDeCentrosdeCostoRelacionado(oddl,ArrDatosRemotos[3]);//Lista de Centros de Costo Relacionados
				window.returnValue=ArrDatosRemotos;
				window.close();
			}
			ObtenerListadoDeCentrosdeCostoRelacionado=function(oddl,ValorOpcionSeleccionada){
				var idRelacionados = "";
				for(var v=0;v<=oddl.options.length-1;v++){
					if(oddl.options[v].value != ValorOpcionSeleccionada){
						idRelacionados += oddl.options[v].value + ";";
					}
				}
				return idRelacionados.toString().substring(0,idRelacionados.length-1);
			}
			
		
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" scroll="no" onload="LlenarCombos();"
		rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR bgColor="#f5f5f5">
					<TD><asp:label id="Label3" runat="server" Width="288px" CssClass="TextoNegroNegrita"> SELECCIONAR CENTRO DE COSTO:</asp:label></TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px"><asp:label id="Label5" runat="server" Width="144px" CssClass="TextoNegroNegrita">MES DE TRANSFERENCIA:</asp:label></TD>
								<TD width="100%" colSpan="3"><asp:dropdownlist id="ddlMes" runat="server" Width="146px" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD id="divContenedor" width="100%" colSpan="4"></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px"><asp:label id="Label2" runat="server" Width="128px" CssClass="TextoNegroNegrita">GRUPO:</asp:label></TD>
								<TD width="100%" colSpan="3"><asp:dropdownlist id="ddlGrupoCC" runat="server" Width="312px" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD style="WIDTH: 128px"><asp:label id="Label4" runat="server" Width="128px" CssClass="TextoNegroNegrita">CENTRO DE COSTO:</asp:label></TD>
								<TD width="100%" colSpan="3"><asp:dropdownlist id="ddlCentroCosto" runat="server" Width="312px" CssClass="normaldetalle"></asp:dropdownlist></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR class="ItemDetalle">
					<TD align="right">
						<TABLE id="Table3" style="WIDTH: 186px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="186"
							align="right" border="0">
							<TR>
								<TD><IMG id="imgAceptar" onclick="EntregarDatosWindowRemoto();" alt="" src="/SimanetWeb/imagenes/bt_aceptar.gif"></TD>
								<TD><SPAN class="normal">
										<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="/SimanetWeb/imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
						&nbsp;
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<INPUT id="hidMes" type="hidden" size="1"><INPUT id="hidCentroOperativo" type="hidden" size="1"></TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
