<%@ Page language="c#" Codebehind="ConsultarMovimientoMaterialesoServiciosPorCentroCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.ConsultarMovimientoMaterialesoServiciosPorCentroCosto" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>Detalle de Gastos por Naturaleza</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js">  </SCRIPT>
		<script>	
				function ObtenerCabeceraDataGrid()
				{
					oDataGrid = document.all["grid"];
					if (oDataGrid != undefined)
					{
						var tbl = oDataGrid.cloneNode(false);
						var tblb = document.createElement("TBody");
						tblb.appendChild(oDataGrid.rows[0].cloneNode(true));
						tbl.appendChild(tblb);
						oDataGridHeader = document.all["HeaderGrilla"];
						oDataGridHeader.appendChild(tbl);
						
						for (var f=1;f<=oDataGrid.rows.length-1;f++)
						{
							for(var c=0;c<=tbl.rows[0].cells.length-1;c++)
							{
								oDataGrid.rows[f].cells(c).style.width = oDataGrid.rows[f].cells(c).offsetWidth +"px";
							}
						}
						oDataGrid.rows[0].style.display = "none";
					}
					
					AutoResize();
				}
				function AutoResize()
				{
					var oDiv = document.all["divScroll"];
					oDiv.style.height = (document.body.scrollHeight -70) + "px";
				}
		</script>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerCabeceraDataGrid();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table3" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD class="commands"><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Inicio> Gestión Financiera> Prespuesto>Detalle de Naturaleza de Gastos por Fecha.</asp:label></TD>
				</TR>
				<TR>
					<TD align="left"></TD>
				</TR>
				<TR>
					<TD id="HeaderGrilla" align="left"></TD>
				</TR>
				<TR>
					<TD align="left">
						<div id="divScroll" style="BORDER-TOP-WIDTH: 1px; BORDER-LEFT-WIDTH: 1px; BORDER-LEFT-COLOR: #0033ff; OVERFLOW-X: hidden; BORDER-BOTTOM-WIDTH: 1px; BORDER-BOTTOM-COLOR: #0033ff; OVERFLOW: auto; WIDTH: 776px; BORDER-TOP-COLOR: #0033ff; HEIGHT: 200px; BORDER-RIGHT-WIDTH: 1px; BORDER-RIGHT-COLOR: #0033ff"><cc1:datagridweb id="grid" runat="server" Width="752px" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
								AllowSorting="True" PageSize="20">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="NroArea" HeaderText="COD AREA">
<HeaderStyle Width="2%" VerticalAlign="Middle">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NroMaterial" HeaderText="NRO MATERIAL">
<HeaderStyle Width="8%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Descripcion" HeaderText="DESCRIPCION">
<HeaderStyle Width="35%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="CantidadMaterial" HeaderText="CANT.">
<HeaderStyle Width="2%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Monto" HeaderText="MONTO">
<HeaderStyle Width="5%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="TipoDocumento" HeaderText="TIPO DOC.">
<HeaderStyle Width="3%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="NroValeSalida" HeaderText="NRO DOC">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="FechaEmision" HeaderText="F. EMISION">
<HeaderStyle Width="10%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn HeaderText="CB">
<HeaderStyle Width="2%">
</HeaderStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
							</cc1:datagridweb></div>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
