<%@ Page language="c#" Codebehind="PopupDetalleRepresentanteoContacto.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Cliente.PopupDetalleRepresentanteoContacto" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>PopupDetalleRepresentanteoContacto</title>
<meta content=http://schemas.microsoft.com/intellisense/ie5 name=vs_targetSchema><LINK href="../../styles.css" type=text/css rel=stylesheet >
<SCRIPT language=javascript src="../../js/jscript.js"></SCRIPT>

<SCRIPT language=javascript src="../../js/General.js"></SCRIPT>

<SCRIPT language=javascript src="../../js/Historial.js"></SCRIPT>
</HEAD>
<body bottomMargin=0 leftMargin=0 topMargin=0 onload=ObtenerHistorial(); 
rightMargin=0 onunload=SubirHistorial();>
<form id=Form1 method=post runat="server">
<TABLE id=Table3 cellSpacing=0 cellPadding=0 width="100%" align=center border=0>
  <TR>
    <TD vAlign=top colSpan=3><uc1:header id=Header1 runat="server"></uc1:header></TD></TR>
  <TR>
    <TD vAlign=top colSpan=3><uc1:menu id=Menu1 runat="server"></uc1:menu></TD></TR>
  <TR>
    <TD class=Commands style="HEIGHT: 10px" vAlign=top colSpan=3 
    ><asp:label id=lblRutaPagina runat="server" CssClass="RutaPagina">Inicio > Gestión Comercial > Clientes > </asp:label><asp:label id=lblPagina runat="server" CssClass="RutaPaginaActual"> Consulta de</asp:label></TD></TR>
  <TR>
    <TD class=TituloPrincipal vAlign=top align=center colSpan=3 
    ><asp:label id=lblTituloPrincipal runat="server" CssClass="TituloPrincipal"></asp:label></TD></TR>
  <TR>
    <TD vAlign=top align=center>
      <TABLE id=Table2 borderColor=#ffffff cellSpacing=0 cellPadding=0 width=400 
      border=1>
        <TR>
          <TD class=TituloPrincipalBlanco bgColor=#000080 colSpan=2 
          ><asp:label id=lblDatos runat="server"></asp:label></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblNombre runat="server" CssClass="TextoBlanco">Nombre:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#dddddd><asp:textbox id=txtNombre runat="server" CssClass="normaldetalle" Height="24px" Width="300px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px; HEIGHT: 18px" bgColor=#335eb4 
          ><asp:label id=lblApellidoPaterno runat="server" CssClass="TextoBlanco" Width="112px">Apellido Paterno :</asp:label></TD>
          <TD style="WIDTH: 647px; HEIGHT: 18px" bgColor=#f0f0f0 
          ><asp:textbox id=txtApellidoPaterno runat="server" CssClass="normaldetalle" Height="24px" Width="300px"></asp:textbox></TD>
          <TD style="HEIGHT: 18px"></TD>
          <TD style="HEIGHT: 18px"></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblApellidoMaterno runat="server" CssClass="TextoBlanco" Width="112px">Apellido Materno :</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#dddddd><asp:textbox id=txtApellidoMaterno runat="server" CssClass="normaldetalle" Height="24px" Width="300px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblDNI runat="server" CssClass="TextoBlanco">DNI:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#dddddd><asp:textbox id=txtDni runat="server" CssClass="normaldetalle" Height="24px" Width="120px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblTelefono1 runat="server" CssClass="TextoBlanco"> Telefono:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#f0f0f0><asp:textbox id=txtTelefono runat="server" CssClass="normaldetalle" Height="24px" Width="120px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblCelular runat="server" CssClass="TextoBlanco">Celular:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#dddddd><asp:textbox id=txtCelular runat="server" CssClass="normaldetalle" Height="24px" Width="120px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblFax runat="server" CssClass="TextoBlanco">Fax:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#f0f0f0><asp:textbox id=txtFax runat="server" CssClass="normaldetalle" Height="24px" Width="120px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblCorreo runat="server" CssClass="TextoBlanco">Correo:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#f0f0f0><asp:textbox id=txtCorreo runat="server" CssClass="normaldetalle" Height="24px" Width="300px" ReadOnly="True"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px; HEIGHT: 27px" bgColor=#335eb4 
          ><asp:label id=lblOnomastico runat="server" CssClass="TextoBlanco">Onomastico:</asp:label></TD>
          <TD style="WIDTH: 647px; HEIGHT: 27px" bgColor=#dddddd 
          ><ew:calendarpopup id=CalOnomastico runat="server" CssClass="normaldetalle" Width="120px" ImageUrl="../../imagenes/BtPU_Mas.gif" Nullable="True" NullableLabelText="Seleccione una fecha:" MonthYearPopupCancelText="Cancelar" MonthYearPopupApplyText="Aceptar" GoToTodayText="Hoy :" PadSingleDigits="True" Culture="Spanish (Chile)" ControlDisplay="TextBoxImage" ShowGoToToday="True" AllowArbitraryText="False" ClearDateText="Limpiar Fecha">
										<TextboxLabelStyle CssClass="NormalDetalle"></TextboxLabelStyle>
										<WeekdayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></WeekdayStyle>
										<MonthHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="Navy"></MonthHeaderStyle>
										<OffMonthStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="White"></OffMonthStyle>
										<GoToTodayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Navy"
											BackColor="#F0F0F0"></GoToTodayStyle>
										<TodayDayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="#335EB4" BackColor="LightSteelBlue"></TodayDayStyle>
										<DayHeaderStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="#335EB4"></DayHeaderStyle>
										<WeekendStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Bold="True"
											ForeColor="IndianRed" BackColor="White"></WeekendStyle>
										<SelectedDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="White"
											BackColor="CornflowerBlue"></SelectedDateStyle>
										<ClearDateStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></ClearDateStyle>
										<HolidayStyle Font-Size="XX-Small" Font-Names="Verdana,Helvetica,Tahoma,Arial" ForeColor="Black"
											BackColor="White"></HolidayStyle>
									</ew:calendarpopup><asp:textbox id=txtOnomastico runat="server" CssClass="normaldetalle" Height="24px" Width="120px" ReadOnly="True" BackColor="Transparent"></asp:textbox></TD>
          <TD style="HEIGHT: 27px"></TD>
          <TD style="HEIGHT: 27px"></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblCargo runat="server" CssClass="TextoBlanco">Cargo:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#f0f0f0><asp:textbox id=txtCargo runat="server" CssClass="normaldetalle" Height="24px" Width="300px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD style="WIDTH: 82px" bgColor=#335eb4><asp:label id=lblTituloProfesional runat="server" CssClass="TextoBlanco" Width="112px">Titulo Profesional:</asp:label></TD>
          <TD style="WIDTH: 647px" bgColor=#dddddd><asp:textbox id=txtTituloProfesional runat="server" CssClass="normaldetalle" Height="24px" Width="300px"></asp:textbox></TD>
          <TD></TD>
          <TD></TD></TR>
        <TR>
          <TD class=normal id=TdCeldaCancelar vAlign=top colSpan=5 
           runat="server"><IMG id=ibtnAtras style="CURSOR: hand" onclick=HistorialIrAtras(); alt="" src="../../imagenes/atras.gif" > </TD>
          <TD class=normal></TD>
          <TD style="WIDTH: 647px"></TD>
          <TD></TD>
          <TD></TD></TR></TABLE>
      <TABLE id=Table8 width=425 align=center border=0>
        <TR>
          <TD align=center>&nbsp;&nbsp;&nbsp; <asp:imagebutton id=ibtnAceptar runat="server" Height="22px" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"></asp:imagebutton><IMG 
            id=ibtnCancelar onclick=HistorialIrAtras(); alt="" 
            src="../../imagenes/bt_cancelar.gif" 
      runat="server"></TD></TR></TABLE>
      <TABLE class=normal id=Table1 cellSpacing=0 cellPadding=0 width=350 
      align=center border=0>
        <TR>
          <TD vAlign=top align=center colSpan=3><asp:label id=lblResultado runat="server" CssClass="ResultadoBusqueda" DESIGNTIMEDRAGDROP="56"></asp:label></TD></TR></TABLE></TD></TR>
  <tr>
    <td vAlign=top></TD></TR></TABLE>
<SCRIPT>
				<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
			</SCRIPT>
</FORM>
	</body>
</HTML>
