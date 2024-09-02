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
using NullableTypes;
namespace SIMA.SimaNetWeb.GestionFinanciera.CuentasPorCobrarPagar.Directorio
{
	/// <summary>
	/// Summary description for AdministrarObservacionesCuentasPorCobrarPagar.
	/// </summary>
	public class AdministrarObservacionesCuentasPorCobrarPagar : System.Web.UI.Page,IPaginaBase
	{
		#region Controles

		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminarFiltro;
		protected System.Web.UI.WebControls.ImageButton ibtnFiltrar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HidCO;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hnumdocana;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hnroruc;
		protected projDataGridWeb.DataGridWeb gridDiversasAccionistas;
		protected projDataGridWeb.DataGridWeb gridDiversasPrestamoPersonal;
		protected projDataGridWeb.DataGridWeb gridDiversasPrestamosTerceros;
		protected projDataGridWeb.DataGridWeb gridDiverasReclamosTerceros;
		protected projDataGridWeb.DataGridWeb gridDiversasIntereses;
		protected projDataGridWeb.DataGridWeb gridDiverasOtras;
		protected projDataGridWeb.DataGridWeb gridJudicialesProvicionar;
		protected projDataGridWeb.DataGridWeb gridComercial;
		protected projDataGridWeb.DataGridWeb gridOtrosComercial;
		protected System.Web.UI.WebControls.Label lblMensajeComercial;
		protected System.Web.UI.WebControls.Label lblMensajeDiversasAccionistas;
		protected System.Web.UI.WebControls.Label lblMensajeDiversasPrestamosPersonal;
		protected System.Web.UI.WebControls.Label lblMensajesDiversasPrestamosTerceros;
		protected System.Web.UI.WebControls.Label lblMensajeDiversasReclamosTerceros;
		protected System.Web.UI.WebControls.Label lblMensajeDiversasIntereses;
		protected System.Web.UI.WebControls.Label lblMensajeDiversasOtras;
		protected System.Web.UI.WebControls.Label lblMensajeJudiciales;
		protected System.Web.UI.WebControls.Label lblMensajeOtrosComercial;
		//DataTable dt;
		#endregion
	
		#region Constantes
		NullableDouble acumCantidadTotal;
		double TotImporte;
		double TotAmortizado;
		double TotSaldo;
		const int IDSUBCUENTAJUDICIAL=10;
		const string URLDETALLE="DetalleAdministrarObservacionesCuentasPorCobrarPagar.aspx?";
		const string KEYQIDCENTROOPERATIVO="IdCentro";
		const string KEYQNUMDOCANA="NUMDOCANA";
		const string KEYQNRORUC="NRORUC";
		const string KEYQCONCEPTO = "concepto";
		const int	 CUENTAPORCOBRAR=0;
		const int	 CUENTAPORPAGAR=1;
		const int IDENTIDAD = 4;
		const string KEYQSUBCUENTARUBRO = "subcuentarubro";
		const string KEYQSUBCUENTA = "subcuenta";
		string JSVERIFICARSELECCION = "return verificarSeleccionRb('HidCO','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		const string ALERTA = "../../../imagenes/alert.gif";
		protected System.Web.UI.HtmlControls.HtmlInputHidden hOrdenGrilla;
		const string KEYQIDENTIDAD="KEYQIDENTIDAD";
		const string KEYQCUENTACONTABLE="KEYQCUENTACONTABLE";
		const string KEYQNROCLIENTE="KEYQNROCLIENTE";
		const string KEYQIDTIPOCUENTA="KEYQIDTIPOCUENTA";
		const string KEYQIDCUENTA="KEYQIDCUENTA";
		const string KEYQIDSUBCUENTA="KEYQIDSUBCUENTA";
		DataTable dtJudiciales;
		
		const string CONTROLIMGBUTTON = "imgCaducidad";


	
		#endregion

