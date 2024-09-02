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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.GestionControlInstituacional
{
	/// <summary>
	/// Summary description for DetallePoderes.
	/// </summary>
	public class DetalleObservacionesAuditoria : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
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
			this.txtRecomendaciones.TextChanged += new System.EventHandler(this.txtRecomendaciones_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA OBSERVACION";
		const string TITULOMODOMODIFICAR = "OBSERVACION";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDOBSERVACION = "IdObservacion";
		const string KEYQIDDOCUMENTOAUDITORIA = "IdDocumentoAuditoria";
		const string KEYTIPOBUSQUEDA ="TipoBusqueda";

		//Paginas
		const string URLBUSQUEDAPERSONAL = "../Legal/BusquedaPersonal.aspx?";

		#endregion Constantes
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtRecomendaciones;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlTableCell cellListDestino;
		protected System.Web.UI.WebControls.TextBox txtBuscar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstDetinatario;
		protected System.Web.UI.WebControls.TextBox calFechaTermino;
		protected System.Web.UI.WebControls.TextBox txtPersonalRespo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvResponsable;
		/// <summary>
		/// Llena el combo de Tipo Accion
		/// </summary>
		ListItem lItem;

		private void llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo= new CCentroOperativo();
			ddlbCentroOperativo.DataSource= oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlbCentroOperativo.DataBind();
		}

		private void llenarTipoSituacion()
		{
			CTablaTablas oCTablasTablas = new CTablaTablas();
			ddlbSituacion.DataSource= oCTablasTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion));
			ddlbSituacion.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString ();
			ddlbSituacion.DataBind();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();

					this.CargarModoPagina();	
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			this.llenarCentroOperativo();
			this.llenarTipoSituacion();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvObservacion.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOOBSERVACION);
			rfvObservacion.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOOBSERVACION);

			/*rfvSituacionActual.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL);
			rfvSituacionActual.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL);*/

			rfvResponsable.ErrorMessage = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDORESPONSABLE);
			rfvResponsable.ToolTip = Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDORESPONSABLE);

			//ibtnBuscarPersonal.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPERSONAL + KEYTIPOBUSQUEDA + Utilitario.Constantes.SIGNOIGUAL + "1",700,500,true));
			ibtnAceptar.Attributes.Add(Constantes.EVENTOCLICK,Constantes.EVENTOVALIDATORONSUBMIT);	
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePoderes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePoderes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePoderes.ConfigurarAccesoControles implementation
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{
				CNetAccessControl.LoadControls(this);
			}
			else
			{
				
				CNetAccessControl.RedirectPageError();
				
			}
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePoderes.ValidarFiltros implementation
			return true;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			ObservacionesAuditoriaBE oObservacionesAuditoriaBE= new  ObservacionesAuditoriaBE();
			oObservacionesAuditoriaBE.IdDocumentoAuditoria = Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]);

			//if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				//oObservacionesAuditoriaBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
				oObservacionesAuditoriaBE.FechaTermino = Convert.ToDateTime(calFechaTermino.Text);	
			}

			oObservacionesAuditoriaBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion);
			oObservacionesAuditoriaBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oObservacionesAuditoriaBE.Observacion = txtObservaciones.Text;		
			oObservacionesAuditoriaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);

			oObservacionesAuditoriaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoObservacionesAuditora);
			oObservacionesAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObservacionesAuditoria.Activo);
			oObservacionesAuditoriaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oObservacionesAuditoriaBE.IdPersonal=Convert.ToInt32(hIdPersonal.Value);
			/*Implementacion Extension erosales*/		
			oObservacionesAuditoriaBE.LstArea = LstIdAreas(this.hLstDetinatario.Value);

			
			if(txtRecomendaciones.Text!=String.Empty)
			{oObservacionesAuditoriaBE.Recomendaciones = txtRecomendaciones.Text;}

				CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oObservacionesAuditoriaBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se registró la Observación Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROOBSERVACIONCONTROL));
			}
		}

		public void Modificar()
		{
			ObservacionesAuditoriaBE oObservacionesAuditoriaBE = new  ObservacionesAuditoriaBE();

			//oObservacionesAuditoriaBE.IdDocumentoAuditoria = Convert.ToInt32(Page.Request.QueryString[KEYQIDDOCUMENTOAUDITORIA]);
			oObservacionesAuditoriaBE.IdObservacionAuditoria = Convert.ToInt32(Page.Request.QueryString[KEYQIDOBSERVACION]);

			//if(calFechaTermino.SelectedDate.ToString() != Constantes.FECHAVALORENBLANCO)
			{
				//oObservacionesAuditoriaBE.FechaTermino = Convert.ToDateTime(calFechaTermino.SelectedDate);	
				oObservacionesAuditoriaBE.FechaTermino = Convert.ToDateTime(calFechaTermino.Text);	
			}

			oObservacionesAuditoriaBE.IdTablaSituacion = Convert.ToInt32(Enumerados.TablasTabla.TipoSituacionObservacion);
			oObservacionesAuditoriaBE.IdSituacion = Convert.ToInt32(ddlbSituacion.SelectedValue);
			oObservacionesAuditoriaBE.Observacion = txtObservaciones.Text;		
			oObservacionesAuditoriaBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);

			oObservacionesAuditoriaBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoObservacionesAuditora);
			oObservacionesAuditoriaBE.IdEstado = Convert.ToInt32(Enumerados.EstadosObservacionesAuditoria.Activo);
			oObservacionesAuditoriaBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oObservacionesAuditoriaBE.IdPersonal=Convert.ToInt32(hIdPersonal.Value);
			if(txtRecomendaciones.Text!=String.Empty)
			{oObservacionesAuditoriaBE.Recomendaciones = txtRecomendaciones.Text;}
			/*Implementacion Extension erosales*/		
			oObservacionesAuditoriaBE.LstArea = LstIdAreas(this.hLstDetinatario.Value);
			

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oObservacionesAuditoriaBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se modificó la Observación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionOCI.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONOBSERVACIONCONTROL));
			}
		}

		string LstIdAreas(string arrValores)
		{
			if(arrValores.Length==0) return "";
			string LIdsAreas="";
			string[] LArea =  arrValores.ToString().Split('@');
			foreach(string LReg in LArea){
				string [] LCampo =  LReg.Split(';');
				LIdsAreas+= LCampo[1].ToString() + ';';
			}
			return ((LIdsAreas.Length>0)?LIdsAreas.Substring(0,LIdsAreas.Length-1):LIdsAreas);
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePoderes.Eliminar implementation
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
					this.CargarModoConsulta();
					break;
				
			}
		}

		public void CargarModoNuevo()
		{
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ObservacionesAuditoriaBE oObservacionesAuditoriaBE = (ObservacionesAuditoriaBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDOBSERVACION]),Enumerados.ClasesNTAD.ObservacionesAuditoriaNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"OCI",this.ToString(),"Se consultó el Detalle de la Observación Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObservacionesAuditoriaBE!=null)
			{
				//if(oObservacionesAuditoriaBE.FechaTermino.ToString() != Constantes.FECHAVALORENBLANCO)
				{
				//	calFechaTermino.SelectedDate  = Convert.ToDateTime(oObservacionesAuditoriaBE.FechaTermino);
					calFechaTermino.Text  = Convert.ToDateTime(oObservacionesAuditoriaBE.FechaTermino).ToShortDateString();
				}
				
				ddlbSituacion.Items.FindByValue(oObservacionesAuditoriaBE.IdSituacion.ToString()).Selected = true;				
				txtObservaciones.Text = oObservacionesAuditoriaBE.Observacion.ToString();
				//txtPersonal.Text=oObservacionesAuditoriaBE.Personal.ToString();
				this.txtPersonalRespo.Text=oObservacionesAuditoriaBE.Personal.ToString();
				hIdPersonal.Value = oObservacionesAuditoriaBE.IdPersonal.ToString();
				ddlbCentroOperativo.Items.FindByValue(oObservacionesAuditoriaBE.IdCentroOperativo.ToString()).Selected = true;				
				if(!oObservacionesAuditoriaBE.Recomendaciones.IsNull)
				{txtRecomendaciones.Text = Convert.ToString(oObservacionesAuditoriaBE.Recomendaciones);}
				/*Implementacion Extension erosales*/
				this.hLstDetinatario.Value = ObtenerLstAreas(oObservacionesAuditoriaBE.LstArea.ToString());
				//this.txtAccionesTomadas.Text = oObservacionesAuditoriaBE.AccionesTomadas.ToString();


			}
		}

		string ObtenerLstAreas(string lstIds){
			string lstAreas="";
			if(lstIds.Length>0)
			{
				DataTable dt = (new CArea()).ListarTodosCombo();
				string [] Lids = lstIds.ToString().ToString().Split(';');
				foreach(string idArea in Lids)
				{
					if(Lids.Length>0)
					{
						foreach(DataRow dr in dt.Select("IDAREA=" + idArea.ToString()))
						{
							lstAreas +="0;" + idArea +";" + dr["Nombre"].ToString() +"@";
						}
					}
				}
			}
			return ((lstAreas.Length>0)?lstAreas.Substring(0,lstAreas.Length-1):lstAreas);

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePoderes.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtPersonalRespo.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDORESPONSABLE));
				return false;	
			}

			if(txtObservaciones.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOOBSERVACION));
				return false;	
			}

			/*if(txtSituacionActual.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionOCIUsuario(Mensajes.CODIGOMENSAJECONTROLCAMPOREQUERIDOSITUACIONACTUAL));
				return false;	
			}*/

			return true;		
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void redireccionaPaginaPrincipal()
		{
			//Page.Response.Redirect(URLPRINCIPAL);
		}


		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void txtRecomendaciones_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	}
}
