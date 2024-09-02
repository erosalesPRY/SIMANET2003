<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="BusquedaCartaFianza.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.BusquedaCartaFianza" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js" type="text/javascript"></script>
		<script src="../../js/Menu/MenuSP.js" type="text/javascript"></script>
		<script>
				function txtBuscarFZA_ItemDataBound(sender,e,dr){
					LimpiarTexto();
					$O('txtCentroOperativo').value = dr["NombreCentroOperativo"].toString();
					$O('txtBanco').value = dr["EntidadFinanciera"].toString();
					$O('txtBeneficiario').value = dr["ClienteProveedor"].toString();
					$O('txtTipo').value = dr["Tipo"].toString();
					$O('txtPeriodo').value = dr["periodo"].toString();
					$O('txtConcepto').value = dr["Concepto"].toString();
					$O('hIdFianza').value = dr["idcartafianza"].toString();					
				}
				
				function LimpiarTexto(){
					$O('txtCentroOperativo').value = "";
					$O('txtBanco').value = "";
					$O('txtBeneficiario').value = "";
					$O('txtTipo').value = "";
					$O('txtPeriodo').value = "";
					$O('txtConcepto').value ="";
					$O('hIdFianza').value ="";
				}	
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblCabeceraPrint" cellSpacing="0" cellPadding="0" width="100%" align="center"
				border="0">
				<tr id="Cabecera">
					<td width="100%" colSpan="1"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<tr id="FilaMenu">
					<td vAlign="top" width="100%"><uc1:menu id="Menu1" runat="server"></uc1:menu></td>
				</tr>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Legal></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consultar Carta Fianza</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE id="Table2" style="WIDTH: 768px; HEIGHT: 160px" cellSpacing="0" cellPadding="0"
							width="768" align="center" border="0">
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap bgColor="white"><asp:label id="Label6" runat="server" CssClass="TituloPrincipalBlanco" Width="154px">BUSCAR FIANZA POR NRO:</asp:label></TD>
								<TD colSpan="3"><asp:textbox id="txtBuscarFZA" runat="server" Width="128px" Height="19px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 167px" bgColor="#000080" colSpan="4"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Width="160px" Height="8px">DETALLE CARTA FIANZA:</asp:label></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap><asp:label id="Label2" runat="server" Width="120px">CENTRO OPERATIVO:</asp:label></TD>
								<TD width="100%" bgColor="#dddddd"><asp:textbox id="txtCentroOperativo" runat="server" CssClass="normaldetalle" Width="408px" BackColor="Transparent"
										BorderStyle="None"></asp:textbox></TD>
								<TD class="HeaderDetalle"><asp:label id="Label11" runat="server">TIPO:</asp:label></TD>
								<TD bgColor="#dddddd"><asp:textbox id="txtTipo" runat="server" CssClass="normaldetalle" BackColor="Transparent" BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="HeaderDetalle" style="WIDTH: 89px" noWrap><asp:label id="Label4" runat="server">BANCO:</asp:label></TD>
								<TD width="100%" bgColor="#f0f0f0"><asp:textbox id="txtBanco" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
										BorderStyle="None"></asp:textbox></TD>
								<TD class="HeaderDetalle"><asp:label id="Label1" runat="server">PERIODO:</asp:label></TD>
								<TD bgColor="#f0f0f0"><asp:textbox id="txtPeriodo" runat="server" CssClass="normaldetalle" BackColor="Transparent"
										BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" style="WIDTH: 89px"><asp:label id="Label9" runat="server">BENEFICIARIO:</asp:label></TD>
								<TD width="100%" bgColor="#dddddd" colSpan="3"><asp:textbox id="txtBeneficiario" runat="server" CssClass="normaldetalle" Width="100%" BackColor="Transparent"
										BorderStyle="None"></asp:textbox></TD>
							</TR>
							<TR class="AlternateItemDetalle">
								<TD class="HeaderDetalle" noWrap><asp:label id="Label13" runat="server">CONCEPTO:</asp:label></TD>
								<TD style="HEIGHT: 3px" width="100%" bgColor="#f0f0f0" colSpan="3"><asp:textbox id="txtConcepto" runat="server" CssClass="normaldetalle" Width="100%" Height="56px"
										BackColor="Transparent" BorderStyle="None" TextMode="MultiLine"></asp:textbox></TD>
							</TR>
							<TR>
								<TD noWrap align="center" colSpan="4" rowSpan="1">
									<TABLE id="Table7" border="0">
										<TR>
											<TD colSpan="1"><asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" Height="22px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton></TD>
											<TD><IMG id="Img1" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
						<INPUT id="hIdFianza" type="hidden" name="hIdFianza" runat="server"></TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
						//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
							var oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="nrocartafianza";
							oParamBusqueda.CampoAlterno="Concepto";
							oParamBusqueda.LongitudEjecucion=2;
							oParamBusqueda.Tipo="C";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);

							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=200;
							oParamBusqueda.ParaBusqueda=false;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						(new AutoBusqueda('txtBuscarFZA')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
		</SCRIPT>
	</body>
</HTML>
