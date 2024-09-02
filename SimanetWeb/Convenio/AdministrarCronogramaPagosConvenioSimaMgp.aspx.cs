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
using SIMA.Controladoras.Convenio;
using SIMA.Controladoras.General;
using SIMA.Controladoras;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using NullableTypes;


namespace SIMA.SimaNetWeb.Convenio
{
	/// <summary>
	/// Aquí se administra los pagos establecidos en un cronograma, estos pueden esta dentro
	/// o fuera de las fechas establecidas, aqui solo se ve la lista de pagos dentro y 
	/// fuera, para administralos de verdad usan los botones ubicados en la parte superior
	/// del formulario
	/// Este formulario ya paso por Refactory
	/// </summary>
	public class AdministrarCronogramaPagosConvenioSimaMgp :  System.Web.UI.Page,IPaginaBase,IPaginaMantenimento 
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
			this.ibtnCronogramaPagos.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCronogramaPagos_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.dgPagoProgramado.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgPagoProgramado_SortCommand);
			this.dgPagoProgramado.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgPagoProgramado_PageIndexChanged);
			this.dgPagoProgramado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgPagoProgramado_ItemDataBound);
			this.ibtnPagoFueraPrograma.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnPagoFueraPrograma_Click);
			this.ibtnEliminarPN.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarPN_Click);
			this.dgPagoNoProgramado.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgPagoNoProgramado_SortCommand);
			this.dgPagoNoProgramado.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgPagoNoProgramado_PageIndexChanged);
			this.dgPagoNoProgramado.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgPagoNoProgramado_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		#region IPaginaMantenimento Members
		public void Agregar()
		{}

		public void Modificar()
		{}

		public void Eliminar()
		{
			if(hCodigo.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEPAGOCRONOGRAMAELIMINACION));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.CronogramaPagoConvenioTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo.Value + Utilitario.Constantes.SIMBOLOPUNTO  ,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEUNIDADAPOYOELIMINAR), URLADMINISTRARCRONOGRAMACONVENIO + KEYIDCONVENIOSIMAMGP +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYIDCONVENIOSIMAMGP]  +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYQNROCONVENIO]);
					this.LlenarGrillaOrdenamiento(Helper.ObtenerColumnaOrdenamiento());	
				}
			}
		}

		public void Eliminar_PN()
		{
			if(hCodigo2.Value.Length==Utilitario.Constantes.ValorConstanteCero)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerMensajesConfirmacionConvenioUsuario(Mensajes.CODIGOMENSAJEPAGOCRONOGRAMAELIMINACION));
			}
			else
			{
				CMantenimientos oCMantenimientos = new CMantenimientos();

				if(oCMantenimientos.Eliminar(Convert.ToInt32(hCodigo2.Value),CNetAccessControl.GetIdUser(),Enumerados.ClasesTAD.CronogramaPagoConvenioTAD.ToString())>Utilitario.Constantes.ValorConstanteCero)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.ConveniosyProyectos.ToString(),this.ToString(),MENSAJEELIMINAR + hCodigo2.Value + Utilitario.Constantes.SIMBOLOPUNTO ,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionConvenios.ToString(),Mensajes.CODIGOMENSAJEUNIDADAPOYOELIMINAR), URLADMINISTRARCRONOGRAMACONVENIO + KEYIDCONVENIOSIMAMGP +
						Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYIDCONVENIOSIMAMGP]  +
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + 
						Page.Request.QueryString[KEYQNROCONVENIO]);
					this.LlenarGrilla();
					
				}
			}
		}
		public void CargarModoPagina()
		{}

		public void CargarModoNuevo()
		{}

		public void CargarModoModificar()
		{}

		public void CargarModoConsulta()
		{}

		public bool ValidarCampos()
		{
			return false;
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
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtPagoNoProgramado=oConvenioSimaMgp.ConsultarPagosPendientesFueraDelProgramaDePagos(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));

			if(dtPagoNoProgramado!=null)
			{
				DataView dwPagoNoProgramado = dtPagoNoProgramado.DefaultView;
				dgPagoNoProgramado.DataSource = dwPagoNoProgramado;
				dgPagoNoProgramado.Columns[2].FooterText = dwPagoNoProgramado.Count.ToString();
				lblResultado2.Visible = false;
			}
			else
			{
				dgPagoNoProgramado.DataSource = dtPagoNoProgramado;
				lblResultado2.Visible = true;
				lblResultado2.Text = GRILLAVACIAPAGONOPROGRAMADO;
			}
			try
			{
				dgPagoNoProgramado.DataBind();
			}
			catch	
			{
				dgPagoNoProgramado.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				dgPagoNoProgramado.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			CConvenioSimaMgp oConvenioSimaMgp=new CConvenioSimaMgp();
			DataTable dtPagoProgramado=oConvenioSimaMgp.ConsultarPagosYCronogramaDePagosDeUnConvenio(Convert.ToInt32(Page.Request.Params[KEYIDCONVENIOSIMAMGP]));
			
			if(dtPagoProgramado!=null)
			{
				DataView dwPagoProgramado = dtPagoProgramado.DefaultView;
				dwPagoProgramado.Sort = columnaOrdenar;
				dgPagoProgramado.DataSource = dwPagoProgramado;

				dgPagoProgramado.Columns[2].FooterText = dwPagoProgramado.Count.ToString();
				lblResultado1.Visible = false;
			}
			else
			{
				dgPagoProgramado.DataSource = dtPagoProgramado;
				lblResultado1.Visible = true;
				lblResultado1.Text = GRILLAVACIAPAGOPROGRAMADO;
			}
			try
			{
				dgPagoProgramado.DataBind();
			}
			catch	
			{
				dgPagoProgramado.CurrentPageIndex = Utilitario.Constantes.POSICIONINDEXCERO;
				dgPagoProgramado.DataBind();
			}
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{}

		public void LlenarCombos()
		{}

		public void LlenarDatos()
		{
			lblTitulo.Text= TITULO +  Page.Request.Params[KEYQNROCONVENIO];
		}

		public void LlenarJScript()
		{
			ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR);
			ibtnEliminarPN.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,JSVERIFICARELIMINAR2);
			this.ibtnCronogramaPagos.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
			this.ibtnPagoFueraPrograma.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
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
		// KEYs 
		private const string URLADMINISTRARCRONOGRAMACONVENIO="AdministrarCronogramaPagosConvenioSimaMgp.aspx?";
		private const string KEYIDCONVENIOSIMAMGP="IdConvenioSimaMgp";
		private const string KEYQTITULOPRINCIPAL="TituloPrincipal";
		private const string KEYQNROCONVENIO="NroConvenio";
		private const string KEYIDCRONOGRAMAPAGOCONVENIO="IdCronogramaPagoConvenio";
		private const string KEYQMES="Mes";
		private const string KEYQPERIODO="Periodo";
		private const string KEYQMONTOPROGRAMANDO="MontoProgramado";
		private const string KEYQMONTORECIBIDO="MontoRecibido";
		private const string KEYQOBSERVACIONES="Observaciones";
		private const string KEYIDRANGOPAGO="IdRangoPago";

		//URL's
		private const string URLPRINCIPAL="AdministracionConsultarConvenioSimaMgp.aspx?";
		private const string URLREGISTRARPROGRAMAPAGOSCONVENIO="AdmRegistrarProgramaPagosConvenio.aspx?";

		//Mensajes
		private const string GRILLAVACIAPAGOPROGRAMADO="No Hay Programa de Pagos Establecido";
		private const string GRILLAVACIAPAGONOPROGRAMADO="No existen pagos efectuados fuera del programa de pagos";
		private const string TITULO="CRONOGRAMA DE PAGOS DEL CONVENIO SIMA - MGP  ";
		private const string MENSAJEELIMINAR="Se elimino el Pago de Cronograma Nro. ";

		//Ordenamiento
		private const string COLORDENAMIENTO="Orden";

		//Otros
		private const string CONTROLINK="hlkId";
		private const string CONTROLBOTON="ibtnObservaciones";

		//Posiciones en Grilla
		private const int CANTIDADSUBSTRING=4;
		private const int COLPOSTOTAL=2;
		private const int COLPOSMONTOPROGRAMADO=3;
		private const int COLPOSMONTORECIBIDO=4;
		private const int COLPOSMONTORECIBIDONO=3;
		private const int COLPOSMONTOPENDIENTE=5;

		private const int POSICIONBOTONOBSERVACIONESP=6;
		private const int POSICIONBOTONOBSERVACIONESNP=4;

		#endregion
		#region Controles
		protected projDataGridWeb.DataGridWeb dgPagoProgramado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		protected projDataGridWeb.DataGridWeb dgPagoNoProgramado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla2;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblResultado1;
		protected System.Web.UI.WebControls.Label lblSaldoConvenio;
		protected System.Web.UI.WebControls.Label lblTotalRecibido;
		protected System.Web.UI.WebControls.Label lblDbTotalRecibido;
		protected System.Web.UI.WebControls.Label lblSubtitulo2;
		protected System.Web.UI.WebControls.Label lblSubtitulo1;
		protected System.Web.UI.WebControls.Label lblDbSaldoConvenio;
		protected System.Web.UI.WebControls.ImageButton ibtnCronogramaPagos;
		protected System.Web.UI.WebControls.ImageButton ibtnPagoFueraPrograma;
		protected System.Web.UI.WebControls.Label lblResultado2;
		protected System.Web.UI.HtmlControls.HtmlForm Form2;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo2;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarPN;

		#endregion	
		#region Variables

		//Jscript
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private string JSVERIFICARELIMINAR2 = "return verificarEliminarRb('hCodigo2','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";

		//PagoProgramado
		private double acumMontoRecibido=0;
		private double acumMontoProgramado=0;
		private double acumMontoPendiente=0;


		//Pago No Programado
		private double npacumMontoRecibido=0;
		#endregion Variables
		#region Eventos
		private void dgPagoNoProgramado_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgPagoNoProgramado.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrilla();
		}

		private void dgPagoProgramado_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgPagoProgramado.CurrentPageIndex=e.NewPageIndex;
			this.LlenarGrillaOrdenamiento(Helper.ObtenerColumnaOrdenamiento());
		}

		private void dgPagoNoProgramado_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla2.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrilla();
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
					this.LlenarGrillaOrdenamiento(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO,true));
					this.LlenarGrilla();					
					this.LlenarTotalMontoLabel();					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);			
				}
				catch(SIMAExcepcion oSIMAExcepcion)
				{
					ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcion.Mensaje);				
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
		}

		private void LlenarTotalMontoLabel()
		{ 
			double TotalRecibido=Utilitario.Constantes.ValorConstanteCero;
			double TotalSaldoConvenio=Utilitario.Constantes.ValorConstanteCero;
			TotalRecibido=(acumMontoRecibido + npacumMontoRecibido);
			TotalSaldoConvenio=(acumMontoProgramado - (acumMontoRecibido + npacumMontoRecibido));
			lblDbTotalRecibido.Text = TotalRecibido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			lblDbSaldoConvenio.Text = TotalSaldoConvenio.ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}

		private void dgPagoProgramado_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamiento(this.hOrdenGrilla.Value);
		}

		private void dgPagoProgramado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				ImageButton img=(ImageButton)e.Item.Cells[POSICIONBOTONOBSERVACIONESP].FindControl(CONTROLBOTON);

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(dgPagoProgramado.CurrentPageIndex,dgPagoProgramado.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLREGISTRARPROGRAMAPAGOSCONVENIO ,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCRONOGRAMAPAGOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.IdCronogramaPagoConvenio.ToString()].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.Orden.ToString()].ToString().Substring(CANTIDADSUBSTRING)).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.Orden.ToString()].ToString().Substring(Utilitario.Constantes.ValorConstanteCero,CANTIDADSUBSTRING) + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDRANGOPAGO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma).ToString()));

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline = true;

				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString()]).IsNull)
				{
					acumMontoProgramado = acumMontoProgramado + Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoProgramado.ToString()]);
				}

				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()]).IsNull)
				{
					acumMontoRecibido = acumMontoRecibido + Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()]);
				}

				if(!NullableDouble.Parse(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()]).IsNull)
				{
					acumMontoPendiente+= Convert.ToDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoPendiente.ToString()]);
				}

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo",dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.IdCronogramaPagoConvenio.ToString()].ToString()));

				img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Helper.MostrarVentaModalTextoHTML(Utilitario.Enumerados.ColumnasProyectoConvenio.Observaciones.ToString(),Convert.ToString(dr[Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()]),500,400));

			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[COLPOSTOTAL].Text =Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[4].Text = acumMontoProgramado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = acumMontoRecibido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = acumMontoPendiente.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void dgPagoNoProgramado_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(dgPagoNoProgramado.CurrentPageIndex,dgPagoNoProgramado.PageSize,e.Item.ItemIndex);
		
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.MostrarVentana(URLREGISTRARPROGRAMAPAGOSCONVENIO ,Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.M.ToString() +
					Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDCONVENIOSIMAMGP] + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQNROCONVENIO] +  Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDCRONOGRAMAPAGOCONVENIO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.IdCronogramaPagoConvenio.ToString()].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQMES + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.Orden.ToString()].ToString().Substring(CANTIDADSUBSTRING)).ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.Orden.ToString()].ToString().Substring(Utilitario.Constantes.ValorConstanteCero,CANTIDADSUBSTRING) + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQMONTORECIBIDO + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYQOBSERVACIONES + Utilitario.Constantes.SIGNOIGUAL + dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()].ToString() + Utilitario.Constantes.SIGNOAMPERSON +
					KEYIDRANGOPAGO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma).ToString()));

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Font.Underline = true;

				npacumMontoRecibido = npacumMontoRecibido + NullableTypes.NullableIsNull.IsNullDouble(dr[Enumerados.ColumnasProgramaPagosConvenio.MontoRecibido.ToString()],0);

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto("hCodigo2",dr[Utilitario.Enumerados.ColumnasProgramaPagosConvenio.IdCronogramaPagoConvenio.ToString()].ToString()));

				//Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				ImageButton img=(ImageButton)e.Item.Cells[POSICIONBOTONOBSERVACIONESNP].FindControl(CONTROLBOTON);
				
				img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentaModalTextoHTML("OBSERVACIONES",Convert.ToString(dr[Enumerados.ColumnasProgramaPagosConvenio.Observaciones.ToString()]),500,400));


			}
			else if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[COLPOSTOTAL].Text =Utilitario.Constantes.TEXTOTOTAL;
				e.Item.Cells[COLPOSMONTORECIBIDONO].Text = npacumMontoRecibido.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void RedireccionarPaginaPrevia()
		{
			this.Page.Response.Redirect(URLPRINCIPAL + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP]);
		}

		private void ibtnCronogramaPagos_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Page.Response.Redirect(URLREGISTRARPROGRAMAPAGOSCONVENIO + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] + Utilitario.Constantes.SIGNOAMPERSON + 
				KEYIDRANGOPAGO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.DentroDelPrograma).ToString());
		}

		private void ibtnPagoFueraPrograma_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Page.Response.Redirect(URLREGISTRARPROGRAMAPAGOSCONVENIO + Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + KEYIDCONVENIOSIMAMGP + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYIDCONVENIOSIMAMGP] +
				Utilitario.Constantes.SIGNOAMPERSON + KEYQNROCONVENIO + Utilitario.Constantes.SIGNOIGUAL + this.Page.Request.Params[KEYQNROCONVENIO] + Utilitario.Constantes.SIGNOAMPERSON + 
				KEYIDRANGOPAGO + Utilitario.Constantes.SIGNOIGUAL + Convert.ToInt32(Utilitario.Enumerados.EstadoRangoPagoConvenio.FueraDelPrograma).ToString());
		}
		#endregion		

		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar();
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

		private void ibtnEliminarPN_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.Eliminar_PN();
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




	}
}
