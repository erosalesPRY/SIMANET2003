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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica.PlanEstrategico;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	public class DetalleAdministracionIndicadoresPorObjetivoEspecifico : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbPrioridad;
		protected System.Web.UI.HtmlControls.HtmlTable Table8;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList ddlbIndicador;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvIndicador;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO INDICADOR";
		const string TITULOMODOMODIFICAR = "MODIFICAR INDICADOR";
		const string TITULOMODOCONSULTAR = "CONSULTAR INDICADOR";

		//Key Session y QueryString
		const string KEYQIDOBJETIVOESPECIFICO="idObjEsp";
		//Paginas
		
		#endregion Constantes		

		#region Variables
		private ListItem item = new ListItem();
		#endregion

		private void CargarTiposIndicador()
		{
			ddlbIndicador.DataSource = (new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.TablaIndicadores));
			ddlbIndicador.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbIndicador.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbIndicador.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbIndicador.Items.Insert(0,item);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.CargarModoPagina();
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
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			this.CargarTiposIndicador();
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			rfvIndicador.ErrorMessage = "Seleccione Indicador";
			rfvIndicador.ToolTip = rfvIndicador.ErrorMessage;
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
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEIndicadorObjetivoEspecificoBE oPEIndicadorObjetivoEspecificoBE = new PEIndicadorObjetivoEspecificoBE();
			oPEIndicadorObjetivoEspecificoBE.IdObjetivoEspecifico = Convert.ToInt32(Page.Request.QueryString[KEYQIDOBJETIVOESPECIFICO]);
			oPEIndicadorObjetivoEspecificoBE.IdTablaTipoIndicador = Convert.ToInt32(Enumerados.TablasTabla.TablaIndicadores);
			oPEIndicadorObjetivoEspecificoBE.IdTipoIndicador = Convert.ToInt32(ddlbIndicador.SelectedValue);

			if (Convert.ToInt32((new CPEIndicador()).InsertarIndicadorObjetivoEspecifico(oPEIndicadorObjetivoEspecificoBE,null))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
					"Indicador",this.ToString(),"Se registró Item de Indicador" + Utilitario.Constantes.SIMBOLOPUNTO,
					Enumerados.NivelesErrorLog.I.ToString()));								
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			/*if (Convert.ToInt32((new CPEIndicador()).Modificar(oPEIndicadorObjetivoEspecificoBE,null))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
					"Indicador",this.ToString(),"Se modificó Item de Indicador" + Utilitario.Constantes.SIMBOLOPUNTO,
					Enumerados.NivelesErrorLog.I.ToString()));								

				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}*/
		}

		public void Eliminar()
		{
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
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
			this.LlenarTitulos();
		}

		public void CargarDatos()
		{
		}

		public void CargarModoModificar()
		{
		}

		public void CargarModoConsulta()
		{
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(ddlbIndicador.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvIndicador.ErrorMessage);
				return false;		
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		private void LlenarTitulos()
		{
		}

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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

	}
}
