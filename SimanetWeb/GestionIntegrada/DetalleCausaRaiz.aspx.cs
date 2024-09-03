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
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionIntegrada;
using NetAccessControl;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for DetalleCausaRaiz.
	/// </summary>
	public class DetalleCausaRaiz : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdDestino;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCausaRaiz;
	 

		const string KEYQIDCAUSARAIZ="IdCausaRaiz";
		
		private string IdCausaRaiz
		{
			get{return Page.Request.Params[KEYQIDCAUSARAIZ].ToString();}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoPagina();
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
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje.ToString());					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleCausaRaiz.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleCausaRaiz.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleCausaRaiz.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleCausaRaiz.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleCausaRaiz.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			/*
			string script = "var otxtfecha = jNet.get('calFecha');\n";
			script += "	new Ext.form.DateField({allowBlank : false,applyTo: otxtfecha,format:'d/m/Y',width:80});\n";
			Helper.JavaScript.RegistrarScript(script);		
			*/
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleCausaRaiz.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleCausaRaiz.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleCausaRaiz.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleCausaRaiz.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleCausaRaiz.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleCausaRaiz.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleCausaRaiz.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleCausaRaiz.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					break;
				
			}				
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleCausaRaiz.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			SAMCausaRaizBE oSAMCausaRaizBE= (SAMCausaRaizBE)(new CCausaRaiz()).ListarDetalle(this.IdCausaRaiz);
			this.hIdCausaRaiz.Value = this.IdCausaRaiz;
			this.txtDescripcion.Text = oSAMCausaRaizBE.Descripcion.ToString();
			this.hIdDestino.Value = oSAMCausaRaizBE.IdDestino.ToString();
		}

		public void CargarModoConsulta()
		{
			
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleCausaRaiz.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleCausaRaiz.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleCausaRaiz.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
