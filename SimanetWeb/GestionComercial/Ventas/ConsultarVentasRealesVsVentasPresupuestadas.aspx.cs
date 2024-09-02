using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionComercial.Ventas
{
	/// <summary>
	/// Summary description for ConsultarVentasRealesVsVentasPresupuestadas.
	/// </summary>
	public class ConsultarVentasRealesVsVentasPresupuestadas: System.Web.UI.Page,IPaginaBase
	{
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label lblCallao;
		protected System.Web.UI.WebControls.Label lblChimbote;
		protected System.Web.UI.WebControls.Label lblIquitos;
		protected projDataGridWeb.DataGridWeb dgConsultaLogroCallao;
		protected System.Web.UI.WebControls.Label lblResultadoCallao;
		protected System.Web.UI.WebControls.Label lblResultadoIquitos;
		protected System.Web.UI.WebControls.Label lblResultadoChimbote;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb dgConsultaLogroChimbote;
		protected projDataGridWeb.DataGridWeb dgConsultaLogroIquitos;
		protected System.Web.UI.WebControls.ImageButton ibtnAtras;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		
		#region Constantes
		
		//Ordenamiento
		const string COLORDENAMIENTO = "lineanegocio";

		//JScript

		//Columnas DataTable

		//Nombres de Controles
		
		//Paginas
		const string URLIMPRESION = "PopupImpresionConsultarVentasRealesVsVentasPresupuestadas.aspx";
	
		//Key Session y QueryString
		
		//Otros
		const string GRILLAVACIACALLAO ="No existe ninguna Venta Ejecutada en SIMA CALLAO.";
		const string GRILLAVACIACHIMBOTE ="No existe ninguna Venta Ejecutada en SIMA CHIMBOTE.";
		const string GRILLAVACIAIQUITOS ="No existe ninguna Venta Ejecutada en SIMA IQUITOS";

		const string TablaImpresion0 = "VentaCallao";
		const string TablaImpresion1 = "VentaChimbote";
		const string TablaImpresion2 = "VentaIquitos";

		const string NombreGlosaLogro = "%";
		const string ColumnoTitulo = "titulo";
		const int MontoCero = 1;
		const int MontoMenorMiles = 3;
		const int CantidadPosicionesBorrar = 4;

		const int PosicionItemEnero = 1;
		const int PosicionItemFebrero = 2;
		const int PosicionItemMarzo = 3;
		const int PosicionItemAbril = 4;
		const int PosicionItemMayo = 5;
		const int PosicionItemJunio = 6;
		const int PosicionItemJulio = 7;
		const int PosicionItemAgosto = 8;
		const int PosicionItemSetiembre = 9;
		const int PosicionItemOctubre = 10;
		const int PosicionItemNoviembre = 11;
		const int PosicionItemDiciembre = 12;
		const int PosicionDatoTotal = 13;

		#endregion Constantes

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					
					Helper.ReiniciarSession();

					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Comercial",this.ToString(),"Se consultaron las Ventas Reales Vs las Ventas Presupuestadas",Enumerados.NivelesErrorLog.I.ToString()));

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
			this.ibtnImprimir.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnImprimir_Click);
			this.dgConsultaLogroCallao.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaLogroCallao_ItemDataBound);
			this.dgConsultaLogroChimbote.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaLogroChimbote_ItemDataBound);
			this.dgConsultaLogroIquitos.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgConsultaLogroIquitos_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataSet dsImprimir = new DataSet();

			//Grilla Callao
			CVentasReales oCVentasReales = new CVentasReales();
			DataTable dtVentasCallao = oCVentasReales.ConsultarLogroVentasRealesMensualPorCentroOperativo(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaCallao), Helper.FechaSimanet.ObtenerFechaSesion());
			if(dtVentasCallao!=null)
			{
				DataTable dtImpresion = dtVentasCallao.Copy();
				dtImpresion.TableName = TablaImpresion0;

				DataView dwVentasCallao = dtVentasCallao.DefaultView;
				dgConsultaLogroCallao.DataSource = dwVentasCallao;
				lblResultadoCallao.Visible = false;

				dsImprimir.Tables.Add(dtImpresion);
			}
			else
			{
				dgConsultaLogroCallao.DataSource = dtVentasCallao;
				lblResultadoCallao.Visible = true;
				lblResultadoCallao.Text = GRILLAVACIACALLAO;
			}
			
			try
			{
				dgConsultaLogroCallao.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaLogroCallao.DataBind();
			}

			//Grilla Chimbote
			DataTable dtVentasChimbote =  oCVentasReales.ConsultarLogroVentasRealesMensualPorCentroOperativo(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaChimbote), Helper.FechaSimanet.ObtenerFechaSesion());
			
			if(dtVentasChimbote!=null)
			{
				DataTable dtImpresion1 = dtVentasChimbote.Copy();
				dtImpresion1.TableName = TablaImpresion1;

				DataView dwVentasChimbote = dtVentasChimbote.DefaultView;
				dgConsultaLogroChimbote.DataSource = dwVentasChimbote;
				lblResultadoChimbote.Visible = false;
				
				dsImprimir.Tables.Add(dtImpresion1);
			}
			else
			{
				dgConsultaLogroChimbote.DataSource = dtVentasChimbote;
				lblResultadoChimbote.Visible = true;
				lblResultadoChimbote.Text = GRILLAVACIACHIMBOTE;
			}
			
			try
			{
				dgConsultaLogroChimbote.DataBind();
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaLogroChimbote.DataBind();
			}

			//Grilla Iquitos
			DataTable dtVentasIquitos =  oCVentasReales.ConsultarLogroVentasRealesMensualPorCentroOperativo(Convert.ToInt32(Enumerados.IdCentroOperativo.SimaIquitos), Helper.FechaSimanet.ObtenerFechaSesion());
			
			if(dtVentasIquitos!=null)
			{
				DataTable dtImpresion2 = dtVentasIquitos.Copy();
				dtImpresion2.TableName = TablaImpresion2;

				DataView dwVentasIquitos = dtVentasIquitos.DefaultView;
				dgConsultaLogroIquitos.DataSource = dwVentasIquitos;
				lblResultadoIquitos.Visible = false;
				
				dsImprimir.Tables.Add(dtImpresion2);
			}
			else
			{
				dgConsultaLogroIquitos.DataSource = dtVentasIquitos;
				lblResultadoIquitos.Visible = true;
				lblResultadoIquitos.Text = GRILLAVACIAIQUITOS;
			}
			
			try
			{
				dgConsultaLogroIquitos.DataBind();
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dsImprimir,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEVENTASREALESVSVENTASPRESUPUESTADAS));
			}
			catch(Exception ex)
			{
				string a = ex.Message;
				dgConsultaLogroIquitos.DataBind();
			}
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			ltlMensaje.Text = Helper.PopupImpresion(URLIMPRESION,750,500,false,false,false,true,true);
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.Exportar implementation
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
			// TODO:  Add ConsultarVentasRealesVsVentasPresupuestadas.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void ibtnImprimir_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.Imprimir();
		}

		private void dgConsultaLogroCallao_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(!dr[ColumnoTitulo].ToString().StartsWith(NombreGlosaLogro))
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}

				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaLogro))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}
		}

		private void dgConsultaLogroChimbote_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(!dr[ColumnoTitulo].ToString().StartsWith(NombreGlosaLogro))
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}

					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}

				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaLogro))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}
		}

		private void dgConsultaLogroIquitos_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;

				if(!dr[ColumnoTitulo].ToString().StartsWith(NombreGlosaLogro))
				{
					int int1 = dr[Enumerados.Meses.Enero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemEnero].Text = dr[Enumerados.Meses.Enero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemEnero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Febrero.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemFebrero].Text = dr[Enumerados.Meses.Febrero.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemFebrero].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Marzo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMarzo].Text = dr[Enumerados.Meses.Marzo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMarzo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Abril.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAbril].Text = dr[Enumerados.Meses.Abril.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAbril].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Mayo.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemMayo].Text = dr[Enumerados.Meses.Mayo.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemMayo].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Junio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJunio].Text = dr[Enumerados.Meses.Junio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJunio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Julio.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemJulio].Text = dr[Enumerados.Meses.Julio.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemJulio].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Agosto.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemAgosto].Text = dr[Enumerados.Meses.Agosto.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemAgosto].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemSetiembre].Text = dr[Enumerados.Meses.Setiembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemSetiembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Octubre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemOctubre].Text = dr[Enumerados.Meses.Octubre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemOctubre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemNoviembre].Text = dr[Enumerados.Meses.Noviembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemNoviembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionItemDiciembre].Text = dr[Enumerados.Meses.Diciembre.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionItemDiciembre].Text = Constantes.POSICIONCONTADOR.ToString();
					}
					
					int1 = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Length;
					
					if(int1 > MontoMenorMiles)
					{
						e.Item.Cells[PosicionDatoTotal].Text = dr[Enumerados.ColumnasVentasReales.total.ToString()].ToString().Remove(int1-CantidadPosicionesBorrar,CantidadPosicionesBorrar).Replace(Constantes.SIGNOCOMA,Constantes.ESPACIO);
					}
					else
					{
						e.Item.Cells[PosicionDatoTotal].Text = Constantes.POSICIONCONTADOR.ToString();
					}
				}

				if(e.Item.Cells[Constantes.POSICIONCONTADOR].Text.StartsWith(NombreGlosaLogro))
				{
					Helper.ConfigurarColorTotalesGrilla(e);
				}
				else
				{
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
			}
		}
	}
}