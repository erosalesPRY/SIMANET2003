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
using SIMA.EntidadesNegocio.Personal;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetallePersona_Contratista_Visita.
	/// </summary>
	public class DetallePersona_Contratista_Visita : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		protected System.Web.UI.WebControls.TextBox txtAPaterno;
		protected System.Web.UI.WebControls.DropDownList ddlNacionalidad;
		protected System.Web.UI.WebControls.TextBox txtAMaterno;
		protected System.Web.UI.WebControls.TextBox txtNombres;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;

		const string KEYQDNI ="NroDNI";

		public string NroDNI{
			get{return Page.Request.Params[KEYQDNI].ToString();}
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Seguridad Industrial: Registro de Personal (Contratista-Visita)", this.ToString(),"Se ingreso a la funcionalidad de  registro de Personal (Contratista-Visita)",Enumerados.NivelesErrorLog.I.ToString()));
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
			CCTT_TrabajadorBE oCCTT_TrabajadorBE = new CCTT_TrabajadorBE();
			oCCTT_TrabajadorBE.NroDNI = this.txtNroDNI.Text;
			oCCTT_TrabajadorBE.ApellidoPaterno = this.txtAPaterno.Text;
			oCCTT_TrabajadorBE.ApellidoMaterno = this.txtAMaterno.Text;
			oCCTT_TrabajadorBE.Nombres = this.txtNombres.Text;
			oCCTT_TrabajadorBE.ApellidosyNombres =oCCTT_TrabajadorBE.ApellidoPaterno + ' ' + oCCTT_TrabajadorBE.ApellidoMaterno + ' ' + oCCTT_TrabajadorBE.Nombres;

			oCCTT_TrabajadorBE.IdNacionalidad = Convert.ToInt32(this.ddlNacionalidad.SelectedValue);
			string  Resultado=(new CCCTT_Trabajador()).Insertar(oCCTT_TrabajadorBE);

			if(Resultado.Length>0)
			{
				Session["dtTrabajador"]=null;
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Trabajador",this.ToString(),"Se registró Item de trabajador" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(this.Page);
			}						
		}

		public void Modificar()
		{
			CCTT_TrabajadorBE oCCTT_TrabajadorBE = new CCTT_TrabajadorBE();
			oCCTT_TrabajadorBE.NroDNI = this.txtNroDNI.Text;
			oCCTT_TrabajadorBE.NroDNIOld= this.NroDNI;
			oCCTT_TrabajadorBE.ApellidoPaterno = this.txtAPaterno.Text;
			oCCTT_TrabajadorBE.ApellidoMaterno = this.txtAMaterno.Text;
			oCCTT_TrabajadorBE.Nombres = this.txtNombres.Text;
			oCCTT_TrabajadorBE.ApellidosyNombres =oCCTT_TrabajadorBE.ApellidoPaterno + ' ' + oCCTT_TrabajadorBE.ApellidoMaterno + ' ' + oCCTT_TrabajadorBE.Nombres;
			oCCTT_TrabajadorBE.IdEstado=1;

			oCCTT_TrabajadorBE.IdNacionalidad = Convert.ToInt32(this.ddlNacionalidad.SelectedValue);
			int  Resultado=Convert.ToInt32( (new CCCTT_Trabajador()).ModificarAll(oCCTT_TrabajadorBE));

			if(Resultado>0)
			{
				//Modificar la session
				Session["dtTrabajador"]=null;
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Trabajador",this.ToString(),"Se Modifico Item de trabajador" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(this.Page);
			}								
		}

		public void Eliminar()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.Eliminar implementation
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
			// TODO:  Add DetallePersona_Contratista_Visita.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CCTT_TrabajadorBE oCCTT_TrabajadorBE= (CCTT_TrabajadorBE)(new CCCTT_Personal_Contratista_Visita()).Detalle(this.NroDNI);
			this.txtNroDNI.Text = oCCTT_TrabajadorBE.NroDNI;
			this.txtAPaterno.Text = oCCTT_TrabajadorBE.ApellidoPaterno;
			this.txtAMaterno.Text=oCCTT_TrabajadorBE.ApellidoMaterno;
			this.txtNombres.Text=oCCTT_TrabajadorBE.Nombres;

			ListItem item = this.ddlNacionalidad.Items.FindByValue(oCCTT_TrabajadorBE.IdNacionalidad.ToString());
			if(item!=null)item.Selected=true;
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetallePersona_Contratista_Visita.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetallePersona_Contratista_Visita.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			const int IDTABLANACIONALIDAD = 458;
			this.ddlNacionalidad.DataSource = (new CTablaTablas()).ListaTodosCombo(IDTABLANACIONALIDAD);
			this.ddlNacionalidad.DataTextField = Enumerados.ColumnasTablasTablas.Var1.ToString();
			this.ddlNacionalidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			this.ddlNacionalidad.DataBind();
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetallePersona_Contratista_Visita.ValidarFiltros implementation
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
				Helper.MsgBox("ERROR",oSIMAExcepcionDominio.Error,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
		
	}
}
