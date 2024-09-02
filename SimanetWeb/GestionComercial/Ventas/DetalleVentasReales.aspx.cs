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
using SIMA.EntidadesNegocio.GestionComercial;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.Proyectos;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for DetalleVentasReales.
	/// </summary>
	public class DetalleVentasReales: System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblProyecto;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarProyecto;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProyecto;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.TextBox txtCliente;
		protected System.Web.UI.WebControls.Label lblSector;
		protected System.Web.UI.WebControls.TextBox txtSector;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.TextBox txtCentroOperativo;
		protected System.Web.UI.WebControls.Label lblLineaNegocio;
		protected System.Web.UI.WebControls.TextBox txtLineaNegocio;
		protected System.Web.UI.WebControls.Label lblMonto;
		protected System.Web.UI.WebControls.TextBox txtMonto;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.TextBox txtMoneda;
		protected System.Web.UI.WebControls.Label lblMontoSoles;
		protected System.Web.UI.WebControls.TextBox txtMontoSoles;
		protected System.Web.UI.WebControls.Label lblPromotor;
		protected System.Web.UI.WebControls.TextBox txtPromotor;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarPromotor;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.Label lblEmpresaDestino;
		protected System.Web.UI.WebControls.TextBox txtEmpresaDestino;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarEmpresaDestino;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.WebControls.RadioButtonList rblPromotor;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellibtnCancelar;
		#endregion

		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVA VENTA COLOCADA";
		const string TITULOMODOMODIFICAR = "VENTA COLOCADA";
		const string TITULOMODOCONSULTA = "VENTA COLOCADA DETALLADA";

		//Key Session y QueryString
		const string KEYQID = "Id";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";
		const string KEYQNOMBRE = "Nombre";
		const string KEYQIDMES = "IdMes";
		const string KEYQNOMBREMES = "NombreMes";
	
		//Paginas
		const string URLBUSQUEDAENTIDAD = "../../Legal/BusquedaEntidad.aspx?";
		const string URLBUSQUEDAPROYECTO = "../BusquedaProyecto.aspx?";
		const string URLPRINCIPALCONSULTA = "ConsultarDetalleVentasReales.aspx?";

		//Otros
		const int VentasSinPromotor = 0;
		const int VentasConPromotor = 1;
		
		#endregion Constantes
		
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
			this.ibtnBuscarProyecto.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnBuscarProyecto_Click);
			this.rblPromotor.SelectedIndexChanged += new System.EventHandler(this.rblPromotor_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			VENTAREALBE oVENTAREALBE = new VENTAREALBE();

			oVENTAREALBE.PRECIOVENTA = Convert.ToDouble(this.txtMontoSoles.Text);
			if(this.hIdCodigo.Value != Constantes.VACIO)
			{
				oVENTAREALBE.IDPROMOTOR = Convert.ToInt32(this.hIdCodigo.Value);
			}
			oVENTAREALBE.IDPROYECTOTRABAJO = Convert.ToInt32(this.hIdProyecto.Value);
			oVENTAREALBE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
			oVENTAREALBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasReales);
			oVENTAREALBE.IDESTADO = Convert.ToInt32(Enumerados.EstadosVentasReales.Activo);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVENTAREALBE.DESCRIPCION = this.txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Insertar(oVENTAREALBE);

			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se registró la Venta Real. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROVENTASREALES));
			}
		}

		public void Modificar()
		{
			VENTAREALBE oVENTAREALBE = new VENTAREALBE();

			oVENTAREALBE.IDVENTAREAL = Convert.ToInt32(Page.Request.QueryString[KEYQID]);
			oVENTAREALBE.PRECIOVENTA = Convert.ToDouble(this.txtMontoSoles.Text.Replace(Constantes.ESPACIO,Constantes.VACIO));
			if(this.hIdCodigo.Value != Constantes.VACIO)
			{
				oVENTAREALBE.IDPROMOTOR = Convert.ToInt32(this.hIdCodigo.Value);
			}
			oVENTAREALBE.IDPROYECTOTRABAJO = Convert.ToInt32(this.hIdProyecto.Value);
			oVENTAREALBE.IDUSUARIOREGISTRO = CNetAccessControl.GetIdUser();
			oVENTAREALBE.IDTABLAESTADO = Convert.ToInt32(Enumerados.TablasTabla.EstadosVentasReales);
			oVENTAREALBE.IDESTADO = Convert.ToInt32(Enumerados.EstadosVentasReales.Activo);
			if(txtDescripcion.Text.Trim()!=String.Empty)
			{
				oVENTAREALBE.DESCRIPCION = this.txtDescripcion.Text;
			}

			CMantenimientos oCMantenimientos = new CMantenimientos();

			int retorno = oCMantenimientos.Modificar(oVENTAREALBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se modificó la Venta Real Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJEMODIFICACIONREGISTROVENTASREALES));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleVentasReales.Eliminar implementation
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
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
		}

		public void CargarModoModificar()
		{
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			VENTAREALBE oVENTAREALBE = (VENTAREALBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.VentasRealesNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Venta Real Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVENTAREALBE!=null)
			{
				this.hIdProyecto.Value = oVENTAREALBE.IDPROYECTOTRABAJO.ToString();
				
				CProyectos oCProyectos = new CProyectos();
				DataRow dr = oCProyectos.ConsultarDetalleProyectoTrabajoVentaReal(oVENTAREALBE.IDPROYECTOTRABAJO);
				this.txtProyecto.Text = dr[Enumerados.ColumnasBusquedaProyecto.DESCRIPCION.ToString()].ToString();
				this.txtCliente.Text = dr[Enumerados.ColumnasBusquedaProyecto.RAZONSOCIAL.ToString()].ToString();
				this.txtSector.Text = dr[Enumerados.ColumnasBusquedaProyecto.SECTOR.ToString()].ToString();
				this.txtCentroOperativo.Text = dr[Enumerados.ColumnasBusquedaProyecto.CENTROOPERATIVO.ToString()].ToString();
				this.txtLineaNegocio.Text = dr[Enumerados.ColumnasBusquedaProyecto.LINEANEGOCIO.ToString()].ToString();
				this.txtMonto.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
				this.txtMonto.Text = double.Parse(dr[Enumerados.ColumnasBusquedaProyecto.MONTOPRECIOVENTASINIMPUESTO.ToString()].ToString()).ToString(Constantes.FORMATODECIMAL4);
				this.txtMoneda.Text = dr[Enumerados.ColumnasBusquedaProyecto.MONEDA.ToString()].ToString();
				this.txtMontoSoles.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
				this.txtMontoSoles.Text = double.Parse(dr[Enumerados.ColumnasBusquedaProyecto.MONTOPRECIOVENTASOLES.ToString()].ToString()).ToString(Constantes.FORMATODECIMAL4);

				if(!oVENTAREALBE.IDPROMOTOR.IsNull)
				{
					this.hIdCodigo.Value = oVENTAREALBE.IDPROMOTOR.ToString();
					CPromotores oCPromotores = new CPromotores();
					this.txtPromotor.Text = oCPromotores.ObtenerNombrePromotor(Convert.ToInt32(oVENTAREALBE.IDPROMOTOR));
				}
				else
				{
					this.rblPromotor.SelectedIndex = VentasSinPromotor;
				}

				if(!oVENTAREALBE.DESCRIPCION.IsNull)
				{
					this.txtDescripcion.Text = oVENTAREALBE.DESCRIPCION.ToString();
				}
			}
		}

		public void CargarModoConsulta()
		{
			this.CellibtnCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOCONSULTA;
			
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			VENTAREALBE oVENTAREALBE = (VENTAREALBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.VentasRealesNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionComercial",this.ToString(),"Se consultó el Detalle de la Venta Real Nro. " + Page.Request.QueryString[KEYQID] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oVENTAREALBE!=null)
			{
				this.hIdProyecto.Value = oVENTAREALBE.IDPROYECTOTRABAJO.ToString();
				
				CProyectos oCProyectos = new CProyectos();
				DataRow dr = oCProyectos.ConsultarDetalleProyectoTrabajoVentaReal(oVENTAREALBE.IDPROYECTOTRABAJO);
				this.txtProyecto.Text = dr[1].ToString();
				this.txtCliente.Text = dr[2].ToString();
				this.txtSector.Text = dr[3].ToString();
				this.txtCentroOperativo.Text = dr[4].ToString();
				this.txtLineaNegocio.Text = dr[5].ToString();
				this.txtMonto.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
				this.txtMonto.Text = double.Parse(dr[6].ToString()).ToString(Constantes.FORMATODECIMAL4);
				this.txtMoneda.Text = dr[7].ToString();
				this.txtMontoSoles.Style[Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();
				this.txtMontoSoles.Text = double.Parse(dr[8].ToString()).ToString(Constantes.FORMATODECIMAL4);

				if(!oVENTAREALBE.IDPROMOTOR.IsNull)
				{
					this.hIdCodigo.Value = oVENTAREALBE.IDPROMOTOR.ToString();
					CPromotores oCPromotores = new CPromotores();
					this.txtPromotor.Text = oCPromotores.ObtenerNombrePromotor(Convert.ToInt32(oVENTAREALBE.IDPROMOTOR));
				}
				else
				{
					this.rblPromotor.SelectedIndex = VentasSinPromotor;
					this.ModificarVentaConPromotor(false);
				}

				if(!oVENTAREALBE.DESCRIPCION.IsNull)
				{
					this.txtDescripcion.Text = oVENTAREALBE.DESCRIPCION.ToString();
				}
			}

			Helper.BloquearControles(this);
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(this.txtProyecto.Text.Trim()==String.Empty)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAREALCAMPOREQUERIDOPROYECTO));
				return false;
			}
			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleVentasReales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleVentasReales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleVentasReales.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleVentasReales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleVentasReales.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnBuscarProyecto.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPROYECTO,700,700,true));
			this.ibtnBuscarPromotor.Attributes.Add(Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD + Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.P,700,700,true));

			this.rfvProyecto.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAREALCAMPOREQUERIDOPROYECTO);
			this.rfvProyecto.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEVENTAREALCAMPOREQUERIDOPROYECTO);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleVentasReales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleVentasReales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleVentasReales.Exportar implementation
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


