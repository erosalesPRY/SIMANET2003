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
	/// <summary>
	/// Summary description for PreDetalleRegistroProyectosOtros.
	/// </summary>
	public class PreDetalleRegistroProyectosOtros : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion	
		#region Controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label2;



		protected System.Web.UI.WebControls.Label lblEspTecnica;
		protected eWorld.UI.CalendarPopup calFechaInicioContractual;
		protected System.Web.UI.WebControls.Label lblInicioContractual;
		protected System.Web.UI.WebControls.DropDownList ddlTipoDocumento;
		protected System.Web.UI.WebControls.Label lblTipoDocumento;
		protected eWorld.UI.CalendarPopup calFechaFinContractual;
		protected System.Web.UI.WebControls.Label lblFinContractual;
		protected System.Web.UI.WebControls.TextBox txtOtroDocumento;
		protected System.Web.UI.WebControls.Label lblOtroDocumento;
		protected System.Web.UI.WebControls.DropDownList ddlOtroTipoDocumento;
		protected System.Web.UI.WebControls.Label lblOtroTipoDocumento;
		protected eWorld.UI.NumericBox txtPrecioContractual;
		protected System.Web.UI.WebControls.Label lblPrecioContractual;
		protected eWorld.UI.NumericBox txtPrecioReal;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblAspectosAdministrativos;
		protected System.Web.UI.WebControls.Label lblContrato;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.WebControls.DropDownList ddlProvincia;
		protected System.Web.UI.WebControls.Label lblLugartres;
		protected System.Web.UI.WebControls.DropDownList ddlRegion;
		protected System.Web.UI.WebControls.Label lblLugardos;
		protected System.Web.UI.WebControls.DropDownList dllPais;
		protected System.Web.UI.WebControls.Label lblLugarUno;
		protected System.Web.UI.WebControls.TextBox txtLocalidad;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.RadioButton rbtExtranjero;
		protected System.Web.UI.WebControls.RadioButton rbtPeruano;
		protected System.Web.UI.WebControls.Label lblTipoCliente;
		protected System.Web.UI.WebControls.Label lblUbigeo;
		protected System.Web.UI.WebControls.TextBox txtSubTipo;
		protected System.Web.UI.WebControls.Label lblSubTipo;
		protected System.Web.UI.WebControls.DropDownList ddlTipoBuque;
		protected System.Web.UI.WebControls.Label lblTipoBuque;
		protected System.Web.UI.WebControls.DropDownList ddlTipoProducto;
		protected System.Web.UI.WebControls.Label lblTipoProducto;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarDependencia;
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.Label lblCliente;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label lnlCO;
		protected System.Web.UI.WebControls.TextBox txtIdProyecto;
		protected System.Web.UI.WebControls.Label lblIdProyecto;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.WebControls.TextBox txtTipoMaterial;
		protected System.Web.UI.WebControls.Label lblTipoMaterial;
		protected eWorld.UI.CalendarPopup calFechaEntrega;
		protected System.Web.UI.WebControls.Label lblTermino;
		protected System.Web.UI.WebControls.DropDownList ddlMaterial;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected eWorld.UI.CalendarPopup calFechaFinReal;
		protected System.Web.UI.WebControls.Label lblFinReal;
		protected System.Web.UI.WebControls.TextBox txtEspesor;
		protected System.Web.UI.WebControls.Label lblEspesor;
		protected eWorld.UI.CalendarPopup calFechaInicioReal;
		protected System.Web.UI.WebControls.Label lblInicioreal;
		protected System.Web.UI.WebControls.TextBox txtDiametro;
		protected System.Web.UI.WebControls.Label lblDiametro;
		protected eWorld.UI.CalendarPopup calFechaFirmaAcuerdo;
		protected System.Web.UI.WebControls.Label lblFirmaAcuerdo;
		protected System.Web.UI.WebControls.TextBox txtDimesion;
		protected System.Web.UI.WebControls.Label lblDimension;
		protected System.Web.UI.WebControls.TextBox txtCapacidad;
		protected System.Web.UI.WebControls.Label lblCapacidad;
		protected eWorld.UI.NumericBox txtPesoNeto;
		protected System.Web.UI.WebControls.Label lblPesoNeto;
		protected System.Web.UI.WebControls.TextBox txtTramos;
		protected System.Web.UI.WebControls.Label lblTramos;
		protected System.Web.UI.WebControls.Label lblTituloAspectosTecnicos;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefeProyecto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoProducto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellRadio;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllPais;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlRegion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlProvincia;
		protected System.Web.UI.HtmlControls.HtmlImage btnDetalle;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMaterial;
		protected System.Web.UI.HtmlControls.HtmlTableCell CeldacalFechaFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CeldacalFechaInicioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaEntrega;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPesoNeto;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion
		#region Eventos
		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void dllPais_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CUbigeo oCUbigeo = new CUbigeo();
			ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataBind();
		}

		private void ddlRegion_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CUbigeo oCUbigeo = new CUbigeo();
			ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
			ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlProvincia.DataBind();
		}



		private void btnDetalle_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLDETALLE + Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +
				Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDREGISTROPROYECTOOTROS + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS] 
				);
		}
		private void rbtPeruano_CheckedChanged(object sender, System.EventArgs e)
		{
			HabilitarClientePeruano();
			rbtExtranjero.Checked = false;
		}

		private void rbtExtranjero_CheckedChanged(object sender, System.EventArgs e)
		{
			HabilitarClienteExtranjero();
			rbtPeruano.Checked = false;
		}
		
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

		private DataTable llenarTipoDocumento()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoDocumento);
		}
		private DataTable llenarTipoMonedas()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoModena);
		}

		private DataTable llenarEstadosProyecto()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idEstadoProyecto);
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
					this.LlenarCombos();
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

		private void HabilitarClienteExtranjero()
		{
			CUbigeo oCUbigeo = new CUbigeo();
			dllPais.DataSource = oCUbigeo.LlenarContinentes();
			dllPais.DataTextField = Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataValueField =Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataBind();

			ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataBind();

			ddlRegion.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlRegion.DataBind();

			lblLugarUno.Text = "Continente:";
			lblLugardos.Text = "Pais:";
			lblLugartres.Text = "Ciudad:";
		}

		private void HabilitarClientePeruano()
		{
			CUbigeo oCUbigeo = new CUbigeo();
			dllPais.DataSource = oCUbigeo.ListaDepartamentosNacional();
			dllPais.DataTextField = Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataValueField =Enumerados.ColumnasUbigeo.NombreDepartamento.ToString();
			dllPais.DataBind();

			ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
			ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
			ddlRegion.DataBind();

			ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
			ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
			ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
			ddlProvincia.DataBind();

			lblLugarUno.Text = "Region:";
			lblLugardos.Text = "Provincia:";
			lblLugartres.Text = "Distrito:";		
		}
		

		#endregion
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
			
			this.ddlMaterial.DataSource = this.llenarMaterialCasco();
			ddlMaterial.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMaterial.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMaterial.DataBind();
		
		}

		public void LlenarDatos()
		{
			Helper.CalendarioControlStyle(this.calFechaEntrega);
			Helper.CalendarioControlStyle(this.calFechaFinReal);
			Helper.CalendarioControlStyle(this.calFechaFirmaAcuerdo);
			Helper.CalendarioControlStyle(this.calFechaInicioReal);
		}

		public void LlenarJScript()
		{
			this.btnDetalle.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);

			this.btnDetalle.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
				Helper.MostrarVentana("DetalleRegistroProyectosOtros.aspx?",
				KEYIDREGISTROPROYECTOOTROS + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS].ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString()+
				Utilitario.Constantes.SIGNOAMPERSON +
				KEYIDCLIENTE + Utilitario.Constantes.SIGNOIGUAL +
				Page.Request.QueryString[KEYIDCLIENTE]
				));
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
		{	}

		public void Modificar()
		{	}

		public void Eliminar()
		{	}

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
			if(Page.Request.QueryString[KEYIDCLIENTE] == Utilitario.Constantes.IDCLIENTEMARINA.ToString())
				lblTermino.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			RegistroProyectoOtrosBE oRegistroProyectoOtrosBE = (RegistroProyectoOtrosBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDREGISTROPROYECTOOTROS]),Enumerados.ClasesNTAD.RegistroProyectoOtrosNTAD.ToString());

			txtNombre.Text =	oRegistroProyectoOtrosBE.Nombre;
			
			if (!oRegistroProyectoOtrosBE.IdProyecto.IsNull )
				txtIdProyecto.Text = oRegistroProyectoOtrosBE.IdProyecto.ToString();
			
			
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.C:
				{
					if (!oRegistroProyectoOtrosBE.IdCentroOperativo.IsNull )
						ddlCentroOperativo.SelectedValue = oRegistroProyectoOtrosBE.IdCentroOperativo.ToString();
					else
						CellddlCentroOperativo.InnerText = Utilitario.Constantes.TEXTOSINDATA;
					
					if (!oRegistroProyectoOtrosBE.IdTipoProducto.IsNull )
						ddlTipoProducto.SelectedValue = oRegistroProyectoOtrosBE.IdTipoProducto.ToString();
					else
						CellddlTipoProducto.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.IdBuque.IsNull )
						ddlTipoBuque.SelectedValue = oRegistroProyectoOtrosBE.IdBuque.ToString();
					else
						CellddlTipoBuque.InnerText = Utilitario.Constantes.TEXTOSINDATA;


					if (!oRegistroProyectoOtrosBE.IdMaterial.IsNull )
						ddlMaterial.SelectedValue = oRegistroProyectoOtrosBE.IdMaterial.ToString();
					else
						CellddlMaterial.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaAcuerdo.IsNull )
					{
						calFechaFirmaAcuerdo.Visible= false;
						CeldacalFechaFirmaAcuerdo.InnerText = oRegistroProyectoOtrosBE.FechaAcuerdo.Value.ToShortDateString();
					}
					else
						CeldacalFechaFirmaAcuerdo.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.PesoNeto.IsNull )
						txtPesoNeto.Text = oRegistroProyectoOtrosBE.PesoNeto.ToString();
					else
						CelltxtPesoNeto.InnerText = Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaInicioReal.IsNull )
					{
						calFechaInicioReal.Visible= false;
						CeldacalFechaInicioReal.InnerText = oRegistroProyectoOtrosBE.FechaInicioReal.Value.ToShortDateString();
					}
					else
						CeldacalFechaInicioReal.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaFinReal.IsNull )
					{
						calFechaFinReal.Visible= false;
						CellcalFechaFinReal.InnerText = oRegistroProyectoOtrosBE.FechaFinReal.Value.ToShortDateString();
					}
					else
						CellcalFechaFinReal.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if (!oRegistroProyectoOtrosBE.FechaEntrega.IsNull )
					{
						calFechaEntrega.Visible= false;
						CellcalFechaEntrega.InnerText = oRegistroProyectoOtrosBE.FechaEntrega.Value.ToShortDateString();
					}
					else
						CellcalFechaEntrega.InnerText =  Utilitario.Constantes.TEXTOSINDATA;

					if(!oRegistroProyectoOtrosBE.IdUbigeo.IsNull)
					{
						CUbigeo oCUbigeo = new CUbigeo();

						if(oRegistroProyectoOtrosBE.IdUbigeo >= 700101)
						{
							HabilitarClienteExtranjero();
							rbtExtranjero.Checked = true;
							rbtPeruano.Checked = false;
					
							DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oRegistroProyectoOtrosBE.IdUbigeo));

							dllPais.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreDepartamento.ToString()].ToString();
					
							ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
							ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
							ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
							ddlRegion.DataBind();

							ddlRegion.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreProvincia.ToString()].ToString();

							ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
							ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
							ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
							ddlProvincia.DataBind();

							ddlProvincia.SelectedValue = dr[Enumerados.ColumnasUbigeo.IdUbigeo.ToString()].ToString();
						}
						else
						{
				
							HabilitarClientePeruano();
							rbtExtranjero.Checked = false;
							rbtPeruano.Checked = true;
					
							DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oRegistroProyectoOtrosBE.IdUbigeo));

							dllPais.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreDepartamento.ToString()].ToString();
					
							ddlRegion.DataSource = oCUbigeo.LlenarProvincia(dllPais.SelectedValue.ToString());
							ddlRegion.DataTextField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
							ddlRegion.DataValueField = Enumerados.ColumnasUbigeo.NombreProvincia.ToString();
							ddlRegion.DataBind();

							ddlRegion.SelectedValue = dr[Enumerados.ColumnasUbigeo.NombreProvincia.ToString()].ToString();

							ddlProvincia.DataSource = oCUbigeo.LlenarDistrito(ddlRegion.SelectedValue.ToString());
							ddlProvincia.DataTextField = Enumerados.ColumnasUbigeo.NombreDistrito.ToString();
							ddlProvincia.DataValueField = Enumerados.ColumnasUbigeo.IdUbigeo.ToString();
							ddlProvincia.DataBind();

							ddlProvincia.SelectedValue = dr[Enumerados.ColumnasUbigeo.IdUbigeo.ToString()].ToString();				
						}
					}
					else
					{
						CelldllPais.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						CellddlRegion.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						CellddlProvincia.InnerText = Utilitario.Constantes.TEXTOSINDATA;
					}

				}break;
			}

			if (!oRegistroProyectoOtrosBE.IdCliente.IsNull )
			{
				hIdCliente.Value = oRegistroProyectoOtrosBE.IdCliente.ToString();
				CCliente oCCliente = new CCliente();
				txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
			}
			else
				txtRazonSocial.Text =  Utilitario.Constantes.TEXTOSINDATA;

			if (!oRegistroProyectoOtrosBE.SubTipo.IsNull )
				txtSubTipo.Text = oRegistroProyectoOtrosBE.SubTipo.ToString();
			else
				txtSubTipo.Text =  Utilitario.Constantes.TEXTOSINDATA;

			
			if(rbtExtranjero.Checked)
				CellRadio.InnerText = rbtExtranjero.Text;

			if(rbtPeruano.Checked)
				CellRadio.InnerText = rbtPeruano.Text;

			if (!oRegistroProyectoOtrosBE.Localidad.IsNull )
				txtLocalidad.Text = oRegistroProyectoOtrosBE.Localidad.ToString();

			if (!oRegistroProyectoOtrosBE.Tramos.IsNull )
				txtTramos.Text = oRegistroProyectoOtrosBE.Tramos.ToString();

			if (!oRegistroProyectoOtrosBE.Capacidad.IsNull )
				txtCapacidad.Text = oRegistroProyectoOtrosBE.Capacidad.ToString();

			if (!oRegistroProyectoOtrosBE.Dimension.IsNull )
				txtDimesion.Text = oRegistroProyectoOtrosBE.Dimension.ToString();

			if (!oRegistroProyectoOtrosBE.Diametro.IsNull )
				txtDiametro.Text = oRegistroProyectoOtrosBE.Diametro.ToString();

			if (!oRegistroProyectoOtrosBE.Espesor.IsNull )
				txtEspesor.Text = oRegistroProyectoOtrosBE.Espesor.ToString();

			if (!oRegistroProyectoOtrosBE.TipoMaterial.IsNull )
				txtTipoMaterial.Text = oRegistroProyectoOtrosBE.TipoMaterial.ToString();


			if (!oRegistroProyectoOtrosBE.RutaImagen.IsNull )
			{
				hFoto.Value =Convert.ToString( oRegistroProyectoOtrosBE.RutaImagen);
				string RutaImagen=RutaImagenServerProyecto + oRegistroProyectoOtrosBE.RutaImagen.Value;
				imgProyecto.ImageUrl = RutaImagen;
				hFoto.Value = oRegistroProyectoOtrosBE.RutaImagen.Value;
			}
		}


		public void CargarModoConsulta()
		{
			
			this.CargarModoModificar();

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
		#region Constantes
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";

		int idTablabuque = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaBuques);
		int idTipoProducto = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TipoProducto);
		int idTipoMaterial = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TiposMaterial);
		int idTipoDocumento = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaTipoDocumentos);
		int idEstadoProyecto = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.ProyectosEstadoProyectoSegunGrupoProyecto);
		int idTipoModena= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.Moneda);

		//URL
		const string URLDETALLE="DetalleRegistroProyectosOtros.aspx?";

		//Mensajes
		const string MENSAJECONSULTAR= "Se ingreso al Pre Detalle de registros proyectos otros";
			
		//key
		const string KEYIDREGISTROPROYECTOOTROS="IDREGISTROPROYECTOOTROS";
		
		//Otros
		string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		
		#endregion

	}
}


