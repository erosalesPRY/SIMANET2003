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
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for ConsultarPlanEstrategicoActividad.
	/// </summary>
	public class ConsultarPlanEstrategicoActividad : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblPlanBase;
		protected System.Web.UI.WebControls.Label lblNombrePlanBase;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label lblNombreObjGral;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lblObjEsp;
		protected System.Web.UI.WebControls.Label lblNombreObjEsp;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblAccion;
		protected System.Web.UI.WebControls.Label lblNombreAccion;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label14;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcionActividad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigoActividad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.DropDownList ddlbPrioridad;
		protected System.Web.UI.WebControls.DropDownList ddlbImportancia;
		protected System.Web.UI.WebControls.DropDownList ddlbAno;
		protected System.Web.UI.WebControls.DropDownList ddlbNivel;
		protected System.Web.UI.WebControls.DropDownList ddlbTi;
		protected System.Web.UI.WebControls.CheckBoxList chkListTipoInversion;
		protected System.Web.UI.WebControls.CheckBox chkTodos;
		protected System.Web.UI.WebControls.Button btnFiltrar;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		#endregion

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdActividad";
		const string CONTROLGRILLAINDICADORES ="gridIndicadores";

		const int COLUMNANUMERACION = 0;
		const int COLUMNAMODIFICAR = 1;

		//OTROS
		const string URLMODIFICAR = "DetallePlanEstrategicoActividad.aspx?";
		const string URLANOINVERSION = "ConsultarPlanEstrategicoAnoInversion.aspx?";
		const string TEXTOFOOTERTOTAL = "Total:";
		const string GRILLAVACIA = "No hay Datos";
		const int POSICIONFOOTERTOTAL = 1;
		const string TITULOVERACTIVIDAD = "Ver Actividad: ";

		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";

		// new
		const string NOMBREPLANBASE  = "PLEstrNombre";
		const string NOMBREOBJGRAL   = "ObjGenNombre";
		const string NOMBREOBJESP    = "idObjEspNombre";
		const string NOMBREACCION    = "ACCION";
		const string NOMBREACTIVIDAD = "ACTIVIDAD";

		const string KEYQIDPLANESTRATEGICO="idPLEstr";

		const string KEYIDOBJGRAL   = "idObjGen";
		const string KEYIDOBJESP    = "idObjEsp";
		const string KEYIDACCION    = "IdAccion";
		const string KEYIDACTIVIDAD = "IdActividad";
		const string KEYIDGRUPOCC   = "IdGrupoCC";

		const string KEYCODOBJGRAL   = "CodObjGen";
		const string KEYCODOBJESP    = "CodObjEsp";
		const string KEYCODACCION    = "CodAccion";
		const string KEYCODACTIVIDAD = "CodActividad";

		const string SESSIONPERIODO = "speriodo";
		const string SESSIONTIPO = "stipo";
		const string SESSIONNIVEL = "snivel";
		const string SESSIONTI = "sti";
		const string SESSIONIMPORTANCIA = "simportancia";
		const string SESSIONPRIORIDAD = "sprioridad";

		#endregion

		#region Variables
		private ListItem item = new ListItem();
		int periodo = 0;
		int idtiprcs = 0;
		int idniv = 0;
		int idimportancia = 0;
		int prioridad = 0;
		string cadenaTipoinversion = "0";
		double TotInversion;

		#endregion
	
		int idPlanEstrategico
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDPLANESTRATEGICO]); }
		}

		private void CargarPeriodos()
		{
			/*ddlbAno.DataSource = (new CPEAnoInversion()).ListarPEPeriodos(idPlanEstrategico);
			ddlbAno.DataValueField = "periodo";
			ddlbAno.DataTextField = "periodo";
			ddlbAno.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbAno.Items.Insert(0,item);

			if (Session[SESSIONPERIODO]!=null)
			{
				item = ddlbAno.Items.FindByValue(Session[SESSIONPERIODO].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONPERIODO]=periodo.ToString();
		}

		private void CargarTi()
		{
			/*ddlbTi.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoRecursoACTIVIDAD));
			ddlbTi.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTi.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTi.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbTi.Items.Insert(0,item);

			if (Session[SESSIONTIPO]!=null)
			{
				item = ddlbTi.Items.FindByValue(Session[SESSIONTIPO].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONTIPO]=idtiprcs.ToString();
		}

		private void CargarTipo()
		{
			/*chkListTipoInversion.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoACTIVIDAD));
			chkListTipoInversion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			chkListTipoInversion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			chkListTipoInversion.DataBind();
			chkListTipoInversion.RepeatLayout = RepeatLayout.Table;

			if (Session[SESSIONTI]!=null)
			{
				cadenaTipoinversion = Session[SESSIONTI].ToString();
				if (cadenaTipoinversion=="0")
				{
					chkTodos.Checked = true;
					Session[SESSIONTI]=cadenaTipoinversion;
					for (int i=0;i<chkListTipoInversion.Items.Count;i++)
						chkListTipoInversion.Items[i].Selected=true;
				}
				else
				{
					chkTodos.Checked = false;
					string []idTi = cadenaTipoinversion.Split(',');
					for (int i=0;i<idTi.Length;i++)
					{
						item = chkListTipoInversion.Items.FindByValue(idTi[i]);
						if(item!=null){item.Selected=true;}
					}
				}
			}
			else
			{
				chkTodos.Checked = true;*/
				Session[SESSIONTI]=cadenaTipoinversion;
				//				Page.RegisterClientScriptBlock("valor","<SCRIPT>chkInicialTodas();</SCRIPT>");
				/*for (int i=0;i<chkListTipoInversion.Items.Count;i++)
					chkListTipoInversion.Items[i].Selected=true;
			}*/
		}

		private void CargarNivel()
		{
			ddlbNivel.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaNivelACTIVIDAD));
			ddlbNivel.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbNivel.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbNivel.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbNivel.Items.Insert(0,item);


			if (Session[SESSIONNIVEL]!=null)
			{
				item = ddlbNivel.Items.FindByValue(Session[SESSIONNIVEL].ToString());
				if(item!=null){item.Selected=true;}
			}
			else
				Session[SESSIONNIVEL]=idniv.ToString();
		}

		private void CargarImportancia()
		{
			/*ddlbImportancia.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaImportanciaACTIVIDAD));
			ddlbImportancia.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbImportancia.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbImportancia.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbImportancia.Items.Insert(0,item);

			if (Session[SESSIONIMPORTANCIA]!=null)
			{
				item = ddlbImportancia.Items.FindByValue(Session[SESSIONIMPORTANCIA].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONIMPORTANCIA]=idimportancia.ToString();
		}

		private void CargarPrioridad()
		{
			/*for(int i=1;i<=10;i++)
				ddlbPrioridad.Items.Add(i.ToString());
			item = new ListItem(Utilitario.Constantes.TEXTOTODOS,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbPrioridad.Items.Insert(0,item);

			if (Session[SESSIONPRIORIDAD]!=null)
			{
				item = ddlbImportancia.Items.FindByValue(Session[SESSIONPRIORIDAD].ToString());
				if(item!=null){item.Selected=true;}
			}
			else*/
				Session[SESSIONPRIORIDAD]=prioridad.ToString();
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack )
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionEstrategica",this.ToString(),"Se consulto el Modulo Gestion Estrategico.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPlanEstrategicoActividad.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPlanEstrategicoActividad.LlenarGrillaOrdenamiento implementation
		}

		public void Totalizar (DataView dwTotales)
		{
			if (dwTotales != null)
			{
				double [] aArreglo = Helper.TotalizarDataView(dwTotales,"INVERSION");
				TotInversion = aArreglo[0];
			}
		}

		public DataTable ObtenerDatos(int per, int tipo, string cadenati, int nivel, int idimportancia, int prioridad)
		{
			int id = Convert.ToInt32(Page.Request.QueryString[KEYIDACCION]);
			CPEActividad oCPEActividad = new CPEActividad();
			return oCPEActividad.ListarPEACTIVIDAD(id, per, tipo, cadenati, nivel, idimportancia, prioridad);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos
				(
				Convert.ToInt32(Session[SESSIONPERIODO].ToString())
				, Convert.ToInt32(Session[SESSIONTIPO].ToString())
				, Session[SESSIONTI].ToString()
				, Convert.ToInt32(Session[SESSIONNIVEL].ToString())
				, Convert.ToInt32(Session[SESSIONIMPORTANCIA].ToString())
				, Convert.ToInt32(Session[SESSIONPRIORIDAD].ToString())
				);
			

			if(dt!=null)
			{
				DataView dw1 = dt.DefaultView;
				dw1.Sort = columnaOrdenar ;
				dw1.RowFilter = Helper.ObtenerFiltro();

				DataTable dt1 = Helper.DataViewTODataTable(dw1);

				DataView dw = dt1.DefaultView;
				this.Totalizar(dw);

				if (dw.Count == 0)
				{
					grid.DataSource = null; 
					lblResultado.Text = GRILLAVACIA;
					lblResultado.Visible = true;
				}
				else
				{
					grid.DataSource = dw;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,14,21);
					grid.Columns[0].FooterText = TEXTOFOOTERTOTAL;
					grid.Columns[POSICIONFOOTERTOTAL].FooterText = dw.Count.ToString();
				}
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
				lblResultado.Visible = true;
			}

			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.CargarPeriodos();
			this.CargarNivel();
			this.CargarTipo();
			this.CargarTi();
			this.CargarImportancia();
			this.CargarPrioridad();
		}

		public void LlenarDatos()
		{
			this.lblObjGral.Text  = Page.Request.QueryString[KEYCODOBJGRAL];
			this.lblObjEsp.Text   = Page.Request.QueryString[KEYCODOBJESP];
			this.lblAccion.Text   = Page.Request.QueryString[KEYCODACCION];

			this.lblNombrePlanBase.Text = Page.Request.QueryString[NOMBREPLANBASE];
			this.lblNombreObjGral.Text  = Page.Request.QueryString[NOMBREOBJGRAL];
			this.lblNombreObjEsp.Text   = Page.Request.QueryString[NOMBREOBJESP];
			this.lblNombreAccion.Text   = Page.Request.QueryString[NOMBREACCION];
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoActividad.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPlanEstrategicoActividad.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPlanEstrategicoActividad.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPlanEstrategicoActividad.Exportar implementation
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
			// TODO:  Add ConsultarPlanEstrategicoActividad.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ToolTip = "Consultar Actividad:";
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Text =  Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

//				e.Item.Cells[1].Font.Underline=true;
//				e.Item.Cells[1].ForeColor= System.Drawing.Color.Blue;
//				e.Item.Cells[1].ToolTip = "Mostrar Años de Inversion";

				e.Item.Cells[COLUMNANUMERACION].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort") + ";" +
					Helper.MostrarVentana(URLMODIFICAR,
					NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDPLANESTRATEGICO + Utilitario.Constantes.SIGNOIGUAL + this.idPlanEstrategico.ToString() + Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBREOBJGRAL  + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
					+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
					+ NOMBREACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREACCION] + Utilitario.Constantes.SIGNOAMPERSON 
					+ NOMBREACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Helper.EncodeText(dr["DESCRIPCION"].ToString()) + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
					+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] +  Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDACCION] + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr["IDACTIVIDAD"]) + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDGRUPOCC] + Utilitario.Constantes.SIGNOAMPERSON  
					+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 				
					+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYCODACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODACCION] + Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYCODACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["CODIGO"] + Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() 
					));										

