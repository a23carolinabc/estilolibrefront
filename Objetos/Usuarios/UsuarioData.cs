using EstiloLibreFront.Utils;

namespace EstiloLibreFront.Objetos.Usuarios
{
    public partial class UsuarioData
    {
        public Dtos.UsuarioDTO? Usuario { get; set; }
        public int? iUsuarioAnteriorId { get; set; }
        public int? iUsuarioSiguienteId { get; set; }
        public List<ControlItem>? Idiomas { get; set; }
        public List<Dtos.PermisoAccesoDTO>? PermisosAcceso { get; set; }
        public List<Dtos.GrupoAccesoDTO>? GruposAcceso { get; set; }
    }
}
