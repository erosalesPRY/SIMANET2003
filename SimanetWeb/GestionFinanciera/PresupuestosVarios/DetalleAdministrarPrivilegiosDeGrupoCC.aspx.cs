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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using SIMA.EntidadesNegocio.GestionFinanciera;
using NetAccessControl;

namespace SIMA.SimaNetWeb.GestionFinanciera.PresupuestosVarios
{
	/// <summary>
	/// Summary description for DetalleAdministrarPrivilegiosDeGrupoCC.
	/// </summary>
	public class DetalleAdministrarPrivilegiosDeGrupoCC : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region controles
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPresupuesto;
		
		protected System.Web.UI.WebControls.DropDownList ddlbTipoPresupuestoo;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroGrupoCC;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox txtNombreGrupoCC;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.ImageButton ibtnCancelar;
		protected System.Web.UI.WebControls.ListBox lstListaUsuariosAsignados;
		protected System.Web.UI.WebControls.Button btnAñadir;
		protected System.Web.UI.WebControls.Button btnQuitar;
		protected System.Web.UI.WebControls.ListBox lstListaUsuarios;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		

		#endregion controles
		#region Constantes
		const string URLPRINCIPAL = "AdministrarPrivilegiosDeGrupoCC.aspx";
		const string TITULOMODONUEVO = "NUEVO GRUPO DE CENTRO DE COSTOS";
		const string TITULOMODOMODIFICAR = "GRUPO DE CENTRO DE COSTOS";
		
		
		const string GRILLAVACIA="No existe Usuarios asignados al Grupo de Centro de Costos";
		const string KEYQIDGRUPOCC = "IdGrupoCC";
	
		const string KEYQDATATABLE = "DataTable";
		const string KEYQDATATABLE2 = "DataTable2";
		const string KEYQCONTADOR = "Contador";
		const string KEYQTIPOPPTO ="TipoPpto";
		const string KEYQNROGRUPOCC = "NroGrupoCC";

		//Otros
		const string MENSAJE ="Debe Seleccionar un Usuario de lista";
		const string SESSIONID2 ="id2";
		const string SESSIONID3 ="id3";

		//DataGrid and DataTable
		const string DATATABLELISTAUSUARIOS ="DataTableListaUsuarios";
		const string DATATABLELISTAUSRASIGNADOS ="DataTableListaUsuariosAsignados";
		const string COLUMNAIDUSUARIO ="idusuario";
		const string COLUMNANOMBRE ="Nombre";


		int flag;
	
		
		ListItem  lItem ;

		#endregion Constantes
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.CrearDataTable();
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
			this.lstListaUsuarios.SelectedIndexChanged += new System.EventHandler(this.lstListaUsuarios_SelectedIndexChanged);
			this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
			this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
			this.lstListaUsuariosAsignados.SelectedIndexChanged += new System.EventHandler(this.lstListaUsuariosAsignados_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.ibtnCancelar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnCancelar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			lItem = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			this.llenarTipoPresupuestos();
			this.ddlbTipoPresupuestoo.Items.Insert(0,lItem);
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.Exportar implementation
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
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.Agregar implementation
		}

