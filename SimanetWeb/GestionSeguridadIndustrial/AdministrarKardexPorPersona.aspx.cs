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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using System.Drawing;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for AdministrarKardexPorPersona.
	/// </summary>
	public class AdministrarKardexPorPersona : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodTrabAct;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodArea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstClass;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaFoto;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlImage cmdEntregaMaterial;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblAlmacen;
		protected System.Web.UI.HtmlControls.HtmlImage ImgConfirma;

		const string KEYQNOMBREAREA = "NomArea";
		const string KEYQIDAREA="IdArea";
		protected System.Web.UI.HtmlControls.HtmlImage imgAdmHuella;
		protected System.Web.UI.HtmlControls.HtmlImage imgEntregaxLectora;
		const string KEYQCODCEO = "CodCeo";

		public string IdArea{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
		}
		public string CodigoCentro
		{
			get{return Page.Request.Params[KEYQCODCEO].ToString();}
		}
		public string NombreArea
		{
			get{return Page.Request.Params[KEYQNOMBREAREA].ToString();}
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
					this.LlenarDatos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					
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
			this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarKardexPorPersona.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarKardexPorPersona.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarKardexPorPersona.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			 
			hCodArea.Value = Page.Request.Params[KEYQIDAREA].ToString();
		}

		public void LlenarDatos()
		{
			hRutaFoto.Value= Utilitario.Helper.ObtenerRutaFotoPersonal();
			lblAlmacen.Text = this.NombreArea;
			//Obtener datos de nombre de area


		}

		public void LlenarJScript()
		{
			this.cmdEntregaMaterial.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ManagerProcess.InvocadoDesde=ManagerProcess.Enum.Opcion.BotonOpcion;AdministrarKardexPorPersona.ListarMaterialDisponible()");
			this.imgAdmHuella.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AdministrarKardexPorPersona.RegistrarHuella()");
			this.ImgConfirma.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AdministrarKardexPorPersona.ConfirmarRecibido();");
			this.imgEntregaxLectora.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AdministrarKardexPorPersona.EntregaProductoConLectoradeBarra()");
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarKardexPorPersona.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarKardexPorPersona.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarKardexPorPersona.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarKardexPorPersona.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarKardexPorPersona.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void txtBuscar_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
