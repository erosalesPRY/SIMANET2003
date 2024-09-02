<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarAnalisisFinanciero.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.AnalisisFinanciero.AdministrarAnalisisFinanciero" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarAnalisisFinanciero</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3">
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD class="RutaPaginaActual" colSpan="3">
						<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label>
						<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Análisis Financieros</asp:label></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center">
						<asp:label id="lblSubTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></TD>
					<TD align="center"></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center">
						<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="600" bgColor="#f5f5f5" border="0">
							<TR>
								<TD></TD>
								<TD></TD>
								<TD colSpan="2" align="right">
									<asp:imagebutton id="ibtnEliminar" runat="server" ImageUrl="../../imagenes/bt_eliminar.gif"></asp:imagebutton>
									<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton>
									<asp:imagebutton id="ibtnConclusiones" runat="server" ImageUrl="../../imagenes/btnConclusion.jpg"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD colSpan="4">
									<cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
										Width="600px" DataKeyField="IdAdenda" AllowSorting="True" AllowPaging="True" PageSize="7" ShowFooter="True">
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO.">
												<HeaderStyle HorizontalAlign="Center" Width="30px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="CO">
												<HeaderStyle Width="30px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="DESCRIPCION">
												<HeaderStyle HorizontalAlign="Center" Width="200px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FECHA AF">
												<HeaderStyle HorizontalAlign="Center" Width="60px"></HeaderStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="FECHA CIERRE">
												<HeaderStyle HorizontalAlign="Center" Width="80px"></HeaderStyle>
											</asp:BoundColumn>
										</Columns>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD align="center" bgColor="#f5f5f5" colSpan="4">
									<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
							</TR>
						</TABLE>
					</TD>
					<TD></TD>
				</TR>
				<TR>
					<TD></TD>
					<TD align="center"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server"><INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
							runat="server"><INPUT id="hCodigo" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hCodigo"
							runat="server"></TD>
					<TD align="center"></TD>
				</TR>
				<TR>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
