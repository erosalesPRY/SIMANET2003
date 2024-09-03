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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleEvaluacionInduccionSI.
	/// </summary>
	public class DetalleEvaluacionInduccionSI : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFechVence;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNombreCM;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroMedico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CheckBox chkAprobado;
		protected System.Web.UI.WebControls.Label Label6;
		protected eWorld.UI.NumericBox nNota;

		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEVALUACION ="idEva";
		const string KEYQNOMTRAB ="NomTrab";

		const string KEYQPERIODOEM ="PeriodoEM";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroDNI;
		const string KEYQIDEXAMENEM ="idExaEM";
		
		


		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}
	
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdEvaluacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDEVALUACION]);}
		}
		private string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQNOMTRAB];}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					
					this.CargarModoPagina();	
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			EvaluacionInduccionBE oEvaluacionInduccionBE= new EvaluacionInduccionBE();
			oEvaluacionInduccionBE.NroDNI = this.hNroDNI.Value;
			oEvaluacionInduccionBE.FechaInicio = this.CalFechaInicio.SelectedDate;
			oEvaluacionInduccionBE.FechaVencimiento = this.CalFechVence.SelectedDate;
			oEvaluacionInduccionBE.Aprobado = this.chkAprobado.Checked;
			oEvaluacionInduccionBE.Nota = Convert.ToInt32( this.nNota.Text);

			
			int retorno = (new CCCTT_InduccionEvaluacion()).Insertar(oEvaluacionInduccionBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró evaluacion de inducción. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADENDAS));
			}


		}

		public void Modificar()
		{
			EvaluacionInduccionBE oEvaluacionInduccionBE= new EvaluacionInduccionBE();
			oEvaluacionInduccionBE.Periodo = this.Periodo;
			oEvaluacionInduccionBE.IdEvaluacion = this.IdEvaluacion;
			oEvaluacionInduccionBE.NroDNI = this.hNroDNI.Value;
			oEvaluacionInduccionBE.FechaInicio = this.CalFechaInicio.SelectedDate;
			oEvaluacionInduccionBE.FechaVencimiento = this.CalFechVence.SelectedDate;
			oEvaluacionInduccionBE.Aprobado = this.chkAprobado.Checked==true;
			oEvaluacionInduccionBE.Nota = Convert.ToInt32( this.nNota.Text);

			
			int retorno = (new CCCTT_InduccionEvaluacion()).Modificar(oEvaluacionInduccionBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró evaluacion de inducción. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADENDAS));
			}
			// TODO:  Add DetalleEvaluacionInduccionSI.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.Eliminar implementation
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
					this.txtTrabajador.ReadOnly=true;
					this.CargarModoModificar();
					break;
				
			}			
		}

		public void CargarModoNuevo()
		{
			if(this.ApellidosyNombres!=null){
				this.txtTrabajador.ReadOnly=true;
				this.txtTrabajador.Text = this.ApellidosyNombres;
				this.hNroDNI.Value = this.NroDNI.ToString();
			}
		}

		public void CargarModoModificar()
		{
			EvaluacionInduccionBE oEvaluacionInduccionBE = (EvaluacionInduccionBE)(new CCCTT_InduccionEvaluacion()).ListarDetalle(this.NroDNI,this.Periodo,this.IdEvaluacion);
			this.txtTrabajador.Text = oEvaluacionInduccionBE.ApellidosyNombres;
			this.CalFechaInicio.SelectedDate = oEvaluacionInduccionBE.FechaInicio;
			this.CalFechVence.SelectedDate = oEvaluacionInduccionBE.FechaVencimiento;
			this.chkAprobado.Checked = oEvaluacionInduccionBE.Aprobado;
			this.nNota.Text = oEvaluacionInduccionBE.Nota.ToString();
			this.hNroDNI.Value = this.NroDNI;
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleEvaluacionInduccionSI.ValidarExpresionesRegulares implementation
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
