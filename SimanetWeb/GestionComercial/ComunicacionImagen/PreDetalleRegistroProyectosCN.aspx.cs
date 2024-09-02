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
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionComercial;
using NetAccessControl;
using System.IO;
using NullableTypes;


namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{

	public class PreDetalleRegistroProyectosCN : System.Web.UI.Page , IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.TextBox txtTonProcesadas;
		protected System.Web.UI.WebControls.Label lblTonProcesadas;
		protected System.Web.UI.WebControls.TextBox txtVelocidad;
		protected System.Web.UI.WebControls.Label lblVelocidad;
		protected System.Web.UI.WebControls.DropDownList ddlMaterailCasco;
		protected System.Web.UI.WebControls.Label lblMaterialCasco;
		protected System.Web.UI.WebControls.TextBox txtEmpuje;
		protected System.Web.UI.WebControls.Label lblEmpuje;
		protected eWorld.UI.NumericBox txtPuntal;
		protected System.Web.UI.WebControls.Label lblPuntual;
		protected System.Web.UI.WebControls.TextBox txtCapBod;
		protected System.Web.UI.WebControls.Label lblCapBod;
		protected eWorld.UI.NumericBox txtManga;
		protected System.Web.UI.WebControls.Label lblManga;
		protected System.Web.UI.WebControls.Label lblDesplazamiento;
		protected eWorld.UI.NumericBox txtEslora;
		protected System.Web.UI.WebControls.Label lblEslora;
		protected System.Web.UI.WebControls.Label lblDWT;
		protected System.Web.UI.WebControls.Label lblAspectosTecnicos;
		protected System.Web.UI.WebControls.TextBox txtClasificacion;
		protected System.Web.UI.WebControls.Label lblClasficacion;
		protected System.Web.UI.WebControls.TextBox txtSubTipo;
		protected System.Web.UI.WebControls.Label lblSubTipo;
		protected System.Web.UI.WebControls.DropDownList ddlTipoBuque;
		protected System.Web.UI.WebControls.Label lblTipoBuque;
		protected System.Web.UI.WebControls.DropDownList ddlTipoProducto;
		protected System.Web.UI.WebControls.Label lblTipoProducto;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarDependencia;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.TextBox txtMatricula;
		protected System.Web.UI.WebControls.Label lblMatricula;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label lnlCO;
		protected System.Web.UI.WebControls.TextBox txtNroProyecto;
		protected System.Web.UI.WebControls.Label lbbNroProyecto;
		protected System.Web.UI.WebControls.TextBox txtIdProyecto;
		protected System.Web.UI.WebControls.Label lblIdProyecto;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoProducto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMaterailCasco;
		protected eWorld.UI.CalendarPopup calFechaEntrega;
		protected System.Web.UI.WebControls.Label lblTermino;
		protected System.Web.UI.WebControls.Label lblFinReal;
		protected System.Web.UI.WebControls.Label lblInicioreal;
		protected eWorld.UI.CalendarPopup calFechaFirmaAcuerdo;
		protected System.Web.UI.WebControls.Label lblFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlImage btnDetalle;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaEntrega;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD2;
		protected eWorld.UI.CalendarPopup calPuestaQuilla;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalPuestaQuilla;
		protected eWorld.UI.CalendarPopup calFechaLanzamiento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaLanzamiento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtEslora;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtManga;
		protected System.Web.UI.HtmlControls.HtmlTableCell cELLtxtPuntal;
		protected System.Web.UI.WebControls.TextBox txtDesplazamiento;
		protected System.Web.UI.WebControls.TextBox txtDWT;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtRazonSocial;
		#endregion

		#region Constantes
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		const string KEYIDREGISTROPROYECTOCN= "IdRegistroProyectoCN";
		const string MENSAJECONSULTAR= "Se ingreso a Detalle de registros Proyectos CN";
		int idTablabuque = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaBuques);
		const int idTipoProducto = 223;
		const int idTipoMaterial = 171;
		#endregion

		private string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
	
		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{

		
		}

		public void LlenarCombos()
		{
			this.ddlCentroOperativo.DataSource = this.llenarCentroOperativo();
			ddlCentroOperativo.DataValueField = Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			ddlCentroOperativo.DataTextField = Enumerados.ColumnasCentroOperativo.Sigla2.ToString();
			ddlCentroOperativo.DataBind();

			this.ddlTipoProducto.DataSource = this.llenarTipoProducto();
			ddlTipoProducto.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoProducto.DataTextField = Enumerados.ColumnasTablaTablas.Var1.ToString();
			ddlTipoProducto.DataBind();
			
			this.ddlTipoBuque.DataSource = this.llenarTipoBuque();
			ddlTipoBuque.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlTipoBuque.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlTipoBuque.DataBind();
			
			this.ddlMaterailCasco.DataSource = this.llenarMaterialCasco();
			ddlMaterailCasco.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMaterailCasco.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMaterailCasco.DataBind();
		
		}

		public void LlenarDatos()
		{
			Helper.CalendarioControlStyle(this.calFechaEntrega);
			Helper.CalendarioControlStyle(this.calFechaFirmaAcuerdo);
			Helper.CalendarioControlStyle(this.calFechaLanzamiento);
			Helper.CalendarioControlStyle(this.calPuestaQuilla);
		}

		public void LlenarJScript()
		{
			
			this.btnDetalle.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Helper.MostrarVentana("DetalleRegistroProyectos.aspx?",
				KEYIDREGISTROPROYECTOCN + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYIDREGISTROPROYECTOCN].ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[KEYIDCLIENTE].ToString()
				));

			this.btnDetalle.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
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

		#region IPaginaMantenimento Members
		public void Agregar()
		{}

		public void Modificar()
		{}

		public void Eliminar()
		{

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
		}

		public void CargarModoModificar()
		{
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroProyectoCNBE oRegistroProyectoCNBE = (RegistroProyectoCNBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOCN]),Enumerados.ClasesNTAD.RegistroProyectoCNNTAD.ToString());

			
			txtNombre.Text =	oRegistroProyectoCNBE.Nombre;
			txtIdProyecto.Text = oRegistroProyectoCNBE.IdHistorico;

			if (!oRegistroProyectoCNBE.NroProyecto.IsNull )
				txtNroProyecto.Text = Convert.ToString(oRegistroProyectoCNBE.NroProyecto);
			
			if (!oRegistroProyectoCNBE.Matricula.IsNull )
				txtMatricula.Text = Convert.ToString(oRegistroProyectoCNBE.Matricula);

			if (!oRegistroProyectoCNBE.SubTipoBuque.IsNull)
				txtSubTipo.Text  = Convert.ToString(oRegistroProyectoCNBE.SubTipoBuque);
			
			if (!oRegistroProyectoCNBE.Clasificacion.IsNull )
				txtClasificacion.Text = Convert.ToString(oRegistroProyectoCNBE.Clasificacion);
			
			if (!oRegistroProyectoCNBE.DWT.IsNull )
				txtDWT.Text = Convert.ToString(oRegistroProyectoCNBE.DWT);
			
			if (!oRegistroProyectoCNBE.Desplazamiento.IsNull)
				txtDesplazamiento.Text = Convert.ToString(oRegistroProyectoCNBE.Desplazamiento);
			
			if (!oRegistroProyectoCNBE.CapBod.IsNull )
				txtCapBod.Text = Convert.ToString(oRegistroProyectoCNBE.CapBod);
			
			if (!oRegistroProyectoCNBE.Empuje.IsNull )
				txtEmpuje.Text = Convert.ToString(oRegistroProyectoCNBE.Empuje);
			
			if (!oRegistroProyectoCNBE.TonProcesadas.IsNull )
				txtTonProcesadas.Text = Convert.ToString(oRegistroProyectoCNBE.TonProcesadas);

			if (!oRegistroProyectoCNBE.Velocidad.IsNull)
				txtVelocidad.Text=	Convert.ToString(oRegistroProyectoCNBE.Velocidad);

			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.C:
				{
					if (!oRegistroProyectoCNBE.IdTipoMaterialCasco.IsNull)
						ddlMaterailCasco.Items.FindByValue(oRegistroProyectoCNBE.IdTipoMaterialCasco.ToString()).Selected = true;
					else
						CellddlMaterailCasco.InnerText=Utilitario.Constantes.TEXTOSINDATA;
				
					if (!oRegistroProyectoCNBE.IdBuque.IsNull)
						ddlTipoBuque.Items.FindByValue(oRegistroProyectoCNBE.IdBuque.ToString()).Selected = true;
					else
						CellddlTipoBuque.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdTipoProducto.IsNull)
						ddlTipoProducto.Items.FindByValue(oRegistroProyectoCNBE.IdTipoProducto.ToString()).Selected = true;
					else
						CellddlTipoProducto.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.IdCentroOperativo.IsNull)
						ddlCentroOperativo.Items.FindByValue(oRegistroProyectoCNBE.IdCentroOperativo.ToString()).Selected = true;
					else
						CellddlCentroOperativo.InnerText=Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.FechaFirmaAcuerdo.IsNull )
						CellcalFechaFirmaAcuerdo.InnerText = oRegistroProyectoCNBE.FechaFirmaAcuerdo.Value.ToShortDateString();
					else
						CellcalFechaFirmaAcuerdo.InnerText = Utilitario.Constantes.TEXTOSINDATA;
					
					if (!oRegistroProyectoCNBE.FechaPuestaQuilla.IsNull )
						CellcalPuestaQuilla.InnerText = oRegistroProyectoCNBE.FechaPuestaQuilla.Value.ToShortDateString();
					else
						CellcalPuestaQuilla.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.FechaEntrega.IsNull )
						CellcalFechaEntrega.InnerText = oRegistroProyectoCNBE.FechaEntrega.Value.ToShortDateString();
					else
						CellcalFechaEntrega.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoCNBE.FechaLanzamiento.IsNull )
						CellcalFechaLanzamiento.InnerText = oRegistroProyectoCNBE.FechaLanzamiento.Value.ToShortDateString();
					else
						CellcalFechaLanzamiento.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						
					if (!oRegistroProyectoCNBE.Eslora.IsNull )
						txtEslora.Text= Convert.ToString(oRegistroProyectoCNBE.Eslora);
					else
						CelltxtEslora.InnerText = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Manga.IsNull)
						txtManga.Text=Convert.ToString(oRegistroProyectoCNBE.Manga);
					else
						CelltxtManga.InnerText = Utilitario.Constantes.TEXTOSINDATA;
			
					if (!oRegistroProyectoCNBE.Puntal.IsNull )
						txtPuntal.Text= Convert.ToString(oRegistroProyectoCNBE.Puntal);
					else
						cELLtxtPuntal.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					
					if (!oRegistroProyectoCNBE.IdCliente.IsNull )
					{
						hIdCliente.Value = oRegistroProyectoCNBE.IdCliente.ToString();
						CCliente oCCliente = new CCliente();
						txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));

					}
					else
						CelltxtRazonSocial.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					calFechaLanzamiento.Visible = false;
					calFechaEntrega.Visible = false;
					calPuestaQuilla.Visible = false;
					calFechaFirmaAcuerdo.Visible = false;


				}break;
				
			}



			if (!oRegistroProyectoCNBE.RutaFoto.IsNull )
			{
				hFoto.Value =Convert.ToString( oRegistroProyectoCNBE.RutaFoto);
				string RutaImagen=RutaImagenServerProyecto + oRegistroProyectoCNBE.RutaFoto.Value;
				imgProyecto.ImageUrl = RutaImagen;
				hFoto.Value = oRegistroProyectoCNBE.RutaFoto.Value;
			}
			
		}

	
	

		public void CargarModoConsulta()
		{
			if (Page.Request.QueryString[KEYIDCLIENTE] == Utilitario.Constantes.IDCLIENTEMARINA.ToString())
				lblTermino.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			CargarModoModificar();
			Helper.BloquearControles(this);
			

			this.btnDetalle.Visible= true;
            
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

			return true;
			
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region Eventos

		private DataTable llenarCentroOperativo()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			return oCCentroOperativo.ListarTodosCombo();
		}
		private DataTable llenarTipoBuque()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTablabuque);
		}
		private DataTable llenarTipoProducto()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoProducto);
		}
		private DataTable llenarMaterialCasco()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoMaterial);
		}

	
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarJScript();
					this.CargarModoPagina();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
