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
	/// Summary description for TiposdePresupuestoEvaluacion.
	/// </summary>
	public class TiposdePresupuestoEvaluacion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region CONSTANTES
			const string COLUMNAPERIODO ="Periodo";
			const string GRILLAVACIA="No existe Datos";
			const string ESTILOFONT ="font";
			const string ESTILOBOLD ="bold";
			const string STYLEITEMGRILLASINCOlOR ="itemgrillasinColor";
			const string IMGPLUS ="/imagenes/tree/plus.gif";
			const string KEYQPERIODO ="Periodo";
			const string KEYQMES ="Mes";
			const string KEYQANIO="anio";
			const string KEYMES="mes";
		#endregion

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DropDownList dddblMes;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbPeriodo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidTabSelect;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellHeader;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellMenu;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList ddlVista;
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.ImageButton imgXLS;
		protected System.Web.UI.WebControls.Button cmdPartidas123;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					if(Page.Request.Params[KEYMES]!=null&& Page.Request.Params[KEYQANIO]!=null)
					{
					 CellHeader.Visible=false;
					 CellMenu.Visible=false;
					}
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					Utilitario.Helper.ReestablecerPagina(this);
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
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.imgXLS.Click += new System.Web.UI.ImageClickEventHandler(this.imgXLS_Click);
			this.cmdPartidas123.Click += new System.EventHandler(this.cmdPartidas123_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarPeriodoContable();
		}

		private void LlenarPeriodoContable()
		{
			CPeriodoContable oCPeriodoContable = new CPeriodoContable();
			ddlbPeriodo.DataSource = oCPeriodoContable.ListarPeriodo();
			ddlbPeriodo.DataValueField=COLUMNAPERIODO;
			ddlbPeriodo.DataTextField=COLUMNAPERIODO;
			ddlbPeriodo.DataBind();
			if(Page.Request.Params[KEYMES]!=null&& Page.Request.Params[KEYQANIO]!=null)
			{
				ListItem item;
				item = ddlbPeriodo.Items.FindByText(Page.Request.Params[KEYQANIO].ToString());
				if (item !=null){item.Selected = true;}

				dddblMes.SelectedItem.Text=Page.Request.Params[KEYMES].ToString();
				
			}
			else
			{
				if(Page.Request.Params[KEYQPERIODO]==null)
				{
					ListItem item;
					item = ddlbPeriodo.Items.FindByText(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Year.ToString());
					if (item !=null){item.Selected = true;}

					item = dddblMes.Items.FindByValue(SIMA.Utilitario.Helper.FechaSimanet.ObtenerFechaSesion().Month.ToString());
					if (item !=null){item.Selected = true;}
				}	
				else
				{
					ListItem item;
					item = ddlbPeriodo.Items.FindByText(Page.Request.Params[KEYQPERIODO].ToString());
					if (item !=null){item.Selected = true;}

					item = dddblMes.Items.FindByValue(Page.Request.Params[KEYQMES].ToString());
					if (item !=null){item.Selected = true;}
				
				}
			}
		}


		public void LlenarDatos()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add TiposdePresupuestoEvaluacion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void imgXLS_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dto=(new CPresupuesto()).ListarPresupuestoToXLS(Convert.ToInt32(ddlbPeriodo.SelectedValue));
				try
				{
					DataView dv = dto.DefaultView;
					//dv.RowFilter="NroCentroCosto='400102'";
					DataTable dt1 =  Helper.DataViewTODataTable(dv);
					dt1.TableName="FINuspNTADExportarPresupuestoXLS";
					DataSet dsSrc= new DataSet("Reportes");

					dsSrc.Tables.Add(dt1);
					Helper.Archivo.GenerarReporteToXls(305,dsSrc,true);

				}
				catch(Exception ex)
				{
					int i=0; 
					i++;
				}

		}

		private void cmdPartidas123_Click(object sender, System.EventArgs e)
		{
			try
			{
				int Periodo = Convert.ToInt32(this.ddlbPeriodo.SelectedValue);
				int Prc=(new CPeriodo()).EstadoProcesoPeriodoPPTO(Periodo);
				if(Prc==1)
				{
					(new CPresupuesto()).ImportarRequerimientoPorItemCentroCosto(Periodo);
				}
			}
			catch(Exception ex){
				Helper.MsgBox("Error",ex.Message,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
		
		}
	}
}
