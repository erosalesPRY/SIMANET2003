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
	/// Summary description for AdministrarHuellaPersonal.
	/// </summary>
	public class AdministrarHuellaPersonal : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.PlaceHolder LtlMapContext;
		
		const string KEYQCODPERSONA="CodPers";

		public string CodigoPersonal
		{
			get{ return Page.Request.Params[KEYQCODPERSONA].ToString();}
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
			// TODO:  Add AdministrarHuellaPersonal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarHuellaPersonal.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarHuellaPersonal.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarHuellaPersonal.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarHuellaPersonal.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			LtlMapContext.Controls.Add(new LiteralControl(CargarConfgHuella(this.CodigoPersonal)));
		}
		public string CargarConfgHuella(string CodigoPer)
		{
			string cmll = Utilitario.Constantes.SIGNOCOMILLADOBLE;
			DataTable dt =  (new CCCTT_Huella()).ListarModelo(CodigoPer);
			if((dt!=null)&&(dt.Rows.Count>0)){
				string htmlMap="<map name=" + cmll + "image-map" + cmll +  ">";
				
				foreach(DataRow dr in dt.Rows)
				{
					string HtmlEfecto = ((dr["COD_HUELLA"].ToString()!="0")?"data-maphilight='" + dr["VAL_ALTER1"].ToString() + "'":"");

					string Nombre = dr["NOM_ITEM"].ToString();
					htmlMap += "<area  id=" + cmll + dr["COD_ALTER"].ToString() + cmll + " data-key = " + cmll +  dr["COD_ALTER"].ToString() + cmll + "   class=" + cmll + "map" + cmll + " idHuella=" + cmll +   dr["cod_item"].ToString() + cmll + " title=" + cmll + Nombre + cmll + " href='#'  shape=" + cmll + "poly"+ cmll +" coords=" + cmll + dr["DES_ITEM"].ToString() + cmll +" target='_blank' alt="+ cmll + Nombre + cmll + HtmlEfecto +">";
				}
				htmlMap += "</map>";
				return htmlMap;
			}
			return "";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarHuellaPersonal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarHuellaPersonal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarHuellaPersonal.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarHuellaPersonal.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarHuellaPersonal.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarHuellaPersonal.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarHuellaPersonal.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarHuellaPersonal.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarHuellaPersonal.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarHuellaPersonal.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarHuellaPersonal.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarHuellaPersonal.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarHuellaPersonal.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarHuellaPersonal.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarHuellaPersonal.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
