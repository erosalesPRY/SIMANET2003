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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for ControldeCierreEstadosFinancieros.
	/// </summary>
	public class ControldeCierreEstadosFinancieros : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Variables		
		int idFila=0;
		#endregion
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDRUBRO = "IdRubro";
		const string CONTROLINK = "hlkConcepto";
		const string COLMONTOMES = "lbldelMes";
		const string COLMONTOACUM = "lblalMes";

		const string CONTROLIMAGE = "imgBtnDetalle";
		
		const string GRILLAVACIA="No exiets";
		const string OBJPARAMETROCONTABLE="ParametroContable";

		//Paginas
		const string URLDETALLE1 = "AdministrarFormulaFinanciera.aspx?";			
		const string URLDETALLE = "DetalleReporteFormulaContable.aspx?";
		const string URLGLOSA = "GlosaEstadosFinancieros.aspx?";
		const string URLCONTROLPARAMETRO ="../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx";
	
		const string  KEYQNRODIGITOSCABECERA ="NroDigCab";
		const string KEYDIGCUENTACONTABLE = "Cuenta";
		const string KEYIDEMPRESA ="idEmp";
		const string KEYIDACUMULADO ="Acumulado";
		const string KEYQIDNOMBREFORMATO = "NFormato";		

		//Controles
		const string CTRLCHKESTADO ="chkEstado";

		//Columnas Grilla
		const string COLUMNAIDESTADO ="idEstado";
		const string COLUMNAMODO ="Modo";
		const string COLUMNAIDMES ="idMes";
		
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Panel Panel;
		protected System.Web.UI.WebControls.Button btnConsultar;
		protected System.Web.UI.WebControls.ImageButton imgbtnGrabar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.HtmlControls.HtmlTable TblTabs;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.CargarControl();
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarGrilla();
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
				string debug = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
		private void CargarControl()
		{

			if (Session[OBJPARAMETROCONTABLE]==null)
			{
				ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)LoadControl(URLCONTROLPARAMETRO);
				//usc_ParametroContable.IdEmpresa = Convert.ToInt32(Page.Request.Params[KEYIDEMPRESA]);
				usc_ParametroContable.VerCentroOperativo = true;
				usc_ParametroContable.VerPeriodo = true;
				usc_ParametroContable.VerMes = false;
				usc_ParametroContable.VerTipoInformacion = true;
				usc_ParametroContable.VerEntidadFinanciera=false;
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETROCONTABLE] = usc_ParametroContable;
			}
			else
			{
				ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];
				usc_ParametroContable.EnabledCentroOperativo=true;
				usc_ParametroContable.EnabledPeriodo=true;
				usc_ParametroContable.EnabledMes =false;
				usc_ParametroContable.EnabledTipoInformacion=true;
				Panel.Controls.Clear();
				Panel.Controls.Add(usc_ParametroContable);
				Session[OBJPARAMETROCONTABLE] = usc_ParametroContable;
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
			this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
			this.imgbtnGrabar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnGrabar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];
			DataTable dtEstadoFinanciero = ((CControlCierreEstadoFinanciero) new  CControlCierreEstadoFinanciero()).AdministrarDetalleControlCierreEstadoFinanciero(Convert.ToInt32(usc_ParametroContable.IdCentroOperativo),
																																									Convert.ToInt32(usc_ParametroContable.IdTipoInformacion),
																																									Convert.ToInt32(usc_ParametroContable.Periodo),
																																									0);
			if(dtEstadoFinanciero!=null)
			{
				grid.DataSource = dtEstadoFinanciero;
			}
			else
			{
				grid.DataSource = dtEstadoFinanciero;
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.imgbtnGrabar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"return ConfirmaGrabar();");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}		
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			
		}
		public void Agregar(string []strRegistro)
		{
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];

			ControlCierreEstadoFinancieroBE oControlCierreEstadoFinancieroBE = new ControlCierreEstadoFinancieroBE();
			oControlCierreEstadoFinancieroBE.IdCentroOperativo = usc_ParametroContable.IdCentroOperativo;
			oControlCierreEstadoFinancieroBE.IdTablaTipoInformacion = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipoInformacion);
			oControlCierreEstadoFinancieroBE.IdTipoInformacion = usc_ParametroContable.IdTipoInformacion;
			oControlCierreEstadoFinancieroBE.Periodo = usc_ParametroContable.Periodo;
			oControlCierreEstadoFinancieroBE.IdMes = Convert.ToInt32(strRegistro[1]);
			oControlCierreEstadoFinancieroBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoControlCierreEstadosFinancieros);
			oControlCierreEstadoFinancieroBE.IdEstado = ((strRegistro[2].ToString().ToUpper()=="TRUE")? Utilitario.Constantes.ValorConstanteUno:Utilitario.Constantes.ValorConstanteCero);
			oControlCierreEstadoFinancieroBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			((CControlCierreEstadoFinanciero) new CControlCierreEstadoFinanciero()).Insertar(oControlCierreEstadoFinancieroBE);

		}
		public void Modificar(string []strRegistro)
		{
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE];

			ControlCierreEstadoFinancieroBE oControlCierreEstadoFinancieroBE = new ControlCierreEstadoFinancieroBE();
			oControlCierreEstadoFinancieroBE.IdCentroOperativo = usc_ParametroContable.IdCentroOperativo;
			oControlCierreEstadoFinancieroBE.IdTablaTipoInformacion = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipoInformacion);
			oControlCierreEstadoFinancieroBE.IdTipoInformacion = usc_ParametroContable.IdTipoInformacion;
			oControlCierreEstadoFinancieroBE.Periodo = usc_ParametroContable.Periodo;
			oControlCierreEstadoFinancieroBE.IdMes = Convert.ToInt32(strRegistro[1]);
			oControlCierreEstadoFinancieroBE.IdTablaEstado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoControlCierreEstadosFinancieros);
			oControlCierreEstadoFinancieroBE.IdEstado = ((strRegistro[2].ToString().ToUpper()=="TRUE")? Utilitario.Constantes.ValorConstanteUno:Utilitario.Constantes.ValorConstanteCero);
			oControlCierreEstadoFinancieroBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();
			((CControlCierreEstadoFinanciero) new CControlCierreEstadoFinanciero()).Modificar(oControlCierreEstadoFinancieroBE);
		}

		public void Modificar()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ControldeCierreEstadosFinancieros.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				((CheckBox) e.Item.Cells[1].FindControl(CTRLCHKESTADO)).Checked = ((Convert.ToInt32(dr[COLUMNAIDESTADO])==0)?false:true);
				((CheckBox) e.Item.Cells[1].FindControl(CTRLCHKESTADO)).Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"EstablecerEstado(this.checked," + idFila.ToString() + ")");
				
				e.Item.Attributes.Add("ESTADO",((CheckBox) e.Item.Cells[1].FindControl(CTRLCHKESTADO)).Checked.ToString());
				e.Item.Attributes.Add("MODO",dr[COLUMNAMODO].ToString());
				e.Item.Attributes.Add("IDMES",dr[COLUMNAIDMES].ToString());

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
			idFila++;
		}

		private void btnConsultar_Click(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

		private void imgbtnGrabar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (this.hModo.Value.ToString().Length>0)
			{
				string strTrama = this.hModo.Value.ToString();
				string []arrData = strTrama.Split('@');
				
					for(int i=0;i<= arrData.Length-2;i++)
					{
						string []arrRegistro = arrData[i].Split(';');
						if (arrRegistro[0].ToString()==Utilitario.Enumerados.ModoPagina.N.ToString())
						{
							this.Agregar(arrRegistro);
						}
						else
						{
							this.Modificar(arrRegistro);
						}
					}
			}
			this.LlenarGrilla();
		}
	}
}
