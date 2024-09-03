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
using SIMA.Controladoras.GestionFinanciera;
using SIMA.EntidadesNegocio.GestionFinanciera;

using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
namespace SIMA.SimaNetWeb.GestionFinanciera.EstadosFinancieros
{
	/// <summary>
	/// Summary description for AdministrarFormulaFinanciera.
	/// </summary>
	public class AdministrarFormulaFinanciera : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
		//Key Session y QueryString
		const string KEYQIDFORMATO = "IdFormato";
		const string KEYQIDREPORTE = "IdReporte";
		const string KEYQIDRUBRO= "IdRubro";
		const string KEYQCUENTACONTABLE = "CtaCtble";
		const string KEYQPERIODO = "Periodo";
		const string KEYQIDCOLUMNA="IdCol";

		const string CONTROLIMAGE = "imgVerDetalle";
		const string GRILLAVACIA="No exiets";
		const string OBJPARAMETROCONTABLE="ParametroContable";
		const string CONTROLINK="hlkCuenta";
		const string CONTROCHK ="chkEstado";
		const string URLPRINCIPAL="DetalleReporteFormula.aspx";
		const string URLBUSQUEDACUENTACONTABLE="ConsultarPlanContable.aspx?";
		const string CONTROLDDL1="ddblOperador";
		const string CONTROLDDL2="ddblCondicion";
		const string CONTROLTXT="txtCuenta";
		const string CONTROLCHK="chkActivo";
		int idFila=0;
		DataTable dtOperador;
		DataTable dtCondicion;

		//Otros
		const string NOMBREDATATABLE ="Formula";
		const string ETIQUETAFORMULA ="FORMULA DE ";
		const string ETIQUETACONCEPTO ="CONCEPTO : ";

		//Columnas Grilla
		const string IDOPERADORMAT ="idOperadorMat";
		const string IDOPERADORLOG ="idOperadorLog";
		const string CUENTACONTABLE ="CuentaContable";
		const string IDESTADO ="idEstado";
		const string ESTADO = "Estado";
		#endregion

		#region Controles

		protected System.Web.UI.WebControls.Label lblReporte;
		protected System.Web.UI.WebControls.Label lblRubro;
		protected System.Web.UI.WebControls.Label lblResultado;
		protected projDataGridWeb.DataGridWeb gridAdm;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hRegistro;
		protected System.Web.UI.WebControls.Label lblRutaPagina;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGridPagina;
		protected System.Web.UI.WebControls.Image ibtnGrabarFila;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion Controles

