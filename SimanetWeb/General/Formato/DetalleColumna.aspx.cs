using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for DetalleColumna.
	/// </summary>
	public class DetalleColumna : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlTipoColumna;
		protected System.Web.UI.WebControls.DropDownList ddlCampoBD;
		protected System.Web.UI.WebControls.TextBox txtTitulo;
		protected System.Web.UI.WebControls.Label Label4;
	
		const string KEYQIDCOLUMNA="IdCol";
		public int IdColumna{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDCOLUMNA]);}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					this.CargarModoPagina();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleColumna.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleColumna.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleColumna.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlTipoColumna.DataSource = (new CTablaTablas()).ListaItemTablas(601);
			this.ddlTipoColumna.DataTextField="var1";
			this.ddlTipoColumna.DataValueField="codigo";
			this.ddlTipoColumna.DataBind();
			this.ddlTipoColumna.Items.Insert(0,(new ListItem("[Seleccionar..]","0")));
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleColumna.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleColumna.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleColumna.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleColumna.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleColumna.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleColumna.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleColumna.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleColumna.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleColumna.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleColumna.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}					
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleColumna.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			FormatoReporteColumnaBE oFormatoReporteColumnaBE = (FormatoReporteColumnaBE)(new CFormatoReporteColumna()).Detalle(this.IdColumna);

			txtTitulo.Text=oFormatoReporteColumnaBE.TituloCampo;
			ListItem itm = ddlTipoColumna.Items.FindByValue(oFormatoReporteColumnaBE.IdTipoPRCColumn.ToString());
			if(itm!=null){itm.Selected=true;}

			itm = ddlCampoBD.Items.FindByValue(oFormatoReporteColumnaBE.NombreCampo.ToString());
			if(itm!=null){itm.Selected=true;}
			
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleColumna.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleColumna.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleColumna.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleColumna.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
