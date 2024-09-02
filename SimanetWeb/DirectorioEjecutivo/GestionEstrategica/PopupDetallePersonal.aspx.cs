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
using SIMA.Controladoras.Personal;
using SIMA.Utilitario;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;

namespace SIMA.SimaNetWeb.DirectorioEjecutivo.GestionEstrategica
{
	/// <summary>
	/// Summary description for PopupDetallePersonal.
	/// </summary>
	public class PopupDetallePersonal : System.Web.UI.Page, IPaginaBase
	{
		#region Constantes

		const string KEYAPELLIDOSPERSONAL= "IdPersonal";
		private const string MENSAJECONSULTAR="Se consulto el detalle del personal responsable a la PC";

		//Otros <a href=../../imagenes/Aceptar.GIF></a>
		const string IMAGENACTIVO     = "../../imagenes/CheckYes.png";
		const string IMAGENBAJA       = "../../imagenes/CheckNo.png";
		const string IMAGENCAMBIO     = "../../imagenes/ChangeCO.GIF";
		const string IMAGENALERTA     = "../../imagenes/alert.gif";

		const string ToolTipPersonalXCesar        = "Personal por Cesar";
		const string ToolTipPersonalActivo        = "Personal Activo";
		const string ToolTipPersonaldeBaja        = "Personal de Baja";
		const string ToolTipPersonalCambio        = "Personal Cambió de Área o Condición Laboral";

		const string ARCHIVO = "sinfoto.jpg";

		const string EXTENSIONFOTO = ".JPG";


		#endregion

		#region Controles

		protected System.Web.UI.WebControls.TextBox txtSobAcum;
		protected System.Web.UI.WebControls.Label Label46;
		protected System.Web.UI.WebControls.Image imgEstado;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.TextBox txtSobAut;
		protected System.Web.UI.WebControls.Label Label33;
		protected System.Web.UI.WebControls.TextBox txtHaber;
		protected System.Web.UI.WebControls.Label Label32;
		protected System.Web.UI.WebControls.TextBox txtNivGO;
		protected System.Web.UI.WebControls.Label Label45;
		protected System.Web.UI.WebControls.TextBox txtMO;
		protected System.Web.UI.WebControls.Label Label31;
		protected System.Web.UI.WebControls.TextBox txtGO;
		protected System.Web.UI.WebControls.Label Label44;
		protected System.Web.UI.WebControls.TextBox txtEsp;
		protected System.Web.UI.WebControls.Label Label30;
		protected System.Web.UI.WebControls.TextBox txtTC;
		protected System.Web.UI.WebControls.Label Label42;
		protected System.Web.UI.WebControls.TextBox txtCargo;
		protected System.Web.UI.WebControls.Label Label29;
		protected System.Web.UI.WebControls.TextBox txtFTCont;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtTServ;
		protected System.Web.UI.WebControls.Label Label28;
		protected System.Web.UI.WebControls.TextBox txtFechFin;
		protected System.Web.UI.WebControls.Label Label41;
		protected System.Web.UI.WebControls.TextBox txtFechaIng;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtTT;
		protected System.Web.UI.WebControls.Label Label35;
		protected System.Web.UI.WebControls.TextBox txtCCosto;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Image imgFoto;
		protected System.Web.UI.WebControls.TextBox txtCo;
		protected System.Web.UI.WebControls.Label Label27;
		protected System.Web.UI.WebControls.TextBox txtPR;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.TextBox txtID;
		protected System.Web.UI.WebControls.TextBox txtEstCiv;
		protected System.Web.UI.WebControls.Label Label49;
		protected System.Web.UI.WebControls.TextBox txtProf;
		protected System.Web.UI.WebControls.Label Label39;
		protected System.Web.UI.WebControls.TextBox txtEdad;
		protected System.Web.UI.WebControls.Label Label48;
		protected System.Web.UI.WebControls.TextBox txtFechNac;
		protected System.Web.UI.WebControls.Label Label36;
		protected System.Web.UI.WebControls.TextBox txtNivInst;
		protected System.Web.UI.WebControls.Label Label38;
		protected System.Web.UI.WebControls.TextBox txtGrado;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.TextBox txtDni;
		protected System.Web.UI.WebControls.Label Label37;
		protected System.Web.UI.WebControls.TextBox txtApelyNom;
		protected System.Web.UI.WebControls.Label Label34;
		protected System.Web.UI.WebControls.Label lblDatos;
		protected System.Web.UI.WebControls.Label lblTitulo;

