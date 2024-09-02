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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionEstrategica.Proyecto;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionEstrategica;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;
using System.Net;
using SIMA.Controladoras.Proyectos;

namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		const string KEYQIDCOMPONENTE="IdComponente";

		const string KEYQIDPROYECTOPERFIL="IdProyPerf";
		const string KEYQIDNIVELAPROBACION="IdNivelAprob";
		//Datos para la bitacora
		const string KEYQIDBITACORA="IdBitacora";
		const string KEYQFECHA="Fecha";
		const string KEYQIDDESCRICION="Descrip";
		const string KEYQIDESTADO="IdEstado";
		const string KEYQCODIGOPROYECTOPC="CodProyPC";
		const string KEYQIDCENTROOPERATIVO="IdCeo";
		const string KEYQIDPIP="IdPIP";
		const string KEYQAÑOPIP="AnioPIP";
		const string PROCESO ="idProceso";


		#region Procesos
			//int IDPRCPASARPROYECTOESTUDIOAPROYECTO=167;
			int IDPRCELIMINAPROYECTOPERFIL=168;
			int IDPRCINSERTAACTUALIZAPROYECTOPERFILBITACORA=169;

			int IDPRCBUSCAROBJETIVOESPECIFICO=170;
			int IDPRCINSERTAMODIFICACOMPONENTE=171;

			int IDPRCBUSCARPROYECTOUNISYS=172;
			int IDPRCLISTADOVALORZACIONOTSUNISYS=173;

			int IDPRCELIMINARPROYECTOGENERAL=182;

			int IDPRCVERIFICAEXISTENCIA=183;
		#endregion
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{	
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCELIMINAPROYECTOPERFIL)
					{
						Helper.GenerarEsquemaXMLTAD((new CProyectoPerfil()).Eliminar(Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString()));
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCELIMINARPROYECTOGENERAL)
					{
						Helper.GenerarEsquemaXMLTAD((new CProyectoGeneral()).Eliminar(Page.Request.Params[KEYQIDPIP].ToString()));
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCINSERTAACTUALIZAPROYECTOPERFILBITACORA)
					{
						ProyectoPerfilBitacoraBE oProyectoPerfilBitacoraBE = new ProyectoPerfilBitacoraBE();
						oProyectoPerfilBitacoraBE.IdBitacora = Page.Request.Params[KEYQIDBITACORA].ToString();
						oProyectoPerfilBitacoraBE.IdProyectoPerfil = Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString();
						oProyectoPerfilBitacoraBE.Fecha = Convert.ToDateTime(Page.Request.Params[KEYQFECHA].ToString());
						oProyectoPerfilBitacoraBE.Descripcion = Page.Request.Params[KEYQIDDESCRICION].ToString();
						oProyectoPerfilBitacoraBE.IdEstado= Convert.ToInt32(Page.Request.Params[KEYQIDESTADO].ToString());
						Helper.GenerarEsquemaXMLTAD((new CProyectoPerfilBitacora()).Insertar(oProyectoPerfilBitacoraBE));

					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCBUSCAROBJETIVOESPECIFICO)
					{
						Helper.AutoBusquedaResultado((new CProyectoInversionPublica()).ListarObjetivosEspecificosPorCriterio(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Helper.CriterioBusqueda()));
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCINSERTAMODIFICACOMPONENTE)
					{
						ProyectoPerfilComponenteBE oProyectoPerfilComponenteBE = new ProyectoPerfilComponenteBE();
						oProyectoPerfilComponenteBE.IdComponente = Page.Request.Params[KEYQIDCOMPONENTE].ToString();
						oProyectoPerfilComponenteBE.IdProyectoPerfil= Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString();
						oProyectoPerfilComponenteBE.Descripcion= Page.Request.Params[KEYQIDDESCRICION].ToString();
						oProyectoPerfilComponenteBE.pIdEstado = Convert.ToInt32(Page.Request.Params[KEYQIDESTADO].ToString());
						Helper.GenerarEsquemaXMLTAD((new CProyectoPerfilComponente()).Insertar(oProyectoPerfilComponenteBE));
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCBUSCARPROYECTOUNISYS)
					{
						Helper.AutoBusquedaResultado((new CProyectoGeneral()).BuscarProyectoOTs(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]), Helper.CriterioBusqueda()));
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCLISTADOVALORZACIONOTSUNISYS)
					{
						Helper.GenerarEsquemaXMLNTAD((new CProyectoGeneral()).ListadodeOtsyValorizacionesporProyecto(Page.Request.Params[KEYQCODIGOPROYECTOPC]));
					}
					if(Convert.ToInt32(Page.Request.Params[PROCESO])==IDPRCVERIFICAEXISTENCIA)
					{
						Helper.GenerarEsquemaXMLTAD((new CProyectoGeneral()).VerificarAñoCodigoPIPExistente(Page.Request.Params[KEYQAÑOPIP]));
					}
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
	}
}
