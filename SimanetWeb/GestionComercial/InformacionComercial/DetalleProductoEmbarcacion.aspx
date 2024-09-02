<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Page language="c#" Codebehind="DetalleProductoEmbarcacion.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.InformacionComercial.DetalleProductoEmbarcacion" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
  <HEAD>
		<title>SIMANET</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../js/jscript.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/General.js"></SCRIPT>
		<SCRIPT language="javascript" src="../../js/Historial.js"></SCRIPT>
</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" onload="ObtenerHistorial();" rightMargin="0"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></td>
				</tr>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<table cellSpacing="0" cellPadding="0" width="780" align="center" border="0" borderColor=#ffffff>
							<TR>
								<TD class="Commands" style="HEIGHT: 11px" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Informacion Comercial > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Registro de Embarcaciones</asp:label></TD>
							</TR>
        <TR>
          <TD align=center colSpan=3>
<asp:label id=lblMensaje runat="server" CssClass="normal"></asp:label></TD></TR>
        <TR>
          <TD align=center colSpan=3>
            <TABLE class=normal id=Table3 cellSpacing=0 cellPadding=0 width=780 
            align=center border=1 borderColor=#ffffff>
              <TR>
                <TD class=normal bgColor=#000080 colSpan=2>
<asp:label id=lblTitulo runat="server" CssClass="TituloPrincipalBlanco"></asp:label>
<asp:label id=lblDatos runat="server" CssClass="TituloPrincipalBlanco"></asp:label></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px" bgColor=#335eb4 colSpan=1>
<asp:label id=lblDescripcion runat="server" CssClass="TextoBlanco">Descripcion :</asp:label></TD>
                <TD class=normal bgColor=#dddddd colSpan=1>
<asp:textbox id=txtDescripcion runat="server" CssClass="normaldetalle" MaxLength="2000" Width="400px"></asp:textbox></TD>
                <TD class=normal align=left colSpan=1>
<cc1:requireddomvalidator id=rfvDescripcion runat="server" InitialValue="%" ControlToValidate="txtDescripcion">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px" vAlign=top 
bgColor=#335eb4>
<asp:label id=lblTipoEmbarcacion runat="server" CssClass="TextoBlanco">Tipo Embarcacion:</asp:label></TD>
                <TD class=normal bgColor=#f0f0f0>
<asp:dropdownlist id=ddlbTipoEmbarcacion runat="server" CssClass="normaldetalle" Width="400px"></asp:dropdownlist></TD>
                <TD class=normal>
<cc1:requireddomvalidator id=rfvTipoEmbarcacion runat="server" InitialValue="%" ControlToValidate="ddlbTipoEmbarcacion">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px; HEIGHT: 26px" vAlign=top 
                bgColor=#335eb4>
<asp:label id=lblUnidaddeMedida runat="server" CssClass="TextoBlanco" >Unidad de Medida:</asp:label></TD>
                <TD class=normal>
<asp:dropdownlist id=ddlbUnidadMedida runat="server" CssClass="normaldetalle" Width="159px" ></asp:dropdownlist></TD>
                <TD class=normal style="HEIGHT: 26px">
<cc1:requireddomvalidator id=rfvUnidadMedida runat="server" InitialValue="%" ControlToValidate="ddlbTipoEmbarcacion" Visible="False">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px; HEIGHT: 22px" vAlign=top 
                bgColor=#335eb4>
<asp:label id=lblCoeficiente runat="server" CssClass="TextoBlanco">Coeficiente:</asp:label></TD>
                <TD class=normal bgColor=#f0f0f0>
<asp:textbox id=txtCoeficiente runat="server" CssClass="normaldetalle" MaxLength="20" Width="70px"></asp:textbox></TD>
                <TD class=normal style="HEIGHT: 22px">
<cc1:requireddomvalidator id=rfvCoeficiente runat="server" ControlToValidate="txtCoeficiente">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px" vAlign=top 
bgColor=#335eb4>
<asp:label id=lblPesoEslora runat="server" CssClass="TextoBlanco"> Eslora:</asp:label></TD>
                <TD class=normal bgColor=#dddddd>
<asp:textbox id=txtPesoEslora runat="server" CssClass="normaldetalle" MaxLength="20" Width="70px"></asp:textbox>&nbsp; 
<asp:label id=Label1 runat="server" CssClass="TextoAzul" Font-Bold="True"> Pies</asp:label></TD>
                <TD class=normal>
<cc1:requireddomvalidator id=rfvPesoEslora runat="server" ControlToValidate="txtPesoEslora">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px" vAlign=top 
bgColor=#335eb4>
<asp:label id=lblPesoPuntal runat="server" CssClass="TextoBlanco"> Puntal:</asp:label></TD>
                <TD class=normal bgColor=#f0f0f0>
<asp:textbox id=txtPesoPuntal runat="server" CssClass="normaldetalle" MaxLength="20" Width="70px"></asp:textbox>&nbsp; 
<asp:label id=Label2 runat="server" CssClass="TextoAzul" Font-Bold="True"> Pies</asp:label></TD>
                <TD class=normal>
<cc1:requireddomvalidator id=rfvPesoPuntal runat="server" ControlToValidate="txtPesoPuntal">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 128px" vAlign=top 
bgColor=#335eb4>
<asp:label id=lblPesoManga runat="server" CssClass="TextoBlanco"> Manga:</asp:label></TD>
                <TD class=normal bgColor=#dddddd>
<asp:textbox id=txtPesoManga runat="server" CssClass="normaldetalle" MaxLength="20" Width="70px"></asp:textbox>&nbsp; 
<asp:label id=Label3 runat="server" CssClass="TextoAzul" Font-Bold="True"> Pies</asp:label></TD>
                <TD class=normal>
<cc1:requireddomvalidator id=rfvPesoManga runat="server" ControlToValidate="txtPesoManga">*</cc1:requireddomvalidator></TD></TR>
              <TR>
                <TD class=normal vAlign=middle align=right colSpan=2>
                  <TABLE borderColor=#ffffff cellSpacing=0 cellPadding=0 
                  border=1>
                    <TR>
                      <TD align=center>
<asp:imagebutton id=ibtnAceptar runat="server" ImageUrl="../../imagenes/bt_aceptar.gif" Height="22px"></asp:imagebutton></TD>
                      <TD align=center></SPAN><IMG id=ibtnCancelar 
                        style="CURSOR: hand" onclick=HistorialIrAtras(); alt="" 
                        src="../../imagenes/bt_cancelar.gif"></TD></TR></TABLE></TD></TR>
              <TR>
                <TD class=normal style="WIDTH: 81px" vAlign=top align=left 
                colSpan=2>
<cc1:domvalidationsummary id=vSum runat="server" Width="88px" Height="22px" EnableClientScript="False" DisplayMode="List" ShowMessageBox="True"></cc1:domvalidationsummary></TD></TR></TABLE></TD></TR>
						</table>
					</TD>
				</TR>
			</table>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