		public void Modificar()
		{
			GrupoCentroCostoBE oGrupoCentroCostoBE = new GrupoCentroCostoBE();
			
			DataTable dt = ((DataTable)ViewState[KEYQDATATABLE2]).Copy();
			
			oGrupoCentroCostoBE.IdUsuarioRegistro = Convert.ToInt32(dt.Rows[0][0]);
			oGrupoCentroCostoBE.IdGrupoCC = Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]);
			oGrupoCentroCostoBE.IdTipoPresupuestoCuenta =Convert.ToInt32(Page.Request.QueryString[KEYQTIPOPPTO]);
			oGrupoCentroCostoBE.NroGrupoCC=Page.Request.QueryString[KEYQNROGRUPOCC].ToString();
			oGrupoCentroCostoBE.Idtransaccion=Utilitario.Constantes.ValorConstanteCero;

		
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			int retorno= oCGrupoCentroCosto.AgregarPrivilegiosGrupo(oGrupoCentroCostoBE,(DataTable)ViewState[KEYQDATATABLE2], 
																	Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]),
																	Convert.ToInt32(Page.Request.QueryString[KEYQTIPOPPTO]),
																	Convert.ToInt32(Page.Request.QueryString[KEYQNROGRUPOCC]));
			
			if(retorno>0)
			{
			//	Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Gestion Financiera",this.ToString(),"Se registró el privilegio Nro. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));

				ltlMensaje.Text = Helper.MensajeRetornoAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionComercial.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONREGISTROREGISTROVISITA),URLPRINCIPAL);
			}

		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			
			lblTitulo.Text = TITULOMODOMODIFICAR;
			this.LlenarCombos();
						
			CMantenimientos	oCMantenimientos = new CMantenimientos();
			GrupoCentroCostoBE oGrupoCentroCostoBE = (GrupoCentroCostoBE)oCMantenimientos.ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]),Enumerados.ClasesNTAD.GrupoCentroCostoNTAD.ToString());
			
			//Graba en el Log la acción ejecutada
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Documentaria",this.ToString(),"Se consultó el Detalle del Grupo de Centro de Costo Nro. " + Page.Request.QueryString[KEYQIDGRUPOCC] + ".",Enumerados.NivelesErrorLog.I.ToString()));

			if(oGrupoCentroCostoBE!=null)
			{
			
				this.txtNroGrupoCC.Text = oGrupoCentroCostoBE.NroGrupoCC.ToString();
				this.txtNombreGrupoCC.Text = oGrupoCentroCostoBE.Nombre.ToString();
				this.ddlbTipoPresupuestoo.Items.FindByValue(oGrupoCentroCostoBE.IdTipoPresupuestoCuenta.ToString()).Selected = true;
				
			}
			llenarUsuariosAsignados();
			llenarListaUsuarios();
			//this.cargaControles();

		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAdministrarPrivilegiosDeGrupoCC.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion


		public void llenarTipoPresupuestos()
		{
		
			CGrupoCentroCosto oCGrupoCentroCosto = new CGrupoCentroCosto();
			this.ddlbTipoPresupuestoo.DataSource = oCGrupoCentroCosto.ListarTodosComboPresupuesto();
			ddlbTipoPresupuestoo.DataValueField =Enumerados.ColumnaTipoPresupuesto.idTipoPresupuesto.ToString();
			ddlbTipoPresupuestoo.DataTextField =Enumerados.ColumnaTipoPresupuesto.nombre.ToString();
			ddlbTipoPresupuestoo.DataBind();
		
		}

		public void llenarUsuariosAsignados()
		{
			CPrivilegiosGrupoCentroCosto oCPrivilegiosGrupoCentroCosto = new CPrivilegiosGrupoCentroCosto();
			DataTable dtDetalle = oCPrivilegiosGrupoCentroCosto.ListarTodosGrillaDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]));
			
			if(dtDetalle!=null)
			{
				DataTable dt = ((DataTable)ViewState[KEYQDATATABLE2]).Copy();
			
				int i;
				
				for(i=0; i<dtDetalle.Rows.Count;i++)
				{
					DataRow dr = dt.NewRow();
					dr.ItemArray = new object [2]     {dtDetalle.Rows[i][0],
													   dtDetalle.Rows[i][1]};
						
					dt.Rows.Add(dr);
				}
				ViewState[KEYQDATATABLE2]= dt;
				int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
				
				if(dtDetalle!=null)
				{
				
					this.lstListaUsuariosAsignados.DataSource=dt.DefaultView;
					this.lstListaUsuariosAsignados.DataValueField=COLUMNAIDUSUARIO;
					this.lstListaUsuariosAsignados.DataTextField=COLUMNANOMBRE;

					try
					{
						this.lstListaUsuariosAsignados.DataBind();
					}
					catch(Exception oException)
					{
						string mensaje=oException.Message;
				
					}
						
				}
			}
		
		}

		public void llenarListaUsuarios()
		{
			
			 CPrivilegiosGrupoCentroCosto oCPrivilegiosGrupoCentroCosto = new CPrivilegiosGrupoCentroCosto();
			 DataTable dtDetalle = oCPrivilegiosGrupoCentroCosto.ListarUsuarios(NetAccessControl.CNetAccessControl.GetIdUser());
			
			if(dtDetalle!=null)
			{
				DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
				int i;
				
				for(i=0; i<dtDetalle.Rows.Count;i++)
				{
					DataRow dr1 = dt.NewRow();
					dr1.ItemArray = new object [2] {dtDetalle.Rows[i][0],
													dtDetalle.Rows[i][1]};
					dt.Rows.Add(dr1);
				}
				  
					int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);

					CPrivilegiosGrupoCentroCosto oCPrivilegiosGrupoCentroCosto2 = new CPrivilegiosGrupoCentroCosto();
					DataTable dt3 = oCPrivilegiosGrupoCentroCosto2.ListarTodosGrillaDetalle(Convert.ToInt32(Page.Request.QueryString[KEYQIDGRUPOCC]));
					if(dt3!=null)
					{
							for(i=0; i<dt3.Rows.Count;i++)
							{
								dt.Rows.Find(dt3.Rows[i][0]).Delete();
								dt.AcceptChanges();
							}
					 }			
					this.lstListaUsuarios.DataSource=dt.DefaultView;
					this.lstListaUsuarios.DataValueField=COLUMNAIDUSUARIO;
					this.lstListaUsuarios.DataTextField=COLUMNANOMBRE;

					try
					{
						this.lstListaUsuarios.DataBind();
						
						ViewState[KEYQDATATABLE]= dt;
						
					}
					catch(Exception oException)
					{
						string mensaje=oException.Message;
				
					}	
				
			}
						
		}

		private void CrearDataTable()
		{
			DataTable dt = new DataTable(DATATABLELISTAUSUARIOS);
			dt.Columns.Add(Enumerados.ColumnaListaUsuarios.idUsuario.ToString());
			dt.Columns.Add(Enumerados.ColumnaListaUsuarios.nombre.ToString());
			dt.PrimaryKey = new DataColumn[1]{dt.Columns[Enumerados.ColumnaListaUsuarios.idUsuario.ToString()]};
			ViewState[KEYQDATATABLE] = dt;
						

			DataTable dt2 = new DataTable(DATATABLELISTAUSRASIGNADOS);
			dt2.Columns.Add(Enumerados.ColumnaListaUsuarios.idUsuario.ToString());
			dt2.Columns.Add(Enumerados.ColumnaListaUsuarios.nombre.ToString());
			dt2.PrimaryKey = new DataColumn[1]{dt2.Columns[Enumerados.ColumnaListaUsuarios.idUsuario.ToString()]};
			ViewState[KEYQDATATABLE2] = dt2;
			ViewState[KEYQCONTADOR] = 1;
			
		}

		
		private void btnAñadir_Click(object sender, System.EventArgs e)
		{	
			
			if(this.lstListaUsuarios.SelectedIndex != -1)
			{
				DataTable dt = ((DataTable)ViewState[KEYQDATATABLE2]).Copy();
				int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
				DataRow dr = dt.NewRow();
				dr.ItemArray = new object [2] {
												 
												  this.lstListaUsuarios.SelectedValue,
												  this.lstListaUsuarios.SelectedItem.Text};

				dt.Rows.Add(dr);
				ViewState[KEYQCONTADOR] = ++contador;
				this.ActualizarListaUsuariosAsignados(dt);
				ViewState[KEYQDATATABLE2] = dt;
						
			}
			else
			{
			ltlMensaje.Text= Utilitario.Helper.MensajeAlert(MENSAJE);
			}
		}

		private void ActualizarListaUsuariosAsignados(DataTable dt)
		{
			
				ViewState[KEYQDATATABLE2] = dt;

				if(ViewState[KEYQDATATABLE2] != null)
				{
					this.lstListaUsuariosAsignados.DataSource = dt;
					this.lstListaUsuarios.DataValueField=COLUMNAIDUSUARIO;
					this.lstListaUsuarios.DataTextField=COLUMNANOMBRE;
				
				}
				else
				{
					this.lstListaUsuariosAsignados.DataSource = null;
				
				}
				try
				{
					this.lstListaUsuariosAsignados.DataBind();
					int id = Convert.ToInt32(Session[SESSIONID2]);

					DataTable dt2 = ((DataTable)ViewState[KEYQDATATABLE]).Copy();
					dt2.Rows.Find(id).Delete();
					dt2.AcceptChanges();
					ActualizarListaUsuarios(dt2);
							
				}
				catch(Exception oException)
				{
					string mensaje =oException.Message;
			
				}
			
		}

		private void ActualizarListaUsuariosAsignados()
		{
			if(flag ==1)
			{
			
				DataTable dt3 = ((DataTable)ViewState[KEYQDATATABLE2]).Copy();
				dt3.Rows.Find(Convert.ToInt32(Session[SESSIONID3])).Delete();
				dt3.AcceptChanges();
				flag= Utilitario.Constantes.ValorConstanteCero;
				ViewState[KEYQDATATABLE2] = dt3;
				this.lstListaUsuariosAsignados.DataSource = dt3;
				this.lstListaUsuarios.DataValueField=COLUMNAIDUSUARIO;
				this.lstListaUsuarios.DataTextField=COLUMNANOMBRE;
				this.lstListaUsuariosAsignados.DataBind();
			
			}
		}
		private void ActualizarListaUsuarios(DataTable dt2)
		{
			try
			{
				ViewState[KEYQDATATABLE] = dt2;
				DataTable dt = ((DataTable)ViewState[KEYQDATATABLE]).Copy();

				if(ViewState[KEYQDATATABLE] != null)
				{
					this.lstListaUsuarios.DataSource = dt;
					this.lstListaUsuarios.DataValueField=COLUMNAIDUSUARIO;
					this.lstListaUsuarios.DataTextField=COLUMNANOMBRE;
						
				}
				else
				{
					this.lstListaUsuarios.DataSource = null;
						
				}
				this.lstListaUsuarios.DataBind();
				
			}
		
			catch(Exception oException)
			{
				string mensaje =oException.Message;
			
			}
		
		}

		private void lstListaUsuarios_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session[SESSIONID2]=this.lstListaUsuarios.SelectedValue;
		}

		private void btnQuitar_Click(object sender, System.EventArgs e)
		{
				
			if(this.lstListaUsuariosAsignados.SelectedIndex != -1)
			{
				flag= Utilitario.Constantes.ValorConstanteUno;
				DataTable dt2 = ((DataTable)ViewState[KEYQDATATABLE]).Copy();

				int contador = Convert.ToInt32(ViewState[KEYQCONTADOR]);
				DataRow dr = dt2.NewRow();
				dr.ItemArray = new object [2] {
												 
												  this.lstListaUsuariosAsignados.SelectedValue,
												  this.lstListaUsuariosAsignados.SelectedItem.Text};

				dt2.Rows.Add(dr);
				ViewState[KEYQCONTADOR] = ++contador;
				this.ActualizarListaUsuarios(dt2);
				this.ActualizarListaUsuariosAsignados();
			
			}
			else
			{
				ltlMensaje.Text= Utilitario.Helper.MensajeAlert(MENSAJE);
			}

		}

		private void lstListaUsuariosAsignados_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Session["id3"]=this.lstListaUsuariosAsignados.SelectedValue;
		}

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
		
			try
			{
				if(Page.IsValid)
				{
					
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;

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

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.redireccionaPaginaPrincipal();
		}
		private void redireccionaPaginaPrincipal()
		{
			Page.Response.Redirect(URLPRINCIPAL);
		}
		
		
	}
}
