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
	/// Summary description for DetalleLetradeCambio.
	/// </summary>
	public class DetalleLetradeCambio : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{	
		#region Constantes
		const string OBJPARAMETROCONTABLE="ParametroDsctLetra";
		const string GRILLAVACIA ="No existe ningún Registro.";  
		const string URLBUSQUEDAENTIDAD="../../Legal/BusquedaEntidad.aspx?";
		const string URLBUSQUEDAPROYECTO="../../Legal/BusquedaProyecto.aspx";
		const string COLORDENAMIENTO = "idLetra";

		const string KEYIDDOCLET ="idDocLetra";
		const string KEYIDTIPOLETRA = "TipoLetra";
		const string KEYNOMBRETIPOLETRA = "NombreTipoLetra";
		const string KEYIDCENTRO = "idCentro";			
		const string KEYIDMODOLETRA ="MODOLETRA";
		const string KEYIDLETRARENOVADA ="idLetraRenovada";
		const string JSMENSAJE="window.alert('No es posible guardar este registro, para ello es necesario asociar por lo menos una factura');";
		#endregion
		#region Controles
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroDocumento;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlbSituacion;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.DropDownList ddlbTipoTrabajo;
		protected System.Web.UI.WebControls.Label Label18;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected eWorld.UI.NumericBox NDiasPlazo;
		protected System.Web.UI.WebControls.Label Label7;
		protected eWorld.UI.NumericBox nDiasVence;
		protected System.Web.UI.WebControls.Label Label9;
		protected eWorld.UI.NumericBox nMonto;
		protected System.Web.UI.WebControls.Label Label3;
		protected eWorld.UI.NumericBox nTasaInteres;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.DomValidators.DomValidationSummary Vresumen;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbTipoTrabajo;
		protected System.Web.UI.HtmlControls.HtmlTable ToolBar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPostback;
		protected System.Web.UI.HtmlControls.HtmlTable tblAtras;
		protected System.Web.UI.WebControls.Label Label16;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvTasaInteres;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNroReferencia;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvMontoEstablecido;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hListaFacturas;
		protected System.Web.UI.WebControls.Label CalFechaVencimiento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hMontoTotalFac;
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
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoPagina();
					
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
					string debug = oException.Message.ToString();
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
				}
			}
			if(this.hPostback.Value=="Grabar")
			{
				Aceptar();
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleLetradeCambio.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleLetradeCambio.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleLetradeCambio.LlenarGrillaOrdenamientoPaginacion implementation
		}


		private void CargarSituacion()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbSituacion.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraSituacionLetras));
			ddlbSituacion.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbSituacion.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbSituacion.DataBind();
			ListItem litem =  ddlbSituacion.Items.FindByValue("4");
			if(litem!=null){ddlbSituacion.Items.Remove(litem);}
		}
		private void CargarTipodeTrabajos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			this.ddlbTipoTrabajo.DataSource= oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraTipodeTrabajos));
			ddlbTipoTrabajo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbTipoTrabajo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbTipoTrabajo.DataBind();			
		}

		public void LlenarCombos()
		{
			this.CargarSituacion();
			this.CargarTipodeTrabajos();
		}

		public void LlenarDatos()
		{
			this.lblPagina.Text = Page.Request.Params[KEYNOMBRETIPOLETRA].ToString();
		}

		public void LlenarJScript()
		{
			ibtnAceptar.Attributes.Add("onClick","ObteneridRegistro();");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleLetradeCambio.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleLetradeCambio.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleLetradeCambio.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleLetradeCambio.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleLetradeCambio.ValidarFiltros implementation
			return false;
		}

		#endregion


		private void Aceptar()
		{
			
		}	


		#region IPaginaMantenimento Members

		public void Agregar()
		{
			if(Convert.ToDouble(this.hMontoTotalFac.Value)>0)
			{
				LetrasdeCambioBE oLetrasdeCambioBE = new LetrasdeCambioBE();
				oLetrasdeCambioBE.NroDocumento = this.txtNroDocumento.Text;
				oLetrasdeCambioBE.Garantia = this.txtObservacion.Text;
				oLetrasdeCambioBE.IdTipoLetra = Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]);
				oLetrasdeCambioBE.IdTipoTrabajo = Convert.ToInt32(this.ddlbTipoTrabajo.SelectedValue);
				int idLetra = ((CLetrasdeCambio)new CLetrasdeCambio()).Insertar(oLetrasdeCambioBE);
			
				if(idLetra>0)
				{
					LetrasdeCambioRenovacionBE oLetrasdeCambioRenovacionBE = new LetrasdeCambioRenovacionBE();
					oLetrasdeCambioRenovacionBE.IdLetra = idLetra;
					oLetrasdeCambioRenovacionBE.IdLetraRenovadaRel = 0;
					oLetrasdeCambioRenovacionBE.IdSituacion = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
					oLetrasdeCambioRenovacionBE.Monto = Convert.ToDouble(this.nMonto.Text);
					oLetrasdeCambioRenovacionBE.FechaRenovacion =  Convert.ToDateTime(this.CalFechaInicio.SelectedDate);
					oLetrasdeCambioRenovacionBE.DiasdePlazo = Convert.ToInt32(this.NDiasPlazo.Text);
					oLetrasdeCambioRenovacionBE.TasaInteres = Convert.ToDecimal(this.nTasaInteres.Text);
					oLetrasdeCambioRenovacionBE.Observacion = this.txtObservacion.Text;
					oLetrasdeCambioRenovacionBE.IdEstado = 1;

					(new CLetrasdeCambioRenovacion()).Insertar(oLetrasdeCambioRenovacionBE);
					AlmacenarFacturas(idLetra);

					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestión Financiera",this.ToString(),"Se ingresó Item de " + oLetrasdeCambioBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
					ltlMensaje.Text = Helper.MensajeRetornoAlert();
				}
			}
			else{
				this.ltlMensaje.Text = JSMENSAJE;
			}
		}

		public void Modificar()
		{
			LetrasdeCambioBE oLetrasdeCambioBE = new LetrasdeCambioBE();
			oLetrasdeCambioBE.IdLetra = Convert.ToInt32(Page.Request.Params[KEYIDDOCLET]);
			oLetrasdeCambioBE.NroDocumento = this.txtNroDocumento.Text;
			oLetrasdeCambioBE.Garantia = this.txtObservacion.Text;
			oLetrasdeCambioBE.IdTipoLetra = Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]);
			oLetrasdeCambioBE.IdTipoTrabajo = Convert.ToInt32(this.ddlbTipoTrabajo.SelectedValue);
			if(((CLetrasdeCambio)new CLetrasdeCambio()).Modificar(oLetrasdeCambioBE)>0)
			{
				LetrasdeCambioRenovacionBE oLetrasdeCambioRenovacionBE = new LetrasdeCambioRenovacionBE();
				oLetrasdeCambioRenovacionBE.IdLetraRenovada = Convert.ToInt32(Page.Request.Params[KEYIDLETRARENOVADA]);
				oLetrasdeCambioRenovacionBE.IdSituacion = Convert.ToInt32(this.ddlbSituacion.SelectedValue);
				oLetrasdeCambioRenovacionBE.Monto = Convert.ToDouble(this.nMonto.Text);
				oLetrasdeCambioRenovacionBE.FechaRenovacion =  Convert.ToDateTime(this.CalFechaInicio.SelectedDate);
				oLetrasdeCambioRenovacionBE.DiasdePlazo = Convert.ToInt32(this.NDiasPlazo.Text);
				oLetrasdeCambioRenovacionBE.TasaInteres = Convert.ToDecimal(this.nTasaInteres.Text);
				oLetrasdeCambioRenovacionBE.Observacion = this.txtObservacion.Text;
				oLetrasdeCambioRenovacionBE.IdEstado = 1;
					
				(new CLetrasdeCambioRenovacion()).Modificar(oLetrasdeCambioRenovacionBE);
				AlmacenarFacturas(oLetrasdeCambioBE.IdLetra);
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + oLetrasdeCambioBE.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}
		
		void AlmacenarFacturas(int idLetra){
			string []arrFactura = hListaFacturas.Value.ToString().Split(';');
			if((arrFactura!=null)&& arrFactura.Length>1)
			{
				for(int i=0;i<= arrFactura.Length-1;i++)
				{
					string []arrCampo = arrFactura[i].ToString().Split(',');
					LetrasdeCambioFacturasBE oLetrasdeCambioFacturasBE = new LetrasdeCambioFacturasBE();
					oLetrasdeCambioFacturasBE.IdLetra = idLetra;
					oLetrasdeCambioFacturasBE.IdCentroOperativo = Convert.ToInt32(arrCampo[0]);
					oLetrasdeCambioFacturasBE.NroSerie = Convert.ToInt32(arrCampo[1]);
					oLetrasdeCambioFacturasBE.NroFactura = Convert.ToInt32(arrCampo[2]);
					oLetrasdeCambioFacturasBE.TipoCambio=Convert.ToDecimal(arrCampo[3]);
					(new CLetrasdeCambioFacturas()).Insertar(oLetrasdeCambioFacturasBE);
				}
			}
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleLetradeCambio.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					if(Page.Request.Params[KEYIDMODOLETRA]!=null)
					{
						this.CargarModoModificar();
					}
					else
					{
						this.CargarModoNuevo();
					}
					this.tblAtras.Visible= false;
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					this.tblAtras.Visible= false;
					break;
				case Enumerados.ModoPagina.C:
					this.CargarModoModificar();
					if (Page.Request.Params[Utilitario.Constantes.KEYMODULOCONSULTA].ToString()== Utilitario.Enumerados.ModuloConsulta.Si.ToString())
					{
						Helper.BloquearControles(this);
						this.ibtnCancelar.Visible=false;
						this.ToolBar.Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
						this.tblAtras.Visible= true;
					}
					break;			
			}
		}

		public void CargarModoNuevo()
		{
			this.CargarGilla();
		}

		public void CargarModoModificar()
		{
			LetrasDBE oLetrasDBE = (LetrasDBE)((CLetrasdeCambio) new CLetrasdeCambio()).DetalleLetrasdeCambio(Page.Request.Params[KEYIDLETRARENOVADA],Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT,Utilitario.Constantes.IDDEFAULT,CNetAccessControl.GetIdUser());
			this.txtNroDocumento.Text = oLetrasDBE.NroDocumento.ToString();
			this.CalFechaInicio.SelectedDate = Convert.ToDateTime(oLetrasDBE.FechaInicio);
			this.CalFechaVencimiento.Text = Convert.ToDateTime(oLetrasDBE.FechaVencimiento).ToShortDateString().Replace("/","-");
			this.NDiasPlazo.Text = oLetrasDBE.NroDiasPlazo.ToString();
			this.nDiasVence.Text = oLetrasDBE.NroDiasFaltantes.ToString();
			try
			{
				((ListItem)this.ddlbSituacion.Items.FindByValue(oLetrasDBE.IdSituacion.ToString())).Selected =true;
			}
			catch(Exception ex){
				this.ddlbSituacion.Style.Add("display","none");
				ibtnAceptar.Style.Add("display","none");
			}
			((ListItem)this.ddlbTipoTrabajo.Items.FindByValue(oLetrasDBE.IdTipoTrabajo.ToString())).Selected =true;
			this.nMonto.Text  = oLetrasDBE.Monto.ToString();
			this.nTasaInteres.Text=oLetrasDBE.TasaInteres.ToString();
			this.txtObservacion.Text = oLetrasDBE.Observacion.ToString();
			this.CargarGilla();
		}
		private void CargarGilla(){
			DataTable dt = new  DataTable();
			dt =(new CFacturasEnLetras()).ListarFacturasEnLetras(Convert.ToInt32(Page.Request.Params[KEYIDDOCLET]),Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA]));
			//object []Data={0,"",0,0,0,0,"","",0,0};
			//dt.Rows.Add(Data);
			if(dt!=null)
			{
				DataView dw= dt.DefaultView;
				grid.DataSource = dw;
			}
			else
			{
				grid.DataSource = dt;
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
		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleLetradeCambio.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleLetradeCambio.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleLetradeCambio.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleLetradeCambio.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.Header)
			{
				e.Item.Cells[2].Text= ((Convert.ToInt32(Page.Request.Params[KEYIDTIPOLETRA])==0)?"CLIENTE":"PROVEEDOR");
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRow dr = (DataRow)(((DataRowView)e.Item.DataItem).Row);
				if(Convert.ToInt32(dr["idCentroOperativo"])!=0)
				{
					e.Item.Cells[0].Text = dr["Factura"].ToString();
					e.Item.Attributes.Add("idCentroOperativo",dr["idCentroOperativo"].ToString());
					e.Item.Attributes.Add("NroSerie",dr["NroSerie"].ToString());
					e.Item.Attributes.Add("Nrofactura",dr["Nrofactura"].ToString());
					e.Item.Attributes.Add("TipoCambio",dr["Tipo_cambio"].ToString());

					e.Item.Cells[4].Text = Convert.ToDouble(e.Item.Cells[4].Text).ToString(Utilitario.Constantes.FORMATODECIMAL4);

					this.hMontoTotalFac.Value = Convert.ToDouble(dr["TotalFactura"].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
					//Imagen
					HtmlImage oImg =(HtmlImage) e.Item.Cells[6].FindControl("imgEliminar");
					oImg.Attributes.Add("onClick"," Eliminar(this.parentElement.parentElement,'" + dr["idFacturaCambio"].ToString() + "');");
					oImg.Attributes.Add("onmousemove","this.src='/SimanetWeb/Imagenes/Tree/CloseWindowB.gif';");
					oImg.Attributes.Add("onmouseout","this.src='/SimanetWeb/Imagenes/Tree/CloseWindowA.gif';");
					Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
				}
				else{
						e.Item.Cells[4].Text = this.hMontoTotalFac.Value ;
						e.Item.Cells[0].ColumnSpan=4;
						e.Item.Cells[1].Visible=false;
						e.Item.Cells[2].Visible=false;
						e.Item.Cells[3].Visible=false;
						e.Item.Cells[5].ColumnSpan=2;
						e.Item.Cells[5].Text="";
						e.Item.Cells[6].Visible=false;
				}
				e.Item.Attributes.Add("Estado","M");
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

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