		private int idCentroOperativo
		{
			get{ return Convert.ToInt32(Page.Request.QueryString[KEYQIDCENTROOPERATIVO]);}
		}

		private int idConcepto
		{
			get{ return Convert.ToInt32(Page.Request.QueryString[KEYQCONCEPTO]);}
		}
		private int idSubCuentaRubro
		{
			get{ return Convert.ToInt32(Page.Request.QueryString[KEYQSUBCUENTARUBRO]);}
		}
		private int idSubCuenta
		{
			get{ return Convert.ToInt32(Page.Request.QueryString[KEYQSUBCUENTA]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.LlenarJScript();
					//this.ConfigurarAccesoControles();
					//Helper.ReiniciarSession();
					//LlenarCombos();
					//Helper.SeleccionarItemCombos(this);
					//HidCO.Value=String.Empty;
					this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value));
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
			this.ibtnFiltrar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnFiltrar_Click);
			this.ibtnEliminarFiltro.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminarFiltro_Click);
			this.gridComercial.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridComercial_SortCommand);
			this.gridComercial.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridComercial_PageIndexChanged);
			this.gridComercial.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridComercial_ItemDataBound);
			this.gridDiversasAccionistas.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridDiversasAccionistas_SortCommand);
			this.gridDiversasAccionistas.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridDiversasAccionistas_PageIndexChanged);
			this.gridDiversasAccionistas.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDiversasAccionistas_ItemDataBound);
			this.gridDiversasPrestamoPersonal.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridDiversasPrestamoPersonal_SortCommand);
			this.gridDiversasPrestamoPersonal.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridDiversasPrestamoPersonal_PageIndexChanged);
			this.gridDiversasPrestamoPersonal.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDiversasPrestamoPersonal_ItemDataBound);
			this.gridDiversasPrestamosTerceros.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridDiversasPrestamosTerceros_SortCommand);
			this.gridDiversasPrestamosTerceros.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridDiversasPrestamosTerceros_PageIndexChanged);
			this.gridDiversasPrestamosTerceros.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDiversasPrestamosTerceros_ItemDataBound);
			this.gridDiverasReclamosTerceros.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridDiverasReclamosTerceros_SortCommand);
			this.gridDiverasReclamosTerceros.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridDiverasReclamosTerceros_PageIndexChanged);
			this.gridDiverasReclamosTerceros.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDiverasReclamosTerceros_ItemDataBound);
			this.gridDiversasIntereses.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridDiversasIntereses_SortCommand);
			this.gridDiversasIntereses.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridDiversasIntereses_PageIndexChanged);
			this.gridDiversasIntereses.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDiversasIntereses_ItemDataBound);
			this.gridDiverasOtras.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridDiverasOtras_SortCommand);
			this.gridDiverasOtras.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridDiverasOtras_PageIndexChanged);
			this.gridDiverasOtras.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridDiverasOtras_ItemDataBound);
			this.gridJudicialesProvicionar.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridJudicialesProvicionar_SortCommand);
			this.gridJudicialesProvicionar.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridJudicialesProvicionar_PageIndexChanged);
			this.gridJudicialesProvicionar.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridJudicialesProvicionar_ItemDataBound);
			this.gridOtrosComercial.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.gridOtrosComercial_SortCommand);
			this.gridOtrosComercial.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridOtrosComercial_PageIndexChanged);
			this.gridOtrosComercial.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridOtrosComercial_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			try
			{
				ObtenerDatos();
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

		
	
		public void LlenarDatos()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			//ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCION);
			//ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.HistorialIrAdelantePersonalizado("hGridPaginaSort","hGridPagina",ddlbConcepto.ID,ddblSubCuenta.ID,ddblSubCuentaRubro.ID));
			//btnComsultar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);
			//ddblSubCuentaRubro.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,Utilitario.Constantes.POPUPDEESPERA);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.RegistrarJScript implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.Imprimir implementation
		}
		public void Imprimir()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarObservacionesCuentasPorCobrarPagar.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void LlenarGrillaPersonalizado(DataTable dt,DataGrid grid, string columnaOrdenar, int indicePagina, Label lblResultado)
		{
			if(dt!=null)
			{
				
				DataView dw = dt.DefaultView;
				
				dw.RowFilter = Helper.ObtenerFiltro();
				dw.Sort = columnaOrdenar ;
				grid.DataSource = dw;
				grid.Columns[1].FooterText=dw.Count.ToString();
				grid.CurrentPageIndex =indicePagina;

				
				
				lblResultado.Visible=false;
				
			}
			else
			{
				grid.DataSource = null;
				lblResultado.Visible=true;
				lblResultado.Text = "No existen registros";
			}
			try
			{
				grid.DataBind();
			
				
			}
			catch(Exception o)	
			{
				string a = o.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}			

		}

		private void ObtenerDatos()
		{
			CCuentasPorCobrarPagar oCCuentasPorCobrarPagar = new CCuentasPorCobrarPagar();
			if(idSubCuentaRubro==3 || idSubCuentaRubro==6 || idSubCuentaRubro==7)
			{
				
				#region JudicialesProvisionar
				if(idSubCuentaRubro==3)
				 dtJudiciales=oCCuentasPorCobrarPagar.ConsultarResumenCtasPorCobrarNivel3Judiciales(idCentroOperativo,
					idSubCuentaRubro,
					IDSUBCUENTAJUDICIAL, 
					0);
				else if(idSubCuentaRubro==6)
					dtJudiciales=oCCuentasPorCobrarPagar.ConsultarResumenCtasPorCobrarNivel3Judiciales(idCentroOperativo,
						3,
						IDSUBCUENTAJUDICIAL, 
						1);
				else
					dtJudiciales=oCCuentasPorCobrarPagar.ConsultarResumenCtasPorCobrarNivel3Judiciales(idCentroOperativo,
						3,
						IDSUBCUENTAJUDICIAL, 
						0);
				if(dtJudiciales!=null)
				{
					dtJudiciales = Helper.TablePersonalizado(dtJudiciales,"Fecha");
					DataView dw= dtJudiciales.DefaultView;
					this.Totalizar(dw,"saldo");
				}
				gridJudicialesProvicionar.Visible=true;
				gridJudicialesProvicionar.PageSize=10;
				LlenarGrillaPersonalizado(dtJudiciales,gridJudicialesProvicionar,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeJudiciales);
				#endregion
			}
			else if(idSubCuentaRubro==1 || idSubCuentaRubro==4)
			{
				#region Comercial
				DataTable dt= oCCuentasPorCobrarPagar.ConsultarDetalleSubCuentaPorCobrarPagar(idCentroOperativo,
					idConcepto
					,idSubCuentaRubro
					,idSubCuenta);
				if(idConcepto == CUENTAPORCOBRAR)
				{
					gridComercial.Columns[1].HeaderText = idSubCuenta==3?"PROVEEDOR":"CLIENTE";
				}
				else
				{gridComercial.Columns[1].HeaderText = "PROVEEDOR";}

			
				if(dt!=null)
				{
						dt = Helper.TablePersonalizado(dt,"FechaEmision");
						DataView dw=dt.DefaultView;
						this.Totalizar(dw,Enumerados.FINColumnaResumenCuentasPorPagar.TotalEnSoles.ToString());
				}

				gridComercial.Visible=true;
				gridComercial.PageSize=10;
			
				
				LlenarGrillaPersonalizado(dt,gridComercial,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeComercial);
				#endregion
			}
			else if(idSubCuentaRubro==5)
			{
				#region ComercialOtras
				DataTable dt= oCCuentasPorCobrarPagar.ConsultarDetalleSubCuentaPorCobrarPagar(idCentroOperativo,
					idConcepto
					,idSubCuentaRubro
					,idSubCuenta);
				if(dt!=null)
				{
					dt = Helper.TablePersonalizado(dt,"FechaEmision");
					DataView dw=dt.DefaultView;
					this.Totalizar(dw,Enumerados.FINColumnaResumenCuentasPorPagar.TotalEnSoles.ToString());
				}
			
				gridOtrosComercial.Visible=true;
				gridOtrosComercial.PageSize=10;
				LlenarGrillaPersonalizado(dt,gridOtrosComercial,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeOtrosComercial);
				#endregion
			}
			else if(idSubCuentaRubro==2)
			{	
				#region CtasPorCobrarDiversas
				if(idSubCuenta==4)
				{
					#region AportesAccionistas
					DataTable dt=oCCuentasPorCobrarPagar.ConsultarCuentasDiversasAportesAccionistas(idConcepto,
						idCentroOperativo
						,idSubCuentaRubro
						,idSubCuenta);
					if(dt!=null)
					{
						dt = Helper.TablePersonalizado(dt,"Fecha");
						DataView dw= dt.DefaultView;
						this.Totalizar(dw,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Importe.ToString());
					}
					
					gridDiversasAccionistas.Visible=true;
					gridDiversasAccionistas.PageSize=10;
					LlenarGrillaPersonalizado(dt,gridDiversasAccionistas,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeDiversasAccionistas);
					#endregion
			
				}

				if(idSubCuenta==5)
				{
					#region PrestamosPersonal
					DataTable dt=oCCuentasPorCobrarPagar.ConsultarCuentasDiversasPrestamosaPersonal(IDENTIDAD,
						idCentroOperativo
						,idSubCuentaRubro
						,idSubCuenta);
					if(dt!=null)
					{
							dt = Helper.TablePersonalizado(dt,"Fecha");
							DataView dw= dt.DefaultView;
							this.Totalizar(dw,Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Importe.ToString(),
											Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Amortizado.ToString(),
											Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaPersonal.Saldo.ToString());
					}
					gridDiversasPrestamoPersonal.Visible=true;
					gridDiversasPrestamoPersonal.PageSize=10;
					LlenarGrillaPersonalizado(dt,gridDiversasPrestamoPersonal,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeDiversasPrestamosPersonal);
					#endregion
			
				}
				if(idSubCuenta==6)
				{
					#region PrestamosTerceros
					DataTable dt=oCCuentasPorCobrarPagar.ConsultarCuentasDiversasPrestamosaTerceros(idConcepto,
						idCentroOperativo
						,idSubCuentaRubro
						,idSubCuenta);
					if(dt!=null)
					{
						dt = Helper.TablePersonalizado(dt,"Fecha");
						DataView dw= dt.DefaultView;
						this.Totalizar(dw,Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaTerceros.Importe.ToString(),
							Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaTerceros.Amortizado.ToString(),
							Enumerados.FINColumnaCuentaporCobrarDiversasPrestamosaTerceros.Saldo.ToString());
					}
					gridDiversasPrestamosTerceros.Visible=true;
					gridDiversasPrestamosTerceros.PageSize=10;
					LlenarGrillaPersonalizado(dt,gridDiversasPrestamosTerceros,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajesDiversasPrestamosTerceros);
					#endregion

				}

				if(idSubCuenta==7)
				{
					#region ReclamosTerceros
					DataTable dt=oCCuentasPorCobrarPagar.ConsultarCuentasDiversasReclamosaTerceros(idConcepto,
						idCentroOperativo
						,idSubCuentaRubro
						,idSubCuenta);
					if(dt!=null)
					{
						dt = Helper.TablePersonalizado(dt,"Fecha");
						DataView dw= dt.DefaultView;
						this.Totalizar(dw,Enumerados.FINColumnaCuentaporCobrarDiversasReclamosaTerceros.Importe.ToString(),
							Enumerados.FINColumnaCuentaporCobrarDiversasReclamosaTerceros.Amortizado.ToString(),
							Enumerados.FINColumnaCuentaporCobrarDiversasReclamosaTerceros.Saldo.ToString());
					}
					gridDiverasReclamosTerceros.Visible=true;
					gridDiverasReclamosTerceros.PageSize=10;
					LlenarGrillaPersonalizado(dt,gridDiverasReclamosTerceros,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeDiversasReclamosTerceros);
					#endregion
				}

				if(idSubCuenta==8)
				{
					#region Intereses
					DataTable dt=oCCuentasPorCobrarPagar.ConsultarCuentasDiversasIntereses(idConcepto,
						idCentroOperativo
						,idSubCuentaRubro
						,idSubCuenta);
					if(dt!=null)
					{
						dt = Helper.TablePersonalizado(dt,"Fecha");
						DataView dw= dt.DefaultView;
						this.Totalizar(dw,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Importe.ToString(),
							String.Empty,
							Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Saldo.ToString());
					}
					gridDiversasIntereses.Visible=true;
					gridDiversasIntereses.PageSize=10;
					LlenarGrillaPersonalizado(dt,gridDiversasIntereses,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeDiversasIntereses);

					#endregion
				}

				if(idSubCuenta==9)
				{
					#region Otros
					DataTable dt=oCCuentasPorCobrarPagar.ConsultarCuentasDiversasOtros(idConcepto,
						idCentroOperativo
						,idSubCuentaRubro
						,idSubCuenta);
					if(dt!=null)
					{
						dt = Helper.TablePersonalizado(dt,"Fecha");
						DataView dw= dt.DefaultView;
						this.Totalizar(dw,Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Importe.ToString(),
							String.Empty,
							Enumerados.FINColumnaCuentaporCobrarDiversasOtros.Saldo.ToString());
					}
					gridDiverasOtras.Visible=true;
					gridDiverasOtras.PageSize=10;
					LlenarGrillaPersonalizado(dt,gridDiverasOtras,this.hOrdenGrilla.Value,Convert.ToInt32(this.hGridPagina.Value),lblMensajeDiversasOtras);

					#endregion
				}
				#endregion
			}
		}
