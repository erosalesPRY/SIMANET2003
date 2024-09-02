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



namespace SIMA.SimaNetWeb.General.Formato
{
	/// <summary>
	/// Summary description for AdministrarFormato.
	/// </summary>
	public class AdministrarFormatoEstructura : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string KEYQIDFORMATO="IdFormato";
			const string KEYQIDREPORTE="IdReporte";

			const string GRILLAVACIA="No existe";
			const string KEYQNROFILAINI="NroFilaIni";
			const string KEYQREQCTATABLE="ReqCta";
		
			const string KEYQIDGRUPOFORMATO="IdGrupoFormato";
			const string KEYQIDFORMATOCONECTADO="IdFormatoConec";
			const string KEYQIDREPORTECONECTADO="IdReporteConec";

		#endregion

		public int IdFormato{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		public int IdReporte
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}

		public int IdGrupo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDGRUPOFORMATO]);}
		}

		
		const string IBTNFORMULA="ibtnFormula";
		const string fnjsFORMULAPORRUBRO="FormulaPorRubro(this.parentElement.parentElement)";
		const string fnjsFORMULAPORCUENTAS="FormulaPorCuentas(this.parentElement.parentElement)";
		
		


		#region Constantes
			protected System.Web.UI.WebControls.Image imgFormula;
			protected System.Web.UI.WebControls.Image imgBtnDetalle;
			protected eWorld.UI.NumericBox nMonto;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUserOld;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
			protected System.Web.UI.WebControls.Image imgBtnDescripcion;
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
					this.LlenarGrilla();
				}
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
			DataTable dt = (new  CFormatoEstructura()).ConsultarFormatoEstructura(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),0);
			if(dt!=null)
			{
				grid.DataSource = Helper.OrdenarFormatoEstructura(dt);
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
			// TODO:  Add AdministrarFormato.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarFormato.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarFormato.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			
		}

		public void LlenarJScript()
		{
			// TODO:  Add AdministrarFormato.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFormato.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFormato.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFormato.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarFormato.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFormato.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarFormato.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarFormato.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarFormato.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarFormato.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarFormato.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarFormato.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarFormato.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarFormato.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarFormato.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarFormato.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Attributes.Add("NoDrag","");
			}
			else if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;			
				HtmlImage oimg =  (HtmlImage)e.Item.Cells[1].FindControl(IBTNFORMULA);

				if(dr["EsFormato"].ToString()=="1")
				{
					e.Item.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"TIPONODOPRINCIPAL=1;");
					//Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"MostrarDatosEnCajaTexto('hidFilaSeleccionada',ObtenerRowId(this));" + Helper.MostrarDatosEnCajaTexto("hNroNivel",dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString()));
					Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"TIPONODOPRINCIPAL=1;");
					oimg.Style.Add("display","none");
				}
				else
				{
					e.Item.Attributes.Add("PRIORIDAD",dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString());
					e.Item.Attributes.Add("ORDEN",dr[Enumerados.ColumnasFormato.Orden.ToString()].ToString());
					e.Item.Attributes.Add("IDULTNIVELNEW",dr[Enumerados.ColumnasFormato.MaxUltDigNroNivel.ToString()].ToString());
					e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
					e.Item.Attributes.Add("IDTIPOLINEA",dr[Enumerados.ColumnasFormato.IdTipoLinea.ToString()].ToString());
					e.Item.Attributes.Add("VERMONTO",dr[Enumerados.ColumnasFormato.FlgVerMonto.ToString()].ToString());
					e.Item.Attributes.Add("NIVEL",dr[Enumerados.ColumnasFormato.idNivel.ToString()].ToString());
					e.Item.Attributes.Add("NOMBRE",dr[Enumerados.ColumnasFormato.Concepto.ToString()].ToString());

					
					//if(Convert.ToInt32(dr[Enumerados.ColumnasFormato.NroHijos.ToString()])==0)
					{
						if(Convert.ToInt32(dr["FORMENTRERUBRO"])==0)
						{
							oimg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),fnjsFORMULAPORRUBRO);
							oimg.Attributes.Add("title","Definir formula de rubros");
						}
						else
						{
							
							oimg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),fnjsFORMULAPORCUENTAS);
							oimg.Attributes.Add("title","Definir formula de cuentas");
						}
					}
					/*else
					{
						oimg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),fnjsFORMULAPORRUBRO);
						oimg.Attributes.Add("title","Definir formula de rubros");
					}*/	
					e.Item.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.Ondblclick.ToString(),"AgregarRubroAFormula(this)");


				

					DataTable dt = (new CFormatoReporteInterconexion()).Listar(this.IdFormato,this.IdReporte,Convert.ToInt32(dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString()));
					if(dt!=null&&dt.Rows.Count>0){
						foreach(DataRow drN in dt.Rows){
							HtmlTable tbl = Helper.CrearHtmlTabla(1,2);
							tbl.Attributes.Add("class","BaseItemInGrid");
							tbl.Rows[0].Cells[0].InnerHtml = drN["Nombre"].ToString() ;
							tbl.Rows[0].Cells[1].InnerHtml = "<p style='font-size:8px;color:red'> (" + drN["Formula"].ToString() +")</p>";
							e.Item.Cells[2].Controls.Add(tbl);

							e.Item.Attributes.Add("IDGRUPOINTERCONEX", drN["IdGrupoInterConex"].ToString());
							e.Item.Attributes.Add("IDFORMATOCONECTADO", drN["IdFormatoInterConex"].ToString());
							e.Item.Attributes.Add("IDREPORTECONECTADO", drN["IdReporteInterConex"].ToString());
						}
					}




					Utilitario.Helper.ConfiguraNodosTreeview(e,0,dr,"DetalleNodo('" + dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString() + "')");


					Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"MostrarDatosEnCajaTexto('hidFilaSeleccionada',ObtenerRowId(this));" + Helper.MostrarDatosEnCajaTexto("hNroNivel",dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString()));
					//Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"MostrarDatosEnCajaTexto('hidFilaSeleccionada',ObtenerRowId('" + (e.Item.ItemIndex+1).ToString() + "'));" + Helper.MostrarDatosEnCajaTexto("hNroNivel",dr[Enumerados.ColumnasFormato.NroNivel.ToString()].ToString()));
					 
				}
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
