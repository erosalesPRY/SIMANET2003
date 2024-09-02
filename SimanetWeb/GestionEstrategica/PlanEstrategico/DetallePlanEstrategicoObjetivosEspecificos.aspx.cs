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
	/// Summary description for DetallePlanEstrategicoObjetivosEspecificos.
	/// </summary>
	public class DetallePlanEstrategicoObjetivosEspecificos : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constante
		const string KEYQIDOBJETIVOGENERAL="idObjGen";
		const string KEYQIDOBJETIVOESPECIFICO="idObjEsp";
		const string URLDETALLE="DetallePlanEstrategicoObjetivosEspecificos.aspx";

		const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";
		const string KEYQCODDOBJETIVOGENERAL="CodObjGen";
		const string KEYQOBJETIVOGENERALNOMBRE="ObjGenNombre";

		#endregion
		int idObjetivoGeneral
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETIVOGENERAL]);}
		}
		int idObjetivoEspecifico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETIVOESPECIFICO]);}
		}

		string PlanEstrategicoNombre
		{
			get{return Page.Request.Params[KEYQPLANESTRATEGICONOMBRE].ToString();}
		}

		string CodigoObjetivoGeneral
		{
			get{return Page.Request.Params[KEYQCODDOBJETIVOGENERAL].ToString();}
		}
		string NombreObjetivoGeneral
		{
			get{return Page.Request.Params[KEYQOBJETIVOGENERALNOMBRE].ToString();}
		}

		#region Controles

		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCodigo;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnDescripcion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblPlanEstrategico;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblCodObjGeneral;
		protected System.Web.UI.WebControls.Label lblObjetivoGeneral;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras1;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.WebControls.CheckBox chkTotalVisible;
		protected System.Web.UI.WebControls.Label Label7;
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
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarCentroOperativos();
		}
		private void LlenarCentroOperativos()
		{
			ddlCentroOperativo.DataSource = (new CCentroOperativo()).ListarTodosCombo();
			ddlCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			ddlCentroOperativo.DataBind();
		}
		public void LlenarDatos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvnCodigo.ErrorMessage = "No se ha ingresado Código de Objetivo Especifico";
			rfvnCodigo.ToolTip = rfvnCodigo.ErrorMessage ;

			rfvnDescripcion.ErrorMessage = "No se ha ingresado Descripcion de Objetivo Especifico";
			rfvnDescripcion.ToolTip = rfvnDescripcion.ErrorMessage;

			this.txtCodigo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí el código de objetivo especifico",150));
			this.txtDescripcion.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Ingrese aquí la descripción de objetivo especifico",150));
			this.ddlCentroOperativo.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString(),Helper.ToolTipsBallon("Seleccione aquí el centro de operaciones para este objetivo especifico",150));

			this.lblPlanEstrategico.Text = this.PlanEstrategicoNombre;
			this.lblCodObjGeneral.Text = this.CodigoObjetivoGeneral;
			this.lblObjetivoGeneral.Text = this.NombreObjetivoGeneral;
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEObjetivoEspecificoBE oPEObjetivoEspecificoBE = new PEObjetivoEspecificoBE();
			oPEObjetivoEspecificoBE.IdObjetivoGeneral = this.idObjetivoGeneral;
			oPEObjetivoEspecificoBE.Codigo = this.txtCodigo.Text.ToUpper();
			oPEObjetivoEspecificoBE.Descripcion = this.txtDescripcion.Text.ToUpper();
			oPEObjetivoEspecificoBE.IdcentroOperativo = Convert.ToInt32(this.ddlCentroOperativo.SelectedValue);
			oPEObjetivoEspecificoBE.FlagTotalVisible = Convert.ToInt32(chkTotalVisible.Checked);
			if(Convert.ToInt32((new CPEObjetivoEspecifico()).Insertar(oPEObjetivoEspecificoBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Estrategico-Objetivo Especifico",this.ToString(),"Se registró Item de Plan Estrategico-Objetivo Especifico" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(Page);
			}
		}

		public void Modificar()
		{
			PEObjetivoEspecificoBE oPEObjetivoEspecificoBE = new PEObjetivoEspecificoBE();
			oPEObjetivoEspecificoBE.IdObjetivoGeneral = this.idObjetivoGeneral;
			oPEObjetivoEspecificoBE.IdObjetivoEspecifico = this.idObjetivoEspecifico;
			oPEObjetivoEspecificoBE.Codigo = this.txtCodigo.Text.ToUpper();
			oPEObjetivoEspecificoBE.Descripcion = this.txtDescripcion.Text.ToUpper();
			oPEObjetivoEspecificoBE.IdcentroOperativo = Convert.ToInt32(this.ddlCentroOperativo.SelectedValue);
			oPEObjetivoEspecificoBE.FlagTotalVisible = Convert.ToInt32(chkTotalVisible.Checked);

			if(Convert.ToInt32((new CPEObjetivoEspecifico()).Modificar(oPEObjetivoEspecificoBE)) >0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Plan Estrategico-Objetivo Especifico",this.ToString(),"Se registró Item de Plan Estrategico-Objetivo Especifico" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(Page);
			}
		}

		public void Eliminar()
		{
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
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.CargarModoNuevo implementation
		}

		public void CargarDatos()
		{
			PEObjetivoEspecificoBE oPEObjetivoEspecificoBE = (PEObjetivoEspecificoBE)(new CPEObjetivoEspecifico()).ListarDetalle(this.idObjetivoGeneral,this.idObjetivoEspecifico);
			this.txtCodigo.Text = oPEObjetivoEspecificoBE.Codigo;
			this.txtDescripcion.Text = oPEObjetivoEspecificoBE.Descripcion;
			ListItem item = this.ddlCentroOperativo.Items.FindByValue(oPEObjetivoEspecificoBE.IdcentroOperativo.ToString());
			if(item!=null){item.Selected=true;}

			chkTotalVisible.Checked = Convert.ToBoolean(oPEObjetivoEspecificoBE.FlagTotalVisible);
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
			this.ddlCentroOperativo.Attributes.Remove(Utilitario.Enumerados.EventosJavaScript.OnMouseover.ToString());
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePlanEstrategicoObjetivosEspecificos.ValidarExpresionesRegulares implementation
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
