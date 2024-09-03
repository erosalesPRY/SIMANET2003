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

namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancierosPresupuestales
{
	/// <summary>
	/// Summary description for PopupImpresionEstadosFinancierosFormulacion.
	/// </summary>
	public class PopupImpresionEstadosFinancierosFormulacion : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
		#endregion Controles

		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQIDCENTRO = "idCentro";
		const string NOMBRECENTRO ="NombreCentro";

		//Tipo de Opcion Contable o Presupuestal
		const string KEYIDTIPOOPCION ="idOpcion";
		const string NOMBRETIPOOPCION ="NombreOpcion";

		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQIDACUMULADO = "Acumulado";

		const string KEYQIDNIVELEXPANDE = "NivelExp";
		const string KEYQIDCLASIFICACIONRUBRO = "RubroClasf";	

		//		const string KEYQIDPERIDO = "Periodo";
		//		const string KEYQIDMES = "Mes";
		const string KEYQIDNOMBREMES = "NombreMes";

		const string KEYQIDFECHA = "efFecha";

		const string KEYQNRODIGITOS ="NroDig";
		const string KEYQDIGCUENTA = "DigCuenta";

		const string KEYQNUEVOSSOLES = "MILNS";

		const string CONTROLINK = "hlkConcepto";


		//Campos de Cabecera
		const string CAMPOH1 = "LblAlMesT";
		const string CAMPOH2 = "lblDelMesT";
		const string CAMPOH3 = "lblPPTOalT";

		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string GRILLAVACIA="No existe";
		const string URLDETALLECOMPARATIVO = "EstadosFinancierosEvaluacion.aspx?";

		//Datagrid and DataTable
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOPTOPERIODO ="PRESUPUESTO PERIODO ";
		const string COLUMNAIDRUBRO ="IdRubro";
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();					
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.ColspanRowspanHeader();
					this.LlenarGrilla();
					this.Imprimir();
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CImpresion oCImpresion =  new CImpresion();
			DataTable dtImpresion =  oCImpresion.ObtenerDataImprimir();
			if(dtImpresion != null)
			{
				grid.DataSource = dtImpresion;
			}
			else
			{
				grid.DataSource = dtImpresion;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblTitulo.Text = CImpresion.ObtenerTituloReporteEstadosFinancieros();
			lblPeriodo.Text = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]).Year.ToString();			
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text=Helper.Imprimir();
		}

		public void Exportar()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				CNetAccessControl.RedirectPageError();
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add PopupImpresionEstadosFinancierosFormulacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ColspanRowspanHeader()
		{
			DateTime Fecha = Convert.ToDateTime(HttpContext.Current.Session[KEYQIDFECHA]);
			TableCell cell = null;
			m_add.DatagridToDecorate = grid;
			ArrayList header = new ArrayList();


			cell = new TableCell();
			cell.Text = TITULOCONCEPTO;
			cell.RowSpan = 2;
			cell.VerticalAlign = VerticalAlign.Middle;
			header.Add(cell);
			cell = new TableCell();
			cell.Text = TITULOPTOPERIODO + Fecha.Year.ToString();
			cell.ColumnSpan = ((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO])== Utilitario.Constantes.ValorConstanteUno)? 16:17);
			cell.HorizontalAlign = HorizontalAlign.Center;
			header.Add(cell);

			m_add.AddMergeHeader(header);
			
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[0].Style.Add("width","18%");
			e.Item.Cells[e.Item.Cells.Count-1].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(HttpContext.Current.Session[KEYQIDACUMULADO])==1)? Utilitario.Constantes.NONE:Utilitario.Constantes.BLOCK));
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()]) == Utilitario.Constantes.ValorConstanteCero) 
				{
					for (int i = 1;i<=13;i++)
					{e.Item.Cells[i].Text = String.Empty;}
				}
				else
				{
					double Totalppto=0;
					for (int i = 1;i<=12;i++)
					{
						Totalppto +=Convert.ToDouble(e.Item.Cells[i].Text);

						if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
						{
							e.Item.Cells[i].Text = Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}

						/*
						if (System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.KEYVERMILESNUEVOSSOLES] == Utilitario.Constantes.SIVERMILES)
						{
							e.Item.Cells[i].Text = Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						*/
					}
					//Totaliza
					if (System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.KEYVERMILESNUEVOSSOLES] == Utilitario.Constantes.SIVERMILES)
					{
						e.Item.Cells[e.Item.Cells.Count-1].Text = Convert.ToDouble(Totalppto /Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
					}
					else
					{
						e.Item.Cells[e.Item.Cells.Count-1].Text = Totalppto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
					}

					//Exepciones del Flujo de Caja
					if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==8) && (Convert.ToDouble(HttpContext.Current.Session[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))
					{
						e.Item.Cells[e.Item.Cells.Count-1].Text = e.Item.Cells[1].Text;
					}
					else if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==9) && (Convert.ToDouble(HttpContext.Current.Session[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))					
					{
						e.Item.Cells[e.Item.Cells.Count-1].Text = e.Item.Cells[e.Item.Cells.Count-2].Text;
					}
				}
				
				Utilitario.Helper.ConfiguraNodosTreeview(e,
														2,
														5/*Convert.ToInt32(HttpContext.Current.Session[KEYQIDNIVELEXPANDE])*/,
														dr,
														String.Empty);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				//				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != 0 )
				//				{
				//					e.Item.BackColor = Color.LightYellow;
				//					e.Item.Font.Bold = true;
				//				}

			}
		}
	}
}
