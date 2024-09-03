<%@ Page language="c#" Codebehind="AgregarRequerimientoNaturalezadeGasto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.AgregarRequerimientoNaturalezadeGasto" %>
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
		<style type="text/css">DIV.scroll { BORDER-RIGHT: #666 1px solid; BORDER-TOP: #666 1px solid; OVERFLOW: auto; BORDER-LEFT: #666 1px solid; WIDTH: 300px; BORDER-BOTTOM: #666 1px solid; HEIGHT: 100px }
		</style>
		<script>
			var KEYIDREQUERIMIENTO="idrqr";
			function EntregarDatosWindowRemoto(){
				var ogrid = document.all["grid"];
				
				for(var i=1;i<=ogrid.rows.length-1;i++){
					ArrDatosRemotos[i-1]= ogrid.rows[i].getAttribute("idCuentaContableGrupo") + ";" + ogrid.rows[i].getAttribute("chkValue");
				}
				window.returnValue=ArrDatosRemotos;
				window.close();
			}
			
			Aceptar=function(e){
				var oFila = e.parentElement.parentElement.parentElement;
				oFila.setAttribute("chkValue",((e.checked==true)?1:0));
			}
		</script>
	</HEAD>
	<body oncontextmenu="return false" onkeydown="if (event.keyCode==13 || event.keyCode==9)return false"
		bottomMargin="0" leftMargin="0" topMargin="0" scroll="no" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR bgColor="#f5f5f5">
					<TD><asp:label id="Label3" runat="server" CssClass="TextoNegroNegrita" Width="288px"> SELECCIONAR NATURALEZA DE GASTO:</asp:label></TD>
				</TR>
				<TR>
					<TD><cc1:datagridweb id="grid" runat="server" Width="100%" RowHighlightColor="#E0E0E0" AutoGenerateColumns="False"
							AllowSorting="True" PageSize="7">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:TemplateColumn>
									<HeaderStyle Width="5%"></HeaderStyle>
									<ItemTemplate>
										<asp:CheckBox id="chkNaturaleza" runat="server" Text=" " BorderStyle="None"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="NombreCuenta" HeaderText="NATURALEZA DE GASTO">
									<HeaderStyle Width="90%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD align="center">
						<TABLE id="Table3" style="WIDTH: 186px; HEIGHT: 30px" cellSpacing="1" cellPadding="1" width="186"
							align="right" border="0">
							<TR>
								<TD><IMG id="imgAceptar" onclick="EntregarDatosWindowRemoto();" alt="" src="/SimanetWeb/imagenes/bt_aceptar.gif"></TD>
								<TD><SPAN class="normal"><asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="/SimanetWeb/imagenes/bt_cancelar.gif"></asp:image></SPAN></TD>
							</TR>
						</TABLE>
						<INPUT id="hidMes" type="hidden" size="1"><INPUT id="hidCentroOperativo" type="hidden" size="1"></TD>
				</TR>
				<TR>
					<TD align="center"><asp:checkbox id="CheckBox1" runat="server"></asp:checkbox><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
