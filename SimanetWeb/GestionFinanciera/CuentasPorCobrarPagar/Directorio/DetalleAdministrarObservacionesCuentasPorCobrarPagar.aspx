<%@ Register TagPrefix="uc1" TagName="Menu" Src="../../../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../../../ControlesUsuario/Header.ascx" %>
<%@ Page language="c#" Codebehind="DetalleAdministrarObservacionesCuentasPorCobrarPagar.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio.DetalleAdministrarObservacionesCuentasPorCobrarPagar" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Detalle Datos de Observaciones</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../../../styles.css" type="text/css" rel="stylesheet">
		<SCRIPT language="javascript" src="../../../js/@Import.js"></SCRIPT>
		<SCRIPT language="javascript">(new Script.Import()).Registrar();</SCRIPT>
				
		<script>
										
				function cambiarTamano()
				{
						
						x = (screen.width - 360) / 2;
						y = (screen.height - 650) / 2;
						moveTo(x, y);
				}
				
								
				function InsertarObservaciones(idcentroOperativo,dist,numdocAna,idEntidad,cuenta,nroCliente,tipoCuenta,idcuenta,idSubcuenta,idUsuario)
				{
					var observacion = document.forms[0].elements['txtObservacion'];
					var concepto = document.forms[0].elements['txtConcepto'];
					var retorno="";
				
					retorno=(new Controladora.CtasPagarCobrar.CObservacionesCtasCobrarPagar()).Insertar(idcentroOperativo,dist,numdocAna,idEntidad,cuenta,nroCliente,tipoCuenta,idcuenta,idSubcuenta,idUsuario,observacion.value,concepto.value);
					if(retorno>0)
					{	window.alert('Se registro con exito');
						window.close();
					}
					
				}
				function ModificarObservaciones(idcentroOperativo,dist,numdocAna,idEntidad,cuenta,nroCliente,tipoCuenta,idcuenta,idSubcuenta,idUsuario)
				{
					var observacion = document.forms[0].elements['txtObservacion'];
					var concepto = document.forms[0].elements['txtConcepto'];
					var retorno="";
				
					retorno=(new Controladora.CtasPagarCobrar.CObservacionesCtasCobrarPagar()).Modificar(idcentroOperativo,dist,numdocAna,idEntidad,cuenta,nroCliente,tipoCuenta,idcuenta,idSubcuenta,idUsuario,observacion.value,concepto.value);
					if(retorno>0)
					{	window.alert('Se modificaron los datos con exito');
						window.close();
					}
					
				}
		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0"  rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
				<TR>
					<TD colSpan="3"></TD>
				</TR>
				<TR>
					<TD colSpan="3">
						<DIV align="center">
							<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="300" align="center" border="1"
								borderColor="#ffffff">
								<TR>
									<TD bgColor="#000080" colSpan="3"><asp:label id="lblTitulo" runat="server" CssClass="TituloPrincipalBlanco" Height="14px"></asp:label></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4"><asp:label id="lblDenominacion" runat="server" CssClass="TextoBlanco" Width="89px">OBSERVACION :</asp:label></TD>
									<TD bgColor="#dddddd"><asp:textbox id="txtObservacion" runat="server" CssClass="normal" Height="112px" Width="434px"
											MaxLength="2000" TextMode="MultiLine"></asp:textbox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD bgColor="#335eb4">
										<asp:label id="Label1" runat="server" CssClass="TextoBlanco" Width="89px">CONCEPTO:</asp:label></TD>
									<TD bgColor="#dddddd">
										<asp:textbox id="txtConcepto" runat="server" CssClass="normal" Height="104px" Width="434px" TextMode="MultiLine"
											MaxLength="2000"></asp:textbox></TD>
									<TD></TD>
								</TR>
								<TR>
									<TD colSpan="3">
										<P align="center">&nbsp; <IMG id="imgAceptar" onclick="EntregarDatosWindowRemoto();" alt="" src="/SimanetWeb/imagenes/bt_aceptar.gif"
												runat="server">&nbsp;<SPAN class="normal">
												<asp:image id="imgCancelar" onclick="window.close()" runat="server" ImageUrl="/SimanetWeb/imagenes/bt_cancelar.gif"></asp:image></SPAN></P>
									</TD>
								</TR>
							</TABLE>
						</DIV>
					</TD>
				</TR>
			</TABLE>
		</form>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</body>
</HTML>
