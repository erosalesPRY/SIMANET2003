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
using SIMA.Controladoras;
using SIMA.Controladoras.General;
using SIMA.Controladoras.GestionIntegrada;
using SIMA.Utilitario;
using SIMA.EntidadesNegocio;
using SIMA.EntidadesNegocio.GestionIntegrada;
using SIMA.ManejadorExcepcion;
using SIMA.Log;
using NetAccessControl;
using MetaBuilders.WebControls;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;
using System.Configuration;

namespace SIMA.SimaNetWeb.GestionIntegrada
{
	/// <summary>
	/// Summary description for Procesar.
	/// </summary>
	public class Procesar : System.Web.UI.Page
	{
		const string PROCESO ="idProceso";
		
		const int KEYPRCADMINISTRARSAMPT=196;
		const int KEYPRCBUSCARAREAGENERALPORCRITERIO=200;
		const int KEYPRCMANTENIMIENTOANEXO=201;
		const int KEYPRCLISTARAUDITORIAS=202;
		const int KEYPRCADMINISTRARCAUSARAIZ=204;
		const int KEYPRCCONSULTARSAMACCION=205;
		const int KEYPRCADMINISTRARACCION=207;
		const int KEYPRCADMINISTRARACCIONANEXO=208;
		const int KEYPRCADMINISTRARSAM=209;
		const int KEYPRCCONSULTARVALIDACION=210;
		const int KEYPRCADMINISTRARVERIFICACION=211;

		const int KEYPRCADMINISTRARCAUSARAIZACCION=212;
		const int KEYPRCADMINISTRARGRUPOCAUSARAIZACCION=213;
		const int KEYPRCLISTARACCIONPORCAUSARAIZ=214;
		const int KEYPRCADMINISTRARGRUPOACCIONVERIFICACION=215;
		const int KEYPRCADMINISTRARACCIONVERIFICACION=216;
		const int KEYPRCACTUALIZAESTADOCAUSAACCION=217;
		const int KEYPRCELIMINARVERIFICACION=218;
		const int KEYPRCLSITAVERIFICACIONPORGRUPO=219;
		const int KEYPRCLELIMINAACCIONVERIFICACION=220;
		const int KEYPRCLELIMINASAM=222;
		const int KEYPRCLENVIACORREO=223;
		const int KEYPRCBUSCARAREAGENERALPORCRITERIOOGI =243;

		const int KEYPRCLISTARREPONSABLEPORAREAOGI =244;
		const int KEYPRCINSACTREPONSABLEPORAREAOGI =245;

		const int KEYPRCSAMENVIARPTA =253;
		
		const int KEYPRCBUSQUEDAAREA=59;
		
		const int KEYPRCBUSCARPERSONAINUSUARIO=55;

		const int KEYPRCENVIACORREORESPONSABLEACCION=254;

		const int KEYPRCACTUALIZAVB=256;
		
		const int KEYPRCBUSCARAREAGENERALPORCRITERIOOGIASIG =257;
		
		const int KEYPRCSAMENVIARPTAVERIFICACION=267;
		const int KEYPRCSAMLISTARNOTA=277;

		const int KEYPRCSAMINSACTNOTA=278;
		const int KEYPRCSAMLISTARNOTARECIBE=279;

		const int KEYPRCBUSCARAREA=292;

		const int KEYPRCLISTARVERSIONNORMAISO=311;

		const int KEYPRCLLENARDATOSCUADROESTADISTICO=313;


								
		//const string KEYQIDSAM="IdSAM";

		const string KEYQIDDESTINO="IdDestino";
		const string KEYQIDANEXO="IdAnexo";
		const string KEYQNOMBREFILE="NFile";
		const string KEYQIDTIPOAUDITORIA="IdTipoAU";
		const string KEYQFECHA="Fecha";
		const string KEYQDESCRIPCION="Descrip";
		const string KEYQIDCAUSARAIZ="IdCausaRaiz";
		const string KEYQIDACCION="IdAccion";
		const string KEYQIDTIPOACCION="IdTipoAccion";
		const string KEYQIDRESPONSABLE="IdResp";
		const string KEYQIDACCIONANEXO="IdAccionAnexo";
		const string KEYQIDVERIFICACION="IdVerifica";
		const string KEYQOBSERVACION = "Observa";
		const string KEYQCONFORME = "Conforme";
		const string KEYQIDESTADO = "IdEstado";
		const string KEYQIDESTADOFIN = "IdEstadoFin";

