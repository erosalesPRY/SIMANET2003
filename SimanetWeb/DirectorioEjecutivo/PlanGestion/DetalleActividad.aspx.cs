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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	public class DetalleActividad : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			Helper.CalendarioControlStyle(this.CalFecha);
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{
			ActividadBE oActividadBE = new ActividadBE();
			oActividadBE.IDACCION = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]);
			oActividadBE.DESCRIPCION = NullableTypes.NullableString.Parse(txtNombreActividad.Text);
			oActividadBE.AF = NullableTypes.NullableDouble.Parse(txtAF.Text);
			oActividadBE.INVERSION = NullableTypes.NullableInt32.Parse(txtInversion.Text);
			oActividadBE.AÑO = NullableTypes.NullableDateTime.Parse(CalFecha.SelectedDate);
			oActividadBE.IdUsuarioRegistro = NullableTypes.NullableInt32.Parse(NetAccessControl.CNetAccessControl.GetIdUser());
			oActividadBE.IdTablaEstado = NullableTypes.NullableInt32.Parse(Convert.ToInt32(Enumerados.TablasTabla.EstadosPlanDirector));
			oActividadBE.IdEstado = NullableTypes.NullableInt32.Parse(Convert.ToInt32(Enumerados.EstadoPlanDirector.Activo));
			oActividadBE.IdNivelVisibilidad = Convert.ToInt32(dllVisibilidad.SelectedValue);
			oActividadBE.IdTablaNivelVisibilidad = Convert.ToInt32(Enumerados.TablasTabla.NivelesVisibilidad);
            		
			
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oActividadBE.IdCargoLider = NullableTypes.NullableInt32.Parse(this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oActividadBE.IdAreaLider = NullableTypes.NullableInt32.Parse(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oActividadBE.IdPersonalLider = NullableTypes.NullableInt32.Parse(this.hIdPersonalLider.Value);
			}


			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Insertar(oActividadBE)>0)
			{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se Agregó una a la Accion Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));

					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCION))  + JSUBIRHISTORIAL;
					/*
						KEYIDOGENERAL +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						//Descripcion OGenerales
						DESCRIPCIONOGENERAL +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						//idOEspecifico
						KEYIDOESPECIFICOS +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +  
						Utilitario.Constantes.SIGNOAMPERSON + 
						//idAccion
						KEYIDACCION +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						//Codigo OE
						CODIGOOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre OE
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
				
						CODIGOACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						
						DESCRIPCIONACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()] +
						
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()] 
					*/	
										
						
			}
		}

		public void Modificar()
		{
			ActividadBE oActividadBE = new ActividadBE();
			oActividadBE.IDACTIVIDAD = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasActividad.IDACTIVIDAD.ToString()]);
			oActividadBE.IDACCION = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]);
			oActividadBE.DESCRIPCION = txtNombreActividad.Text.ToString();
			oActividadBE.AF = NullableTypes.NullableDouble.Parse(txtAF.Text);
			oActividadBE.INVERSION = NullableTypes.NullableInt32.Parse(txtInversion.Text);
			oActividadBE.AÑO = NullableTypes.NullableDateTime.Parse(CalFecha.SelectedDate);
			oActividadBE.IdUsuarioActualizacion = NullableTypes.NullableInt32.Parse(NetAccessControl.CNetAccessControl.GetIdUser());
			oActividadBE.IdTablaEstado = NullableTypes.NullableInt32.Parse(Convert.ToInt32(Enumerados.TablasTabla.EstadosPlanDirector));
			oActividadBE.IdEstado = NullableTypes.NullableInt32.Parse(Convert.ToInt32(Enumerados.EstadoPlanDirector.Activo));
			oActividadBE.IdNivelVisibilidad = Convert.ToInt32(dllVisibilidad.SelectedValue);
			
			
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oActividadBE.IdCargoLider = NullableTypes.NullableInt32.Parse(this.hidCargoLider.Value);
			}
			else
			{
				oActividadBE.IdCargoLider = Utilitario.Constantes.INDICEPAGINADEFAULT;
			}

			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oActividadBE.IdAreaLider = NullableTypes.NullableInt32.Parse(this.hIdAreaLider.Value);
			}
			else
			{
				oActividadBE.IdAreaLider = Utilitario.Constantes.INDICEPAGINADEFAULT;
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oActividadBE.IdPersonalLider = NullableTypes.NullableInt32.Parse(this.hIdPersonalLider.Value);
			}
			else
			{
				oActividadBE.IdPersonalLider = Utilitario.Constantes.INDICEPAGINADEFAULT;
			}
								
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oActividadBE)>0)
			{
				int origen = Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICARACCION),URLPRINCIPAL + 
						KEYIDOESPECIFICOS +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						//Codigo OE
						CODIGOOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre OE
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]
						);
					#endregion
				}
				else
				{
					#region Proceso Estrategico
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se Agregó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.DESCRIPCIONOE.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCION)) + JSUBIRHISTORIAL;//,URLPRINCIPAL +
					/*
						KEYIDOGENERAL +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						//Descripcion OGenerales
						DESCRIPCIONOGENERAL +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						//idOEspecifico
						KEYIDOESPECIFICOS +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +  
						Utilitario.Constantes.SIGNOAMPERSON + 
						//idAccion
						KEYIDACCION +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						//Codigo OE
						CODIGOOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre OE
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//ModoPagina
						Utilitario.Constantes.KEYMODOPAGINA +
						Utilitario.Constantes.SIGNOIGUAL + 
						Enumerados.ModoPagina.M.ToString() + 
						//Plan Estrategico
						Utilitario.Constantes.SIGNOAMPERSON +

						CODIGOACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 	
						
						DESCRIPCIONACCION + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +

						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()] 
						);*/
					#endregion
				}
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleActividad.Eliminar implementation
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
			this.LlenarDatos();
		}

		public void CargarModoModificar()
		{
			this.LlenarDatos();
			int IdActividad = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasActividad.IDACTIVIDAD.ToString()]);

			lblTitulo.Text = TITULOMODOMODIFICAR;
					
			CActividad oCActividad = new CActividad();
			ActividadBE oActividadBE = (ActividadBE)oCActividad.ListarDetalle(IdActividad);
		
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"PlanGestion",this.ToString(),"Se consultó el Detalle del SubProceso del Plan de Gestión " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
			if(oActividadBE!=null)
			{
				this.txtCodigoActividad.Text = oActividadBE.CODIGOACTIVIDAD.ToString();
				this.txtNombreActividad.Text = oActividadBE.DESCRIPCION.ToString();
				this.txtLider.Text = oActividadBE.RESPONSABLE.ToString();
				this.txtAF.Text = oActividadBE.AF.ToString();
				this.txtInversion.Text = oActividadBE.INVERSION.ToString();
				this.CalFecha.SelectedDate = Convert.ToDateTime(oActividadBE.AÑO);
				this.dllVisibilidad.SelectedValue = oActividadBE.IdNivelVisibilidad.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleActividad.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleActividad.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleActividad.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleActividad.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion		
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleActividad.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleActividad.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleActividad.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{

			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			dllVisibilidad.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.NivelesVisibilidad));
			dllVisibilidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			dllVisibilidad.DataTextField = Enumerados.ColumnasTablasTablas.Descripcion.ToString();
			dllVisibilidad.DataBind();

		}

		public void LlenarDatos()
		{
			this.LlenarTitulosPlanEstrategico();
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarLider.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDALIDER + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),750,500,true));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleActividad.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleActividad.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleActividad.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
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
			// TODO:  Add DetalleActividad.ValidarFiltros implementation
			return false;
		}

		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCodigoActividad;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNombreActividad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreProceso;
		protected System.Web.UI.WebControls.Label lblDefinicion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.TextBox txtResponsable;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarLider;
		protected System.Web.UI.WebControls.Label lblParticipantes;
		protected eWorld.UI.NumericBox txtAF;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Label lblCO;
		protected eWorld.UI.NumericBox txtInversion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		#region Constantes

		//Ordenamiento
		const string COLORDENAMIENTO = "IdActividad";
		const int COLUMNANUMERACION = 0;
		const int COLUMNAMODIFICAR = 1;
