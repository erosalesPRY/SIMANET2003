<%@ Page language="c#" Codebehind="BuscarGrupodeCentrodeCosto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.BuscarGrupodeCentrodeCosto" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Buscar Grupo de Centro de Costo</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/@Import.js"></SCRIPT>
		<SCRIPT language="javascript">(new Script.Import()).Registrar();</SCRIPT>
		<style type="text/css">DIV.scroll { BORDER-RIGHT: #666 1px solid; BORDER-TOP: #666 1px solid; OVERFLOW: auto; BORDER-LEFT: #666 1px solid; WIDTH: 300px; BORDER-BOTTOM: #666 1px solid; HEIGHT: 100px }
		</style>
		<script>
			function ConsultarGruposdeCentrosdeCostos(){
				if (event.keyCode == SIMA.Utilitario.Constantes.General.KeyCode.KeyReturn){
					CargarDatos();
				}
			}
			function CargarDatos(){
					var objddl = document.all["ddlCentroOperativo"];
					var objTxt = document.all["txtBuscar"];
					var oDataTable = new System.Data.DataTable("tblGrupoCC");
					oDataTable = (new Controladora.Presupuesto.CRequerimientos()).CosultarGrupodeCentrodeCostoPorCentro(objddl.options[objddl.selectedIndex].value,objTxt.value);
					//Crea el obj Datagrid
					try{
						oDataGrid = new DataGrid(document.all["grid"]);
						oDataGrid.DataSource = oDataTable;
						oDataGrid.EventHandleItemDataBound =ItemDataBound;
						oDataGrid.DataBind();
					}
					catch(error){
						window.alert(error.description);
						window.alert("No existen Datos de Grupo de Centros de Costos");
					}
			}
			
			function ItemDataBound(sender,e){
				dr = e.Item.DataItem;
				e.Item.cells(0).innerText=e.Item.rowIndex;
				e.Item.cells(1).align = "left";
				e.Item.cells(1).innerText=dr.Item("NROGRUPOCC") + " " + dr.Item("NOMBRE");
				e.Item.cells(1).setAttribute("IDGRUPOCC",dr.Item("IDGRUPOCC"));
				SIMA.Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,SeleccionarItem);
			}
			
			function SeleccionarItem(e){
				ArrDatosRemotos.Remover();
				ArrDatosRemotos.Adicionar(e.cells(1).getAttribute("IDGRUPOCC"));
				ArrDatosRemotos.Adicionar(e.cells(1).innerText);
			}
			function EntregarDatosWindowRemoto(){
				window.returnValue=ArrDatosRemotos;
				window.close();
			}
			
		</script>
	</HEAD>
	<body onload="CargarDatos();" oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" scroll="no">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" height="100%" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR bgcolor="#f5f5f5">
					<TD>
						<asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita" Width="288px">RELACION DE GRUPOS DE CENTROS DE COSTO</asp:label></TD>
				</TR>
				<TR bgcolor="#f5f5f5">
					<TD>
						<TABLE id="Table2" cellSpacing="1" cellPadding="1" width="100%" align="left" border="0">
							<TR>
								<TD style="WIDTH: 112px"><asp:label id="Label1" runat="server" CssClass="TextoNegroNegrita" Width="128px">CENTRO OPERATIVO:</asp:label></TD>
								<TD style="WIDTH: 141px"><asp:dropdownlist id="ddlCentroOperativo" runat="server" Width="146px"></asp:dropdownlist></TD>
								<TD style="WIDTH: 39px"><asp:label id="Label2" runat="server" CssClass="TextoNegroNegrita">BUSCAR:</asp:label></TD>
								<TD><asp:textbox id="txtBuscar" runat="server" Width="232px"></asp:textbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD height="100%" width="100%">
						<DIV style="WIDTH: 100%; HEIGHT: 98.13%" ms_positioning="FlowLayout" class="scroll">
							<cc1:datagridweb id="grid" runat="server" Width="100%" PageSize="17" AutoGenerateColumns="False"
								RowHighlightColor="#E0E0E0">
								<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
								<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
								<FooterStyle CssClass="FooterGrilla"></FooterStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<Columns>
									<asp:BoundColumn HeaderText="N&#186;">
										<HeaderStyle Width="2%"></HeaderStyle>
									</asp:BoundColumn>
									<asp:BoundColumn DataField="Nombre" HeaderText="GRUPO DE CENTROS DE COSTO">
										<HeaderStyle Width="80%" VerticalAlign="Middle"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
									</asp:BoundColumn>
								</Columns>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							</cc1:datagridweb></DIV>
					</TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 186px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="186"
							align="right" border="0">
							<TR>
								<TD><IMG id="imgAceptar" onclick="EntregarDatosWindowRemoto();" alt="" src="/SimanetWeb/imagenes/bt_aceptar.gif"></TD>
								<TD><SPAN class="normal">
										<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="/SimanetWeb/imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR>
					<TD align="center"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
