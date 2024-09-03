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
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using System.IO;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	
	public class DetalleAntecedenteTrabajadorContratista : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Controls
			protected System.Web.UI.WebControls.Label lblRutaPagina;
			protected System.Web.UI.WebControls.Label lblPagina;
			protected System.Web.UI.WebControls.Label lblTitulo;
			protected System.Web.UI.WebControls.Label Label1;
			protected System.Web.UI.WebControls.Label Label2;
			protected System.Web.UI.WebControls.Label Label7;
			protected System.Web.UI.WebControls.Label Label8;
			protected System.Web.UI.WebControls.Label Label9;
			protected System.Web.UI.WebControls.Label Label3;
			protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdArea;
		protected eWorld.UI.CalendarPopup CalFecha;
		protected eWorld.UI.TimePicker tmHora;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdProveedor;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdTrab;
		#endregion

		protected System.Web.UI.WebControls.Literal ltlMensaje;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.CheckBox chkCritica;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.TextBox txtNroDNI;
		protected System.Web.UI.WebControls.DropDownList ddlParentesco;
		protected System.Web.UI.WebControls.CheckBox chkContratista;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.TextBox txtTrabajador;
		protected System.Web.UI.WebControls.Image oImgFoto;
		protected System.Web.UI.WebControls.TextBox txtArea;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdJefe;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdPerInterviene;
		protected System.Web.UI.WebControls.CheckBox chkIngPermitido;
		protected System.Web.UI.WebControls.TextBox txtContratista;
		protected System.Web.UI.WebControls.TextBox txtJefe;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdFamiliar;
		protected System.Web.UI.WebControls.TextBox txtFamiliar;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.TextBox txtEventoCritico;
		protected System.Web.UI.WebControls.TextBox txtObservacion;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.TextBox txtPersonaInterviene;
		protected System.Web.UI.WebControls.DropDownList ddlTipoAntecedente;
		protected System.Web.UI.HtmlControls.HtmlInputFile FUFile;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCargar;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathHttpTmp;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.HtmlControls.HtmlInputFile fAnexo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCarga2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstAnexo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNombreArchivoUP;
		protected System.Web.UI.WebControls.Button btnSubir;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathLocalTmp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFileHttpTmp;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hLstAnexoDel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFileHttpFinal;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hIdUsuario;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.TextBox txtApellidoP;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.TextBox txtApellidoM;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.TextBox txtNombres;
		protected System.Web.UI.WebControls.Label Label22;
		protected System.Web.UI.WebControls.DropDownList ddlNacionalidad;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAgregarTrab;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAgregarTrab2;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAgregarTrab3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hFecha;
		protected System.Web.UI.WebControls.TextBox txtNroDNIReg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hUpload;
		protected System.Web.UI.WebControls.Button btnCargarFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hGrabarFoto;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroRecarga;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hPathFileLocalTmp;

		//const string KEYQIDANTECEDENTE = "IdAnte";
		/*public string IdAntecedente{
			get{return Page.Request.Params[KEYQIDANTECEDENTE].ToString();}
		}
		*/

		public string Extension
		{
			get{return (string)Session["Exten"];}
			set{Session["Exten"]=value;}
		}
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			 Page.GetPostBackEventReference(this, "MyEventArgumentName");

			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					this.LlenarJScript();
					this.LlenarCombos();
					this.LlenarDatos();
					this.CargarModoPagina();	
					//LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Registro de programación - CONTRATISTA", this.ToString(),"Se ingreso a la funcionalidad de  registro de Programación(Ingreso y Modificación)",Enumerados.NivelesErrorLog.I.ToString()));
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
					//Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
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
			this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
			this.btnCargarFoto.Click += new System.EventHandler(this.btnCargarFoto_Click);
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			ddlTipoAntecedente.DataSource =(new CTablaTablas()).ListaTodosCombo(620);
			ddlTipoAntecedente.DataTextField="var1";
			ddlTipoAntecedente.DataValueField="Codigo";
			ddlTipoAntecedente.DataBind();
			ListItem lItem = new ListItem("[Seleccionar]","0");
			ddlTipoAntecedente.Items.Insert(0,lItem);
			//Cargar Parentesco

			ddlParentesco.DataSource =(new CTablaTablas()).ListaTodosCombo(622);
			ddlParentesco.DataTextField="var1";
			ddlParentesco.DataValueField="Codigo";
			ddlParentesco.DataBind();


			//Cargar Nacionalidad
			const int IDTABLANACIONALIDAD = 458;
			this.ddlNacionalidad.DataSource = (new CTablaTablas()).ListaTodosCombo(IDTABLANACIONALIDAD);
			this.ddlNacionalidad.DataTextField = Enumerados.ColumnasTablasTablas.Var1.ToString();
			this.ddlNacionalidad.DataValueField = Enumerados.ColumnasTablasTablas.Codigo.ToString();
			this.ddlNacionalidad.DataBind();

		}

		public void LlenarDatos()
		{
			hPathHttpTmp.Value = Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpTmpDirImg;
			hPathFileHttpTmp.Value = Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpTmpDirFile;
			hPathFileHttpFinal.Value= Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpDirFile;
			CtrlAnexos(Utilitario.Helper.GestionSeguridadIndustrial.Params.IdAntecedente);
			hIdUsuario.Value = CNetAccessControl.GetIdUser().ToString();
			hFecha.Value = DateTime.Now.ToString("yyyymmdd");
		}

		public void LlenarJScript()
		{
			btnSubir.Style["display"]="none";
			btnCargarFoto.Style["display"]="none";
			//btnCargarFoto.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"ProgresoUpLoad()");

			//ibtnAgregarTrab.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AgregarTrabajador()");
			//ibtnAgregarTrab2.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AgregarTrabajador()");
			//ibtnAgregarTrab3.Attributes.Add(Utilitario.Enumerados.EventosJavaScript.OnClick.ToString(),"AgregarTrabajador()");
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.ValidarFiltros implementation
			return false;
		}

		#endregion


		ArrayList ObtenerCollecciondeAnexos(string LstAnexos,string IdAntecedente)
		{
			ArrayList oColletionAnexoBE = new ArrayList();
			oColletionAnexoBE = new ArrayList();
			if(LstAnexos.Length>0)
			{
				string []arrAnexo = LstAnexos.Split('@');
				for(int i=0;i<=arrAnexo.Length-1;i++)
				{
					string []Data = arrAnexo[i].ToString().Split(';');

					AntecedenteAnexoBE oAntecedenteAnexoBE = new AntecedenteAnexoBE();
					oAntecedenteAnexoBE.IdAnexo= Data[0];
					oAntecedenteAnexoBE.NombreArchivo = Data[1].ToString();
					oAntecedenteAnexoBE.IdAntecedente=IdAntecedente;
					oAntecedenteAnexoBE.IdEstado = 1;
					oColletionAnexoBE.Add(oAntecedenteAnexoBE);
				}
				return oColletionAnexoBE;
			}
			return  null;
		}

		

		#region IPaginaMantenimento Members

		public void Agregar()
		{
		
			AntecedenteTrabajadorContratistaBE oAntecedenteTrabajadorContratistaBE = new AntecedenteTrabajadorContratistaBE();	

			oAntecedenteTrabajadorContratistaBE.NroDNI= this.txtNroDNI.Text;
			oAntecedenteTrabajadorContratistaBE.IdProveedor= ((txtContratista.Text.Length>0)?Convert.ToInt32(this.hIdProveedor.Value):0);
			oAntecedenteTrabajadorContratistaBE.Contratista=((this.chkContratista.Checked==true)?1:0);
			oAntecedenteTrabajadorContratistaBE.IdLugardeTrabajo= Convert.ToInt32(this.hIdArea.Value);
			oAntecedenteTrabajadorContratistaBE.IdTipoAntecedente= Convert.ToInt32(this.ddlTipoAntecedente.SelectedValue);
			oAntecedenteTrabajadorContratistaBE.Fecha= this.CalFecha.SelectedDate;
			oAntecedenteTrabajadorContratistaBE.Hora= this.tmHora.SelectedTime.ToShortTimeString();
			oAntecedenteTrabajadorContratistaBE.Descripcion= this.txtObservacion.Text;

			oAntecedenteTrabajadorContratistaBE.DescripcioEvento = this.txtEventoCritico.Text;
			oAntecedenteTrabajadorContratistaBE.IdJefeDirecto = ((txtJefe.Text.Length>0)? this.hIdJefe.Value:null);
			oAntecedenteTrabajadorContratistaBE.IdPersonalFamiliar=Convert.ToInt32(this.hIdFamiliar.Value);
			oAntecedenteTrabajadorContratistaBE.IdParentesco=Convert.ToInt32(this.ddlParentesco.SelectedValue);
			oAntecedenteTrabajadorContratistaBE.DescripcioEvento = this.txtEventoCritico.Text;
			oAntecedenteTrabajadorContratistaBE.IdPersonalInterviene=this.hIdPerInterviene.Value;
			oAntecedenteTrabajadorContratistaBE.IngresoPermitido=((this.chkIngPermitido.Checked==true)?1:0);
			oAntecedenteTrabajadorContratistaBE.Extension= Extension;

			int retorno=(new CCCTT_TrabajadorAntecedente()).Insertar(oAntecedenteTrabajadorContratistaBE,ObtenerCollecciondeAnexos(hLstAnexo.Value,""));
			if(retorno>0)
			{
				if((oAntecedenteTrabajadorContratistaBE.Extension!=null) && (oAntecedenteTrabajadorContratistaBE.Extension.Length>0))
				{
					if(hGrabarFoto.Value=="1")
					{
						try
						{
							string ImgFinal = Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalDirImg+ this.txtNroDNI.Text + "."+ oAntecedenteTrabajadorContratistaBE.Extension;
							if(File.Exists(ImgFinal))
							{
								File.Delete(ImgFinal);
							}
							string NombArchivo = Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalTmpDirImg  + ((Convert.ToInt32(this.hNroRecarga.Value)>0)?(Convert.ToInt32(this.hNroRecarga.Value)-1).ToString():this.hNroRecarga.Value) +"_" + this.txtNroDNI.Text + "."+ oAntecedenteTrabajadorContratistaBE.Extension;
							Utilitario.Helper.CopiarArchivo(Utilitario.Enumerados.FileTipoOperacion.Cortar, NombArchivo,Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalDirImg+ this.txtNroDNI.Text + "."+ oAntecedenteTrabajadorContratistaBE.Extension);
							//File.Delete(NombArchivo);
							hGrabarFoto.Value="0";
						}
						catch(Exception ex){}
					}
				}
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró Antecedente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}	
		}

	

		public void Modificar()
		{
			AntecedenteTrabajadorContratistaBE oAntecedenteTrabajadorContratistaBE = new AntecedenteTrabajadorContratistaBE();	
			oAntecedenteTrabajadorContratistaBE.IdAntecedente = Utilitario.Helper.GestionSeguridadIndustrial.Params.IdAntecedente;
			oAntecedenteTrabajadorContratistaBE.NroDNI= this.txtNroDNI.Text;
			oAntecedenteTrabajadorContratistaBE.IdProveedor= ((txtContratista.Text.Length>0)?Convert.ToInt32(this.hIdProveedor.Value):0);
			oAntecedenteTrabajadorContratistaBE.Contratista=((this.chkContratista.Checked==true)?1:0);
			oAntecedenteTrabajadorContratistaBE.IdLugardeTrabajo= Convert.ToInt32(this.hIdArea.Value);
			oAntecedenteTrabajadorContratistaBE.IdTipoAntecedente= Convert.ToInt32(this.ddlTipoAntecedente.SelectedValue);
			oAntecedenteTrabajadorContratistaBE.Fecha= this.CalFecha.SelectedDate;
			oAntecedenteTrabajadorContratistaBE.Hora= this.tmHora.SelectedTime.ToShortTimeString();
			oAntecedenteTrabajadorContratistaBE.Descripcion= this.txtObservacion.Text;

			oAntecedenteTrabajadorContratistaBE.IdJefeDirecto = ((txtJefe.Text.Length>0)? this.hIdJefe.Value:null);
			oAntecedenteTrabajadorContratistaBE.DescripcioEvento = this.txtEventoCritico.Text;
			oAntecedenteTrabajadorContratistaBE.IdPersonalFamiliar=Convert.ToInt32(this.hIdFamiliar.Value);
			oAntecedenteTrabajadorContratistaBE.IdParentesco=Convert.ToInt32(this.ddlParentesco.SelectedValue);
			oAntecedenteTrabajadorContratistaBE.DescripcioEvento = this.txtEventoCritico.Text;
			oAntecedenteTrabajadorContratistaBE.IdPersonalInterviene=this.hIdPerInterviene.Value;
			oAntecedenteTrabajadorContratistaBE.IngresoPermitido=((this.chkIngPermitido.Checked==true)?1:0);
			oAntecedenteTrabajadorContratistaBE.Extension= Extension;

			int retorno=(new CCCTT_TrabajadorAntecedente()).Modificar(oAntecedenteTrabajadorContratistaBE,ObtenerCollecciondeAnexos(hLstAnexo.Value,oAntecedenteTrabajadorContratistaBE.IdAntecedente),ObtenerCollecciondeAnexos(hLstAnexoDel.Value,oAntecedenteTrabajadorContratistaBE.IdAntecedente));
			if(retorno>0)
			{
				if((oAntecedenteTrabajadorContratistaBE.Extension!=null) && (oAntecedenteTrabajadorContratistaBE.Extension.Length>0))
				{
					if(hGrabarFoto.Value=="1")
					{
						try
						{
							string ImgFinal = Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalDirImg+ this.txtNroDNI.Text + "."+ oAntecedenteTrabajadorContratistaBE.Extension;
							if(File.Exists(ImgFinal))
							{
								File.Delete(ImgFinal);
							}
							string NombArchivo = Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalTmpDirImg  + ((Convert.ToInt32(this.hNroRecarga.Value)>0)?(Convert.ToInt32(this.hNroRecarga.Value)-1).ToString():this.hNroRecarga.Value) +"_" + this.txtNroDNI.Text + "."+ oAntecedenteTrabajadorContratistaBE.Extension;
							Utilitario.Helper.CopiarArchivo(Utilitario.Enumerados.FileTipoOperacion.Cortar, NombArchivo,ImgFinal);
							hGrabarFoto.Value="0";
						}
						catch(Exception ex)
						{
							string msg = ex.Message;
							string xx = msg;
						}
					}
				}

				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Seguridad industrial",this.ToString(),"Se registró Antecedente. " + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}	
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.Eliminar implementation
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
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.CargarModoNuevo implementation
		}

		void CtrlAnexos(string IdAntecedente)
		{
			try
			{
				foreach(DataRow dri in (new CCCTT_TrabajadorAntecedenteAnexo()).Listar(IdAntecedente).Rows)
				{
					hLstAnexo.Value += dri["IdAnexo"].ToString() +';'+dri["Nombre"].ToString() +'@';
				}
				hLstAnexo.Value = hLstAnexo.Value .ToString().Substring(0,hLstAnexo.Value.ToString().Length-1);
			}
			catch(Exception ex){}
		}

		public void CargarModoModificar()
		{
			
			AntecedenteTrabajadorContratistaBE oAntecedenteTrabajadorContratistaBE=(AntecedenteTrabajadorContratistaBE)(new CCCTT_TrabajadorAntecedente()).Detalle(Utilitario.Helper.GestionSeguridadIndustrial.Params.IdAntecedente);
			if(oAntecedenteTrabajadorContratistaBE!=null){
				this.txtTrabajador.Text=oAntecedenteTrabajadorContratistaBE.ApellidosyNombres;
				this.txtNroDNI.Text= oAntecedenteTrabajadorContratistaBE.NroDNI;
				this.hIdProveedor.Value= oAntecedenteTrabajadorContratistaBE.IdProveedor.ToString();
				this.txtContratista.Text= oAntecedenteTrabajadorContratistaBE.RazonSocial;
				this.txtArea.Text=oAntecedenteTrabajadorContratistaBE.NombreLugardeTrabajo.ToString();	
				this.hIdArea.Value=oAntecedenteTrabajadorContratistaBE.IdLugardeTrabajo.ToString();


				ListItem item = this.ddlTipoAntecedente.Items.FindByValue(oAntecedenteTrabajadorContratistaBE.IdTipoAntecedente.ToString());
				if(item!=null){item.Selected=true;}
			
				this.CalFecha.SelectedDate =  oAntecedenteTrabajadorContratistaBE.Fecha;
				this.tmHora.SelectedTime =  Convert.ToDateTime(oAntecedenteTrabajadorContratistaBE.Hora);
				this.txtObservacion.Text=oAntecedenteTrabajadorContratistaBE.Descripcion;
				this.chkContratista.Checked =((oAntecedenteTrabajadorContratistaBE.Contratista==1)?true:false);
				this.hIdJefe.Value =  oAntecedenteTrabajadorContratistaBE.IdJefeDirecto.ToString();
				this.txtJefe.Text =	oAntecedenteTrabajadorContratistaBE.NombresJefeDirecto;

				this.hIdFamiliar.Value= oAntecedenteTrabajadorContratistaBE.IdPersonalFamiliar.ToString();
				this.txtFamiliar.Text = oAntecedenteTrabajadorContratistaBE.NombresFamiliar;


				item =  this.ddlParentesco.Items.FindByValue(oAntecedenteTrabajadorContratistaBE.IdParentesco.ToString());
				if(item!=null){item.Selected=true;}

				

				this.txtEventoCritico.Text= oAntecedenteTrabajadorContratistaBE.DescripcioEvento;

				this.hIdPerInterviene.Value= oAntecedenteTrabajadorContratistaBE.IdPersonalInterviene.ToString();
				this.txtPersonaInterviene.Text = oAntecedenteTrabajadorContratistaBE.NombrePersonalInterviene;
				this.Extension = oAntecedenteTrabajadorContratistaBE.Extension;
				this.chkIngPermitido.Checked=((oAntecedenteTrabajadorContratistaBE.IngresoPermitido==1)?true:false);

				this.oImgFoto.ImageUrl = Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpDirImg + this.txtNroDNI.Text + "." + oAntecedenteTrabajadorContratistaBE.Extension;
				this.oImgFoto.Attributes.Add("onerror","ErrLoadImg(this);");

										   
			}
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			if(this.txtNroDNI.Text.Length==0){
				Utilitario.Helper.MsgBox("VALIDACION","Ingresar Nro DNI",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				return false;
			}
			if(this.hIdArea.Value.Length==0){
				Utilitario.Helper.MsgBox("VALIDACION","Ingresar punto de intervención",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				return false;
			}
			if(Convert.ToInt32(this.ddlTipoAntecedente.SelectedValue)==0){
				Utilitario.Helper.MsgBox("VALIDACION","Ingresar tipo de antecedente",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				return false;
			}
			if(this.txtObservacion.Text.Length==0)
			{
				Utilitario.Helper.MsgBox("VALIDACION","Ingresar observacion",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				return false;
			}
			if(this.txtEventoCritico.Text.Length==0)
			{
				Utilitario.Helper.MsgBox("VALIDACION","Ingresar evento critico",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				return false;
			}
			if(this.hIdPerInterviene.Value.Length==0)
			{
				Utilitario.Helper.MsgBox("VALIDACION","Ingresar personal que interviene",SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.INFO);
				return false;
			}
			
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleAntecedenteTrabajadorContratista.ValidarExpresionesRegulares implementation
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

		private void btnSubir_Click(object sender, System.EventArgs e)
		{
			string []arrNombre = this.hNombreArchivoUP.Value.ToString().Split('.');
			string Ext =arrNombre[arrNombre.Length-1];
			string SoloNombre = this.hNombreArchivoUP.Value.ToString().Substring(0,this.hNombreArchivoUP.Value.ToString().Length-(Ext.Length+1));
			//string SoloNombre = this.hNombreArchivoUP.Value.ToString();
			string NombreArchivo = CNetAccessControl.GetIdUser().ToString() + SoloNombre;
			Helper.SubirArchivo(this.fAnexo,Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpTmpDirFile,NombreArchivo);
		}
		
		int NroCargas= 0;
		private void btnCargarFoto_Click(object sender, System.EventArgs e)
		{
			NroCargas = Convert.ToInt32(hNroRecarga.Value);
 
			string []arrPath=this.FUFile.Value.Split('.');
			Extension = arrPath[arrPath.Length-1];
			string nArchivo = Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalTmpDirImg  + NroCargas.ToString() +"_" + this.txtNroDNI.Text+'.'+ Extension;

			if(File.Exists(nArchivo))
			{
				File.Delete(nArchivo);
			}
			Utilitario.Helper.SubirArchivo(this.FUFile,Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalTmpDirImg,NroCargas.ToString() +"_" +this.txtNroDNI.Text);
			oImgFoto.ImageUrl= Helper.Configuracion.SeguridadIndustrial.Antecedentes.HttpTmpDirImg + NroCargas.ToString() +"_" +this.txtNroDNI.Text+'.'+ Extension;
			if(NroCargas>0){//Elimina recargas anteriores
				int RecargaAnt = NroCargas -1;
				string ArchivoAnt = Helper.Configuracion.SeguridadIndustrial.Antecedentes.LocalTmpDirImg  + RecargaAnt.ToString() +"_" + this.txtNroDNI.Text+'.'+ Extension;
				if(File.Exists(ArchivoAnt))
				{
					File.Delete(ArchivoAnt);
				}
	
			}
			NroCargas++;
			hNroRecarga.Value=NroCargas.ToString();
		}
	}
}
