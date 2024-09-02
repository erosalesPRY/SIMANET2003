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
using SIMA.EntidadesNegocio.GestionEstrategica.PlanEstrategico;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for DetallePlanEstrategicoAccion.
	/// </summary>
	public class DetallePlanEstrategicoAccion : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCodigoAccion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNombreAccion;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.DropDownList ddlbGrupoCC;
		protected System.Web.UI.WebControls.Label lblNombrePlanBase;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjEsp;
		protected System.Web.UI.WebControls.Label lblObjEsp;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator rfvNombreAccion;
		protected System.Web.UI.WebControls.DomValidators.RangeDomValidator rfvGrupoCC;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigoAccion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnNombreAccion;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvnGrupoCC;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbGrupoCC;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.HtmlControls.HtmlTable Table8;
		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA ACCION";
		const string TITULOMODOMODIFICAR = "MODIFICAR ACCION";
		const string TITULOMODOCONSULTAR = "CONSULTAR ACCION";

		//Key Session y QueryString
		const string NOMBREPLANBASE = "PLEstrNombre";
		const string NOMBREOBJGRAL  = "ObjGenNombre";
		const string NOMBREOBJESP   = "idObjEspNombre";

		const string KEYIDOBJGRAL   = "idObjGen";
		const string KEYIDOBJESP    = "idObjEsp";
		const string KEYIDACCION    = "IdAccion";

		const string KEYCODOBJGRAL  = "CodObjGen";
		const string KEYCODOBJESP   = "CodObjEsp";

		const string KEYIDCO    = "idCentro";
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
	
		//Paginas
		
		#endregion Constantes		

		#region Variables
		private ListItem item = new ListItem();
		#endregion

	
		private void CargarGrupodeCentroCosto()
		{
			/*ddlbGrupoCC.DataSource =  (new CGrupoCentroCosto()).ListarGrupoCCPorCentroOperativo(Convert.ToInt32(Page.Request.QueryString[KEYIDCO].ToString()));
			ddlbGrupoCC.DataValueField = Enumerados.ColumnasGrupoCentroCosto.IdGrupoCC.ToString();
			ddlbGrupoCC.DataTextField = Enumerados.ColumnasGrupoCentroCosto.Nombre.ToString();
			ddlbGrupoCC.DataBind();
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbGrupoCC.Items.Insert(0,item);*/
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
//					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
//					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					ltlMensaje.Text = Helper.MensajeAlert(oException.Message);	
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
			// TODO:  Add DetallePlanEstrategicoAccion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoAccion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoAccion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarGrupodeCentroCosto();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvCodigoAccion.ErrorMessage = "Debe Ingresar Código de Acción";
			rfvCodigoAccion.ToolTip = rfvCodigoAccion.ErrorMessage;

			rfvnNombreAccion.ErrorMessage = "Debe Ingresar Descripción de Acción";
			rfvnNombreAccion.ToolTip = rfvnNombreAccion.ErrorMessage;

			rfvnGrupoCC.ErrorMessage = "Debe Seleccionar Grupo de Centro de Costos";
			rfvnGrupoCC.ToolTip = rfvnGrupoCC.ErrorMessage;

		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEAccionBE oPEAccionBE = new PEAccionBE();
			oPEAccionBE.IDOBJETIVOESPECIFICO = Convert.ToInt32(Page.Request.QueryString[KEYIDOBJESP]);
			oPEAccionBE.CODIGO = txtCodigoAccion.Text.ToUpper();
			oPEAccionBE.DESCRIPCION = txtNombreAccion.Text.ToUpper();
			//oPEAccionBE.IDGRUPOCC = Convert.ToInt32(ddlbGrupoCC.SelectedValue);
			oPEAccionBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oPEAccionBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.TablaPEACCION);
			oPEAccionBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPEACCION.Activo);


			if (Convert.ToInt32((new CMantenimientos()).Insertar(oPEAccionBE))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Acción",this.ToString(),"Se registró Item de Accion" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}

		}

		public void Modificar()
		{
			PEAccionBE oPEAccionBE = new PEAccionBE();
			oPEAccionBE.IDACCION = Convert.ToInt32(Page.Request.QueryString[KEYIDACCION]);
			oPEAccionBE.IDOBJETIVOESPECIFICO = Convert.ToInt32(Page.Request.QueryString[KEYIDOBJESP]);
			oPEAccionBE.CODIGO = txtCodigoAccion.Text;
			oPEAccionBE.DESCRIPCION = txtNombreAccion.Text.ToUpper();
			//oPEAccionBE.IDGRUPOCC = Convert.ToInt32(ddlbGrupoCC.SelectedValue);

			oPEAccionBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if (Convert.ToInt32((new CMantenimientos()).Modificar(oPEAccionBE))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Acción",this.ToString(),"Se modificó Item de Accion" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.Eliminar implementation
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
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
			this.LlenarTitulos();
			ibtnAtras.Visible = false;
		}

		public void CargarDatos()
		{
			this.LlenarCombos();
			this.LlenarTitulos();
			PEAccionBE oPEAccionBE = (PEAccionBE)(new CMantenimientos()).ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDACCION].ToString()), Enumerados.ClasesNTAD.PEAccionNTAD.ToString());
			this.txtCodigoAccion.Text = oPEAccionBE.CODIGO;
			this.txtNombreAccion.Text = oPEAccionBE.DESCRIPCION;
			/*ListItem item = this.ddlbGrupoCC.Items.FindByValue(oPEAccionBE.IDGRUPOCC.ToString());
			if(item!=null){item.Selected=true;}*/
		}

		public void CargarModoModificar()
		{
			this.lblTitulo.Text = TITULOMODOMODIFICAR;
			this.CargarDatos();
			ibtnAtras.Visible = false;
			
		}

		public void CargarModoConsulta()
		{
			this.lblTitulo.Text = TITULOMODOCONSULTAR;
			this.CargarDatos();
			Helper.BloquearControles(this);
			this.Table8.Visible = false;
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(txtCodigoAccion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvCodigoAccion.ErrorMessage);
				return false;
			}

			if(txtNombreAccion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvnNombreAccion.ErrorMessage);
				return false;
			}

			/*if(ddlbGrupoCC.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvnGrupoCC.ErrorMessage);
				return false;		
			}*/

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePlanEstrategicoAccion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void LlenarTitulos()
		{
			this.lblObjGral.Text  = Page.Request.QueryString[KEYCODOBJGRAL];
			this.lblObjEsp.Text   = Page.Request.QueryString[KEYCODOBJESP];

			this.lblNombrePlanBase.Text = Page.Request.QueryString[NOMBREPLANBASE];
			this.lblNombreObjGral.Text  = Page.Request.QueryString[NOMBREOBJGRAL];
			this.lblNombreObjEsp.Text   = Page.Request.QueryString[NOMBREOBJESP];
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
//				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
//				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				ltlMensaje.Text = Helper.MensajeAlert(oException.Message);	
			}
		
		}

	}
}
