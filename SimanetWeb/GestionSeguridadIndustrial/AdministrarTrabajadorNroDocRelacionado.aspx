<%@ Page language="c#" Codebehind="AdministrarTrabajadorNroDocRelacionado.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.AdministrarTrabajadorNroDocRelacionado" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarPersona_Contratista_Visita</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../js/RegEXT.js"></script>
	</HEAD>
	<body onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" scroll="no" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<TR>
					<TD><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="commands"><asp:label style="Z-INDEX: 0" id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio >Seguridad Industrial ></asp:label><asp:label style="Z-INDEX: 0" id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administración Personal (contratista-visitas)></asp:label></TD>
				</TR>
				<TR>
					<TD height="100%" vAlign="top" align="center">
						<TABLE style="WIDTH: 400px; HEIGHT: 75px" id="Table2" border="0" cellSpacing="1" cellPadding="1"
							width="818" align="center">
							<TR>
								<TD style="DISPLAY: none" align="right"><asp:button style="Z-INDEX: 0" id="btnGrabar" runat="server" Text="Grabar"></asp:button>
									<TABLE id="Table4" border="0" cellSpacing="1" cellPadding="1" width="300" align="right">
										<TR>
											<TD align="right"></TD>
											<TD align="right"></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center">
									<TABLE style="WIDTH: 648px; HEIGHT: 81px" id="Table3" border="0" cellSpacing="1" cellPadding="1"
										width="648">
										<TR>
											<TD colSpan="2" noWrap align="center">
												<asp:Label id="Label1" runat="server" Font-Bold="True">CAMBIO DE NRO DE DOCUMENTO</asp:Label></TD>
										</TR>
										<TR>
											<TD noWrap>
												<asp:Label id="Label2" runat="server">APELLIDOS Y NOMBRES:</asp:Label></TD>
											<TD width="100%" noWrap>
												<asp:Label style="Z-INDEX: 0" id="lblApellidosyNombres" runat="server">APELLIDOS Y NOMBRES:</asp:Label></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<cc1:datagridweb style="Z-INDEX: 0" id="grid" runat="server" CssClass="HeaderGrilla" RowPositionEnabled="False"
													RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" Width="464px" PageSize="20">
													<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
													<ItemStyle Height="20px" CssClass="ItemGrilla"></ItemStyle>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="1%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
															<FooterStyle HorizontalAlign="Left"></FooterStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NroDocOld" HeaderText="NRO  DOC ANT">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:TemplateColumn HeaderText="NRO DOC NUEVO">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemTemplate>
																<asp:TextBox id="txtNroDocNew" runat="server" Width="177px"></asp:TextBox>
															</ItemTemplate>
														</asp:TemplateColumn>
														<asp:BoundColumn DataField="Fecha" HeaderText="FECHA">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<PagerStyle HorizontalAlign="Center" CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
												</cc1:datagridweb></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD align="center"></TD>
							</TR>
							<TR>
								<TD align="right"><INPUT style="WIDTH: 75px; HEIGHT: 23px" id="hNroDoc" size="7" type="hidden" name="hNroDoc"
										runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 50px; HEIGHT: 22px" id="hGridPagina" value="0" size="3"
										type="hidden" name="hGridPagina" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 57px; HEIGHT: 22px" id="hGridPaginaSort" size="4" type="hidden"
										name="hGridPaginaSort" runat="server"><IMG style="Z-INDEX: 0" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/atras.gif"></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>		
			<asp:literal id=ltlMensaje runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<script>
			function CrearNuevoNroDOc(NroDocAnt,e){
				if(((event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn)||(event.keyCode==SIMA.Utilitario.Constantes.General.KeyCode.keyTab))&&(e.value.length>0)){
					Ext.MessageBox.confirm('CREAR NRO DE DOCUMENTO', 'desea ud. crear un nuevo nro relacionado a este trabajador?', function(btn){
									if(btn=="yes"){
										//var idResult = (new Controladora.Personal.CCCTT_Trabajado()).ActualizarNroDoc(IdReg, DNInuevo,DNIAntiguo);
										var strParam = NroDocAnt + '|' + e.value;
										__doPostBack('btnGrabar',strParam);
										
									}
								});
				}
			}
		</script>
	</body>
</HTML>
