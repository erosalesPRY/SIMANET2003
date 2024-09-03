<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DefaultTransferencia.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.DefaultTransferencia" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DefaultCentrosdeCosto</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
			var ArrDatosRemotos = new Array();
			var KEYIDREQUERIMIENTO="idrqr";
			var KEYQIDCENTRO = "idCentroOperativo";
			var KEYIDCC = "IdCentroCosto";
			var KEYIDNROCC = "NroCC";
			var KEYIDNOMBRECC = "NombreCC";
			var KEYQIDGRUPOCC="idGrupoCC";

			var KEYIDPERIODO = "Periodo";
			var KEYIDMES = "idMes";
			var KEYQTIPOPRESUPUESTO="idTP";
			var KEYQIDTRANSFERENCIA="idTransf";
			
			function ObtenerListadodeCentrosdeCostoConRequerimiento(){
					var URLPAGINATRASNFERENCIA ="AdministrarTransferenciasdePartidas.aspx?";
					var oDataTable = new System.Data.DataTable("tblCC");
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					try{
						oDataTable = (new Controladora.Presupuesto.CRequerimientos()).ConsultarRequerimientosCentrosdeCosto(oPagina.Request.Params[KEYIDREQUERIMIENTO]);
						var PathApp = SIMA.Utilitario.Helper.General.ObtenerPathApp();
						oTabStrip= new SIMA.Utilitario.Helper.General.TabStrip(document.all["divContenedor"]);
						oTabStrip.PathImagen=PathApp + "/Imagenes/Tabs/";
						
						with(SIMA.Utilitario.Constantes.General.Caracter){
							for (var i=0; i <= oDataTable.Rows.Items.length-1; i++) 
							{
								dr = oDataTable.Rows.Items[i];
								if(dr.Item("EOF")==false){
									oTab = new SIMA.Utilitario.Helper.General.Tab();
									oTab.Texto = dr.Item("NombreCentroCosto");
									var Parametros = KEYIDREQUERIMIENTO + SignoIgual + oPagina.Request.Params[KEYIDREQUERIMIENTO]
												+ signoAmperson 
												+ KEYQIDCENTRO + SignoIgual + dr.Item("idCentroOperativo")
												+ signoAmperson 
												+ KEYQIDGRUPOCC + SignoIgual + dr.Item("idGrupoCC")
												+ signoAmperson 
												+ KEYIDCC + SignoIgual + dr.Item("idCentroCosto")
												+ signoAmperson 
												+ KEYIDNROCC + SignoIgual + dr.Item("NroCentroCosto")
												+ signoAmperson 
												+ KEYIDNOMBRECC + SignoIgual + dr.Item("NombreCentroCosto")
												+ signoAmperson 
												+ KEYIDPERIODO + SignoIgual + dr.Item("Periodo")
												+ signoAmperson 
												+ KEYIDMES + SignoIgual + dr.Item("idMes")
												+ signoAmperson 
												+ KEYQIDTRANSFERENCIA + SignoIgual + dr.Item("idTransferencia")
												+ signoAmperson 
												+ KEYQTIPOPRESUPUESTO + SignoIgual + oPagina.Request.Params[KEYQTIPOPRESUPUESTO];
									
									oTab.Url = URLPAGINATRASNFERENCIA + Parametros;
									oTab.ToolTips = dr.Item("NroCentroCosto")+ " " + dr.Item("NombreCentroCosto");
									oTabStrip.Tabs.Adicionar(oTab);
								}
								else if(dr.Item("EOF")==true){
									Agregar();
								}
							}
						}
						oTabStrip.RepintarTabs();
						oTabStrip.Tabs.Tab(0).Click();
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
			}
			/*-------------------------------------------------------------------------------------------------------------------*/
			function Agregar(){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				var URLPAGINA = "AgregarCentrosdeCostosTransferencias.aspx?"
				var KEYQQUIENLLAMA = "QLLAMA";
				with(SIMA.Utilitario.Constantes.General.Caracter){
					WindMostraVentaModal(URLPAGINA + KEYQQUIENLLAMA + SignoIgual + "Solicita"
													+ signoAmperson
													+ KEYQTIPOPRESUPUESTO + SignoIgual + oPagina.Request.Params[KEYQTIPOPRESUPUESTO]
													+ signoAmperson
													+ KEYIDREQUERIMIENTO + SignoIgual + oPagina.Request.Params[KEYIDREQUERIMIENTO]
												,"",480,200);
				}
				try{
					var oTransferenciaBE = new EntidadesNegocio.Presupuesto.TransferenciaBE();
					oTransferenciaBE.idTransferencia = 0;
					oTransferenciaBE.idRequerimiento = oPagina.Request.Params[KEYIDREQUERIMIENTO];
					oTransferenciaBE.idCentroOperativo = ArrDatosRemotos[1];
					oTransferenciaBE.idGrupoCC = ArrDatosRemotos[2];
					oTransferenciaBE.idCentroCosto = ArrDatosRemotos[3];
					oTransferenciaBE.Periodo = oPagina.Request.Params[KEYIDPERIODO];
					oTransferenciaBE.idMes = ArrDatosRemotos[0];
					var id =(new Controladora.Presupuesto.CTransferencia()).Insertar(oTransferenciaBE);
					if (parseInt(id)>0){
						var arrCCRelacionado = ArrDatosRemotos[4].toString().split(";");
						for(var r=0;r<=arrCCRelacionado.length-1;r++){
							GuardarCentrosdeCostosRelacionado(id,arrCCRelacionado[r]);
						}
						window.document.location.reload();
					}				
				}
				catch(error){
					switch(error.number){
						case -2146823279:
								window.alert("ERROR:NUMERO: " + error.number + "\nDESCRIPTCION : " + error.description);
							break;
						default:
							break;
					}
					
				}
			}
			/*-------------------------------------------------------------------------------------------------------------------*/
			function GuardarCentrosdeCostosRelacionado(widTransferencia,idCentroCostoRelacionado){
				var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				try{
					var oTransferenciaBE = new EntidadesNegocio.Presupuesto.TransferenciaBE();
					oTransferenciaBE.idTransferencia = widTransferencia;
					oTransferenciaBE.idRequerimiento = oPagina.Request.Params[KEYIDREQUERIMIENTO];
					oTransferenciaBE.idCentroOperativo = ArrDatosRemotos[1];
					oTransferenciaBE.idGrupoCC = ArrDatosRemotos[2];
					oTransferenciaBE.idCentroCosto = idCentroCostoRelacionado;
					oTransferenciaBE.Periodo = oPagina.Request.Params[KEYIDPERIODO];
					oTransferenciaBE.idMes = ArrDatosRemotos[0];
					(new Controladora.Presupuesto.CTransferencia()).Insertar(oTransferenciaBE);
				}
				catch(error){
					switch(error.number){
						case -2146823279:
								window.alert("ERROR:NUMERO: " + error.number + "\nDESCRIPTCION : " + error.description);
							break;
						default:
							break;
					}
				}
				
				
		}
		
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerListadodeCentrosdeCostoConRequerimiento();ObtenerHistorial();"
		onunload="SubirHistorial();" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr >
					<td  width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr>
					<td vAlign="top" width="100%" bgColor="#eff7fa"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Presupuestos por Grupos de Centros de Costos</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table1" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<TR>
								<TD align="left" width="100%">
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="left" border="0">
										<TR bgColor="#f0f0f0">
											<TD colSpan="2"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="128px"> REQUERIMIENTO :</asp:label></TD>
											<TD width="100%" colSpan="2"><asp:label id="lblRequerimiento" runat="server" CssClass="TextoNegroNegrita" Width="432px"> ....:</asp:label></TD>
											<TD style="WIDTH: 69px"></TD>
											<TD></TD>
										</TR>
										<TR>
											<TD colSpan="6"><IMG id=ibtnAgregar 
                  onclick=Agregar(); alt="" 
                  src="../../imagenes/Otros/ibtnIncluirCC.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
        <TR>
								<TD id="divContenedor" align="left" width="100%"></TD></TR>
							<TR>
								<TD><IMG id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
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
