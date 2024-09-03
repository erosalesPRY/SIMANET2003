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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	
	public class SplahLecturaHuella : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblNroItems;
		protected System.Web.UI.WebControls.Image imgHuella;


		const string KEYQCODPERSONA="CodPers";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroHuellas;
		protected System.Web.UI.WebControls.Label lblStatusScanHuella;
		protected System.Web.UI.WebControls.Image imgHuellaScan;
		protected System.Web.UI.WebControls.PlaceHolder LtlMapContext;
		protected System.Web.UI.WebControls.Label lblAviso;
		const string KEYQNROITEMS = "NroItemConf";

		public string CodigoPersonal{
			get{ return Page.Request.Params[KEYQCODPERSONA].ToString();}
		}
		public string NroItemsxConfirmar{
			get{ return Page.Request.Params[KEYQNROITEMS].ToString();}
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
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarDatos();
					
					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add SplahLecturaHuella.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add SplahLecturaHuella.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add SplahLecturaHuella.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add SplahLecturaHuella.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			//Nro Huellas registradas
			DataTable dt = (new CCCTT_Huella()).Listar(this.CodigoPersonal);
			if((dt!=null)&&(dt.Rows.Count>0))
			{
				this.hNroHuellas.Value=dt.Rows.Count.ToString(); 
			}
			else{
				this.hNroHuellas.Value="0";
			}
			
			this.lblNroItems.Text = this.NroItemsxConfirmar;
		}

		public void LlenarJScript()
		{
			LtlMapContext.Controls.Add(new LiteralControl((new AdministrarHuellaPersonal()).CargarConfgHuella(this.CodigoPersonal))); 
		}

		public void RegistrarJScript()
		{
			// TODO:  Add SplahLecturaHuella.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add SplahLecturaHuella.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add SplahLecturaHuella.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add SplahLecturaHuella.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add SplahLecturaHuella.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add SplahLecturaHuella.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add SplahLecturaHuella.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add SplahLecturaHuella.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add SplahLecturaHuella.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add SplahLecturaHuella.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add SplahLecturaHuella.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add SplahLecturaHuella.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add SplahLecturaHuella.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add SplahLecturaHuella.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add SplahLecturaHuella.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