//		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
//		{
//			
//			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
//			{
//				
//				DataRowView drv = (DataRowView)e.Item.DataItem;
//				DataRow dr = drv.Row;
//				
//				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Utilitario.Helper.MostrarDatosEnCajaTexto(HidCO.ID,dr["idcentrooperativo"].ToString()),
//					Utilitario.Helper.MostrarDatosEnCajaTexto(Hnroruc.ID,dr["nroruc"].ToString()),
//					Utilitario.Helper.MostrarDatosEnCajaTexto(Hnumdocana.ID,dr["num_doc_ana"].ToString()));
//				
//
//											
//					
//				//e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado("hGridPagina","hGridPaginaSort","ddlbConcepto","ddblSubCuenta","ddblSubCuentaRubro",ddblCentroOperativo.ID.ToString()));
//
//				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[5].FindControl(CONTROLIMGBUTTON);	
//				if (Convert.ToString(dr["observacion"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
//				{
//					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
//						Helper.PopupBusqueda(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
//						dr["idcentrooperativo"].ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
//						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
//						dr["nroruc"].ToString() +  
//						Utilitario.Constantes.SIGNOAMPERSON +
//						KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
//						dr["num_doc_ana"]+
//						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
//						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),650,360)+
//						Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
//					ibtn1.ImageUrl = ALERTA;
//				}
//				else
//				{
//					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
//						Helper.PopupBusqueda(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
//						dr["idcentrooperativo"].ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
//						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
//						dr["nroruc"].ToString() +  
//						Utilitario.Constantes.SIGNOAMPERSON +
//						KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
//						dr["num_doc_ana"]+
//						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
//						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),650,360)+
//						Utilitario.Constantes.SIGNOPUNTOYCOMA + Utilitario.Constantes.POPUPDEESPERA);
//					ibtn1.Visible = false;
//				}
//
//				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
//				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
//				e.Item.Cells[0].Font.Underline=true;
//				Helper.FiltroporSeleccionConfiguraColumna(e,grid);
//			}
//		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,e.NewPageIndex);
		}



		private void ibtnEliminarFiltro_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Helper.EliminarFiltro();
		}

		private void ibtnFiltrar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
