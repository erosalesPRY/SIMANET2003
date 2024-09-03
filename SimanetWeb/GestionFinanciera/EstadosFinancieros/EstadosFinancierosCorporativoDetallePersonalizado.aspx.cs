using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for EstadosFinancierosCorporativoDetallePersonalizado.
	/// </summary>
	public class EstadosFinancierosCorporativoDetallePersonalizado : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYIDCENTRO ="IdCentro";
		const string NOMBRECENTRO ="NombreCentro";
		const string NOMBRETIPOOPCION ="NombreOpcion";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFECHA = "efFecha";
		const string KEYQIDNOMBREMES = "NombreMes";


		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";
		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";


		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			
		const string URLDETALLE="EstadosFinancierosCorporativoDetalle.aspx?";

		const string GRILLAVACIA="No existen";

		//Variables
		//string []NombreCampos = {"CuentaContable","NombreCuenta","PeruPresupuestoAnual","PeruEjecucionRealAlmes","PeruSaldoRealAlMes","PeruProyectadoAnual","IquitosPresupuestoAnual","IquitosEjecucionRealAlmes","IquitosSaldoRealAlMes","IquitosProyectadoAnual"};
		string []NombreCampos = {"CuentaContable","NombreCuenta","PeruPresupuestoAnual","PeruEjecucionRealDelmesAnterior","PeruEjecucionRealDelmesActual","PeruEjecucionRealAcumulado","PeruProyectadoAnual","IquitosPresupuestoAnual","IquitosEjecucionRealDelmesAnterior","IquitosEjecucionRealDelmesActual","IquitosEjecucionRealAcumulado","IquitosProyectadoAnual"};

		DateTime FechaPeriodo;
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();

		//Datos Grilla
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOSIMAPERU ="SIMA-PERU S.A.";
		const string TITULOSIMAIQUITOS ="SIMA-IQUITOS S.R.Ltda";
		const string DATATABLERESUMEN ="Resumen";
		const string SYSTEM ="System.";
		const string TITULOAL ="AL";
		const string TITULODEL ="DEL";
		const string TITULOMES =" MES<br>DE<br>";
		const string TITULOPTO ="PRESU-<BR>PUESTO";
		const string TITULOACUMULADO ="ACU-<BR>MULADO";
		const string TITULOPROYECTADO ="PROYEC-<BR>TADO";
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label1;
			protected projDataGridWeb.DataGridWeb gridDetalle;
			protected projDataGridWeb.DataGridWeb gridResumen;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.ColspanRowspanHeader();
					this.LlenarDatos();
					this.LlenarGrilla();
				}				
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void ColspanRowspanHeader()
		{
			int NroColaMostrar = ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?
				(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)?2:3
				:5);

			//DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
			TableCell cell = null;
			m_add.DatagridToDecorate = gridDetalle;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOSIMAPERU;
			cell.Font.Size = 11;
			cell.Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
			cell.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));

			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			cell = new TableCell();
			cell.Text = TITULOSIMAIQUITOS;
			cell.Font.Size = 11;
			cell.ColumnSpan = NroColaMostrar;//((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)?3:5);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);
			m_add.AddMergeHeader(header);
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.gridDetalle.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDetalle_ItemDataBound);
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			int NroDig = Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOS]);
			string DigCuenta =Page.Request.Params[KEYQDIGCUENTA].ToString();

			DataTable dtEstadoFinanciero = this.ObtenerDatos(NroDig,DigCuenta);
			if(dtEstadoFinanciero!=null)
			{grid.DataSource = dtEstadoFinanciero;}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			grid.DataBind();			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.MostrarDetalle(this.ObtenerDetalleRubro());
			this.ObtenerDetalle();			
		}
		private DataTable ObtenerDetalleRubro()
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			return oCEstadosFinancieros.ConsultarEstadosFinancierosCorporativo
				(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA])
				,Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE])
				,Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE])
				,Convert.ToInt32(Page.Request.Params[KEYQIDCLASIFICACIONRUBRO])
				,Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]));		
		}


		private void MostrarDetalle(DataTable dtEstadoFinanciero)
		{
			if(dtEstadoFinanciero!=null)
			{gridDetalle.DataSource = dtEstadoFinanciero;}
			else
			{gridDetalle.DataSource = dtEstadoFinanciero;}
			gridDetalle.DataBind();
		}
		private void ObtenerDetalle()
		{
			int NroDig = Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOS]);
			string DigCuenta =Page.Request.Params[KEYQDIGCUENTA].ToString();
			ArrayList ListaData = new ArrayList();
			switch (NroDig)
			{
				case 2:
					//this.ibtnAtras.Visible=true;
					break;
				case 3:
					ListaData.Add(this.ObtenerDatos(2,DigCuenta));
					this.MostrarDetalleGrilla(ListaData);
					break;
				case 5:
					ListaData.Add(this.ObtenerDatos(2,DigCuenta.Substring(0,2)));
					ListaData.Add(this.ObtenerDatos(3,DigCuenta));
					this.MostrarDetalleGrilla(ListaData);
					break;
				case 10:
					ListaData.Add(this.ObtenerDatos(2,DigCuenta.Substring(0,2)));
					ListaData.Add(this.ObtenerDatos(3,DigCuenta.Substring(0,3)));
					ListaData.Add(this.ObtenerDatos(5,DigCuenta));
					this.MostrarDetalleGrilla(ListaData);
					break;

			}

		}
		private DataTable ObtenerDatos(int pNroDig,string pDigCuenta)
		{
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			return null;
			//ConsultarEstadosFinancierosMovimientosCorporativoPersonalizado
//			return oCEstadosFinancieros.ConsultarEstadosFinancierosMovimientosCorporativoPersonalizado
//				(Page.Request.Params[KEYQIDFECHA]
//				,Page.Request.QueryString[KEYQIDFORMATO]
//				,Page.Request.QueryString[KEYQIDREPORTE]
//				,Page.Request.QueryString[KEYQIDRUBRO]
//				,0
//				,Page.Request.Params[KEYQIDACUMULADO]
//				);
		}

		private void MostrarDetalleGrilla(ArrayList arrlData)
		{
			DataTable tblResumen = this.CrearTabla();
			for(int i=0;i<=arrlData.Count-1;i++)
			{
				DataRow myRow = tblResumen.NewRow();
				DataTable dtnew = (DataTable) arrlData[i];
				foreach(DataColumn dc in tblResumen.Columns)
				{myRow[dc.ColumnName.ToString()] = dtnew.Rows[0][dc.ColumnName.ToString()];}
				tblResumen.Rows.Add(myRow);
			}
			gridResumen.DataSource=tblResumen;
			gridResumen.DataBind();
		}

		private DataTable CrearTabla()
		{

			DataTable tblResumen = new DataTable(DATATABLERESUMEN); 
			string []NombreCampos = {"CuentaContable","NombreCuenta","PeruPresupuestoAnual","PeruEjecucionRealDelmesAnterior","PeruEjecucionRealDelmesActual","PeruEjecucionRealAcumulado","PeruProyectadoAnual","IquitosPresupuestoAnual","IquitosEjecucionRealDelmesAnterior","IquitosEjecucionRealDelmesActual","IquitosEjecucionRealAcumulado","IquitosProyectadoAnual"};
			string []TipodeDatos =  {"String","String","Double","Double","Double","Double","Double","Double","Double","Double","Double","Double"};
			for(int i = 0;i<= NombreCampos.Length-1;i++)
			{
				DataColumn Columna = new  DataColumn();
				Columna.DataType = System.Type.GetType(SYSTEM + TipodeDatos[i].ToString() );
				Columna.ColumnName = NombreCampos[i].ToString();
				tblResumen.Columns.Add(Columna);
			}
			return tblResumen;
		}


		public void LlenarJScript()
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add EstadosFinancierosCorporativoDetallePersonalizado.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void GeneraFecha()
		{FechaPeriodo =  Convert.ToDateTime(DateTime.DaysInMonth(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month) + Utilitario.Constantes.SEPARADORFECHA + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString().PadLeft(2,'0') + Utilitario.Constantes.SEPARADORFECHA  + Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString());}


		private void gridDetalle_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if (Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)
			{	
				e.Item.Cells[0].Style.Add("width","20%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[3].Style.Add(Utilitario.Constantes.DISPLAY, Utilitario.Constantes.NONE);
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.DISPLAY, Utilitario.Constantes.NONE);
				e.Item.Cells[8].Style.Add(Utilitario.Constantes.DISPLAY, Utilitario.Constantes.NONE);
				e.Item.Cells[10].Style.Add(Utilitario.Constantes.DISPLAY, Utilitario.Constantes.NONE);

				string visible = (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)? Utilitario.Constantes.NONE:"block";
				e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,visible);
				e.Item.Cells[9].Style.Add(Utilitario.Constantes.DISPLAY,visible);

			}
			this.GeneraFecha();
			#region Header
			if(e.Item.ItemType == ListItemType.Header)
			{
				string Prefijo = (Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)?TITULOAL:TITULODEL;

				#region Columnas de Datos de Ejecucion Sima Peru / Sima Iquitos
				//Datos de  Ejecucion
				//Mes Anterior
				if (FechaPeriodo.Month > 1)
				{
					#region Sima Peru Mes Anterior
					e.Item.Cells[1].Text = Prefijo + TITULOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month-1 ,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
					e.Item.Cells[1].Font.Size=7;
					#endregion
					#region Sima Iquitos Mes Anterior
					e.Item.Cells[6].Text = Prefijo + TITULOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month-1 ,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
					e.Item.Cells[6].Font.Size=7;
					#endregion
				}
				//Mes Actual
				#region Sima Peru Mes Actual
				e.Item.Cells[2].Text = Prefijo + TITULOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				e.Item.Cells[2].Font.Size=7;
				#endregion
				#region Sima Iquitos Mes Actual
				e.Item.Cells[7].Text = Prefijo + TITULOMES + Helper.ObtenerNombreMes(FechaPeriodo.Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto).ToUpper();
				e.Item.Cells[7].Font.Size=7;
				#endregion
				#endregion

				#region Columna de Datos de Presupuesto
				//Datos de Presupuesto
				#region Presupuesto Sima Peru
				e.Item.Cells[4].Text = TITULOPTO;
				e.Item.Cells[4].Font.Size=7;
				#endregion

				#region Sima - Iquitos
				e.Item.Cells[9].Text = TITULOPTO;
				e.Item.Cells[9].Font.Size=7;
				#endregion
				#endregion

				#region Columna de Acumulado Sima Peru / Sima Iquitos
				#region Sima Peru
				e.Item.Cells[3].Text = TITULOACUMULADO;
				e.Item.Cells[3].Font.Size=7;
				#endregion
				#region Sima Iquitos
				e.Item.Cells[8].Text = TITULOACUMULADO;
				e.Item.Cells[8].Font.Size=7;
				#endregion
				#endregion

				#region Columnas de Proyeccion Sima Peru / SIma Iquitos
				#region Sima Peru
				e.Item.Cells[5].Text = TITULOPROYECTADO;
				e.Item.Cells[5].Font.Size=7;
				#endregion

				#region Sima Iquitos
				e.Item.Cells[10].Text = TITULOPROYECTADO;
				e.Item.Cells[10].Font.Size=7;
				#endregion

				#endregion
			
			}
			#endregion

			#region Item
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) == Utilitario.Constantes.ValorConstanteCero ) 
				{
					//Sima Peru
					e.Item.Cells[1].Text=String.Empty;
					e.Item.Cells[2].Text=String.Empty;
					e.Item.Cells[3].Text=String.Empty;
					e.Item.Cells[4].Text=String.Empty;
					e.Item.Cells[5].Text=String.Empty;
					//Sima Iquitos
					e.Item.Cells[6].Text=String.Empty;
					e.Item.Cells[7].Text=String.Empty;
					e.Item.Cells[8].Text=String.Empty;
					e.Item.Cells[9].Text=String.Empty;
					e.Item.Cells[10].Text=String.Empty;
				}
				else
				{
					//Sima Peru
					e.Item.Cells[1].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[1].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[2].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[2].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[3].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[3].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[4].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[4].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[5].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[5].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					//Sima Iquitos
					e.Item.Cells[6].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[6].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[7].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[7].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[8].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[8].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[9].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[9].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					e.Item.Cells[10].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[10].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					//
				}
			}
			#endregion		
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			for(int i=2;i<=11;i++)
			{
				e.Item.Cells[i].Style.Add("width","7%");
			}

			if (Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == Utilitario.Constantes.ValorConstanteUno)
			{	
				e.Item.Cells[0].Style.Add("width","3%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[1].Style.Add("width","17%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[6].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[9].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[11].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);

				string visible = (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)? Utilitario.Constantes.NONE:"block";
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.DISPLAY,visible);
				e.Item.Cells[10].Style.Add(Utilitario.Constantes.DISPLAY,visible);

			}

			#region Item
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				for(int i=2;i<=11;i++)
				{
					e.Item.Cells[i].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
			}
			#endregion		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			for(int i=2;i<=11;i++)
			{
				e.Item.Cells[i].Style.Add("width","7%");
			}

			if (Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO]) == 1)
			{	
				e.Item.Cells[0].Style.Add("width","3%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[1].Style.Add("width","17%");//Cambia el Ancho de la Columna de conceptos
				e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[6].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[9].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
				e.Item.Cells[11].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);

				string visible = (Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORCOBRAR || Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]) == Utilitario.Constantes.KEYIDFORMATOCUENTASPORPAGAR)? Utilitario.Constantes.NONE:"block";
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.DISPLAY,visible);
				e.Item.Cells[10].Style.Add(Utilitario.Constantes.DISPLAY,visible);
			}
			

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;

				int NroDig=Convert.ToInt32(Page.Request.Params[KEYQNRODIGITOS]); 
				switch (NroDig)
				{
					case 2:
						NroDig = 3;
						break;
					case 3:
						NroDig=5;
						break;
					case 5:
						NroDig=10;
						break;
				}				
				
				for(int i=2;i<=11;i++)
				{
					e.Item.Cells[i].Text= Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text) /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
				}
				/*Calcula el Total por Empresa  si la Empresa es Peru*/
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}					
		}
	}
}
