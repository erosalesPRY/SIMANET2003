using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for AdministrarRecomendacionesPorObservaciones.
	/// </summary>
	public class AdministrarRecomendacionesPorObservaciones : System.Web.UI.Page,IPaginaBase
	{

		const string GRILLAVACIA ="No existe ningún Documento para Control.";  

		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAcciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRecomendacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAnio;
		

		const string KEYQDESCRIPCIONDOC = "DesDoc";

		const string KEYQIDOBSERVACION = "IdObservacion";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYQIDRECOMENDACION = "IdRecomendacion";
		const string KEYQPERIODO = "Periodo";
		const string KEYQDESCRIPCIONRECOMENDACION = "DescRecomendacion";

		const string URLDETALLE="DetalleRecomendacion.aspx?";
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblObservacion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcionRecom;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		const string URLACCIONESPORRECOMENDACION="AdministrarAccionesPorRecomendacion.aspx?";


		#region Propiedades de pagina adiciopnal
			private int IdObservacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBSERVACION]);}
			}
			private string DescripcionObservacion
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);}
			}
			private string DescripcionDocumento
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCIONDOC]);}
			}

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					//Graba en el Log la acción ejecutada
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se consultó los ControlInterno Embargados.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnAcciones.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAcciones_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt =(new CRecomendacionesPorObservacion()).ConsultarRecomendaciones(this.IdObservacion,0,0);

			if(dt!=null)
			{
				grid.DataSource = dt;
				grid.CurrentPageIndex =indicePagina;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception a)
			{
				string b = a.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			LblObservacion.Text = this.DescripcionObservacion;
			lblTitulo.Text = this.DescripcionDocumento;
		}

		public void LlenarJScript()
		{
			ibtnAcciones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort","hIdRecomendacion","hIdAnio"));
			ibtnEliminar.Style["display"]="none";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarRecomendacionesPorObservaciones.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL +  this.IdObservacion
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL +  this.DescripcionObservacion
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString()
												);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hIdRecomendacion",dr["IdRecomendacion"].ToString())
																+ Helper.MostrarDatosEnCajaTexto("hIdAnio",dr["Periodo"].ToString())
																+ Helper.MostrarDatosEnCajaTexto("hDescripcionRecom",dr["Observacion"].ToString())
															  );

				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0]
					,"HistorialIrAdelantePersonalizado('hGridPaginaSort;hGridPagina')"
					,Helper.Response.Redirec(Page.Request.ApplicationPath +"/GestionControlInstitucional/"+ URLDETALLE + KEYQIDRECOMENDACION + Utilitario.Constantes.SIGNOIGUAL + dr["IdRecomendacion"].ToString() 
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr["Periodo"].ToString() 
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL +  this.IdObservacion.ToString()
												+ Utilitario.Constantes.SIGNOAMPERSON  
												+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL + this.DescripcionObservacion
												+ Utilitario.Constantes.SIGNOAMPERSON 
												+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.M.ToString(),false)
											);

				
				//Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

			}		

		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAcciones_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hIdRecomendacion.Value.Length==0)
			{
				Helper.MsgBox("ACCIONES","No se ha seleccionado registro de recomendación!!...Por favor seleccione uno",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
			else
			{
				Page.Response.Redirect(URLACCIONESPORRECOMENDACION 
					+ KEYQDESCRIPCIONDOC + Utilitario.Constantes.SIGNOIGUAL +  this.DescripcionDocumento
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDOBSERVACION + Utilitario.Constantes.SIGNOIGUAL +  this.IdObservacion
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQDESCRIPCION + Utilitario.Constantes.SIGNOIGUAL +  this.DescripcionObservacion.Replace("\"","")
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDRECOMENDACION + Utilitario.Constantes.SIGNOIGUAL +  this.hIdRecomendacion.Value
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL +  this.hIdAnio.Value
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQDESCRIPCIONRECOMENDACION  + Utilitario.Constantes.SIGNOIGUAL +  this.hDescripcionRecom.Value.Replace("\"","")
					);
			}
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			(new CRecomendacionesPorObservacion()).Eliminar(Convert.ToInt32(hIdAnio.Value),Convert.ToInt32(this.hIdRecomendacion.Value));
			this.hIdAnio.Value="";
			this.hIdRecomendacion.Value="";
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}
	}
}
