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
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Reflection;


namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{

	public class AdministrarPresupuestodeFinanciamiento : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
		const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";
		const string KEYIDPERIODO ="periodo";
		const string KEYIDMES ="idMes";
		const string KEYIDNOMBREMES ="NombreMes";
		const string URLAMORTIZAPTMO ="DialogoEditarMontoAmortizadoeInteres.aspx?";
		const string KEYMONTOAMORTIZA ="ma";
		const string KEYMONTOINTERES ="mi";
		const string KEYNOMBREBANCO ="nb";
		const string KEYOCULTAR ="Ocultar";

			
		const string LBLPPTO="lblPresupuesto";
		const string LBLREAL="lblReal";
		const string LBLSALDO="lblSaldo";
 
		//Otros
		const string COLUMNAIDCENTROOPERATIVO ="idCentroOperativo";
		const string COLUMNADESCRIPCION ="Descripcion";

		const string TITULOPTO ="PRESUPUESTO DE ";
		const string CLASEJSCRIPT ="GrabarColumnasModificadas();";
		const string TITULOBANCO ="BANCO ";
		const string TITULOSI ="SI";

		//Controles
		const string CTRLMONTO ="MONTO";
		const string CTRLMONTOAMORTIZA ="MONTOAMORTIZA";
		const string CTRLMONTOINTERES ="MONTOINTERES";
		const string CTRLMODIFICADO ="MODIFICADO";
		const string CTRLIDEF ="IDEF";
		const string CTRLNOMBREBCO ="NOMBREBCO";

		//DataGrid and DataTable
		const string COLUMNAIDENTIDADFINACIERA ="idEntidadFinanciera";
		const string COLUMNARAZONSOCIAL ="RazonSocial";
		const string COLUMNAATOTALPTO ="aTotalPpto";
		const string COLUMNAITOTALPTO ="iTotalPpto";
		
		#endregion

		#region Constroles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblTipoPresupuesto;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
			protected System.Web.UI.WebControls.DropDownList ddldCentrodeOperaciones;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hTrama;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddldTipo;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
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
					ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());					
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
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CPresupuestoFinanciamiento)new CPresupuestoFinanciamiento()).AdministrarDetallePresupuestodeFinanciamiento(
																																Convert.ToInt32(this.ddldCentrodeOperaciones.SelectedValue)
																																,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																																,Convert.ToInt32(this.ddldTipo.SelectedValue));
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dt = this.ObtenerDatos();
			if(dt!=null)
			{
				DataView dw = dt.DefaultView;
				dw.Sort = columnaOrdenar ;
				//dw.RowFilter= Utilitario.Helper.ObtenerFiltro();
				//grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dw.Count.ToString();
				grid.DataSource = dw;
				grid.CurrentPageIndex =indicePagina;
				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch	
			{
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
		}

		public void LlenarCombos()
		{
			this.CargarPresupuestoTipoPlazos();
			this.LlenarTipoPresupuestoCuenta();
		}
		private void CargarPresupuestoTipoPlazos()
		{
			
			this.ddldTipo.DataSource= ((CTablaTablas)new CTablaTablas()).ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraPresupuestoTipoPlazo));
			ddldTipo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddldTipo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddldTipo.DataBind();			
		}
		private void LlenarTipoPresupuestoCuenta()
		{
			ddldCentrodeOperaciones.DataSource =((CTipoPresupuestoCuenta)new CTipoPresupuestoCuenta()).AdministrarDetalleTiposdePresupuestoCuenta(
																																				Convert.ToInt32(Page.Request.Params[KEYIDTIPOPRESUPUESTO])
																																				,CNetAccessControl.GetIdUser()
																																				,Utilitario.Constantes.IDDEFAULT
																																				,Utilitario.Constantes.IDDEFAULT);
			ddldCentrodeOperaciones.DataValueField=COLUMNAIDCENTROOPERATIVO;
			ddldCentrodeOperaciones.DataTextField=COLUMNADESCRIPCION;
			ddldCentrodeOperaciones.DataBind();
		}
		public void LlenarDatos()
		{
			this.lblTipoPresupuesto.Text= TITULOPTO + Page.Request.Params[KEYIDNOMBRETIPOPRESUPUESTO].ToString();
			this.lblPeriodo.Text = Page.Request.Params[KEYIDPERIODO].ToString();
		}

		public void LlenarJScript()
		{
			ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,CLASEJSCRIPT);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.Exportar implementation
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
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				string []NombreMes={"Enero","Febrero","Marzo","Abril","Mayo","Junio","Julio","Agosto","Setiembre","Octubre","Noviembre","Diciembre"};
				for(int i=0;i<=NombreMes.Length-1;i++)
				{
					((eWorld.UI.NumericBox) e.Item.Cells[i+1].FindControl("n" + (i+1))).Text = Convert.ToDouble(dr["p"+NombreMes[i].ToString()]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					((eWorld.UI.NumericBox) e.Item.Cells[i+1].FindControl("n" + (i+1))).Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"ValidaNro(this)");
					((eWorld.UI.NumericBox) e.Item.Cells[i+1].FindControl("n" + (i+1))).Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK,Utilitario.Constantes.POPUPDEESPERA +  "MostrarAmortizacioneInteres(this)");
					
					e.Item.Cells[i+1].Attributes.Add(CTRLMONTO,dr["p"+NombreMes[i].ToString()].ToString());
					e.Item.Cells[i+1].Attributes.Add(CTRLMONTOAMORTIZA,dr["a"+NombreMes[i].ToString()].ToString());
					e.Item.Cells[i+1].Attributes.Add(CTRLMONTOINTERES,dr["i"+NombreMes[i].ToString()].ToString());
					e.Item.Cells[i+1].Attributes.Add(CTRLMODIFICADO,"NO");

					
					
				}
				e.Item.Attributes.Add(CTRLIDEF,dr[COLUMNAIDENTIDADFINACIERA].ToString());
				e.Item.Attributes.Add(CTRLNOMBREBCO,dr[COLUMNARAZONSOCIAL].ToString());

				string strQuery = URLAMORTIZAPTMO + KEYMONTOAMORTIZA + Utilitario.Constantes.SIGNOIGUAL + dr[COLUMNAATOTALPTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYMONTOINTERES + Utilitario.Constantes.SIGNOIGUAL  + dr[COLUMNAITOTALPTO].ToString()
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYNOMBREBANCO + Utilitario.Constantes.SIGNOIGUAL  + TITULOBANCO + e.Item.Cells[0].Text
					+ Utilitario.Constantes.SIGNOAMPERSON
					+ KEYOCULTAR + Utilitario.Constantes.SIGNOIGUAL  + TITULOSI;
				
				e.Item.Cells[13].Attributes.Add(Utilitario.Constantes.EVENTODBLCLICK,Utilitario.Constantes.POPUPDEESPERA +  Helper.MostrarVentanaDialogo(strQuery,480,225));

				e.Item.Cells[13].Text = Convert.ToDouble(e.Item.Cells[13].Text ).ToString(Utilitario.Constantes.FORMATODECIMAL4); 

				

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}		
		}
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarPresupuestodeFinanciamiento.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string strData = this.hTrama.Value.ToString();
			string []strRegistro = strData.Split('@');
			for (int i=0;i<= strRegistro.Length-1;i++)
			{
				string []Data = strRegistro[i].Split('*');
				if (Data.Length >1)
				{
					this.AgragarModificar(Data);
				}
			}
			this.LlenarGrilla();
		}
		private void AgragarModificar(string []Data)
		{
			PresupuestoFinanciamientoBE oPresupuestoFinanciamientoBE = new PresupuestoFinanciamientoBE();

			oPresupuestoFinanciamientoBE.Periodo = Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]);
			oPresupuestoFinanciamientoBE.IdCentroOperativo = Convert.ToInt32(this.ddldCentrodeOperaciones.SelectedValue);
			oPresupuestoFinanciamientoBE.IdTipoPresupuesto = Convert.ToInt32(Page.Request.Params[KEYIDTIPOPRESUPUESTO]);
			oPresupuestoFinanciamientoBE.IdTipoPLazo = Convert.ToInt32(this.ddldTipo.SelectedValue);
			oPresupuestoFinanciamientoBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

			for(int c=0;c<=Data.Length-1;c++)
			{
				if (c==0)
				{
					oPresupuestoFinanciamientoBE.IdEntidadFinanciera = Convert.ToInt32(Data[c].ToString());
				}
				else
				{
					//Inserta o Actualiza los Monstro de Presupuesto
					string []idMesMonto	= Data[c].Split('_');
					oPresupuestoFinanciamientoBE.IdMes = Convert.ToInt32(idMesMonto[0]);
					oPresupuestoFinanciamientoBE.MontoPtmo=Convert.ToDouble(idMesMonto[1]);
					oPresupuestoFinanciamientoBE.MontoAmortiza=Convert.ToDouble(idMesMonto[2]);
					oPresupuestoFinanciamientoBE.MontoInteres=Convert.ToDouble(idMesMonto[3]);
					int i=((CPresupuestoFinanciamiento) new CPresupuestoFinanciamiento()).InsertarModificar(oPresupuestoFinanciamientoBE);
				}
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}
}
