<%@ Page language="c#" Codebehind="MostrarVentanaModal.aspx.cs" AutoEventWireup="false" Inherits="SIMA.SimaNetWeb.General.MostrarVentanaModal" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SIMANET</title>
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript" type="text/javascript"></script>
		<LINK href="../styles.css" type="text/css" rel="stylesheet">
		<script language="javascript">			
			function Reemplazar(cadena, patron, valor)
			{
				var ArraObj = cadena.split(patron);
				for(var i=0;i<= ArraObj.length;i++)
				{cadena=cadena.replace(patron,valor);}
				return cadena;
			}
		
		
			function POPUPMOSTRARARCHIVOS(rutadocumento)
			{
				var ArraObj = rutadocumento.split("?");
				for(var i=0;i<= ArraObj.length;i++)
				{rutadocumento=rutadocumento.replace("?"," ");}
				window.open(rutadocumento,"miwin","Width=790,Height=560,scrollbars=true, screenX=0, screenY=0,top=0,left=0");
			}
		</script>
	</HEAD>
	<body>
		<form id="frmModal" method="post" runat="server">
			<TABLE id="Table1" cellSpacing="1" cellPadding="1" width="100%" border="0">
				<TR>
					<TD id="oTitulo" style="FONT-SIZE: 14px; VERTICAL-ALIGN: baseline; COLOR: #000000; LINE-HEIGHT: normal; HEIGHT: 35px; TEXT-ALIGN: left; TEXT-DECORATION: underline; FONT-BOLD: true"
						width="90%"></TD>
					<TD style="HEIGHT: 35px"><INPUT id="CmdCerrar" onclick="window.close();" type="button" value="Cerrar"></TD>
				</TR>
				<TR>
					<TD id="oMostrar" width="100%" style="FONT-SIZE: 10px; FONT-STYLE: normal; FONT-FAMILY: Arial"
						colSpan="2"></TD>
					<TD style="FONT-SIZE: 10px; FONT-STYLE: normal; FONT-FAMILY: Arial" width="100%"></TD>
				</TR>
			</TABLE>
			<script language="javascript">
				var Comilla = String.fromCharCode(34);
				objTitulo=document.all["oTitulo"]; 
				objMostrar=document.all["oMostrar"];
				var Cadena=window.dialogArguments;
				var Valor = Cadena.split('@%@');
				var pTitulo=Valor[0];
				var pMostrar=Valor[1];
				var Contenido = Reemplazar(pMostrar,"@",Comilla);
				Contenido = Reemplazar(Contenido,"¿","'");				
				Contenido = Reemplazar(Contenido,"#","'");								
				objTitulo.innerHTML=pTitulo;
				objMostrar.innerHTML=Contenido;
			</script>
		</form>
	</body>
</HTML>
