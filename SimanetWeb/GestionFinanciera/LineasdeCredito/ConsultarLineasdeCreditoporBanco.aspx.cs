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


namespace SIMA.SimaNetWeb.GestionFinanciera.LineasdeCredito
{
	/// <summary>
	/// Summary description for ConsultarLineasdeCreditoporBanco.
	/// </summary>
	public class ConsultarLineasdeCreditoporBanco : System.Web.UI.Page,IPaginaBase
	{
		#region Constantes
		
		const string  GRILLAVACIA="No existe";
		//Ordenamiento
		const string COLORDENAMIENTO = "Moneda";
		const string COLORDENAMIENTO2 = "Orden Asc";

		//Paginas
		const string URLPRINCIPAL = "ConsultarLineasdeCredito.aspx";
		
		//Key Session y QueryString
		//const string KEYQID = "idEntidadFin";
		//const string KEYQNOMBREBCO ="NombreBco";

		const string KEYIDENTIDADFINANCIERA = "idEF";
		const string KEYIDCENTRO ="IdCentro";

		const string NOMBREENTIDAD = "Nombre";
		const string KEYIDESTADO = "idEstado";
		const string TIPOFIANZA = "TFianza";//Descripcion
		const string KEYIDTIPOFZA = "TipoFza";//identificacion del tipo de la CartaFianza

		//Nuevo
		const string KEYIDTIPOCREDITO = "idTipoCredito";		
		const string KEYESTADOFIANZAP = "EstadoFianzaP";
		
		//decuento de letras
		const string KEYIDTIPOLETRADESC = "TipoDLetra";
		const string KEYIDNOMBRETIPODESC ="NomTipo";
		//
		const string KEYIDBENEFICIARIO="KEYIDBENEFICIARIO";


		const string KEYQMONTO = "MntAprob";

		// Campos de totales de la grilla
		const string CAMPO1 ="lblMontoCCR";
		const string CAMPO2 ="lblMontoCCCV";
		const string CAMPO3 ="lblMontoCFR";
		const string CAMPO4 ="lblMontoCFCV";
		const string CAMPO5 ="lblMontoCPR";
		const string CAMPO6 ="lblMontoCPCV";
		const string CAMPO7 ="lblMontoCLR";
		const string CAMPO8 ="lblMontoCLCV";
		/*campo de totales*/
		const string CAMPOTOTAL1 ="lbltotalCC";
		const string CAMPOTOTAL2 ="lblTotalCF";
		const string CAMPOTOTAL3 ="lblTotalPtm";
		const string CAMPOTOTAL4 ="lblTotalDL";
		/*Paginas de Origen*/
		const string URLCARTADECREDITO="../CartasCredito/ConsultarCartasdeCreditoporBancoDetalle.aspx?";
		const string URLCARTAFIANZA="../CartasFianza/ConsultarCartaFianzaporBancoDetalle.aspx?";
		const string URLPRESTAMOS="../PrestamosBancarios/ConsultarPrestamosporBancoDetalle.aspx?";
		//const string URLDSCTLETRAS="../DescuentodeLetras/ConsultarDescuentodeLetrasPorSituacion.aspx?";
		//Cambio realizado el 21 04 2006
		//const string URLDSCTLETRAS="../DescuentodeLetras/ConsultarDescuentodeLetras.aspx?";
		//Cambio realizado el 24 04 2006
		const string URLDSCTLETRAS="../DescuentoLetras/ConsultarDescuentodeLetras.aspx?";

		//Otros
		const string NOMBRECLASELOCKED ="locked";
		const string TITULOEMIAFAVOR="EMITIDAS A FAVOR DE TERCEROS";
		const string TITULOLETRASXCOBRAR ="Letras por Cobrar";
		const string TEXTOTOTAL ="TOTAL :";

		//Controles
		const string CTRLLBLHCC ="lblHCC";
		const string CTRLLBLCF ="lblCF";
		const string CTRLLBLPTMO ="lblptmo";
		const string CTRLLBLDL ="lblDL";

		//DataGrid and DataTable
		const string TITULOAUTORIZADO ="AUTORIZADO";
		const string TITULOSALDO ="SALDO";

