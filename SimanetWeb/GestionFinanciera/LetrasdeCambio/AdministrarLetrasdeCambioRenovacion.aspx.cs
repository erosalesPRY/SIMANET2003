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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using MetaBuilders.WebControls;
using SIMA.SimaNetWeb.Legal;


namespace SIMA.SimaNetWeb.GestionFinanciera.LetrasdeCambio
{
	/// <summary>
	/// Summary description for AdministrarLetrasdeCambioRenovacion.
	/// </summary>
	public class AdministrarLetrasdeCambioRenovacion : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region
			const string GRILLAVACIA ="No existe ningún Registro de Renovación de Letras.";  
			const string KEYMONTOLETRA ="MntLetra";
			const string KEYIDDOCLET ="idDocLetra";
			const string KEYIDLETRENOVADA ="idLetraRenovada";
			const string KEYIDMONEDA="idMoneda";
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hidLetra;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox nMontoCancelado;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label lblMontoLetra;
		protected System.Web.UI.WebControls.Label lblSado;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRegRenovaciones;
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
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se consultó Carta de Crédito.",Enumerados.NivelesErrorLog.I.ToString()));
					Helper.ReestablecerPagina(this);
					this.LlenarGrillaOrdenamientoPaginacion("" ,0);
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.LlenarGrillaOrdenamiento implementation
		}
		DataTable ObtenerDatos(){
			DataTable oDataTable = new DataTable();
			oDataTable.Columns.Add(new DataColumn("Nro", typeof(int)));
			oDataTable.Columns.Add(new DataColumn("FechaRenovacion", typeof(DateTime)));
			oDataTable.Columns.Add(new DataColumn("NroDias", typeof(int)));
			oDataTable.Columns.Add(new DataColumn("FechaVencimiento", typeof(DateTime)));
			oDataTable.Columns.Add(new DataColumn("TasaInteres", typeof(decimal)));
			oDataTable.Columns.Add(new DataColumn("Monto", typeof(double)));
			return oDataTable;
		}

		DataTable LlenarRegistros(DataTable dt){
			object []Registro = {1,null,0,null,0,0};
			dt.Rows.Add(Registro);Registro[0]=2;
			dt.Rows.Add(Registro);Registro[0]=3;
			dt.Rows.Add(Registro);Registro[0]=4;
			dt.Rows.Add(Registro);Registro[0]=5;
			dt.Rows.Add(Registro);
			return dt;
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dt =this.LlenarRegistros(this.ObtenerDatos());
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				dw.RowFilter = Helper.ObtenerFiltro();
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dw.Count.ToString();
				dw.Sort = columnaOrdenar;
				//this.GenerarResumen(dw);
				grid.DataSource = dw;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception ex)
			{
				string msg = ex.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}		
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblMontoLetra.Text = Convert.ToDouble(Page.Request.Params[KEYMONTOLETRA]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
		}

		public void LlenarJScript()
		{
			this.ibtnAceptar.Attributes.Add("onmousedown","AlmacenarRenovacion()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				((eWorld.UI.NumericBox)e.Item.Cells[2].FindControl("NDiasPlazo")).Attributes.Add("onfocus","AsignarEvento(this);");
			}
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						this.AdministrarRenovaciones(); 
						/*Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								this.Agregar(); 
								break;
							case Enumerados.ModoPagina.M:
								this.Modificar();
								break;
						}*/
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
				ltlMensaje.Text = Helper.MsgdbErrMostrarMesaje(true,oSIMAExcepcionDominio.Error.ToString());
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}			
		
		}
		int RegistraRenovacion(double Monto,DateTime FechaRenovacion,int NroDias,decimal tInteres){
			LetrasdeCambioRenovacionBE oLetrasdeCambioRenovacionBE = new LetrasdeCambioRenovacionBE();
			oLetrasdeCambioRenovacionBE.IdLetra = Convert.ToInt32(Page.Request.Params[KEYIDDOCLET]);
			oLetrasdeCambioRenovacionBE.IdLetraRenovadaRel = Convert.ToInt32(Page.Request.Params[KEYIDLETRENOVADA]);
			oLetrasdeCambioRenovacionBE.IdMoneda = Convert.ToInt32(Page.Request.Params[KEYIDMONEDA]);

			oLetrasdeCambioRenovacionBE.IdSituacion = 1;//En Cartera
			oLetrasdeCambioRenovacionBE.Monto = Monto;
			oLetrasdeCambioRenovacionBE.MontoCancelado = 0;
			oLetrasdeCambioRenovacionBE.FechaRenovacion =  FechaRenovacion;
			oLetrasdeCambioRenovacionBE.DiasdePlazo = NroDias;
			oLetrasdeCambioRenovacionBE.TasaInteres = tInteres;
			oLetrasdeCambioRenovacionBE.Observacion = "";
			oLetrasdeCambioRenovacionBE.IdEstado = 1;

			return (new CLetrasdeCambioRenovacion()).Insertar(oLetrasdeCambioRenovacionBE);
		}
		#region IPaginaMantenimento Members

		public void AdministrarRenovaciones()
		{
			LetrasdeCambioRenovacionBE oLetrasdeCambioRenovacionBE = new LetrasdeCambioRenovacionBE() ;
			oLetrasdeCambioRenovacionBE.IdLetraRenovada = Convert.ToInt32(Page.Request.Params[KEYIDLETRENOVADA]) ;
			oLetrasdeCambioRenovacionBE.MontoCancelado=Convert.ToDouble(this.nMontoCancelado.Text);
			oLetrasdeCambioRenovacionBE.IdSituacion=((Convert.ToDouble(this.lblMontoLetra.Text.Trim())== Convert.ToDouble(this.nMontoCancelado.Text.Trim()))?4:9);//Cancelada y Renovada
			if((new CLetrasdeCambioRenovacion()).Modificar(oLetrasdeCambioRenovacionBE,0)!=0)
			{
				string []arrReg = this.hRegRenovaciones.Value.ToString().Split('#');	
				for(int i=0;i<=arrReg.Length-1;i++)
				{
					string []arrRegCol = arrReg[i].ToString().Split(';');
					RegistraRenovacion(Convert.ToDouble(arrRegCol[3]),Convert.ToDateTime(arrRegCol[0]),Convert.ToInt32(arrRegCol[1]),Convert.ToDecimal(arrRegCol[2]));
				}
				//LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestión Financiera",this.ToString(),"Se ingresó Item de " + oLetrasdeCambioBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				Helper.CerrarVentana();
			}
		}
		public void Agregar()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.Modificar implementation
		}
		public void Modificar()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarLetrasdeCambioRenovacion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
