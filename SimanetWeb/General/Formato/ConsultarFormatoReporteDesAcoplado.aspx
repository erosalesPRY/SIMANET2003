<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarFormatoReporteDesAcoplado.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.ConsultarFormatoReporteDesAcoplado" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProcesarFormatoInterConexion</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT language="javascript" src="../../js/JQuery/js/jquery.min.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JQuery/js/JQueryPlugInSIMA.js"></SCRIPT>
		<script>
			var KEYIDEMPRESA ="idEmp";
			var KEYQPERIODO = "Periodo";
			var KEYQIDGRUPOFORMATO="IdGrupoFormato";
			var IDCENTROOPERATIVO="idcop";
			var KEYQIDGRUPOCC = "idGrpCC";
			var KEYQIDCENTROCOSTO ="idCC";
			var KEYQIDTIPOINFO ="idTipoInfo";
			var KEYQREQCC ="ReqCC";
			var KEYQIDREPORTE = "IdReporte";
			var KEYQIDFORMATO="IdFormato";
			var KEYQNOMBREFORMATO="NFormato";
			
			var KEYQREQCTACTABLE="ReqCtaCtable"
			var KEYQACUMULADO="Acum";
			var KEYQCERRADO="Close";
			var KEYQIDTIPOFORMATO ="IdTipForm";
			var KEYQIDGRUPOFORMATO="IdGrupoFormato";
			
			function FormatoBE(INDEX,IDREPORTE,CODIGO,NOMBRE,REQCENTROCOSTO,REQCTACTABLE){
				this.Index=INDEX;
				this.IdReporte=IDREPORTE;
				this.Codigo=CODIGO;
				this.Nombre=NOMBRE;
				this.ReqCentroCosto = REQCENTROCOSTO;
				this.ReqCtaCtable = REQCTACTABLE;
			}
			
		function Formato(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var URLFORMATO = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoDetalleMovimientoporPeriodo.aspx?";
				//var URLFORMATOANEXO = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoAnexoDetalleMovimientoPorPeriodo.aspx?";
				var URLFORMATOANEXO = SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/General/Formato/AdministrarFormatoAnexoDetalleMovPorPeriodoColumnas.aspx?";
				
						
				var Existe=false;
				/*--------------------------------------------------------------------------------------------------*/
				var oddlCentroCosto;
				this.Load=function(IdGrupo){
					var IdCentroCosto=0;
				
					
					var oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip($O("divContenedor"));
					oTabStrip.PathImagen= SIMA.Utilitario.Helper.General.ObtenerPathApp() + "/Imagenes/Tabs/";

					with(SIMA.Utilitario.Constantes.General.Caracter){
							var oDataTable = new System.Data.DataTable("tblFormato");
							//oDataTable = (new Controladora.General.CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(Page.Request.Params[IDCENTROOPERATIVO],Page.Request.Params[KEYQPERIODO],1,Page.Request.Params[KEYQIDTIPOINFO],Page.Request.Params[KEYQIDGRUPOFORMATO]);
							oDataTable = (new Controladora.General.CFormato()).ListarGruposFormAccesoSegunPrivilegioUsuarioUsuarioCtrlCierre(Page.Request.Params[IDCENTROOPERATIVO],Page.Request.Params[KEYQPERIODO],1,Page.Request.Params[KEYQIDTIPOINFO],Page.Request.Params[KEYQIDGRUPOFORMATO]);
							
							
							
							for (f=0;f<=oDataTable.Rows.Items.length-1;f++){
									var oDataRow =oDataTable.Rows.Items[f];
									//alert(oDataRow.Item("IdFormato") +' ' + Page.Request.Params[KEYQIDFORMATO]);
									if((oDataRow.Item("EOF")==false)&&(oDataRow.Item("IdFormato")== Page.Request.Params[KEYQIDFORMATO])&&(oDataRow.Item("IdReporte")== Page.Request.Params[KEYQIDREPORTE])){
									//if((oDataRow.Item("EOF")==false)){
										Existe=true;
										var oFormatoBE = new FormatoBE();
										oFormatoBE.Index=f;
										oFormatoBE.IdReporte=oDataRow.Item("IdReporte");
										oFormatoBE.Codigo=oDataRow.Item("IdFormato");
										oFormatoBE.Nombre=oDataRow.Item("Nombre");
										oFormatoBE.ReqCentroCosto=oDataRow.Item("ReqCentroCosto");
										oFormatoBE.ReqCtaCtable= oDataRow.Item("ReqCtaCtable");
										
										var ParametrosFormato = KEYQIDFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  oFormatoBE.Codigo
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDREPORTE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  oFormatoBE.IdReporte
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQNOMBREFORMATO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() +  oFormatoBE.Nombre
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Page.Request.Params[KEYQPERIODO]
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ IDCENTROOPERATIVO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Page.Request.Params[IDCENTROOPERATIVO]
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDCENTROCOSTO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Page.Request.Params[KEYQIDCENTROCOSTO]
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDTIPOINFO  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + Page.Request.Params[KEYQIDTIPOINFO]
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQREQCC + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + oFormatoBE.ReqCentroCosto
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQREQCTACTABLE + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual.toString() + oFormatoBE.ReqCtaCtable
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQACUMULADO + SignoIgual.toString() +  oDataRow.Item("Acumulado")
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQCERRADO+ SignoIgual.toString() +  oDataRow.Item("Cerrado")
																+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson.toString()
																+ KEYQIDTIPOFORMATO + SignoIgual.toString() +  oDataRow.Item("IdTipoFormato");
																
																
																
										oTab = new SIMA.Utilitario.Helper.General.Tab(oFormatoBE.Nombre,((oDataRow.Item("IdTipoFormato")==1)?URLFORMATO:URLFORMATOANEXO) + ParametrosFormato ,"Administrar " + oFormatoBE.Nombre);
										oTab.Tag = oFormatoBE;
										//oTab.EventHandle = TabSeleccionado;						
										oTabStrip.Tabs.Adicionar(oTab);
									}
							}
							if(Existe==true){
									oTabStrip.RepintarTabs();
									window.setTimeout(function(){oTabStrip.Tabs.Tab(0).Click();},200);
							}
							else{
								//$O("tblOpciones").style.display="none";
							}
					}
				}
				/*--------------------------------------------------------------------------------------------------*/

			}
			var oFormato = new Formato();
				
	
		</script>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="1" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD id="divContenedor"></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		
		<script>
			oFormato.Load(Page.Request.Params[KEYQIDGRUPOFORMATO]);
		</script>
	</body>
</HTML>