		private int IdFormato{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);}
		}
		private int IdReporte
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);}
		}
		private int IdRubro
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);}
		}

		private int IdColumna
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDCOLUMNA]);}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				if(!Page.IsPostBack)
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					Helper.ReiniciarSession();
					this.CargarModoConsulta();
					//this.LlenarGrilla();
					this.LlenarGrillaOrdenamientoPaginacion("",0);
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
			this.gridAdm.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.gridAdm_PageIndexChanged);
			this.gridAdm.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.gridAdm_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members
		private DataTable ObtenerDatos()
		{
			DataTable dt = new DataTable(NOMBREDATATABLE);
			CEstadosFinancieros oCEstadosFinancieros = new  CEstadosFinancieros();
			if(this.IdColumna==0)
			{
				dt = oCEstadosFinancieros.AdministraFormatoReporteFormula(this.IdFormato
																			,this.IdReporte
																			,this.IdRubro
																			,Convert.ToString(Utilitario.Constantes.IDDEFAULT));
			}
			else{
				dt = oCEstadosFinancieros.AdministraFormatoReporteColumnaFormula(this.IdFormato
																				,this.IdReporte
																				,this.IdRubro
																				,this.IdColumna
																				,Convert.ToString(Utilitario.Constantes.IDDEFAULT));

			}
			
			
			/*dt = oCEstadosFinancieros.AdministraFormatoReporteColumnaFormula(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO].ToString()),
				Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE].ToString()),
				Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO].ToString()),0,
				Convert.ToString(Utilitario.Constantes.IDDEFAULT));
			*/
			
			
			object [] DataRows={0,1,1,1,"",0,0,"",0,0,"",1,"P"};
			if (dt ==null)
			{
				DataTable tdn = new DataTable(NOMBREDATATABLE);
				string [] Columnas = {"idFormula","idFormato","idReporte","idRubro","CuentaContable","idTablaOperadorMat","idOperadorMat","OperadorMat","idTablaOperadorLog","idOperadorLog","OperadorLog","idEstado","Estado"};
				//object [] ColumnasType = {System.Int32,System.Int32,System.Int32,System.Int32,System.String,System.Int32,System.Int32,System.String,System.Int32,System.Int32,System.String,System.Int32,System.String};
				tdn.Columns.Add(Columnas[0].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[1].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[2].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[3].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[4].ToString(),typeof(System.String));
				tdn.Columns.Add(Columnas[5].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[6].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[7].ToString(),typeof(System.String));
				tdn.Columns.Add(Columnas[8].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[9].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[10].ToString(),typeof(System.String));
				tdn.Columns.Add(Columnas[11].ToString(),typeof(System.Int32));
				tdn.Columns.Add(Columnas[12].ToString(),typeof(System.String));

				tdn.Rows.Add(DataRows);
				return tdn;
			}
			dt.Rows.Add(DataRows);
			return dt;
		}

		public void LlenarGrilla()
		{
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add AdministrarFormulaFinanciera.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add ConsultaDeEstadosFinancieros.LlenarGrilla implementation
			DataTable dtFormula = this.ObtenerDatos();
			DataView dv = dtFormula.DefaultView;
			if(dv!=null)
			{
				this.hGridPagina.Value=indicePagina.ToString();
				gridAdm.DataSource = dv;
				gridAdm.CurrentPageIndex =indicePagina;
			}
			else
			{
				gridAdm.DataSource = dv;
				lblResultado.Text = GRILLAVACIA;
			}
			gridAdm.DataBind();
			// TODO:  Add AdministrarFormulaFinanciera.LlenarGrilla implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add AdministrarFormulaFinanciera.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add AdministrarFormulaFinanciera.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			//this.ibtnAgregar.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"ObtenerRegistroModificado()");
			// TODO:  Add AdministrarFormulaFinanciera.LlenarJScript implementation
			this.ibtnGrabarFila.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"GrabarFila()");

		}

		public void RegistrarJScript()
		{
			// TODO:  Add AdministrarFormulaFinanciera.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add AdministrarFormulaFinanciera.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add AdministrarFormulaFinanciera.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			//string ss = Page.Request.Url.AbsolutePath.ToString();
			if(CNetAccessControl.FindPage(Page.Request.Url.AbsolutePath.ToString()))
			{CNetAccessControl.LoadControls(this);}
			else
			{CNetAccessControl.RedirectPageError();}			
			// TODO:  Add AdministrarFormulaFinanciera.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add AdministrarFormulaFinanciera.ValidarFiltros implementation
			return false;
		}

		#endregion

		private void grid_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		#region IPaginaMantenimento Members
		public void Agregar()
		{
		}
		public int Agregar(string ObjRegistro)
		{
			string []Datos = ObjRegistro.Split(';');
			
			FormatoReporteFormulaBE oFormatoReporteFormulaBE = new FormatoReporteFormulaBE();
			oFormatoReporteFormulaBE.Idformato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			oFormatoReporteFormulaBE.Idreporte  = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
			oFormatoReporteFormulaBE.Idrubro= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
			oFormatoReporteFormulaBE.Cuentacontable = Datos[3].ToString().Trim();
			oFormatoReporteFormulaBE.Orden = Utilitario.Constantes.ValorConstanteCero;
			oFormatoReporteFormulaBE.Idtablaoperadormat = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraOperadoresMatematicos);
			oFormatoReporteFormulaBE.Idoperadormat = Convert.ToInt32(Datos[2].ToString());
			oFormatoReporteFormulaBE.Idtablaoperadorlog = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraOperadoresLogicos);
			oFormatoReporteFormulaBE.Idoperadorlog = Convert.ToInt32(Datos[4].ToString());
			oFormatoReporteFormulaBE.Idusuarioregistro = CNetAccessControl.GetIdUser();
			oFormatoReporteFormulaBE.Idtablaestado = Convert.ToInt32(Utilitario.Enumerados.TablasTabla.FinancieraEstadoFormatoReporteFormula);
			oFormatoReporteFormulaBE.Idestado = Convert.ToInt32(Datos[5].ToString());
			
			CFormatoReporteFormula oCFormatoReporteFormula = new CFormatoReporteFormula();
			int retorno = oCFormatoReporteFormula.Insertar(oFormatoReporteFormulaBE);
			if(retorno >0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName()
					,"GestionFinanciera"
					,this.ToString()
					,"Se modificó Item de " + oCFormatoReporteFormula.ToString()
					,Enumerados.NivelesErrorLog.I.ToString()));
			}			
			return retorno;
		}
		public void Modificar()
		{
		}
		public int Modificar(string ObjRegistro)
		{
			string []Datos = ObjRegistro.Split(';');
			FormatoReporteFormulaBE oFormatoReporteFormulaBE = new FormatoReporteFormulaBE();
			oFormatoReporteFormulaBE.IdFormula = Convert.ToInt32(Datos[0]);
			oFormatoReporteFormulaBE.Idformato = Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]);
			oFormatoReporteFormulaBE.Idreporte  = Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]);
			oFormatoReporteFormulaBE.Idrubro= Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]);
			oFormatoReporteFormulaBE.Cuentacontable = Datos[3].ToString();
			oFormatoReporteFormulaBE.Idoperadormat = Convert.ToInt32(Datos[2].ToString());
			oFormatoReporteFormulaBE.Idoperadorlog = Convert.ToInt32(Datos[4].ToString());
			oFormatoReporteFormulaBE.Idusuarioactualizacion = CNetAccessControl.GetIdUser();
			oFormatoReporteFormulaBE.Idestado = Convert.ToInt32(Datos[5].ToString());
			
			CFormatoReporteFormula oCFormatoReporteFormula = new CFormatoReporteFormula();
			int retorno = oCFormatoReporteFormula.Modificar(oFormatoReporteFormulaBE);
			if(retorno >0)
			{
				//Graba en el Log la acción ejecutada
				LogAplicativo.GrabarLogAplicativoArchivo
					(new LogAplicativo(CNetAccessControl.GetUserName(),"GestionFinanciera",this.ToString(),"Se modificó Item de " + 
					oCFormatoReporteFormula.ToString(),Enumerados.NivelesErrorLog.I.ToString()));
			}	
			return retorno;
			// TODO:  Add AdministrarFormulaFinanciera.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add AdministrarFormulaFinanciera.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			// TODO:  Add AdministrarFormulaFinanciera.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add AdministrarFormulaFinanciera.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			// TODO:  Add AdministrarFormulaFinanciera.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			CEstadosFinancieros oCEstadosFinancieros = new CEstadosFinancieros();
			ReporteRubroBE oReporteRubroBE = (ReporteRubroBE) 
											oCEstadosFinancieros.DetalleReporteRubro(Convert.ToInt32(Page.Request.Params[KEYQIDFORMATO]),
																					 Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]),
																					 Convert.ToInt32(Page.Request.Params[KEYQIDRUBRO]));

			this.lblReporte.Text = ETIQUETAFORMULA + oReporteRubroBE.NombreReporte.ToString().ToUpper();
			this.lblRubro.Text = ETIQUETACONCEPTO + oReporteRubroBE.NombreRubro.ToString().ToUpper();
			// TODO:  Add AdministrarFormulaFinanciera.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add AdministrarFormulaFinanciera.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add AdministrarFormulaFinanciera.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add AdministrarFormulaFinanciera.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void gridAdm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private DataTable CargarOperadoresMatematicos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			return oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraOperadoresMatematicos));
		}
		private DataTable CargarOperadoresLogicos()
		{
			CTablaTablas oCTablaTablas = new CTablaTablas();
			return oCTablaTablas.ListaTodosCombo(Convert.ToInt32(Enumerados.TablasTabla.FinancieraOperadoresLogicos));
		}

		private void gridAdm_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			e.Item.Cells[4].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			e.Item.Cells[5].Style.Add(Utilitario.Constantes.DISPLAY,Utilitario.Constantes.NONE);
			DropDownList ddl;
			ListItem item;
			if(e.Item.ItemType == ListItemType.Header)
			{
				dtOperador = CargarOperadoresMatematicos();
				dtCondicion = CargarOperadoresLogicos();
			}
			if(e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
			{
				DataRowView drv = (DataRowView)e.Item.DataItem;
				DataRow dr = drv.Row;
				/*Establece los valores del registo en atrinutos de la fila*/
				e.Item.Attributes.Add("Estado",dr[ESTADO].ToString());//Modo de edicion del registro

				e.Item.Attributes.Add("CmpValID",dr["idFormula"].ToString());
				e.Item.Attributes.Add("CmpValMAT",dr[IDOPERADORMAT].ToString());
				e.Item.Attributes.Add("CmpValCTA",dr[CUENTACONTABLE].ToString());
				e.Item.Attributes.Add("CmpValLOG",dr[IDOPERADORLOG].ToString());
				e.Item.Attributes.Add("CmpValEST",dr[IDESTADO].ToString());
				
				//if(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])==22)
				//{
					
					
					
				//}
				
				//Operador Matematico
				ddl = (DropDownList)e.Item.Cells[0].FindControl(CONTROLDDL1);
				ddl.DataSource = dtOperador;
				ddl.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
				ddl.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
				ddl.DataBind();
				//ddl.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"CambiarEstado('"+ idFila.ToString()  + "')");
				ddl.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"AsignarValorAlaFila(1);");
				
				item = ddl.Items.FindByValue(dr[IDOPERADORMAT].ToString());
				if (item!=null){item.Selected=true;}

				//Cuenta Contable
				TextBox txt = (TextBox)e.Item.Cells[1].FindControl(CONTROLTXT);
				txt.Text = dr[CUENTACONTABLE].ToString();
				
				string Parametros=KEYQPERIODO + Utilitario.Constantes.SIGNOIGUAL + Page.Request.QueryString[KEYQPERIODO].ToString() + 
					Utilitario.Constantes.SIGNOAMPERSON +"Control" + Utilitario.Constantes.SIGNOIGUAL + txt.ClientID.ToString();
				System.Web.UI.WebControls.Image imgBuscarPlanContable = (System.Web.UI.WebControls.Image)e.Item.Cells[1].FindControl("imgBtnDetalle");
				imgBuscarPlanContable.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,Utilitario.Helper.PopupBusqueda(URLBUSQUEDACUENTACONTABLE+Parametros,400,400));
				imgBuscarPlanContable.Visible=true;

				//txt.Attributes.Add(Utilitario.Constantes.EVENTOONKEYDOWN,"CambiarEstado('"+ idFila.ToString()  + "')");
				//if(Convert.ToInt32(Page.Request.QueryString[KEYQIDFORMATO])==22)
				//{
					txt.Attributes.Add(Utilitario.Constantes.EVENTOONBLUR,"AsignarValorAlaFila(2)");
				//}
				//else
				//{
				//	txt.Attributes.Add(Utilitario.Constantes.EVENTOONKEYUP,"AsignarValorAlaFila(2)");
				//}

				//Operador logico
				ddl = (DropDownList)e.Item.Cells[2].FindControl(CONTROLDDL2);
				ddl.DataSource = dtCondicion;
				ddl.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
				ddl.DataTextField= Enumerados.ColumnasTablaTablas.Descripcion.ToString();
				ddl.DataBind();
				//ddl.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"CambiarEstado('"+ idFila.ToString()  + "')");
				ddl.Attributes.Add(Utilitario.Constantes.EVENTOONCHANGE,"AsignarValorAlaFila(3);");
				item = ddl.Items.FindByValue(dr[IDOPERADORLOG].ToString());
				if (item!=null){item.Selected=true;}

				//Estado de la formula
				CheckBox chk = (CheckBox)e.Item.Cells[3].FindControl(CONTROLCHK);
				chk.Checked = ((Convert.ToInt32(dr[IDESTADO])==1)?true:false);
				//chk.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"CambiarEstado('"+ idFila.ToString()  + "')");
				chk.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,"AsignarValorAlaFila(4)");
				e.Item.Cells[4].Text = dr[ESTADO].ToString();
			}
			idFila ++;			
		}

		private void ibtnAgregar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			string []ArrRegistro  = hRegistro.Value.ToString().Split('@');
			try
			{
				for(int i = 1;i<= ArrRegistro.Length-1;i++)
				{
					string []Data = ArrRegistro[i].ToString().Split(';');
					switch (Data[1].ToString())
					{
						case "M":
							if (this.Modificar(ArrRegistro[i].ToString())==0)
							{
								ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Mensajes.CODIGOMENSAJEERRORESTADOFINANCEROMODIFICACION));   //"window.alert('No se puedo modificar registro');"; 
								return;
							}
							break;
						case "N":
							int Resultado = Convert.ToInt32(this.Agregar(ArrRegistro[i].ToString()));
							if (Resultado==0)
							{
								ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesErrorFinanciera.ToString(),Mensajes.CODIGOMENSAJEERRORESTADOFINANCEROREGISTRO)); //"window.alert('No se puedo Agregar registro');";
								return;
							}
							break;
						default:
							break;
					}
					
				}
				ltlMensaje.Text = Helper.MensajeAlert(Helper.ObtenerValorString(Enumerados.SeccionesArchivoConfiguracion.MensajesConfirmacionFinanciera.ToString(),Mensajes.CODIGOMENSAJECONFIRMACIONESTADOFINANCEROOPERACIONCOMPLETADA)); //"window.alert('Operacion completada');";
				this.CargarModoConsulta();
				this.LlenarGrillaOrdenamientoPaginacion("",Convert.ToInt32(this.hGridPagina.Value));
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

		

		private void gridAdm_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.LlenarGrillaOrdenamientoPaginacion("",e.NewPageIndex);
		}

		private void ibtnAdicionarFila_DataBinding(object sender, System.EventArgs e)
		{
		
		}

	
	}
}
