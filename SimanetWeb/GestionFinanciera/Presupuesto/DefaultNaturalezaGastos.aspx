<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="DefaultNaturalezaGastos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.DefaultNaturalezaGastos" %>
<%@ OutputCache Duration="1" Location="Client" VaryByParam="None" %>


<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Relacion de Naturaleza de Gastos</title>
		<META content="text/html; charset=windows-1252" http-equiv="Content-Type">
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<script>
				
			
		</script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<form id="Form2" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" align="center">
				<TR>
				</TR>
				<TR>
					<TD class="commands"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Gestión Financiera ></asp:label><asp:label style="Z-INDEX: 0" id="Label26" runat="server" CssClass="RutaPaginaActual">Administracion Presupuesto></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Relacion de Naturaleza de Gastos</asp:label></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD bgColor="#000080" align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="16px" Width="401px">RELACION DE NATURALEZA DE GASTOS</asp:label></TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" Height="1px"
										Width="100%" AllowSorting="True" AutoGenerateColumns="False" AllowPaging="True" RowHighlightColor="#E0E0E0"
										RowPositionEnabled="False" PageSize="15" ShowFooter="True">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn DataField="CuentaContableGrupo" HeaderText="Cuenta Contable">
												<HeaderStyle Width="4%"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Center"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NombreCuenta" HeaderText="Naturaleza Gastos">
												<HeaderStyle Width="15%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="1%"></HeaderStyle>
												<ItemTemplate>
													<asp:CheckBox id="cbxNaturaleza" runat="server"></asp:CheckBox>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD bgColor="#f0f0f0" align="center" style="HEIGHT: 1px"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False" DESIGNTIMEDRAGDROP="55"></asp:label></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="left">
									<asp:ImageButton id="ibtnAceptar" runat="server" ImageAlign="Right" ImageUrl="../../imagenes/bt_agregar.gif"></asp:ImageButton></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
		<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal></SCRIPT>
	</body>
</HTML>
