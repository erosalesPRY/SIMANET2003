using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionControlInstitucional;
using SIMA.EntidadesNegocio.GestionControlInstitucional;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionControlInstitucional
{
	/// <summary>
	/// Summary description for DetalleRecomendacion.
	/// </summary>
	public class DetalleRecomendacion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
	

	

		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblConcepto;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPersonal;
		protected System.Web.UI.WebControls.Literal ltlMensaje;


		#region Constante
			const string KEYQIDRECOMENDACION= "IdRecomendacion";
			const string KEYQPERIODO = "Periodo";
			const string KEYQIDOBSERVACION = "IdObservacion";
			const string KEYQDESCRIPCION = "Descripcion";
			const string URLDETALLE="DetalleRecomendacion.aspx?";

			protected System.Web.UI.WebControls.TextBox txtPorcAvance;
			protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlSItuacion;
		protected System.Web.UI.WebControls.Label Label4;
			protected System.Web.UI.WebControls.TextBox txtFecha;
			
		#endregion 
		#region Propiedades de pagina adiciopnal
		private int IdObservacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDOBSERVACION]);}
		}
		private string DescripcionObservacion
		{
			get{return Convert.ToString(Page.Request.Params[KEYQDESCRIPCION]);}
		}
		private int IdRecomendacion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRECOMENDACION]);}
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		#endregion


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
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
					string debug = oException.Message.ToString();
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleRecomendacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleRecomendacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleRecomendacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlSItuacion.DataSource = (new CTablaTablas()).ListaTodosCombo(546);
			this.ddlSItuacion.DataTextField="var1";
			this.ddlSItuacion.DataValueField="Codigo";
			this.ddlSItuacion.DataBind();

		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleRecomendacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleRecomendacion.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleRecomendacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleRecomendacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleRecomendacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleRecomendacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleRecomendacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			RecomendacionesBE oRecomendacionesBE = new RecomendacionesBE();
			oRecomendacionesBE.IdObservacion =this.IdObservacion;
			oRecomendacionesBE.Observacion =this.txtObservacion.Text;
			oRecomendacionesBE.PorcAvance =Convert.ToInt32(this.txtPorcAvance.Text);
			oRecomendacionesBE.Fecha =Convert.ToDateTime(this.txtFecha.Text);
			oRecomendacionesBE.IdSituacion = Convert.ToInt32(this.ddlSItuacion.SelectedValue);

			if((new CRecomendacionesPorObservacion()).Insertar(oRecomendacionesBE) >0 )
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Recomendaciones",this.ToString(),"Se registró Item de Recomendacion  OCI" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}

		}

		public void Modificar()
		{
			RecomendacionesBE oRecomendacionesBE = new RecomendacionesBE();
			oRecomendacionesBE.IdRecomendacion=this.IdRecomendacion;
			oRecomendacionesBE.Periodo=this.Periodo;
			oRecomendacionesBE.Observacion =this.txtObservacion.Text;
			oRecomendacionesBE.PorcAvance =Convert.ToInt32(this.txtPorcAvance.Text);
			oRecomendacionesBE.Fecha =Convert.ToDateTime(this.txtFecha.Text);
			oRecomendacionesBE.IdSituacion = Convert.ToInt32(this.ddlSItuacion.SelectedValue);

			if((new CRecomendacionesPorObservacion()).Modificar(oRecomendacionesBE) >0 )
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Recomendaciones",this.ToString(),"Se registró Item de Recomendacion  OCI" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));								
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleRecomendacion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			this.lblTitulo.Text = this.DescripcionObservacion;

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
					this.CargarModoModificar();
					Helper.BloquearControles(this);
					break;
			}						

		}

		public void CargarModoNuevo()
		{
		}

		public void CargarModoModificar()
		{
			RecomendacionesBE oRecomendacionesBE = (RecomendacionesBE) (new CRecomendacionesPorObservacion()).ListarDetalle(this.IdObservacion,this.IdRecomendacion ,this.Periodo);
			ListItem litem;
			litem = this.ddlSItuacion.Items.FindByValue(oRecomendacionesBE.IdSituacion.ToString());
			if(litem!=null){litem.Selected=true;}

			this.txtFecha.Text = oRecomendacionesBE.Fecha.ToShortDateString();
			this.txtObservacion.Text = oRecomendacionesBE.Observacion;
			this.txtPorcAvance.Text = oRecomendacionesBE.PorcAvance.ToString();
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleRecomendacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleRecomendacion.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleRecomendacion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleRecomendacion.ValidarExpresionesRegulares implementation
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
	}
}
