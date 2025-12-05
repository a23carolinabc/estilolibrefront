using EstiloLibreFront.Base;
using EstiloLibreFront.Objetos.Prendas;
using EstiloLibreFront.Objetos.Usuarios;
using System.Net.Http.Json;
using System.Text.Json;

namespace EstiloLibreFront.Servicios
{
    public class ServicioPrendas : ServicioBase
    {
        #region ***** PROPIEDADES *****
        private string _urlSaveData = "Prendas/savedata";
        private string _urlShowData = "Prendas/showdata/";
        private string _urlAddNew = "Prendas/addnew";
        private string _urlDelete = "Prendas/delete/";
        #endregion

        #region ***** CONSTRUCTORES *****

        public ServicioPrendas(IHttpClientFactory factoriaClientesHttp, ServicioDatosContexto servicioDatosContexto)
                : base(factoriaClientesHttp, servicioDatosContexto)
        {
        }

        #endregion

        #region ***** MÉTODOS PÚBLICOS *****
               
        public async Task<PrendaData?> AddNew()
        {
            PrendaData? prendaData;
            HttpResponseMessage respuestaHttp;
            string strDatos;

            prendaData = new PrendaData();

            //Enviar petición al servidor.
            respuestaHttp = await this._factoriaClientesHttp.CreateClient("API")
                    .GetAsync(_urlAddNew);

            //Comprobar status 200.
            strDatos = this.ProcesarRespuestaTexto<string>(respuestaHttp);

            //Deserializar y devolver respuesta.
            prendaData = JsonSerializer.Deserialize<PrendaData>(strDatos, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return prendaData;
        }
        
        #endregion
    }
}