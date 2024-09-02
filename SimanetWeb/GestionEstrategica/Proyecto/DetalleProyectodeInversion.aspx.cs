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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Controladoras.GestionEstrategica.Proyecto;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica;
using SIMA.Controladoras.Proyectos;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionEstrategica.Proyecto
{
	/// <summary>
	/// Summary description for DetalleProyectodeInversion.
	/// </summary>
	public class DetalleProyectodeInversion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento	
	{

		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtCodigoPIP;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtCodigoInterno;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.DropDownList ddlCentroOperativo;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCodigoSNIP;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.TextBox FechaInscripcion;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label15;
		protected eWorld.UI.NumericBox nAvanceFisico;
		protected System.Web.UI.WebControls.Label Label12;
		protected eWorld.UI.NumericBox nPresupuesto;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtDiagrama;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUDiagrama;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HNombreImagen;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

		const string KEYQIDTIPOPROYECTO="IdTipProy";
		const string KEYQDESCRIPTIPPROY="DescripTipProy";

		const string KEYQIDPROYECTOG="IdProyG";
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected eWorld.UI.NumericBox Numericbox1;
		protected System.Web.UI.WebControls.Label Label20;
		protected eWorld.UI.NumericBox Numericbox2;
		protected eWorld.UI.NumericBox nMontoExpTecnico;
		protected eWorld.UI.NumericBox nMontoInveTotal;
		protected System.Web.UI.WebControls.Label Label11;
		protected eWorld.UI.NumericBox nAvanceEconomico;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdObjetivoEspecifico;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.DataGrid gridOtsVals;
		protected System.Web.UI.WebControls.DropDownList ddlFuenteFinanciamiento;
		protected System.Web.UI.WebControls.DropDownList ddlEtapa;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Image imgFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathArchivo;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtComponentes;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.DropDownList ddlNivelActual;
		protected System.Web.UI.WebControls.DropDownList ddlNivelAprobacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlFuenteFinanciamiento;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlNivelActual;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlEtapa;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlNivelAprobacion;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlPeriodo;
		const string KEYQIDPROYECTOPERFIL="IdProyPerf";

		private string HTTPPathFilePIP
		{
			get{return ConfigurationSettings.AppSettings["RutaHTTPProyectoInversion"].ToString();}
		}
		private string LocalPathFilePIP
		{
			get{return ConfigurationSettings.AppSettings["RutaLocalProyectoInversion"].ToString();}
		}

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoPagina();
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleProyectodeInversion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleProyectodeInversion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleProyectodeInversion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			CargarCentroOoperativo();
			CargarEtapas();
			CargarNivelActual();
			CargarNiveldeAprobacion();
			//CargarSituacion();
			CargarPeriodo();
			CargarFuentedeFinanciamiento();
			//CargarMoneda();
		}

		public void CargarCentroOoperativo()
		{
			this.ddlCentroOperativo.DataSource = (new CCentroOperativo()).ListarTodosCombo();
			this.ddlCentroOperativo.DataTextField = "Nombre";
			this.ddlCentroOperativo.DataValueField = "IdCentroOperativo";
			this.ddlCentroOperativo.DataBind();
			this.ddlCentroOperativo.Items.RemoveAt(4);
			this.ddlCentroOperativo.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}
		public void CargarFuentedeFinanciamiento()
		{
			this.ddlFuenteFinanciamiento.DataSource = (new CProyectoInvestigacion()).ListarFuenteFinanciamientoProyectoInvestigacion();
			this.ddlFuenteFinanciamiento.DataValueField=Utilitario.Enumerados.ProyectosColumnasFuenteFinanciamiento.IdFuenteFinanciamiento.ToString();
			this.ddlFuenteFinanciamiento.DataTextField=Utilitario.Enumerados.ProyectosColumnasFuenteFinanciamiento.Nombre.ToString();
			this.ddlFuenteFinanciamiento.DataBind();
			this.ddlFuenteFinanciamiento.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
			
		}		
		
		public void CargarEtapas()
		{
			this.ddlEtapa.DataSource = (new CTablaTablas()).ListaSegunCriterioFiltro(Convert.ToInt32(Enumerados.TablasTabla.EtapaProyecto),"var3='" + Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPROYECTO]) + "'");
			this.ddlEtapa.DataTextField = "Descripcion";
			this.ddlEtapa.DataValueField = "codigo";
			this.ddlEtapa.DataBind();
			this.ddlEtapa.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}
		public void CargarNivelActual()
		{
			this.ddlNivelActual.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.NivelActual));
			this.ddlNivelActual.DataTextField = "Descripcion";
			this.ddlNivelActual.DataValueField = "codigo";
			this.ddlNivelActual.DataBind();
			this.ddlNivelActual.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}

		public void CargarNiveldeAprobacion()
		{
			this.ddlNivelAprobacion.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.NivelDeAprobacionProyecto));
			this.ddlNivelAprobacion.DataTextField = "Descripcion";
			this.ddlNivelAprobacion.DataValueField = "codigo";
			this.ddlNivelAprobacion.DataBind();
			this.ddlNivelAprobacion.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}

		/*public void CargarSituacion()
		{
			this.ddlSituacion.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.SituacionProyecto));
			this.ddlSituacion.DataTextField = "Descripcion";
			this.ddlSituacion.DataValueField = "codigo";
			this.ddlSituacion.DataBind();
			this.ddlSituacion.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}
		*/
		/*public void CargarMoneda()
		{
			this.ddlMoneda.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			this.ddlMoneda.DataTextField = "Var1";
			this.ddlMoneda.DataValueField = "codigo";
			this.ddlMoneda.DataBind();
			this.ddlMoneda.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}**/
		public void CargarPeriodo()
		{
			this.ddlPeriodo.DataSource = (new CPeriodoContable()).ListarPeriodo();
			this.ddlPeriodo.DataValueField="Periodo";
			this.ddlPeriodo.DataTextField="Periodo";
			this.ddlPeriodo.DataBind();
			this.ddlPeriodo.Items.Insert(0,new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,"0"));
		}


		public void LlenarDatos()
		{
			this.lblTitulo.Text = Page.Request.Params[KEYQDESCRIPTIPPROY].ToString();
			this.hPathArchivo.Value = this.HTTPPathFilePIP;
		}

		public void LlenarJScript()
		{
			this.ddlCentroOperativo.Attributes[Utilitario.Enumerados.EventosJavaScript.OnChange.ToString()]="ConfigurarBusqueda();";
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleProyectodeInversion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleProyectodeInversion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleProyectodeInversion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleProyectodeInversion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleProyectodeInversion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			/*ProyectoGeneralBE oProyectoGeneralBE = new ProyectoGeneralBE();
			oProyectoGeneralBE.CodigoPIP = this.txtCodigoPIP.Text;
			oProyectoGeneralBE.NombreProyecto = this.txtNombre.Text;
			oProyectoGeneralBE.IdCentroOperativo = Convert.ToInt32(this.ddlCentroOperativo.SelectedValue);
			oProyectoGeneralBE.CodigoSNIP = this.txtCodigoSNIP.Text;
			oProyectoGeneralBE.Componentes=this.txtComponentes.Text;
			if(this.txtDescripcion.Text.Length>0)
			{
				oProyectoGeneralBE.Descripcion= this.txtDescripcion.Text;
			}
			if(this.HNombreImagen.Value.Length>0)
			{
				oProyectoGeneralBE.Imagen = this.HNombreImagen.Value;
			}
			ProyectoPerfilBE oProyectoPerfilBE = new ProyectoPerfilBE();
			oProyectoPerfilBE.CodigoProyecto=this.txtCodigoInterno.Text;
			if(this.FechaInscripcion.Text.Length>0)
			{
				oProyectoPerfilBE.FechaInscripcion = Convert.ToDateTime(this.FechaInscripcion.Text);
			}
			oProyectoPerfilBE.IdEtapa = Convert.ToInt32(this.ddlEtapa.SelectedValue);
			oProyectoPerfilBE.IdFuenteFinanciamiento = Convert.ToInt32(this.ddlFuenteFinanciamiento.SelectedValue);
			oProyectoPerfilBE.IdNivelActual = Convert.ToInt32(this.ddlNivelActual.SelectedValue);
			oProyectoPerfilBE.IdNivelAprobacion = Convert.ToInt32(this.ddlNivelAprobacion.SelectedValue);
			if(this.nAvanceFisico.Text.Length>0)
			{
				oProyectoPerfilBE.AvanceFisico = Convert.ToDouble(this.nAvanceFisico.Text);
			}
			oProyectoPerfilBE.AvanceEconomico = Convert.ToDouble(this.nAvanceEconomico.Text);
			oProyectoPerfilBE.Periodo = Convert.ToInt32(this.ddlPeriodo.SelectedValue);
			oProyectoPerfilBE.MontoExpedienteTecnico = Convert.ToDouble(this.nMontoExpTecnico.Text);
			oProyectoPerfilBE.MontoInversionTotal = Convert.ToDouble(this.nMontoInveTotal);
			if(this.nPresupuesto.Text.Length>0)
			{
				oProyectoPerfilBE.MontoPresupuestoAnual = Convert.ToDouble(this.nPresupuesto.Text);
			}
			if(this.txtSituacion.Text.Length>0)
			{
				oProyectoPerfilBE.DescripcionSituacion = this.txtSituacion.Text;
			}
			if(this.txtDiagrama.Text.Length>0)
			{
				oProyectoPerfilBE.RutaArchivoDiagrama = this.txtDiagrama.Text;
			}
			oProyectoPerfilBE.IdTipoProyecto = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPROYECTO]);
			if((new CProyectoGeneral()).Insertar(oProyectoGeneralBE,oProyectoPerfilBE)!="-1")
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Carta de Credito",this.ToString(),"Se registró Item de Carta de Credito" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
			*/
		}

		public void Modificar()
		{
			ProyectoGeneralBE oProyectoGeneralBE = new ProyectoGeneralBE();
			oProyectoGeneralBE.IdProyectoG = Page.Request.Params[KEYQIDPROYECTOG].ToString();
			oProyectoGeneralBE.CodigoPIP = this.txtCodigoPIP.Text;
			oProyectoGeneralBE.NombreProyecto = this.txtNombre.Text;
			oProyectoGeneralBE.IdCentroOperativo = Convert.ToInt32(this.ddlCentroOperativo.SelectedValue);
			//oProyectoGeneralBE.IdObjetivoEspecifico = Convert.ToInt32(this.hIdObjetivoEspecifico.Value);
			oProyectoGeneralBE.CodigoSNIP = this.txtCodigoSNIP.Text;
			oProyectoGeneralBE.Componentes=this.txtComponentes.Text;
			if(this.txtDescripcion.Text.Length>0)
			{
				oProyectoGeneralBE.Descripcion= this.txtDescripcion.Text;
			}
			if(this.HNombreImagen.Value.Length>0)
			{
				oProyectoGeneralBE.Imagen = this.HNombreImagen.Value;
			}
			ProyectoPerfilBE oProyectoPerfilBE = new ProyectoPerfilBE();
			oProyectoPerfilBE.IdProyectoPerfil = Page.Request.Params[KEYQIDPROYECTOPERFIL].ToString();
			oProyectoPerfilBE.CodigoProyecto=this.txtCodigoInterno.Text;
			if(this.FechaInscripcion.Text.Length>0)
			{
				oProyectoPerfilBE.FechaInscripcion = Convert.ToDateTime(this.FechaInscripcion.Text);
			}
			oProyectoPerfilBE.IdEtapa = Convert.ToInt32(this.ddlEtapa.SelectedValue);
			oProyectoPerfilBE.IdFuenteFinanciamiento = Convert.ToInt32(this.ddlFuenteFinanciamiento.SelectedValue);
			oProyectoPerfilBE.IdNivelActual = Convert.ToInt32(this.ddlNivelActual.SelectedValue);
			oProyectoPerfilBE.IdNivelAprobacion = Convert.ToInt32(this.ddlNivelAprobacion.SelectedValue);
			if(this.nAvanceFisico.Text.Length>0)
			{
				oProyectoPerfilBE.AvanceFisico = Convert.ToDouble(this.nAvanceFisico.Text);
			}
			if(this.nAvanceEconomico.Text.Length>0)
			{
				oProyectoPerfilBE.AvanceEconomico = Convert.ToDouble(this.nAvanceEconomico.Text);
			}
			if(this.nMontoExpTecnico.Text.Length>0)
			{
				oProyectoPerfilBE.MontoExpedienteTecnico = Convert.ToDouble(this.nMontoExpTecnico.Text) ;
			}
			oProyectoPerfilBE.Periodo = Convert.ToInt32(this.ddlPeriodo.SelectedValue);
			oProyectoPerfilBE.MontoInversionTotal = Convert.ToDouble(this.nMontoInveTotal.Text); 
			if(this.nPresupuesto.Text.Length>0)
			{
				oProyectoPerfilBE.MontoPresupuestoAnual = Convert.ToDouble(this.nPresupuesto.Text);
			}
			if(this.txtSituacion.Text.Length>0)
			{
				oProyectoPerfilBE.DescripcionSituacion = this.txtSituacion.Text;
			}
			if(this.txtDiagrama.Text.Length>0)
			{
				oProyectoPerfilBE.RutaArchivoDiagrama = this.txtDiagrama.Text;
			}
			oProyectoPerfilBE.IdTipoProyecto = Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPROYECTO]);
			if((new CProyectoGeneral()).Modificar(oProyectoGeneralBE,oProyectoPerfilBE)!="-1")
			{
				//if(NullableTypes.NullableString.Parse(oProyectoGeneralBE.Imagen).IsNull!=true)
				if(this.HNombreImagen.Value.Length>0)
				{
					string NombreImg = this.HNombreImagen.Value.Split('.')[0];
					Helper.SubirArchivo(this.FUFile,this.LocalPathFilePIP,NombreImg);
					this.imgFoto.ImageUrl = this.HTTPPathFilePIP +  this.HNombreImagen.Value;
				}
				if(oProyectoPerfilBE.RutaArchivoDiagrama!=null)
				{
					string NombreFile = txtDiagrama.Text.Split('.')[0];
					Helper.SubirArchivo(this.FUDiagrama,this.LocalPathFilePIP,NombreFile);
				}
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}

		}

		public void Eliminar()
		{
			// TODO:  Add DetalleProyectodeInversion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					try
					{
						this.CargarModoModificar();
						Helper.BloquearControles(this);
					}
					catch(Exception ex)
					{
						Helper.BloquearControles(this);
					}
					break;
			}		
		}

		public void CargarModoNuevo()
		{
			CargarOTsyValorizacionesRelacionadas("0");
		}

		public void CargarModoModificar()
		{
			ProyectoPerfilBE oProyectoPerfilBE = (ProyectoPerfilBE) (new CProyectoGeneral()).ListarDetalle(Page.Request.Params[KEYQIDPROYECTOG],Convert.ToInt32(Page.Request.Params[KEYQIDTIPOPROYECTO]));
			if(oProyectoPerfilBE!=null)
			{
				txtCodigoPIP.Text = oProyectoPerfilBE.CodigoPIP;
				txtNombre.Text = oProyectoPerfilBE.NombreProyecto;
				this.txtCodigoInterno.Text =oProyectoPerfilBE.CodigoProyecto;

				ListItem lItem = ddlCentroOperativo.Items.FindByValue(oProyectoPerfilBE.IdCentroOperativo.ToString());
				if(lItem!=null){lItem.Selected=true;}
			
				/*hIdObjetivoEspecifico.Value = oProyectoPerfilBE.IdObjetivoEspecifico.ToString();
				this.txtBuscarObjetivo.Text = oProyectoPerfilBE.NombreObjetivoEspecifico;
				this.lblCodigoOEstr.Text = oProyectoPerfilBE.CodigoObjetivoEspecifico;
				*/
				txtCodigoSNIP.Text = oProyectoPerfilBE.CodigoSNIP;
				this.txtComponentes.Text = oProyectoPerfilBE.Componentes;
				if(NullableTypes.NullableDateTime.Parse(oProyectoPerfilBE.FechaInscripcion).IsNull!=false)
				{
					FechaInscripcion.Text = Convert.ToString(oProyectoPerfilBE.FechaInscripcion);
				}

				lItem = ddlEtapa.Items.FindByValue(oProyectoPerfilBE.IdEtapa.ToString());
				if(lItem!=null){lItem.Selected=true;}

				lItem = ddlFuenteFinanciamiento.Items.FindByValue(oProyectoPerfilBE.IdFuenteFinanciamiento.ToString());
				if(lItem!=null){lItem.Selected=true;}

				lItem = ddlPeriodo.Items.FindByValue(oProyectoPerfilBE.Periodo.ToString());
				if(lItem!=null){lItem.Selected=true;}

				lItem = ddlNivelActual.Items.FindByValue(oProyectoPerfilBE.IdNivelActual.ToString());
				if(lItem!=null){lItem.Selected=true;}
				
				lItem = ddlNivelAprobacion.Items.FindByValue(oProyectoPerfilBE.IdNivelAprobacion.ToString());
				if(lItem!=null){lItem.Selected=true;}

				nMontoExpTecnico.Text = oProyectoPerfilBE.MontoExpedienteTecnico.ToString();
				nMontoInveTotal.Text = oProyectoPerfilBE.MontoInversionTotal.ToString();

				nAvanceFisico.Text = oProyectoPerfilBE.AvanceFisico.ToString();
				this.nAvanceEconomico.Text=oProyectoPerfilBE.AvanceEconomico.ToString();
				nPresupuesto.Text = oProyectoPerfilBE.MontoPresupuestoAnual.ToString();

				
				if(NullableTypes.NullableDateTime.Parse(oProyectoPerfilBE.FechaInscripcion).IsNull!=true)
				{
					this.FechaInscripcion.Text = Convert.ToDateTime(oProyectoPerfilBE.FechaInscripcion).ToShortDateString();
				}

				//nInversionEstimada.Text = oProyectoPerfilBE.MontoInversionEstimadaProyectada.ToString();

				txtDescripcion.Text = oProyectoPerfilBE.Descripcion.ToString();
				txtSituacion.Text = oProyectoPerfilBE.DescripcionSituacion.ToString();
				
				if(oProyectoPerfilBE.Imagen.Length>0)
				{
					this.HNombreImagen.Value = Convert.ToString(oProyectoPerfilBE.Imagen);
					imgFoto.ImageUrl= this.HTTPPathFilePIP +this.HNombreImagen.Value;
				}
				if(oProyectoPerfilBE.RutaArchivoDiagrama.Length>0)
				{
					txtDiagrama.Text = oProyectoPerfilBE.RutaArchivoDiagrama;
				}
				CargarOTsyValorizacionesRelacionadas(oProyectoPerfilBE.CodigoProyecto);
				
			}
		}

		private void CargarOTsyValorizacionesRelacionadas(string CodigoProyectoPC){
			gridOtsVals.DataSource = (new CProyectoGeneral()).ListadodeOtsyValorizacionesporProyecto(CodigoProyectoPC);
			gridOtsVals.DataBind();
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleProyectodeInversion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.txtCodigoPIP.Text.Length==0)
			{
				Helper.MsgBox("Estudios","Ingresar codigo del proyecto",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}

			if(this.txtNombre.Text.Length==0)
			{
				Helper.MsgBox("Estudios","Ingresar nombre del proyecto",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}
			if(Convert.ToInt32(this.ddlCentroOperativo.SelectedValue)==0)
			{
				Helper.MsgBox("Estudios","Seleccionar centro de operaciones",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}
			/*if(Convert.ToInt32(this.hIdObjetivoEspecifico.Value)==0)
			{
				Helper.MsgBox("Estudios","No se ha ingresado objetivo especifico",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}*/
			if(Convert.ToInt32(this.ddlEtapa.SelectedValue)==0)
			{
				Helper.MsgBox("Estudios","Seleccionar una etapa del proyecto",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}
			if(Convert.ToInt32(this.ddlFuenteFinanciamiento.SelectedValue)==0)
			{
				Helper.MsgBox("Estudios","Seleccionar fuente de financiamiento del proyecto",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}

			/*if(Convert.ToInt32(this.ddlSituacion.SelectedValue)==0)
			{
				Helper.MsgBox("Estudios","Seleccionar situacion del proyecto",Enumerados.Ext.MessageBox.Button.OK,Enumerados.Ext.MessageBox.Icon.QUESTION);
				return false;
			}*/
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleProyectodeInversion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleProyectodeInversion.ValidarExpresionesRegulares implementation
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								//this.Agregar();
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
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());					
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				//Helper.MsgBox("PROYECTO",oException.Message,Enumerados.Ext.mESS
			}		
		}
	}
}