const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYIDOGENERAL = "idOGenerales";
		const string NOMBREOGENERAL = "Descripcion";
		const string KEYIDOESPECIFICOS = "idOEspecificos";
		const string CODIGOESPECIFICO = "CodigoOEspecificos";
		const string NOMBREOESPECIFICO = "NombreOEspecificos";
		const string KEYIDACCION = "IdAccion";
		const string CODIGOACCION = "CodigoAccion";
		const string DESCRIPCIONACCION = "DescripcionAccion";
		const string DESCRIPCIONOGENERAL = "DESCRIPCION";
		const string CODIGOOE = "CodigoOEspecificos";
		const string NOMBREOE = "NombreOEspecificos";
		const string CODIGOPROCESO = "CodigoProceso";
		const string PE = "PlanEstrategico";


		const string KEYQID = "Id";
		const string KEYIDPROCESO = "IdProceso";
		const string KEYIDSUBPROCESO = "IdSubProceso";

		//OTROS
		const string URLMODIFICAR = "DetalleActividad.aspx?";
		const string URLPRINCIPAL = "AdministrarActividad.aspx?";
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Datos";
		const int POSICIONFOOTERTOTAL = 1;
		protected System.Web.UI.WebControls.TextBox txtLider;

		const string URLBUSQUEDALIDER = "BusquedaLider.aspx?";
const string JSUBIRHISTORIAL="HistorialIrAtras();";
		const string TITULOMODONUEVO = "NUEVA ACTIVIDAD";
		protected System.Web.UI.WebControls.Label lblVisibilidad;
		protected System.Web.UI.WebControls.DropDownList dllVisibilidad;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		const string TITULOMODOMODIFICAR = "MODIFICAR ACTIVIDAD";
		#endregion
		#region Eventos
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.LlenarCombos();
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		public void LlenarTitulosPlanEstrategico()
		{
			//this.lblProceso.Text = "OG" + Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()];
			//this.lblNombreProceso.Text = Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()].ToUpper();
			//this.lblOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.	.ToString()]).ToUpper();
			//this.lblNombreOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]).ToUpper();
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
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

		#endregion
		#region Eventos del Boton Cancelar Comentados por ser no funcional
		/*
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
		*/
		/*
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL +
				KEYIDOGENERAL +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//Descripcion OGenerales
				DESCRIPCIONOGENERAL +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//idOEspecifico
				KEYIDOESPECIFICOS +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +  
				Utilitario.Constantes.SIGNOAMPERSON + 
				//idAccion
				KEYIDACCION +
				Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 
				//Codigo OE
				CODIGOOE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON +
				//Nombre OE
				NOMBREOE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON +
				
				CODIGOACCION + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.CodigoAccion.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 	
						
				DESCRIPCIONACCION + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.Descripcion.ToString()] +
				Utilitario.Constantes.SIGNOAMPERSON + 	

				PE +
				Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]
				
				+
 				
				Utilitario.Constantes.SIGNOAMPERSON + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[KEYQFILTRO]
				);
		}
		*/
		#endregion

	}
}
