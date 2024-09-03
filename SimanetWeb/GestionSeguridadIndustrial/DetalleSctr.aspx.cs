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
using SIMA.Controladoras.Personal;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio.General;
using SIMA.EntidadesNegocio.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
 
	public class DetalleSctr : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controles
		//Cuadros de Txto
		protected System.Web.UI.WebControls.TextBox txtRazonSocial;
		protected System.Web.UI.WebControls.TextBox txtRuc;
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.WebControls.TextBox txtAseguradora;
		protected System.Web.UI.WebControls.TextBox txtNroSctr;
		protected System.Web.UI.WebControls.TextBox txtNroPoliza;
		protected System.Web.UI.WebControls.TextBox txtNroSeguro;
		//Etiquetas
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label LblHabilitado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		//Fechas
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechVence;

		//imagenes
		protected System.Web.UI.WebControls.Image imgNuevoPRV;
		protected System.Web.UI.WebControls.Image ibtnBuscar;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		
		//Otros
		protected System.Web.UI.WebControls.HyperLink HyperLink1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvCiaSeguros;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvProveedor;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary vSum;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidAseguradora;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEntidad;
		#endregion

		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDSCTR ="idSctr";
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtRucNew;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.TextBox txtRSocialNew;
		
		const string KEYQNOMTRAB ="NomTrab";

		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdSctr
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDSCTR]);}
		}
		private string ApellidosyNombres
		{
			get{return Page.Request.Params[KEYQNOMTRAB];}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					
					this.LlenarDatos();
					this.CargarModoPagina();	
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
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
			this.txtRazonSocial.TextChanged += new System.EventHandler(this.txtRazonSocial_TextChanged);
			this.txtAseguradora.TextChanged += new System.EventHandler(this.txtAseguradora_TextChanged);
			this.txtTrabajador.TextChanged += new System.EventHandler(this.txttxtTrabajador_TextChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			AdministracionSctrBE oAdministracionSctrBE=new AdministracionSctrBE();

			//oAdministracionSctrBE.Periodo;
			//oAdministracionSctrBE.IdSctr;
			oAdministracionSctrBE.NroDni=this.hIdTrabajador.Value;
			oAdministracionSctrBE.IdTablaTipoEntidad=26;//Tablas de la Vista VMEntidad
			oAdministracionSctrBE.IdTipoEntidad=1;//proveedores
			//oAdministracionSctrBE.IdEntidad=this.txtRuc.Text;
			oAdministracionSctrBE.IdTablaCiaSeguros=454;
			oAdministracionSctrBE.IdCiaSeguros=Convert.ToInt32(this.hidAseguradora.Value);
			oAdministracionSctrBE.NroSctr=this.txtNroSctr.Text;
			oAdministracionSctrBE.NroPolizaPension=this.txtNroPoliza.Text;
			oAdministracionSctrBE.NroContratoSalud=this.txtNroSeguro.Text;
			oAdministracionSctrBE.FechaInicio=this.CalFechaInicio.SelectedDate;
			oAdministracionSctrBE.FechaTermino=this.CalFechVence.SelectedDate;
			//oAdministracionSctrBE.Habilitado;

			

			int retorno = (new CCCTT_AdministracionSctr()).Insertar(oAdministracionSctrBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró Sctr. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADENDAS));
			}
		}


		public void Modificar()
		{
            AdministracionSctrBE oAdministracionSctrBE=new AdministracionSctrBE();
			oAdministracionSctrBE.Periodo =this.Periodo;
			oAdministracionSctrBE.IdSctr=this.IdSctr;
			//oAdministracionSctrBE.NroDni=x;
			oAdministracionSctrBE.IdTablaTipoEntidad=26;//Tablas de la Vista VMEntidad
			oAdministracionSctrBE.IdTipoEntidad=1;//proveedor
			//oAdministracionSctrBE.IdEntidad=this.txtRuc.Text;
			oAdministracionSctrBE.IdTablaCiaSeguros=454;
			//oAdministracionSctrBE.IdCiaSeguros=x;
			oAdministracionSctrBE.NroSctr=this.txtNroSctr.Text;
			oAdministracionSctrBE.NroPolizaPension=this.txtNroPoliza.Text;
			oAdministracionSctrBE.NroContratoSalud=this.txtNroSeguro.Text;
			oAdministracionSctrBE.FechaInicio=this.CalFechaInicio.SelectedDate;




		}

		
		public void Eliminar()
		{
			// TODO:  Add DetalleProgramacionContratista.Eliminar implementation
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
			if(this.NroDNI!=null)
			{
				txtTrabajador.Text = this.ApellidosyNombres;
				hIdTrabajador.Value = this.NroDNI;
				//btnAgregarTrabajador.Style.Add("DISPLAY","NONE");
				txtTrabajador.ReadOnly=true;
			}
		}

		
		public void CargarModoModificar()
		{
		}

		
		public void CargarModoConsulta()
		{
			CargarModoModificar();
			Helper.BloquearControles(this);
		}

		
		public bool ValidarCampos()
		{
			bool Validado=true;
			//string Scriptmsg = "(new System.Ext.UI.WebControls.Windows()).DialogoDescripcion('VALIDACION','[MENSAJE]',400,ValidaRespuesta,'CalFechaInicio')";
			string Scriptmsg = "Ext.MessageBox.alert('VALIDACION', '[MENSAJE]', function(btn){})";

			string Mensaje="";
			if(this.hIdEntidad.Value.Length==0)
			{
				Mensaje ="Ud debe de seleccionar un proveedor de la lista de proveedores";
				Validado= false;
			}

			else if(this.hIdTrabajador.Value.Length==0)
			{
				Mensaje ="Ud debe de seleccionar un trabajador";
				Validado= false;
			}

			else if(this.hidAseguradora.Value.Length==0)
			{
				Mensaje ="Ud debe de seleccionar un Aseguradora";
				Validado= false;
			}

			if(Validado==false)
			{
				Scriptmsg = Scriptmsg.Replace("[MENSAJE]",Mensaje);
				Page.RegisterStartupScript("msgAlert","<script>" + Scriptmsg + "</script>");
			}
			return Validado;
			
		}
		
		
		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleProgramacionContratista.ValidarCamposRequeridos implementation
			return false;
		}

		
		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleProgramacionContratista.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleProgramacionContratista.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleProgramacionContratista.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleProgramacionContratista.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleProgramacionContratista.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			//this.imgFoto.ImageUrl= hPathFotos.Value+'/'+ CNetAccessControl.GetUserNroPersonal()+ ".jpg";
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleExamenMedico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleProgramacionContratista.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleProgramacionContratista.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleProgramacionContratista.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleProgramacionContratista.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleProgramacionContratista.ValidarFiltros implementation
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
				ltlMensaje.Text =Helper.MensajeAlert(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				ltlMensaje.Text =Helper.MensajeAlert(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				ltlMensaje.Text =Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void txtAseguradora_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void txtRuc_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		




	}
}

