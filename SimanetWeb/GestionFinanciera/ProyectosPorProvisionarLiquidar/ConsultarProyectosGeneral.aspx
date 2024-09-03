<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Page language="c#" Codebehind="ConsultarProyectosGeneral.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.ProyectosPorProvisionarLiquidar.ConsultarProyectosGeneral" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>ConsultarProyectosGeneral</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/JSFrameworkSima.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR id="id1">
					<TD colSpan="2"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR id="id2">
					<TD colSpan="2"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR id="id3">
					<TD class="commands" colSpan="2"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestión Financiera ></asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Proyectos Liquidados</asp:label></TD>
				</TR>
				<TR id="id4">
					<TD align="right" bgColor="#f0f0f0" colSpan="2"><IMG id="ImgImprimir" style="CURSOR: hand" onclick="oPrint = new SIMA.Utilitario.Helper.Dialogos();oPrint.VistaPrevia(this,id1,id2,id3,id4,id5);"
							alt="" src="../../imagenes/bt_imprimir.gif"></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="2"><cc1:datagridweb id="grid" runat="server" CssClass="HeaderGrilla" PageSize="7" AllowSorting="True"
							AutoGenerateColumns="False" RowHighlightColor="#E0E0E0" ShowFooter="True" Width="100%">
<AlternatingItemStyle CssClass="Alternateitemgrilla">
</AlternatingItemStyle>

<ItemStyle CssClass="ItemGrilla">
</ItemStyle>

<HeaderStyle CssClass="HeaderGrilla">
</HeaderStyle>

<FooterStyle Font-Names="Nina" Font-Bold="True" HorizontalAlign="Right" ForeColor="Black" CssClass="FooterGrilla">
</FooterStyle>

<Columns>
<asp:BoundColumn DataField="Situacion" HeaderText="CONCEPTO" FooterText="TOTAL:">
<HeaderStyle Width="22%">
</HeaderStyle>

<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SimaCallao" HeaderText="CALLAO" FooterText="0" DataFormatString="{0:# ### ### ##0.00} ">
<HeaderStyle Font-Underline="True" Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right" VerticalAlign="Middle">
</ItemStyle>

<FooterStyle HorizontalAlign="Right" VerticalAlign="Middle">
</FooterStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SimaChimbote" HeaderText="CHIMBOTE" FooterText="0" DataFormatString="{0:# ### ### ##0.00} ">
<HeaderStyle Font-Underline="True" Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SimaPeru" HeaderText="PERU" FooterText="0" DataFormatString="{0:# ### ### ##0.00} ">
<HeaderStyle Font-Underline="True" Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="SimaIquitos" HeaderText="IQUITOS" FooterText="0" DataFormatString="{0:# ### ### ##0.00} ">
<HeaderStyle Font-Underline="True" Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="Total" HeaderText="TOTAL" FooterText="0" DataFormatString="{0:# ### ### ##0.00} ">
<HeaderStyle Width="15%">
</HeaderStyle>

<ItemStyle HorizontalAlign="Right">
</ItemStyle>
</asp:BoundColumn>
</Columns>

<PagerStyle CssClass="PagerGrilla" Mode="NumericPages">
</PagerStyle>
						</cc1:datagridweb><asp:label id="lblResultado" runat="server" CssClass="ResultadoBusqueda"></asp:label></TD>
				</TR>
				<TR id="id5">
					<TD colSpan="2"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
