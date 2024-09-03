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
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using NetAccessControl;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleListaCapacitacion.
	/// </summary>
	public class DetalleListaCapacitacion : System.Web.UI.Page,IPaginaMantenimento,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label7;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNombreCM;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.WebControls.TextBox txtNroProg;
		protected System.Web.UI.WebControls.TextBox txtMotivo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroMedico;

		
		const string KEYQPERIODO = "Periodo";
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtPR;
		protected System.Web.UI.WebControls.TextBox txtApellidos;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.Button btnPost;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		const string KEYQSELECCION = "IdSelec";
		public int Periodo
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQPERIODO]);}
		}
		public int IdSeleccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQSELECCION]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			
			Page.GetPostBackEventReference(this, "MyEventArgumentName");
			if(!Page.IsPostBack)
			{
				try
				{
					//Inicializa DataTable
					Session["dtLstPer"]=null;
					Session["idSel"]=0;
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
					//this.LlenarCombos();
					this.CargarModoPagina();	
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Seguridad Industrial: Registro de personal para capacitacion", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
				}
				catch(Exception oException)
				{
					SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
					Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
					Helper.MsgBox(oSIMAExcepcionIU.Mensaje);	
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
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.grid.SelectedIndexChanged += new System.EventHandler(this.grid_SelectedIndexChanged);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PersonaCapacitacionProgBE oPersonaCapacitacionProgBE=new PersonaCapacitacionProgBE();
			oPersonaCapacitacionProgBE.IdSeleccion= 0;
			oPersonaCapacitacionProgBE.Periodo=0;
			oPersonaCapacitacionProgBE.Descripcion = this.txtMotivo.Text;
			oPersonaCapacitacionProgBE.Fecha= this.CalFechaInicio.SelectedDate;

			PersonaCapacitacionBE []oPersonaCapacitacionBE;
			DataTable dtLst = (DataTable)Session["dtLstPer"];
			if((dtLst!=null)&&(dtLst.Rows.Count>0))
			{

				//PersonaCapacitacionBE []oPersonaCapacitacionBE = new PersonaCapacitacionBE[dtLst.Rows.Count];
				oPersonaCapacitacionBE = new PersonaCapacitacionBE[dtLst.Rows.Count];
				int i=0;
				foreach(DataRow dr in dtLst.Rows)
				{
					oPersonaCapacitacionBE[i] = new PersonaCapacitacionBE();
					oPersonaCapacitacionBE[i].Periodo=0;
					oPersonaCapacitacionBE[i].IdSeleccion=0;
					oPersonaCapacitacionBE[i].IdPersonal=Convert.ToInt32(dr["IdPersonal"].ToString());
					oPersonaCapacitacionBE[i].IdEstado=Convert.ToInt32(dr["IdEstado"].ToString());
					i++;
				}
				int retorno= (new CCCTT_PersonaCapacitacionProg()).Insertar(oPersonaCapacitacionProgBE,oPersonaCapacitacionBE);
			}
			else
			{
				int retorno= (new CCCTT_PersonaCapacitacionProg()).Modificar(oPersonaCapacitacionProgBE,null);
			}
			Session["dtLstPer"]=null;
			Helper.MensajeRetornoAlert(this);
		}

		public void Modificar()
		{
			PersonaCapacitacionProgBE oPersonaCapacitacionProgBE=new PersonaCapacitacionProgBE();
			oPersonaCapacitacionProgBE.IdSeleccion= this.IdSeleccion;
			oPersonaCapacitacionProgBE.Periodo=this.Periodo;
			oPersonaCapacitacionProgBE.Descripcion = this.txtMotivo.Text;
			oPersonaCapacitacionProgBE.Fecha= this.CalFechaInicio.SelectedDate;

			PersonaCapacitacionBE []oPersonaCapacitacionBE;
			DataTable dtLst = (DataTable)Session["dtLstPer"];
			if((dtLst!=null)&&(dtLst.Rows.Count>0))
			{
				oPersonaCapacitacionBE = new PersonaCapacitacionBE[dtLst.Rows.Count];
				int i=0;
				foreach(DataRow dr in dtLst.Rows)
				{
					oPersonaCapacitacionBE[i] = new PersonaCapacitacionBE();
					oPersonaCapacitacionBE[i].Periodo=this.Periodo;
					oPersonaCapacitacionBE[i].IdSeleccion=this.IdSeleccion;
					oPersonaCapacitacionBE[i].IdPersonal=Convert.ToInt32(dr["IdPersonal"].ToString());
					oPersonaCapacitacionBE[i].IdEstado=Convert.ToInt32(dr["IdEstado"].ToString());
					i++;
				}
				int retorno= (new CCCTT_PersonaCapacitacionProg()).Modificar(oPersonaCapacitacionProgBE,oPersonaCapacitacionBE);
			}
			else{
				int retorno= (new CCCTT_PersonaCapacitacionProg()).Modificar(oPersonaCapacitacionProgBE,null);
			}
			Session["dtLstPer"]=null;
			Helper.MensajeRetornoAlert(this);
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleListaCapacitacion.Eliminar implementation
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
				
			}				
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DetalleListaCapacitacion.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			
			PersonaCapacitacionProgBE oPersonaCapacitacionProgBE=(PersonaCapacitacionProgBE) (new CCCTT_PersonaCapacitacionProg()).ListarDetalle(this.Periodo,this.IdSeleccion);
			txtNroProg.Text = this.Periodo.ToString() +"-"+this.IdSeleccion.ToString();
			CalFechaInicio.Text = oPersonaCapacitacionProgBE.Fecha.ToShortDateString();
			txtMotivo.Text = oPersonaCapacitacionProgBE.Descripcion;
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleListaCapacitacion.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleListaCapacitacion.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleListaCapacitacion.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleListaCapacitacion.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					if(this.ValidarCampos())
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
			}
			catch(SIMAExcepcionLog oSIMAExcepcionLog)
			{
				Helper.MsgBox(oSIMAExcepcionLog.Mensaje);					
			}
			catch(SIMAExcepcionIU oSIMAExcepcionIU)
			{
				Helper.MsgBox(oSIMAExcepcionIU.Mensaje);					
			}
			catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
			{
				Helper.MsgBox(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				//SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.MsgBox("Validacion", oException.Message,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}		
		}



		public DataTable ObtenerDatos()
		{
			if((int)Session["idSel"]!=this.IdSeleccion){
				Session["idSel"]=this.IdSeleccion;
				Session["dtLstPer"]=null;
			}

			DataTable dt=null;
			if(((DataTable)Session["dtLstPer"])==null)
			{
				dt = (new CCCTT_PersonalCapacitacion()).ListarTodosGrilla(this.Periodo,this.IdSeleccion);
			}
			else{
				dt =(DataTable)Session["dtLstPer"];
			}
			return CreaEstructura(dt);
		}

		DataTable CreaEstructura(DataTable	dt){
			if((dt==null)&&((DataTable)Session["dtLstPer"])==null)
			{
				dt = new DataTable();
				dt.Columns.Add("IdPersonal",System.Type.GetType("System.Int32"));
				dt.Columns.Add("IdSeleccion",System.Type.GetType("System.Int32"));
				dt.Columns.Add("Periodo",System.Type.GetType("System.Int32"));
				dt.Columns.Add("NroPersonal",System.Type.GetType("System.String"));
				dt.Columns.Add("NroDNI",System.Type.GetType("System.String"));
				dt.Columns.Add("ApellidosyNombres",System.Type.GetType("System.String"));
				dt.Columns.Add("NombreArea",System.Type.GetType("System.String"));
				dt.Columns.Add("IdEstado",System.Type.GetType("System.Int32"));
				dt.Columns.Add("IdAsistencia",System.Type.GetType("System.Int32"));
				dt.Columns.Add("Modo",System.Type.GetType("System.String"));
			}
			Session["dtLstPer"]=dt;
			return dt; 
		}

		
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			DataTable dt = this.ObtenerDatos();
			if (dt!=null)
			{
				grid.DataSource = dt;
				
			}
			else
			{
				grid.DataSource = dt;
			}
			
			try
			{
				
				grid.DataBind();
			}
			catch (Exception exception)
			{
				string mensaje = exception.Message.ToString();
				grid.CurrentPageIndex = 0;
				grid.DataBind();
			}				
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleListaCapacitacion.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleListaCapacitacion.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleListaCapacitacion.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleListaCapacitacion.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.btnPost.Style.Add("display","none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleListaCapacitacion.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleListaCapacitacion.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleListaCapacitacion.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleListaCapacitacion.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleListaCapacitacion.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void btnPost_Click(object sender, System.EventArgs e)
		{
			this.LlenarJScript();
			this.LlenarGrilla();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
			 	  
				//Asistencia a la capacitacion
				HtmlImage imgA =(HtmlImage)e.Item.Cells[5].FindControl("imgEliminar");
				imgA.Src= ((dr["IdAsistencia"].ToString()=="1")?"../imagenes/Filtro/Aprobar.gif":"");

				HtmlImage img =(HtmlImage)e.Item.Cells[6].FindControl("imgEliminar");
				img.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ListarProgSeleccionPersonal.EliminarPersona(this.parentNode.parentNode,'" + dr["IdPersonal"].ToString() + "');");
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex,Helper.MostrarDatosEnCajaTexto("hIdPersonal",dr["IdPersonal"].ToString()));
				e.Item.Attributes.Add("IDESTADO",dr["IdEstado"].ToString());

				if(dr["IdEstado"].ToString()!="1")
				{
					img.Src = "../imagenes/ToolBar/InsertarTR1.gif";
					for(int i=1;i<=4;i++)
					{
						e.Item.Cells[i].Style.Add("text-decoration","line-through");
						e.Item.Cells[i].Style.Add("color","red");
					}
				}
				else
				{
					img.Src = "../imagenes/Filtro/Eliminar.gif";
					for(int i=1;i<=4;i++)
					{
						e.Item.Cells[i].Style.Add("text-decoration","");
						e.Item.Cells[i].Style.Add("color","Navy");
					}
				}
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);
			}
		}

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
