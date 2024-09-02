<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="cc2" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="PopupDetallesRepresentantePromotor.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionComercial.Promotores.PopupDetallesRepresentantePromotor" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
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
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0" onload="ObtenerHistorial();"
		onunload="SubirHistorial();">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table4" cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<TR>
					<TD colSpan="3"><uc1:header id="Header1" runat="server"></uc1:header></TD>
				</TR>
				<TR>
					<TD colSpan="3"><uc1:menu id="Menu1" runat="server"></uc1:menu></TD>
				</TR>
				<TR>
					<TD class="Commands" colSpan="3"><asp:label id="lblRutaPagina" runat="server" CssClass="RutaPagina">Inicio > Gestion Comercial > Promotor > </asp:label><asp:label id="lblPagina" runat="server" CssClass="RutaPaginaActual"> Consulta Detalle de Promotor</asp:label></TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<P align="center"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipal"></asp:label></P>
					</TD>
				</TR>
				<TR>
					<TD align="center" colSpan="3">
						<TABLE class="normal" id="Table7" style="WIDTH: 454px; HEIGHT: 203px" cellSpacing="1" cellPadding="1"
							width="454" align="center" border="0" runat="server">
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 32px" vAlign="top" bgColor="#335eb4"><asp:label id="lblNombre" runat="server" CssClass="TextoBlanco">Nombre :</asp:label></TD>
								<TD class="normal" style="WIDTH: 352px; HEIGHT: 32px" vAlign="top" bgColor="#f0f0f0"
									colSpan="4"><asp:textbox id="txtNombre" runat="server" CssClass="normaldetalle" BackColor="White" Width="150px"
										BorderStyle="Groove"></asp:textbox><cc2:requireddomvalidator id="rfvNombre" runat="server" ControlToValidate="txtNombre">*</cc2:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 32px" vAlign="top" bgColor="#335eb4"><asp:label id="lblApellidoPaterno" runat="server" CssClass="TextoBlanco">Apellido Paterno :</asp:label></TD>
								<TD class="normal" style="WIDTH: 352px; HEIGHT: 32px" vAlign="top" bgColor="#dddddd"
									colSpan="4"><asp:textbox id="txtApellidoPaterno" runat="server" CssClass="normaldetalle" BackColor="White"
										Width="150px" BorderStyle="Groove"></asp:textbox><cc2:requireddomvalidator id="rfvApellidoPaterno" runat="server" ControlToValidate="txtApellidoPaterno">*</cc2:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 32px" vAlign="top" bgColor="#335eb4"><asp:label id="lblApellidoMaterrno" runat="server" CssClass="TextoBlanco">Apellido Materno :</asp:label></TD>
								<TD class="normal" style="WIDTH: 352px; HEIGHT: 32px" vAlign="top" bgColor="#f0f0f0"
									colSpan="4"><asp:textbox id="txtApellidoMaterno" runat="server" CssClass="normaldetalle" BackColor="White"
										Width="150px" BorderStyle="Groove"></asp:textbox><cc2:requireddomvalidator id="rfvApellidoMaterno" runat="server" ControlToValidate="txtApellidoMaterno">*</cc2:requireddomvalidator></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 32px" vAlign="top" bgColor="#335eb4"><asp:label id="lblDocumentoIdentidad" runat="server" CssClass="TextoBlanco">Documento Identidad :</asp:label></TD>
								<TD class="normal" style="WIDTH: 352px; HEIGHT: 32px" vAlign="top" bgColor="#dddddd"
									colSpan="4"><asp:textbox id="txtDocIdentidad" runat="server" CssClass="normaldetalle" BackColor="White" Width="150px"
										BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 3px" vAlign="top" bgColor="#335eb4"><asp:label id="lblTelefono" runat="server" CssClass="TextoBlanco">Telefono:</asp:label></TD>
								<TD class="normal" style="WIDTH: 110px; HEIGHT: 3px" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtTelefono" runat="server" CssClass="normaldetalle" BackColor="White" Width="150px"
										BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 19px" vAlign="top" bgColor="#335eb4"><asp:label id="lblCelu" runat="server" CssClass="TextoBlanco">Celu :</asp:label></TD>
								<TD class="normal" style="HEIGHT: 19px" bgColor="#dddddd" colSpan="4"><asp:textbox id="txtCelu" runat="server" CssClass="normaldetalle" BackColor="White" Width="150px"
										BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="normal" style="WIDTH: 132px; HEIGHT: 3px" vAlign="top" bgColor="#335eb4"><asp:label id="lblCorreoElectronico" runat="server" CssClass="TextoBlanco">Correo Electronico:</asp:label></TD>
								<TD class="normal" style="WIDTH: 110px; HEIGHT: 3px" bgColor="#f0f0f0" colSpan="4"><asp:textbox id="txtCorreoElectronico" runat="server" CssClass="normaldetalle" BackColor="White"
										Width="300px" BorderStyle="Groove"></asp:textbox></TD>
							</TR>
							<TR>
								<TD class="normal" id="TdCeldaCancelar" vAlign="top" colSpan="4" runat="server"><IMG id="ibtnAtras" style="CURSOR: hand" onclick="HistorialIrAtras();" alt="" src="../../imagenes/atras.gif"></TD>
								<TD class="normal" style="WIDTH: 110px; HEIGHT: 3px"></TD>
							</TR>
							<TR>
								<TD class="normal" vAlign="top" colSpan="4"></TD>
								<TD class="normal" style="WIDTH: 110px; HEIGHT: 3px">
									<asp:ValidationSummary id="sSum" runat="server" Width="100px" DisplayMode="List" EnableClientScript="False"
										ShowMessageBox="True" ShowSummary="False"></asp:ValidationSummary></TD>
							</TR>
						</TABLE>
						<asp:imagebutton id="ibtnAceptar" runat="server" Width="87px" ImageUrl="../../imagenes/bt_aceptar.gif"
							Height="22px"></asp:imagebutton><IMG id="ibtnCancelar" onclick="HistorialIrAtras();" alt="" src="../../imagenes/bt_cancelar.gif"
							runat="server"></TD>
				</TR>
				<TR>
					<TD vAlign="top" align="center" width="592"><asp:label id="lblMensaje" runat="server" CssClass="normal"></asp:label></TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
