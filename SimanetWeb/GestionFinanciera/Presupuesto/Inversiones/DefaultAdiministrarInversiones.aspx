<%@ Page language="c#" Codebehind="DefaultAdiministrarInversiones.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones.DefaultAdiministrarInversiones" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultCentrosdeCosto</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<script>
				var KEYQMODODETALLE = "MODODETALLE";
				
				var PROCESO ="idProceso";//Indicador de Proceso 
				var KEYQTIPOPRESUPUESTO ="idtp";
				
				var KEYQIDCENTROOPERATIVO="idcop";//CentroOPerativo de la pagina de Procesos
				
				var KEYQCENTROOPERATIVONOMBRE = "NombreCentro";
				var KEYQIDGRUPOCC = "idGrpCC";
				var KEYQNOMBREGRUPOCC = "NombreGrpCC";
				var KEYQTIPOOPCION = "Opcion";
				var KEYQIDCENTROCOSTO ="idCC";
				var KEYQPERIODO="Periodo";
				var KEYQIDTIPOINFORMACION="idTipoInfo";
				
			function LlenarCombos(){
				ListarTipoInformacion();
				ListarCentrosOperativos();
				ObtenerListadodeCentrosdeCostoInversiones();
			}
			
			function ListarTipoInformacion(){
				var oDataTable;
				try{
					var oDataTable = (new Controladora.General.CTipoInformacion()).ListarTipodeInformacion();
								
					var oddlTipoInformacion = new System.Web.UI.WebControls.DropDownList("ddlTipoInformacion");
					oddlTipoInformacion.DataSource = oDataTable;
					oddlTipoInformacion.DataTextField="descripcion";
					oddlTipoInformacion.DataValueField="codigo";
					oddlTipoInformacion.SelectedIndexChanged = oddlTipoInformacion_SelectedIndexChanged;
					oddlTipoInformacion.DataBind();
				}
				catch(error){
					window.alert(error);
				}
			}
			function oddlTipoInformacion_SelectedIndexChanged(){
				ObtenerListadodeCentrosdeCostoInversiones();
			}
				
			function ListarCentrosOperativos(){
				var IDTABLAESTADO = 451;//446
				var oDataTable;
				try{
					var oDataTable = (new Controladora.General.CCentroOperativo()).ListarCentroOperativoAccesoSegunPrivilegioUsuario(IDTABLAESTADO);
				}
				catch(error){
					window.alert(error);
				}				
					var oddlCentroOperativo = new System.Web.UI.WebControls.DropDownList("ddlCentroOperativo");
					oddlCentroOperativo.DataSource = oDataTable;
					oddlCentroOperativo.DataTextField="NOMBRE";
					oddlCentroOperativo.DataValueField="IDCENTROOPERATIVO";
					oddlCentroOperativo.SelectedIndexChanged = SelectedIndexChanged;
					oddlCentroOperativo.DataBind();
					SelectedIndexChanged();
				
			}
			function SelectedIndexChanged(){
				ListarGrupodeCentrosdeCosto();
			}
			
			function ListarGrupodeCentrosdeCosto(){
				var oDataTable;
				var oddlCentroOperativo = $O("ddlCentroOperativo");
				var idCentro = oddlCentroOperativo.options[oddlCentroOperativo.selectedIndex].value;
				try{
					oDataTable = (new Controladora.General.GrupoCentrocosto()).ListarGrupoCCXCentroOperativo(idCentro);
				}
				catch(error){
					window.alert(error);
				}		
				
				var oddlGrupoCC = new System.Web.UI.WebControls.DropDownList("ddlGrupoCC");
				oddlGrupoCC.DataSource = oDataTable;
				oddlGrupoCC.DataTextField="NOMBRE";
				oddlGrupoCC.DataValueField="IDGRUPOCC";
				oddlGrupoCC.SelectedIndexChanged = ObtenerListadodeCentrosdeCostoInversiones;
				oddlGrupoCC.DataBind();
			}	
			
			function ObtenerListadodeCentrosdeCostoInversiones(){
					var oddlGrupoCC = $O("ddlGrupoCC")
					var idGrupoCC = oddlGrupoCC.options[oddlGrupoCC.selectedIndex].value;
					
					var oddlCentroOperativo = $O("ddlCentroOperativo");
					var idCentro = oddlCentroOperativo.options[oddlCentroOperativo.selectedIndex].value;
					
					var oddlTipoInformacion = $O("ddlTipoInformacion");
					var idTipoInfo = oddlTipoInformacion.options[oddlTipoInformacion.selectedIndex].value;
					
					var URLPAGINATRASNFERENCIA ="AdministrarInversionesPorCentrodeCosto.aspx?";
					var oDataTable = new System.Data.DataTable("tblCC");
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					try{
						oDataTable = (new Controladora.General.CentroCosto()).ListarCentroCostoPorGrupoCC(idGrupoCC);
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
					
					var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
					oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
					oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
					
					with(SIMA.Utilitario.Constantes.General.Caracter){
						for (var i=0; i <= oDataTable.Rows.Items.length-1; i++){
							dr = oDataTable.Rows.Items[i];
							if(dr.Item("EOF")==false){
								oTab = new SIMA.Utilitario.Helper.General.Tab();
								oTab.Texto = dr.Item("NOMBRE");
								var Parametros=KEYQPERIODO + SignoIgual + $O("txtPeriodo").value
								+ signoAmperson 
								+ KEYQIDCENTROCOSTO + SignoIgual + dr.Item("IDCENTROCOSTO")
								+ signoAmperson 
								+ KEYQIDCENTROOPERATIVO + SignoIgual + idCentro
								+ signoAmperson 
								+ KEYQIDTIPOINFORMACION + SignoIgual + idTipoInfo;
								
								oTab.Url = URLPAGINATRASNFERENCIA + Parametros;
								oTab.ToolTips = dr.Item("NROCC")+ " " + dr.Item("NOMBRE");
								oTabStrip.Tabs.Adicionar(oTab);
							}
							else if(dr.Item("EOF")==true){
								window.alert("No existen centros de costos en inversiones");
							}
						}
					}
					oTabStrip.RepintarTabs();
					oTabStrip.Tabs.Tab(0).Click();
			}
			
			/*-------------------------------------------------------------------------------------------------------------------*/
			function txtPeriodo_onKeyDown(){
				if(window.event.keyCode==13){
					window.alert(this.value);
					ObtenerListadodeCentrosdeCostoInversiones();
				}
			}				

			
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="LlenarCombos();ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td id="tdHeader" width="100%" colSpan="1" runat="server"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td id="tdMenu" vAlign="top" width="100%" bgColor="#eff7fa" runat="server"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera>Presupuesto></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos Inversiones por Centros de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
							<TR>
								<TD align="left" width="100%">
									<TABLE id="Table2" style="HEIGHT: 33px" cellSpacing="0" cellPadding="0" width="100%" align="left"
										border="0">
										<TR bgColor="#f0f0f0">
											<TD id="tdCentro" style="WIDTH: 200px; HEIGHT: 16px" colSpan="2" runat="server"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="128px">CENTRO OPERATIVO :</asp:label></TD>
											<TD id="tdCentro1" style="WIDTH: 405px; HEIGHT: 16px" colSpan="2" runat="server"><asp:dropdownlist id="ddlCentroOperativo" runat="server" Width="144px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 144px; HEIGHT: 16px"></TD>
											<TD style="HEIGHT: 16px"></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 200px; HEIGHT: 11px" colSpan="2"><asp:label id="Label2" runat="server" CssClass="TextoNegroNegrita" Width="161px">GRUPO CENTRO DE COSTO :</asp:label></TD>
											<TD style="WIDTH: 405px; HEIGHT: 11px" colSpan="2"><asp:dropdownlist id="ddlGrupoCC" runat="server" Width="352px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 144px; HEIGHT: 11px"></TD>
											<TD style="HEIGHT: 11px"></TD>
										</TR>
										<TR id="trPeriodo" bgColor="#f0f0f0" runat="server">
											<TD style="WIDTH: 200px" colSpan="2"><asp:label id="Label5" runat="server" CssClass="TextoNegroNegrita" Width="80%">PERIODO :</asp:label></TD>
											<TD style="WIDTH: 14px"><asp:textbox id="txtPeriodo" runat="server" CssClass="normaldetalle" Width="48px">2008</asp:textbox></TD>
											<TD style="WIDTH: 317px">
												<asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita" Width="136px">TIPO INFORMACION :</asp:label>
												<asp:dropdownlist id="ddlTipoInformacion" runat="server" CssClass="normaldetalle" Width="160px"></asp:dropdownlist></TD>
											<TD style="WIDTH: 504px"></TD>
											<TD></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD id="divContenedor" align="left" width="100%"></TD>
							</TR>
							<TR>
								<TD align="left" width="100%"></TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="PaginaAtras();" alt="" src="../../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
