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
	/// Summary description for DetallePlanEstrategicoActividad.
	/// </summary>
	public class DetallePlanEstrategicoActividad : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblLider;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCargoLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdAreaLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonalLider;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreLider;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.WebControls.Label lblNombrePlanBase;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjEsp;
		protected System.Web.UI.WebControls.Label lblAF;
		protected eWorld.UI.NumericBox txtAvanceFinanciero;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbTipo;
		protected System.Web.UI.WebControls.DropDownList ddlbRecurso;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.WebControls.DropDownList ddlbCC;
		protected System.Web.UI.WebControls.TextBox txtCodigoActividad;
		protected System.Web.UI.WebControls.TextBox txtNombreActividad;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.DropDownList ddlbNivel;
		protected System.Web.UI.WebControls.Label lblObjEsp;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCodigoActividad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAvanceFinanciero;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTipo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNivel;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvRecurso;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombreActividad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCC;
		protected System.Web.UI.WebControls.Label lblAccion;
		protected System.Web.UI.WebControls.Label lblNombreAccion;
		protected System.Web.UI.HtmlControls.HtmlTable Table8;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbCC;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbNivel;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected eWorld.UI.NumericBox nPeriodo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPeriodo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbRecurso;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipo;
		protected System.Web.UI.WebControls.DropDownList ddlbRcs;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbRcs;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvRcs;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList ddlbImportancia;
		protected System.Web.UI.WebControls.DropDownList ddlbPrioridad;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbImportancia;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbPrioridad;
		#endregion
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA ACTIVIDAD";
		const string TITULOMODOMODIFICAR = "MODIFICAR ACTIVIDAD";
		const string TITULOMODOCONSULTAR = "CONSULTAR ACTIVIDAD";

		//Key Session y QueryString
		const string NOMBREPLANBASE = "PLEstrNombre";
		const string NOMBREOBJGRAL  = "ObjGenNombre";
		const string NOMBREOBJESP   = "idObjEspNombre";
		const string NOMBREACCION    = "ACCION";
		const string NOMBREACTIVIDAD = "ACTIVIDAD";

		const string KEYIDOBJGRAL   = "idObjGen";
		const string KEYIDOBJESP    = "idObjEsp";
		const string KEYIDACCION    = "IdAccion";
		const string KEYIDACTIVIDAD = "IdActividad";
		const string KEYIDGRUPOCC   = "IdGrupoCC";

		const string KEYCODOBJGRAL  = "CodObjGen";
		const string KEYCODOBJESP   = "CodObjEsp";
		const string KEYCODACCION    = "CodAccion";
		const string KEYCODACTIVIDAD = "CodActividad";

		const string KEYIDCO    = "idCentro";
		protected System.Web.UI.WebControls.TextBox txtResponsable;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPrioridad;

	
		//Paginas
		
		#endregion Constantes		

		#region Variables
		private ListItem item = new ListItem();
		#endregion

		private void CargarPrioridad()
		{
			for(int i=1;i<=10;i++)
			{
				if (i == 1)
				{
					item = new ListItem(i.ToString() + Constantes.ESPACIO + Constantes.SIGNOMENOS +
										Constantes.ESPACIO + "Más Importante",i.ToString());
				}
				else if (i == 10)
				{
					item = new ListItem(i.ToString() + Constantes.ESPACIO + Constantes.SIGNOMENOS +
										Constantes.ESPACIO + "Menos Importante",i.ToString());
				}
				else
				{
					item = new ListItem(i.ToString(),i.ToString());
				}
				ddlbPrioridad.Items.Add(item);
			}
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbPrioridad.Items.Insert(0,item);
		}

		private void CargarCentroCosto()
		{
			ddlbCC.DataSource =  (new CCentroCosto()).ListarCentroCostoPorGrupoCC(Convert.ToInt32(Page.Request.QueryString[KEYIDGRUPOCC].ToString()));
			ddlbCC.DataValueField = Enumerados.ColumnaCentroCosto.IdCentroCosto.ToString();
			ddlbCC.DataTextField = Enumerados.ColumnaCentroCosto.Nombre.ToString();
			ddlbCC.DataBind();
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbCC.Items.Insert(0,item);
		}

		private void CargarImportancia()
		{
			ddlbImportancia.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaImportanciaACTIVIDAD));
			ddlbImportancia.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbImportancia.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbImportancia.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbImportancia.Items.Insert(0,item);
		}

		private void CargarTipo()
		{
			ddlbTipo.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoACTIVIDAD));
			ddlbTipo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipo.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTipo.Items.Insert(0,item);
		}

		private void CargarRecurso()
		{
			ddlbRecurso.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoRecursoACTIVIDAD));
			ddlbRecurso.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbRecurso.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbRecurso.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbRecurso.Items.Insert(0,item);
		}

		private void CargarNivel()
		{
			ddlbNivel.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaNivelACTIVIDAD));
			ddlbNivel.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbNivel.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbNivel.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbNivel.Items.Insert(0,item);
		}

		private void CargarRcs()
		{
			ddlbRcs.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaRcsACTIVIDAD));
			ddlbRcs.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbRcs.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbRcs.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbRcs.Items.Insert(0,item);
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
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

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePlanEstrategicoActividad.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePlanEstrategicoActividad.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.CargarPrioridad();
			//this.CargarCentroCosto();
			//this.CargarImportancia();
			//this.CargarTipo();
			//this.CargarRecurso();
			this.CargarNivel();
			//this.CargarRcs();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			rfvCodigoActividad.ErrorMessage = "Debe Ingresar Código de Actividad";
			rfvCodigoActividad.ToolTip = rfvCodigoActividad.ErrorMessage;

			rfvNombreActividad.ErrorMessage = "Debe Ingresar Nombre de Actividad";
			rfvNombreActividad.ToolTip = rfvNombreActividad.ErrorMessage;

			/*rfvAvanceFinanciero.ErrorMessage = "Debe Ingresar el Monto de Avance Financiero";
			rfvAvanceFinanciero.ToolTip = rfvAvanceFinanciero.ErrorMessage;*/

			/*rfvInversion.ErrorMessage = "Debe Ingresar el Monto de la Inversión";
			rfvInversion.ToolTip = rfvInversion.ErrorMessage;*/

			rfvCC.ErrorMessage = "Debe Seleccionar el Centro de Costos";
			rfvCC.ToolTip = rfvCC.ErrorMessage;

			/*rfvTipo.ErrorMessage = "Debe Seleccionar el Tipo de Actividad";
			rfvTipo.ToolTip = rfvTipo.ErrorMessage;*/
			 
			/*rfvRecurso.ErrorMessage = "Debe Seleccionar el Tipo de Inversión";
			rfvRecurso.ToolTip = rfvRecurso.ErrorMessage;*/

			rfvNivel.ErrorMessage = "Debe Seleccionar el Nivel de la Actividad";
			rfvNivel.ToolTip = rfvNivel.ErrorMessage;

			rfvPrioridad.ErrorMessage = "Debe Seleccionar la Prioridad de la Actividad";
			rfvPrioridad.ToolTip = rfvPrioridad.ErrorMessage;

			/*rfvRcs.ErrorMessage = "Debe Seleccionar el Nivel de Recurso de la Actividad";
			rfvRcs.ToolTip = rfvRcs.ErrorMessage;*/


		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{

			PEActividadBE oPEActividadBE = new PEActividadBE();
			oPEActividadBE.IDACCION = Convert.ToInt32(Page.Request.QueryString[KEYIDACCION]);
			oPEActividadBE.CODIGO = txtCodigoActividad.Text.ToUpper();
			oPEActividadBE.DESCRIPCION = txtNombreActividad.Text.ToUpper();
			oPEActividadBE.AF = 0;//Convert.ToDouble(txtAvanceFinanciero.Text);
			oPEActividadBE.INVERSION = 0;//Convert.ToDouble(txtInversion.Text);

			/*oPEActividadBE.IDGRUPOCC = Convert.ToInt32(Page.Request.QueryString[KEYIDGRUPOCC]);
			oPEActividadBE.IDCENTROCOSTO = Convert.ToInt32(ddlbCC.SelectedValue);*/

			//oPEActividadBE.IDTIPOINFORMACION = Convert.ToInt32(ddlbTipo.SelectedValue);
			//oPEActividadBE.IDTIPORECURSO = Convert.ToInt32(ddlbRecurso.SelectedValue);
			oPEActividadBE.IDNIVEL = Convert.ToInt32(ddlbNivel.SelectedValue);

			//oPEActividadBE.IDTABLATIPOINFORMACION= Convert.ToInt32(Enumerados.TablasTabla.TablaTipoACTIVIDAD);
			//oPEActividadBE.IDTABLATIPORECURSO = Convert.ToInt32(Enumerados.TablasTabla.TablaTipoRecursoACTIVIDAD);
			oPEActividadBE.IDTABLANIVEL = Convert.ToInt32(Enumerados.TablasTabla.TablaNivelACTIVIDAD);
			oPEActividadBE.PERIODO = Convert.ToInt32(this.nPeriodo.Text);

			oPEActividadBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.TablaPEACTIVIDAD);
			oPEActividadBE.IdEstado = Convert.ToInt32(Enumerados.EstadosPEACTIVIDAD.Activo);

			//oPEActividadBE.IDRCS = Convert.ToInt32(ddlbRcs.SelectedValue);
			//oPEActividadBE.IDTABLARCS = Convert.ToInt32(Enumerados.TablasTabla.TablaRcsACTIVIDAD);

			//oPEActividadBE.IDIMPORTANCIA = Convert.ToInt32(ddlbImportancia.SelectedValue);
			//oPEActividadBE.IDTABLAIMPORTANCIA = Convert.ToInt32(Enumerados.TablasTabla.TablaImportanciaACTIVIDAD);

			oPEActividadBE.PRIORIDAD = Convert.ToInt32(ddlbPrioridad.SelectedValue);

			oPEActividadBE.Responsable = txtResponsable.Text;
			oPEActividadBE.Observaciones = txtObservaciones.Text;

			/*if (numEne.Text!= String.Empty)
			{oPEActividadBE.InvEne = Convert.ToDouble(numEne.Text);}

			if (numFeb.Text!= String.Empty)
			{oPEActividadBE.InvFeb = Convert.ToDouble(numFeb.Text);}

			if (numMar.Text!= String.Empty)
			{oPEActividadBE.InvMar = Convert.ToDouble(numMar.Text);}

			if (numAbr.Text!= String.Empty)
			{oPEActividadBE.InvAbr = Convert.ToDouble(numAbr.Text);}

			if (numMay.Text!= String.Empty)
			{oPEActividadBE.InvMay = Convert.ToDouble(numMay.Text);}

			if (numJun.Text!= String.Empty)
			{oPEActividadBE.InvJun = Convert.ToDouble(numJun.Text);}

			if (numJul.Text!= String.Empty)
			{oPEActividadBE.InvJul = Convert.ToDouble(numJul.Text);}

			if (numAgo.Text!= String.Empty)
			{oPEActividadBE.InvAgo = Convert.ToDouble(numAgo.Text);}

			if (numSet.Text!= String.Empty)
			{oPEActividadBE.InvSet = Convert.ToDouble(numSet.Text);}

			if (numOct.Text!= String.Empty)
			{oPEActividadBE.InvOct = Convert.ToDouble(numOct.Text);}

			if (numNov.Text!= String.Empty)
			{oPEActividadBE.InvNov = Convert.ToDouble(numNov.Text);}

			if (numDic.Text!= String.Empty)
			{oPEActividadBE.InvDic = Convert.ToDouble(numDic.Text);}

			if (numPorcEne.Text!= String.Empty)
			{oPEActividadBE.PorcEne = Convert.ToInt32(numPorcEne.Text);}

			if (numPorcFeb.Text!= String.Empty)
			{oPEActividadBE.PorcFeb = Convert.ToInt32(numPorcFeb.Text);}

			if (numPorcMar.Text!= String.Empty)
			{oPEActividadBE.PorcMar = Convert.ToInt32(numPorcMar.Text);}

			if (numPorcAbr.Text!= String.Empty)
			{oPEActividadBE.PorcAbr = Convert.ToInt32(numPorcAbr.Text);}

			if (numPorcMay.Text!= String.Empty)
			{oPEActividadBE.PorcMay = Convert.ToInt32(numPorcMay.Text);}

			if (numPorcJun.Text!= String.Empty)
			{oPEActividadBE.PorcJun = Convert.ToInt32(numPorcJun.Text);}

			if (numPorcJul.Text!= String.Empty)
			{oPEActividadBE.PorcJul = Convert.ToInt32(numPorcJul.Text);}

			if (numPorcAgo.Text!= String.Empty)
			{oPEActividadBE.PorcAgo = Convert.ToInt32(numPorcAgo.Text);}

			if (numPorcSet.Text!= String.Empty)
			{oPEActividadBE.PorcSet = Convert.ToInt32(numPorcSet.Text);}

			if (numPorcOct.Text!= String.Empty)
			{oPEActividadBE.PorcOct = Convert.ToInt32(numPorcOct.Text);}

			if (numPorcNov.Text!= String.Empty)
			{oPEActividadBE.PorcNov = Convert.ToInt32(numPorcNov.Text);}

			if (numPorcDic.Text!= String.Empty)
			{oPEActividadBE.PorcDic = Convert.ToInt32(numPorcDic.Text);}*/

			oPEActividadBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			if (Convert.ToInt32((new CMantenimientos()).Insertar(oPEActividadBE))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Actividad",this.ToString(),"Se registró Item de Accion" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			PEActividadBE oPEActividadBE = new PEActividadBE();
			oPEActividadBE.IDACTIVIDAD = Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD]);
			oPEActividadBE.IDACCION = Convert.ToInt32(Page.Request.QueryString[KEYIDACCION]);
			oPEActividadBE.CODIGO = txtCodigoActividad.Text.ToUpper();
			oPEActividadBE.DESCRIPCION = txtNombreActividad.Text.ToUpper();
			oPEActividadBE.AF = 0;//Convert.ToDouble(txtAvanceFinanciero.Text);
			oPEActividadBE.INVERSION =0;// Convert.ToDouble(txtInversion.Text);


			/*oPEActividadBE.IDGRUPOCC = Convert.ToInt32(Page.Request.QueryString[KEYIDGRUPOCC]);
			oPEActividadBE.IDCENTROCOSTO = Convert.ToInt32(ddlbCC.SelectedValue);*/

			/*oPEActividadBE.IDTIPOINFORMACION = Convert.ToInt32(ddlbTipo.SelectedValue);
			oPEActividadBE.IDTIPORECURSO = Convert.ToInt32(ddlbRecurso.SelectedValue);*/
			oPEActividadBE.IDNIVEL = Convert.ToInt32(ddlbNivel.SelectedValue);
			oPEActividadBE.PERIODO = Convert.ToInt32(this.nPeriodo.Text);

			/*oPEActividadBE.IDTABLATIPOINFORMACION= Convert.ToInt32(Enumerados.TablasTabla.TablaTipoACTIVIDAD);
			oPEActividadBE.IDTABLATIPORECURSO = Convert.ToInt32(Enumerados.TablasTabla.TablaTipoRecursoACTIVIDAD);*/
			oPEActividadBE.IDTABLANIVEL = Convert.ToInt32(Enumerados.TablasTabla.TablaNivelACTIVIDAD);

			//oPEActividadBE.IDRCS = Convert.ToInt32(ddlbRcs.SelectedValue);
			//oPEActividadBE.IDTABLARCS = Convert.ToInt32(Enumerados.TablasTabla.TablaRcsACTIVIDAD);

			/*oPEActividadBE.IDIMPORTANCIA = Convert.ToInt32(ddlbImportancia.SelectedValue);
			oPEActividadBE.IDTABLAIMPORTANCIA = Convert.ToInt32(Enumerados.TablasTabla.TablaImportanciaACTIVIDAD);
			*/
			oPEActividadBE.PRIORIDAD = Convert.ToInt32(ddlbPrioridad.SelectedValue);

			oPEActividadBE.Responsable = txtResponsable.Text;
			oPEActividadBE.Observaciones = txtObservaciones.Text;

			/*if (numEne.Text!= String.Empty)
			{oPEActividadBE.InvEne = Convert.ToDouble(numEne.Text);}

			if (numFeb.Text!= String.Empty)
			{oPEActividadBE.InvFeb = Convert.ToDouble(numFeb.Text);}

			if (numMar.Text!= String.Empty)
			{oPEActividadBE.InvMar = Convert.ToDouble(numMar.Text);}

			if (numAbr.Text!= String.Empty)
			{oPEActividadBE.InvAbr = Convert.ToDouble(numAbr.Text);}

			if (numMay.Text!= String.Empty)
			{oPEActividadBE.InvMay = Convert.ToDouble(numMay.Text);}

			if (numJun.Text!= String.Empty)
			{oPEActividadBE.InvJun = Convert.ToDouble(numJun.Text);}

			if (numJul.Text!= String.Empty)
			{oPEActividadBE.InvJul = Convert.ToDouble(numJul.Text);}

			if (numAgo.Text!= String.Empty)
			{oPEActividadBE.InvAgo = Convert.ToDouble(numAgo.Text);}

			if (numSet.Text!= String.Empty)
			{oPEActividadBE.InvSet = Convert.ToDouble(numSet.Text);}

			if (numOct.Text!= String.Empty)
			{oPEActividadBE.InvOct = Convert.ToDouble(numOct.Text);}

			if (numNov.Text!= String.Empty)
			{oPEActividadBE.InvNov = Convert.ToDouble(numNov.Text);}

			if (numDic.Text!= String.Empty)
			{oPEActividadBE.InvDic = Convert.ToDouble(numDic.Text);}

			if (numPorcEne.Text!= String.Empty)
			{oPEActividadBE.PorcEne = Convert.ToInt32(numPorcEne.Text);}

			if (numPorcFeb.Text!= String.Empty)
			{oPEActividadBE.PorcFeb = Convert.ToInt32(numPorcFeb.Text);}

			if (numPorcMar.Text!= String.Empty)
			{oPEActividadBE.PorcMar = Convert.ToInt32(numPorcMar.Text);}

			if (numPorcAbr.Text!= String.Empty)
			{oPEActividadBE.PorcAbr = Convert.ToInt32(numPorcAbr.Text);}

			if (numPorcMay.Text!= String.Empty)
			{oPEActividadBE.PorcMay = Convert.ToInt32(numPorcMay.Text);}

			if (numPorcJun.Text!= String.Empty)
			{oPEActividadBE.PorcJun = Convert.ToInt32(numPorcJun.Text);}

			if (numPorcJul.Text!= String.Empty)
			{oPEActividadBE.PorcJul = Convert.ToInt32(numPorcJul.Text);}

			if (numPorcAgo.Text!= String.Empty)
			{oPEActividadBE.PorcAgo = Convert.ToInt32(numPorcAgo.Text);}

			if (numPorcSet.Text!= String.Empty)
			{oPEActividadBE.PorcSet = Convert.ToInt32(numPorcSet.Text);}

			if (numPorcOct.Text!= String.Empty)
			{oPEActividadBE.PorcOct = Convert.ToInt32(numPorcOct.Text);}

			if (numPorcNov.Text!= String.Empty)
			{oPEActividadBE.PorcNov = Convert.ToInt32(numPorcNov.Text);}

			if (numPorcDic.Text!= String.Empty)
			{oPEActividadBE.PorcDic = Convert.ToInt32(numPorcDic.Text);}*/

			oPEActividadBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			if (Convert.ToInt32((new CMantenimientos()).Modificar(oPEActividadBE))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Actividad",this.ToString(),"Se modificó Item de Actividad" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.Eliminar implementation
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
		}

		public void CargarDatos()
		{
			this.LlenarCombos();
			this.LlenarTitulos();

			PEActividadBE oPEActividadBE = (PEActividadBE)(new CMantenimientos()).ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD].ToString()), Enumerados.ClasesNTAD.PEActividadNTAD.ToString());
			txtCodigoActividad.Text = oPEActividadBE.CODIGO;
			txtNombreActividad.Text = oPEActividadBE.DESCRIPCION;
			//txtAvanceFinanciero.Text = oPEActividadBE.AF.ToString(Constantes.FORMATODECIMAL5);