		const string KEYQIGRUPOCRA= "IdGRPCRA";
		const string KEYQLSTCR = "LstCR";
		const string KEYQTIPORST = "TRST";
		const string KEYQGRPACCIONVERIFICA = "IdGRPAV";
		const string KEYQIDACCIONVERIFICACION = "IdAccionVerifica";
		const string KEYQMOTIVOELIMINACION = "MotivoEliminacion";
		const string KEYQIDAREA = "IdArea";
		
		const string KEYQIDUSERRESP="IdUsrRes";
		const string KEYQIDTIPORESP="IdTipRes";

		const string KEYQIDSAMISO = "IdSamISO";
		const string KEYQIDRESPNORMA = "IdUseRespNorma";
		const string KEYQIDUSURECIBE = "IdUseEnvia";
		const string KEYQMETAANUAL = "MetaAnual";

		

		const string KEYQIDSAMNOTA = "IdSamNota";
		const string KEYQIDSAMNOTAPADRE = "IdSamNotaPa";
		const string KEYQIDSAMNOTATEXT= "SamNota";
		const string KEYQIDUSUARIODEST= "IdUsuDst";
		const string KEYQIDUSUARIOSRC= "IdUsuSrc";
		const string KEYQCODSAM="CodSAM";

		 const string KEYQNOMNORMAISO= "NomNorISO";

		const string KEYQNOMUSUARIODEST= "NomUsuDst";
		

