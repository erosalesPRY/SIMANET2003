<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarDetalleCuentasPorPagarOtros.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.ConsultarDetalleCuentasPorPagarOtros" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleCuentasPorPagarOtros</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR id="id1">
					<TD colSpan="2"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="id2">
					<TD colSpan="2"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR id="id3">
					<TD class="commands" colSpan="2"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera > Consultar Cuentas por Cobrar y Pagar > Consultar Cuentas Por Pagar > Otras Cuentas ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle</asp:label></TD>
				</TR>
				<TR id="id4">
					<TD style="HEIGHT: 21px" align="left" bgColor="#f0f0f0"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selecci�n"
							src="../../../imagenes/filtroPorSeleccion.JPG">
						<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../../imagenes/filtroEliminar.GIF"
							ToolTip="Eliminar Filtro.."></asp:imagebutton></TD>
					<TD style="HEIGHT: 21px" align="right" bgColor="#f0f0f0"><asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_abrir.gif"></asp:imagebutton><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5,id6,id7);"
							alt="" src="../../../imagenes/bt_imprimir.gif"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<cc1:datagridweb id="grid" runat="server" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%" AllowPaging="True">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ACREEDOR">
									<HeaderStyle Width="25%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle Width="20%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="fechaEmision" SortExpression="fechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
									<HeaderStyle Width="15%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="REFERENCIA">
									<HeaderStyle Width="35%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb><BR>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR id="id5">
					<TD align="left" colSpan="2"><asp:label id="lblObservaciones" runat="server" CssClass="normaldetalle">CONCEPTO:</asp:label></TD>
				</TR>
				<TR id="id6">
					<TD align="center" colSpan="2"><asp:textbox id="txtObservaciones" runat="server" CssClass="normalDetalle" Width="100%" Height="64px"
							TextMode="MultiLine"></asp:textbox></TD>
				</TR>
				<TR id="id7">
					<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
