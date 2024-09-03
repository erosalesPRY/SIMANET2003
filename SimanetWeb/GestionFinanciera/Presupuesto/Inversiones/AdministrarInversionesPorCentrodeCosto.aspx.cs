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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using System.IO;


namespace SIMA.SimaNetWeb.GestionFinanciera.Presupuesto.Inversiones
{
	/// <summary>
	/// Summary description for AdministrarInversionesPorCentrodeCosto.
	/// </summary>
	public class AdministrarInversionesPorCentrodeCosto : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		const string URLDETALLE="DetalleInversiones.aspx?";
		const string GRILLAVACIA="No existe";
		const string KEYQIDCENTROOPERATIVO="idcop";//CentroOPerativo de la pagina de Procesos
		const string KEYQIDCENTROCOSTO ="idCC";
		const string KEYQPERIODO="Periodo";
		const string KEYQIDTIPOINFORMACION="idTipoInfo";
		const string KEYQIDIDRUBRO="idRubro";
		
		const string KEYQIDROW="idRow";

		string stridFila="";
		int idFila=1;
		#region Controles
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hResolucion;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt= (new CPresupuestoInversiones()).AdministrarPresupuestoInversionesporCentroCosto(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]),Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]),Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]));
			if(dt!=null)
			{
				grid.DataSource = dt;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;
			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.hResolucion.Value = (Helper.ObtenerAltodePantalla()-200).ToString();
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarInversionesPorCentrodeCosto.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			

				e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				
				string Parametro = KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQPERIODO]).ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]).ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDCENTROCOSTO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]).ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDIDRUBRO + Utilitario.Constantes.SIGNOIGUAL +  dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYQIDTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]).ToString();


				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,
					Utilitario.Constantes.POPUPDEESPERA,															
					Helper.MostrarVentanaDialogo(URLDETALLE + KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQPERIODO]).ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]).ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQIDCENTROCOSTO + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQIDCENTROCOSTO]).ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQIDIDRUBRO + Utilitario.Constantes.SIGNOIGUAL +  dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQIDTIPOINFORMACION + Utilitario.Constantes.SIGNOIGUAL +  Convert.ToInt32(Page.Request.Params[KEYQIDTIPOINFORMACION]).ToString()
															+ Utilitario.Constantes.SIGNOAMPERSON
															+ KEYQIDROW + Utilitario.Constantes.SIGNOIGUAL + (e.Item.ItemIndex + 2).ToString()
															,"window"
															,Helper.ObtenerAnchodePantalla()-50,Helper.ObtenerAltodePantalla()-300)
															,"MostrarDetalle();"
												);

					for(int i=1;i<=12;i++){
						TextBox txt = (TextBox)e.Item.Cells[i].FindControl("txtCol" + i.ToString());
						txt.ReadOnly= ((Convert.ToInt32(dr["VerDetalle"].ToString())!=9)?true:false);
						txt.Text = Convert.ToDouble(dr[Utilitario.Helper.ObtenerNombreMes(i,Utilitario.Enumerados.TipoDatoMes.NombreCompleto)]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
						txt.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnKeydown.ToString(),"txtCol_onKeyDown()");
					}

				e.Item.Attributes.Add("IDRUBRO",dr["idRubro"].ToString());
				
				string strFormula = dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString();
				for(int i=0;i<= strFormula.Length-1;i++)
				{
					if (strFormula.Substring(i,1)==Utilitario.Constantes.SIGNOMAS || strFormula.Substring(i,1)==Utilitario.Constantes.SIGNOMENOS)
					{
						strFormula =strFormula.Substring((i+1),strFormula.Length-(i+1));
						break;
					}
				}
				e.Item.Attributes.Add("FORMULA",strFormula + Utilitario.Constantes.SIGNOARROBA);
				e.Item.Attributes.Add("PRIORIDAD",dr["idPrioridad"].ToString());

				if (dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString().Length>0)
				{stridFila += idFila.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA;}
				grid.Attributes.Add("FILAFORMULA",stridFila);

				idFila ++;

				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}	
		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