		#endregion

		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			
			this.LlenarDatos();
			LogAplicativo.GrabarLogAplicativoArchivo(new LogAplicativo(CNetAccessControl.GetUserName(),Enumerados.NombresdeModulo.GestionEstratégica.ToString(),this.ToString(),MENSAJECONSULTAR,Enumerados.NivelesErrorLog.I.ToString()));			
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
			// TODO:  Add PopupDetallePersonal.LlenarGrilla implementation
		}

		public void LlenarGrillaOrdenamiento(string columnaOrdenar)
		{
			// TODO:  Add PopupDetallePersonal.LlenarGrillaOrdenamiento implementation
		}

		public void LlenarGrillaOrdenamientoPaginacion(string columnaOrdenar, int indicePagina)
		{
			// TODO:  Add PopupDetallePersonal.LlenarGrillaOrdenamientoPaginacion implementation
		}

		public void LlenarCombos()
		{
			// TODO:  Add PopupDetallePersonal.LlenarCombos implementation
		}

		public void LlenarDatos()
		{
			try
			{
				CPersonal oCPersonal=new CPersonal();
				DataTable dtPersonal = oCPersonal.ConsultarDetallePlantaActual("ID",0,Convert.ToInt32(Page.Request.QueryString[KEYAPELLIDOSPERSONAL]),"");

				txtID.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.IDPERSONAL.ToString()].ToString();
				txtPR.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NROPERSONAL.ToString()].ToString();
				txtCo.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.CO.ToString()].ToString();
				txtCCosto.Text   = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.CODCC.ToString()].ToString() + Utilitario.Constantes.SEPARADORLINEA +
					dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NOMCC.ToString()].ToString();
				txtTT.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NROTIPOPERSONA.ToString()].ToString();
				txtTC.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.TIPOCONTRATO.ToString()].ToString();

				if (dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHAING.ToString()].ToString()!=String.Empty)
					txtFechaIng.Text = this.ConvFecha(Convert.ToDateTime(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHAING.ToString()].ToString()));
				else
					txtFechaIng.Text = "";

				if (dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHAFIN.ToString()].ToString()!=String.Empty)
					txtFechFin.Text  = this.ConvFecha(Convert.ToDateTime(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHAFIN.ToString()].ToString()));
				else
					txtFechFin.Text  = "";

				if (dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHATERMCONT.ToString()].ToString()!=String.Empty)
					txtFTCont.Text   = this.ConvFecha(Convert.ToDateTime(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHATERMCONT.ToString()].ToString()));
				else
					txtFTCont.Text   = "";

				txtTServ.Text    = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.T_SERV.ToString()].ToString();
				txtCargo.Text    = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.CARGO.ToString()].ToString();
				txtEsp.Text      = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.ESPECIALIDAD.ToString()].ToString();
				txtGrado.Text    = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.GRADO.ToString()].ToString();
				txtMO.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.TIPOMANOOBRA.ToString()].ToString();
				txtGO.Text       = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.GRUPOOCUPACIONAL.ToString()].ToString();
				txtNivGO.Text    = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NIVELGPOOCUP.ToString()].ToString();
				txtApelyNom.Text = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.APELLIDOPATERNO.ToString()].ToString()+" "+
					dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.APELLIDOMATERNO.ToString()].ToString()+" "+
					dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NOMBRES.ToString()].ToString();

				if (dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHANAC.ToString()].ToString()!=String.Empty)
					txtFechNac.Text  = this.ConvFecha(Convert.ToDateTime(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.FECHANAC.ToString()].ToString()));
				else
					txtFechNac.Text = "";

				txtEdad.Text     = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.EDAD.ToString()].ToString();

				txtDni.Text      = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NRODOCIDENTIDAD.ToString()].ToString();
				txtEstCiv.Text   = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.ESTADOCIVIL.ToString()].ToString();
				txtNivInst.Text  = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NIVELINSTRUCCION.ToString()].ToString();
				txtProf.Text     = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.PROFESION.ToString()].ToString();

				if (dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.HABER.ToString()].ToString()!=String.Empty)
					txtHaber.Text    = Convert.ToDouble(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.HABER.ToString()].ToString()).ToString(Utilitario.Constantes.FORMATODECIMAL4);
				else
					txtHaber.Text    = "";

				txtHaber.Style[Utilitario.Constantes.ALINEAMIENTOTEXTO] = TextAlign.Right.ToString();

				string strFilename = dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.NROPERSONAL.ToString()].ToString() + EXTENSIONFOTO;

				string pathServer = Helper.ObtenerRutaImagenes(Utilitario.Constantes.RUTAFOTOS);


				if (Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.ESTADO.ToString()]) == Utilitario.Constantes.ESTADOALERTA )
				{
					imgEstado.ImageUrl = IMAGENALERTA;
					imgEstado.ToolTip  = ToolTipPersonalXCesar;
				}
				else 
				{
					if(Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.ESTADO.ToString()]) == Utilitario.Constantes.ESTADOACTIVO )
					{
						imgEstado.ImageUrl = IMAGENACTIVO;
						imgEstado.ToolTip  = ToolTipPersonalActivo;
					}
					else
					{
						if(Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.ESTADO.ToString()]) == Utilitario.Constantes.ESTADOBAJA )
						{
							imgEstado.ImageUrl = IMAGENBAJA;
							imgEstado.ToolTip  = ToolTipPersonaldeBaja;
						}
						else
						{
							if(Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.ESTADO.ToString()]) == Utilitario.Constantes.ESTADOCAMBIO )
							{
								imgEstado.ImageUrl = IMAGENCAMBIO;
								imgEstado.ToolTip  = ToolTipPersonalCambio;
							}
						}
					}
				}

			
				if (Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.IDCENTROOPERATIVO.ToString()].ToString()) == Utilitario.Constantes.SIMAPERU ||
					Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.IDCENTROOPERATIVO.ToString()].ToString()) == Utilitario.Constantes.SIMACALLAO ||
					Convert.ToInt32(dtPersonal.Rows[0][Enumerados.ColumnasConsDetallePlantaActual.IDCENTROOPERATIVO.ToString()].ToString()) == Utilitario.Constantes.SIMAIQUITOS )
					imgFoto.ImageUrl  = pathServer + strFilename;
				else
					imgFoto.ImageUrl  = pathServer + ARCHIVO;	
			}
			catch(Exception oException)
			{
				string error = oException.Message.ToString();
			}
			//PERuspNTADConsDetallePlantaActual 'ID',0,18046,NULL
		}

		public void LlenarJScript()
		{
			// TODO:  Add PopupDetallePersonal.LlenarJScript implementation
		}

		public void RegistrarJScript()
		{
			// TODO:  Add PopupDetallePersonal.RegistrarJScript implementation
		}

		public void Imprimir()
		{
			// TODO:  Add PopupDetallePersonal.Imprimir implementation
		}

		public void Exportar()
		{
			// TODO:  Add PopupDetallePersonal.Exportar implementation
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
			// TODO:  Add PopupDetallePersonal.ValidarFiltros implementation
			return false;
		}

		#endregion

		private string ConvFecha(DateTime Fecha)
		{
			return Fecha.ToString(Utilitario.Constantes.FORMATOFECHA4);
		}
	}
}
