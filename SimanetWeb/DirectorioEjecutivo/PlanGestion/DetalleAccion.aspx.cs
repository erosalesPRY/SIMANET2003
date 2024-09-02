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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.PlanGestion
{
	/// <summary>
	/// Summary description for DetalleAccion.
	/// </summary>
	public class DetalleAccion : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblOG;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA ACCION";
		const string TITULOMODOMODIFICAR = "MODIFICAR ACCION";

		//Key Session y QueryString
		const string JSUBIRHISTORIAL="HistorialIrAtras();";
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string KEYQID = "Id";
		const string KEYIDOGENERAL = "IdOGenerales";
		const string DESCRIPCIONOGENERAL = "DESCRIPCION";
		const string KEYQIDPROCESO = "idProceso";
		const string KEYIDSUBPROCESO = "idSubProceso";
		const string KEYIDOESPECIFICOS = "IdOEspecificos";
		const string CODIGOPROCESO = "CodigoProceso";
		const string NOMBREPROCESO = "NombreProceso";
		const string CODIGOSUBPROCESO = "CodigoSubproceso";
		const string NOMBRESUBPROCESO = "Descripcion";
		const string CODIGOOE = "CodigoOEspecificos";
		const string NOMBREOE = "NombreOEspecificos";
		const string PE = "PlanEstrategico";
	
		//Paginas
		const string URLPRINCIPAL = "AdministrarAccion.aspx?";
		protected System.Web.UI.WebControls.TextBox txtCodigoAccion;
		protected System.Web.UI.WebControls.TextBox txtNombreAccion;
		protected System.Web.UI.WebControls.TextBox txtResponsableAccion;
		protected System.Web.UI.WebControls.Label lblAE;
		protected eWorld.UI.NumericBox txtAvanceEconomica;
		protected System.Web.UI.WebControls.Label lblAF;
		protected eWorld.UI.NumericBox txtAvanceFinanciero;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator RangeDomValidator1;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator RangeDomValidator2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator Rangedomvalidator3;
		protected eWorld.UI.NumericBox txtPeso;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label lblNombreOEspecifico;
		protected System.Web.UI.WebControls.Label lblOEspecifico;
		protected System.Web.UI.WebControls.Label lblNombreSubProceso;
		protected System.Web.UI.WebControls.Label lblSubProceso;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.TextBox txtLider;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarLider;
		protected System.Web.UI.WebControls.Label Label5;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected System.Web.UI.WebControls.Label lblCO;
		protected eWorld.UI.NumericBox txtInversion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		const string URLBUSQUEDALIDER = "BusquedaLider.aspx?";
		
		#endregion Constantes		

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
			AccionBE oAccionBE = new AccionBE();
			oAccionBE.IDOESPECIFICOS =  Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);
			oAccionBE.CODIGOACCION = txtCodigoAccion.Text;
			oAccionBE.DESCRIPCION = txtNombreAccion.Text;
			oAccionBE.INVERSION = NullableTypes.NullableInt32.Parse(txtInversion.Text);
			oAccionBE.AÑO = NullableTypes.NullableDateTime.Parse(CalFecha.SelectedDate);
			oAccionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oAccionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosPlanDirector);
			oAccionBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Activo);
			
			if(this.txtAvanceEconomica.Text!=String.Empty)
			{
				oAccionBE.AE = Convert.ToDouble(txtAvanceEconomica.Text);
			}
			else
			{
				oAccionBE.AE = 0;
			}
			
			if(this.txtAvanceFinanciero.Text!=String.Empty)
			{
				oAccionBE.AF = Convert.ToDouble(txtAvanceFinanciero.Text);
			}
			else
			{
				oAccionBE.AF = 0;
			}

			if(this.txtPeso.Text!=String.Empty)
			{
				oAccionBE.PESO = Convert.ToDouble(txtPeso.Text);
			}
			else
			{
				oAccionBE.PESO = 0;
			}
	
			//oObjetivoEspecificoBE.PE = txtResponsable.Text;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Insertar(oAccionBE)>0)
			{
				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se Agregó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.DESCRIPCIONOE.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCION),URLPRINCIPAL +
						KEYQIDPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDOESPECIFICOS +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre Proceso
						NOMBREPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Codigo SubProceso
						CODIGOSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre SubProces
						NOMBRESUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
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
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCION)) + JSUBIRHISTORIAL;/*,URLPRINCIPAL +
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
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()] 
						);*/
					#endregion
				}

				

				
			}
		}

		public void Modificar()
		{
			AccionBE oAccionBE = new AccionBE();
			oAccionBE.IDACCION = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]);
			oAccionBE.DESCRIPCION = txtNombreAccion.Text;
			oAccionBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();		
			oAccionBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Modificado);	
			oAccionBE.INVERSION = NullableTypes.NullableInt32.Parse(txtInversion.Text);
			oAccionBE.AÑO = NullableTypes.NullableDateTime.Parse(CalFecha.SelectedDate);

			if(this.txtAvanceEconomica.Text!=String.Empty)
			{
				oAccionBE.AE = Convert.ToDouble(txtAvanceEconomica.Text);
			}
			else
			{
				oAccionBE.AE = 0;
			}
			
			if(this.txtAvanceFinanciero.Text!=String.Empty)
			{
				oAccionBE.AF = Convert.ToDouble(txtAvanceFinanciero.Text);
			}
			else
			{
				oAccionBE.AF = 0;
			}

			if(this.txtPeso.Text!=String.Empty)
			{
				oAccionBE.PESO = Convert.ToDouble(txtPeso.Text);
			}
			else
			{
				oAccionBE.PESO = 0;
			}

			if(this.hidCargoLider.Value!=String.Empty)
			{
				oAccionBE.IdCargoLider = NullableTypes.NullableInt32.Parse(this.hidCargoLider.Value);
			}
			else
			{
				oAccionBE.IdCargoLider = Utilitario.Constantes.INDICEPAGINADEFAULT;
			}

			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oAccionBE.IdAreaLider = NullableTypes.NullableInt32.Parse(this.hIdAreaLider.Value);
			}
			else
			{
				oAccionBE.IdAreaLider = Utilitario.Constantes.INDICEPAGINADEFAULT;
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oAccionBE.IdPersonaLider = NullableTypes.NullableInt32.Parse(this.hIdPersonalLider.Value);
			}
			else
			{
				oAccionBE.IdPersonaLider = Utilitario.Constantes.INDICEPAGINADEFAULT;
			}
			
			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oAccionBE)>0)
			{
				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICARACCION),URLPRINCIPAL + 
						KEYQIDPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDOESPECIFICOS +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] + 
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre Proceso
						NOMBREPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Codigo SubProceso
						CODIGOSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre SubProces
						NOMBRESUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
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
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROACCION)) + JSUBIRHISTORIAL; /*,URLPRINCIPAL +
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
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Eliminar implementation
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
			this.LlenarTitulos();
		}

		public void CargarModoModificar()
		{
			this.LlenarTitulos();
			int idAccion = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasAccion.idAccion.ToString()]);

			lblTitulo.Text = TITULOMODOMODIFICAR;
					
			CPlanGestion oCPlanGestion = new CPlanGestion();
			AccionBE oAccionBE = (AccionBE)oCPlanGestion.ListarDetalleAccion(idAccion);
		
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"PlanGestion",this.ToString(),"Se consultó el Detalle del SubProceso del Plan de Gestión " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));
			if(oAccionBE!=null)
			{				
				this.txtCodigoAccion.Text = oAccionBE.CODIGOACCION.ToString();
				this.txtNombreAccion.Text = oAccionBE.DESCRIPCION.ToString();
				this.txtAvanceEconomica.Text = oAccionBE.AE.ToString();
				this.txtAvanceFinanciero.Text = oAccionBE.AF.ToString();
				this.txtPeso.Text = oAccionBE.PESO.ToString();
				this.CalFecha.SelectedDate = Convert.ToDateTime(oAccionBE.AÑO);
				this.txtInversion.Text = oAccionBE.INVERSION.ToString();
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.CargarModoConsulta implementation
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
			if(this.txtCodigoAccion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}

			if(this.txtNombreAccion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region Eventos del Boton Cancelar quitados por disfuncionalidad
		/*
		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}

		private void redireccionaPaginaPrincipal()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				#region Plan Director
				Page.Response.Redirect(URLPRINCIPAL +
					KEYQIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDOESPECIFICOS +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + 
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre Proceso
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Codigo SubProceso
					CODIGOSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre SubProces
					NOMBRESUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Codigo OE
					CODIGOOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					//Nombre OE
					NOMBREOE +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]
					);
				#endregion
			}
			else
			{
				#region Plan Estrategico
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
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON + 
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]) +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Codigo OE
						CODIGOOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Nombre OE
						NOMBREOE +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[KEYQFILTRO]
					);
				#endregion
			}
		}
		*/
		#endregion

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
					//					}
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
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarTitulos()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				this.LlenarTitulosPlanDirector();
			}
			else
			{
				this.LlenarTitulosPlanEstrategico();
			}
		}

		public void LlenarTitulosPlanDirector()
		{
			this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
			this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();
			this.lblSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper();
			this.lblNombreSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper();
			this.lblOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]).ToUpper();
			this.lblNombreOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]).ToUpper();

		}

		public void LlenarTitulosPlanEstrategico()
		{
			this.lblProceso.Text = "OG" + Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()];
			this.lblNombreProceso.Text = Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()].ToUpper();
			this.lblOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()]).ToUpper();
			this.lblNombreOEspecifico.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.NOMBREOESPECIFICOS.ToString()]).ToUpper();
		}


		public void LlenarJScript()
		{
			this.ibtnBuscarLider.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDALIDER + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),750,500,true));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.Exportar implementation
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
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.ValidarFiltros implementation
			return false;
		}


		public void LlenarCombos()
		{
			// TODO:  Add DetalleAccion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAccion.LlenarDatos implementation
		}

		#endregion
	}
}
