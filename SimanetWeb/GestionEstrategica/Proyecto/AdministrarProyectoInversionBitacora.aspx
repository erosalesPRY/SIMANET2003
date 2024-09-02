<%@ Page language="c#" Codebehind="AdministrarProyectoInversionBitacora.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionEstrategica.Proyecto.AdministrarProyectoInversionBitacora" %>
<%@ Register TagPrefix="cc1" Namespace="projDataGridWeb" Assembly="projDataGridWeb" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdministrarProyectoInversionBitacora</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../../styles.css">
	</HEAD>
	<body bottomMargin="0" leftMargin="0" rightMargin="0" topMargin="0">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="0" cellSpacing="1" cellPadding="1" width="100%" height="100%">
				<TR>
					<TD vAlign="top" align="left">
						<div style="WIDTH: 100%; HEIGHT: 450px; OVERFLOW: auto; TOP: 48px"><asp:datagrid id="gridBitacora" runat="server" Width="100%" AutoGenerateColumns="False" style="Z-INDEX: 0">
								<AlternatingItemStyle CssClass="AlternateItemGrilla"></AlternatingItemStyle>
								<ItemStyle CssClass="ItemGrilla"></ItemStyle>
								<HeaderStyle CssClass="HeaderGrilla"></HeaderStyle>
								<Columns>
									<asp:TemplateColumn HeaderText="FECHA">
										<HeaderStyle Width="80px"></HeaderStyle>
										<ItemStyle HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
										<ItemTemplate>
											<asp:TextBox onblur="GrabarBitacora(this);" id="txtFecha" runat="server" Width="80px" rel="calendar"
												CssClass="normaldetalle" BorderWidth="1px" BorderStyle="Dashed"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn HeaderText="DESCRIPCION">
										<HeaderStyle Width="80%"></HeaderStyle>
										<ItemTemplate>
											<asp:TextBox onblur="GrabarBitacora(this);" id="txtDescripcion" runat="server" Width="100%" TextMode="MultiLine"
												Height="100px" BorderStyle="Dashed" BorderWidth="1px" CssClass="normaldetalle"></asp:TextBox>
										</ItemTemplate>
									</asp:TemplateColumn>
									<asp:TemplateColumn>
										<HeaderStyle Width="5%"></HeaderStyle>
										<ItemTemplate>
											<IMG id="imgEliminaBitacora" onclick="EliminarBitacora(this);" src="../../imagenes/Filtro/Eliminar.gif"
												runat="server">
										</ItemTemplate>
									</asp:TemplateColumn>
								</Columns>
							</asp:datagrid></div>
					</TD>
				</TR>
			</TABLE>
		</form>
		<script>
			var textBoxes = Ext.DomQuery.select("input[rel=calendar]");   
					Ext.each(textBoxes, function(item, id, all){   
						var cl = new Ext.form.DateField({   
							format: 'd/m/Y',
							allowBlank : false,   
							applyTo: item   
						});
					}); 
					  
			function GrabarBitacora(e){
				var orow;
				if(e.id.toString().indexOf("txtFecha")!=-1){
					orow =jNet.get(e.parentNode.parentNode.parentNode);
					if(e.value==orow.attr("FECHA")){return false;}
					orow.attr("FECHA",e.value);
				}
				else{
					orow =jNet.get(e.parentNode.parentNode);
					if(e.value==orow.attr("DESCRIPCION")){return false;}
					orow.attr("DESCRIPCION",e.value);
				}
				orow = jNet.get(orow);
				var otxtFecha =  orow.cells[0].childNodes[0].childNodes[0];
				if(otxtFecha.value.length==0){
					Ext.MessageBox.alert('MENSAJE', 'para que se registre los datos se debera de ingresar el dato fecha', function(btn){});
					return;
				}
				var oProyectoPerfilBitacoraBE = new EntidadesNegocio.Estrategica.ProyectoPerfilBitacoraBE();
				oProyectoPerfilBitacoraBE.IdBitacora = orow.attr("IDBITACORA")
				oProyectoPerfilBitacoraBE.IdProyectoPerfil = orow.attr("IDPROYECTOPERFIL");
				oProyectoPerfilBitacoraBE.Fecha = orow.attr("FECHA");
				oProyectoPerfilBitacoraBE.Descripcion = orow.attr("DESCRIPCION");
				oProyectoPerfilBitacoraBE.IdEstado = 1;
				orow.attr("IDBITACORA",(new Controladora.Estrategica.CProyectoPerfilBitacora()).Insertar(oProyectoPerfilBitacoraBE));
				orow.cells[2].childNodes[0].style.display="block";
			}

			function EliminarBitacora(e){
				var orow = e.parentNode.parentNode;
				var oDataGrid = orow.parentNode;
				orow = jNet.get(orow);
				Ext.MessageBox.confirm('Confirmar', 'Desea ud. eliminar este registro ahora?', function(btn){
					if(btn=="yes"){
						var oProyectoPerfilBitacoraBE = new EntidadesNegocio.Estrategica.ProyectoPerfilBitacoraBE();
						oProyectoPerfilBitacoraBE.IdBitacora = orow.attr("IDBITACORA")
						oProyectoPerfilBitacoraBE.IdProyectoPerfil = orow.attr("IDPROYECTOPERFIL");
						oProyectoPerfilBitacoraBE.Fecha = orow.attr("FECHA");
						oProyectoPerfilBitacoraBE.Descripcion = orow.attr("DESCRIPCION");
						oProyectoPerfilBitacoraBE.IdEstado = 0;
						
						(new Controladora.Estrategica.CProyectoPerfilBitacora()).Insertar(oProyectoPerfilBitacoraBE);
						oDataGrid.removeChild(orow);
					}
				});				
			}
		</script>
	</body>
</HTML>
