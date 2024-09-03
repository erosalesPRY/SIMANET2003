<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Page language="c#" Codebehind="AdministarFormatoRubroDetalleMovimiento.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros.AdministarFormatoRubroDetalleMovimiento" %>
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=1.0)">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/FrameCallBack.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<script>
			function ObtenerCambios()
			{
				var strTrama="";
				var grilla = document.all["grid"];
				for(var i=1;i<=grilla.rows.length-1;i++)
				{
					strTrama = "Modo" + "=" + grilla.rows[i].cells(0).getAttribute("Modo") 
								+ "&Centro" + "=" + grilla.rows[i].cells(0).getAttribute("Centro")
								+ "&Formato" + "=" + grilla.rows[i].cells(0).getAttribute("Formato")
								+ "&idRubro" + "=" + grilla.rows[i].cells(0).getAttribute("idRubro")
								+ "&IdRubroDetalle" + "=" + grilla.rows[i].cells(0).getAttribute("IdRubroDetalle")
								+ "&idRubroMovimiento" + "=" + grilla.rows[i].cells(0).getAttribute("idRubroMovimiento")
								+ "&Periodo" + "=" + grilla.rows[i].cells(0).getAttribute("Periodo")
								+ "&idMes" + "=" + grilla.rows[i].cells(0).getAttribute("idMes")
								+ "&TipoInfo" + "=" + grilla.rows[i].cells(0).getAttribute("TipoInfo") 
								+ "&Monto" + "=" + grilla.rows[i].cells(1).innerText;
								
					miVentana=window.showModalDialog("GrabarFormatoRubroDetalleMovimiento.aspx?" + strTrama ,window,"dialogHeight: 5px; dialogWidth: 5px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
				}
				//miVentana=window.showModalDialog("GrabarFormatoRubroDetalleMovimiento.aspx?TRAMA=" + strTrama ,window,"dialogHeight: 5px; dialogWidth: 5px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
				window.window.close();
			}
			
			var RemoteCelda=null;
			function AbrirEditordeCelda(objDelda)
			{
				//window.clipboardData.setData("Text",objDelda.innerText);
				localStorage.setItem('History',objDelda.innerText);
				
				RemoteCelda = objDelda;
				miVentana=window.showModalDialog("EditarFormatoRubroDetalleMovimiento.aspx",window,"dialogHeight: 105px; dialogWidth: 167px;edge: Raised; center: Yes; help: no; resizable: no; status: no;");
			}
			function AsignarValor(valor)
			{
				RemoteCelda.innerText = valor;
			}
	
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD class="RutaPaginaActual" style="HEIGHT: 22px" vAlign="top" width="100%"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Administrar Detalle de Concepto</asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
						<TABLE style="WIDTH: 492px; HEIGHT: 22px" cellSpacing="0" cellPadding="0" width="492" border="0">
							<TR bgColor="#f0f0f0">
								<TD><IMG height="22" src="../../imagenes/tab_izq.gif" width="4"></TD>
								<TD></TD>
								<TD style="WIDTH: 138px"></TD>
								<TD style="WIDTH: 575px"><IMG style="WIDTH: 382px; HEIGHT: 8px" height="8" src="../imagenes/spacer.gif" width="382"></TD>
								<TD style="WIDTH: 186px"><IMG alt="" src="../../imagenes/bt_agregar.gif" id="ibtnAgregar" onclick="ObtenerCambios();"></TD>
								<TD></TD>
								<TD></TD>
								<TD align="right" width="4"><IMG height="22" src="../../imagenes/tab_der.gif" width="4"></TD>
							</TR>
						</TABLE>
						<cc1:datagridweb id="grid" runat="server" Width="495px" AllowSorting="True" AutoGenerateColumns="False"
							RowHighlightColor="#E0E0E0" PageSize="7">
							<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
							<ItemStyle CssClass="ItemGrilla"></ItemStyle>
							<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
							<FooterStyle CssClass="FooterGrilla"></FooterStyle>
							<Columns>
								<asp:BoundColumn DataField="Descripcion" SortExpression="Descripcion" HeaderText="DESCRIPCION">
									<HeaderStyle HorizontalAlign="Center" Width="80%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
								<asp:BoundColumn DataField="Monto" SortExpression="Monto" HeaderText="IMPORTE">
									<HeaderStyle HorizontalAlign="Center" Width="30%" VerticalAlign="Middle"></HeaderStyle>
									<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle"></ItemStyle>
								</asp:BoundColumn>
							</Columns>
							<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
						</cc1:datagridweb></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%"><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="100%">
					</TD>
				</TR>
				<tr>
					<td>
					</td>
				</tr>
			</table>
			&nbsp;
		</form>
		<SCRIPT>
			SIMA.Utilitario.Error.TiempoEsperadePagina();
		</SCRIPT>
	</body>
</HTML>
