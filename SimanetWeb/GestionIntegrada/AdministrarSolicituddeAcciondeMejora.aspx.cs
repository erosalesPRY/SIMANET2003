using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for AdministrarSolicituddeAcciondeMejora.
	/// </summary>
	public class AdministrarSolicituddeAcciondeMejora : System.Web.UI.Page,IPaginaBase
	{
		const string GRILLAVACIA="No existen datos";
		const string KEYQIDSAM = "IdSAM";
		const string URLDETALLE="/GestionIntegrada/DetalleSolicituddeAcciondeMejora.aspx?";
		const string URLDETALLE2="DetalleSolicituddeAcciondeMejora.aspx?";
		string Hallazgo="";

		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hIdSAM','No se ha seleccionado registro a ser eliminado','Desea Ud. Eliminar este registro ahora?');";


		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminaFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidCentro;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdDestino;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdSAM;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Integrada: Administrar Solicitad de acción de mejora", this.ToString(),"Se consultó El Listado de SAM emitidas por cada usuario responsable.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina();
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

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
					string msg = oException.Message.ToString();
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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
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
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return (new CSolicituddeAcciondeMejora()).ListarTodosGrilla("0");
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();

			if (dt!=null)
			{
				DataView dv     = dt.DefaultView;
				dv.Sort         = columnaOrdenar;
				dv.RowFilter    = Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dv;

				grid.CurrentPageIndex     = indicePagina;
				this.lblResultado.Visible = false;

				/*grid.Columns[POSICIONFOOTERTOTAL].FooterText     = TEXTOFOOTERTOTAL;
				grid.Columns[POSICIONFOOTERTOTAL+1].FooterText   = dv.Count.ToString() + " de " + dt.Rows.Count.ToString();
				*/
			}
			else
			{
				grid.DataSource = dt;
				this.lblResultado.Visible = true;
				this.lblResultado.Text    = GRILLAVACIA;
			}
			
			try
			{
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnEliminar.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA + Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina","hCodigo","hidCentro"));
			this.ibtnImprimir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("hIdRow","hGridPaginaSort","hGridPagina","hIdSAM","hIdDestino","hidUsuarioEmite","hIdAccionInmediata","hIdArea")+Helper.PopupDeEspera());
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarSolicituddeAcciondeMejora.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Image oingEst = (Image) e.Item.Cells[8].FindControl("imgEstado");
				oingEst.ImageUrl = Page.Request.ApplicationPath +"/imagenes/Navegador/db.png";
				bool Open=false;
				try
				{
					
					foreach(DataRow dri in (new CSAMDestino()).ListarTodosGrilla(dr["IdSAM"].ToString(),"0").Rows)
					{
						HtmlTable TBLItem =  Helper.CrearHtmlTabla(1,2,true);
						TBLItem.Border=0;
						TBLItem.CellSpacing=0;
						TBLItem.Rows[0].Attributes["class"] ="BaseItemInGrid";
						TBLItem.Rows[0].Cells[0].InnerText = dri["NombreArea"].ToString();
						TBLItem.Rows[0].Cells[0].Attributes["noWrap"] ="noWrap";

						HtmlImage oImg = new HtmlImage();
						oImg.Style.Add("cursor", "hand");
						oImg.Src =  Page.Request.ApplicationPath +"/imagenes/Navegador/db.png";
						if(dri["IdEstado"].ToString()!="2")
						{
							//oImg.Attributes["onclick"]="EnviarCorreoEliminacion('" + dr["IdSAM"].ToString() + "','" + dri["idDestino"].ToString() + "');";
							Open=true;
						}
						else{
							oImg.Src =  Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";
						}
						

						TBLItem.Rows[0].Cells[1].Controls.Add(oImg);

						e.Item.Cells[3].Controls.Add(TBLItem);
					}
				}
				catch(Exception ex){

				}
				if(Open==false){oingEst.ImageUrl = Page.Request.ApplicationPath +"/imagenes/EvaluacionPersonal/Cerrado.png";}


				Helper.UIControls.DataGrid.CHiperLink((DataGrid)sender, e.Item.Cells[0],"HistorialIrAdelantePersonalizado('hGridPaginaSort;hidCentro;hGridPagina;hCodigo')"
					,Helper.Response.Redirec( Page.Request.ApplicationPath + URLDETALLE + KEYQIDSAM + Utilitario.Constantes.SIGNOIGUAL + dr["IdSAM"].ToString() 
											+ Utilitario.Constantes.SIGNOAMPERSON 
											+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.M.ToString(),false));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,"grid_onClick(this);" + Helper.MostrarDatosEnCajaTexto("hIdSAM",dr["IdSAM"].ToString()));

				Helper.FiltroporSeleccionConfiguraColumna(e,grid,true,"txtBuscar");
			}		
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLDETALLE2 +  Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModoPagina.N.ToString());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos(),"CodigoSAM;Codigo"
																,Utilitario.Constantes.SIGNOASTERISCO + "NombreLugarDetectado;Lugar detectado"
																,"DescripcionHallazgo;Descripcion del hallazgo"
																,Utilitario.Constantes.SIGNOASTERISCO + "NombreTipoAccion;Tipo de Accion"
																);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));

		}

		private void ibtnEliminaFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value, Convert.ToInt32(hGridPagina.Value));
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.eliminar();
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


		private void eliminar()
		{
			if(hIdSAM.Value.Length == 0)
			{
				ltlMensaje.Text = Helper.MensajeAlert("Desea eliminar este registro ahora?");
			}
			else
			{			
				
				if((new CSolicituddeAcciondeMejora()).Eliminar(this.hIdSAM.Value)> 0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se eliminó el cliente nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
					this.hIdSAM.Value="0";
				}
			}
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			/*if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex+1,0,e.Item.ItemType);
				di.CssClass="ItemGrillaText";
				TableCell tc = new TableCell();
				tc.ColumnSpan=grid.Columns.Count;
				tc.HorizontalAlign= System.Web.UI.WebControls.HorizontalAlign.Left;
				tc.Controls.Add(new LiteralControl(Hallazgo));
				di.Cells.Add(tc);


				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
				
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				DataGridItem di = new DataGridItem(e.Item.ItemIndex+1,0,e.Item.ItemType);
				di.CssClass="ItemGrillaText";
				TableCell tc = new TableCell();
				tc.ColumnSpan=grid.Columns.Count;
				tc.HorizontalAlign= System.Web.UI.WebControls.HorizontalAlign.Left;
				tc.Controls.Add(new LiteralControl(Hallazgo));
				di.Cells.Add(tc);


				DataGrid dg = (DataGrid)sender;
				Table t = (Table)dg.Controls[0];
				t.Rows.Add(di);
         
			}*/
		}

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			(new AdministrarRescepcionSolicitudeAcciondeMejora()).VistaPreviaSAM(this.hIdSAM.Value,this.hIdDestino.Value);
		}
	}
}
