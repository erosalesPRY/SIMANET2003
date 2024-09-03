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
using SIMA.EntidadesNegocio.General;
using SIMA.Utilitario;
using NetAccessControl;
using SIMA.ManejadorExcepcion;
using SIMA.Log;


namespace SIMA.SimaNetWeb.GestionFinanciera
{
	/// <summary>
	/// Summary description for DocPrevioObjPropiedad.
	/// </summary>
	public class DocPrevioObjPropiedad : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		#region Constantes
			const string KEYQIDREPORTE = "IDREP";
			const string KEYQIDITEM = "IDITEM";
			const string KEYQTOP ="TOP";
			const string KEYQESTILO ="ESTILO";
			const string KEYQVALOR ="valor";


		//Otros
		const string METODOJSCRIPT ="Confirmar();";
		const string CONSTANTESI ="SI";
		const string TAMANOPX ="px";
		const string TAMANOPT ="pt";
		const string MENSAJE = "Operacion Cancelada";
		#endregion
		#region Control
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label Label15;
		protected System.Web.UI.WebControls.Label Label16;
		protected System.Web.UI.WebControls.Label Label17;
		protected System.Web.UI.WebControls.Label Label19;
		protected System.Web.UI.WebControls.Label Label20;
		protected System.Web.UI.WebControls.Label Label21;
		protected System.Web.UI.WebControls.Label Label18;
		protected System.Web.UI.WebControls.TextBox txtColorFondo;
		protected System.Web.UI.WebControls.TextBox txtNombre;
		protected System.Web.UI.WebControls.TextBox txtValor;
		protected System.Web.UI.WebControls.DropDownList ddlbAlineacion;
		protected System.Web.UI.WebControls.TextBox txtFontTamaño;
		protected System.Web.UI.WebControls.TextBox txtFontTipo;
		protected System.Web.UI.WebControls.TextBox txtFontColor;
		protected System.Web.UI.WebControls.CheckBox chkFontNegrita;
		protected System.Web.UI.WebControls.DropDownList ddlbCapitalizacion;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.DropDownList ddlbFuente;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hValorConfirma;
		protected System.Web.UI.WebControls.TextBox txtBordeArriba;
		protected System.Web.UI.WebControls.TextBox txtBordeAbajo;
		protected System.Web.UI.WebControls.TextBox txtBordeIzquierda;
		protected System.Web.UI.WebControls.TextBox txtBordeDerecha;
		protected eWorld.UI.NumericBox nPosArriba;
		protected eWorld.UI.NumericBox nAlto;
		protected eWorld.UI.NumericBox nPosIzquierda;
		protected eWorld.UI.NumericBox nAncho;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.ImageButton ibtnAcepta;
		protected System.Web.UI.WebControls.Image imgCancelar;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion 
		private void Page_Load(object sender, System.EventArgs e)
		{
			string arr = Page.Request.Params[KEYQTOP].ToString();
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();
					Helper.ReiniciarSession();
					this.LlenarJScript();
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
			// Put user code to initialize the page here
		}

		

		#region Web Form Designer generated code
		override protected void OnInit(System.EventArgs e)
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
			this.ibtnAcepta.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAcepta_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DocPrevioObjPropiedad.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DocPrevioObjPropiedad.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DocPrevioObjPropiedad.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DocPrevioObjPropiedad.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			// TODO:  Add DocPrevioObjPropiedad.LlenarDatos implementation
		}

		public void LlenarJScript()
		{
			this.ibtnAcepta.Attributes.Add(Utilitario.Constantes.EVENTOCLICK,METODOJSCRIPT);
			// TODO:  Add DocPrevioObjPropiedad.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DocPrevioObjPropiedad.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DocPrevioObjPropiedad.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DocPrevioObjPropiedad.Exportar implementation
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
			// TODO:  Add DocPrevioObjPropiedad.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			string strEstilo = this.ElaboraEstilo();
			if (this.hValorConfirma.Value==CONSTANTESI)
			{
				CDocPrevioItem oCDocPrevioItem = new CDocPrevioItem();
				DataTable dtGeneral = oCDocPrevioItem.ObtenerNuevoIDItemsdeReporte(Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]));
				DataRow dr = dtGeneral.Rows[0];

				char Comilla = '"';
				string strDefDiv = Utilitario.Constantes.DEFOBJDIV.ToString().Replace("NOMBRE","DIV" + Page.Request.Params[KEYQIDREPORTE]+ Utilitario.Constantes.SIGNOARROBA + dr[KEYQIDITEM].ToString()).Replace("EVENTO","onmousedown='dragstart(this);' EVENTO").Replace("VALOR",this.txtValor.Text).Replace("ESTILO","style=" + Comilla + strEstilo + Comilla );
				string ObjDiv=strDefDiv.ToString().Replace("EVENTO","ondblclick=" + Comilla + "Propiedades('" + Page.Request.Params[KEYQIDREPORTE].ToString() + "','" + dr[KEYQIDITEM].ToString() + "');" + Comilla );

