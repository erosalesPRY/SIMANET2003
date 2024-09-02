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
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for AdministrarGrupoFormatos.
	/// </summary>
	public class AdministrarGrupoFormatos : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
		const string URLPAGINAFORMATO="/General/Formato/DefaultFormatos.aspx?";
		const string URLPAGINAFORMATODETALLE="/General/Formato/DetalleGrupoFormatos.aspx?";

		const string BTNFORMATO="ibtnFormato";

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroPag;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					Helper.ReestablecerPagina();
					this.LlenarGrilla();
					
				}
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(Page.Request.ApplicationPath + URLPAGINAFORMATODETALLE + Constantes.KEYMODOPAGINA + Constantes.SIGNOIGUAL +  Enumerados.ModoPagina.N.ToString());
		}
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = (new  CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.GrupodeFormatos));
			if(dt!=null)
			{
				grid.DataSource = dt;
				grid.CurrentPageIndex=Convert.ToInt32(this.hNroPag.Value); 
			}
			else
			{
				grid.DataSource = dt;
				//	lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarGrupoFormatos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarGrupoFormatos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarGrupoFormatos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarGrupoFormatos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Enumerados.EventosJavaScript.OnMouseDown.ToString(),Helper.HistorialIrAdelantePersonalizado("hNroPag"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarGrupoFormatos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarGrupoFormatos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarGrupoFormatos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarGrupoFormatos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarGrupoFormatos.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarGrupoFormatos.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarGrupoFormatos.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarGrupoFormatos.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarGrupoFormatos.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarGrupoFormatos.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarGrupoFormatos.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarGrupoFormatos.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarGrupoFormatos.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarGrupoFormatos.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarGrupoFormatos.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string Parametros=KEYQIDGRUPOFORMATO + Utilitario.Constantes.SIGNOIGUAL + dr[Enumerados.ColumnasTablasTablas.Codigo.ToString()].ToString()
									+ Utilitario.Constantes.SIGNOAMPERSON
									+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
											Helper.HistorialIrAdelantePersonalizado("hNroPag")
											,Helper.MostrarVentana(Page.Request.ApplicationPath + URLPAGINAFORMATODETALLE + Parametros 
																								+ Utilitario.Constantes.SIGNOAMPERSON 
																								+ Constantes.KEYMODOPAGINA + Constantes.SIGNOIGUAL +  Enumerados.ModoPagina.M.ToString()
																								));

				HtmlImage oimg = (HtmlImage)e.Item.Cells[3].FindControl(BTNFORMATO);
				oimg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),Helper.HistorialIrAdelantePersonalizado("hNroPag") + Helper.MostrarVentana(Page.Request.ApplicationPath + URLPAGINAFORMATO + Parametros));

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hNroPag.Value = e.NewPageIndex.ToString();
			this.LlenarGrilla();
		}
	}
}
