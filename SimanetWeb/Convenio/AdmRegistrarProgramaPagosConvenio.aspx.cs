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
using SIMA.EntidadesNegocio.Convenio;
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se le da mantenimiento a los pagos realizados dentro o fuera del cronograma. Una
	/// Vez ingresado el PEriodo no se puede modificar pero si se puede eliminar y crear otro.
	/// Si ingresas un perido que ya existe, la aplicacion te manda una mensaje que no se puede
	/// Este formulario ya paso por Refactory
	/// </summary>
	
	public class AdmRegistrarProgramaPagosConvenio : System.Web.UI.Page,IPaginaMantenimento, IPaginaBase
	{
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
		#region IPaginaMantenimento Members
		public void Agregar()
		{
			CronogramaPagoConvenioBE oCronogramaPagoConvenioBE=new CronogramaPagoConvenioBE();
			oCronogramaPagoConvenioBE.IdConvenioSimaMgp=Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]);
			oCronogramaPagoConvenioBE.Periodo=Convert.ToInt32(this.nbPeriodo.Text);
			oCronogramaPagoConvenioBE.Mes=Convert.ToInt32(this.ddltMeses.SelectedValue);
			oCronogramaPagoConvenioBE.Observaciones=this.txtObservaciones.Text;			

			CCronogramaPagoConvenio oCCronogramaPagoConvenio=new CCronogramaPagoConvenio();
			int retorno=Utilitario.Constantes.ValorConstanteCero;
			
			Enumerados.EstadoRangoPagoConvenio oEstado=(Enumerados.EstadoRangoPagoConvenio)System.Enum.Parse(typeof(Enumerados.EstadoRangoPagoConvenio),this.Page.Request.Params[KEYIDRANGOPAGO].ToString());

			CMantenimientos oCMantenimientos=new CMantenimientos();

			switch (oEstado)
			{
				case Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma:
					oCronogramaPagoConvenioBE.MontoProgramado=Convert.ToDouble(this.nbMonto.Text);
					oCronogramaPagoConvenioBE.IdTablaRangoPago=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.RangoPagoConvenio);
					oCronogramaPagoConvenioBE.IdRangoPago=Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma);

					
					retorno = oCMantenimientos.Insertar(oCronogramaPagoConvenioBE);

					if (retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEAGREGARP  + 
						hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
						
						this.LlenarGrillaOrdenamiento(COLORDENAMIENTO);
						this.nbMonto.Text="";
						this.txtObservaciones.Text="";

						string strUrlGoBack = URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
							Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROCONVENIO];
						
						ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
					}
					else
					{
						ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
					}
					break;

				case Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma:
					oCronogramaPagoConvenioBE.MontoProgramado=Utilitario.Constantes.ValorConstanteCero;
					oCronogramaPagoConvenioBE.MontoRecibido=NullableTypes.NullableDouble.Parse(this.nbMonto.Text);
					oCronogramaPagoConvenioBE.IdTablaRangoPago=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.RangoPagoConvenio);
					oCronogramaPagoConvenioBE.IdRangoPago=Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma);
					
					
					retorno = oCMantenimientos.Insertar(oCronogramaPagoConvenioBE);
					
					if (retorno==Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEAGREGARNP,
							Enumerados.NivelesErrorLog.I.ToString()));

						string strUrlGoBack = URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
						Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROCONVENIO];
						
						ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CONVENIOREGISTROEXITOSO),strUrlGoBack.ToString());
					}
					else
					{
						ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesErrorConvenioUsuario(retorno.ToString()));
					}
					break;
			}
		}

		public void Modificar()
		{
			CronogramaPagoConvenioBE oCronogramaPagoConvenioBE=new CronogramaPagoConvenioBE();
			
			oCronogramaPagoConvenioBE.IdCronogramaPagoConvenio=Convert.ToInt32(this.Page.Request.Params[KEYIDCRONOGRAMAPAGOCONVENIO]);
			oCronogramaPagoConvenioBE.Periodo=Convert.ToInt32(this.Page.Request.Params[KEYQPERIODO]);
			oCronogramaPagoConvenioBE.Mes=Convert.ToInt32(this.ddltMeses.SelectedValue);
			oCronogramaPagoConvenioBE.Observaciones=this.txtObservaciones.Text;

			CMantenimientos oCMantenimientos=new CMantenimientos();
            int retorno= Utilitario.Constantes.ValorConstanteCero; 

			Enumerados.EstadoRangoPagoConvenio oEstado=(Enumerados.EstadoRangoPagoConvenio)System.Enum.Parse(typeof(Enumerados.EstadoRangoPagoConvenio),this.Page.Request.Params[KEYIDRANGOPAGO].ToString());

			switch (oEstado)
			{
				case Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma:
					oCronogramaPagoConvenioBE.MontoProgramado=Convert.ToDouble(this.nbMonto.Text);
					if(!NullableTypes.NullableDouble.Parse(this.nbMontoCobrado.Text).IsNull)
					{
						oCronogramaPagoConvenioBE.MontoRecibido=Convert.ToDouble(this.nbMontoCobrado.Text);
					}
					oCronogramaPagoConvenioBE.IdTablaRangoPago=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.RangoPagoConvenio);
					oCronogramaPagoConvenioBE.IdRangoPago=Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma);
					break;
				case Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma:
					oCronogramaPagoConvenioBE.MontoRecibido=NullableTypes.NullableDouble.Parse(this.nbMonto.Text);
					oCronogramaPagoConvenioBE.IdTablaRangoPago=Convert.ToInt32(Utilitario.Enumerados.TablasTabla.RangoPagoConvenio);
					oCronogramaPagoConvenioBE.IdRangoPago=Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma);
					break;
			}

			retorno=oCMantenimientos.Modificar(oCronogramaPagoConvenioBE);
			
			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEMODIFICO + 
					hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				
				string strUrlGoBack = URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROCONVENIO];
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Utilitario.Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONREGISTROSELECCIONADO),strUrlGoBack.ToString());

			}

		}

		public void Eliminar()
		{}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}			
		}

		public void CargarModoNuevo()
		{
			Enumerados.EstadoRangoPagoConvenio oEstado=(Enumerados.EstadoRangoPagoConvenio)System.Enum.Parse(typeof(Enumerados.EstadoRangoPagoConvenio),this.Page.Request.Params[KEYIDRANGOPAGO].ToString());

			switch (oEstado)
			{
				case Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma:
					this.lblMontoCobrado.Visible=VALORFALSO;
					this.nbMontoCobrado.Visible=VALORFALSO;
					this.lblTituloSecundario.Text=TITULOCRONOGRAMAPAGOS;
					this.lblPagina.Text=TITULOCRONOGRAMAPAGOSMINISCULA;
					this.LlenarGrillaOrdenamiento(COLORDENAMIENTO);
					break;
				
				case Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma:
					this.lblTituloSecundario.Text=TITULOCRONOGRAMAPAGOSATRAZADOS;
					this.lblPagina.Text=TITULOCRONOGRAMAPAGOSATRAZADOSMINUSCULA;
					this.lblMontoProgramado.Text=PIEMONTO;
					this.lblMontoCobrado.Visible=VALORFALSO;
					this.nbMontoCobrado.Visible=VALORFALSO;
					break;
			}
		}

		public void CargarModoModificar()
		{

			this.nbPeriodo.Enabled=VALORFALSO;
			this.ddltMeses.Enabled=VALORFALSO;
			
			string h = Page.Request.QueryString[KEYIDCRONOGRAMAPAGOCONVENIO].ToString();
			
			this.nbPeriodo.Text=this.Page.Request.Params[KEYQPERIODO];
			
			item=this.ddltMeses.Items.FindByValue(this.Page.Request.Params[KEYQMES]);
			
			if(item!=null)
			{item.Selected = true;}

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			CronogramaPagoConvenioBE oCronogramaPagoConvenioBE = (CronogramaPagoConvenioBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDCRONOGRAMAPAGOCONVENIO].ToString()), Utilitario.Enumerados.ClasesNTAD.CronogramaPagoConvenioNTAD.ToString());


            LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJECONSULTA + Page.Request.QueryString[KEYIDCRONOGRAMAPAGOCONVENIO] + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));


			if(oCronogramaPagoConvenioBE != null)
			{
				
				this.nbMonto.Text = oCronogramaPagoConvenioBE.MontoProgramado.ToString();
				this.nbMontoCobrado.Text = oCronogramaPagoConvenioBE.MontoRecibido.ToString();
				

				if (!oCronogramaPagoConvenioBE.Observaciones.IsNull)
					txtObservaciones.Text = oCronogramaPagoConvenioBE.Observaciones.ToString();		
			}



			/*
			if(oUnidadApoyoBE!=null)
			{
				txtNombre.Text = oUnidadApoyoBE.Nombre; 
				txtSiglas.Text = oUnidadApoyoBE.Siglas;

				if (!oUnidadApoyoBE.Observaciones.IsNull)
					txtObservacion.Text = oUnidadApoyoBE.Observaciones.ToString();		
			}*/


			/*

		this.txtObservaciones.Text=this.Page.Request.Params[KEYQOBSERVACIONES];
		*/	
	
			Enumerados.EstadoRangoPagoConvenio oEstado=(Enumerados.EstadoRangoPagoConvenio)System.Enum.Parse(typeof(Enumerados.EstadoRangoPagoConvenio),this.Page.Request.Params[KEYIDRANGOPAGO].ToString());

			switch (oEstado)
			{
				case Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma:
					this.lblTituloSecundario.Text=TITULOMODIFICARCRONOGRAMAPAGOS;
					this.lblPagina.Text=TITULOMODIFICARCRONOGRAMAPAGOSMINUSCULA;
					//this.nbMonto.Text=this.Page.Request.Params[KEYQMONTOPROGRAMANDO];
					//this.nbMontoCobrado.Text=this.Page.Request.Params[KEYQMONTORECIBIDO];

					break;
				case Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma:
					this.lblTituloSecundario.Text=TITULOMODIFICARPAGOATRAZADO;
					this.lblPagina.Text=TITULOMODIFICARPAGOATRAZADOMINUSCULA;
					this.lblMontoProgramado.Text=PIEMONTO;
					//this.nbMonto.Text=this.Page.Request.Params[KEYQMONTORECIBIDO];
					this.lblMontoCobrado.Visible=VALORFALSO;
					this.nbMontoCobrado.Visible=VALORFALSO;
					break;
			}
			
		}

		public void CargarModoConsulta()
		{}

		public bool ValidarCampos()
		{
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion
		#region IPaginaBase Members
		public void LlenarGrilla()
		{}
		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{}

		public void LlenarCombos()
		{
			CMes oCMes=new CMes();
			DataTable dt=oCMes.ListarMeses();
			
			this.ddltMeses.DataSource=dt;
			this.ddltMeses.DataValueField="IdMes";
			this.ddltMeses.DataTextField="NombreMes";
			this.ddltMeses.DataBind();
		}

		public void LlenarDatos()
		{
			this.lblTitulo.Text= TITULOPRICIPAL + this.Page.Request.Params[KEYQNROCONVENIO];
		}

		public void LlenarJScript()
		{
			this.rqdvPeriodo.ErrorMessage=Utilitario.Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEDEBEINGRESARUNPERIODO);
			this.rqdvMonto.ErrorMessage=Utilitario.Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEDEBEINGRESARMONTOVALOR);
			this.rdvPeriodo.ErrorMessage=Utilitario.Helper.ObtenerMensajesErrorConvenioUsuario(Mensajes.CONVENIOMENSAJEPERIODONOVALIDO);
		}

		public void RegistrarJScript()
		{}

		public void Imprimir()
		{}

		public void Exportar()
		{}

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
		#region Constantes
		//Mensaje
		private const string MENSAJEAGREGARP="Se agrego un Pago  dentro del Cronograma";
		private const string MENSAJEAGREGARNP="Se agrego un Pago fuera del Cronograma";
		private const string MENSAJEMODIFICO="Se modificó Item de ";
		private const string MENSAJECONSULTA="Se consulto del Detalle de Programa de Pagos Cronogras de Convenios MGP";
		private const string GRILLAVACIAPAGOPROGRAMADO="No Hay Programa de Pagos Establecido";
		private const string TITULOCRONOGRAMAPAGOS="REGISTRAR CRONOGRAMA DE PAGOS";
		private const string TITULOCRONOGRAMAPAGOSATRAZADOS="REGISTRAR PAGOS ATRAZADO";
		private const string TITULOCRONOGRAMAPAGOSMINISCULA = " Registrar Cronograma de Pago";
		private const string TITULOCRONOGRAMAPAGOSATRAZADOSMINUSCULA=" Registrar Pagos Atrazados";
		private const string PIEMONTO = "Monto Cobrado S/: ";
		private const string TITULOMODIFICARCRONOGRAMAPAGOS="MODIFICAR CRONOGRAMA DE PAGO";
		private const string TITULOMODIFICARCRONOGRAMAPAGOSMINUSCULA=" Modificar Cronograma de Pago";
		private const string TITULOMODIFICARPAGOATRAZADO="MODIFICAR PAGO ATRAZADO";
		private const string TITULOMODIFICARPAGOATRAZADOMINUSCULA=" Modificar Pagos Atrazados";
		private const string TITULOPRICIPAL=" CONVENIO SIMA - MGP  ";
		
		//KEYs
		private const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		private const string KEYQNROCONVENIO="NroConvenio";
		private const string KEYIDCRONOGRAMAPAGOCONVENIO="IdCronogramaPagoConvenio";
		private const string KEYQMES="Mes";
		private const string KEYQPERIODO="Periodo";
		private const string KEYQMONTOPROGRAMANDO="MontoProgramado";
		private const string KEYQMONTORECIBIDO="MontoRecibido";
		private const string KEYQOBSERVACIONES="Observaciones";
		private const string KEYIDRANGOPAGO="IdRangoPago";
		
		
		//URL's
		private const string URLPRINCIPAL="AdministrarCronogramaPagosConvenioSimaMgp.aspx?";
				
		//Ordenamiento
		private const string COLORDENAMIENTO="Orden ASC";
		private const int COLPOSTOTAL=1;
		private const int COLPOSMONTOACUMULADO=2;

		//Otros
		private const bool VALORFALSO=false;
		#endregion Constantes
		#region Controles
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label lblTituloSecundario;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblMes;
		protected eWorld.UI.NumericBox nbPeriodo;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.Label lblMontoProgramado;
		protected System.Web.UI.WebControls.Label lblObservacionesGrid;
		protected System.Web.UI.WebControls.DropDownList ddltMeses;
		protected eWorld.UI.NumericBox nbMonto;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary DomValidationSummary1;
		protected System.Web.UI.WebControls.RangeValidator rdvPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblMontoCobrado;
		protected eWorld.UI.NumericBox nbMontoCobrado;
		protected System.Web.UI.HtmlControls.HtmlTable tblCabecera;
		protected System.Web.UI.WebControls.RequiredFieldValidator rqdvPeriodo;
		protected System.Web.UI.WebControls.RequiredFieldValidator rqdvMonto;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		#endregion
		#region Variables		
		private ListItem item =  new ListItem();
		private CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
		#endregion
		#region Eventos
		private void RegresarPaginaPrincipal()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request[KEYQNROCONVENIO]);
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA]) ;
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
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}	
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarJScript();
					this.LlenarCombos();
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


		#endregion
	}
}
