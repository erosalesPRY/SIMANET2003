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
using SIMA.EntidadesNegocio.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera.DescuentoLetras
{
	
	public class BuscarLetras : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string GRILLAVACIA ="No existe ninguna Cuenta Bancaria.";

			const string KEYIDDOCDESCLET ="idDocdescLetra";
			const string KEYIDLETDESCTDET ="idLetraDesctDet";
			const string KEYIDMONEDA = "idMoneda";

			const string KEYIDTIPOLETRA = "TipoLetra";
			const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
			const string KEYIDCENTRO = "idCentro";
			const string KEYCENTROABREV = "CentroAbrev";
		

			const string CAMPOFECHA1 = "lblFechaInicio";
			const string CAMPOFECHA2 = "lblFechaVence";

			const string CAMPODIAS1 = "lblDiasPlazo";
			const string CAMPODIAS2 = "lblDiasFaltantes";


		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label Label1;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblSituacion;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.ImageButton btnBuscar;
		protected System.Web.UI.WebControls.TextBox txtLetraNro;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdLetra;
		protected System.Web.UI.HtmlControls.HtmlTextArea txtProyecto;
		protected System.Web.UI.HtmlControls.HtmlInputText nTasaInteres;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarDatos();
					Helper.ReiniciarSession();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Auditoria",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,Utilitario.Constantes.ValorConstanteCero);
					
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
			this.btnBuscar.Click += new System.Web.UI.ImageClickEventHandler(this.btnBuscar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add BuscarLetras.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add BuscarLetras.LlenarGrillaOrdenamiento implementation
		}
		private DataTable ObtenerDatos()
		{
			return ((CLetras) new CLetras()).BuscarLetras(Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]),
																			this.txtLetraNro.Text);
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			DataTable dtLetras=this.ObtenerDatos();
			if(dtLetras!=null)
			{
				DataView dwLetras= dtLetras.DefaultView;
				//dwLetras.RowFilter = Helper.ObtenerFiltro();
				//dwLetras.RowFilter = "idMoneda='" + Convert.ToInt32(Page.Request.Params[KEYIDMONEDA]).ToString() + "' and AbreviaturaCentroOperativo='" + Page.Request.Params[KEYCENTROABREV].ToString() +  "'";
				dwLetras.RowFilter = "idMoneda='" + Convert.ToInt32(Page.Request.Params[KEYIDMONEDA]).ToString() + "'";

				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + Utilitario.Constantes.ESPACIO + dwLetras.Count.ToString();
				dwLetras.Sort = columnaOrdenar ;
				grid.DataSource = dwLetras;
				grid.CurrentPageIndex = indicePagina;
				lblResultado.Visible = false;
			}
			else
			{
				grid.DataSource = dtLetras;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
				//ibtnImprimir.Visible = false;
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
			// TODO:  Add BuscarLetras.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			this.lblSituacion.Text = Page.Request.Params[KEYNOMBRETIPOLETRA].ToString().ToUpper();
		}

		public void LlenarJScript()
		{
			// TODO:  Add BuscarLetras.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add BuscarLetras.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add BuscarLetras.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add BuscarLetras.Exportar implementation
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
			// TODO:  Add BuscarLetras.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnBuscar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion(Utilitario.Constantes.VACIO,0);
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[0].Font.Underline=true;
				e.Item.Cells[0].ForeColor=Color.Blue;
				e.Item.Cells[0].Text = Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);

				((Label) e.Item.Cells[5].FindControl(CAMPOFECHA1)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.FechaInicio.ToString()].ToString();
				((Label) e.Item.Cells[5].FindControl(CAMPOFECHA2)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.FechaVencimiento.ToString()].ToString();
				
				((Label) e.Item.Cells[6].FindControl(CAMPODIAS1)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasPlazo.ToString()].ToString();
				((Label) e.Item.Cells[6].FindControl(CAMPODIAS2)).Text = dr[Utilitario.Enumerados.FinColumnaLetras.NroDiasFaltantes.ToString()].ToString();


				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,Helper.MostrarDatosEnCajaTexto("hIdLetra",dr[Utilitario.Enumerados.FinColumnaLetras.idLetra.ToString()].ToString()));
				
				//Helper.FiltroporSeleccionConfiguraColumna(e,grid);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA]) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								this.Agregar(); 
								break;
							case Enumerados.ModoPagina.M:
								this.Modificar();
								break;
						}
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
		#region IPaginaMantenimento Members

		public void Agregar()
		{
			LetrasDescuentoBE oLetrasDescuentoBE = new LetrasDescuentoBE();
			oLetrasDescuentoBE.IdDescuento = Page.Request.Params[KEYIDDOCDESCLET].ToString();
			oLetrasDescuentoBE.IdLetra = hIdLetra.Value.ToString();
			oLetrasDescuentoBE.IdUsuarioRegistro= CNetAccessControl.GetIdUser();
			//oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoLetrasDescuento);
			oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
			oLetrasDescuentoBE.IdEstado= 1;//En descuento de letras
			if(((CLetrasDescuento)new CLetrasDescuento()).Insertar(oLetrasDescuentoBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDescuentoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				Helper.CerrarVentana(true);
			}		
		}

		public void Modificar()
		{
			LetrasDescuentoBE oLetrasDescuentoBE = new LetrasDescuentoBE();
			oLetrasDescuentoBE.IdLetrasDescuento = Page.Request.Params[KEYIDLETDESCTDET].ToString();
			oLetrasDescuentoBE.IdDescuento = Page.Request.Params[KEYIDDOCDESCLET].ToString();
			oLetrasDescuentoBE.IdLetra = hIdLetra.Value.ToString();
			oLetrasDescuentoBE.IdUsuarioActualizacion= CNetAccessControl.GetIdUser();
			oLetrasDescuentoBE.IdTablaEstado= Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras);
			oLetrasDescuentoBE.IdEstado= 1;//En descuento de letras
			if(((CLetrasDescuento)new CLetrasDescuento()).Modificar(oLetrasDescuentoBE)>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasDescuentoBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				Helper.CerrarVentana(true);
			}		
		}

		public void Eliminar()
		{
			// TODO:  Add BuscarLetras.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add BuscarLetras.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add BuscarLetras.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add BuscarLetras.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add BuscarLetras.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add BuscarLetras.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add BuscarLetras.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add BuscarLetras.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
