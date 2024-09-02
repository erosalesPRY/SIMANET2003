<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetallePromotores.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.DetallePromotores" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script src="/SimaNetWeb/js/Menu/MenuSP.js" type="text/javascript"></script>
		<style>UNKNOWN { FONT: 12px sans-serif }
		</style>
		<script>
			function txtProveedor_ItemDataBound(sender,e,dr){
				
				//Limpiar datos
				$O('txtIdentificacionPersonal').value = "";
				$O('txtDireccion').value = "";
				$O('txtTelefono').value = "";
				$O('txtNroFax').value = "";
				$O('lblUbicacion').innerText = "";
				$O('lblTipo').innerText = "";
				//Cargar Dato
				$O('txtIdentificacionPersonal').value =dr["nroProveedor"].toString() ;
				$O('txtDireccion').value = dr["Direccion"].toString();
				$O('txtTelefono').value = dr["Telefono"].toString();
				
				$O('txtNroFax').value = dr["Fax1"].toString();
				$O('lblUbicacion').innerText = dr["UbicacionGeo"].toString();
				$O('lblTipo').innerText = dr["TipoPersona"].toString();
			}
		</script>
	</HEAD>
	<body onkeydown="if(event.keyCode==13){return false;}" bottomMargin="0" leftMargin="0"
		topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center">
						<TABLE id="Table5" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Promotor ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta Detalle de Promotor</asp:label></TD>
							</TR>
							<TR>
								<TD align="left"></TD>
							</TR>
						</TABLE>
						<TABLE id="Table1" style="WIDTH: 496px; HEIGHT: 347px" cellSpacing="0" cellPadding="0"
							width="496" border="0">
							<TR>
								<TD bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblRazonSocial" runat="server" CssClass="TextoBlanco">Razon Social :</asp:label></TD>
								<TD><asp:textbox id="txtProveedor" runat="server" Width="340px" DESIGNTIMEDRAGDROP="114"></asp:textbox></TD>
								<TD><cc1:requireddomvalidator id="rfvNombre" runat="server" ControlToValidate="txtProveedor">*</cc1:requireddomvalidator></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblRuc" runat="server" CssClass="TextoBlanco">Nro Identificacion:</asp:label></TD>
								<TD><asp:textbox id="txtIdentificacionPersonal" runat="server" CssClass="normaldetalle" Width="170px"
										BackColor="Transparent" ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="Label1" runat="server" CssClass="TextoBlanco">TIPO:</asp:label></TD>
								<TD><asp:label id="lblTipo" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblPais" runat="server" CssClass="TextoBlanco">UBICACION :</asp:label></TD>
								<TD><asp:label id="lblUbicacion" runat="server" CssClass="normaldetalle"></asp:label></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblDireccion" runat="server" CssClass="TextoBlanco">Direccion:</asp:label></TD>
								<TD><asp:textbox id="txtDireccion" runat="server" CssClass="normaldetalle" Width="340px" BackColor="Transparent"
										ReadOnly="True" BorderStyle="None" Height="18px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblTelefono" runat="server" CssClass="TextoBlanco">Telefono:</asp:label></TD>
								<TD><asp:textbox id="txtTelefono" runat="server" CssClass="normaldetalle" Width="170px" BackColor="Transparent"
										ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblNroFax" runat="server" CssClass="TextoBlanco">Nro Fax:</asp:label></TD>
								<TD><asp:textbox id="txtNroFax" runat="server" CssClass="normaldetalle" Width="170px" BackColor="Transparent"
										ReadOnly="True" BorderStyle="None"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblCelular" runat="server" CssClass="TextoBlanco">Celular:</asp:label></TD>
								<TD><asp:textbox id="txtCelular" runat="server" CssClass="normaldetalle" Width="170px" BackColor="White"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblCorreoElectronico" runat="server" CssClass="TextoBlanco">E-mail:</asp:label></TD>
								<TD><asp:textbox id="txtCorreoElectronico" runat="server" CssClass="normaldetalle" Width="340px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle"><asp:label id="lblObservaciones" runat="server" CssClass="TextoBlanco">Observaciones:</asp:label></TD>
								<TD><asp:textbox id="txtObservaciones" runat="server" CssClass="normaldetalle" Width="340px" TextMode="MultiLine"
										Height="56px"></asp:textbox></TD>
								<TD></TD>
							</TR>
							<TR class="ItemDetalle">
								<TD class="HeaderDetalle"></TD>
								<TD align="center"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
										runat="server"></TD>
								<TD></TD>
							</TR>
							<TR>
								<TD align="center" width="100%" colSpan="3"><asp:validationsummary id="vSum" runat="server" Width="100%" ShowSummary="False" ShowMessageBox="True"
										EnableClientScript="False" DisplayMode="List"></asp:validationsummary></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><INPUT id="hIdCliente" type="hidden" size="1" value="0" name="hIdCliente" runat="server"><asp:label id="lblMensaje1" runat="server" CssClass="normal"></asp:label></TD>
							</TR>
							<TR>
								<TD id="CellBtnAtras" colSpan="3" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"
										runat="server"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
			var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
				var oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="RazonSocial";
				oParamBusqueda.Texto="Razon Social";
				oParamBusqueda.LongitudEjecucion=4;
				oParamBusqueda.Tipo="C";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);

				oParamBusqueda = new ParamBusqueda();
				oParamBusqueda.Nombre="idProceso";
				oParamBusqueda.Valor=51;
				oParamBusqueda.Tipo="Q";
			oParamCollecionBusqueda.Agregar(oParamBusqueda);
			
			(new AutoBusqueda('txtProveedor')).Crear('/' + ApplicationPath + '/GestionComercial/Promotores/Procesos.aspx?',oParamCollecionBusqueda);
		</SCRIPT>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
