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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for PopupImagenInventarioImagen.
	/// </summary>
	public class PopupImagenInventarioImagen : System.Web.UI.Page
	{
		#region Controles
		protected System.Web.UI.WebControls.Image ImgFoto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region Constantes
		private const string KEYNOMBREFOTO="Foto";
		private const string MENSAJECONSULTAR = "Se ingreso al Popup de la Imagen";
		private string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//this.ConfigurarAccesoControles();
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));

			string RutaImagen=RutaImagenServerProyecto + Page.Request.QueryString[KEYNOMBREFOTO];
			ImgFoto.ImageUrl = RutaImagen;
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
	}
}
