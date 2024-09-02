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
using SIMA.Controladoras.Secretaria.Directorio;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.Secretaria.Directorio;
using SIMA.EntidadesNegocio.GestionLogistica;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.DirectorEjecutivo.Director
{
	/// <summary>
	/// Summary description for DetallePoderes.
	/// </summary>
	public class DetalleAdquisicionesPropias : System.Web.UI.Page, IPaginaBase
	{
		protected System.Web.UI.WebControls.Literal ltlMensaje;
	
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

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA ADQUISICION";
		const string TITULOMODOMODIFICAR = "ADQUISICION";

		//Key Session y QueryString
		const string KEYQID = "Id";

		//Paginas
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		
		#endregion Constantes

		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblFecha;
		protected eWorld.UI.CalendarPopup CalFechaAdquisicion;
		protected System.Web.UI.WebControls.Label lblTema;
		protected System.Web.UI.WebControls.TextBox txtObjeto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvObjeto;
		protected System.Web.UI.WebControls.TextBox txtEntidad;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProveedor;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProyecto;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlbCentroOperativo;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlbMoneda;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected eWorld.UI.NumericBox txtMonto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMonto;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtLicitaciones;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvLicitaciones;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvConcursoPublico;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNumero;
		protected System.Web.UI.HtmlControls.HtmlInputHidden txtCliente;
		#endregion Controles
		protected System.Web.UI.HtmlControls.HtmlTableCell cellListDestino;
		protected System.Web.UI.WebControls.TextBox LstPrvs;
		protected System.Web.UI.WebControls.TextBox txtConcursoPublico;


		/// <summary>
		/// Llena el combo de Tipo Accion
		/// </summary>
		ListItem lItem;

		private void llenarTiposDeMoneda()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();
			ddlbMoneda.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlbMoneda.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbMoneda.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbMoneda.DataBind();
		}	

		private void llenarCentrosOperativos()
		{
			CCentroOperativo oCCentroOperativo=  new CCentroOperativo();
			ddlbCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			ddlbCentroOperativo.DataValueField=Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlbCentroOperativo.DataTextField=Enumerados.ColumnasCentroOperativo.Sigla1.ToString();
			ddlbCentroOperativo.DataBind();
		}	

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();

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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePoderes.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePoderes.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			//lItem = new ListItem(Constantes.TEXTOSSELECCIONAR,Constantes.VALORSELECCIONAR);
			this.llenarTiposDeMoneda();
			this.llenarCentrosOperativos();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePoderes.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.rfvConcursoPublico.ErrorMessage = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOCONCURSOPUBLICO);
			this.rfvConcursoPublico.ToolTip = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOCONCURSOPUBLICO);

			this.rfvLicitaciones.ErrorMessage = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOLICITACION);
			this.rfvLicitaciones.ToolTip = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOLICITACION);

			this.rfvMonto.ErrorMessage = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOMONTO2);
			this.rfvMonto.ToolTip = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOMONTO2);

			this.rfvObjeto.ErrorMessage = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOOBJETO2);
			this.rfvObjeto.ToolTip = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOOBJETO2);

			this.rfvProveedor.ErrorMessage = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOPROVEEDOR2);
			this.rfvProveedor.ToolTip = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOPROVEEDOR2);
            
            this.rfvProyecto.ErrorMessage = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOPROYECTO2);
			this.rfvProyecto.ToolTip = Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOPROYECTO2);

			/*ibtnBuscarPromotor.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + 
				Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + 
				Enumerados.TipoBusquedaEntidad.PRO,Constantes.ANCHOPOPUPBUSQUEDADEFECTO,
				Constantes.ALTOPOPUPBUSQUEDAPORDEFECTO, Constantes.MOSTRARSCROLLBAR));*/

			//ibtnAceptar.Attributes.Add(Constantes.EVENTOCLICK,Constantes.EVENTOVALIDATORONSUBMIT);		
			LstPrvs.Style.Add("display","none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePoderes.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePoderes.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePoderes.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePoderes.ConfigurarAccesoControles implementation
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
			// TODO:  Add DetallePoderes.ValidarFiltros implementation
			return true;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			AdquisicionesBE oAdquisicionesBE= new  AdquisicionesBE();

			oAdquisicionesBE.FechaAdquisicion = Convert.ToDateTime(CalFechaAdquisicion.SelectedDate);
			oAdquisicionesBE.ObjetoAdquisicion = txtObjeto.Text;	
			oAdquisicionesBE.IdProveedor = Convert.ToInt32(hIdCodigo.Value);
			
			oAdquisicionesBE.IdEntidad = Convert.ToInt32(hIdEntidad.Value);

			oAdquisicionesBE.IdTablaEntidad = Convert.ToInt32(hIdTablaEntidad.Value);
			oAdquisicionesBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oAdquisicionesBE.IdMoneda = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oAdquisicionesBE.MontoAdquisicion = Convert.ToDouble(txtMonto.Text);	
			oAdquisicionesBE.Proyecto = txtProyecto.Text;	
			oAdquisicionesBE.Licitaciones = txtLicitaciones.Text;	
			oAdquisicionesBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			//oAdquisicionesBE.ConcursoPublico = txtConcursoPublico.Text;
			oAdquisicionesBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.LogisticaEstadoAdquisicion);
			oAdquisicionesBE.IdEstado = Convert.ToInt32(Enumerados.EstadosAdquisiciones.Activo);
			oAdquisicionesBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			AdquisicionProveedorBE [] oAdquisicionProveedorBE = getProveedores(oAdquisicionesBE.IdAdquisicion);

			CAdquisiciones oCAdquisiciones = new CAdquisiciones();
			int retorno = oCAdquisiciones.Insertar(oAdquisicionesBE,oAdquisicionProveedorBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Adquisiciones",this.ToString(),"Se registró la Adquisicíón Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionSecretaria.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADQUISICION));
			}
		}

		public void Modificar()
		{
			AdquisicionesBE oAdquisicionesBE = new  AdquisicionesBE();

			oAdquisicionesBE.IdAdquisicion = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oAdquisicionesBE.FechaAdquisicion = Convert.ToDateTime(CalFechaAdquisicion.SelectedDate);
			oAdquisicionesBE.ObjetoAdquisicion = txtObjeto.Text;	
			/*oAdquisicionesBE.IdProveedor = Convert.ToInt32(hIdCodigo.Value);
			oAdquisicionesBE.IdEntidad = Convert.ToInt32(hIdEntidad.Value);
			oAdquisicionesBE.IdTablaEntidad = Convert.ToInt32(hIdTablaEntidad.Value);*/
			oAdquisicionesBE.IdTablaMoneda = Convert.ToInt32(Enumerados.TablasTabla.Moneda);
			oAdquisicionesBE.IdMoneda = Convert.ToInt32(ddlbMoneda.SelectedValue);
			oAdquisicionesBE.MontoAdquisicion = Convert.ToDouble(txtMonto.Text);	
			oAdquisicionesBE.Proyecto = txtProyecto.Text;	
			oAdquisicionesBE.Licitaciones = txtLicitaciones.Text;	
			oAdquisicionesBE.IdCentroOperativo = Convert.ToInt32(ddlbCentroOperativo.SelectedValue);
			//oAdquisicionesBE.ConcursoPublico = txtConcursoPublico.Text;
			oAdquisicionesBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			

			AdquisicionProveedorBE [] oAdquisicionProveedorBE = getProveedores(oAdquisicionesBE.IdAdquisicion);

			CAdquisiciones oCAdquisiciones = new CAdquisiciones();
			//if(oCAdquisiciones.Modificar(oAdquisicionesBE)>0)
			if(oCAdquisiciones.Modificar(oAdquisicionesBE,oAdquisicionProveedorBE)>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Adquisiciones",this.ToString(),"Se modificó la Adquisicíón Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionSecretaria.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONADQUISICION));
			}
		}

		private AdquisicionProveedorBE [] getProveedores(int IdAdquisicion){
			//{Codigo:'11611',RazonSocial:'INGEPESCA INV.PESQUERAS SRL.'}
			string []arrPrv = LstPrvs.Text.Split(';');
			AdquisicionProveedorBE []oAdqu_Prov = new AdquisicionProveedorBE[arrPrv.Length];
			int i=0;
			foreach(string item  in arrPrv){
				string strItem = item.Replace("{","").Replace("}","").Replace("'","");
				string []field_value = strItem.Split(',');
				AdquisicionProveedorBE oAdquisicionProveedorBE  = new AdquisicionProveedorBE();
				oAdquisicionProveedorBE.IdAdquisicion = IdAdquisicion;
				oAdquisicionProveedorBE.IdProveedor = Convert.ToInt32(field_value[0].Split(':')[1]);
				oAdquisicionProveedorBE.pIdEstado = 1;
				oAdqu_Prov[i]=new AdquisicionProveedorBE();
				oAdqu_Prov[i]=oAdquisicionProveedorBE;
				i++;
			}

			return oAdqu_Prov;
		}



		public void Eliminar()
		{
			// TODO:  Add DetallePoderes.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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
			lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
		}

		public void CargarModoModificar()
		{
				   lblTitulo.Text = TITULOMODOMODIFICAR;
				   this.LlenarCombos();
			
				   CAdquisiciones oCAdquisiciones = new CAdquisiciones();
				   AdquisicionesBE oAdquisicionesBE = (AdquisicionesBE)oCAdquisiciones.ConsultarDetalleAdquisicionesPropias(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
			
				   //Graba en el Log la acción ejecutada
				   LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Adquisiciones",this.ToString(),"Se consultó el Detalle de la Adquisición Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

				   if(oAdquisicionesBE!=null)
				   {
					   CalFechaAdquisicion.SelectedDate = oAdquisicionesBE.FechaAdquisicion;
					   txtObjeto.Text = oAdquisicionesBE.ObjetoAdquisicion.ToString();
					   //txtEntidad.Text = oAdquisicionesBE.Proveedor.ToString();
					   //hIdCodigo.Value = oAdquisicionesBE.IdProveedor.ToString();
					   //hIdEntidad.Value = oAdquisicionesBE.IdEntidad.ToString();
					   //hIdTablaEntidad.Value = oAdquisicionesBE.IdTablaEntidad.ToString();
					   DataTable dtprv = (new CAdquisicionesProveedor()).ListarAdquisicionProveedores(Convert.ToInt32(Page.Request.QueryString[KEYQID]));
					   string Separador="";
					   LstPrvs.Text="";
					   foreach(DataRow dr in dtprv.Rows)
					   {
						   Separador= ((LstPrvs.Text.Length>0)?";":"");
						   LstPrvs.Text += Separador + "{Codigo:'" + dr["IdProveedor"].ToString() + "',RazonSocial:'" + dr["RazonSOcial"].ToString() + "'}";
					   }
					   txtProyecto.Text = oAdquisicionesBE.Proyecto.ToString();

					   lItem = ddlbMoneda.Items.FindByValue(oAdquisicionesBE.IdMoneda.ToString());
					   if(lItem!=null)
					   {lItem.Selected = true;}

					   txtMonto.Text = oAdquisicionesBE.MontoAdquisicion.ToString();

					   lItem = ddlbCentroOperativo.Items.FindByValue(oAdquisicionesBE.IdCentroOperativo.ToString());
					   if(lItem!=null)
					   {lItem.Selected = true;}
				
					   txtLicitaciones.Text = oAdquisicionesBE.Licitaciones.ToString();
					  // txtConcursoPublico.Text = oAdquisicionesBE.ConcursoPublico.ToString();
				   }
			   
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePoderes.CargarModoConsulta implementation
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
			if(txtObjeto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOOBJETO2));
				return false;	
			}

			/*if(txtEntidad.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOPROVEEDOR2));
				return false;	
			}*/

			if(txtMonto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOMONTO2));
				return false;	
			}
			if(LstPrvs.Text==String.Empty){
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorSecretaria(Mensajes.CODIGOMENSAJEADQUISICIONCAMPOREQUERIDOPROVEEDOR2));
				return false;	
			}

			return true;		
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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

		private void redireccionaPaginaPrincipal()
		{
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		}
	}
}