using EstiloLibreFront.Base;
using EstiloLibreFront.Objetos.Usuarios;
using System.Net.Http.Json;
using System.Text.Json;

namespace EstiloLibreFront.Servicios
{
    public class ServicioUsuarios : ServicioBase
    {
        #region ***** PROPIEDADES *****
        private string _urlSaveData = "Usuarios/savedata";
        private string _urlShowData = "Usuarios/showdata/";
        private string _urlAddNew = "Usuarios/addnew";
        private string _urlDelete = "Usuarios/delete/";
        #endregion

        #region ***** CONSTRUCTORES *****

        public ServicioUsuarios(IHttpClientFactory factoriaClientesHttp, ServicioDatosContexto servicioDatosContexto)
                : base(factoriaClientesHttp, servicioDatosContexto)
        {
        }

        #endregion

        #region ***** MÉTODOS PÚBLICOS *****
               
        public async Task<UsuarioDataRegistro?> AddNew()
        {
            UsuarioDataRegistro? usuarioDataDB;
            HttpResponseMessage respuestaHttp;
            string strDatos;

            usuarioDataDB = new UsuarioDataRegistro();

            //Enviar petición al servidor.
            respuestaHttp = await this._factoriaClientesHttp.CreateClient("API")
                    .GetAsync(_urlAddNew);

            //Comprobar status 200.
            strDatos = this.ProcesarRespuestaTexto<string>(respuestaHttp);

            //Deserializar y devolver respuesta.
            usuarioDataDB = JsonSerializer.Deserialize<UsuarioDataRegistro>(strDatos, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return usuarioDataDB;
        }

        public async Task<UsuarioDataRegistro?> ShowData(int iUsuarioId)
        {
            UsuarioDataRegistro? usuarioDataDB;
            HttpResponseMessage respuestaHttp;
            string strDatos;

            usuarioDataDB = new UsuarioDataRegistro();

            //Enviar petición al servidor.
            respuestaHttp = await this._factoriaClientesHttp.CreateClient("API")
                    .GetAsync(_urlShowData + iUsuarioId);

            //Comprobar status 200.
            strDatos = this.ProcesarRespuestaTexto<string>(respuestaHttp);

            //Deserializar y devolver respuesta.
            usuarioDataDB = JsonSerializer.Deserialize<UsuarioDataRegistro>(strDatos, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return usuarioDataDB;
        }

        public async Task<int> SaveData(UsuarioSaveDataDTO usuario)
        {
            JsonElement datos;
            HttpResponseMessage respuestaHttp;
            int iObjetoId;

            //Serializar a json.
            datos = JsonSerializer.SerializeToElement<UsuarioSaveDataDTO>(usuario);

            //Enviar petición al servidor.
            respuestaHttp = await this._factoriaClientesHttp.CreateClient("API")
                .PostAsJsonAsync(_urlSaveData, datos);

            //Comprobar status 200.
            iObjetoId = this.ProcesarRespuestaTexto<int>(respuestaHttp);

            //Devolver respuesta.
            return iObjetoId;
        }

        public async Task<string> Delete(int idUsuario)
        {
            HttpResponseMessage respuestaHttp;
            string strRespuesta;

            //Enviar petición al servidor.
            respuestaHttp = await this._factoriaClientesHttp.CreateClient("API")
                    .DeleteAsync(_urlDelete + idUsuario);

            //Comprobar status 200.
            strRespuesta = this.ProcesarRespuestaTexto<string>(respuestaHttp);

            //Devolver respuesta.
            return strRespuesta;
        }

        #endregion
    }
}