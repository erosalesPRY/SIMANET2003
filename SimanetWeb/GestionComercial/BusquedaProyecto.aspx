<%@ Page language="c#" Codebehind="BusquedaProyecto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.BusquedaProyecto" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>BusquedaPromotores</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="610" align="center" border="0">
				<TR>
					<TD class="TituloPrincipal" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"> BUSQUEDA DE PROYECTOS</asp:label></TD>
				</TR>
				<TR>
					<TD align="right"></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="tabla" id="Table6" cellSpacing="0" cellPadding="0" width="550" bgColor="#f5f5f5"
							border="0">
							<TR bgColor="#ffffff">
								<TD class="TitFiltros"><IMG height="14" src="../imagenes/TitFiltros.gif" width="82"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD><INPUT id="hIdProyecto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hIdProyecto"
										runat="server"> <INPUT id="hProyecto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hProyecto"
										runat="server"> <INPUT id="hCliente" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCliente"
										runat="server"><INPUT id="hSector" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hSector"
										runat="server">
								</TD>
								<TD class="SmallFont" align="center" style="HEIGHT: 24px"></TD>
								<TD class="SmallFont" align="center" style="HEIGHT: 24px"></TD>
								<TD class="SmallFont" align="center" style="HEIGHT: 24px"></TD>
								<TD class="SmallFont" align="center" colSpan="1" style="HEIGHT: 24px"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros" align="left">&nbsp;<INPUT id="hCentroOperativo" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hCentroOperativo"
										runat="server"><INPUT id="hLineaNegocio" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hLineaNegocio"
										runat="server"><INPUT id="hMonto" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hMonto"
										runat="server"><INPUT id="hMoneda" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hMoneda"
										runat="server"><INPUT id="hMontoSoles" style="WIDTH: 16px; HEIGHT: 22px" type="hidden" size="1" name="hMontoSoles"
										runat="server"></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:label id="lblDescripcion" runat="server" CssClass="normal">Descripcion del Proyecto</asp:label></TD>
								<TD class="combos"></TD>
								<TD class="combos"></TD>
							</TR>
							<TR>
								<TD class="TitFiltros"></TD>
								<TD class="combos"></TD>
								<TD class="combos"><asp:textbox id="txtProyecto" runat="server" CssClass="normal" Width="370px"></asp:textbox></TD>
								<TD class="combos"><cc2:requireddomvalidator id="rfvDescripcionProyecto" runat="server" CssClass="normal" ControlToValidate="txtProyecto">*</cc2:requireddomvalidator></TD>
								<TD class="combos">
									<asp:imagebutton id="btnBuscar" runat="server" ImageUrl="../imagenes/bt_Buscar.GIF"></asp:imagebutton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE class="normal" id="Table1" cellSpacing="0" cellPadding="0" width="550" border="0">
							<TR>
								<TD align="center" colSpan="3">
									<cc1:datagridweb id="grid" runat="server" Width="600px" DataKeyField="IDPROYECTO" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
										CssClass="HeaderGrilla">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn Visible="False" DataField="IDPROYECTO"></asp:BoundColumn>
											<asp:BoundColumn DataField="DESCRIPCION" HeaderText="Descripcion del Proyecto"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="RAZONSOCIAL"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="SECTOR"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="CENTROOPERATIVO"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="LINEANEGOCIO"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MONTOPRECIOVENTASINIMPUESTO"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MONEDA"></asp:BoundColumn>
											<asp:BoundColumn Visible="False" DataField="MONTOPRECIOVENTASOLES"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"
										Visible="False"></asp:label></TD>
							</TR>
							<TR>
								<TD align="center" colSpan="3"><cc2:domvalidationsummary id="vSum" runat="server" CssClass="normal" Width="96px" DisplayMode="List" ShowMessageBox="True"
										EnableClientScript="False"></cc2:domvalidationsummary></TD>
							</TR>
						</TABLE>
						<IMG style="WIDTH: 160px; HEIGHT: 24px" height="24" src="../imagenes/spacer.gif" width="160">
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table8" width="180" border="0">
							<TR>
								<TD width="198">&nbsp;<asp:imagebutton id="ibtnAceptar" runat="server" ImageUrl="../imagenes/bt_aceptar.gif" Height="22px"
										Width="87px"></asp:imagebutton></TD>
								<TD width="94"><asp:image id="imgCancelar" runat="server" ImageUrl="../imagenes/bt_cancelar.gif" Width="87px"
										Height="22px"></asp:image></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
			&nbsp;
		</form>
		<script>
		<asp:Literal id="ltlMensaje" Runat="server" EnableViewState="False"></asp:Literal>		
		
		function PonerTexto()
			{ 
				opener.document.forms[0].hIdProyecto.value =document.forms[0].hIdProyecto.value;
				opener.document.forms[0].txtProyecto.value =document.forms[0].hProyecto.value;
				opener.document.forms[0].txtCliente.value =document.forms[0].hCliente.value;
				opener.document.forms[0].txtSector.value =document.forms[0].hSector.value;
				opener.document.forms[0].txtCentroOperativo.value =document.forms[0].hCentroOperativo.value;
				opener.document.forms[0].txtLineaNegocio.value =document.forms[0].hLineaNegocio.value;
				opener.document.forms[0].txtMonto.value =document.forms[0].hMonto.value;
				opener.document.forms[0].txtMoneda.value =document.forms[0].hMoneda.value;
				opener.document.forms[0].txtMontoSoles.value =document.forms[0].hMontoSoles.value;
				window.close();
			} 
		</script>
	</body>
</HTML>