//				e.Item.Cells[COLUMNAMODIFICAR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.HISTORIALADELANTE + ";" +
//					Helper.MostrarVentana(URLANOINVERSION,
//					NOMBREPLANBASE + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREPLANBASE] + Utilitario.Constantes.SIGNOAMPERSON 
//					+ NOMBREOBJGRAL  + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
//					+ NOMBREOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
//					+ NOMBREACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[NOMBREACCION] + Utilitario.Constantes.SIGNOAMPERSON 
//					+ NOMBREACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["DESCRIPCION"].ToString() + Utilitario.Constantes.SIGNOAMPERSON 
//					+ KEYIDOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON
//					+ KEYIDOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDOBJESP] +  Utilitario.Constantes.SIGNOAMPERSON  
//					+ KEYIDACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDACCION] + Utilitario.Constantes.SIGNOAMPERSON  
//					+ KEYIDACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr["IDACTIVIDAD"]) + Utilitario.Constantes.SIGNOAMPERSON  
//					+ KEYIDGRUPOCC + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYIDGRUPOCC] + Utilitario.Constantes.SIGNOAMPERSON  
//					+ KEYCODOBJGRAL + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJGRAL] + Utilitario.Constantes.SIGNOAMPERSON 				
//					+ KEYCODOBJESP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODOBJESP] + Utilitario.Constantes.SIGNOAMPERSON 
//					+ KEYCODACCION + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYCODACCION] + Utilitario.Constantes.SIGNOAMPERSON 
//					+ KEYCODACTIVIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["CODIGO"]
//					));										

				projDataGridWeb.DataGridWeb gridInd =(projDataGridWeb.DataGridWeb)e.Item.Cells[6].FindControl(CONTROLGRILLAINDICADORES);	
				DataTable dt = (new CPEIndicador()).ConsultarIndicadoresPorAccion_Actividad(
					Convert.ToInt32(Page.Request.QueryString[KEYIDOBJESP]),
					Convert.ToInt32(Page.Request.QueryString[KEYIDACCION]),
					Convert.ToInt32(dr[Enumerados.PlanEstrategicoColumnas.IdActividad.ToString()].ToString()));

				gridInd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridIndicadores_ItemDataBound);
				gridInd.Columns[0].ItemStyle.Width = 400;
				gridInd.Columns[1].ItemStyle.Width = 80;
				gridInd.DataSource = dt;
				gridInd.DataBind();

				e.Item.Cells[COLUMNANUMERACION].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e
					,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["IDACTIVIDAD"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");

			}

			/*if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[6].Text = TotInversion.ToString(Constantes.FORMATODECIMAL5);
			}*/
		}

		private void gridIndicadores_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				double Monto=0;

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Monto = Convert.ToDouble(dr[Enumerados.PlanEstrategicoColumnas.Total.ToString()]);

				/*if (Enumerados.TipoDatosColumnas.DOUBLE.ToString() == dr[Enumerados.PlanEstrategicoColumnas.Var2.ToString()].ToString())
				{e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);}
				else
				{*/e.Item.Cells[1].Text = Monto.ToString(Utilitario.Constantes.FORMATODECIMAL0);//}
			}								
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value=e.NewPageIndex.ToString();
			grid.CurrentPageIndex=Convert.ToInt32(this.hGridPagina.Value);
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);	
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(
				Convert.ToInt32(Session[SESSIONPERIODO].ToString())
				, Convert.ToInt32(Session[SESSIONTIPO].ToString())
				, Session[SESSIONTI].ToString()
				, Convert.ToInt32(Session[SESSIONNIVEL].ToString())
				, Convert.ToInt32(Session[SESSIONIMPORTANCIA].ToString())
				, Convert.ToInt32(Session[SESSIONPRIORIDAD].ToString())
				)
				,"Codigo;Codigo Actividad"
				,"Descripcion;Nombre Actividad"
				);

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void btnFiltrar_Click(object sender, System.EventArgs e)
		{
			// Filtro por Tipo de Inversion
			cadenaTipoinversion = "0";
			/*if (chkTodos.Checked != true)
			{
				cadenaTipoinversion = "";
				///Obtener Valores de un CheckBoxList
				for (int i=0; i< chkListTipoInversion.Items.Count; i++)
					if(chkListTipoInversion.Items[i].Selected)
						cadenaTipoinversion += Convert.ToInt32(chkListTipoInversion.Items[i].Value).ToString() + ",";
			}*/
                       
			cadenaTipoinversion = cadenaTipoinversion.TrimEnd(',');

			Session[SESSIONTI]=cadenaTipoinversion;

			// Filtro por Naturaleza
			idtiprcs = 0;//Convert.ToInt32(ddlbTi.SelectedValue=="&"?"0":ddlbTi.SelectedValue);
			Session[SESSIONTIPO]=idtiprcs.ToString();

			// Filtro por Nivel
			idniv  = Convert.ToInt32(ddlbNivel.SelectedValue=="&"?"0":ddlbNivel.SelectedValue);
			Session[SESSIONNIVEL]=idniv.ToString();

			// Filtro por Año
			periodo = 0; //Convert.ToInt32(ddlbAno.SelectedValue=="&"?"0":ddlbAno.SelectedValue);
			Session[SESSIONPERIODO]=periodo.ToString();

			// Filtro por Importancia
			idimportancia = 0;//Convert.ToInt32(ddlbImportancia.SelectedValue=="&"?"0":ddlbImportancia.SelectedValue);
			Session[SESSIONIMPORTANCIA]=idimportancia.ToString();

			// Filtro por Prioridad
			prioridad = 0;//Convert.ToInt32(ddlbPrioridad.SelectedValue=="&"?"0":ddlbPrioridad.SelectedValue);
			Session[SESSIONPRIORIDAD]=prioridad.ToString();


			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		
		}

	}
}
