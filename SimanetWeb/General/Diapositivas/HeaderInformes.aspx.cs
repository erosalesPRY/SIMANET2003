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
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.General;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;


namespace SIMA.SimaNetWeb.General.Diapositivas
{
	/// <summary>
	/// Summary description for HeaderInformes.
	/// </summary>
	public class HeaderInformes : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected System.Web.UI.WebControls.Label lblUsuario;
		protected System.Web.UI.WebControls.Label lblArea;
		protected System.Web.UI.WebControls.Label lblSubTitulo;
		protected System.Web.UI.WebControls.Image Image1;

		const string KEYTITULO="TitRep";
		const string KEYSUBTITULO="SubTitRep";

		public string Titulo
		{
			get{return Page.Request.Params[KEYTITULO].ToString();}
		}
		public string SubTitulo
		{
			get{return Page.Request.Params[KEYSUBTITULO].ToString();}
		}
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.LlenarDatos();
					
				}
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
			// TODO:  Add HeaderInformes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add HeaderInformes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add HeaderInformes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add HeaderInformes.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text = this.Titulo;
			this.lblSubTitulo.Text= this.SubTitulo;
			this.lblFecha.Text = DateTime.Now.ToShortDateString();
			this.lblUsuario.Text = CNetAccessControl.GetUserName();
			this.lblArea.Text= CNetAccessControl.GetUserNombreArea();
		}

		public void LlenarJScript()
		{
			// TODO:  Add HeaderInformes.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add HeaderInformes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add HeaderInformes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add HeaderInformes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add HeaderInformes.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add HeaderInformes.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
