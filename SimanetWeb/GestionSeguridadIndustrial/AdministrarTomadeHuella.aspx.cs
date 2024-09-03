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
	/// <summary>
	/// Summary description for AdministrarTomadeHuella.
	/// </summary>
	public class AdministrarTomadeHuella : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label lblMsg;
	
		const string  KEYQNOMHUELLA="NomHuella";
		protected System.Web.UI.HtmlControls.HtmlImage imgHuellaSelect;
		protected System.Web.UI.WebControls.Image Img1;
		protected System.Web.UI.WebControls.Image Img2;
		protected System.Web.UI.WebControls.Image Img3;
		protected System.Web.UI.WebControls.Image Img4;
		protected System.Web.UI.WebControls.Image Image2;
		protected System.Web.UI.WebControls.Label lbl1;
		protected System.Web.UI.WebControls.Label lbl2;
		protected System.Web.UI.WebControls.Label lbl3;
		protected System.Web.UI.WebControls.Label lbl4;
		protected System.Web.UI.WebControls.Label lblStatusScanHuella;
		const string  KEYQIMGHUELLASELECT="HuellaSelect";
		public string NombreHuella{
			get{return ((Page.Request.Params[KEYQNOMHUELLA]==null)?" ": Page.Request.Params[KEYQNOMHUELLA].ToString());}
		}

		public string NombreImgHuellaSeleccionada
		{
			get{return ((Page.Request.Params[KEYQIMGHUELLASELECT]==null)?" ": Page.Request.Params[KEYQIMGHUELLASELECT].ToString());}
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
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
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
			// TODO:  Add AdministrarTomadeHuella.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTomadeHuella.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarTomadeHuella.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarTomadeHuella.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblMsg.Text = "PARA COMENZAR,ESCANEE SU DEDO " + this.NombreHuella + " Y ESPERE HASTA QUE SE CONFIRME EL ÉXITO. REPETIR PARA CADA UNO DE LOS ESCANEOS RESTANTES";
			string PathImgHuellaselect = "/SimaNetWeb/imagenes/Navegador/Finger/" +  this.NombreImgHuellaSeleccionada + ".gif";
			imgHuellaSelect.Src = PathImgHuellaselect;
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarTomadeHuella.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTomadeHuella.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTomadeHuella.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTomadeHuella.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarTomadeHuella.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarTomadeHuella.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
