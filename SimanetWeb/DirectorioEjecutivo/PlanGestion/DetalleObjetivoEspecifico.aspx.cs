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
	/// Summary description for DetalleObjetivoEspecifico.
	/// </summary>
	public class DetalleObjetivoEspecifico : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblAF;
		protected System.Web.UI.WebControls.Label lblAE;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreProceso;
		protected eWorld.UI.NumericBox txtAvanceEconomica;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator RangeDomValidator1;
		protected eWorld.UI.NumericBox txtAvanceFinanciero;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator RangeDomValidator2;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.TextBox txtCodigoOE;
		protected System.Web.UI.WebControls.TextBox txtNombreOE;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		#region Constantes
		
		//Titulos 
		const string KEYQFILTRO = "IDVISIBILIDAD";
		const string TITULOMODONUEVO = "NUEVO OBJETIVO ESPECIFICO";
		const string TITULOMODOMODIFICAR = "MODIFICAR OBJETIVO ESPECIFICO";
		const string TEXTONOSP = "SP NO ASIGNADO";
		const string VALORNOSP = "0";

		//Key Session y QueryString
		const string JSUBIRHISTORIAL="HistorialIrAtras();";
		const string KEYQID = "Id";

		const string KEYQIDOGENERAL = "IDOGENERALES";
		const string KEYOGENERALTEXTO = "DESCRIPCION";
		const string KEYQIDPROCESO = "idProceso";
		const string KEYIDSUBPROCESO = "idSubProceso";
		const string CODIGOPROCESO = "CodigoProceso";
		const string NOMBREPROCESO = "NombreProceso";
		const string CODIGOSUBPROCESO = "CodigoSubproceso";
		const string NOMBRESUBPROCESO = "Descripcion";
		const string PE = "PlanEstrategico";
	
		//Paginas
		const string URLPRINCIPAL = "AdministrarObjetivoEspecifico.aspx?";
		protected System.Web.UI.WebControls.Label lblOG;
		protected System.Web.UI.WebControls.DropDownList ddlbObjetivoGenerales;
		protected System.Web.UI.WebControls.Label lblProceso;
		protected System.Web.UI.WebControls.Label lblNombreProceso;
		protected System.Web.UI.WebControls.Label lblSubProceso;
		protected System.Web.UI.WebControls.Label lblNombreSubProceso;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.TextBox txtLider;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarLider;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbSubProceso;
		protected System.Web.UI.WebControls.Image Image1;
		protected System.Web.UI.WebControls.Label lblCO;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		const string URLBUSQUEDALIDER = "BusquedaLider.aspx?";
		
		#endregion Constantes		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
			ObjetivoEspecificoBE oObjetivoEspecificoBE = new ObjetivoEspecificoBE();
			oObjetivoEspecificoBE.IDSUBPROCESO = Convert.ToInt32(ddlbSubProceso.SelectedValue);
			oObjetivoEspecificoBE.IDOGENERALES = Convert.ToInt32(Page.Request.QueryString[KEYQIDOGENERAL]);//Convert.ToInt32(ddlbObjetivoGenerales.SelectedValue);
			//oObjetivoEspecificoBE.CODIGOOESPECIFICOS= txtCodigoOE.Text;
			oObjetivoEspecificoBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			oObjetivoEspecificoBE.NOMBREOESPECIFICOS = txtNombreOE.Text;
			oObjetivoEspecificoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oObjetivoEspecificoBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadosPlanDirector);
			oObjetivoEspecificoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Activo);
			
			if(this.txtAvanceEconomica.Text!=String.Empty)
			{
				oObjetivoEspecificoBE.AE = Convert.ToDouble(txtAvanceEconomica.Text);
			}
			else
			{
				oObjetivoEspecificoBE.AE = 0;
			}
			
			if(this.txtAvanceFinanciero.Text!=String.Empty)
			{
				oObjetivoEspecificoBE.AF = Convert.ToDouble(txtAvanceFinanciero.Text);
			}	
			else
			{
				oObjetivoEspecificoBE.AF = 0;
			}

			//oObjetivoEspecificoBE.PE = txtResponsable.Text;
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oObjetivoEspecificoBE.IDCARGOLIDER = Convert.ToInt32( this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oObjetivoEspecificoBE.IDAREALIDER = Convert.ToInt32(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oObjetivoEspecificoBE.IDPERSONALLIDER = Convert.ToInt32(this.hIdPersonalLider.Value);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Insertar(oObjetivoEspecificoBE)>0)
			{
				//Graba en el Log la acción ejecutada
				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICAROBJETIVOESPECIFICO),URLPRINCIPAL + 
						KEYQIDPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()].ToUpper() +
						Utilitario.Constantes.SIGNOAMPERSON +
						NOMBREPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()].ToUpper() +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()].ToUpper() +
						Utilitario.Constantes.SIGNOAMPERSON +
						NOMBRESUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()].ToUpper()
						);
					#endregion
				}
				else
				{
					#region Plan Estrategico
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICAROBJETIVOESPECIFICO)) + JSUBIRHISTORIAL;
					/*ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICAROBJETIVOESPECIFICO),URLPRINCIPAL + 
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Plan Estrategico
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()])
						);*/
					
					#endregion 
				}
			}
		}

		public void Modificar()
		{
			ObjetivoEspecificoBE oObjetivoEspecificoBE = new ObjetivoEspecificoBE();
			oObjetivoEspecificoBE.IDOESPECIFICOS = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);
			oObjetivoEspecificoBE.IDSUBPROCESO = Convert.ToInt32(ddlbSubProceso.SelectedIndex);
			oObjetivoEspecificoBE.IDOGENERALES =Convert.ToInt32(Page.Request.QueryString[KEYQIDOGENERAL]); //Convert.ToInt32(ddlbObjetivoGenerales.SelectedIndex);
			oObjetivoEspecificoBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedIndex);
			oObjetivoEspecificoBE.CODIGOOESPECIFICOS= txtCodigoOE.Text;
			oObjetivoEspecificoBE.NOMBREOESPECIFICOS = txtNombreOE.Text;
			oObjetivoEspecificoBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			oObjetivoEspecificoBE.IdEstado = Convert.ToInt32(Enumerados.EstadoPlanDirector.Modificado);
			
			if(this.txtAvanceEconomica.Text!=String.Empty)
			{
				oObjetivoEspecificoBE.AE = Convert.ToDouble(txtAvanceEconomica.Text);
			}
			else
			{
				oObjetivoEspecificoBE.AE = 0;
			}
			
			if(this.txtAvanceFinanciero.Text!=String.Empty)
			{
				oObjetivoEspecificoBE.AF = Convert.ToDouble(txtAvanceFinanciero.Text);
			}	
			else
			{
				oObjetivoEspecificoBE.AF = 0;
			}
			
			//oObjetivoEspecificoBE.PE = txtResponsable.Text;
			if(this.hidCargoLider.Value!=String.Empty)
			{
				oObjetivoEspecificoBE.IDCARGOLIDER = Convert.ToInt32( this.hidCargoLider.Value);
			}
			if(this.hIdAreaLider.Value!=String.Empty)
			{
				oObjetivoEspecificoBE.IDAREALIDER = Convert.ToInt32(this.hIdAreaLider.Value);
			}
			if(this.hIdPersonalLider.Value!=String.Empty)			
			{
				oObjetivoEspecificoBE.IDPERSONALLIDER = Convert.ToInt32(this.hIdPersonalLider.Value);
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();
			if(oCMantenimientos.Modificar(oObjetivoEspecificoBE)>0)
			{
				int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

				if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
				{	
					#region Plan Director
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICAROBJETIVOESPECIFICO),URLPRINCIPAL + 
						KEYQIDPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYIDSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()].ToUpper() +
						Utilitario.Constantes.SIGNOAMPERSON +
						NOMBREPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()].ToUpper() +
						Utilitario.Constantes.SIGNOAMPERSON +
						CODIGOSUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()].ToUpper() +
						Utilitario.Constantes.SIGNOAMPERSON +
						NOMBRESUBPROCESO +
						Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()].ToUpper()
						);
					#endregion
				}
				else
				{
					#region Plan Estrategico
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan de Gestion",this.ToString(),"Se modificó el Objetivo Especifico Nro. " + Page.Request.QueryString[Utilitario.Enumerados.ColumnasObjetivosEspecificos.CODIGOOESPECIFICOS.ToString()] + ".",Enumerados.NivelesErrorLog.I.ToString()));
					/*
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICAROBJETIVOESPECIFICO),URLPRINCIPAL + 
						KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL +
						Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
						Utilitario.Constantes.SIGNOAMPERSON +
						//Plan Estrategico
						PE +
						Utilitario.Constantes.SIGNOIGUAL +
						Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()])
						);
						*/
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionEstrategica.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICAROBJETIVOESPECIFICO)) + JSUBIRHISTORIAL;
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
				this.llenarSubProcesos();
				this.llenarObjetivosGenerales();
				this.LlenarTitulos();
				this.llenarCentrosOperativos();
				//ddlbObjetivoGenerales.Items.FindByValue(Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()]).Selected = true;
		}

		public void CargarModoModificar()
		{
			this.LlenarCombos();
			//int idProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()]);
			//int idSubProceso = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()]);
			int idOEspecificos = Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosEspecificos.IDOESPECIFICOS.ToString()]);
			this.LlenarTitulos();
			lblTitulo.Text = TITULOMODOMODIFICAR;

						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			ObjetivoEspecificoBE oObjetivoEspecificoBE = (ObjetivoEspecificoBE)oCMantenimientos.ListarDetalle(idOEspecificos,Enumerados.ClasesNTAD.ObjetivoEspecificoNTAD.ToString());
		
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"PlanGestion",this.ToString(),"Se consultó el Detalle del SubProceso del Plan de Gestión " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oObjetivoEspecificoBE!=null)
			{
				this.ddlbObjetivoGenerales.Items.FindByValue(oObjetivoEspecificoBE.IDOGENERALES.ToString()).Selected = true;
				this.ddlbSubProceso.Items.FindByValue(oObjetivoEspecificoBE.IDSUBPROCESO.ToString()).Selected = true;
				if(oObjetivoEspecificoBE.IdCentroOperativo.ToString() != String.Empty)
				{
					this.ddlbCentroOperativo.Items.FindByValue(oObjetivoEspecificoBE.IdCentroOperativo.ToString()).Selected = true;
				}				
				this.txtCodigoOE.Text = oObjetivoEspecificoBE.CODIGOOESPECIFICOS.ToString();
				this.txtNombreOE.Text = oObjetivoEspecificoBE.NOMBREOESPECIFICOS.ToString();
				this.txtAvanceEconomica.Text = oObjetivoEspecificoBE.AE.ToString();
				this.txtAvanceFinanciero.Text = oObjetivoEspecificoBE.AF.ToString();
				this.txtLider.Text = oObjetivoEspecificoBE.LIDER.ToString();
				this.hidCargoLider.Value = oObjetivoEspecificoBE.IDCARGOLIDER.ToString();
				this.hIdAreaLider.Value = oObjetivoEspecificoBE.IDAREALIDER.ToString();
				this.hIdPersonalLider.Value = oObjetivoEspecificoBE.IDPERSONALLIDER.ToString();
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
			/*
			if(this.txtCodigoOE.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}

			if(this.txtNombreOE.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARCAMPOREQUERIDOCLIENTEPERSONAL));
				return false;
			}
			*/

			if(ddlbCentroOperativo.SelectedValue == Utilitario.Constantes.VALORSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert("Tiene que seleccionar un Centro Operativo");
				return false;
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			//			if(!ExpresionesRegulares.ValidarExpresionRegularEnterosPositivos(Server.HtmlEncode(this.txtAlcance.Text)))
			//			{
			//				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJELISTAPROTOCOLARDATOSINCORRECTOSCANTIDAD));
			//				return false;
			//			}
			return true;
		}

		#endregion

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

		public void LlenarCombos()
		{
			ListItem lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			ListItem lItemSubProceso = new ListItem(TEXTONOSP,VALORNOSP);
			this.llenarObjetivosGenerales();
			this.llenarSubProcesos();
			this.llenarCentrosOperativos();

			//ddlbObjetivoGenerales.Items.Insert(0,lItem);
			this.ddlbObjetivoGenerales.Items.Insert(Utilitario.Constantes.POSICIONCONTADOR,lItem);
			this.ddlbSubProceso.Items.Insert(Utilitario.Constantes.POSICIONCONTADOR,lItem);
			this.ddlbSubProceso.Items.Insert(Utilitario.Constantes.POSICIONTOTAL,lItemSubProceso);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePresentesOtorgadosPorTipoPersona.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarLider.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDALIDER + Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString(),750,500,true));
			//this.ibtnCancelar.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"CambiarColorPasarMouse(this, true);");
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

		#endregion

		private void llenarCentrosOperativos()
		{
			ListItem lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			CCentroOperativo oCCentroOperativo =  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
			ddlbCentroOperativo.Items.Insert(0,lItem);
		}
        
		private void llenarObjetivosGenerales()
		{
			CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
			ddlbObjetivoGenerales.DataSource = oCObjetivoGeneral.ListarObjetivoGeneral();
			ddlbObjetivoGenerales.DataValueField = Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString();
			ddlbObjetivoGenerales.DataTextField = Utilitario.Enumerados.ColumnasObjetivosGenerales.DATOSCOMBO.ToString();
			ddlbObjetivoGenerales.DataBind();
		}

		private void llenarSubProcesos()
		{
			CObjetivoGeneral oCObjetivoGeneral =  new CObjetivoGeneral();
			ddlbSubProceso.DataSource = oCObjetivoGeneral.ListarSubProcesos();
			ddlbSubProceso.DataValueField = Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString();		
			ddlbSubProceso.DataTextField = Utilitario.Enumerados.ColumnasSubProceso.DATOSCOMBO.ToString();
			ddlbSubProceso.DataBind();
		}

		private void LlenarTitulos()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				//Plan Director
				this.LlenarTitulosPlanDirector();
			}
			else
			{
				//Plan Estrategico
				this.LlenarTitulosPlanEstrategico();
			}
		}

		public void LlenarTitulosPlanDirector()
		{
			this.lblProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()]).ToUpper();
			this.lblNombreProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()]).ToUpper();
			this.lblSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()]).ToUpper();
			this.lblNombreSubProceso.Text = Convert.ToString(Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()]).ToUpper();
		}

		public void LlenarTitulosPlanEstrategico()
		{
			this.lblProceso.Text = "OG" + Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()];
			this.lblNombreProceso.Text = Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()].ToUpper();			
		}

		#region MetodoRedireccionaraPaginaPrincipal 
		/*
		private void redireccionaPaginaPrincipal()
		{
			int origen = Convert.ToInt32(Page.Request.QueryString[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()]);

			if(origen != Convert.ToInt32(Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico))
			{	
				#region Plan Director
				//Graba en el Log la acción ejecutada
				
					Page.Response.Redirect(URLPRINCIPAL +
					KEYQIDPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.IdProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.IdSubProceso.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					CODIGOPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.CodigoProceso.ToString()].ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON +
					NOMBREPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasProceso.NombreProceso.ToString()].ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON +
					CODIGOSUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.CodigoSubproceso.ToString()].ToUpper() +
					Utilitario.Constantes.SIGNOAMPERSON +
					NOMBRESUBPROCESO +
					Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[Utilitario.Enumerados.ColumnasSubProceso.Descripcion.ToString()].ToUpper()
					);
				#endregion
			}
			else
			{
				Page.Response.Redirect
				(
					URLPRINCIPAL+
					KEYQIDOGENERAL + Utilitario.Constantes.SIGNOIGUAL + 
					Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.IDOGENERALES.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYOGENERALTEXTO + Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.Params[Utilitario.Enumerados.ColumnasObjetivosGenerales.DESCRIPCION.ToString()] +
					Utilitario.Constantes.SIGNOAMPERSON +
					PE +
					Utilitario.Constantes.SIGNOIGUAL +
					Convert.ToInt32(Page.Request.Params[Utilitario.Enumerados.OpcionModuloGestionEstrategica.PlanEstrategico.ToString()])  +
					Utilitario.Constantes.SIGNOAMPERSON + KEYQFILTRO + Utilitario.Constantes.SIGNOIGUAL +
					Page.Request.QueryString[KEYQFILTRO]
				);
			}
		}
		*/
		#endregion
	
		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(ValidarCampos())
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
		}
	
}
