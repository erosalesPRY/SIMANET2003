using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Data;
using System.Text;
using SIMA.Utilitario;

namespace SIMA.SimaNetWeb.ControlesUsuario.GestionFinanciera
{
	/// <summary>
	/// Summary description for TablaDinamica.
	/// </summary>
	[DefaultProperty("Text"), 
		ToolboxData("<{0}:TablaDinamica runat=server></{0}:TablaDinamica>")]
	public class TablaDinamica : System.Web.UI.WebControls.WebControl
	{
		private string text;
		private DataTable datasource;
		private const string KEYQIDCLIENTE = "IdCliente";
		private const string KEYQIDTABLATIPOPROYECTO = "IdTablaTipoProyecto";
		private const string KEYQIDTIPOPROYECTO = "IdTipoProyecto";
		private const string KEYQTITULO = "Titulo";
		private	const string KEYQIDPROYECTO = "IdProyecto";	
	
		[Bindable(true), 
			Category("Appearance"), 
			DefaultValue("")] 
		public string Text 
		{
			get
			{
				return text;
			}

			set
			{
				text = value;
			}
		}

		[Bindable(true), 
		Category("Appearance"), 
		DefaultValue("")] 
		public DataTable Datasource 
		{
			get
			{
				return datasource;
			}

			set
			{
				datasource = value;
			}
		}

		/// <summary> 
		/// Render this control to the output parameter specified.
		/// </summary>
		/// <param name="output"> The HTML writer to write out to </param>
		protected override void Render(HtmlTextWriter output)
		{
			output.Write(GenerarCadena(datasource).ToString());
		}

		private StringBuilder GenerarCadena(DataTable dt)
		{
			StringBuilder generado = new StringBuilder("<TABLE class='headerGrilla' id='Table4' cellSpacing='0' cellPadding='0' width='100%' border='1'>" +
				"<TR>" +
					"<TD width='4%' rowSpan='3'>co</TD>" +
					"<TD width='8%' rowSpan='3'>BANCO</TD>" +
					"<TD width='40%' colSpan='6'>PROYECTO</TD>" +
					"<TD width='2%' rowSpan='3'>REN</TD>" +
					"<TD width='9%' rowSpan='3'>SITUACION</TD>" +
					"<TD width='18%' colSpan='2'>FECHA</TD>" +
					"<TD width='20%' colSpan='3' >COSTO ACUMULADO</TD>" +
				"</TR>" +
				"<TR>" +
					"<TD width='5%' rowSpan='12'>N°C.F.</TD>" +
					"<TD width='14%' rowSpan='2'>BENEFICIARIO</TD>" + 
					"<TD width='23%' colSpan='4'>IMPORTES</TD>" +
					"<TD width='8%' rowSpan='2'>INICIO</TD>" +
					"<TD width='8%' rowSpan='12'>VCMTO.</TD>" +
					"<TD width='2%' rowSpan='2'>%</TD>" +
					"<TD width='9%' rowSpan='2'>SOLES</TD>" +
					"<TD width='8%' rowSpan='2'>EQUIV. USD.</TD>" +
				"</TR>" +
				"<TR>" +
					"<TD width='4%'>MONEDA</TD>" +
					"<TD width='8%'>IMPORTE</TD>" +
					"<TD width='3%'>T.C.</TD>" + 
					"<TD width='8%'>V.CAMBIO S/.</TD>" +
				"</TR>" +
			"</TABLE>");

			generado.Append("<TABLE class='Grid' id='Table3' cellSpacing='0' cellPadding='0' width='100%' border='1'>");

			
            DataTable ColumnaDistinct = SelectDistinct2("Default",dt,"IDPROYECTO");
			DataTable ColumnaDistinct2 = SelectDistinct("Default",dt,"NCF");


			foreach (DataRow dr in ColumnaDistinct.Rows )
			{
				DataView dwContenido = ColumnaDistinct2.DefaultView;				
				dwContenido.RowFilter = "idproyecto='" + dr["idProyecto"].ToString()+ "'";
					
				if(dwContenido.Count>0)
					generado.Append(GenerarBloque(dwContenido));				
			}
		

			return generado;
		}

