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
	/// Summary description for DetallePlanEstrategicoObjetivoGeneral.
	/// </summary>
	public class DetallePlanEstrategicoObjetivoGeneral : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constante
			const string KEYQIDPLANESTRATEGICO="idPLEstr";
			const string KEYQIDOBJETIVOGENERAL="idObjGen";
			const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";
		#endregion
		int idPlanEstrategico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]);}
		}
		int idObjetivoGeneral
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETIVOGENERAL]);}
		}
		string PlanEstrategicoNombre
		{
			get{return Page.Request.Params[KEYQPLANESTRATEGICONOMBRE].ToString();}
		}
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.TextBox txtFundamento;
		protected System.Web.UI.WebControls.TextBox txtRequerimiento;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblPlanEstrategico;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras1;
		protected System.Web.UI.WebControls.TextBox txtTema;
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
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPlanEstrategico.Text = this.PlanEstrategicoNombre;
		}

		public void LlenarJScript()
		{
			rfvnCodigo.ErrorMessage = "No se ha ingresado Código de Objetivo General";
			rfvnCodigo.ToolTip = rfvnCodigo.ErrorMessage ;

			rfvnDescripcion.ErrorMessage = "No se ha ingresado Descripcion de Objetivo General";
			rfvnDescripcion.ToolTip = rfvnDescripcion.ErrorMessage;

			this.txtCodigo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el código de objetivo general",150));
			this.txtDescripcion.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la descripción de objetivo general",150));
			this.txtFundamento.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el fundamento de objetivo general",150));
			this.txtRequerimiento.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el requerimiento de objetivo general",150));
			this.txtTema.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el tema del objetivo general",150));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEObjetivoGeneralBE oPEObjetivoGeneralBE = new PEObjetivoGeneralBE();
			oPEObjetivoGeneralBE.IdPlanEstrategico = this.idPlanEstrategico;
			oPEObjetivoGeneralBE.Codigo= this.txtCodigo.Text.ToUpper();
			oPEObjetivoGeneralBE.Descripcion= this.txtDescripcion.Text.ToUpper();
			oPEObjetivoGeneralBE.Fundamento= this.txtFundamento.Text.ToUpper();
			oPEObjetivoGeneralBE.Requerimiento= this.txtRequerimiento.Text.ToUpper();
			oPEObjetivoGeneralBE.Tema = this.txtTema.Text.ToUpper();
			if(Convert.ToInt32((new CPEObjetivoGeneral()).Insertar(oPEObjetivoGeneralBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Estrategico-Objetivo General",this.ToString(),"Se registró Item de Plan Estrategico-Objetivo General" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(Page);
			}				
		}

		public void Modificar()
		{
			PEObjetivoGeneralBE oPEObjetivoGeneralBE = new PEObjetivoGeneralBE();
			oPEObjetivoGeneralBE.IdObjetivoGeneral = this.idObjetivoGeneral;
			oPEObjetivoGeneralBE.IdPlanEstrategico= this.idPlanEstrategico;
			oPEObjetivoGeneralBE.Codigo= this.txtCodigo.Text.ToUpper();
			oPEObjetivoGeneralBE.Descripcion= this.txtDescripcion.Text.ToUpper();
			oPEObjetivoGeneralBE.Fundamento= this.txtFundamento.Text.ToUpper();
			oPEObjetivoGeneralBE.Requerimiento= this.txtRequerimiento.Text.ToUpper();
			oPEObjetivoGeneralBE.Tema = this.txtTema.Text.ToUpper();
			if(Convert.ToInt32((new CPEObjetivoGeneral()).Modificar(oPEObjetivoGeneralBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Estrategico-Objetivo General",this.ToString(),"Se registró Item de Plan Estrategico-Objetivo General" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(Page);
			}				
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.Eliminar implementation
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
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.CargarModoNuevo implementation
		}

		public void CargarDatos()
		{
			PEObjetivoGeneralBE oPEObjetivoGeneralBE= (PEObjetivoGeneralBE) (new CPEObjetivoGeneral()).ListarDetalle(this.idPlanEstrategico,this.idObjetivoGeneral);
			this.txtCodigo.Text = oPEObjetivoGeneralBE.Codigo;
			this.txtDescripcion.Text = oPEObjetivoGeneralBE.Descripcion;
			this.txtFundamento.Text = oPEObjetivoGeneralBE.Fundamento.ToString();
			this.txtRequerimiento.Text = oPEObjetivoGeneralBE.Requerimiento.ToString();
			this.txtTema.Text = oPEObjetivoGeneralBE.Tema.ToString();
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
			this.txtCodigo.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
			this.txtDescripcion.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
			this.txtFundamento.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
			this.txtRequerimiento.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
			this.txtTema.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());

		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivoGeneral.ValidarExpresionesRegulares implementation
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
