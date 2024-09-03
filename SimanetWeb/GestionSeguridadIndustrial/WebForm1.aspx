<%@ Register TagPrefix="ew" Namespace="eWorld.UI" Assembly="eWorld.UI" %>
<%@ Register TagPrefix="uc1" TagName="Header" Src="../ControlesUsuario/Header.ascx" %>
<%@ Register TagPrefix="uc1" TagName="Menu" Src="../ControlesUsuario/Menu.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="System.Web.UI.WebControls.DomValidators" Assembly="System.Web.UI.WebControls.DomValidators" %>
<%@ Page language="c#" Codebehind="DetalleSctr.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.GestionSeguridadIndustrial.DetalleSctr" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Administrar Programación Trabajadores Contratista</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="../styles.css">
		<SCRIPT language="javascript" src="/SimaNetWeb/js/@Import.js"></SCRIPT>
		<script type="text/javascript" src="../../js/date.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/Busqueda/scripts/AutoBusqueda.js"></script>
		<script type="text/javascript" src="/SimaNetWeb/js/RegEXT.js"></script>
		<SCRIPT>
		//FUNSION BUSCAR TRABAJADOR//
			function txtTrabajador_ItemDataBound(sender,e,dr){
				document.getElementById("hIdTrabajador").value = dr["NroDNI"];
			}
		//FUNSION BUSCA ASEGURADORA//
			function txtAseguradora_ItemDataBound(sender,e,dr){
				document.getElementById("hidAseguradora").value = dr["codigo"];
			}			
			
			function ValidaRespuesta(btn){
				alert(btn);
			}

		//FUNSION BUSCA PROVEEDOR RAZONSOCIAL - RUC (IDENTIDAD=26)
			function txtRazonSocial_ItemDataBound(sender,e,dr){
				if(new SIMA.Numero($O('txtRazonSocial').value).IsNumeric()==true){
					$O('txtRuc').value = dr["RAZONSOCIAL"].toString();	
				}
				else{
					$O('txtRuc').value = dr["NROPROVEEDOR"].toString();	
				}
				//Obtiene la identificacion del proveedor
				$O('hidEntidad').value = dr["IDPROVEEDOR"].toString()
			}

		</SCRIPT>
	</HEAD>
	<body onkeypress="if(event.keyCode==13)return false;" onclick="MostrarTrabajadorAgregado();"
		onunload="SubirHistorial();onload=ObtenerHistorial();" bottomMargin="0" leftMargin="0"
		rightMargin="0" topMargin="0" bgColor="white">
		<form id="Form1" method="post" runat="server">
			<TABLE id="Table1" border="1" cellSpacing="1" cellPadding="1" width="100%">
				<TR>
					<TD>header</TD>
				</TR>
				<TR>
					<TD>menu</TD>
				</TR>
				<TR>
					<TD>ruta</TD>
				</TR>
				<TR>
					<TD></TD>
				</TR>
				<TR>
					<TD>botones</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
