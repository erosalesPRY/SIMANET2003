<%@ Page language="c#" Codebehind="ConsultarDetallesCuentasporPagaryCobrar5Digitos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.ConsultarDetallesCuentasporPagaryCobrar5Digitos" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetallesCuentasporPagaryCobrar5Digitos</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
			function TipoVentana()
			{
				var DIGCTA = "DigCta";
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				
				var oValParams = oPagina.Request.Params[DIGCTA];
				var objtblMaster = document.all["tblMaster"];
				objtblMaster.rows[0].cells(0).style.display = (oValParams==SIMA.Utilitario.Constantes.Financiera.CuentasPorPagar.OtrasCuentasporPagarDiversas.toString())
															? SIMA.Utilitario.Constantes.Html.Atributos.Display.Block.toString()
															: SIMA.Utilitario.Constantes.Html.Atributos.Display.None.toString();
				
				objtblMaster.rows[1].cells(0).style.display = objtblMaster.rows[0].cells(0).style.display;

				objBtnAtras = document.all["ibtnAtras"];
				if (oValParams==SIMA.Utilitario.Constantes.Financiera.CuentasPorPagar.OtrasCuentasporPagarDiversas.toString())
				{
					oHtmObject = new SIMA.Utilitario.Helper.General.Html();
					objBtnAtras.onclick=SIMA.Utilitario.Constantes.Html.Eventos.Nulo.toString();
					oHtmObject.EnlazarEvento(objBtnAtras,SIMA.Utilitario.Constantes.Html.Eventos.Click.toString(),HistorialIrAtras);
				}
				
			}
			
			function MostrarVentana(oNombrePagina,oParametros)
			{
				HistorialIrAdelantePersonalizado("");
				oPagina = new SIMA.Utilitario.Helper.General.Pagina();
				oPagina.Response.Redirect(oNombrePagina+oParametros);
			}
			
		</script>
	</HEAD>
	<body onkeydown="if (event.keyCode==13 || event.keyCode==9)return false" bottomMargin="0"
		leftMargin="0" topMargin="0" onload="ObtenerHistorial();TipoVentana();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table id="tblMaster" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD id="ColHeader"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD id="ColMenu"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Detalle de Cuentas por Cobrar o Pagar</asp:label></TD>
				</TR>
				<TR>
					<TD style="HEIGHT: 12px" vAlign="top" align="center" width="100%"><asp:label id="lblNombreConcepto" runat="server" CssClass="RutaPaginaActual" Width="455px"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><cc1:datagridweb id="grid" runat="server" Width="454px" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" ShowFooter="True" PageSize="7">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle Font-Bold="True" CssClass="FooterGrillaEF"></FooterStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="1%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CuentaContable" SortExpression="CuentaContable" HeaderText="CUENTA">
									<HeaderStyle Width="2%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="NombreCuenta" SortExpression="NombreCuenta" HeaderText="CONCEPTO">
									<HeaderStyle Width="50%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Center" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SimaCallao" HeaderText="SIMA-CALLAO">
									<HeaderStyle Width="16.6%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<tr>
					<td vAlign="top" align="center" width="100%">
						<TABLE id="Table1" style="WIDTH: 456px; HEIGHT: 26px" cellSpacing="1" cellPadding="1" width="456"
							border="0">
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="window.close();" alt="" src="../../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></td>
				</tr>
			</table>
		</form>
		<SCRIPT>
		<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
