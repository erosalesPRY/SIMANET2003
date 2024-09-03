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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing.Printing;



namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	/// <summary>
	/// Summary description for ConsultarPresupuestoVarios.
	/// </summary>
	public class ConsultarPresupuestoVarios : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes

		const string KEYQIDCENTRO="Centro";
		const string KEYQIDFECHA="Fecha";
		const string KEYQIDTIPOPRESUPUESTO="idTPPPto";
		const string KEYQIDDIGCTA="DigCta";
		
		const string KEYQIDNOMBREMES = "NombreMes";
		const string KEYQIDNIVELRESUMEN = "NivelResumen";
		const string KEYQIDPPERSONAL = "idpPersonal";
		const string NOMBREPRESUPUESTO = "NomPresup";
		const string KEYQIDTIPOPRESUPUESTOCUENTA = "idTPCta";
		const string KEYQIDNOMBRECENTRO="NombreCentro";
		const string KEYQIDNOMBREPRESUPUESTO="NombreTipoPrespuesto";
		const string KEYQIDNOMBREANEXO="NombreAnexo";


		string tblNodoRaiz ="<TABLE class='ItemGrillaSinColor' cellSpacing='0' cellPadding='0' width='100%' border='0'><TR><TD><IMG id=[IMGPM] src='../../imagenes/tree/plus.gif' onclick=" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "OpenClose([PARAMETROS]);" + Utilitario.Constantes.SIGNOCOMILLADOBLE + "></TD><TD style='display:none' ><IMG id=[IMGFOLDER] src='../../imagenes/tree/Close.gif'></TD><TD id=[IDCOL] width='100%'>[Texto]</TD></TR></TABLE>";
		//string tblNodoHijo ="<TABLE class='ItemGrillaSinColor' cellSpacing='0' cellPadding='0' width='100%' border='0'><TR><TD><IMG src='../../imagenes/tree/Blanco.gif'></TD><TD><IMG src='../../imagenes/tree/Blanco.gif'></TD><TD><IMG src='../../imagenes/tree/xpMyDoc.gif'></TD><TD width='100%' [EVENTO] style='COLOR: #0000ff; TEXT-DECORATION: underline'> [Texto]</TD></TR></TABLE>";

		const string NOMBRECENTRO ="NombreCentro";

		const string GRILLAVACIA ="No existe ningún Registro."; 
 
		//DataGrid and DataTable
		const string COLUMNASALDO ="Saldo";
		const string COLUMNANOMBRE ="NOMBRE";
		const string COLUMNAIDCENTROOPERATIVO ="idCentroOperativo";
		const string COLUMNAIDGRUPOCC ="idGrupoCC";
		const string COLUMNACO ="CO";
		const string COLUMNAPERIODO ="PERIODO";
		const string COLUMNAMES ="MES";
		const string COLUMNADIGCTA ="DIGCTA";
		const string COLUMNAGRPCC ="GRPCC";
		const string COLUMNACC = "CC";


		const string VALORIDFILA ="IDFILA";
		const string VALORIDNIVEL ="IDNIVEL";
		const string VALORNIVEL ="NIVEL";
		const string VALORCONSULTADO ="CONSULTADO";
		const string VALORTEXTO ="Texto";
		const string VALORPARAMETROS ="PARAMETROS";
		const string VALORIMGPM ="IMGPM";
		const string VALORIMGFOLDER ="IMGFOLDER";
		const string VALORIDCOL ="IDCOL";

				

		//Otros
		const string SYSTEMDOUBLE ="System.Double";
		const string EXPRESSION ="TotalPPtoCta - TotalEjecutado";


		//const string URLPAGINAPRESUPUESTOADM = "../PresupuestoAdministrativo/ConsultarPresupuesto.aspx?";

		int Fila=1;		
		#endregion

		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label Label5;
			protected System.Web.UI.WebControls.Label Label4;
			protected projDataGridWeb.DataGridWeb grid;
			protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblPeriodo;
		protected System.Web.UI.WebControls.Label lblMes;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblNombreCentro;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblNombreTipoPresupuesto;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.LlenarCombos();
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Constantes.INDICEPAGINADEFAULT);
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
					string msgb =oException.Message.ToString();
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarPresupuestoVarios.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarPresupuestoVarios.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			DataTable tblResultado;
			CPresupuesto oCPresupuesto = new  CPresupuesto();
			if (Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString()=="99")
			{
				//Presupuesto de Personal
				tblResultado =oCPresupuesto.ConsultarPresupuestodePersonalporGrupodeCentrodeCosto 
									(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
									,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
									,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
									,Page.Request.Params[KEYQIDDIGCTA].ToString());

			}
			else
			{
				tblResultado =oCPresupuesto.ConsultarPresupuestoporGrupodeCentrodeCosto
					(Convert.ToInt32(Page.Request.Params[KEYQIDCENTRO])
					,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year)
					,Convert.ToInt32(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month)
					,Page.Request.Params[KEYQIDTIPOPRESUPUESTO].ToString());
			}
			if (tblResultado !=null)
			{
				DataColumn dc = new  DataColumn(COLUMNASALDO, Type.GetType(SYSTEMDOUBLE));
				dc.Expression = EXPRESSION;
				tblResultado.Columns.Add(dc);
			}
			return tblResultado;
		}


		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = this.ObtenerDatos();
			if(dtGeneral!=null)
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
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
			// TODO:  Add ConsultarPresupuestoVarios.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString();
			this.lblMes.Text = Helper.ObtenerNombreMes(Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month,Utilitario.Enumerados.TipoDatoMes.NombreCompleto);
			this.lblNombreCentro.Text = Page.Request.Params[KEYQIDNOMBRECENTRO].ToString().ToUpper();
			this.lblNombreTipoPresupuesto.Text = Page.Request.Params[KEYQIDNOMBREPRESUPUESTO].ToString().ToUpper() +  "  " + Page.Request.Params[KEYQIDNOMBREANEXO].ToString().ToUpper() ;
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarPresupuestoVarios.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarPresupuestoVarios.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarPresupuestoVarios.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarPresupuestoVarios.Exportar implementation
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
			// TODO:  Add ConsultarPresupuestoVarios.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add ConsultarPresupuestoVarios.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add ConsultarPresupuestoVarios.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add ConsultarPresupuestoVarios.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add ConsultarPresupuestoVarios.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add ConsultarPresupuestoVarios.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add ConsultarPresupuestoVarios.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add ConsultarPresupuestoVarios.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add ConsultarPresupuestoVarios.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add ConsultarPresupuestoVarios.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add ConsultarPresupuestoVarios.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Attributes.Add(VALORIDFILA,Fila.ToString());
				e.Item.Attributes.Add(VALORIDNIVEL,Fila.ToString());
				e.Item.Attributes.Add(VALORNIVEL,Utilitario.Constantes.ValorConstanteCero.ToString());
				e.Item.Attributes.Add(VALORCONSULTADO,Utilitario.Constantes.ValorConstanteCero.ToString());
				//e.Item.Attributes.Add("onmouseover","FilaSeleccionada(this)");
				//e.Item.Cells[0].Text= tblNodoRaiz.Replace("[Texto]",e.Item.Cells[0].Text).Replace("[PARAMETROS]","this,objImg" + Fila.ToString() + ",'" + Fila.ToString() + "'" ).Replace("[IMGFOLDER]","objImg" + Fila.ToString());
				string vNodo = tblNodoRaiz.Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORTEXTO + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,e.Item.Cells[0].Text).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORPARAMETROS + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"this,objImg" + Fila.ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORIMGPM + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"imgPlusMinus_" + Fila.ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORIMGFOLDER + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"objImg" + Fila.ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORIDCOL + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"td" + Fila.ToString());
				e.Item.Cells[0].Text= tblNodoRaiz.Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORTEXTO + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,dr[COLUMNANOMBRE].ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORPARAMETROS + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"this,objImg" + Fila.ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORIMGPM + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"imgPlusMinus_" + Fila.ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORIMGFOLDER + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"objImg" + Fila.ToString()).Replace(Utilitario.Constantes.SIGNOABRECORCHETES + VALORIDCOL + Utilitario.Constantes.SIGNOCIERRACORCHETES
					,"td" + Fila.ToString());
				//Atributos para la carga de datos
				e.Item.Attributes.Add(COLUMNACO,dr[COLUMNAIDCENTROOPERATIVO].ToString());
				e.Item.Attributes.Add(COLUMNAPERIODO,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Year.ToString() );
				e.Item.Attributes.Add(COLUMNAMES,Convert.ToDateTime(Page.Request.Params[KEYQIDFECHA]).Month.ToString());
				//e.Item.Attributes.Add("DIGCTA",Page.Request.Params[CUENTASCC].ToString());
				e.Item.Attributes.Add(COLUMNADIGCTA,Page.Request.Params[KEYQIDDIGCTA].ToString());
				e.Item.Attributes.Add(COLUMNAGRPCC,dr[COLUMNAIDGRUPOCC].ToString());
				e.Item.Attributes.Add(COLUMNACC,Utilitario.Constantes.ValorConstanteCero.ToString());
				
				e.Item.Cells[1].Text =Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text =Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text =Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Attributes.Add(Utilitario.Constantes.EVENTOONMOUSEOVER,"FilaSeleccionada(this);CambiarColorPasarMouse(this, true)");

				Fila ++;
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
