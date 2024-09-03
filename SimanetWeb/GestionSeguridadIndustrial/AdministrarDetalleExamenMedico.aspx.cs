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
	/// Summary description for AdministrarDetalleExamenMedico.
	/// </summary>
	public class AdministrarDetalleExamenMedico : System.Web.UI.Page,IPaginaBase ,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.TextBox txtNombreCM;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblDisponible;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label LblHabilitado;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtCentroMedico;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroMedico;
		protected System.Web.UI.WebControls.TextBox txtFechaInicio;
		protected System.Web.UI.WebControls.TextBox txtFechaVencimiento;
		protected System.Web.UI.WebControls.Label lblResultado;
	



		
		protected System.Web.UI.WebControls.TextBox txtNombreAptitud;
		protected System.Web.UI.WebControls.TextBox txtNombreToxicologico;
		protected System.Web.UI.WebControls.TextBox txtTipoEMO;
		
		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEXAMEN ="idExa";
		const string KEYQNOMTRAB ="NomTrab";

		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdExamen
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDEXAMEN]);}
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
					this.CargarModoPagina();	
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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			this.CargarModoModificar();
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			txtTrabajador.ReadOnly=true;
			ExamenMedicoBE oExamenMedicoBE=(ExamenMedicoBE) (new CCCTT_ExamenMedicoHistorial()).ListarDetalle(this.NroDNI,this.Periodo,this.IdExamen);
			txtTrabajador.Text = oExamenMedicoBE.ApellidosyNombres;
			txtCentroMedico.Text=oExamenMedicoBE.NombreCentroMedico;
			txtFechaInicio.Text=oExamenMedicoBE.FechaInicio.ToShortDateString();
			txtFechaVencimiento.Text=oExamenMedicoBE.FechaVencimiento.ToShortDateString();
			txtCentroMedico.Text = oExamenMedicoBE.NombreCentroMedico;
			txtNombreAptitud.Text=oExamenMedicoBE.NombreAptitud;
			txtNombreToxicologico.Text=oExamenMedicoBE.NombreToxicologico;
			txtTipoEMO.Text=oExamenMedicoBE.NombreTipoEMO;
			LblDisponible.Text=oExamenMedicoBE.NombreDisponible;
			LblHabilitado.Text=oExamenMedicoBE.NombreHabilitado;
			txtNombreToxicologico.Text=oExamenMedicoBE.NombreToxicologico;

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public DataTable ObtenerDatos(){
			//return (new SIMA.Controladoras.General.CTablaTablas()).ListaItemTablas(575);
			return (new CCCTT_ExamenMedicoRestriciones()).ListarTodosGrilla(this.Periodo,this.IdExamen);
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
			// TODO:  Add AdministrarDetalleExamenMedico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarDetalleExamenMedico.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarDetalleExamenMedico.ValidarFiltros implementation
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
				chk.Attributes[Utilitario.Enumerados.EventosJavaScript.OnClick.ToString()]="AgregarRestriccion('"+ dr["IdRestriccion"].ToString()  +"',this);";

			}
		}
	}
}
