<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="BuscarOrdendeCompra.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CartasCredito.BuscarOrdendeCompra" %>

<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<SCRIPT>
			miOrdendeCompras = new OrdendeCompra();
			function OrdendeCompra(Periodo,NroOC,NroOrdendeCompra,Moneda,NProveedor,NombreCentroOperativo,IdCentroOperativo,Descripcion,MontoOC,MontoGastoOC,MontoCC)
			{
				this.nroOrdendeCompra = NroOrdendeCompra;
				this.moneda = Moneda;
				this.nProveedor=NProveedor;
				this.nombreCentroOperativo= NombreCentroOperativo;
				this.idCentroOperativo = IdCentroOperativo;
				this.descripcion = Descripcion;
				this.montoOC = MontoOC;
				this.montoGastoOC = MontoGastoOC;
				this.montoCC = MontoCC;
				this.periodo=Periodo;
				this.nroOC=NroOC;
			}
			
			function AsignarDatos(Periodo,NroOC,NroOrdendeCompra,Moneda,NProveedor,NombreCentroOperativo,IdCentroOperativo,Descripcion,MontoOC,MontoGastoOC,MontoCC)
			{
				miOrdendeCompras.nroOrdendeCompra = NroOrdendeCompra;
				miOrdendeCompras.moneda = Moneda;
				miOrdendeCompras.nProveedor=NProveedor;
				miOrdendeCompras.nombreCentroOperativo= NombreCentroOperativo;
				miOrdendeCompras.idCentroOperativo = IdCentroOperativo;
				miOrdendeCompras.descripcion = Descripcion;
				miOrdendeCompras.montoOC = MontoOC;
				miOrdendeCompras.montoGastoOC = MontoGastoOC;
				miOrdendeCompras.montoCC = MontoCC;
				miOrdendeCompras.periodo=Periodo;
				miOrdendeCompras.nroOC=NroOC;
			}			
			function EntregarDatos()
			{
					opener.document.forms[0].txtNroOrdenCompra.value =miOrdendeCompras.nroOrdendeCompra;
					opener.document.forms[0].txtMoneda.value =miOrdendeCompras.moneda;
					opener.document.forms[0].txtDescripcionOC.value = miOrdendeCompras.descripcion;
					opener.document.forms[0].txtProveedor.value =miOrdendeCompras.nProveedor;
					opener.document.forms[0].txtCentroOperativo.value =miOrdendeCompras.nombreCentroOperativo;
					opener.document.forms[0].nImporte.value = miOrdendeCompras.montoOC;
					opener.document.forms[0].nGastos.value =miOrdendeCompras.montoGastoOC;
					opener.document.forms[0].NTotalOC.value =(parseFloat(miOrdendeCompras.montoOC)  + parseFloat(miOrdendeCompras.montoGastoOC));
					opener.document.forms[0].nTipoCambio.value =0;
					opener.document.forms[0].nContravalor.value =0;
					opener.document.forms[0].hPeriodo.value =miOrdendeCompras.periodo;
					opener.document.forms[0].hNroOC.value =miOrdendeCompras.nroOC;
					opener.document.forms[0].txtidCentroOperativo.value =miOrdendeCompras.idCentroOperativo;
					window.close();
			}
			
		</SCRIPT>
</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0" onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Dialogo de Busqueda de Ordenes de Compra</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE cellSpacing="0" cellPadding="0" width="751" border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD></TD>
								<TD style="WIDTH: 138px"><IMG id="ibtnFiltrarSeleccion" title="OrdenCompra" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
										src="../../imagenes/filtroporseleccion.jpg"></TD>
								<TD style="WIDTH: 9px"><asp:imagebutton id="ibtnEliminaFiltro" runat="server" ImageUrl="../../imagenes/filtroEliminar.GIF"
										ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
								<TD style="WIDTH: 2px"><asp:label id="Label3" runat="server" CssClass="normaldetalle" Width="53px" Font-Bold="True"> Buscar :</asp:label></TD>
								<TD width="100%"><INPUT class="InputFind" id="txtBuscar" onkeydown="BusquedaporCampoColumna(this.value);"
										title="Buscar por la Columna Seleccionada" style="BORDER-RIGHT: #999999 1px groove; BORDER-TOP: #999999 1px groove; BORDER-LEFT: #999999 1px groove; WIDTH: 152px; BORDER-BOTTOM: #999999 1px groove"
										type="text" size="20" name="txtBuscar"></TD>
								<TD style="WIDTH: 186px"></TD>
								<TD></TD>
								<TD></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="752px" ShowFooter="True" RowHighlightColor="#E0E0E0"
							AutoGenerateColumns="False" AllowSorting="True" AllowPaging="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle HorizontalAlign="Center" Width="1%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OrdenCompra" SortExpression="OrdenCompra" HeaderText="NRO OC">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CENTRO" SortExpression="CENTRO" HeaderText="CO">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NProveedor" SortExpression="NProveedor" HeaderText="PROVEEDOR">
									<HeaderStyle Width="30%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
									<HeaderStyle Width="40%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Moneda" SortExpression="Moneda" HeaderText="M">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MontoOC" SortExpression="MontoOC" HeaderText="VALOR FOB">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><IMG id="ibtnEntregar" style="CURSOR: hand" onclick="EntregarDatos();" alt="" src="../../imagenes/bt_aceptar.gif">&nbsp;<IMG id="ibtnCancelar" style="CURSOR: hand" onclick="window.close();" alt="" src="../../imagenes/bt_cancelar.gif"></TD>
				</TR>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			
		</SCRIPT>
	</body>
</HTML>
