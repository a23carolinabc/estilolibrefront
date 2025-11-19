using EstiloLibreFront.Base;

namespace EstiloLibreFront.Servicios
{
    public class ServicioLogIn
    {
        #region ***** PROPIEDADES *****

        private readonly ServicioAutentificacion _servicioAutentificacion;
        private ServicioNavegacion _navegacion;

        #endregion

        #region ***** CONSTRUCTOR ***** 

        public ServicioLogIn(
            ServicioNavegacion navigation, 
            ServicioAutentificacion authenticationService)
        {
            this._servicioAutentificacion = authenticationService;
            this._navegacion = navigation;
        }

        #endregion

        #region ***** MÉTODOS PÚBLICOS *****

        public async Task<bool> LogIn(string login, string password)
        {
            try
            {
                await this._servicioAutentificacion.AutentificarAsync(login, password);
                this._navegacion.NavegarA(URLsPantallas.Menu);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                this._navegacion.NavegarA(URLsPantallas.Login); 
                return false;
            }
        }

        public async void LogOut()
        {    
            this._navegacion.NavegarA(URLsPantallas.Login);        
            await this._servicioAutentificacion.QuitarAutentificacionAsync();            
        }

        #endregion
    }
}
