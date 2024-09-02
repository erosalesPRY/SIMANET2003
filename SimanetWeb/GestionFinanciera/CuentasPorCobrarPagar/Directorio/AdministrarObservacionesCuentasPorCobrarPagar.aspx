<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="AdministrarObservacionesCuentasPorCobrarPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.AdministrarObservacionesCuentasPorCobrarPagar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarObservacionesCuentasPorCobrarPagar</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3">
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
								<TR>
									<TD colSpan="3">
										<DIV align="center"></DIV>
									</TD>
								</TR>
								<TR>
									<TD bgColor="#f0f0f0" colSpan="3"><asp:imagebutton id="ibtnFiltrar" runat="server" ImageUrl="../../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" onclick="FiltroporSeleccion(1);" alt="Aplicar Filtro por Selección"
											src="../../../imagenes/filtroPorSeleccion.JPG">
										<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../../imagenes/filtroEliminar.GIF"
											ToolTip="Eliminar Filtro.."></asp:imagebutton><IMG style="WIDTH: 729px; HEIGHT: 8px" height="8" src="../../imagenes/spacer.gif" width="729">
										<asp:imagebutton id="ibtnAgregar" runat="server" ImageUrl="../../../imagenes/bt_agregar.gif" Visible="False"></asp:imagebutton></TD>
								</TR>
								<TR>
									<TD colSpan="3"></TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridComercial" runat="server" Visible="False" AllowPaging="True" PageSize="1"
											Height="20px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO." FooterText="TOTAL:">
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="CLIENTE">
													<HeaderStyle Width="18%"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Num_Doc_Ana" SortExpression="Num_Doc_Ana" HeaderText="FACTURA">
													<HeaderStyle Width="8%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="FechaEmision" SortExpression="FechaEmision" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="12%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="TotalEnSoles" SortExpression="TotalEnSoles" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="13%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" HeaderText="FECHA VENC.">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn SortExpression="Descripcion" HeaderText="CONCEPTO">
													<ItemTemplate>
														<asp:TextBox id="txtDescripcion" runat="server" CssClass="normalDetalle" Width="100%" TextMode="MultiLine"
															BorderColor="Transparent" BackColor="Transparent" Rows="3" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
													</ItemTemplate>
												</asp:TemplateColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeComercial" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridDiversasAccionistas" runat="server" Visible="False" AllowPaging="True" PageSize="1"
											Height="40px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True" AutoGenerateColumns="False">
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
												<asp:BoundColumn DataField="Accionista" SortExpression="Accionista" HeaderText="ACCIONISTA">
													<HeaderStyle Width="30%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
													<HeaderStyle Width="25%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeDiversasAccionistas" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridDiversasPrestamoPersonal" runat="server" Visible="False" AllowPaging="True"
											PageSize="1" Height="40px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True"
											AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="cuentacontable" SortExpression="cuentacontable" HeaderText="CUENTA"></asp:BoundColumn>
												<asp:BoundColumn DataField="ApellidosNombres" SortExpression="ApellidosNombres" HeaderText="NOMBRE">
													<HeaderStyle Width="25%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="PR" SortExpression="PR" HeaderText="PR">
													<HeaderStyle Width="8%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Amortizado" SortExpression="Amortizado" HeaderText="AMORTIZADO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeDiversasPrestamosPersonal" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridDiversasPrestamosTerceros" runat="server" Visible="False" AllowPaging="True"
											PageSize="1" Height="40px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True"
											AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
													<HeaderStyle Width="2%"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="EMPRESA">
													<HeaderStyle Width="18%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="14%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Amortizado" SortExpression="Amortizado" HeaderText="AMORTIZADO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="14%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="14%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajesDiversasPrestamosTerceros" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridDiverasReclamosTerceros" runat="server" Visible="False" AllowPaging="True"
											PageSize="1" Height="32px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True"
											AutoGenerateColumns="False">
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
												<asp:BoundColumn DataField="Empresa" SortExpression="Empresa" HeaderText="EMPRESA">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Amortizado" SortExpression="Amortizado" HeaderText="AMORTIZADO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
													<HeaderStyle Width="15%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeDiversasReclamosTerceros" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridDiversasIntereses" runat="server" Visible="False" AllowPaging="True" PageSize="1"
											Height="40px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True" AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL:">
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemStyle Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Empresa" SortExpression="Empresa" HeaderText="EMPRESA">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC">
													<HeaderStyle Width="7%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="13%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="REFERENCIA">
													<HeaderStyle Width="25%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
													<HeaderStyle Width="5%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
													<HeaderStyle Width="7%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeDiversasIntereses" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridDiverasOtras" runat="server" Visible="False" AllowPaging="True" PageSize="1"
											Height="54px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True" AutoGenerateColumns="False">
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
												<asp:BoundColumn DataField="RazonSocial" SortExpression="RazonSocial" HeaderText="ENTIDAD">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Ruc" SortExpression="Ruc" HeaderText="RUC">
													<HeaderStyle Width="7%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Fecha" SortExpression="Fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Importe" SortExpression="Importe" HeaderText="IMPORTE" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="14%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Saldo" SortExpression="Saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="14%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Referencia" SortExpression="Referencia" HeaderText="REFERENCIA" DataFormatString="{0:###,##0.00}">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Concepto" SortExpression="Concepto" HeaderText="CONCEPTO">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="Observaciones" SortExpression="Observaciones" HeaderText="OBSERVACIONES">
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeDiversasOtras" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridJudicialesProvicionar" runat="server" Visible="False" AllowPaging="True"
											PageSize="1" Height="34px" Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True"
											AutoGenerateColumns="False">
											<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
											<ItemStyle CssClass="ItemGrilla"></ItemStyle>
											<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
											<FooterStyle HorizontalAlign="Right" CssClass="FooterGrillaEF"></FooterStyle>
											<Columns>
												<asp:BoundColumn HeaderText="NRO" FooterText="TOTAL">
													<HeaderStyle Width="1%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
													<FooterStyle Font-Size="XX-Small" Font-Bold="True" HorizontalAlign="Left" VerticalAlign="Middle"></FooterStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="SUBCUENTA" SortExpression="subcuenta" HeaderText="SUB CUENTA">
													<HeaderStyle Width="10%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="razonsocial" SortExpression="razonsocial" HeaderText="DEUDOR">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="nroentidad" SortExpression="nroentidad" HeaderText="IDENT.">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="num_doc_ana" SortExpression="num_doc_ana" HeaderText="REFERENCIA">
													<HeaderStyle Width="10%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="fecha" SortExpression="fecha" HeaderText="FECHA" DataFormatString="{0:dd-MM-yyyy}">
													<HeaderStyle Width="12%"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="saldo" SortExpression="saldo" HeaderText="SALDO" DataFormatString="{0:# ### ### ##0.00}">
													<HeaderStyle Width="12%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Right"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="concepto" SortExpression="concepto" HeaderText="CONCEPTO">
													<HeaderStyle Width="30%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:BoundColumn Visible="False" DataField="observaciones" SortExpression="observaciones" HeaderText="OBSERVACIONES">
													<HeaderStyle Width="20%"></HeaderStyle>
													<ItemStyle HorizontalAlign="Left"></ItemStyle>
												</asp:BoundColumn>
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeJudiciales" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"><cc1:datagridweb id="gridOtrosComercial" runat="server" AllowPaging="True" PageSize="1" Height="34px"
											Width="100%" ShowFooter="True" RowHighlightColor="#E0E0E0" AllowSorting="True" AutoGenerateColumns="False">
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
												<asp:TemplateColumn>
													<HeaderStyle Width="3%"></HeaderStyle>
													<ItemTemplate>
														<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
													</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
											<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
										</cc1:datagridweb></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center"><asp:label id="lblMensajeOtrosComercial" runat="server" Visible="False" CssClass="ResultadoBusqueda"></asp:label></P>
									</TD>
								</TR>
								<TR>
									<TD colSpan="3"></TD>
								</TR>
							</TABLE>
						</DIV>
						<INPUT id="hOrdenGrilla" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="hOrdenGrilla"
							runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server"><INPUT id="HidCO" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="HidCO"
							runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="Hnumdocana" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="Hnumdocana"
							runat="server" DESIGNTIMEDRAGDROP="410"><INPUT id="Hnroruc" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" name="Hnroruc"
							runat="server" DESIGNTIMEDRAGDROP="410"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