//			ltlMensaje.Text = Utilitario.Helper.ElaborarFiltro(ObtenerDatos()
//				,"razonsocial" + ";RAZON SOCIAL/ACCIONISTA/PROVEEDOR/PERSONAL"
//				,"co" + ";CENTRO OPERATIVO"
//				,"nroruc" + ";NRO RUC");
				
		}
		private void Totalizar(DataView dwTotales,string columna)
		{
			if (dwTotales !=null)
			{
				CFuncionesEspeciales oCFuncionesEspeciales=new CFuncionesEspeciales();
				acumCantidadTotal = NullableDouble.Parse(oCFuncionesEspeciales.CalcularMontosTotalesDataFile(dwTotales,columna));
			}
		}

		private void Totalizar(DataView dwTotales, string importe, string amortizado, string saldo)
		{
			if (dwTotales !=null)
			{
				double[] aArreglo;
				if(importe!=String.Empty)
				{
					aArreglo = Helper.TotalizarDataView(dwTotales,importe);
					TotImporte = aArreglo[0];
				}
				if(amortizado!=String.Empty)
				{
					aArreglo = Helper.TotalizarDataView(dwTotales,amortizado);
					TotAmortizado = aArreglo[0];
				}
				aArreglo = Helper.TotalizarDataView(dwTotales,saldo);
				TotSaldo = aArreglo[0];

			}
		}
		#region eventosGrillaComercial
		private void gridComercial_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridComercial.CurrentPageIndex,gridComercial.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
			System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[5].FindControl(CONTROLIMGBUTTON);	
			if (Convert.ToString(dr["observacion"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
			{
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA + Utilitario.Constantes.SIGNOPUNTOYCOMA + 
					Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
					idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
					KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
					dr["NroEntidad"].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
					dr["num_doc_ana"]+
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
					
				ibtn1.ImageUrl = ALERTA;
			}
			else
			{
				e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
					Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
					idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
					KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
					dr["NroEntidad"].ToString() +  
					Utilitario.Constantes.SIGNOAMPERSON +
					KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
					dr["num_doc_ana"]+
					Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
					Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");

				ibtn1.Visible = false;
			}
				
				
				
				e.Item.ToolTip = dr[Enumerados.FINColumnaResumenCuentasPorPagar.NroRuc.ToString()].ToString();

				//TextBox txt=(TextBox)e.Item.Cells[6].FindControl(CONTROLTEXTO);	
				//txt.Text = NRORUC + dr[Enumerados.FINColumnaResumenCuentasPorPagar.Descripcion.ToString()].ToString();

				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,gridComercial);
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				double monto = NullableIsNull.IsNullDouble(acumCantidadTotal,Utilitario.Constantes.POSICIONINDEXCERO);
				e.Item.Cells[4].Text = monto.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}	
		}

		private void gridComercial_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridComercial_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hOrdenGrilla.Value,Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaAccionistas
		private void gridDiversasAccionistas_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridDiversasAccionistas.CurrentPageIndex,gridDiversasAccionistas.PageSize,e.Item.ItemIndex);
				Helper.FiltroporSeleccionConfiguraColumna(e,gridDiversasAccionistas);

				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");

					ibtn1.Visible = false;
				}

			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[2].Text =Convert.ToDouble(acumCantidadTotal).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}	
		}

		private void gridDiversasAccionistas_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiversasAccionistas.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridDiversasAccionistas_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventoGrillaPrestamoPersonal
		private void gridDiversasPrestamoPersonal_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridDiversasPrestamoPersonal.CurrentPageIndex,gridDiversasPrestamoPersonal.PageSize,e.Item.ItemIndex);
				
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + IDENTIDAD.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
	
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + IDENTIDAD.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.Visible = false;
				}

				
				Helper.FiltroporSeleccionConfiguraColumna(e,gridDiversasPrestamoPersonal);
				e.Item.ToolTip = "CUENTA CONTABLE : " +dr["descripcioncuenta"].ToString();

			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[5].Text = TotImporte.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = TotAmortizado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[7].Text = TotSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}	
		}

		private void gridDiversasPrestamoPersonal_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiversasPrestamoPersonal.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridDiversasPrestamoPersonal_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaPrestamosTerceros
		private void gridDiversasPrestamosTerceros_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridDiversasPrestamosTerceros.CurrentPageIndex,gridDiversasPrestamosTerceros.PageSize,e.Item.ItemIndex);

				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNROCLIENTE + Utilitario.Constantes.SIGNOIGUAL + dr["nrocliente"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNROCLIENTE + Utilitario.Constantes.SIGNOIGUAL + dr["nrocliente"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.Visible = false;
				}

				//Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.PopupDialogoModal(URLPAGINADETALLE + Parametros ,750,500,true));
				Helper.FiltroporSeleccionConfiguraColumna(e,gridDiversasPrestamosTerceros);

			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = TotImporte.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = TotAmortizado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = TotSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void gridDiversasPrestamosTerceros_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiversasPrestamosTerceros.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridDiversasPrestamosTerceros_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaReclamosTerceros
		private void gridDiverasReclamosTerceros_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridDiverasReclamosTerceros.CurrentPageIndex,gridDiverasReclamosTerceros.PageSize,e.Item.ItemIndex);
				
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
				
					ibtn1.Visible = false;
				}
				
				Helper.FiltroporSeleccionConfiguraColumna(e,gridDiverasReclamosTerceros);
			
			
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = TotImporte.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = TotAmortizado.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = TotSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}		
		}

		private void gridDiverasReclamosTerceros_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiverasReclamosTerceros.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridDiverasReclamosTerceros_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaIntereses
		private void gridDiversasIntereses_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridDiversasIntereses.CurrentPageIndex,gridDiversasIntereses.PageSize,e.Item.ItemIndex);

				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.Visible = false;
				}
				
				//Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.PopupDialogoModal(URLPAGINADETALLE + Parametros ,750,500,true));
				Helper.FiltroporSeleccionConfiguraColumna(e,gridDiversasIntereses);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = TotImporte.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = TotSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}		
		}

		private void gridDiversasIntereses_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiversasIntereses.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridDiversasIntereses_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaOtras
		private void gridDiverasOtras_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridDiverasOtras.CurrentPageIndex,gridDiverasOtras.PageSize,e.Item.ItemIndex);

				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[2].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						Utilitario.Constantes.KEYMODOPAGINA +  Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQIDENTIDAD + Utilitario.Constantes.SIGNOIGUAL + dr["identidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + dr["ruc"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON+
						KEYQCUENTACONTABLE + Utilitario.Constantes.SIGNOIGUAL + dr["cuentacontable"].ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQIDTIPOCUENTA + Utilitario.Constantes.SIGNOIGUAL + idConcepto.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuentaRubro.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON + 
						KEYQIDSUBCUENTA + Utilitario.Constantes.SIGNOIGUAL + idSubCuenta.ToString()+
						Utilitario.Constantes.SIGNOAMPERSON +  Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
					
					ibtn1.Visible = false;
				}

				//Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.PopupDialogoModal(URLPAGINADETALLE + Parametros ,750,500,true));
				Helper.FiltroporSeleccionConfiguraColumna(e,gridDiverasOtras);
			}

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[4].Text = TotImporte.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text = TotSaldo.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}		
		}

		private void gridDiverasOtras_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiverasOtras.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);

		}
		
		private void gridDiverasOtras_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaJudiciales
		private void gridJudicialesProvicionar_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[3].ToolTip="Identificacion";
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				e.Item.Cells[6].Text=Convert.ToDouble(dr["saldo"]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(gridJudicialesProvicionar.CurrentPageIndex,gridJudicialesProvicionar.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[5].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observaciones"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
						dr["nroruc"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
						dr["num_doc_ana"]+
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+";"+"document.location.reload();");
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
						dr["nroruc"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
						dr["num_doc_ana"]+
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+";"+"document.location.reload();");
					
					ibtn1.Visible = false;
				}
				
				
				Helper.FiltroporSeleccionConfiguraColumna(e,gridJudicialesProvicionar);


			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[6].Text = Convert.ToDouble(acumCantidadTotal).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}

		}

		private void gridJudicialesProvicionar_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			hGridPagina.Value = e.NewPageIndex.ToString();
			gridDiversasPrestamoPersonal.CurrentPageIndex = e.NewPageIndex;
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value,e.NewPageIndex);
		}

		private void gridJudicialesProvicionar_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hOrdenGrilla.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hOrdenGrilla.Value, Helper.ObtenerIndicePagina());
		}
		#endregion

		#region eventosGrillaOtrosComercial
		private void gridOtrosComercial_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{e.Item.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Constantes.POPUPDEESPERA);}

			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				e.Item.Cells[Utilitario.Constantes.POSICIONCONTADOR].Text = Helper.ObtenerIndicedeRegistro(gridOtrosComercial.CurrentPageIndex,gridOtrosComercial.PageSize,e.Item.ItemIndex);
				e.Item.Cells[0].ForeColor= System.Drawing.Color.Blue;
				e.Item.Cells[0].Font.Underline=true;
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				Helper.FiltroporSeleccionConfiguraColumna(e,gridOtrosComercial);

				if(idSubCuenta == 14 && idSubCuentaRubro == 5)
				{
					e.Item.Cells[1].Text = String.Empty;
				}
				else if(idSubCuenta == 15 && idSubCuentaRubro == 5)
				{
					e.Item.Cells[1].Text = String.Empty;
				}
				System.Web.UI.WebControls.Image ibtn1=(System.Web.UI.WebControls.Image)e.Item.Cells[5].FindControl(CONTROLIMGBUTTON);	
				if (Convert.ToString(dr["observacion"])== String.Empty && Convert.ToString(dr["concepto"])== String.Empty)
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
						dr["NroEntidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
						dr["num_doc_ana"]+
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.N.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.ImageUrl = ALERTA;
				}
				else
				{
					e.Item.Cells[0].Attributes.Add(Utilitario.Constantes.EVENTOCLICK,
						Helper.WindowShowModalDialogCadenaJava(URLDETALLE+KEYQIDCENTROOPERATIVO + Utilitario.Constantes.SIGNOIGUAL + 
						idCentroOperativo.ToString() +  Utilitario.Constantes.SIGNOAMPERSON  +
						KEYQNRORUC + Utilitario.Constantes.SIGNOIGUAL + 
						dr["NroEntidad"].ToString() +  
						Utilitario.Constantes.SIGNOAMPERSON +
						KEYQNUMDOCANA + Utilitario.Constantes.SIGNOIGUAL + 
						dr["num_doc_ana"]+
						Utilitario.Constantes.SIGNOAMPERSON + Utilitario.Constantes.KEYMODOPAGINA +  
						Utilitario.Constantes.SIGNOIGUAL + Enumerados.ModoPagina.M.ToString(),360,650)+Utilitario.Constantes.SIGNOPUNTOYCOMA +"document.location.reload();");
						
					ibtn1.Visible = false;
				}
			}
			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[2].Text = Convert.ToDouble(acumCantidadTotal).ToString(Utilitario.Constantes.FORMATODECIMAL4);
			}
		}

		private void gridOtrosComercial_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,e.NewPageIndex);
		}

		private void gridOtrosComercial_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			this.hGridPaginaSort.Value = Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		#endregion
	
	}
}
