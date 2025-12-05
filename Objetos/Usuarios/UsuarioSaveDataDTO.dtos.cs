namespace EstiloLibreFront.Objetos.Usuarios
{
    public partial class UsuarioSaveDataDTO
    {
        public class Dtos
        {
            public class UsuarioDTO
            {
                public int Id { get; set; }
                public string Login { get; set; }
                public string? Contraseña { get; set; }
                public string Nombre { get; set; }
                public string Apellido1 { get; set; }
                public string Apellido2 { get; set; }
                public string CorreoE { get; set; }
                public int IdiomaId { get; set; }
                public bool Activo { get; set; }

                public UsuarioDTO() { }
                public UsuarioDTO(UsuarioData.Dtos.UsuarioDTO usuarioDTO)
                {
                    this.Id = usuarioDTO.Id;
                    this.Login = usuarioDTO.Login;
                    this.Nombre = usuarioDTO.Nombre;
                    this.CorreoE = usuarioDTO.CorreoE;
                    this.Activo = usuarioDTO.Activo;
                    this.Apellido1 = usuarioDTO.Apellido1;
                    this.Apellido2 = usuarioDTO.Apellido2;
                    this.IdiomaId = usuarioDTO.IdiomaId;
                    this.Contraseña = usuarioDTO.Contraseña;
                }               
            }            
        }    
    }
}
