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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.EntidadesNegocio.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for DetallePlanEstrategicoBase.
	/// </summary>
	public class DetallePlanEstrategicoBase : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		#region Constantes
			const string KEYQIDPLANESTRATEGICO="idPLEstr";
		#endregion
		private int idPlanEstategico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]);}
		}
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected eWorld.UI.CalendarPopup CalFechaFinal;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnDescripcion;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
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
					this.LlenarDatos();
					this.LlenarCombos();
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePlanEstrategicoBase.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoBase.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoBase.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetallePlanEstrategicoBase.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePlanEstrategicoBase.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvnDescripcion.ErrorMessage = "No se ha ingresado Descripcion del Plan Estrategico";
			rfvnDescripcion.ToolTip = rfvnDescripcion.ErrorMessage ;
			this.txtDescripcion.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí una descripción del plan estrategico",150));
			this.CalFechaInicio.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la fecha de inicio del plan estratégico",150));
			this.CalFechaFinal.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la fecha de finalización del plan estratégico",120));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoBase.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoBase.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoBase.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePlanEstrategicoBase.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePlanEstrategicoBase.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEBaseBE oPEBaseBE = new PEBaseBE();
			oPEBaseBE.PeriodoInicial  = this.CalFechaInicio.SelectedDate;
			oPEBaseBE.PeriodoFinal= this.CalFechaFinal.SelectedDate;
			oPEBaseBE.Descripcion= this.txtDescripcion.Text.ToUpper();

			if(Convert.ToInt32((new CPEBase()).Insertar(oPEBaseBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Estrategico",this.ToString(),"Se registró Item de Plan Estrategico" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				Helper.MensajeRetornoAlert(Page);
			}		
		}

		public void Modificar()
		{
			PEBaseBE oPEBaseBE = new PEBaseBE();
			oPEBaseBE.IdPlanEstrategico = this.idPlanEstategico;
			oPEBaseBE.PeriodoInicial  = this.CalFechaInicio.SelectedDate;
			oPEBaseBE.PeriodoFinal= this.CalFechaFinal.SelectedDate;
			oPEBaseBE.Descripcion= this.txtDescripcion.Text.ToUpper();
			if(Convert.ToInt32((new CPEBase()).Modificar(oPEBaseBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Estrategico",this.ToString(),"Se registró Item de Plan Estrategico" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				Helper.MensajeRetornoAlert(Page);
			}		
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePlanEstrategicoBase.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
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
			// TODO:  Add DetallePlanEstrategicoBase.CargarModoNuevo implementation
		}

		public void CargarDatos()
		{
			PEBaseBE OPEBaseBE = (PEBaseBE) (new CPEBase()).ListarDetalle(Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]));
			this.CalFechaInicio.SelectedDate = OPEBaseBE.PeriodoInicial;
			this.CalFechaFinal.SelectedDate = OPEBaseBE.PeriodoFinal;
			this.txtDescripcion.Text= OPEBaseBE.Descripcion;
		}

		public void CargarModoModificar()
		{
			this.CargarDatos();
			this.ibtnAtras1.Visible = false;
		}

		public void CargarModoConsulta()
		{
			this.CargarDatos();
			Helper.BloquearControles(this);
			this.Table2.Visible = false;
			this.txtDescripcion.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
			this.CalFechaInicio.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
			this.CalFechaFinal.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());

		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePlanEstrategicoBase.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePlanEstrategicoBase.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePlanEstrategicoBase.ValidarExpresionesRegulares implementation
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}
	}
}
