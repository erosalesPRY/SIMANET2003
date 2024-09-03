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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarPersona_Contratista_Visita.
	/// </summary>
	public class AdministrarPersona_Contratista_Visita : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;


		
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnEliminarProg;
		protected System.Web.UI.WebControls.Button btnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroDoc;
		const string URLDETALLE = "DetallePersona_Contratista_Visita.aspx?";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdReg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hApellidosyNombres;

		const string KEYQIDREG="IdReg";
		const string KEYQAPPNOM="APMN";
		protected System.Web.UI.WebControls.ImageButton btnNroRel;
		const string KEYQDNI ="NroDNI";
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Page.GetPostBackEventReference(this, "MyEventArgumentName");
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Seguridad Industrial: Personal (Contratista-Visita)", this.ToString(),"Se consultó El Listado de personas (Contratista-Visitas).",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
					this.LlenarJScript();

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
					string msg = oException.Message.ToString();
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			this.btnNroRel.Click += new System.Web.UI.ImageClickEventHandler(this.btnNroRel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.LlenarGrillaOrdenamiento implementation
		}

		DataTable ObtenerDatos(){
			if(Session["dtTrabajador"]==null)
			{
				Session["dtTrabajador"]=(new CCCTT_Personal_Contratista_Visita()).Listar("0");
			}
			return (DataTable)Session["dtTrabajador"];
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;
				//grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dv.Count.ToString() + " de " + dt.Rows.Count.ToString();
				grid.CurrentPageIndex     = indicePagina;
				
			}
			else
			{
				grid.DataSource = dt;
			//	this.lblResultado.Visible = true;
			//	this.lblResultado.Text    = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			btnEliminar.Style.Add("display","none");
			ibtnEliminarProg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"Eliminar();");
			btnEliminar.Style.Add("display","none");
			btnNroRel.Style.Add("display","none");

			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()));
			this.btnNroRel.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPersona_Contratista_Visita.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				string parametros =KEYQDNI+ Utilitario.Constantes.SIGNOIGUAL + dr["NroDNI"].ToString()
								+ Utilitario.Constantes.SIGNOAMPERSON
								+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString();

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
												Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString())
												,Helper.MostrarVentana(URLDETALLE,parametros));

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hNroDoc",dr["NroDNI"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hIdReg",dr["IdReg"].ToString())
																,Helper.MostrarDatosEnCajaTexto("hApellidosyNombres",dr["ApellidoyNombres"].ToString())
																,"MostrarOcultar('" + ((dr["IdNacionalidad"].ToString().Equals("1"))?"none":"block")  + "');"
																);
				
				
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value=e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=e.SortExpression;
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string Pagina =URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString();
			Page.Response.Redirect(Pagina,true);

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dts  = (DataTable)Session["dtTrabajador"];
			ltlMensaje.Text = Helper.ElaborarFiltro(dts,"NroDNI;Nro de Documento","ApellidoyNombres;Apellidos y Nombres");
		}

		private void btnEliminar_Click(object sender, System.EventArgs e)
		{
			(new CCCTT_Trabajador()).Eliminar(hNroDoc.Value);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}


		private void btnNroRel_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(hIdReg.Value.Length>0)
			{
				string Pagina ="AdministrarTrabajadorNroDocRelacionado.aspx?" + KEYQIDREG + Utilitario.Constantes.SIGNOIGUAL + hIdReg.Value
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQAPPNOM + Utilitario.Constantes.SIGNOIGUAL + this.hApellidosyNombres.Value;

				Page.Response.Redirect(Pagina,true);
			}
			else
			{
				Helper.MsgBox("CAMBIO NRO DE DOCUMENTO","No se ha seleccionado registro de trabajador a modificar",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
		}
	}
}