//		private void redireccionaPaginaPrincipalConsulta()
//		{
//			if(Page.Request.QueryString[Utilitario.Constantes.KEYSINDICEPAGINA] != null)
//			{
//				if(Page.Request.QueryString[Utilitario.Constantes.KEYSINDICEPAGINA].ToString() == Enumerados.DirectorioInformativo.V.ToString())
//				{
//					Page.Response.Redirect(URLPRINCIPALCONSULTA + 
//						KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDMES]) + Constantes.SIGNOAMPERSON + 
//						KEYQNOMBREMES + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBREMES] + Constantes.SIGNOAMPERSON + 
//						KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]) + Constantes.SIGNOAMPERSON + 
//						KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE]+ Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYSINDICEPAGINA.ToString() + Utilitario.Constantes.SIGNOIGUAL + Enumerados.DirectorioInformativo.V.ToString() + Utilitario.Constantes.SIGNOAMPERSON + 
//						Utilitario.Constantes.KEYQFILTRO +  Utilitario.Constantes.SIGNOIGUAL + ((Page.Request.Params[Utilitario.Constantes.KEYQFILTRO]!=null) ? Page.Request.Params[Utilitario.Constantes.KEYQFILTRO].ToString():Utilitario.Constantes.VACIO));
//				}
//			}
//			else
//			{
//				Page.Response.Redirect(URLPRINCIPALCONSULTA + 
//					KEYQIDMES + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDMES]) + Constantes.SIGNOAMPERSON + 
//					KEYQNOMBREMES + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBREMES] + Constantes.SIGNOAMPERSON + 
//					KEYQIDCENTROOPERATIVO + Constantes.SIGNOIGUAL + Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]) + Constantes.SIGNOAMPERSON + 
//					KEYQNOMBRE + Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQNOMBRE] + Utilitario.Constantes.SIGNOAMPERSON + 
//					Utilitario.Constantes.KEYQFILTRO +  Utilitario.Constantes.SIGNOIGUAL + ((Page.Request.Params[Utilitario.Constantes.KEYQFILTRO]!=null) ? Page.Request.Params[Utilitario.Constantes.KEYQFILTRO].ToString():Utilitario.Constantes.VACIO));				
//			}			
//		}

		private void rblPromotor_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.rblPromotor.SelectedIndex == VentasConPromotor)
			{
				this.txtPromotor.Text = Constantes.VACIO;
				this.ModificarVentaConPromotor(true);
			}

			else
			{
				this.txtPromotor.Text = Constantes.VACIO;
				this.ModificarVentaConPromotor(false);
			}
		}

		private void ModificarVentaConPromotor(bool valor)
		{
			this.lblPromotor.Visible = valor;
			this.txtPromotor.Visible = valor;
			this.ibtnBuscarPromotor.Visible = valor;
		}

		private void ibtnBuscarProyecto_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
		}
	}
}