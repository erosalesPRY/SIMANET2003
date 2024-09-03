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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;



namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto
{
	/// <summary>
	/// Summary description for ConsultarResumeEvaluacionPresupuestal.
	/// </summary>
	public class ConsultarResumeEvaluacionPresupuestal : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

	
		#region CONSTANTES
			const string COLUMNAPERIODO ="Periodo";
			const string GRILLAVACIA="No existe Datos";
			const string ESTILOFONT ="font";
			const string ESTILOBOLD ="bold";
			const string STYLEITEMGRILLASINCOlOR ="itemgrillasinColor";
			const string IMGPLUS ="/imagenes/tree/plus.gif";

			const string KEYQPERIODO ="Periodo";
			const string KEYQMES ="Mes";
			const string KEYQPPTO = "VISTAPPTO";
			const string VISTAPPTOPRINCIPAL="Principales";

		#endregion
		protected System.Web.UI.WebControls.Label lblPagina;
		#region Variables	
			int idFila =0;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
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
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					string msgb =oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
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
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			if (Page.Request.Params[KEYQPPTO].ToString()==VISTAPPTOPRINCIPAL)
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarResumenEvaluacionPresupuesto(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQMES]));
			}
			else
			{
				return ((CPresupuesto) new  CPresupuesto()).ConsultarResumenEvaluacionPresupuestoAuxiliar(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQMES]));
			}
			//return new DataTable();
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}





		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarResumeEvaluacionPresupuestal.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add("idCentroOperativo","0");
				e.Item.Attributes.Add("idTipoPresupuesto",dr["idTipoPresupuesto"].ToString());
				/*e.Item.Attributes.Add("idFilaReferencia",idFila.ToString());
				e.Item.Attributes.Add("DatosCargados","NO");
				e.Item.Attributes.Add("NodoPadre","SI");
				//e.Item.Attributes.Add("IdNivel",idFila.ToString());
				e.Item.Attributes.Add("IdNivel","0");
				e.Item.Attributes.Add("CodigoNivel",idFila.ToString());
				e.Item.Cells[0].Controls.Add(CrearNodoRaiz(e.Item.Cells[0].Text,idFila));*/

				e.Item.Cells[0].Controls.Add(Helper.CrearNodoRaiz(e,e.Item.Cells[0].Text,"ObtenerDetalledeCentroporTipodePresupuesto" ,true));

				e.Item.Cells[1].Controls.Add(HtmlTableMontosPorEmpresa(Convert.ToDouble(dr["MontoPresupuestadoPeru"])
																		,Convert.ToDouble(dr["MontoEjecutadoPeru"])
																		,Convert.ToDouble(dr["MontoSaldoPeru"])
																		));

				e.Item.Cells[2].Controls.Add(HtmlTableMontosPorEmpresa(Convert.ToDouble(dr["MontoPresupuestadoIquitos"])
																	,Convert.ToDouble(dr["MontoEjecutadoIquitos"])
																	,Convert.ToDouble(dr["MontoSaldoIquitos"])
																	));



				
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			idFila++;
		}

		private HtmlTable HtmlTableMontosPorEmpresa(double MontoPresupuesto,double MontoEjecutado,double MontoSaldo)
		{
			HtmlTable oHtmlTable = Utilitario.Helper.CrearHtmlTabla(1,3);
			oHtmlTable.Rows[0].Cells[0].InnerText = MontoPresupuesto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			oHtmlTable.Rows[0].Cells[0].Attributes.Add("Class",STYLEITEMGRILLASINCOlOR);
			oHtmlTable.Rows[0].Cells[0].Attributes.Add("Width","33.33%");
			oHtmlTable.Rows[0].Cells[0].Attributes.Add("align","right");
			

			oHtmlTable.Rows[0].Cells[1].InnerText = MontoEjecutado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			oHtmlTable.Rows[0].Cells[1].Attributes.Add("Class",STYLEITEMGRILLASINCOlOR);
			oHtmlTable.Rows[0].Cells[1].Attributes.Add("Width","33.33%");
			oHtmlTable.Rows[0].Cells[1].Attributes.Add("align","right");

			oHtmlTable.Rows[0].Cells[2].InnerText = MontoSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			oHtmlTable.Rows[0].Cells[2].Attributes.Add("Class",STYLEITEMGRILLASINCOlOR);
			oHtmlTable.Rows[0].Cells[2].Attributes.Add("Width","33.33%");
			oHtmlTable.Rows[0].Cells[2].Attributes.Add("align","right");
			oHtmlTable.Attributes.Add("Width","100%");
			return oHtmlTable;
		}

		private HtmlTable CrearNodoRaiz(string Descripcion,int idFilaReferencia)
		{
			HtmlTable tbl = new HtmlTable();
			HtmlTableRow Fila = new HtmlTableRow();
			HtmlImage imagen;
			HtmlTableCell Celda;

			Celda = new HtmlTableCell();
			imagen = new HtmlImage();imagen.Src =Session[Utilitario.Constantes.SPATHAPPWEB].ToString() + IMGPLUS;
			imagen.ID ="img";
			imagen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"SIMA.Utilitario.Helper.General.Treeview.Nodo.Adicionar(this," + idFilaReferencia.ToString() + ")");
			Celda.Controls.Add(imagen);
			Fila.Controls.Add(Celda);

			Celda = new HtmlTableCell();
			Celda.InnerText = Descripcion;
			Celda.NoWrap=true;
			Celda.Style.Add(ESTILOFONT,ESTILOBOLD);
			
			Fila.Controls.Add(Celda);
			Fila.Attributes.Add("Class",STYLEITEMGRILLASINCOlOR);
			tbl.Controls.Add(Fila);
			
			return tbl;
		}


		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ddlbPeriodo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
		}

		private void dddblMes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(String.Empty,Constantes.INDICEPAGINADEFAULT);	
		}


	}
}

