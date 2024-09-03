using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using SIMA.SimaNetWeb.InterfacesIU;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Drawing;
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionSeguridadIndustrial;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionSeguridadIndustrial;

namespace SIMA.SimaNetWeb.GestionSeguridadIndustrial
{
	/// <summary>
	/// Summary description for DetalleMaterialDisponibledeEntrega.
	/// </summary>
	public class DetalleMaterialDisponibledeEntrega : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtCodMatEntrega;
		protected System.Web.UI.WebControls.TextBox txtCantEntrega;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtTalla;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodEntrega;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodItem;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodTrabajador;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox calFEntrega;
		protected System.Web.UI.WebControls.TextBox txtDescripcion;

		const string KEYCODITEM = "CodItem";
		const string KEYCODENTREGA = "CodEnt";
		const string KEYQCODPERSONA="CodPers";
		const string KEYQCLASEMAT="ClasMat";
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtFechaUltEntrega;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtNroDias;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCantAtendida;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCantEnStock;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hEstadoEntrega;
		const string KEYQIDAREA="IdArea";
		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
		}

		public string CodigoItem
		{
			get{return ((Page.Request.Params[KEYCODITEM]==null)?"": Page.Request.Params[KEYCODITEM].ToString());}
		}
		public string CodigoEntrega
		{
			get{return ((Page.Request.Params[KEYCODENTREGA]==null)?"": Page.Request.Params[KEYCODENTREGA].ToString());}
		}


		public string CodigoPersona
		{
			get{return Page.Request.Params[KEYQCODPERSONA].ToString();}
		}
		public string ClaseMaterial
		{
			get{return Page.Request.Params[KEYQCLASEMAT].ToString();}
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				try
				{
					this.ConfigurarAccesoControles();	
					Helper.ReiniciarSession();
					this.LlenarJScript();
					this.LlenarCombos();
					//Graba en el Log la acción ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gestión de Personal: Administrar Programación Personal Contratista", this.ToString(),"Se consultó El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					this.LlenarDatos();
					this.CargarModoPagina();
					
				}
				catch(SIMAExcepcionLog oSIMAExcepcionLog)
				{
					Helper.MsgBox("ACCESO A DATOS",oSIMAExcepcionLog.Mensaje,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				}
				catch(SIMAExcepcionIU oSIMAExcepcionIU)
				{
					Helper.MsgBox("ACCESO A DATOS",oSIMAExcepcionIU.Mensaje,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				}
				catch(SIMAExcepcionDominio oSIMAExcepcionDominio)
				{
					Helper.MsgBox("ACCESO A DATOS",oSIMAExcepcionDominio.Error,SIMA.Utilitario.Enumerados.Ext.MessageBox.Button.OK,SIMA.Utilitario.Enumerados.Ext.MessageBox.Icon.ERROR);
				}
				catch(Exception oException)
				{
					string msg = oException.Message.ToString();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			hModo.Value = Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString();
			hCodEntrega.Value= this.CodigoEntrega;
			hCodItem.Value= this.CodigoItem;
			hCodTrabajador.Value= this.CodigoPersona;

		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.ValidarFiltros implementation
			return false;
		}

		#endregion

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.Eliminar implementation
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
			StockMaterialBE oStockMaterialBE = (StockMaterialBE)(new CCCTT_StockMaterialPorArea()).DetalleMaterialStock(this.CodArea,this.CodigoItem);
			this.txtCodMatEntrega.Text = oStockMaterialBE.CodMat; //oStockMaterialEntregaBE.CodMat;
			this.txtDescripcion.Text = oStockMaterialBE.DescripcionMat; //oStockMaterialEntregaBE.NombreMat;
			this.txtCantEntrega.Text = oStockMaterialBE.CantEnStock.ToString(); //Biene a ser la cantidad que sera entregada;
			this.txtTalla.Text = oStockMaterialBE.NombreTalla; //oStockMaterialEntregaBE.NombreTalla;
			this.calFEntrega.Text=DateTime.Now.ToShortDateString();
			this.hCantEnStock.Value = oStockMaterialBE.CantEnStock.ToString();
			this.hCantAtendida.Value = oStockMaterialBE.CantAtendida.ToString();

			this.MostrarUltimaFechaEntrega(oStockMaterialBE.CodMat);

		}

		void MostrarUltimaFechaEntrega(string CodigoMaterial){
			StockMaterialEntregaBE oStockMaterialEntregaBE = (StockMaterialEntregaBE)(new CCCTT_KardexPersona()).ObtenerUltimaFechaEntrega(this.CodigoPersona,CodigoMaterial);
			if(oStockMaterialEntregaBE!=null)
			{
				this.txtFechaUltEntrega.Text = oStockMaterialEntregaBE.FechaUltEntrega.ToShortDateString();
				this.txtNroDias.Text= oStockMaterialEntregaBE.NroDias.ToString();
			}
		}

		public void CargarModoModificar()
		{
			
			StockMaterialEntregaBE oStockMaterialEntregaBE = (StockMaterialEntregaBE)(new CCCTT_KardexPersona()).Detalle(this.CodigoPersona,this.ClaseMaterial, this.CodigoEntrega);
			this.txtCodMatEntrega.Text = oStockMaterialEntregaBE.CodMat;
			this.txtDescripcion.Text = oStockMaterialEntregaBE.NombreMat;
			this.txtCantEntrega.Text = oStockMaterialEntregaBE.Cantidad.ToString();
			this.txtTalla.Text = oStockMaterialEntregaBE.NombreTalla;
			this.calFEntrega.Text=oStockMaterialEntregaBE.FechaEntrega.ToShortDateString();

			
			StockMaterialBE oStockMaterialBE = (StockMaterialBE)(new CCCTT_StockMaterialPorArea()).DetalleMaterialStock(oStockMaterialEntregaBE.CodArea,this.CodigoItem);
			this.hCantEnStock.Value = oStockMaterialBE.CantEnStock.ToString();
			this.hCantAtendida.Value = oStockMaterialBE.CantAtendida.ToString();
			if(oStockMaterialBE.CantEnStock==0){
				txtCantEntrega.ReadOnly=true;
			}
			hEstadoEntrega.Value =  oStockMaterialEntregaBE.IdMatEstadoEntrega.ToString();


			this.MostrarUltimaFechaEntrega(oStockMaterialEntregaBE.CodMat);
		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleMaterialDisponibledeEntrega.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion
	}
}
