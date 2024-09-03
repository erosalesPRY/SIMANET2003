<%@ Page language="c#" Codebehind="DetalleSctr.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleSctr" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Administracion Detalle de SCTR</title>
		<meta name="vs_showGrid" content="False">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<script language="javascript" src="/SimaNetWeb/js/@Import.js"></script>
		<script type="text/javascript" src="../../js/date.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<style type="text/css">INPUT.text { BORDER-BOTTOM: 1px solid; BORDER-LEFT: 1px solid; BACKGROUND: white; COLOR: black; BORDER-TOP: 1px solid; BORDER-RIGHT: 1px solid }
	.text:focus { BACKGROUND: yellow }
	.text:unknown { BACKGROUND: red }
	</style>
		<script>
	//FUNSION BUSCAR TRABAJADOR//
	function txtTrabajador_ItemDataBound(sender,e,dr)
	{
	document.getElementById("hIdTrabajador").value = dr["NroDNI"];
	}
	//FUNSION BUSCA ASEGURADORA//
	function txtAseguradora_ItemDataBound(sender,e,dr)
	{
	document.getElementById("hidAseguradora").value = dr["codigo"];
	}
	//VALIDA RESPUESTA--PREGUNTAR BIEN QUE HACE???			
	//function ValidaRespuesta(btn)
	//{
	//alert(btn);
	//}
	//FUNSION BUSCA PROVEEDOR RAZONSOCIAL - RUC (IDENTIDAD=26)
	function txtRazonSocial_ItemDataBound(sender,e,dr)
	{
		if(new SIMA.Numero($O('txtRazonSocial').value).IsNumeric()==true)
		{
		$O('txtRuc').value = dr["RAZONSOCIAL"].toString();	
		}
		else
		{
		$O('txtRuc').value = dr["NROPROVEEDOR"].toString();	
		}
		//Obtiene la identificacion del proveedor
		$O('hIdEntidad').value = dr["IDPROVEEDOR"].toString()
	}
	//FUNSION DE AGREGAR NUEVAS ASEGURADORAS
	//function AddAseguradora()
	//{
	//}
	</script>
	<script>
	function CreaNuevoPRV(){
	jNet.get('txtRucNew').value='';
	jNet.get('txtRSocialNew').value=jNet.get('txtRazonSocial').value;
	(new System.Ext.UI.WebControls.Windows()).DetalleFromEL('DEMO',document.getElementById("tblPrvCLI"),"Nuevo registro",420,120,GrabarNuevoPRV_CLI);
			}

	</script>
		
