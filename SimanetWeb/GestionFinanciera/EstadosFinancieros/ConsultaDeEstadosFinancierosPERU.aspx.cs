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
	/// Summary description for ConsultaDeEstadosFinancierosPERU.
	/// </summary>
	public class ConsultaDeEstadosFinancierosPERU : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton imgbtnGrabar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTramaData;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hvalida;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdRubro;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles
		

		#region Constantes
		//Key Session y QueryString
		const string KEYQIDNOMBREFORMATO = "NFormato";
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDCENTRO = "IdCentro";
		const string KEYQIDRUBRO = "IdRubro";
		const string KEYQRUBRONOMBRE= "RubroNombre";
		const string KEYQIDTIPOINFO= "idTipoInfo";
		const string KEYQPERIODO = "Periodo";
		const string KEYQMES = "idMes";
		
		const string CONTROLINK = "hlkConcepto";
		const string COLMONTOMES = "lbldelMes";
		const string COLMONTOACUM = "lblalMes";

		const string CONTROLIMAGE = "imgBtnDetalle";
		
		const string GRILLAVACIA="No exiets";
		const string OBJPARAMETROCONTABLE="ParametroContable";
			
		const string  KEYQNRODIGITOSCABECERA ="NroDigCab";
		const string KEYDIGCUENTACONTABLE = "Cuenta";
		const string KEYIDEMPRESA ="idEmp";
		const string KEYIDACUMULADO ="Acumulado";
		const string URLGLOSA = "GlosaEstadosFinancieros.aspx?";
			
		const string CTRLMONTO1 = "nMonto";
			

		//Variables de Session
		const string VARIABLESESSIONCIERRE ="Cierre";

		//Paginas		
		const string URLDETALLE = "DetalleReporteFormulaContable.aspx?";
		const string URLDETALLE1 = "AdministrarFormulaFinanciera.aspx?";			
		const string URLDETALLE2 = "AdministarFormatoRubroDetalleMovimientoporMes.aspx?";
		const string URLDETALLENOTARUBRO = "../../Editor/Editor.aspx?";
		const string URLCONTROLUSUARIOPARAMETROCONTABLE = "../../ControlesUsuario/GestionFinanciera/ParametroContable.ascx";
		
		//Otros
		const string ETIQUETAESTADOSFINANCIEROS =" Estados Financieros > ";

		//Columnas Grilla
		const string COLUMNACONCEPTO ="Concepto";
		const string COLUMNAMONTOMES ="montoMes";
		const string COLUMNAOBSERVACION ="Observacion";

		//Controles
		const string CONTROLIMGFORMULA ="imgFormula";
		const string CONTROLIMGBTNDESCRIPCION ="imgBtnDescripcion";
		#endregion Constantes

		#region Variables
		string stridFila ="";
		int idFila=1;
		int idCentroOperativoDescripcion;
		#endregion Variables

	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.imgbtnGrabar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnGrabar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];
			int periodo=0;
			if (usc_ParametroContable.CantidadPeriodo>0)
			{periodo = Convert.ToInt32(usc_ParametroContable.Periodo);}
			else
			{periodo = DateTime.Now.Year;}

			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			DataTable dtEstadoFinanciero = oCEstadosFinancieros.ConsultarEstadosFinancierosPorCentro(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO]),
																										Convert.ToInt32(Page.Request.QueryString[KEYQIDREPORTE]),
																										idCentroOperativoDescripcion,
																										periodo,
																										Convert.ToInt32(usc_ParametroContable.Mes),
																										Convert.ToInt32(usc_ParametroContable.IdTipoInformacion));
			
			Session[VARIABLESESSIONCIERRE]=((ControlCierreEstadoFinancieroBE) ((CControlCierreEstadoFinanciero) new CControlCierreEstadoFinanciero()).DetalleControlCierreEstadoFinanciero(idCentroOperativoDescripcion,
																																															Convert.ToInt32(usc_ParametroContable.IdTipoInformacion),
																																															Convert.ToInt32(usc_ParametroContable.Periodo),
																																															Convert.ToInt32(usc_ParametroContable.Mes))).IdEstado;
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
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPagina.Text =ETIQUETAESTADOSFINANCIEROS + "Administrar Especificaciones de SIMA PERU";
			idCentroOperativoDescripcion = (Convert.ToInt32(Page.Request.Params[KEYIDEMPRESA].ToString()) ==1)? Utilitario.Constantes.KEYIDCENTROPERU:Utilitario.Constantes.KEYIDCENTROIQUITOS;
		}

		public void LlenarJScript()
		{
			imgbtnGrabar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + "return ObtenerDataModificada()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.Exportar implementation
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
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.ValidarFiltros implementation
			return false;
		}

		#endregion


		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable =(ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + Page.Request.Params[KEYIDEMPRESA].ToString()];

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;				

				e.Item.Attributes.Add("PRIORIDAD",dr[Enumerados.ColumnasFormato.idPrioridad.ToString()].ToString());
				string strFormula = dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString();
				for(int i=0;i<= strFormula.Length-1;i++)
				{
					if (strFormula.Substring(i,1)==Utilitario.Constantes.SIGNOMAS || strFormula.Substring(i,1)==Utilitario.Constantes.SIGNOMENOS)
					{
						strFormula =strFormula.Substring((i+1),strFormula.Length-(i+1));
						break;
					}
				}
				
				e.Item.Attributes.Add("FORMULA",strFormula + Utilitario.Constantes.SIGNOARROBA);
				e.Item.Attributes.Add("MODO",dr[Enumerados.ColumnasFormato.Modo.ToString()].ToString());
				e.Item.Attributes.Add("IDRUBRO",dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				

				if (dr[Enumerados.ColumnasFormato.FormulaFormato.ToString()].ToString().Length>0)
				{stridFila += idFila.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA;}
				grid.Attributes.Add("FILAFORMULA",stridFila);
				#region Query string
				System.Text.StringBuilder QryStringBase =   new System.Text.StringBuilder(Utilitario.Constantes.VACIO);
				QryStringBase.Append(KEYIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDEMPRESA].ToString());
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQIDFORMATO);
				QryStringBase.Append(Utilitario.Constantes.SIGNOIGUAL);	
				QryStringBase.Append(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]));
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQIDREPORTE + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]));
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYQIDRUBRO + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString());
				QryStringBase.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringBase.Append(KEYIDACUMULADO + Utilitario.Constantes.SIGNOIGUAL);
				QryStringBase.Append(Page.Request.Params[KEYIDACUMULADO]);

				//QueryString para el Mantenimiento del los Rubros del Formato
				System.Text.StringBuilder QryStringDetalle =   new System.Text.StringBuilder(Utilitario.Constantes.VACIO);
				QryStringDetalle.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringDetalle.Append(Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL);
				QryStringDetalle.Append(dr[Enumerados.ColumnasFormato.Modo.ToString()].ToString());
				//QueryString para la Consulta de la Cuenta Por Niveles
				System.Text.StringBuilder QryStringConsulta =   new System.Text.StringBuilder(Utilitario.Constantes.VACIO);
				QryStringConsulta.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringConsulta.Append(KEYQNRODIGITOSCABECERA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString());
				QryStringConsulta.Append(Utilitario.Constantes.SIGNOAMPERSON);	
				QryStringConsulta.Append(KEYDIGCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString());
				#endregion

				Utilitario.Helper.ConfiguraNodosTreeview(e,1,0,dr,
					Utilitario.Constantes.POPUPDEESPERA,
					Helper.HistorialIrAdelantePersonalizado(Utilitario.Constantes.VACIO),
					Helper.MostrarVentana(URLDETALLE,QryStringBase.ToString()+ QryStringConsulta.ToString())
					);
				
				Utilitario.Helper.SeleccionarItemGrillaOnClickMoverRaton(e);

				idFila ++;
				//Descipciones
				e.Item.Attributes.Add("OBSERVACIONES",dr[COLUMNAOBSERVACION].ToString());
				((System.Web.UI.WebControls.Image) e.Item.Cells[4].FindControl(CONTROLIMGBTNDESCRIPCION)).Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"EscribirDescripcionEnFila('" + dr[Enumerados.ColumnasFormato.IdRubro.ToString()].ToString() + "');");
			}	
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnProcesar_Click(object sender, System.EventArgs e)
		{
		}
		private void imgbtnGrabar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.LlenarDatos();

			if (hTramaData.Value.ToString().Length==0) {return;}
			string []sdata = hTramaData.Value.ToString().Split('@');
			for (int i=0;i<=sdata.Length-1;i++)
			{
				string []Data = sdata[i].Split('*');
				switch (Data[0].ToString())
				{
					case "N":
						//if (Data[2].ToString().Length > 0){this.Agregar(Data);}
						this.Agregar(Data);
						break;
					case "M":
						this.Modificar(Data);
						break;
				}
			}
			this.LlenarGrilla();
		}


		#region IPaginaMantenimento Members

		public void Agregar(string []Data)
		{
			//Referencia la Control de Parametros
			string idEmpresa = Page.Request.Params[KEYIDEMPRESA].ToString();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + idEmpresa];
			//Referencia a la Entidad de Negocio
			FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();

			oFormatoDetalleMovimientoBE.IdCentroOperativo = idCentroOperativoDescripcion;
			oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]); 
			oFormatoDetalleMovimientoBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]); 
			oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Data[1]);
			oFormatoDetalleMovimientoBE.Periodo = Convert.ToInt32(usc_ParametroContable.Periodo); 
			oFormatoDetalleMovimientoBE.Mes = Convert.ToInt32(usc_ParametroContable.Mes); 
			oFormatoDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(usc_ParametroContable.IdTipoInformacion); 
			oFormatoDetalleMovimientoBE.IdUsuarioRegistro =  CNetAccessControl.GetIdUser();
			oFormatoDetalleMovimientoBE.MontoAcumulado = 0;
