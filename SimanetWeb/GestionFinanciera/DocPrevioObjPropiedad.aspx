<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DocPrevioObjPropiedad.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.DocPrevioObjPropiedad" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>DocPrevioObjPropiedad</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<script type="text/javascript"> 
		function CrearControl(Comilla,Control)
		{ 
			//var Control1="<DIV id=NOMBRE style='BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; FONT-WEIGHT: bold; FONT-SIZE: 12pt; LEFT: 150px; TEXT-TRANSFORM: capitalize; BORDER-LEFT: #999999 1px solid; WIDTH: 232px; COLOR: slategray; BORDER-BOTTOM: #999999 1px solid; FONT-STYLE: normal; FONT-FAMILY: Arial; POSITION: absolute; TOP: 150px; HEIGHT: 32px; BACKGROUND-COLOR: #ccffff; TEXT-ALIGN: center' onmousedown='dragstart(this);'>EDDY ROSALES</DIV>";
			//window.alert(Control.replace("\",""));
			window.alert(Control);
			//opener.document.Form1.innerHTML+= Control;
			window.close();
			return null;
		} 
		function Confirmar()
		{
			confirmar=confirm("¿Desea Crear Esta Etiqueta Ahora..?"); 
			if (confirmar) 
			{
				document.getElementById("hValorConfirma").setAttribute("value","SI");
			}
			else
			{
				document.getElementById("hValorConfirma").setAttribute("value","NO");		
			}
		
		}
		</script>
