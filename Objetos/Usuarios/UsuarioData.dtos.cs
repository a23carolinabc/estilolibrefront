using EstiloLibreFront.Validaciones;
using System.ComponentModel.DataAnnotations;

namespace EstiloLibreFront.Objetos.Usuarios
{
    public partial class UsuarioData
    {
        public class Dtos
        {
            public class UsuarioDTO
            {
                public int Id { get; set; }
                [CampoObligatorio]
                public string Login { get; set; }
                [Contraseña]
                public string? Contraseña { get; set; }
                [CampoObligatorio]
                public string Nombre { get; set; }
                [CampoObligatorio]
                public string Apellido1 { get; set; }
                public string Apellido2 { get; set; }
                [EmailAddress]
                public string CorreoE { get; set; }
                [IdObligatorio]
                public int IdiomaId { get; set; }
                public bool Activo { get; set; } = true;
            }

            public class GrupoAccesoDTO
            {
                public int Id { get; set; }
                public string Codigo { get; set; }
                public string Descripcion { get; set; }
                public List<int> lstPermisosAccesoIds { get; set; }
                public bool Asignado { get; set; }
            }

            public class PermisoAccesoDTO
            {
                public int Id { get; set; }
                public string Codigo { get; set; }
                public string Nombre { get; set; }
                public string Descripcion { get; set; }
                public bool Asignado { get; set; }
                public bool AsignadoPorPertenecerAGrupo { get; set; }
            }
        }
    }
}