</HEAD>
	<BODY onkeypress="if(event.keyCode==13)return false;" onclick="MostrarTrabajadorAgregado();"
		onunload="SubirHistorial();onload=ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0" bgColor="white">
		<FORM id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
				<TR>
					<td width="100%"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</TR>
				<TR>
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="Label11" runat="server" CssClass="RutaPagina">Inicio >Gestión de seguridad></asp:label><asp:label id="Label12" runat="server" CssClass="RutaPaginaActual"> > Detalle del SCTR></asp:label></TD>
				</TR>
				<TR>
				<TR>
					<TD style="HEIGHT: 211px">
						<P>&nbsp;</P>
						<TABLE style="Z-INDEX: 0; WIDTH: 736px; HEIGHT: 227px" id="Table2" border="0" cellSpacing="1"
							cellPadding="1" width="736" align="center">
        <TBODY>
							<TR>
								<TD bgColor="#000080" height="18" colSpan="12" align="center">
									<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="160px" Height="8px"> DETALLE DE SCTR</asp:label></P>
								</TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px; HEIGHT: 20px" class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label1" runat="server" Height="8px">RAZON SOCIAL</asp:label></TD>
								<TD style="WIDTH: 566px; HEIGHT: 20px" class="ItemDetalle" width="566" colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtRazonSocial" runat="server" Width="580px"></asp:textbox></TD>
								<TD style="HEIGHT: 20px"><cc1:requireddomvalidator id="rfvProveedor" runat="server" CssClass="normaldetalle" ErrorMessage="No se ha ingresado información de proveedor"
										ControlToValidate="txtRazonSocial">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px; HEIGHT: 19px" class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label2" runat="server" Width="119px" Height="8px">R.U.C.</asp:label></TD>
								<TD style="WIDTH: 566px; HEIGHT: 19px" class="ItemDetalle" width="566" colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtRuc" runat="server" CssClass="normaldetalle" Width="580px"
										Height="18px" BackColor="WhiteSmoke" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								<TD style="HEIGHT: 19px"><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdEntidad" size="1" type="hidden"
										name="hIdEntidad" runat="server">
								</TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px" class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label3" runat="server" CssClass="HeaderGrilla" Width="129px"
										Height="8px">Apellidos y Nombres</asp:label></TD>
								<TD style="WIDTH: 566px" colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtTrabajador" runat="server" CssClass="normaldetalle" Width="580px"
										Height="22px"></asp:textbox></TD>
								<TD><INPUT style="Z-INDEX: 0; WIDTH: 24px; HEIGHT: 22px" id="hIdTrabajador" size="1" type="hidden"
										name="hIdTrabajador" runat="server">
								</TD>
							</TR>
							<TR class="ItemDetalle">
								<TD style="WIDTH: 128px" class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label4" runat="server" Height="8px">AEGURADORA:
										</asp:label></TD>
								<TD style="WIDTH: 566px" colSpan="5"><asp:textbox style="Z-INDEX: 0" id="txtAseguradora" runat="server" CssClass="normaldetalle" Width="580px"></asp:textbox></TD>
								<TD><IMG style="Z-INDEX: 0" id="btnAseguradora" title="Crear un nueva Aseguradora" onclick="AddAseguradora();"
										alt="" src="../imagenes/BtPU_Mas.gif">
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 25px" class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label5" runat="server" Height="8px">NRO SCTR 
										</asp:label></TD>
								<TD style="WIDTH: 122px; HEIGHT: 25px" width="122"><asp:textbox style="Z-INDEX: 0" id="txtNroSctr" runat="server" CssClass="normaldetalle" Width="96px"
										Height="22px"></asp:textbox></TD>
								<TD style="HEIGHT: 25px" class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" Width="80px" Height="8px">NRO POLIZA PENSION:
										</asp:label></TD>
								<TD style="WIDTH: 131px; HEIGHT: 25px" width="131"><asp:textbox style="Z-INDEX: 0" id="txtNroPoliza" runat="server" CssClass="normaldetalle" Width="110px"
										Height="22px"></asp:textbox></TD>
								<TD style="WIDTH: 73px; HEIGHT: 25px" class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label7" runat="server" Width="88px" Height="8px">NRO CONTRATO SALUD:
										</asp:label></TD>
								<TD style="WIDTH: 92px; HEIGHT: 25px"><asp:textbox style="Z-INDEX: 0" id="txtNroSeguro" runat="server" CssClass="normaldetalle" Width="92px"
										Height="22px"></asp:textbox></TD>
								<TD style="HEIGHT: 25px">&nbsp;
								</TD>
							</TR>
							<TR> 
								<TD style="WIDTH: 128px; HEIGHT: 4px" class="HeaderGrilla" align="left"><asp:label style="Z-INDEX: 0" id="Label8" runat="server" Height="8px">FECHA INICIO:
										</asp:label></TD>
								<TD style="WIDTH: 122px; HEIGHT: 4px"><ew:calendarpopup style="Z-INDEX: 0" id="CalFechaInicio" runat="server" CssClass="normaldetalle" Width="60px"
										DisableTextboxEntry="False" JavascriptOnChangeFunction="ValidaFechaConFechaSeguro" PadSingleDigits="True" Culture="Spanish (Chile)"
										ControlDisplay="TextBoxImage" ShowGoToToday="True" ClearDateText="Limpiar Fecha" NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar"
										MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" AllowArbitraryText="False" SelectedDate="2009-06-15" ImageUrl="../imagenes/BtPU_Mas.gif">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD style="HEIGHT: 4px" class="HeaderGrilla" noWrap><asp:label style="Z-INDEX: 0" id="Label9" runat="server" Height="8px">FECHA TERMINO:
										</asp:label></TD>
								<TD style="WIDTH: 131px; HEIGHT: 4px"><ew:calendarpopup style="Z-INDEX: 0" id="CalFechVence" runat="server" CssClass="normaldetalle" Width="60px"
										DisableTextboxEntry="False" JavascriptOnChangeFunction="ValidaFechaConFechaSeguro" PadSingleDigits="True" Culture="Spanish (Chile)"
										ControlDisplay="TextBoxImage" ShowGoToToday="True" ClearDateText="Limpiar Fecha" NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar"
										MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" AllowArbitraryText="False" SelectedDate="2009-06-15" ImageUrl="../imagenes/BtPU_Mas.gif">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup></TD>
								<TD style="WIDTH: 83px; HEIGHT: 4px" class="HeaderGrilla"><asp:label style="Z-INDEX: 0" id="Label10" runat="server" Height="8px">HABILITADO:
										</asp:label></TD>
								<TD style="WIDTH: 76px; HEIGHT: 4px"><asp:label style="Z-INDEX: 0" id="LblHabilitado" runat="server" CssClass="normaldetalle" Height="8px"
										Font-Bold="True"></asp:label></TD>
								<TD style="WIDTH: 92px; HEIGHT: 4px">&nbsp;
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 1px" height="1" align="left"></TD>
								<TD style="WIDTH: 122px; HEIGHT: 1px" height="1"></TD>
								<TD height="1" noWrap style="HEIGHT: 1px"></TD>
								<TD style="WIDTH: 131px; HEIGHT: 1px" height="1"></TD>
								<TD style="WIDTH: 83px; HEIGHT: 1px" height="1"></TD>
								<TD style="WIDTH: 92px; HEIGHT: 1px" height="1"></TD>
								<TD height="1" style="HEIGHT: 1px"></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 128px; HEIGHT: 4px" align="left"></TD>
								<TD style="WIDTH: 122px; HEIGHT: 4px"></TD>
								<TD style="HEIGHT: 4px" noWrap></TD>
								<TD style="WIDTH: 131px; HEIGHT: 4px"></TD>
								<TD style="WIDTH: 83px; HEIGHT: 4px" align="center">&nbsp;<asp:imagebutton style="Z-INDEX: 0" id="ibtnAceptar" runat="server" Height="22px" ImageUrl="../imagenes/bt_aceptar.gif"></asp:imagebutton>
								</TD>
								<TD style="WIDTH: 92px; HEIGHT: 4px" align="center"><IMG style="Z-INDEX: 0; CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt=""
										src="../imagenes/bt_cancelar.gif"></TD>
								<TD style="HEIGHT: 4px">
								</TD>
							</TR>
							<TR>
								<TD style="DISPLAY: none" height="2" vAlign="top" width="100%" align="center">
									<TABLE style="MARGIN-TOP: 2px; MARGIN-LEFT: 2px" id="tblPrvCLI" border="0" cellSpacing="1"
										cellPadding="1" width="100%">
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label id="Label14" runat="server">Nro de R.U.C:</asp:label></TD>
											<TD><asp:textbox id="txtRucNew" runat="server" Width="128px" MaxLength="11"></asp:textbox></TD>
										</TR>
										<TR>
											<TD class="HeaderDetalle" noWrap><asp:label id="Label22" runat="server">Razón Social:</asp:label></TD>
											<TD><asp:textbox id="txtRSocialNew" runat="server" Width="300px" MaxLength="200"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR></TBODY>
						</TABLE></TD></TR></TABLE>
		</FORM>
		<SCRIPT>
		asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<SCRIPT>
		//Configuracion de Busqueda para trabajadores
		var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
		var oParamCollecionBusqueda = new ParamCollecionBusqueda();
		var oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="ApellidoyNombres";
			oParamBusqueda.Texto="Trabajador";
			oParamBusqueda.LongitudEjecucion=2;
			oParamBusqueda.CampoAlterno="NroDNI";
			oParamBusqueda.Tipo="C";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);

			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="idProceso";
			oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarTrabajadorCCTT;
			oParamBusqueda.Tipo="Q";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);

		(new AutoBusqueda('txtTrabajador')).Crear( '/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);						
		
		//Configuracion de Busqueda para Compañia de Seguros
		var oParamCollecionBusqueda = new ParamCollecionBusqueda();
		var oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="descripcion";
			oParamBusqueda.Texto="Aseguradora";
			oParamBusqueda.LongitudEjecucion=2;
			oParamBusqueda.Tipo="C";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);

			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="idProceso";
			oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarCIASeguros;
			oParamBusqueda.Tipo="Q";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);
		(new AutoBusqueda('txtAseguradora')).Crear( '/' + ApplicationPath + '/GestionSeguridadIndustrial/Procesar.aspx?',oParamCollecionBusqueda);

		
		//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
		//Configuracion de Busqueda para Proveedores
		var KEYQIDTIPOENTIDAD="idTipoEntidad";
		var oParamCollecionBusqueda = new ParamCollecionBusqueda();
			var oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="RAZONSOCIAL";
			oParamBusqueda.Texto="Razon Social del Proveedor";
			oParamBusqueda.LongitudEjecucion=5;
			oParamBusqueda.Tipo="C";
			oParamBusqueda.Ancho=100;
			oParamBusqueda.CampoAlterno = "NROPROVEEDOR";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);
		
			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="NROPROVEEDOR";
			oParamBusqueda.Texto="R.U.C. de Proveedor";
			oParamBusqueda.LongitudEjecucion=5;
			oParamBusqueda.Tipo="C";
			oParamBusqueda.Ancho=100;
			oParamBusqueda.CampoAlterno = "RAZONSOCIAL";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);

			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre=KEYQIDTIPOENTIDAD;
			oParamBusqueda.Valor=1;
			oParamBusqueda.ParaBusqueda=false;
			oParamBusqueda.Tipo="Q";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);

			oParamBusqueda = new ParamBusqueda();
			oParamBusqueda.Nombre="idProceso";
			oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.BuscarProveedores;
			oParamBusqueda.ParaBusqueda=false;
			oParamBusqueda.Tipo="Q";
		oParamCollecionBusqueda.Agregar(oParamBusqueda);
		
		(new AutoBusqueda('txtRazonSocial')).CrearPopupOpcion( '/' + ApplicationPath + '/Personal/Procesar.aspx?',oParamCollecionBusqueda);
		</SCRIPT>
	</BODY>
</HTML>
