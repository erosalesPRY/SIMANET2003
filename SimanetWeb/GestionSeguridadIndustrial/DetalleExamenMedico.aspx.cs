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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleExamenMedico.
	/// </summary>
	public class DetalleExamenMedico : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup CalFechVence;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroMedico;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtNombreCM;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.DropDownList ddlActitud;
		protected System.Web.UI.WebControls.DropDownList ddlToxicologico;
		protected System.Web.UI.HtmlControls.HtmlImage btnAgregarTrabajador;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label LblDisponible;
		protected System.Web.UI.WebControls.Label LblHabilitado;
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.WebControls.TextBox txtCentroMedico;
		protected System.Web.UI.WebControls.DropDownList ddlTipoEMO;

		const string KEYQDNI ="NroDNI";
		const string KEYQPERIODO ="Periodo";
		const string KEYQIDEXAMEN ="idExa";
		const string KEYQNOMTRAB ="NomTrab";

		private string NroDNI
		{
			get{return Page.Request.Params[KEYQDNI];}
		}
		private int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		private int IdExamen
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDEXAMEN]);}
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
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					this.CargarModoPagina();	
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
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
			ExamenMedicoBE oExamenMedicoBE = new ExamenMedicoBE();

			oExamenMedicoBE.NroDni= this.hIdTrabajador.Value;
			oExamenMedicoBE.IdCM= Convert.ToInt32(this.hIdCentroMedico.Value);
			oExamenMedicoBE.FechaInicio= this.CalFechaInicio.SelectedDate;
			oExamenMedicoBE.FechaVencimiento= this.CalFechVence.SelectedDate;
			oExamenMedicoBE.IdTipoEMO= Convert.ToInt32(this.ddlTipoEMO.SelectedValue);
			oExamenMedicoBE.IdAptitud= Convert.ToInt32(this.ddlActitud.SelectedValue);
			oExamenMedicoBE.IdToxicologico= Convert.ToInt32(this.ddlToxicologico.SelectedValue);

			int retorno = (new CCCTT_ExamenMedico()).Insertar(oExamenMedicoBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró examen medico. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADENDAS));
			}
		}

		public void Modificar()
		{
			ExamenMedicoBE oExamenMedicoBE = new ExamenMedicoBE();
			oExamenMedicoBE.Periodo= this.Periodo;
			oExamenMedicoBE.IdExamen= this.IdExamen;
			oExamenMedicoBE.NroDni= this.NroDNI;
			oExamenMedicoBE.IdCM= Convert.ToInt32(this.hIdCentroMedico.Value);
			oExamenMedicoBE.FechaInicio= this.CalFechaInicio.SelectedDate;
			oExamenMedicoBE.FechaVencimiento= this.CalFechVence.SelectedDate;
			oExamenMedicoBE.IdTipoEMO= Convert.ToInt32(this.ddlTipoEMO.SelectedValue);
			oExamenMedicoBE.IdAptitud= Convert.ToInt32(this.ddlActitud.SelectedValue);
			oExamenMedicoBE.IdToxicologico= Convert.ToInt32(this.ddlToxicologico.SelectedValue);

			oExamenMedicoBE.pIdEstado= 1;

			int retorno = (new CCCTT_ExamenMedico()).Modificar(oExamenMedicoBE);
			if(retorno>0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró examen medico. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert(
					Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString()
					,Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROADENDAS));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleExamenMedico.Eliminar implementation
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
				
			}		
		}

		public void CargarModoNuevo()
		{
			if(this.NroDNI!=null){
				txtTrabajador.Text = this.ApellidosyNombres;
				hIdTrabajador.Value = this.NroDNI;
				btnAgregarTrabajador.Style.Add("DISPLAY","NONE");
				txtTrabajador.ReadOnly=true;
			}
		}

		public void CargarModoModificar()
		{
			txtTrabajador.ReadOnly=true;
			ExamenMedicoBE oExamenMedicoBE=(ExamenMedicoBE) (new CCCTT_ExamenMedicoHistorial()).ListarDetalle(this.NroDNI,this.Periodo,this.IdExamen);
			txtTrabajador.Text = oExamenMedicoBE.ApellidosyNombres;
			txtCentroMedico.Text=oExamenMedicoBE.NombreCentroMedico;
			CalFechaInicio.SelectedDate=oExamenMedicoBE.FechaInicio;
			CalFechVence.SelectedDate=oExamenMedicoBE.FechaVencimiento;

			hIdTrabajador.Value = this.NroDNI;
			hIdCentroMedico.Value = oExamenMedicoBE.IdCM.ToString();
			ListItem item = this.ddlTipoEMO.Items.FindByValue(oExamenMedicoBE.IdTipoEMO.ToString());
			if(item!=null)item.Selected=true;

			item = this.ddlActitud.Items.FindByValue(oExamenMedicoBE.IdAptitud.ToString());
			if(item!=null)item.Selected=true;

			item = this.ddlToxicologico.Items.FindByValue(oExamenMedicoBE.IdToxicologico.ToString());
			if(item!=null)item.Selected=true;

			LblDisponible.Text=oExamenMedicoBE.NombreDisponible;
			LblHabilitado.Text=oExamenMedicoBE.NombreHabilitado;

		}


		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleExamenMedico.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			bool Validado=true;
			//string Scriptmsg = "(new System.Ext.UI.WebControls.Windows()).DialogoDescripcion('VALIDACION','[MENSAJE]',400,ValidaRespuesta,'CalFechaInicio')";
			string Scriptmsg = "Ext.MessageBox.alert('VALIDACION', '[MENSAJE]', function(btn){})";

			string Mensaje="";
			if(this.hIdTrabajador.Value.Length==0)
			{
				Mensaje="No se ha ingresado nombre de trabajor";
				Validado=false;
			}
			else if(this.hIdCentroMedico.Value.Length==0){
				Mensaje="No se ha ingresado centro medico";
				Validado=false;
			}
			else if(this.CalFechVence.SelectedDate <this.CalFechaInicio.SelectedDate)
			{
				Mensaje="La fecha de vencimiento dbe ser mayor a la fecha de incio";
				Validado=false;
			}
			else if(this.ddlTipoEMO.SelectedValue=="0")
			{
				Mensaje="No se ha seleccionado tipo de Examen EMO";
				Validado=false;
			}
			else if(this.ddlActitud.SelectedValue=="0")
			{
				Mensaje="No se ha seleccionado tipo de actitud";
				Validado=false;
			}
			else if(this.ddlToxicologico.SelectedValue=="0")
			{
				Mensaje="No se ha seleccionado tipo toxicologico";
				Validado=false;
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
			// TODO:  Add DetalleExamenMedico.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleExamenMedico.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleExamenMedico.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleExamenMedico.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleExamenMedico.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.ddlTipoEMO.DataSource=(new SIMA.Controladoras.General.CTablaTablas()).ListaItemTablas(571);
			this.ddlTipoEMO.DataTextField="Descripcion";
			this.ddlTipoEMO.DataValueField="Codigo";
			this.ddlTipoEMO.DataBind();
			this.ddlTipoEMO.Items.Insert(0,(new ListItem("Seleccionar","0")));

			this.ddlActitud.DataSource=(new SIMA.Controladoras.General.CTablaTablas()).ListaItemTablas(572);
			this.ddlActitud.DataTextField="Descripcion";
			this.ddlActitud.DataValueField="Codigo";
			this.ddlActitud.DataBind();
			this.ddlActitud.Items.Insert(0,(new ListItem("Seleccionar","0")));

			this.ddlToxicologico.DataSource=(new SIMA.Controladoras.General.CTablaTablas()).ListaItemTablas(573);
			this.ddlToxicologico.DataTextField="Descripcion";
			this.ddlToxicologico.DataValueField="Codigo";
			this.ddlToxicologico.DataBind();
			this.ddlToxicologico.Items.Insert(0,(new ListItem("Seleccionar","0")));
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleExamenMedico.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleExamenMedico.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleExamenMedico.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleExamenMedico.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleExamenMedico.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleExamenMedico.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleExamenMedico.ValidarFiltros implementation
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
	}
}
