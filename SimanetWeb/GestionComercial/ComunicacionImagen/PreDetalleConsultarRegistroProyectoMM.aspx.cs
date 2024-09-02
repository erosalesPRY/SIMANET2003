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

	public class PreDetalleConsultarRegistroProyectoMM:System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlProvincia;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlRegion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllPais;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtAncho;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtAnchoRodadura;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD1;
		protected System.Web.UI.HtmlControls.HtmlTableCell TD2;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtPesoNeto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelltxtLuz;
		protected System.Web.UI.WebControls.DropDownList ddlMaterial;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlMaterial;
		protected System.Web.UI.HtmlControls.HtmlImage btnDetalle;
		protected System.Web.UI.WebControls.Label lblFechaEntrega;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFirmaAcuerdo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaInicioReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaFinReal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellcalFechaEntrega;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblDatosGenerales;
		protected System.Web.UI.WebControls.DropDownList ddlProvincia;
		protected System.Web.UI.WebControls.Label lblLugartres;
		protected System.Web.UI.WebControls.DropDownList ddlRegion;
		protected System.Web.UI.WebControls.Label lblLugardos;
		protected System.Web.UI.WebControls.DropDownList dllPais;
		protected System.Web.UI.WebControls.Label lblLugarUno;
		protected System.Web.UI.WebControls.TextBox txtLocalidad;
		protected System.Web.UI.WebControls.Label Label20;
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
		protected System.Web.UI.HtmlControls.HtmlInputFile fFoto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoProducto;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlTipoBuque;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellRadio;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCliente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefeProyecto;
		protected System.Web.UI.WebControls.Label lblTituloAspectosTecnicos;
		protected eWorld.UI.NumericBox txtLuz;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtTramos;
		protected System.Web.UI.WebControls.Label lblTramos;
		protected System.Web.UI.WebControls.Label lblMaterial;
		protected System.Web.UI.WebControls.TextBox txtVias;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.NumericBox txtAncho;
		protected System.Web.UI.WebControls.Label Label5;
		protected eWorld.UI.NumericBox txtAnchoRodadura;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtSobreCarga;
		protected System.Web.UI.WebControls.Label lblCapacidad;
		protected eWorld.UI.NumericBox txtPesoNeto;
		protected System.Web.UI.WebControls.Label Label18;
		protected eWorld.UI.CalendarPopup calFechaFirmaAcuerdo;
		protected System.Web.UI.WebControls.Label lblFirmaAcuerdo;
		protected eWorld.UI.CalendarPopup calFechaInicioReal;
		protected System.Web.UI.WebControls.Label lblInicioreal;
		protected eWorld.UI.CalendarPopup calFechaFinReal;
		protected System.Web.UI.WebControls.Label lblFinReal;
		protected eWorld.UI.CalendarPopup calFechaEntrega;

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		#endregion

		#region Constantes
		private const string KEYIDCLIENTE ="KEYIDCLIENTE";
		const int idTipoMaterial = 171;
		const int idTablabuque = 348;
		const int idTipoProducto = 223;
		const string KEYQID ="Id";
		const string MENSAJECONSULTAR="Se consulto el Predetalle de Registro Proyecto MM";
		const string URLDETALLE="DetalleConsultarRegistroProyectoMM.aspx?";
		#endregion
		
		private string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);

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

		private DataTable llenarMaterialCasco()
		{
			CTablaTablas oCTablaTablas =  new CTablaTablas();		
			return oCTablaTablas.ListaTodosCombo(idTipoMaterial);
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

			this.btnDetalle.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
			Helper.MostrarVentana("DetalleConsultarRegistroProyectoMM.aspx?",
				KEYQID + Utilitario.Constantes.SIGNOIGUAL + 
				Page.Request.QueryString[KEYQID].ToString() +
				Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +
				Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.C.ToString() +
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
		{
		}

		public void Modificar()
		{
		}

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
			// TODO:  Add DetalleConsultarRegistroProyectoMM.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.CargarModoModificar implementation

		}

		public void CargarModoConsulta()
		{
			if (Page.Request.QueryString[KEYIDCLIENTE] == Utilitario.Constantes.IDCLIENTEMARINA.ToString())
				lblFechaEntrega.Text = Utilitario.Constantes.TEXTOSETIQUETAMARINA;

			CMantenimientos oCMantenimientos = new CMantenimientos();
			ProyectosMMBE oProyectosMMBE = (ProyectosMMBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQID]),Enumerados.ClasesNTAD.ProyectosMMNTAD.ToString());
			
			if(oProyectosMMBE!=null)
			{
				

				txtNombre.Text=oProyectosMMBE.NOMBREPROYECTO.ToString();
				txtIdProyecto.Text=oProyectosMMBE.IdHistorico.ToString();
				
				if (!oProyectosMMBE.IDCLIENTE.IsNull )
				{
					hIdCliente.Value = oProyectosMMBE.IDCLIENTE.ToString();
					CCliente oCCliente = new CCliente();
					txtRazonSocial.Text=  oCCliente.ObtenerNombreCliente(Convert.ToInt32(hIdCliente.Value));
				}
				else
					txtRazonSocial.Text= Utilitario.Constantes.TEXTOSINDATA;
				
				if (!oProyectosMMBE.SUBTIPO.IsNull )
					txtSubTipo.Text=oProyectosMMBE.SUBTIPO.ToString();
				else
					txtSubTipo.Text= Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.LOCALIDAD.IsNull)
					txtLocalidad.Text=oProyectosMMBE.LOCALIDAD.ToString();
				else
					txtLocalidad.Text= Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDMATERIALES.IsNull)
					ddlMaterial.SelectedValue=oProyectosMMBE.IDMATERIALES.ToString();
				else
					CellddlMaterial.InnerText =Utilitario.Constantes.TEXTOSINDATA;
				
				#region Ubigeo			
	
				if(!oProyectosMMBE.IDUBIGEO.IsNull)
				{
					CUbigeo oCUbigeo = new CUbigeo();

					if(oProyectosMMBE.IDUBIGEO >= 700101)
					{
						HabilitarClienteExtranjero();
						rbtExtranjero.Checked = true;
						rbtPeruano.Checked = false;
					
						DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oProyectosMMBE.IDUBIGEO));

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
					
						DataRow dr = oCUbigeo.ObtenerNombreUbigeo(Convert.ToInt32(oProyectosMMBE.IDUBIGEO));

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
					CellddlProvincia.InnerText = Utilitario.Constantes.TEXTOSINDATA;
					CelldllPais.InnerText = Utilitario.Constantes.TEXTOSINDATA;
					CellddlRegion.InnerText = Utilitario.Constantes.TEXTOSINDATA;
				}
				#endregion
				
				if(rbtExtranjero.Checked)
					CellRadio.InnerText = rbtExtranjero.Text;

				if(rbtPeruano.Checked)
					CellRadio.InnerText = rbtPeruano.Text;

				if(!oProyectosMMBE.LUZ.IsNull)
					txtLuz.Text=oProyectosMMBE.LUZ.ToString();
				else
					CelltxtLuz.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.TRAMOS.IsNull)
					txtTramos.Text=oProyectosMMBE.TRAMOS.ToString();
				else
					txtTramos.Text=Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.VIAS.IsNull)
					txtVias.Text=oProyectosMMBE.VIAS.ToString();
				else
					txtVias.Text=Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.ANCHO.IsNull)
					txtAncho.Text=oProyectosMMBE.ANCHO.ToString();
				else
					CelltxtAncho.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.ANCHORODADURA.IsNull)
					txtAnchoRodadura.Text=oProyectosMMBE.ANCHORODADURA.ToString();
				else
					CelltxtAnchoRodadura.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.SOBRECARGA.IsNull)
					txtSobreCarga.Text=oProyectosMMBE.SOBRECARGA.ToString();
				else
					txtSobreCarga.Text = Utilitario.Constantes.TEXTOSINDATA;

				
				if(!oProyectosMMBE.PESONETO.IsNull)
					txtPesoNeto.Text=oProyectosMMBE.PESONETO.ToString();
				else
					CelltxtPesoNeto.InnerText=Utilitario.Constantes.TEXTOSINDATA;
				
				if(!oProyectosMMBE.IDCENTROOPERATIVO.IsNull)
					ddlCentroOperativo.SelectedValue=oProyectosMMBE.IDCENTROOPERATIVO.ToString();
				else
					CellddlCentroOperativo.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDTIPOPRODUCTO.IsNull)
					ddlTipoBuque.SelectedValue=oProyectosMMBE.IDTIPOPRODUCTO.ToString();
				else
					CellddlTipoBuque.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if(!oProyectosMMBE.IDLINEAPRODUCTO.IsNull)
					ddlTipoProducto.SelectedValue=oProyectosMMBE.IDLINEAPRODUCTO.ToString();
				else
					CellddlTipoProducto.InnerText= Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.FECHAACUERDO.IsNull)
				{
					calFechaFirmaAcuerdo.Visible= false;	
					CellcalFechaFirmaAcuerdo.InnerText = oProyectosMMBE.FECHAACUERDO.Value.ToShortDateString();
				}
				else
					CellcalFechaFirmaAcuerdo.InnerText = Utilitario.Constantes.TEXTOSINDATA;
					
				if (!oProyectosMMBE.INICIOREAL.IsNull)
				{
					calFechaInicioReal.Visible= false;					
					CellcalFechaInicioReal.InnerText = oProyectosMMBE.INICIOREAL.Value.ToShortDateString();
				}
				else
					CellcalFechaInicioReal.InnerText= Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.FINREAL.IsNull)
				{
					calFechaFinReal.Visible= false;					
					CellcalFechaFinReal.InnerText = oProyectosMMBE.FINREAL.Value.ToShortDateString();
				}
				else
					CellcalFechaFinReal.InnerText = Utilitario.Constantes.TEXTOSINDATA;

				if (!oProyectosMMBE.ENTREGA.IsNull)
				{
					calFechaEntrega.Visible= false;					
					CellcalFechaEntrega.InnerText = oProyectosMMBE.ENTREGA.Value.ToShortDateString();
				}
				else
					CellcalFechaEntrega.InnerText = Utilitario.Constantes.TEXTOSINDATA;
						
				if (!oProyectosMMBE.Imagen.IsNull )
				{
					hFoto.Value =Convert.ToString(oProyectosMMBE.Imagen);
					string RutaImagen=RutaImagenServerProyecto + oProyectosMMBE.Imagen.Value;
					imgProyecto.ImageUrl = RutaImagen;
					hFoto.Value = oProyectosMMBE.Imagen.Value;
				}
				else
				{
					imgProyecto.ImageUrl= RutaImagenServerProyecto + "sinfoto.jpg";
				}

				
				this.fFoto.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
				Helper.BloquearControles(this);
				this.btnDetalle.Visible = true;

			}
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleConsultarRegistroProyectoMM.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

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

	}
}