</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" style="WIDTH: 364px; HEIGHT: 367px" cellSpacing="1" cellPadding="1"
				width="364" border="0">
				<TR class="itemgrilla">
					<TD style="HEIGHT: 27px" width="400" colSpan="5">
						<P align="center">
							<asp:label id="Label8" runat="server" Font-Bold="True" Font-Size="Small" CssClass="TextoAzul">DIALOGO DE PROPIEDADES</asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px; HEIGHT: 27px">
						<asp:label id="Label1" runat="server" CssClass="TextoAzul" DESIGNTIMEDRAGDROP="50">Nombre</asp:label></TD>
					<TD style="WIDTH: 385px; HEIGHT: 27px" colSpan="3"><asp:textbox id="txtNombre" runat="server" DESIGNTIMEDRAGDROP="112" Width="135px"></asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px; HEIGHT: 33px"><asp:label id="Label2" runat="server" CssClass="TextoAzul" DESIGNTIMEDRAGDROP="51">Color de Fondo</asp:label></TD>
					<TD style="WIDTH: 385px; HEIGHT: 33px" colSpan="3"><asp:textbox id="txtColorFondo" runat="server" Width="135px">#ffffff</asp:textbox></TD>
				</TR>
				<TR class="itemgrilla">
					<TD style="WIDTH: 104px"><asp:label id="Label3" runat="server" Font-Bold="True" Font-Size="Small" CssClass="TextoAzul"
							DESIGNTIMEDRAGDROP="24">Texto</asp:label></TD>
					<TD style="WIDTH: 58px"><asp:label id="Label7" runat="server" CssClass="TextoAzul">Valor</asp:label></TD>
					<TD width="800" colSpan="3">
						<asp:textbox id="txtValor" runat="server" Width="225px">Etiqueta</asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px"></TD>
					<TD style="WIDTH: 58px"><asp:label id="Label6" runat="server" CssClass="TextoAzul">Alineación</asp:label></TD>
					<TD style="WIDTH: 283px" colSpan="2"><asp:dropdownlist id="ddlbAlineacion" runat="server" CssClass="combos" Width="224px">
							<asp:ListItem Value="Left">Left</asp:ListItem>
							<asp:ListItem Value="Centered">Centered</asp:ListItem>
							<asp:ListItem Value="Rigth">Rigth</asp:ListItem>
							<asp:ListItem Value="Justified">Justified</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR class="itemgrilla">
					<TD style="WIDTH: 104px; HEIGHT: 41px"><asp:label id="Label5" runat="server" Font-Bold="True" Font-Size="Small" CssClass="TextoAzul"
							DESIGNTIMEDRAGDROP="67">Posición</asp:label></TD>
					<TD style="WIDTH: 58px; HEIGHT: 41px" colSpan="4">
						<TABLE id="Table2" style="WIDTH: 288px; HEIGHT: 52px" cellSpacing="1" cellPadding="1" width="288"
							border="0">
							<TR>
								<TD>
									<asp:label id="Label9" runat="server" CssClass="TextoAzul">Arriba</asp:label></TD>
								<TD style="WIDTH: 86px">
									<ew:numericbox id="nPosArriba" runat="server" CssClass="normal" Width="56px" MaxLength="12" RealNumber="False"
										PositiveNumber="True">50</ew:numericbox></TD>
								<TD style="WIDTH: 69px">
									<asp:label id="Label12" runat="server" CssClass="TextoAzul">Alto</asp:label></TD>
								<TD>
									<ew:numericbox id="nAlto" runat="server" CssClass="normal" Width="64px" MaxLength="12" RealNumber="False"
										PositiveNumber="True">80</ew:numericbox></TD>
							</TR>
							<TR>
								<TD>
									<asp:label id="Label10" runat="server" CssClass="TextoAzul">Izquierda</asp:label></TD>
								<TD style="WIDTH: 86px">
									<ew:numericbox id="nPosIzquierda" runat="server" CssClass="normal" Width="56px" MaxLength="12"
										RealNumber="False" PositiveNumber="True">50</ew:numericbox></TD>
								<TD style="WIDTH: 69px">
									<asp:label id="Label11" runat="server" CssClass="TextoAzul">Ancho</asp:label></TD>
								<TD>
									<ew:numericbox id="nAncho" runat="server" CssClass="normal" Width="64px" MaxLength="12" RealNumber="False"
										PositiveNumber="True">20</ew:numericbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR class="itemgrilla">
					<TD style="WIDTH: 104px">
						<asp:label id="Label4" runat="server" Font-Bold="True" Font-Size="Small" CssClass="TextoAzul"
							DESIGNTIMEDRAGDROP="66">Bordes</asp:label></TD>
					<TD style="WIDTH: 147px" colSpan="4"></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px">
						<asp:label id="Label16" runat="server" CssClass="TextoAzul">Arriba</asp:label></TD>
					<TD style="WIDTH: 147px" colSpan="4">
						<asp:textbox id="txtBordeArriba" runat="server" Width="281px">#999999 1px solid</asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px"><asp:label id="Label15" runat="server" CssClass="TextoAzul">Abajo</asp:label></TD>
					<TD style="WIDTH: 147px" colSpan="4">
						<asp:textbox id="txtBordeAbajo" runat="server" Width="280px">#999999 1px solid</asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px"><asp:label id="Label14" runat="server" CssClass="TextoAzul">Izquierda</asp:label></TD>
					<TD style="WIDTH: 147px" colSpan="4">
						<asp:textbox id="txtBordeIzquierda" runat="server" Width="280px">#999999 1px solid</asp:textbox></TD>
				</TR>
				<TR>
					<TD style="WIDTH: 104px; HEIGHT: 20px"><asp:label id="Label13" runat="server" CssClass="TextoAzul">Derecha</asp:label></TD>
					<TD style="WIDTH: 147px; HEIGHT: 20px" colSpan="4">
						<asp:textbox id="txtBordeDerecha" runat="server" Width="280px">#999999 1px solid</asp:textbox></TD>
				</TR>
				<TR class="itemgrilla">
					<TD style="WIDTH: 104px"><asp:label id="Label17" runat="server" Font-Bold="True" Font-Size="Small" CssClass="TextoAzul">Fuente</asp:label></TD>
					<TD style="WIDTH: 385px" colSpan="3"><asp:dropdownlist id="ddlbFuente" runat="server" Width="280px">
							<asp:ListItem Value="Arial">Arial</asp:ListItem>
							<asp:ListItem Value="Arial Black">Arial Black</asp:ListItem>
							<asp:ListItem Value="Bookman Old Style">Bookman Old Style</asp:ListItem>
							<asp:ListItem Value="Courier New">Courier New</asp:ListItem>
							<asp:ListItem Value="Times New Roman">Times New Roman</asp:ListItem>
							<asp:ListItem Value="Verdana">Verdana</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<TR>
					<TD width="400" colSpan="5">
						<TABLE id="Table5" style="WIDTH: 318px; HEIGHT: 53px" cellSpacing="1" cellPadding="1" width="318"
							align="left" border="0">
							<TR>
								<TD style="WIDTH: 68px; HEIGHT: 26px">
									<asp:label id="Label21" runat="server" CssClass="TextoAzul" DESIGNTIMEDRAGDROP="106">Tamaño</asp:label></TD>
								<TD style="WIDTH: 25px; HEIGHT: 26px">
									<asp:textbox id="txtFontTamaño" runat="server" DESIGNTIMEDRAGDROP="114" Width="32px">12</asp:textbox></TD>
								<TD style="HEIGHT: 26px">
									<asp:label id="Label20" runat="server" CssClass="TextoAzul">Tipo</asp:label></TD>
								<TD style="WIDTH: 41px; HEIGHT: 26px">
									<asp:textbox id="txtFontTipo" runat="server" Width="64px">Normal</asp:textbox></TD>
								<TD style="HEIGHT: 26px">
									<asp:label id="Label19" runat="server" CssClass="TextoAzul">Color</asp:label></TD>
								<TD style="WIDTH: 67px; HEIGHT: 26px" colSpan="3">
									<asp:textbox id="txtFontColor" runat="server" Width="94px">Black</asp:textbox></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 95px" colSpan="2">
									<asp:label id="Label18" runat="server" CssClass="TextoAzul">Capitalización</asp:label></TD>
								<TD style="WIDTH: 227px" colSpan="5">
									<asp:dropdownlist id="ddlbCapitalizacion" runat="server" Width="177px">
										<asp:ListItem Value="None">None</asp:ListItem>
										<asp:ListItem Value="Init Cap">Init Cap</asp:ListItem>
										<asp:ListItem Value="lowercase">lowercase</asp:ListItem>
										<asp:ListItem Value="UPPERCASE">UPPERCASE</asp:ListItem>
									</asp:dropdownlist></TD>
								<TD style="WIDTH: 68px">
									<asp:checkbox id="chkFontNegrita" runat="server" CssClass="TextoAzul" Text="Negrita"></asp:checkbox></TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<TR class="itemgrilla">
					<TD style="WIDTH: 104px"><INPUT id="hValorConfirma" style="WIDTH: 18px; HEIGHT: 22px" type="hidden" size="1" name="hIdEntidad"
							runat="server"></TD>
					<TD style="WIDTH: 58px"></TD>
					<TD style="WIDTH: 5px" align=right>
						<asp:imagebutton id="ibtnAcepta" runat="server" ImageUrl="../imagenes/bt_aceptar.gif" Height="27px"></asp:imagebutton></TD>
					<TD style="WIDTH: 19px" align =right >
						<asp:image id="imgCancelar" Runat="server" CssClass="cursor" ImageUrl="../imagenes/bt_cancelar.gif"></asp:image></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
