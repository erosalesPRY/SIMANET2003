<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="FiltrosParaReporte.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasFianza.FiltrosParaReporte" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>FiltrosParaReporte</title>
		<meta name="vs_snapToGrid" content="True">
		<meta name="vs_showGrid" content="True">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Menu/MenuSP.js"></script>
		<script>
				function txtNrofianza_ItemDataBound(sender,e,dr){
					
						$O("txtNroFianza").value = dr["nrocartaFianza"].toString();
																
					}		
		
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD><uc1:header style="Z-INDEX: 0" id="Header1" runat="server"></uc1:header>
						<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD><uc1:menu style="Z-INDEX: 0" id="Menu1" runat="server"></uc1:menu></TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE style="Z-INDEX: 0" id="Table2" border="0" cellSpacing="1" cellPadding="1" width="100%">
										<TR>
											<TD style="HEIGHT: 22px" class="TituloPrincipalBlanco" bgColor="#000080" width="67"
												colSpan="9" align="center">
												<P align="center"><asp:label style="Z-INDEX: 0" id="Label6" runat="server" Height="16px" Width="1531px" CssClass="TItuloPrincipalBlanco">FILTROS PARA REPORTE</asp:label></P>
											</TD>
										</TR>
										<TR>
											<TD class="normalDetalle" align="right"></TD>
											<TD class="normalDetalle" colSpan="8" align="right">
												<DIV align="left"></DIV>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 67px; HEIGHT: 19px"><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar2" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Pdf.gif"
													ToolTip="Fianas Agrupados por Beneficiario y Proyecto"></asp:imagebutton>&nbsp;
												<asp:imagebutton style="Z-INDEX: 0" id="imgXLS2" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"
													ToolTip="Fianas Agrupados por Beneficiario y Proyecto"></asp:imagebutton></TD>
											<TD style="WIDTH: 112px; HEIGHT: 19px"><asp:label style="Z-INDEX: 0" id="Label9" class="ControlesLabes" runat="server" Height="17px"
													Width="80px" BackColor="White"> Por Proyecto</asp:label></TD>
											<TD></TD>
											<TD colSpan="2" noWrap></TD>
											<TD style="WIDTH: 364px" width="364"></TD>
											<TD width="30%"></TD>
											<TD style="WIDTH: 99px; HEIGHT: 19px">
												<P align="right">&nbsp;</P>
											</TD>
											<TD style="HEIGHT: 19px" align="center">
												<TABLE id="Table5" border="0" cellSpacing="1" cellPadding="1" width="100%" align="right">
													<TR>
														<TD style="WIDTH: 170%; PADDING-RIGHT: 5px" align="center">
															<P align="right"><asp:imagebutton style="Z-INDEX: 0" id="ibtnFiltrar" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/Pdf.gif"
																	ToolTip="Fianzas Agrupadas por Proyectos"></asp:imagebutton></P>
														</TD>
														<TD align="center"><asp:imagebutton style="Z-INDEX: 0" id="imgXLS" runat="server" ImageUrl="/SimaNetWeb/imagenes/Navegador/xls.gif"
																ImageAlign="Right" ToolTip="Fianzas Agrupadas por Proyectos"></asp:imagebutton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 67px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label7" runat="server">ORIGEN</asp:label></TD>
											<TD style="WIDTH: 112px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label8" runat="server">TDOC</asp:label></TD>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label1" runat="server">CO</asp:label></TD>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label2" runat="server">BANCO</asp:label></TD>
											<TD style="WIDTH: 68px" class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label11" runat="server">PROCEDENCIA</asp:label></TD>
											<TD style="WIDTH: 364px" class="HeaderDetalle" width="364"><asp:label id="Label3" runat="server">BENEFICIARIO</asp:label></TD>
											<TD class="HeaderDetalle"><asp:label id="Label10" runat="server">PROYECTO</asp:label></TD>
											<TD class="HeaderDetalle"><asp:label id="Label4" runat="server">NRO. FIANZA</asp:label></TD>
											<TD class="HeaderDetalle"><asp:label style="Z-INDEX: 0" id="Label5" runat="server">SITUACION</asp:label></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 67px"><asp:dropdownlist style="Z-INDEX: 0" id="DDLORIGEN" runat="server" Height="20px" Width="80px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 112px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlTipoDoc" runat="server" Height="20px" Width="120px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 82px"><asp:dropdownlist style="Z-INDEX: 0" id="ddlCentro" runat="server" Height="20px" Width="88px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 104px"><asp:dropdownlist style="Z-INDEX: 0" id="DDLBANCO" runat="server" Height="20px" Width="120px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 68px"><asp:dropdownlist style="Z-INDEX: 0" id="DDLTIPOPROCEDEN" runat="server" Height="20px" Width="87px"
													CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 364px" width="364"><asp:dropdownlist id="DDLBENEFICIARIO" runat="server" Height="20px" Width="360px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 430px"><asp:dropdownlist id="ddlproyecto" runat="server" Height="20px" Width="456px" CssClass="normaldetalle"></asp:dropdownlist></TD>
											<TD style="WIDTH: 99px"><asp:textbox id="txtNroFianza" runat="server" Width="108px"></asp:textbox></TD>
											<TD><asp:dropdownlist style="Z-INDEX: 0" id="DDLSITUACION" runat="server" Height="20px" Width="100px"
													CssClass="normaldetalle"></asp:dropdownlist></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 21px"></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<P>&nbsp;</P>
						<P><IMG style="Z-INDEX: 0; WIDTH: 72px; HEIGHT: 19px" id="ibtnAtras" onclick="HistorialIrAtras();"
								alt="" align="left" src="../../imagenes/atras.gif" width="72" height="19"></P>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</script>
		<script>
		
									//var oPagina = new SIMA.Utilitario.Helper.General.Pagina();
						var oParamCollecionBusqueda = new ParamCollecionBusqueda();//El parametro de ingreso es el Nro de Caracter que desencadenara la busqueda
						var oParamBusqueda = new ParamBusqueda();
					
							oParamBusqueda.Nombre="nrocartafianza";
							oParamBusqueda.Texto="Nro.de Carta Fianza";
							oParamBusqueda.LongitudEjecucion=3;
							oParamBusqueda.Tipo="C";
							oParamBusqueda.Ancho=100;
							//oParamBusqueda.CampoAlterno = "";
							oParamCollecionBusqueda.Agregar(oParamBusqueda);
					
											
							oParamBusqueda = new ParamBusqueda();
							oParamBusqueda.Nombre="idProceso";
							oParamBusqueda.Valor=SIMA.Utilitario.Constantes.General.ProcesoCallBack.ConsultarFianzaDetallePorNro;
							oParamBusqueda.Tipo="Q";
						oParamCollecionBusqueda.Agregar(oParamBusqueda);
						
						(new AutoBusqueda('txtNroFianza')).Crear('/' + ApplicationPath + '/GestionFinanciera/Procesar.aspx?',oParamCollecionBusqueda);
		</script>
	</body>
</HTML>
