<%@ Page language="c#" Codebehind="ImportarBubirArchivos.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.ImportarBubirArchivos" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<%@ Register TagPrefix="mbrsc" Namespace="MetaBuilders.WebControls" Assembly="MetaBuilders.WebControls.RowSelectorColumn" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="../js/@Import.js"></SCRIPT>
		<script>
			function detect(){
				//var obj = document.elementFromPoint(event.x,event.y);
				var obj =$O('filMyFile');
				cargado(obj);
			}
			
			function comprueba_extension(archivo) { 

			//extensiones_permitidas = new Array(".gif", ".jpg", ".doc", ".pdf"); 
			extensiones_permitidas = new Array(".xls"); 
			mierror = ""; 
			if (!archivo) { 
				//Si no tengo archivo, es que no se ha seleccionado un archivo en el formulario 
				mierror = "No has seleccionado ningún archivo"; 
			}else{ 
				//recupero la extensión de este nombre de archivo 
				extension = (archivo.substring(archivo.lastIndexOf("."))).toLowerCase(); 
				//alert (extension); 
				//compruebo si la extensión está entre las permitidas 
				permitida = false; 
				for (var i = 0; i < extensiones_permitidas.length; i++) { 
					if (extensiones_permitidas[i] == extension) { 
					permitida = true; 
					break; 
					} 
				} 
				if (!permitida) { 
					mierror = "Comprueba la extensión de los archivos a subir. \nSólo se pueden subir archivos con extensiones: " + extensiones_permitidas.join(); 
				}else{ 
					//alert ("Todo correcto. Voy a submitir el formulario."); 
					$O('hArchivoValido').value = "1";
					document.Form1.submit();
					return 1; 
				} 
			} 
			//si estoy aqui es que no se ha podido submitir 
			alert (mierror); 
			return 0; 
			} 
		</script>
	</HEAD>
	<BODY onunload="SubirHistorial();" onload="ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0">
		<FORM id="Form1" method="post" runat="server">
			<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%" height="100%">
				<tr>
					<td>
						<uc1:Header id="Header1" runat="server"></uc1:Header></td>
				</tr>
				<tr>
					<td>
						<uc1:Menu id="Menu1" runat="server"></uc1:Menu></td>
				</tr>
				<tr>
					<td height="100%" vAlign="top" align="center">
						<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" align="center">
							<TR>
								<TD style="HEIGHT: 108px"></TD>
								<TD>
									<TABLE id="Table3" class="normal" border="0" cellSpacing="1" cellPadding="1" width="100%"
										align="center">
										<TR>
											<TD class="normal" bgColor="#335eb4" vAlign="middle" style="HEIGHT: 25px"><asp:label id="lblFecha" runat="server" CssClass="TextoBlanco">MODULO:</asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4" style="HEIGHT: 25px">
												<asp:label style="Z-INDEX: 0" id="lblModulo" runat="server">MODULO:</asp:label></TD>
											<TD class="normal" style="HEIGHT: 25px"></TD>
										</TR>
										<TR>
											<TD class="normal" bgColor="#335eb4" vAlign="middle"><asp:label id="lblArchivoAdjunto" runat="server" CssClass="TextoBlanco" Width="107px"> Archivo Adjunto </asp:label></TD>
											<TD class="normal" bgColor="#dddddd" colSpan="4"><INPUT style="WIDTH: 470px; HEIGHT: 24px" id="filMyFile" class="normaldetalle" size="59"
													type="file" name="filMyFile" runat="server"></TD>
											<TD class="normal"></TD>
										</TR>
										<TR>
											<TD class="normal" height="100%" vAlign="top" colSpan="6"><cc1:datagridweb id="grid" runat="server" Width="98%" PageSize="7" AllowSorting="True" AutoGenerateColumns="False"
													AllowPaging="True" RowHighlightColor="#E0E0E0">
													<PagerStyle CssClass="PagerGrilla" Mode="NumericPages"></PagerStyle>
													<AlternatingItemStyle CssClass="Alternateitemgrilla"></AlternatingItemStyle>
													<FooterStyle CssClass="FooterGrilla"></FooterStyle>
													<ItemStyle CssClass="ItemGrilla"></ItemStyle>
													<Columns>
														<asp:BoundColumn HeaderText="NRO">
															<HeaderStyle Width="1%"></HeaderStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="FechaRegistro" HeaderText="FECHA">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="NombreArchivo" HeaderText="ARCHIVO">
															<HeaderStyle Width="15%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Responsable" HeaderText="IMPORTADO POR:">
															<HeaderStyle Width="10%"></HeaderStyle>
															<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
														<asp:BoundColumn DataField="Estado" HeaderText="ESTADO">
															<HeaderStyle Width="2%"></HeaderStyle>
															<ItemStyle Wrap="False" HorizontalAlign="Left" VerticalAlign="Middle"></ItemStyle>
														</asp:BoundColumn>
													</Columns>
													<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
												</cc1:datagridweb></TD>
										</TR>
										<TR>
											<TD class="normal" height="100%" vAlign="top" width="100%" colSpan="6" align="center">
												<asp:label style="Z-INDEX: 0" id="lblResultado" runat="server" CssClass="normal"></asp:label></TD>
										</TR>
										<TR>
											<TD class="normal" height="100%" vAlign="top" width="100%" colSpan="6">&nbsp; <INPUT style="WIDTH: 48px; HEIGHT: 22px" id="hArchivoValido" size="2" type="hidden" runat="server"><INPUT style="Z-INDEX: 0; WIDTH: 48px; HEIGHT: 22px" id="hGridPagina" size="2" type="hidden"
													name="Hidden1" runat="server" value="0">
												<TABLE id="Table7" border="0" cellSpacing="0" cellPadding="0" align="center" height="25">
													<TR>
														<TD align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <IMG style="Z-INDEX: 0" id="ibtnValida" onclick="comprueba_extension($O('filMyFile').value);"
																alt="" src="../imagenes/bt_aceptar.gif">&nbsp;&nbsp;<SPAN class="normal"> <IMG style="CURSOR: hand" id="ibtnAtras" onclick="HistorialIrAtras();" alt="" src="../imagenes/bt_cancelar.gif"></SPAN></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
								<TD vAlign="bottom" align="center"></TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</TABLE>
		</FORM>
		<SCRIPT>
			<asp:Literal id="ltlMensaje" runat="server" EnableViewState="False"></asp:Literal>
		</SCRIPT>
	</BODY>
</HTML>
