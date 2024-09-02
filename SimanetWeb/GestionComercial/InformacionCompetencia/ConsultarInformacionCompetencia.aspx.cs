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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using System.IO;
using SIMA.EntidadesNegocio;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionCompetencia
{
	/// <summary>
	/// Summary description for ConsultarInformacionCompetencia.
	/// </summary>
	public class ConsultarInformacionCompetencia : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected projDataGridWeb.DataGridWeb dgArchivoConsulta;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdArchivo";

		//Nombres de Controles
		const string CONTROLINK = "hlkIdArchivoConsulta";
		const string KEYQIDTIPOARCHIVO = "IdTipoArchivo";	
		const string CONTROLLBL = "lblDescripcion";	
							
		//Key Session y QueryString
		const string KEYQID = "Id";
		
		//JScript
			
		//Otros
		const string GRILLAVACIA ="No existe ningún Archivo.";  
		const string TITULOREGISTRO = "REGISTRO ";

		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";
		const int POSICIONFOOTERTOTAL = 2;
		const int POSICIONINICIALCOMBO = 0;
		#endregion

		#region Variables

		int REGISTROACTUAL;	

		#endregion Variables

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.ObtenerTituloFormulario();

				try
				{
					this.ConfigurarAccesoControles();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Modulo Informativo",this.ToString(),"Se consultó Informativo WEB.",Enumerados.NivelesErrorLog.I.ToString()));
                    					
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.dgArchivoConsulta.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgArchivoConsulta_SortCommand);
			this.dgArchivoConsulta.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgArchivoConsulta_PageIndexChanged);
			this.dgArchivoConsulta.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgArchivoConsulta_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarInformacionCompetencia.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarInformacionCompetencia.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			CArchivo oCArchivo =  new CArchivo();
			DataTable dtArchivo = oCArchivo.ListarTodosPorTipo(Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOARCHIVO]).ToString());
			
			if(dtArchivo!=null)
			{
				DataView dwArchivo = dtArchivo.DefaultView;
				dwArchivo.Sort = columnaOrdenar ;
				dgArchivoConsulta.DataSource = dwArchivo;
				dgArchivoConsulta.Columns[0].FooterText = TEXTOFOOTERTOTAL;
				dgArchivoConsulta.Columns[POSICIONFOOTERTOTAL].FooterText = dwArchivo.Count.ToString();
			}
			else
			{
				dgArchivoConsulta.DataSource = dtArchivo;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				if(indicePagina==0)
				{
					REGISTROACTUAL=0;
				}
				else
				{
					REGISTROACTUAL=(indicePagina * dgArchivoConsulta.PageSize);
				}

				dgArchivoConsulta.DataBind();		
			}
			catch	 (Exception a)
			{
				string b = a.Message.ToString();
				dgArchivoConsulta.CurrentPageIndex = 0;
				dgArchivoConsulta.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarInformacionCompetencia.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarInformacionCompetencia.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarInformacionCompetencia.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarInformacionCompetencia.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarInformacionCompetencia.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarInformacionCompetencia.Exportar implementation
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
			return false;
		}

		#endregion

		public void ObtenerTituloFormulario()
		{
			string descripcion = CTablaTablas.ObtenerDescripcionCodigo(Convert.ToInt32(Enumerados.TablasTabla.TipoArchivo),Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOARCHIVO]));
			this.lblTitulo.Text = TITULOREGISTRO + descripcion.ToString();
		}
		private void dgArchivoConsulta_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk = (HyperLink)e.Item.Cells[2].FindControl(CONTROLINK);

				string[] res = Utilitario.Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasArchivo.Ruta.ToString()])).Split('\\');
				int i=res.GetUpperBound(0);
				hlk.Text =res[i];
				hlk.NavigateUrl = Utilitario.Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasArchivo.Ruta.ToString()]));
				hlk.Target= "_new";

				Label lbl = (Label)e.Item.Cells[3].FindControl(CONTROLLBL);
				lbl.Text =  Utilitario.Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasArchivo.Descripcion.ToString()]));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(dgArchivoConsulta.CurrentPageIndex,dgArchivoConsulta.PageSize,e.Item.ItemIndex);
			}	
		}
		
		private void dgArchivoConsulta_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgArchivoConsulta.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void dgArchivoConsulta_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}
	}
}