//			txtInversion.Text = oPEActividadBE.INVERSION.ToString(Constantes.FORMATODECIMAL5);
			nPeriodo.Text  = oPEActividadBE.PERIODO.ToString();
			ListItem item = ddlbCC.Items.FindByValue(oPEActividadBE.IDCENTROCOSTO.ToString());
			if(item!=null){item.Selected=true;}
			/*item = ddlbTipo.Items.FindByValue(oPEActividadBE.IDTIPOINFORMACION.ToString());
			if(item!=null){item.Selected=true;}*/
			item = ddlbNivel.Items.FindByValue(oPEActividadBE.IDNIVEL.ToString());
			if(item!=null){item.Selected=true;}
			/*item = ddlbRecurso.Items.FindByValue(oPEActividadBE.IDTIPORECURSO.ToString());
			if(item!=null){item.Selected=true;}*/
			/*item = ddlbRcs.Items.FindByValue(oPEActividadBE.IDRCS.ToString());
			if(item!=null){item.Selected=true;}*/
			/*item = ddlbImportancia.Items.FindByValue(oPEActividadBE.IDIMPORTANCIA.ToString());
			if(item!=null){item.Selected=true;}*/
			item = ddlbPrioridad.Items.FindByValue(oPEActividadBE.PRIORIDAD.ToString());
			if(item!=null){item.Selected=true;}

			txtResponsable.Text = oPEActividadBE.Responsable.ToString();
			txtObservaciones.Text = oPEActividadBE.Observaciones.ToString();
			/*lblTotal.Text = oPEActividadBE.Total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			lblTotalPorcentaje.Text = oPEActividadBE.TotalPorcentaje.ToString();

			if (!oPEActividadBE.InvEne.IsNull)
			{numEne.Text = oPEActividadBE.InvEne.ToString();}

			if (!oPEActividadBE.InvFeb.IsNull)
			{numFeb.Text = oPEActividadBE.InvFeb.ToString();}
			
			if (!oPEActividadBE.InvMar.IsNull)			
			{numMar.Text = oPEActividadBE.InvMar.ToString();}

			if (!oPEActividadBE.InvAbr.IsNull)
			{numAbr.Text = oPEActividadBE.InvAbr.ToString();}

			if (!oPEActividadBE.InvMay.IsNull)
			{numMay.Text = oPEActividadBE.InvMay.ToString();}

			if (!oPEActividadBE.InvJun.IsNull)
			{numJun.Text = oPEActividadBE.InvJun.ToString();}

			if (!oPEActividadBE.InvJul.IsNull)
			{numJul.Text = oPEActividadBE.InvJul.ToString();}
		
			if (!oPEActividadBE.InvAgo.IsNull)
			{numAgo.Text = oPEActividadBE.InvAgo.ToString();}

			if (!oPEActividadBE.InvSet.IsNull)
			{numSet.Text = oPEActividadBE.InvSet.ToString();}

			if (!oPEActividadBE.InvOct.IsNull)
			{numOct.Text = oPEActividadBE.InvOct.ToString();}

			if (!oPEActividadBE.InvNov.IsNull)
			{numNov.Text = oPEActividadBE.InvNov.ToString();}

			if (!oPEActividadBE.InvDic.IsNull)
			{numDic.Text = oPEActividadBE.InvDic.ToString();}
			
			if (!oPEActividadBE.PorcEne.IsNull)
			{numPorcEne.Text = oPEActividadBE.PorcEne.ToString();}

			if (!oPEActividadBE.PorcFeb.IsNull)
			{numPorcFeb.Text = oPEActividadBE.PorcFeb.ToString();}

			if (!oPEActividadBE.PorcMar.IsNull)
			{numPorcMar.Text = oPEActividadBE.PorcMar.ToString();}

			if (!oPEActividadBE.PorcAbr.IsNull)
			{numPorcAbr.Text = oPEActividadBE.PorcAbr.ToString();}

			if (!oPEActividadBE.PorcMay.IsNull)
			{numPorcMay.Text = oPEActividadBE.PorcMay.ToString();}

			if (!oPEActividadBE.PorcJun.IsNull)
			{numPorcJun.Text = oPEActividadBE.PorcJun.ToString();}

			if (!oPEActividadBE.PorcJul.IsNull)
			{numPorcJul.Text = oPEActividadBE.PorcJul.ToString();}

			if (!oPEActividadBE.PorcAgo.IsNull)
			{numPorcAgo.Text = oPEActividadBE.PorcAgo.ToString();}

			if (!oPEActividadBE.PorcSet.IsNull)
			{numPorcSet.Text = oPEActividadBE.PorcSet.ToString();}

			if (!oPEActividadBE.PorcOct.IsNull)
			{numPorcOct.Text = oPEActividadBE.PorcOct.ToString();}

			if (!oPEActividadBE.PorcNov.IsNull)
			{numPorcNov.Text = oPEActividadBE.PorcNov.ToString();}

			if (!oPEActividadBE.PorcDic.IsNull)
			{numPorcDic.Text = oPEActividadBE.PorcDic.ToString();}*/
		}

		public void CargarModoModificar()
		{
			this.lblTitulo.Text = TITULOMODOMODIFICAR;
			this.CargarDatos();
			this.ibtnAtras.Visible = false;

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
			// TODO:  Add DetallePlanEstrategicoActividad.ValidarCampos implementation
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(nPeriodo.Text.Trim()!=String.Empty)
			{
				int Ano = DateTime.Now.Year + 1;
				
				if (Convert.ToInt32(nPeriodo.Text) < Ano)
				{
					ltlMensaje.Text = Helper.MensajeAlert("Año ingresado debe ser mayor o igual a " + Ano.ToString());
					return false;
				}
			}

			if(txtCodigoActividad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvCodigoActividad.ErrorMessage);
				return false;
			}

			if(txtNombreActividad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvNombreActividad.ErrorMessage);
				return false;
			}

			/*if(txtAvanceFinanciero.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvAvanceFinanciero.ErrorMessage);
				return false;
			}*/

			/*if(txtInversion.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text = Helper.MensajeAlert(rfvInversion.ErrorMessage);
				return false;
			}*/

			/*if(ddlbCC.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvCC.ErrorMessage);
				return false;		
			}*/

			/*if(ddlbTipo.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvTipo.ErrorMessage);
				return false;		
			}*/

			if(ddlbNivel.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvNivel.ErrorMessage);
				return false;		
			}

			if(ddlbPrioridad.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvPrioridad.ErrorMessage);
				return false;		
			}

			/*if(ddlbRecurso.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvRecurso.ErrorMessage);
				return false;		
			}*/

			/*if(ddlbRcs.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvRcs.ErrorMessage);
				return false;		
			}*/

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePlanEstrategicoActividad.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void LlenarTitulos()
		{
			this.lblObjGral.Text  = Page.Request.QueryString[KEYCODOBJGRAL];
			this.lblObjEsp.Text   = Page.Request.QueryString[KEYCODOBJESP];
			this.lblAccion.Text   = Page.Request.QueryString[KEYCODACCION];

			this.lblNombrePlanBase.Text = Page.Request.QueryString[NOMBREPLANBASE];
			this.lblNombreObjGral.Text  = Page.Request.QueryString[NOMBREOBJGRAL];
			this.lblNombreObjEsp.Text   = Page.Request.QueryString[NOMBREOBJESP];
			this.lblNombreAccion.Text   = Page.Request.QueryString[NOMBREACCION];
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

	}
}
