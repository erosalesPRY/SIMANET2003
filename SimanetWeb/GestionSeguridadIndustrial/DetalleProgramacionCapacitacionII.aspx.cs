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
using SIMA.EntidadesNegocio.Personal;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;

using NetAccessControl;


namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleProgramacionCapacitacionII.
	/// </summary>
	public class DetalleProgramacionCapacitacionII : System.Web.UI.Page,IPaginaBase
	{
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.WebControls.Label lblPagina;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtNroProg;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtMotivo;
		protected projDataGridWeb.DataGridWeb grid;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtNombreCM;
		protected System.Web.UI.HtmlControls.HtmlTableCell LstUser;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrabajador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCentroMedico;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.ImageButton imgAgregar;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected eWorld.UI.CalendarPopup CalFechaInicio;
		protected eWorld.UI.CalendarPopup calFechaTermino;
		protected eWorld.UI.TimePicker tmHoraInicio;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hidArea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArea;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Button btnEliminar;

		public string IdGrpProgCap
		{
			get{return ((Page.Request.Params["IdGrpprgCap"]==null)?"0":Page.Request.Params["IdGrpprgCap"].ToString());}
		}
		int IdArea;




		string ParamArgument;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlImage imgSeleccPersonal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPeriodoSeleccion;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdSeleccion;
		protected System.Web.UI.WebControls.TextBox txtProgSelec;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.TextBox txtCapacitador;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdCapacitador;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.CheckBox chkRequiereEva;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.DropDownList ddlTipo;
		const string NomDTTemp = "dtTmp";
		private void Page_Load(object sender, System.EventArgs e)
		{
			Page.GetPostBackEventReference(this, "MyEventArgumentName");

			ParamArgument=Page.Request.Params["__EVENTARGUMENT"];
			if((ParamArgument!=null)&&(ParamArgument.Length>0))
			{
				IdArea = Convert.ToInt32(ParamArgument); 
			}

			if(!Page.IsPostBack)
			{
				try
				{
					/*this.ConfigurarAccesoControles();					
					this.LlenarCombos();*/
					this.LlenarJScript();
					this.LlenarCombos();
					this.CargarModoPagina();
					this.LlenarGrilla();
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Seguridad Industrial: Registro de Personal (Contratista-Visita)", this.ToString(),"Se ingreso a la funcionalidad de  registro de Personal (Contratista-Visita)",Enumerados.NivelesErrorLog.I.ToString()));
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
			this.imgAgregar.Click += new System.Web.UI.ImageClickEventHandler(this.imgAgregar_Click);
			this.grid.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.grid_ItemDataBound);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			GrpCapacitacionProgBE oGrpCapacitacionProgBE = new GrpCapacitacionProgBE();
			oGrpCapacitacionProgBE.IdSeleccion = Convert.ToInt32(this.hIdSeleccion.Value);
			oGrpCapacitacionProgBE.PeriodoSeleccion = Convert.ToInt32(this.hPeriodoSeleccion.Value);
			oGrpCapacitacionProgBE.Mensaje = this.txtMotivo.Text;
			oGrpCapacitacionProgBE.IdSeleccion = Convert.ToInt32(this.hIdSeleccion.Value); 
			oGrpCapacitacionProgBE.PeriodoSeleccion = Convert.ToInt32(this.hPeriodoSeleccion.Value); 
			oGrpCapacitacionProgBE.IdTipoCapacitacion = Convert.ToInt32(this.ddlTipo.SelectedValue); 

			/*Obtiene la lista de areas*/
			DataTable dt = ((DataTable)ViewState[NomDTTemp]);

			CapacitacionProgRespBE []oCapacitacionProgRespBEALL=null;
			if((dt!=null)&&(dt.Rows.Count>0))
			{
				oCapacitacionProgRespBEALL = new CapacitacionProgRespBE[dt.Rows.Count];

				int i=0;
				foreach(DataRow dr in dt.Rows)
				{
					oCapacitacionProgRespBEALL[i]= new CapacitacionProgRespBE();
					oCapacitacionProgRespBEALL[i].IdProgCap = Convert.ToInt32(dr["IdProgCap"].ToString());
					oCapacitacionProgRespBEALL[i].PeriodoProgCap = Convert.ToInt32(dr["PeriodoProgCap"].ToString());
					//oCapacitacionProgRespBEALL[i].IdGrpProgCap = dr["IdGrpProgCap"].ToString();
					oCapacitacionProgRespBEALL[i].IdArea = Convert.ToInt32(dr["IdAreaResponsable"].ToString());
					oCapacitacionProgRespBEALL[i].IdCapacitador= Convert.ToInt32(dr["IdCapacitador"].ToString());
					oCapacitacionProgRespBEALL[i].Asunto = "";
					oCapacitacionProgRespBEALL[i].RequiereEvaluacion = Convert.ToInt32(dr["RequiereEvaluacion"].ToString());
					oCapacitacionProgRespBEALL[i].FechaInicio =Convert.ToDateTime(dr["FechaInicio"].ToString());
					oCapacitacionProgRespBEALL[i].FechaFin =Convert.ToDateTime(dr["FechaFin"].ToString());
					oCapacitacionProgRespBEALL[i].HoraInicio =dr["HoraInicio"].ToString();
					oCapacitacionProgRespBEALL[i].Modo = dr["Modo"].ToString();
					i++;
				}
			}
			int retorno = (new CCCTT_Grp_Capacitacion_Prog()).Insertar(oGrpCapacitacionProgBE,oCapacitacionProgRespBEALL);
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Programación Capacitación",this.ToString(),"Se registró Item de programación de Capacitación" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
			Helper.MensajeRetornoAlert(this);

		}
		

		public void Modificar()
		{
			GrpCapacitacionProgBE oGrpCapacitacionProgBE = new GrpCapacitacionProgBE();
			oGrpCapacitacionProgBE.IdGrpProgCap = this.IdGrpProgCap;
			oGrpCapacitacionProgBE.IdSeleccion = Convert.ToInt32(this.hIdSeleccion.Value);
			oGrpCapacitacionProgBE.PeriodoSeleccion = Convert.ToInt32(this.hPeriodoSeleccion.Value);
			oGrpCapacitacionProgBE.Mensaje = this.txtMotivo.Text;
			oGrpCapacitacionProgBE.IdTipoCapacitacion = Convert.ToInt32(this.ddlTipo.SelectedValue); 
			/*Obtiene la lista de areas*/
			DataTable dt = ((DataTable)ViewState[NomDTTemp]);

			CapacitacionProgRespBE []oCapacitacionProgRespBEALL=null;
			if((dt!=null)&&(dt.Rows.Count>0))
			{
				oCapacitacionProgRespBEALL = new CapacitacionProgRespBE[dt.Rows.Count];

				int i=0;
				foreach(DataRow dr in dt.Rows)
				{
					oCapacitacionProgRespBEALL[i]= new CapacitacionProgRespBE();
					oCapacitacionProgRespBEALL[i].IdProgCap = Convert.ToInt32(dr["IdProgCap"].ToString());
					oCapacitacionProgRespBEALL[i].PeriodoProgCap = Convert.ToInt32(dr["PeriodoProgCap"].ToString());
					oCapacitacionProgRespBEALL[i].IdGrpProgCap = dr["IdGrpProgCap"].ToString();
					oCapacitacionProgRespBEALL[i].IdArea = Convert.ToInt32(dr["IdAreaResponsable"].ToString());
					oCapacitacionProgRespBEALL[i].IdCapacitador= Convert.ToInt32(dr["IdCapacitador"].ToString());
					oCapacitacionProgRespBEALL[i].Asunto = "";
					oCapacitacionProgRespBEALL[i].RequiereEvaluacion = Convert.ToInt32(dr["RequiereEvaluacion"].ToString());
					oCapacitacionProgRespBEALL[i].FechaInicio =Convert.ToDateTime(dr["FechaInicio"].ToString());
					oCapacitacionProgRespBEALL[i].FechaFin =Convert.ToDateTime(dr["FechaFin"].ToString());
					oCapacitacionProgRespBEALL[i].HoraInicio =dr["HoraInicio"].ToString();
					oCapacitacionProgRespBEALL[i].Modo = dr["Modo"].ToString();
					i++;
				}
			}
			int retorno = (new CCCTT_Grp_Capacitacion_Prog()).Modificar(oGrpCapacitacionProgBE,oCapacitacionProgRespBEALL);
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Programación Capacitación",this.ToString(),"Se registró Item de programación de Capacitación" + Utilitario.Constantes.SIMBOLOPUNTO,Enumerados.NivelesErrorLog.I.ToString()));
				Helper.MensajeRetornoAlert(this);
		}


		public void Eliminar()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.Eliminar implementation
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
			// TODO:  Add DetalleProgramacionCapacitacionII.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			GrpCapacitacionProgBE oGrpCapacitacionProgBE=(GrpCapacitacionProgBE)(new CCCTT_Grp_Capacitacion_Prog()).ListarDetalle(this.IdGrpProgCap);
			txtNroProg.Text = oGrpCapacitacionProgBE.IdGrpProgCap;
			this.hIdSeleccion.Value = oGrpCapacitacionProgBE.IdSeleccion.ToString();
			this.hPeriodoSeleccion.Value = oGrpCapacitacionProgBE.PeriodoSeleccion.ToString();
			txtProgSelec.Text = oGrpCapacitacionProgBE.NombreProgramaSeleccion;
			txtMotivo.Text = oGrpCapacitacionProgBE.Mensaje;
			ListItem item =  this.ddlTipo.Items.FindByValue(oGrpCapacitacionProgBE.IdTipoCapacitacion.ToString());
			if(item !=null){item.Selected=true;}

			/*Crear data table Temporal*/
		
			
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(Convert.ToInt32(this.hIdSeleccion.Value)==0){
				Utilitario.Helper.MsgBox("VALIDACION","No se ha seleccionado programación de personal",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}
			if(Convert.ToInt32(this.hIdCapacitador.Value)==0){
				Utilitario.Helper.MsgBox("VALIDACION","No se ha seleccionado persona responsable de la capacitacion",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				return false;
			}

			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnAceptar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			try
			{
				if(Page.IsValid)
				{
					
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
				Helper.MsgBox("ERROR",oSIMAExcepcionDominio.Error,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
			}
			catch(Exception oException)
			{
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		}
		#region IPaginaBase Members


		public DataTable ObtenerDatos()
		{
			DataTable dt=null;
			if(((DataTable)ViewState[NomDTTemp])==null)
			{
				dt = (new CCTT_CapacitacionProgResp()).ListarTodosGrilla(this.IdGrpProgCap);
				if((dt==null)||(dt.Rows.Count==0))
				{
					dt = new DataTable();
					dt.Columns.Add(new DataColumn("IdProgCap",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("PeriodoProgCap",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("IdGrpProgCap",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("IdAreaResponsable",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("NombreAreaResponsable",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("IdCapacitador",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("ApellidosyNombresCapacitador",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("Asunto",System.Type.GetType("System.String")));
					
					dt.Columns.Add(new DataColumn("RequiereEvaluacion",System.Type.GetType("System.Int32")));
					dt.Columns.Add(new DataColumn("FechaInicio",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("FechaFin",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("HoraInicio",System.Type.GetType("System.String")));
					dt.Columns.Add(new DataColumn("Modo",System.Type.GetType("System.String")));
				}
				ViewState[NomDTTemp]= dt;
			}
			else
			{
				
				dt =(DataTable)ViewState[NomDTTemp];
			}
			return dt;
		}

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
			// TODO:  Add DetalleProgramacionCapacitacionII.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			DataTable odt = (new CTablaTablas()).ListaItemTablas(647);
			ddlTipo.DataSource = odt;
			ddlTipo.DataValueField="codigo";
			ddlTipo.DataTextField="descripcion";
			ddlTipo.DataBind();
			ddlTipo.Items.Insert(0,(new ListItem("--Seleccionar--","0")));
			
		}

		public void LlenarDatos()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			btnEliminar.Style.Add("display","none");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleProgramacionCapacitacionII.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void imgAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			if(this.ValidarCampos())
			{
				if(this.txtArea.Text.ToString().Length>0)
				{
					DataTable dt = (DataTable) ViewState[NomDTTemp];
					if(dt.Rows.Count>0)
					{
						string Filtro = "IdAreaResponsable=" + this.hidArea.Value + " AND  Modo <> 'E'";
						DataRow []ddr = dt.Select(Filtro);
						if(ddr.Length>0)
						{
							Helper.MsgBox("Validación"	,"Area ya existe no es posible volver a agregarlo",Utilitario.Enumerados.Ext.MessageBox.Button.OK,Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
							return;
						}
					}
					DataRow dr = dt.NewRow();
					dr["IdProgCap"]=0;
					dr["PeriodoProgCap"]=0;
					dr["IdGrpProgCap"]=this.IdGrpProgCap;
					dr["IdAreaResponsable"]=hidArea.Value;
					dr["NombreAreaResponsable"]= this.txtArea.Text;
					dr["IdCapacitador"]=this.hIdCapacitador.Value;
					dr["ApellidosyNombresCapacitador"]=this.txtCapacitador.Text;
					dr["Asunto"]="";
					dr["RequiereEvaluacion"] = ((this.chkRequiereEva.Checked==true)?1:0);
					dr["FechaInicio"]=CalFechaInicio.SelectedDate.ToShortDateString();
					dr["FechaFin"]=calFechaTermino.SelectedDate.ToShortDateString();
					dr["HoraInicio"]=tmHoraInicio.SelectedTime.ToShortTimeString();
					dr["Modo"]="N";
					dt.Rows.Add(dr);
					dt.AcceptChanges();
					ViewState[NomDTTemp] = dt;
					/*Limpia los controles*/
					this.txtArea.Text="";
					this.hidArea.Value="";
					this.txtCapacitador.Text="";
					this.hIdCapacitador.Value="";

				}
				else
				{
					Helper.MsgBox("Validacion","No se ha ingresado area responsable de la capacitación",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OKCANCEL,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				}
			}
			this.LlenarGrilla();
		}

		private void grid_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				Helper.ConfiguraColumnaHyperLink(e.Item.Cells[0],grid.CurrentPageIndex,grid.PageSize,e.Item.ItemIndex);
			
				Helper.SeleccionarItemGrillaOnClickMoverRaton(e);		


				CheckBox chkRE = (CheckBox)e.Item.Cells[3].FindControl("chkReqEva"); 
				chkRE.Checked = ((Convert.ToInt32(dr["RequiereEvaluacion"].ToString())==1)?true:false);

				HtmlImage oImg = (HtmlImage) e.Item.Cells[6].FindControl("imgEliminar");
				oImg.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"CCTT_CapacitacionProgRespUI.Eliminar('" + dr["IdAreaResponsable"].ToString() + "')");
				if(dr["Modo"].ToString().Equals("E"))
				{
					e.Item.Style.Add("text-decoration","line-through");
					e.Item.Style.Add("color","red");
				}
			}
		}

		
		private void btnEliminar_Click(object sender, System.EventArgs e)
		{
			DataTable dt =(DataTable) ViewState[NomDTTemp];
			foreach(DataRow dr in dt.Rows){
				if(IdArea==Convert.ToInt32(dr["IdAreaResponsable"].ToString())){
					dr["Modo"]="E";
				}
				dt.AcceptChanges();
				ViewState[NomDTTemp]=dt;
			}
			this.LlenarGrilla();
		}
	}
}