		private int IdUsuario
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDUSERRESP]);}
		}
	
		private int IdTipoUsuarioResponsable
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPORESP]);}
		}
		private int IdArea
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDAREA]);}
		}
	

		private string IdAccionVerificacion
		{
			get{return Convert.ToString(Page.Request.Params[KEYQIDACCIONVERIFICACION]);}
		}
		private string IdGrupoAccionVerificacion
		{
			get{return Convert.ToString(Page.Request.Params[KEYQGRPACCIONVERIFICA]);}
		}
		private string LstCR
		{
			get{return Convert.ToString(Page.Request.Params[KEYQLSTCR]);}
		}
		
		private string IdGrupoCausaRaizAccion
		{
				get{return Convert.ToString(Page.Request.Params[KEYQIGRUPOCRA]);}
		}
		private int IdEstado
		{
				get{return Convert.ToInt32(Page.Request.Params[KEYQIDESTADO]);}
		}
		private string OGIRutaLocal
		{
			get{return ConfigurationSettings.AppSettings["RutaLocalOGI"].ToString();}
		}
		private string IdAccion
		{
			get{return Page.Request.Params[KEYQIDACCION];}
		}
		private string IdVerificacion
		{
			get{return Page.Request.Params[KEYQIDVERIFICACION];}
		}		
		private string IdAccionAnexo
		{
			get{return Page.Request.Params[KEYQIDACCIONANEXO];}
		}
		private int IdTipoAccion
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOACCION]);}
		}
		private int IdPersonal
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRESPONSABLE]);}
		}

		private string IdAnexo
		{
			get{return Page.Request.Params[KEYQIDANEXO];}
		}
		private string NombreFile
		{
			get{return Page.Request.Params[KEYQNOMBREFILE];}
		}
		/*private string IdSAM
		{
			get{return Page.Request.Params[KEYQIDSAM];}
		}*/
		
		private string IdDestino
		{
			get{return Page.Request.Params[KEYQIDDESTINO];}
		}
		private int IdTipoAuditoria
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDTIPOAUDITORIA]);}
		}	
		private string IdCausaRaiz
		{
			get{return Page.Request.Params[KEYQIDCAUSARAIZ].ToString();}
		}
		private DateTime Fecha
		{
			
			get{return Convert.ToDateTime(Page.Request.Params[KEYQFECHA]);}
			
			//DateTime.ParseExact(txtFromDate, "g", new CultureInfo("fr-FR"));
		}
		private string Descripcion
		{
			get{return Page.Request.Params[KEYQDESCRIPCION].ToString();}
		}
		private string Observacion
		{
			get{return Page.Request.Params[KEYQOBSERVACION].ToString();}
		}	
		private string MotivoEliminacion
		{
			get{return Page.Request.Params[KEYQMOTIVOELIMINACION].ToString();}
		}

		/*SAM NOTA*/
		public string IdSamISO
		{
			get{return Page.Request.Params[KEYQIDSAMISO].ToString();}
		}

		private int MetaAnual
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQMETAANUAL].ToString());}
		}

		public int IdResponsableNorma
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDRESPNORMA].ToString());}
		}

		public int IdUsuarioRecibeMSG
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDUSURECIBE].ToString());}
		}

		public string IdSamISONota
		{
			get{return Page.Request.Params[KEYQIDSAMNOTA].ToString();}
		}
		public string IdSamISONotaPadre
		{
			get{return Page.Request.Params[KEYQIDSAMNOTAPADRE].ToString();}
		}
		//,@IdSamISO
		public string Nota 
		{
			get{return Page.Request.Params[KEYQIDSAMNOTATEXT].ToString();}
		}

		public string CodigoSAM
		{
			get{return Page.Request.Params[KEYQCODSAM].ToString();}
		}
		public string NombreNormaISO
		{
			get{return Page.Request.Params[KEYQNOMNORMAISO].ToString();}
		}

		

		public int IdUsuarioDestino
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIODEST].ToString());}
		}

		public string NombreUsuarioDestino
		{
			get{return Page.Request.Params[KEYQNOMUSUARIODEST].ToString();}
		}

		public int IdUsuarioOrigen
		{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDUSUARIOSRC].ToString());}
		}
		
		public int IdEstadoFin{
			get{return Convert.ToInt32(Page.Request.Params[KEYQIDESTADOFIN].ToString());}
		}


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				if (Page.Request.Params[PROCESO]!=null)
				{	
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARSAMPT)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.E:
								Helper.GenerarEsquemaXMLTAD((new CSAMDestino()).Eliminar(this.IdDestino));
								break;
						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCBUSCARAREAGENERALPORCRITERIO)
					{
						Helper.AutoBusquedaResultado((new SIMA.Controladoras.General.CArea()).ListarAreaPorNombre(Helper.CriterioBusqueda()));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCBUSCARAREAGENERALPORCRITERIOOGI)
					{
						Helper.AutoBusquedaResultado((new CSAMResponsable()).BuscarAreaParaCtrlOGI(Helper.CriterioBusqueda()));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCBUSCARAREAGENERALPORCRITERIOOGIASIG)
					{
						DataTable dt =  (new CSAMResponsable()).BuscarAreaParaCtrlOGIAsignResponsable(Helper.CriterioBusqueda());
						DataView dv = dt.DefaultView;
						if(dt!=null)
						{
							dv.RowFilter="IdCentroOperativo in (" + (((CNetAccessControl.GetUserIdCentroOperativo()==1)||(CNetAccessControl.GetUserIdCentroOperativo()==2))?"1,2":CNetAccessControl.GetUserIdCentroOperativo().ToString()) +")";
							Helper.AutoBusquedaResultado(Helper.DataViewTODataTable(dv));
							}
						else{
							Helper.AutoBusquedaResultado(dt);
						}

						
						//Helper.AutoBusquedaResultado((new CSAMResponsable()).BuscarAreaParaCtrlOGIAsignResponsable(Helper.CriterioBusqueda()));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCBUSCARAREA)
					{
						DataTable dt =  (new CSAMResponsable()).BuscarAreaDisponible(Helper.CriterioBusqueda());
						Helper.AutoBusquedaResultado(dt);
					}


					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCMANTENIMIENTOANEXO)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.E:

								int IdResult =(new CSAMAnexo()).Eliminar(this.IdAnexo);
								try
								{
									File.Delete(this.OGIRutaLocal + Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora +'_'+ this.NombreFile);
								}
								catch(Exception ex){}
								Helper.GenerarEsquemaXMLTAD(IdResult);
								break;
						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLISTARAUDITORIAS)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMAuditoria()).ListarTodosCombo(this.IdTipoAuditoria));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARCAUSARAIZ)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								SAMCausaRaizBE oSAMCausaRaizBE = new SAMCausaRaizBE();
								oSAMCausaRaizBE.IdCausaRaiz =this.IdCausaRaiz;
								oSAMCausaRaizBE.IdDestino=this.IdDestino;
								oSAMCausaRaizBE.FechaEmision=DateTime.Now;
								oSAMCausaRaizBE.Descripcion=Helper.HttpUtility.HtmlDecode(this.Descripcion);
								Helper.GenerarEsquemaXMLTAD((new CCausaRaiz()).Insertar(oSAMCausaRaizBE));
								break;
							case Enumerados.ModoPagina.E:
								Helper.GenerarEsquemaXMLTAD((new CCausaRaiz()).Eliminar(this.IdCausaRaiz));
								break;
						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCCONSULTARSAMACCION)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMAccion()).ListarTodosGrilla(this.IdCausaRaiz));
					}

					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARACCION)
					{
						SAMAccionBE oSAMAccionBE = new SAMAccionBE();
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								oSAMAccionBE.IdAccion = this.IdAccion;
								//oSAMAccionBE.IdCausaRaiz = this.IdCausaRaiz;
								oSAMAccionBE.IdTipoAccion= this.IdTipoAccion;
								oSAMAccionBE.Descripcion= Helper.HttpUtility.HtmlDecode(this.Descripcion);
								oSAMAccionBE.PlazoEjecucion= this.Fecha;
								oSAMAccionBE.IdPersonal= this.IdPersonal;
								Helper.GenerarEsquemaXMLTAD((new CSAMAccion()).Insertar(oSAMAccionBE));
								break;
							case Enumerados.ModoPagina.M:
								oSAMAccionBE.IdAccion = this.IdAccion;
								oSAMAccionBE.Conforme = Convert.ToInt32(Page.Request.Params[KEYQCONFORME]);
								Helper.GenerarEsquemaXMLTAD((new CSAMAccion()).Modificar(oSAMAccionBE));
								break;
							case Enumerados.ModoPagina.E:
								Helper.GenerarEsquemaXMLTAD((new CSAMAccion()).Eliminar(this.IdAccion));
								break;
						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARCAUSARAIZACCION)
					{
						SAMCausaRaizAccionBE oSAMCausaRaizAccionBE = new SAMCausaRaizAccionBE();
						oSAMCausaRaizAccionBE.IdCausaRaiz = this.IdCausaRaiz;
						oSAMCausaRaizAccionBE.IdAccion=this.IdAccion;
						oSAMCausaRaizAccionBE.IdGrupoCausaRaizAccion = this.IdGrupoCausaRaizAccion;
						oSAMCausaRaizAccionBE.IdEstado = this.IdEstado;
						string Resultado = (new CSAMCausaRaizAccion()).Insertar(oSAMCausaRaizAccionBE);
						Helper.GenerarEsquemaXMLTAD(Resultado);

						//Aqui debe de ir la ruta de envio de correo en el formato especifico
						//SP almacenado OGIuspNTADConsultarDatosAccion
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCENVIACORREORESPONSABLEACCION)
					{
						SAMCausaRaizAccionBE oSAMCausaRaizAccionBE= (SAMCausaRaizAccionBE)(new CSAMCausaRaizAccion()).ObtenerVencimiento( this.IdAccion);

						string HtmlEmail = Helper.Archivo.Leer(Helper.Archivo.RutaArchivoCorreo + "SAMAccionRespon.aspx");
						HtmlEmail = HtmlEmail.Replace("[QUIENENVIA]",CNetAccessControl.GetUserApellidosNombres());
						HtmlEmail = HtmlEmail.Replace("[IMG]", System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString() + CNetAccessControl.GetUserNroDocIdent() + ".jpg");
						
						HtmlEmail = HtmlEmail.Replace("[SAM]",oSAMCausaRaizAccionBE.CodigoSAM);
						HtmlEmail = HtmlEmail.Replace("[FECHA]",oSAMCausaRaizAccionBE.FechaEmisionSAM.ToShortDateString());
						HtmlEmail = HtmlEmail.Replace("[HALLAZGO]",oSAMCausaRaizAccionBE.HallazgoSAM);

						HtmlEmail = HtmlEmail.Replace("[ACCION]",oSAMCausaRaizAccionBE.DescripcionAccion);
						HtmlEmail = HtmlEmail.Replace("[PLAZO]",oSAMCausaRaizAccionBE.FechaPlazo.ToShortDateString());
						if(oSAMCausaRaizAccionBE.Email.Length>0)
						{
							Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"GENERACION DE SAM",oSAMCausaRaizAccionBE.Email,oSAMCausaRaizAccionBE.Email,HtmlEmail,true);
							string enviado = (new CSAMAccion()).ActEnviaEmail(this.IdAccion);
						}
							
						Helper.GenerarEsquemaXMLTAD("1");

					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARACCIONANEXO)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								SAMAccionAnexoBE oSAMAccionAnexoBE = new SAMAccionAnexoBE();
								oSAMAccionAnexoBE.IdAccion = this.IdAccion;
								oSAMAccionAnexoBE.Nombre = this.NombreFile;
								Helper.GenerarEsquemaXMLTAD((new CSAMAccionAnexo()).Insertar(oSAMAccionAnexoBE));
								break;
							case Enumerados.ModoPagina.E:
								Helper.GenerarEsquemaXMLTAD((new CSAMAccionAnexo()).Eliminar(this.IdAccionAnexo));
								break;
							case Enumerados.ModoPagina.C:
								Helper.GenerarEsquemaXMLNTAD((new CSAMAccionAnexo()).ListarTodosGrilla(this.IdAccion));
								break;

						}
					}

					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARSAM)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.M:
								SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = new SolicitudAccionMejoraBE();
								oSolicitudAccionMejoraBE.IdDestino=this.IdDestino;
								oSolicitudAccionMejoraBE.DescripcionAccionInmediata = Helper.HttpUtility.HtmlDecode(this.Descripcion);
								Helper.GenerarEsquemaXMLTAD((new CSolicituddeAcciondeMejora()).Modificar(oSolicitudAccionMejoraBE));
								break;

						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCCONSULTARVALIDACION)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMVerificacion()).ListarTodosGrilla(this.IdAccion));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARVERIFICACION)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								SAMVerificacionBE oSAMVerificacionBE = new SAMVerificacionBE();
								oSAMVerificacionBE.IdVerificacion = this.IdVerificacion;
								oSAMVerificacionBE.Fecha = this.Fecha;
								oSAMVerificacionBE.AccionTomada = Helper.HttpUtility.HtmlDecode(this.Descripcion);
								oSAMVerificacionBE.Observacion = Helper.HttpUtility.HtmlDecode(this.Observacion);
								Helper.GenerarEsquemaXMLTAD((new CSAMVerificacion()).Insertar(oSAMVerificacionBE));
								break;

						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARGRUPOCAUSARAIZACCION)
					{
						Helper.GenerarEsquemaXMLTAD((new CSAMGrupoCausaRaizAccion()).Insertar());
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLISTARACCIONPORCAUSARAIZ)
					{
						DataTable dt = (new CSAMAccion()).ListarAccionesPorVerificar(this.LstCR);
						if(Convert.ToInt32(Page.Request.Params[KEYQTIPORST])==1)
						{
							//Helper.GenerarEsquemaXMLNTAD(Helper.SelectDistinct(dt,"IdGrupoAccionVerificacion","IdEstadoGrupoAV"));
							Helper.GenerarEsquemaXMLNTAD(Helper.SelectDistinct(dt,"IdGrupoAccionVerificacion","IdEstado"));
						}
						else{
							Helper.GenerarEsquemaXMLNTAD(dt);
						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARGRUPOACCIONVERIFICACION)
					{
						Helper.GenerarEsquemaXMLTAD((new CSAMGrupoAccionVerificacion()).Insertar());
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCADMINISTRARACCIONVERIFICACION)
					{
						SAMAccionVerificacionBE oSAMAccionVerificacionBE = new SAMAccionVerificacionBE();
						oSAMAccionVerificacionBE.IdGrupoAccionVerificacion = this.IdGrupoAccionVerificacion;
						oSAMAccionVerificacionBE.IdAccion = this.IdAccion;
						oSAMAccionVerificacionBE.IdVerificacion = this.IdVerificacion;
						Helper.GenerarEsquemaXMLTAD((new CSAMAccionVerificacion()).Insertar(oSAMAccionVerificacionBE));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCACTUALIZAESTADOCAUSAACCION)
					{
						string Id = (new CSAMCausaRaizAccion()).ActualizaEstado(this.IdAccion,this.IdEstado);
						Helper.GenerarEsquemaXMLTAD("1");

						//Helper.GenerarEsquemaXMLTAD((new CSAMAccionVerificacion()).ActualizaEstado(this.IdGrupoAccionVerificacion,this.IdAccion,this.IdEstado));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCELIMINARVERIFICACION)
					{
						Helper.GenerarEsquemaXMLTAD((new CSAMVerificacion()).Eliminar(this.IdVerificacion));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLSITAVERIFICACIONPORGRUPO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMVerificacion()).ListarTodos(this.IdGrupoAccionVerificacion));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLELIMINAACCIONVERIFICACION)
					{
						string Eliminado=(new CSAMAccionVerificacion()).Eliminar(this.IdAccion,this.IdGrupoAccionVerificacion).ToString();
						Helper.GenerarEsquemaXMLTAD("1");
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLELIMINASAM)
					{
						Helper.GenerarEsquemaXMLTAD((new CSolicituddeAcciondeMejora()).Eliminar(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLENVIACORREO)
					{
						SAMDestinoBE oSAMDestinoBE = new SAMDestinoBE();
						oSAMDestinoBE.IdSAM = Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora;
						oSAMDestinoBE.IdDestino = this.IdDestino;
						oSAMDestinoBE.MotivoEliminacion =  Helper.HttpUtility.HtmlDecode(this.MotivoEliminacion);
						Helper.GenerarEsquemaXMLNTAD((new CSAMDestino()).EnviarCorreo(oSAMDestinoBE));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLISTARREPONSABLEPORAREAOGI)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMResponsable()).ListarTodosGrilla(this.IdArea));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCINSACTREPONSABLEPORAREAOGI)
					{
						SAMResponsableBE oSAMResponsableBE = new SAMResponsableBE();
						oSAMResponsableBE.IdArea = this.IdArea;
						oSAMResponsableBE.IdUsuario= this.IdUsuario;
						oSAMResponsableBE.IdEstado=this.IdEstado;
						oSAMResponsableBE.IdTipoResponsable= this.IdTipoUsuarioResponsable;
						Helper.GenerarEsquemaXMLTAD((new CSAMResponsable()).InsAct(oSAMResponsableBE));
					}
					if((Utilitario.Helper.General.Params.IdProceso== KEYPRCSAMENVIARPTA)||(Utilitario.Helper.General.Params.IdProceso== KEYPRCSAMENVIARPTAVERIFICACION))
					{
						string LstEmails ="";
						DataTable dt =(new CSAMDestino()).ListarReponsablexArea(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,this.IdDestino);
						foreach(DataRow dr in dt.Rows)
						{
							LstEmails = LstEmails + dr["CorreoReponsableArea"].ToString()+";";
						}
						LstEmails=((LstEmails.Length>0)?LstEmails.Substring(0,LstEmails.Length-1):LstEmails);
						
						DataTable dtEstado= Helper.SelectDistinct(dt,"IdEstado");
						string NombreEst = ((dtEstado.Rows[0]["IdEstado"].ToString()=="2")?"SUPERADO":"NO SUPERADO");

						SolicitudAccionMejoraBE oSolicitudAccionMejoraBE = (SolicitudAccionMejoraBE)(new CSolicituddeAcciondeMejora()).ListarDetalle(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,0);
						string HtmlEmail = Helper.Archivo.Leer(Helper.Archivo.RutaArchivoCorreo + "SAMCtrlOGIRpt.aspx");
			
						HtmlEmail = HtmlEmail.Replace("[QUIENENVIA]",CNetAccessControl.GetUserApellidosNombres());
						HtmlEmail = HtmlEmail.Replace("[IMG]", System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString() + CNetAccessControl.GetUserNroDocIdent() + ".jpg");
						HtmlEmail = HtmlEmail.Replace("[FECHA]", oSolicitudAccionMejoraBE.FechaEmision.ToShortDateString());
						HtmlEmail = HtmlEmail.Replace("[ACCION]",oSolicitudAccionMejoraBE.NombreTipoAccion);
						HtmlEmail = HtmlEmail.Replace("[DETECTADO]",oSolicitudAccionMejoraBE.NombreDetectadoEn);
						HtmlEmail = HtmlEmail.Replace("[DESCRIPCION]",oSolicitudAccionMejoraBE.DescripcionHallazgo);
						HtmlEmail = HtmlEmail.Replace("[SAM]",oSolicitudAccionMejoraBE.CodigoSAM);
						HtmlEmail = HtmlEmail.Replace("[ESTADO]",NombreEst);
						
						HtmlEmail = HtmlEmail.Replace("[LSNORMA]",(new AdministrarRescepcionSolicitudeAcciondeMejora()).ObtenerLstISOText(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora));

						Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"RESPUESTA DE SAM",LstEmails,HtmlEmail);
						Helper.GenerarEsquemaXMLTAD("1");
						//Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"RESPUESTA DE SAM","erosales@sima.com.pe",HtmlEmail);
						
					}
					
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCBUSCARPERSONAINUSUARIO)
					{
						DataTable dt = (new CSAMResponsable()).BuscarInUsuariosAPersonas(Helper.CriterioBusqueda());
						DataView dv;
						if((dt!=null)&&(dt.Rows.Count>0))
						{
							dv = dt.DefaultView;
							dv.RowFilter="IdEstado=1";
							dt=Helper.DataViewTODataTable(dv);
						}
						
						Helper.AutoBusquedaResultado(dt);
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCACTUALIZAVB)
					{
						Helper.GenerarEsquemaXMLTAD((new CSAMDestino()).ActVistoBueno(Utilitario.Helper.GestionIntegrada.Params.IDSolicitudAccionMejora,this.IdDestino,Convert.ToInt32(Page.Request.Params[KEYQCONFORME]))); 
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCSAMLISTARNOTA)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMNota()).Listar(this.IdSamISO,this.IdResponsableNorma));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCSAMINSACTNOTA)
					{
						Enumerados.ModoPagina oModoPagina =(Enumerados.ModoPagina)System.Enum.Parse(typeof(Enumerados.ModoPagina),Page.Request.Params[Constantes.KEYMODOPAGINA].ToString()) ;
						SAMNotaBE oSAMNotaBE = new SAMNotaBE();
						switch (oModoPagina)
						{
							case Enumerados.ModoPagina.N:
								
								oSAMNotaBE.IdSamISONota = this.IdSamISONota;
								oSAMNotaBE.IdSamISONotaPadre = this.IdSamISONotaPadre;
								oSAMNotaBE.IdSamISO = this.IdSamISO;
								oSAMNotaBE.Nota = this.Nota;
								oSAMNotaBE.IdUsuarioDestino= this.IdUsuarioDestino;
								oSAMNotaBE.IdUsuarioOrigen= this.IdUsuarioOrigen;
								
									
								string HtmlEmail = Helper.Archivo.Leer(Helper.Archivo.RutaArchivoCorreo + "SAMMsgSend.aspx");
								HtmlEmail = HtmlEmail.Replace("[QUIENENVIA]",CNetAccessControl.GetUserApellidosNombres());
								HtmlEmail = HtmlEmail.Replace("[IMG]", System.Configuration.ConfigurationSettings.AppSettings[Utilitario.Constantes.RUTAFOTOSP].ToString() + CNetAccessControl.GetUserNroDocIdent() + ".jpg");
						
								HtmlEmail = HtmlEmail.Replace("[SAM]",this.CodigoSAM);
								HtmlEmail = HtmlEmail.Replace("[FECHA]",DateTime.Now.ToShortDateString() + "  " +DateTime.Now.ToShortTimeString());
								HtmlEmail = HtmlEmail.Replace("[MENSAJE]",oSAMNotaBE.Nota);
								HtmlEmail = HtmlEmail.Replace("[NORMA]",this.NombreNormaISO);

								//Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"GENERACION DE SAM","erosales@sima.com.pe","erosales@sima.com.pe",HtmlEmail,true);
								Helper.EnviarCorreo(CNetAccessControl.GetUserName(),"MSG - SAM" ,this.NombreUsuarioDestino,this.NombreUsuarioDestino,HtmlEmail,true);

								Helper.GenerarEsquemaXMLTAD((new CSAMNota()).InsertarActualiza(oSAMNotaBE) );
								break;
							case Enumerados.ModoPagina.M:
								oSAMNotaBE.IdSamISONota = this.IdSamISONota;
								oSAMNotaBE.IdEstadoFind = this.IdEstadoFin;
								oSAMNotaBE.pIdEstado=this.IdEstado;

								Helper.GenerarEsquemaXMLTAD((new CSAMNota()).ActualizarEst(oSAMNotaBE));
								break;

						}
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCSAMLISTARNOTARECIBE)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMNota()).ListarRecibidos(this.IdSamISO,CNetAccessControl.GetIdUser(),this.IdUsuarioRecibeMSG));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLISTARVERSIONNORMAISO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSAMiso()).ListarVersiones(Utilitario.Helper.GestionIntegrada.Params.IdNormaISO ));
					}
					if(Utilitario.Helper.General.Params.IdProceso== KEYPRCLLENARDATOSCUADROESTADISTICO)
					{
						Helper.GenerarEsquemaXMLNTAD((new CSolicituddeAcciondeMejora()).LlenarDatosCuadroEstadistico(this.MetaAnual));
					}
					
					


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
	}
}
