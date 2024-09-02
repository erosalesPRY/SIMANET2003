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
using SIMA.Controladoras.GestionEstrategica;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionEstrategica.PlanEstrategico;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using SIMA.EntidadesNegocio.GestionEstrategica.PlanEstrategico;

namespace SIMA.SimaNetWeb.GestionEstrategica.PlanEstrategico
{
	public class DetalleAdministrarIndicadores : System.Web.UI.Page, IPaginaBase, IPaginaMantenimento
	{
		#region Controles
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.DropDownList ddlbIndicador;
		protected System.Web.UI.WebControls.DomValidators.RequiredDomValidator rfvIndicador;
		protected System.Web.UI.WebControls.Label lblTotal;
		protected System.Web.UI.HtmlControls.HtmlTable Table2;
		protected System.Web.UI.HtmlControls.HtmlTableCell CellddlbPrioridad;
		protected System.Web.UI.HtmlControls.HtmlTable Table8;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnCancelar;
		protected System.Web.UI.HtmlControls.HtmlImage ibtnAtras;
		protected System.Web.UI.WebControls.Label lblTitulo;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label14;
		protected eWorld.UI.NumericBox numEne;
		protected System.Web.UI.WebControls.Label Label17;
		protected eWorld.UI.NumericBox numAbr;
		protected System.Web.UI.WebControls.Label Label20;
		protected eWorld.UI.NumericBox numJul;
		protected System.Web.UI.WebControls.Label Label23;
		protected eWorld.UI.NumericBox numOct;
		protected System.Web.UI.WebControls.Label Label15;
		protected eWorld.UI.NumericBox numFeb;
		protected System.Web.UI.WebControls.Label Label18;
		protected eWorld.UI.NumericBox numMay;
		protected System.Web.UI.WebControls.Label Label21;
		protected eWorld.UI.NumericBox numAgo;
		protected System.Web.UI.WebControls.Label Label24;
		protected eWorld.UI.NumericBox numNov;
		protected System.Web.UI.WebControls.Label Label16;
		protected eWorld.UI.NumericBox numMar;
		protected System.Web.UI.WebControls.Label Label19;
		protected eWorld.UI.NumericBox numJun;
		protected System.Web.UI.WebControls.Label Label22;
		protected eWorld.UI.NumericBox numSet;
		protected System.Web.UI.WebControls.Label Label25;
		protected eWorld.UI.NumericBox numDic;
		protected System.Web.UI.WebControls.ImageButton ibtnAceptar;
		protected System.Web.UI.WebControls.Label Label1;
		protected eWorld.UI.NumericBox numOrden;
		protected System.Web.UI.WebControls.Literal ltlMensaje;
		#endregion
	
		#region Constantes
		
		//Titulos 
		const string TITULOMODONUEVO = "NUEVO INDICADOR";
		const string TITULOMODOMODIFICAR = "MODIFICAR INDICADOR";
		const string TITULOMODOCONSULTAR = "CONSULTAR INDICADOR";
		//Key Session y QueryString
		const string NOMBREACTIVIDAD = "ACTIVIDAD";

		const string KEYIDACTIVIDAD = "IdActividad";
		const string KEYIDINDICADOR = "IdIndicador";
		const string KEYIDOBJESP = "idObjEsp";

		//Paginas
		
		#endregion Constantes		

		#region Variables
		private ListItem item = new ListItem();
		#endregion

		private void CargarTiposIndicador()
		{
			ddlbIndicador.DataSource = (new CPEIndicador()).ListarIndicadoresPorObjetivoEspecifico(
				Convert.ToInt32(Page.Request[KEYIDOBJESP]));
			ddlbIndicador.DataValueField = Enumerados.ColumnasTablaTablas.Codigo.ToString();
			ddlbIndicador.DataTextField = Enumerados.ColumnasTablaTablas.Descripcion.ToString();
			ddlbIndicador.DataBind();	
			item = new ListItem(Utilitario.Constantes.TEXTOSSELECCIONAR,Utilitario.Constantes.VALORSELECCIONAR);
			ddlbIndicador.Items.Insert(0,item);
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					//this.ConfigurarAccesoControles();
					this.LlenarJScript();
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
			this.ibtnAceptar.Click += new System.Web.UI.ImageClickEventHandler(this.ibtnAceptar_Click);
			this.Load += new System.EventHandler(this.Page_Load);

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
			this.CargarTiposIndicador();
		}

		public void LlenarDatos()
		{
		}

		public void LlenarJScript()
		{
			rfvIndicador.ErrorMessage = "Seleccione Indicador";
			rfvIndicador.ToolTip = rfvIndicador.ErrorMessage;
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
		}

		public bool ValidarFiltros()
		{
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			PEIndicadorBE oPEIndicadorBE = new PEIndicadorBE();
			oPEIndicadorBE.IdActividad = Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD]);
			oPEIndicadorBE.IdTablaTipoIndicador = Convert.ToInt32(Enumerados.TablasTabla.TablaIndicadores);
			oPEIndicadorBE.IdTipoIndicador = Convert.ToInt32(ddlbIndicador.SelectedValue);