		private string GenerarBloque(DataView dw)
		{
			string filaGenerada=String.Empty;
			int flagCabecera=0;
			int inicio= 1;

			int totalcontador=0;
			double totalimporte=0;
			double totalvalorcambio=0;
			double totalmontoacumulado=0;
			double totalacumuladodolar=0;

			foreach (DataRowView dr in dw)
			{
				totalcontador++;
				totalimporte+= Convert.ToDouble(dr["IMPORTE"].ToString());
				totalvalorcambio+= Convert.ToDouble(dr["VALORCAMBIO"].ToString());
				totalmontoacumulado+= Convert.ToDouble(dr["MONTOACUMULADO"].ToString());
				totalacumuladodolar+= Convert.ToDouble(dr["ACUMULADODOLAR"].ToString());

				string tooltip = "onmouseover=" + @"""" + "Tip('" + Helper.EncodeText(GenerarToolTips(Convert.ToInt32(dr["IDPROYECTO"].ToString())).ToString())  + "', WIDTH, 300, TITLE, 'Renovaciones', SHADOW, true, FADEIN, 300, FADEOUT, 300, STICKY, 1, OFFSETX, -20, CLOSEBTN, true, CLICKCLOSE, false)" + @"""" + ">";

				#region Construccion
				if(flagCabecera == 0)
				{
					filaGenerada+= "<tr><TD id=td" + totalcontador.ToString() + " onclick=" + @"""" + "HistorialIrAdelante();" + @"""" + " class='FooterGrilla' colSpan='15'>" + @"<a href='..\..\Proyectos\DetalleProyectosEjecucionSectorPrivado.aspx?"
						+ Utilitario.Constantes.KEYMODOPAGINA + "=C" + Utilitario.Constantes.SIGNOAMPERSON  
						+ KEYQIDTABLATIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + dr["IDTABLATIPOPROYECTO"].ToString() + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDTIPOPROYECTO + Utilitario.Constantes.SIGNOIGUAL + dr["IDTIPOPROYECTO"].ToString() + Utilitario.Constantes.SIGNOAMPERSON
						+ KEYQIDPROYECTO + Utilitario.Constantes.SIGNOIGUAL + dr["IDPROYECTO"].ToString() + Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQTITULO + Utilitario.Constantes.SIGNOIGUAL + "Sima-Callao - PROYECTOS EN EJECUCION" +  Utilitario.Constantes.SIGNOAMPERSON 
						+ KEYQIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL + dr["IDCLIENTE"].ToString() + "'>"
						+  dr["PROYECTO"].ToString() + "</a></td></tr>";
					flagCabecera++;

					filaGenerada+= @"<tr class=ItemGrilla onmouseover=" + @"""" +  "CambiarColorPasarMouse(this, true)" + @"""" +  
						" onmouseout=" + @"""" + "CambiarColorPasarMouse(this, false)" + @"""" + 
						" OnClick=" + @"""" + "CambiarColorSeleccion(this);" + @"""" + ">" +
						"<TD width=4%>" + dr["CENTRODEORIGEN"].ToString() + "</td>" + 
						"<TD width=8%>" + dr["BANCO"].ToString() + "</td>" +
						"<TD width='5%'>" + dr["NCF"].ToString() + "</td>" +
						"<TD width='14%'>" + dr["BENEFICIARIO"].ToString() + "</td>" +
						"<TD width='4%'>" + dr["MONEDA"].ToString() + "</td>" +
						"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["IMPORTE"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
						"<TD width='3%' align='right'>" + dr["TIPOCAMBIO"].ToString() + "</td>" +
						"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["VALORCAMBIO"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
						"<TD width='2%'>" + dr["REN"].ToString() + "</td>" +
						"<TD width='9%'>" + dr["EstadoCartaFianza"].ToString() + "</td>" +
						"<TD width='8%'" + tooltip + dr["fechaRenovacion"].ToString() + "</td>" +
						"<TD width='8%'" + tooltip + dr["fechavencimiento"].ToString() + "</td>" +
						"<TD width='2%' align='right'>" + Convert.ToDecimal(dr["interes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL2) + "</td>" +
						"<TD width='9%' align='right'>" + Convert.ToDecimal(dr["MONTOACUMULADO"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
						"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["ACUMULADODOLAR"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td></tr>"
						;
					inicio++;
				}
				else
				{
					if(inicio == 1)
					{
						filaGenerada+= @"<tr class=ItemGrilla onmouseover=" + @"""" +  "CambiarColorPasarMouse(this, true)" + @"""" +  
							" onmouseout=" + @"""" + "CambiarColorPasarMouse(this, false)" + @"""" + 
							" OnClick=" + @"""" + "CambiarColorSeleccion(this);" + @"""" + ">" +
							"<TD width=4%>" + dr["CENTRODEORIGEN"].ToString() + "</td>" + 
							"<TD width=8%>" + dr["BANCO"].ToString() + "</td>" +
							"<TD width='5%'>" + dr["NCF"].ToString() + "</td>" +
							"<TD width='14%'>" + dr["BENEFICIARIO"].ToString() + "</td>" +
							"<TD width='4%'>" + dr["MONEDA"].ToString() + "</td>" +
							"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["IMPORTE"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='3%' align='right'>" + dr["TIPOCAMBIO"].ToString() + "</td>" +
							"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["VALORCAMBIO"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='2%'>" + dr["REN"].ToString() + "</td>" +
							"<TD width='9%'>" + dr["EstadoCartaFianza"].ToString() + "</td>" +
							"<TD width='8%'" + tooltip + dr["fechaRenovacion"].ToString() + "</td>" +
							"<TD width='8%'" + tooltip + dr["fechavencimiento"].ToString() + "</td>" +
							"<TD width='2%' align='right'>" + Convert.ToDecimal(dr["interes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL2) + "</td>" +
							"<TD width='9%' align='right'>" + Convert.ToDecimal(dr["MONTOACUMULADO"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["ACUMULADODOLAR"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td></tr>"
							;
						inicio++;
					}
					else
					{
						filaGenerada+= @"<tr class=AlternateItemGrilla onmouseover=" + @"""" +  "CambiarColorPasarMouse(this, true);" + @"""" +  
							" onmouseout=" + @"""" + "CambiarColorPasarMouse(this, false);" + @"""" + 
							" OnClick=" + @"""" + "CambiarColorSeleccion(this);" + @"""" + ">" +
							"<TD width=4%>" + dr["CENTRODEORIGEN"].ToString() + "</td>" + 
							"<TD width=8%>" + dr["BANCO"].ToString() + "</td>" +
							"<TD width='5%'>" + dr["NCF"].ToString() + "</td>" +
							"<TD width='14%'>" + dr["BENEFICIARIO"].ToString() + "</td>" +
							"<TD width='4%'>" + dr["MONEDA"].ToString() + "</td>" +
							"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["IMPORTE"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='3%' align='right'>" + dr["TIPOCAMBIO"].ToString() + "</td>" +
							"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["VALORCAMBIO"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='2%'>" + dr["REN"].ToString() + "</td>" +
							"<TD width='9%'>" + dr["EstadoCartaFianza"].ToString() + "</td>" +
							"<TD width='8%'" + tooltip + dr["fechaRenovacion"].ToString() + "</td>" +
							"<TD width='8%'" + tooltip + dr["fechavencimiento"].ToString() + "</td>" +
							"<TD width='2%' align='right'>" + Convert.ToDecimal(dr["interes"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL2) + "</td>" +
							"<TD width='9%' align='right'>" + Convert.ToDecimal(dr["MONTOACUMULADO"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='8%' align='right'>" + Convert.ToDecimal(dr["ACUMULADODOLAR"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td></tr>"
							;
						inicio--;
					}
				}
			#endregion
			}
			

			filaGenerada+= 	"<TD width=4% class='FooterGrilla' align='left' >" + "T.:" + "</td>" + 
							"<TD width=8% class='FooterGrilla' align='right'>" + totalcontador.ToString() + "</td>" +
							"<TD width='5%' class='FooterGrilla'></td>" +
							"<TD width='14%' class='FooterGrilla'></td>" +
							"<TD width='4%' class='FooterGrilla'></td>" +
							"<TD width='8%' class='FooterGrilla' align='right'>" + totalimporte.ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='3%' class='FooterGrilla'></td>" +
							"<TD width='8%' class='FooterGrilla' align='right'>" + totalvalorcambio.ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='2%' class='FooterGrilla'></td>" +
							"<TD width='9%' class='FooterGrilla'></td>" +
							"<TD width='8%' class='FooterGrilla'></td>" +
							"<TD width='8%' class='FooterGrilla'></td>" +
							"<TD width='2%' class='FooterGrilla'></td>" +
							"<TD width='9%' class='FooterGrilla' align='right'>" + totalmontoacumulado.ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td>" +
							"<TD width='8%' class='FooterGrilla' align='right'>" + totalacumuladodolar.ToString(Utilitario.Constantes.FORMATODECIMAL4) + "</td></tr>";

			return filaGenerada;
		}

	
		private bool ColumnEqual(object A, object B)
		{
			if ( A == DBNull.Value && B == DBNull.Value ) 
				return true; 
			if ( A == DBNull.Value || B == DBNull.Value ) 
				return false; 
			return ( A.Equals(B) );  
		}

		private DataTable SelectDistinct2(string TableName, DataTable SourceTable, string FieldName )
		{	
			DataTable dt = new DataTable(TableName);
			dt.Columns.Add(FieldName, SourceTable.Columns[FieldName].DataType);
					
			object LastValue = null; 

			foreach (DataRow dr in SourceTable.Select("", FieldName))
			{
				if (  LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])) ) 
				{
					LastValue = dr[FieldName]; 
					dt.Rows.Add(new object[]{LastValue});
				}
			}
			return dt;
		}

		private DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName )
		{	
			DataTable dt = new DataTable(TableName);

			for(int i=0;i<=SourceTable.Columns.Count-1;i++)
				dt.Columns.Add(SourceTable.Columns[i].ColumnName.ToString(),SourceTable.Columns[i].DataType);
					
			object LastValue = null; 

			foreach (DataRow dr in SourceTable.Select("", FieldName))
			{
				if (  LastValue == null || !(ColumnEqual(LastValue, dr[FieldName])) ) 
				{
					LastValue = dr[FieldName]; 
					dt.Rows.Add( dr.ItemArray);
				}
			}
			return dt;
		}

		private StringBuilder GenerarToolTips(int idProyecto)
		{
			
			DataView dwContenido = datasource.DefaultView;
			dwContenido.RowFilter = "idproyecto='" + idProyecto.ToString() + "'";

			StringBuilder cadena= new StringBuilder("<TABLE class='headerGrilla' ><tr><td>FECHA INICIO</TD><TD>FECHA VENCIMIENTO</TD><TD>MONTO ACUMULADO</TD></TR>");
			
			int flag=0;

			foreach (DataRowView dr in dwContenido)
			{
				if(flag == 0)
				{
					cadena.Append("<tr class='ItemGrilla'><td>" + dr["FEC1"].ToString() + "</td><td>" + dr["FEC2"].ToString() + "</td><td>" + Convert.ToDouble(dr["MONTOCARTAFZA"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) +"</td></tr>");
					flag++;
				}
				else
				{
					cadena.Append("<tr class='AlternateItemGrilla'><td>" + dr["FEC1"].ToString() + "</td><td>" + dr["FEC2"].ToString() + "</td><td>" + Convert.ToDouble(dr["MONTOCARTAFZA"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4) +"</td></tr>");
					flag--;
				}
			}
			
			return cadena.Append("</TABLE>");
		}
	}
}
