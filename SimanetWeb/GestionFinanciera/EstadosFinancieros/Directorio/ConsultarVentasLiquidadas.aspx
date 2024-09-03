<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="ConsultarVentasLiquidadas.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.Directorio.ConsultarVentasLiquidadas" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ConsultarDetalleProyectosGeneral</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../../js/JSFrameworkSima.js"></SCRIPT>
		<script>
		function MostrarOcultar(mostrar)
		{
			var odatagrid = document.all["grid"];
			
			for (var i=0;i<=odatagrid.rows.length-1;i++)
			{
				var NroFila = ((i==0)?1:0);
				var otable = odatagrid.rows[i].cells(6).children[0];
				otable.rows[NroFila].cells[0].style.display = mostrar;
				otable.rows[NroFila].cells[1].style.display = mostrar;
				var estilo = "";
				if (mostrar == "block")
				{
					estilo = "1px #cccccc solid";
				}
				else
				{
					estilo = "";
				}
				otable.rows[NroFila].cells[2].style.borderLeft = estilo;
			}
		}


		function ExpandCollapse()
		{
			var objHideEstado = document.all["ESTADO"];
			var oimg = window.event.srcElement;
			if (oimg==undefined)
			{
				oimg = document.all[objHideEstado.value.toString()];
			}
			
			var strPath = oimg.src.toString();
			var arrPath = oimg.src.toString().split("/");
			var strimg = arrPath[arrPath.length-1].split(".")[0].toString();
			var Estado="";
			
			if (strimg.toUpperCase()=="PLUS")
			{
				objHideEstado.value = oimg.id.toString();
				strPath = strPath.replace("plus","minus");
				Estado="block";
			}
			else
			{
				strPath = strPath.replace("minus","plus");
				Estado="none";
				objHideEstado.value = "";
			}
			oimg.src = strPath;
			MostrarOcultar(Estado);
		}
		
		function RestauraEstado()
		{
			var objHideEstado = document.all["ESTADO"];
			if (objHideEstado.value.toString().length>0)
			{
				oimg = document.all[objHideEstado.value.toString()];
				oimg.onclick();
				
			}
		}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="RestauraEstado();ObtenerHistorial();"
		rightMargin="0" onunload="SubirHistorial();">
		<form id="form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD bgColor="#f0f0f0" colSpan="2">
						<TABLE id="Table0" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
							<TR>
								<TD style="WIDTH: 52px" colSpan="5"><asp:label id="lblLN" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="373px"
										Font-Bold="True"></asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 52px" colSpan="5"><asp:label id="lblPantalla" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
										Width="373px" Font-Bold="True">VENTAS LIQUIDADAS</asp:label></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 52px"><asp:label id="Label3" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
										Font-Bold="True">PERIODO :</asp:label></TD>
								<TD style="WIDTH: 36px"><asp:label id="lblPeriodo" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy"
										Width="32px" Font-Bold="True"> 2005</asp:label></TD>
								<TD style="WIDTH: 24px"><asp:label id="Label2" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Font-Bold="True">MES :</asp:label></TD>
								<TD style="WIDTH: 88px"><asp:label id="lblMes" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="80%"
										Font-Bold="True">Periodo :</asp:label></TD>
								<TD align="center"><asp:label id="Label4" runat="server" CssClass="TituloPrincipalBlanco" ForeColor="Navy" Width="373px"
										Font-Bold="True">EN MILES DE NUEVOS SOLES</asp:label></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR id="id4">
					<TD>
						<asp:imagebutton id="ibtnFiltrar" runat="server" CausesValidation="False" ImageUrl="../../../imagenes/filtrar.gif"></asp:imagebutton><IMG id="ibtnFiltrarSeleccion" style="CURSOR: hand" onclick="FiltroporSeleccion(1);"
							alt="Aplicar Filtro por Selección" src="../../../imagenes/filtroPorSeleccion.JPG">
						<asp:imagebutton id="ibtnEliminarFiltro" runat="server" ImageUrl="../../../imagenes/filtroEliminar.GIF"
							ToolTip="Eliminar Filtro.."></asp:imagebutton>
						<asp:imagebutton id="ibtnAbrir" runat="server" ImageUrl="..\..\..\imagenes\bt_exportar.gif"></asp:imagebutton></TD>
				</TR>
				<TR>
					<TD><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" Width="100%" ShowFooter="True"
							RowHighlightColor="#E0E0E0" AutoGenerateColumns="False" AllowSorting="True" PageSize="7" AllowPaging="True">
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla"></FooterStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<Columns>
								<asp:BoundColumn HeaderText="NRO">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="OT" SortExpression="OT" HeaderText="OT'S">
									<HeaderStyle Width="3%"></HeaderStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="FEC_EMS" SortExpression="FEC_EMS" HeaderText="FECHA EMISION" DataFormatString="{0: dd-MM-yyyy}">
									<HeaderStyle Width="8%"></HeaderStyle>
									<FooterStyle HorizontalAlign="Center"></FooterStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="CLIENTE" SortExpression="CLIENTE" HeaderText="CLIENTE">
									<HeaderStyle Font-Underline="True" Width="15%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="SERVICIO" SortExpression="SERVICIO" HeaderText="SERVICIO">
									<HeaderStyle Width="16%"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn SortExpression="VALORIZACION" HeaderText="VAL" DataFormatString="{0:# ### ### ##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn HeaderText="COSTOS DE PRODUCCION">
									<HeaderStyle Width="22%"></HeaderStyle>
									<HeaderTemplate>
										<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
											<TR>
												<TD style="BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #cccccc; BORDER-BOTTOM: #cccccc 1px solid; HEIGHT: 10px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #cccccc"
													align="center" colSpan="3">&nbsp;
													<asp:Label id="lblCostosdeProduccion" runat="server" CssClass="HeaderGrilla" BorderStyle="None">COSTOS DE PRODUCCION</asp:Label></TD>
											</TR>
											<TR>
												<TD align="center" width="36%">
													<asp:Label id="lblDir" runat="server" CssClass="HeaderGrilla" BorderStyle="None">DIR</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="36%">
													<asp:Label id="lblInd" runat="server" CssClass="HeaderGrilla" BorderStyle="None">IND</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="center" width="28%">
													<asp:Label id="lblCostoTotal" runat="server" CssClass="HeaderGrilla" BorderStyle="None">TOT</asp:Label></TD>
											</TR>
										</TABLE>
									</HeaderTemplate>
									<ItemTemplate>
										<TABLE id="Table4" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="36%">
													<asp:Label id="lblDirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">DIR</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="36%">
													<asp:Label id="lblIndirectos" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">IND</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28%">
													<asp:Label id="lblTotal" runat="server" CssClass="ItemGrillaSinColor" BorderStyle="None">TOTAL</asp:Label></TD>
											</TR>
										</TABLE>
									</ItemTemplate>
									<FooterTemplate>
										<TABLE id="Table8" height="100%" cellSpacing="0" cellPadding="0" width="100%" align="left"
											border="0">
											<TR>
												<TD align="right" width="36%">
													<asp:Label id="lblSumGDirectos" runat="server" CssClass="FooterGrilla" BorderStyle="None">DIR</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="36%">
													<asp:Label id="lblSumGIndirectos" runat="server" CssClass="FooterGrilla" BorderStyle="None">IND</asp:Label></TD>
												<TD style="BORDER-LEFT: #cccccc 1px solid; HEIGHT: 10px" align="right" width="28%">
													<asp:Label id="lblSumGTotal" runat="server" CssClass="FooterGrilla" BorderStyle="None">TOT</asp:Label></TD>
											</TR>
										</TABLE>
									</FooterTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn SortExpression="DIFERENCIA" HeaderText="DIF" DataFormatString="{0:# ### ### ##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn SortExpression="FACTURADO" HeaderText="FAC" DataFormatString="{0:# ### ### ##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn SortExpression="COBRADO" HeaderText="RES" DataFormatString="{0:# ### ### ##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn SortExpression="PORCENTAJEUTILIDAD" HeaderText="%" DataFormatString="{0:# ### ### ##0.00}">
									<ItemStyle HorizontalAlign="Right"></ItemStyle>
								</asp:BoundColumn>
								<asp:TemplateColumn Visible="False">
									<ItemTemplate>
										<asp:Image id="imgCaducidad" runat="server" Height="18px"></asp:Image>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2">
						<P align="left">
							<asp:label id="Label11" runat="server" Height="1px" Font-Size="XX-Small">OBSERVACIONES:</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><TEXTAREA id="campo1" style="WIDTH: 100%; FONT-FAMILY: Arial; HEIGHT: 64px; FONT-SIZE: 10px"
							name="campo1" rows="4" readOnly cols="101" runat="server"></TEXTAREA></TD>
				</TR>
				<TR>
					<TD align="right" colSpan="2">
						<asp:Button id="btnInd" runat="server" Width="0px"></asp:Button>
						<asp:Button id="btnTot" runat="server" Width="0px"></asp:Button>
						<asp:Button id="btnDir" runat="server" Width="0px"></asp:Button><INPUT id="hOrden" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="GASTOSDIRECTOS"
							name="hOrden" runat="server"><INPUT id="hGridPagina" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="0"
							name="hGridPagina" runat="server"><INPUT id="hGridSort" style="WIDTH: 32px; HEIGHT: 22px" type="hidden" size="1" value="FEC_EMS DESC, OT"
							name="hGridSort" runat="server"><INPUT id="ESTADO" type="hidden" runat="server"><IMG id="Img1" onclick="HistorialIrAtras();" alt="" src="../../../imagenes/RetornarAlFormato.GIF"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			SIMA.Utilitario.Error.TiempoEsperadePagina();
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
		<BR>
	</body>
</HTML>
