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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.Controladoras.GestionComercial;
using SIMA.Controladoras.General;
using SIMA.EntidadesNegocio.GestionComercial;
using System.IO;
using NullableTypes;


namespace SIMA.SimaNetWeb.GestionComercial.ComunicacionImagen
{

	public class DetalleInventarioImagen : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
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
			this.dllGrupo.SelectedIndexChanged += new System.EventHandler(this.dllGrupo_SelectedIndexChanged);
			this.chkTieneMovimientos.CheckedChanged += new System.EventHandler(this.chkTieneMovimientos_CheckedChanged);
			this.chkIngreso.CheckedChanged += new System.EventHandler(this.chkIngreso_CheckedChanged);
			this.chkEgreso.CheckedChanged += new System.EventHandler(this.chkEgreso_CheckedChanged);
			this.txtPrecioUnitario.TextChanged += new System.EventHandler(this.txtPrecioUnitario_TextChanged);
			this.dllGrupoCC.SelectedIndexChanged += new System.EventHandler(this.dllGrupoCC_SelectedIndexChanged);
			this.txtPrecioUnitarioEgresos.TextChanged += new System.EventHandler(this.txtPrecioUnitarioEgresos_TextChanged);
			this.dllCentroOperativo.SelectedIndexChanged += new System.EventHandler(this.dllCentroOperativo_SelectedIndexChanged);
			this.ibtnAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAgregar_Click);
			this.ibtnEliminar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnEliminar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.ibtnModificar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnModificar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members
		public void Agregar()
		{
			InventarioImagenBE oInventarioImagenBE = new InventarioImagenBE();
			
			oInventarioImagenBE.Nombre = txtNombre.Text;
			
			if(this.txtObservacion.Text.Trim()!=String.Empty)
				oInventarioImagenBE.Observaciones = txtObservacion.Text;

			if(this.txtDescripcion.Text.Trim()!=String.Empty)
				oInventarioImagenBE.Descripcion = txtDescripcion.Text;
			
			oInventarioImagenBE.IdGrupo = Convert.ToInt32(dllGrupo.SelectedValue.ToString());
			oInventarioImagenBE.IdTablaGrupo = Convert.ToInt32(Enumerados.TablasTabla.GrupoArticulos);
			oInventarioImagenBE.IdSubGrupo = Convert.ToInt32(dllSubGrupo.SelectedValue.ToString());
			oInventarioImagenBE.IdUsuarioRegistro = CNetAccessControl.GetIdUser();
			oInventarioImagenBE.FechaRegistro = DateTime.Now;
			oInventarioImagenBE.IdIdioma = NullableInt32.Parse(ddlIdioma.SelectedValue);
			oInventarioImagenBE.IdTablaIdioma = NullableInt32.Parse(Enumerados.TablasTabla.Idiomas);
			
			if(this.txtMinimo.Text!=String.Empty)
				oInventarioImagenBE.Minimo =  NullableInt32.Parse(txtMinimo.Text);

			
			if(filMyFile.Value!=String.Empty)
			{
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oInventarioImagenBE.Foto = strFilename;
			}
			else
			{
				string pathServer = RutaImagenServerProyecto;
				oInventarioImagenBE.Foto = ARCHIVO;	
			}

			oInventarioImagenBE.IdEstado = Convert.ToInt32(Enumerados.EstadosInventarioImagen.Activo);
			oInventarioImagenBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoInvetarioImagen);

			CInventarioImagen oCInventarioImagen = new CInventarioImagen();
			int retorno=Utilitario.Constantes.ValorConstanteCero;

			if(ViewState[KEYQCAMBIOS].ToString() ==  Utilitario.Constantes.ValorConstanteUno.ToString())
			{
				retorno = oCInventarioImagen.RegistrarInventarios(oInventarioImagenBE,(DataTable)ViewState[KEYQDATATABLE]);
			}
			else if(ViewState[KEYQCAMBIOS].ToString()== Utilitario.Constantes.ValorConstanteCero.ToString())
			{
				retorno =  oCInventarioImagen.Insertar(oInventarioImagenBE);
			}

			if(retorno>Utilitario.Constantes.ValorConstanteCero)
			{
				if (oInventarioImagenBE.Foto != ARCHIVO)
					this.GuardarImagen();

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString() ,this.ToString(), MENSAJEREGITRO + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROINVENTARIOIMAGEN)) + Utilitario.Constantes.HISTORIALATRAS;
			}
		}

		public void Modificar()
		{
			InventarioImagenBE oInventarioImagenBE = new InventarioImagenBE();

			oInventarioImagenBE.IdInventarioImagen = Convert.ToInt32(Page.Request.QueryString[KEIDINVENTARIO]);
			oInventarioImagenBE.Nombre = txtNombre.Text;

			if(this.txtObservacion.Text.Trim()!=String.Empty)
				oInventarioImagenBE.Observaciones = txtObservacion.Text;

			if(this.txtDescripcion.Text.Trim()!=String.Empty)
				oInventarioImagenBE.Descripcion = txtDescripcion.Text;

			oInventarioImagenBE.IdGrupo = Convert.ToInt32(dllGrupo.SelectedValue);
			oInventarioImagenBE.IdTablaGrupo = Convert.ToInt32(Enumerados.TablasTabla.GrupoArticulos);
			oInventarioImagenBE.IdSubGrupo = Convert.ToInt32(dllSubGrupo.SelectedValue);

			oInventarioImagenBE.FechaRegistro = DateTime.Now;
			oInventarioImagenBE.IdEstado = Convert.ToInt32(Enumerados.EstadosInventarioImagen.Modificado);
			oInventarioImagenBE.IdTablaEstado = Convert.ToInt32(Enumerados.TablasTabla.EstadoInvetarioImagen);
			oInventarioImagenBE.IdIdioma = NullableInt32.Parse(ddlIdioma.SelectedValue);

			if(this.txtMinimo.Text!=String.Empty)
				oInventarioImagenBE.Minimo = NullableInt32.Parse(txtMinimo.Text);
			
		
			if(filMyFile.Value!=String.Empty)
			{
				string strFilename = filMyFile.PostedFile.FileName;
				string[] res = strFilename.Split('\\');
				int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
				strFilename = res[i];

				oInventarioImagenBE.Foto = strFilename;
			}
			else
			{
				if(hImagen.Value!=String.Empty)  
				{
					oInventarioImagenBE.Foto = hImagen.Value;	
				}
				else
				{
					string pathServer = RutaImagenServerProyecto;
					oInventarioImagenBE.Foto = ARCHIVO;	
				}
			}


			oInventarioImagenBE.IdUsuarioActualizacion = CNetAccessControl.GetIdUser();

			CInventarioImagen oCInventarioImagen = new CInventarioImagen();

			int retorno=0;
			string retornaa=ViewState[KEYQCAMBIOS].ToString();
		
			if(retornaa ==  Utilitario.Constantes.ValorConstanteUno.ToString())
			{
				retorno = oCInventarioImagen.ModificarRegistroInventario(oInventarioImagenBE,(DataTable)ViewState[KEYQDATATABLE],((int[])ViewState[KEYQREGISTROSELIMINADOS]),Convert.ToInt32(ViewState[KEYQCODIGOINICIAL]));
			}
			else if (retornaa == Utilitario.Constantes.ValorConstanteCero.ToString())
			{
				retorno = oCInventarioImagen.Modificar(oInventarioImagenBE);
			}
			if(retorno>0)
			{
				if(oInventarioImagenBE.Foto != ARCHIVO)
					this.GuardarImagen();

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(), MENSAJEMODIFICAR + retorno.ToString() + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONMODIFICACIONINVENTARIOIMAGEN)) + Utilitario.Constantes.HISTORIALATRAS;
			}
			
		}

		public void Eliminar()
		{
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODONUEVO;
			this.HabilitaMoviemientos(false);
			this.HabilitarEgresos(false);
			this.HabilitarIngresos(false);
			this.ddlMoneda.SelectedValue = "1";
		}

		public void CargarModoModificar()
		{


			this.TdCeldaCancelar.Visible = false;
			lblTitulo.Text = TITULOMODOMODIFICAR;

			CMantenimientos	oCMantenimientos = new CMantenimientos();
			InventarioImagenBE oInventarioImagenBE = (InventarioImagenBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEIDINVENTARIO]),Enumerados.ClasesNTAD.InventarioImagenNTAD.ToString());

			if(oInventarioImagenBE!=null)
			{
				txtNombre.Text =  oInventarioImagenBE.Nombre;

				if (!oInventarioImagenBE.Descripcion.IsNull)
					txtDescripcion.Text = oInventarioImagenBE.Descripcion.ToString();

				if(!oInventarioImagenBE.Observaciones.IsNull)
					txtObservacion.Text = oInventarioImagenBE.Observaciones.ToString();

				if(!oInventarioImagenBE.Foto.IsNull)
				{
					string RutaImagen=RutaImagenServerProyecto + oInventarioImagenBE.Foto.Value;
					imgProyecto.ImageUrl = RutaImagen;
					hImagen.Value = oInventarioImagenBE.Foto.ToString();
				}

				dllGrupo.SelectedValue = oInventarioImagenBE.IdGrupo.ToString();

				CTablaTablas oCTablaTablas = new CTablaTablas();
				dllSubGrupo.DataSource = oCTablaTablas.ListaTodosCombo(Convert.ToInt32(dllGrupo.SelectedValue));
				dllSubGrupo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
				dllSubGrupo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
				dllSubGrupo.DataBind();
				dllSubGrupo.SelectedValue = oInventarioImagenBE.IdSubGrupo.ToString();


				if(!oInventarioImagenBE.IdIdioma.IsNull)
                    ddlIdioma.SelectedValue = oInventarioImagenBE.IdIdioma.ToString();

				txtMinimo.Text = oInventarioImagenBE.Minimo.ToString();

				CMovimientoInventarioImagen oCMovimientoInventarioImagen = new CMovimientoInventarioImagen();
				DataTable dt = oCMovimientoInventarioImagen.ListarTodos(Convert.ToInt32(Page.Request.QueryString[KEIDINVENTARIO]));

				
				if(dt != null)
				{
					dt.PrimaryKey = new DataColumn[1]{dt.Columns[Enumerados.ColumnasMovimientoInventarioImagen.IdMovimientoInventarioImagen.ToString()]};
					
					this.chkTieneMovimientos.Checked = true;
					this.tblTituloMovimientos.Visible = true;
					this.tblMovimientos.Visible = true;
					this.chkIngreso.Checked = true;
					this.HabilitarIngresos(true);
					this.HabilitarEgresos(false);
					this.ActualizarGrilla(dt);
					ViewState[KEYQACTUAL] = 0;
					grid.DataSource = dt;
					grid.DataBind();
					grid.Visible = true;
				}
				else
				{
					this.chkTieneMovimientos.Checked = false;
					this.HabilitaMoviemientos(false);
					this.HabilitarIngresos(false);
					this.HabilitarEgresos(false);
					this.CrearDataTable();
				}
				ViewState[KEYQCODIGOINICIAL] = oCMovimientoInventarioImagen.ObtenerMaximoDetallePorRegistroDeMoviemiento(Convert.ToInt32(Page.Request.QueryString[KEIDINVENTARIO]));
				ViewState[KEYQCONTADOR] = ViewState[KEYQCODIGOINICIAL];
				ViewState[KEYQREGISTROSELIMINADOS] = new int [Convert.ToInt32(ViewState[KEYQCONTADOR])-1];
				ViewState[KEYQCONTADORREGISTROSELIMINADOS] = 0;
			}

			calFechaMovimiento.SelectedDate = Convert.ToDateTime(Utilitario.Constantes.FECHAVALORENBLANCO);

			this.imgProyecto.Attributes.Add( Utilitario.Constantes.EVENTOCLICK, Helper.PopupBusqueda(URLIMPRESIONFOTO + KEYNOMBREFOTO + Utilitario.Constantes.SIGNOIGUAL + hImagen.Value.ToString(),750,500,true));
		}

		public void CargarModoConsulta()
		{
			this.CargarModoModificar();
			lblTitulo.Text = TITULOMODOCONSULTA;
			Helper.BloquearControles(this);
			this.ibtnCancelar.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.ibtnAceptar.Visible = Utilitario.Constantes.VALORUNCHECKEDBOOL;
			this.TdCeldaCancelar.Visible = Utilitario.Constantes.VALORCHECKEDBOOL;
			this.HabilitarIngresos(false);
			this.HabilitarEgresos(false);
			this.HabilitaMoviemientos(false);
		}

		public bool ValidarCampos()
		{
			return Utilitario.Constantes.VALORCHECKEDBOOL;
		}

		public bool ValidarCamposRequeridos()
		{
			
			if (calFechaMovimiento.SelectedDate.ToString() == Utilitario.Constantes.FECHAVALORENBLANCO)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPOFECHAMOVIMIENTO));
				return  Utilitario.Constantes.VALORUNCHECKEDBOOL;
			}

			if (chkIngreso.Checked == true)
			{
				#region Ingresos
				if (txtAlta.Text == String.Empty)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPOALTA));
					return  Utilitario.Constantes.VALORUNCHECKEDBOOL;
				}
				
				if (hIdCodigo.Value == String.Empty)
				{
					ltlMensaje.Text =  Helper.MensajeAlert("Debe de Ingresar un Proveedor");
					return  Utilitario.Constantes.VALORUNCHECKEDBOOL;
				}
				if (txtPrecioUnitario.Text == String.Empty)
				{
					ltlMensaje.Text =  Helper.MensajeAlert("Debe de Ingresar el Precio Unitario");
					return  Utilitario.Constantes.VALORUNCHECKEDBOOL;
				}
				#endregion
			}
			else
			{
				#region Egresos
				if (txtBaja.Text == String.Empty)
				{
					ltlMensaje.Text =  Helper.MensajeAlert(Helper.ObtenerMensajesErrorComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPOBAJA));
					return  Utilitario.Constantes.VALORUNCHECKEDBOOL;
				}
				if (txtPrecioUnitarioEgresos.Text == String.Empty)
				{
					ltlMensaje.Text =  Helper.MensajeAlert("Tiene que ingresar el precio Unitario del Egreso");
					return  Utilitario.Constantes.VALORUNCHECKEDBOOL;
				}
				#endregion
			}
			
			return Utilitario.Constantes.VALORCHECKEDBOOL;
		}

		public bool ValidarExpresionesRegulares()
		{
			return true;
		}

		#endregion

		#region IPaginaBase Members
		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
		}

		public void LlenarCombos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			dllGrupo.DataSource =  oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.GrupoArticulos));
			dllGrupo.DataValueField = Enumerados.ColumnasTablaTablas.Var2.ToString();
			dllGrupo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			dllGrupo.DataBind();

			dllSubGrupo.DataSource =  oCTablaTablas.ListaTodosCombo(Convert.ToInt32(dllGrupo.SelectedValue));
			dllSubGrupo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			dllSubGrupo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			dllSubGrupo.DataBind();

			ddlMotivo.DataSource =	oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.MotivosEgresos));
			ddlMotivo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMotivo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMotivo.DataBind();

			ddlMoneda.DataSource =	oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlMoneda.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMoneda.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMoneda.DataBind();

			ddlMoneda.SelectedValue = Utilitario.Constantes.ValorConstanteUno.ToString();

			ddlMonedaEgresos.DataSource =	oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Moneda));
			ddlMonedaEgresos.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlMonedaEgresos.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlMonedaEgresos.DataBind();

			ddlMonedaEgresos.SelectedValue = Utilitario.Constantes.ValorConstanteUno.ToString();

			ddlIdioma.DataSource =	oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.Idiomas));
			ddlIdioma.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlIdioma.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlIdioma.DataBind();
		}

		public void LlenarDatos()
		{
			ViewState[KEYQACTUAL]=0;
			ViewState[KEYQCAMBIOS]="0";
			Helper.CalendarioControlStyle(this.calFechaMovimiento);
		}

		public void LlenarJScript()
		{

			this.filMyFile.Attributes.Add( Utilitario.Constantes.EVENTOONBLUR, JMOSTRARIMAGEN);

			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARELIMINAR);
			this.ibtnEliminar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,JSVERIFICARSELECCIONFILA);
			
			this.rfvNombre.ErrorMessage = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPONOMBRE);
			this.rfvNombre.ToolTip = Helper.ObtenerMensajesConfirmacionComercialUsuario(Mensajes.CODIGOMENSAJEREQUERIMIENTOCAMPONOMBRE);

			this.ibtnBuscarProveedor.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Helper.PopupBusqueda(URLBUSQUEDAPROVEEDOR,750,500,true));
		}

		public void RegistrarJScript()
		{
		}

		public void Imprimir()
		{
		}

		public void Exportar()
		{
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
			return true;
		}

		#endregion

		#region Controles
		protected System.Web.UI.WebControls.Label lblGrupoCC;
		protected System.Web.UI.WebControls.Label lblCC;
		protected System.Web.UI.WebControls.Label lblPrecioUnitario;
		protected eWorld.UI.NumericBox txtPrecioUnitario;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvBaja;
		protected System.Web.UI.WebControls.Label lblDescripcionClick;
		protected System.Web.UI.WebControls.Label lblObservacionesClick;
		protected System.Web.UI.WebControls.TextBox txtObservacionesClick;
		protected System.Web.UI.WebControls.TextBox txtDescripcionClick;
		protected System.Web.UI.HtmlControls.HtmlTable tblTextos;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.TextBox txtObservacionesMovimiento;
		protected System.Web.UI.WebControls.TextBox txtDescripcionMovimiento;
		protected System.Web.UI.WebControls.Label lblFechaMovimiento;
		protected System.Web.UI.WebControls.Label lblAsunto;
		protected System.Web.UI.WebControls.Label lblObservacionesMovimiento;
		protected System.Web.UI.WebControls.Label lblDescripcionObservaciones;
		protected eWorld.UI.CalendarPopup calFechaMovimiento;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvFechaMovimiento;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblTitulodos;
		protected System.Web.UI.WebControls.Label lblNombre;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.Image imgProyecto;
		protected System.Web.UI.WebControls.Label lblDescripcion;
		protected System.Web.UI.WebControls.Label lblObservaciones;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.Label lblGrupo;
		protected System.Web.UI.WebControls.DropDownList dllGrupo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList dllSubGrupo;
		protected System.Web.UI.WebControls.Label lblMovimientos;
		protected System.Web.UI.WebControls.CheckBox chkTieneMovimientos;
		protected System.Web.UI.HtmlControls.HtmlInputFile filMyFile;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvAlta;
		protected System.Web.UI.WebControls.Label lblMovimiento;
		protected System.Web.UI.WebControls.Label lblAlta;
		protected System.Web.UI.WebControls.Label lblIngresos;
		protected eWorld.UI.NumericBox txtAlta;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.Label lblEgresos;
		protected System.Web.UI.WebControls.CheckBox Checkbox1;
		protected System.Web.UI.WebControls.CheckBox Checkbox2;
		protected System.Web.UI.WebControls.Label lblBaja;
		protected eWorld.UI.NumericBox txtBaja;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvNombre;
		protected System.Web.UI.WebControls.Label lblSubGrupo;
		protected System.Web.UI.WebControls.Label lblProveedor;
		protected System.Web.UI.WebControls.CheckBox chkIngreso;
		protected System.Web.UI.WebControls.CheckBox chkEgreso;
		protected System.Web.UI.HtmlControls.HtmlTable tblTituloIngreso;
		protected System.Web.UI.HtmlControls.HtmlTable tblIngresos;
		protected System.Web.UI.HtmlControls.HtmlTable tblTituloEgresos;
		protected System.Web.UI.WebControls.ImageButton ibtnAgregar;
		protected System.Web.UI.WebControls.ImageButton ibtnModificar;
		protected System.Web.UI.WebControls.ImageButton ibtnEliminar;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected System.Web.UI.WebControls.Label lblCalculado;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlTableCell TdCeldaCancelar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdMovimiento;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hImagen;
		protected System.Web.UI.HtmlControls.HtmlTable tblMovimientos;
		protected System.Web.UI.HtmlControls.HtmlTable tblTituloMovimientos;
		protected System.Web.UI.HtmlControls.HtmlTable tblEgresos;
		protected System.Web.UI.WebControls.ImageButton ibtnBuscarProveedor;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;
		protected System.Web.UI.WebControls.TextBox txtEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTablaEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdEntidad;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCodigo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNumero;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodigo;
		protected System.Web.UI.WebControls.Label lblCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList dllCentroOperativo;
		protected System.Web.UI.WebControls.DropDownList dllGrupoCC;
		protected System.Web.UI.WebControls.DropDownList dllCC;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected eWorld.UI.NumericBox txtTotal;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvPrecioUnitario;
		protected System.Web.UI.WebControls.Label lblMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlMoneda;
		protected System.Web.UI.WebControls.DropDownList ddlMotivo;
		protected System.Web.UI.WebControls.Label lblIdioma;
		protected System.Web.UI.WebControls.DropDownList ddlIdioma;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlIdioma;
		protected System.Web.UI.WebControls.Label lblMinimo;
		protected eWorld.UI.NumericBox txtMinimo;
		#endregion

		#region Constantes
		const string URLIMPRESIONFOTO="PopupImagenInventarioImagen.aspx?";
		const string ROWNOMBREMONEDA="moneda";
		const string ROWNOMBREMOTIVO="motivo";
		const string ROWTOTAL="total";
		const string ROWPRECIOUNITARIO="PrecioUnitario";
		const string KEYQACTUAL = "cantidadActual";
		const string ROWDESCRIPCIONTIPO="DescripcionTipo";
		const string ROWNOMBREPROVEEDOR="NombreProveedor";
		const string ROWNOMBRECENTROCOSTO="NombreCentroCosto";
		const string KEYNOMBREFOTO="Foto";
		const string KEYQID = "Id";
		const string KEYQDATATABLE = "DataTable";
		const string KEYQCONTADOR = "Contador";
		const string KEYQCODIGOINICIAL = "CodigoInicial";
		const string KEYQREGISTROSELIMINADOS = "RegistrosEliminados";
		const string KEYQCONTADORREGISTROSELIMINADOS = "ContadorRegistrosEliminados";
		const string MENSAJECONSULTAR = "Se consulto el Detalle de Inventarios";
		const string MENSAJEREGITRO="Se registró el Registro de Visita Nro. ";
		const string TITULOMODONUEVO="Registrar Articulo";
		const string KEIDINVENTARIO="IdInventario";
		const string TITULOMODOMODIFICAR="Modificar Articulo";
		const string MENSAJEMODIFICAR="";
		const string Estado="Tipo";
		const string SeparadorExtencion=".";
		const string ARCHIVO = "sinfoto.jpg";
		const int TAMANOARCHIVO=5000000;
		const string TITULOMODOCONSULTA="CONSULTAR ARTICULOS";
		const string KEYQCAMBIOS="CAMBIOS";
		const string URLADMINISTRACION="AdministrarInventarioImagen.aspx";
		#endregion

		#region Variables
		//Jscript
		private string JSVERIFICARELIMINAR = "return verificarEliminarRb('hCodigo','" + Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO)+"','"+Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJEPREGUNTAELIMINACIONREGISTRO)+"');";
		private string JSVERIFICARSELECCIONFILA="return verificarSeleccionRb('hCodigo','"+ Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO) + "');";
		private string URLBUSQUEDAPROVEEDOR ="../../Legal/BusquedaEntidad.aspx?"+ Utilitario.Constantes.KEYTIPOBUSQUEDAENTIDAD + Utilitario.Constantes.SIGNOIGUAL + Enumerados.TipoBusquedaEntidad.PRO.ToString();
		private string RutaImagenServerProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenServerProyectoEjecucionTerminado);
		private string JMOSTRARIMAGEN = "MuestraImagen('imgProyecto',document.forms[0].filMyFile,1)";
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;

		protected eWorld.UI.NumericBox txtPrecioUnitarioEgresos;
		protected System.Web.UI.WebControls.DropDownList ddlMonedaEgresos;
		protected eWorld.UI.NumericBox txtInversionTotal;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllGrupoCC;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllCentroOperativo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllCC;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllGrupo;
		protected System.Web.UI.HtmlControls.HtmlTableCell CelldllSubGrupo;
		protected System.Web.UI.WebControls.ValidationSummary vSum;
		private string RutaImagenCarpetaProyecto = Helper.ObtenerRutaImagenes(Utilitario.Constantes.ProyectoRutaImagenCarpetaProyectoEjecucionTerminado);
		#endregion	

		#region Eventos
		public void GuardarImagen() 
		{
			HttpPostedFile myFile = filMyFile.PostedFile;
			int nFileLen = myFile.ContentLength; 
					
			if( nFileLen > Utilitario.Constantes.ValorConstanteCero)
			{
				if(nFileLen <= TAMANOARCHIVO)
				{	
					byte[] myData = new byte[nFileLen];

					myFile.InputStream.Read(myData, Utilitario.Constantes.ValorConstanteCero, nFileLen);
					string path = RutaImagenCarpetaProyecto;
					string strFilename = myFile.FileName;

					string[] res = strFilename.Split('\\');
					int i=res.GetUpperBound(Utilitario.Constantes.ValorConstanteCero);
					strFilename = res[i];
							
					Helper.GuardarImagenServidor(myData,path + strFilename);
				}
			}		
			
		}

		private void CrearDataTable()
		{
			DataTable dt = new DataTable("DataTableMovimientoInventarios");
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdMovimientoInventarioImagen.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdInventarioImagen.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.FechaMovimiento.ToString(), Type.GetType("System.DateTime"));
			dt.Columns.Add(ROWDESCRIPCIONTIPO);
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.Observaciones.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.Descripcion.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdTipoMovimiento.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdProveedor.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdResponsable.ToString());
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.Cantidad.ToString());
			dt.Columns.Add(Estado);
			dt.Columns.Add(ROWNOMBREPROVEEDOR);
			dt.Columns.Add(ROWNOMBRECENTROCOSTO);
			dt.Columns.Add(ROWPRECIOUNITARIO);
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdMoneda.ToString());
			dt.Columns.Add(ROWNOMBREMONEDA);
			dt.Columns.Add(Enumerados.ColumnasMovimientoInventarioImagen.IdMotivo.ToString());
			dt.Columns.Add(ROWNOMBREMOTIVO);
			dt.Columns.Add(ROWTOTAL);

			ViewState[KEYQDATATABLE] = dt;
			ViewState[KEYQCONTADOR] = 1;
			dt.PrimaryKey = new DataColumn[1]{dt.Columns[Enumerados.ColumnasMovimientoInventarioImagen.IdMovimientoInventarioImagen.ToString()]};
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.CrearDataTable();
					this.LlenarJScript();
					this.LlenarDatos();
					this.LlenarCombos();
					this.CargarModoPagina();
					this.LlenarJScript();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Utilitario.Enumerados.NombresdeModulo.GestiónComercial.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Utilitario.Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}

		private void ActualizarGrilla(DataTable dt)
		{
			ViewState[KEYQDATATABLE] = dt;

			if(ViewState[KEYQDATATABLE] != null)
			{
				this.grid.DataSource = dt;
				this.grid.Visible = true;
			}
			else
			{
				this.grid.DataSource = null;
				this.grid.Visible = false;
			}
			this.grid.DataBind();
		}

		public void HabilitarIngresos(bool valor)
		{
			this.tblTituloIngreso.Visible = valor;
			this.tblIngresos.Visible = valor;
		}

		public void HabilitarEgresos(bool valor)
		{
			this.tblTituloEgresos.Visible = valor;
			this.tblEgresos.Visible = valor;
		}

		public void HabilitaMoviemientos(bool valor)
		{
			this.tblMovimientos.Visible = valor;
			this.tblTituloMovimientos.Visible = valor;
			this.tblTextos.Visible = valor;
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

			if (chkTieneMovimientos.Checked == true)
			{
				ViewState[KEYQACTUAL] = 0;
				if (ValidarCamposRequeridos() == true)
				{
					if (chkTieneMovimientos.Checked == Utilitario.Constantes.VALORCHECKEDBOOL)
					{
						ViewState[KEYQCAMBIOS]="1";
					
						DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
						int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
						DataRow dr = dt.NewRow();
			
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;
				
						if (chkIngreso.Checked == true)
						{
							#region Para Ingresos
							dr.ItemArray = new object [19] {
															   contador,
															   Page.Request.QueryString[KEIDINVENTARIO],
															   calFechaMovimiento.SelectedDate,
															   "Ingreso",
															   txtObservacionesMovimiento.Text,
															   txtDescripcionMovimiento.Text,
															   Utilitario.Constantes.TIPOMOVIMIENTOINGRESO,
															   hIdCodigo.Value,
															   0,
															   Convert.ToInt32(txtAlta.Text),
															   Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar),
															   txtEntidad.Text,
															   "-",
															   txtPrecioUnitario.Text.ToString(),
															   ddlMoneda.SelectedValue,
															   ddlMoneda.SelectedItem.Text,
															   ddlMotivo.SelectedValue,
															   ddlMotivo.SelectedItem.Text,
															   Convert.ToDouble(txtTotal.Text)
							};	
			
							#endregion
						}
						else
						{
							#region Para Egresos
							dr.ItemArray = new object [19] {
															   contador,
															   Page.Request.QueryString[KEIDINVENTARIO],
															   calFechaMovimiento.SelectedDate,
															   "Egreso",
															   txtObservacionesMovimiento.Text,
															   txtDescripcionMovimiento.Text,
															   Utilitario.Constantes.TIPOMOVIMIENTOEGRESO,
															   0,
															   dllCC.SelectedValue,
															   Convert.ToInt32(txtBaja.Text),
															   Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar),
															   dllCC.SelectedItem.Text,
															   dllCC.SelectedItem.Text,
															   txtPrecioUnitarioEgresos.Text.ToString(),
															   ddlMonedaEgresos.SelectedValue,
															   ddlMonedaEgresos.SelectedItem.Text,
															   ddlMotivo.SelectedValue,
															   ddlMotivo.SelectedItem.Text,
															   Convert.ToDouble(txtInversionTotal.Text)						
														   };
							#endregion
						}
						dt.Rows.Add(dr);
						ViewState[KEYQCONTADOR] = ++contador;
						this.ActualizarGrilla(dt);
						this.LimpiarCamposMovimientos();
					}
				}
			}
		}

		private void LimpiarCamposMovimientos()
		{
			hIdMovimiento.Value = Utilitario.Constantes.VACIO;
			hCodigo.Value = Utilitario.Constantes.VACIO;
			hIdEntidad.Value = Utilitario.Constantes.VACIO;
			hIdTablaEntidad.Value = Utilitario.Constantes.VACIO;
			hNumero.Value = Utilitario.Constantes.VACIO;
			
			txtEntidad.Text = Utilitario.Constantes.VACIO;
			txtAlta.Text = Utilitario.Constantes.VACIO;
			txtBaja.Text = Utilitario.Constantes.VACIO;
			txtDescripcionMovimiento.Text = Utilitario.Constantes.VACIO;
			txtObservacionesMovimiento.Text = Utilitario.Constantes.VACIO;
			calFechaMovimiento.Text = Utilitario.Constantes.FECHAVALORENBLANCO;
			calFechaMovimiento.SelectedDate = Convert.ToDateTime(Utilitario.Constantes.FECHAVALORENBLANCO);
			txtPrecioUnitario.Text = String.Empty;
			txtDescripcionClick.Text = String.Empty;
			txtObservacionesClick.Text = String.Empty;
			txtTotal.Text = String.Empty;
			txtPrecioUnitarioEgresos.Text = String.Empty;
			txtInversionTotal.Text = String.Empty;
		}
		
		private void chkTieneMovimientos_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkTieneMovimientos.Checked == true)
			{
				this.HabilitaMoviemientos(true);
				this.chkIngreso.Checked = true;
				this.HabilitarIngresos(true);
			}
			else
			{
				this.HabilitaMoviemientos(false);
				this.HabilitarIngresos(false);
				this.HabilitarEgresos(false);
				this.LimpiarCamposMovimientos();
			}
		}

		private void ibtnModificar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			/*
			if (ValidarCamposRequeridos() == true)
			{
				if (chkTieneMovimientos.Checked == true)
				{
					ViewState[KEYQCAMBIOS]="1";
					try
					{
						if(this.hIdMovimiento.Value.Length==0)
						{
							ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
						}
						else
						{
							DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
							Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA]) ;

							switch (oModoPagina)
							{
								case Enumerados.ModoPagina.N:
								{
							
									dt.Rows.Find(this.hIdMovimiento.Value).ItemArray 
										= new object [10] {
															  Convert.ToInt32(this.hIdMovimiento.Value),
															  Page.Request.QueryString[KEIDINVENTARIO],
															  Convert.ToInt32(txtAlta.Text),
															  Convert.ToInt32(txtBaja.Text),
															  calFechaMovimiento.SelectedDate,
															  txtAsunto.Text,
															  Convert.ToInt32(txtAlta.Text) - Convert.ToInt32(txtBaja.Text),
															  txtObservacionesMovimiento.Text,
															  txtDescripcionMovimiento.Text,
															  Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)
													 
														  };
									break;
								}
								case Enumerados.ModoPagina.M:
								{
									dt.Rows.Find(this.hIdMovimiento.Value).ItemArray  = new object [10] {
																											Convert.ToInt32(this.hIdMovimiento.Value),
																											Page.Request.QueryString[KEIDINVENTARIO],
																											Convert.ToInt32(txtAlta.Text),
																											Convert.ToInt32(txtBaja.Text),
																											calFechaMovimiento.SelectedDate,
																											txtAsunto.Text,
																											Convert.ToInt32(txtAlta.Text) - Convert.ToInt32(txtBaja.Text),
																											txtObservacionesMovimiento.Text,
																											txtDescripcionMovimiento.Text,
																											//Convert.ToInt32(ViewState[KEYQCODIGOINICIAL])>Convert.ToInt32(this.hIdMovimiento.Value)?Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Modificar):Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Agregar)
																											Convert.ToInt32(Enumerados.TipoLogicaCabeceraDetalle.Modificar)
																										};
									break;
								}
							}

					
				
							this.ActualizarGrilla(dt);
							this.LimpiarCamposMovimientos();
						}
					}
					catch(Exception ex)
					{
						string a = ex.Message;
						this.LimpiarCamposMovimientos();
					}
				}
			}
			*/
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				
				e.Item.Cells[Utilitario.Constantes.POSICIONINDEXCERO].Text=Helper.ObtenerIndicedeRegistro(grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex); 
		
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e,
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula(hCodigo.ID,dr[Enumerados.ColumnasMovimientoInventarioImagen.IdMovimientoInventarioImagen.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula(txtObservacionesClick.ID, dr[Enumerados.ColumnasMovimientoInventarioImagen.Observaciones.ToString()].ToString()),
					Utilitario.Helper.MostrarDatosEnCajaTextoManteniendoMayusculaMinuscula(txtDescripcionClick.ID,dr[Enumerados.ColumnasMovimientoInventarioImagen.Descripcion.ToString()].ToString())
					);
			
				if (dr[Enumerados.ColumnasMovimientoInventarioImagen.IdTipoMovimiento.ToString()].ToString() == Utilitario.Constantes.TIPOMOVIMIENTOEGRESO.ToString())
				{
					ViewState[KEYQACTUAL]= Convert.ToInt32(ViewState[KEYQACTUAL]) - Convert.ToInt32(dr[Enumerados.ColumnasMovimientoInventarioImagen.Cantidad.ToString()].ToString());
				}
				else
				{
					ViewState[KEYQACTUAL]= Convert.ToInt32(ViewState[KEYQACTUAL]) + Convert.ToInt32(dr[Enumerados.ColumnasMovimientoInventarioImagen.Cantidad.ToString()].ToString());
				}

				lblCalculado.Text = "ACTUAL: " + ViewState[KEYQACTUAL].ToString();	
			} 
		}
	
		private void ibtnEliminar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if (chkTieneMovimientos.Checked == true)
			{
				ViewState[KEYQACTUAL] = 0;
				ViewState[KEYQCAMBIOS]="1";
				try
				{
					if(this.hCodigo.Value.Length==0)
					{
						ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacion.ToString(),Mensajes.CODIGOMENSAJESELECCIONREGISTRO));
					}
					else
					{
						DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
						dt.Rows.Find(this.hCodigo.Value).Delete();
						dt.AcceptChanges();
						if(Page.Request.QueryString[Utilitario.Constantes.KEYMODOPAGINA].ToString() == Enumerados.ModoPagina.M.ToString())
						{
							if(Convert.ToInt32(this.hCodigo.Value) < Convert.ToInt32(ViewState[KEYQCODIGOINICIAL]))
							{
								int contador = Convert.ToInt32(ViewState[KEYQCONTADORREGISTROSELIMINADOS]);
								((int[])ViewState[KEYQREGISTROSELIMINADOS])[contador] = Convert.ToInt32(this.hCodigo.Value);
								ViewState[KEYQCONTADORREGISTROSELIMINADOS] = ++contador;
							}
						}
						this.ActualizarGrilla(dt);
						this.LimpiarCamposMovimientos();
					}
				}
				catch(Exception ex)
				{
					string a = ex.Message;
					this.LimpiarCamposMovimientos();
				}
			}
		}

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect(URLADMINISTRACION);
		}

		private void chkIngreso_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkIngreso.Checked == true)
			{
				this.HabilitarIngresos(true);
				this.HabilitarEgresos(false);
				this.chkEgreso.Checked = false;
			}
			else
			{
				this.HabilitarIngresos(false);
			}
		}

		private void chkEgreso_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.chkEgreso.Checked == true)
			{
				this.HabilitarEgresos(true);
				this.HabilitarIngresos(false);
				this.chkIngreso.Checked = false;
				this.cargarCombosEgresos();
			}
			else
			{
				this.HabilitarEgresos(false);
			}
		}

		private void cargarCombosEgresos()
		{
			CCentroOperativo oCCentroOperativo = new CCentroOperativo();
			dllCentroOperativo.DataSource = oCCentroOperativo.ListarTodosCombo();
			dllCentroOperativo.DataValueField = Enumerados.ColumnasCentroOperativo.IdCentroOperativo.ToString();
			dllCentroOperativo.DataTextField = Enumerados.ColumnasCentroOperativo.Nombre.ToString();
			dllCentroOperativo.DataBind();

			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			dllGrupoCC.DataSource = oCGrupoCentroCosto.ListarGrupoCCPorCentroOperativo(Convert.ToInt32(dllCentroOperativo.SelectedValue));
			dllGrupoCC.DataValueField = Enumerados.ColumnasGrupoCentroCosto.IdGrupoCC.ToString();
			dllGrupoCC.DataTextField = Enumerados.ColumnasGrupoCentroCosto.Nombre.ToString();
			dllGrupoCC.DataBind();

			CCentroCosto oCCentroCosto = new CCentroCosto();
			dllCC.DataSource = oCCentroCosto.ListarCentroCostoPorGrupoCC(Convert.ToInt32(dllGrupoCC.SelectedValue));
			dllCC.DataValueField = Enumerados.ColumnaCentroCosto.IdCentroCosto.ToString();
			dllCC.DataTextField = Enumerados.ColumnaCentroCosto.Nombre.ToString();
			dllCC.DataBind();

		}

		private void dllGrupo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			dllSubGrupo.DataSource =  oCTablaTablas.ListaTodosCombo(Convert.ToInt32(dllGrupo.SelectedValue));
			dllSubGrupo.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			dllSubGrupo.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			dllSubGrupo.DataBind();
		}

		private void dllCentroOperativo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			dllGrupoCC.DataSource = oCGrupoCentroCosto.ListarGrupoCCPorCentroOperativo(Convert.ToInt32(dllCentroOperativo.SelectedValue));
			dllGrupoCC.DataValueField = Enumerados.ColumnasGrupoCentroCosto.IdGrupoCC.ToString();
			dllGrupoCC.DataTextField = Enumerados.ColumnasGrupoCentroCosto.Nombre.ToString();
			dllGrupoCC.DataBind();

			CCentroCosto oCCentroCosto = new CCentroCosto();
			dllCC.DataSource = oCCentroCosto.ListarCentroCostoPorGrupoCC(Convert.ToInt32(dllGrupoCC.SelectedValue));
			dllCC.DataValueField = Enumerados.ColumnaCentroCosto.IdCentroCosto.ToString();
			dllCC.DataTextField = Enumerados.ColumnaCentroCosto.Nombre.ToString();
			dllCC.DataBind();
		}

		#endregion

		private void dllGrupoCC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CCentroCosto oCCentroCosto = new CCentroCosto();
			dllCC.DataSource = oCCentroCosto.ListarCentroCostoPorGrupoCC(Convert.ToInt32(dllGrupoCC.SelectedValue));
			dllCC.DataValueField = Enumerados.ColumnaCentroCosto.IdCentroCosto.ToString();
			dllCC.DataTextField = Enumerados.ColumnaCentroCosto.Nombre.ToString();
			dllCC.DataBind();
		}

		private void txtPrecioUnitario_TextChanged(object sender, System.EventArgs e)
		{
			if (txtAlta.Text != String.Empty && txtPrecioUnitario.Text != String.Empty)
			{
				txtTotal.Text =  Convert.ToString(Convert.ToDouble(txtPrecioUnitario.Text) * Convert.ToInt32(txtAlta.Text));
			}
		}

		private void txtPrecioUnitarioEgresos_TextChanged(object sender, System.EventArgs e)
		{
			if (txtBaja.Text != String.Empty && txtPrecioUnitarioEgresos.Text != String.Empty)
			{
				txtInversionTotal.Text =  Convert.ToString(Convert.ToDouble(txtPrecioUnitarioEgresos.Text) * Convert.ToInt32(txtBaja.Text));
			}
		}
	}
}
