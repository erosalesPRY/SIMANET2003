<%@ Page language="c#" Codebehind="ConsultarOtrasCuentasPorPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.CuentasPorCobrarPagarDirectorio.ConsultarOtrasCuentasPorPagar" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarOtrasCuentasPorPagar</title>
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
		<form id="form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR id="id1">
					<TD colSpan="2"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="id2">
					<TD colSpan="2"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR id="id3">
					<TD class="Commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Financiera > Consultar Cuentas por Cobrar y Pagar > Consultar Cuentas Por Pagar ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Otras Cuentas</asp:label></TD>
				</TR>
				<TR id="id4">
					<TD align="right" bgColor="#f0f0f0" colSpan="2"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5);"
							alt="" src="../../../imagenes/bt_imprimir.gif"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><cc1:datagridweb id="grid" runat="server" DESIGNTIMEDRAGDROP="262" BorderStyle="None" PageSize="7"
							AllowSorting="True" AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%">
							<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn DataField="Descripcion" HeaderText="SUBCUENTA" FooterText="TOTAL:">
									<HeaderStyle Width="25%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSimaCallao" HeaderText="CALLAO" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSimaChimbote" HeaderText="CHIMBOTE" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSimaPeru" HeaderText="PERU" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MSimaIquitos" HeaderText="IQUITOS" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="MTotal" HeaderText="TOTAL" DataFormatString="{0:# ### ### ##0.00}">
									<HeaderStyle HorizontalAlign="Center" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
									<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
								</asp:BoundColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb><BR>
						<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR id="id5">
					<TD colSpan="2"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/atras.gif"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