/*				string strobjFinal = "<DIV ID=DIV" + Page.Request.Params[KEYQIDREPORTE]+ "@" + dr["idItem"].ToString();
				strobjFinal += " style=&" + strEstilo + "&";
				strobjFinal += " onmousedown=&dragstart(this);&";
				strobjFinal += " ondblclick= &Propiedades(" + Page.Request.Params[KEYQIDREPORTE].ToString() + "," + dr["iditem"].ToString() + ");&>";
				strobjFinal += " sistema de prueba";
				strobjFinal += " </div>";
*/

				string strobjFinal = "<DIV ID=DIV" + Page.Request.Params[KEYQIDREPORTE]+ Utilitario.Constantes.SIGNOARROBA + dr[KEYQIDITEM].ToString();
				strobjFinal += " style=" + Comilla + strEstilo + Comilla;
				strobjFinal += " onmousedown="+ Comilla +"dragstart(this);"+ Comilla;
				strobjFinal += " ondblclick= "+ Comilla +"Propiedades" + Utilitario.Constantes.SIGNOABREPARANTESIS + Page.Request.Params[KEYQIDREPORTE].ToString() + Utilitario.Constantes.SIGNOCOMA + dr[KEYQIDITEM].ToString() + Utilitario.Constantes.SIGNOCIERRAPARANTESIS + Utilitario.Constantes.SIGNOPUNTOYCOMA + Comilla + Utilitario.Constantes.SIGNOMAYOR;
				strobjFinal += " sistema de prueba";
				strobjFinal += " </div>";

				ltlMensaje.Text="CrearControl('" + Comilla + "','" + strobjFinal  + "');";
				DocPrevioItemBE oDocPrevioItemBE = new DocPrevioItemBE(Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]),Convert.ToInt32(dr[KEYQIDITEM].ToString()),strEstilo,this.txtValor.Text);
				int retorno = oCDocPrevioItem.Insertar(oDocPrevioItemBE);
				//grabar en la bae de datos
				if(retorno>0)
				{
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),"Carta de Credito",this.ToString(),"Se registró Item de Carta de Credito" + retorno.ToString() + ".",Enumerados.NivelesErrorLog.I.ToString()));
				}					
			}
			else
			{
				//ltlMensaje.Text="window.alert('Operacion Cancelada')";
				ltlMensaje.Text= Utilitario.Helper.MensajeAlert(MENSAJE);
			}

			// TODO:  Add DocPrevioObjPropiedad.Agregar implementation
		}
		private string ElaboraEstilo()
		{
			System.Text.StringBuilder strEstilo=new System.Text.StringBuilder();
			//Color de Fondo
			if (this.txtColorFondo.Text !=null)
			{strEstilo.Append("BACKGROUND-COLOR: " + txtColorFondo.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);	}
			// bordes y colores "BORDER-LEFT: #999999 1px solid;"
			if (this.txtBordeArriba.Text!=null)
			{strEstilo.Append("BORDER-TOP: " + this.txtBordeArriba.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);	}
			if (this.txtBordeAbajo.Text!=null)
			{strEstilo.Append("BORDER-BOTTOM: " + this.txtBordeAbajo.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			if (this.txtBordeIzquierda.Text!=null)
			{strEstilo.Append("BORDER-LEFT: " + this.txtBordeIzquierda.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			if (this.txtBordeDerecha.Text!=null)
			{strEstilo.Append("BORDER-RIGHT: " + this.txtBordeDerecha.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			//posicion del Objeto
			strEstilo.Append("POSITION: absolute;");

			if (this.nPosArriba.Text!=null)
			{strEstilo.Append("TOP: " + this.nPosArriba.Text + TAMANOPX + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			if (this.nPosIzquierda.Text!=null)
			{strEstilo.Append("LEFT: " + this.nPosIzquierda.Text + TAMANOPX + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			if (this.nAncho.Text!=null)
			{strEstilo.Append("WIDTH: " + this.nAncho.Text + TAMANOPX + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			if (this.nAlto.Text!=null)
			{strEstilo.Append("HEIGHT: " + this.nAlto.Text + TAMANOPX + Utilitario.Constantes.SIGNOPUNTOYCOMA);}

			//Texto y Fuente*/
			strEstilo.Append("TEXT-TRANSFORM: "+ ddlbCapitalizacion.SelectedValue.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA);
			//Alinecacion del Texto 
			strEstilo.Append("TEXT-ALIGN: " + this.ddlbAlineacion.SelectedValue.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA);

			if (this.txtFontColor.Text!=null)
			{strEstilo.Append("COLOR: Black;");}
			else
			{strEstilo.Append("COLOR: " + this.txtFontColor.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			if (chkFontNegrita.Checked == true)
			{strEstilo.Append("FONT-WEIGHT: bold;");}
			//Tamaño de Fuente
			if (this.txtFontTamaño.Text!=null)
			{strEstilo.Append("FONT-SIZE: " + this.txtFontTamaño.Text + TAMANOPT + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			else
			{strEstilo.Append("FONT-SIZE: 12pt;");}
			
			if(this.txtFontTipo.Text!=null)
			{strEstilo.Append("FONT-STYLE: " + this.txtFontTipo.Text + Utilitario.Constantes.SIGNOPUNTOYCOMA);}
			else
			{strEstilo.Append("FONT-STYLE: normal;");}
			
			strEstilo.Append("FONT-FAMILY: " + this.ddlbFuente.SelectedValue.ToString() + Utilitario.Constantes.SIGNOPUNTOYCOMA);
			
			return strEstilo.ToString();

		}
		public void Modificar()
		{
			// TODO:  Add DocPrevioObjPropiedad.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DocPrevioObjPropiedad.Eliminar implementation
		}

		public void CargarModoPagina()
		{
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}						
			// TODO:  Add DocPrevioObjPropiedad.CargarModoPagina implementation
		}

		public void CargarModoNuevo()
		{
			// TODO:  Add DocPrevioObjPropiedad.CargarModoNuevo implementation
		}

		public void CargarModoModificar()
		{
			CDocPrevioItem oCDocPrevioItem= new CDocPrevioItem();
			DataTable dtGeneral = oCDocPrevioItem.ObtenerNuevoIDItemsdeReporte(Convert.ToInt32(Page.Request.Params[KEYQIDREPORTE]));
			if(dtGeneral!=null)
			{
				foreach(DataRow dr in dtGeneral.Rows)
				{
					char Comilla = '"';
					string strDefDiv = Utilitario.Constantes.DEFOBJDIV.ToString().Replace("NOMBRE","DIV" + Page.Request.Params[KEYQIDREPORTE]+ Utilitario.Constantes.SIGNOARROBA + dr[KEYQIDITEM].ToString()).Replace("EVENTO","onmousedown='dragstart(this);' EVENTO").Replace("VALOR",dr[KEYQVALOR].ToString()).Replace("ESTILO","style=" + Comilla + dr[KEYQESTILO].ToString() + Comilla );
					string ObjDiv=strDefDiv.ToString().Replace("EVENTO","ondblclick=" + Comilla + "Propiedades('" + Page.Request.Params[KEYQIDREPORTE].ToString() + "','" + dr[KEYQIDITEM].ToString() + "');" + Comilla );
					Page.Response.Write(ObjDiv);
				}
			}
			// TODO:  Add DocPrevioObjPropiedad.CargarModoModificar implementation
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DocPrevioObjPropiedad.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DocPrevioObjPropiedad.ValidarCampos implementation
			return true;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DocPrevioObjPropiedad.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DocPrevioObjPropiedad.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		private void ibtnCancelar_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{

		}

		private void ibtnAcepta_Click(object sender, System.Web.UI.ImageClickEventArgs e)
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
				ltlMensaje.Text = Helper.MensajeAlert(oSIMAExcepcionDominio.Mensaje);					
			}
			catch(Exception oException)
			{
				string ex = oException.Message.ToString();
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}		
		}
	}
}