			if (numEne.Text != String.Empty)
			{oPEIndicadorBE.Mes1 = Convert.ToDouble(numEne.Text);}
			else
			{oPEIndicadorBE.Mes1 = 0;}

			if (numFeb.Text != String.Empty)
			{oPEIndicadorBE.Mes2 = Convert.ToDouble(numFeb.Text);}
			else
			{oPEIndicadorBE.Mes2 = 0;}

			if (numMar.Text != String.Empty)
			{oPEIndicadorBE.Mes3 = Convert.ToDouble(numMar.Text);}
			else
			{oPEIndicadorBE.Mes3 = 0;}

			if (numAbr.Text != String.Empty)
			{oPEIndicadorBE.Mes4 = Convert.ToDouble(numAbr.Text);}
			else
			{oPEIndicadorBE.Mes4 = 0;}

			if (numMay.Text != String.Empty)
			{oPEIndicadorBE.Mes5 = Convert.ToDouble(numMay.Text);}
			else
			{oPEIndicadorBE.Mes5 = 0;}

			if (numJun.Text != String.Empty)
			{oPEIndicadorBE.Mes6 = Convert.ToDouble(numJun.Text);}
			else
			{oPEIndicadorBE.Mes6 = 0;}

			if (numJul.Text != String.Empty)
			{oPEIndicadorBE.Mes7 = Convert.ToDouble(numJul.Text);}
			else
			{oPEIndicadorBE.Mes7 = 0;}

			if (numAgo.Text != String.Empty)
			{oPEIndicadorBE.Mes8 = Convert.ToDouble(numAgo.Text);}
			else
			{oPEIndicadorBE.Mes8 = 0;}

			if (numSet.Text != String.Empty)
			{oPEIndicadorBE.Mes9 = Convert.ToDouble(numSet.Text);}
			else
			{oPEIndicadorBE.Mes9 = 0;}
			
			if (numOct.Text != String.Empty)
			{oPEIndicadorBE.Mes10 = Convert.ToDouble(numOct.Text);}
			else
			{oPEIndicadorBE.Mes10 = 0;}
			
			if (numNov.Text != String.Empty)
			{oPEIndicadorBE.Mes11 = Convert.ToDouble(numNov.Text);}
			else
			{oPEIndicadorBE.Mes11 = 0;}

			if (numDic.Text != String.Empty)
			{oPEIndicadorBE.Mes12 = Convert.ToDouble(numDic.Text);}
			else
			{oPEIndicadorBE.Mes12 = 0;}
			
			oPEIndicadorBE.Orden = 0;

