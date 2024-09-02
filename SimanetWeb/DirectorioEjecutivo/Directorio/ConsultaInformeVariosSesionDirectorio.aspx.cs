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
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using SIMA.Controladoras.Secretaria.Directorio;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.Directorio
{
	/// <summary>
	/// Summary description for RequerimientosAsignados.
	/// </summary>
	public class ConsultaInformeVariosSesionDirectorio : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblPagina;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPosicionRegistro;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		#endregion Controles
		

		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "IdInformeVariosSesionDirecto";

		//Nombres de Controles
		const string CONTROLINK = "hlkId";
		const string CONTROCHECKBOX = "cbxEliminar";
		
		//Paginas
		const string URLDETALLE = "DetalleInformeVariosSesionDirectorio.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionInformeVariosSesionDirectorio.aspx";
		const string URLSESIONES = "ConsultaSesionDirectorio.aspx";
		//Key Session y QueryString
		
		const string KEYQIDSESIONDIRECTORIO = "IdSesionDirectorio";
		const string KEYQID = "Id";

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
			
		//Otros
		const string GRILLAVACIA ="No existe ningún  Informe de Sesión de Directorio.";  
		const string CONTROLIMGBUTTON = "imgDocumento";
		const string CONTROLIMGBUTTON2 = "imgDocumento2";
		const string CONTROLIMGBUTTON3 = "imgDocumento3";

		const string IMAGENCONDOCUMENTO="../../imagenes/ley1.gif";
		protected projDataGridWeb.DataGridWeb gridVarios;
		protected System.Web.UI.WebControls.Label lblInformesPermanentes;
		protected System.Web.UI.WebControls.Label lblInformesVarios;
		const string IMAGENSINDOCUMENTO="../../imagenes/ley2.gif";

		#endregion Constantes

		#region Variables
		#endregion Variables
		
					
		
		
		

		
		/// <summary>
		/// Elimina los Informes seleccionados
		/// </summary>
		private void eliminar()
		{
			if(hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.InformeVariosSesionDirectoTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Legal",this.ToString(),"Se eliminó el Informe de Sesión de Directorio Nro. " + hCodigo.Value +"." ,Enumerados.NivelesErrorLog.I.ToString()));
				
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
						
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}										
		}

		/// <summary>
		/// Limpia los valores ocultos
		/// </summary>
		private void reiniciarCampos()
		{
			//this.hCodigo.Value = "";

		}

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			

			if(!Page.IsPostBack)
			{
				try
				{
					
					this.ConfigurarAccesoControles();
					
					this.LlenarJScript();
					this.LlenarDatos();					

					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Secretaria - Directorio",this.ToString(),"Se consultó los Informes de Sesión de Directorio.",Enumerados.NivelesErrorLog.I.ToString()));
					

					this.LlenarGrillaOrdenamientoPaginacion("",Utilitario.Constantes.INDICEPAGINADEFAULT);
					this.LlenarGrillaOrdenamientoPaginacionVarios("",Utilitario.Constantes.INDICEPAGINADEFAULT);
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

			this.reiniciarCampos();
		}

		private void AsignarSession()
		{
			if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO] != null) 
			{
				if (Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString() != HttpContext.Current.Session[Utilitario.Constantes.KEYSIDSESIONDIRECTORIO].ToString())
				{
					Helper.GeneraSessionParaDirectorio(Page.Request.QueryString[KEYQIDSESIONDIRECTORIO].ToString());
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
			this.gridVarios.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridVarios_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			CInformeVariosSesionDirectorio oCInformeVariosSesionDirectorio =  new CInformeVariosSesionDirectorio();
			DataTable dtInformeVariosSesionDirectorio =  oCInformeVariosSesionDirectorio.ConsultarInformesVariosPorSesionDirectorio(
				Convert.ToInt32(Helper.RetornaSessionParaDirectorio()), 
				Convert.ToInt32(Enumerados.TiposInformeVarios.Permanentes));
			
			if(dtInformeVariosSesionDirectorio!=null)
			{
				DataView dwInformeVariosSesionDirectorio = dtInformeVariosSesionDirectorio.DefaultView;
				dwInformeVariosSesionDirectorio.Sort = columnaOrdenar ;
				dwInformeVariosSesionDirectorio.RowFilter= Utilitario.Helper.ObtenerFiltro();
				grid.DataSource = dwInformeVariosSesionDirectorio;
				
				grid.Columns[0].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				grid.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwInformeVariosSesionDirectorio.Count.ToString();

				//CImpresion oCImpresion = new CImpresion();
				//oCImpresion.GuardarDataImprimirExportar(dtInformeVariosSesionDirectorio,"REPORTE DE INFORMES VARIOS",columnaOrdenar,indicePagina);//Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCORRECTIVA),columnaOrdenar,indicePagina);
				lblInformesPermanentes.Visible =true;				
			}
			else
			{
				grid.DataSource = dtInformeVariosSesionDirectorio;
				lblInformesPermanentes.Visible =false;
	
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


		public void LlenarGrillaOrdenamientoPaginacionVarios(string columnaOrdenar,int indicePagina)
		{
			CInformeVariosSesionDirectorio oCInformeVariosSesionDirectorio =  new CInformeVariosSesionDirectorio();
			DataTable dtInformeVariosSesionDirectorio =  oCInformeVariosSesionDirectorio.ConsultarInformesVariosPorSesionDirectorio(
				Convert.ToInt32(Helper.RetornaSessionParaDirectorio()), 
				Convert.ToInt32(Enumerados.TiposInformeVarios.Varios));
			
			if(dtInformeVariosSesionDirectorio!=null)
			{
				DataView dwInformeVariosSesionDirectorio = dtInformeVariosSesionDirectorio.DefaultView;
				dwInformeVariosSesionDirectorio.Sort = columnaOrdenar ;
				dwInformeVariosSesionDirectorio.RowFilter= Utilitario.Helper.ObtenerFiltro();
				gridVarios.DataSource = dwInformeVariosSesionDirectorio;
				
				gridVarios.Columns[0].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL;
				gridVarios.Columns[Utilitario.Constantes.POSICIONTOTAL].FooterText = dwInformeVariosSesionDirectorio.Count.ToString();			
				lblInformesVarios.Visible =true;
			}
			else
			{
				gridVarios.DataSource = dtInformeVariosSesionDirectorio;
				lblInformesVarios.Visible =false;
			}

			try
			{
				gridVarios.DataBind();
			}
			catch	
			{
				gridVarios.CurrentPageIndex = 0;
				gridVarios.DataBind();
			}
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.AsignarSession();
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultaDeCartasFianzas.LlenarJScript implementation
			/*ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN, Utilitario.Constantes.HISTORIALADELANTE);
			ibtnSesiones.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLSESIONES,""));*/
		}

		public void RegistrarJScript()
		{
	

		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,650,700,false,false,false,true,true);
		}

		public void Exportar()
		{
			
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add ConsultaDeCartasFianzas.ConfigurarAccesoControles implementation

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
			return true;
		}

		

		#endregion


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				Image ibtn=(Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento.ToString() ])!= String.Empty)
				{
					ibtn.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento.ToString()]));
				}
				else
				{ibtn.ImageUrl = IMAGENSINDOCUMENTO;}

				Image ibtn2=(Image)e.Item.Cells[3].FindControl(CONTROLIMGBUTTON2);	
				if (Convert.ToString(dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento2.ToString() ])!= String.Empty)
				{
					ibtn2.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn2.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento2.ToString()]));
				}
				else
				{ibtn2.ImageUrl = IMAGENSINDOCUMENTO;}

				Image ibtn3=(Image)e.Item.Cells[4].FindControl(CONTROLIMGBUTTON3);	
				if (Convert.ToString(dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento3.ToString() ])!= String.Empty)
				{
					ibtn3.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn3.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento3.ToString()]));
				}
				else
				{ibtn3.ImageUrl = IMAGENSINDOCUMENTO;}			
			}	
		}

		/// <summary>
		/// Abre la Pagina para Agregar una Cuenta Bancaria
		/// </summary>
		private void redireccionaPaginaAgregar()
		{
			
			Page.Response.Redirect(URLDETALLE+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + 
				Enumerados.ModoPagina.N.ToString());
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

		private void imgEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();																
		}

		private void gridVarios_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				Image ibtn=(Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento.ToString() ])!= String.Empty)
				{
					ibtn.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento.ToString()]));
				}
				else
				{ibtn.ImageUrl = IMAGENSINDOCUMENTO;}

				Image ibtn2=(Image)e.Item.Cells[3].FindControl(CONTROLIMGBUTTON2);	
				if (Convert.ToString(dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento2.ToString() ])!= String.Empty)
				{
					ibtn2.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn2.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento2.ToString()]));
				}
				else
				{ibtn2.ImageUrl = IMAGENSINDOCUMENTO;}

				Image ibtn3=(Image)e.Item.Cells[4].FindControl(CONTROLIMGBUTTON3);	
				if (Convert.ToString(dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento3.ToString() ])!= String.Empty)
				{
					ibtn3.ImageUrl = IMAGENCONDOCUMENTO;
					ibtn3.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),
						Helper.AbrirArchivo(Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTASERVERDOCUMENTOSDIRECTORIO) + 
						dr[Enumerados.ColumnasInformeVariosSesionDirectorio.Documento3.ToString()]));
				}
				else
				{ibtn3.ImageUrl = IMAGENSINDOCUMENTO;}			
			}			
		}
	}
}

