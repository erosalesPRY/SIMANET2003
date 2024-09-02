<%@ Page language="c#" Codebehind="AdministrarVentasRealesExcel.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Ventas.AdministrarVentasRealesExcel" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Ventas Reales</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\imagenes\bt_exportar.gif"></asp:imagebutton>
				<asp:datagrid id="gridReporte" runat="server" CssClass="HeaderGrilla" Width="2300px" AutoGenerateColumns="False"
					PageSize="1" Height="1px">
					<FooterStyle CssClass="FooterGrilla"></FooterStyle>
					<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
					<ItemStyle CssClass="ItemGrilla"></ItemStyle>
					<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
					<Columns>
						<asp:BoundColumn DataField="IDVENTAREAL" HeaderText="IDVENTAREAL"></asp:BoundColumn>
						<asp:BoundColumn DataField="IDPROYECTOTRABAJO" HeaderText="IDPROYECTOTRABAJO"></asp:BoundColumn>
						<asp:BoundColumn DataField="CENTROOPERATIVO" HeaderText="CENTROOPERATIVO"></asp:BoundColumn>
						<asp:BoundColumn DataField="LINEANEGOCIO" HeaderText="LINEANEGOCIO">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="SECTOR" HeaderText="SECTOR">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="RAZONSOCIAL" HeaderText="RAZONSOCIAL">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="DESCRIPCION" HeaderText="DESCRIPCION">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="MONTOPRECIOVENTASOLES" HeaderText="MONTOPRECIOVENTASOLES"></asp:BoundColumn>
						<asp:BoundColumn DataField="BUENAPRO" HeaderText="BUENAPRO"></asp:BoundColumn>
						<asp:BoundColumn DataField="PROMOTOR" HeaderText="PROMOTOR">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundColumn>
						<asp:BoundColumn DataField="ESTADO" HeaderText="ESTADO"></asp:BoundColumn>
						<asp:BoundColumn DataField="INICIO CONTRACTUAL" HeaderText="INICIO CONTRACTUAL"></asp:BoundColumn>
						<asp:BoundColumn DataField="FIN CONTRACTUAL" HeaderText="FIN CONTRACTUAL"></asp:BoundColumn>
						<asp:BoundColumn DataField="INICIO REAL" HeaderText="INICIO REAL"></asp:BoundColumn>
						<asp:BoundColumn DataField="FIN REAL" HeaderText="FIN REAL"></asp:BoundColumn>
						<asp:BoundColumn DataField="UTILIDAD" HeaderText="UTILIDAD"></asp:BoundColumn>
					</Columns>
					<PagerStyle Visible="False" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
				</asp:datagrid>
			</P>
			<P>
				<asp:Label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:Label>&nbsp;
			</P>
		</form>
	</body>
</HTML>