			if (Convert.ToInt32((new CPEIndicador()).Insertar(oPEIndicadorBE,null))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
				"Indicador",this.ToString(),"Se registró Item de Indicador" + Utilitario.Constantes.SIMBOLOPUNTO,
				Enumerados.NivelesErrorLog.I.ToString()));								
				
				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Modificar()
		{
			PEIndicadorBE oPEIndicadorBE = new PEIndicadorBE();
			oPEIndicadorBE.IdActividad = Convert.ToInt32(Page.Request.QueryString[KEYIDACTIVIDAD]);
			oPEIndicadorBE.IdIndicador = Convert.ToInt32(Page.Request.QueryString[KEYIDINDICADOR]);
			oPEIndicadorBE.IdTablaTipoIndicador = Convert.ToInt32(Enumerados.TablasTabla.TablaIndicadores);
			oPEIndicadorBE.IdTipoIndicador = Convert.ToInt32(ddlbIndicador.SelectedValue);

			if (numEne.Text != String.Empty)
			{oPEIndicadorBE.Mes1 = Convert.ToDouble(numEne.Text);}
			else
			{oPEIndicadorBE.Mes1 = 0;}

			if (numFeb.Text != String.Empty)
			{oPEIndicadorBE.Mes2 = Convert.ToDouble(numFeb.Text);}
			else
			{oPEIndicadorBE.Mes2 = 0;}

			if (numMar.Text != String.Empty)
			{oPEIndicadorBE.Mes3 = Convert.ToDouble(numMar.Text);}
			else
			{oPEIndicadorBE.Mes3 = 0;}

			if (numAbr.Text != String.Empty)
			{oPEIndicadorBE.Mes4 = Convert.ToDouble(numAbr.Text);}
			else
			{oPEIndicadorBE.Mes4 = 0;}

			if (numMay.Text != String.Empty)
			{oPEIndicadorBE.Mes5 = Convert.ToDouble(numMay.Text);}
			else
			{oPEIndicadorBE.Mes5 = 0;}

			if (numJun.Text != String.Empty)
			{oPEIndicadorBE.Mes6 = Convert.ToDouble(numJun.Text);}
			else
			{oPEIndicadorBE.Mes6 = 0;}

			if (numJul.Text != String.Empty)
			{oPEIndicadorBE.Mes7 = Convert.ToDouble(numJul.Text);}
			else
			{oPEIndicadorBE.Mes7 = 0;}

			if (numAgo.Text != String.Empty)
			{oPEIndicadorBE.Mes8 = Convert.ToDouble(numAgo.Text);}
			else
			{oPEIndicadorBE.Mes8 = 0;}

			if (numSet.Text != String.Empty)
			{oPEIndicadorBE.Mes9 = Convert.ToDouble(numSet.Text);}
			else
			{oPEIndicadorBE.Mes9 = 0;}
			
			if (numOct.Text != String.Empty)
			{oPEIndicadorBE.Mes10 = Convert.ToDouble(numOct.Text);}
			else
			{oPEIndicadorBE.Mes10 = 0;}
			
			if (numNov.Text != String.Empty)
			{oPEIndicadorBE.Mes11 = Convert.ToDouble(numNov.Text);}
			else
			{oPEIndicadorBE.Mes11 = 0;}

			if (numDic.Text != String.Empty)
			{oPEIndicadorBE.Mes12 = Convert.ToDouble(numDic.Text);}
			else
			{oPEIndicadorBE.Mes12 = 0;}

			oPEIndicadorBE.Orden = Convert.ToInt32(numOrden.Text);

			if (Convert.ToInt32((new CPEIndicador()).Modificar(oPEIndicadorBE,null))>0)
			{
				LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),
				"Indicador",this.ToString(),"Se modificó Item de Indicador" + Utilitario.Constantes.SIMBOLOPUNTO,
				Enumerados.NivelesErrorLog.I.ToString()));								

				ltlMensaje.Text = Helper.MensajeRetornoAlert();
			}
		}

		public void Eliminar()
		{
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
				case Enumerados.ModoPagina.C:
					this.CargarModoConsulta();
					break;
			}
		}

		public void CargarModoNuevo()
		{
			this.lblTitulo.Text = TITULOMODONUEVO;
			this.LlenarCombos();
			this.LlenarTitulos();
		}

		public void CargarDatos()
		{
			this.LlenarCombos();
			this.LlenarTitulos();

			PEIndicadorBE oPEIndicadorBE = (PEIndicadorBE)(new CPEIndicador()).ListarDetalle(Convert.ToInt32(Page.Request.QueryString[KEYIDINDICADOR].ToString()));
			numOrden.Text = oPEIndicadorBE.Orden.ToString();
			lblTotal.Text = oPEIndicadorBE.Total.ToString(Constantes.FORMATODECIMAL0);

			ListItem item = ddlbIndicador.Items.FindByValue(oPEIndicadorBE.IdTipoIndicador.ToString());
			if(item!=null){item.Selected=true;}

			{numEne.Text = oPEIndicadorBE.Mes1.ToString();}
			{numFeb.Text = oPEIndicadorBE.Mes2.ToString();}
			{numMar.Text = oPEIndicadorBE.Mes3.ToString();}
			{numAbr.Text = oPEIndicadorBE.Mes4.ToString();}
			{numMay.Text = oPEIndicadorBE.Mes5.ToString();}
			{numJun.Text = oPEIndicadorBE.Mes6.ToString();}
			{numJul.Text = oPEIndicadorBE.Mes7.ToString();}
			{numAgo.Text = oPEIndicadorBE.Mes8.ToString();}
			{numSet.Text = oPEIndicadorBE.Mes9.ToString();}
			{numOct.Text = oPEIndicadorBE.Mes10.ToString();}
			{numNov.Text = oPEIndicadorBE.Mes11.ToString();}
			{numDic.Text = oPEIndicadorBE.Mes12.ToString();}
		}

		public void CargarModoModificar()
		{
			this.lblTitulo.Text = TITULOMODOMODIFICAR;
			this.CargarDatos();
			this.ibtnAtras.Visible = false;

		}

		public void CargarModoConsulta()
		{
			this.lblTitulo.Text = TITULOMODOCONSULTAR;
			this.CargarDatos();
			Helper.BloquearControles(this);
			this.Table8.Visible = false;
		}

		public bool ValidarCampos()
		{
			return this.ValidarCamposRequeridos();
		}

		public bool ValidarCamposRequeridos()
		{
			if(ddlbIndicador.SelectedItem.Text == Utilitario.Constantes.TEXTOSSELECCIONAR)
			{
				ltlMensaje.Text =  Helper.MensajeAlert(rfvIndicador.ErrorMessage);
				return false;		
			}

			return true;
		}

		public bool ValidarExpresionesRegulares()
		{
			return false;
		}

		#endregion

		private void LlenarTitulos()
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
				SIMAExcepcionIU oSIMAExcepcionIU = LogTransaccional.CrearSIMAExcepcionIU(CNetAccessControl.GetUserName(),this.GetType().Name,Enumerados.OrigenError.Presentacion.ToString(),Constantes.CODIGOERRORGENERICO,oException.Message);
				Helper.ControlarErrorIU(this,oSIMAExcepcionIU.Mensaje);
			}
		
		}

	}
}
