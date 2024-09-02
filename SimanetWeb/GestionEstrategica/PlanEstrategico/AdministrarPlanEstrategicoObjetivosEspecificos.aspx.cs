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
using NullableTypes;
using MetaBuilders.WebControls;
using System.Diagnostics; 

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	/// <summary>
	/// Summary description for AdministrarPlanEstrategicoObjetivosEspecificos.
	/// </summary>
	public class AdministrarPlanEstrategicoObjetivosEspecificos : System.Web.UI.Page,IPaginaBase
	{
		#region Constante
		const string GRILLAVACIA="No Existen datos Plan Estrategico";
		const string CONTROLGRILLAINDICADORES ="gridIndicadores";

		const string KEYQPLANESTRATEGICONOMBRE="PLEstrNombre";	
		const string KEYQIDOBJETIVOGENERAL="idObjGen";
		const string KEYQCODDOBJETIVOGENERAL="CodObjGen";
		const string KEYQOBJETIVOGENERALNOMBRE="ObjGenNombre";
		const string KEYQIDOBJETIVOESPECIFICO="idObjEsp";
		const string KEYDESOBJETIVOESPECIFICO = "desObjetivoEspecifico";
		const string KEYQCODOBJETIVOESPECIFICO="CodObjEsp";
		const string KEYQOBJETIVOESPECIFICONOMBRE="idObjEspNombre";
		const string KEYQIDCENTROOPERATIVO="idCentro";
		const string KEYIDCENTROOPERATIVO = "IDCENTROOPERATIVO";

		const string URLDETALLE="DetallePlanEstrategicoObjetivosEspecificos.aspx";
		const string URLACCION="AdministrarPlanEstrategicoAccion.aspx";
		const string URLINDICADORES = "AdministracionIndicadoresPorObjetivoEspecifico.aspx?";

		const string MENSAJESELECCIONAR="Tiene que seleccionar un registro";
		const string MENSAJEELIMINAR="Se elimino la accion Nro. ";
		const string SESSIONPERIODO = "speriodo";
		const string SESSIONTIPO = "stipo";
		const string SESSIONNIVEL = "snivel";
		const string SESSIONTI = "sti";
		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		#endregion

		#region Variables
		int periodo = 0;
		int idtipinf= 0;
		int idniv	= 0;
		int idimportancia = 0;
		int prioridad = 0;
		string cadenaTipoinversion = "0";
		#endregion

		int idObjetivoGeneral
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBJETIVOGENERAL]); }
		}
		string CodigoObjetivoGeneral
		{
			get{return Page.Request.Params[KEYQCODDOBJETIVOGENERAL].ToString(); }
		}
		string PlanEstrategicoNombre
		{
			get{return Page.Request.Params[KEYQPLANESTRATEGICONOMBRE].ToString(); }
		}

		string ObjetivoGeneralNombre
		{
			get{return Page.Request.Params[KEYQOBJETIVOGENERALNOMBRE].ToString(); }
		}
		int CentroOperativo
		{
			get{return int.Parse(Page.Request.Params[KEYQIDCENTROOPERATIVO].ToString());}
		}
		#region Controles

		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPlanEstrategico;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblObjetivoGeneral;
		protected System.Web.UI.WebControls.Label lblObjGral;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnIndicadores;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Eliminar()
		{
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(MENSAJESELECCIONAR);
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Utilitario.Enumerados.ClasesTAD.PEObjetivoEspecificoTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeAlert("Se elimino el registro");
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				}
			}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					Helper.ReestablecerPagina(this);
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminaFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminaFiltro_Click);
			this.ibtnIndicadores.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnIndicadores_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos(int per, int tipo, string cadenati, int nivel, int idimportancia, int prioridad)
		{
			return (new CPEObjetivoEspecifico()).ListarTodosGrilla(this.idObjetivoGeneral,Utilitario.Constantes.FLAGDEFAULT, per, tipo, cadenati, nivel, idimportancia, prioridad);
		}
		private DataView FiltrarDatosXCentro(DataTable dt)
		{
			DataView dw = dt.DefaultView;
			string filtroXCentro = String.Empty;
			switch(CentroOperativo)
			{
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString();break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote).ToString();break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaPeru:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaPeru).ToString() +
						" OR " + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaCallao).ToString() +
						" OR " + KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaChimbote).ToString();break;
				}
				case (int)Utilitario.Enumerados.IdCentroOperativo.SimaIquitos:
				{
					filtroXCentro = KEYIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +
						((int)Utilitario.Enumerados.IdCentroOperativo.SimaIquitos).ToString();break;
				}
			}
			dw.RowFilter = filtroXCentro;
			return dw;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			string filtro = String.Empty;
			DataTable dt = this.ObtenerDatos(periodo, idtipinf, cadenaTipoinversion, idniv, idimportancia, prioridad);
			if(dt!=null)
			{
				DataView dw = FiltrarDatosXCentro(dt);
				if(dw.Count > Utilitario.Constantes.ValorConstanteCero)
				{
					filtro = Helper.ObtenerFiltro();

					if(filtro.Trim() != String.Empty)
						dw.RowFilter = "(" + dw.RowFilter.ToString() + ") and " + filtro;
					
					dw.Sort = columnaOrdenar ;
					grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
					grid.DataSource = dw;
					grid.PageSize = Helper.ObtenerCantidadRegistrosPorGrilla(7,14,21);
					grid.CurrentPageIndex = Convert.ToInt32(this.hGridPagina.Value);
					lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = dw;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblPlanEstrategico.Text = this.PlanEstrategicoNombre;
			lblObjetivoGeneral.Text=this.ObjetivoGeneralNombre;
			lblObjGral.Text= this.CodigoObjetivoGeneral;
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"));
			ibtnIndicadores.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"));
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarPlanEstrategicoObjetivosEspecificos.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{

				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLDETALLE+ Utilitario.Constantes.SIGNOINTERROGACION,KEYQIDOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + dr["idObjetivoEspecifico"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + this.idObjetivoGeneral.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.PlanEstrategicoNombre
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQCODDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL +  this.CodigoObjetivoGeneral
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQOBJETIVOGENERALNOMBRE + Utilitario.Constantes.SIGNOIGUAL +  this.ObjetivoGeneralNombre
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString()));
						

				Helper.ConfiguraColumnaHyperLink(Utilitario.Enumerados.EventosJavaScript.OnClick,e.Item.Cells[1],
					Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort"),
					Helper.MostrarVentana(URLACCION + Utilitario.Constantes.SIGNOINTERROGACION,KEYQIDOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + dr["idObjetivoEspecifico"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQOBJETIVOESPECIFICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + dr["Descripcion"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQCODOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL +  dr["Codigo"].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + this.idObjetivoGeneral.ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQPLANESTRATEGICONOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.PlanEstrategicoNombre
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQCODDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL +  this.CodigoObjetivoGeneral
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQOBJETIVOGENERALNOMBRE + Utilitario.Constantes.SIGNOIGUAL +  this.ObjetivoGeneralNombre
					+ Utilitario.Constantes.SIGNOAMPERSON 
					+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + dr["idCentroOperativo"].ToString()
					));
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e
					,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr["idObjetivoEspecifico"].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr["DESCRIPCION"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");


				projDataGridWeb.DataGridWeb gridInd =(projDataGridWeb.DataGridWeb)e.Item.Cells[4].FindControl(CONTROLGRILLAINDICADORES);	
				DataTable dt = (new CPEIndicador()).ConsultarIndicadoresPlanOperativo(					
					Convert.ToInt32(dr[Enumerados.PlanEstrategicoColumnas.IdObjetivoEspecifico.ToString()].ToString()));

				gridInd.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridIndicadores_ItemDataBound);
				gridInd.Columns[0].ItemStyle.Width = 400;
				gridInd.Columns[1].ItemStyle.Width = 150;
				gridInd.DataSource = dt;
				gridInd.DataBind();
			}					
		
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

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE + Utilitario.Constantes.SIGNOINTERROGACION 
				+ KEYQPLANESTRATEGICONOMBRE +  Utilitario.Constantes.SIGNOIGUAL + this.PlanEstrategicoNombre.ToString() + Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQIDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + this.idObjetivoGeneral.ToString()+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQCODDOBJETIVOGENERAL + Utilitario.Constantes.SIGNOIGUAL + this.CodigoObjetivoGeneral.ToString() + Utilitario.Constantes.SIGNOAMPERSON
				+ KEYQOBJETIVOGENERALNOMBRE + Utilitario.Constantes.SIGNOIGUAL + this.ObjetivoGeneralNombre.ToString()+ Utilitario.Constantes.SIGNOAMPERSON
				+ Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Helper.ElaborarFiltro(this.ObtenerDatos(periodo, idtipinf, cadenaTipoinversion, idniv, idimportancia, prioridad)
				,"Codigo;Codigo","Descripcion;Descripcion","NOMBRECENTROOPERATIVO;Centro Operativo");

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

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar();
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}

		}

		private void ibtnIndicadores_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLINDICADORES + 
				Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString() + Utilitario.Constantes.SIGNOAMPERSON +
				KEYQIDOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + hCodigo.Value + Utilitario.Constantes.SIGNOAMPERSON +
				KEYDESOBJETIVOESPECIFICO + Utilitario.Constantes.SIGNOIGUAL + hDescripcion.Value);
		}
	}
}