		#endregion
		#region Variable
			double Total1=0;
			double Total2=0;
			double Total3=0;
			double Total4=0;
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.ImageButton ibtnImprimir;
		protected projDataGridWeb.DataGridWeb gridResumen;
		protected System.Web.UI.WebControls.Label Label5;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
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
					this.LlenarGrillaOrdenamientoPaginacion(Helper.GenerarExpresionOrdenamiento(COLORDENAMIENTO),Constantes.INDICEPAGINADEFAULT);
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
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			// Put user code to initialize the page here
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
			this.gridResumen.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridResumen_ItemDataBound);
			this.gridResumen.SelectedIndexChanged += new System.EventHandler(this.gridResumen_SelectedIndexChanged);
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemCreated);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			CLineaCredito oCLineaCredito = new CLineaCredito();
			DataTable dtGeneral = oCLineaCredito.ConsultarLineadeCreditoPorBanco(Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]));
			if(dtGeneral!=null)
			{
				gridResumen.DataSource = dtGeneral;
			}
			else
			{
				gridResumen.DataSource = dtGeneral;
				lblResultado.Text = GRILLAVACIA;
			}
			gridResumen.DataBind();
			// TODO:  Add ConsultarLineasdeCreditoporBanco.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtGeneral = ((CLineaCredito) new CLineaCredito()).ConsultarLineadeCreditoPorBancoDetalle(Convert.ToInt32(Page.Request.Params[KEYIDENTIDADFINANCIERA]));

			if(dtGeneral!=null)
			{
				DataView dwGeneral = dtGeneral.DefaultView;
				dwGeneral.Sort = COLORDENAMIENTO2;
				grid.DataSource = dwGeneral;
				CImpresion oCImpresion = new CImpresion();
				oCImpresion.GuardarDataImprimirExportar(dtGeneral,Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.ConfiguracionesAplicativo.ToString(),Utilitario.Constantes.CODIGOTITULOREPORTEACCIONCONTROLNOPROGRAMADA),columnaOrdenar,indicePagina);
				ibtnImprimir.Visible = true;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtGeneral;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				ibtnImprimir.Visible = false;
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
			// TODO:  Add ConsultarLineasdeCreditoporBanco.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add ConsultarLineasdeCreditoporBanco.Exportar implementation
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
			// TODO:  Add ConsultarLineasdeCreditoporBanco.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			 e.Item.Cells[0].CssClass = NOMBRECLASELOCKED;
			 e.Item.Cells[1].CssClass = NOMBRECLASELOCKED;

			Label lbl;
			if(e.Item.ItemType == ListItemType.Header)
			{

				lbl = (Label)e.Item.Cells[2].FindControl(CTRLLBLHCC);
				lbl.Font.Underline=true;
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLCARTADECREDITO,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString() 
																											+ Utilitario.Constantes.SIGNOAMPERSON
																											+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBREENTIDAD].ToString()
																											+ Utilitario.Constantes.SIGNOAMPERSON
																											+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDESTADO].ToString()
																											+ Utilitario.Constantes.SIGNOAMPERSON
																											+ KEYIDTIPOCREDITO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString()
																											+ Utilitario.Constantes.SIGNOAMPERSON
																											+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()

					
					));
				e.Item.Cells[2].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);
				

				lbl = (Label)e.Item.Cells[3].FindControl(CTRLLBLCF);
				lbl.Font.Underline=true;
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLCARTAFIANZA,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString() 
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDESTADO].ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ TIPOFIANZA + Utilitario.Constantes.SIGNOIGUAL + TITULOEMIAFAVOR
																										+ Utilitario.Constantes.SIGNOAMPERSON 
																										+ KEYIDTIPOFZA + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteCero.ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON 
																										+ KEYESTADOFIANZAP + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.ValorConstanteUno.ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON 				
																										+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBREENTIDAD].ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON 																									
																										+ KEYIDBENEFICIARIO + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.VALORTODOS
					));
				e.Item.Cells[3].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

				lbl = (Label)e.Item.Cells[4].FindControl(CTRLLBLPTMO);
				lbl.Font.Underline=true;
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLPRESTAMOS,KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString() 
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ KEYIDESTADO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDESTADO].ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ NOMBREENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[NOMBREENTIDAD].ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ Utilitario.Constantes.KEYMODULOCONSULTA + Utilitario.Constantes.SIGNOIGUAL +  Utilitario.Enumerados.ModuloConsulta.Si.ToString()
					));
				e.Item.Cells[4].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

				lbl = (Label)e.Item.Cells[5].FindControl(CTRLLBLDL);
				lbl.Font.Underline=true;
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.HISTORIALADELANTE);
				lbl.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.MostrarVentana(URLDSCTLETRAS,KEYIDTIPOLETRADESC + Utilitario.Constantes.SIGNOIGUAL + Utilitario.Constantes.IDDEFAULT.ToString()
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ KEYIDNOMBRETIPODESC + Utilitario.Constantes.SIGNOIGUAL + TITULOLETRASXCOBRAR
																										+ Utilitario.Constantes.SIGNOAMPERSON
																										+ KEYIDENTIDADFINANCIERA + Utilitario.Constantes.SIGNOIGUAL + Page.Request.Params[KEYIDENTIDADFINANCIERA].ToString()
					));
				
				e.Item.Cells[5].Style.Add(Utilitario.Constantes.CURSOR,Utilitario.Constantes.TIPOCURSORMANO);

			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				int ind=0;
				if (e.Item.Cells[0].Text == TITULOAUTORIZADO || e.Item.Cells[0].Text == TITULOSALDO)
				{
					e.Item.Style.Add("BACKGROUND-COLOR","#7B96C5");
					e.Item.Font.Size=8;
					e.Item.Font.Bold =true;

					((Label)e.Item.Cells[2].FindControl(CAMPO1)).Font.Size=8;
					((Label)e.Item.Cells[2].FindControl(CAMPO1)).Font.Bold =true;

					((Label)e.Item.Cells[2].FindControl(CAMPO2)).Font.Size=8;
					((Label)e.Item.Cells[2].FindControl(CAMPO2)).Font.Bold =true;

					((Label)e.Item.Cells[3].FindControl(CAMPO3)).Font.Size=8;
					((Label)e.Item.Cells[3].FindControl(CAMPO3)).Font.Bold =true;

					((Label)e.Item.Cells[3].FindControl(CAMPO4)).Font.Size=8;
					((Label)e.Item.Cells[3].FindControl(CAMPO4)).Font.Bold =true;

					((Label)e.Item.Cells[4].FindControl(CAMPO5)).Font.Size=8;
					((Label)e.Item.Cells[4].FindControl(CAMPO5)).Font.Bold =true;

					((Label)e.Item.Cells[4].FindControl(CAMPO6)).Font.Size=8;
					((Label)e.Item.Cells[4].FindControl(CAMPO6)).Font.Bold =true;


					((Label)e.Item.Cells[5].FindControl(CAMPO7)).Font.Size=8;
					((Label)e.Item.Cells[5].FindControl(CAMPO7)).Font.Bold =true;

					((Label)e.Item.Cells[5].FindControl(CAMPO8)).Font.Size=8;
					((Label)e.Item.Cells[5].FindControl(CAMPO8)).Font.Bold =true;

					ind	=1;
				}
				
				lbl = (Label)e.Item.Cells[2].FindControl(CAMPO1);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.ccreditor.ToString()].ToString();
				lbl.Text = ((ind==1 || ind ==2)? String.Empty: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				lbl = (Label)e.Item.Cells[2].FindControl(CAMPO2);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.ccreditocv.ToString()].ToString();
				lbl.Text = Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label)e.Item.Cells[3].FindControl(CAMPO3);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.cfianzar.ToString()].ToString();
				lbl.Text = ((ind==1 || ind ==2)? String.Empty: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				lbl = (Label)e.Item.Cells[3].FindControl(CAMPO4);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.cfianzacv.ToString()].ToString();
				lbl.Text = Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label)e.Item.Cells[4].FindControl(CAMPO5);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.cprestamor.ToString()].ToString();
				lbl.Text = ((ind==1 || ind ==2)? String.Empty: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4));


				lbl = (Label)e.Item.Cells[4].FindControl(CAMPO6);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.cprestamocv.ToString()].ToString();
				lbl.Text = Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				lbl = (Label)e.Item.Cells[5].FindControl(CAMPO7);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.cletrasr.ToString()].ToString();
				lbl.Text = ((ind==1 || ind ==2)? String.Empty: Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4));

				lbl = (Label)e.Item.Cells[5].FindControl(CAMPO8);
				lbl.Text = dr[Utilitario.Enumerados.FinColumnaLineaCredito.cletrascv.ToString()].ToString();
				lbl.Text = Convert.ToDouble(lbl.Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Height=10;
				/*calculo de Totales*/
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}						
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Footer) 
			{ 
				e.Item.Cells[0].Text=TEXTOTOTAL;

				e.Item.Cells[2].Text=Total1.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text=Total2.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[4].Text=Total3.ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[5].Text=Total4.ToString(Utilitario.Constantes.FORMATODECIMAL4);
			} 			
		}
		private void gridResumen_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void gridResumen_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				e.Item.Cells[1].Text= Convert.ToDouble(e.Item.Cells[1].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[2].Text= Convert.ToDouble(e.Item.Cells[2].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[3].Text= Convert.ToDouble(e.Item.Cells[3].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Cells[3].Text= Helper.FormateaNumeroNegativo(3,e.Item);
			}
		}
	}
}
