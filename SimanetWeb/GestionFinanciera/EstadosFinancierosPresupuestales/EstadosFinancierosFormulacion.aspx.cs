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
	/// Summary description for EstadosFinancierosFormulacion.
	/// </summary>
	public class EstadosFinancierosFormulacion : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDEMPRESA = "idEmp";
		const string KEYQIDCENTRO = "idCentro";
		const string NOMBRECENTRO ="NombreCentro";

		//Nuevos Key Session y QueryString
		const string KEYQOBSCALLAO = "ObsCallao";
		const string KEYQOBSCHIMBOTE = "ObsChimbote";
		const string KEYQOBSIQUITOS = "ObsIquitos";

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

		const string CONTROLINK = "hlkConcepto";


		//Campos de Cabecera
		const string CAMPOH1 = "LblAlMesT";
		const string CAMPOH2 = "lblDelMesT";
		const string CAMPOH3 = "lblPPTOalT";

		const int NRODIGINI = 2;
		const int DIGCTA = 0;
			

		const string GRILLAVACIA="No existe";

		//URL
		const string URLDETALLECOMPARATIVO = "EstadosFinancierosEvaluacion.aspx?";
		const string URLIMPRESION = "PopupImpresionEstadosFinancierosFormulacion.aspx";

		//DataTable and DataGrid
		const string TITULOCONCEPTO ="CONCEPTO";
		const string TITULOPTOPERIODO ="PRESUPUESTO PERIODO ";
		const string COLUMNAIDRUBRO ="IdRubro";

		const string KEYQNUEVOSSOLES = "MILNS";
        	

		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;

			protected System.Web.UI.WebControls.Repeater Repeater1;
			protected projDataGridWeb.DataGridWeb grid;
			private ASPNetDatagridDecorator m_add = new ASPNetDatagridDecorator();
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
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
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.ColspanRowspanHeader();
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
			// Put user code to initialize the page here
		}

		private void ColspanRowspanHeader()
		{
			DateTime Fecha = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]);
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
			cell.ColumnSpan = ((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO])== Utilitario.Constantes.ValorConstanteUno)? 16:17);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CEstadoFinancieroPresupuestal oCEstadoFinancieroPresupuestal = new CEstadoFinancieroPresupuestal();

			DataTable dtEstadoFinanciero = oCEstadoFinancieroPresupuestal.ConsultarEstadosFinancierosPresupuestalesFormulacionporEmpresa(
																			Convert.ToInt32(Page.Request.Params[KEYQIDEMPRESA])
																			,Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
																			,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
																			,Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])
																			,Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE])
																			,Utilitario.Constantes.IDDEFAULT
																			,Convert.ToInt32(Page.Request.QueryString[KEYQIDNIVELEXPANDE])
																			,Convert.ToInt32(Page.Request.QueryString[KEYQIDCLASIFICACIONRUBRO])
																			,Convert.ToInt32(Page.Request.QueryString[KEYQIDACUMULADO])
																			);
			
			if(dtEstadoFinanciero!=null)
			{
				#region Impresion
					CImpresion oCImpresion = new CImpresion();
					oCImpresion.GuardarDataImprimirExportar(dtEstadoFinanciero, 
						Convert.ToString(Page.Request.Params[KEYQIDFORMATO]),
						Convert.ToString(Page.Request.Params[KEYQIDREPORTE]),
						Convert.ToString(Page.Request.Params[KEYQIDNIVELEXPANDE]),
						Convert.ToString(Page.Request.Params[KEYQIDCLASIFICACIONRUBRO]),
						Convert.ToString(Page.Request.Params[KEYQIDACUMULADO]),
						Convert.ToString(Page.Request.Params[KEYQIDFECHA]),
						Convert.ToString(Page.Request.Params[KEYQIDEMPRESA]),	//Cambiar por KEYQIDEMPRESA
						Convert.ToString(Page.Request.Params[KEYQIDNOMBREFORMATO]));	

				#endregion Impresion
				grid.DataSource = dtEstadoFinanciero;
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			grid.DataBind();
			// TODO:  Add EstadosFinancierosFormulacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
			// TODO:  Add EstadosFinancierosFormulacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add EstadosFinancierosFormulacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add EstadosFinancierosFormulacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblPeriodo.Text = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString();
			lblPagina.Text = Page.Request.Params[KEYQIDNOMBREFORMATO].ToString().ToUpper();
			// TODO:  Add EstadosFinancierosFormulacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add EstadosFinancierosFormulacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add EstadosFinancierosFormulacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add EstadosFinancierosFormulacion.Exportar implementation
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
			// TODO:  Add EstadosFinancierosFormulacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ddlbEmpresa_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[0].Style.Add("width","18%");
			e.Item.Cells[e.Item.Cells.Count-1].Style.Add(Utilitario.Constantes.DISPLAY,((Convert.ToInt32(Page.Request.Params[KEYQIDACUMULADO])== Utilitario.Constantes.ValorConstanteUno)? Utilitario.Constantes.NONE: Utilitario.Constantes.BLOCK));
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

						if(Session[KEYQNUEVOSSOLES] ==null)
						{
							e.Item.Cells[i].Text = Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
						}
						else
						{
							if (Session[KEYQNUEVOSSOLES].ToString() == Utilitario.Constantes.SIVERMILES)
							{
								e.Item.Cells[i].Text = Convert.ToDouble(Convert.ToDouble(e.Item.Cells[i].Text)/Utilitario.Constantes.MILES).ToString(Utilitario.Constantes.FORMATODECIMAL5);
							}
							else
							{
								e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL5);
							}
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
					if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==8) && (Convert.ToDouble(Page.Request.Params[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))
					{
						e.Item.Cells[e.Item.Cells.Count-1].Text = e.Item.Cells[1].Text;
					}
					else if ((Convert.ToInt32(dr[COLUMNAIDRUBRO])==9) && (Convert.ToDouble(Page.Request.Params[KEYQIDFORMATO]) ==Utilitario.Constantes.KEYIDFORMATOFLUJODECAJA))					
					{
						e.Item.Cells[e.Item.Cells.Count-1].Text = e.Item.Cells[e.Item.Cells.Count-2].Text;
					}
				}
				
				Utilitario.Helper.ConfiguraNodosTreeview(e,2,Convert.ToInt32(Page.Request.Params[KEYQIDNIVELEXPANDE]),dr,String.Empty);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

//				if (Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()]) != 0 )
//				{
//					e.Item.BackColor = Color.LightYellow;
//					e.Item.Font.Bold = true;
//				}

			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.ReiniciarSession();
			this.LlenarJScript();
			this.LlenarCombos();
			this.LlenarDatos();
			this.ColspanRowspanHeader();
			this.LlenarGrilla();
			this.Imprimir();
		}
	}
}
