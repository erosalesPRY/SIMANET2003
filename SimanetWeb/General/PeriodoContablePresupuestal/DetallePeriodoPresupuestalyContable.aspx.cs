using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.General;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.General.PeriodoContablePresupuestal
{
	/// <summary>
	/// Summary description for DetallePeriodoPresupuestalyContable.
	/// </summary>
	public class DetallePeriodoPresupuestalyContable : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{

		//string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		string JSVERIFICARELIMINAR = "return ConfirmarCreacion();";
		const string KEYQPERIODO= "Periodo";

		protected System.Web.UI.WebControls.ImageButton imgAceptar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlPeriodoRef;
		protected eWorld.UI.NumericBox nPeriodo;
		protected System.Web.UI.WebControls.DropDownList ddlTipoInfoRef;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTipoInfo;
		protected System.Web.UI.WebControls.CheckBox chkActivo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.LlenarJScript();
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					
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
					Helper.MsgBox(oSIMAExcepcionDominio.Error);					
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
			this.imgAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.LlenarGrillaOrdenamientoPaginacion implementation
		}

		private void CargarPeriodos(){
			this.ddlPeriodoRef.DataSource =(new CPeriodo()).ListarTodosGrilla();
			this.ddlPeriodoRef.DataTextField = "Periodo";
			this.ddlPeriodoRef.DataValueField= "Periodo";
			this.ddlPeriodoRef.DataBind();
			this.ddlPeriodoRef.Items.Insert(0,new ListItem("[Selleccionar...]","0"));
		}
		private void CargarTipoInformacion(){
			this.ddlTipoInfoRef.DataSource = (new  SIMA.Controladoras.General.CTablaTablas()).ListaTodosCombo(21);
			this.ddlTipoInfoRef.DataValueField=Enumerados.ColumnasTablaTablas.Codigo.ToString();
			this.ddlTipoInfoRef.DataTextField=Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			this.ddlTipoInfoRef.DataBind();
			this.ddlTipoInfoRef.Items.Insert(0,new ListItem("[Selleccionar...]","9"));
		}

		public void LlenarCombos()
		{
			this.CargarPeriodos();
			this.CargarTipoInformacion();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.imgAceptar.Attributes.Add("onclick",JSVERIFICARELIMINAR);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PeriodoBE oPeriodoBEFind = new PeriodoBE();
			oPeriodoBEFind = (PeriodoBE)(new CPeriodo()).ListarDetalle(Convert.ToInt32( this.nPeriodo.Text));
			if(oPeriodoBEFind==null)
			{
				ListItem lItem = this.ddlPeriodoRef.Items.FindByValue(nPeriodo.Text);
				if(lItem==null)
				{
					PeriodoBE oPeriodoBE = new PeriodoBE();
					oPeriodoBE.Periodo = Convert.ToInt32(this.nPeriodo.Text);
					oPeriodoBE.NroDentroOperativo= 1;
					oPeriodoBE.pIdEstado= ((this.chkActivo.Checked==true)?1:2);
					oPeriodoBE.IdEstadoUnisys= ((oPeriodoBE.pIdEstado==1)?"ACT":"INA");

					if(Convert.ToInt32(this.ddlPeriodoRef.SelectedValue)!=0)
					{
						oPeriodoBE.PeriodoReferencia = Convert.ToInt32(this.ddlPeriodoRef.SelectedValue);
					}
					if(Convert.ToInt32(this.ddlTipoInfoRef.SelectedValue)==0)
					{
						oPeriodoBE.IdTipoInformacion = Convert.ToInt32(this.ddlTipoInfoRef.SelectedValue);
					}
					if(Convert.ToInt32((new CPeriodo()).CrearPeriodoyEsquemaPresupuestal(oPeriodoBE))>0)
					{
						LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Periodo",this.ToString(),"Se registró Item de periodo" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
						ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Utilitario.Mensajes.CODIGOMENSAJESECONFIRMACIONCARTACREDITOREGISTRO));

					}
				}
				else
				{
					Helper.MsgBox("Ud. esta intentando crear un periodo para el proceso de ppto que ya existe..");
				
				}
			}
			else
			{
				Helper.MsgBox("El Nro de periodo que se desea ingresar ya existe");
			}
		}

		public void Modificar()
		{
			if(Convert.ToInt32(this.ddlPeriodoRef.SelectedValue)!= Convert.ToInt32(nPeriodo.Text))
			{
				PeriodoBE oPeriodoBE = new PeriodoBE();
				oPeriodoBE.Periodo = Convert.ToInt32(this.nPeriodo.Text);
				oPeriodoBE.NroDentroOperativo= 1;
				oPeriodoBE.pIdEstado= ((this.chkActivo.Checked==true)?1:2);
				oPeriodoBE.IdEstadoUnisys= ((oPeriodoBE.pIdEstado==1)?"ACT":"INA");

				if(Convert.ToInt32(this.ddlPeriodoRef.SelectedValue)!=0)
				{
					oPeriodoBE.PeriodoReferencia = Convert.ToInt32(this.ddlPeriodoRef.SelectedValue);
				}
				if(Convert.ToInt32(this.ddlTipoInfoRef.SelectedValue)==0)
				{
					oPeriodoBE.IdTipoInformacion = Convert.ToInt32(this.ddlTipoInfoRef.SelectedValue);
				}
				if(Convert.ToInt32((new CPeriodo()).ModificarPeriodoyEsquemaPresupuestal(oPeriodoBE))>0)
				{
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Periodo",this.ToString(),"Se registró Item de periodo" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(), Utilitario.Mensajes.CODIGOMENSAJESECONFIRMACIONCARTACREDITOREGISTRO));

				}
			}
			else{
				Helper.MsgBox("No es posible tomar como referencia el mismo periodo de creacion");
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.Eliminar implementation
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
					this.CargarModoModificar();
					break;
			}						
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			PeriodoBE oPeriodoBE = (PeriodoBE)(new CPeriodo()).ListarDetalle(Convert.ToInt32(Page.Request.Params[KEYQPERIODO]));
			this.nPeriodo.Text = oPeriodoBE.Periodo.ToString();
			this.chkActivo.Checked = ((oPeriodoBE.pIdEstado==1)?true:false);
			ListItem lItem =  this.ddlPeriodoRef.Items.FindByValue(oPeriodoBE.PeriodoReferencia.ToString());
			if(lItem!=null){lItem.Selected=true;this.hPeriodo.Value=oPeriodoBE.PeriodoReferencia.ToString();}

			lItem =  this.ddlTipoInfoRef.Items.FindByValue(oPeriodoBE.IdTipoInformacion.ToString());
			if(lItem!=null){lItem.Selected=true;this.hTipoInfo.Value=oPeriodoBE.IdTipoInformacion.ToString();}

			this.nPeriodo.Enabled=false;

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePeriodoPresupuestalyContable.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void imgAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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
				//ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
				Helper.MsgBox(oSIMAExcepcionDominio.Error.ToString());
			}
			catch(Exception oException)
			{
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}
	}
}
