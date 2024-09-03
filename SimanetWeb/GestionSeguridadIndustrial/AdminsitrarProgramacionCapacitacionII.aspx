<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdminsitrarProgramacionCapacitacionII.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdminsitrarProgramacionCapacitacionII" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPersona_Contratista_Visita</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<style>
			.ContextImg { Z-INDEX: 3; POSITION: relative; WIDTH: 45px; BACKGROUND-REPEAT: no-repeat; HEIGHT: 45px }
			.imgCirc { Z-INDEX: 1; POSITION: absolute; BACKGROUND-REPEAT: no-repeat; TOP: -2px; left-30: }
		</style>
		<script>
			var Pagina = "ListarProgSeleccionPersonal.aspx?";
			var KEYQPERIODO = "Periodo";
			var KEYQSELECCION = "IdSelec";
			var KEYQIDPROGCAP = "IdProg";
			var KEYQPERODOPROGCAP = "PeriodoProg";
			var KEYQREQEVA = "ReqEva";
			
				
			var AdminsitrarProgramacionCapacitacionIIUI= new Object();
			
			AdminsitrarProgramacionCapacitacionIIUI.WindowsAsistencia= "";
			AdminsitrarProgramacionCapacitacionIIUI.ListarPersonalAsistencia=function(Periodo,IdSeleccion,IdProgCap,PeriodoProgCap,RequiereEvaluacion){
				var URL = Pagina + KEYQPERIODO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + Periodo
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQSELECCION  + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdSeleccion
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQIDPROGCAP + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + IdProgCap
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQPERODOPROGCAP + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + PeriodoProgCap
						+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
						+ KEYQREQEVA + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + RequiereEvaluacion;
						
				AdminsitrarProgramacionCapacitacionIIUI.WindowsAsistencia= (new System.Ext.UI.WebControls.Windows()).Dialogo('CONTROL DE ASISTENCIA',URL,this,820,400);
			}
			
			
			AdminsitrarProgramacionCapacitacionIIUI.RegistrarAsistencia=function(IdLstProgAsisCap,IdPersonal,IdProgCap,PeriodoProgCap,oImg,otxtNota){
				if(otxtNota.value!='0'){
					var Estado = ((oImg.style.display=="none")?"1":"0");
					oImg.style.display = ((Estado =="1")?"block":"none");
					var oCapacitacionProgLstPerBE=new EntidadesNegocio.GestionSeguridadIndustrial.CapacitacionProgLstPerBE();
					oCapacitacionProgLstPerBE.IdLstProgAsisCap =IdLstProgAsisCap;
					oCapacitacionProgLstPerBE.IdProgCap=IdProgCap;
					oCapacitacionProgLstPerBE.PeriodoProgCap=PeriodoProgCap;
					oCapacitacionProgLstPerBE.IdPersonal=IdPersonal;	
					oCapacitacionProgLstPerBE.IdEstado=Estado;
					oCapacitacionProgLstPerBE.Nota=((Estado =="1")?otxtNota.value:0);
					otxtNota.value=oCapacitacionProgLstPerBE.Nota;
					var Id= (new Controladora.SeguridadIndustrial.CCCTTuspTADCapacitacion_Prog_Lst_Per()).InsertarUpdate(oCapacitacionProgLstPerBE);
				}
				else{
					Ext.MessageBox.alert('AVISO', 'No se ha NOTA de evaluación ha este trabajador', function(btn){});
				}
			}
			AdminsitrarProgramacionCapacitacionIIUI.RegistrarAsistenciaOnKeyDown=function(IdLstProgAsisCap,IdPersonal,IdProgCap,PeriodoProgCap,oImg,otxtNota){
				if(event.keyCode==13){
					var Estado = ((otxtNota.value!='0')?1:0);
					oImg.style.display = ((Estado =="1")?"block":"none");
					var oCapacitacionProgLstPerBE=new EntidadesNegocio.GestionSeguridadIndustrial.CapacitacionProgLstPerBE();
					oCapacitacionProgLstPerBE.IdLstProgAsisCap =IdLstProgAsisCap;
					oCapacitacionProgLstPerBE.IdProgCap=IdProgCap;
					oCapacitacionProgLstPerBE.PeriodoProgCap=PeriodoProgCap;
					oCapacitacionProgLstPerBE.IdPersonal=IdPersonal;	
					oCapacitacionProgLstPerBE.IdEstado=Estado;
					oCapacitacionProgLstPerBE.Nota=((Estado =="1")?otxtNota.value:0);
					var Id= (new Controladora.SeguridadIndustrial.CCCTTuspTADCapacitacion_Prog_Lst_Per()).InsertarUpdate(oCapacitacionProgLstPerBE);
				}
			}
			
			
			AdminsitrarProgramacionCapacitacionIIUI.Eliminar=function(){
				if(jNet.get('hIdProgCap').value!='0'){
					Ext.MessageBox.confirm('ELIMINAR', 'Desea Ud. Hacer efectiva la eliminación de este registro ahora?', function(btn){
									if(btn=="yes"){
										__doPostBack('btnEliminar','');
									}
								});
				}
				else{
					Ext.MessageBox.alert('PERSONAL', 'No se ha seleccionado registro a ser eliminado', function(btn){});
				}
			}
		</script>
		<script language="javascript">
				function doSearch()
				{
					var tableReg = document.getElementById('gridLst');
					var searchText = document.getElementById('txtBuscar').value.toLowerCase();
					var cellsOfRow="";
					var found=false;
					var compareWith="";
					
					// Recorremos todas las filas con contenido de la tabla
					for (var i = 1; i < tableReg.rows.length; i++)
					{
						cellsOfRow = tableReg.rows[i].getElementsByTagName('td');
						found = false;
						// Recorremos todas las celdas
						for (var j = 0; j < cellsOfRow.length && !found; j++)
						{
							compareWith = cellsOfRow[j].innerHTML.toLowerCase();
							// Buscamos el texto en el contenido de la celda
							if (searchText.length == 0 || (compareWith.indexOf(searchText) > -1))
							{
								found = true;
							}
						}
						if(found)
						{
							tableReg.rows[i].style.display = '';
						} else {
							// si no ha encontrado ninguna coincidencia, esconde la
							// fila de la tabla
							tableReg.rows[i].style.display = 'none';
						}
					}
				}
		</script>
	</HEAD>
	<BODY onunload="SubirHistorial();" onload="ObtenerHistorial();" onkeydown="if (event.keyCode==13)return false"
		bottomMargin="0" leftMargin="0" rightMargin="0" scroll="no" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Seguridad Industrial ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> > Administración  Programación de Capacitación</asp:label></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 818px; HEIGHT: 75px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
							width="818" align="center">
							<TR>
								<TD align="right">
									<TABLE id="Table3" border="0" cellSpacing="1" cellPadding="1" width="100%" align="left">
										<TR>
											<TD></TD>
											<TD></TD>
											<TD></TD>
											<TD width="100%" noWrap align="right"><asp:label id="Label1" runat="server" Font-Size="10pt" Font-Bold="True">Buscar: (Apellidos y Nombres)</asp:label></TD>
											<TD width="100%" align="left"><asp:textbox id="txtApellidos" runat="server" Width="328px"></asp:textbox></TD>
											<TD><asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" ImageUrl="../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
											<TD><IMG style="Z-INDEX: 0" id="ibtnEliminarProg" onclick="AdminsitrarProgramacionCapacitacionIIUI.Eliminar()"
													alt="" src="../imagenes/bt_eliminar.gif" runat="server"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><ALTERNATINGITEMSTYLE CssClass="AlternateItemGrilla">
										<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Width="100%"
											PageSize="20" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
											RowPositionEnabled="False">
											<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
											<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO">
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="IdGrpProgCap" HeaderText="NRO  PROG">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle Wrap="False"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Mensaje" HeaderText="MENSAJE">
													<HeaderStyle Width="50%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn HeaderText="AREAS COMPROMETIDAS">
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												</asp:TemplateColumn>
												<asp:TemplateColumn></asp:TemplateColumn>
											</Columns>
											<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb>
									</ALTERNATINGITEMSTYLE><ITEMSTYLE CssClass="ItemGrilla" Height="20px"></ITEMSTYLE><HEADERSTYLE CssClass="HeaderGrilla"></HEADERSTYLE><FOOTERSTYLE CssClass="FooterGrilla"></FOOTERSTYLE><COLUMNS><ASP:BOUNDCOLUMN HeaderText="NRO"><HEADERSTYLE Width="1%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Center" VerticalAlign="Middle"></ITEMSTYLE>
											<FOOTERSTYLE HorizontalAlign="Left"></FOOTERSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="NRO  PROG" DataField="NroProg">
											<HEADERSTYLE Width="10%"></HEADERSTYLE>
											<ITEMSTYLE Wrap="False"></ITEMSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="DESCRIPCION" DataField="Descripcion">
											<HEADERSTYLE Width="50%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Left" VerticalAlign="Middle"></ITEMSTYLE>
										</ASP:BOUNDCOLUMN>
										<ASP:BOUNDCOLUMN HeaderText="FECHA" DataField="Fecha">
											<HEADERSTYLE Width="3%"></HEADERSTYLE>
											<ITEMSTYLE HorizontalAlign="Left" VerticalAlign="Top" Wrap="False"></ITEMSTYLE>
										</ASP:BOUNDCOLUMN>
									</COLUMNS><PAGERSTYLE CssClass="PagerGrilla" HorizontalAlign="Center" Mode="NumericPages"></PAGERSTYLE></TD>
							</TR>
							<TR>
								<TD align="right"><INPUT style="Z-INDEX: 0; WIDTH: 75px; HEIGHT: 23px" id="hIdProgCap" value="0" size="7"
										type="hidden" name="hNroDoc" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 75px; HEIGHT: 23px" id="hIdPersonal" value="0" size="7"
										type="hidden" name="hNroDoc" runat="server"><asp:button id="btnBuscar" runat="server" Text="Button"></asp:button>
									<asp:button id="btnEliminar" runat="server" Text="Button"></asp:button><INPUT style="Z-INDEX: 0; WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden"
										name="hGridPaginaSort" runat="server"><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<script>
			
	
			function txtApellidos_ItemDataBound(sender,e,dr){
				jNet.get('hIdPersonal').value=dr["idpersonal"];
				__doPostBack('btnBuscar','');
			}			
			
			var oParamCollecionBusqueda = new ParamCollecionBusqueda();
				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre='Nombres';
				oParamBusqueda.Texto='Apellidos y Nombres';
				oParamBusqueda.LongitudEjecucion=1;
				oParamBusqueda.Tipo='C';
				oParamBusqueda.CampoAlterno = 'NroPersonal';
				oParamBusqueda.LongitudEjecucion=4;
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre='idProceso';
				oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarPersonal;
				oParamBusqueda.Tipo='Q';
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

				(new AutoBusqueda("txtApellidos")).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);		
			
		</script>
	</BODY>
</HTML>
