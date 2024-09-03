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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.Controladoras.General;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionFinanciera;
using System.Text;
using System.IO;
namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar
{
	/// <summary>
	/// Summary description for ConsultarDetalleCuentasPorCobrarJudiciales.
	/// </summary>
	public class ConsultarDetalleCuentasPorCobrarJudiciales : System.Web.UI.Page,IPaginaBase
	{
		#region controles
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblConcepto;
		#endregion

		#region constantes
		DataTable dt;
		const string KEYQIDTIPOCUENTA = "IdTipoCuenta";
		const string KEYQIDCUENTAPORCOBRARPAGAR = "IdCuenta";//
		const string KEYQIDSUBCUENTAPORCOBRARPAGAR = "IdSubCuenta";
		const string KEYQIDCENTROOPERATIVO = "IdCentroOperativo";//
		const string KEYQID2 = "Id2";//
//		const string KEYQDESCRIPCIONTIPOCUENTA = "TipoCuenta";
	//	const string KEYQDESCRIPCION = "TipoCuenta";
		const string KEYQDESCRIPCION = "Descripcion";//
		const string KEYQFLAGDIRECTORIO= "FlagDirectorio";
		const string KEYQPORPROVISIONAR= "PorProvisionar";
		double acumCantidadTotal=0;

		const string URLDETALLEXCEL="ExportarDetalleExcelCtasPorCobrarJudiciales.aspx?";
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.WebControls.ImageButton ibtnAbrir;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtObservaciones;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;

		//JScript
		string JSVERIFICARPORPROVISIONAR = "return verificarEliminarRb('hCta','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+"Desea Transferir a Cuentas por Cobrar por Provisionar?"+"');";
		string JSVERIFICARJUDICIALES = "return verificarEliminarRb('hIdProv','"  + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+"Desea Transferir a Cuentas por Cobrar Judiciales?"+"');";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCta;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNumDocAna;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMes;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hDesc;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hAbono;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCargo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNumAsto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProv;
		protected System.Web.UI.WebControls.ImageButton ibtnProvision;
		protected System.Web.UI.WebControls.ImageButton ibtnJudicial;

		
		double total=0;
		#endregion
		
		private void PasaraJudiciales()
		{
			if(hIdProv.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CCuentasPorCobrarPagar oCCuentasPorCobrarPagar = new CCuentasPorCobrarPagar();
				if (oCCuentasPorCobrarPagar.EliminarCuentaporCobrarporProvisionar(Convert.ToInt32(this.hIdProv.Value.ToString()))>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera:Cuentas por Cobrar y Pagar", this.ToString(), "Se Transfirió Movimiento a Cuentas de Judiciales " + this.hIdProv.ToString() + Utilitario.Constantes.SEPARADOR + ".",Enumerados.NivelesErrorLog.I.ToString())); 
					ViewState["tabla"]=null;
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
//					ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONELIMINACIONREGISTRO));
				}
			}
		}

		private void PasaraPorProvisionar()
		{
			if(hCta.Value.Length==0)
			{
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
			}
			else
			{
				CtasporCobrarPorProvisionarBE oCtasporCobrarPorProvisionarBE = new CtasporCobrarPorProvisionarBE();
				oCtasporCobrarPorProvisionarBE.CuentaContable    = hCta.Value.ToString();
				oCtasporCobrarPorProvisionarBE.IdCentroOperativo = Convert.ToInt32(hCo.Value.ToString());
				oCtasporCobrarPorProvisionarBE.Nroentidad        = hEntidad.Value.ToString();
				oCtasporCobrarPorProvisionarBE.Num_doc_ana       = hNumDocAna.Value.ToString();
				oCtasporCobrarPorProvisionarBE.Num_asto          = Convert.ToInt32(hNumAsto.Value.ToString());
				oCtasporCobrarPorProvisionarBE.Idmes             = Convert.ToInt32(hMes.Value.ToString());
				oCtasporCobrarPorProvisionarBE.Periodo           = Convert.ToInt32(hPeriodo.Value.ToString());
				oCtasporCobrarPorProvisionarBE.Descripcion       = hDesc.Value.ToString();
				oCtasporCobrarPorProvisionarBE.Abono             = Convert.ToDecimal(hAbono.Value.ToString());
				oCtasporCobrarPorProvisionarBE.Cargo             = Convert.ToDecimal(hCargo.Value.ToString());
				oCtasporCobrarPorProvisionarBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();

				CCuentasPorCobrarPagar oCCuentasPorCobrarPagar = new CCuentasPorCobrarPagar();
				if (oCCuentasPorCobrarPagar.InsertarCtaporProvisionar(oCtasporCobrarPorProvisionarBE)>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión Financiera:Cuentas por Cobrar y Pagar", this.ToString(), "Se Transfirió Movimiento a Cuentas por Provisionar " + this.hCta.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString())); 
					ViewState["tabla"]=null;
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					//ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),"Se Transfirió Movimiento a Cuentas por Provisionar"));
				}
			}
		}

		
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					LlenarDatos();
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();

					

					if (CNetAccessControl.GetIdUser()==58 || CNetAccessControl.GetIdUser()==35)
						if (Convert.ToInt32(Page.Request.Params[KEYQPORPROVISIONAR])==1)
						{
							ibtnProvision.Style.Add("display","none");
						}
						else
						{
							ibtnJudicial.Style.Add("display","none");
						}
					else
					{
						ibtnProvision.Style.Add("display","none");
						ibtnJudicial.Style.Add("display","none");
					}
						
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					this.LlenarJScript();
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.ibtnJudicial.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnJudicial_Click);
			this.ibtnProvision.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnProvision_Click);
			this.ibtnAbrir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAbrir_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			

		
			dt = this.ObtenerDatos(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),Convert.ToInt32(Page.Request.Params[KEYQID2]), Convert.ToInt32(Page.Request.Params[KEYQPORPROVISIONAR]) );
			dt = Helper.TablePersonalizado(dt,"fecha");
			
		
		
			if(dt!=null)
			{
				
				DataView dw = dt.DefaultView;
				
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				Session["EXPORTAREXCEL"]=dt;
				

//				foreach(DataRow dr in  dw.Table.Rows)
//				{
//					total+= Convert.ToDouble(dr["saldo"]);
//				}
				//grid.Columns[6].FooterText=total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				grid.DataSource = dw;
				grid.Columns[1].FooterText=dw.Count.ToString();
				grid.CurrentPageIndex =indicePagina;
				this.Totalizar(dw);
				lblResultado.Visible=false;
				
			}
			else
			{
				Session["EXPORTAREXCEL"]=null;
				grid.DataSource = null;
				lblResultado.Visible=true;
			    lblResultado.Text = "No existen registros";
			}
			try
			{
				grid.DataBind();
				grid.Columns[6].FooterText=total.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				
			}
			catch	
			{
				Session["EXPORTAREXCEL"]=null;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
				
			}			

		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			lblConcepto.Text= Page.Request.QueryString[KEYQDESCRIPCION].ToString();

		}

		public void LlenarJScript()
		{
			if(dt!=null)
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLDETALLEXCEL,780,640));
			else
				ibtnAbrir.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"window.alert('No existen datos a exportar')");
			ibtnProvision.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARPORPROVISIONAR);
			ibtnJudicial.Attributes.Add(Constantes.EVENTOCLICK,JSVERIFICARJUDICIALES);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.Exportar implementation
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
			// TODO:  Add ConsultarDetalleCuentasPorCobrarJudiciales.ValidarFiltros implementation
			return false;
		}

		#endregion

		private DataTable ObtenerDatos(int idcentrooperativo,int id, int id2, int prov)
		{
//			if (Convert.ToInt32(Page.Request.QueryString[KEYQFLAGDIRECTORIO].ToString()) == Constantes.POSICIONINDEXUNO)
//			{
//				return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarResumenCtasPorCobrarNivel3JudicialesAlCierre(idcentrooperativo,id,id2, prov);
//			}
//			else
//			{
				return ((CCuentasPorCobrarPagar) new CCuentasPorCobrarPagar()).ConsultarResumenCtasPorCobrarNivel3Judiciales(idcentrooperativo,id,id2, prov);
			//}
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[3].ToolTip="Identificacion";
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

//				string Cta = dr["SUBCUENTA"].ToString();
//				string Co  = dr["idcentroOperativo"].ToString();
//				string Entidad = dr["NroEntidad"].ToString();
//				string NumDocAna = dr["Num_Doc_Ana"].ToString();
//				string NumAsto = dr["Num_Asto"].ToString();
//				string Mes = dr["FechaAsto"].ToString();
//				//Mes = Mes.ToString(Constantes.FORMATOFECHA2).Substring(4,2);
//				string Periodo = dr["FechaAsto"].ToString();
//				//Periodo = Periodo.ToString(Constantes.FORMATOFECHA2).Substring(0,4);
//				string Desc = dr["descrip"].ToString();
//				string Abono = dr["abono"].ToString();
//				string Cargo = dr["cargo"].ToString();
//				string IdProv = dr["idCtasporCobrarPorProvisionar"].ToString();


				e.Item.Cells[6].Text=Convert.ToDouble(dr["saldo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;

				if (dr["idcentroOperativo"].ToString()=="2")
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
						Utilitario.Helper.MostrarDatosEnCajaTexto(txtObservaciones.ID,dr["Observaciones"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hCta",dr["SUBCUENTA"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hCo",dr["idcentroOperativo"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hEntidad",dr["Ent"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hNumDocAna",dr["Num_Doc_Ana"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hNumAsto",dr["Num_Asto"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hMes",Convert.ToDateTime(dr["FechaAsto"].ToString()).Month.ToString() )
						,Helper.MostrarDatosEnCajaTexto("hPeriodo",Convert.ToDateTime(dr["FechaAsto"].ToString()).Year.ToString() )
						,Helper.MostrarDatosEnCajaTexto("hDesc",dr["descrip"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hAbono",dr["abono"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hCargo",dr["cargo"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hIdProv",dr["idCtasporCobrarPorProvisionar"].ToString())
						);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
						Utilitario.Helper.MostrarDatosEnCajaTexto(txtObservaciones.ID,dr["Observaciones"].ToString())
						,Helper.MostrarDatosEnCajaTexto("hIdProv",dr["idCtasporCobrarPorProvisionar"].ToString())
						);
				}

//				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
//					Utilitario.Helper.MostrarDatosEnCajaTexto(txtObservaciones.ID,dr["Observaciones"].ToString())
//					,Helper.MostrarDatosEnCajaTexto("hCta"      , Cta)
//					,Helper.MostrarDatosEnCajaTexto("hCo"       , Co)
//					,Helper.MostrarDatosEnCajaTexto("hEntidad"  , Entidad)
//					,Helper.MostrarDatosEnCajaTexto("hNumDocAna", NumDocAna)
//					,Helper.MostrarDatosEnCajaTexto("hNumAsto"  , NumAsto)
//					,Helper.MostrarDatosEnCajaTexto("hMes"      , Mes)
//					,Helper.MostrarDatosEnCajaTexto("hPeriodo"  , Periodo)
//					,Helper.MostrarDatosEnCajaTexto("hDesc"     , Desc)
//					,Helper.MostrarDatosEnCajaTexto("hAbono"    , Abono)
//					,Helper.MostrarDatosEnCajaTexto("hCargo"    , Cargo)
//					,Helper.MostrarDatosEnCajaTexto("hIdProv"   , IdProv)
//					);
			
				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				
				e.Item.Cells[6].Text = acumCantidadTotal.ToString(Utilitario.Constantes.FORMATODECIMAL4);

				
			}
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,e.NewPageIndex);
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			DataTable dt;

			if(ViewState["tabla"]==null)
			{
				dt = this.ObtenerDatos(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),Convert.ToInt32(Page.Request.Params[KEYQID2]), Convert.ToInt32(Page.Request.Params[KEYQPORPROVISIONAR]) );
				dt = Helper.TablePersonalizado(dt,"fecha");
				ViewState["tabla"]=dt;
			}

			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(((DataTable)ViewState["tabla"])
				,"razonsocial" + ";DEUDOR"
				,"nroentidad" + ";IDENTIFICACION"
				,"num_doc_ana" + ";REFERENCIA"
				,"Fecha"+ ";FECHA"
				);
		}

		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnProvision_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.PasaraPorProvisionar();
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
		private void Totalizar(DataView dwTotales)
		{
			if (dwTotales !=null)
			{
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				acumCantidadTotal = Convert.ToDouble(oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwTotales,"saldo"));
			}
		}
		private void ibtnJudicial_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					this.PasaraJudiciales();
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

		private void ibtnAbrir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
//			//Helper.GenerarExcelCompleto(this,grid,ObtenerDatos(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),Convert.ToInt32(Page.Request.Params[KEYQID2]), Convert.ToInt32(Page.Request.Params[KEYQPORPROVISIONAR]) ));
////
////			StringBuilder sb = new StringBuilder();
////			StringWriter sw = new StringWriter(sb);
////			HtmlTextWriter htw = new HtmlTextWriter(sw);
////			
////			Page page = new Page();
////			HtmlForm form = new HtmlForm();
////			
////			grid.DataSource = this.ObtenerDatos(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),Convert.ToInt32(Page.Request.Params[KEYQID2]), Convert.ToInt32(Page.Request.Params[KEYQPORPROVISIONAR]) );
////			grid.AllowPaging=false;
////			grid.AllowSorting=false;
////			///grid.DataBind();
////			grid.EnableViewState = false;
////
////			page.DesignerInitialize(); 
////			page.Controls.Add(form);
////			form.Controls.Add(grid);
////			//ClearControls(grid);
////			page.RenderControl(htw);
////			
////			this.Response.Clear();
////			this.Response.Buffer = true;
////			this.Response.ContentType ="application/vnd.ms-excel";
////			//Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
////			this.Response.Charset = String.Empty;
////			this.Response.ContentEncoding = Encoding.Default;
////		
////			this.Response.Write(sb.ToString());
////			this.Response.End();
//
//			StringBuilder sb = new StringBuilder();
//			StringWriter sw = new StringWriter(sb);
//			HtmlTextWriter htw = new HtmlTextWriter(sw);
//
//			Page page = new Page();
//			HtmlForm form = new HtmlForm();
//
//			grid.EnableViewState = false;
//
//			// Deshabilitar la validación de eventos, sólo asp.net 2
//			//page.EnableEventValidation = false; 
//
//			// Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
//			page.DesignerInitialize(); 
//
//			page.Controls.Add(form);
//			form.Controls.Add(grid);
//			
//			
//			grid.DataSource = this.ObtenerDatos(Convert.ToInt32(Page.Request.Params[KEYQIDCENTROOPERATIVO]),Convert.ToInt32(Page.Request.Params[KEYQIDCUENTAPORCOBRARPAGAR]),Convert.ToInt32(Page.Request.Params[KEYQID2]), Convert.ToInt32(Page.Request.Params[KEYQPORPROVISIONAR]) );
//			grid.AllowPaging=false;
//			grid.AllowSorting=false;
//			grid.DataBind();
//
//			page.RenderControl(htw);
//
//			Response.Clear();
//			Response.Buffer = true;
//			Response.ContentType = "application/vnd.ms-excel";
//			//Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
//			Response.Charset = "UTF-8";
//			Response.ContentEncoding = Encoding.Default;
//			Response.Write(sb.ToString());
//			Response.End();
		

		}
		
	}
}
