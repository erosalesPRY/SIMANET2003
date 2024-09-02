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
using SIMA.Controladoras.Auditoria;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using System.IO;
using SIMA.EntidadesNegocio;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.GestionComercial.InformacionCompetencia
{
	public class AdministracionInformacionCompetencia : System.Web.UI.Page, IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTexto;
		protected projDataGridWeb.DataGridWeb dgArchivo;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlTable TablaAdjuntarArchivos;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDato1;
		protected System.Web.UI.WebControls.TextBox IdURL;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvIdURL;
		protected System.Web.UI.WebControls.Label lblDato2;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvDescripcion;
		#endregion

		#region Constantes
		//Ordenamiento de columna de grilla
		const string COLORDENAMIENTO = "IdArchivo";
				
		//Nombres de Controles
		const string CONTROLINK = "hlkIdArchivo";
		const string CONTROCHECKBOX = "cbxEliminarArchivo";
		const string CONTROLLBL = "lblDescripcion";	

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDTIPOARCHIVO = "IdTipoArchivo";	
		const string KEYQIDLBLPAGINA   = "IdLblPagina";     

		//JScript
		string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		
		//Otros
		const string GRILLAVACIA ="No existe ningún Archivo.";  

		//Numero de Registro
		const string TEXTOFOOTERTOTAL = "Total:";
		const string TITULOADMINISTRACION = "ADMINISTRACION ";
		const int POSICIONFOOTERTOTAL = 2;
		const int POSICIONINICIALCOMBO = 0;
		
		#endregion
	
		#region Variables		
		int REGISTROACTUAL;	
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.ObtenerTituloFormulario();

				try
				{
					this.ConfigurarAccesoControles();

					this.LlenarJScript();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"ModuloInformativo",this.ToString(),"Se consultó Informativo WEB.",Enumerados.NivelesErrorLog.I.ToString()));
                    					
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
			this.reiniciarCampos();
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.dgArchivo.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgArchivo_SortCommand);
			this.dgArchivo.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgArchivo_PageIndexChanged);
			this.dgArchivo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgArchivo_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{	
						this.Agregar();
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministracionInformacionCompetencia.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministracionInformacionCompetencia.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			
			CArchivo oCArchivo =  new CArchivo();
			DataTable dtArchivo = oCArchivo.ListarTodosPorTipo(Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOARCHIVO]).ToString());

			if(dtArchivo!=null)
			{
				DataView dwArchivo = dtArchivo.DefaultView;
				dwArchivo.Sort = columnaOrdenar ;
				dgArchivo.DataSource = dwArchivo;
				dgArchivo.Columns[0].FooterText = TEXTOFOOTERTOTAL;
				dgArchivo.Columns[POSICIONFOOTERTOTAL].FooterText = dwArchivo.Count.ToString();
				lblResultado.Visible = false;
			}
			else
			{
				dgArchivo.DataSource = dtArchivo;
				lblResultado.Visible= true;
				lblResultado.Text = GRILLAVACIA;				
			}
			try
			{
				if(indicePagina==0)
				{
					REGISTROACTUAL=0;
				}
				else
				{
					REGISTROACTUAL=(indicePagina * dgArchivo.PageSize);
				}

				dgArchivo.DataBind();		
			}
			catch (Exception e)
			{
				string a = e.Message;
				dgArchivo.CurrentPageIndex = 0;
				dgArchivo.DataBind();
			}
		}


		public void LlenarCombos()
		{
			// TODO:  Add AdministracionInformacionCompetencia.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministracionInformacionCompetencia.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// Dirección Página WEB
			rfvIdURL.ErrorMessage = Helper.ObtenerMensajesConfirmacionInformativoUsuario(Mensajes.CODIGOMENSAJEINFORMATIVOCAMPOREQUERIDODIRECCIONPAGWEB);
			rfvIdURL.ToolTip = Helper.ObtenerMensajesConfirmacionInformativoUsuario(Mensajes.CODIGOMENSAJEINFORMATIVOCAMPOREQUERIDODIRECCIONPAGWEB);

			//Descripción de Página WEB 
			rfvDescripcion.ErrorMessage = Helper.ObtenerMensajesConfirmacionInformativoUsuario(Mensajes.CODIGOMENSAJEINFORMATIVOCAMPOREQUERIDODESCRIPCION);
			rfvDescripcion.ToolTip = Helper.ObtenerMensajesConfirmacionInformativoUsuario(Mensajes.CODIGOMENSAJEINFORMATIVOCAMPOREQUERIDODESCRIPCION);

			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK, JSVERIFICARELIMINAR);
			
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministracionInformacionCompetencia.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministracionInformacionCompetencia.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministracionInformacionCompetencia.Exportar implementation
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
			return false;
		}

		#endregion

		#region IPaginaMantenimiento Members

		public void ObtenerTituloFormulario()
		{
			string descripcion = CTablaTablas.ObtenerDescripcionCodigo(Convert.ToInt32(Enumerados.TablasTabla.TipoArchivo),Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOARCHIVO]));
			this.lblTitulo.Text = TITULOADMINISTRACION + descripcion.ToString();
		}

		public void Agregar()
		{
			//Asigna valores para insertar 

			if (Convert.ToString(IdURL.Text) != Utilitario.Constantes.VACIO)
			{
				ArchivoBE  oArchivoBE = new ArchivoBE();
				oArchivoBE.Ruta = IdURL.Text.ToString();
				oArchivoBE.IdTablaTipoArchivo = Convert.ToInt32(Enumerados.TablasTabla.TipoArchivo);
				oArchivoBE.IdTipoArchivo = Convert.ToInt32(Page.Request.QueryString[KEYQIDTIPOARCHIVO]);
				oArchivoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
				oArchivoBE.FlgUrl = "1";
				oArchivoBE.Descripcion = txtDescripcion.Text.ToString();
				CMantenimientos oCMantenimientos = new CMantenimientos();

				//Graba en el Log la acción ejecutada

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"ModuloInformativo",this.ToString(),"Se guardó el Archivo " + IdURL.Text.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				int retorno = oCMantenimientos.Insertar(oArchivoBE);

				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
				
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"ModuloInformativo",this.ToString(),"Se registró el Archivo Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
			
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Utilitario.Constantes.INDICEPAGINADEFAULT);
				
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONUPLOADARCHIVO));	

					IdURL.Text = "";
					this.txtDescripcion.Text = Utilitario.Constantes.VACIO;
				}
			}
			else
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONARCHIVO));
			}
		
		}

		public void Modificar()
		{
			// TODO:  Add AdministracionInformacionCompetencia.Modificar implementation
		}

		private void eliminar()
		{
			RowSelectorColumn rSel = RowSelectorColumn.FindColumn(dgArchivo);
			
			if(rSel.SelectedIndexes.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				int indice = rSel.SelectedIndexes[0];
								
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(dgArchivo.DataKeys[indice]),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.ArchivoTAD.ToString())>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Informativo",this.ToString(),"Se eliminó Informativo WEB Nro. " + dgArchivo.DataKeys[indice].ToString() +"." ,Enumerados.NivelesErrorLog.I.ToString()));
				
					this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),Helper.ObtenerIndicePagina());
						
					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}		
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
			this.txtDescripcion.Text = Utilitario.Constantes.VACIO;
		}
		
		public void CargarModoModificar()
		{
			// TODO:  Add AdministracionInformacionCompetencia.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministracionInformacionCompetencia.CargarModoConsulta implementation
		}
		
		public bool ValidarCampos()
		{    
			if(this.ValidarCamposRequeridos())
			{
				return this.ValidarExpresionesRegulares();
			}
			else
			{
				return false;
			}
		}

		public bool ValidarCamposRequeridos()
		{
		
			if(IdURL.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionUsuario(Mensajes.CODIGOMENSAJESELECCIONARCHIVO));
				return false;		
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			if(!ExpresionesRegulares.ValidarExpresionRegularURL(Server.HtmlEncode(IdURL.Text)))
			{
				ltlMensaje.Text	= Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorInformativo.ToString(),Mensajes.CODIGOMENSAJEINFORMATIVOVALIDADIRECCIONPAGWEB));
				return false;
			}
			return true;
		}

		#endregion 

		private void dgArchivo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				HyperLink hlk = (HyperLink)e.Item.Cells[2].FindControl(CONTROLINK);

				string[] res = Utilitario.Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasArchivo.Ruta.ToString()])).Split('\\');
				int i=res.GetUpperBound(0);
				hlk.Text =res[i];
				hlk.NavigateUrl = Utilitario.Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasArchivo.Ruta.ToString()]));
				hlk.Target= "_new";

				Label lbl = (Label)e.Item.Cells[3].FindControl(CONTROLLBL);
				lbl.Text =  Utilitario.Helper.LimpiarTexto(Convert.ToString(dr[Enumerados.ColumnasArchivo.Descripcion.ToString()]));

				HtmlInputRadioButton rb = (HtmlInputRadioButton)e.Item.Cells[4].Controls[0];
				rb.Value = Convert.ToString(dr[Enumerados.ColumnasArchivo.IdArchivo.ToString()]);
				rb.Attributes.Add(Constantes.EVENTOCLICK,"AccionSeleccionFila('hCodigo',"+Convert.ToString(dr[Enumerados.ColumnasArchivo.IdArchivo.ToString()])+");");

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(dgArchivo.CurrentPageIndex,dgArchivo.PageSize,e.Item.ItemIndex);
			
			}	
		}

		private void dgArchivo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgArchivo.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void dgArchivo_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(e.SortExpression),Helper.ObtenerIndicePagina());
		}

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.eliminar();
		}

		private void reiniciarCampos()
		{
			this.hCodigo.Value = Utilitario.Constantes.VACIO;
		}
	}
}
