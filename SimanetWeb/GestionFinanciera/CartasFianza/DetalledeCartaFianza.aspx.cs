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
using SIMA.Controladoras.Proyectos;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.Proyectos;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using NullableTypes;
using MetaBuilders.WebControls;
using SIMA.EntidadesNegocio.GestionFinanciera;

namespace SIMA.SimaNetWeb.GestionFinanciera.CartasFianza
{
	/// <summary>
	/// Summary description for DetalledeCartaFianza.
	/// </summary>
	public class DetalledeCartaFianza : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constante
			const string URLBUSQUEDAENTIDAD="../../General/BuscarProyecto.aspx";
			const string JRETURN = " return false;";
			const string OBJPARAMETROCONTABLE="ParametroCartaFza";
			const string KEYIDDETCF="idDetCF";
			const string KEYIDCARTAFZA="idCartaFza";
			const string KEYIDPERIODO="Periodo";
			const string KEYIDFECHA ="Fecha";
			const string KEYIDESTADO= "IdEstado";
			const string COLORDENAMIENTO = "idDetCF";
			const int IDTABLAESTADOCARTAFIANZA=5;
			const string GRILLAVACIA="No Existen Datos";
			const string CONTROLINK="hlkidItem";
			const string URLDETALLE="ConsultarNotasdeCargo.aspx?";
			const string URLPRINCIPAL="ConsultarCartaFianza.aspx?";

			//Mensajes ToolTip Grilla
			const string TOOLTIPRENOVACIONFIANZA ="Nro de Renovación de la Fianza";
			const string TOOLTIPMONEDA ="Moneda";
			const string TOOLTIPSITUACIONFIANZA ="Situación de la Fianza";

			const string MENSAJECONFIRMACIONIMPORTACIONRENOVACIONESCARTAFZA ="Importación termino con exito..";

			//Otros
			const string COLUMNAIDDETALLECARTAFZA ="idDetCF";
			const string COLUMNAFECHAAPERTURA ="FechaApertura";
			const string COLUMNAIDD ="idd";
			const string VARIABLETOTALIZAR ="Totalizar";

