<%@ Page language="c#" Codebehind="AdministrarGrupoFormatos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.Formato.AdministrarGrupoFormatos" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD>
						<uc1:Header id="Header1" runat="server"></uc1:Header></TD>
				</TR>
				<TR>
					<TD>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></TD>
				</TR>
				<TR>
					<TD style="FONT-SIZE: 14pt; FONT-WEIGHT: bold" align="center">
						<asp:Label id="Label1" runat="server">ADMINISTRAR GRUPO DE FORMATOS:</asp:Label></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" width="100%" align="center"><TABLE id="Table2" border="0" cellSpacing="1" cellPadding="1" width="300">
							<TR>
								<TD align="right" style="HEIGHT: 24px">
									<asp:imagebutton style="Z-INDEX: 0" id="ibtnAgregar" runat="server" CausesValidation="False" ImageUrl="../../imagenes/bt_agregar.gif"></asp:imagebutton></TD>
							</TR>
							<TR>
								<TD>
									<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" Width="598px" RowHighlightColor="#E0E0E0"
										AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" PageSize="20">
										<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="var1" HeaderText="NOMBRE">
												<HeaderStyle Width="40px"></HeaderStyle>
												<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
												<HeaderStyle Width="60%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:TemplateColumn>
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemTemplate>
													<IMG style="Z-INDEX: 0" id="ibtnFormato" alt="" src="../../imagenes/BtPU_Mas.gif" runat="server">
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">&nbsp;</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD><INPUT style="WIDTH: 84px; HEIGHT: 23px" id="hNroPag" value="0" size="8" type="hidden"
							runat="server" NAME="hNroPag"><INPUT style="Z-INDEX: 0; WIDTH: 84px; HEIGHT: 23px" id="Hidden1" value="0" size="8" type="hidden"
							name="hNroPag" runat="server"></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
