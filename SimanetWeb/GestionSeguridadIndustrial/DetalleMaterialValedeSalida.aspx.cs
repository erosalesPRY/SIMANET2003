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
	/// Summary description for DetalleMaterialValedeSalida.
	/// </summary>
	public class DetalleMaterialValedeSalida : System.Web.UI.Page,IPaginaBase,IPaginaMantenimento
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtCodMat;
		protected System.Web.UI.WebControls.DropDownList ddlTalla;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtDesMat;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodItem;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodCeo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroAlmacen;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hNroValeSalida;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hModo;
		const string KEYQIDAREA="IdArea";

		const string KEYQCODCEO = "CodCeo";
		const string KEYQCODALM = "CodAlm";
		const string KEYQNROVALSAL = "NroValSal";
		const string KEYQCODMAT="CodMat";
		protected System.Web.UI.WebControls.TextBox txtCantEnVSM;
		protected System.Web.UI.WebControls.TextBox txtCantReg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCantReg;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hCodTblTalla;
		const string KEYCODITEM = "CodItem";

		
		public string CodigoCentro
		{
			get{return Page.Request.Params[KEYQCODCEO].ToString();}
		}
		public string CodigoAlmacen
		{
			get{return Page.Request.Params[KEYQCODALM].ToString();}
		}

		public string NroValeSalida
		{
			get{return Page.Request.Params[KEYQNROVALSAL].ToString();}
		}

		public string CodigoMaterial
		{
			get{return Page.Request.Params[KEYQCODMAT].ToString();}
		}

		public string CodigoItem
		{
			get{return ((Page.Request.Params[KEYCODITEM]==null)?"": Page.Request.Params[KEYCODITEM].ToString());}
		}
		public string CodArea
		{
			get{return Page.Request.Params[KEYQIDAREA].ToString();}
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
					
					//Graba en el Log la acci�n ejecutada
					LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(), "Gesti�n de Personal: Administrar Programaci�n Personal Contratista", this.ToString(),"Se consult� El Listado de las programaciones de los contratistas",Enumerados.NivelesErrorLog.I.ToString()));
					this.CargarModoPagina();
					
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

		#region IPaginaMantenimento Members

		public void Agregar()
		{
			// TODO:  Add DetalleMaterialValedeSalida.Agregar implementation
		}

		public void Modificar()
		{
			// TODO:  Add DetalleMaterialValedeSalida.Modificar implementation
		}

		public void Eliminar()
		{
			// TODO:  Add DetalleMaterialValedeSalida.Eliminar implementation
		}

		public void CargarModoPagina()
		{

			this.hModo.Value = Page.Request.QueryString[Constantes.KEYMODOPAGINA].ToString();
			Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.QueryString[Constantes.KEYMODOPAGINA]) ;
			switch (oModoPagina)
			{
				case Enumerados.ModoPagina.N:
					this.LlenarDatos();
					this.CargarModoNuevo();
					break;
				case Enumerados.ModoPagina.M:
					this.CargarModoModificar();
					break;
			}					
		}

		public void CargarModoNuevo()
		{
			StockMaterialBE oStockMaterialBE = (StockMaterialBE)(new CCCTT_ValedeSalida()).DetalleMaterial(this.CodigoCentro,this.NroValeSalida,this.CodigoAlmacen,this.CodigoMaterial);
			this.txtCodMat.Text = oStockMaterialBE.CodMat;
			this.txtDesMat.Text = oStockMaterialBE.DescripcionMat;
			this.txtCantEnVSM.Text	= oStockMaterialBE.CantEntregada.ToString();
			this.txtCantReg.Text	= oStockMaterialBE.CantPorReg.ToString();
			this.hCantReg.Value = oStockMaterialBE.CantRegistrada.ToString();
			this.hCodTblTalla.Value=oStockMaterialBE.CodTblRel.ToString();

			this.CargarTBLs(oStockMaterialBE.CodTblRel);

		}

		public void CargarModoModificar()
		{
			StockMaterialBE oStockMaterialBE = (StockMaterialBE)(new CCCTT_StockMaterialPorArea()).DetalleMaterialStock(this.CodArea,this.CodigoItem);
			this.txtCodMat.Text = oStockMaterialBE.CodMat;
			this.txtDesMat.Text = oStockMaterialBE.DescripcionMat;
			this.txtCantEnVSM.Text= oStockMaterialBE.CantEnVSM.ToString();
			this.txtCantReg.Text  = oStockMaterialBE.CantRegistrada.ToString();
			this.hCantReg.Value = oStockMaterialBE.CantRegistrada.ToString();
			this.hCodTblTalla.Value=oStockMaterialBE.CodTblRel.ToString();
			this.CargarTBLs(oStockMaterialBE.CodTblRel);

			ListItem litem = this.ddlTalla.Items.FindByValue(oStockMaterialBE.IdTalla.ToString());
			if(litem!=null){litem.Selected=true;}

			hCodItem.Value = oStockMaterialBE.CodItem;
			hCodCeo.Value=oStockMaterialBE.CodCeo;
			hNroAlmacen.Value=oStockMaterialBE.CodAlm;
			hNroValeSalida.Value=oStockMaterialBE.NroVsm;
			/*bLOQUEA LA EDICION SI EL MATERIAL YA CUENTA CON INFORMACION DE ATENCION*/
			if(oStockMaterialBE.CantAtendida>0){
				this.ddlTalla.Enabled=false;
				this.txtCantReg.Enabled=false;
			}


		}

		public void CargarModoConsulta()
		{
			// TODO:  Add DetalleMaterialValedeSalida.CargarModoConsulta implementation
		}

		public bool ValidarCampos()
		{
			// TODO:  Add DetalleMaterialValedeSalida.ValidarCampos implementation
			return false;
		}

		public bool ValidarCamposRequeridos()
		{
			// TODO:  Add DetalleMaterialValedeSalida.ValidarCamposRequeridos implementation
			return false;
		}

		public bool ValidarExpresionesRegulares()
		{
			// TODO:  Add DetalleMaterialValedeSalida.ValidarExpresionesRegulares implementation
			return false;
		}

		#endregion

		#region IPaginaBase Members

		public void LlenarGrilla()
		{
			// TODO:  Add DetalleMaterialValedeSalida.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add DetalleMaterialValedeSalida.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add DetalleMaterialValedeSalida.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			
		}
		void CargarTBLs(int IdTbl){
			this.ddlTalla.DataSource =(new CTablaTablas()).ListarItems(IdTbl);
			this.ddlTalla.DataTextField="Nom_item";
			this.ddlTalla.DataValueField="Cod_item";
			this.ddlTalla.DataBind();
		}

		public void LlenarDatos()
		{
			hCodItem.Value = this.CodigoItem;
			hCodCeo.Value=this.CodigoCentro;
			hNroAlmacen.Value=this.CodigoAlmacen;
			hNroValeSalida.Value=this.NroValeSalida;
		}

		public void LlenarJScript()
		{
			// TODO:  Add DetalleMaterialValedeSalida.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add DetalleMaterialValedeSalida.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add DetalleMaterialValedeSalida.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add DetalleMaterialValedeSalida.Exportar implementation
		}

		public void ConfigurarAccesoControles()
		{
			// TODO:  Add DetalleMaterialValedeSalida.ConfigurarAccesoControles implementation
		}

		public bool ValidarFiltros()
		{
			// TODO:  Add DetalleMaterialValedeSalida.ValidarFiltros implementation
			return false;
		}

		#endregion
	}
}
