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
	/// Summary description for AdministrarTrabajadorNroDocRelacionado.
	/// </summary>
	public class AdministrarTrabajadorNroDocRelacionado : System.Web.UI.Page,IPaginaBase	
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroDoc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Button btnGrabar;

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblApellidosyNombres;
	
		const string KEYQIDREG="IdReg";
		const string KEYQAPPNOM="APMN";

		public string IdReg
		{
			get{return Page.Request.Params[KEYQIDREG];}
		}
		public string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQAPPNOM];}
		}

		string ParamArgument="";

		private void Page_Load(object sender, System.EventArgs e)
		{
			Page.GetPostBackEventReference(this, "MyEventArgumentName");

			ParamArgument=Page.Request.Params["__EVENTARGUMENT"];

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
			this.btnGrabar.Click += new System.EventHandler(this.btnGrabar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos()
		{
			return(new CCCTT_Personal_Contratista_Visita()).ListarNroRelacionado(this.IdReg);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				grid.DataSource = dv;
				grid.CurrentPageIndex     = indicePagina;
				
			}
			else
			{
				grid.DataSource = dt;
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
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblApellidosyNombres.Text = this.ApellidosyNombres;
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarTrabajadorNroDocRelacionado.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				TextBox txtNro = (TextBox)e.Item.Cells[2].FindControl("txtNroDocNew");
				txtNro.Text = dr["NroDocNew"].ToString();
				if(dr["NroDocNew"].ToString().Length>0)
				{
					txtNro.Enabled=false;
				}
				else{
					txtNro.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeypress.ToString(),"CrearNuevoNroDOc('" + dr["NroDocOld"].ToString() + "',this);");
				}
				
			}
		}

		private void btnGrabar_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(ParamArgument.Length>0)
				{
					string[] _params = ParamArgument.Split('|');
					(new CCCTT_Trabajadores()).ActualizarNroDoc(this.IdReg,_params[1], _params[0] );
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
				}
			}
			catch(Exception ex){
				Helper.MsgBox("CAMBIO DE NRO DOC",ex.Message.ToString(),Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
		}
	}
}
