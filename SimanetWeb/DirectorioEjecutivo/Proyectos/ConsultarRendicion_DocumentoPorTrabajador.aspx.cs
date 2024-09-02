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
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Proyectos
{
	public class ConsultarRendicion_DocumentoPorTrabajador : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string COLORDENAMIENTO = "folio";

		const string KEYCENTRO ="Centro";
		const string KEYIDTRABAJADOR = "COD_PROYECTO";
		const string KEYTRABAJADOR = "PROYECTO";
		
		//Otros
		const string CAMPO_IMP_SOL = "lblIMP_SOL";
		const string CAMPO_DEV_SOL = "lblDEV_SOL";
		const string CAMPO_REN_SOL = "lblREN_SOL";
		const string CAMPO_PEN_SOL = "lblPEN_SOL";

		const string CAMPO_IMP_DOL = "lblIMP_DOL";
		const string CAMPO_DEV_DOL = "lblDEV_DOL";
		const string CAMPO_REN_DOL = "lblREN_DOL";
		const string CAMPO_PEN_DOL = "lblPEN_DOL";

		const string CONTROLMONTOTOTAL_IMP_SOL = "lblTIMP_SOL";
		const string CONTROLMONTOTOTAL_DEV_SOL = "lblTDEV_SOL";
		const string CONTROLMONTOTOTAL_REN_SOL = "lblTREN_SOL";
		const string CONTROLMONTOTOTAL_PEN_SOL = "lblTPEN_SOL";

		const string CONTROLMONTOTOTAL_IMP_DOL = "lblTIMP_DOL";
		const string CONTROLMONTOTOTAL_DEV_DOL = "lblTDEV_DOL";
		const string CONTROLMONTOTOTAL_REN_DOL = "lblTREN_DOL";
		const string CONTROLMONTOTOTAL_PEN_DOL = "lblTPEN_DOL";

		const string TOTALIZA ="Totaliza";

		#endregion
		#region Controles

		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;

		ArrayList arrTotaliza;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Rendición de Cuenta",this.ToString(),"Se consultó Rendiciones de cuenta Pendientes",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarCabecera();
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
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
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
		}

		public void LlenarCabecera()
		{
			lblTitulo.Text = Page.Request[KEYCENTRO].ToString().ToUpper() + Utilitario.Constantes.SEPARADOR +  Page.Request[KEYTRABAJADOR].ToString().ToUpper();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		private DataTable ObtenerDatos()
		{
			CProyectos oCProyectos= new CProyectos();
			DataTable dtGeneral =oCProyectos.ConsultarRendicionCuentasPendientesPorTrabajador(Convert.ToInt32(Page.Request.Params[KEYIDTRABAJADOR].ToString()));			
			return dtGeneral;
		}
		private void Totaliza(DataView dv)
		{
			arrTotaliza = new ArrayList();
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.IMP_SOL.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.DEV_SOL.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.REN_SOL.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.PEN_SOL.ToString() + ")",dv.RowFilter.ToString()));
			
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.IMP_DOL.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.DEV_DOL.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.REN_DOL.ToString() + ")",dv.RowFilter.ToString()));
			arrTotaliza.Add((object)dv.Table.Compute("SUM(" + Enumerados.INTColumna_RENDICIONCUENTAS_PEND.PEN_DOL.ToString() + ")",dv.RowFilter.ToString()));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = columnaOrdenar ;
				dwGeneral.RowFilter = Helper.ObtenerFiltro();
				this.Totaliza(dwGeneral);
				grid.DataSource = dwGeneral;
				grid.CurrentPageIndex = indicePagina;

				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwGeneral.Count.ToString();

				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception oException)
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}												
		}

		public void LlenarCombos()
		{
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
		}

		public void RegistrarJScript()
		{
		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}	
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			#region ITEM
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				((Label)e.Item.Cells[5].FindControl(CAMPO_IMP_SOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.IMP_SOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO_DEV_SOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.DEV_SOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO_REN_SOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.REN_SOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);				
				((Label)e.Item.Cells[5].FindControl(CAMPO_PEN_SOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.PEN_SOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);				

				((Label)e.Item.Cells[5].FindControl(CAMPO_IMP_DOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.IMP_DOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO_DEV_DOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.DEV_DOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				((Label)e.Item.Cells[5].FindControl(CAMPO_REN_DOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.REN_DOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);				
				((Label)e.Item.Cells[5].FindControl(CAMPO_PEN_DOL)).Text= Convert.ToDouble(dr[Enumerados.INTColumna_RENDICIONCUENTAS_PEND.PEN_DOL.ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);				

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);			
			}	
			#endregion

			#region FOOTER
			if(e.Item.ItemType == ListItemType.Footer)
			{
				if (arrTotaliza.Count > 0)
				{
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_IMP_SOL)).Text=Convert.ToDouble(arrTotaliza[0]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_DEV_SOL)).Text=Convert.ToDouble(arrTotaliza[1]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_REN_SOL)).Text=Convert.ToDouble(arrTotaliza[2]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PEN_SOL)).Text=Convert.ToDouble(arrTotaliza[3]).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_IMP_DOL)).Text=Convert.ToDouble(arrTotaliza[4]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_DEV_DOL)).Text=Convert.ToDouble(arrTotaliza[5]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_REN_DOL)).Text=Convert.ToDouble(arrTotaliza[6]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((Label) e.Item.Cells[5].FindControl(CONTROLMONTOTOTAL_PEN_DOL)).Text=Convert.ToDouble(arrTotaliza[7]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
			}		
			#endregion
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			grid.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);				
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());		
		}
	}
}