//			if (Data[2].Trim().Length>0)
//			{
//				oFormatoDetalleMovimientoBE.MontoMes = Convert.ToDouble(Data[2]);
//			}
			oFormatoDetalleMovimientoBE.Observacion = Data[3].ToString();
			//oFormatoDetalleMovimientoBE.Observacion = this.txtObservacion.Text;

			CEstadosFinancieros  oCEstadosFinancieros = new CEstadosFinancieros();
			int retorno = oCEstadosFinancieros.Insertar(oFormatoDetalleMovimientoBE);
		}

		public void Modificar(string []Data)
		{
			
			//Referencia la Control de Parametros
			string idEmpresa = Page.Request.Params[KEYIDEMPRESA].ToString();
			ControlesUsuario.GestionFinanciera.ParametroContable usc_ParametroContable = (ControlesUsuario.GestionFinanciera.ParametroContable)Session[OBJPARAMETROCONTABLE + idEmpresa ];
			//Referencia a la Entidad de Negocio
			FormatoDetalleMovimientoBE oFormatoDetalleMovimientoBE = new FormatoDetalleMovimientoBE();

			

			oFormatoDetalleMovimientoBE.IdCentroOperativo = idCentroOperativoDescripcion;
			oFormatoDetalleMovimientoBE.IdFormato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]); 
			oFormatoDetalleMovimientoBE.IdReporte = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]); 
			oFormatoDetalleMovimientoBE.IdRubro = Convert.ToInt32(Data[1]);
			oFormatoDetalleMovimientoBE.Periodo = Convert.ToInt32(usc_ParametroContable.Periodo); 
			oFormatoDetalleMovimientoBE.Mes = Convert.ToInt32(usc_ParametroContable.Mes);
			oFormatoDetalleMovimientoBE.IdTipoInformacion = Convert.ToInt32(usc_ParametroContable.IdTipoInformacion); 
			oFormatoDetalleMovimientoBE.IdUsuarioActualizacion =  CNetAccessControl.GetIdUser();
			oFormatoDetalleMovimientoBE.MontoAcumulado = 0;
			
			//string a = Data[2].ToString().Trim();
			//string strMonto = ((Data[2].ToString().Trim().Length>0)? Data[2].ToString().Trim().Replace(" ",""):"0");

			//oFormatoDetalleMovimientoBE.MontoMes = Convert.ToDouble(strMonto);
			oFormatoDetalleMovimientoBE.MontoMes = 0;
			oFormatoDetalleMovimientoBE.Observacion = Data[3].ToString();
			//oFormatoDetalleMovimientoBE.Observacion = this.txtObservacion.Text.ToString();

			CEstadosFinancieros  oCEstadosFinancieros = new CEstadosFinancieros();
			int retorno = oCEstadosFinancieros.Modificar(oFormatoDetalleMovimientoBE);
		}

		public void Agregar()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultaDeEstadosFinancierosPERU.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion		
		
		private void imgGlosa_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Page.Response.Redirect(URLGLOSA + KEYQIDFORMATO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYQIDFORMATO].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ KEYIDEMPRESA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDEMPRESA].ToString()
				+ Utilitario.Constantes.SIGNOAMPERSON
				+ Utilitario.Constantes.KEYMODOPAGINA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Enumerados.ModoPagina.N.ToString());
		}
	}
}
