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
using SIMA.Utilitario;
using SIMA.EntidadesNegocio.GestionFinanciera;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using System.Reflection;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestoVarios
{
	public class AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string KEYIDCENTROOPERATIVO ="centro"; 
 
		const string KEYIDPRESUPUESTOCUENTA ="Cta";  
		const string KEYIDTIPOPRESUPUESTOCUENTA ="idTipoPresupuestoCta";  
		const string KEYIDTIPOPRESUPUESTO ="idTipoPresupuesto";
		const string KEYIDNOMBRETIPOPRESUPUESTO ="NombreTipoPresupuesto";
		
		const string KEYIDCENTROCOSTO ="idCC";
		const string KEYIDGRUPOCC ="idGrpCC";
		const string KEYIDNOMBREGRUPOCC ="NombreGrpCC";
		const string KEYIDPERIODO ="periodo";
		const string KEYIDMES ="idMes";
		const string KEYIDNOMBREMES ="NombreMes";
		
		const string FNCJSGRABARCOLUMNAS="GrabarColumnasModificadas();";

		//URL
		const string URLPRESUPUESTOCUENTA ="AdministrarTipodePresupuestoCuentasGruposCC.aspx?";
		const string URLIMGPLUS ="/imagenes/tree/plus.gif";

		int idFila=0;

		//Otros
		const string SESSIONTOTALIZA ="Totaliza";
		const string TITULOPTO ="PRESUPUESTO : ";
		const string TITULOGRUPO ="GRUPO : ";
		const string TITULOTOTAL ="TOTAL :";

		//DataGrid and DataTable
		const string COLUMNAIDCENTROCOSTO ="idCentroCosto";
		const string COLUMNANOMBRECENTROCOSTO ="NombreCentrodeCosto";
		const string COLUMNANOMBRECTA ="NombreCuenta";
		const string COLUMNACTACONTABLE ="CuentaContable";

		//Controles
		const string CTRLIDDIGCTA="IDDIGCTA";
		const string CTRLCARGADO ="CARGADO";
		const string CTRLIDFILA ="IDFILA";
		const string CTRLIDFILAORG ="IDFILAORG";

		#endregion
		#region Controles
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblTipoPresupuesto;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label lblPeriodo;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
			protected System.Web.UI.WebControls.Label lblResultado;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
			protected System.Web.UI.WebControls.Label lblGrupoCC;
			protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.DropDownList ddldCentrodeCosto;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hTrama;
			protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			//this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarCombos();
					this.LlenarDatos();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrilla();
					
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
			this.ddldCentrodeCosto.SelectedIndexChanged += new System.EventHandler(this.ddldCentrodeCosto_SelectedIndexChanged);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		private void Totalizar(DataTable dtOrigen)
		{
			if (dtOrigen !=null)
			{
				string []NMeses ={"pEnero","pFebrero","pMarzo","pAbril","pMAyo","pJunio","pJulio","pAgosto","pSetiembre","pOctubre","pNoviembre","pDiciembre","pTotal"};
				ArrayList arrTotal = new ArrayList();
				for(int i=0;i<=NMeses.Length-1;i++)
				{
					arrTotal.Add(Helper.TotalizarDataView(dtOrigen.DefaultView,NMeses[i].ToString())[0]);	
				}
				Session[SESSIONTOTALIZA] = arrTotal;
			}
		}


		public void LlenarGrilla()
		{
			DataTable dt = ((CPresupuesto) new CPresupuesto()).AdministrarDetallePresupuestoCuenta3Dig(
																										Page.Request.Params[KEYIDPRESUPUESTOCUENTA].ToString()
																										,Convert.ToInt32(Page.Request.Params[KEYIDCENTROOPERATIVO])
																										,Convert.ToInt32(Page.Request.Params[KEYIDGRUPOCC])
																										,Convert.ToInt32(this.ddldCentrodeCosto.SelectedValue)
																										,Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])
																										,CNetAccessControl.GetIdUser());
			if(dt!=null)
			{
				grid.DataSource = dt;
				this.Totalizar(dt);
			}
			else
			{
				grid.DataSource = dt;
				lblResultado.Text = GRILLAVACIA;

			}
			grid.DataBind();
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			this.LlenarCentrodeCostos();
		}
		private void LlenarCentrodeCostos()
		{
			ddldCentrodeCosto.DataSource =((CCentroCosto) new CCentroCosto()).AdministrarDetalleCentrodeCosto(
																												Convert.ToInt32(Page.Request.Params[KEYIDGRUPOCC])
																												,CNetAccessControl.GetIdUser());
			ddldCentrodeCosto.DataValueField=COLUMNAIDCENTROCOSTO;
			ddldCentrodeCosto.DataTextField=COLUMNANOMBRECENTROCOSTO;
			ddldCentrodeCosto.DataBind();
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
		}

		public void LlenarDatos()
		{
			this.lblPeriodo.Text = Page.Request.Params[KEYIDPERIODO].ToString();
			//this.lblMes.Text =Page.Request.Params[KEYIDNOMBREMES].ToString();
			this.lblTipoPresupuesto.Text = TITULOPTO + Page.Request.Params[KEYIDNOMBRETIPOPRESUPUESTO].ToString();
			this.lblGrupoCC.Text = TITULOGRUPO + Page.Request.Params[KEYIDNOMBREGRUPOCC].ToString();
		}

		public void LlenarJScript()
		{
			this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,FNCJSGRABARCOLUMNAS);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.Exportar implementation
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
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//e.Item.Cells[0].CssClass = "locked";
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				e.Item.Cells[0].Controls.Add(this.CrearTablaNodoRaiz(dr[COLUMNANOMBRECTA].ToString(),dr[COLUMNACTACONTABLE].ToString()));
				e.Item.Attributes.Add(KEYIDPRESUPUESTOCUENTA,Page.Request.Params[KEYIDPRESUPUESTOCUENTA].ToString());
				e.Item.Attributes.Add(KEYIDCENTROOPERATIVO,Page.Request.Params[KEYIDCENTROOPERATIVO].ToString());
				e.Item.Attributes.Add(KEYIDGRUPOCC,Page.Request.Params[KEYIDGRUPOCC].ToString());
				e.Item.Attributes.Add(KEYIDCENTROCOSTO,this.ddldCentrodeCosto.SelectedValue.ToString());
				e.Item.Attributes.Add(KEYIDPERIODO,Page.Request.Params[KEYIDPERIODO].ToString());
				e.Item.Attributes.Add(CTRLIDDIGCTA,dr[COLUMNACTACONTABLE].ToString());
				e.Item.Attributes.Add(CTRLCARGADO,Utilitario.Constantes.ValorConstanteCero.ToString());
				for(int i=1;i<=13;i++)
				{
					e.Item.Cells[i].Text = Convert.ToDouble(e.Item.Cells[i].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
			e.Item.Attributes.Add(CTRLIDFILA,idFila.ToString());
			e.Item.Attributes.Add(CTRLIDFILAORG,idFila.ToString());
			e.Item.Font.Bold=true;
			e.Item.Font.Size = 8;
			idFila++;
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].Text =TITULOTOTAL;
				ArrayList ArrTotal = (ArrayList)Session[SESSIONTOTALIZA];
				for(int i=0;i<=ArrTotal.Count-1;i++)
				{
					e.Item.Cells[i+1].Text = Convert.ToDouble(ArrTotal[i]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					e.Item.Cells[i+1].ForeColor = Color.Navy;
				}
				Session[SESSIONTOTALIZA] = null;
			}
		}
		private HtmlTable CrearTablaNodoRaiz(string Descripcion,string idDigCta)
		{
			HtmlTable tbl = new HtmlTable();
			HtmlTableRow Fila = new HtmlTableRow();
			HtmlImage imagen;
			HtmlTableCell Celda;

			Celda = new HtmlTableCell();
			imagen = new HtmlImage();imagen.Src =Session[Utilitario.Constantes.SPATHAPPWEB].ToString() + URLIMGPLUS;
			imagen.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"CargarDetalleNaturaleza5Dig(this,'" + idDigCta + "')");
			Celda.Controls.Add(imagen);
			Fila.Controls.Add(Celda);

			Celda = new HtmlTableCell();
			Celda.InnerText = Descripcion;
			Celda.NoWrap=true;
			Celda.Style.Add("font","bold");
			
			Fila.Controls.Add(Celda);
			Fila.Attributes.Add("Class","itemgrillasinColor");
			tbl.Controls.Add(Fila);
			
			return tbl;
		}

		private void ddldCentrodeCosto_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.LlenarGrilla();
		}

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
			SaldoContableBE oSaldoContableBE = new SaldoContableBE();
			oSaldoContableBE.IDCENTROOPERATIVO = Convert.ToInt32(Page.Request.Params[KEYIDCENTROOPERATIVO]);
			oSaldoContableBE.IDGRUPOCC = Convert.ToInt32(Page.Request.Params[KEYIDGRUPOCC]);
			oSaldoContableBE.IDCENTROCOSTO = Convert.ToInt32(this.ddldCentrodeCosto.SelectedValue);
			oSaldoContableBE.PERIODO = Convert.ToInt32(Page.Request.Params[KEYIDPERIODO]);

			for(int c=0;c<=Data.Length-1;c++)
			{
				if (c==0)
				{
					oSaldoContableBE.CUENTACONTABLE = Data[c].ToString();
				}
				else
				{
					//Inserta o Actualiza los Monstro de Presupuesto
					string []idMesMonto	= Data[c].Split('_');
					oSaldoContableBE.IDMES = Convert.ToInt32(idMesMonto[0]);
					oSaldoContableBE.MONTOPRESUPUESTO = Convert.ToDouble(idMesMonto[1]);
					//int i=((CPresupuesto) new CPresupuesto()).InsertarModificar(oSaldoContableBE);
				}
			}
		}
		#region IPaginaMantenimento Members

		public void Agregar()
		{
						
		}

		public void Modificar()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarTipodePresupuestoCuentasGruposCCCentrodeCosto.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
