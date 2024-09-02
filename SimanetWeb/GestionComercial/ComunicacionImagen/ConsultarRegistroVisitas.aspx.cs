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
using SIMA.Controladoras.GestionComercial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{
	/// <summary>
	/// Summary description for ConsultarRegistroVisitas.
	/// </summary>
	public class ConsultarRegistroVisitas : System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblTipoPersona;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPersona;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFoto;
		protected System.Web.UI.WebControls.ImageButton ibtnVideo;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDescripcion;
		#endregion Controles

		#region Constantes
		//Ordenamiento
		const string COLORDENAMIENTO = "IdVisitas";

		//Nombres de Controles
		const string CONTROLIMAGENREGALO = "imgRegalo";
		const string CONTROLIMAGENFOTO = "imgFoto";
		const string CONTROLIMAGENVIDEO = "imgVideo";
		
		//Paginas
		const string URLDETALLE = "DetalleRegistroVisitas.aspx?";
		const string URLIMPRESION = "PopupImpresionAdministracionArticulosRelacionesPublicas.aspx";
		const string URLCONSULTAFOTOS = "ConsultarFotos.aspx?";
		const string URLCONSULTAVIDEOS = "ConsultarVideos.aspx?";
				
		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQDESCRIPCION = "Descripcion";
		const string KEYTIPO = "Tipo";
		const string KEYQPOSICIONCOMBO = "PosicionComboVisita";
		//JScript
		
			
		//Otros
		const string GRILLAVACIA ="No existe ningun Registro de Visitas.";
		const int POSICIONINICIALCOMBO = 0;
		const int PosicionFooterTotal = 2;
		const int PosicionImagenRegalo = 12;
		const int PosicionImageFoto = 13;
		const int PosicionImagenVideo = 14;
		const string ImagenRegaloNo = "../../imagenes/CheckNo.png";
		const string ImagenRegaloSi = "../../imagenes/CheckYes.png";
		const string ImagenFotoSi = "../../imagenes/Foto.jpg";
		const string ImagenFotoNo = "../../imagenes/FotoBW.jpg";
		const string ImagenVideoSi = "../../imagenes/Video.jpg";
		const string ImagenVideoNo = "../../imagenes/VideoBW.jpg";
		#endregion Constantes

		#region Variables
		#endregion Variables
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

					Helper.ReiniciarSession();
					
					this.LlenarJScript();

					this.LlenarCombos();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Registro de Visitas.",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ddlbTipoPersona.SelectedIndexChanged += new System.EventHandler(this.ddlbTipoPersona_SelectedIndexChanged);
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnFoto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFoto_Click);
			this.ibtnVideo.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnVideo_Click);
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarRegistroVisitas.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarRegistroVisitas.LlenarGrillaOrdenamiento implementation
		}

		public DataTable ObtenerDatos()
		{
			CRegistroVisitas oCRegistroVisitas =  new CRegistroVisitas();
			return oCRegistroVisitas.ConsultarRegistroDeVisitasPorTipoDePersona(Convert.ToInt32(this.ddlbTipoPersona.SelectedValue));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar,int indicePagina)
		{
			DataTable dtRegistroVisitas = this.ObtenerDatos();
			
			if(dtRegistroVisitas!=null)
			{
				DataView dwRegistroVisitas = dtRegistroVisitas.DefaultView;
				dwRegistroVisitas.Sort = columnaOrdenar ;
				dwRegistroVisitas.RowFilter = Helper.ObtenerFiltro(this);

				if(dwRegistroVisitas.Count>0)
				{
					grid.DataSource = dwRegistroVisitas;
					grid.Columns[PosicionFooterTotal].FooterText = dwRegistroVisitas.Count.ToString();
					this.lblResultado.Visible = false;
				}
				else
				{
					grid.DataSource = null;
					lblResultado.Visible = true;
					lblResultado.Text = GRILLAVACIA;
				}
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dwRegistroVisitas.Table,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEPRESENTES),columnaOrdenar,indicePagina);
			}
			else
			{
				grid.DataSource = dtRegistroVisitas;
				this.lblResultado.Visible = true;
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
			this.llenarTiposPersona();
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarRegistroVisitas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnFoto.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnVideo.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

			ibtnFoto.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnFoto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);

			ibtnVideo.Attributes.Add(Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO));
			ibtnVideo.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, Utilitario.Constantes.POPUPDEESPERA);

		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarRegistroVisitas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarRegistroVisitas.Exportar implementation
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
			return true;
		}

		#endregion

		/// <summary>
		/// Llena el combo de Tipos de Persona
		/// </summary>
		private void llenarTiposPersona()
		{
			ListItem lItem1 = new ListItem(Enumerados.TiposOrigenVistaEntidad.Cliente.ToString(),Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Cliente).ToString());
			ListItem lItem2 = new ListItem(Enumerados.TiposOrigenVistaEntidad.Personal.ToString(),Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Personal).ToString());
			ListItem lItem3 = new ListItem(Enumerados.TiposOrigenVistaEntidad.Visita.ToString(),Convert.ToInt32(Enumerados.TiposOrigenVistaEntidad.Visita).ToString());
			ddlbTipoPersona.Items.Insert(POSICIONINICIALCOMBO,lItem1);
			ddlbTipoPersona.Items.Insert(POSICIONINICIALCOMBO+1,lItem2);
			ddlbTipoPersona.Items.Insert(POSICIONINICIALCOMBO+2,lItem3);
			ddlbTipoPersona.DataBind();
			if(HttpContext.Current.Session[KEYQPOSICIONCOMBO] != null)
			{
				this.ddlbTipoPersona.Items.FindByValue(HttpContext.Current.Session[KEYQPOSICIONCOMBO].ToString()).Selected = true;
			}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

				e.Item.Cells[Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLDETALLE,KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
					Convert.ToString(dr[Enumerados.ColumnasRegistroVisita.IdVisitas.ToString()]) +  
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()));

				if(Convert.ToInt32(dr[Enumerados.ColumnasRegistroVisita.FlgEntregaRegalo.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenRegalo].FindControl(CONTROLIMAGENREGALO);
					img1.ImageUrl = ImagenRegaloNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenRegalo].FindControl(CONTROLIMAGENREGALO);
					img1.ImageUrl = ImagenRegaloSi;
				}
				if(Convert.ToInt32(dr[Enumerados.ColumnasRegistroVisita.IdCodigoFoto.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImageFoto].FindControl(CONTROLIMAGENFOTO);
					img1.ImageUrl = ImagenFotoNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImageFoto].FindControl(CONTROLIMAGENFOTO);
					img1.ImageUrl = ImagenFotoSi;
				}

				if(Convert.ToInt32(dr[Enumerados.ColumnasRegistroVisita.IdCodigoVideo.ToString()]) == Constantes.POSICIONCONTADOR)
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenVideo].FindControl(CONTROLIMAGENVIDEO);
					img1.ImageUrl = ImagenVideoNo;
				}
				else
				{
					Image img1 = (Image)e.Item.Cells[PosicionImagenVideo].FindControl(CONTROLIMAGENVIDEO);
					img1.ImageUrl = ImagenVideoSi;
				}
	
				e.Item.Cells[Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[Constantes.POSICIONCONTADOR].Font.Underline=true;
				e.Item.Cells[Constantes.POSICIONCONTADOR].ForeColor = System.Drawing.Color.Blue;

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Enumerados.ColumnasRegistroVisita.IdVisitas.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTexto("hDescripcion",dr[Enumerados.ColumnasVisita.Nombres.ToString()].ToString()));
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
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

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//this.Imprimir();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			ltlMensaje.Text= Utilitario.Helper.ElaborarFiltro(this.ObtenerDatos()
					,Utilitario.Enumerados.ColumnasVisita.Nombres.ToString()+";Nombre"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasBuque.IdGrado.ToString()+ ";Grado"
					,Utilitario.Enumerados.ColumnasVisita.Cargo.ToString()+ ";Cargo"
					,Constantes.SIGNOASTERISCO + Utilitario.Enumerados.ColumnasVisita.IdUbigeo.ToString()+ ";Nacionalidad"
					,Utilitario.Enumerados.ColumnasRegistroVisita.FechaVisita.ToString()+ ";Fecha de l Visita"
					,Utilitario.Enumerados.ColumnasRegistroVisita.HoraEntrada.ToString()+ ";HoraEvntrada"
					,Utilitario.Enumerados.ColumnasRegistroVisita.HoraSalida.ToString()+ ";Hora Salida");
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ddlbTipoPersona_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[KEYQPOSICIONCOMBO] = this.ddlbTipoPersona.SelectedValue;

			Helper.EliminarFiltro();

			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron los Registro de Visitas.",Enumerados.NivelesErrorLog.I.ToString()));

			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
		}

		private void ibtnFoto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLCONSULTAFOTOS+
					KEYQID+Constantes.SIGNOIGUAL+this.hCodigo.Value+Constantes.SIGNOAMPERSON+
					KEYQDESCRIPCION+Constantes.SIGNOIGUAL+this.hDescripcion.Value+Constantes.SIGNOAMPERSON+
					KEYTIPO+Constantes.SIGNOIGUAL+Enumerados.TipoEntidadConFoto.Visita.ToString());
			}
		}

		private void ibtnVideo_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.hCodigo.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				Page.Response.Redirect(URLCONSULTAVIDEOS+
					KEYQID+Constantes.SIGNOIGUAL+this.hCodigo.Value+Constantes.SIGNOAMPERSON+
					KEYQDESCRIPCION+Constantes.SIGNOIGUAL+this.hDescripcion.Value+Constantes.SIGNOAMPERSON+
					KEYTIPO+Constantes.SIGNOIGUAL+Enumerados.TipoEntidadConFoto.Visita.ToString());
			}
		}
	}
}