			const string KEYQIDCLIENTE = "IdCliente";
			const string KEYQIDTABLATIPOPROYECTO = "IdTablaTipoProyecto";
			const string KEYQIDTIPOPROYECTO = "IdTipoProyecto";
			const string KEYQTITULO = "Titulo";
			const string KEYQIDPROYECTO = "IdProyecto";	
			const string KEYQIDCENTRO="IdCentro";
		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.TextBox txtNroFza;
		protected System.Web.UI.WebControls.TextBox txtNombreMoneda;
		protected System.Web.UI.WebControls.TextBox txtNroContrato;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.TextBox txtSituacion;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.TextBox txtCentro;
		protected System.Web.UI.WebControls.TextBox txtBanco;
		protected System.Web.UI.WebControls.TextBox txtConcepto;
		protected System.Web.UI.WebControls.TextBox txtBeneficiario;
		protected System.Web.UI.WebControls.TextBox txtProyecto;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPaginaSort;
		protected System.Web.UI.WebControls.ImageButton imgbtnImportar;
		protected System.Web.UI.WebControls.Label lblProyectoA;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProyecto;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		private 	ListItem item =  new ListItem();
		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.LlenarDatos();
					this.MostrarDetalle();
					Helper.ReestablecerPagina(this);
					this.CargarModoPagina();
					//this.imgbtnImportar.Visible = true;
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"CartaFianza",this.ToString(),"Se consultó las Acciones Correctivas.",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarGrillaOrdenamientoPaginacion(this.hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
					
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
			this.txtBeneficiario.TextChanged += new System.EventHandler(this.txtBeneficiario_TextChanged);
			this.imgbtnImportar.Click += new System.Web.UI.ImageClickEventHandler(this.imgbtnImportar_Click);
			this.grid.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.grid_SortCommand);
			this.grid.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.grid_PageIndexChanged);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void MostrarDetalle()
		{
			//Referencia a la Entidad de Negocio
			CCartaFianza oCCartaFianza = new CCartaFianza();
			CartaFianzaBE oCartaFianzaBE = (CartaFianzaBE) oCCartaFianza.DetalleCartaFianza(Convert.ToInt32(Page.Request.Params[KEYIDDETCF]),
																							Convert.ToInt32(Page.Request.Params[KEYIDCARTAFZA]),
																							Convert.ToInt32(Page.Request.Params[KEYIDPERIODO])) ;
			if(oCartaFianzaBE!=null)
			{
				this.txtCentro.Text = oCartaFianzaBE.Centro.ToString();
				this.txtBanco.Text = oCartaFianzaBE.NombreEntidadFinanciera.ToString();
				this.txtSituacion.Text= oCartaFianzaBE.Situacion.ToString();
				this.txtNroFza.Text = oCartaFianzaBE.NroFianza.ToString();
				this.txtNombreMoneda.Text = oCartaFianzaBE.Moneda.ToString();
				this.txtNroContrato.Text= oCartaFianzaBE.NroContrato.ToString();
				this.txtConcepto.Text = oCartaFianzaBE.Concepto.ToString();
				this.txtProyecto.Text = oCartaFianzaBE.NombreProyecto.ToString();
				this.txtBeneficiario.Text = oCartaFianzaBE.NombreBeneficiario.ToString();
				hIdProyecto.Value = oCartaFianzaBE.IdProyecto.ToString();

				Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA]) ;
				switch (oModoPagina)
				{
					case Enumerados.ModoPagina.C:
					{
						Helper.BloquearControles(this);
					}break;
				}
			}
		 }

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalledeCartaFianza.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalledeCartaFianza.LlenarGrillaOrdenamiento implementation
		}

		private DataTable ObtenerDatos()
		{
			CCartaFianza oCCartaFianza = new CCartaFianza();
			return oCCartaFianza.ConsultarRenovacionCartaFianza(Convert.ToInt32(Page.Request.Params[KEYIDCARTAFZA].ToString()),
																Convert.ToInt32(Page.Request.Params[KEYIDPERIODO].ToString()));
		}
		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			DataTable dtCartaFianza = this.ObtenerDatos();
			if(dtCartaFianza!=null)
			{
				DataView dwCartaFianza = dtCartaFianza.DefaultView;
				
				Session[VARIABLETOTALIZAR] = Helper.TotalizarDataView(dwCartaFianza,"MontoCargo")[0];

				dwCartaFianza.RowFilter = Helper.ObtenerFiltro();
				dwCartaFianza.Sort = columnaOrdenar ;
				
				grid.Columns[Utilitario.Constantes.POSICIONFOOTERTOTAL].FooterText = Utilitario.Constantes.TEXTOFOOTERTOTAL + " " + dwCartaFianza.Count.ToString();
				grid.DataSource = dwCartaFianza;
				grid.CurrentPageIndex = indicePagina;

				lblResultado.Visible = false;

			}
			else
			{
				grid.DataSource = dtCartaFianza;
				lblResultado.Visible = true;
				lblResultado.Text = GRILLAVACIA;
			}
			try
			{
				grid.DataBind();
			}
			catch(Exception e)
			{
				string a = e.Message;
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}
			// TODO:  Add DetalledeCartaFianza.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalledeCartaFianza.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			//this.imgbtnImportar.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnMouseDown.ToString(),Utilitario.Constantes.POPUPDEESPERA);
			this.imgbtnImportar.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Utilitario.Constantes.POPUPDEESPERA);
			///this.ibtnBuscarProyecto.Attributes.Add(Utilitario.Constantes.EVENTOCLICK ,Helper.PopupBusqueda(URLBUSQUEDAENTIDAD,700,700,true) +  JRETURN);
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalledeCartaFianza.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalledeCartaFianza.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalledeCartaFianza.Exportar implementation
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
			// TODO:  Add DetalledeCartaFianza.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalledeCartaFianza.Agregar implementation
		}

		public void Modificar()
		{
			CartaFianzaBE oCartaFianzaBE = new CartaFianzaBE();

			oCartaFianzaBE.IdCartaFza = Convert.ToInt32(Page.Request.QueryString[KEYIDCARTAFZA]);
			oCartaFianzaBE.IddetCF = Convert.ToInt32(Page.Request.QueryString[KEYIDDETCF]);
			oCartaFianzaBE.Periodo = Convert.ToInt32(Page.Request.QueryString[KEYIDPERIODO]);
			oCartaFianzaBE.NroFianza = txtNroFza.Text.ToString();

			if(hIdProyecto.Value != String.Empty)
				oCartaFianzaBE.IdProyecto = NullableInt32.Parse(hIdProyecto.Value);

			CCartaFianza oCCartaFianza = new CCartaFianza();
			int retorno = oCCartaFianza.ModificarCartaFianza(oCartaFianzaBE);

			if (retorno == Utilitario.Constantes.VALORCONFIRMACIONREGISTRO)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestionFinanciera.ToString(),this.ToString(),"Se actualiza la carta fianza" + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREGISTROPROYECTOMM));
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalledeCartaFianza.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalledeCartaFianza.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			//this.imgbtnImportar.Visible = true;
		}

		public void CargarModoConsulta()
		{
			//this.imgbtnImportar.Visible = false;
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalledeCartaFianza.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalledeCartaFianza.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalledeCartaFianza.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[0].ToolTip=TOOLTIPRENOVACIONFIANZA;
				e.Item.Cells[3].ToolTip=TOOLTIPMONEDA;
				e.Item.Cells[5].ToolTip=TOOLTIPSITUACIONFIANZA;
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				HyperLink hlk = (HyperLink)e.Item.Cells[1].FindControl(CONTROLINK);
				//hlk.Text =dr[COLUMNAIDD].ToString(); //Convert.ToString((Convert.ToInt32(dr["idDetCF"])-1)) ;				
				hlk.Text =Convert.ToString(Convert.ToInt32(dr[COLUMNAIDD]) + 1); //Convert.ToString((Convert.ToInt32(dr["idDetCF"])-1)) ;				
				/*System.Text.StringBuilder stbQuery = new System.Text.StringBuilder(URLDETALLE);
					stbQuery.Append(KEYIDDETCF);
					stbQuery.Append(Utilitario.Constantes.SIGNOIGUAL);
					stbQuery.Append(Convert.ToString(dr[COLUMNAIDDETALLECARTAFZA]));
					stbQuery.Append(Utilitario.Constantes.SIGNOAMPERSON);
					stbQuery.Append(KEYIDCARTAFZA);
					stbQuery.Append(Utilitario.Constantes.SIGNOIGUAL);
					stbQuery.Append(Page.Request.Params[KEYIDCARTAFZA]);
					stbQuery.Append(Utilitario.Constantes.SIGNOAMPERSON);
					stbQuery.Append(KEYIDPERIODO);
					stbQuery.Append(Utilitario.Constantes.SIGNOIGUAL);
					stbQuery.Append(Page.Request.Params[KEYIDPERIODO]);
					stbQuery.Append(Utilitario.Constantes.SIGNOAMPERSON);
					stbQuery.Append(KEYIDFECHA);
					stbQuery.Append(Utilitario.Constantes.SIGNOIGUAL);
					DateTime dtFecha = Convert.ToDateTime(dr[COLUMNAFECHAAPERTURA]);
					stbQuery.Append(dtFecha.Year.ToString()+ dtFecha.Month.ToString().PadLeft(2,'0') + dtFecha.Day.ToString().PadLeft(2,'0'));
					
					hlk.Attributes.Add(Utilitario.Constantes.EVENTOMOUSEDOWN,Helper.HistorialIrAdelantePersonalizado(this.hGridPagina.ID.ToString(),this.hGridPaginaSort.ID.ToString()));
					hlk.NavigateUrl = stbQuery.ToString();*/
					hlk.Text = Convert.ToDouble(Convert.ToDouble(hlk.Text)-1).ToString();
					hlk.ForeColor= System.Drawing.Color.Navy;
				#region Helpers
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
					Helper.FiltroporSeleccionConfiguraColumna(e,grid);
				#endregion				
				e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				e.Item.Cells[6].Text = Convert.ToDouble(e.Item.Cells[6].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

				e.Item.Height=5;
				if (Convert.ToInt32(Page.Request.Params[KEYIDDETCF])== Convert.ToInt32(dr[COLUMNAIDDETALLECARTAFZA]))
				{
					e.Item.Font.Bold=true;
					e.Item.BackColor = Color.LightYellow;
					e.Item.Font.Bold = true;
				}
			}	

			if(e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[0].ColumnSpan=6;
				e.Item.Cells[7].Visible = true;
				e.Item.Cells[7].Text = ((double) Session[VARIABLETOTALIZAR]).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				Session[VARIABLETOTALIZAR]=null;
			}
		
		}

		private void grid_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			hGridPaginaSort.Value=Helper.GenerarExpresionOrdenamiento(e.SortExpression);
			this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Helper.ObtenerIndicePagina());
		}

		private void grid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.hGridPagina.Value = e.NewPageIndex.ToString();
			this.LlenarGrillaOrdenamientoPaginacion(Helper.ObtenerColumnaOrdenamiento(),e.NewPageIndex);
		}

		private void imgbtnImportar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			
			try
			{
				int i = ((CCartaFianza) new CCartaFianza()).ImportarCartaFianzaRenovaciones();
				ASPNetUtilitario.MessageBox.Show(MENSAJECONFIRMACIONIMPORTACIONRENOVACIONESCARTAFZA);
				this.LlenarGrillaOrdenamientoPaginacion(hGridPaginaSort.Value,Convert.ToInt32(this.hGridPagina.Value));
				this.grid.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(Utilitario.Helper.FooterSpan);
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
				ASPNetUtilitario.MessageBox.Show(oException.Message.ToString());
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Utilitario.Constantes.KEYMODOPAGINA]) ;
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void txtBeneficiario_TextChanged(object sender, System.EventArgs e)
		{
		
		}	
	}
}
