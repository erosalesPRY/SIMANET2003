<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarPrivilegiosPorCentrosdeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.AdministrarPrivilegiosPorCentrosdeCosto" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPrivilegiosPorCentrosdeCosto</title> 
		<!--<%@ OutputCache Location="None" VaryByParam="None" %>-->
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script>
			var idUsuario=0;
			var idTipoInformacion=0;
			var idGrupoCentroCosto=0;
			var idCentroOperativo=1;
						
			var idRegistro=0;
			var idTabla=0;
			var idTablaMoviReg=0;
			var idFlg=0;
		
			var KEYQCENTROCOSTO="idCentroCosto";
			var KEYTIPOINFORMACION = "idTipoInformacion";
			var KEYGRUPOCC = "idGrupoCC";
			var KEYQCENTROOPERATIVO = "idCentroOperativo";
			var KEYQIDREG = "idRegistro";
			var KEYQIDUSUARIO = "idUsuario";
			var KEYQIDTABLAORIGEN ="idTablaOrigen";
			var KEYQIDTABLAMOVREG = "idTablaMovReg";
			var KEYQIDFLAG = "idFlag";
			
			function FrmPrevilegions_onLoad(){
				//LlenarCombos();
			}
			function LlenarCombos(){
				CargarCentrosOperativos();
			}
			function CargarCentrosOperativos(){
				var oddlCentroOperativo = new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo');
					oddlCentroOperativo.DataSource = (new Controladora.General.CCentroOperativo()).ListarTodosCombo();
					oddlCentroOperativo.DataTextField = "NOMBRE";
					oddlCentroOperativo.DataValueField = "IDCENTROOPERATIVO";
					oddlCentroOperativo.SelectedIndexChanged = ddlCentroOperativo_SelectedIndexChanged;
					oddlCentroOperativo.DataBind();
			}
			
			function ddlCentroOperativo_SelectedIndexChanged(e){
				
				try{
					idCentroOperativo =e.options[e.selectedIndex].value;
					
				}
				catch(error){
					idCentroOperativo=this.options[this.options.selectedIndex].value;
				}
				ParametrosPorCentroOperativo();
			}
			
			
			function LlenarCentrosdeCostoDisponibles(idGrupoCentroCosto){
				var olstCentroCostoDisp= new System.Web.UI.WebControls.DropDownList('lstCentroCostoDisp');
				olstCentroCostoDisp.DataSource = (new Controladora.General.CentroCosto()).ListarAccesoUsuarioCentroCostoDisponible(idGrupoCentroCosto,idUsuario,idTipoInformacion);
				olstCentroCostoDisp.DataTextField = "DatosCentroCosto";
				olstCentroCostoDisp.DataValueField = "idCentroCosto";
				
				olstCentroCostoDisp.DataBind();
				
				var olstCentroCostoDispID= new System.Web.UI.WebControls.DropDownList('lstCentroCostoDispID');
				olstCentroCostoDispID.DataSource = olstCentroCostoDisp.DataSource;
				olstCentroCostoDispID.DataTextField = "DatosCentroCosto";
				olstCentroCostoDispID.DataValueField = "IdAccesoUsuarioTabla";
				olstCentroCostoDispID.DataBind();
			}
			
			function LlenarCentrosdeCostoSeleccionado(idGrupoCentroCosto){
				var olstCentroCostoSelec= new System.Web.UI.WebControls.DropDownList('lstCentroCostoSelec');
				olstCentroCostoSelec.DataSource = (new Controladora.General.CentroCosto()).ListarAccesoUsuarioCentroCostoSeleccionado(idGrupoCentroCosto,idUsuario,idTipoInformacion);
				olstCentroCostoSelec.DataTextField = "DatosCentroCosto";
				olstCentroCostoSelec.DataValueField = "idCentroCosto";
				
				olstCentroCostoSelec.DataBind();

				var olstCentroCostoSelecID= new System.Web.UI.WebControls.DropDownList('lstCentroCostoSelecID');
				olstCentroCostoSelecID.DataSource = olstCentroCostoSelec.DataSource;
				olstCentroCostoSelecID.DataTextField = "DatosCentroCosto";
				olstCentroCostoSelecID.DataValueField = "IdAccesoUsuarioTabla";
				
				olstCentroCostoSelecID.DataBind();
			}
			function lstCentroCostoSelec_SelectedIndexChanged(e){
				var idCentroCosto=0;
				var oolstCentroCostoSelecID = $O('lstCentroCostoSelecID');
				try{
					
					idCentroCosto = e.options[e.selectedIndex].value;
					
					var Index = (oolstCentroCostoSelecID.selectedIndex = e.selectedIndex);
					idRegistro = oolstCentroCostoSelecID.options[Index].value;
					
					AdministrarNaturalezaGastos(idCentroCosto);
					
					}
				catch(error){
					idCentroCosto=this.options[this.options.selectedIndex].value;
				}
				
			}
			function AdministrarNaturalezaGastos(idCentroCosto){
					
					var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
					
					var URLDETALLE = '/' + ApplicationPath + '/GestionFinanciera/Presupuesto/DefaultNaturalezaGastos.aspx?' 
					+ SIMA.Utilitario.Constantes.KEYMODOPAGINA 
					+ SIMA.Utilitario.Constantes.General.Caracter.SignoIgual 
					+ SIMA.Utilitario.Enumerados.ModoPagina.N.toString()
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYGRUPOCC + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idGrupoCentroCosto
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQCENTROCOSTO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idCentroCosto
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYTIPOINFORMACION + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idTipoInformacion
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQCENTROOPERATIVO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idCentroOperativo
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQIDREG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idRegistro
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQIDUSUARIO + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idUsuario
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQIDTABLAORIGEN + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idTabla
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQIDTABLAMOVREG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idTablaMoviReg
					+ SIMA.Utilitario.Constantes.General.Caracter.signoAmperson
					+ KEYQIDFLAG + SIMA.Utilitario.Constantes.General.Caracter.SignoIgual + idFlg;
					
					(new SIMA.Utilitario.Helper.Response()).ShowDialogoNoModal(URLDETALLE,610,350);
				}
			/*Asignar y desaignar Centros de Costos*/
			function Agregar(){
				var olstCentroCostoDisp = new System.Web.UI.WebControls.DropDownList('lstCentroCostoDisp');
				var oListItem = olstCentroCostoDisp.ClonarItem('lstCentroCostoSelec');
				
				var olstCentroCostoDispID = new System.Web.UI.WebControls.DropDownList('lstCentroCostoDispID');
				var oListItemID = olstCentroCostoDispID.ClonarItem('lstCentroCostoSelecID');
				
				var idReg = AgregarModificar(oListItemID.value,282,oListItem.value,idTipoInformacion,1);
				var id3=100;
				//Actualiza la lista
				for (var i=1; i<=8; i++)
				{
					AgregarNaturalezaGastos(oListItemID.value,282,oListItem.value,idTipoInformacion,1,id3);
					id3=id3+100;
					
				}
				LlenarCentrosdeCostoDisponibles(idGrupoCentroCosto);
				LlenarCentrosdeCostoSeleccionado(idGrupoCentroCosto);
			}
			function Quitar(){
				var olstCentroCostoSelec = new System.Web.UI.WebControls.DropDownList('lstCentroCostoSelec');
				var oListItem = olstCentroCostoSelec.ClonarItem('lstCentroCostoDisp');
				
				var olstCentroCostoSelecID = new System.Web.UI.WebControls.DropDownList('lstCentroCostoSelecID');
				var oListItemID = olstCentroCostoSelecID.ClonarItem('lstCentroCostoDispID');
				
				AgregarModificar(oListItemID.value,282,oListItem.value,idTipoInformacion,0);
				//Actualiza la lista 
				LlenarCentrosdeCostoDisponibles(idGrupoCentroCosto);
				LlenarCentrosdeCostoSeleccionado(idGrupoCentroCosto);
			}
			
			function AgregarModificar(idReg,idTablaOrigen,idRegistroTblOrigen,idTablaMovReg,idFlag){
				var oAccesoUsuarioTablaBE = new EntidadesNegocio.General.AccesoUsuarioTablaBE();
				
				oAccesoUsuarioTablaBE.idAccesoUsuarioTabla = idReg;
				oAccesoUsuarioTablaBE.idUsuario = idUsuario;
				oAccesoUsuarioTablaBE.idTablaNombreTabla = 176;
				oAccesoUsuarioTablaBE.idNombreTabla = idTablaOrigen;//282Tabla Origen del Registro
				oAccesoUsuarioTablaBE.id1 = idRegistroTblOrigen;//Registro seleccionado
				oAccesoUsuarioTablaBE.id2 = idTablaMovReg;//tabla de movimiento relacionado al registro
				oAccesoUsuarioTablaBE.flgAcceso = idFlag;
				//idRegistro = idReg;
				idTabla = idTablaOrigen;
				idTablaMoviReg = idTablaMovReg;
				idFlg = idFlag;
				
				return (new Controladora.General.AccesoUsuarioTabla()).InsertarModificar(oAccesoUsuarioTablaBE);
			}
			
			function SeleccionDDLDisponible(){
				var olstCentroCostoDisp = new System.Web.UI.WebControls.DropDownList('lstCentroCostoDisp')
				olstCentroCostoDisp.Sincronizar('lstCentroCostoDispID');
			}
			function SeleccionDDLSeleccionado(){
				var olstCentroCostoSelec = new System.Web.UI.WebControls.DropDownList('lstCentroCostoSelec')
				olstCentroCostoSelec.Sincronizar('lstCentroCostoSelecID');
			}
			

		</script>
		<script>
			function txtBuscar_ItemDataBound(sender,e,dr){
				idUsuario = dr["idUsuario"].toString();
				$O('imgFotoUsuario').src = $O('hPathFotos').value + dr["NroPersonal"].toString() +".jpg";
				(new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo')).FindByValue(dr["idCentroOperativo"].toString());
				(new System.Web.UI.WebControls.DropDownList('ddlTipoGrupo')).FindByValue(dr["CuentaContableAsignada"].toString());
				//Actualiza la lista 
				LlenarCentrosdeCostoDisponibles(idGrupoCentroCosto);
				LlenarCentrosdeCostoSeleccionado(idGrupoCentroCosto);
			}
			
			function txtBuscarTipoInformacion_ItemDataBound(sender,e,dr){
				idTipoInformacion = dr["idcabeceratablatablas"].toString();
				//Actualiza la lista 
				LlenarCentrosdeCostoDisponibles(idGrupoCentroCosto);
				LlenarCentrosdeCostoSeleccionado(idGrupoCentroCosto);
			}

			function txtGrupoCentroCosto_ItemDataBound(sender,e,dr){
				idGrupoCentroCosto= dr["IDGRUPOCC"].toString();
				LlenarCentrosdeCostoDisponibles(idGrupoCentroCosto);
				LlenarCentrosdeCostoSeleccionado(idGrupoCentroCosto);
			}
			function AgregarNaturalezaGastos(idReg,idTablaOrigen,idRegistroTblOrigen,idTablaMovReg,idFlag,naturaleza){
			
			
				var oAccesoUsuarioTablaBE = new EntidadesNegocio.General.AccesoUsuarioTablaBE();
				
					oAccesoUsuarioTablaBE.idUsuario = idUsuario;
					oAccesoUsuarioTablaBE.idTablaNombreTabla = 176;
					oAccesoUsuarioTablaBE.idNombreTabla = idTablaOrigen; //282Tabla Origen del Registro
					oAccesoUsuarioTablaBE.id1 = idRegistroTblOrigen; //Registro seleccionado
					oAccesoUsuarioTablaBE.id2 = idTablaMovReg;
					oAccesoUsuarioTablaBE.id3 = naturaleza; //tabla de movimiento relacionado al registro
					oAccesoUsuarioTablaBE.flgAcceso = 1;
					
		
					return (new Controladora.General.AccesoUsuarioTabla()).InsertarNaturalezaGasto(oAccesoUsuarioTablaBE);
					
				
			}

			
			
		</script>
	</HEAD>
	<body topMargin="0" onload="FrmPrevilegions_onLoad();ObtenerHistorial();" bottomMargin="0"
		leftMargin="0" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0"
				height="100%" style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/FondoFooterPagOpciones.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left bottom">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu>
					</TD>
				</TR>
				<TR>
					<TD id="CellContext" width="100%" height="100%" runat="server" style="BACKGROUND-IMAGE: url(/SimaNetWeb/imagenes/Navegador/FondoHeaderPagOpciones.gif); BACKGROUND-REPEAT: repeat-x; BACKGROUND-POSITION: left top; COLOR: #666666; FONT-SIZE: 18pt; FONT-WEIGHT: bold; TEXT-DECORATION: underline"
						vAlign="middle" borderColor="#333366" align="center">
						<TABLE id="Table1" style="WIDTH: 744px; HEIGHT: 333px" cellSpacing="1" cellPadding="1"
							width="744" border="0">
							<TR>
								<TD class="HeaderDetalle" colSpan="5"><asp:label id="Label8" runat="server" Font-Size="X-Small" Font-Bold="True">ADMINISTRAR PRIVILEGIO A CENTROS DE COSTO</asp:label></TD>
							</TR>
							<TR>
								<TD class="AlternateItemDetalle" colSpan="5">
									<TABLE id="Table7" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD style="WIDTH: 92px"><asp:label id="Label1" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco"> INFORMACIÓN</asp:label></TD>
											<TD><asp:textbox id="txtBuscarTipoInformacion" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 92px"><IMG id="imgFotoUsuario" style="BORDER-BOTTOM: gray 1px solid; BORDER-LEFT: gray 1px solid; WIDTH: 96px; HEIGHT: 104px; BORDER-TOP: gray 1px solid; BORDER-RIGHT: gray 1px solid"
													height="104" alt="" src="../imagenes/Navegador/BtnOpciones/ImgBase.gif" width="96"></TD>
											<TD vAlign="top">
												<TABLE id="Table8" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
													<TR>
														<TD><asp:label id="Label6" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco">USUARIO:</asp:label></TD>
													</TR>
													<TR>
														<TD><asp:textbox id="txtBuscar" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table3" style="HEIGHT: 48px" cellSpacing="1" cellPadding="1" width="100%" align="left"
																border="0">
																<TR>
																	<TD style="WIDTH: 241px" colSpan="2">
																		<asp:label id="Label7" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Width="136px">CENTRO OOPERATIVO:</asp:label></TD>
																	<TD style="WIDTH: 101px; HEIGHT: 22px" colSpan="2">
																		<asp:label id="Label3" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco" Width="552px">GRUPO DE CENTRO DE COSTO</asp:label></TD>
																</TR>
																<TR>
																	<TD style="WIDTH: 241px" colSpan="2">
																		<asp:dropdownlist id="ddlCentroOperativo" runat="server" CssClass="normaldetalle" Width="136px"></asp:dropdownlist></TD>
																	<TD colSpan="2">
																		<asp:textbox id="txtGrupoCentroCosto" runat="server" CssClass="normaldetalle" Width="100%"></asp:textbox></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="ItemDetalle" colSpan="5">
									<TABLE id="Table5" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
										<TR>
											<TD>
												<asp:label id="Label4" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CENTROS DE COSTO DISPONIBLE</asp:label><SELECT class="normaldetalle" id="lstCentroCostoDispID" style="WIDTH: 56px; DISPLAY: none; HEIGHT: 21px"
													size="2" name="Select1">
													<OPTION></OPTION>
												</SELECT></TD>
											<TD></TD>
											<TD>
												<asp:label id="Label5" runat="server" ForeColor="Navy" CssClass="TituloPrincipalBlanco">CENTROS DE COSTO SELECCIONADO:</asp:label><SELECT class="normaldetalle" id="lstCentroCostoSelecID" style="WIDTH: 40px; DISPLAY: none; HEIGHT: 23px"
													size="2" name="Select1">
													<OPTION></OPTION>
												</SELECT></TD>
										</TR>
										<TR>
											<TD vAlign="top" align="left" width="50%"><SELECT class="normaldetalle" id="lstCentroCostoDisp" style="WIDTH: 100.28%; HEIGHT: 156px"
													onclick="SeleccionDDLDisponible();" align="left" size="9">
													<OPTION></OPTION>
												</SELECT></TD>
											<TD align="center">
												<TABLE id="Table4" style="WIDTH: 27px; HEIGHT: 131px" cellSpacing="1" cellPadding="1" width="27"
													border="0">
													<TR>
														<TD><IMG id="ibtnAgregarTodos" src="../imagenes/Navegador/ibtnUltimo.gif" style="DISPLAY: none"></TD>
													</TR>
													<TR>
														<TD><IMG id="ibtnAgregar" onclick="Agregar();" src="../imagenes/Navegador/ibtnSiguiente.gif"></TD>
													</TR>
													<TR>
														<TD></TD>
													</TR>
													<TR>
														<TD><IMG id="ibtnQuitar" onclick="Quitar();" src="../imagenes/Navegador/ibtnAnterior.gif"></TD>
													</TR>
													<TR>
														<TD><IMG id="ibtnQuitarTodos" src="../imagenes/Navegador/ibtnPrimero.gif" style="DISPLAY: none"></TD>
													</TR>
												</TABLE>
											</TD>
											<TD vAlign="top" align="left" width="50%"><SELECT class="normaldetalle" id="lstCentroCostoSelec" style="WIDTH: 100%; HEIGHT: 156px"
													onclick="SeleccionDDLSeleccionado();" ondblclick="lstCentroCostoSelec_SelectedIndexChanged(this);" size="9" name="Select1">
													<OPTION></OPTION>
												</SELECT></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD class="ItemDetalle" colSpan="5">.<INPUT id="hPathFotos" style="WIDTH: 72px; HEIGHT: 22px" type="hidden" size="6" runat="server"
										NAME="hPathFotos"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="right" width="100%" height="40"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"
							runat="server"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			
			LlenarCombos();
			var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
			var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
				var oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="Nombres";
				oParamBusqueda.Texto="Apellidos y Nombres";
				oParamBusqueda.LongitudEjecucion=1;
				oParamBusqueda.Tipo="C";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);

				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="idProceso";
				oParamBusqueda.Valor=55;
				oParamBusqueda.Tipo="Q";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);
			(new AutoBusqueda('txtBuscar')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
			
			/*Busqueda de tipo de informacion*/
			var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
				var oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="descripcion";
				oParamBusqueda.Texto="Nombre de tablas generales";
				oParamBusqueda.LongitudEjecucion=1;
				oParamBusqueda.Tipo="C";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);

				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="idProceso";
				oParamBusqueda.Valor=35;
				oParamBusqueda.Tipo="Q";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);
			
				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="IDMODULO";
				oParamBusqueda.Valor=5;
				oParamBusqueda.Tipo="Q";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);
			(new AutoBusqueda('txtBuscarTipoInformacion')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
			
			/*Para los grupos de centros de costos*/
			function ParametrosPorCentroOperativo(){
				var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
					var oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="NOMBRE";
					oParamBusqueda.Texto="Grupo de Centro de Costo";
					oParamBusqueda.LongitudEjecucion=1;
					oParamBusqueda.CampoAlterno = "NROGRUPOCC";
					oParamBusqueda.Tipo="C";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);

					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idProceso";
					oParamBusqueda.Valor=37;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				
					oParamBusqueda = new ParamBusqueda();
					oParamBusqueda.Nombre="idcop";
					oParamBusqueda.Valor=(new System.Web.UI.WebControls.DropDownList('ddlCentroOperativo')).ListItem().value;
					oParamBusqueda.Tipo="Q";
				oParamCollecionBusqueda.Agregar(oParamBusqueda);
				(new AutoBusqueda('txtGrupoCentroCosto')).Crear('/' + ApplicationPath + '/General/Procesar.aspx?',oParamCollecionBusqueda);
				
				$O('txtGrupoCentroCosto').value="";
				(new System.Web.UI.WebControls.DropDownList('lstCentroCostoDisp')).Clear();
				(new System.Web.UI.WebControls.DropDownList('lstCentroCostoSelec')).Clear();
			}
			ParametrosPorCentroOperativo();
		</SCRIPT>
	</body>
</HTML>
