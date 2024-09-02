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
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.Collections;
using System.Configuration;


namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleAccionesPorRecomendacion.
	/// </summary>
	public class DetalleAccionesPorRecomendacion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtDocumento;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellListAnexos;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox txtFecha;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstAnexos;
		protected System.Web.UI.WebControls.Button btnSubir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArchivoUP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRutaHTTP;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label LblObservacion;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label LblRecomendacion;
		protected System.Web.UI.WebControls.Label Label6;


		const string KEYQDESCRIPCIONDOC = "DesDoc";
		const string KEYQIDOBSERVACION = "IdObservacion";
		const string KEYQDESCRIPCION = "Descripcion";

		const string KEYQIDRECOMENDACION = "IdRecomendacion";
		const string KEYQPERIODO = "Periodo";
		const string KEYQDESCRIPCIONRECOMENDACION = "DescRecomendacion"; 

		const string KEYQIDACCIONRECOMENDACION = "IdAccRec";


		#region Propiedades de pagina adiciopnal
			private string OCIRutaLocalTMP
			{
				get{return ConfigurationSettings.AppSettings["RutaLocalOCITMP"].ToString();}
			}
			private string OCIRutaHTTP
			{
				get{return ConfigurationSettings.AppSettings["RutaHTTPOCI"].ToString();}
			}


			private string DescripcionDocumento
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCIONDOC]);}
			}
			private int IdObservacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBSERVACION]);}
			}
			private string DescripcionObservacion
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);}
			}

			private int Periodo
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
			}
			private int IdRecomendacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDRECOMENDACION]);}
			}
			private string DescripcionRecomendacion
			{
				get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCIONRECOMENDACION]);}
			}
			private int IdAccionPorRecomendacion
			{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDACCIONRECOMENDACION]);}
			}
		#endregion




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
			// TODO:  Add DetalleAccionesPorRecomendacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.hRutaHTTP.Value = this.OCIRutaHTTP;
			this.hIdAccion.Value = this.IdAccionPorRecomendacion.ToString();
			this.hPeriodo.Value = this.Periodo.ToString();

			this.lblTitulo.Text = this.DescripcionDocumento;
			this.LblObservacion.Text = this.DescripcionObservacion;
			this.LblRecomendacion.Text = this.DescripcionRecomendacion;


		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			AccionRecomendacionBE oAccionRecomendacionBE = new AccionRecomendacionBE();
			oAccionRecomendacionBE.IdRecomendacion = this.IdRecomendacion;
			oAccionRecomendacionBE.Periodo = this.Periodo;
			oAccionRecomendacionBE.NroDocumento = this.txtDocumento.Text;
			oAccionRecomendacionBE.Fecha = Convert.ToDateTime(this.txtFecha.Text);
			oAccionRecomendacionBE.Descripcion = this.txtDescripcion.Text;
			//oAccionRecomendacionBE.Situacion = this.txtSituacion.Text;
			//oAccionRecomendacionBE.Opinion = this.txtOpinion.Text;
			
			if((new CAccionRecomendacion()).InsertaAccionRecomendacion(oAccionRecomendacionBE,ObtenerLstAnexos())>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Registro de Acciones por Recomendaciones",this.ToString(),"Se registró Item de acción por recomendación" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}

		}

		ArrayList ObtenerLstAnexos()
		{
			ArrayList arrAnexoBE = new ArrayList();
			string []LstAnexos = this.hLstAnexos.Value.ToString().Split('@');
			for(int l=0;l<=LstAnexos .Length-1;l++)
			{
				if(LstAnexos[l].Length!=0)
				{
					string []LstCampo = LstAnexos[l].ToString().Split(';');
					AnexoAccionRecomendacionBE oAnexoAccionRecomendacionBE = new AnexoAccionRecomendacionBE();
					oAnexoAccionRecomendacionBE.IdAnexo=Convert.ToInt32(LstCampo[0].ToString());
					oAnexoAccionRecomendacionBE.Archivo=LstCampo[1].ToString();
					arrAnexoBE.Add(oAnexoAccionRecomendacionBE);
				}
			}
			return arrAnexoBE;
		}



		public void Modificar()
		{
			AccionRecomendacionBE oAccionRecomendacionBE = new AccionRecomendacionBE();
			oAccionRecomendacionBE.IdAccion= this.IdAccionPorRecomendacion;
			oAccionRecomendacionBE.IdRecomendacion = this.IdRecomendacion;
			oAccionRecomendacionBE.Periodo = this.Periodo;
			oAccionRecomendacionBE.NroDocumento = this.txtDocumento.Text;
			oAccionRecomendacionBE.Fecha = Convert.ToDateTime(this.txtFecha.Text);
			oAccionRecomendacionBE.Descripcion = this.txtDescripcion.Text;
			//oAccionRecomendacionBE.Situacion = this.txtSituacion.Text;
			//oAccionRecomendacionBE.Opinion = this.txtOpinion.Text;
			
			if((new CAccionRecomendacion()).ModificarAccionRecomendacion(oAccionRecomendacionBE,ObtenerLstAnexos())>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Registro de Acciones por Recomendaciones",this.ToString(),"Se registró Item de acción por recomendación" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					Helper.BloquearControles(this);
					break;
			}						
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			AccionRecomendacionBE oAccionRecomendacionBE = (AccionRecomendacionBE) (new CAccionRecomendacion()).ListarDetalle(this.IdRecomendacion,this.Periodo,this.IdAccionPorRecomendacion);
			this.txtDocumento.Text = oAccionRecomendacionBE.NroDocumento;
			this.txtDescripcion.Text = oAccionRecomendacionBE.Descripcion;
			//this.txtSituacion.Text = oAccionRecomendacionBE.Situacion;
			//this.txtOpinion.Text = oAccionRecomendacionBE.Opinion;
			this.txtFecha.Text = oAccionRecomendacionBE.Fecha.ToShortDateString();
			this.hLstAnexos.Value = GenerarLstAnexos();

		}

		string GenerarLstAnexos(){
			string LstAnexos="";
			DataTable dt = (new CAccionRecomendacion()).ConsultarAnexoAccionRecomendaciones(this.Periodo,this.IdAccionPorRecomendacion,0);
			if(dt!=null)
			{
				foreach(DataRow dr in dt.Rows)
				{
					LstAnexos += dr["IdAnexo"].ToString()+ ";" + dr["Archivo"].ToString() +"@";
				}
			}
			return ((LstAnexos.Length>0)? LstAnexos.Substring(0,LstAnexos.Length-1):"");
		}
		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.txtDocumento.Text.Length==0){
				Helper.MsgBox("REGISTRO DE ACCIONES","No se ha ingresado Nro de Documento",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.txtFecha.Text.Length==0)
			{
				Helper.MsgBox("REGISTRO DE ACCIONES","No se ha ingresado valor de fecha correcta",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(this.txtDescripcion.Text.Length==0)
			{
				Helper.MsgBox("REGISTRO DE ACCIONES","No se ha ingresado descripcion de la accion",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAccionesPorRecomendacion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								this.Agregar();
								break;
							case Enumerados.ModoPagina.M:
								this.Modificar();
								break;
						}
					}
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}				
		}

		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			string []arrNombre = this.hNombreArchivoUP.Value.ToString().Split('.');
			string Ext =arrNombre[arrNombre.Length-1];
			string SoloNombre = this.hNombreArchivoUP.Value.ToString().Substring(0,this.hNombreArchivoUP.Value.ToString().Length-(Ext.Length+1));
			string NombreArchivo = CNetAccessControl.GetIdUser().ToString() + SoloNombre;
			Helper.SubirArchivo(this.FUFile,this.OCIRutaLocalTMP,NombreArchivo);
		}
	}
}
