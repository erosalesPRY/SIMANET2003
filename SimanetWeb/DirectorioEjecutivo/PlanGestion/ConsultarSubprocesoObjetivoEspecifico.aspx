<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Page language="c#" Codebehind="ConsultarSubprocesoObjetivoEspecifico.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion.ConsultarSubprocesoObjetivoEspecifico" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarSubprocesoObjetivoEspecifico</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD>
						<P style="COLOR: white" align="left" class="Commands">
							<asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Plan de Gestión ></asp:label>
							<asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual">Objetivos Especificos del Plan de Gestión</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD>
						<TABLE id="Table3" cellSpacing="0" cellPadding="0" align="center" border="0">
							<TR>
								<TD>
									<asp:Image id="Image1" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
							</TR>
							<TR>
								<TD>
									<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalAzul">OBJETIVOS ESPECIFICOS</asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD>
									<asp:Image id="Image2" runat="server" Width="72px" Height="16px" ImageUrl="../../imagenes/spacer.gif"></asp:Image></TD>
							</TR>
							<TR>
								<TD style="HEIGHT: 9px">
									<TABLE id="Table2" borderColor="#ffffff" cellSpacing="0" cellPadding="0" width="100%" bgColor="#f0f0f0"
										border="2">
										<TR>
											<TD style="HEIGHT: 2px" width="90">
												<asp:label id="lblProceso" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
											<TD style="HEIGHT: 2px">
												<asp:Label id="lblNombreProceso" runat="server" CssClass="normaldetalle"></asp:Label></TD>
										</TR>
										<TR>
											<TD style="HEIGHT: 2px" width="90">
												<asp:label id="lblSubProceso" runat="server" CssClass="normaldetalle" Width="100%"></asp:label></TD>
											<TD style="HEIGHT: 2px">
												<asp:Label id="lblNombreSubProceso" runat="server" CssClass="normaldetalle"></asp:Label></TD>
										</TR>
										<TR>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="780px" RowPositionEnabled="False"
										RowHighlightColor="#E0E0E0" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True"
										ShowFooter="True" PageSize="7">
										<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
										<ItemStyle CssClass="ItemGrilla"></ItemStyle>
										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderGrilla"></HeaderStyle>
										<FooterStyle HorizontalAlign="Right" CssClass="FooterGrilla"></FooterStyle>
										<Columns>
											<asp:BoundColumn HeaderText="NRO">
												<HeaderStyle Width="2%"></HeaderStyle>
												<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="CODIGOOESPECIFICOS" SortExpression="CODIGOOESPECIFICOS" HeaderText="OE">
												<ItemStyle VerticalAlign="Middle"></ItemStyle>
											</asp:BoundColumn>
											<asp:BoundColumn DataField="NOMBREOESPECIFICOS" SortExpression="NOMBREOESPECIFICOS" HeaderText="DESCRIPCION">
												<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
												<FooterStyle HorizontalAlign="Left"></FooterStyle>
											</asp:BoundColumn>
											<asp:BoundColumn HeaderText="RESPONSABLE"></asp:BoundColumn>
											<asp:BoundColumn DataField="IDOGENERALES" SortExpression="IDOGENERALES" HeaderText="OG"></asp:BoundColumn>
										</Columns>
										<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
									</cc1:datagridweb></TD>
							</TR>
							<TR>
								<TD>
									<P align="center">
										<asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda" Visible="False"></asp:label></P>
								</TD>
							</TR>
							<TR>
								<TD><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif">
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
