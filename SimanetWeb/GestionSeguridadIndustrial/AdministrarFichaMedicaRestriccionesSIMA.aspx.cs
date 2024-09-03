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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarFichaMedicaRestriccionesSIMA.
	/// </summary>
	public class AdministrarFichaMedicaRestriccionesSIMA : System.Web.UI.Page,IPaginaBase
	{
		protected projDataGridWeb.DataGridWeb grid;
	
		const string KEYQPR ="NroPR";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDFICHA ="IdFicha";
		const string KEYQNOMTRAB ="NomTrab";
		const string KEYQIDPERMANENTE ="IdPerm";

		private string NroPR
		{
			get{return Page.Request.Params[KEYQPR];}
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdFicha
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFICHA]);}
		}
		private int IdPermanente
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPERMANENTE]);}
		}
		

		private string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQNOMTRAB];}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					//this.CargarModoPagina();	
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public DataTable ObtenerDatos()
		{
			return (new CCCTT_ExamenMedicoRestriciones()).ListarTodosGrilla(this.Periodo,this.IdFicha,this.IdPermanente);
		}

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
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

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFichaMedicaRestriccionesSIMA.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,"");
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				CheckBox chk = (CheckBox)e.Item.Cells[2].FindControl("chkRestriccion");
				chk.Checked= ((dr["Existe"].ToString()!="0")?true:false);
				chk.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="AgregarRestriccion('" + this.Periodo.ToString() + "','" + this.IdFicha.ToString() + "','"+ dr["IdRestriccion"].ToString()  +"',this);";

			}
		}
	}
}
